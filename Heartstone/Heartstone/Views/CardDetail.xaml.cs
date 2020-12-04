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
            titel.Text = cardSelected.Name;
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex(cardSelected.Color);
            SetLabels(cardSelected);
        }

        private void SetLabels(Card cardSelected)
        {
            
            if (cardSelected.Mechanics != null)
            {
                string stringmechanics = "";
                foreach (Mechanic item in cardSelected.Mechanics)
                {
                    stringmechanics = stringmechanics + "," + item.Name;
                }
                stringmechanics = stringmechanics.Substring(1);
                mechanics.Text = stringmechanics;
            }
            else
            {
                mechanics.Text = "No mechanics";
            }
            type.Text = cardSelected.Type;
            rarity.Text = cardSelected.Rarity;
            artist.Text = cardSelected.Artist;
            playerclass.Text = cardSelected.PlayerClass;
            CardImg.Source = cardSelected.Afbeelding;
        }
    }
}