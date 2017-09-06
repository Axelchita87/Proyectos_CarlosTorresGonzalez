namespace MyCTS.Presentation
{
    partial class frmSearchCurrencyCode
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
            this.components = new System.ComponentModel.Container();
            this.dgvCodesAirport = new System.Windows.Forms.DataGridView();
            this.tblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblNameCityCountry = new System.Windows.Forms.Label();
            this.txtCurrencyNameCountryName = new MyCTS.Forms.UI.SmartTextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tblLayoutSearchFor = new System.Windows.Forms.TableLayoutPanel();
            this.lblSearchFor = new System.Windows.Forms.Label();
            this.rdoCountryCode = new System.Windows.Forms.RadioButton();
            this.rdoCountry = new System.Windows.Forms.RadioButton();
            this.rdoCurrencyName = new System.Windows.Forms.RadioButton();
            this.lblTitleDgv = new System.Windows.Forms.Label();
            this.dgvCodeCurrency = new System.Windows.Forms.DataGridView();
            this.Código_de_Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo_de_País = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodesAirport)).BeginInit();
            this.tblLayoutMain.SuspendLayout();
            this.tblLayoutSearchFor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodeCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCodesAirport
            // 
            this.dgvCodesAirport.AllowUserToAddRows = false;
            this.dgvCodesAirport.AllowUserToDeleteRows = false;
            this.dgvCodesAirport.AllowUserToResizeRows = false;
            this.dgvCodesAirport.BackgroundColor = System.Drawing.Color.FloralWhite;
            this.dgvCodesAirport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvCodesAirport.ColumnHeadersHeight = 25;
            this.dgvCodesAirport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCodesAirport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCodesAirport.GridColor = System.Drawing.Color.White;
            this.dgvCodesAirport.Location = new System.Drawing.Point(0, 0);
            this.dgvCodesAirport.MultiSelect = false;
            this.dgvCodesAirport.Name = "dgvCodesAirport";
            this.dgvCodesAirport.ReadOnly = true;
            this.dgvCodesAirport.RowHeadersWidth = 30;
            this.dgvCodesAirport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCodesAirport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCodesAirport.Size = new System.Drawing.Size(532, 395);
            this.dgvCodesAirport.TabIndex = 6;
            // 
            // tblLayoutMain
            // 
            this.tblLayoutMain.ColumnCount = 2;
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.56604F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.43396F));
            this.tblLayoutMain.Controls.Add(this.lblHeader, 0, 0);
            this.tblLayoutMain.Controls.Add(this.lblNameCityCountry, 0, 3);
            this.tblLayoutMain.Controls.Add(this.txtCurrencyNameCountryName, 0, 4);
            this.tblLayoutMain.Controls.Add(this.btnSearch, 1, 4);
            this.tblLayoutMain.Controls.Add(this.tblLayoutSearchFor, 0, 2);
            this.tblLayoutMain.Controls.Add(this.lblTitleDgv, 0, 5);
            this.tblLayoutMain.Controls.Add(this.dgvCodeCurrency, 0, 6);
            this.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutMain.Name = "tblLayoutMain";
            this.tblLayoutMain.RowCount = 8;
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.433497F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.970443F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.611548F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.511811F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.611548F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.461942F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.43045F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.54856F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.Size = new System.Drawing.Size(532, 395);
            this.tblLayoutMain.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.BackColor = System.Drawing.Color.MediumBlue;
            this.tblLayoutMain.SetColumnSpan(this.lblHeader, 2);
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(532, 17);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Búsqueda de códigos de Moneda";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNameCityCountry
            // 
            this.lblNameCityCountry.AutoSize = true;
            this.tblLayoutMain.SetColumnSpan(this.lblNameCityCountry, 2);
            this.lblNameCityCountry.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblNameCityCountry.Location = new System.Drawing.Point(3, 54);
            this.lblNameCityCountry.Name = "lblNameCityCountry";
            this.lblNameCityCountry.Size = new System.Drawing.Size(263, 21);
            this.lblNameCityCountry.TabIndex = 0;
            this.lblNameCityCountry.Text = "Ingrese el Código de País, País o Nombre de Moneda";
            this.lblNameCityCountry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCurrencyNameCountryName
            // 
            this.txtCurrencyNameCountryName.AcceptsReturn = true;
            this.txtCurrencyNameCountryName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCurrencyNameCountryName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCurrencyNameCountryName.CustomExpression = ".*";
            this.txtCurrencyNameCountryName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtCurrencyNameCountryName.EnterColor = System.Drawing.Color.Empty;
            this.txtCurrencyNameCountryName.LeaveColor = System.Drawing.Color.Empty;
            this.txtCurrencyNameCountryName.Location = new System.Drawing.Point(3, 78);
            this.txtCurrencyNameCountryName.MaxLength = 20;
            this.txtCurrencyNameCountryName.Name = "txtCurrencyNameCountryName";
            this.txtCurrencyNameCountryName.Size = new System.Drawing.Size(250, 20);
            this.txtCurrencyNameCountryName.TabIndex = 5;
            this.txtCurrencyNameCountryName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtCurrencyNameCountryName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validation_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(431, 78);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 24);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // tblLayoutSearchFor
            // 
            this.tblLayoutSearchFor.ColumnCount = 5;
            this.tblLayoutSearchFor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.19048F));
            this.tblLayoutSearchFor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblLayoutSearchFor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.38095F));
            this.tblLayoutSearchFor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.14286F));
            this.tblLayoutSearchFor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.04762F));
            this.tblLayoutSearchFor.Controls.Add(this.lblSearchFor, 0, 0);
            this.tblLayoutSearchFor.Controls.Add(this.rdoCountryCode, 1, 0);
            this.tblLayoutSearchFor.Controls.Add(this.rdoCountry, 2, 0);
            this.tblLayoutSearchFor.Controls.Add(this.rdoCurrencyName, 3, 0);
            this.tblLayoutSearchFor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutSearchFor.Location = new System.Drawing.Point(0, 24);
            this.tblLayoutSearchFor.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayoutSearchFor.Name = "tblLayoutSearchFor";
            this.tblLayoutSearchFor.RowCount = 1;
            this.tblLayoutSearchFor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutSearchFor.Size = new System.Drawing.Size(428, 30);
            this.tblLayoutSearchFor.TabIndex = 1;
            // 
            // lblSearchFor
            // 
            this.lblSearchFor.AutoSize = true;
            this.lblSearchFor.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSearchFor.Location = new System.Drawing.Point(3, 0);
            this.lblSearchFor.Name = "lblSearchFor";
            this.lblSearchFor.Size = new System.Drawing.Size(61, 30);
            this.lblSearchFor.TabIndex = 0;
            this.lblSearchFor.Text = "Buscar por:";
            this.lblSearchFor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoCountryCode
            // 
            this.rdoCountryCode.AutoSize = true;
            this.rdoCountryCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoCountryCode.Location = new System.Drawing.Point(72, 3);
            this.rdoCountryCode.Name = "rdoCountryCode";
            this.rdoCountryCode.Size = new System.Drawing.Size(98, 24);
            this.rdoCountryCode.TabIndex = 2;
            this.rdoCountryCode.TabStop = true;
            this.rdoCountryCode.Text = "Código de País";
            this.rdoCountryCode.UseVisualStyleBackColor = true;
            this.rdoCountryCode.CheckedChanged += new System.EventHandler(this.rdoCountryCode_CheckedChanged);
            this.rdoCountryCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoCountry
            // 
            this.rdoCountry.AutoSize = true;
            this.rdoCountry.Checked = true;
            this.rdoCountry.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoCountry.Location = new System.Drawing.Point(179, 3);
            this.rdoCountry.Name = "rdoCountry";
            this.rdoCountry.Size = new System.Drawing.Size(47, 24);
            this.rdoCountry.TabIndex = 3;
            this.rdoCountry.TabStop = true;
            this.rdoCountry.Text = "País";
            this.rdoCountry.UseVisualStyleBackColor = true;
            this.rdoCountry.CheckedChanged += new System.EventHandler(this.rdoCountry_CheckedChanged);
            this.rdoCountry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoCurrencyName
            // 
            this.rdoCurrencyName.AutoSize = true;
            this.tblLayoutSearchFor.SetColumnSpan(this.rdoCurrencyName, 2);
            this.rdoCurrencyName.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoCurrencyName.Location = new System.Drawing.Point(232, 3);
            this.rdoCurrencyName.Name = "rdoCurrencyName";
            this.rdoCurrencyName.Size = new System.Drawing.Size(119, 24);
            this.rdoCurrencyName.TabIndex = 4;
            this.rdoCurrencyName.TabStop = true;
            this.rdoCurrencyName.Text = "Nombre de Moneda";
            this.rdoCurrencyName.UseVisualStyleBackColor = true;
            this.rdoCurrencyName.CheckedChanged += new System.EventHandler(this.rdoCurrencyName_CheckedChanged);
            this.rdoCurrencyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTitleDgv
            // 
            this.lblTitleDgv.AutoSize = true;
            this.lblTitleDgv.BackColor = System.Drawing.Color.MediumBlue;
            this.tblLayoutMain.SetColumnSpan(this.lblTitleDgv, 2);
            this.lblTitleDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleDgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleDgv.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleDgv.Location = new System.Drawing.Point(0, 105);
            this.lblTitleDgv.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitleDgv.Name = "lblTitleDgv";
            this.lblTitleDgv.Size = new System.Drawing.Size(532, 17);
            this.lblTitleDgv.TabIndex = 0;
            this.lblTitleDgv.Text = "Resultados de la Búsqueda";
            this.lblTitleDgv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvCodeCurrency
            // 
            this.dgvCodeCurrency.AllowUserToAddRows = false;
            this.dgvCodeCurrency.AllowUserToDeleteRows = false;
            this.dgvCodeCurrency.AllowUserToResizeRows = false;
            this.dgvCodeCurrency.AutoGenerateColumns = false;
            this.dgvCodeCurrency.BackgroundColor = System.Drawing.Color.FloralWhite;
            this.dgvCodeCurrency.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvCodeCurrency.ColumnHeadersHeight = 25;
            this.dgvCodeCurrency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCodeCurrency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Código_de_Moneda,
            this.Codigo_de_País,
            this.countryNameDataGridViewTextBoxColumn,
            this.countryIDDataGridViewTextBoxColumn});
            this.tblLayoutMain.SetColumnSpan(this.dgvCodeCurrency, 2);
            this.dgvCodeCurrency.DataSource = this.bindingSource1;
            this.dgvCodeCurrency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCodeCurrency.GridColor = System.Drawing.Color.White;
            this.dgvCodeCurrency.Location = new System.Drawing.Point(3, 125);
            this.dgvCodeCurrency.MultiSelect = false;
            this.dgvCodeCurrency.Name = "dgvCodeCurrency";
            this.dgvCodeCurrency.ReadOnly = true;
            this.dgvCodeCurrency.RowHeadersWidth = 30;
            this.dgvCodeCurrency.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tblLayoutMain.SetRowSpan(this.dgvCodeCurrency, 2);
            this.dgvCodeCurrency.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCodeCurrency.Size = new System.Drawing.Size(526, 267);
            this.dgvCodeCurrency.TabIndex = 0;
            this.dgvCodeCurrency.TabStop = false;
            this.dgvCodeCurrency.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCodeCurrency_CellDoubleClick_1);
            this.dgvCodeCurrency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // Código_de_Moneda
            // 
            this.Código_de_Moneda.DataPropertyName = "CurrencyCode";
            this.Código_de_Moneda.HeaderText = "Código de Moneda";
            this.Código_de_Moneda.Name = "Código_de_Moneda";
            this.Código_de_Moneda.ReadOnly = true;
            this.Código_de_Moneda.Width = 105;
            // 
            // Codigo_de_País
            // 
            this.Codigo_de_País.DataPropertyName = "CurrencyName";
            this.Codigo_de_País.HeaderText = "Nombre de Moneda";
            this.Codigo_de_País.Name = "Codigo_de_País";
            this.Codigo_de_País.ReadOnly = true;
            this.Codigo_de_País.Width = 110;
            // 
            // countryNameDataGridViewTextBoxColumn
            // 
            this.countryNameDataGridViewTextBoxColumn.DataPropertyName = "CountryName";
            this.countryNameDataGridViewTextBoxColumn.HeaderText = "País";
            this.countryNameDataGridViewTextBoxColumn.Name = "countryNameDataGridViewTextBoxColumn";
            this.countryNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.countryNameDataGridViewTextBoxColumn.Width = 120;
            // 
            // countryIDDataGridViewTextBoxColumn
            // 
            this.countryIDDataGridViewTextBoxColumn.DataPropertyName = "CountryID";
            this.countryIDDataGridViewTextBoxColumn.HeaderText = "Código de País";
            this.countryIDDataGridViewTextBoxColumn.Name = "countryIDDataGridViewTextBoxColumn";
            this.countryIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.countryIDDataGridViewTextBoxColumn.Width = 88;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MyCTS.Entities.CurrencyCountry);
            // 
            // frmSearchCurrencyCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(532, 395);
            this.Controls.Add(this.tblLayoutMain);
            this.Controls.Add(this.dgvCodesAirport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximizeBox = false;
            this.Name = "frmSearchCurrencyCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyCTS";
            this.Load += new System.EventHandler(this.frmSearchCurrencyCode_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodesAirport)).EndInit();
            this.tblLayoutMain.ResumeLayout(false);
            this.tblLayoutMain.PerformLayout();
            this.tblLayoutSearchFor.ResumeLayout(false);
            this.tblLayoutSearchFor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodeCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCodesAirport;
        private System.Windows.Forms.TableLayoutPanel tblLayoutMain;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblNameCityCountry;
        private MyCTS.Forms.UI.SmartTextBox txtCurrencyNameCountryName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TableLayoutPanel tblLayoutSearchFor;
        private System.Windows.Forms.Label lblSearchFor;
        private System.Windows.Forms.RadioButton rdoCountryCode;
        private System.Windows.Forms.RadioButton rdoCountry;
        private System.Windows.Forms.Label lblTitleDgv;
        private System.Windows.Forms.DataGridView dgvCodeCurrency;
        private System.Windows.Forms.RadioButton rdoCurrencyName;
        //private System.Windows.Forms.DataGridViewTextBoxColumn contryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Código_de_Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_de_País;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryIDDataGridViewTextBoxColumn;
    }
}
