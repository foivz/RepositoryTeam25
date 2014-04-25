using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrApp
{
    public class TehnickiPregled : Vozilo
    {
        public int idTehnickogPregleda;
        public Vozilo vozilo;
        public string datumTehPregleda; //Nemre biti string!!!!!!!!!!!!!1

        public TehnickiPregled(Vozilo vozilo, string datTehPregleda)
        {
            this.vozilo = new Vozilo();
            this.datumTehPregleda = datTehPregleda;
        }//class

        public override void ispisVozila()
        {
            //to do ...
        }

        public void posaljiNaTehPregled()
        {
            //to do ...
        }

        
         
    }//class
}
