namespace MyCTS.Presentation
{
    partial class ucQualityControls
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblJustifications = new System.Windows.Forms.Label();
            this.cmbJustifications = new System.Windows.Forms.ComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnAccept = new System.Windows.Forms.Button();
            this.chkClass = new System.Windows.Forms.CheckBox();
            this.lblCenterCosts = new System.Windows.Forms.Label();
            this.txtCostCenter = new MyCTS.Forms.UI.SmartTextBox();
            this.lbCostCenter = new System.Windows.Forms.ListBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.txtArea = new MyCTS.Forms.UI.SmartTextBox();
            this.lblBusinessUnit = new System.Windows.Forms.Label();
            this.lblSaleOrigin = new System.Windows.Forms.Label();
            this.cmbBusinessUnit = new System.Windows.Forms.ComboBox();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.cmbSaleOrigin = new System.Windows.Forms.ComboBox();
            this.txtDepartment = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblDivision = new System.Windows.Forms.Label();
            this.txtDivision = new MyCTS.Forms.UI.SmartTextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAuthorization = new System.Windows.Forms.Label();
            this.txtAuthorization = new MyCTS.Forms.UI.SmartTextBox();
            this.txtWorkerNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.lblWorkerNumber = new System.Windows.Forms.Label();
            this.txtSociety = new MyCTS.Forms.UI.SmartTextBox();
            this.lblSociety = new System.Windows.Forms.Label();
            this.txtManageCenter = new MyCTS.Forms.UI.SmartTextBox();
            this.lblManagerCenter = new System.Windows.Forms.Label();
            this.txtInvoicePosition = new MyCTS.Forms.UI.SmartTextBox();
            this.lblInvoicePosition = new System.Windows.Forms.Label();
            this.txtSolicitator = new MyCTS.Forms.UI.SmartTextBox();
            this.lblSolicitator = new System.Windows.Forms.Label();
            this.txtcontractPosition = new MyCTS.Forms.UI.SmartTextBox();
            this.lblcontractPosition = new System.Windows.Forms.Label();
            this.txtFareIndicator = new MyCTS.Forms.UI.SmartTextBox();
            this.lblFareIndicator = new System.Windows.Forms.Label();
            this.txtOnlineBookingIndicator = new MyCTS.Forms.UI.SmartTextBox();
            this.lblOnlineBookingIndicator = new System.Windows.Forms.Label();
            this.txtLegalEntity = new MyCTS.Forms.UI.SmartTextBox();
            this.lblLegalEntity = new System.Windows.Forms.Label();
            this.lblSubactivity = new System.Windows.Forms.Label();
            this.lblActivity = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblCostCenterDHL = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.cmbCostCenterDHL = new System.Windows.Forms.ComboBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.cmbActivity = new System.Windows.Forms.ComboBox();
            this.cmbSubactivity = new System.Windows.Forms.ComboBox();
            this.txtRealFare = new MyCTS.Forms.UI.SmartTextBox();
            this.lblRealFare = new System.Windows.Forms.Label();
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Controles de Calidad";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblJustifications
            // 
            this.lblJustifications.AutoSize = true;
            this.lblJustifications.Location = new System.Drawing.Point(2, 309);
            this.lblJustifications.Name = "lblJustifications";
            this.lblJustifications.Size = new System.Drawing.Size(79, 13);
            this.lblJustifications.TabIndex = 0;
            this.lblJustifications.Text = "Justificaciones:";
            // 
            // cmbJustifications
            // 
            this.cmbJustifications.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJustifications.FormattingEnabled = true;
            this.cmbJustifications.Items.AddRange(new object[] {
            "Selecciona la justificación adecuada:"});
            this.cmbJustifications.Location = new System.Drawing.Point(125, 307);
            this.cmbJustifications.Name = "cmbJustifications";
            this.cmbJustifications.Size = new System.Drawing.Size(283, 21);
            this.cmbJustifications.TabIndex = 11;
            this.cmbJustifications.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MyCTS.Entities.DKTemp);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(287, 691);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 27;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // chkClass
            // 
            this.chkClass.AutoSize = true;
            this.chkClass.Checked = true;
            this.chkClass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClass.Location = new System.Drawing.Point(125, 334);
            this.chkClass.Name = "chkClass";
            this.chkClass.Size = new System.Drawing.Size(191, 17);
            this.chkClass.TabIndex = 12;
            this.chkClass.Text = "¿Es una clase Business o Primera?";
            this.chkClass.UseVisualStyleBackColor = true;
            this.chkClass.Visible = false;
            this.chkClass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCenterCosts
            // 
            this.lblCenterCosts.AutoSize = true;
            this.lblCenterCosts.ForeColor = System.Drawing.Color.Black;
            this.lblCenterCosts.Location = new System.Drawing.Point(2, 47);
            this.lblCenterCosts.Name = "lblCenterCosts";
            this.lblCenterCosts.Size = new System.Drawing.Size(91, 13);
            this.lblCenterCosts.TabIndex = 0;
            this.lblCenterCosts.Text = "Centro de Costos:";
            // 
            // txtCostCenter
            // 
            this.txtCostCenter.AllowBlankSpaces = false;
            this.txtCostCenter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCostCenter.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCostCenter.CustomExpression = ".*";
            this.txtCostCenter.EnterColor = System.Drawing.Color.Empty;
            this.txtCostCenter.LeaveColor = System.Drawing.Color.Empty;
            this.txtCostCenter.Location = new System.Drawing.Point(125, 45);
            this.txtCostCenter.MaxLength = 20;
            this.txtCostCenter.Name = "txtCostCenter";
            this.txtCostCenter.Size = new System.Drawing.Size(224, 20);
            this.txtCostCenter.TabIndex = 1;
            this.txtCostCenter.TextChanged += new System.EventHandler(this.txtCostCenter_TextChanged);
            this.txtCostCenter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControlCostcenter_KeyDown);
            // 
            // lbCostCenter
            // 
            this.lbCostCenter.DisplayMember = "Text";
            this.lbCostCenter.FormattingEnabled = true;
            this.lbCostCenter.Location = new System.Drawing.Point(209, 206);
            this.lbCostCenter.Name = "lbCostCenter";
            this.lbCostCenter.Size = new System.Drawing.Size(224, 95);
            this.lbCostCenter.TabIndex = 45;
            this.lbCostCenter.ValueMember = "Value";
            this.lbCostCenter.Visible = false;
            this.lbCostCenter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbCostCenter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbCostCenter_KeyDown);
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.ForeColor = System.Drawing.Color.Black;
            this.lblArea.Location = new System.Drawing.Point(3, 124);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(32, 13);
            this.lblArea.TabIndex = 0;
            this.lblArea.Text = "Área:";
            // 
            // txtArea
            // 
            this.txtArea.AllowBlankSpaces = false;
            this.txtArea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtArea.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtArea.CustomExpression = ".*";
            this.txtArea.EnterColor = System.Drawing.Color.Empty;
            this.txtArea.LeaveColor = System.Drawing.Color.Empty;
            this.txtArea.Location = new System.Drawing.Point(125, 122);
            this.txtArea.MaxLength = 10;
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(78, 20);
            this.txtArea.TabIndex = 4;
            this.txtArea.TextChanged += new System.EventHandler(this.txtArea_TextChanged);
            this.txtArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblBusinessUnit
            // 
            this.lblBusinessUnit.AutoSize = true;
            this.lblBusinessUnit.Location = new System.Drawing.Point(2, 386);
            this.lblBusinessUnit.Name = "lblBusinessUnit";
            this.lblBusinessUnit.Size = new System.Drawing.Size(93, 13);
            this.lblBusinessUnit.TabIndex = 0;
            this.lblBusinessUnit.Text = "Unidad Operativa:";
            // 
            // lblSaleOrigin
            // 
            this.lblSaleOrigin.AutoSize = true;
            this.lblSaleOrigin.Location = new System.Drawing.Point(2, 360);
            this.lblSaleOrigin.Name = "lblSaleOrigin";
            this.lblSaleOrigin.Size = new System.Drawing.Size(87, 13);
            this.lblSaleOrigin.TabIndex = 0;
            this.lblSaleOrigin.Text = "Origen de Venta:";
            // 
            // cmbBusinessUnit
            // 
            this.cmbBusinessUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusinessUnit.FormattingEnabled = true;
            this.cmbBusinessUnit.Items.AddRange(new object[] {
            "Selecciona la Unidad Operativa requerida:"});
            this.cmbBusinessUnit.Location = new System.Drawing.Point(125, 384);
            this.cmbBusinessUnit.Name = "cmbBusinessUnit";
            this.cmbBusinessUnit.Size = new System.Drawing.Size(262, 21);
            this.cmbBusinessUnit.TabIndex = 14;
            this.cmbBusinessUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataSource = typeof(MyCTS.Entities.CatBusinessUnits);
            // 
            // cmbSaleOrigin
            // 
            this.cmbSaleOrigin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSaleOrigin.FormattingEnabled = true;
            this.cmbSaleOrigin.Items.AddRange(new object[] {
            "Seleccione Origen de Venta:",
            "Política de la Empresa",
            "Anuncio Boletín Turistico",
            "Correo Electronico",
            "Recomendación cliente",
            "Recursos Humanos"});
            this.cmbSaleOrigin.Location = new System.Drawing.Point(125, 357);
            this.cmbSaleOrigin.Name = "cmbSaleOrigin";
            this.cmbSaleOrigin.Size = new System.Drawing.Size(262, 21);
            this.cmbSaleOrigin.TabIndex = 13;
            this.cmbSaleOrigin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtDepartment
            // 
            this.txtDepartment.AllowBlankSpaces = false;
            this.txtDepartment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDepartment.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtDepartment.CustomExpression = ".*";
            this.txtDepartment.EnterColor = System.Drawing.Color.Empty;
            this.txtDepartment.LeaveColor = System.Drawing.Color.Empty;
            this.txtDepartment.Location = new System.Drawing.Point(125, 97);
            this.txtDepartment.MaxLength = 10;
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(77, 20);
            this.txtDepartment.TabIndex = 3;
            this.txtDepartment.TextChanged += new System.EventHandler(this.txtDepartment_TextChanged);
            this.txtDepartment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.ForeColor = System.Drawing.Color.Black;
            this.lblDepartment.Location = new System.Drawing.Point(2, 99);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(77, 13);
            this.lblDepartment.TabIndex = 0;
            this.lblDepartment.Text = "Departamento:";
            // 
            // lblDivision
            // 
            this.lblDivision.AutoSize = true;
            this.lblDivision.ForeColor = System.Drawing.Color.Black;
            this.lblDivision.Location = new System.Drawing.Point(2, 73);
            this.lblDivision.Name = "lblDivision";
            this.lblDivision.Size = new System.Drawing.Size(47, 13);
            this.lblDivision.TabIndex = 0;
            this.lblDivision.Text = "División:";
            // 
            // txtDivision
            // 
            this.txtDivision.AllowBlankSpaces = false;
            this.txtDivision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDivision.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtDivision.CustomExpression = ".*";
            this.txtDivision.EnterColor = System.Drawing.Color.Empty;
            this.txtDivision.LeaveColor = System.Drawing.Color.Empty;
            this.txtDivision.Location = new System.Drawing.Point(125, 71);
            this.txtDivision.MaxLength = 10;
            this.txtDivision.Name = "txtDivision";
            this.txtDivision.Size = new System.Drawing.Size(77, 20);
            this.txtDivision.TabIndex = 2;
            this.txtDivision.TextChanged += new System.EventHandler(this.txtDivision_TextChanged);
            this.txtDivision.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.ForeColor = System.Drawing.Color.Black;
            this.lblNumber.Location = new System.Drawing.Point(2, 152);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(32, 13);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "Folio:";
            // 
            // txtNumber
            // 
            this.txtNumber.AllowBlankSpaces = false;
            this.txtNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtNumber.CustomExpression = ".*";
            this.txtNumber.EnterColor = System.Drawing.Color.Empty;
            this.txtNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumber.Location = new System.Drawing.Point(125, 150);
            this.txtNumber.MaxLength = 10;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(78, 20);
            this.txtNumber.TabIndex = 5;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            this.txtNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblAuthorization
            // 
            this.lblAuthorization.AutoSize = true;
            this.lblAuthorization.ForeColor = System.Drawing.Color.Black;
            this.lblAuthorization.Location = new System.Drawing.Point(2, 178);
            this.lblAuthorization.Name = "lblAuthorization";
            this.lblAuthorization.Size = new System.Drawing.Size(68, 13);
            this.lblAuthorization.TabIndex = 0;
            this.lblAuthorization.Text = "Autorización:";
            // 
            // txtAuthorization
            // 
            this.txtAuthorization.AllowBlankSpaces = false;
            this.txtAuthorization.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAuthorization.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtAuthorization.CustomExpression = ".*";
            this.txtAuthorization.EnterColor = System.Drawing.Color.Empty;
            this.txtAuthorization.LeaveColor = System.Drawing.Color.Empty;
            this.txtAuthorization.Location = new System.Drawing.Point(125, 176);
            this.txtAuthorization.MaxLength = 10;
            this.txtAuthorization.Name = "txtAuthorization";
            this.txtAuthorization.Size = new System.Drawing.Size(78, 20);
            this.txtAuthorization.TabIndex = 6;
            this.txtAuthorization.TextChanged += new System.EventHandler(this.txtAuthorization_TextChanged);
            this.txtAuthorization.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtWorkerNumber
            // 
            this.txtWorkerNumber.AllowBlankSpaces = false;
            this.txtWorkerNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWorkerNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtWorkerNumber.CustomExpression = ".*";
            this.txtWorkerNumber.EnterColor = System.Drawing.Color.Empty;
            this.txtWorkerNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtWorkerNumber.Location = new System.Drawing.Point(125, 202);
            this.txtWorkerNumber.MaxLength = 10;
            this.txtWorkerNumber.Name = "txtWorkerNumber";
            this.txtWorkerNumber.Size = new System.Drawing.Size(78, 20);
            this.txtWorkerNumber.TabIndex = 7;
            this.txtWorkerNumber.TextChanged += new System.EventHandler(this.txtWorkerNumber_TextChanged);
            this.txtWorkerNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblWorkerNumber
            // 
            this.lblWorkerNumber.AutoSize = true;
            this.lblWorkerNumber.ForeColor = System.Drawing.Color.Black;
            this.lblWorkerNumber.Location = new System.Drawing.Point(2, 204);
            this.lblWorkerNumber.Name = "lblWorkerNumber";
            this.lblWorkerNumber.Size = new System.Drawing.Size(112, 13);
            this.lblWorkerNumber.TabIndex = 0;
            this.lblWorkerNumber.Text = "Número de Empleado:";
            // 
            // txtSociety
            // 
            this.txtSociety.AllowBlankSpaces = false;
            this.txtSociety.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSociety.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtSociety.CustomExpression = ".*";
            this.txtSociety.EnterColor = System.Drawing.Color.Empty;
            this.txtSociety.LeaveColor = System.Drawing.Color.Empty;
            this.txtSociety.Location = new System.Drawing.Point(125, 228);
            this.txtSociety.MaxLength = 10;
            this.txtSociety.Name = "txtSociety";
            this.txtSociety.Size = new System.Drawing.Size(78, 20);
            this.txtSociety.TabIndex = 8;
            this.txtSociety.TextChanged += new System.EventHandler(this.txtSociety_TextChanged);
            this.txtSociety.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblSociety
            // 
            this.lblSociety.AutoSize = true;
            this.lblSociety.ForeColor = System.Drawing.Color.Black;
            this.lblSociety.Location = new System.Drawing.Point(2, 230);
            this.lblSociety.Name = "lblSociety";
            this.lblSociety.Size = new System.Drawing.Size(55, 13);
            this.lblSociety.TabIndex = 0;
            this.lblSociety.Text = "Sociedad:";
            // 
            // txtManageCenter
            // 
            this.txtManageCenter.AllowBlankSpaces = false;
            this.txtManageCenter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtManageCenter.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtManageCenter.CustomExpression = ".*";
            this.txtManageCenter.EnterColor = System.Drawing.Color.Empty;
            this.txtManageCenter.LeaveColor = System.Drawing.Color.Empty;
            this.txtManageCenter.Location = new System.Drawing.Point(125, 254);
            this.txtManageCenter.MaxLength = 10;
            this.txtManageCenter.Name = "txtManageCenter";
            this.txtManageCenter.Size = new System.Drawing.Size(78, 20);
            this.txtManageCenter.TabIndex = 9;
            this.txtManageCenter.TextChanged += new System.EventHandler(this.txtManageCenter_TextChanged);
            this.txtManageCenter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblManagerCenter
            // 
            this.lblManagerCenter.AutoSize = true;
            this.lblManagerCenter.ForeColor = System.Drawing.Color.Black;
            this.lblManagerCenter.Location = new System.Drawing.Point(2, 256);
            this.lblManagerCenter.Name = "lblManagerCenter";
            this.lblManagerCenter.Size = new System.Drawing.Size(75, 13);
            this.lblManagerCenter.TabIndex = 0;
            this.lblManagerCenter.Text = "Centro Gestor:";
            // 
            // txtInvoicePosition
            // 
            this.txtInvoicePosition.AllowBlankSpaces = false;
            this.txtInvoicePosition.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInvoicePosition.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtInvoicePosition.CustomExpression = ".*";
            this.txtInvoicePosition.EnterColor = System.Drawing.Color.Empty;
            this.txtInvoicePosition.LeaveColor = System.Drawing.Color.Empty;
            this.txtInvoicePosition.Location = new System.Drawing.Point(125, 280);
            this.txtInvoicePosition.MaxLength = 10;
            this.txtInvoicePosition.Name = "txtInvoicePosition";
            this.txtInvoicePosition.Size = new System.Drawing.Size(78, 20);
            this.txtInvoicePosition.TabIndex = 10;
            this.txtInvoicePosition.TextChanged += new System.EventHandler(this.txtInvoicePosition_TextChanged);
            this.txtInvoicePosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblInvoicePosition
            // 
            this.lblInvoicePosition.AutoSize = true;
            this.lblInvoicePosition.ForeColor = System.Drawing.Color.Black;
            this.lblInvoicePosition.Location = new System.Drawing.Point(2, 282);
            this.lblInvoicePosition.Name = "lblInvoicePosition";
            this.lblInvoicePosition.Size = new System.Drawing.Size(114, 13);
            this.lblInvoicePosition.TabIndex = 0;
            this.lblInvoicePosition.Text = "Posición Presupuestal:";
            // 
            // txtSolicitator
            // 
            this.txtSolicitator.AllowBlankSpaces = false;
            this.txtSolicitator.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSolicitator.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtSolicitator.CustomExpression = ".*";
            this.txtSolicitator.EnterColor = System.Drawing.Color.Empty;
            this.txtSolicitator.LeaveColor = System.Drawing.Color.Empty;
            this.txtSolicitator.Location = new System.Drawing.Point(126, 434);
            this.txtSolicitator.MaxLength = 10;
            this.txtSolicitator.Name = "txtSolicitator";
            this.txtSolicitator.Size = new System.Drawing.Size(78, 20);
            this.txtSolicitator.TabIndex = 16;
            this.txtSolicitator.TextChanged += new System.EventHandler(this.txtSolicitator_TextChanged);
            this.txtSolicitator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblSolicitator
            // 
            this.lblSolicitator.AutoSize = true;
            this.lblSolicitator.ForeColor = System.Drawing.Color.Black;
            this.lblSolicitator.Location = new System.Drawing.Point(3, 436);
            this.lblSolicitator.Name = "lblSolicitator";
            this.lblSolicitator.Size = new System.Drawing.Size(59, 13);
            this.lblSolicitator.TabIndex = 47;
            this.lblSolicitator.Text = "Solicitante:";
            // 
            // txtcontractPosition
            // 
            this.txtcontractPosition.AllowBlankSpaces = false;
            this.txtcontractPosition.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcontractPosition.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtcontractPosition.CustomExpression = ".*";
            this.txtcontractPosition.EnterColor = System.Drawing.Color.Empty;
            this.txtcontractPosition.LeaveColor = System.Drawing.Color.Empty;
            this.txtcontractPosition.Location = new System.Drawing.Point(126, 408);
            this.txtcontractPosition.MaxLength = 20;
            this.txtcontractPosition.Name = "txtcontractPosition";
            this.txtcontractPosition.Size = new System.Drawing.Size(174, 20);
            this.txtcontractPosition.TabIndex = 15;
            this.txtcontractPosition.TextChanged += new System.EventHandler(this.txtcontractPosition_TextChanged);
            this.txtcontractPosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblcontractPosition
            // 
            this.lblcontractPosition.AutoSize = true;
            this.lblcontractPosition.ForeColor = System.Drawing.Color.Black;
            this.lblcontractPosition.Location = new System.Drawing.Point(3, 410);
            this.lblcontractPosition.Name = "lblcontractPosition";
            this.lblcontractPosition.Size = new System.Drawing.Size(110, 13);
            this.lblcontractPosition.TabIndex = 46;
            this.lblcontractPosition.Text = "Posición del Contrato:";
            // 
            // txtFareIndicator
            // 
            this.txtFareIndicator.AllowBlankSpaces = false;
            this.txtFareIndicator.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFareIndicator.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtFareIndicator.CustomExpression = ".*";
            this.txtFareIndicator.EnterColor = System.Drawing.Color.Empty;
            this.txtFareIndicator.LeaveColor = System.Drawing.Color.Empty;
            this.txtFareIndicator.Location = new System.Drawing.Point(126, 668);
            this.txtFareIndicator.MaxLength = 10;
            this.txtFareIndicator.Name = "txtFareIndicator";
            this.txtFareIndicator.Size = new System.Drawing.Size(78, 20);
            this.txtFareIndicator.TabIndex = 25;
            this.txtFareIndicator.TextChanged += new System.EventHandler(this.txtFareIndicator_TextChanged);
            this.txtFareIndicator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblFareIndicator
            // 
            this.lblFareIndicator.AutoSize = true;
            this.lblFareIndicator.ForeColor = System.Drawing.Color.Black;
            this.lblFareIndicator.Location = new System.Drawing.Point(3, 670);
            this.lblFareIndicator.Name = "lblFareIndicator";
            this.lblFareIndicator.Size = new System.Drawing.Size(75, 13);
            this.lblFareIndicator.TabIndex = 54;
            this.lblFareIndicator.Text = "Fare Indicator:";
            // 
            // txtOnlineBookingIndicator
            // 
            this.txtOnlineBookingIndicator.AllowBlankSpaces = false;
            this.txtOnlineBookingIndicator.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOnlineBookingIndicator.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtOnlineBookingIndicator.CustomExpression = ".*";
            this.txtOnlineBookingIndicator.EnterColor = System.Drawing.Color.Empty;
            this.txtOnlineBookingIndicator.LeaveColor = System.Drawing.Color.Empty;
            this.txtOnlineBookingIndicator.Location = new System.Drawing.Point(126, 642);
            this.txtOnlineBookingIndicator.MaxLength = 10;
            this.txtOnlineBookingIndicator.Name = "txtOnlineBookingIndicator";
            this.txtOnlineBookingIndicator.Size = new System.Drawing.Size(78, 20);
            this.txtOnlineBookingIndicator.TabIndex = 24;
            this.txtOnlineBookingIndicator.TextChanged += new System.EventHandler(this.txtOnlineBookingIndicator_TextChanged);
            this.txtOnlineBookingIndicator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblOnlineBookingIndicator
            // 
            this.lblOnlineBookingIndicator.AutoSize = true;
            this.lblOnlineBookingIndicator.ForeColor = System.Drawing.Color.Black;
            this.lblOnlineBookingIndicator.Location = new System.Drawing.Point(3, 644);
            this.lblOnlineBookingIndicator.Name = "lblOnlineBookingIndicator";
            this.lblOnlineBookingIndicator.Size = new System.Drawing.Size(126, 13);
            this.lblOnlineBookingIndicator.TabIndex = 0;
            this.lblOnlineBookingIndicator.Text = "Online Booking Indicator:";
            // 
            // txtLegalEntity
            // 
            this.txtLegalEntity.AllowBlankSpaces = false;
            this.txtLegalEntity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLegalEntity.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtLegalEntity.CustomExpression = ".*";
            this.txtLegalEntity.EnterColor = System.Drawing.Color.Empty;
            this.txtLegalEntity.LeaveColor = System.Drawing.Color.Empty;
            this.txtLegalEntity.Location = new System.Drawing.Point(126, 616);
            this.txtLegalEntity.MaxLength = 10;
            this.txtLegalEntity.Name = "txtLegalEntity";
            this.txtLegalEntity.Size = new System.Drawing.Size(78, 20);
            this.txtLegalEntity.TabIndex = 23;
            this.txtLegalEntity.TextChanged += new System.EventHandler(this.txtLegalEntity_TextChanged);
            this.txtLegalEntity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblLegalEntity
            // 
            this.lblLegalEntity.AutoSize = true;
            this.lblLegalEntity.ForeColor = System.Drawing.Color.Black;
            this.lblLegalEntity.Location = new System.Drawing.Point(3, 618);
            this.lblLegalEntity.Name = "lblLegalEntity";
            this.lblLegalEntity.Size = new System.Drawing.Size(65, 13);
            this.lblLegalEntity.TabIndex = 0;
            this.lblLegalEntity.Text = "Legal Entity:";
            // 
            // lblSubactivity
            // 
            this.lblSubactivity.AutoSize = true;
            this.lblSubactivity.ForeColor = System.Drawing.Color.Black;
            this.lblSubactivity.Location = new System.Drawing.Point(3, 592);
            this.lblSubactivity.Name = "lblSubactivity";
            this.lblSubactivity.Size = new System.Drawing.Size(62, 13);
            this.lblSubactivity.TabIndex = 50;
            this.lblSubactivity.Text = "Subcuenta:";
            // 
            // lblActivity
            // 
            this.lblActivity.AutoSize = true;
            this.lblActivity.ForeColor = System.Drawing.Color.Black;
            this.lblActivity.Location = new System.Drawing.Point(3, 566);
            this.lblActivity.Name = "lblActivity";
            this.lblActivity.Size = new System.Drawing.Size(54, 13);
            this.lblActivity.TabIndex = 0;
            this.lblActivity.Text = "Actividad:";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.ForeColor = System.Drawing.Color.Black;
            this.lblAccount.Location = new System.Drawing.Point(3, 540);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(44, 13);
            this.lblAccount.TabIndex = 0;
            this.lblAccount.Text = "Cuenta:";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.ForeColor = System.Drawing.Color.Black;
            this.lblCompany.Location = new System.Drawing.Point(3, 461);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(57, 13);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Compañia:";
            // 
            // lblCostCenterDHL
            // 
            this.lblCostCenterDHL.AutoSize = true;
            this.lblCostCenterDHL.ForeColor = System.Drawing.Color.Black;
            this.lblCostCenterDHL.Location = new System.Drawing.Point(3, 487);
            this.lblCostCenterDHL.Name = "lblCostCenterDHL";
            this.lblCostCenterDHL.Size = new System.Drawing.Size(28, 13);
            this.lblCostCenterDHL.TabIndex = 0;
            this.lblCostCenterDHL.Text = "Site:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.ForeColor = System.Drawing.Color.Black;
            this.lblCustomer.Location = new System.Drawing.Point(4, 512);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(42, 13);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Cliente:";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DisplayMember = "Text";
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Items.AddRange(new object[] {
            "Ingrese el código de Compañia:"});
            this.cmbCompany.Location = new System.Drawing.Point(125, 459);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(262, 21);
            this.cmbCompany.TabIndex = 17;
            this.cmbCompany.ValueMember = "Value";
            this.cmbCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbCostCenterDHL
            // 
            this.cmbCostCenterDHL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCostCenterDHL.FormattingEnabled = true;
            this.cmbCostCenterDHL.Items.AddRange(new object[] {
            "Ingresa el código de CostCenter:"});
            this.cmbCostCenterDHL.Location = new System.Drawing.Point(125, 485);
            this.cmbCostCenterDHL.Name = "cmbCostCenterDHL";
            this.cmbCostCenterDHL.Size = new System.Drawing.Size(262, 21);
            this.cmbCostCenterDHL.TabIndex = 18;
            this.cmbCostCenterDHL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Items.AddRange(new object[] {
            "Ingresa el código de Customer:"});
            this.cmbCustomer.Location = new System.Drawing.Point(125, 510);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(262, 21);
            this.cmbCustomer.TabIndex = 19;
            this.cmbCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbAccount
            // 
            this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Items.AddRange(new object[] {
            "Ingresa el código de Account:"});
            this.cmbAccount.Location = new System.Drawing.Point(125, 538);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(262, 21);
            this.cmbAccount.TabIndex = 20;
            this.cmbAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbActivity
            // 
            this.cmbActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActivity.FormattingEnabled = true;
            this.cmbActivity.Items.AddRange(new object[] {
            "Ingresa el código de Activity:"});
            this.cmbActivity.Location = new System.Drawing.Point(125, 564);
            this.cmbActivity.Name = "cmbActivity";
            this.cmbActivity.Size = new System.Drawing.Size(262, 21);
            this.cmbActivity.TabIndex = 21;
            this.cmbActivity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbSubactivity
            // 
            this.cmbSubactivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubactivity.FormattingEnabled = true;
            this.cmbSubactivity.Items.AddRange(new object[] {
            "Ingresa el código de Subactivity:"});
            this.cmbSubactivity.Location = new System.Drawing.Point(125, 590);
            this.cmbSubactivity.Name = "cmbSubactivity";
            this.cmbSubactivity.Size = new System.Drawing.Size(262, 21);
            this.cmbSubactivity.TabIndex = 22;
            this.cmbSubactivity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRealFare
            // 
            this.txtRealFare.AllowBlankSpaces = false;
            this.txtRealFare.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRealFare.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtRealFare.CustomExpression = ".*";
            this.txtRealFare.EnterColor = System.Drawing.Color.Empty;
            this.txtRealFare.LeaveColor = System.Drawing.Color.Empty;
            this.txtRealFare.Location = new System.Drawing.Point(126, 694);
            this.txtRealFare.MaxLength = 10;
            this.txtRealFare.Name = "txtRealFare";
            this.txtRealFare.Size = new System.Drawing.Size(78, 20);
            this.txtRealFare.TabIndex = 26;
            this.txtRealFare.TextChanged += new System.EventHandler(this.txtRealFare_TextChanged);
            this.txtRealFare.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblRealFare
            // 
            this.lblRealFare.AutoSize = true;
            this.lblRealFare.ForeColor = System.Drawing.Color.Black;
            this.lblRealFare.Location = new System.Drawing.Point(2, 696);
            this.lblRealFare.Name = "lblRealFare";
            this.lblRealFare.Size = new System.Drawing.Size(62, 13);
            this.lblRealFare.TabIndex = 0;
            this.lblRealFare.Text = "Tarifa Real:";
            // 
            // ucQualityControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtRealFare);
            this.Controls.Add(this.lblRealFare);
            this.Controls.Add(this.cmbSubactivity);
            this.Controls.Add(this.cmbActivity);
            this.Controls.Add(this.cmbAccount);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.cmbCostCenterDHL);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.txtFareIndicator);
            this.Controls.Add(this.lblFareIndicator);
            this.Controls.Add(this.txtOnlineBookingIndicator);
            this.Controls.Add(this.lblOnlineBookingIndicator);
            this.Controls.Add(this.txtLegalEntity);
            this.Controls.Add(this.lblLegalEntity);
            this.Controls.Add(this.lblSubactivity);
            this.Controls.Add(this.lblActivity);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblCostCenterDHL);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.txtSolicitator);
            this.Controls.Add(this.lblSolicitator);
            this.Controls.Add(this.txtcontractPosition);
            this.Controls.Add(this.lblcontractPosition);
            this.Controls.Add(this.lbCostCenter);
            this.Controls.Add(this.txtInvoicePosition);
            this.Controls.Add(this.lblInvoicePosition);
            this.Controls.Add(this.txtManageCenter);
            this.Controls.Add(this.lblManagerCenter);
            this.Controls.Add(this.txtSociety);
            this.Controls.Add(this.lblSociety);
            this.Controls.Add(this.txtWorkerNumber);
            this.Controls.Add(this.lblWorkerNumber);
            this.Controls.Add(this.txtAuthorization);
            this.Controls.Add(this.lblAuthorization);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblDivision);
            this.Controls.Add(this.txtDivision);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.cmbSaleOrigin);
            this.Controls.Add(this.cmbBusinessUnit);
            this.Controls.Add(this.lblSaleOrigin);
            this.Controls.Add(this.lblBusinessUnit);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.txtCostCenter);
            this.Controls.Add(this.lblCenterCosts);
            this.Controls.Add(this.chkClass);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.cmbJustifications);
            this.Controls.Add(this.lblJustifications);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucQualityControls";
            this.Size = new System.Drawing.Size(411, 725);
            this.Load += new System.EventHandler(this.ucQualityControls_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblJustifications;
        private System.Windows.Forms.ComboBox cmbJustifications;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.CheckBox chkClass;
        private System.Windows.Forms.Label lblCenterCosts;
        private MyCTS.Forms.UI.SmartTextBox txtCostCenter;
        private System.Windows.Forms.ListBox lbCostCenter;
        private System.Windows.Forms.Label lblArea;
        private MyCTS.Forms.UI.SmartTextBox txtArea;
        private System.Windows.Forms.Label lblBusinessUnit;
        private System.Windows.Forms.Label lblSaleOrigin;
        private System.Windows.Forms.ComboBox cmbBusinessUnit;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.ComboBox cmbSaleOrigin;
        private MyCTS.Forms.UI.SmartTextBox txtDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblDivision;
        private MyCTS.Forms.UI.SmartTextBox txtDivision;
        private System.Windows.Forms.Label lblNumber;
        private MyCTS.Forms.UI.SmartTextBox txtNumber;
        private System.Windows.Forms.Label lblAuthorization;
        private MyCTS.Forms.UI.SmartTextBox txtAuthorization;
        private MyCTS.Forms.UI.SmartTextBox txtWorkerNumber;
        private System.Windows.Forms.Label lblWorkerNumber;
        private MyCTS.Forms.UI.SmartTextBox txtSociety;
        private System.Windows.Forms.Label lblSociety;
        private MyCTS.Forms.UI.SmartTextBox txtManageCenter;
        private System.Windows.Forms.Label lblManagerCenter;
        private MyCTS.Forms.UI.SmartTextBox txtInvoicePosition;
        private System.Windows.Forms.Label lblInvoicePosition;
        private MyCTS.Forms.UI.SmartTextBox txtSolicitator;
        private System.Windows.Forms.Label lblSolicitator;
        private MyCTS.Forms.UI.SmartTextBox txtcontractPosition;
        private System.Windows.Forms.Label lblcontractPosition;
        private MyCTS.Forms.UI.SmartTextBox txtFareIndicator;
        private System.Windows.Forms.Label lblFareIndicator;
        private MyCTS.Forms.UI.SmartTextBox txtOnlineBookingIndicator;
        private System.Windows.Forms.Label lblOnlineBookingIndicator;
        private MyCTS.Forms.UI.SmartTextBox txtLegalEntity;
        private System.Windows.Forms.Label lblLegalEntity;
        private System.Windows.Forms.Label lblSubactivity;
        private System.Windows.Forms.Label lblActivity;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblCostCenterDHL;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.ComboBox cmbCostCenterDHL;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.ComboBox cmbActivity;
        private System.Windows.Forms.ComboBox cmbSubactivity;
        private MyCTS.Forms.UI.SmartTextBox txtRealFare;
        private System.Windows.Forms.Label lblRealFare;
        private System.Windows.Forms.BindingSource bindingSource3;
    }
}
