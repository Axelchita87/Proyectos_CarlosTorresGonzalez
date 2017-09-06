namespace MyCTS.Presentation
{
    partial class frmSearchAirLines
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new MyCTS.Forms.UI.SmartTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblNameCityCountry = new System.Windows.Forms.Label();
            this.txtCurrencyNameCountryName = new MyCTS.Forms.UI.SmartTextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tblLayoutSearchFor = new System.Windows.Forms.TableLayoutPanel();
            this.lblSearchFor = new System.Windows.Forms.Label();
            this.rdoCountryCode = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodeAirLineNameAirline = new MyCTS.Forms.UI.SmartTextBox();
            this.btnSearch1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.rdoCodeAirLine = new System.Windows.Forms.RadioButton();
            this.rdoNameAerLine = new System.Windows.Forms.RadioButton();
            this.lblTitleDgv = new System.Windows.Forms.Label();
            this.dgvCodesAirLines = new System.Windows.Forms.DataGridView();
            this.airlineAlfaIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.airlineNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tblLayoutMain.SuspendLayout();
            this.tblLayoutSearchFor.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodesAirLines)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MyCTS.Entities.AirLines);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.86792F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.13208F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Brown;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Búsqueda de códigos de Aeropuertos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(3, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ingrese el Nombre de Ciudad o Nombre de País";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox1.Location = new System.Drawing.Point(3, 83);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(91, 20);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Cornsilk;
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(100, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 14);
            this.button1.TabIndex = 4;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.74825F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.25175F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 100);
            this.label3.TabIndex = 0;
            this.label3.Text = "Buscar por:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(1, 1);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Ciudad";
            this.radioButton1.UseVisualStyleBackColor = true;
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
            this.tblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutMain.Name = "tblLayoutMain";
            this.tblLayoutMain.RowCount = 5;
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.Size = new System.Drawing.Size(200, 100);
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
            this.lblHeader.Size = new System.Drawing.Size(200, 20);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Búsqueda de códigos de Moneda";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNameCityCountry
            // 
            this.lblNameCityCountry.AutoSize = true;
            this.tblLayoutMain.SetColumnSpan(this.lblNameCityCountry, 2);
            this.lblNameCityCountry.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblNameCityCountry.Location = new System.Drawing.Point(3, 60);
            this.lblNameCityCountry.Name = "lblNameCityCountry";
            this.lblNameCityCountry.Size = new System.Drawing.Size(160, 20);
            this.lblNameCityCountry.TabIndex = 0;
            this.lblNameCityCountry.Text = "Ingrese el Codigo de País, País, Moneda o Codigo de Moneda";
            this.lblNameCityCountry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCurrencyNameCountryName
            // 
            this.txtCurrencyNameCountryName.AcceptsReturn = true;
            this.txtCurrencyNameCountryName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCurrencyNameCountryName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtCurrencyNameCountryName.Location = new System.Drawing.Point(3, 83);
            this.txtCurrencyNameCountryName.Name = "txtCurrencyNameCountryName";
            this.txtCurrencyNameCountryName.Size = new System.Drawing.Size(155, 20);
            this.txtCurrencyNameCountryName.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Cornsilk;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(164, 83);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(33, 14);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = false;
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
            this.tblLayoutSearchFor.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutSearchFor.Name = "tblLayoutSearchFor";
            this.tblLayoutSearchFor.RowCount = 1;
            this.tblLayoutSearchFor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutSearchFor.Size = new System.Drawing.Size(200, 100);
            this.tblLayoutSearchFor.TabIndex = 0;
            // 
            // lblSearchFor
            // 
            this.lblSearchFor.AutoSize = true;
            this.lblSearchFor.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSearchFor.Location = new System.Drawing.Point(3, 0);
            this.lblSearchFor.Name = "lblSearchFor";
            this.lblSearchFor.Size = new System.Drawing.Size(25, 100);
            this.lblSearchFor.TabIndex = 0;
            this.lblSearchFor.Text = "Buscar por:";
            this.lblSearchFor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoCountryCode
            // 
            this.rdoCountryCode.AutoSize = true;
            this.rdoCountryCode.Checked = true;
            this.rdoCountryCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoCountryCode.Location = new System.Drawing.Point(72, 3);
            this.rdoCountryCode.Name = "rdoCountryCode";
            this.rdoCountryCode.Size = new System.Drawing.Size(98, 28);
            this.rdoCountryCode.TabIndex = 1;
            this.rdoCountryCode.TabStop = true;
            this.rdoCountryCode.Text = "Codigo de País";
            this.rdoCountryCode.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.91192F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.08808F));
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtCodeAirLineNameAirline, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.btnSearch1, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblTitleDgv, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.dgvCodesAirLines, 0, 6);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.433497F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.970443F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.665025F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.418719F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.896552F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.358354F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.32203F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.54856F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(380, 413);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.MediumBlue;
            this.tableLayoutPanel3.SetColumnSpan(this.label4, 2);
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(380, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Búsqueda de códigos de Aerolíneas";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.label5, 2);
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(3, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ingrese el Código o Nombre de la Aerolínea";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCodeAirLineNameAirline
            // 
            this.txtCodeAirLineNameAirline.AcceptsReturn = true;
            this.txtCodeAirLineNameAirline.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodeAirLineNameAirline.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtCodeAirLineNameAirline.Location = new System.Drawing.Point(3, 74);
            this.txtCodeAirLineNameAirline.Name = "txtCodeAirLineNameAirline";
            this.txtCodeAirLineNameAirline.Size = new System.Drawing.Size(252, 20);
            this.txtCodeAirLineNameAirline.TabIndex = 3;
            
            
            this.txtCodeAirLineNameAirline.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validation_KeyPress);
            this.txtCodeAirLineNameAirline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnSearch1
            // 
            this.btnSearch1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSearch1.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch1.Location = new System.Drawing.Point(264, 74);
            this.btnSearch1.Name = "btnSearch1";
            this.btnSearch1.Size = new System.Drawing.Size(100, 22);
            this.btnSearch1.TabIndex = 4;
            this.btnSearch1.Text = "Buscar";
            this.btnSearch1.UseVisualStyleBackColor = false;
            this.btnSearch1.Click += new System.EventHandler(this.button2_Click);
            this.btnSearch1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.33645F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.66355F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.rdoCodeAirLine, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.rdoNameAerLine, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 26);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(261, 23);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Buscar por:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoCodeAirLine
            // 
            this.rdoCodeAirLine.AutoSize = true;
            this.rdoCodeAirLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoCodeAirLine.Location = new System.Drawing.Point(78, 3);
            this.rdoCodeAirLine.Name = "rdoCodeAirLine";
            this.rdoCodeAirLine.Size = new System.Drawing.Size(63, 17);
            this.rdoCodeAirLine.TabIndex = 1;
            this.rdoCodeAirLine.Text = "Código Aerolinea";
            this.rdoCodeAirLine.UseVisualStyleBackColor = true;
            this.rdoCodeAirLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoNameAerLine
            // 
            this.rdoNameAerLine.AutoSize = true;
            this.rdoNameAerLine.Checked = true;
            this.rdoNameAerLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoNameAerLine.Location = new System.Drawing.Point(147, 3);
            this.rdoNameAerLine.Name = "rdoNameAerLine";
            this.rdoNameAerLine.Size = new System.Drawing.Size(111, 17);
            this.rdoNameAerLine.TabIndex = 2;
            this.rdoNameAerLine.TabStop = true;
            this.rdoNameAerLine.Text = "Nombre Aerolínea";
            this.rdoNameAerLine.UseVisualStyleBackColor = true;
            this.rdoNameAerLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTitleDgv
            // 
            this.lblTitleDgv.AutoSize = true;
            this.lblTitleDgv.BackColor = System.Drawing.Color.MediumBlue;
            this.tableLayoutPanel3.SetColumnSpan(this.lblTitleDgv, 2);
            this.lblTitleDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleDgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleDgv.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleDgv.Location = new System.Drawing.Point(0, 99);
            this.lblTitleDgv.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitleDgv.Name = "lblTitleDgv";
            this.lblTitleDgv.Size = new System.Drawing.Size(380, 18);
            this.lblTitleDgv.TabIndex = 0;
            this.lblTitleDgv.Text = "Resultados de la Búsqueda";
            this.lblTitleDgv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvCodesAirLines
            // 
            this.dgvCodesAirLines.AllowUserToAddRows = false;
            this.dgvCodesAirLines.AllowUserToDeleteRows = false;
            this.dgvCodesAirLines.AllowUserToResizeRows = false;
            this.dgvCodesAirLines.AutoGenerateColumns = false;
            this.dgvCodesAirLines.BackgroundColor = System.Drawing.Color.FloralWhite;
            this.dgvCodesAirLines.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvCodesAirLines.ColumnHeadersHeight = 25;
            this.dgvCodesAirLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCodesAirLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.airlineAlfaIDDataGridViewTextBoxColumn,
            this.airlineNameDataGridViewTextBoxColumn});
            this.tableLayoutPanel3.SetColumnSpan(this.dgvCodesAirLines, 2);
            this.dgvCodesAirLines.DataSource = this.bindingSource1;
            this.dgvCodesAirLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCodesAirLines.GridColor = System.Drawing.Color.White;
            this.dgvCodesAirLines.Location = new System.Drawing.Point(3, 120);
            this.dgvCodesAirLines.MultiSelect = false;
            this.dgvCodesAirLines.Name = "dgvCodesAirLines";
            this.dgvCodesAirLines.ReadOnly = true;
            this.dgvCodesAirLines.RowHeadersWidth = 30;
            this.dgvCodesAirLines.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tableLayoutPanel3.SetRowSpan(this.dgvCodesAirLines, 2);
            this.dgvCodesAirLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCodesAirLines.Size = new System.Drawing.Size(374, 290);
            this.dgvCodesAirLines.TabIndex = 5;
            this.dgvCodesAirLines.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCodesAirLines_CellDoubleClick);
            // 
            // airlineAlfaIDDataGridViewTextBoxColumn
            // 
            this.airlineAlfaIDDataGridViewTextBoxColumn.DataPropertyName = "AirlineAlfaID";
            this.airlineAlfaIDDataGridViewTextBoxColumn.HeaderText = "Código Aerolínea";
            this.airlineAlfaIDDataGridViewTextBoxColumn.Name = "airlineAlfaIDDataGridViewTextBoxColumn";
            this.airlineAlfaIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.airlineAlfaIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // airlineNameDataGridViewTextBoxColumn
            // 
            this.airlineNameDataGridViewTextBoxColumn.DataPropertyName = "AirlineName";
            this.airlineNameDataGridViewTextBoxColumn.HeaderText = "Nombre de la Aerolínea";
            this.airlineNameDataGridViewTextBoxColumn.Name = "airlineNameDataGridViewTextBoxColumn";
            this.airlineNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.airlineNameDataGridViewTextBoxColumn.Width = 220;
            // 
            // frmSearchAirLines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(380, 413);
            this.Controls.Add(this.tableLayoutPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "frmSearchAirLines";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyCTS";
            this.Load += new System.EventHandler(this.frmSearchAirLines_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tblLayoutMain.ResumeLayout(false);
            this.tblLayoutMain.PerformLayout();
            this.tblLayoutSearchFor.ResumeLayout(false);
            this.tblLayoutSearchFor.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodesAirLines)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MyCTS.Forms.UI.SmartTextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TableLayoutPanel tblLayoutMain;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblNameCityCountry;
        private MyCTS.Forms.UI.SmartTextBox txtCurrencyNameCountryName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TableLayoutPanel tblLayoutSearchFor;
        private System.Windows.Forms.Label lblSearchFor;
        private System.Windows.Forms.RadioButton rdoCountryCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private MyCTS.Forms.UI.SmartTextBox txtCodeAirLineNameAirline;
        private System.Windows.Forms.Button btnSearch1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdoCodeAirLine;
        private System.Windows.Forms.RadioButton rdoNameAerLine;
        private System.Windows.Forms.Label lblTitleDgv;
        private System.Windows.Forms.DataGridView dgvCodesAirLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn airlineAlfaIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn airlineNameDataGridViewTextBoxColumn;

    }
}
