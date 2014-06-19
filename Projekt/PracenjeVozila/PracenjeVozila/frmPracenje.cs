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

namespace PracenjeVozila
{
    public partial class frmPracenje: UserControl
    {
        public frmPracenje()
        {
            InitializeComponent();

            try
            {
                System.Net.IPHostEntry e =
                     System.Net.Dns.GetHostEntry("www.google.com");
            }
            catch
            {
                mapControl.Manager.Mode = AccessMode.CacheOnly;
                MessageBox.Show("Nedostupna internetska veza! Prelazim u Cache način rada...",
                      "TrApp praćenje vozila", MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
            }

            // add your custom map db provider
            //GMap.NET.CacheProviders.MySQLPureImageCache ch = new GMap.NET.CacheProviders.MySQLPureImageCache();
            //ch.ConnectionString = @"server=sql2008;User Id=trolis;Persist Security Info=True;database=gmapnetcache;password=trolis;";
            //MainMap.Manager.SecondaryCache = ch;
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
