using Heartstone.Models;
using Heartstone.Repositories;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Heartstone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCard : ContentPage
    {
        public string base64String { get; set; }
        public AddCard()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#EDA115");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex("#2C2319");
            base64String = "leeg";
            type.SelectedIndex = 0;
            rarity.SelectedIndex = 0;
            playerClass.SelectedIndex = 10;
        }

        private async void preview_Pressed(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                //controleren of het toestel pickPhote wel support
                await DisplayAlert("no upload", "picking a photo is not supported", "ok");
                return;
            }
            //opmzetten van een img naar een base64string en die dan weer weergeven
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;
            var text = file.Path;
            base64String = Convert.ToBase64String(File.ReadAllBytes(file.Path));
            voorbeeldimg.Source = ImageSource.FromStream(() => file.GetStream());
            


        }

        private async void Confirm_Pressed(object sender, EventArgs e)
        {
            bool nameOK = false;
            bool artistOK = false;
            bool costOK = false;
            bool afbeeldingOK = false;
            bool mechanicsOK = false;
            Card card = new Card();
            //geef voorlopig id langer dan 15 omdat alleen de kaarten met een carid langer dan 15 hun afbeelding meekrijgen die we bepaalden anders wordt de afbeelding opgezocht op het internet(zie klasse)
            card.CardId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            if (Name.Text != null && Name.Text != "")
            {
                card.Name = Name.Text;
                nameOK = true;
            }
            else
            {
                Error.Text = "Name field is empty";
                nameOK = false;
            }

            if (artist.Text != null && artist.Text != "")
            {
                card.Artist = artist.Text;
                artistOK = true;
            }
            else
            {
                Error.Text = "Artist field is empty";
                artistOK = false;
            }
            //hier controleren we of de cost wel een nummer is
            int check = 0;
            bool result = int.TryParse(cost.Text,out check);
            if (result == true && cost.Text != null && cost.Text != "")
            {
                card.Cost = cost.Text;
                costOK = true;
            }
            else
            {
                Error.Text = "Manacost is not a number or empty";
                costOK = false;
            }

            card.Type = type.SelectedItem.ToString();

            card.Rarity = rarity.SelectedItem.ToString();

            card.PlayerClass = playerClass.SelectedItem.ToString();

            if (base64String != "leeg")
            {
                afbeeldingOK = true;
            }
            else
            {
                Error.Text = "No image selected";
                afbeeldingOK = false;
            }
            
            if(mechanics.Text != null && mechanics.Text != "")
            {
                List<Mechanic> list_mechanics = new List<Mechanic>();
                List<string> list_mechanicsExamples = new List<string>();
                list_mechanicsExamples.AddRange(new string[] { "battlecry","deathrattle","charge","taunt","devine shield","stealth","enrage","windfury","freeze","silence","spell damage","choose one","combo","overload","discover","lifesteal","poisonous","outcast","rush","secret","silence","adapt","cast when drawn","choose twice","corrupt","counter","dormant","echo","immune","inspire","invoke","magnetic","mega-windfury","overkill","passive","quest","reborn","recruit","sidequest","spellburst","start of game","twinspell","death knnight","jade golem","lackey","piece of c'tun","spare part","can't attack","can't attack heroes","card draw effect","cast spell","copy","deal damage","destroy","disable hero power","discard","elusive","enchant","equip","force attack","forgetfull","gain armor","generate","highlander","increment attribute","joust","mind control effect","modify cost","multiply attribute","no durability loss","permanent","playerbound","put into battlefield","put into hand","refresh mana","remove from deck","replace","restore health","return","set attribute","shuffle into deck","spend mana","summon","transform","transform in hand","unlimited attacks"});
                string[] parts = mechanics.Text.Split(',');
                foreach (string item in parts)
                {
                    if(list_mechanicsExamples.Contains(item.ToLower().Trim()))
                    {
                        Mechanic mechanic = new Mechanic();
                        mechanic.Name = item;
                        list_mechanics.Add(mechanic);
                        mechanicsOK = true;
                    }
                    else
                    {
                        Error.Text = "Mechanic doesn't exist";
                        mechanicsOK = false;
                    }
                }
                card.Mechanics = list_mechanics;
            }
            else
            {
                card.Mechanics = null;
                mechanicsOK = true;
            }
            if (nameOK == true && artistOK == true && costOK == true && afbeeldingOK == true && mechanicsOK == true)
            {
                //pas als alle labels goed zijn gekeurd voer dit uit
                this.IsEnabled = false;
                //omzetten van de base64string(image) naar een link om makkelijker op te slaan
                card.Afbeelding = await HeartstoneRepository.ConvertImgToUrl(base64String);
                await HeartstoneRepository.SendToDatabase(card);
                await Navigation.PushAsync(new FilterPage());
            }
            
        }
    }
}