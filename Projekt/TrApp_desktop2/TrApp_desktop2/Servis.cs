using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrApp
{
    public class Servis : Vozilo //tu nasljedjue vozilo zbog metode ispis vozila
    {
        public int idServisa;
        public int prijedjeniKm;
        public string opis;
        public string datumServisa;
        Vozilo vozilo;
 
        public override void ispisVozila()
        {
            //to do ...
        }

        public void posaljiNaServis(int prijedjeniKm, string opis, string datumServisa, Vozilo vozilo)
        {
            this.prijedjeniKm = prijedjeniKm;
            this.opis = opis;
            this.datumServisa = datumServisa;
            this.vozilo = vozilo;
            // to do 
        }
    }//class
}
