using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrApp
{
    public class GodisnjiOdmor
    {
        public int idGodOdmora;
        public Zaposlenik zaposlenik;
        public string pocGodOdmora;
        public string krajGodOdmora;

        public GodisnjiOdmor()
        {
            zaposlenik = new Zaposlenik();
        }

        public void unosGodOdmora(Zaposlenik zaposlenik, string pocGodOdmora, string krajGodOdmora)
        {
            this.zaposlenik = zaposlenik;
            this.pocGodOdmora = pocGodOdmora;
            this.krajGodOdmora = krajGodOdmora;
        }

        public void pregledGodOdmora()
        {
            //to do
        }

        public void azuriranjeGodOdmora()
        {
            // to do
        }
    
        
    }
}
