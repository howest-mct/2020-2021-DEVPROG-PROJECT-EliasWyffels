using Heartstone.Models;
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
        public AddCard()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#EDA115");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex("#2C2319");
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
            var base64String = Convert.ToBase64String(File.ReadAllBytes(file.Path));
            voorbeeldimg.Source = ImageSource.FromStream(() => file.GetStream());
            var test = await HeartstoneRepository.ConvertImgToUrl(base64String);


        }

        private void Confirm_Pressed(object sender, EventArgs e)
        {
            var test = playerClass.SelectedItem.ToString();
        }
    }
}