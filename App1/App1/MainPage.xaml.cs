using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Xamarin.Essentials;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // ___________ HANDLE EVENT____________
        // LOGIN 

        public void SignIn(object sender , EventArgs e)
        {
            Navigation.PushAsync(new LOGIN_PAGE.login_page());
        }

        public void SignUp(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SIGNUP_PAGE.signup_page());
        }
        
        public async Task AuthenticateSpotify()
        {
            string clientId = "11edc94d8b1a44cb97c24215906954dc";
            string redirectUri = "myapp://callback";
            string scopes = "user-read-playback-state"; // Add desired scopes
            string authUrl = $"https://accounts.spotify.com/authorize?client_id={clientId}&response_type=code&redirect_uri={redirectUri}&scope={scopes}";
            await Browser.OpenAsync(authUrl , BrowserLaunchMode.SystemPreferred);
        }

      
        public async void SpotifyLogin(object sender , EventArgs e)
        {
            await AuthenticateSpotify();
        }

    }
}
