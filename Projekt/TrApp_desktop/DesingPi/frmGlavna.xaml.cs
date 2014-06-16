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
                kreiraTextBox.Text = odabraniPTRObj.kreira.ToString();
                kilometrazaTextBox.Text = odabraniPTRObj.kilometraza.ToString();
                teretTextBox.Text = odabraniPTRObj.teret.ToString();
                if(!string.IsNullOrWhiteSpace(napomeneTextBox.Text))
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
                string.IsNullOrWhiteSpace(kreiraTextBox.Text) ||
                string.IsNullOrWhiteSpace(mjesto_utovaraTextBox.Text) ||
                string.IsNullOrWhiteSpace(mjesto_istovaraTextBox.Text)||
                string.IsNullOrWhiteSpace(teretTextBox.Text))
            {
                MessageBox.Show("Niste unijeli sve podatke!", "Upozorenje");
                return false;
            }
            else if (pocetakDatePicker.SelectedDate > krajDatePicker.SelectedDate || krajDatePicker.SelectedDate < pocetakDatePicker.SelectedDate)
            {
                MessageBox.Show("Neispravan datum!","Upozorenje");
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
                PTR.vozilo = Convert.ToInt32(voziloTextBox.Text);
                PTR.kreira = Convert.ToInt32(kreiraTextBox.Text);
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
            if (provjeriPopunjenostPTR()==true)
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
            voziloDataGrid.ItemsSource=model.dohvatVozila(podatak);
        }

        private void popisSvihVozaca(object sender, RoutedEventArgs e)
        {
            string podatak = "svi_vozaci";
            zaposleniciDataGrid.ItemsSource = model.dohvatVozaca(podatak);
        }

        private void popisSlobodnihVozaca(object sender, RoutedEventArgs e)
        {
            string podatak = "";
            zaposleniciDataGrid.ItemsSource = model.dohvatVozaca(podatak);
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
            int PTRId = Convert.ToInt32(id_putnog_radnog_listaTextBox.Text);
            controller.obrisi(PTRId, podatak);
            PregledPTR PTR = new PregledPTR();
            MessageBox.Show("Putni radni list uspješno obrisan!", "Obavijest");
            PTR.putniRadniListDataGrid.ItemsSource = model.dohvatPTR();
            PTR.radni_satiDataGrid.ItemsSource = model.dohvatRS();
            ocistiTextBox(this);
        }

        /// <summary>
        /// Meotda koja provjerava dal su uneseni svi podaci potrebni za registraciju vozila.
        /// </summary>
        /// <returns></returns>
        private bool provjeriPopunjenostRegistracija()
        {
            if (string.IsNullOrWhiteSpace(id_vrsta_vozilaTextBox3.Text) ||
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
        /// Metoda za ispis vozila koja su danas poslana na registraciju. Poslana vozila se prikazju na novoj formi, odabirom nekog vozila na ispisu
        /// prikazuju se podaci za vozilo na glavnoj formi (njezinim textboksovima).
        /// </summary> METODA NE RADI SKROZ DOBRO JER NE PRIKAZUJE TOČNO ONA VOZILA KOJA SAD POSALJES
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIspisRegistracija_Click(object sender, RoutedEventArgs e)
        {
            frmIspisRegistracija frmIspisReg = new frmIspisRegistracija();
            frmIspisReg.ShowDialog();
            VozilaRegistracija reg=new VozilaRegistracija();
            int idVozila;
            if (!string.IsNullOrWhiteSpace(frmIspisReg.id_voziloTextBox3.Text))
            {
                idVozila = Convert.ToInt32(frmIspisReg.id_voziloTextBox3.Text);
                reg = controller.ispisRegistracija(idVozila);
                id_voziloTextBox3.Text = Convert.ToString(reg.id_vozilo);
                nazivTextBox3.Text = reg.naziv;
                id_vrsta_vozilaTextBox3.Text = Convert.ToString(reg.vrsta_vozila_id);
                registracijaTextBox3.Text = reg.registracija;
                datumDatePicker.Text = Convert.ToString(reg.sljedeca_registracija);
                txtNapomena.Text = reg.napomena;
                txtIdTehnickog.Text = Convert.ToString(reg.id_tehnickog_pregleda);
            }
        }

        private void btnObrisiRegistraciju_Click(object sender, RoutedEventArgs e)
        {
            controller.obrisi(Convert.ToInt32(txtIdTehnickog.Text), "brisanje_registracije");
            MessageBox.Show("Registracija uspješno obrisana!", "Obavijest");
            ocistiTextBox(this);
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
                || string.IsNullOrWhiteSpace(txtStanjeNaZadnjemServisu.Text)
                || string.IsNullOrWhiteSpace(txtTrenutnoStanje.Text)
                || string.IsNullOrWhiteSpace(opisTextBox.Text)
                || string.IsNullOrWhiteSpace(datumDatePicker1.Text)
                || string.IsNullOrWhiteSpace(opisTextBox.Text)
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
                || string.IsNullOrWhiteSpace(zaposlenikTextBox2.Text))
                return false;
            return true;
        }

        private godisnji_odmor dohvatGodisnjeg()
        {
            godisnji_odmor odmor = new godisnji_odmor();
            odmor.zaposlenik = Convert.ToInt32(zaposlenikTextBox2.Text);
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
            }
            else MessageBox.Show("Niste unijeli sve podatke!", "Upozorenje!");
        }

    }
}
