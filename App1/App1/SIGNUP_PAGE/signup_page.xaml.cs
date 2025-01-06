using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.SIGNUP_PAGE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class signup_page : ContentPage
    {
        public signup_page()
        {
            InitializeComponent();
        }

        public void ChangePage(Page page)
        {
            Navigation.PushAsync(page);
        }

        public void DirectLoginPage(object sender , EventArgs e)
        {
            ChangePage(new LOGIN_PAGE.login_page());
        }
    }
}