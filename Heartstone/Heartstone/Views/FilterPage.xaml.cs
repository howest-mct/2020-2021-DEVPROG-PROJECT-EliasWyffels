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
    public partial class FilterPage : ContentPage
    {
        public FilterPage()
        {
            InitializeComponent();
            test();
        }

        private async void test()
        {
            
            
            
            
            
            
            
            
            
            
        }

        private async void Button_Pressed(object sender, EventArgs e)
        {
            List<Card> hunter = await HeartstoneRepository.GetCardsClass("Hunter");
            await Navigation.PushAsync(new ShowCards(hunterlbl.Text, hunter));
        }

        private async void Button_Pressed_1(object sender, EventArgs e)
        {
            List<Card> warrior = await HeartstoneRepository.GetCardsClass("Warrior");
            await Navigation.PushAsync(new ShowCards(warriorlbl.Text,warrior));
        }

        private async void Button_Pressed_2(object sender, EventArgs e)
        {
            List<Card> rogue = await HeartstoneRepository.GetCardsClass("Rogue");
            await Navigation.PushAsync(new ShowCards(roguelbl.Text,rogue));
        }

        private async void Button_Pressed_3(object sender, EventArgs e)
        {
            List<Card> warlock = await HeartstoneRepository.GetCardsClass("Warlock");
            await Navigation.PushAsync(new ShowCards(warlocklbl.Text,warlock));
        }

        private async void Button_Pressed_4(object sender, EventArgs e)
        {
            List<Card> paladin = await HeartstoneRepository.GetCardsClass("Paladin");
            await Navigation.PushAsync(new ShowCards(paladinlbl.Text,paladin));
        }

        private async void Button_Pressed_5(object sender, EventArgs e)
        {
            List<Card> druid = await HeartstoneRepository.GetCardsClass("Druid");
            await Navigation.PushAsync(new ShowCards(druidlbl.Text,druid));
        }

        private async void Button_Pressed_6(object sender, EventArgs e)
        {
            List<Card> mage = await HeartstoneRepository.GetCardsClass("Mage");
            await Navigation.PushAsync(new ShowCards(magelbl.Text,mage));
        }

        private async void Button_Pressed_7(object sender, EventArgs e)
        {
            List<Card> priest = await HeartstoneRepository.GetCardsClass("Priest");
            await Navigation.PushAsync(new ShowCards(priestlbl.Text,priest));
        }

        private async void Button_Pressed_8(object sender, EventArgs e)
        {
            List<Card> shaman = await HeartstoneRepository.GetCardsClass("Shaman");
            await Navigation.PushAsync(new ShowCards(shamanlbl.Text,shaman));
        }

        private async void Button_Pressed_9(object sender, EventArgs e)
        {
            List<Card> neutral = await HeartstoneRepository.GetCardsClass("Neutral");
            await Navigation.PushAsync(new ShowCards(neutrallbl.Text,neutral));
        }

        private void Button_Pressed_10(object sender, EventArgs e)
        {

        }
    }
}