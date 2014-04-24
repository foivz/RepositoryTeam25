using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrApp
{
    public class TehnickiPregled : Vozilo //tu nasljedjue vozilo zbog metode ispis vozila
    {
        public int idTehnickogPregleda;
        public Vozilo vozilo;
        public string datumTehPregleda; //Nemre biti string!!!!!!!!!!!!!1

        public override void ispisVozila()
        {
            //to do ...
        }

        public void posaljiNaTehPregled(Vozilo vozilo, string datTehPregleda)
        {
            this.vozilo = new Vozilo();
            this.datumTehPregleda = datTehPregleda;
            //to do ...
        } 
    }//class
}
