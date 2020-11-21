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
    public partial class FilterPage : ContentPage
    {
        public FilterPage()
        {
            InitializeComponent();
        }

        private void Button_Pressed(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShowCards(hunterlbl.Text.ToLower()));
        }

        private void Button_Pressed_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShowCards(warriorlbl.Text.ToLower()));
        }

        private void Button_Pressed_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShowCards(roguelbl.Text.ToLower()));
        }

        private void Button_Pressed_3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShowCards(warriorlbl.Text.ToLower()));
        }

        private void Button_Pressed_4(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShowCards(paladinlbl.Text.ToLower()));
        }

        private void Button_Pressed_5(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShowCards(druidlbl.Text.ToLower()));
        }

        private void Button_Pressed_6(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShowCards(magelbl.Text.ToLower()));
        }

        private void Button_Pressed_7(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShowCards(priestlbl.Text.ToLower()));
        }

        private void Button_Pressed_8(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShowCards(shamanlbl.Text.ToLower()));
        }

        private void Button_Pressed_9(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShowCards(neutrallbl.Text.ToLower()));
        }

        private void Button_Pressed_10(object sender, EventArgs e)
        {

        }
    }
}