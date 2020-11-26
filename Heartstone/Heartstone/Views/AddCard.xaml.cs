﻿using Heartstone.Models;
using Heartstone.Repositories;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                await DisplayAlert("no upload", "picking a photo is not supported", "ok");
                return;
            }

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
            Card c = new Card();
            c.cardId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            if (Name.Text != null && Name.Text != "")
            {
                c.name = Name.Text;
                nameOK = true;
            }
            else
            {
                Error.Text = "Name field is empty";
                nameOK = false;
            }

            if (artist.Text != null && artist.Text != "")
            {
                c.artist = artist.Text;
                artistOK = true;
            }
            else
            {
                Error.Text = "Artist field is empty";
                artistOK = false;
            }

            int l = 0;
            bool result = int.TryParse(cost.Text,out l);
            if (result == true && cost.Text != null && cost.Text != "")
            {
                c.cost = cost.Text;
                costOK = true;
            }
            else
            {
                Error.Text = "Manacost is not a number or empty";
                costOK = false;
            }

            c.type = type.SelectedItem.ToString();

            c.rarity = rarity.SelectedItem.ToString();

            c.playerClass = playerClass.SelectedItem.ToString();

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
                List<Mechanic> m = new List<Mechanic>();
                List<string> allmechanics = new List<string>();
                allmechanics.AddRange(new string[] { "battlecry","deathrattle","charge","taunt","devine shield","stealth","enrage","windfury","freeze","silence","spell damage","choose one","combo","overload","discover","lifesteal","poisonous","outcast","rush","secret","silence","adapt","cast when drawn","choose twice","corrupt","counter","dormant","echo","immune","inspire","invoke","magnetic","mega-windfury","overkill","passive","quest","reborn","recruit","sidequest","spellburst","start of game","twinspell","death knnight","jade golem","lackey","piece of c'tun","spare part","can't attack","can't attack heroes","card draw effect","cast spell","copy","deal damage","destroy","disable hero power","discard","elusive","enchant","equip","force attack","forgetfull","gain armor","generate","highlander","increment attribute","joust","mind control effect","modify cost","multiply attribute","no durability loss","permanent","playerbound","put into battlefield","put into hand","refresh mana","remove from deck","replace","restore health","return","set attribute","shuffle into deck","spend mana","summon","transform","transform in hand","unlimited attacks"});
                string[] parts = mechanics.Text.Split(',');
                foreach (string item in parts)
                {
                    if(allmechanics.Contains(item.ToLower().Trim()))
                    {
                        Mechanic i = new Mechanic();
                        i.name = item;
                        m.Add(i);
                        mechanicsOK = true;
                    }
                    else
                    {
                        Error.Text = "Mechanic doesn't exist";
                        mechanicsOK = false;
                    }
                }
                c.mechanics = m;
            }
            if (nameOK == true && artistOK == true && costOK == true && afbeeldingOK == true && mechanicsOK == true)
            {
                c.afbeelding = await HeartstoneRepository.ConvertImgToUrl(base64String);
                await HeartstoneRepository.SendToDatabase(c);
            }
            
        }
    }
}