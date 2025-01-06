using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.LOGIN_PAGE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login_page : ContentPage
    {
        public login_page()
        {
            InitializeComponent();
        }

        public void BackMain(object sender , EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        // _____________ HANDLE SIGNUP ______________

        public void Google_SignIn(object sender , EventArgs e)
        {

        }

        public void Facebook_SignIn(object sender, EventArgs e)
        {

        }
    }
}