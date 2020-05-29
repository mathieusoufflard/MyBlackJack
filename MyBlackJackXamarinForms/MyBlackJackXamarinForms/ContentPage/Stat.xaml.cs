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
    public partial class Stat : ContentPage
    {
        public Stat(Playeur playeur)
        {
            InitializeComponent();
            ContentPage(playeur);
        }

        private void ContentPage(Playeur playeur)
        {
            LblName.Text = playeur.Name;
            LblBalance.Text = playeur.TotalMoney.ToString();
        }
    }
}