using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DesingPi
{
    /// <summary>
    /// Interaction logic for frmUnosVrsteVozila.xaml
    /// </summary>
    public partial class frmUnosVrsteVozila : Window
    {
        TrAppModel model = new TrAppModel();
        TrAppController controller = new TrAppController();

        /// <summary>
        /// Konstruktor forme za unos vrste vozila
        /// </summary>
        public frmUnosVrsteVozila()
        {
            InitializeComponent();
            vrsta_vozilaDataGrid.ItemsSource = model.dohvatiVrsteVozila();
        }

        /// <summary>
        /// Metoda koja se poziva kod otvaranja prozora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource vrsta_vozilaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("vrsta_vozilaViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // vrsta_vozilaViewSource.Source = [generic data source]
        }

        /// <summary>
        /// Metoda koja dodaje novu vrstu vozila u bazu podataka. Prvo se provjerava jesu li uneseni
        /// svi potrebni podaci. Nakon toga dodaje se nova vrsta i datagrid se popunjava novim podacima.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDodajVrstuVozila_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nazivTextBox.Text))
            {
                vrsta_vozila vrstaVozila = new vrsta_vozila();
                vrstaVozila.naziv = nazivTextBox.Text;
                model.dodaj(vrstaVozila);
                MessageBox.Show("Vrsta vozila uspješno je dodana!", "Obavijest");
                vrsta_vozilaDataGrid.ItemsSource = model.dohvatiVrsteVozila();
            }

        }

        /// <summary>
        /// Metoda koja brise vrste vozila. Prvo se provjerava da li je unesen ID vrste koji će biti obrisan
        /// ako je onda se taj id prosljeđuje controlleru koji taj id šalje do modela te se potom
        /// vrsta s tim ID-om briše.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnObrisiVrstuVozila_Click(object sender, RoutedEventArgs e)
        {
            int IDVrsteVozila;
            if (!string.IsNullOrWhiteSpace(id_voziloTextBox.Text))
            {
                IDVrsteVozila = Convert.ToInt32(id_voziloTextBox.Text);
                controller.obrisi(IDVrsteVozila, "vrsta_vozila");
                MessageBox.Show("Vrsta vozila uspješno je obrisana!", "Obavijest");
                vrsta_vozilaDataGrid.ItemsSource = model.dohvatiVrsteVozila();
            }
        }
    }
}
