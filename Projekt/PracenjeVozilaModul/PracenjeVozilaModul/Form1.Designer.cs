namespace PracenjeVozilaModul
{
    partial class frmPracenjeVozila
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.btnStartPracenje = new System.Windows.Forms.Button();
            this.btnStopPracenje = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gmap.CanDragMap = true;
            this.gmap.Dock = System.Windows.Forms.DockStyle.Left;
            this.gmap.GrayScaleMode = false;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(0, 0);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 10;
            this.gmap.MinZoom = 0;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(405, 422);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 5D;
            // 
            // btnStartPracenje
            // 
            this.btnStartPracenje.Location = new System.Drawing.Point(450, 64);
            this.btnStartPracenje.Name = "btnStartPracenje";
            this.btnStartPracenje.Size = new System.Drawing.Size(113, 31);
            this.btnStartPracenje.TabIndex = 1;
            this.btnStartPracenje.Text = "Start";
            this.btnStartPracenje.UseVisualStyleBackColor = true;
            this.btnStartPracenje.Click += new System.EventHandler(this.btnStartPracenje_Click);
            // 
            // btnStopPracenje
            // 
            this.btnStopPracenje.Location = new System.Drawing.Point(450, 135);
            this.btnStopPracenje.Name = "btnStopPracenje";
            this.btnStopPracenje.Size = new System.Drawing.Size(113, 29);
            this.btnStopPracenje.TabIndex = 2;
            this.btnStopPracenje.Text = "Stop";
            this.btnStopPracenje.UseVisualStyleBackColor = true;
            this.btnStopPracenje.Click += new System.EventHandler(this.btnStopPracenje_Click);
            // 
            // frmPracenjeVozila
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(601, 422);
            this.Controls.Add(this.btnStopPracenje);
            this.Controls.Add(this.btnStartPracenje);
            this.Controls.Add(this.gmap);
            this.Name = "frmPracenjeVozila";
            this.Text = "Praćenje vozila";
            this.Load += new System.EventHandler(this.frmPracenjeVozila_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.Button btnStartPracenje;
        private System.Windows.Forms.Button btnStopPracenje;
    }
}

