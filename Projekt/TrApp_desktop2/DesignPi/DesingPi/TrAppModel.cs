using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPi
{
    class TrAppModel
    {
        /// <summary>
        /// Metoda za dohvat svih podataka o vozilu.
        /// 
        /// </summary>
        /// <returns>Vraća listu vozila.</returns>
        public List<vozilo> dohvatVozila(string podatak)
        {
            if (podatak == "sva_vozila")
            {
                using (var db = new T25_DBEntities())
                {
                    var upit = from podaci in db.vozilo select podaci;
                    return upit.ToList();
                }
            }
            else
            {
                using (var db = new T25_DBEntities())
                {
                    var upit = from podaci in db.vozilo select podaci;
                    return upit.ToList();

                    /* var upit = db.Database.SqlQuery<vozilo>("select vozilo.id_vozilo, vozilo.naziv, vozilo.nosivost," +
                         " vozilo.registracija, vozilo.vrsta_vozila_id from vozilo, dnevnik, PutniRadniList where vozilo.id_vozilo" +
                         " = dnevnik.vozilo_id_vozilo and dnevnik.status_id_statusa = null and dnevnik.datum = CURRENT_TIMESTAMP and" +
                         " PutniRadniList.vozilo = vozilo.id_vozilo and PutniRadniList.kraj = null;").ToList<vozilo>();
                     return upit.ToList();*/
                }
            }
        }

        /// <summary>
        /// Metoda za dohvat svih vozača.
        /// </summary>
        /// <returns>Vraća listu vozača.</returns>
        public List<zaposlenici> dohvatVozaca()
        {
            using (var db = new T25_DBEntities())
            {
                var upit = from podaci in db.zaposlenici where podaci.uloga == 7 select podaci;
                return upit.ToList();
            }
        }

        /// <summary>
        /// Metoda za dohvat putnih radnih listova.
        /// </summary>
        /// <returns>Vraća listu putnih radnih listova.</returns>
        public List<PutniRadniList> dohvatPTR()
        {
            using (var db = new T25_DBEntities())
            {
                var upit = from podaci in db.PutniRadniList select podaci;
                return upit.ToList();
            }
        }
        /// <summary>
        /// Metoda za dohvaćanje određenog putnog radnog lista
        /// </summary>
        /// <param name="idPTR">ID putnig radnog lista</param>
        /// <returns>Listu koja sadrži odabrani putni radni list</returns>
        public List<PutniRadniList> dohvatPTR(int idPTR)
        {
            using (var db = new T25_DBEntities())
            {
                var upit = from podaci in db.PutniRadniList where podaci.id_putnog_radnog_lista == idPTR select podaci;
                return upit.ToList();
            }
        }

        /// <summary>
        /// Metoda za dohvat radnih sati.
        /// </summary>
        /// <returns>Vraća listu radnih sati.</returns>
        public List<radni_sati> dohvatRS()
        {
            using (var db = new T25_DBEntities())
            {
                var upit = from podaci in db.radni_sati select podaci;
                return upit.ToList();
            }
        }

        /// <summary>
        /// Metoda koja dohvaća vozače navedene na putnom radnom listu.
        /// </summary>
        /// <param name="idPTR">ID putnog radnog lista</param>
        /// <returns>Vraća listu objekata radnih sati koja sadrži zaposlenike.</returns>
        public List<radni_sati> dohvatRS(int idPTR)
        {
            using (var db = new T25_DBEntities())
            {
                var upit = from podaci in db.radni_sati where podaci.putni_radni_list == idPTR select podaci;
                return upit.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<zaposlenici> dohvatZaposlenika()
        {
            using (var db = new T25_DBEntities())
            {
                var upit = from podaci in db.zaposlenici select podaci;
                return upit.ToList();
            }
        }
        public void dodaj(vozilo vozilo)
        {
            using (var db = new T25_DBEntities())
            {
                db.vozilo.Add(vozilo);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="voziloId"></param>
        /// <param name="novipodaci"></param>
        public void izmjeni(int voziloId, vozilo novipodaci)
        {
            using (var db = new T25_DBEntities())
            {
                var update = db.vozilo.Where(u => (u.id_vozilo == voziloId));
                foreach (var item in update)
                {
                    item.registracija = novipodaci.registracija;
                    item.naziv = novipodaci.naziv;
                    item.godina_proizvodnje = novipodaci.godina_proizvodnje;
                    item.vrsta_vozila = novipodaci.vrsta_vozila;
                    item.nosivost = novipodaci.nosivost;
                    item.servisni_interval = novipodaci.servisni_interval;
                    item.datum_registracije = novipodaci.datum_registracije;
                    item.pocetno_stanje_km = novipodaci.pocetno_stanje_km;
                }
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Metoda kojoj je proslijeđen id vozila koji će biti obrisan.
        /// </summary>
        /// <param name="vozilo"></param>
        public void obrisi(int id, string podatak)
        {
            if (podatak == "vozilo")
            {
                using (var db = new T25_DBEntities())
                {
                    var brisanje = db.vozilo.SingleOrDefault(x => x.id_vozilo == id);
                    if (brisanje != null)
                    {
                        db.vozilo.Remove(brisanje);
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                using (var db = new T25_DBEntities())
                {
                    var brisanje = db.zaposlenici.SingleOrDefault(x => x.id_zaposlenici == id);
                    if (brisanje != null)
                    {
                        db.zaposlenici.Remove(brisanje);
                        db.SaveChanges();
                    }
                }
            }
        }
        public void dodaj(zaposlenici zaposlenik)
        {
            using (var db = new T25_DBEntities())
            {
                db.zaposlenici.Add(zaposlenik);
                db.SaveChanges();
            }
        }

        public void izmjeni(int zaposlenikId, zaposlenici novipodaci)
        {
            using (var db = new T25_DBEntities())
            {
                var update = db.zaposlenici.Where(u => (u.id_zaposlenici == zaposlenikId));
                foreach (var item in update)
                {
                    item.prezime = novipodaci.prezime;
                    item.ime = novipodaci.ime;
                    item.lozinka = novipodaci.lozinka;
                    item.korisnicko_ime = novipodaci.korisnicko_ime;
                    item.oib = novipodaci.oib;
                    item.IBAN = novipodaci.IBAN;
                    item.telefon = novipodaci.telefon;
                    item.adresa = novipodaci.adresa;
                    item.datum_rodjenja = novipodaci.datum_rodjenja;
                    item.uloga = novipodaci.uloga;
                    item.datum_zaposlenja = novipodaci.datum_zaposlenja;
                }
                db.SaveChanges();
            }
        }

        public void dodaj(PutniRadniList PTR)
        {
            using (var db = new T25_DBEntities())
            {
                db.PutniRadniList.Add(PTR);
                db.SaveChanges();
            }
        }
        public void dodaj(radni_sati RS)
        {
            using (var db = new T25_DBEntities())
            {
                db.radni_sati.Add(RS);
                db.SaveChanges();
            }
        }

        internal List<PutniRadniList> dohvatiIdPTR(PutniRadniList PTR)
        {
            using (var db = new T25_DBEntities())
            {
              
                 var upit = db.Database.SqlQuery<PutniRadniList>("select * from PutniRadniList where id_putnog_radnog_lista = (select max(id_putnog_radnog_lista) from PutniRadniList)").ToList<PutniRadniList>();
                 return upit.ToList();
            }
        }
    }
}
