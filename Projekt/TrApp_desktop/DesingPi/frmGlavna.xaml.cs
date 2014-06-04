using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TrAppModel model = new TrAppModel();
        TrAppController controller = new TrAppController();

        public MainWindow()
        {
            InitializeComponent();
        }

        void tabPopisVozila(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 0;
            tabVozila.SelectedIndex = 0;
        }

        void tabRegistracija(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 0;
            tabVozila.SelectedIndex = 1;
        }
        void tabServis(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 0;
            tabVozila.SelectedIndex = 2;
        }
        void tabTehnickiPregled(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 0;
            tabVozila.SelectedIndex = 3;
        }

        void tabPopisVozaca(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 1;
            tabVozaci.SelectedIndex = 0;
        }

        void tabGodisnjiOdmor(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 1;
            tabVozaci.SelectedIndex = 1;
        }

        void tabRadniSati(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 1;
            tabVozaci.SelectedIndex = 2;
        }

        void tabUnosPutnogRadnogLista(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 2;
            tabTransportniPodaci.SelectedIndex = 0;
        }

        void tabUnosZaposlenika(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 2;
            tabTransportniPodaci.SelectedIndex = 1;
        }

        void tabUnosVozila(object sender, EventArgs e)
        {
            tabGlavni.SelectedIndex = 2;
            tabTransportniPodaci.SelectedIndex = 2;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource t25_DBEntitiesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("t25_DBEntitiesViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // t25_DBEntitiesViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource putniRadniListViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("putniRadniListViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // putniRadniListViewSource.Source = [generic data source]
        }

        /// <summary>
        /// Metoda koja govori koji datagrid s vozilima će biti popunjen podacima.
        /// Želi se izbjeći da se pri pokretanju programa odmah oba popune.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popisZaposlenika_Loaded(object sender, RoutedEventArgs e)
        {
            string a = "System.Windows.Controls.TabItem Header:Popis vozila Content:System.Windows.Controls.TabItem Header:Unos vozila Content:System.Windows.Controls.TabItem Header:Unos vozila Content:";
            string b = e.OriginalSource.ToString();
            if (string.Compare(a, b) == 1)
            {
                zaposleniciDataGrid.ItemsSource = model.dohvatVozaca();
            }
            else
            {
                zaposleniciDataGrid1.ItemsSource = model.dohvatZaposlenika();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            else
            {
                MessageBox.Show("Niste unijeli sve podatke!", "Upozorenje");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void btnObrisiVozilo_Click(object sender, RoutedEventArgs e)
        {
            string podatak = "vozilo";
            string podatak2 = "sva_vozila";
            int voziloId = Convert.ToInt32(id_voziloTextBox.Text);
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
            if (string.IsNullOrWhiteSpace(id_vrsta_vozilaTextBox.Text) ||
               string.IsNullOrWhiteSpace(registracijaTextBox.Text) ||
               string.IsNullOrWhiteSpace(nazivTextBox.Text) ||
               string.IsNullOrWhiteSpace(godina_proizvodnjeTextBox.Text) ||
               string.IsNullOrWhiteSpace(nosivostTextBox.Text) ||
               string.IsNullOrWhiteSpace(servisni_intervalTextBox.Text) ||
               string.IsNullOrWhiteSpace(datum_registracijeDatePicker.Text) ||
               string.IsNullOrWhiteSpace(pocetno_stanje_kmTextBox.Text))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Metoda koja dohvaća podatke iz textBox-ova i sprema ih u objekt vozilo
        /// </summary>
        /// <returns>Popunje objekt vozilo</returns>
        private vozilo dohvatiPodatkeVozilo()
        {
            vozilo vozilo = new vozilo();
            vozilo.vrsta_vozila_id = int.Parse(id_vrsta_vozilaTextBox.Text);
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDodajZaposlenika_Click(object sender, RoutedEventArgs e)
        {
            if (provjeriPopunjenostZaposlenika())
            {
                controller.dodaj(dohvatiPodatkeZaposlenika());
                zaposleniciDataGrid.ItemsSource = model.dohvatVozaca();
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIzmjeniZaposlenika_Click(object sender, RoutedEventArgs e)
        {
            if (provjeriPopunjenostZaposlenika())
            {

                int zaposlenikId = Convert.ToInt32(id_zaposleniciTextBox.Text);
                controller.izmjeni(zaposlenikId, dohvatiPodatkeZaposlenika());
                MessageBox.Show("Zaposlenik uspješno izmjenjen!", "Obavijest");
                zaposleniciDataGrid.ItemsSource = model.dohvatVozaca();
                zaposleniciDataGrid1.ItemsSource = model.dohvatZaposlenika();
            }
            else
            {
                MessageBox.Show("Niste unijeli sve podatke!", "Upozorenje");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnObrisiZaposlenika_Click(object sender, RoutedEventArgs e)
        {
            string podatak = "zaposlenik";
            int zaposlenikId = Convert.ToInt32(id_zaposleniciTextBox.Text);
            controller.obrisi(zaposlenikId, podatak);
            MessageBox.Show("Vozilo uspješno obrisano!", "Obavijest");
            zaposleniciDataGrid.ItemsSource = model.dohvatVozaca();
            zaposleniciDataGrid1.ItemsSource = model.dohvatZaposlenika();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
                string.IsNullOrWhiteSpace(ulogaTextBox.Text) ||
                string.IsNullOrWhiteSpace(datum_zaposlenjaDatePicker.Text))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private zaposlenici dohvatiPodatkeZaposlenika()
        {
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
            zaposlenici.uloga = Convert.ToInt32(ulogaTextBox.Text);
            zaposlenici.datum_zaposlenja = Convert.ToDateTime(datum_zaposlenjaDatePicker.Text);
            return zaposlenici;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOdaberiSlobodnaVozila(object sender, RoutedEventArgs e)
        {
            SlobodnaVozila frmSlobodnaVozila = new SlobodnaVozila();
            frmSlobodnaVozila.ShowDialog();
            voziloTextBox.Text = frmSlobodnaVozila.txtID.Text;
        }

        private void btnPregledPTR_Click(object sender, RoutedEventArgs e)
        {
            //kreiranje liste za dohvat objekata
            List<PutniRadniList> odabraniPTR = new List<PutniRadniList>();
            //kreiranje objekta za prvi objekt u listi
            PutniRadniList odabraniPTRObj = new PutniRadniList();
            //otvaranje forme za odabir putnig radnog lista
            PregledPTR frmPTR = new PregledPTR();
            frmPTR.ShowDialog();
            id_putnog_radnog_listaTextBox.Text = frmPTR.txtIDPTR.Text;
            int idPTR = 0;
            
           
                idPTR = Convert.ToInt32(id_putnog_radnog_listaTextBox.Text);
          


            odabraniPTR = model.dohvatPTR(idPTR);
            odabraniPTRObj = odabraniPTR.First<PutniRadniList>();
            
            voziloTextBox.Text = odabraniPTRObj.vozilo.ToString();
            pocetakDatePicker.Text = odabraniPTRObj.pocetak.ToString();
            krajDatePicker.Text = odabraniPTRObj.kraj.ToString();
            // to do -> zaposlenikTextBox.Text = odabraniPTRObj
            mjesto_utovaraTextBox.Text = odabraniPTRObj.mjesto_utovara.ToString();
            mjesto_istovaraTextBox.Text = odabraniPTRObj.mjesto_istovara.ToString();
            kreiraTextBox.Text = odabraniPTRObj.kreira.ToString();
            kilometrazaTextBox.Text = odabraniPTRObj.kilometraza.ToString();



        }

        private void btnOdaberiVozaca1_Click(object sender, RoutedEventArgs e)
        {
            SlobodniVozaci vozaci = new SlobodniVozaci();
            vozaci.ShowDialog();
            zaposlenikTextBox.Text = vozaci.txtID.Text;
        }

        private void btnOdaberiVozaca2_Click(object sender, RoutedEventArgs e)
        {
            SlobodniVozaci vozaci = new SlobodniVozaci();
            vozaci.ShowDialog();
            zaposlenikTextBox1.Text = vozaci.txtID.Text;
        }

        private bool provjeriPopunjenostPTR()
        {
            if (string.IsNullOrWhiteSpace(voziloTextBox.Text) ||
                string.IsNullOrWhiteSpace(zaposlenikTextBox.Text) ||
                string.IsNullOrWhiteSpace(zaposlenikTextBox1.Text) ||
                string.IsNullOrWhiteSpace(pocetakDatePicker.Text) ||
                string.IsNullOrWhiteSpace(krajDatePicker.Text) ||
                string.IsNullOrWhiteSpace(kilometrazaTextBox.Text) ||
                string.IsNullOrWhiteSpace(kreiraTextBox.Text) ||
                string.IsNullOrWhiteSpace(mjesto_utovaraTextBox.Text) ||
                string.IsNullOrWhiteSpace(mjesto_istovaraTextBox.Text))
            {
                return false;
            }
            return true;
        }

        private PutniRadniList dohvatPodatakaPTR()
        {
            PutniRadniList PTR = new PutniRadniList();
            PTR.vozilo = Convert.ToInt32(voziloTextBox.Text);
            PTR.kreira = Convert.ToInt32(kreiraTextBox.Text);
            PTR.kilometraza = Convert.ToInt32(kilometrazaTextBox.Text);
            PTR.pocetak = Convert.ToDateTime(pocetakDatePicker.Text);
            PTR.kraj = Convert.ToDateTime(krajDatePicker.Text);
            PTR.mjesto_utovara = mjesto_utovaraTextBox.Text;
            PTR.mjesto_istovara = mjesto_istovaraTextBox.Text;
            return PTR;
        }

        private radni_sati dohvatPodatakaRS()
        {
            radni_sati RS = new radni_sati();
            RS.putni_radni_list = Convert.ToInt32(id_putnog_radnog_listaTextBox.Text);
            RS.zaposlenik = Convert.ToInt32(zaposlenikTextBox.Text);
            RS.zaposlenik = Convert.ToInt32(zaposlenikTextBox1.Text);
            return RS;
        }

        private void btnSpremiPTR_Click(object sender, RoutedEventArgs e)
        {
            PregledPTR PTR = new PregledPTR();
            if (/*provjeriPopunjenostPTR()*/ true)
            {
                controller.dodaj(dohvatPodatakaPTR(), dohvatPodatakaRS());
                PTR.putniRadniListDataGrid.ItemsSource = model.dohvatPTR();
                PTR.radni_satiDataGrid.ItemsSource = model.dohvatRS();
                MessageBox.Show("Putni radni list uspješno dodan!", "Obavijest");
                ocistiTextBox(this);
            }
            else
            {
                MessageBox.Show("Niste unijeli sve podatke!", "Upozorenje");
            }
        }


        private void btnIzmijeniPTR_Click(object sender, RoutedEventArgs e)
        {
            PregledPTR PTR = new PregledPTR();
            if (provjeriPopunjenostPTR())
            {

            }
        }
    }
}
