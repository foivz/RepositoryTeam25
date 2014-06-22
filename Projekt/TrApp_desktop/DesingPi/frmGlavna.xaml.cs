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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TrAppModel model = new TrAppModel();
        TrAppController controller = new TrAppController();
        private int uloga;

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
        /// <returns>Popunje objekt vozilo</returns>
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnObrisiZaposlenika_Click(object sender, RoutedEventArgs e)
        {
            string podatak = "svi_vozaci";
            if (string.IsNullOrWhiteSpace(id_zaposleniciTextBox.Text))
                return;
            int zaposlenikId = Convert.ToInt32(id_zaposleniciTextBox.Text);
            controller.obrisi(zaposlenikId, podatak);
            MessageBox.Show("Vozilo uspješno obrisano!", "Obavijest");
            zaposleniciDataGrid.ItemsSource = model.dohvatVozaca(podatak);
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
                string.IsNullOrWhiteSpace(cmbUloga.Text) ||
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


        /// <summary>
        /// Forma koja služi za pregled Putnih radnih listova. Klikom na pregled otvara se nova forma, a na novoj formi možemo odabrati postojeći PTR kojeg onda 
        /// potom mijenjamo ili brisemo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPregledPTR_Click(object sender, RoutedEventArgs e)
        {
            //kreiranje objekta za prvi objekt u listi
            PutniRadniList odabraniPTRObj = new PutniRadniList();

            List<radni_sati> odabraniVozaci = new List<radni_sati>();
            radni_sati odabraniVozaciObj = new radni_sati();

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

        /// <summary>
        /// Metoda koja služi za provjeru popunjenosti textboksova za putni radni list.
        /// Ako je unesen neispravan datum i teret javlja grešku.
        /// </summary>
        /// <returns></returns>
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

        private void VozilaServis_Loaded(object sender, RoutedEventArgs e)
        {
            vozilaservisdatagrid.ItemsSource = controller.dohvatiRazlikuKm();
        }

        private void popisSvih(object sender, RoutedEventArgs e)
        {
            string podatak = "sva_vozila";
            voziloDataGrid.ItemsSource = model.dohvatVozila(podatak);
        }

        private void popisSlobodnih(object sender, RoutedEventArgs e)
        {
            string podatak = "";
            voziloDataGrid.ItemsSource = model.dohvatVozila(podatak);
        }

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
        /// Metoda koja provjerava dal su unijeti svi potrebni podaci za slanje vozila na servis.
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

        private servis dohvatServisa()
        {
            servis vozilo = new servis();
            vozilo.vozilo = Convert.ToInt32(id_voziloTextBox4.Text);
            vozilo.prijedjeni_km = Convert.ToInt32(txtTrenutnoStanje.Text);
            vozilo.opis = opisTextBox.Text;
            vozilo.datum = Convert.ToDateTime(datumDatePicker1.Text);
            return vozilo;
        }

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
        /// Metoda koja provjerava dal su uneseni svi podaci potrebni za godišnji odmor.
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

        private godisnji_odmor dohvatGodisnjeg()
        {
            string[] proba = cmbZaposleniciCombo.Text.Split(' ');
            godisnji_odmor odmor = new godisnji_odmor();
            odmor.zaposlenik = Convert.ToInt32(proba[0]);
            odmor.pocetak = Convert.ToDateTime(pocetakDatePicker1.Text);
            odmor.kraj = Convert.ToDateTime(krajDatePicker1.Text);
            return odmor;
        }

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

        /******************************************************************************/
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

        int brPonavljanja = 0; //kolko put se otvorio combobox
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

        private void tabDokumentacija(object sender, RoutedEventArgs e)
        {
            Process.Start("DesingPI.chm");
        }

        private void btnDodajVrstuVozila_Click(object sender, RoutedEventArgs e)
        {
            frmUnosVrsteVozila vrsta_vozila = new frmUnosVrsteVozila();
            vrsta_vozila.Show();
        }

        int brPonavljanjaVrstaVozila = 0;

        int brPonavljanjaUlogaZaposlenika = 0;
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



    }
}
