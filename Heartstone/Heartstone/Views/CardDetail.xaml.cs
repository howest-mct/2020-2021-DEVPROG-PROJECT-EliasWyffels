using Heartstone.Models;
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
    public partial class CardDetail : ContentPage
    {
        public CardDetail(Card cardSelected)
        {
            InitializeComponent();
            SetNavColor(cardSelected);
            SetImg(cardSelected);
            SetLabels(cardSelected);
        }

        private void SetLabels(Card cardSelected)
        {
            if (cardSelected.mechanics != null)
            {
                string stringmechanics = "";
                foreach (Mechanic item in cardSelected.mechanics)
                {
                    stringmechanics = stringmechanics + "," + item.name;
                }
                stringmechanics = stringmechanics.Substring(1);
                mechanics.Text = stringmechanics;
            }
            else
            {
                mechanics.Text = "No mechanics";
            }
            type.Text = cardSelected.type;
            artist.Text = cardSelected.artist;
        }

        private void SetImg(Card cardSelected)
        {
            CardImg.Source = cardSelected.afbeelding;
        }

        private void SetNavColor(Card cardSelected)
        {
            switch (cardSelected.playerClass.ToLower())
            {
                case "hunter":
                    ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#016E01");
                    break;

                case "warrior":
                    ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#8E1002");
                    break;

                case "priest":
                    ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#C7C19F");
                    break;

                case "mage":
                    ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#0092AB");
                    break;

                case "rogue":
                    ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#4C4D48");
                    break;

                case "druid":
                    ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#703606");
                    break;

                case "shaman":
                    ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#8E1002");
                    break;

                case "warlock":
                    ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#7624AD");
                    break;

                case "paladin":
                    ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#AA8F00");
                    break;

                case "demon hunter":
                    ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#A330C9");
                    break;

                case "neutral":
                    ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.LightGray;
                    break;
            }
        }
    }
}