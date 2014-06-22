using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for frmPrijava.xaml
    /// </summary>
    public partial class frmPrijava : Window
    {
        SqlConnection Connection = new SqlConnection();
        public int uloga;
        public frmPrijava()
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
                    MessageBox.Show("Uspješna prijava!","Poruka o prijavi",MessageBoxButton.OK,MessageBoxImage.Information);
                    dr.Read();
                    uloga = dr.GetInt32(1); 
                    Config conf = new Config(uloga);
                    MainWindow glavna = new MainWindow(uloga);
                    glavna.Show();
                    Close();
                 
                }
                else 
                {
                    MessageBox.Show("Prijava nije uspijela!\nProvjerite korisničko ime i lozinku!!!","Upozorenje",MessageBoxButton.OK,MessageBoxImage.Error);
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
            MessageBoxResult rezultat=MessageBox.Show("Jeste li sigurni da želite napustiti izbornik?","Upozorenje!",MessageBoxButton.YesNo,MessageBoxImage.Warning);
            if (rezultat == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else 
            {
                Show();
            }  
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            bool stanje = chkBox.IsChecked.Value;
            if (pssBox.Password.Length == 0)
            {
                txtLozinka.SelectAll();
                txtLozinka.Copy();
                pssBox.Paste();
                Clipboard.Clear();
            }
            else if(txtLozinka.Text!=pssBox.Password)
            {
                pssBox.Clear();
                txtLozinka.SelectAll();
                txtLozinka.Copy();
                pssBox.Paste();
                Clipboard.Clear();
            }
            pssBox.Visibility = System.Windows.Visibility.Visible;
        }

        private void chkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (txtLozinka.Text == pssBox.Password)
            {
                pssBox.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
