using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrApp
{
    public class Prijava
    {
        public Zaposlenik korIme;
        public Zaposlenik lozinka;

        public Prijava() 
        {
            korIme = new Zaposlenik();
            lozinka = new Zaposlenik();
        }

        public frmGlavna frmGlavna
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string ispisGreska(string greska)
        {
            //to do ispis u log i korisniku
            return null;
        }



    }//class

}
