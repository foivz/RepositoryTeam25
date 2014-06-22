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
    /// Interaction logic for PregledPTR.xaml
    /// </summary>
    public partial class PregledPTR : Window
    {
        TrAppModel model = new TrAppModel();

        /// <summary>
        /// Konstruktor forme za pregled putnih radnih listova
        /// </summary>
        public PregledPTR()
        {
            InitializeComponent();
            putniRadniListDataGrid.ItemsSource = model.dohvatPTR();
            radni_satiDataGrid.ItemsSource = model.dohvatRS();
        }

        /// <summary>
        /// Metoda koja nakon učitanog prozora forme dohvaća podatke o putnim radnim listovima i sprema ih u obliku kolekcija
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pregled_putnih_radnih_listova_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource t25_DBEntitiesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("t25_DBEntitiesViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // t25_DBEntitiesViewSource.Source = [generic data source]
        }

        /// <summary>
        /// Metoda koja zatvara formu za pregled putnih radnih listova
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOdaberiPTR_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
