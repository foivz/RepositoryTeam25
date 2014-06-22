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
    /// Interaction logic for frmIspisServisa.xaml
    /// </summary>
    public partial class frmIspisServisa : Window
    {
        TrAppController controller = new TrAppController();
        public frmIspisServisa()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vozilaservisdatagrid2.ItemsSource = controller.poslanaNaServis();
        }
        private void btnOdaberiServis_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
