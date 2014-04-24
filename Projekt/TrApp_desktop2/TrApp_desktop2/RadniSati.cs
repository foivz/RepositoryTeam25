using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrApp
{
    public class RadniSati
    {
        public int brSati;
        public Zaposlenik zaposlenik;
        public PutniRadniList putRadList;

        public void unosRadnihSati(int brSati, Zaposlenik zaposlenik, PutniRadniList putRadList)
        {
            this.brSati = brSati;
            this.zaposlenik = new Zaposlenik();
            this.putRadList = new PutniRadniList();
            //to do;
        }

        public void azuriranjeRadnihSati()
        {
            //to do;
        }

        public void obracunRadnihSati() 
        {
            //to do;
        }

        public void ispisRadnihSati()
        {
            //to do
        }
    }
}
