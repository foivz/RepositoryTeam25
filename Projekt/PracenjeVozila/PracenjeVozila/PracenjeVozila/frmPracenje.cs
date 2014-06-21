using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.MapProviders;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace PracenjeVozila
{
   
    public partial class frmPracenje: UserControl
    {
        string connectionString = "server=144.76.19.105;userid=mvukovic2;pwd=L3xxtafb;database=mvukovic2;";
        public frmPracenje()
        {
            InitializeComponent();
           
           string query = String.Format("SELECT DISTINCT idptr AS 'ID putnog radnog lista', status AS 'Status rute' from lokacije WHERE idlokacije IN(SELECT MAX(idlokacije) FROM lokacije l1 WHERE l1.idptr=idptr GROUP BY l1.idptr) AND status='t';  ", "bd");

           MySqlConnection conn = new MySqlConnection(connectionString);
           conn.Open();
           MySqlCommand command = new MySqlCommand(query, conn);
           MySqlDataAdapter adapter = new MySqlDataAdapter(command);
           DataTable data = new DataTable();
           adapter.Fill(data);
           
           dataGridView1.DataSource = data;
            
           
            conn.Close();
        }


        /// <summary>
        /// Metodom kojom se klikom na polje u prvom datagridu upisuje ID putnog radnog lista u label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            int ptr = int.Parse(label1.Text);

            string sConnectionString;
            sConnectionString = "Password=rrharSGb;User ID=T25_User;"
                                   + "Initial Catalog=T25_DB;"
                                    + "Data Source=31.147.204.119\\PISERVER,1433";
            SqlConnection objConn = new SqlConnection(sConnectionString);
            objConn.Open();
            string upit = "select putni_radni_list as #PTR, zaposlenik as #Vozač, ime as Ime, prezime as Prezime from radni_sati, zaposlenici where putni_radni_list = " + ptr+" and radni_sati.zaposlenik = zaposlenici.id_zaposlenici";
            SqlDataAdapter adapter = new SqlDataAdapter(upit, objConn);
            DataTable data1 = new DataTable();
            adapter.Fill(data1);
           // MessageBox.Show(data1.Container.Components.ToString());
            dataGridView2.DataSource = data1;
            objConn.Close();


            //rad sa mapom
            try
            {
                System.Net.IPHostEntry ent =
                     System.Net.Dns.GetHostEntry("www.google.com");
            }
            catch
            {
                mapControl.Manager.Mode = AccessMode.CacheOnly;
                MessageBox.Show("Nedostupna internetska veza! Prelazim u Cache način rada...",
                      "TrApp praćenje vozila", MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
            }
            mapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            List<PointLatLng> nova = napuniListu(ptr);
            PointLatLng zadnja = nova.LastOrDefault<PointLatLng>();
            mapControl.Position = zadnja;

           GMapRoute r = new GMapRoute(nova, "Ruta");
            r.Stroke.Width = 5;
            r.Stroke.Color = Color.Red;
            
            GMapOverlay routes = new GMapOverlay(mapControl, "Routes");
            routes.Routes.Add(r);
            mapControl.Overlays.Add(routes);
            mapControl.ZoomAndCenterRoute(r);

            
             GMapOverlay markersOverlay = new GMapOverlay(mapControl, "markers");
            GMapMarkerGoogleGreen marker = new GMapMarkerGoogleGreen(zadnja);
            markersOverlay.Markers.Add(marker);
            mapControl.Overlays.Add(markersOverlay);
             

        }



        /// <summary>
        /// Metoda koja nakon učitavanja forme priprema kartu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPracenje_Load(object sender, EventArgs e)
        {
            try
            {
                System.Net.IPHostEntry ent =
                     System.Net.Dns.GetHostEntry("www.google.com");
            }
            catch
            {
                mapControl.Manager.Mode = AccessMode.CacheOnly;
                MessageBox.Show("Nedostupna internetska veza! Prelazim u Cache način rada...",
                      "TrApp praćenje vozila", MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
            }
            mapControl.DragButton = MouseButtons.Left;

            mapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            //mapControl.Position = new PointLatLng(46.305746000000000000, 16.336606599999982000);

            /*GMapOverlay markersOverlay = new GMapOverlay(mapControl, "markers");
            GMapMarkerGoogleGreen marker = new GMapMarkerGoogleGreen(new PointLatLng(46.305746000000000000, 16.336606599999982000));
            markersOverlay.Markers.Add(marker);
            mapControl.Overlays.Add(markersOverlay);

            mapControl.RoutesEnabled = true;
            PointLatLng start = new PointLatLng(46.305746000000000000, 16.336606599999982000);
            PointLatLng end = new PointLatLng(45.815011, 15.981919);
            MapRoute route = GMap.NET.MapProviders.OpenStreetMapProvider.Instance.GetRouteBetweenPoints(start, end, false, false, 15);


            GMapRoute r = new GMapRoute(route.Points, "Ruta");
            r.Stroke.Color = Color.Red;
            GMapOverlay routesOverlay = new GMapOverlay(mapControl, "routes");
            routesOverlay.Routes.Add(r);
            mapControl.Overlays.Add(routesOverlay);
            */
            
        }


        /// <summary>
        /// Metoda koja se spaja na bazu, dohvaća koordinate i sprema ih u listu koordinata prema id-u PTR
        /// </summary>
        /// <returns>Lista koordinata</returns>
        private List<PointLatLng> napuniListu(int id)
        {
            List<PointLatLng> listaKoor = new List<PointLatLng>();
            //spoji na bazu
            string connectionString = "server=144.76.19.105;userid=mvukovic2;pwd=L3xxtafb;database=mvukovic2;"; 
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = String.Format("select lat, lng from lokacije where idptr = "+id+";", "bd");
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable data = new DataTable();
            List<TrenutnaLokacija> lokacija = new List<TrenutnaLokacija>();
            adapter.Fill(data);
            //Prolazi po dataTableu i unosi vrijednosti u listu
            foreach (DataRow dr in data.Rows)
            {
                var vrijednosti = dr.ItemArray;
                TrenutnaLokacija tl = new TrenutnaLokacija()
                {
                    lat = Convert.ToDouble(vrijednosti[0]),
                    lng = Convert.ToDouble(vrijednosti[1])
                };
                //MessageBox.Show("lat: "+vrijednosti[0]+":long: "+vrijednosti[1]);
                lokacija.Add(tl);   
            }
            //idi koroz listu lokacija i za svaki element dodaj koordnate
            foreach (var i in lokacija)
            {
                listaKoor.Add(new PointLatLng(i.lat, i.lng));
            }
            conn.Close();

            return listaKoor;
        }
      
    }
}
