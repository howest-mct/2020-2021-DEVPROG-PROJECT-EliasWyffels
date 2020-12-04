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
        private List<Card> all = new List<Card>();
        private List<Card> minions = new List<Card>();
        private List<Card> weapons = new List<Card>();
        private List<Card> spells = new List<Card>();

        private List<Card> currentlist = new List<Card>();

        private bool minionsgedrukt = false;
        private bool spellsgedrukt = false;
        private bool weaponsgedrukt = false;
        public ShowCards(string name)
        {
            InitializeComponent();
            SetTitel(name);
            LoadCards(name);
        }

        private async void LoadCards(string name)
        {
            List<Card> lijst;
            if (name == "Custom Cards")
            {
                lijst = await HeartstoneRepository.GetCustomCards();
            }
            else
            {
                lijst = await HeartstoneRepository.GetCardsClass(name);
            }
            foreach (Card item in lijst)
            {
                if (item.Artist != null)
                {
                    if (item.Type == "Minion")
                    {
                        minions.Add(item);
                        all.Add(item);
                    }
                    if (item.Type == "Spell")
                    {
                        spells.Add(item);
                        all.Add(item);
                    }
                    if (item.Type == "Weapon")
                    {
                        weapons.Add(item);
                        all.Add(item);
                    }
                }
                    
            }
            all = all.OrderBy(o => o.Name).ToList();
            minions = minions.OrderBy(o => o.Name).ToList();
            spells = spells.OrderBy(o => o.Name).ToList();
            weapons = weapons.OrderBy(o => o.Name).ToList();
            currentlist = all;
            lvwCards.ItemsSource = all;
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

                case "Neutral":
                    classcolor.BackgroundColor = Color.LightGray;
                    break;
            }
        }

        private void Minions_Pressed(object sender, EventArgs e)
        {
            if (minionsgedrukt == false)
            {
                minionsgedrukt = true;
                lvwCards.ItemsSource = minions;
                Minions.BorderColor = Color.White;
                Spells.BorderColor = Color.FromHex("#FCD237");
                Weapons.BorderColor = Color.FromHex("#FCD237");
                spellsgedrukt = false;
                weaponsgedrukt = false;
                currentlist = minions;
            }
            else
            {
                minionsgedrukt = false;
                lvwCards.ItemsSource = all;
                Minions.BorderColor = Color.FromHex("#FCD237");
                currentlist = all;
            }
            
        }

        private void Spells_Pressed(object sender, EventArgs e)
        {
            if (spellsgedrukt == false)
            {
                spellsgedrukt = true;
                lvwCards.ItemsSource = spells;
                Spells.BorderColor = Color.White;
                Minions.BorderColor = Color.FromHex("#FCD237");
                Weapons.BorderColor = Color.FromHex("#FCD237");
                minionsgedrukt = false;
                weaponsgedrukt = false;
                currentlist = spells;
            }
            else
            {
                spellsgedrukt = false;
                lvwCards.ItemsSource = all;
                Spells.BorderColor = Color.FromHex("#FCD237");
                currentlist = all;
            }

        }

        private void Weapons_Pressed(object sender, EventArgs e)
        {
            if (weaponsgedrukt == false)
            {
                weaponsgedrukt = true;
                lvwCards.ItemsSource = weapons;
                Weapons.BorderColor = Color.White;
                Spells.BorderColor = Color.FromHex("#FCD237");
                Minions.BorderColor = Color.FromHex("#FCD237");
                minionsgedrukt = false;
                spellsgedrukt = false;
                currentlist = weapons;
            }
            else
            {
                weaponsgedrukt = false;
                lvwCards.ItemsSource = all;
                Weapons.BorderColor = Color.FromHex("#FCD237");
                currentlist = all;
            }

        }

        private void Button_Pressed(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchlist = currentlist.Where(c => c.Name.ToLower().Contains(searchbar.Text.ToLower()));
            lvwCards.ItemsSource = searchlist;
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            Card CardSelected = (Card)lvwCards.SelectedItem;
            Navigation.PushAsync(new CardDetail(CardSelected));
            lvwCards.SelectedItem = null;
        }
    }
}