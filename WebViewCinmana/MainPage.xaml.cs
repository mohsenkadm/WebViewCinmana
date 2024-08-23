using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WebViewCinmana
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            img1.Source = new UriImageSource
            {
                Uri = new Uri("https://soft31.com/000.gif"),
                CachingEnabled = false,
                CacheValidity = TimeSpan.FromDays(5)
            };
            DependencyService.Get<IDeviceSpecificService>().ClearCookies();
        }

        protected override void OnAppearing()
        {
            Task.Run(async () => await LoadPopup());
            base.OnAppearing();
        }

        #region LoadPopup
        private async Task LoadPopup()
        {
            try
            {
                string apiUrl = "https://api.cdnbitly.com/";

                try
                {
                    var client = new HttpClient();
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        // Deserialize the JSON into an object
                        var apiData = JsonConvert.DeserializeObject<ApiData>(json);
                        if (apiData.show_box == true)
                        {
                            var dailog = new PopupImage(apiData);
                            await Navigation.PushPopupAsync(dailog, false);
                        }
                    }

                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion

        private async void Button_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new WebView(), true);
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://cdnbitly.com/baner", new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredToolbarColor = Color.FromHex("4F92C9"),
                PreferredControlColor = Color.Violet,
            });
        }

    }
}
