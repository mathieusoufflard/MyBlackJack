using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyBlackJackXamarinForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game : ContentPage
    {
        private Deck deck = new Deck();
        private Playeur playeur;
        private List<Card> BanqueFirstGet = new List<Card>();
        bool PlayeurAddEleven;
        bool BanqueAddEleven;
        public Game(Playeur Theplayer)
        {
            InitializeComponent();
            playeur = Theplayer;
            StartGame();
        }

        private void StartGame()
        {
            if (PlayerHand.Children != null && BanqueHand.Children != null)
            {
                PlayerHand.Children.Clear();
                PlayeurAddEleven = false;
                BanqueAddEleven = false;
                lblBanqueScrore.Text = "0";
                frmBet.IsVisible = false;
                EntryBet.IsVisible = true;
                EntryBet.Text = "";
                EntryBet.Placeholder = "Miser";
                lblBet.Text = "Mise : ";
                btnRest.IsVisible = false;
                btnPick.IsVisible = false;
                EntryBet.IsReadOnly = false;
                lblPlayeurScrore.Text = "0";
                BanqueHand.Children.Clear();
                lblBalance.Text = playeur.TotalMoney.ToString();
                BanqueFirstGet.Clear();
            }
        }

        private void BtnExit_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void EntryBet_Completed(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(EntryBet.Text) <= playeur.TotalMoney && int.Parse(EntryBet.Text) > 0)
                {
                    playeur.TotalMoney = playeur.TotalMoney - int.Parse(EntryBet.Text);
                    lblBalance.Text = playeur.TotalMoney.ToString();
                    EntryBet.IsReadOnly = true;
                    btnExit.IsVisible = false;
                    frmBet.IsVisible = true;
                    FirtGet();
                    lblBet.Text += EntryBet.Text.ToString();
                    EntryBet.IsVisible = false;
                    if (int.Parse(lblPlayeurScrore.Text) == 21)
                        btnRest.IsVisible = true;
                    else if (int.Parse(lblPlayeurScrore.Text) < 21)
                    {
                        btnPick.IsVisible = true;
                        btnRest.IsVisible = true;
                    }
                }
                else
                {
                    await DisplayAlert("Mise invalide", "Impossible de miser une somme superieur a votre solde ou inferieur a 0", "OK");
                    return;
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Mise invalide", "Impossible de miser avec un nombre a virgule", "OK");
                return;
            }
        }

        private void FirtGet()
        {
            int score = int.Parse(lblPlayeurScrore.Text);
            for (int i = 0; i <= 1; i++)
                PlayeurAddEleven = TakeNewCard(lblPlayeurScrore, PlayerHand, PlayeurAddEleven);

            score = int.Parse(lblBanqueScrore.Text);
            for (int i = 0; i <= 1; i++)
            {
                Card picked = PickOne();
                if (i == 0)
                {
                    BanqueHand.Children.Add(new Image { Source = $"BackCard.png" });
                    BanqueFirstGet.Add(picked);
                }
                else
                {
                    BanqueHand.Children.Add(new Image { Source = picked.Path });
                    lblBanqueScrore.Text = picked.Value.ToString();
                    BanqueFirstGet.Add(picked);
                }
            }
        }

        private Card PickOne()
        {
            Random rand = new Random();
            int nb = rand.Next(0, deck.cards.Count());
            Card picked = new Card(deck.cards[nb].Value, deck.cards[nb].Path);
            deck.cards.RemoveAt(nb);
            return picked;
        }

        private bool TakeNewCard(Label label, StackLayout stack, bool ElevenAsAdded)
        {
            int score = int.Parse(label.Text);
            Card picked = PickOne();
            stack.Children.Add(new Image { Source = $"{picked.Path}" });
            if (int.Parse(label.Text) < 21)
            {
                if (picked.Value == 11 && ElevenAsAdded == false)
                {
                    if (score + picked.Value > 21)
                        picked.Value = 1;
                    else
                        ElevenAsAdded = true;
                }
                else if (ElevenAsAdded == true && score + picked.Value > 21)
                {
                    score -= 10;
                    ElevenAsAdded = false;
                    if (picked.Value == 11)
                        picked.Value = 1;
                }
                score += picked.Value;
                label.Text = score.ToString();
            }
            else if (ElevenAsAdded == true)
            {
                ElevenAsAdded = false;
                score -= 10;
                if (picked.Value == 11)
                    score += 1;
                else
                    score += picked.Value;
                label.Text = score.ToString();
            }
            if (int.Parse(lblPlayeurScrore.Text) >= 21)
                btnPick.IsVisible = false;
            return ElevenAsAdded;
        }

        private void BtnPick_Clicked(object sender, EventArgs e)
        {
            PlayeurAddEleven = TakeNewCard(lblPlayeurScrore, PlayerHand, PlayeurAddEleven);
        }
        private void Banqueturn()
        {
            BanqueHand.Children.Clear();
            int score = 0;
            foreach (var item in BanqueFirstGet)
            {
                BanqueHand.Children.Add(new Image { Source = item.Path });
                score += item.Value;
            }
            if (BanqueFirstGet[0].Value == 11 && BanqueFirstGet[1].Value != 11
                || BanqueFirstGet[1].Value == 11 && BanqueFirstGet[0].Value != 11)
                BanqueAddEleven = true;
            else if (BanqueFirstGet[0].Value == 11 && BanqueFirstGet[1].Value == 11)
            {
                BanqueAddEleven = true;
                score -= 10;
            }
            lblBanqueScrore.Text = score.ToString();
            while (int.Parse(lblBanqueScrore.Text) < 17)
                BanqueAddEleven = TakeNewCard(lblBanqueScrore, BanqueHand, BanqueAddEleven);
            FinalScore();
        }

        private async void FinalScore()
        {
            if (playeur.TotalMoney == 0 && int.Parse(lblBanqueScrore.Text) <= 21
                && (int.Parse(lblBanqueScrore.Text) > int.Parse(lblPlayeurScrore.Text)
                || int.Parse(lblBanqueScrore.Text) <= 21 && int.Parse(lblPlayeurScrore.Text) > 21))
            {
                await DisplayAlert("Fond insuffisant", "Votre capital a atin le 0" +
                    "vous pouvez obtenir plus de capital dans le magasin", "Ok");
                await Navigation.PopAsync();
            }
            else if (int.Parse(lblPlayeurScrore.Text) == int.Parse(lblBanqueScrore.Text) ||
                int.Parse(lblPlayeurScrore.Text) > 21 && int.Parse(lblBanqueScrore.Text) > 21)
            {
                DisplaScrore("Equality");
                playeur.TotalMoney += int.Parse(EntryBet.Text);
            }
            else if (int.Parse(lblPlayeurScrore.Text) <= 21 && int.Parse(lblBanqueScrore.Text) < int.Parse(lblPlayeurScrore.Text)
                || int.Parse(lblPlayeurScrore.Text) <= 21 && int.Parse(lblBanqueScrore.Text) > 21)
            {
                DisplaScrore("Win");
                playeur.TotalMoney += int.Parse(EntryBet.Text) + int.Parse(EntryBet.Text);
            }
            else if (int.Parse(lblBanqueScrore.Text) <= 21 && (int.Parse(lblBanqueScrore.Text) > int.Parse(lblPlayeurScrore.Text)
                || int.Parse(lblBanqueScrore.Text) <= 21 && int.Parse(lblPlayeurScrore.Text) > 21))
                DisplaScrore("Lose");
        }

        private async void DisplaScrore(string v)
        {
            bool answer;
            if (v == "Win")
                answer = await DisplayAlert("Félicitations vous avez gagner", "Nouvel partie", "Oui", "Non");
            else if (v == "Lose")
                answer = await DisplayAlert("Vous perder cette manche", "Nouvel partie", "Oui", "Non");
            else
                answer = await DisplayAlert("Égalité", "Nouvel partie", "Oui", "Non");

            if (answer)
                StartGame();
            else
                await Navigation.PopAsync();
        }

        private void BtnRest_Clicked(object sender, EventArgs e)
        {
            btnPick.IsVisible = false;
            btnRest.IsVisible = false;
            Banqueturn();
            btnExit.IsVisible = true;
        }

        protected override bool OnBackButtonPressed()
        {
            if (lblBet.Text != "Mise : ")
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Attention !",
                        "Si vous quitter la table en pleinne partie vous perderez votre mise Etes vous sur de vouloir fair ça ?", "Oui", "Non");
                    if (result) await this.Navigation.PopAsync();
                });
                return true;
            }
            return false;
        }
    }
}