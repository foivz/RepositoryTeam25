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

        /// <summary>
        /// Metoda za dohvat registracija.
        /// </summary>
        /// <returns></returns>
        public List<VozilaRegistracija> dohvatVozila()
        {
            using (var db = new T25_DBEntities1())
            {
                var upit = db.Database.SqlQuery<VozilaRegistracija>("select *, t2.datum as posljednja_registracija, getdate() as sljedeca_registracija, t2.napomena as napomena, t2.id_tehnickog_pregleda from vozilo, tehnicki_pregled t2 where t2.id_tehnickog_pregleda in  (select max(t1.id_tehnickog_pregleda) from tehnicki_pregled t1 group by vozilo) and t2.vozilo = vozilo.id_vozilo order by month(t2.datum), day(t2.datum) asc;").ToList<VozilaRegistracija>();
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
        /// Metoda za dodavanje novog vozila u tablicu vozilo.
        /// Istovremeno u tablicu tehnički pregled se unosi datum zadnjeg tehničkog pregleda.
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
        /// Metoda kojoj može biti proslijeđen id vozila, zaposlenika ili putnog radnog lista koji će biti obrisan.
        /// </summary>
        /// <param name="vozilo"></param>
        public void obrisi(int id, string podatak)
        {
            if (podatak == "vozilo")
            {
                using (var db = new T25_DBEntities1())
                {
                    db.tehnicki_pregled.RemoveRange(db.tehnicki_pregled.Where(x => x.vozilo == id));
                    db.SaveChanges();
                }

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
            else if (podatak == "svi_vozaci")
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

            else if (podatak == "obrisi_PTR")
            {
                using (var db = new T25_DBEntities1())
                {
                    db.radni_sati.RemoveRange(db.radni_sati.Where(x => x.putni_radni_list == id));
                    db.SaveChanges();
                }

                using (var db = new T25_DBEntities1())
                {
                    var brisanje = db.PutniRadniList.SingleOrDefault(x => x.id_putnog_radnog_lista == id);
                    if (brisanje != null)
                    {
                        db.PutniRadniList.Remove(brisanje);
                        db.SaveChanges();
                    }
                }
            }
            else if (podatak == "brisanje_registracije")
            {
                using (var db = new T25_DBEntities1())
                {
                    var brisanje = db.tehnicki_pregled.SingleOrDefault(x => x.id_tehnickog_pregleda == id);
                    if (brisanje != null)
                    {
                        db.tehnicki_pregled.Remove(brisanje);
                        db.SaveChanges();
                    }
                }
            }
            else if (podatak == "brisanje_servisa")
            {
                using (var db = new T25_DBEntities1())
                {
                    var brisanje = db.servis.SingleOrDefault(x => x.id_servisa == id);
                    if (brisanje != null)
                    {
                        db.servis.Remove(brisanje);
                        db.SaveChanges();
                    }
                }
            }
            else if (podatak == "brisanje_godisnjeg")
            {
                using (var db = new T25_DBEntities1())
                {
                    var brisanje = db.godisnji_odmor.SingleOrDefault(x => x.id_godisnjeg_odmora == id);
                    if (brisanje != null)
                    {
                        db.godisnji_odmor.Remove(brisanje);
                        db.SaveChanges();
                    }
                }
            }
            else if (podatak == "vrsta_vozila")
            {
                using (var db = new T25_DBEntities1())
                {
                    var brisanje = db.vrsta_vozila.SingleOrDefault(x => x.id_vrsta_vozila == id);
                    if (brisanje != null)
                    {
                        db.vrsta_vozila.Remove(brisanje);
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
                return;
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

        public void izmjeni(int PTRId, PutniRadniList novipodaci)
        {
            //db.radni_sati.RemoveRange(db.radni_sati.Where(x => x.putni_radni_list == id));
            using (var db = new T25_DBEntities1())
            {
                var RS = db.radni_sati.Where(rs => rs.putni_radni_list == PTRId).ToList();

                //var some = db.radni_sati.Where(x => ls.Contains(x.friendid)).ToList();
                foreach (var item in RS)
                {
                    item.putni_radni_list = novipodaci.id_putnog_radnog_lista;
                    item.zaposlenici = novipodaci.zaposlenici;
                }
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

        /// <summary>
        /// Metoda koja zbraja na putnim radnim listovima kilometražu koja nam je potrebna za određivanje ide li vozilo na servis.
        /// </summary>
        /// <returns></returns>
        public List<VozilaServis> dohvatiVozilaServis()
        {
            using (var db = new T25_DBEntities1())
            {
                var upit = db.Database.SqlQuery<VozilaServis>("select vozilo.id_vozilo, vozilo.registracija, vozilo.naziv, vozilo.servisni_interval, vozilo.pocetno_stanje_km, servis.prijedjeni_km as stanje_na_zadnjem_servisu, sum(kilometraza) as trenutno_stanje_km, servis.opis, servis.datum as datum_servisa from vozilo right join PutniRadniList on vozilo.id_vozilo=PutniRadniList.vozilo left join servis on servis.vozilo=(select servis.vozilo from servis where servis.id_servisa in (select max(servis.id_servisa) from servis, PutniRadniList where PutniRadniList.vozilo=servis.vozilo group by servis.vozilo) and PutniRadniList.vozilo=servis.vozilo) group by vozilo.id_vozilo, vozilo.naziv, vozilo.registracija, vozilo.servisni_interval, vozilo.pocetno_stanje_km, servis.prijedjeni_km, servis.opis, servis.datum order by vozilo.id_vozilo asc;").ToList<VozilaServis>();
                return upit.ToList();
            }
        }

        /// <summary>
        /// Metoda koja vraća listu vozila koje smo DANAS poslali na servis. Rezultat će se pokazati na frmIspisServisa unutar datagrida.
        /// </summary>
        /// <returns></returns>
        public List<VozilaServis> ispisPoslanihServisa()
        {
            using (var db = new T25_DBEntities1())
            {
                var upit = db.Database.SqlQuery<VozilaServis>("select servis.id_servisa, vozilo.id_vozilo, vozilo.registracija, vozilo.naziv, vozilo.servisni_interval, vozilo.pocetno_stanje_km, servis.prijedjeni_km as stanje_na_zadnjem_servisu, servis.opis, servis.datum as datum_servisa from vozilo, servis where vozilo.id_vozilo=servis.vozilo").ToList<VozilaServis>();
                return upit;
            }
        }

        /// <summary>
        /// Metoda koja dohvaća zaposlenike koji su na godišnjem odmoru.
        /// </summary>
        public List<GodisnjiOdmor> dohvatiGodisnjiOdmor(string podatak)
        {
            if (podatak == "danas")
            {
                using (var db = new T25_DBEntities1())
                {
                    var upit = db.Database.SqlQuery<GodisnjiOdmor>("select *, godisnji_odmor.pocetak as pocetak_godisnjeg, godisnji_odmor.kraj as kraj_godisnjeg, godisnji_odmor.id_godisnjeg_odmora from zaposlenici join godisnji_odmor on zaposlenici.id_zaposlenici=godisnji_odmor.zaposlenik and getdate()>pocetak and GETDATE()<kraj;").ToList<GodisnjiOdmor>();
                    return upit.ToList();
                }
            }
            else
            {
                using (var db = new T25_DBEntities1())
                {
                    var upit = db.Database.SqlQuery<GodisnjiOdmor>("select *, godisnji_odmor.pocetak as pocetak_godisnjeg, godisnji_odmor.kraj as kraj_godisnjeg, godisnji_odmor.id_godisnjeg_odmora from zaposlenici join godisnji_odmor on zaposlenici.id_zaposlenici=godisnji_odmor.zaposlenik;").ToList<GodisnjiOdmor>();
                    return upit.ToList();
                }
            }
        }

        /// <summary>
        /// Metoda koja dodaje vozilo poslano na registraciju.
        /// </summary>
        /// <param name="teh"></param>
        public void dodaj(tehnicki_pregled teh)
        {
            using (var db = new T25_DBEntities1())
            {
                db.tehnicki_pregled.Add(teh);
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Metoda koja vraća listu vozila koje smo DANAS ODABRALI i koje danas šeljemo na registraciju.
        /// Njezin rezultat se prikazuje na frmIspisRegistracija.
        /// </summary>
        /// <returns></returns>
        public List<VozilaRegistracija> ispisPoslanihRegistracija()
        {
            using (var db = new T25_DBEntities1())
            {
                var upit = db.Database.SqlQuery<VozilaRegistracija>("select t1.datum as sljedeca_registracija, t1.id_tehnickog_pregleda, v1.id_vozilo, v1.vrsta_vozila_id, v1.registracija, v1.naziv, t1.napomena from vozilo v1, tehnicki_pregled t1 where v1.id_vozilo=t1.vozilo;").ToList<VozilaRegistracija>();
                return upit;
            }
        }

        /// <summary>
        /// Metoda koja služi za dodavnje vozila na servis.
        /// </summary>
        /// <param name="vozilo"></param>
        public void dodaj(servis vozilo)
        {
            using (var db = new T25_DBEntities1())
            {
                db.servis.Add(vozilo);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Metoda koja zapisuje u bazu zaposlenike koji su na godišnjem odmoru.
        /// </summary>
        /// <param name="odmor"></param>
        public void dodaj(godisnji_odmor odmor)
        {
            using (var db = new T25_DBEntities1())
            {
                db.godisnji_odmor.Add(odmor);
                db.SaveChanges();
            }
        }
        /*****************************************************************************************************************/
        //NOVE STVARI ZA SLOBODNA VOZILA

        /// <summary>
        /// Metoda koja vraća id vozila koja su na putnom radnom listu.
        /// Treba nam kako bi pomoću te metode mogli pronaći slobodna vozila u contrroleru.
        /// </summary>
        /// <returns></returns>
        public List<int> idPTR()
        {
            using (var db = new T25_DBEntities1())
            {
                var upit = db.Database.SqlQuery<int>("select PutniRadniList.vozilo as id from PutniRadniList, vozilo where vozilo.id_vozilo=PutniRadniList.vozilo and GETDATE()>=PutniRadniList.pocetak and getdate()<=PutniRadniList.kraj;").ToList<int>();
                return upit;
            }
        }

        /// <summary>
        /// Metoda koja vraća id vozila koja su na servisu.
        /// Treba nam kako bi pomoću te metode mogli pronaći slobodna vozila u contrroleru.
        /// </summary>
        /// <returns></returns>
        public List<int> idServis()
        {
            using (var db = new T25_DBEntities1())
            {
                var upit = db.Database.SqlQuery<int>("select servis.vozilo as id from servis,vozilo where servis.vozilo=vozilo.id_vozilo and YEAR(servis.datum)=YEAR(GETDATE()) and month(servis.datum)=month(getdate()) and day(servis.datum)=day(GETDATE());").ToList<int>();
                return upit;
            }
        }

        /// <summary>
        /// Metoda koja vraća id vozila koja su na tehničkom pregledu.
        /// Treba nam kako bi pomoću te metode mogli pronaći slobodna vozila u contrroleru.
        /// </summary>
        /// <returns></returns>
        public List<int> idTehnickiPregled()
        {
            using (var db = new T25_DBEntities1())
            {
                var upit = db.Database.SqlQuery<int>("select t1.vozilo from tehnicki_pregled t1, vozilo where t1.vozilo=vozilo.id_vozilo and YEAR(t1.datum)=YEAR(GETDATE()) and month(t1.datum)=month(getdate()) and day(t1.datum)=day(GETDATE());").ToList<int>();
                return upit;
            }
        }

        /// <summary>
        /// Metoda koja vraća id zaposlenika koja su na godišnjem odmoru.
        /// Treba nam kako bi pomoću te metode mogli pronaći slobodne zaposlenike u contrroleru.
        /// </summary>
        /// <returns></returns>
        public List<int> idGodisnjiOdmor()
        {
            using (var db = new T25_DBEntities1())
            {
                var upit = db.Database.SqlQuery<int>("select zaposlenici.id_zaposlenici from zaposlenici, godisnji_odmor where zaposlenici.id_zaposlenici=godisnji_odmor.zaposlenik and year(GETDATE())>=year(pocetak) and month(GETDATE())>=month(pocetak) and day(getdate())>=day(pocetak) and year(GETDATE())<=year(kraj) and MONTH(GETDATE())<=month(kraj) and day(getdate())<=day(kraj);").ToList<int>();
                return upit;
            }
        }

        /// <summary>
        /// Metoda koja vraća id zaposlenika koja su na Putnom radnom listu..
        /// Treba nam kako bi pomoću te metode mogli pronaći slobodne zaposlenike u contrroleru.
        /// </summary>
        /// <returns></returns>
        public List<int> idPTRZaposlenici()
        {
            using (var db = new T25_DBEntities1())
            {
                var upit = db.Database.SqlQuery<int>("select zaposlenici.id_zaposlenici from zaposlenici, radni_sati, PutniRadniList where zaposlenici.id_zaposlenici=radni_sati.zaposlenik and radni_sati.putni_radni_list=PutniRadniList.id_putnog_radnog_lista and GETDATE()>=PutniRadniList.pocetak and getdate()<=PutniRadniList.kraj;").ToList<int>();
                return upit;
            }
        }

        /// <summary>
        /// Metoda koja dohvaća vrste vozila koje će biti prikazane na comboboxu prilikom unosa
        /// novog vozila.
        /// </summary>
        /// <returns></returns>
        public List<vrsta_vozila> dohvatiVrsteVozila()
        {
            using (var db = new T25_DBEntities1())
            {
                var upit = db.Database.SqlQuery<vrsta_vozila>("select id_vrsta_vozila, naziv from vrsta_vozila").ToList<vrsta_vozila>();
                return upit;
            }
        }

        /// <summary>
        /// Metoda kojojm spremamo nove vrste vozila u bazu podataka. 
        /// </summary>
        /// <param name="vrstaVozila"></param>
        public void dodaj(vrsta_vozila vrstaVozila)
        {
            using (var db = new T25_DBEntities1())
            {
                db.vrsta_vozila.Add(vrstaVozila);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Metoda koja dohvaća uloge zaposlenika koje su nam potrebne za prikaz na comoboxu prilikom
        /// unosa novog zaposlenika.
        /// </summary>
        /// <returns></returns>
        public List<uloga> dohvatiUloge()
        {
            using (var db = new T25_DBEntities1())
            {
                var upit = db.Database.SqlQuery<uloga>("select id_uloge, naziv from uloga").ToList<uloga>();
                return upit.ToList();
            }
        }

        /// <summary>
        /// Metoda koja dohvaća broj radnih sati za svakog zaposlenika koji se nalazi na putnom radnom listu.
        /// </summary>
        /// <returns></returns>
        public List<ObracunSati> dohvatiSate()
        {
            using (var db = new T25_DBEntities1())
            {
                var upit = db.Database.SqlQuery<ObracunSati>("select zaposlenici.prezime, zaposlenici.ime, zaposlenici.id_zaposlenici, zaposlenici.IBAN, zaposlenici.adresa, sum(br_sati) as suma_sati from zaposlenici, PutniRadniList, radni_sati where zaposlenici.id_zaposlenici=radni_sati.zaposlenik and radni_sati.putni_radni_list=PutniRadniList.id_putnog_radnog_lista and month(getdate())=month(PutniRadniList.pocetak) group by zaposlenici.prezime, zaposlenici.ime, zaposlenici.id_zaposlenici, zaposlenici.IBAN, zaposlenici.adresa;").ToList<ObracunSati>();
                return upit.ToList();
            }

        }
    }
}
