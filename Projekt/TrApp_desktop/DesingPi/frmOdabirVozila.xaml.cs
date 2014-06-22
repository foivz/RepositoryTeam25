using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
    /// Interaction logic for SlobodnaVozila.xaml
    /// </summary>
    public partial class SlobodnaVozila : Window
    {
        TrAppController controller = new TrAppController();

        /// <summary>
        /// Konstruktor forme za ispis slobodnih vozila
        /// </summary>
        public SlobodnaVozila()
        {
            string podatak = "slobodna_vozila";
            InitializeComponent();
            voziloDataGrid3.ItemsSource = controller.ispisSlobodnihVozila();
        }

        /// <summary>
        /// Metoda koja nakon učitanog prozora dohvaća podatke o slobodnim vozilima i sprema ih u obliku kolekcije
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            T25_DBEntities1 context = new T25_DBEntities1();
            System.Windows.Data.CollectionViewSource t25_DBEntitiesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("t25_DBEntitiesViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // t25_DBEntitiesViewSource.Source = [generic data source]
        }

        /// <summary>
        /// Metoda kojom se zatvara forma za ispis slobodnih vozila
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOdaberiVozilo_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
