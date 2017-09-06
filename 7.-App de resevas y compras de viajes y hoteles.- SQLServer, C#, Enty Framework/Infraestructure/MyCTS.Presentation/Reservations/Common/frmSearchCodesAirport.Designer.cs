namespace MyCTS.Presentation
{
    partial class frmSearchCodesAirport
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblNameCityCountry = new System.Windows.Forms.Label();
            this.txtCityNameCountryName = new MyCTS.Forms.UI.SmartTextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tblLayoutSearchFor = new System.Windows.Forms.TableLayoutPanel();
            this.lblSearchFor = new System.Windows.Forms.Label();
            this.rdoCity = new System.Windows.Forms.RadioButton();
            this.rdoCountry = new System.Windows.Forms.RadioButton();
            this.lblTitleDgv = new System.Windows.Forms.Label();
            this.dgvCodesAirport = new System.Windows.Forms.DataGridView();
            this.cityIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tblLayoutMain.SuspendLayout();
            this.tblLayoutSearchFor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodesAirport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tblLayoutMain
            // 
            this.tblLayoutMain.ColumnCount = 2;
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.86792F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.13208F));
            this.tblLayoutMain.Controls.Add(this.lblHeader, 0, 0);
            this.tblLayoutMain.Controls.Add(this.lblNameCityCountry, 0, 3);
            this.tblLayoutMain.Controls.Add(this.txtCityNameCountryName, 0, 4);
            this.tblLayoutMain.Controls.Add(this.btnSearch, 1, 4);
            this.tblLayoutMain.Controls.Add(this.tblLayoutSearchFor, 0, 2);
            this.tblLayoutMain.Controls.Add(this.lblTitleDgv, 0, 5);
            this.tblLayoutMain.Controls.Add(this.dgvCodesAirport, 0, 6);
            this.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutMain.Name = "tblLayoutMain";
            this.tblLayoutMain.RowCount = 8;
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.433497F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.970443F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.665025F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.418719F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.896552F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.358354F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.32203F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.54856F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.Size = new System.Drawing.Size(529, 415);
            this.tblLayoutMain.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.BackColor = System.Drawing.Color.Brown;
            this.tblLayoutMain.SetColumnSpan(this.lblHeader, 2);
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(529, 18);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Búsqueda de códigos de Aeropuertos";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNameCityCountry
            // 
            this.lblNameCityCountry.AutoSize = true;
            this.tblLayoutMain.SetColumnSpan(this.lblNameCityCountry, 2);
            this.lblNameCityCountry.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblNameCityCountry.Location = new System.Drawing.Point(3, 49);
            this.lblNameCityCountry.Name = "lblNameCityCountry";
            this.lblNameCityCountry.Size = new System.Drawing.Size(233, 22);
            this.lblNameCityCountry.TabIndex = 0;
            this.lblNameCityCountry.Text = "Ingrese el Nombre de Ciudad o Nombre de País";
            this.lblNameCityCountry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCityNameCountryName
            // 
            this.txtCityNameCountryName.AcceptsReturn = true;
            this.txtCityNameCountryName.AllowBlankSpaces = true;
            this.txtCityNameCountryName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCityNameCountryName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCityNameCountryName.CustomExpression = ".*";
            this.txtCityNameCountryName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtCityNameCountryName.EnterColor = System.Drawing.Color.Empty;
            this.txtCityNameCountryName.LeaveColor = System.Drawing.Color.Empty;
            this.txtCityNameCountryName.Location = new System.Drawing.Point(3, 74);
            this.txtCityNameCountryName.Name = "txtCityNameCountryName";
            this.txtCityNameCountryName.Size = new System.Drawing.Size(252, 20);
            this.txtCityNameCountryName.TabIndex = 3;
            this.txtCityNameCountryName.TextChanged += new System.EventHandler(this.txtCityNameCountryName_TextChanged);
            this.txtCityNameCountryName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Cornsilk;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(261, 74);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 22);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tblLayoutSearchFor
            // 
            this.tblLayoutSearchFor.ColumnCount = 3;
            this.tblLayoutSearchFor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.36709F));
            this.tblLayoutSearchFor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.63291F));
            this.tblLayoutSearchFor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tblLayoutSearchFor.Controls.Add(this.lblSearchFor, 0, 0);
            this.tblLayoutSearchFor.Controls.Add(this.rdoCity, 1, 0);
            this.tblLayoutSearchFor.Controls.Add(this.rdoCountry, 2, 0);
            this.tblLayoutSearchFor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutSearchFor.Location = new System.Drawing.Point(0, 26);
            this.tblLayoutSearchFor.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayoutSearchFor.Name = "tblLayoutSearchFor";
            this.tblLayoutSearchFor.RowCount = 1;
            this.tblLayoutSearchFor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutSearchFor.Size = new System.Drawing.Size(258, 23);
            this.tblLayoutSearchFor.TabIndex = 6;
            // 
            // lblSearchFor
            // 
            this.lblSearchFor.AutoSize = true;
            this.lblSearchFor.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSearchFor.Location = new System.Drawing.Point(3, 0);
            this.lblSearchFor.Name = "lblSearchFor";
            this.lblSearchFor.Size = new System.Drawing.Size(61, 23);
            this.lblSearchFor.TabIndex = 0;
            this.lblSearchFor.Text = "Buscar por:";
            this.lblSearchFor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoCity
            // 
            this.rdoCity.AutoSize = true;
            this.rdoCity.Checked = true;
            this.rdoCity.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoCity.Location = new System.Drawing.Point(76, 3);
            this.rdoCity.Name = "rdoCity";
            this.rdoCity.Size = new System.Drawing.Size(58, 17);
            this.rdoCity.TabIndex = 1;
            this.rdoCity.TabStop = true;
            this.rdoCity.Text = "Ciudad";
            this.rdoCity.UseVisualStyleBackColor = true;
            // 
            // rdoCountry
            // 
            this.rdoCountry.AutoSize = true;
            this.rdoCountry.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoCountry.Location = new System.Drawing.Point(150, 3);
            this.rdoCountry.Name = "rdoCountry";
            this.rdoCountry.Size = new System.Drawing.Size(45, 17);
            this.rdoCountry.TabIndex = 2;
            this.rdoCountry.TabStop = true;
            this.rdoCountry.Text = "Pais";
            this.rdoCountry.UseVisualStyleBackColor = true;
            // 
            // lblTitleDgv
            // 
            this.lblTitleDgv.AutoSize = true;
            this.lblTitleDgv.BackColor = System.Drawing.Color.Brown;
            this.tblLayoutMain.SetColumnSpan(this.lblTitleDgv, 2);
            this.lblTitleDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleDgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleDgv.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleDgv.Location = new System.Drawing.Point(0, 99);
            this.lblTitleDgv.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitleDgv.Name = "lblTitleDgv";
            this.lblTitleDgv.Size = new System.Drawing.Size(529, 18);
            this.lblTitleDgv.TabIndex = 0;
            this.lblTitleDgv.Text = "Resultados de la Búsqueda";
            this.lblTitleDgv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvCodesAirport
            // 
            this.dgvCodesAirport.AllowUserToAddRows = false;
            this.dgvCodesAirport.AllowUserToDeleteRows = false;
            this.dgvCodesAirport.AllowUserToResizeRows = false;
            this.dgvCodesAirport.AutoGenerateColumns = false;
            this.dgvCodesAirport.BackgroundColor = System.Drawing.Color.FloralWhite;
            this.dgvCodesAirport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvCodesAirport.ColumnHeadersHeight = 25;
            this.dgvCodesAirport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCodesAirport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cityIDDataGridViewTextBoxColumn,
            this.cityNameDataGridViewTextBoxColumn,
            this.countryIDDataGridViewTextBoxColumn,
            this.countryNameDataGridViewTextBoxColumn});
            this.tblLayoutMain.SetColumnSpan(this.dgvCodesAirport, 2);
            this.dgvCodesAirport.DataSource = this.bindingSource1;
            this.dgvCodesAirport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCodesAirport.GridColor = System.Drawing.Color.White;
            this.dgvCodesAirport.Location = new System.Drawing.Point(3, 120);
            this.dgvCodesAirport.MultiSelect = false;
            this.dgvCodesAirport.Name = "dgvCodesAirport";
            this.dgvCodesAirport.ReadOnly = true;
            this.dgvCodesAirport.RowHeadersWidth = 30;
            this.dgvCodesAirport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tblLayoutMain.SetRowSpan(this.dgvCodesAirport, 2);
            this.dgvCodesAirport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCodesAirport.Size = new System.Drawing.Size(523, 292);
            this.dgvCodesAirport.TabIndex = 5;
            this.dgvCodesAirport.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCodesAirport_CellDoubleClick);
            // 
            // cityIDDataGridViewTextBoxColumn
            // 
            this.cityIDDataGridViewTextBoxColumn.DataPropertyName = "CityID";
            this.cityIDDataGridViewTextBoxColumn.HeaderText = "Código Aeropuerto";
            this.cityIDDataGridViewTextBoxColumn.Name = "cityIDDataGridViewTextBoxColumn";
            this.cityIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cityIDDataGridViewTextBoxColumn.Width = 105;
            // 
            // cityNameDataGridViewTextBoxColumn
            // 
            this.cityNameDataGridViewTextBoxColumn.DataPropertyName = "CityName";
            this.cityNameDataGridViewTextBoxColumn.HeaderText = "Nombre de Ciudad";
            this.cityNameDataGridViewTextBoxColumn.Name = "cityNameDataGridViewTextBoxColumn";
            this.cityNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.cityNameDataGridViewTextBoxColumn.Width = 140;
            // 
            // countryIDDataGridViewTextBoxColumn
            // 
            this.countryIDDataGridViewTextBoxColumn.DataPropertyName = "CountryID";
            this.countryIDDataGridViewTextBoxColumn.HeaderText = "Código País";
            this.countryIDDataGridViewTextBoxColumn.Name = "countryIDDataGridViewTextBoxColumn";
            this.countryIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.countryIDDataGridViewTextBoxColumn.Width = 75;
            // 
            // countryNameDataGridViewTextBoxColumn
            // 
            this.countryNameDataGridViewTextBoxColumn.DataPropertyName = "CountryName";
            this.countryNameDataGridViewTextBoxColumn.HeaderText = "Nombre de País";
            this.countryNameDataGridViewTextBoxColumn.Name = "countryNameDataGridViewTextBoxColumn";
            this.countryNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.countryNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MyCTS.Entities.AirportCodes);
            // 
            // frmSearchCodesAirport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(529, 415);
            this.Controls.Add(this.tblLayoutMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchCodesAirport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyCTS";
            this.tblLayoutMain.ResumeLayout(false);
            this.tblLayoutMain.PerformLayout();
            this.tblLayoutSearchFor.ResumeLayout(false);
            this.tblLayoutSearchFor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodesAirport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblLayoutMain;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblNameCityCountry;
        private MyCTS.Forms.UI.SmartTextBox txtCityNameCountryName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TableLayoutPanel tblLayoutSearchFor;
        private System.Windows.Forms.Label lblSearchFor;
        private System.Windows.Forms.Label lblTitleDgv;
        private System.Windows.Forms.DataGridView dgvCodesAirport;
        private System.Windows.Forms.RadioButton rdoCity;
        private System.Windows.Forms.RadioButton rdoCountry;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryNameDataGridViewTextBoxColumn;


    }
}