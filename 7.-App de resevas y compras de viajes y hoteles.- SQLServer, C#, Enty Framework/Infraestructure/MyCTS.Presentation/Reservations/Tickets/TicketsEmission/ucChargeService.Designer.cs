namespace MyCTS.Presentation
{
    partial class ucChargeService
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
            this.lblChargePerService = new System.Windows.Forms.Label();
            this.lblPax1 = new System.Windows.Forms.Label();
            this.lblPax2 = new System.Windows.Forms.Label();
            this.lblPax3 = new System.Windows.Forms.Label();
            this.lblPax4 = new System.Windows.Forms.Label();
            this.lblPax5 = new System.Windows.Forms.Label();
            this.lblPax7 = new System.Windows.Forms.Label();
            this.lblPax6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPax9 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtPax1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPax3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPax4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPax5 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPax6 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPax7 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPax8 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPax9 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPax2 = new MyCTS.Forms.UI.SmartTextBox();
            this.lbPax = new System.Windows.Forms.ListBox();
            this.lblImport = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFOPInformation = new System.Windows.Forms.Label();
            this.cmbTypeCard = new System.Windows.Forms.ComboBox();
            this.btnShowCTS = new System.Windows.Forms.Button();
            this.lblCardTypeCTS = new System.Windows.Forms.Label();
            this.lblCardNumberCTS = new System.Windows.Forms.Label();
            this.txtNumberCardCTS = new MyCTS.Forms.UI.SmartTextBox();
            this.cotizandoLabel = new System.Windows.Forms.Label();
            this.gradProg1 = new GradProg.GradProg();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.loadingPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBoxReservation = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReservation)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MyCTS.Entities.ChargePerService);
            // 
            // lblChargePerService
            // 
            this.lblChargePerService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblChargePerService.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChargePerService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChargePerService.ForeColor = System.Drawing.Color.White;
            this.lblChargePerService.Location = new System.Drawing.Point(0, 0);
            this.lblChargePerService.Name = "lblChargePerService";
            this.lblChargePerService.Size = new System.Drawing.Size(434, 17);
            this.lblChargePerService.TabIndex = 39;
            this.lblChargePerService.Text = "Cargo por Servicio";
            this.lblChargePerService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPax1
            // 
            this.lblPax1.AutoSize = true;
            this.lblPax1.Location = new System.Drawing.Point(40, 28);
            this.lblPax1.Name = "lblPax1";
            this.lblPax1.Size = new System.Drawing.Size(37, 13);
            this.lblPax1.TabIndex = 38;
            this.lblPax1.Text = "Pax 1:";
            this.lblPax1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPax2
            // 
            this.lblPax2.AutoSize = true;
            this.lblPax2.Location = new System.Drawing.Point(40, 52);
            this.lblPax2.Name = "lblPax2";
            this.lblPax2.Size = new System.Drawing.Size(37, 13);
            this.lblPax2.TabIndex = 40;
            this.lblPax2.Text = "Pax 2:";
            this.lblPax2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPax3
            // 
            this.lblPax3.AutoSize = true;
            this.lblPax3.Location = new System.Drawing.Point(40, 76);
            this.lblPax3.Name = "lblPax3";
            this.lblPax3.Size = new System.Drawing.Size(37, 13);
            this.lblPax3.TabIndex = 42;
            this.lblPax3.Text = "Pax 3:";
            this.lblPax3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPax4
            // 
            this.lblPax4.AutoSize = true;
            this.lblPax4.Location = new System.Drawing.Point(40, 100);
            this.lblPax4.Name = "lblPax4";
            this.lblPax4.Size = new System.Drawing.Size(37, 13);
            this.lblPax4.TabIndex = 41;
            this.lblPax4.Text = "Pax 4:";
            this.lblPax4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPax5
            // 
            this.lblPax5.AutoSize = true;
            this.lblPax5.Location = new System.Drawing.Point(40, 125);
            this.lblPax5.Name = "lblPax5";
            this.lblPax5.Size = new System.Drawing.Size(37, 13);
            this.lblPax5.TabIndex = 34;
            this.lblPax5.Text = "Pax 5:";
            this.lblPax5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPax7
            // 
            this.lblPax7.AutoSize = true;
            this.lblPax7.Location = new System.Drawing.Point(40, 174);
            this.lblPax7.Name = "lblPax7";
            this.lblPax7.Size = new System.Drawing.Size(37, 13);
            this.lblPax7.TabIndex = 33;
            this.lblPax7.Text = "Pax 7:";
            this.lblPax7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPax6
            // 
            this.lblPax6.AutoSize = true;
            this.lblPax6.Location = new System.Drawing.Point(40, 149);
            this.lblPax6.Name = "lblPax6";
            this.lblPax6.Size = new System.Drawing.Size(37, 13);
            this.lblPax6.TabIndex = 35;
            this.lblPax6.Text = "Pax 6:";
            this.lblPax6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Pax 8:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPax9
            // 
            this.lblPax9.AutoSize = true;
            this.lblPax9.Location = new System.Drawing.Point(40, 223);
            this.lblPax9.Name = "lblPax9";
            this.lblPax9.Size = new System.Drawing.Size(37, 13);
            this.lblPax9.TabIndex = 36;
            this.lblPax9.Text = "Pax 9:";
            this.lblPax9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(222, 346);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 53;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtPax1
            // 
            this.txtPax1.AllowBlankSpaces = true;
            this.txtPax1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPax1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPax1.CustomExpression = ".*";
            this.txtPax1.EnterColor = System.Drawing.Color.Empty;
            this.txtPax1.LeaveColor = System.Drawing.Color.Empty;
            this.txtPax1.Location = new System.Drawing.Point(83, 31);
            this.txtPax1.Name = "txtPax1";
            this.txtPax1.Size = new System.Drawing.Size(263, 20);
            this.txtPax1.TabIndex = 43;
            this.txtPax1.TextChanged += new System.EventHandler(this.txtPax1_TextChanged);
            this.txtPax1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtPax1.Leave += new System.EventHandler(this.txtPax_Leave);
            // 
            // txtPax3
            // 
            this.txtPax3.AllowBlankSpaces = true;
            this.txtPax3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPax3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPax3.CustomExpression = ".*";
            this.txtPax3.EnterColor = System.Drawing.Color.Empty;
            this.txtPax3.LeaveColor = System.Drawing.Color.Empty;
            this.txtPax3.Location = new System.Drawing.Point(83, 79);
            this.txtPax3.Name = "txtPax3";
            this.txtPax3.Size = new System.Drawing.Size(263, 20);
            this.txtPax3.TabIndex = 45;
            this.txtPax3.TextChanged += new System.EventHandler(this.txtPax3_TextChanged);
            this.txtPax3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtPax3.Leave += new System.EventHandler(this.txtPax_Leave);
            // 
            // txtPax4
            // 
            this.txtPax4.AllowBlankSpaces = true;
            this.txtPax4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPax4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPax4.CustomExpression = ".*";
            this.txtPax4.EnterColor = System.Drawing.Color.Empty;
            this.txtPax4.LeaveColor = System.Drawing.Color.Empty;
            this.txtPax4.Location = new System.Drawing.Point(83, 103);
            this.txtPax4.Name = "txtPax4";
            this.txtPax4.Size = new System.Drawing.Size(263, 20);
            this.txtPax4.TabIndex = 46;
            this.txtPax4.TextChanged += new System.EventHandler(this.txtPax4_TextChanged);
            this.txtPax4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtPax4.Leave += new System.EventHandler(this.txtPax_Leave);
            // 
            // txtPax5
            // 
            this.txtPax5.AllowBlankSpaces = true;
            this.txtPax5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPax5.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPax5.CustomExpression = ".*";
            this.txtPax5.EnterColor = System.Drawing.Color.Empty;
            this.txtPax5.LeaveColor = System.Drawing.Color.Empty;
            this.txtPax5.Location = new System.Drawing.Point(83, 128);
            this.txtPax5.Name = "txtPax5";
            this.txtPax5.Size = new System.Drawing.Size(263, 20);
            this.txtPax5.TabIndex = 47;
            this.txtPax5.TextChanged += new System.EventHandler(this.txtPax5_TextChanged);
            this.txtPax5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtPax5.Leave += new System.EventHandler(this.txtPax_Leave);
            // 
            // txtPax6
            // 
            this.txtPax6.AllowBlankSpaces = true;
            this.txtPax6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPax6.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPax6.CustomExpression = ".*";
            this.txtPax6.EnterColor = System.Drawing.Color.Empty;
            this.txtPax6.LeaveColor = System.Drawing.Color.Empty;
            this.txtPax6.Location = new System.Drawing.Point(83, 152);
            this.txtPax6.Name = "txtPax6";
            this.txtPax6.Size = new System.Drawing.Size(263, 20);
            this.txtPax6.TabIndex = 48;
            this.txtPax6.TextChanged += new System.EventHandler(this.txtPax6_TextChanged);
            this.txtPax6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtPax6.Leave += new System.EventHandler(this.txtPax_Leave);
            // 
            // txtPax7
            // 
            this.txtPax7.AllowBlankSpaces = true;
            this.txtPax7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPax7.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPax7.CustomExpression = ".*";
            this.txtPax7.EnterColor = System.Drawing.Color.Empty;
            this.txtPax7.LeaveColor = System.Drawing.Color.Empty;
            this.txtPax7.Location = new System.Drawing.Point(83, 177);
            this.txtPax7.Name = "txtPax7";
            this.txtPax7.Size = new System.Drawing.Size(263, 20);
            this.txtPax7.TabIndex = 49;
            this.txtPax7.TextChanged += new System.EventHandler(this.txtPax7_TextChanged);
            this.txtPax7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtPax7.Leave += new System.EventHandler(this.txtPax_Leave);
            // 
            // txtPax8
            // 
            this.txtPax8.AllowBlankSpaces = true;
            this.txtPax8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPax8.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPax8.CustomExpression = ".*";
            this.txtPax8.EnterColor = System.Drawing.Color.Empty;
            this.txtPax8.LeaveColor = System.Drawing.Color.Empty;
            this.txtPax8.Location = new System.Drawing.Point(83, 201);
            this.txtPax8.Name = "txtPax8";
            this.txtPax8.Size = new System.Drawing.Size(263, 20);
            this.txtPax8.TabIndex = 50;
            this.txtPax8.TextChanged += new System.EventHandler(this.txtPax8_TextChanged);
            this.txtPax8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtPax8.Leave += new System.EventHandler(this.txtPax_Leave);
            // 
            // txtPax9
            // 
            this.txtPax9.AllowBlankSpaces = true;
            this.txtPax9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPax9.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPax9.CustomExpression = ".*";
            this.txtPax9.EnterColor = System.Drawing.Color.Empty;
            this.txtPax9.LeaveColor = System.Drawing.Color.Empty;
            this.txtPax9.Location = new System.Drawing.Point(83, 226);
            this.txtPax9.Name = "txtPax9";
            this.txtPax9.Size = new System.Drawing.Size(263, 20);
            this.txtPax9.TabIndex = 51;
            this.txtPax9.TextChanged += new System.EventHandler(this.txtPax9_TextChanged);
            this.txtPax9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtPax9.Leave += new System.EventHandler(this.txtPax_Leave);
            // 
            // txtPax2
            // 
            this.txtPax2.AllowBlankSpaces = true;
            this.txtPax2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPax2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPax2.CustomExpression = ".*";
            this.txtPax2.EnterColor = System.Drawing.Color.Empty;
            this.txtPax2.LeaveColor = System.Drawing.Color.Empty;
            this.txtPax2.Location = new System.Drawing.Point(83, 55);
            this.txtPax2.Name = "txtPax2";
            this.txtPax2.Size = new System.Drawing.Size(263, 20);
            this.txtPax2.TabIndex = 44;
            this.txtPax2.TextChanged += new System.EventHandler(this.txtPax2_TextChanged);
            this.txtPax2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtPax2.Leave += new System.EventHandler(this.txtPax_Leave);
            // 
            // lbPax
            // 
            this.lbPax.DisplayMember = "Text";
            this.lbPax.FormattingEnabled = true;
            this.lbPax.Location = new System.Drawing.Point(0, 316);
            this.lbPax.Name = "lbPax";
            this.lbPax.Size = new System.Drawing.Size(263, 108);
            this.lbPax.TabIndex = 52;
            this.lbPax.ValueMember = "Value";
            this.lbPax.Visible = false;
            this.lbPax.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbPax.Leave += new System.EventHandler(this.lbPax_Leave);
            this.lbPax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbPax_KeyDown);
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblImport.Location = new System.Drawing.Point(92, 15);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(200, 13);
            this.lblImport.TabIndex = 54;
            this.lblImport.Text = "Introduce el código de cargo por servicio";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.loadingPictureBox);
            this.panel1.Controls.Add(this.lblFOPInformation);
            this.panel1.Controls.Add(this.cmbTypeCard);
            this.panel1.Controls.Add(this.cotizandoLabel);
            this.panel1.Controls.Add(this.btnShowCTS);
            this.panel1.Controls.Add(this.lblCardTypeCTS);
            this.panel1.Controls.Add(this.lblCardNumberCTS);
            this.panel1.Controls.Add(this.txtNumberCardCTS);
            this.panel1.Controls.Add(this.btnAccept);
            this.panel1.Controls.Add(this.lblImport);
            this.panel1.Controls.Add(this.lbPax);
            this.panel1.Controls.Add(this.lblPax1);
            this.panel1.Controls.Add(this.txtPax2);
            this.panel1.Controls.Add(this.lblPax2);
            this.panel1.Controls.Add(this.txtPax9);
            this.panel1.Controls.Add(this.lblPax3);
            this.panel1.Controls.Add(this.txtPax8);
            this.panel1.Controls.Add(this.lblPax4);
            this.panel1.Controls.Add(this.txtPax7);
            this.panel1.Controls.Add(this.lblPax5);
            this.panel1.Controls.Add(this.txtPax6);
            this.panel1.Controls.Add(this.lblPax7);
            this.panel1.Controls.Add(this.txtPax5);
            this.panel1.Controls.Add(this.lblPax6);
            this.panel1.Controls.Add(this.txtPax4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPax3);
            this.panel1.Controls.Add(this.lblPax9);
            this.panel1.Controls.Add(this.txtPax1);
            this.panel1.Location = new System.Drawing.Point(6, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 463);
            this.panel1.TabIndex = 55;
            // 
            // lblFOPInformation
            // 
            this.lblFOPInformation.AutoSize = true;
            this.lblFOPInformation.Location = new System.Drawing.Point(40, 253);
            this.lblFOPInformation.Name = "lblFOPInformation";
            this.lblFOPInformation.Size = new System.Drawing.Size(252, 13);
            this.lblFOPInformation.TabIndex = 176;
            this.lblFOPInformation.Text = "Ingresa la forma de pago para el Cargo por Servicio:";
            this.lblFOPInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbTypeCard
            // 
            this.cmbTypeCard.DisplayMember = "Text";
            this.cmbTypeCard.FormattingEnabled = true;
            this.cmbTypeCard.Items.AddRange(new object[] {
            "- Selecciona Forma de Pago -"});
            this.cmbTypeCard.Location = new System.Drawing.Point(159, 271);
            this.cmbTypeCard.Name = "cmbTypeCard";
            this.cmbTypeCard.Size = new System.Drawing.Size(226, 21);
            this.cmbTypeCard.TabIndex = 175;
            this.cmbTypeCard.ValueMember = "Value";
            this.cmbTypeCard.SelectedIndexChanged += new System.EventHandler(this.cmbTypeCard_SelectedIndexChanged);
            this.cmbTypeCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTypeCard_KeyDown);
            // 
            // btnShowCTS
            // 
            this.btnShowCTS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnShowCTS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowCTS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowCTS.Image = global::MyCTS.Presentation.Properties.Resources._1327964141_find;
            this.btnShowCTS.Location = new System.Drawing.Point(282, 298);
            this.btnShowCTS.Name = "btnShowCTS";
            this.btnShowCTS.Size = new System.Drawing.Size(23, 20);
            this.btnShowCTS.TabIndex = 174;
            this.btnShowCTS.UseVisualStyleBackColor = false;
            this.btnShowCTS.Click += new System.EventHandler(this.btnShowCTS_Click);
            // 
            // lblCardTypeCTS
            // 
            this.lblCardTypeCTS.AutoSize = true;
            this.lblCardTypeCTS.Location = new System.Drawing.Point(40, 274);
            this.lblCardTypeCTS.Name = "lblCardTypeCTS";
            this.lblCardTypeCTS.Size = new System.Drawing.Size(79, 13);
            this.lblCardTypeCTS.TabIndex = 172;
            this.lblCardTypeCTS.Text = "Tipo de Tarjeta";
            this.lblCardTypeCTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCardNumberCTS
            // 
            this.lblCardNumberCTS.AutoSize = true;
            this.lblCardNumberCTS.Location = new System.Drawing.Point(40, 301);
            this.lblCardNumberCTS.Name = "lblCardNumberCTS";
            this.lblCardNumberCTS.Size = new System.Drawing.Size(91, 13);
            this.lblCardNumberCTS.TabIndex = 171;
            this.lblCardNumberCTS.Text = "Número de tarjeta";
            this.lblCardNumberCTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNumberCardCTS
            // 
            this.txtNumberCardCTS.AllowBlankSpaces = false;
            this.txtNumberCardCTS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberCardCTS.CharsIncluded = new char[0];
            this.txtNumberCardCTS.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberCardCTS.CustomExpression = ".*";
            this.txtNumberCardCTS.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberCardCTS.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberCardCTS.Location = new System.Drawing.Point(159, 298);
            this.txtNumberCardCTS.MaxLength = 16;
            this.txtNumberCardCTS.Name = "txtNumberCardCTS";
            this.txtNumberCardCTS.Size = new System.Drawing.Size(117, 20);
            this.txtNumberCardCTS.TabIndex = 173;
            this.txtNumberCardCTS.Leave += new System.EventHandler(this.txtCardNumberCTS_Leave);
            // 
            // cotizandoLabel
            // 
            this.cotizandoLabel.AutoSize = true;
            this.cotizandoLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cotizandoLabel.Location = new System.Drawing.Point(58, 407);
            this.cotizandoLabel.Name = "cotizandoLabel";
            this.cotizandoLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cotizandoLabel.Size = new System.Drawing.Size(323, 14);
            this.cotizandoLabel.TabIndex = 101;
            this.cotizandoLabel.Text = "Agregando datos a la reserva espere por favor..";
            this.cotizandoLabel.Visible = false;
            // 
            // gradProg1
            // 
            this.gradProg1.BackColor = System.Drawing.Color.White;
            this.gradProg1.GradientStyle = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.gradProg1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gradProg1.LabelBackColour = System.Drawing.Color.DimGray;
            this.gradProg1.LabelForeColour = System.Drawing.Color.LightSeaGreen;
            this.gradProg1.LabelPosition = new System.Drawing.Point(0, 0);
            this.gradProg1.Location = new System.Drawing.Point(6, 237);
            this.gradProg1.Maximum = 100;
            this.gradProg1.Minimum = 0;
            this.gradProg1.Name = "gradProg1";
            this.gradProg1.Percentage = 0;
            this.gradProg1.ProgressBarBackColour = System.Drawing.Color.White;
            this.gradProg1.ProgressBarForeColour = System.Drawing.Color.SteelBlue;
            this.gradProg1.ShowLabel = false;
            this.gradProg1.Size = new System.Drawing.Size(367, 26);
            this.gradProg1.TabIndex = 100;
            this.gradProg1.Value = 0;
            this.gradProg1.Visible = false;
            // 
            // loadingPictureBox
            // 
            this.loadingPictureBox.Image = global::MyCTS.Presentation.Properties.Resources.loadingBlue;
            this.loadingPictureBox.Location = new System.Drawing.Point(100, 376);
            this.loadingPictureBox.Name = "loadingPictureBox";
            this.loadingPictureBox.Size = new System.Drawing.Size(267, 28);
            this.loadingPictureBox.TabIndex = 115;
            this.loadingPictureBox.TabStop = false;
            this.loadingPictureBox.Visible = false;
            // 
            // pictureBoxReservation
            // 
            this.pictureBoxReservation.Image = global::MyCTS.Presentation.Properties.Resources.rsz_1327971100_passport;
            this.pictureBoxReservation.Location = new System.Drawing.Point(95, 144);
            this.pictureBoxReservation.Name = "pictureBoxReservation";
            this.pictureBoxReservation.Size = new System.Drawing.Size(142, 134);
            this.pictureBoxReservation.TabIndex = 114;
            this.pictureBoxReservation.TabStop = false;
            this.pictureBoxReservation.Visible = false;
            // 
            // ucChargeService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBoxReservation);
            this.Controls.Add(this.gradProg1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblChargePerService);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucChargeService";
            this.Size = new System.Drawing.Size(434, 564);
            this.Load += new System.EventHandler(this.ucChargeService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReservation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        internal System.Windows.Forms.Label lblChargePerService;
        private System.Windows.Forms.Label lblPax1;
        private System.Windows.Forms.Label lblPax2;
        private System.Windows.Forms.Label lblPax3;
        private System.Windows.Forms.Label lblPax4;
        private System.Windows.Forms.Label lblPax5;
        private System.Windows.Forms.Label lblPax7;
        private System.Windows.Forms.Label lblPax6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPax9;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtPax1;
        private MyCTS.Forms.UI.SmartTextBox txtPax3;
        private MyCTS.Forms.UI.SmartTextBox txtPax4;
        private MyCTS.Forms.UI.SmartTextBox txtPax5;
        private MyCTS.Forms.UI.SmartTextBox txtPax6;
        private MyCTS.Forms.UI.SmartTextBox txtPax7;
        private MyCTS.Forms.UI.SmartTextBox txtPax8;
        private MyCTS.Forms.UI.SmartTextBox txtPax9;
        private MyCTS.Forms.UI.SmartTextBox txtPax2;
        private System.Windows.Forms.ListBox lbPax;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label cotizandoLabel;
        private GradProg.GradProg gradProg1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox loadingPictureBox;
        private System.Windows.Forms.PictureBox pictureBoxReservation;
        private System.Windows.Forms.Label lblFOPInformation;
        private System.Windows.Forms.ComboBox cmbTypeCard;
        private System.Windows.Forms.Button btnShowCTS;
        private System.Windows.Forms.Label lblCardTypeCTS;
        private System.Windows.Forms.Label lblCardNumberCTS;
        private MyCTS.Forms.UI.SmartTextBox txtNumberCardCTS;
    }
}
