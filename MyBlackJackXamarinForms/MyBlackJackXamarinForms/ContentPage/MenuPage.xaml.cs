using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyBlackJackXamarinForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public Playeur playeur;
        public MenuPage(Playeur thePlayeur)
        {
            playeur = thePlayeur;
            InitializeComponent();
            ContentPage();
        }

        private void ContentPage()
        {
            LblPlayeur.Text = "NON CONNECTEE";
        }

        private async void BtnRules_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Rules());
        }

        private void BtnDifficulty_Clicked(object sender, EventArgs e)
        {
            if (BtnDifficulty.Text == "DIFFICULTER : CLIQUER POUR CHANGER" || BtnDifficulty.Text == "DIFFICULTER : DIFFICILE")
                BtnDifficulty.Text = "DIFFICULTER : FACILE";
            else if (BtnDifficulty.Text == "DIFFICULTER : FACILE")
                BtnDifficulty.Text = "DIFFICULTER : Moyen";
            else
                BtnDifficulty.Text = "DIFFICULTER : DIFFICILE";
        }

        private async void BtnPlay_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Game(playeur));
        }

        private async void BtnStat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Stat(playeur));
        }

        private async void BtnGetMoney_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetMoney(playeur));
        }
    }
}