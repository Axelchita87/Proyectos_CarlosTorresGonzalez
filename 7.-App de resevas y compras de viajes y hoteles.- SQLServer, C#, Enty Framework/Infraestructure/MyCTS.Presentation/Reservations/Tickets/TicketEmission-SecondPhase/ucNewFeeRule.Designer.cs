namespace MyCTS.Presentation
{
    partial class ucNewFeeRule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucNewFeeRule));
            this.lblChargePerService = new System.Windows.Forms.Label();
            this.txtAttribute1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtDescription = new MyCTS.Forms.UI.SmartTextBox();
            this.txtExtendedDescription = new MyCTS.Forms.UI.SmartTextBox();
            this.txtDefaultFee = new MyCTS.Forms.UI.SmartTextBox();
            this.txtDefaultMount = new MyCTS.Forms.UI.SmartTextBox();
            this.txtStartDate = new MyCTS.Forms.UI.SmartTextBox();
            this.txtExpirationDate = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCorporative = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblExtendedDescription = new System.Windows.Forms.Label();
            this.lblDefaultFee = new System.Windows.Forms.Label();
            this.lblDefaultMount = new System.Windows.Forms.Label();
            this.txtPriority = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.picCalendar = new System.Windows.Forms.PictureBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.txtInfoRuleByAttribute1 = new MyCTS.Forms.UI.SmartTextBox();
            this.btnCorp = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chKMontoFijo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChargePerService
            // 
            this.lblChargePerService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblChargePerService.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChargePerService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChargePerService.ForeColor = System.Drawing.Color.White;
            this.lblChargePerService.Location = new System.Drawing.Point(0, 0);
            this.lblChargePerService.Name = "lblChargePerService";
            this.lblChargePerService.Size = new System.Drawing.Size(411, 17);
            this.lblChargePerService.TabIndex = 0;
            this.lblChargePerService.Text = "Creación de regla para el cargo por servicio";
            this.lblChargePerService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAttribute1
            // 
            this.txtAttribute1.AllowBlankSpaces = false;
            this.txtAttribute1.BackColor = System.Drawing.SystemColors.Window;
            this.txtAttribute1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAttribute1.CharsIncluded = new char[0];
            this.txtAttribute1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAttribute1.CustomExpression = ".*";
            this.txtAttribute1.EnterColor = System.Drawing.Color.White;
            this.txtAttribute1.LeaveColor = System.Drawing.Color.Empty;
            this.txtAttribute1.Location = new System.Drawing.Point(132, 66);
            this.txtAttribute1.MaxLength = 6;
            this.txtAttribute1.Name = "txtAttribute1";
            this.txtAttribute1.Size = new System.Drawing.Size(83, 20);
            this.txtAttribute1.TabIndex = 1;
            this.txtAttribute1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtAttribute1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown2);
            // 
            // txtDescription
            // 
            this.txtDescription.AllowBlankSpaces = true;
            this.txtDescription.BackColor = System.Drawing.SystemColors.Window;
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.CharsIncluded = new char[0];
            this.txtDescription.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtDescription.CustomExpression = ".*";
            this.txtDescription.EnterColor = System.Drawing.Color.White;
            this.txtDescription.LeaveColor = System.Drawing.Color.Empty;
            this.txtDescription.Location = new System.Drawing.Point(132, 206);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(250, 20);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtExtendedDescription
            // 
            this.txtExtendedDescription.AllowBlankSpaces = true;
            this.txtExtendedDescription.BackColor = System.Drawing.SystemColors.Window;
            this.txtExtendedDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExtendedDescription.CharsIncluded = new char[0];
            this.txtExtendedDescription.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtExtendedDescription.CustomExpression = ".*";
            this.txtExtendedDescription.EnterColor = System.Drawing.Color.White;
            this.txtExtendedDescription.LeaveColor = System.Drawing.Color.Empty;
            this.txtExtendedDescription.Location = new System.Drawing.Point(132, 241);
            this.txtExtendedDescription.MaxLength = 200;
            this.txtExtendedDescription.Multiline = true;
            this.txtExtendedDescription.Name = "txtExtendedDescription";
            this.txtExtendedDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExtendedDescription.Size = new System.Drawing.Size(250, 57);
            this.txtExtendedDescription.TabIndex = 3;
            this.txtExtendedDescription.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtExtendedDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtDefaultFee
            // 
            this.txtDefaultFee.AllowBlankSpaces = false;
            this.txtDefaultFee.BackColor = System.Drawing.SystemColors.Window;
            this.txtDefaultFee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDefaultFee.CharsIncluded = new char[0];
            this.txtDefaultFee.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtDefaultFee.CustomExpression = ".*";
            this.txtDefaultFee.EnterColor = System.Drawing.Color.White;
            this.txtDefaultFee.LeaveColor = System.Drawing.Color.Empty;
            this.txtDefaultFee.Location = new System.Drawing.Point(132, 317);
            this.txtDefaultFee.MaxLength = 3;
            this.txtDefaultFee.Name = "txtDefaultFee";
            this.txtDefaultFee.Size = new System.Drawing.Size(62, 20);
            this.txtDefaultFee.TabIndex = 4;
            this.txtDefaultFee.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtDefaultFee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtDefaultMount
            // 
            this.txtDefaultMount.AllowBlankSpaces = false;
            this.txtDefaultMount.BackColor = System.Drawing.SystemColors.Window;
            this.txtDefaultMount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDefaultMount.CharsIncluded = new char[] {
        '.'};
            this.txtDefaultMount.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtDefaultMount.CustomExpression = ".*";
            this.txtDefaultMount.EnterColor = System.Drawing.Color.White;
            this.txtDefaultMount.LeaveColor = System.Drawing.Color.Empty;
            this.txtDefaultMount.Location = new System.Drawing.Point(132, 354);
            this.txtDefaultMount.MaxLength = 7;
            this.txtDefaultMount.Name = "txtDefaultMount";
            this.txtDefaultMount.Size = new System.Drawing.Size(83, 20);
            this.txtDefaultMount.TabIndex = 5;
            this.txtDefaultMount.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtDefaultMount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtStartDate
            // 
            this.txtStartDate.AllowBlankSpaces = false;
            this.txtStartDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStartDate.CharsIncluded = new char[0];
            this.txtStartDate.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtStartDate.CustomExpression = ".*";
            this.txtStartDate.EnterColor = System.Drawing.Color.White;
            this.txtStartDate.LeaveColor = System.Drawing.Color.Empty;
            this.txtStartDate.Location = new System.Drawing.Point(132, 424);
            this.txtStartDate.MaxLength = 7;
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(93, 20);
            this.txtStartDate.TabIndex = 7;
            this.txtStartDate.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtStartDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtExpirationDate
            // 
            this.txtExpirationDate.AllowBlankSpaces = false;
            this.txtExpirationDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtExpirationDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExpirationDate.CharsIncluded = new char[0];
            this.txtExpirationDate.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtExpirationDate.CustomExpression = ".*";
            this.txtExpirationDate.EnterColor = System.Drawing.Color.White;
            this.txtExpirationDate.LeaveColor = System.Drawing.Color.Empty;
            this.txtExpirationDate.Location = new System.Drawing.Point(132, 459);
            this.txtExpirationDate.MaxLength = 7;
            this.txtExpirationDate.Name = "txtExpirationDate";
            this.txtExpirationDate.Size = new System.Drawing.Size(93, 20);
            this.txtExpirationDate.TabIndex = 8;
            this.txtExpirationDate.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtExpirationDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCorporative
            // 
            this.lblCorporative.AutoSize = true;
            this.lblCorporative.Location = new System.Drawing.Point(38, 73);
            this.lblCorporative.Name = "lblCorporative";
            this.lblCorporative.Size = new System.Drawing.Size(64, 13);
            this.lblCorporative.TabIndex = 0;
            this.lblCorporative.Text = "Corporativo:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(38, 213);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(47, 13);
            this.lblDescription.TabIndex = 43;
            this.lblDescription.Text = "Nombre:";
            // 
            // lblExtendedDescription
            // 
            this.lblExtendedDescription.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblExtendedDescription.Location = new System.Drawing.Point(38, 241);
            this.lblExtendedDescription.Name = "lblExtendedDescription";
            this.lblExtendedDescription.Size = new System.Drawing.Size(86, 33);
            this.lblExtendedDescription.TabIndex = 44;
            this.lblExtendedDescription.Text = "Descripción Extendida:";
            // 
            // lblDefaultFee
            // 
            this.lblDefaultFee.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblDefaultFee.Location = new System.Drawing.Point(38, 317);
            this.lblDefaultFee.Name = "lblDefaultFee";
            this.lblDefaultFee.Size = new System.Drawing.Size(85, 36);
            this.lblDefaultFee.TabIndex = 45;
            this.lblDefaultFee.Text = "Porcentaje de la tarifa base:";
            // 
            // lblDefaultMount
            // 
            this.lblDefaultMount.AutoSize = true;
            this.lblDefaultMount.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblDefaultMount.Location = new System.Drawing.Point(38, 361);
            this.lblDefaultMount.Name = "lblDefaultMount";
            this.lblDefaultMount.Size = new System.Drawing.Size(71, 13);
            this.lblDefaultMount.TabIndex = 46;
            this.lblDefaultMount.Text = "Cantidad Fija:";
            // 
            // txtPriority
            // 
            this.txtPriority.AllowBlankSpaces = false;
            this.txtPriority.BackColor = System.Drawing.SystemColors.Window;
            this.txtPriority.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPriority.CharsIncluded = new char[0];
            this.txtPriority.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPriority.CustomExpression = ".*";
            this.txtPriority.EnterColor = System.Drawing.Color.White;
            this.txtPriority.LeaveColor = System.Drawing.Color.Empty;
            this.txtPriority.Location = new System.Drawing.Point(132, 389);
            this.txtPriority.MaxLength = 2;
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(62, 20);
            this.txtPriority.TabIndex = 6;
            this.txtPriority.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPriority.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(38, 396);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(48, 13);
            this.lblPriority.TabIndex = 46;
            this.lblPriority.Text = "Prioridad";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblStartDate.Location = new System.Drawing.Point(38, 431);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(82, 13);
            this.lblStartDate.TabIndex = 46;
            this.lblStartDate.Text = "Fecha de inicio:";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(38, 459);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 33);
            this.label1.TabIndex = 46;
            this.label1.Text = "Fecha de expiración:";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(71, 36);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(287, 13);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Definición de los criterios para la regla de cargo por servicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(200, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(200, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "1 = Máxima Prioridad";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(272, 539);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 49;
            this.btnAccept.Text = "Siguiente →";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // picCalendar
            // 
            this.picCalendar.BackColor = System.Drawing.Color.Transparent;
            this.picCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCalendar.Image = ((System.Drawing.Image)(resources.GetObject("picCalendar.Image")));
            this.picCalendar.Location = new System.Drawing.Point(231, 424);
            this.picCalendar.Name = "picCalendar";
            this.picCalendar.Size = new System.Drawing.Size(17, 20);
            this.picCalendar.TabIndex = 79;
            this.picCalendar.TabStop = false;
            this.picCalendar.Click += new System.EventHandler(this.picCalendar_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.monthCalendar1.Location = new System.Drawing.Point(132, 267);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 80;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            this.monthCalendar1.Leave += new System.EventHandler(this.monthCalendar1_Leave);
            this.monthCalendar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.monthCalendar1_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(231, 459);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 20);
            this.pictureBox1.TabIndex = 81;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.picCalendar_Click2);
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.monthCalendar2.Location = new System.Drawing.Point(132, 300);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 82;
            this.monthCalendar2.Visible = false;
            this.monthCalendar2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected2);
            this.monthCalendar2.Leave += new System.EventHandler(this.monthCalendar2_Leave);
            this.monthCalendar2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.monthCalendar2_KeyDown);
            // 
            // txtInfoRuleByAttribute1
            // 
            this.txtInfoRuleByAttribute1.AllowBlankSpaces = true;
            this.txtInfoRuleByAttribute1.BackColor = System.Drawing.SystemColors.Window;
            this.txtInfoRuleByAttribute1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInfoRuleByAttribute1.CharsIncluded = new char[0];
            this.txtInfoRuleByAttribute1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtInfoRuleByAttribute1.CustomExpression = ".*";
            this.txtInfoRuleByAttribute1.EnterColor = System.Drawing.Color.White;
            this.txtInfoRuleByAttribute1.LeaveColor = System.Drawing.Color.Empty;
            this.txtInfoRuleByAttribute1.Location = new System.Drawing.Point(15, 93);
            this.txtInfoRuleByAttribute1.MaxLength = 200;
            this.txtInfoRuleByAttribute1.Multiline = true;
            this.txtInfoRuleByAttribute1.Name = "txtInfoRuleByAttribute1";
            this.txtInfoRuleByAttribute1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfoRuleByAttribute1.Size = new System.Drawing.Size(378, 102);
            this.txtInfoRuleByAttribute1.TabIndex = 2;
            this.txtInfoRuleByAttribute1.Visible = false;
            this.txtInfoRuleByAttribute1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtInfoRuleByAttribute1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnCorp
            // 
            this.btnCorp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCorp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCorp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCorp.Location = new System.Drawing.Point(272, 109);
            this.btnCorp.Name = "btnCorp";
            this.btnCorp.Size = new System.Drawing.Size(110, 24);
            this.btnCorp.TabIndex = 2;
            this.btnCorp.Text = "Aceptar";
            this.btnCorp.UseVisualStyleBackColor = false;
            this.btnCorp.Click += new System.EventHandler(this.btnCorp_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(41, 539);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 24);
            this.btnClear.TabIndex = 49;
            this.btnClear.Text = "Limpiar Valores";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(313, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Paso 1/3";
            // 
            // chKMontoFijo
            // 
            this.chKMontoFijo.AutoSize = true;
            this.chKMontoFijo.ForeColor = System.Drawing.Color.DarkCyan;
            this.chKMontoFijo.Location = new System.Drawing.Point(43, 502);
            this.chKMontoFijo.Name = "chKMontoFijo";
            this.chKMontoFijo.Size = new System.Drawing.Size(130, 17);
            this.chKMontoFijo.TabIndex = 9;
            this.chKMontoFijo.Text = "Monto No Negociable";
            this.chKMontoFijo.UseVisualStyleBackColor = true;
            this.chKMontoFijo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucNewFeeRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chKMontoFijo);
            this.Controls.Add(this.monthCalendar2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.picCalendar);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCorp);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.lblDefaultMount);
            this.Controls.Add(this.lblDefaultFee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblExtendedDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblCorporative);
            this.Controls.Add(this.txtPriority);
            this.Controls.Add(this.txtExpirationDate);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.txtDefaultMount);
            this.Controls.Add(this.txtDefaultFee);
            this.Controls.Add(this.txtInfoRuleByAttribute1);
            this.Controls.Add(this.txtExtendedDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtAttribute1);
            this.Controls.Add(this.lblChargePerService);
            this.Name = "ucNewFeeRule";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucNewFeeRule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblChargePerService;
        private MyCTS.Forms.UI.SmartTextBox txtAttribute1;
        private MyCTS.Forms.UI.SmartTextBox txtDescription;
        private MyCTS.Forms.UI.SmartTextBox txtExtendedDescription;
        private MyCTS.Forms.UI.SmartTextBox txtDefaultFee;
        private MyCTS.Forms.UI.SmartTextBox txtDefaultMount;
        private MyCTS.Forms.UI.SmartTextBox txtStartDate;
        private MyCTS.Forms.UI.SmartTextBox txtExpirationDate;
        private System.Windows.Forms.Label lblCorporative;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblExtendedDescription;
        private System.Windows.Forms.Label lblDefaultFee;
        private System.Windows.Forms.Label lblDefaultMount;
        private MyCTS.Forms.UI.SmartTextBox txtPriority;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.PictureBox picCalendar;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        internal System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private MyCTS.Forms.UI.SmartTextBox txtInfoRuleByAttribute1;
        private System.Windows.Forms.Button btnCorp;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chKMontoFijo;
    }
}
