﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPi
{
    class TrAppController
    {
        TrAppModel model = new TrAppModel();

        /// <summary>
        /// Metoda koja sprema novo vozilo u bazu podataka
        /// </summary>
        /// <param name="vozilo">Objekt klase vozilo</param>
        public void dodaj(vozilo vozilo)
        {
             model.dodaj(vozilo);
        }

        /// <summary>
        /// Metoda koja pohranjuje izmijenjene podatke o vozilu u bazu podataka
        /// </summary>
        /// <param name="voziloId">ID vozila čiji se podaci mijenjaju</param>
        /// <param name="novipodaci">Objekt klase vozilo koji sadrži izmijenjene podatke o vozilu</param>
        public void izmjeni(int voziloId, vozilo novipodaci)
        {
            model.izmjeni(voziloId, novipodaci);
        }

        /// <summary>
        /// Metoda koja sprema novog vozača u bazu podataka
        /// </summary>
        /// <param name="zaposlenik">Objekt klase zaposlenici</param>
        public void dodaj(zaposlenici zaposlenik)
        {
            model.dodaj(zaposlenik);
        }

        /// <summary>
        /// Metoda koja pohranjuje izmijenjene podatke o vozaču u bazu podataka
        /// </summary>
        /// <param name="zaposlenikId">ID vozača čiji se podaci mijenjaju</param>
        /// <param name="zaposlenik">Objekt klase zaposlenici koji sadrži izmijenjene podatke o vozaču</param>
        public void izmjeni(int zaposlenikId, zaposlenici zaposlenik)
        {
            model.izmjeni(zaposlenikId, zaposlenik);
        }

        /// <summary>
        /// Metoda koja služi za brisanje vozila, zaposlenika, putnog radnog lista prema primljenom id-u.
        /// </summary>
        /// <param name="voziloId">ID vozila koje se briše iz baze podataka</param>
        /// <param name="podatak">Definira što se briše ("vozilo")</param>
        public void obrisi(int Id, string podatak)
        {
            model.obrisi(Id, podatak);
        }

        /// <summary>
        /// Metoda koja dodaje novi putni radni list u bazu podataka
        /// </summary>
        /// <param name="PTR">Objekt klase PutniRadniList</param>
        /// <param name="RS">Lista radnih sati vozača navedenih na putnom radnom listu</param>
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
        /// Metoda za ispis vozila koja idu na servis.
        /// Ukoliko vozilo još nije bilo na servisu u razliku se zapisuje trenutno stanje km.
        /// U uvjetu se provjerava da li je razlika km veća od servisnog intervala.
        /// </summary>
        /// <returns>Vraća listu vozila koja trebaju na servis</returns>
        public List<VozilaServis> dohvatiRazlikuKm()
        {
            List<VozilaServis> vozilaServisBezDuplikata = new List<VozilaServis>();
            vozilaServisBezDuplikata = model.dohvatiVozilaServis();
            List<VozilaServis> vozilaServisNovo = new List<VozilaServis>();
            foreach (VozilaServis i in vozilaServisBezDuplikata)
            {
                if (i.stanje_na_zadnjem_servisu == null)
                    i.razlika_km = i.trenutno_stanje_km;
                else i.razlika_km = i.trenutno_stanje_km - i.stanje_na_zadnjem_servisu;
                if (i.razlika_km >= i.servisni_interval)
                    vozilaServisNovo.Add(i);
            }
            return vozilaServisNovo;
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

        /// <summary>
        /// Metoda koja služi za filtriranje zaposlenika na godišnjim odmorima s obzirom na vremensku jedinicu
        /// </summary>
        /// <param name="podatak">Vremenska jedinica (tjedan, mjesec)</param>
        /// <returns></returns>
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

        /// <summary>
        /// Metoda koja provjerava je li količina tereta ispravno unesena.
        /// </summary>
        /// <param name="teret">Unesena količina tereta</param>
        /// <param name="vozilo">ID vozila</param>
        /// <returns>True ako je teret ispravno unesen, false ako nije</returns>
        public bool provjeraTereta(int teret, int vozilo)
        {
            List<vozilo> nosivost = new List<vozilo>();
            nosivost = model.dohvatVozila("sva_vozila");
            foreach (vozilo i in nosivost)
            {
                if (i.id_vozilo == vozilo)
                {
                    if(i.nosivost<teret)
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Metoda koja prosljeđuje vozilo koje će biti poslano na registraciju.
        /// </summary>
        /// <param name="teh"></param>
        public void dodaj(tehnicki_pregled teh)
        {
            model.dodaj(teh);
        }

        /// <summary>
        /// Metoda koja služi za popunjavanje textboksova podacima iz frmIspisRegistracija na glavnoj formi (tabu nadolazeće registracije).
        /// Controlleru prosljeđujemo id koji smo odabrali na formi ispisRegistracija.
        /// </summary>
        /// <param name="id">Id vozila koji će biti prikazan na textboksovima na glavnoj formi</param>
        /// <returns></returns>
        public VozilaRegistracija ispisRegistracija(int id)
        {
            VozilaRegistracija ispisID = new VozilaRegistracija();
            DateTime danas = DateTime.Now;
            foreach (VozilaRegistracija i in model.dohvatVozila())
            {
                if (i.id_vozilo == id)
                {
                    if (i.sljedeca_registracija.Date == danas.Date)
                    {
                        ispisID = i;
                    }
                }
            }
            return ispisID;
        }

        /// <summary>
        /// Metoda koja prosljeđuje vozilo na servis modelu. 
        /// </summary>
        /// <param name="vozilo">Vozilo koje je prosljeđeno na servis</param>
        public void dodaj(servis vozilo)
        {
            model.dodaj(vozilo);
        }

        /// <summary>
        /// Metoda koja prosljeđuje zaposlenika koji će biti dodan na godišnji odmor.
        /// </summary>
        /// <param name="odmor"></param>
        public void dodaj(godisnji_odmor odmor)
        {
            model.dodaj(odmor);
        }


        /// <summary>
        /// Metoda koja služi za popunjavanje textboksova na glavnoj formi (tabu nadolazeći servisi) iz forme ispisServisa (prije toga je potrebno označiti podatke na frmIspisServisa).
        /// Controlleru prosljeđujemo odabrani ID vozila.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VozilaServis ispisServisa(int id)
        {
            VozilaServis ispisID = new VozilaServis();
            foreach (VozilaServis i in model.ispisPoslanihServisa())
            {
                if (i.id_vozilo == id)
                {
                    ispisID = i;
                }
            }
            return ispisID;
        }

        /// <summary>
        /// Metoda koja mi ispisjue sve registracije koje sam poslal od danas pa na dalje.
        /// Rezultat metode se prikazuje na frmIpsisRegistracija.
        /// </summary>
        /// <returns></returns>
        public List<VozilaRegistracija> poslanaNaRegistraciju()
        {
            DateTime danas = DateTime.Now;
            List<VozilaRegistracija> poslana = new List<VozilaRegistracija>();
            foreach (VozilaRegistracija i in model.ispisPoslanihRegistracija())
            {
                if (i.sljedeca_registracija.Year >= danas.Year && i.sljedeca_registracija.Month >= danas.Month && i.sljedeca_registracija.Day >= danas.Day)
                {
                    poslana.Add(i);
                }
            }
            return poslana;
        }

        /// <summary>
        /// Metoda koja ispisuje sva vozila koja sam poslal na servis od danas pa na dalje.
        /// Rezultat metode će se prikazati na frmIspisServisa.
        /// </summary>
        /// <returns></returns>
        public List<VozilaServis> poslanaNaServis()
        {
            DateTime danas = DateTime.Now;
            List<VozilaServis> poslana = new List<VozilaServis>();
            foreach (VozilaServis i in model.ispisPoslanihServisa())
            {
                if (i.datum_servisa >= danas)
                {
                    poslana.Add(i);
                }
            }
            return poslana;
        }

        /*****************************************************************************************************************/
        //NOVE STVARI ZA SLOBODNA VOZILA
        /// <summary>
        /// Metoda koja ispisuje vozila koja nisu na servisu, putnom radnom listu i tehničkom pregledu.
        /// Problem se može riješiti i na način da se svaki put (3 put) spajamo na bazu kojoj prosljeđujemo id vozila koja su zauzeta i selektiramo sva ona vozila
        /// koja nisu na prosljeđenim parametrima.
        /// </summary>
        /// <returns></returns>
        public List<vozilo> ispisSlobodnihVozila()
        {
            List<vozilo> svaVozila = model.dohvatVozila("sva_vozila");
            List<vozilo> slobodnaVozila = new List<vozilo>();
            List<vozilo> zauzetaVozila= new List<vozilo>(); // zauzeta
            //Provjeravamo zauzeta vozila na Putnom radnom listu.
            foreach(int i in model.idPTR()){
                vozilo a = svaVozila.Find(x => x.id_vozilo == i);
                zauzetaVozila.Add(a);
            }
            foreach (int i in model.idTehnickiPregled())
            {
                vozilo b = svaVozila.Find(x => x.id_vozilo == i);
                zauzetaVozila.Add(b);
            }
            foreach (int i in model.idServis())
            {
                vozilo c = svaVozila.Find(x => x.id_vozilo == i);
                zauzetaVozila.Add(c);
            }
            slobodnaVozila = svaVozila.Except(zauzetaVozila).ToList();
            return slobodnaVozila;
        }


        /// <summary>
        /// Metoda koja ispisuje zaposlenike koji nisu na godišnjem odmoru i vozače koji nisu na 
        /// putnom radnom listu. Metoda radi na isti princip kao i za slobodna vozila.
        /// </summary>
        /// <returns></returns>
        public List<zaposlenici> ispisSlobodnihZaposlenika()
        {
            List<zaposlenici> sviZaposlenici = model.dohvatVozaca("svi_vozači");
            List<zaposlenici> zauzetiZaposlenici = new List<zaposlenici>();
            List<zaposlenici> slobodniZaposlenici = new List<zaposlenici>();
            foreach (int i in model.idGodisnjiOdmor())
            {
                zaposlenici a = sviZaposlenici.Find(x => x.id_zaposlenici == i);
                zauzetiZaposlenici.Add(a);
            }
            foreach (int i in model.idPTRZaposlenici())
            {
                zaposlenici b=sviZaposlenici.Find(x => x.id_zaposlenici == i);
                zauzetiZaposlenici.Add(b);
            }
            slobodniZaposlenici = sviZaposlenici.Except(zauzetiZaposlenici).ToList();
            return slobodniZaposlenici;
        }

        /// <summary>
        /// Metoda koja izračunava satnicu zaposlenika
        /// </summary>
        /// <param name="cijena">Cijena zaposlenika po satu</param>
        /// <returns></returns>
        public List<ObracunSati> izracunSatnice(int cijena)
        {
            List<ObracunSati> satnica = new List<ObracunSati>();
            List<ObracunSati> izracunataSatnica = new List<ObracunSati>();
            satnica = model.dohvatiSate();
            foreach (ObracunSati i in satnica)
            {
                if (i.suma_sati != null)
                {
                    i.izracunataSatnica = i.suma_sati * cijena;
                    izracunataSatnica.Add(i);
                }
            }
            return izracunataSatnica;
        }
    }
}
