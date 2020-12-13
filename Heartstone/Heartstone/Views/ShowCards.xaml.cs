using Heartstone.Models;
using Heartstone.Repositories;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Heartstone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowCards : ContentPage
    {
        private List<Card> list_all = new List<Card>();
        private List<Card> list_minions = new List<Card>();
        private List<Card> list_weapons = new List<Card>();
        private List<Card> list_spells = new List<Card>();

        private List<Card> list_current = new List<Card>();

        private bool minionsGedrukt = false;
        private bool spellsGedrukt = false;
        private bool weaponsGedrukt = false;
        public ShowCards(string name)
        {
            InitializeComponent();
            SetTitel(name);
            LoadCards(name);
        }

        private async void LoadCards(string name)
        {
            List<Card> list_cards;
            if (name == "Custom Cards")
            {
                list_cards = await HeartstoneRepository.GetCustomCards();
            }
            else
            {
                list_cards = await HeartstoneRepository.GetCardsClass(name);
            }

            foreach (Card item in list_cards)
            {
                //filter alle kaarten die geen artist hebben dus ook geen afbeelding
                if (item.Artist != null)
                {
                    if (item.Type == "Minion")
                    {
                        list_minions.Add(item);
                        list_all.Add(item);
                    }
                    if (item.Type == "Spell")
                    {
                        list_spells.Add(item);
                        list_all.Add(item);
                    }
                    if (item.Type == "Weapon")
                    {
                        list_weapons.Add(item);
                        list_all.Add(item);
                    }
                }
                    
            }
            //sorteer alle kaarten op naam in plaats van mana cost
            list_all = list_all.OrderBy(o => o.Name).ToList();
            list_minions = list_minions.OrderBy(o => o.Name).ToList();
            list_spells = list_spells.OrderBy(o => o.Name).ToList();
            list_weapons = list_weapons.OrderBy(o => o.Name).ToList();

            list_current = list_all;
            lvwCards.ItemsSource = list_all;
        }

        private void SetTitel(string name)
        {
            titel.Text = name;

            switch (name)
            {
                case "Hunter":
                    classcolor.BackgroundColor = Color.FromHex("#016E01");
                    break;

                case "Warrior":
                    classcolor.BackgroundColor = Color.FromHex("#8E1002");
                    break;

                case "Priest":
                    classcolor.BackgroundColor = Color.FromHex("#C7C19F");
                    break;

                case "Mage":
                    classcolor.BackgroundColor = Color.FromHex("#0092AB");
                    break;

                case "Rogue":
                    classcolor.BackgroundColor = Color.FromHex("#4C4D48");
                    break;

                case "Druid":
                    classcolor.BackgroundColor = Color.FromHex("#703606");
                    break;

                case "Shaman":
                    classcolor.BackgroundColor = Color.FromHex("#8E1002");
                    break;

                case "Warlock":
                    classcolor.BackgroundColor = Color.FromHex("#7624AD");
                    break;

                case "Paladin":
                    classcolor.BackgroundColor = Color.FromHex("#AA8F00");
                    break;

                case "Demon Hunter":
                    classcolor.BackgroundColor = Color.FromHex("#A330C9");
                    break;
                case "Custom Cards":
                    classcolor.BackgroundColor = Color.FromHex("#FCD237");
                    break;
                case "Neutral":
                    classcolor.BackgroundColor = Color.LightGray;
                    break;
            }
        }

        private void Minions_Pressed(object sender, EventArgs e)
        {
            //toon enkel de kaarte nmet een bepaald type
            //je kan op dezelfde knop drukken om de filter ongedaan te maken
            //voorbeeld: druk 1 keer op minion voor alle minions te zien
            //druk er een 2de keer op om weer alle kaarten te zien
            if (minionsGedrukt == false)
            {
                minionsGedrukt = true;
                lvwCards.ItemsSource = list_minions;
                Minions.BorderColor = Color.White;
                Spells.BorderColor = Color.FromHex("#FCD237");
                Weapons.BorderColor = Color.FromHex("#FCD237");
                spellsGedrukt = false;
                weaponsGedrukt = false;
                list_current = list_minions;
            }
            else
            {
                minionsGedrukt = false;
                lvwCards.ItemsSource = list_all;
                Minions.BorderColor = Color.FromHex("#FCD237");
                list_current = list_all;
            }
            
        }

        private void Spells_Pressed(object sender, EventArgs e)
        {
            
            if (spellsGedrukt == false)
            {
                spellsGedrukt = true;
                lvwCards.ItemsSource = list_spells;
                Spells.BorderColor = Color.White;
                Minions.BorderColor = Color.FromHex("#FCD237");
                Weapons.BorderColor = Color.FromHex("#FCD237");
                minionsGedrukt = false;
                weaponsGedrukt = false;
                list_current = list_spells;
            }
            else
            {
                spellsGedrukt = false;
                lvwCards.ItemsSource = list_all;
                Spells.BorderColor = Color.FromHex("#FCD237");
                list_current = list_all;
            }

        }

        private void Weapons_Pressed(object sender, EventArgs e)
        {
            if (weaponsGedrukt == false)
            {
                weaponsGedrukt = true;
                lvwCards.ItemsSource = list_weapons;
                Weapons.BorderColor = Color.White;
                Spells.BorderColor = Color.FromHex("#FCD237");
                Minions.BorderColor = Color.FromHex("#FCD237");
                minionsGedrukt = false;
                spellsGedrukt = false;
                list_current = list_weapons;
            }
            else
            {
                weaponsGedrukt = false;
                lvwCards.ItemsSource = list_all;
                Weapons.BorderColor = Color.FromHex("#FCD237");
                list_current = list_all;
            }

        }

        private void Button_Pressed(object sender, EventArgs e)
        {
            //knop terug
            Navigation.PopAsync();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //zoek een kaart met behulp van een deel van de naam(niet hoofdletter gevoelig)
            var searchList = list_current.Where(c => c.Name.ToLower().Contains(searchbar.Text.ToLower()));
            lvwCards.ItemsSource = searchList;
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            Card CardSelected = (Card)lvwCards.SelectedItem;
            Navigation.PushAsync(new CardDetail(CardSelected));
            lvwCards.SelectedItem = null;
        }
    }
}