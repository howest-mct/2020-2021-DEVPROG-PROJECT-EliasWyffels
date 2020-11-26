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

        private bool Minionsgedrukt = false;
        private bool Spellsgedrukt = false;
        private bool Weaponsgedrukt = false;
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
                if (item.artist != null)
                {
                    if (item.type == "Minion")
                    {
                        minions.Add(item);
                        all.Add(item);
                    }
                    if (item.type == "Spell")
                    {
                        spells.Add(item);
                        all.Add(item);
                    }
                    if (item.type == "Weapon")
                    {
                        weapons.Add(item);
                        all.Add(item);
                    }
                }
                    
            }
            all = all.OrderBy(o => o.name).ToList();
            minions = minions.OrderBy(o => o.name).ToList();
            spells = spells.OrderBy(o => o.name).ToList();
            weapons = weapons.OrderBy(o => o.name).ToList();
            currentlist = all;

            var uniqueall = all.DistinctBy(i => i.name);
            lvwCards.ItemsSource = uniqueall;
        }

        private void SetTitel(string name)
        {
            titel.Text = name;

            switch (name.ToLower())
            {
                case "hunter":
                    classcolor.BackgroundColor = Color.FromHex("#016E01");
                    break;

                case "warrior":
                    classcolor.BackgroundColor = Color.FromHex("#8E1002");
                    break;

                case "priest":
                    classcolor.BackgroundColor = Color.FromHex("#C7C19F");
                    break;

                case "mage":
                    classcolor.BackgroundColor = Color.FromHex("#0092AB");
                    break;

                case "rogue":
                    classcolor.BackgroundColor = Color.FromHex("#4C4D48");
                    break;

                case "druid":
                    classcolor.BackgroundColor = Color.FromHex("#703606");
                    break;

                case "shaman":
                    classcolor.BackgroundColor = Color.FromHex("#8E1002");
                    break;

                case "warlock":
                    classcolor.BackgroundColor = Color.FromHex("#7624AD");
                    break;

                case "paladin":
                    classcolor.BackgroundColor = Color.FromHex("#AA8F00");
                    break;

                case "neutral":
                    classcolor.BackgroundColor = Color.LightGray;
                    break;
            }
        }

        private void Minions_Pressed(object sender, EventArgs e)
        {
            if (Minionsgedrukt == false)
            {
                Minionsgedrukt = true;
                var uniqueMinions = minions.DistinctBy(i => i.name);
                lvwCards.ItemsSource = uniqueMinions;
                Minions.BorderColor = Color.White;
                Spells.BorderColor = Color.FromHex("#FCD237");
                Weapons.BorderColor = Color.FromHex("#FCD237");
                Spellsgedrukt = false;
                Weaponsgedrukt = false;
                currentlist = minions;
            }
            else
            {
                Minionsgedrukt = false;
                var uniqueall = all.DistinctBy(i => i.name);
                lvwCards.ItemsSource = uniqueall;
                Minions.BorderColor = Color.FromHex("#FCD237");
                currentlist = all;
            }
            
        }

        private void Spells_Pressed(object sender, EventArgs e)
        {
            if (Spellsgedrukt == false)
            {
                Spellsgedrukt = true;
                var uniqueSpells = spells.DistinctBy(i => i.name);
                lvwCards.ItemsSource = uniqueSpells;
                Spells.BorderColor = Color.White;
                Minions.BorderColor = Color.FromHex("#FCD237");
                Weapons.BorderColor = Color.FromHex("#FCD237");
                Minionsgedrukt = false;
                Weaponsgedrukt = false;
                currentlist = spells;
            }
            else
            {
                Spellsgedrukt = false;
                var uniqueall = all.DistinctBy(i => i.name);
                lvwCards.ItemsSource = uniqueall;
                Spells.BorderColor = Color.FromHex("#FCD237");
                currentlist = all;
            }

        }

        private void Weapons_Pressed(object sender, EventArgs e)
        {
            if (Weaponsgedrukt == false)
            {
                Weaponsgedrukt = true;
                var uniqueWeapons = weapons.DistinctBy(i => i.name);
                lvwCards.ItemsSource = uniqueWeapons;
                Weapons.BorderColor = Color.White;
                Spells.BorderColor = Color.FromHex("#FCD237");
                Minions.BorderColor = Color.FromHex("#FCD237");
                Minionsgedrukt = false;
                Spellsgedrukt = false;
                currentlist = weapons;
            }
            else
            {
                Weaponsgedrukt = false;
                var uniqueall = all.DistinctBy(i => i.name);
                lvwCards.ItemsSource = uniqueall;
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
            var uniquecurrent = currentlist.DistinctBy(i => i.name);
            var searchlist = uniquecurrent.Where(c => c.name.ToLower().Contains(searchbar.Text.ToLower()));
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