using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrApp
{
    public class Vozilo
    {
        public int idVozila;
        public string naziv;
        public int godProizvodnje;
        public string registracija;
        public string datRegistracije;
        public int pocStanjeKm;
        public int nosivost;
        public int servisniIntervalKm;
        public int vrstaVozila;
        
        /// <summary>
        /// Metoda za unos novog vozila u bazu podataka
        /// </summary>
        /// <param name="naziv">Naziv vozila</param>
        /// <param name="godProizvodnje">Godina proizvodnje vozila</param>
        /// <param name="registracija">Registarska oznaka vozila </param>
        /// <param name="datRegistracija">Datum isteka registacije za vozilo</param>
        /// <param name="pocStanjeKm">Početno stanje kilometara vozila</param>
        /// <param name="nosivost">Nosivost vozila u kilogramima</param>
        /// <param name="servisniIntervalKm">Interval nakon kojeg vozilo mora ici na servis(u kilometrima)</param>
        /// <param name="vrstaVozila">Vrsta vozila npr. Osobno Vozilo, Kamion s poluprikolicom...</param>

        public void unosVozila(string naziv, int godProizvodnje, string registracija, string datRegistracije, int pocStanjeKm,
            int nosivost, int servisniIntervalKm, int vrstaVozila)
        {
            this.naziv = naziv;
            this.godProizvodnje = godProizvodnje;
            this.registracija = registracija;
            this.datRegistracije = datRegistracije;
            this.pocStanjeKm = pocStanjeKm;
            this.nosivost = nosivost;
            this.servisniIntervalKm = servisniIntervalKm;
            this.vrstaVozila = vrstaVozila;
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
