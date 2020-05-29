using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlackJackXamarinForms
{
    class Deck
    {
        public List<Card> cards { get; set; } = new List<Card>();

        public Deck()
        {
            CreateDeck();
        }

        private void CreateDeck()
        {
            for (int i = 0; i < 6; i++)
            {
                cards.Add(new Card(2, "Twoc.png"));
                cards.Add(new Card(2, "Twod.png"));
                cards.Add(new Card(2, "Twoh.png"));
                cards.Add(new Card(2, "Twos.png"));
                cards.Add(new Card(3, "Threec.png"));
                cards.Add(new Card(3, "Threed.png"));
                cards.Add(new Card(3, "Threeh.png"));
                cards.Add(new Card(3, "Threes.png"));
                cards.Add(new Card(4, "Fourc.png"));
                cards.Add(new Card(4, "Fourd.png"));
                cards.Add(new Card(4, "Fourh.png"));
                cards.Add(new Card(4, "Fours.png"));
                cards.Add(new Card(5, "Fivec.png"));
                cards.Add(new Card(5, "Fived.png"));
                cards.Add(new Card(5, "Fiveh.png"));
                cards.Add(new Card(5, "Fives.png"));
                cards.Add(new Card(6, "Sixc.png"));
                cards.Add(new Card(6, "Sixd.png"));
                cards.Add(new Card(6, "Sixh.png"));
                cards.Add(new Card(6, "Sixs.png"));
                cards.Add(new Card(7, "Sevenc.png"));
                cards.Add(new Card(7, "Sevend.png"));
                cards.Add(new Card(7, "Sevenh.png"));
                cards.Add(new Card(7, "Sevens.png"));
                cards.Add(new Card(8, "Eightc.png"));
                cards.Add(new Card(8, "Eightd.png"));
                cards.Add(new Card(8, "Eighth.png"));
                cards.Add(new Card(8, "Eights.png"));
                cards.Add(new Card(9, "Ninec.png"));
                cards.Add(new Card(9, "Nined.png"));
                cards.Add(new Card(9, "Nineh.png"));
                cards.Add(new Card(9, "Nines.png"));
                cards.Add(new Card(10, "Tenc.png"));
                cards.Add(new Card(10, "Tend.png"));
                cards.Add(new Card(10, "Tenh.png"));
                cards.Add(new Card(10, "Tens.png"));
                cards.Add(new Card(11, "Ac.png"));
                cards.Add(new Card(11, "Ad.png"));
                cards.Add(new Card(11, "Ah.png"));
                cards.Add(new Card(11, "As.png"));
                cards.Add(new Card(10, "Qc.png"));
                cards.Add(new Card(10, "Qd.png"));
                cards.Add(new Card(10, "Qh.png"));
                cards.Add(new Card(10, "Qs.png"));
                cards.Add(new Card(10, "Jc.png"));
                cards.Add(new Card(10, "Jd.png"));
                cards.Add(new Card(10, "Jh.png"));
                cards.Add(new Card(10, "Js.png"));
                cards.Add(new Card(10, "Kc.png"));
                cards.Add(new Card(10, "Kd.png"));
                cards.Add(new Card(10, "Kh.png"));
                cards.Add(new Card(10, "Ks.png"));                
            }
        }
    }
}
