using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrApp
{
    public class PutniRadniList  
    {
        public int idPutRadList;
        public float kilometraza;
        public string pocetakVoznje; //vrijeme pocetka
        public string krajVoznje; // vrijeme kraja voznje
        public string mjestoUtovara;
        public string mjestoIstovara;
        // Vezano za tankiranje
        public int idTankiranja;
        public int vrstaGoriva;
        public Zaposlenik zaposlenik;
        public string datumTankiranja;
        public float kolicinaGoriva;


        
        public void unosPutRadLista(float kilometraza, string pocetakVoznje, string krajVoznje, string mjestoUtovara, string mjestoIstovara)
        {
            this.kilometraza = kilometraza;
            this.pocetakVoznje = pocetakVoznje;
            this.krajVoznje = krajVoznje;
            this.mjestoIstovara = mjestoIstovara;
            this.mjestoUtovara = mjestoUtovara;
            //to do;
        }

        public void pregledPutRadLista()
        {
            //to do;
        }

        public void azuriranjePutRadLista()
        {
            //to do;
        }
        public void unosTankiranja(int vrstaGoriva, Zaposlenik zaposlenik, int idPutRadList, string datumTankiranja, float kolicinaGoriva)
        {
            this.vrstaGoriva = vrstaGoriva;
            this.zaposlenik = new Zaposlenik();
            this.idPutRadList = idPutRadList;
            this.datumTankiranja = datumTankiranja;
            this.kolicinaGoriva = kolicinaGoriva;
            // to do
        }

    }
}
