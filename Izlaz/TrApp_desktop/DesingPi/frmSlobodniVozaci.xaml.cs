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
    /// Interaction logic for SlobodniVozaci.xaml
    /// </summary>
    public partial class SlobodniVozaci : Window
    {
        TrAppController controller = new TrAppController();
        public SlobodniVozaci()
        {
            InitializeComponent();
            zaposleniciDataGrid3.ItemsSource = controller.ispisSlobodnihZaposlenika();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource t25_DBEntitiesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("t25_DBEntitiesViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // t25_DBEntitiesViewSource.Source = [generic data source]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
