using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPi
{
    class TrAppController
    {
        TrAppModel model = new TrAppModel();

        public void dodaj(vozilo vozilo)
        {
             model.dodaj(vozilo);
        }

        public void izmjeni(int voziloId, vozilo novipodaci)
        {
            model.izmjeni(voziloId, novipodaci);
        }

        public void dodaj(zaposlenici zaposlenik)
        {
            model.dodaj(zaposlenik);
        }

        public void izmjeni(int zaposlenikId, zaposlenici zaposlenik)
        {
            model.izmjeni(zaposlenikId, zaposlenik);
        }

        public void obrisi(int voziloId, string podatak)
        {
            model.obrisi(voziloId, podatak);
        }

        public void dodaj(PutniRadniList PTR, radni_sati RS)
        {
            model.dodaj(PTR, RS);
        }
    }
}
