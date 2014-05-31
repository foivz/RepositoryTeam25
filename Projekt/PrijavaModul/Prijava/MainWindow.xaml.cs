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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data.SqlClient;

namespace Prijava
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection Connection = new SqlConnection();
        public MainWindow()
        {
            Connection.ConnectionString = @"Data Source=31.147.204.119\PISERVER,1433;Initial Catalog=T25_DB;Persist Security Info=True;User ID=T25_User;Password=rrharSGb";
 
            InitializeComponent();
        }

        private void btnPrijava_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Connection.Open();

                string Korisnik = txtKorisnickoIme.Text;
                string Lozinka = txtLozinka.Text;

                string sqlupit = "select * from zaposlenici where korisnicko_ime=@korisnicko_ime and lozinka=@lozinka";
                SqlCommand command = new SqlCommand(sqlupit, Connection);
                command.Parameters.Add(new SqlParameter("@korisnicko_ime", Korisnik));
                command.Parameters.Add(new SqlParameter("@lozinka", Lozinka));

                SqlDataReader dr = command.ExecuteReader();

                if (dr.HasRows == true)
                {
                    MessageBox.Show("Uspješna prijava!");
                }
                else 
                {
                    MessageBox.Show("Prijava nije uspijela!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally 
            {
                Connection.Close();
            }

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rezultat=MessageBox.Show("Jeste li sigurni da želite napustiti izbornik?","Upozorenje!",MessageBoxButton.YesNo);
            if (rezultat == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else 
            {
                Show();
            }
            
        }
    }
}
