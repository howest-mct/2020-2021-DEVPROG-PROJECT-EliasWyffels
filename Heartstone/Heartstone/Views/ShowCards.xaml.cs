using Heartstone.Models;
using Heartstone.Repositories;
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
        public ShowCards(string name)
        {
            InitializeComponent();
            SetTitel(name);
            LoadCards(name);
        }

        private async void LoadCards(string name)
        {
            lvwCards.ItemsSource = await HeartstoneRepository.GetCardsClass(name);
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
    }
}