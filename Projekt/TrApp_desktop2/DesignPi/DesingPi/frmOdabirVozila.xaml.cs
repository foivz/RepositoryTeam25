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
    /// Interaction logic for SlobodnaVozila.xaml
    /// </summary>
    public partial class SlobodnaVozila : Window
    {
        TrAppModel model = new TrAppModel();

        public SlobodnaVozila()
        {
            string podatak = "slobodna_vozila";
            InitializeComponent();
            voziloDataGrid3.ItemsSource = model.dohvatVozila(podatak);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource t25_DBEntitiesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("t25_DBEntitiesViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // t25_DBEntitiesViewSource.Source = [generic data source]
        }

        private void btnOdaberiVozilo_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
