using ProjectHeartstone.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectHeartstone
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FilterPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
