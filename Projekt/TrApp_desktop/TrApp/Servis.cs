using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrApp
{
    public class Servis : Vozilo
    {
        public int idServisa;
        public int prijedjeniKm;
        public string opis;
        public string datumServisa;
        Vozilo vozilo;

        public Servis(Vozilo vozilo, int prijedjeniKm, string opis, string datumServisa) //<---ovo je upitno dali radi
        {
            this.vozilo = new Vozilo();
            this.prijedjeniKm = prijedjeniKm;
            this.opis = opis;
            this.datumServisa = datumServisa;
            
        }//constr
        /// <summary>
        /// Ispis vozila koje treba poslazi na servis, ovisno o servisnom intervalu.
        /// ++ cijelokupna logika za filtiranje vozila prema servisnom intervalu.
        /// </summary>
        public override void ispisVozila()
        {
            //to do ...
        }

        public void posaljiNaServis()
        {
            // to do 
        }

        
       

        
    }//class
}
