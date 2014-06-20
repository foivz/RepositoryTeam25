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
            string query = String.Format("SELECT DISTINCT * FROM radni_sati WHERE putni_radni_list='ptr';  ", "bd");

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);

            dataGridView2.DataSource = data;


            conn.Close();
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
            mapControl.Position = new PointLatLng(46.305746000000000000, 16.336606599999982000);

            GMapOverlay markersOverlay = new GMapOverlay(mapControl, "markers");
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

            
        }
      
    }
}
