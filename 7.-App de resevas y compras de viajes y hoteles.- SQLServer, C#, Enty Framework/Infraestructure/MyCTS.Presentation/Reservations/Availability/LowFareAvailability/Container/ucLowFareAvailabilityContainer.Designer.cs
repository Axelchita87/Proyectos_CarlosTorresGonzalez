namespace MyCTS.Presentation{
    partial class ucLowFareAvailabilityContainer
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLowFareAvailabilityContainer));
            this.itinerary = new DevExpress.XtraEditors.LabelControl();
            this.dateString = new DevExpress.XtraEditors.LabelControl();
            this.OwnerCompany = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.container = new BrightIdeasSoftware.ObjectListView();
            this.CompanyName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DepartureTimeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.selectedColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ArrivalTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.PriceBase = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Clase = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.aerolineIcons = new System.Windows.Forms.ImageList();
            this.errorPanel = new System.Windows.Forms.Panel();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flightType = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.container)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // itinerary
            // 
            this.itinerary.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itinerary.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.itinerary.Location = new System.Drawing.Point(143, 29);
            this.itinerary.Name = "itinerary";
            this.itinerary.Size = new System.Drawing.Size(50, 13);
            this.itinerary.TabIndex = 2;
            this.itinerary.Text = "MEX-CUN";
            // 
            // dateString
            // 
            this.dateString.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateString.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.dateString.Location = new System.Drawing.Point(122, 41);
            this.dateString.Name = "dateString";
            this.dateString.Size = new System.Drawing.Size(97, 13);
            this.dateString.TabIndex = 3;
            this.dateString.Text = "FEBRERO 23,2012";
            // 
            // OwnerCompany
            // 
            this.OwnerCompany.DisplayIndex = 4;
            this.OwnerCompany.IsVisible = false;
            this.OwnerCompany.Text = "";
            this.OwnerCompany.Width = 105;
            // 
            // container
            // 
            this.container.AccessibleRole = System.Windows.Forms.AccessibleRole.Document;
            this.container.AllColumns.Add(this.CompanyName);
            this.container.AllColumns.Add(this.DepartureTimeColumn);
            this.container.AllColumns.Add(this.selectedColumn);
            this.container.AllColumns.Add(this.ArrivalTime);
            this.container.AllColumns.Add(this.PriceBase);
            this.container.AllColumns.Add(this.Clase);
            this.container.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.container.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CompanyName,
            this.DepartureTimeColumn,
            this.selectedColumn,
            this.ArrivalTime,
            this.PriceBase,
            this.Clase});
            this.container.EmptyListMsg = "NO SE ENCONTRARON VUELOS PARA LA FECHA SELECCIONADA.";
            this.container.EmptyListMsgFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.container.Location = new System.Drawing.Point(7, 59);
            this.container.Name = "container";
            this.container.OwnerDraw = true;
            this.container.SelectColumnsOnRightClick = false;
            this.container.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.container.Size = new System.Drawing.Size(383, 231);
            this.container.SmallImageList = this.aerolineIcons;
            this.container.SortGroupItemsByPrimaryColumn = false;
            this.container.TabIndex = 4;
            this.container.UseAlternatingBackColors = true;
            this.container.UseCellFormatEvents = true;
            this.container.UseCompatibleStateImageBehavior = false;
            this.container.UseFiltering = true;
            this.container.View = System.Windows.Forms.View.Details;
            this.container.SubItemChecking += new System.EventHandler<BrightIdeasSoftware.SubItemCheckingEventArgs>(this.container_SubItemChecking);
            this.container.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.container_FormatCell);
            // 
            // CompanyName
            // 
            this.CompanyName.AspectName = "OwnerCompany";
            this.CompanyName.DisplayIndex = 1;
            this.CompanyName.IsEditable = false;
            this.CompanyName.Text = "Aerolinea";
            // 
            // DepartureTimeColumn
            // 
            this.DepartureTimeColumn.AspectName = "DepartureTime";
            this.DepartureTimeColumn.AspectToStringFormat = "{0: HH:mm}";
            this.DepartureTimeColumn.DisplayIndex = 2;
            this.DepartureTimeColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DepartureTimeColumn.Text = " Salida";
            this.DepartureTimeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DepartureTimeColumn.Width = 95;
            // 
            // selectedColumn
            // 
            this.selectedColumn.AspectName = "IsSelected";
            this.selectedColumn.CheckBoxes = true;
            this.selectedColumn.DisplayIndex = 0;
            this.selectedColumn.Groupable = false;
            this.selectedColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.selectedColumn.Text = "";
            this.selectedColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.selectedColumn.Width = 25;
            // 
            // ArrivalTime
            // 
            this.ArrivalTime.AspectName = "ArrivalTime";
            this.ArrivalTime.AspectToStringFormat = "{0: HH:mm}";
            this.ArrivalTime.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ArrivalTime.Text = "Llegada";
            this.ArrivalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ArrivalTime.Width = 95;
            // 
            // PriceBase
            // 
            this.PriceBase.AspectName = "BasePrice";
            this.PriceBase.AspectToStringFormat = "{0:c}";
            this.PriceBase.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PriceBase.Text = "Precio Base";
            this.PriceBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PriceBase.Width = 75;
            // 
            // Clase
            // 
            this.Clase.AspectName = "Class";
            this.Clase.Text = "Clase";
            // 
            // aerolineIcons
            // 
            this.aerolineIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("aerolineIcons.ImageStream")));
            this.aerolineIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.aerolineIcons.Images.SetKeyName(0, "interjetMini.png");
            this.aerolineIcons.Images.SetKeyName(1, "volarin.JPG");
            // 
            // errorPanel
            // 
            this.errorPanel.AutoSize = true;
            this.errorPanel.Location = new System.Drawing.Point(3, 296);
            this.errorPanel.Name = "errorPanel";
            this.errorPanel.Size = new System.Drawing.Size(374, 10);
            this.errorPanel.TabIndex = 5;
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ErrorProvider.ContainerControl = this;
            this.ErrorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("ErrorProvider.Icon")));
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(114, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Salida :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(57, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 43);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // flightType
            // 
            this.flightType.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flightType.Location = new System.Drawing.Point(122, 11);
            this.flightType.Name = "flightType";
            this.flightType.Size = new System.Drawing.Size(113, 13);
            this.flightType.TabIndex = 7;
            this.flightType.Text = "VUELOS DE REGRESO";
            // 
            // ucLowFareAvailabilityContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.flightType);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.errorPanel);
            this.Controls.Add(this.container);
            this.Controls.Add(this.dateString);
            this.Controls.Add(this.itinerary);
            this.Name = "ucLowFareAvailabilityContainer";
            this.Size = new System.Drawing.Size(401, 315);
            this.Load += new System.EventHandler(this.ucLowFareAvailabilityContainer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.container)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl itinerary;
        private DevExpress.XtraEditors.LabelControl dateString;
        private BrightIdeasSoftware.OLVColumn OwnerCompany;
        private BrightIdeasSoftware.ObjectListView container;
        private BrightIdeasSoftware.OLVColumn selectedColumn;
        private BrightIdeasSoftware.OLVColumn DepartureTimeColumn;
        private BrightIdeasSoftware.OLVColumn ArrivalTime;
        private BrightIdeasSoftware.OLVColumn CompanyName;
        private BrightIdeasSoftware.OLVColumn PriceBase;
        private System.Windows.Forms.Panel errorPanel;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList aerolineIcons;
        private DevExpress.XtraEditors.LabelControl flightType;
        private BrightIdeasSoftware.OLVColumn Clase;
    }
}
