namespace PracenjeVozila
{
    partial class frmPracenje
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mapControl = new GMap.NET.WindowsForms.GMapControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.t25_DBDataSet = new PracenjeVozila.T25_DBDataSet();
            this.t25DBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radnisatiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radni_satiTableAdapter = new PracenjeVozila.T25_DBDataSetTableAdapters.radni_satiTableAdapter();
            this.t25_DBDataSet1 = new PracenjeVozila.T25_DBDataSet1();
            this.radni_satiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radni_satiTableAdapter1 = new PracenjeVozila.T25_DBDataSet1TableAdapters.radni_satiTableAdapter();
            this.tableAdapterManager = new PracenjeVozila.T25_DBDataSet1TableAdapters.TableAdapterManager();
            this.zaposleniciTableAdapter = new PracenjeVozila.T25_DBDataSet1TableAdapters.zaposleniciTableAdapter();
            this.zaposleniciBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t25_DBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t25DBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radnisatiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t25_DBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radni_satiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaposleniciBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // mapControl
            // 
            this.mapControl.Bearing = 0F;
            this.mapControl.CanDragMap = true;
            this.mapControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.mapControl.GrayScaleMode = false;
            this.mapControl.LevelsKeepInMemmory = 5;
            this.mapControl.Location = new System.Drawing.Point(0, 0);
            this.mapControl.MarkersEnabled = true;
            this.mapControl.MaxZoom = 18;
            this.mapControl.MinZoom = 2;
            this.mapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.mapControl.Name = "mapControl";
            this.mapControl.NegativeMode = false;
            this.mapControl.PolygonsEnabled = true;
            this.mapControl.RetryLoadTile = 0;
            this.mapControl.RoutesEnabled = true;
            this.mapControl.ShowTileGridLines = false;
            this.mapControl.Size = new System.Drawing.Size(333, 538);
            this.mapControl.TabIndex = 0;
            this.mapControl.Zoom = 8D;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(366, 73);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(326, 150);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(366, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 3;
            // 
            // t25_DBDataSet
            // 
            this.t25_DBDataSet.DataSetName = "T25_DBDataSet";
            this.t25_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // t25DBDataSetBindingSource
            // 
            this.t25DBDataSetBindingSource.DataSource = this.t25_DBDataSet;
            this.t25DBDataSetBindingSource.Position = 0;
            // 
            // radnisatiBindingSource
            // 
            this.radnisatiBindingSource.DataMember = "radni_sati";
            this.radnisatiBindingSource.DataSource = this.t25DBDataSetBindingSource;
            // 
            // radni_satiTableAdapter
            // 
            this.radni_satiTableAdapter.ClearBeforeFill = true;
            // 
            // t25_DBDataSet1
            // 
            this.t25_DBDataSet1.DataSetName = "T25_DBDataSet1";
            this.t25_DBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // radni_satiBindingSource
            // 
            this.radni_satiBindingSource.DataMember = "radni_sati";
            this.radni_satiBindingSource.DataSource = this.t25_DBDataSet1;
            // 
            // radni_satiTableAdapter1
            // 
            this.radni_satiTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.godisnji_odmorTableAdapter = null;
            this.tableAdapterManager.lokacijaTableAdapter = null;
            this.tableAdapterManager.PutniRadniListTableAdapter = null;
            this.tableAdapterManager.radni_satiTableAdapter = this.radni_satiTableAdapter1;
            this.tableAdapterManager.servisTableAdapter = null;
            this.tableAdapterManager.tehnicki_pregledTableAdapter = null;
            this.tableAdapterManager.ulogaTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = PracenjeVozila.T25_DBDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.voziloTableAdapter = null;
            this.tableAdapterManager.vrsta_vozilaTableAdapter = null;
            this.tableAdapterManager.zaposleniciTableAdapter = this.zaposleniciTableAdapter;
            // 
            // zaposleniciTableAdapter
            // 
            this.zaposleniciTableAdapter.ClearBeforeFill = true;
            // 
            // zaposleniciBindingSource
            // 
            this.zaposleniciBindingSource.DataMember = "zaposlenici";
            this.zaposleniciBindingSource.DataSource = this.t25_DBDataSet1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(366, 262);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 25;
            this.dataGridView2.Size = new System.Drawing.Size(326, 150);
            this.dataGridView2.TabIndex = 4;
            // 
            // frmPracenje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.mapControl);
            this.Name = "frmPracenje";
            this.Size = new System.Drawing.Size(734, 538);
            this.Load += new System.EventHandler(this.frmPracenje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t25_DBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t25DBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radnisatiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t25_DBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radni_satiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaposleniciBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl mapControl;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource t25DBDataSetBindingSource;
        private T25_DBDataSet t25_DBDataSet;
        private System.Windows.Forms.BindingSource radnisatiBindingSource;
        private T25_DBDataSetTableAdapters.radni_satiTableAdapter radni_satiTableAdapter;
        private T25_DBDataSet1 t25_DBDataSet1;
        private System.Windows.Forms.BindingSource radni_satiBindingSource;
        private T25_DBDataSet1TableAdapters.radni_satiTableAdapter radni_satiTableAdapter1;
        private T25_DBDataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private T25_DBDataSet1TableAdapters.zaposleniciTableAdapter zaposleniciTableAdapter;
        private System.Windows.Forms.BindingSource zaposleniciBindingSource;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}
