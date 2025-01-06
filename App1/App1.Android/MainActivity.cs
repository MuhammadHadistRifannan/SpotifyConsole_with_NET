using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Content;

using Newtonsoft.Json;
using System.Net.Http.Headers;


using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;

namespace App1.Droid
{
    [Activity(Label = "App1", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            var uri = intent.Data?.ToString();
            if (!string.IsNullOrEmpty(uri) && uri.StartsWith("myapp://callback"))
            {
                var code = uri.Split("code=")[1].Split('&')[0];
                // Process the authorization code
                string token = GetAccessTokenAsync(code).Result;
                string userProfile = GetUserProfileAsync(token).Result;

                
            }
        }

        public async Task<string> GetAccessTokenAsync(string code)
        {
            string clientId = "11edc94d8b1a44cb97c24215906954dc";
            string clientSecret = "bdc76ed2cabc42c8baa36990a28bcf5c";
            string redirectUri = "myapp://callback";

            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
            new KeyValuePair<string, string>("grant_type", "authorization_code"),
            new KeyValuePair<string, string>("code", code),
            new KeyValuePair<string, string>("redirect_uri", redirectUri),
            new KeyValuePair<string, string>("client_id", clientId),
            new KeyValuePair<string, string>("client_secret", clientSecret)
        });

                var response = await client.PostAsync("https://accounts.spotify.com/api/token", content);
                var responseString = await response.Content.ReadAsStringAsync();

                var tokenData = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);
                return tokenData["access_token"];
            }
        }

        public async Task<string> GetUserProfileAsync(string accessToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await client.GetAsync("https://api.spotify.com/v1/me");
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}