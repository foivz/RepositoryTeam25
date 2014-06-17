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
    /// Interaction logic for frmIspisRegistracija.xaml
    /// </summary>
    public partial class frmIspisRegistracija : Window
    {
        TrAppModel model = new TrAppModel();
        public frmIspisRegistracija()
        {
            InitializeComponent();
        }

        private void btnOdaberi_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            registracijadatagrid2.ItemsSource = model.ispisPoslanihRegistracija();
        }
    }
}
