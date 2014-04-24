using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrApp
{

    public class Zaposlenik
    {
        public int idZaposlenika;
        public string ime;
        public string prezime;
        public string oib;
        public string datZaposlenja;
        public string iban;
        public string brTel;
        public string adresaStan;
        public string datRodjenja;
        public string korIme;
        public string lozinka;
        //
        public int idUloge;
        public string nazivUloge;





     
        /// <summary>
        /// Metoda za unos novog zaposlenika u bazu podataka.
        /// </summary>
        /// <param name="ime"></param>
        /// <param name="prezime"></param>
        /// <param name="oib"></param>
        /// <param name="datZaposlenja"></param>
        /// <param name="iban"></param>
        /// <param name="brTel"></param>
        /// <param name="adresaStan"></param>
        /// <param name="datRodjenja"></param>
        public void unosZaposlenika(string ime, string prezime, string oib, string datZaposlenja,
            string iban, string brTel, string adresaStan, string datRodjenja, string korIme, string lozinka) 
        {
            this.ime = ime;
            this.prezime = prezime;
            this.oib = oib;
            this.datZaposlenja = datZaposlenja;
            this.iban = iban;
            this.brTel = brTel;
            this.adresaStan = adresaStan;
            this.datRodjenja = datRodjenja;
            this.korIme = korIme;
            this.lozinka = lozinka;
            // to do 
        }

        public void brisanjeZaposlenika()
        {
            //to do
        }

        public void izmjenaZaposlenika()
        {
            //to do
        }

        public void ispisZaposlenika()
        {
            //to do
        }

        public void unosUloge( string nazivUloge)
        {
            this.nazivUloge = nazivUloge;
            //to do
        }
    }//class
}
