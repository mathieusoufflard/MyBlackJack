using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Toast;

namespace MyBlackJackXamarinForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            CrossToastPopUp.Current.ShowToastMessage("Bientôt disponible");
        }

        private async void BtnGest_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage(new Playeur ("Non Connecté", 100)));
        }
    }
}