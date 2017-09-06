using System;
using System.Windows.Forms;
using MyCTS.Business;

namespace MyCTS.Presentation.Reservations.Profiles
{
    partial class ucFirstLevelProfiles
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
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("En este espacio encontrará la infomación de los perfiles desactivados");
            this.pnlRemarks = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.UserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEmailContact = new System.Windows.Forms.Label();
            this.txtEmailContact = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPCC = new System.Windows.Forms.Label();
            this.txtEnterpriseName = new MyCTS.Forms.UI.SmartTextBox();
            this.lblEnterpriseName = new System.Windows.Forms.Label();
            this.txtNumberExt = new MyCTS.Forms.UI.SmartTextBox();
            this.lblNumberExt = new System.Windows.Forms.Label();
            this.txtPostalCode = new MyCTS.Forms.UI.SmartTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtState = new MyCTS.Forms.UI.SmartTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCity = new MyCTS.Forms.UI.SmartTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumberInt = new MyCTS.Forms.UI.SmartTextBox();
            this.lblNumberInt = new System.Windows.Forms.Label();
            this.txtCreateBy = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCreateBy = new System.Windows.Forms.Label();
            this.lblExample5 = new System.Windows.Forms.Label();
            this.txtEnterpriseContact = new MyCTS.Forms.UI.SmartTextBox();
            this.lblEnterprise = new System.Windows.Forms.Label();
            this.txtRFC3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRFC2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRFC1 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblRFC = new System.Windows.Forms.Label();
            this.txtDelorMunicipality = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAdress2 = new System.Windows.Forms.Label();
            this.txtColony = new MyCTS.Forms.UI.SmartTextBox();
            this.txtStreet = new MyCTS.Forms.UI.SmartTextBox();
            this.lblColony = new System.Windows.Forms.Label();
            this.lblAdress = new System.Windows.Forms.Label();
            this.lblExample4 = new System.Windows.Forms.Label();
            this.txtSocialReason = new MyCTS.Forms.UI.SmartTextBox();
            this.lblSocialReason = new System.Windows.Forms.Label();
            this.txtDK = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDK = new System.Windows.Forms.Label();
            this.txtExt = new MyCTS.Forms.UI.SmartTextBox();
            this.lblExt = new System.Windows.Forms.Label();
            this.txtPhone = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.a = new System.Windows.Forms.Label();
            this.txtProfileName = new MyCTS.Forms.UI.SmartTextBox();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.elmtHostCCFirstLevel = new System.Windows.Forms.Integration.ElementHost();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.chkSync = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblExample6 = new System.Windows.Forms.Label();
            this.ucMultilineSmartTextBox2 = new UC_MultiSmartTextBox.UcMultilineSmartTextBox();
            this.ucMultilineSmartTextBox1 = new UC_MultiSmartTextBox.UcMultilineSmartTextBox();
            this.txtPassword = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.Label();
            this.lblTravelPolicies = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.lblFormatSabre = new System.Windows.Forms.Label();
            this.ucMultiLineSmartTextSabreFormat = new MyCTS.Presentation.Components.ucMultiLineSmartText();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ucMultiLineSmartTextAlternativeEmail = new MyCTS.Presentation.Components.ucMultiLineSmartText();
            this.ucMultiTextRemarks1 = new MyCTS.Presentation.Components.ucMultiTextRemarks();
            this.lblOSI = new System.Windows.Forms.Label();
            this.ucMultiLineSmartTextOSI = new MyCTS.Presentation.Components.ucMultiLineSmartText();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lvHistoric = new System.Windows.Forms.ListView();
            this.Profile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pnlExtraData = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAccept = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imagen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.Update = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.pnlRemarks.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.pnlExtraData.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRemarks
            // 
            this.pnlRemarks.Controls.Add(this.tabPage1);
            this.pnlRemarks.Controls.Add(this.tabPage2);
            this.pnlRemarks.Controls.Add(this.tabPage4);
            this.pnlRemarks.Controls.Add(this.tabPage5);
            this.pnlRemarks.Controls.Add(this.tabPage3);
            this.pnlRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRemarks.Location = new System.Drawing.Point(0, 0);
            this.pnlRemarks.Name = "pnlRemarks";
            this.pnlRemarks.SelectedIndex = 0;
            this.pnlRemarks.Size = new System.Drawing.Size(512, 602);
            this.pnlRemarks.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightBlue;
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.lblEmailContact);
            this.tabPage1.Controls.Add(this.txtEmailContact);
            this.tabPage1.Controls.Add(this.txtPCC);
            this.tabPage1.Controls.Add(this.lblPCC);
            this.tabPage1.Controls.Add(this.txtEnterpriseName);
            this.tabPage1.Controls.Add(this.lblEnterpriseName);
            this.tabPage1.Controls.Add(this.txtNumberExt);
            this.tabPage1.Controls.Add(this.lblNumberExt);
            this.tabPage1.Controls.Add(this.txtPostalCode);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtState);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtCity);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtNumberInt);
            this.tabPage1.Controls.Add(this.lblNumberInt);
            this.tabPage1.Controls.Add(this.txtCreateBy);
            this.tabPage1.Controls.Add(this.lblCreateBy);
            this.tabPage1.Controls.Add(this.lblExample5);
            this.tabPage1.Controls.Add(this.txtEnterpriseContact);
            this.tabPage1.Controls.Add(this.lblEnterprise);
            this.tabPage1.Controls.Add(this.txtRFC3);
            this.tabPage1.Controls.Add(this.txtRFC2);
            this.tabPage1.Controls.Add(this.txtRFC1);
            this.tabPage1.Controls.Add(this.lblRFC);
            this.tabPage1.Controls.Add(this.txtDelorMunicipality);
            this.tabPage1.Controls.Add(this.lblAdress2);
            this.tabPage1.Controls.Add(this.txtColony);
            this.tabPage1.Controls.Add(this.txtStreet);
            this.tabPage1.Controls.Add(this.lblColony);
            this.tabPage1.Controls.Add(this.lblAdress);
            this.tabPage1.Controls.Add(this.lblExample4);
            this.tabPage1.Controls.Add(this.txtSocialReason);
            this.tabPage1.Controls.Add(this.lblSocialReason);
            this.tabPage1.Controls.Add(this.txtDK);
            this.tabPage1.Controls.Add(this.lblDK);
            this.tabPage1.Controls.Add(this.txtExt);
            this.tabPage1.Controls.Add(this.lblExt);
            this.tabPage1.Controls.Add(this.txtPhone);
            this.tabPage1.Controls.Add(this.lblPhone);
            this.tabPage1.Controls.Add(this.a);
            this.tabPage1.Controls.Add(this.txtProfileName);
            this.tabPage1.Controls.Add(this.lblProfileName);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(504, 576);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Perfil 1er. Nivel";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(184, 422);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 13);
            this.label11.TabIndex = 124;
            this.label11.Text = "Historial de Movimientos";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserName,
            this.Date});
            this.listView1.Location = new System.Drawing.Point(186, 447);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(274, 98);
            this.listView1.TabIndex = 123;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // UserName
            // 
            this.UserName.Tag = "Log";
            this.UserName.Text = "Nombre";
            this.UserName.Width = 125;
            // 
            // Date
            // 
            this.Date.Tag = "Log";
            this.Date.Text = "Fecha";
            this.Date.Width = 140;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(21, 510);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 13);
            this.label5.TabIndex = 122;
            this.label5.Text = "Datos en Cyan - Opcionales";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 481);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 13);
            this.label4.TabIndex = 121;
            this.label4.Text = "Datos en Negro - Mandatorios";
            // 
            // lblEmailContact
            // 
            this.lblEmailContact.AutoSize = true;
            this.lblEmailContact.Location = new System.Drawing.Point(23, 365);
            this.lblEmailContact.Name = "lblEmailContact";
            this.lblEmailContact.Size = new System.Drawing.Size(98, 13);
            this.lblEmailContact.TabIndex = 120;
            this.lblEmailContact.Text = "Email del Contacto:";
            // 
            // txtEmailContact
            // 
            this.txtEmailContact.AllowBlankSpaces = true;
            this.txtEmailContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmailContact.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtEmailContact.CustomExpression = ".*";
            this.txtEmailContact.EnterColor = System.Drawing.Color.Empty;
            this.txtEmailContact.LeaveColor = System.Drawing.Color.Empty;
            this.txtEmailContact.Location = new System.Drawing.Point(130, 362);
            this.txtEmailContact.Name = "txtEmailContact";
            this.txtEmailContact.Size = new System.Drawing.Size(347, 20);
            this.txtEmailContact.TabIndex = 20;
            this.txtEmailContact.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = false;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(248, 59);
            this.txtPCC.MaxLength = 4;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(58, 20);
            this.txtPCC.TabIndex = 3;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Location = new System.Drawing.Point(214, 60);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(31, 13);
            this.lblPCC.TabIndex = 119;
            this.lblPCC.Text = "PCC:";
            // 
            // txtEnterpriseName
            // 
            this.txtEnterpriseName.AllowBlankSpaces = true;
            this.txtEnterpriseName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEnterpriseName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtEnterpriseName.CustomExpression = ".*";
            this.txtEnterpriseName.Enabled = false;
            this.txtEnterpriseName.EnterColor = System.Drawing.Color.Empty;
            this.txtEnterpriseName.LeaveColor = System.Drawing.Color.Empty;
            this.txtEnterpriseName.Location = new System.Drawing.Point(130, 82);
            this.txtEnterpriseName.MaxLength = 60;
            this.txtEnterpriseName.Name = "txtEnterpriseName";
            this.txtEnterpriseName.Size = new System.Drawing.Size(346, 20);
            this.txtEnterpriseName.TabIndex = 4;
            this.txtEnterpriseName.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // lblEnterpriseName
            // 
            this.lblEnterpriseName.AutoSize = true;
            this.lblEnterpriseName.Location = new System.Drawing.Point(3, 85);
            this.lblEnterpriseName.Name = "lblEnterpriseName";
            this.lblEnterpriseName.Size = new System.Drawing.Size(117, 13);
            this.lblEnterpriseName.TabIndex = 118;
            this.lblEnterpriseName.Text = "Nombre de la Empresa:";
            // 
            // txtNumberExt
            // 
            this.txtNumberExt.AllowBlankSpaces = true;
            this.txtNumberExt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberExt.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtNumberExt.CustomExpression = ".*";
            this.txtNumberExt.Enabled = false;
            this.txtNumberExt.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberExt.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberExt.Location = new System.Drawing.Point(418, 179);
            this.txtNumberExt.MaxLength = 5;
            this.txtNumberExt.Name = "txtNumberExt";
            this.txtNumberExt.Size = new System.Drawing.Size(59, 20);
            this.txtNumberExt.TabIndex = 9;
            this.txtNumberExt.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // lblNumberExt
            // 
            this.lblNumberExt.AutoSize = true;
            this.lblNumberExt.Location = new System.Drawing.Point(381, 182);
            this.lblNumberExt.Name = "lblNumberExt";
            this.lblNumberExt.Size = new System.Drawing.Size(32, 13);
            this.lblNumberExt.TabIndex = 117;
            this.lblNumberExt.Text = "#Ext:";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.AllowBlankSpaces = true;
            this.txtPostalCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPostalCode.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPostalCode.CustomExpression = ".*";
            this.txtPostalCode.Enabled = false;
            this.txtPostalCode.EnterColor = System.Drawing.Color.Empty;
            this.txtPostalCode.LeaveColor = System.Drawing.Color.Empty;
            this.txtPostalCode.Location = new System.Drawing.Point(402, 232);
            this.txtPostalCode.MaxLength = 6;
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(76, 20);
            this.txtPostalCode.TabIndex = 13;
            this.txtPostalCode.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(368, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 116;
            this.label1.Text = "CP:";
            // 
            // txtState
            // 
            this.txtState.AllowBlankSpaces = true;
            this.txtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtState.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtState.CustomExpression = ".*";
            this.txtState.Enabled = false;
            this.txtState.EnterColor = System.Drawing.Color.Empty;
            this.txtState.LeaveColor = System.Drawing.Color.Empty;
            this.txtState.Location = new System.Drawing.Point(333, 261);
            this.txtState.MaxLength = 18;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(145, 20);
            this.txtState.TabIndex = 15;
            this.txtState.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 115;
            this.label3.Text = "Estado:";
            // 
            // txtCity
            // 
            this.txtCity.AllowBlankSpaces = true;
            this.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCity.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCity.CustomExpression = ".*";
            this.txtCity.Enabled = false;
            this.txtCity.EnterColor = System.Drawing.Color.Empty;
            this.txtCity.LeaveColor = System.Drawing.Color.Empty;
            this.txtCity.Location = new System.Drawing.Point(130, 261);
            this.txtCity.MaxLength = 20;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(100, 20);
            this.txtCity.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 114;
            this.label2.Text = "Ciudad:";
            // 
            // txtNumberInt
            // 
            this.txtNumberInt.AllowBlankSpaces = true;
            this.txtNumberInt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberInt.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtNumberInt.CustomExpression = ".*";
            this.txtNumberInt.Enabled = false;
            this.txtNumberInt.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberInt.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberInt.Location = new System.Drawing.Point(131, 205);
            this.txtNumberInt.MaxLength = 5;
            this.txtNumberInt.Name = "txtNumberInt";
            this.txtNumberInt.Size = new System.Drawing.Size(59, 20);
            this.txtNumberInt.TabIndex = 10;
            this.txtNumberInt.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // lblNumberInt
            // 
            this.lblNumberInt.AutoSize = true;
            this.lblNumberInt.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblNumberInt.Location = new System.Drawing.Point(92, 208);
            this.lblNumberInt.Name = "lblNumberInt";
            this.lblNumberInt.Size = new System.Drawing.Size(29, 13);
            this.lblNumberInt.TabIndex = 113;
            this.lblNumberInt.Text = "#Int:";
            // 
            // txtCreateBy
            // 
            this.txtCreateBy.AllowBlankSpaces = true;
            this.txtCreateBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCreateBy.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCreateBy.CustomExpression = ".*";
            this.txtCreateBy.EnterColor = System.Drawing.Color.Empty;
            this.txtCreateBy.LeaveColor = System.Drawing.Color.Empty;
            this.txtCreateBy.Location = new System.Drawing.Point(129, 388);
            this.txtCreateBy.MaxLength = 100;
            this.txtCreateBy.Name = "txtCreateBy";
            this.txtCreateBy.Size = new System.Drawing.Size(345, 20);
            this.txtCreateBy.TabIndex = 21;
            this.txtCreateBy.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // lblCreateBy
            // 
            this.lblCreateBy.AutoSize = true;
            this.lblCreateBy.Location = new System.Drawing.Point(54, 391);
            this.lblCreateBy.Name = "lblCreateBy";
            this.lblCreateBy.Size = new System.Drawing.Size(62, 13);
            this.lblCreateBy.TabIndex = 79;
            this.lblCreateBy.Text = "Creado por:";
            // 
            // lblExample5
            // 
            this.lblExample5.AutoSize = true;
            this.lblExample5.ForeColor = System.Drawing.Color.Blue;
            this.lblExample5.Location = new System.Drawing.Point(128, 321);
            this.lblExample5.Name = "lblExample5";
            this.lblExample5.Size = new System.Drawing.Size(62, 13);
            this.lblExample5.TabIndex = 64;
            this.lblExample5.Text = "Ej. (15 dias)";
            // 
            // txtEnterpriseContact
            // 
            this.txtEnterpriseContact.AllowBlankSpaces = true;
            this.txtEnterpriseContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEnterpriseContact.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtEnterpriseContact.CustomExpression = ".*";
            this.txtEnterpriseContact.EnterColor = System.Drawing.Color.Empty;
            this.txtEnterpriseContact.LeaveColor = System.Drawing.Color.Empty;
            this.txtEnterpriseContact.Location = new System.Drawing.Point(130, 335);
            this.txtEnterpriseContact.MaxLength = 40;
            this.txtEnterpriseContact.Name = "txtEnterpriseContact";
            this.txtEnterpriseContact.Size = new System.Drawing.Size(347, 20);
            this.txtEnterpriseContact.TabIndex = 19;
            this.txtEnterpriseContact.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // lblEnterprise
            // 
            this.lblEnterprise.AutoSize = true;
            this.lblEnterprise.Location = new System.Drawing.Point(25, 340);
            this.lblEnterprise.Name = "lblEnterprise";
            this.lblEnterprise.Size = new System.Drawing.Size(100, 13);
            this.lblEnterprise.TabIndex = 63;
            this.lblEnterprise.Text = "Contacto  Empresa:";
            // 
            // txtRFC3
            // 
            this.txtRFC3.AllowBlankSpaces = false;
            this.txtRFC3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRFC3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtRFC3.CustomExpression = ".*";
            this.txtRFC3.Enabled = false;
            this.txtRFC3.EnterColor = System.Drawing.Color.Empty;
            this.txtRFC3.LeaveColor = System.Drawing.Color.Empty;
            this.txtRFC3.Location = new System.Drawing.Point(275, 293);
            this.txtRFC3.MaxLength = 3;
            this.txtRFC3.Name = "txtRFC3";
            this.txtRFC3.Size = new System.Drawing.Size(43, 20);
            this.txtRFC3.TabIndex = 18;
            this.txtRFC3.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // txtRFC2
            // 
            this.txtRFC2.AllowBlankSpaces = false;
            this.txtRFC2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRFC2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRFC2.CustomExpression = ".*";
            this.txtRFC2.Enabled = false;
            this.txtRFC2.EnterColor = System.Drawing.Color.Empty;
            this.txtRFC2.LeaveColor = System.Drawing.Color.Empty;
            this.txtRFC2.Location = new System.Drawing.Point(195, 293);
            this.txtRFC2.MaxLength = 6;
            this.txtRFC2.Name = "txtRFC2";
            this.txtRFC2.Size = new System.Drawing.Size(76, 20);
            this.txtRFC2.TabIndex = 17;
            this.txtRFC2.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // txtRFC1
            // 
            this.txtRFC1.AllowBlankSpaces = false;
            this.txtRFC1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRFC1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtRFC1.CustomExpression = ".*";
            this.txtRFC1.Enabled = false;
            this.txtRFC1.EnterColor = System.Drawing.Color.Empty;
            this.txtRFC1.LeaveColor = System.Drawing.Color.Empty;
            this.txtRFC1.Location = new System.Drawing.Point(131, 293);
            this.txtRFC1.MaxLength = 4;
            this.txtRFC1.Name = "txtRFC1";
            this.txtRFC1.Size = new System.Drawing.Size(60, 20);
            this.txtRFC1.TabIndex = 16;
            this.txtRFC1.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // lblRFC
            // 
            this.lblRFC.AutoSize = true;
            this.lblRFC.Location = new System.Drawing.Point(95, 296);
            this.lblRFC.Name = "lblRFC";
            this.lblRFC.Size = new System.Drawing.Size(31, 13);
            this.lblRFC.TabIndex = 54;
            this.lblRFC.Text = "RFC:";
            // 
            // txtDelorMunicipality
            // 
            this.txtDelorMunicipality.AllowBlankSpaces = true;
            this.txtDelorMunicipality.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDelorMunicipality.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtDelorMunicipality.CustomExpression = ".*";
            this.txtDelorMunicipality.Enabled = false;
            this.txtDelorMunicipality.EnterColor = System.Drawing.Color.Empty;
            this.txtDelorMunicipality.LeaveColor = System.Drawing.Color.Empty;
            this.txtDelorMunicipality.Location = new System.Drawing.Point(130, 232);
            this.txtDelorMunicipality.MaxLength = 15;
            this.txtDelorMunicipality.Name = "txtDelorMunicipality";
            this.txtDelorMunicipality.Size = new System.Drawing.Size(224, 20);
            this.txtDelorMunicipality.TabIndex = 12;
            this.txtDelorMunicipality.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // lblAdress2
            // 
            this.lblAdress2.AutoSize = true;
            this.lblAdress2.Location = new System.Drawing.Point(5, 235);
            this.lblAdress2.Name = "lblAdress2";
            this.lblAdress2.Size = new System.Drawing.Size(121, 13);
            this.lblAdress2.TabIndex = 56;
            this.lblAdress2.Text = "Delegación o Municipio:";
            // 
            // txtColony
            // 
            this.txtColony.AllowBlankSpaces = true;
            this.txtColony.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtColony.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtColony.CustomExpression = ".*";
            this.txtColony.Enabled = false;
            this.txtColony.EnterColor = System.Drawing.Color.Empty;
            this.txtColony.LeaveColor = System.Drawing.Color.Empty;
            this.txtColony.Location = new System.Drawing.Point(252, 205);
            this.txtColony.MaxLength = 30;
            this.txtColony.Name = "txtColony";
            this.txtColony.Size = new System.Drawing.Size(225, 20);
            this.txtColony.TabIndex = 11;
            this.txtColony.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // txtStreet
            // 
            this.txtStreet.AllowBlankSpaces = true;
            this.txtStreet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStreet.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtStreet.CustomExpression = ".*";
            this.txtStreet.Enabled = false;
            this.txtStreet.EnterColor = System.Drawing.Color.Empty;
            this.txtStreet.LeaveColor = System.Drawing.Color.Empty;
            this.txtStreet.Location = new System.Drawing.Point(131, 179);
            this.txtStreet.MaxLength = 21;
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(241, 20);
            this.txtStreet.TabIndex = 8;
            this.txtStreet.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // lblColony
            // 
            this.lblColony.AutoSize = true;
            this.lblColony.Location = new System.Drawing.Point(203, 208);
            this.lblColony.Name = "lblColony";
            this.lblColony.Size = new System.Drawing.Size(45, 13);
            this.lblColony.TabIndex = 58;
            this.lblColony.Text = "Colonia:";
            // 
            // lblAdress
            // 
            this.lblAdress.AutoSize = true;
            this.lblAdress.Location = new System.Drawing.Point(92, 182);
            this.lblAdress.Name = "lblAdress";
            this.lblAdress.Size = new System.Drawing.Size(33, 13);
            this.lblAdress.TabIndex = 57;
            this.lblAdress.Text = "Calle:";
            // 
            // lblExample4
            // 
            this.lblExample4.AutoSize = true;
            this.lblExample4.ForeColor = System.Drawing.Color.Blue;
            this.lblExample4.Location = new System.Drawing.Point(128, 136);
            this.lblExample4.Name = "lblExample4";
            this.lblExample4.Size = new System.Drawing.Size(209, 13);
            this.lblExample4.TabIndex = 72;
            this.lblExample4.Text = "Ej. (Corporate Travel Services S.A. de C.V)";
            // 
            // txtSocialReason
            // 
            this.txtSocialReason.AllowBlankSpaces = true;
            this.txtSocialReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSocialReason.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtSocialReason.CustomExpression = ".*";
            this.txtSocialReason.Enabled = false;
            this.txtSocialReason.EnterColor = System.Drawing.Color.Empty;
            this.txtSocialReason.LeaveColor = System.Drawing.Color.Empty;
            this.txtSocialReason.Location = new System.Drawing.Point(131, 152);
            this.txtSocialReason.MaxLength = 55;
            this.txtSocialReason.Name = "txtSocialReason";
            this.txtSocialReason.Size = new System.Drawing.Size(345, 20);
            this.txtSocialReason.TabIndex = 7;
            this.txtSocialReason.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // lblSocialReason
            // 
            this.lblSocialReason.AutoSize = true;
            this.lblSocialReason.Location = new System.Drawing.Point(54, 155);
            this.lblSocialReason.Name = "lblSocialReason";
            this.lblSocialReason.Size = new System.Drawing.Size(71, 13);
            this.lblSocialReason.TabIndex = 71;
            this.lblSocialReason.Text = "Razon social:";
            // 
            // txtDK
            // 
            this.txtDK.AllowBlankSpaces = false;
            this.txtDK.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDK.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtDK.CustomExpression = ".*";
            this.txtDK.EnterColor = System.Drawing.Color.Empty;
            this.txtDK.LeaveColor = System.Drawing.Color.Empty;
            this.txtDK.Location = new System.Drawing.Point(130, 57);
            this.txtDK.MaxLength = 6;
            this.txtDK.Name = "txtDK";
            this.txtDK.Size = new System.Drawing.Size(76, 20);
            this.txtDK.TabIndex = 2;
            this.txtDK.TextChanged += new System.EventHandler(this.txtDK_TextChanged);
            // 
            // lblDK
            // 
            this.lblDK.AutoSize = true;
            this.lblDK.Location = new System.Drawing.Point(21, 60);
            this.lblDK.Name = "lblDK";
            this.lblDK.Size = new System.Drawing.Size(103, 13);
            this.lblDK.TabIndex = 66;
            this.lblDK.Text = "Num. de Cliente DK:";
            // 
            // txtExt
            // 
            this.txtExt.AllowBlankSpaces = false;
            this.txtExt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExt.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtExt.CustomExpression = ".*";
            this.txtExt.EnterColor = System.Drawing.Color.Empty;
            this.txtExt.LeaveColor = System.Drawing.Color.Empty;
            this.txtExt.Location = new System.Drawing.Point(280, 107);
            this.txtExt.MaxLength = 6;
            this.txtExt.Name = "txtExt";
            this.txtExt.Size = new System.Drawing.Size(76, 20);
            this.txtExt.TabIndex = 6;
            this.txtExt.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // lblExt
            // 
            this.lblExt.AutoSize = true;
            this.lblExt.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblExt.Location = new System.Drawing.Point(249, 110);
            this.lblExt.Name = "lblExt";
            this.lblExt.Size = new System.Drawing.Size(25, 13);
            this.lblExt.TabIndex = 65;
            this.lblExt.Text = "Ext:";
            // 
            // txtPhone
            // 
            this.txtPhone.AllowBlankSpaces = false;
            this.txtPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPhone.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPhone.CustomExpression = ".*";
            this.txtPhone.Enabled = false;
            this.txtPhone.EnterColor = System.Drawing.Color.Empty;
            this.txtPhone.LeaveColor = System.Drawing.Color.Empty;
            this.txtPhone.Location = new System.Drawing.Point(130, 107);
            this.txtPhone.MaxLength = 10;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(109, 20);
            this.txtPhone.TabIndex = 5;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(68, 110);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(52, 13);
            this.lblPhone.TabIndex = 67;
            this.lblPhone.Text = "Telefono:";
            // 
            // a
            // 
            this.a.AutoSize = true;
            this.a.ForeColor = System.Drawing.Color.Blue;
            this.a.Location = new System.Drawing.Point(129, 16);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(43, 13);
            this.a.TabIndex = 69;
            this.a.Text = "Ej. CTS";
            // 
            // txtProfileName
            // 
            this.txtProfileName.AllowBlankSpaces = true;
            this.txtProfileName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProfileName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtProfileName.CustomExpression = ".*";
            this.txtProfileName.EnterColor = System.Drawing.Color.Empty;
            this.txtProfileName.LeaveColor = System.Drawing.Color.Empty;
            this.txtProfileName.Location = new System.Drawing.Point(130, 32);
            this.txtProfileName.MaxLength = 60;
            this.txtProfileName.Name = "txtProfileName";
            this.txtProfileName.Size = new System.Drawing.Size(346, 20);
            this.txtProfileName.TabIndex = 1;
            this.txtProfileName.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // lblProfileName
            // 
            this.lblProfileName.AutoSize = true;
            this.lblProfileName.Location = new System.Drawing.Point(30, 35);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(90, 13);
            this.lblProfileName.TabIndex = 59;
            this.lblProfileName.Text = "Nombre del Perfil:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightBlue;
            this.tabPage2.Controls.Add(this.elmtHostCCFirstLevel);
            this.tabPage2.Controls.Add(this.label23);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.chkSync);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.lblExample6);
            this.tabPage2.Controls.Add(this.ucMultilineSmartTextBox2);
            this.tabPage2.Controls.Add(this.ucMultilineSmartTextBox1);
            this.tabPage2.Controls.Add(this.txtPassword);
            this.tabPage2.Controls.Add(this.lblPassword);
            this.tabPage2.Controls.Add(this.txtComments);
            this.tabPage2.Controls.Add(this.lblTravelPolicies);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(504, 576);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Complementaria";
            // 
            // elmtHostCCFirstLevel
            // 
            this.elmtHostCCFirstLevel.Location = new System.Drawing.Point(8, 10);
            this.elmtHostCCFirstLevel.Name = "elmtHostCCFirstLevel";
            this.elmtHostCCFirstLevel.Size = new System.Drawing.Size(450, 144);
            this.elmtHostCCFirstLevel.TabIndex = 159;
            this.elmtHostCCFirstLevel.Text = "elementHost1";
            this.elmtHostCCFirstLevel.Child = null;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(97, 552);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(223, 13);
            this.label23.TabIndex = 158;
            this.label23.Text = "dentro de MyCTS y mantenerlos actualizados.";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(97, 539);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(300, 13);
            this.label22.TabIndex = 157;
            this.label22.Text = "en línea OBT Concur para sincronizar los perfiles de pasajeros";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(97, 526);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(281, 13);
            this.label21.TabIndex = 156;
            this.label21.Text = "Este parámetro se utiliza para las cuentas con herramienta";
            // 
            // chkSync
            // 
            this.chkSync.AutoSize = true;
            this.chkSync.Location = new System.Drawing.Point(100, 509);
            this.chkSync.Name = "chkSync";
            this.chkSync.Size = new System.Drawing.Size(15, 14);
            this.chkSync.TabIndex = 155;
            this.chkSync.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.DarkCyan;
            this.label20.Location = new System.Drawing.Point(15, 509);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 13);
            this.label20.TabIndex = 154;
            this.label20.Text = "Sincronización:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(97, 478);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(261, 13);
            this.label10.TabIndex = 125;
            this.label10.Text = "o un supervisor que tenga acceso a todos los perfiles.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(97, 462);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(269, 13);
            this.label9.TabIndex = 124;
            this.label9.Text = "y nadie podrá abrirlo a menos que conozca el password";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(97, 449);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(264, 13);
            this.label8.TabIndex = 123;
            this.label8.Text = "Si usted escribe un password protegerá su información";
            // 
            // lblExample6
            // 
            this.lblExample6.AutoSize = true;
            this.lblExample6.ForeColor = System.Drawing.Color.Blue;
            this.lblExample6.Location = new System.Drawing.Point(109, 298);
            this.lblExample6.Name = "lblExample6";
            this.lblExample6.Size = new System.Drawing.Size(135, 13);
            this.lblExample6.TabIndex = 115;
            this.lblExample6.Text = "Ej. (Horarios de 9 a 1 p.m. )";
            // 
            // ucMultilineSmartTextBox2
            // 
            this.ucMultilineSmartTextBox2.HeadText = "";
            this.ucMultilineSmartTextBox2.Location = new System.Drawing.Point(100, 286);
            this.ucMultilineSmartTextBox2.MaxCharacters = 50;
            this.ucMultilineSmartTextBox2.Name = "ucMultilineSmartTextBox2";
            this.ucMultilineSmartTextBox2.Separator = new string[] {
        "*#*"};
            this.ucMultilineSmartTextBox2.Size = new System.Drawing.Size(344, 120);
            this.ucMultilineSmartTextBox2.StartRows = 4;
            this.ucMultilineSmartTextBox2.TabIndex = 44;
            this.ucMultilineSmartTextBox2.WidthTextBox = 323;
            // 
            // ucMultilineSmartTextBox1
            // 
            this.ucMultilineSmartTextBox1.HeadText = "";
            this.ucMultilineSmartTextBox1.Location = new System.Drawing.Point(100, 160);
            this.ucMultilineSmartTextBox1.MaxCharacters = 50;
            this.ucMultilineSmartTextBox1.Name = "ucMultilineSmartTextBox1";
            this.ucMultilineSmartTextBox1.Separator = new string[] {
        "*#*"};
            this.ucMultilineSmartTextBox1.Size = new System.Drawing.Size(344, 120);
            this.ucMultilineSmartTextBox1.StartRows = 4;
            this.ucMultilineSmartTextBox1.TabIndex = 43;
            this.ucMultilineSmartTextBox1.WidthTextBox = 323;
            // 
            // txtPassword
            // 
            this.txtPassword.AllowBlankSpaces = false;
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassword.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPassword.CustomExpression = ".*";
            this.txtPassword.EnterColor = System.Drawing.Color.Empty;
            this.txtPassword.Font = new System.Drawing.Font("Symbol", 10F, System.Drawing.FontStyle.Bold);
            this.txtPassword.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassword.Location = new System.Drawing.Point(100, 422);
            this.txtPassword.MaxLength = 8;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(114, 24);
            this.txtPassword.TabIndex = 45;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.ForeColor = System.Drawing.Color.Black;
            this.lblPassword.Location = new System.Drawing.Point(38, 425);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 119;
            this.lblPassword.Text = "Password:";
            // 
            // txtComments
            // 
            this.txtComments.AutoSize = true;
            this.txtComments.ForeColor = System.Drawing.Color.DarkCyan;
            this.txtComments.Location = new System.Drawing.Point(27, 321);
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(68, 13);
            this.txtComments.TabIndex = 113;
            this.txtComments.Text = "Comentarios:";
            // 
            // lblTravelPolicies
            // 
            this.lblTravelPolicies.AutoSize = true;
            this.lblTravelPolicies.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTravelPolicies.Location = new System.Drawing.Point(5, 195);
            this.lblTravelPolicies.Name = "lblTravelPolicies";
            this.lblTravelPolicies.Size = new System.Drawing.Size(90, 13);
            this.lblTravelPolicies.TabIndex = 90;
            this.lblTravelPolicies.Text = "Politicas de Viaje:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(504, 576);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Remarks";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.lblFormatSabre);
            this.panel2.Controls.Add(this.ucMultiLineSmartTextSabreFormat);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.ucMultiLineSmartTextAlternativeEmail);
            this.panel2.Controls.Add(this.ucMultiTextRemarks1);
            this.panel2.Controls.Add(this.lblOSI);
            this.panel2.Controls.Add(this.ucMultiLineSmartTextOSI);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(498, 570);
            this.panel2.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(37, 404);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(298, 12);
            this.label18.TabIndex = 144;
            this.label18.Text = "*Para ingresar guión bajo en correo de Sabre, debes colocar dos veces =";
            // 
            // lblFormatSabre
            // 
            this.lblFormatSabre.AutoSize = true;
            this.lblFormatSabre.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblFormatSabre.Location = new System.Drawing.Point(36, 447);
            this.lblFormatSabre.Name = "lblFormatSabre";
            this.lblFormatSabre.Size = new System.Drawing.Size(63, 13);
            this.lblFormatSabre.TabIndex = 134;
            this.lblFormatSabre.Text = "Otros Sabre";
            // 
            // ucMultiLineSmartTextSabreFormat
            // 
            this.ucMultiLineSmartTextSabreFormat.BackColor = System.Drawing.Color.LightBlue;
            this.ucMultiLineSmartTextSabreFormat.Location = new System.Drawing.Point(27, 436);
            this.ucMultiLineSmartTextSabreFormat.Name = "ucMultiLineSmartTextSabreFormat";
            this.ucMultiLineSmartTextSabreFormat.Size = new System.Drawing.Size(445, 121);
            this.ucMultiLineSmartTextSabreFormat.TabIndex = 135;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DarkCyan;
            this.label7.Location = new System.Drawing.Point(36, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 129;
            this.label7.Text = "Correos Alternos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkCyan;
            this.label6.Location = new System.Drawing.Point(36, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 127;
            this.label6.Text = "Remarks";
            // 
            // ucMultiLineSmartTextAlternativeEmail
            // 
            this.ucMultiLineSmartTextAlternativeEmail.BackColor = System.Drawing.Color.LightBlue;
            this.ucMultiLineSmartTextAlternativeEmail.Location = new System.Drawing.Point(27, 279);
            this.ucMultiLineSmartTextAlternativeEmail.Name = "ucMultiLineSmartTextAlternativeEmail";
            this.ucMultiLineSmartTextAlternativeEmail.Size = new System.Drawing.Size(445, 121);
            this.ucMultiLineSmartTextAlternativeEmail.TabIndex = 133;
            // 
            // ucMultiTextRemarks1
            // 
            this.ucMultiTextRemarks1.BackColor = System.Drawing.Color.LightBlue;
            this.ucMultiTextRemarks1.Location = new System.Drawing.Point(27, 144);
            this.ucMultiTextRemarks1.Name = "ucMultiTextRemarks1";
            this.ucMultiTextRemarks1.Size = new System.Drawing.Size(445, 117);
            this.ucMultiTextRemarks1.TabIndex = 132;
            // 
            // lblOSI
            // 
            this.lblOSI.AutoSize = true;
            this.lblOSI.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblOSI.Location = new System.Drawing.Point(36, 12);
            this.lblOSI.Name = "lblOSI";
            this.lblOSI.Size = new System.Drawing.Size(25, 13);
            this.lblOSI.TabIndex = 125;
            this.lblOSI.Text = "OSI";
            // 
            // ucMultiLineSmartTextOSI
            // 
            this.ucMultiLineSmartTextOSI.BackColor = System.Drawing.Color.LightBlue;
            this.ucMultiLineSmartTextOSI.Location = new System.Drawing.Point(27, 3);
            this.ucMultiLineSmartTextOSI.Name = "ucMultiLineSmartTextOSI";
            this.ucMultiLineSmartTextOSI.Size = new System.Drawing.Size(445, 121);
            this.ucMultiLineSmartTextOSI.TabIndex = 131;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 570);
            this.splitter1.TabIndex = 130;
            this.splitter1.TabStop = false;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.LightBlue;
            this.tabPage5.Controls.Add(this.lvHistoric);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(504, 576);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Histórico";
            // 
            // lvHistoric
            // 
            this.lvHistoric.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Profile});
            this.lvHistoric.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4});
            this.lvHistoric.Location = new System.Drawing.Point(18, 20);
            this.lvHistoric.Name = "lvHistoric";
            this.lvHistoric.Size = new System.Drawing.Size(442, 511);
            this.lvHistoric.TabIndex = 0;
            this.lvHistoric.UseCompatibleStateImageBehavior = false;
            this.lvHistoric.View = System.Windows.Forms.View.List;
            // 
            // Profile
            // 
            this.Profile.Tag = "Historico";
            this.Profile.Text = "Perfiles";
            this.Profile.Width = 440;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pnlExtraData);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(504, 576);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Datos Extras";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pnlExtraData
            // 
            this.pnlExtraData.AutoScroll = true;
            this.pnlExtraData.BackColor = System.Drawing.Color.LightBlue;
            this.pnlExtraData.Controls.Add(this.dataGridView);
            this.pnlExtraData.Controls.Add(this.btnAddImage);
            this.pnlExtraData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExtraData.Location = new System.Drawing.Point(0, 0);
            this.pnlExtraData.Name = "pnlExtraData";
            this.pnlExtraData.Size = new System.Drawing.Size(504, 576);
            this.pnlExtraData.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAccept);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 602);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 32);
            this.panel1.TabIndex = 0;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(391, 4);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(95, 25);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Documento,
            this.Imagen,
            this.Delete,
            this.Update});
            this.dataGridView.Location = new System.Drawing.Point(3, 54);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(479, 119);
            this.dataGridView.TabIndex = 287;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // No
            // 
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            this.No.Width = 50;
            // 
            // Documento
            // 
            this.Documento.HeaderText = "Documento";
            this.Documento.Name = "Documento";
            // 
            // Imagen
            // 
            this.Imagen.HeaderText = "Imagen";
            this.Imagen.Name = "Imagen";
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.Width = 40;
            // 
            // Update
            // 
            this.Update.HeaderText = "Update";
            this.Update.Name = "Update";
            this.Update.Width = 50;
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(3, 25);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(91, 23);
            this.btnAddImage.TabIndex = 286;
            this.btnAddImage.Text = "Add Image";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // ucFirstLevelProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlRemarks);
            this.Controls.Add(this.panel1);
            this.Name = "ucFirstLevelProfiles";
            this.Size = new System.Drawing.Size(512, 634);
            this.Load += new System.EventHandler(this.ucFirstLevelProfiles_Load);
            this.pnlRemarks.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.pnlExtraData.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TabControl pnlRemarks;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblEmailContact;
        private Forms.UI.SmartTextBox txtEmailContact;
        private Forms.UI.SmartTextBox txtPCC;
        private System.Windows.Forms.Label lblPCC;
        private Forms.UI.SmartTextBox txtEnterpriseName;
        private System.Windows.Forms.Label lblEnterpriseName;
        private Forms.UI.SmartTextBox txtNumberExt;
        private System.Windows.Forms.Label lblNumberExt;
        private Forms.UI.SmartTextBox txtPostalCode;
        private System.Windows.Forms.Label label1;
        private Forms.UI.SmartTextBox txtState;
        private System.Windows.Forms.Label label3;
        private Forms.UI.SmartTextBox txtCity;
        private System.Windows.Forms.Label label2;
        private Forms.UI.SmartTextBox txtNumberInt;
        private System.Windows.Forms.Label lblNumberInt;
        private Forms.UI.SmartTextBox txtCreateBy;
        private System.Windows.Forms.Label lblCreateBy;
        private System.Windows.Forms.Label lblExample5;
        private Forms.UI.SmartTextBox txtEnterpriseContact;
        private System.Windows.Forms.Label lblEnterprise;
        private Forms.UI.SmartTextBox txtRFC3;
        private Forms.UI.SmartTextBox txtRFC2;
        private Forms.UI.SmartTextBox txtRFC1;
        private System.Windows.Forms.Label lblRFC;
        private Forms.UI.SmartTextBox txtDelorMunicipality;
        private System.Windows.Forms.Label lblAdress2;
        private Forms.UI.SmartTextBox txtColony;
        private Forms.UI.SmartTextBox txtStreet;
        private System.Windows.Forms.Label lblColony;
        private System.Windows.Forms.Label lblAdress;
        private System.Windows.Forms.Label lblExample4;
        private Forms.UI.SmartTextBox txtSocialReason;
        private System.Windows.Forms.Label lblSocialReason;
        private Forms.UI.SmartTextBox txtDK;
        private System.Windows.Forms.Label lblDK;
        private Forms.UI.SmartTextBox txtExt;
        private System.Windows.Forms.Label lblExt;
        private Forms.UI.SmartTextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label a;
        private Forms.UI.SmartTextBox txtProfileName;
        private System.Windows.Forms.Label lblProfileName;
        private System.Windows.Forms.TabPage tabPage2;
        private Forms.UI.SmartTextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblExample6;
        private System.Windows.Forms.Label txtComments;
        private System.Windows.Forms.Label lblTravelPolicies;

        /// <summary>
        /// Busca si el DK ingresado ya se encuentra en algún perfil guardado
        /// </summary>
        private static Boolean ExistDkInProfiles(string customerDk, string parameter)
        {
            if (string.IsNullOrEmpty(parameter))
            {
                var listProfiles = GetStar1ProfileByDkBL.GetStar1ByDk(customerDk);
                if (listProfiles.Count > 0)
                {
                    string prefiles = "";
                    foreach (var profile in listProfiles)
                    {
                        prefiles = prefiles + "    * " + profile.Level1 + "\n";
                    }
                    MessageBox.Show("Este DK no puede ser utilizado en la creación del perfil\n"
                                    + "debido a que ya pertenece a los siguientes perfiles:\n\n" + prefiles, "Validación DK",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button1);


                    return true;
                }

                return false;
            }
            else if (parameter.Equals("NewUpdate"))
            {
                var listProfiles = GetStar1ProfileByDkBL.GetStar1ByDk(customerDk);
                if (listProfiles.Count > 0)
                {
                    string prefiles = "";
                    foreach (var profile in listProfiles)
                    {
                        prefiles = prefiles + "    * " + profile.Level1 + "\n";
                    }
                    MessageBox.Show("Este DK no puede ser utilizado en la creación del perfil\n"
                                    + "debido a que ya pertenece a los siguientes perfiles:\n\n" + prefiles, "Validación DK",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button1);


                    return true;
                }
                return false;
            }
            else 
                return false;
        }

        private UC_MultiSmartTextBox.UcMultilineSmartTextBox ucMultilineSmartTextBox1;
        private UC_MultiSmartTextBox.UcMultilineSmartTextBox ucMultilineSmartTextBox2;
        private TabPage tabPage3;
        private Panel pnlExtraData;
        private Label label4;
        private Label label5;
        private TabPage tabPage4;
        private Panel panel2;
        private Splitter splitter1;
        private Label label7;
        private Label label6;
        private Label lblOSI;
        private MyCTS.Presentation.Components.ucMultiTextRemarks ucMultiTextRemarks1;
        private MyCTS.Presentation.Components.ucMultiLineSmartText ucMultiLineSmartTextOSI;
        private MyCTS.Presentation.Components.ucMultiLineSmartText ucMultiLineSmartTextAlternativeEmail;
        private TabPage tabPage5;
        private Label label8;
        private Label label9;
        private Label label10;
        private ListView lvHistoric;
        private System.Windows.Forms.ColumnHeader Profile; 
        private ListView listView1;
        private System.Windows.Forms.ColumnHeader UserName;
        private System.Windows.Forms.ColumnHeader Date;
        private Label label11;
        private Label lblFormatSabre;
        private MyCTS.Presentation.Components.ucMultiLineSmartText ucMultiLineSmartTextSabreFormat;
        private Label label18;
        private Label label23;
        private Label label22;
        private Label label21;
        private CheckBox chkSync;
        private Label label20;
        private System.Windows.Forms.Integration.ElementHost elmtHostCCFirstLevel;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn No;
        private DataGridViewTextBoxColumn Documento;
        private DataGridViewTextBoxColumn Imagen;
        private DataGridViewImageColumn Delete;
        private DataGridViewImageColumn Update;
        private Button btnAddImage;
    }
}
