using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrApp
{
    public class Vozilo
    {
        public int idVozila = 0;
        public string naziv;
        public int godProizvodnje;
        public string registracija;
        public string datRegistracije;
        public int pocStanjeKm;
        public int nosivost;
        public int servisniIntervalKm;
        


        /// <summary>
        ///     Konstruktor unutar kojeg se postavljaju unesene vrijednosti vozila
        /// </summary>
        /// <param name="naziv">Naziv vozila</param>
        /// <param name="godProizvodnje">Godina proizvodnje vozila</param>
        /// <param name="registracija">Registarska oznaka vozila </param>
        /// <param name="datRegistracija">Datum isteka registacije za vozilo</param>
        /// <param name="pocStanjeKm">Početno stanje kilometara vozila</param>
        /// <param name="nosivost">Nosivost vozila u kilogramima</param>
        /// <param name="servisniIntervalKm">Interval nakon kojeg vozilo mora ici na servis(u kilometrima)</param>
        public Vozilo(string naziv, int godProizvodnje, string registracija, string datRegistracije, int pocStanjeKm,
            int nosivost, int servisniIntervalKm ) 
        {
            this.naziv = naziv;
            this.godProizvodnje = godProizvodnje;
            this.registracija = registracija;
            this.datRegistracije = datRegistracije;
            this.pocStanjeKm = pocStanjeKm;
            this.nosivost = nosivost;
            this.servisniIntervalKm = servisniIntervalKm;
            
        }//constr

        public Vozilo()
        { 
            //to do nothing!
        }

        public void unosVozila()
        {
            //Poziv metode za spajanje na bazu i unos podataka!!!11
        }
        public void brisanjeVozila()
        {
            //to do
        }

        public void izmjenaVozila()
        {
            //izmjenjuje osnovne podatke vozila npr. izmjena registracije
        }

        public virtual void  ispisVozila()
        {
            //Nešto što dohvaća podatke iz baze i vraća ih nekom dijelu forme
        }

        
        
    }//class Vozilo
}
