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
            Test.Text = await HeartstoneRepository.ConvertImgToUrl(base64String);


        }
    }
}