using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlackJackXamarinForms
{
    public class Playeur
    {
        public string Name { get; }
        public int TotalMoney { get; set; }
        
        public Playeur(string name, int money)
        {
            Name = name;
            TotalMoney = money;
        }
    }
}
