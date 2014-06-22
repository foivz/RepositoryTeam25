using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesingPi
{

   /// <summary>
   ///  Glavna klasa koja nasljeđuje klasu Window, a koja sadrži atribute i metode kontrola na glavnoj formi
   /// </summary>
    public partial class MainWindow : Window
    {
        TrAppModel model = new TrAppModel(); //objekt klase TrAppModel
        TrAppController controller = new TrAppController(); //objekt klase TrAppController
        private int uloga; //uloga korisnika koja se dobiva na temelju korisničkog imena

        /// <summary>
        /// Konstruktor glavne klase MainWindow
        /// </summary>
        /// <param name="uloga">Označava ulogu korisnika aplikacije koja se dobiva na temelju unesenog korisničkog imena prilikom prijave korisnika u aplikaciju.</param>
        public MainWindow(int uloga)
        {
            InitializeComponent();
            this.uloga = uloga;
            if (uloga > 5)
            {
                tabVozila1.IsEnabled = false;
                tabZaposlenici.IsEnabled = false;
            }
            
        }

        /// <summary>
        /// Metoda koja se poziva kad korisnik odabere tab kontrolu Popis vozila, a koja postavlja vrijednost odabranog indeksa u glavnoj i tab kontroli na 0 .
        /// </summary>
        /// <param name="sender">Referenca na tab kontrolu Popis vozila.</param>
        /// <param name="e">Sadrži argumente vezane uz događaje koji su vezani uz tab Popis vozila.</param>
        void tabPopisVozila(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 0;
            tabVozila.SelectedIndex = 0;
        }

        /// <summary>
        /// Metoda koja se poziva kad korisnik odabere tab kontrolu Nadolazeće registracije, a koja postavlja vrijednost odabranog indeksa u glavnoj kontroli na 0, a na tab kontroli na 1.
        /// </summary>
        /// <param name="sender">Referenca na tab kontrolu Nadolazeće registracije.</param>
        /// <param name="e">Sadrži argumente vezane uz događaje koji su vezani uz tab kontrolu Nadolazeće registracije.</param>
        void tabRegistracija(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 0;
            tabVozila.SelectedIndex = 1;
        }

        /// <summary>
        /// Metoda koja se poziva kad korisnik odabere tab kontrolu Nadolazeći servisi, a koja postavlja vrijednost odabranog indeksa u glavnoj kontroli na 0, a na tab kontroli na 2.
        /// </summary>
        /// <param name="sender">Referenca na tab kontrolu Nadolazeći servisi.</param>
        /// <param name="e">Sadrži argumente vezane uz događaje koji su vezani uz tab kontrolu Nadolazeći servisi.</param>
        void tabServis(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 0;
            tabVozila.SelectedIndex = 2;
        }

        /// <summary>
        /// Metoda koja se poziva kad korisnik odabere tab kontrolu Popis vozača, a koja postavlja vrijednost odabranog indeksa u glavnoj kontroli na 1, a na tab kontroli na 0.
        /// </summary>
        /// <param name="sender">Referenca na tab kontrolu Popis vozača.</param>
        /// <param name="e">Sadrži argumente vezane uz događaje koji su vezani uz tab kontrolu Popis vozača.</param>
        void tabPopisVozaca(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 1;
            tabVozaci.SelectedIndex = 0;
        }

        /// <summary>
        /// Metoda koja se poziva kad korisnik odabere tab kontrolu Planiranje godišnjih odmora, a koja postavlja vrijednost odabranog indeksa u glavnoj kontroli i tab kontroli na 1.
        /// </summary>
        /// <param name="sender">Referenca na tab kontrolu Planiranje godišnjih odmora.</param>
        /// <param name="e">Sadrži argumente vezane uz događaje koji su vezani uz tab kontrolu Planiranje godišnjih odmora.</param>
        void tabGodisnjiOdmor(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 1;
            tabVozaci.SelectedIndex = 1;
        }

        /// <summary>
        /// Metoda koja se poziva kad korisnik odabere tab kontrolu Mjesečni obračun radnih sati, a koja postavlja vrijednost odabranog indeksa u glavnoj kontroli na 1, a na tab kontroli na 2.
        /// </summary>
        /// <param name="sender">Referenca na tab kontrolu Mjesečni obračun radnih sati.</param>
        /// <param name="e">Sadrži argumente vezane uz događaje koji su vezani uz tab kontrolu Mjesečni obračun radnih sati.</param>
        void tabRadniSati(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 1;
            tabVozaci.SelectedIndex = 2;
        }

        /// <summary>
        /// Metoda koja se poziva kad korisnik odabere tab kontrolu Unos putnog radnog lista, a koja postavlja vrijednost odabranog indeksa u glavnoj kontroli na 2, a na tab kontroli na 0.
        /// </summary>
        /// <param name="sender">Referenca na tab kontrolu Unos putnog radnog lista.</param>
        /// <param name="e">Sadrži argumente vezane uz događaje koji su vezani uz tab kontrolu Unos putnog radnog lista.</param>
        void tabUnosPutnogRadnogLista(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 2;
            tabTransportniPodaci.SelectedIndex = 0;
        }

        /// <summary>
        /// Metoda koja se poziva kad korisnik odabere tab kontrolu Unos vozača, a koja postavlja vrijednost odabranog indeksa u glavnoj kontroli na 2, a na tab kontroli na 1.
        /// </summary>
        /// <param name="sender">Referenca na tab kontrolu Unos vozača.</param>
        /// <param name="e">Sadrži argumente vezane uz događaje koji su vezani uz tab kontrolu Unos vozača.</param>
        void tabUnosZaposlenika(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 2;
            tabTransportniPodaci.SelectedIndex = 1;
        }

        /// <summary>
        /// Metoda koja se poziva kad korisnik odabere tab kontrolu Unos vozila, a koja postavlja vrijednost odabranog indeksa u glavnoj kontroli i tab kontroli na 2.
        /// </summary>
        /// <param name="sender">Referenca na tab kontrolu Unos vozila.</param>
        /// <param name="e">Sadrži argumente vezane uz događaje koji su vezani uz tab kontrolu Unos vozila.</param>
        void tabUnosVozila(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 2;
            tabTransportniPodaci.SelectedIndex = 2;
        }

        /// <summary>
        /// Privatna metoda koja se poziva kad se učita glavni prozor, a koja pohranjuje resurse dobivene iz baze podataka u kolekcije
        /// </summary>
        /// <param name="sender">Referenca na glavni prozor</param>
        /// <param name="e">Sadrži argumente vezane uz događaje koji su vezani uz glavni prozor.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource t25_DBEntitiesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("t25_DBEntitiesViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // t25_DBEntitiesViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource putniRadniListViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("putniRadniListViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // putniRadniListViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource godisnji_odmorViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("godisnji_odmorViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // godisnji_odmorViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource tehnicki_pregledViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tehnicki_pregledViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // tehnicki_pregledViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource servisViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("servisViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // servisViewSource.Source = [generic data source]
        }

        /// <summary>
        /// Metoda koja govori koji datagrid s vozilima će biti popunjen podacima.
        /// Želi se izbjeći da se pri pokretanju programa odmah oba popune.
        /// </summary>
        /// <param name="sender">Referenca na tab kontrolu Popis vozila</param>
        /// <param name="e">Sadrži argumente vezane uz događaje koji su vezani uz tab kontrolu Popis vozila.</param>
        private void popisVozila_Loaded(object sender, RoutedEventArgs e)
        {
            string a = "System.Windows.Controls.TabItem Header:Popis vozila Content:System.Windows.Controls.TabItem Header:Unos vozila Content:System.Windows.Controls.TabItem Header:Unos vozila Content:";
            string b = e.OriginalSource.ToString();
            string podatak = "sva_vozila";
            if (string.Compare(a, b) == 1)
            {
                voziloDataGrid1.ItemsSource = model.dohvatVozila(podatak);
            }
            else
            {
                voziloDataGrid.ItemsSource = model.dohvatVozila(podatak);
            }
        }

        /// <summary>
        /// Metoda koja govori koji datagrid s vozačima će biti popunjen podacima.
        /// Želi se izbjeći da se pri pokretanju programa odmah oba popune.
        /// </summary>
        /// <param name="sender">Referenca na tab kontrolu Popis vozača.</param>
        /// <param name="e">Sadrži argumente vezane uz događaje koji su vezani uz tab kontrolu Popis vozača.</param>
        private void popisZaposlenika_Loaded(object sender, RoutedEventArgs e)
        {
            string a = "System.Windows.Controls.TabItem Header:Popis vozila Content:System.Windows.Controls.TabItem Header:Unos vozila Content:System.Windows.Controls.TabItem Header:Unos vozila Content:";
            string b = e.OriginalSource.ToString();
            string podatak = "svi_vozaci";
            if (string.Compare(a, b) == 1)
            {
                zaposleniciDataGrid.ItemsSource = model.dohvatVozaca(podatak);
            }
            else
            {
                zaposleniciDataGrid1.ItemsSource = model.dohvatZaposlenika();
            }
        }

        /// <summary>
        /// Metoda koja se poziva kad korisnik odabere opciju Dodaj vozilo na tab kontroli Unos vozila.
        /// Najprije provjerava jesu li sva polja ispravno unesena te, ukoliko jesu, dodaje podatke o vozilu u bazu podataka.
        /// </summary>
        /// <param name="sender">Referenca na gumb Dodaj vozilo</param>
        /// <param name="e">Sadrži argumente vezane uz događaje koji su vezani uz gumb Dodaj vozilo.</param>
        private void btnDodajVozilo_Click(object sender, RoutedEventArgs e)
        {
            string podatak = "sva_vozila";
            if (provjeriPopunjenostVozila())
            {
                controller.dodaj(dohvatiPodatkeVozilo());
                voziloDataGrid.ItemsSource = model.dohvatVozila(podatak);
                voziloDataGrid1.ItemsSource = model.dohvatVozila(podatak);
                MessageBox.Show("Vozilo uspješno dodano!", "Obavijest");
                ocistiTextBox(this);
            }
        }

        /// <summary>
        /// Metoda koja se poziva kad korisnik odabere opciju Izmijeni vozilo na tab kontroli Unos vozila.
        /// Najprije provjerava jesu li svi podaci ispravno uneseni te, ukoliko jesu, pohranjuje izmijenjene podatke o vozilu u bazu podataka.
        /// </summary>
        /// <param name="sender">Referenca na gumb Izmijeni vozilo</param>
        /// <param name="e">Sadrži argumente vezane uz događaje koji su vezani uz gumb Izmijeni vozilo.</param>
        private void btnIzmjeniVozilo_Click(object sender, RoutedEventArgs e)
        {
            string podatak = "sva_vozila";
            if (provjeriPopunjenostVozila())
            {

                int voziloId = Convert.ToInt32(id_voziloTextBox.Text);
                controller.izmjeni(voziloId, dohvatiPodatkeVozilo());
                MessageBox.Show("Vozilo uspješno izmjenjeno!", "Obavijest");
                voziloDataGrid1.ItemsSource = model.dohvatVozila(podatak);
                voziloDataGrid.ItemsSource = model.dohvatVozila(podatak);
            }
            else
            {
                MessageBox.Show("Niste unijeli sve podatke!", "Upozorenje");
            }
        }

        /// <summary>
        /// Metoda koja se poziva kad korisnik odabere opciju Obriši vozilo na tab kontroli Unos vozila.
        /// Najprije provjerava jesu li svi podaci ispravno uneseni, je li vozilo trenutno odsutno.
        /// Ukoliko su uvjeti zadovoljeni, briše podatke o odabranom vozilu iz baze podataka.
        /// </summary>
        /// <param name="sender">Referenca na gumb Obriši vozilo</param>
        /// <param name="e">Sadrži argumente vezane uz događaje koji su vezani uz gumb Obriši vozilo.</param>
        private void btnObrisiVozilo_Click(object sender, RoutedEventArgs e)
        {
            List<VozilaRegistracija> naRegistraciji = controller.poslanaNaRegistraciju();
            List<VozilaServis> naServisu = controller.poslanaNaServis();
            string podatak = "vozilo";
            string podatak2 = "sva_vozila";
            int voziloId = 0;
            if (string.IsNullOrWhiteSpace(id_voziloTextBox.Text))
            {
                return;
            }
            voziloId = Convert.ToInt32(id_voziloTextBox.Text);
            foreach (VozilaRegistracija i in naRegistraciji)
            {
                if (i.id_vozilo == voziloId)
                {
                    MessageBox.Show("Vozilo je na registraciji, ne može se obrisati!", "Obavijest");
                    return;
                }
            }
            foreach (VozilaServis i in naServisu)
            {
                if (i.id_vozilo == voziloId)
                {
                    MessageBox.Show("Vozilo je na servisu, ne može se obrisati", "Obavijest");
                    return;
                }
            }
            controller.obrisi(voziloId, podatak);
            MessageBox.Show("Vozilo uspješno obrisano!", "Obavijest");
            voziloDataGrid.ItemsSource = model.dohvatVozila(podatak2);
            voziloDataGrid1.ItemsSource = model.dohvatVozila(podatak2);
        }

        /// <summary>
        /// Metoda za brisanje sadrzaja svih textBox-ova. 
        /// </summary>
        /// <param name="obj">Objekt kontrole gdje će se obrisati sadržaj</param>
        private void ocistiTextBox(DependencyObject obj)
        {
            TextBox tb = obj as TextBox;
            if (tb != null)
                tb.Text = "";
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj as DependencyObject); i++)
                ocistiTextBox(VisualTreeHelper.GetChild(obj, i));
        }

        /// <summary>
        /// Provjerava popunjenost svih textbox-ova prije unosa.
        /// </summary>
        /// <returns>Vraća true ako je sve ispunjeno, false ako nije.</returns>
        private bool provjeriPopunjenostVozila()
        {
            if (string.IsNullOrWhiteSpace(godina_proizvodnjeTextBox.Text))
                return false;
            int godina_proizvodnje = Convert.ToInt32(godina_proizvodnjeTextBox.Text);
            DateTime datum_registracije = Convert.ToDateTime(datum_registracijeDatePicker.Text);
            int datum = Convert.ToInt32(datum_registracije.Year);
            if (string.IsNullOrWhiteSpace(cmbVrstaVozila.Text) ||
               string.IsNullOrWhiteSpace(registracijaTextBox.Text) ||
               string.IsNullOrWhiteSpace(nazivTextBox.Text) ||
               string.IsNullOrWhiteSpace(godina_proizvodnjeTextBox.Text) ||
               string.IsNullOrWhiteSpace(nosivostTextBox.Text) ||
               string.IsNullOrWhiteSpace(servisni_intervalTextBox.Text) ||
               string.IsNullOrWhiteSpace(datum_registracijeDatePicker.Text) ||
               string.IsNullOrWhiteSpace(pocetno_stanje_kmTextBox.Text))
            {
                MessageBox.Show("Niste unijeli sve podatke!", "Upozorenje!");
                return false;
            }
            else if (godina_proizvodnje > datum)
            {

                MessageBox.Show("Godina proizvodnje ne može biti veća od datuma prve registracije!", "Upozorenje!");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Metoda koja dohvaća podatke iz textBox-ova i sprema ih u objekt vozilo
        /// </summary>
        /// <returns>Popunjava objekt vozilo</returns>
        private vozilo dohvatiPodatkeVozilo()
        {
            string[] vrstaVozila = cmbVrstaVozila.Text.Split(' ');
            vozilo vozilo = new vozilo();
            vozilo.vrsta_vozila_id = int.Parse(vrstaVozila[0]);
            vozilo.registracija = registracijaTextBox.Text;
            vozilo.naziv = nazivTextBox.Text;
            vozilo.godina_proizvodnje = Convert.ToInt32(godina_proizvodnjeTextBox.Text);
            vozilo.nosivost = Convert.ToInt32(nosivostTextBox.Text);
            vozilo.servisni_interval = Convert.ToInt32(servisni_intervalTextBox.Text);
            vozilo.datum_registracije = Convert.ToDateTime(datum_registracijeDatePicker.Text);
            vozilo.pocetno_stanje_km = Convert.ToInt32(pocetno_stanje_kmTextBox.Text);
            return vozilo;
        }

        /// <summary>
        /// Metoda koja se poziva kad korisnik odabere opciju Izmijeni vozilo na tab kontroli Unos vozača.
        /// Najprije provjerava jesu li svi podaci ispravno uneseni te, ukoliko jesu, pohranjuje unesene podatke o vozaču u bazu podataka.
        /// </summary>
        /// <param name="sender">Referenca na gumb Dodaj vozača</param>
        /// <param name="e">Sadrži argumente vezane uz događaje koji su vezani uz gumb Dodaj vozača.</param>
        private void btnDodajZaposlenika_Click(object sender, RoutedEventArgs e)
        {
            if (provjeriPopunjenostZaposlenika())
            {
                string podatak = "svi_vozaci";
                controller.dodaj(dohvatiPodatkeZaposlenika());
                zaposleniciDataGrid.ItemsSource = model.dohvatVozaca(podatak);
                zaposleniciDataGrid1.ItemsSource = model.dohvatZaposlenika();
                MessageBox.Show("Zaposlenik uspješno dodan!", "Obavijest");
                ocistiTextBox(this);
            }
            else
            {
                MessageBox.Show("Niste unijeli sve podatke!", "Upozorenje");
            }

        }

        /// <summary>
        /// Metoda koja se poziva kad korisnik odabere opciju Izmijeni vozilo na tab kontroli Unos vozača.
        /// Najprije provjerava jesu li svi podaci ispravno uneseni te, ukoliko jesu, pohranjuje izmijenjene podatke o vozaču u bazu podataka.
        /// </summary>
        /// <param name="sender">Referenca na gumb Izmijeni vozača</param>
        /// <param name="e">Sadrži argumente vezane uz događaje koji su vezani uz gumb Izmijeni vozača.</param>
        private void btnIzmjeniZaposlenika_Click(object sender, RoutedEventArgs e)
        {
            if (provjeriPopunjenostZaposlenika())
            {
                string podatak = "svi_vozaci";
                int zaposlenikId = Convert.ToInt32(id_zaposleniciTextBox.Text);
                controller.izmjeni(zaposlenikId, dohvatiPodatkeZaposlenika());
                MessageBox.Show("Zaposlenik uspješno izmjenjen!", "Obavijest");
                zaposleniciDataGrid.ItemsSource = model.dohvatVozaca(podatak);
                zaposleniciDataGrid1.ItemsSource = model.dohvatZaposlenika();
            }
            else
            {
                MessageBox.Show("Niste unijeli sve podatke!", "Upozorenje");
            }

        }

        /// <summary>
        /// Metoda koja se poziva kad korisnik odabere opciju Obriši vozača na tab kontroli Unos vozača.
        /// Najprije provjerava jesu li svi podaci ispravno uneseni te, ukoliko jesu, briše podatke o vozaču iz baze podataka.
        /// </summary>
        /// <param name="sender">Referenca na gumb Obriši vozača</param>
        /// <param name="e">Sadrži argumente vezane uz događaje koji su vezani uz gumb Obriši vozača.</param>
        private void btnObrisiZaposlenika_Click(object sender, RoutedEventArgs e)
        {
            string podatak = "svi_vozaci";
            if (string.IsNullOrWhiteSpace(id_zaposleniciTextBox.Text))
                return;
            int zaposlenikId = Convert.ToInt32(id_zaposleniciTextBox.Text);
            controller.obrisi(zaposlenikId, podatak);
            MessageBox.Show("Vozač uspješno obrisan!", "Obavijest");
            zaposleniciDataGrid.ItemsSource = model.dohvatVozaca(podatak);
            zaposleniciDataGrid1.ItemsSource = model.dohvatZaposlenika();
        }

        /// <summary>
        /// Provjerava popunjenost svih textbox-ova prije unosa.
        /// </summary>
        /// <returns>Vraća true ako je sve ispunjeno, false ako nije.</returns>
        private bool provjeriPopunjenostZaposlenika()
        {
            if (string.IsNullOrWhiteSpace(prezimeTextBox.Text) ||
                string.IsNullOrWhiteSpace(imeTextBox.Text) ||
                string.IsNullOrWhiteSpace(lozinkaPasswordBox.Password) ||
                string.IsNullOrWhiteSpace(korisnicko_imeTextBox.Text) ||
                string.IsNullOrWhiteSpace(oibTextBox.Text) ||
                string.IsNullOrWhiteSpace(iBANTextBox.Text) ||
                string.IsNullOrWhiteSpace(telefonTextBox.Text) ||
                string.IsNullOrWhiteSpace(adresaTextBox.Text) ||
                string.IsNullOrWhiteSpace(datum_rodjenjaDatePicker.Text) ||
                string.IsNullOrWhiteSpace(cmbUloga.Text) ||
                string.IsNullOrWhiteSpace(datum_zaposlenjaDatePicker.Text))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Metoda koja dohvaća sve podatke vezane uz zaposlenike i sprema ih u objekt klase Zaposlenici.
        /// </summary>
        /// <returns>Vraća objekte klase zaposlenici koji sadrži podatke o zaposlenicima.</returns>
        private zaposlenici dohvatiPodatkeZaposlenika()
        {
            string[] uloga = cmbUloga.Text.Split(' ');
            zaposlenici zaposlenici = new zaposlenici();
            zaposlenici.prezime = prezimeTextBox.Text;
            zaposlenici.ime = imeTextBox.Text;
            zaposlenici.lozinka = lozinkaPasswordBox.Password;
            zaposlenici.korisnicko_ime = korisnicko_imeTextBox.Text;
            zaposlenici.oib = oibTextBox.Text;
            zaposlenici.IBAN = iBANTextBox.Text;
            zaposlenici.telefon = telefonTextBox.Text;
            zaposlenici.adresa = adresaTextBox.Text;
            zaposlenici.datum_rodjenja = Convert.ToDateTime(datum_rodjenjaDatePicker.Text);
            zaposlenici.uloga = Convert.ToInt32(uloga[0]);
            zaposlenici.datum_zaposlenja = Convert.ToDateTime(datum_zaposlenjaDatePicker.Text);
            return zaposlenici;
        }

        /// <summary>
        /// Metoda koja poziva formu za prikaz slobodnih vozila.
        /// </summary>
        /// <param name="sender">Referenca na gumb Odaberi</param>
        /// <param name="e">Sadrži argumente za događaje vezane uz gumb Odaberi</param>
        private void btnOdaberiSlobodnaVozila(object sender, RoutedEventArgs e)
        {
            SlobodnaVozila frmSlobodnaVozila = new SlobodnaVozila();
            frmSlobodnaVozila.ShowDialog();
            voziloTextBox.Text = frmSlobodnaVozila.txtID.Text;
        }


        /// <summary>
        /// Forma koja služi za pregled Putnih radnih listova. Klikom na pregled otvara se nova forma, a na novoj formi možemo odabrati postojeći PTR kojeg onda 
        /// potom mijenjamo ili brisemo.
        /// </summary>
        /// <param name="sender">Referenca na gumb Pregled</param>
        /// <param name="e">Sadrži argumente za događaje vezane uz gumb Odaberi</param>
        private void btnPregledPTR_Click(object sender, RoutedEventArgs e)
        {
            //kreiranje objekta za prvi objekt u listi
            PutniRadniList odabraniPTRObj = new PutniRadniList();

            List<radni_sati> odabraniVozaci = new List<radni_sati>(); //lista odabranih vozača
            radni_sati odabraniVozaciObj = new radni_sati(); //objekt klase radni_sati

            //otvaranje forme za odabir putnig radnog lista
            PregledPTR frmPTR = new PregledPTR();
            frmPTR.ShowDialog();
            id_putnog_radnog_listaTextBox.Text = frmPTR.txtIDPTR.Text;
            int idPTR = 0;
            if (!string.IsNullOrWhiteSpace(id_putnog_radnog_listaTextBox.Text))
            {
                idPTR = Convert.ToInt32(id_putnog_radnog_listaTextBox.Text);

                odabraniPTRObj = model.dohvatPTR(idPTR).First<PutniRadniList>();

                odabraniVozaci = model.dohvatRS(idPTR);
                odabraniVozaciObj = odabraniVozaci.ElementAt<radni_sati>(0);
                zaposlenikTextBox.Text = odabraniVozaciObj.zaposlenik.ToString();
                var a = odabraniVozaci.Count();
                if (a == 2)
                {
                    odabraniVozaciObj = odabraniVozaci.ElementAt<radni_sati>(1);
                    zaposlenikTextBox1.Text = odabraniVozaciObj.zaposlenik.ToString();
                }
                voziloTextBox.Text = odabraniPTRObj.vozilo.ToString();
                pocetakDatePicker.Text = odabraniPTRObj.pocetak.ToString();
                krajDatePicker.Text = odabraniPTRObj.kraj.ToString();
                mjesto_utovaraTextBox.Text = odabraniPTRObj.mjesto_utovara.ToString();
                mjesto_istovaraTextBox.Text = odabraniPTRObj.mjesto_istovara.ToString();
                //kreiraTextBox.Text = odabraniPTRObj.kreira.ToString();
                kilometrazaTextBox.Text = odabraniPTRObj.kilometraza.ToString();
                teretTextBox.Text = odabraniPTRObj.teret.ToString();
                if (!string.IsNullOrWhiteSpace(napomeneTextBox.Text))
                    napomeneTextBox.Text = odabraniPTRObj.napomene.ToString();
            }
        }

        /// <summary>
        /// Metoda koja poziva novu formu za odabir prvog vozača na putnom radnom listu.
        /// </summary>
        /// <param name="sender">Referenca na gumb Odaberi</param>
        /// <param name="e">Sadrži argumente za događaje vezane uz gumb Odaberi</param>
        private void btnOdaberiVozaca1_Click(object sender, RoutedEventArgs e)
        {
            SlobodniVozaci vozaci = new SlobodniVozaci();
            vozaci.ShowDialog();
            zaposlenikTextBox.Text = vozaci.txtID.Text;
        }

        /// <summary>
        /// Metoda koja poziva novu formu za odabir drugog vozača na putnom radnom listu.
        /// </summary>
        /// <param name="sender">Referenca na gumb Odaberi</param>
        /// <param name="e">Sadrži argumente za događaje vezane uz gumb Odaberi</param>
        private void btnOdaberiVozaca2_Click(object sender, RoutedEventArgs e)
        {
            SlobodniVozaci vozaci = new SlobodniVozaci();
            vozaci.ShowDialog();
            zaposlenikTextBox1.Text = vozaci.txtID.Text;
        }

        /// <summary>
        /// Metoda koja služi za provjeru popunjenosti textboksova za putni radni list.
        /// Ako je unesen neispravan datum i teret javlja grešku.
        /// </summary>
        /// <returns>Vraća true ako su polja ispravno unesena, false ako nisu (uz ispis odgovarajućih poruka).</returns>
        private bool provjeriPopunjenostPTR()
        {
            if (string.IsNullOrWhiteSpace(voziloTextBox.Text) ||
                string.IsNullOrWhiteSpace(zaposlenikTextBox.Text) ||
                string.IsNullOrWhiteSpace(pocetakDatePicker.Text) ||
                string.IsNullOrWhiteSpace(kilometrazaTextBox.Text) ||
                string.IsNullOrWhiteSpace(cmbPTRSlobodniZaposlenici.Text) ||
                string.IsNullOrWhiteSpace(mjesto_utovaraTextBox.Text) ||
                string.IsNullOrWhiteSpace(mjesto_istovaraTextBox.Text) ||
                string.IsNullOrWhiteSpace(teretTextBox.Text))
            {
                MessageBox.Show("Niste unijeli sve podatke!", "Upozorenje");
                return false;
            }
            else if (pocetakDatePicker.SelectedDate > krajDatePicker.SelectedDate || krajDatePicker.SelectedDate < pocetakDatePicker.SelectedDate)
            {
                MessageBox.Show("Neispravan datum!", "Upozorenje");
                return false;
            }
            else if (!(controller.provjeraTereta(Convert.ToInt32(teretTextBox.Text), Convert.ToInt32(voziloTextBox.Text))))
            {
                MessageBox.Show("Unijeli ste previše tereta za odabrano vozilo!", "Upozorenje");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Metoda koja pohranjuje unesene podatke o putnom radnom listu u objekt.
        /// </summary>
        /// <returns>Objekt klase Putni radni list.</returns>
        private PutniRadniList dohvatPodatakaPTR()
        {
            PutniRadniList PTR = new PutniRadniList();
            try
            {
                string[] IDkreira = cmbPTRSlobodniZaposlenici.Text.Split(' ');
                PTR.vozilo = Convert.ToInt32(voziloTextBox.Text);
                PTR.kreira = Convert.ToInt32(IDkreira[0]);
                PTR.kilometraza = Convert.ToInt32(kilometrazaTextBox.Text);
                PTR.pocetak = Convert.ToDateTime(pocetakDatePicker.Text);
                if (!string.IsNullOrWhiteSpace(krajDatePicker.Text))
                    PTR.kraj = Convert.ToDateTime(krajDatePicker.Text);
                PTR.mjesto_utovara = mjesto_utovaraTextBox.Text;
                PTR.mjesto_istovara = mjesto_istovaraTextBox.Text;
                PTR.teret = Convert.ToInt32(teretTextBox.Text);
                PTR.napomene = napomeneTextBox.Text;
                return PTR;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Upozorenje");
            }
            finally
            {


            }
            return null;
        }

        /// <summary>
        /// Metoda koja pohranjuje unesene podatke o radnim satima u listu
        /// </summary>
        /// <returns>Vraća listu zaposlenika i njihovih radnih sati.</returns>
        private List<radni_sati> dohvatPodatakaRS()
        {
            try
            {
                List<radni_sati> zaposlenici = new List<radni_sati>();
                radni_sati RS = new radni_sati();
                //RS.putni_radni_list = Convert.ToInt32(id_putnog_radnog_listaTextBox.Text);
                RS.zaposlenik = Convert.ToInt32(zaposlenikTextBox.Text);
                zaposlenici.Add(RS);
                if (zaposlenikTextBox1.Text != "")
                {
                    radni_sati RS1 = new radni_sati();
                    //RS1.putni_radni_list = Convert.ToInt32(id_putnog_radnog_listaTextBox.Text);
                    RS1.zaposlenik = Convert.ToInt32(zaposlenikTextBox1.Text);
                    zaposlenici.Add(RS1);
                }
                return zaposlenici;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Upozorenje");
            }
            return null;
        }

        /// <summary>
        /// Metoda koja poziva klasu za unos podataka o putnom radnom listu u bazu podataka.
        /// </summary>
        /// <param name="sender">Referenca na gumb Spremi</param>
        /// <param name="e">Sadrži argumente za događaje vezane uz gumb Spremi</param>
        private void btnSpremiPTR_Click(object sender, RoutedEventArgs e)
        {
            if (provjeriPopunjenostPTR() == true)
            {
                PregledPTR PTR = new PregledPTR();
                controller.dodaj(dohvatPodatakaPTR(), dohvatPodatakaRS());
                PTR.putniRadniListDataGrid.ItemsSource = model.dohvatPTR();
                PTR.radni_satiDataGrid.ItemsSource = model.dohvatRS();
                MessageBox.Show("Putni radni list uspješno dodan!", "Obavijest");
                ocistiTextBox(this);
            }
        }

        /// <summary>
        /// Metoda koja se poziva kad korisnik pritisne na gumb Izmijeni Putni radni list.
        /// Najprije provjerava ispravnost unesenih podataka te ih, ukoliko su ispravni, pohranjuje u bazu podataka.
        /// </summary>
        /// <param name="sender">Referenca na gumb Izmijeni</param>
        /// <param name="e">Sadrži argumente za događaje vezane uz gumb Izmijeni</param>
        private void btnIzmijeniPTR_Click(object sender, RoutedEventArgs e)
        {
            radni_sati rsIzmjenjenipodaci = new radni_sati();
            PregledPTR pregled = new PregledPTR();
            int PTRId = Convert.ToInt32(id_putnog_radnog_listaTextBox.Text);
            int rsIzmjenjenVozac1;
            int rsIzmjenjenVozac2;
            int brojSati;
            if (!string.IsNullOrWhiteSpace(zaposlenikTextBox.Text))
                rsIzmjenjenVozac1 = Convert.ToInt32(zaposlenikTextBox.Text);
            if (!string.IsNullOrWhiteSpace(zaposlenikTextBox1.Text))
                rsIzmjenjenVozac2 = Convert.ToInt32(zaposlenikTextBox1.Text);
            if (!string.IsNullOrWhiteSpace(zaposlenikTextBox1.Text))
                rsIzmjenjenVozac2 = Convert.ToInt32(zaposlenikTextBox1.Text);
            //controller.izmjeni(PTRId, rsIzmjenjenVozac1, rsIzmjenjenVozac2);
            MessageBox.Show("Putni radni list uspješno izmjenjen!", "Obavijest");
            pregled.putniRadniListDataGrid.ItemsSource = model.dohvatPTR();
            pregled.radni_satiDataGrid.ItemsSource = model.dohvatRS();

        }

        /// <summary>
        /// Metoda koja u datagrid za popis vozila na servisima učitava izračunatu razliku u kilometraži vozila.
        /// </summary>
        /// <param name="sender">Referenca na objekt VozilaServis</param>
        /// <param name="e">Sadrži argumente za događaje vezane uz objekt VozilaServis</param>
        private void VozilaServis_Loaded(object sender, RoutedEventArgs e)
        {
            vozilaservisdatagrid.ItemsSource = controller.dohvatiRazlikuKm();
        }

        /// <summary>
        /// Metoda koja u datagrid za popis vozila učitava sva vozila.
        /// </summary>
        /// <param name="sender">Referenca na combobox kontrolu</param>
        /// <param name="e">Sadrži argumente za događaje vezane uz combobox kontrolu/param>
        private void popisSvih(object sender, RoutedEventArgs e)
        {
            string podatak = "sva_vozila";
            voziloDataGrid.ItemsSource = model.dohvatVozila(podatak);
        }


        /// <summary>
        /// Metoda koja u datagrid za popis vozila učitava sva vozila.
        /// </summary>
        /// <param name="sender">Referenca na combobox kontrolu</param>
        /// <param name="e">Sadrži argumente za događaje vezane uz combobox kontrolu/param>
        private void popisSvihVozaca(object sender, RoutedEventArgs e)
        {
            string podatak = "svi_vozaci";
            zaposleniciDataGrid.ItemsSource = model.dohvatVozaca(podatak);
        }

        private void popisSlobodnihVozaca(object sender, RoutedEventArgs e)
        {
            zaposleniciDataGrid.ItemsSource = controller.ispisSlobodnihZaposlenika();
        }

        /// <summary>
        /// Metoda koja prikazuje nadolazeće registracije na otvoreni tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VozilaRegistracija_Loaded(object sender, RoutedEventArgs e)
        {
            registracijadatagrid.ItemsSource = controller.vozilaRegistracija();
        }

        /// <summary>
        /// Metoda za filtiranje registracija prema mjesecu.
        /// </summary>
        private void TjednaRegistracija(object sender, RoutedEventArgs e)
        {
            registracijadatagrid.ItemsSource = controller.filtriraneRegistracije("tjedan");
        }

        /// <summary>
        /// Metoda koja ispisuje tjedne registracije.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MjesecnaRegistracija(object sender, RoutedEventArgs e)
        {
            registracijadatagrid.ItemsSource = controller.filtriraneRegistracije("mjesec");
        }

        /// <summary>
        /// Metoda koja ispisuje zaposlenike na godišnjem odmoru
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GodisnjiOdmor(object sender, RoutedEventArgs e)
        {
            datagridGodisnjiOdmor.ItemsSource = model.dohvatiGodisnjiOdmor("see");
        }

        /// <summary>
        /// Postavlja zaposlenike koji su na godišenjem u datagrid.
        /// </summary>
        private void prikaziPodatkeDatum(object sender, SelectionChangedEventArgs e)
        {
            DateTime odabraniDat = calGodisnji.SelectedDate.Value;

            datagridGodisnjiOdmor.ItemsSource = controller.godisnjiOdmorNaDatum(odabraniDat);

        }

        /// <summary>
        /// dohvaća sve zaposlenike koj su danas na godišnjem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void odmorDanas(object sender, RoutedEventArgs e)
        {
            datagridGodisnjiOdmor.ItemsSource = model.dohvatiGodisnjiOdmor("danas");
        }

        /// <summary>
        /// dohvaća sve zaposlenike koj su sljedećih tjedan dana na godišnjem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void odmorTjedan(object sender, RoutedEventArgs e)
        {
            datagridGodisnjiOdmor.ItemsSource = controller.filtiranjeGO("tjedan");
        }

        /// <summary>
        /// dohvaća sve zaposlenike koj su u sljedećih mjesec dana na godišnjem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void odmorMjesec(object sender, RoutedEventArgs e)
        {
            datagridGodisnjiOdmor.ItemsSource = controller.filtiranjeGO("mjesec");
        }

        /// <summary>
        /// Metoda kojom brišemo Putni radni list i vozače koji su mu dodjeljeni.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnObrisiPTR_Click(object sender, RoutedEventArgs e)
        {
            string podatak = "obrisi_PTR";
            int PTRId = 0;
            if (!string.IsNullOrWhiteSpace(id_putnog_radnog_listaTextBox.Text))
            {
                PTRId = Convert.ToInt32(id_putnog_radnog_listaTextBox.Text);
                controller.obrisi(PTRId, podatak);
                PregledPTR PTR = new PregledPTR();
                MessageBox.Show("Putni radni list uspješno obrisan!", "Obavijest");
                PTR.putniRadniListDataGrid.ItemsSource = model.dohvatPTR();
                PTR.radni_satiDataGrid.ItemsSource = model.dohvatRS();
            }
            ocistiTextBox(this);
        }

        /// <summary>
        /// Meotda koja provjerava dal su uneseni svi podaci potrebni za registraciju vozila.
        /// </summary>
        /// <returns></returns>
        private bool provjeriPopunjenostRegistracija()
        {
            if (string.IsNullOrWhiteSpace(cmbVrstaVozilaReg.Text) ||
               string.IsNullOrWhiteSpace(registracijaTextBox3.Text) ||
               string.IsNullOrWhiteSpace(nazivTextBox3.Text) ||
               string.IsNullOrWhiteSpace(datumDatePicker.Text) ||
               string.IsNullOrWhiteSpace(txtNapomena.Text))
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Metoda za dohvat podataka za unos nove registracije.
        /// </summary>
        /// <returns></returns>
        private tehnicki_pregled unosRegistracije()
        {
            tehnicki_pregled teh = new tehnicki_pregled();
            teh.vozilo = Convert.ToInt32(id_voziloTextBox3.Text);
            teh.datum = Convert.ToDateTime(datumDatePicker.Text);
            teh.napomena = txtNapomena.Text;
            return teh;
        }

        /// <summary>
        /// Metoda kojom se odabrano vozilo šalje na registraciju pritiskom na gumb.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPosaljiNaRegistraciju_Click(object sender, RoutedEventArgs e)
        {
            if (provjeriPopunjenostRegistracija())
            {
                controller.dodaj(unosRegistracije());
                MessageBox.Show("Vozilo poslano na registraciju!", "Obavijest");
                ocistiTextBox(this);
            }
            else MessageBox.Show("Niste unijeli sve podatke!", "Upozorenje!");

        }

        /// <summary>
        /// Metoda za ispis vozila koja su DANAS (znaci odabrana u datagridu na tabu nadolazeće registracije) poslana na registraciju. Poslana vozila se prikazuju na novoj formi, odabirom nekog vozila na ispisu
        /// prikazuju se podaci za vozilo na glavnoj formi (njezinim textboksovima).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIspisRegistracija_Click(object sender, RoutedEventArgs e)
        {
            frmIspisRegistracija frmIspisReg = new frmIspisRegistracija();
            frmIspisReg.ShowDialog();
            VozilaRegistracija reg = new VozilaRegistracija();
            int idVozila;
            if (!string.IsNullOrWhiteSpace(frmIspisReg.id_voziloTextBox3.Text))
            {
                idVozila = Convert.ToInt32(frmIspisReg.id_voziloTextBox3.Text);
                reg = controller.ispisRegistracija(idVozila);
                id_voziloTextBox3.Text = Convert.ToString(reg.id_vozilo);
                nazivTextBox3.Text = reg.naziv;
                cmbVrstaVozilaReg.Text = Convert.ToString(reg.vrsta_vozila_id);
                registracijaTextBox3.Text = reg.registracija;
                datumDatePicker.Text = Convert.ToString(reg.sljedeca_registracija);
                txtNapomena.Text = reg.napomena;
                txtIdTehnickog.Text = Convert.ToString(reg.id_tehnickog_pregleda);
            }
        }

        /// <summary>
        /// Metoda koja briše registraciju vozila.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnObrisiRegistraciju_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdTehnickog.Text))
            {
                controller.obrisi(Convert.ToInt32(txtIdTehnickog.Text), "brisanje_registracije");
                MessageBox.Show("Registracija uspješno obrisana!", "Obavijest");
                ocistiTextBox(this);
            }
        }

        /// <summary>
        /// Metoda koja provjerava dal su uneseni svi potrebni podaci za slanje vozila na servis.
        /// </summary>
        /// <returns></returns>
        private bool provjeriPopunjenostServisa()
        {
            if (string.IsNullOrWhiteSpace(id_voziloTextBox4.Text)
                || string.IsNullOrWhiteSpace(nazivTextBox4.Text)
                || string.IsNullOrWhiteSpace(id_vrsta_vozilaTextBox4.Text)
                || string.IsNullOrWhiteSpace(registracijaTextBox4.Text)
                || string.IsNullOrWhiteSpace(txtServisniInterval.Text)
                || string.IsNullOrWhiteSpace(txtTrenutnoStanje.Text)
                || string.IsNullOrWhiteSpace(datumDatePicker1.Text)
                || string.IsNullOrWhiteSpace(datumDatePicker1.Text))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Metoda koja dohvaća podatke vezane uz servis vozila
        /// </summary>
        /// <returns>Vraća objekt klase servis</returns>
        private servis dohvatServisa()
        {
            servis vozilo = new servis();
            vozilo.vozilo = Convert.ToInt32(id_voziloTextBox4.Text);
            vozilo.prijedjeni_km = Convert.ToInt32(txtTrenutnoStanje.Text);
            vozilo.opis = opisTextBox.Text;
            vozilo.datum = Convert.ToDateTime(datumDatePicker1.Text);
            return vozilo;
        }

        /// <summary>
        /// Metoda koja pritiskom na gumb šalje vozilo na servis. Najprije provjerava ispravnost unesenih podataka.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPosaljiNaServis_Click(object sender, RoutedEventArgs e)
        {
            if (provjeriPopunjenostServisa())
            {
                controller.dodaj(dohvatServisa());
                MessageBox.Show("Vozilo poslano na servis!", "Obavijest");
                ocistiTextBox(this);
                vozilaservisdatagrid.ItemsSource = controller.dohvatiRazlikuKm();
            }
            else MessageBox.Show("Niste unijeli sve podatke!", "Upozorenje!");
        }

        /// <summary>
        /// Metoda koja provjerava da li su uneseni svi podaci potrebni za godišnji odmor.
        /// </summary>
        /// <returns></returns>
        private bool provjeriPopunjenostGodisnjeg()
        {
            if (string.IsNullOrWhiteSpace(pocetakDatePicker1.Text)
                || string.IsNullOrWhiteSpace(krajDatePicker1.Text)
                || string.IsNullOrWhiteSpace(cmbZaposleniciCombo.Text))
                return false;
            return true;
        }

        /// <summary>
        /// Metoda koja dohvaća podatke o godišnjem odmoru zaposlenika na određeni dan.
        /// </summary>
        /// <returns>Vraća objekt klase godisnji_odmor</returns>
        private godisnji_odmor dohvatGodisnjeg()
        {
            string[] proba = cmbZaposleniciCombo.Text.Split(' ');
            godisnji_odmor odmor = new godisnji_odmor();
            odmor.zaposlenik = Convert.ToInt32(proba[0]);
            odmor.pocetak = Convert.ToDateTime(pocetakDatePicker1.Text);
            odmor.kraj = Convert.ToDateTime(krajDatePicker1.Text);
            return odmor;
        }

        /// <summary>
        /// Metoda kojom se određnog zaposlenika šalje na godišnji odmor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void posaljiGodisnji_Click(object sender, RoutedEventArgs e)
        {
            if (provjeriPopunjenostGodisnjeg())
            {
                controller.dodaj(dohvatGodisnjeg());
                MessageBox.Show("Zaposlenik dodan na godišnji odmor!", "Obavijest");
                ocistiTextBox(this);
                datagridGodisnjiOdmor.ItemsSource = model.dohvatiGodisnjiOdmor("see");
                ocistiTextBox(this);
            }
            else MessageBox.Show("Niste unijeli sve podatke!", "Upozorenje!");
        }

        /// <summary>
        /// Metoda koja otvara formu frmIspisServisa na kojoj su prikazana vozila koja su danas poslana na servis. Odabirom nekog vozila
        /// iz datagrida na frmIspisServisa popunit će se pripdani textboksovi na glavnoj formi. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ispisServisa_Click(object sender, RoutedEventArgs e)
        {
            frmIspisServisa servisIspis = new frmIspisServisa();
            servisIspis.ShowDialog();
            VozilaServis ser = new VozilaServis();
            int idVozila;
            if (!string.IsNullOrWhiteSpace(servisIspis.id_voziloTextBox4.Text))
            {
                idVozila = Convert.ToInt32(servisIspis.id_voziloTextBox4.Text);
                ser = controller.ispisServisa(idVozila);
                id_voziloTextBox4.Text = Convert.ToString(ser.id_vozilo);
                nazivTextBox4.Text = ser.naziv;
                registracijaTextBox4.Text = ser.registracija;
                datumDatePicker1.Text = Convert.ToString(ser.datum_servisa);
                txtServisniInterval.Text = Convert.ToString(ser.servisni_interval);
                txtStanjeNaZadnjemServisu.Text = Convert.ToString(ser.stanje_na_zadnjem_servisu);
                txtTrenutnoStanje.Text = Convert.ToString(ser.trenutno_stanje_km);
                txtIdServisa.Text = Convert.ToString(ser.id_servisa);
            }


        }

        /// <summary>
        /// Metoda kojom se pritiskom na gumb briše servis vozila.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnObrišiServis_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdServisa.Text))
            {
                controller.obrisi(Convert.ToInt32(txtIdServisa.Text), "brisanje_servisa");
                MessageBox.Show("Servis uspješno obrisan!", "Obavijest");
                ocistiTextBox(this);
                vozilaservisdatagrid.ItemsSource = controller.dohvatiRazlikuKm();
            }
        }

        /// <summary>
        /// Metoda koja popunjava datagrid s podacima o slobodnim vozilima.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popisSlobodnihVozila(object sender, RoutedEventArgs e)
        {
            voziloDataGrid.ItemsSource = controller.ispisSlobodnihVozila();
        }


        /// <summary>
        /// Metoda koja na load metodi puni combobox s slobodnim zaposlenicima.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbZaposleniciCombo_DropDownOpened(object sender, EventArgs e)
        {
            List<zaposlenici> zaCombo = new List<zaposlenici>();
            zaCombo = controller.ispisSlobodnihZaposlenika();
            foreach (zaposlenici i in zaCombo)
            {
                cmbZaposleniciCombo.Items.Add(i.id_zaposlenici + " " + i.prezime + " " + i.ime);
            }
        }

        /// <summary>
        /// Metoda kojom se pritiskom na gumb briše godišnji odmor zaposlenika.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnObrisiGodisnjiOdmor_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(id_godinjeg_odmoraTextBox.Text))
            {
                controller.obrisi(Convert.ToInt32(id_godinjeg_odmoraTextBox.Text), "brisanje_godisnjeg");
                MessageBox.Show("Godišnji odmor uspješno obrisan!", "Obavijest");
                ocistiTextBox(this);
                datagridGodisnjiOdmor.ItemsSource = model.dohvatiGodisnjiOdmor("see");
            }
        }

        int brPonavljanja = 0; //koliko puta se otvorio combobox
        private void cmbPTRSlobodniZaposlenici_DropDownOpened(object sender, EventArgs e)
        {
            if (brPonavljanja++ < 1)
            {
                List<zaposlenici> zaCombo = new List<zaposlenici>();
                zaCombo = controller.ispisSlobodnihZaposlenika();
                foreach (zaposlenici i in zaCombo)
                {
                    if (i.uloga == 5 || i.uloga == 6)
                        cmbPTRSlobodniZaposlenici.Items.Add(i.id_zaposlenici + " " + i.prezime + " " + i.ime);
                }
            }
        }

        /// <summary>
        /// Metoda koja se poziva kad korisnik odabere tab kontrolu tabDokumentacija
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabDokumentacija(object sender, RoutedEventArgs e)
        {
            Process.Start("DesingPI.chm");
        }

        /// <summary>
        /// Metoda koja poziva formu za unos vrste vozila
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDodajVrstuVozila_Click(object sender, RoutedEventArgs e)
        {
            frmUnosVrsteVozila vrsta_vozila = new frmUnosVrsteVozila();
            vrsta_vozila.Show();
        }

        int brPonavljanjaVrstaVozila = 0;

        int brPonavljanjaUlogaZaposlenika = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbUloga_DropDownOpened(object sender, EventArgs e)
        {
            if (brPonavljanjaUlogaZaposlenika++ < 1)
            {
                List<uloga> zaCombo = new List<uloga>();
                zaCombo = model.dohvatiUloge();
                foreach (uloga i in zaCombo)
                {
                    cmbUloga.Items.Add(i.id_uloge + " " + i.naziv);
                }
            }
        }

        int brPonavljanjaVrstaVozila2 = 0;

        private void cmbVrstaVozilaReg_DropDownOpened_1(object sender, EventArgs e)
        {
            if (brPonavljanjaVrstaVozila2++ < 1)
            {
                List<vrsta_vozila> zaCombo = new List<vrsta_vozila>();
                zaCombo = model.dohvatiVrsteVozila();
                foreach (vrsta_vozila i in zaCombo)
                {
                    cmbVrstaVozilaReg.Items.Add(i.id_vrsta_vozila + " " + i.naziv);
                }
            }
        }

        private void cmbVrstaVozila_DropDownOpened_1(object sender, EventArgs e)
        {
            if (brPonavljanjaVrstaVozila++ < 1)
            {
                List<vrsta_vozila> zaCombo = new List<vrsta_vozila>();
                zaCombo = model.dohvatiVrsteVozila();
                foreach (vrsta_vozila i in zaCombo)
                {
                    cmbVrstaVozila.Items.Add(i.id_vrsta_vozila + " " + i.naziv);
                }
            }

        }

        /// <summary>
        /// Metoda koja računa cijenu satnice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIzračunajSatnicu_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCijenaSatnice.Text))
            {
                satnicaDataGrid.ItemsSource = controller.izracunSatnice(Convert.ToInt32(txtCijenaSatnice.Text));
            }
        }

        private void btnUnosVrsteVozila_Click(object sender, RoutedEventArgs e)
        {
            frmUnosVrsteVozila unosVrsteVozila = new frmUnosVrsteVozila();
            unosVrsteVozila.ShowDialog();
        }

        private void btnIspisi_Click(object sender, RoutedEventArgs e)
        {
            DateTime sada = DateTime.Now;
            string naslov = "Mjesecni obracun radnih sati za " + sada.Month + "/"+sada.Year;
            string naziv = "Obracun_" + sada.Month + "_" + sada.Year;
            controller.exportObracunSati(satnicaDataGrid, naslov, naziv);
        }

        private void btnIspisiVozila_Click(object sender, RoutedEventArgs e)
        {
            DateTime sada = DateTime.Now;
            string naslov;
            string naziv;
            if(cmbOdabirVozila.SelectedIndex == 0 )
            {
                naslov = "Vozila " + sada.Day+"/"+sada.Month + "/" + sada.Year;
                naziv = "Vozila_" + sada.Day +"_"+ sada.Month + "_" + sada.Year;
            }
            else
            {
                naslov = "Slobodna vozila " + sada.Day + "/" + sada.Month + "/" + sada.Year;
                naziv = "Slobodna_vozila" + sada.Day + "_" + sada.Month + "_" + sada.Year;
            }

            controller.exportObracunSati(voziloDataGrid, naslov, naziv);
        }

        private void btnIspisiVozace_Click(object sender, RoutedEventArgs e)
        {
            DateTime sada = DateTime.Now;
            string naslov;
            string naziv;
            if (cmbOdabirVozila.SelectedIndex == 0)
            {
                naslov = "Vozaci " + sada.Day + "/" + sada.Month + "/" + sada.Year;
                naziv = "Vozaci_" + sada.Day + "_" + sada.Month + "_" + sada.Year;
            }
            else
            {
                naslov = "Slobodni vozaci " + sada.Day + "/" + sada.Month + "/" + sada.Year;
                naziv = "Slobicni_vozaci" + sada.Day + "_" + sada.Month + "_" + sada.Year;
            }
            controller.exportObracunSati(zaposleniciDataGrid, naslov, naziv);
        }
        


    }
}
