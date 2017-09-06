namespace MyCTS.Presentation
{
    partial class ucHotelChargeService
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
            this.lblChargePerService = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblEsperar = new System.Windows.Forms.Label();
            this.toolTipBanner = new System.Windows.Forms.ToolTip(this.components);
            this.TimerBanerImages = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.radioButton16 = new System.Windows.Forms.RadioButton();
            this.defaultToolTipController1 = new DevExpress.Utils.DefaultToolTipController(this.components);
            this.txtNombreTarjetahabiente = new System.Windows.Forms.TextBox();
            this.lblDigitoSeguridad = new System.Windows.Forms.Label();
            this.lblNombreTarjetahabiente = new System.Windows.Forms.Label();
            this.cmbAnioVencimiento = new System.Windows.Forms.ComboBox();
            this.cmbMesVencimiento = new System.Windows.Forms.ComboBox();
            this.lblAnioVencimiento = new System.Windows.Forms.Label();
            this.lblMesVencimiento = new System.Windows.Forms.Label();
            this.cmbTypeCard = new System.Windows.Forms.ComboBox();
            this.lblCardTypeCTS = new System.Windows.Forms.Label();
            this.lblCardNumberCTS = new System.Windows.Forms.Label();
            this.txtDigitoSeguridad = new MyCTS.Forms.UI.SmartTextBox();
            this.txtNumberCardCTS = new MyCTS.Forms.UI.SmartTextBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.lblLeyendaIva = new System.Windows.Forms.Label();
            this.txtMontoCargo = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPax1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblChargePerService
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblChargePerService, DevExpress.Utils.DefaultBoolean.Default);
            this.lblChargePerService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblChargePerService.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChargePerService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChargePerService.ForeColor = System.Drawing.Color.White;
            this.lblChargePerService.Location = new System.Drawing.Point(0, 0);
            this.lblChargePerService.Name = "lblChargePerService";
            this.lblChargePerService.Size = new System.Drawing.Size(381, 17);
            this.lblChargePerService.TabIndex = 40;
            this.lblChargePerService.Text = "Cobro en Línea - Cargo por Servicio Hoteles";
            this.lblChargePerService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.btnAccept, DevExpress.Utils.DefaultBoolean.Default);
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(227, 253);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 47);
            this.btnAccept.TabIndex = 17;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblEsperar
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblEsperar, DevExpress.Utils.DefaultBoolean.Default);
            this.lblEsperar.AutoSize = true;
            this.lblEsperar.Location = new System.Drawing.Point(7, 288);
            this.lblEsperar.Name = "lblEsperar";
            this.lblEsperar.Size = new System.Drawing.Size(0, 13);
            this.lblEsperar.TabIndex = 97;
            this.lblEsperar.Visible = false;
            // 
            // tableLayoutPanel9
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.tableLayoutPanel9, DevExpress.Utils.DefaultBoolean.Default);
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.83721F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.16279F));
            this.tableLayoutPanel9.Controls.Add(this.radioButton15, 0, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, -8);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel9.TabIndex = 0;
            this.tableLayoutPanel9.TabStop = true;
            // 
            // radioButton15
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.radioButton15, DevExpress.Utils.DefaultBoolean.Default);
            this.radioButton15.AutoSize = true;
            this.radioButton15.Location = new System.Drawing.Point(3, 3);
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.Size = new System.Drawing.Size(34, 17);
            this.radioButton15.TabIndex = 0;
            this.radioButton15.TabStop = true;
            this.radioButton15.Text = "Si";
            this.radioButton15.UseVisualStyleBackColor = true;
            // 
            // radioButton16
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.radioButton16, DevExpress.Utils.DefaultBoolean.Default);
            this.radioButton16.AutoSize = true;
            this.radioButton16.Location = new System.Drawing.Point(44, -5);
            this.radioButton16.Name = "radioButton16";
            this.radioButton16.Size = new System.Drawing.Size(39, 17);
            this.radioButton16.TabIndex = 1;
            this.radioButton16.TabStop = true;
            this.radioButton16.Text = "No";
            this.radioButton16.UseVisualStyleBackColor = true;
            // 
            // txtNombreTarjetahabiente
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.txtNombreTarjetahabiente, DevExpress.Utils.DefaultBoolean.Default);
            this.txtNombreTarjetahabiente.Location = new System.Drawing.Point(157, 226);
            this.txtNombreTarjetahabiente.Name = "txtNombreTarjetahabiente";
            this.txtNombreTarjetahabiente.Size = new System.Drawing.Size(180, 20);
            this.txtNombreTarjetahabiente.TabIndex = 15;
            this.txtNombreTarjetahabiente.Leave += new System.EventHandler(this.txtNombreTarjetahabiente_Leave);
            // 
            // lblDigitoSeguridad
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblDigitoSeguridad, DevExpress.Utils.DefaultBoolean.Default);
            this.lblDigitoSeguridad.AutoSize = true;
            this.lblDigitoSeguridad.Location = new System.Drawing.Point(41, 155);
            this.lblDigitoSeguridad.Name = "lblDigitoSeguridad";
            this.lblDigitoSeguridad.Size = new System.Drawing.Size(99, 13);
            this.lblDigitoSeguridad.TabIndex = 216;
            this.lblDigitoSeguridad.Text = "Códigos Seguridad:";
            // 
            // lblNombreTarjetahabiente
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblNombreTarjetahabiente, DevExpress.Utils.DefaultBoolean.Default);
            this.lblNombreTarjetahabiente.AutoSize = true;
            this.lblNombreTarjetahabiente.Location = new System.Drawing.Point(41, 229);
            this.lblNombreTarjetahabiente.Name = "lblNombreTarjetahabiente";
            this.lblNombreTarjetahabiente.Size = new System.Drawing.Size(79, 13);
            this.lblNombreTarjetahabiente.TabIndex = 215;
            this.lblNombreTarjetahabiente.Text = "Nombre Titular:";
            // 
            // cmbAnioVencimiento
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.cmbAnioVencimiento, DevExpress.Utils.DefaultBoolean.Default);
            this.cmbAnioVencimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnioVencimiento.FormattingEnabled = true;
            this.cmbAnioVencimiento.Location = new System.Drawing.Point(158, 201);
            this.cmbAnioVencimiento.MaxDropDownItems = 20;
            this.cmbAnioVencimiento.Name = "cmbAnioVencimiento";
            this.cmbAnioVencimiento.Size = new System.Drawing.Size(179, 21);
            this.cmbAnioVencimiento.TabIndex = 14;
            this.cmbAnioVencimiento.SelectedIndexChanged += new System.EventHandler(this.cmbAnioVencimiento_SelectedIndexChanged);
            // 
            // cmbMesVencimiento
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.cmbMesVencimiento, DevExpress.Utils.DefaultBoolean.Default);
            this.cmbMesVencimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMesVencimiento.FormattingEnabled = true;
            this.cmbMesVencimiento.Location = new System.Drawing.Point(158, 176);
            this.cmbMesVencimiento.MaxDropDownItems = 12;
            this.cmbMesVencimiento.Name = "cmbMesVencimiento";
            this.cmbMesVencimiento.Size = new System.Drawing.Size(179, 21);
            this.cmbMesVencimiento.TabIndex = 13;
            this.cmbMesVencimiento.SelectedIndexChanged += new System.EventHandler(this.cmbMesVencimiento_SelectedIndexChanged);
            // 
            // lblAnioVencimiento
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblAnioVencimiento, DevExpress.Utils.DefaultBoolean.Default);
            this.lblAnioVencimiento.AutoSize = true;
            this.lblAnioVencimiento.Location = new System.Drawing.Point(41, 204);
            this.lblAnioVencimiento.Name = "lblAnioVencimiento";
            this.lblAnioVencimiento.Size = new System.Drawing.Size(90, 13);
            this.lblAnioVencimiento.TabIndex = 212;
            this.lblAnioVencimiento.Text = "Año Vencimiento:";
            // 
            // lblMesVencimiento
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblMesVencimiento, DevExpress.Utils.DefaultBoolean.Default);
            this.lblMesVencimiento.AutoSize = true;
            this.lblMesVencimiento.Location = new System.Drawing.Point(41, 179);
            this.lblMesVencimiento.Name = "lblMesVencimiento";
            this.lblMesVencimiento.Size = new System.Drawing.Size(91, 13);
            this.lblMesVencimiento.TabIndex = 211;
            this.lblMesVencimiento.Text = "Mes Vencimiento:";
            // 
            // cmbTypeCard
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.cmbTypeCard, DevExpress.Utils.DefaultBoolean.Default);
            this.cmbTypeCard.DisplayMember = "Text";
            this.cmbTypeCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeCard.FormattingEnabled = true;
            this.cmbTypeCard.Items.AddRange(new object[] {
            "- Selecciona Forma de Pago -"});
            this.cmbTypeCard.Location = new System.Drawing.Point(157, 102);
            this.cmbTypeCard.Name = "cmbTypeCard";
            this.cmbTypeCard.Size = new System.Drawing.Size(180, 21);
            this.cmbTypeCard.TabIndex = 10;
            this.cmbTypeCard.ValueMember = "Value";
            this.cmbTypeCard.SelectionChangeCommitted += new System.EventHandler(this.cmbTypeCard_SelectionChangeCommitted);
            // 
            // lblCardTypeCTS
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblCardTypeCTS, DevExpress.Utils.DefaultBoolean.Default);
            this.lblCardTypeCTS.AutoSize = true;
            this.lblCardTypeCTS.Location = new System.Drawing.Point(41, 105);
            this.lblCardTypeCTS.Name = "lblCardTypeCTS";
            this.lblCardTypeCTS.Size = new System.Drawing.Size(81, 13);
            this.lblCardTypeCTS.TabIndex = 208;
            this.lblCardTypeCTS.Text = "Forma de pago:";
            this.lblCardTypeCTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCardNumberCTS
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblCardNumberCTS, DevExpress.Utils.DefaultBoolean.Default);
            this.lblCardNumberCTS.AutoSize = true;
            this.lblCardNumberCTS.Location = new System.Drawing.Point(41, 132);
            this.lblCardNumberCTS.Name = "lblCardNumberCTS";
            this.lblCardNumberCTS.Size = new System.Drawing.Size(94, 13);
            this.lblCardNumberCTS.TabIndex = 207;
            this.lblCardNumberCTS.Text = "Número de tarjeta:";
            this.lblCardNumberCTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDigitoSeguridad
            // 
            this.txtDigitoSeguridad.AllowBlankSpaces = false;
            this.defaultToolTipController1.SetAllowHtmlText(this.txtDigitoSeguridad, DevExpress.Utils.DefaultBoolean.Default);
            this.txtDigitoSeguridad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDigitoSeguridad.CharsIncluded = new char[0];
            this.txtDigitoSeguridad.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtDigitoSeguridad.CustomExpression = ".*";
            this.txtDigitoSeguridad.EnterColor = System.Drawing.Color.Empty;
            this.txtDigitoSeguridad.Font = new System.Drawing.Font("Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.txtDigitoSeguridad.LeaveColor = System.Drawing.Color.Empty;
            this.txtDigitoSeguridad.Location = new System.Drawing.Point(158, 152);
            this.txtDigitoSeguridad.MaxLength = 4;
            this.txtDigitoSeguridad.Name = "txtDigitoSeguridad";
            this.txtDigitoSeguridad.PasswordChar = '·';
            this.txtDigitoSeguridad.Size = new System.Drawing.Size(179, 22);
            this.txtDigitoSeguridad.TabIndex = 12;
            this.txtDigitoSeguridad.Leave += new System.EventHandler(this.txtDigitoSeguridad_Leave);
            // 
            // txtNumberCardCTS
            // 
            this.txtNumberCardCTS.AllowBlankSpaces = false;
            this.defaultToolTipController1.SetAllowHtmlText(this.txtNumberCardCTS, DevExpress.Utils.DefaultBoolean.Default);
            this.txtNumberCardCTS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberCardCTS.CharsIncluded = new char[0];
            this.txtNumberCardCTS.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberCardCTS.CustomExpression = ".*";
            this.txtNumberCardCTS.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberCardCTS.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberCardCTS.Location = new System.Drawing.Point(157, 129);
            this.txtNumberCardCTS.MaxLength = 16;
            this.txtNumberCardCTS.Name = "txtNumberCardCTS";
            this.txtNumberCardCTS.Size = new System.Drawing.Size(180, 20);
            this.txtNumberCardCTS.TabIndex = 11;
            this.txtNumberCardCTS.Leave += new System.EventHandler(this.txtGenericoDatosTarjeta_Leave);
            // 
            // btnContinue
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.btnContinue, DevExpress.Utils.DefaultBoolean.Default);
            this.btnContinue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Location = new System.Drawing.Point(111, 253);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(110, 47);
            this.btnContinue.TabIndex = 16;
            this.btnContinue.Text = "Continuar sin aplicar cargo";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // lblLeyendaIva
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblLeyendaIva, DevExpress.Utils.DefaultBoolean.Default);
            this.lblLeyendaIva.AutoSize = true;
            this.lblLeyendaIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeyendaIva.ForeColor = System.Drawing.Color.Red;
            this.lblLeyendaIva.Location = new System.Drawing.Point(3, 17);
            this.lblLeyendaIva.Name = "lblLeyendaIva";
            this.lblLeyendaIva.Size = new System.Drawing.Size(375, 13);
            this.lblLeyendaIva.TabIndex = 218;
            this.lblLeyendaIva.Text = "EL SISTEMA AUTOMATICAMENTE INCLUIRA EL IVA DEL 16%. ";
            // 
            // txtMontoCargo
            // 
            this.txtMontoCargo.AllowBlankSpaces = false;
            this.defaultToolTipController1.SetAllowHtmlText(this.txtMontoCargo, DevExpress.Utils.DefaultBoolean.Default);
            this.txtMontoCargo.BackColor = System.Drawing.SystemColors.Window;
            this.txtMontoCargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMontoCargo.CharsIncluded = new char[] {
        '.'};
            this.txtMontoCargo.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtMontoCargo.CustomExpression = ".*";
            this.txtMontoCargo.EnterColor = System.Drawing.Color.White;
            this.txtMontoCargo.LeaveColor = System.Drawing.Color.Empty;
            this.txtMontoCargo.Location = new System.Drawing.Point(158, 76);
            this.txtMontoCargo.MaxLength = 8;
            this.txtMontoCargo.Name = "txtMontoCargo";
            this.txtMontoCargo.Size = new System.Drawing.Size(80, 20);
            this.txtMontoCargo.TabIndex = 9;
            // 
            // lblPax1
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblPax1, DevExpress.Utils.DefaultBoolean.Default);
            this.lblPax1.AutoSize = true;
            this.lblPax1.Location = new System.Drawing.Point(41, 83);
            this.lblPax1.Name = "lblPax1";
            this.lblPax1.Size = new System.Drawing.Size(71, 13);
            this.lblPax1.TabIndex = 220;
            this.lblPax1.Text = "Monto Cargo:";
            this.lblPax1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.label1, DevExpress.Utils.DefaultBoolean.Default);
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 13);
            this.label1.TabIndex = 221;
            this.label1.Text = "Solo es posible aplicar un cargo por servicio";
            // 
            // label2
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.label2, DevExpress.Utils.DefaultBoolean.Default);
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 13);
            this.label2.TabIndex = 222;
            this.label2.Text = "por clave de reservación en sabre.";
            // 
            // ucHotelChargeService
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMontoCargo);
            this.Controls.Add(this.lblPax1);
            this.Controls.Add(this.lblLeyendaIva);
            this.Controls.Add(this.lblEsperar);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.txtNombreTarjetahabiente);
            this.Controls.Add(this.txtDigitoSeguridad);
            this.Controls.Add(this.lblDigitoSeguridad);
            this.Controls.Add(this.lblNombreTarjetahabiente);
            this.Controls.Add(this.cmbAnioVencimiento);
            this.Controls.Add(this.cmbMesVencimiento);
            this.Controls.Add(this.lblAnioVencimiento);
            this.Controls.Add(this.lblMesVencimiento);
            this.Controls.Add(this.cmbTypeCard);
            this.Controls.Add(this.lblCardTypeCTS);
            this.Controls.Add(this.lblCardNumberCTS);
            this.Controls.Add(this.txtNumberCardCTS);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblChargePerService);
            this.Name = "ucHotelChargeService";
            this.Size = new System.Drawing.Size(381, 332);
            this.Load += new System.EventHandler(this.ucHotelChargeService_Load);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblChargePerService;
        private System.Windows.Forms.Button btnAccept;
        //private System.Windows.Forms.Button btnNewFeeRule;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblEsperar;
        private System.Windows.Forms.ToolTip toolTipBanner;
        private System.Windows.Forms.Timer TimerBanerImages;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.RadioButton radioButton15;
        private System.Windows.Forms.RadioButton radioButton16;
        private DevExpress.Utils.DefaultToolTipController defaultToolTipController1;
        private System.Windows.Forms.TextBox txtNombreTarjetahabiente;
        private MyCTS.Forms.UI.SmartTextBox txtDigitoSeguridad;
        private System.Windows.Forms.Label lblDigitoSeguridad;
        private System.Windows.Forms.Label lblNombreTarjetahabiente;
        private System.Windows.Forms.ComboBox cmbAnioVencimiento;
        private System.Windows.Forms.ComboBox cmbMesVencimiento;
        private System.Windows.Forms.Label lblAnioVencimiento;
        private System.Windows.Forms.Label lblMesVencimiento;
        private System.Windows.Forms.ComboBox cmbTypeCard;
        private System.Windows.Forms.Label lblCardTypeCTS;
        private System.Windows.Forms.Label lblCardNumberCTS;
        private MyCTS.Forms.UI.SmartTextBox txtNumberCardCTS;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label lblLeyendaIva;
        private Forms.UI.SmartTextBox txtMontoCargo;
        private System.Windows.Forms.Label lblPax1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}
