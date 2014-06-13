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
                using (var db = new T25_DBEntities1())
                {
                    var upit = from podaci in db.vozilo select podaci;
                    return upit.ToList();
                }
            }
            else
            {
                using (var db = new T25_DBEntities1())
                {
                    var upit = db.Database.SqlQuery<vozilo>("select * from vozilo where vozilo.id_vozilo in (select vozilo.id_vozilo from vozilo except select PutniRadniList.vozilo from PutniRadniList, vozilo where vozilo.id_vozilo = PutniRadniList.vozilo and kraj is null except select  servis.vozilo from servis, vozilo where vozilo.id_vozilo in (select vozilo from servis  where day(servis.datum) = day(GETDATE()) and month(servis.datum)=month(GETDATE()) and year(servis.datum)=year(GETDATE())) except select tehnicki_pregled.vozilo from tehnicki_pregled, vozilo where vozilo.id_vozilo in (select tehnicki_pregled.vozilo from tehnicki_pregled  where day(tehnicki_pregled.datum) = day(GETDATE()) and month(tehnicki_pregled.datum)=month(GETDATE()) and year(tehnicki_pregled.datum)=year(GETDATE())));").ToList<vozilo>();
                    return upit.ToList();
                }
            }
        }

        public List<VozilaRegistracija> dohvatVozila()
        {
            using (var db = new T25_DBEntities1())
            {
                var upit = db.Database.SqlQuery<VozilaRegistracija>("select *, t2.datum as posljednja_registracija, getdate() as sljedeca_registracija from vozilo, tehnicki_pregled t2 where t2.id_tehnickog_pregleda in (select max(t1.id_tehnickog_pregleda) from tehnicki_pregled t1 group by vozilo) and t2.vozilo = vozilo.id_vozilo order by month(t2.datum), day(t2.datum) asc;").ToList<VozilaRegistracija>();
                return upit.ToList();
            }
        }

        /// <summary>
        /// Metoda za dohvat svih vozača.
        /// </summary>
        /// <returns>Vraća listu vozača.</returns>
        public List<zaposlenici> dohvatVozaca(string podatak)
        {
            if (podatak == "svi_vozaci")
            {
                using (var db = new T25_DBEntities1())
                {
                    var upit = from podaci in db.zaposlenici where podaci.uloga == 7 select podaci;
                    return upit.ToList();
                }
            }
            else
            {
                using (var db = new T25_DBEntities1())
                {
                    var upit = db.Database.SqlQuery<zaposlenici>("select * from zaposlenici where id_zaposlenici in (select zaposlenici.id_zaposlenici from zaposlenici except select godisnji_odmor.zaposlenik from godisnji_odmor  where GETDATE()>=godisnji_odmor.pocetak and GETDATE()<=godisnji_odmor.kraj except select radni_sati.zaposlenik from radni_sati, PutniRadniList, zaposlenici where zaposlenici.id_zaposlenici = radni_sati.zaposlenik and radni_sati.putni_radni_list = PutniRadniList.id_putnog_radnog_lista and PutniRadniList.kraj is null except select zaposlenici.id_zaposlenici from zaposlenici where zaposlenici.uloga=9);").ToList<zaposlenici>();
                    return upit.ToList();
                }
            }
        }
       
        /// <summary>
        /// Metoda za dohvat putnih radnih listova.
        /// </summary>
        /// <returns>Vraća listu putnih radnih listova.</returns>
        public List<PutniRadniList> dohvatPTR()
        {
            using (var db = new T25_DBEntities1())
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
            using (var db = new T25_DBEntities1())
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
            using (var db = new T25_DBEntities1())
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
            using (var db = new T25_DBEntities1())
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
            using (var db = new T25_DBEntities1())
            {
                var upit = from podaci in db.zaposlenici select podaci;
                return upit.ToList();
            }
        }

        /// <summary>
        /// Metoda za unos novog vozila i servisa istovremeno.
        /// Servis za svako novo dodano vozilo mora biti upisan kako bi se moglo znati
        /// kad će vozilo ići na servis ovisno o prijeđenom broju km. Odmah se zapisuje 
        /// u tablicu tehnički pregled datum zadnjeg tehničkog pregleda.
        /// </summary>
        /// <param name="vozilo"></param>
        public void dodaj(vozilo vozilo)
        {
            using (var db = new T25_DBEntities1())
            {
                db.vozilo.Add(vozilo);
                tehnicki_pregled tehPregled = new tehnicki_pregled();
                tehPregled.vozilo = vozilo.id_vozilo;
                tehPregled.datum = vozilo.datum_registracije;
                db.tehnicki_pregled.Add(tehPregled);
                servis unosServisa = new servis();
                unosServisa.vozilo = vozilo.id_vozilo;
                unosServisa.prijedjeni_km = vozilo.pocetno_stanje_km;
                db.servis.Add(unosServisa);
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
            using (var db = new T25_DBEntities1())
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
                using (var db = new T25_DBEntities1())
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
                using (var db = new T25_DBEntities1())
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
            using (var db = new T25_DBEntities1())
            {
                db.zaposlenici.Add(zaposlenik);
                db.SaveChanges();
            }
        }

        public void izmjeni(int zaposlenikId, zaposlenici novipodaci)
        {
            using (var db = new T25_DBEntities1())
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
            if (PTR == null)
            {
                return ;
            }
            using (var db = new T25_DBEntities1())
            {
                db.PutniRadniList.Add(PTR);
                db.SaveChanges();
            }
        }
        public void dodaj(radni_sati RS)
        {
            using (var db = new T25_DBEntities1())
            {
                db.radni_sati.Add(RS);
                db.SaveChanges();
            }
        }

        public List<PutniRadniList> dohvatiIdPTR(PutniRadniList PTR)
        {
            using (var db = new T25_DBEntities1())
            {
              
                 var upit = db.Database.SqlQuery<PutniRadniList>("select * from PutniRadniList where id_putnog_radnog_lista = (select max(id_putnog_radnog_lista) from PutniRadniList)").ToList<PutniRadniList>();
                 return upit.ToList();
            }
        }

        public List<VozilaServis> dohvatiVozilaServis()
        {
            using (var db = new T25_DBEntities1())
            {
                var upit = db.Database.SqlQuery<VozilaServis>("select vozilo.id_vozilo, vozilo.registracija, vozilo.naziv, vozilo.servisni_interval, vozilo.pocetno_stanje_km, servis.prijedjeni_km as stanje_na_zadnjem_servisu, sum(kilometraza) as trenutno_stanje_km from vozilo right join PutniRadniList on vozilo.id_vozilo=PutniRadniList.vozilo left join servis on servis.vozilo=(select servis.vozilo from servis where servis.id_servisa in (select max(servis.id_servisa) from servis, PutniRadniList where PutniRadniList.vozilo=servis.vozilo group by servis.vozilo) and PutniRadniList.vozilo=servis.vozilo) group by vozilo.id_vozilo, vozilo.naziv, vozilo.registracija, vozilo.servisni_interval, vozilo.pocetno_stanje_km, servis.prijedjeni_km;").ToList<VozilaServis>();
                return upit.ToList();
            }
        }

        /// <summary>
        /// Metoda za unos tehničkog pregleda
        /// </summary>
        public void unosTehnickogPregleda()
        {

        }

        /// <summary>
        /// Metoda koja dohvaća zaposlenike koji su na godišnjem odmoru
        /// </summary>
        public List<GodisnjiOdmor> dohvatiGodisnjiOdmor(string podatak)
        {
            if (podatak == "danas")
            {
                using (var db = new T25_DBEntities1())
                {
                    var upit = db.Database.SqlQuery<GodisnjiOdmor>("select *, godisnji_odmor.pocetak as pocetak_godisnjeg, godisnji_odmor.kraj as kraj_godisnjeg from zaposlenici join godisnji_odmor on zaposlenici.id_zaposlenici=godisnji_odmor.zaposlenik and getdate()>pocetak and GETDATE()<kraj;").ToList<GodisnjiOdmor>();
                    return upit.ToList();
                }
            }   
            else
            {
                using (var db = new T25_DBEntities1())
                {
                    var upit = db.Database.SqlQuery<GodisnjiOdmor>("select *, godisnji_odmor.pocetak as pocetak_godisnjeg, godisnji_odmor.kraj as kraj_godisnjeg from zaposlenici join godisnji_odmor on zaposlenici.id_zaposlenici=godisnji_odmor.zaposlenik;").ToList<GodisnjiOdmor>();
                    return upit.ToList();
                }
            }
        }
    }
}
