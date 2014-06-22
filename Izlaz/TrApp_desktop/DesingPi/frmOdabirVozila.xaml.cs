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
        public SlobodnaVozila()
        {
            string podatak = "slobodna_vozila";
            InitializeComponent();
            voziloDataGrid3.ItemsSource = controller.ispisSlobodnihVozila();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            T25_DBEntities1 context = new T25_DBEntities1();
            //var upit=(from podaci in context.vozilo join podaci2 in context.vrsta_vozila on podaci.vrsta_vozila_id equals podaci2.id_vrsta_vozila select new{podaci2.naziv}).ToList();
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
