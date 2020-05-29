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
    public partial class GetMoney : ContentPage
    {
        public Playeur Playeur;
        public GetMoney(Playeur playeur)
        {
            Playeur = playeur;
            InitializeComponent();
        }

        private void BtnAdd100_Clicked(object sender, EventArgs e)
        {
            if (Playeur.TotalMoney == 0)
            {
                Playeur.TotalMoney += 100;
                DisplayAlert("", "Votre solde est de nouveau à 100", "OK");
            }
            else
                DisplayAlert("Erreur", "Non autoriser avec un solde supérieur à 0", "OK");
        }
    }
}