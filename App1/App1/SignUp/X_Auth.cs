using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Tweetinvi;
using Xamarin.Essentials;

namespace App1.SignUp
{

    public static class X_KEY
    {
        public const string CONSUMER_KEY = "5q0KSssSXuuG0DIavdEwac0ud";
        public const string CONSUMER_SECRET = "PucNtnjNEisf3HjsPYrb6AKmpqNw0j0r6flVgbiNCDDsN8N0Pd";
        public const string ACCESS_TOKEN = "1549756813213827073-3ESS6EBnb0iisoLvigGseS9qFt7GaC";
        public const string ACCESS_TOKEN_SECRET = "XveZHZDBNDwzsy2ntWZDTCJJtzmMBucc2YDp30KEPvYta";
    }


    public struct TwitterAuth
    {
        public string AccessToken;
        public string IdToken;
        public Dictionary<string, string> properties;
    }

}
