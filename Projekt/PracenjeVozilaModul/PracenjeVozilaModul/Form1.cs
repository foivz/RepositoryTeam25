using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracenjeVozilaModul
{
    public partial class frmPracenjeVozila : Form
    {
        public frmPracenjeVozila()
        {
            InitializeComponent();
        }

        private void frmPracenjeVozila_Load(object sender, EventArgs e)
        {
            gmap.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gmap.DragButton = MouseButtons.Left;
            gmap.Zoom = 14;
            gmap.Position = new PointLatLng(46.3044444, 16.3377778);

            
        }

        private void btnStartPracenje_Click(object sender, EventArgs e)
        {

            GMapOverlay markersOverlay = new GMapOverlay(gmap, "markers");
            GMapMarkerGoogleGreen marker = new GMapMarkerGoogleGreen(new PointLatLng(46.3044444, 16.3377778));
            markersOverlay.Markers.Add(marker);
            gmap.Overlays.Add(markersOverlay);
        }

        private void btnStopPracenje_Click(object sender, EventArgs e)
        {
            
        }
    }
}
    