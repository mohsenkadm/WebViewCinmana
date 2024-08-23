using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebViewCinmana
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public partial class PopupImage : PopupPage
    {
        ApiData data1;
        public PopupImage(ApiData data)
        {
            InitializeComponent();
            data1 = data;
            buttonname.Text = data.button_name;
            boxtext.Text = data.box_text;
            boxtitle.Text = data.box_title;
            stack.TranslationY = 600;
            stack.TranslateTo(0, 0, 700, Easing.Linear);

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (data1.button_url.Trim().Length > 0)
                await Browser.OpenAsync(data1.button_url, new BrowserLaunchOptions
                {
                    LaunchMode = BrowserLaunchMode.SystemPreferred,
                    TitleMode = BrowserTitleMode.Show,
                    PreferredToolbarColor = Color.FromHex("4F92C9"),
                    PreferredControlColor = Color.Violet,
                });
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }
    }
}