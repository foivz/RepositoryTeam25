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

        public void dodaj(PutniRadniList PTR, List<radni_sati> RS)
        {
            try
            {
                model.dodaj(PTR);
                PutniRadniList PTRId = new PutniRadniList();
                PTRId = model.dohvatiIdPTR(PTR).First<PutniRadniList>();
                RS.ElementAt<radni_sati>(0).putni_radni_list = PTRId.id_putnog_radnog_lista;
                model.dodaj(RS.ElementAt<radni_sati>(0));

                if (RS.Count() == 2)
                {
                    RS.ElementAt<radni_sati>(1).putni_radni_list = PTRId.id_putnog_radnog_lista;
                    model.dodaj(RS.ElementAt<radni_sati>(1));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return;
        }

        /// <summary>
        /// Metoda za ispis vozila koja idu na servis. U while petlji u prvom uvijetu pregledava se ima li duplikata vozila u listi, ako ima prikazuje se zadnje vozilo s najvecim ID-om,
        /// a ostala se brisu iz liste (ne i iz baze podataka).
        /// </summary>
        /// <returns></returns>
        public List<VozilaServis> dohvatiRazlikuKm()
        {
            List<VozilaServis> razlika = new List<VozilaServis>();
            razlika = model.dohvatiVozilaServis();
            int index = 0;
            while (index < razlika.Count - 1)
            {
                if (razlika[index].id_vozilo == razlika[index + 1].id_vozilo)
                    razlika.RemoveAt(index);
                else index++;
            }
            foreach (VozilaServis i in razlika)
            {
                i.razlika_km = i.trenutno_stanje_km - i.stanje_na_zadnjem_servisu;    
            }
            return razlika;
        }

        /// <summary>
        /// Vraća listu vozila i datume kad trebaju na registraciju
        /// </summary>
        /// <returns>Lista vozila</returns>
        public List<VozilaRegistracija> vozilaRegistracija()
        {
            DateTime trenutna_godina = DateTime.Now;
            List<VozilaRegistracija> listReg = model.dohvatVozila();
            foreach (VozilaRegistracija i in listReg)
            {
                if (trenutna_godina.Year - i.godina_proizvodnje <= 2)
                {
                    i.sljedeca_registracija = i.posljednja_registracija.AddYears(1);
                }
                else if ((trenutna_godina.Year - i.godina_proizvodnje > 2) && (trenutna_godina.Year - i.godina_proizvodnje <= 5))
                {
                    i.sljedeca_registracija = i.posljednja_registracija.AddMonths(6);
                }
                else
                {
                    i.sljedeca_registracija = i.posljednja_registracija.AddMonths(4);
                }
            }
            return listReg.OrderByDescending(o => o.sljedeca_registracija).ToList();
        }

        /// <summary>
        /// Metoda za filtiranje registracija. (U sljedećem tjednu, mjesecu)
        /// </summary>
        /// <param name="podatak"></param>
        /// <returns>Listu vozila</returns>
        public List<VozilaRegistracija> filtriraneRegistracije(string podatak)
        {
            DateTime rok = new DateTime();
            DateTime sad = new DateTime();
            List<VozilaRegistracija> filtReg = new List<VozilaRegistracija>();

            if (podatak == "tjedan")
            {
                rok = DateTime.Now.AddDays(7);
                sad = DateTime.Now;

            }
            else if (podatak == "mjesec")
            {
                rok = DateTime.Now.AddMonths(1);
                sad = DateTime.Now;
            }
            foreach (VozilaRegistracija i in vozilaRegistracija())
            {
                if (i.sljedeca_registracija > sad && i.sljedeca_registracija < rok)
                {
                    filtReg.Add(i);
                }

            }
            return filtReg.ToList();
        }

        /// <summary>
        /// Metoda za filtiranje godišnjih odmora prema odabranom datumu sa kalendara.
        /// </summary>
        /// <param name="datum">daum po kojem se filtira</param>
        /// <returns>Listu godišnjih odmora na zadani datum</returns>
        public List<GodisnjiOdmor> godisnjiOdmorNaDatum(DateTime datum)
        {
            List<GodisnjiOdmor> filtrirana = new List<GodisnjiOdmor>();
            foreach (GodisnjiOdmor i in model.dohvatiGodisnjiOdmor("see"))
            {
                if (datum >= i.pocetak_godisnjeg && datum <= i.kraj_godisnjeg)
                {
                    filtrirana.Add(i);
                }
            }
            return filtrirana;
        }

        public List<GodisnjiOdmor> filtiranjeGO(string podatak)
        {
            List<GodisnjiOdmor> filtirana = new List<GodisnjiOdmor>();
            DateTime danas = DateTime.Now;

            if (podatak == "tjedan")
            {
                foreach (GodisnjiOdmor i in model.dohvatiGodisnjiOdmor("see"))
                {
                    if ((i.pocetak_godisnjeg >= danas && i.pocetak_godisnjeg <= danas.AddDays(7)) || (i.kraj_godisnjeg >=danas && i.kraj_godisnjeg <= danas.AddDays(7)))
                    {
                        filtirana.Add(i);
                    }
                }
                
            }
            else if(podatak == "mjesec")
            {
                foreach (GodisnjiOdmor i in model.dohvatiGodisnjiOdmor("see"))
                {
                    if ((i.pocetak_godisnjeg >= danas && i.pocetak_godisnjeg <= danas.AddMonths(1)) || (i.kraj_godisnjeg >= danas && i.kraj_godisnjeg <= danas.AddMonths(1)))
                    {
                        filtirana.Add(i);
                    }
                }
                
            }
            return filtirana;
        }
    }
}
