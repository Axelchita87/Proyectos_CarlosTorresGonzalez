namespace MyCTS.Presentation
{
    partial class ucCreateFirm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblNumberFirm = new System.Windows.Forms.Label();
            this.lblPCC = new System.Windows.Forms.Label();
            this.lblQueue = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtNumberFirm = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.txtQueue = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLastName = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCodeAgent = new System.Windows.Forms.Label();
            this.lblPassCode = new System.Windows.Forms.Label();
            this.lblTA = new System.Windows.Forms.Label();
            this.lblIntial = new System.Windows.Forms.Label();
            this.txtCodeAgent = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPassCode = new MyCTS.Forms.UI.SmartTextBox();
            this.txtTA = new MyCTS.Forms.UI.SmartTextBox();
            this.txtInitial = new MyCTS.Forms.UI.SmartTextBox();
            this.txtName = new MyCTS.Forms.UI.SmartTextBox();
            this.txtEmail = new MyCTS.Forms.UI.SmartTextBox();
            this.chkDutyCode = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chkMINIOPR = new System.Windows.Forms.CheckBox();
            this.chkCreate = new System.Windows.Forms.CheckBox();
            this.chkAccess = new System.Windows.Forms.CheckBox();
            this.chkCIIMGR = new System.Windows.Forms.CheckBox();
            this.chkSUBMGR = new System.Windows.Forms.CheckBox();
            this.chkPNRREL = new System.Windows.Forms.CheckBox();
            this.chkSUBACC = new System.Windows.Forms.CheckBox();
            this.lblMIOPR = new System.Windows.Forms.Label();
            this.lblCreate = new System.Windows.Forms.Label();
            this.lblAccess = new System.Windows.Forms.Label();
            this.lblCIIMGR = new System.Windows.Forms.Label();
            this.lblSUBMGR = new System.Windows.Forms.Label();
            this.lblPNRREL = new System.Windows.Forms.Label();
            this.lblSUBACC = new System.Windows.Forms.Label();
            this.cmbKeyWord8 = new System.Windows.Forms.ComboBox();
            this.cmbKeyWord12 = new System.Windows.Forms.ComboBox();
            this.cmbKeyWord9 = new System.Windows.Forms.ComboBox();
            this.cmbKeyWord11 = new System.Windows.Forms.ComboBox();
            this.cmbKeyWord10 = new System.Windows.Forms.ComboBox();
            this.lblAuthorization = new System.Windows.Forms.Label();
            this.txtAuthorization = new MyCTS.Forms.UI.SmartTextBox();
            this.lbPCC = new System.Windows.Forms.ListBox();
            this.rbnSabre = new System.Windows.Forms.RadioButton();
            this.rbnMyCTS = new System.Windows.Forms.RadioButton();
            this.rbnBoth = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textAgentMail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Crear Firma";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(288, 545);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 26;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblNumberFirm
            // 
            this.lblNumberFirm.AutoSize = true;
            this.lblNumberFirm.Location = new System.Drawing.Point(12, 23);
            this.lblNumberFirm.Name = "lblNumberFirm";
            this.lblNumberFirm.Size = new System.Drawing.Size(67, 13);
            this.lblNumberFirm.TabIndex = 0;
            this.lblNumberFirm.Text = "No. de Firma";
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Location = new System.Drawing.Point(12, 49);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(28, 13);
            this.lblPCC.TabIndex = 0;
            this.lblPCC.Text = "PCC";
            // 
            // lblQueue
            // 
            this.lblQueue.AutoSize = true;
            this.lblQueue.Location = new System.Drawing.Point(12, 72);
            this.lblQueue.Name = "lblQueue";
            this.lblQueue.Size = new System.Drawing.Size(39, 13);
            this.lblQueue.TabIndex = 0;
            this.lblQueue.Text = "Queue";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(12, 118);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(44, 13);
            this.lblLastName.TabIndex = 0;
            this.lblLastName.Text = "Apellido";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 147);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(91, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nombre Completo";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(16, 173);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(57, 13);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "User Email";
            // 
            // txtNumberFirm
            // 
            this.txtNumberFirm.AllowBlankSpaces = true;
            this.txtNumberFirm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberFirm.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberFirm.CustomExpression = ".*";
            this.txtNumberFirm.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberFirm.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberFirm.Location = new System.Drawing.Point(85, 20);
            this.txtNumberFirm.MaxLength = 4;
            this.txtNumberFirm.Name = "txtNumberFirm";
            this.txtNumberFirm.Size = new System.Drawing.Size(63, 20);
            this.txtNumberFirm.TabIndex = 1;
            this.txtNumberFirm.TextChanged += new System.EventHandler(this.txtNumberFirm_TextChanged);
            this.txtNumberFirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = true;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(85, 46);
            this.txtPCC.MaxLength = 4;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(301, 20);
            this.txtPCC.TabIndex = 3;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtQueue
            // 
            this.txtQueue.AllowBlankSpaces = true;
            this.txtQueue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQueue.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtQueue.CustomExpression = ".*";
            this.txtQueue.EnterColor = System.Drawing.Color.Empty;
            this.txtQueue.LeaveColor = System.Drawing.Color.Empty;
            this.txtQueue.Location = new System.Drawing.Point(85, 69);
            this.txtQueue.MaxLength = 3;
            this.txtQueue.Name = "txtQueue";
            this.txtQueue.Size = new System.Drawing.Size(48, 20);
            this.txtQueue.TabIndex = 5;
            this.txtQueue.TextChanged += new System.EventHandler(this.txtQueue_TextChanged);
            this.txtQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtLastName
            // 
            this.txtLastName.AllowBlankSpaces = true;
            this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtLastName.CustomExpression = ".*";
            this.txtLastName.EnterColor = System.Drawing.Color.Empty;
            this.txtLastName.LeaveColor = System.Drawing.Color.Empty;
            this.txtLastName.Location = new System.Drawing.Point(85, 118);
            this.txtLastName.MaxLength = 12;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 7;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            this.txtLastName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCodeAgent
            // 
            this.lblCodeAgent.AutoSize = true;
            this.lblCodeAgent.Location = new System.Drawing.Point(233, 23);
            this.lblCodeAgent.Name = "lblCodeAgent";
            this.lblCodeAgent.Size = new System.Drawing.Size(81, 13);
            this.lblCodeAgent.TabIndex = 0;
            this.lblCodeAgent.Text = "Cod. de Agente";
            // 
            // lblPassCode
            // 
            this.lblPassCode.AutoSize = true;
            this.lblPassCode.Location = new System.Drawing.Point(233, 75);
            this.lblPassCode.Name = "lblPassCode";
            this.lblPassCode.Size = new System.Drawing.Size(84, 13);
            this.lblPassCode.TabIndex = 0;
            this.lblPassCode.Text = "Passcode Temp";
            // 
            // lblTA
            // 
            this.lblTA.AutoSize = true;
            this.lblTA.Location = new System.Drawing.Point(13, 94);
            this.lblTA.Name = "lblTA";
            this.lblTA.Size = new System.Drawing.Size(21, 13);
            this.lblTA.TabIndex = 0;
            this.lblTA.Text = "TA";
            // 
            // lblIntial
            // 
            this.lblIntial.AutoSize = true;
            this.lblIntial.Location = new System.Drawing.Point(233, 122);
            this.lblIntial.Name = "lblIntial";
            this.lblIntial.Size = new System.Drawing.Size(34, 13);
            this.lblIntial.TabIndex = 0;
            this.lblIntial.Text = "Inicial";
            // 
            // txtCodeAgent
            // 
            this.txtCodeAgent.AllowBlankSpaces = true;
            this.txtCodeAgent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodeAgent.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtCodeAgent.CustomExpression = ".*";
            this.txtCodeAgent.EnterColor = System.Drawing.Color.Empty;
            this.txtCodeAgent.LeaveColor = System.Drawing.Color.Empty;
            this.txtCodeAgent.Location = new System.Drawing.Point(354, 20);
            this.txtCodeAgent.MaxLength = 2;
            this.txtCodeAgent.Name = "txtCodeAgent";
            this.txtCodeAgent.Size = new System.Drawing.Size(34, 20);
            this.txtCodeAgent.TabIndex = 2;
            this.txtCodeAgent.TextChanged += new System.EventHandler(this.txtCodeAgent_TextChanged);
            this.txtCodeAgent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPassCode
            // 
            this.txtPassCode.AllowBlankSpaces = true;
            this.txtPassCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassCode.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPassCode.CustomExpression = ".*";
            this.txtPassCode.EnterColor = System.Drawing.Color.Empty;
            this.txtPassCode.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassCode.Location = new System.Drawing.Point(327, 72);
            this.txtPassCode.MaxLength = 8;
            this.txtPassCode.Name = "txtPassCode";
            this.txtPassCode.Size = new System.Drawing.Size(61, 20);
            this.txtPassCode.TabIndex = 4;
            this.txtPassCode.Text = "TMP1234";
            this.txtPassCode.TextChanged += new System.EventHandler(this.txtPassCode_TextChanged);
            this.txtPassCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtTA
            // 
            this.txtTA.AllowBlankSpaces = true;
            this.txtTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTA.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtTA.CustomExpression = ".*";
            this.txtTA.EnterColor = System.Drawing.Color.Empty;
            this.txtTA.LeaveColor = System.Drawing.Color.Empty;
            this.txtTA.Location = new System.Drawing.Point(86, 94);
            this.txtTA.MaxLength = 6;
            this.txtTA.Name = "txtTA";
            this.txtTA.Size = new System.Drawing.Size(61, 20);
            this.txtTA.TabIndex = 6;
            this.txtTA.TextChanged += new System.EventHandler(this.txtTA_TextChanged);
            this.txtTA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtInitial
            // 
            this.txtInitial.AllowBlankSpaces = true;
            this.txtInitial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInitial.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtInitial.CustomExpression = ".*";
            this.txtInitial.EnterColor = System.Drawing.Color.Empty;
            this.txtInitial.LeaveColor = System.Drawing.Color.Empty;
            this.txtInitial.Location = new System.Drawing.Point(370, 122);
            this.txtInitial.MaxLength = 1;
            this.txtInitial.Name = "txtInitial";
            this.txtInitial.Size = new System.Drawing.Size(18, 20);
            this.txtInitial.TabIndex = 8;
            this.txtInitial.TextChanged += new System.EventHandler(this.txtInitial_TextChanged);
            this.txtInitial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtName
            // 
            this.txtName.AllowBlankSpaces = true;
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtName.CustomExpression = ".*";
            this.txtName.EnterColor = System.Drawing.Color.Empty;
            this.txtName.LeaveColor = System.Drawing.Color.Empty;
            this.txtName.Location = new System.Drawing.Point(109, 144);
            this.txtName.MaxLength = 40;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(279, 20);
            this.txtName.TabIndex = 9;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtEmail
            // 
            this.txtEmail.AllowBlankSpaces = true;
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtEmail.CustomExpression = ".*";
            this.txtEmail.EnterColor = System.Drawing.Color.Empty;
            this.txtEmail.LeaveColor = System.Drawing.Color.Empty;
            this.txtEmail.Location = new System.Drawing.Point(109, 170);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(279, 20);
            this.txtEmail.TabIndex = 10;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkDutyCode
            // 
            this.chkDutyCode.AutoSize = true;
            this.chkDutyCode.Location = new System.Drawing.Point(51, 221);
            this.chkDutyCode.Name = "chkDutyCode";
            this.chkDutyCode.Size = new System.Drawing.Size(82, 17);
            this.chkDutyCode.TabIndex = 12;
            this.chkDutyCode.Text = "DutyCode 9";
            this.chkDutyCode.UseVisualStyleBackColor = true;
            this.chkDutyCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 244);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Keywords por default:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(119, 244);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(192, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "24TIME, SUBAAA, PFKAGT, PTRAGT";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 258);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Adicionales";
            // 
            // chkMINIOPR
            // 
            this.chkMINIOPR.AutoSize = true;
            this.chkMINIOPR.Location = new System.Drawing.Point(19, 276);
            this.chkMINIOPR.Name = "chkMINIOPR";
            this.chkMINIOPR.Size = new System.Drawing.Size(69, 17);
            this.chkMINIOPR.TabIndex = 14;
            this.chkMINIOPR.Text = "MINOPR";
            this.chkMINIOPR.UseVisualStyleBackColor = true;
            this.chkMINIOPR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkCreate
            // 
            this.chkCreate.AutoSize = true;
            this.chkCreate.Location = new System.Drawing.Point(19, 295);
            this.chkCreate.Name = "chkCreate";
            this.chkCreate.Size = new System.Drawing.Size(69, 17);
            this.chkCreate.TabIndex = 15;
            this.chkCreate.Text = "CREATE";
            this.chkCreate.UseVisualStyleBackColor = true;
            this.chkCreate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkAccess
            // 
            this.chkAccess.AutoSize = true;
            this.chkAccess.Location = new System.Drawing.Point(19, 316);
            this.chkAccess.Name = "chkAccess";
            this.chkAccess.Size = new System.Drawing.Size(68, 17);
            this.chkAccess.TabIndex = 16;
            this.chkAccess.Text = "ACCESS";
            this.chkAccess.UseVisualStyleBackColor = true;
            this.chkAccess.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkCIIMGR
            // 
            this.chkCIIMGR.AutoSize = true;
            this.chkCIIMGR.Location = new System.Drawing.Point(19, 335);
            this.chkCIIMGR.Name = "chkCIIMGR";
            this.chkCIIMGR.Size = new System.Drawing.Size(64, 17);
            this.chkCIIMGR.TabIndex = 17;
            this.chkCIIMGR.Text = "CIIMGR";
            this.chkCIIMGR.UseVisualStyleBackColor = true;
            this.chkCIIMGR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkSUBMGR
            // 
            this.chkSUBMGR.AutoSize = true;
            this.chkSUBMGR.Location = new System.Drawing.Point(19, 353);
            this.chkSUBMGR.Name = "chkSUBMGR";
            this.chkSUBMGR.Size = new System.Drawing.Size(73, 17);
            this.chkSUBMGR.TabIndex = 18;
            this.chkSUBMGR.Text = "SUBMGR";
            this.chkSUBMGR.UseVisualStyleBackColor = true;
            this.chkSUBMGR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkPNRREL
            // 
            this.chkPNRREL.AutoSize = true;
            this.chkPNRREL.Location = new System.Drawing.Point(19, 371);
            this.chkPNRREL.Name = "chkPNRREL";
            this.chkPNRREL.Size = new System.Drawing.Size(70, 17);
            this.chkPNRREL.TabIndex = 19;
            this.chkPNRREL.Text = "PNRREL";
            this.chkPNRREL.UseVisualStyleBackColor = true;
            this.chkPNRREL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkSUBACC
            // 
            this.chkSUBACC.AutoSize = true;
            this.chkSUBACC.Location = new System.Drawing.Point(19, 388);
            this.chkSUBACC.Name = "chkSUBACC";
            this.chkSUBACC.Size = new System.Drawing.Size(69, 17);
            this.chkSUBACC.TabIndex = 20;
            this.chkSUBACC.Text = "SUBACC";
            this.chkSUBACC.UseVisualStyleBackColor = true;
            this.chkSUBACC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblMIOPR
            // 
            this.lblMIOPR.AutoSize = true;
            this.lblMIOPR.Location = new System.Drawing.Point(95, 276);
            this.lblMIOPR.Name = "lblMIOPR";
            this.lblMIOPR.Size = new System.Drawing.Size(180, 13);
            this.lblMIOPR.TabIndex = 0;
            this.lblMIOPR.Text = "Control DX – Entradas para Interface";
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.Location = new System.Drawing.Point(95, 295);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(153, 13);
            this.lblCreate.TabIndex = 0;
            this.lblCreate.Text = "Crear, Modificar y Purgar firmas";
            // 
            // lblAccess
            // 
            this.lblAccess.AutoSize = true;
            this.lblAccess.Location = new System.Drawing.Point(95, 316);
            this.lblAccess.Name = "lblAccess";
            this.lblAccess.Size = new System.Drawing.Size(199, 13);
            this.lblAccess.TabIndex = 0;
            this.lblAccess.Text = "Abrir acceso entre Suc. (Branch Access)";
            // 
            // lblCIIMGR
            // 
            this.lblCIIMGR.AutoSize = true;
            this.lblCIIMGR.Location = new System.Drawing.Point(95, 336);
            this.lblCIIMGR.Name = "lblCIIMGR";
            this.lblCIIMGR.Size = new System.Drawing.Size(187, 13);
            this.lblCIIMGR.TabIndex = 0;
            this.lblCIIMGR.Text = "Crear acceso personalizado y facturas";
            // 
            // lblSUBMGR
            // 
            this.lblSUBMGR.AutoSize = true;
            this.lblSUBMGR.Location = new System.Drawing.Point(95, 353);
            this.lblSUBMGR.Name = "lblSUBMGR";
            this.lblSUBMGR.Size = new System.Drawing.Size(201, 13);
            this.lblSUBMGR.TabIndex = 0;
            this.lblSUBMGR.Text = "Activa/Desactiva FlexEdita opc. de PNR";
            // 
            // lblPNRREL
            // 
            this.lblPNRREL.AutoSize = true;
            this.lblPNRREL.Location = new System.Drawing.Point(95, 371);
            this.lblPNRREL.Name = "lblPNRREL";
            this.lblPNRREL.Size = new System.Drawing.Size(188, 13);
            this.lblPNRREL.TabIndex = 0;
            this.lblPNRREL.Text = "Liberar PNR a otras Agy para consulta";
            // 
            // lblSUBACC
            // 
            this.lblSUBACC.AutoSize = true;
            this.lblSUBACC.Location = new System.Drawing.Point(95, 388);
            this.lblSUBACC.Name = "lblSUBACC";
            this.lblSUBACC.Size = new System.Drawing.Size(191, 13);
            this.lblSUBACC.TabIndex = 0;
            this.lblSUBACC.Text = "Firmarse en suc. Usando firma de mariz";
            // 
            // cmbKeyWord8
            // 
            this.cmbKeyWord8.DisplayMember = "Text";
            this.cmbKeyWord8.FormattingEnabled = true;
            this.cmbKeyWord8.Items.AddRange(new object[] {
            "",
            "AASATO                  AGENCY ACCESS TO FOCUS MANUALS - F*CDP",
            "ABAEXC                  ABACUS AGENT EXCEPTION",
            "ADSCOM                 CONTROL ADS MACHINE-TO-MACHINE NETWORK COMMUNICATION",
            "AGSTRC                  FORCE ICE DEBUG",
            "ALTDSP                   CONTROL HOTEL SHOPPING LIST DISPLAY",
            "ALUPTE                   ABACUS AND INFINI CONNECTIVITY TAG",
            "APLRST                   APPLICATIONS RESTRICT - EPR RESTRICTED TO APLCTL",
            "ARCRPT                  ALLOW PRINTING OF AGENCY ARC REPORTS",
            "ASK@@@               CONTROL *   ENTRY VIA PAC CODE TABLE ",
            "ATBRPT                   ALLOW DELETE OF TKT AUDIT TRAIL REPORT",
            "AVLSCN                   AA.COM SCAN AVAILABILTY ENTRIES/REQUEST AADVANTAGE CLS",
            "AYMADM                 SPVSR ADMINISTRATOR ROLE FOR ARM-REVENUE ADVANTAGE AGT+",
            "AYMAFM                 ALLOW ACCESS TO WEB GUI TO UPDATE SERVICE FEE RULES",
            "AYMARM                 AGENCY REVENUE MANAGMENT SUPERVISOR",
            "AYMARU                 AGENCY REVENUE MANAGMENT USER",
            "B-MAIL                    ALLOW DISPLAY/USE OF B-MAIL MESSAGE QUEUE",
            "BSRDSP                   PRICING -- BANKERS SELLING RATE DISPLAY",
            "CARCAN                  PROVIDE RATE CANVASSING WITHOUT PROVIDING RATE UPDATE",
            "CATSUP                   SUPPRESS CATEGORIES IN AN ELECTRONIC RULES DISPLAY",
            "CCVIEW                   ALLOW AGENT TO ADD CCVIEW UAT KEYWORD TO AAA&OAM",
            "COMMSG                 ALLOW PAC CODE -MS- ENTRIES FOR AGENCIES/ASSOCIATES",
            "COMSAB                  ALLOW CREATE AND MODIFY COMMERCIAL SABRE PROFILES",
            "CVRSAB                   CONVERSATIONAL SABRE TERMINAL",
            "DOTCOM                 IDENTIFY AIRLINE CONTROLLED PCC",
            "E@@@@@             CONTROL E   ENTRY VIA PAC CODE TABLE",
            "EPRDSP                   ALLOW DISPLAY OF ALL EPRS AND -H*CST- CAPABILITY",
            "ETDNAG                  ELECTRONIC TICKET DELIVERY NETWORK AGENCY AGENT ",
            "ETRMAP                  ALLOW ONLINE CREATION AND ACTIVATION OF ETRMAP FILE",
            "F@@@@@             CONTROL F   ENTRIES VIA PAC CODE TABLE  ",
            "FOXCTL                   ALLOW UPDT/CREATE OF AUTOMATED REFERENCE SYS DATABASE",
            "FS@@@@              CONTROL FS  ENTRY VIA PAC CODE TABLE",
            "GLOBAL                   ALLOW SUBSCRIBERS GLOBAL SPECTRA AND MULTI BR SPECTRA",
            "GLSAGT                   ALLOW GLOBAL SECURITY ENTRIES",
            "GMRUPD                  APPLY RESTRICTIONS TO GMR DISPLAY REQUESTS AND UPDATES",
            "GMSELL                    APPLY RESTRICTIONS TO GMR SELLS",
            "GMTIME                   DISPLAY CURRENT TIME IN GREENWICH MEAN TIME",
            "HDMRCH                 ALLOWED TO PERFORM CK*SMHD ENTRY",
            "HLPDSK                   PROVIDE HELP DESK CAPABILITIES FOR MULTI-HOSTS",
            "HODMIN                  SUPPRESS FREE TXT-HOTEL DIRECT CONNECT AVAIL DISPLAYS",
            "HODRTE                  RESTRICT HOTEL DCS DISPLAYS TO ONLY CRITICAL ELEMENTS",
            "INFEXC                    INFINI AGENT EXCEPTION",
            "INHMSG                   RESTRICT USE OF TELETYPE TRANSFER MESSAGES",
            "INHNMC                   INHIBIT NAME CHANGE ON RETRIEVED PNRS",
            "IPSI01                     IP SIGN IN VERSION ONE",
            "LABELS                    ALLOW PRINTING OF AGENCY MAILING LABELS",
            "LMTACC                  DIRECT ACCESS USERS WITH LIMITED CAPABILITIES",
            "MGUPTE                  CREATE PASSIVE SEG WITH MG/GA TAG",
            "MNTAGT                  ALLOW AGENT TO MONITOR AUTHORIZED SETS",
            "MONEY@                 ALLOW UPDATE OF BANKERS BUYING RATE TABLES",
            "MRCHNT                  RESTRICT MERCHANT FUNCTION TO KEYWORD HOLDERS",
            "N@@@@@             CONTROL N  ENTRY VIA PAC CODE TABLE",
            "MULSET                    ALLOW SIGN-IN FROM ONE EPR INTO MULTIPLE LNIATA/S",
            "NEGAGT                   ALLOW BUILDING OF BRANCH TABLES FOR NEGOTIATED FARES",
            "NETFQD\t                ACCESS TO NET FARES APPLICABLE TO AGENTS LOCATION",
            "NETWEB                  WEB-BASED BROWSER FOR NET FARES MARK UP PROJECT",
            "NO@AAA                 INHIBIT CHANGING AAA TO THE SET/S UAT CITY",
            "NOBCHQ                  INHIBIT ACCESS TO BRANCH OFFICE QUEUES",
            "NOBDPS                   INHIBIT BOARDING PASS PRINTER ASSIGNMENT",
            "NOCTPS                   INHIBIT CORP TVL PLCY SYSTEM/FLEXIBLE PNR EDITS",
            "NODOCS                  INHIBIT ALL BOARDING CONTROL PRINTER ASSIGNMENTS",
            "NOINIS                     INHIBIT INVOICE/ITINERARY PRINTER ASSIGNMENT",
            "NOMSGQ                  INHIBIT BRANCH OFF QUEUES AND MSG QUEUES OF HOME STA",
            "NOPNRS                   INHIBIT PNR UPDATES",
            "NOQUES                   INHIBIT ACCESS TO ALL QUEUES",
            "NOSTAR                   INHIBIT UPDATES TO STARS",
            "NOTKTS                    INHIBIT TICKET PRINTER ASSIGNMENT",
            "NSPLAT                    CONTROL N* ENTRIES VIA PAC TABLE",
            "ONSNAP                   NETEGRITY SECURITY FOR ONSNAP WEB APPLICATION",
            "PTR@@@                CONTROL PTR ENTRIES VIA PAC CODE TABLE",
            "PVTAGT                    ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "PVTDIS                     ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "Q@@@@@             CONTROL Q   ENTRY VIA PAC CODE TABLE",
            "QUESUB                   ALLOWS UPDATES TO PUB-SUB INDICATORS IN QUEUES DATABASE",
            "RECHCK                   PERMIT USE OF NIGHTLY FARE RE-CHECK ",
            "REMOVE                   ALLOW REMOVAL OF INTERFACE MESSAGE FROM THE PQS QUEUE",
            "REQROB                   POSSIBLE ROBOTIC MACHINE ID",
            "RKNAME                   ABACUS SURNAME CHANGE RESTRICTION TABLE",
            "ROBAP1                   GENUINE ROBOTIC MACHINE ID",
            "ROBAP2                   GENUINE ROBOTIC MACHINE ID-2",
            "RTABLE                    AMEX- ALLOW SUBSCRIBERS TO UPD RESTRICTION TABLES",
            "S@@@@@              CONTROL S   ENTRY VIA PAC CODE TABLE",
            "SABEXC                    SABRE AGENT EXCEPTION",
            "SAMRCH                  ALLOWED TO PERFORM CK*SMSA ENTRY",
            "SASELN                    CONTROL SASE LINES FOR COMPLEX PRICING",
            "SI@@@@                CONTROL SI  ENTRY VIA PAC CODE TABLE",
            "SIRMSG                    ALLOW AGENTS TO CREATE SIGN-IN MSGS FOR THEIR OWN CITY",
            "SPRMKT                    \\SUPERMARKET AUTHORIZATION KEYWORD",
            "STCORP                    ALLOW ACCESS TO SATO DATA BASE ",
            "STMOPR                    ALLOW CMS INTERFACE QUEUE ENTRIES",
            "SUBAAA                    ALLOW AAA ENTRY FOR AGENCY - BRA DOCUMENT GENERATION",
            "SUBREJ                     ALLOW SUBSCRIBER AGENT TO SIGN-IN WITH DUTY CODE ZERO",
            "TAVAIL                      ALLOW 20 LINE CITY PAIR AVAILABILITY DISPLAY",
            "TODAGT                    ALLOW AGENT TO ISSUE TICKET ON DEPARTURE PTA",
            "TRPSCH                     PERMIT USE OF FARE TRIP SEARCH",
            "UNISTR                     ALLOW CREATION OF UNIVERSAL STAR RECORDS",
            "W@@@@@             CONTROL W   ENTRY VIA PAC CODE TABLE",
            "WPNALL                    ALLOW WPNI OR WPNC/ALL ENTRIES",
            "WSLASH                   CONTROL W/  ENTRIES VIA PAC CODE TABLE",
            "WWWUSR                SABRE INTERNET PRODUCTS THAT USSE EZGDS TO COMUNICATE",
            "XAGSSX                    AGSS CONTROL KEYWORD",
            "Y@SLH@                  CONTROL Y/  ENTRIES VIA PAC CODE TABLE",
            "1@@@@@              CONTROL 1   ENTRY VIA PAC CODE TABLE",
            "5@@@@@              CONTROL 5   ENTRY VIA PAC CODE TABLE",
            "6@@@@@              CONTROL 6   ENTRY VIA PAC CODE TABLE"});
            this.cmbKeyWord8.Location = new System.Drawing.Point(19, 410);
            this.cmbKeyWord8.Name = "cmbKeyWord8";
            this.cmbKeyWord8.Size = new System.Drawing.Size(369, 21);
            this.cmbKeyWord8.TabIndex = 21;
            this.cmbKeyWord8.ValueMember = "Text";
            this.cmbKeyWord8.SelectedIndexChanged += new System.EventHandler(this.cmbKeyWord8_SelectedIndexChanged);
            this.cmbKeyWord8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbKeyWord12
            // 
            this.cmbKeyWord12.FormattingEnabled = true;
            this.cmbKeyWord12.Items.AddRange(new object[] {
            "",
            "AASATO                  AGENCY ACCESS TO FOCUS MANUALS - F*CDP",
            "ABAEXC                  ABACUS AGENT EXCEPTION",
            "ADSCOM                 CONTROL ADS MACHINE-TO-MACHINE NETWORK COMMUNICATION",
            "AGSTRC                  FORCE ICE DEBUG",
            "ALTDSP                   CONTROL HOTEL SHOPPING LIST DISPLAY",
            "ALUPTE                   ABACUS AND INFINI CONNECTIVITY TAG",
            "APLRST                   APPLICATIONS RESTRICT - EPR RESTRICTED TO APLCTL",
            "ARCRPT                  ALLOW PRINTING OF AGENCY ARC REPORTS",
            "ASK@@@               CONTROL *   ENTRY VIA PAC CODE TABLE ",
            "ATBRPT                   ALLOW DELETE OF TKT AUDIT TRAIL REPORT",
            "AVLSCN                   AA.COM SCAN AVAILABILTY ENTRIES/REQUEST AADVANTAGE CLS",
            "AYMADM                 SPVSR ADMINISTRATOR ROLE FOR ARM-REVENUE ADVANTAGE AGT+",
            "AYMAFM                 ALLOW ACCESS TO WEB GUI TO UPDATE SERVICE FEE RULES",
            "AYMARM                 AGENCY REVENUE MANAGMENT SUPERVISOR",
            "AYMARU                 AGENCY REVENUE MANAGMENT USER",
            "B-MAIL                    ALLOW DISPLAY/USE OF B-MAIL MESSAGE QUEUE",
            "BSRDSP                   PRICING -- BANKERS SELLING RATE DISPLAY",
            "CARCAN                  PROVIDE RATE CANVASSING WITHOUT PROVIDING RATE UPDATE",
            "CATSUP                   SUPPRESS CATEGORIES IN AN ELECTRONIC RULES DISPLAY",
            "CCVIEW                   ALLOW AGENT TO ADD CCVIEW UAT KEYWORD TO AAA&OAM",
            "COMMSG                 ALLOW PAC CODE -MS- ENTRIES FOR AGENCIES/ASSOCIATES",
            "COMSAB                  ALLOW CREATE AND MODIFY COMMERCIAL SABRE PROFILES",
            "CVRSAB                   CONVERSATIONAL SABRE TERMINAL",
            "DOTCOM                 IDENTIFY AIRLINE CONTROLLED PCC",
            "E@@@@@             CONTROL E   ENTRY VIA PAC CODE TABLE",
            "EPRDSP                   ALLOW DISPLAY OF ALL EPRS AND -H*CST- CAPABILITY",
            "ETDNAG                  ELECTRONIC TICKET DELIVERY NETWORK AGENCY AGENT ",
            "ETRMAP                  ALLOW ONLINE CREATION AND ACTIVATION OF ETRMAP FILE",
            "F@@@@@             CONTROL F   ENTRIES VIA PAC CODE TABLE  ",
            "FOXCTL                   ALLOW UPDT/CREATE OF AUTOMATED REFERENCE SYS DATABASE",
            "FS@@@@              CONTROL FS  ENTRY VIA PAC CODE TABLE",
            "GLOBAL                   ALLOW SUBSCRIBERS GLOBAL SPECTRA AND MULTI BR SPECTRA",
            "GLSAGT                   ALLOW GLOBAL SECURITY ENTRIES",
            "GMRUPD                  APPLY RESTRICTIONS TO GMR DISPLAY REQUESTS AND UPDATES",
            "GMSELL                    APPLY RESTRICTIONS TO GMR SELLS",
            "GMTIME                   DISPLAY CURRENT TIME IN GREENWICH MEAN TIME",
            "HDMRCH                 ALLOWED TO PERFORM CK*SMHD ENTRY",
            "HLPDSK                   PROVIDE HELP DESK CAPABILITIES FOR MULTI-HOSTS",
            "HODMIN                  SUPPRESS FREE TXT-HOTEL DIRECT CONNECT AVAIL DISPLAYS",
            "HODRTE                  RESTRICT HOTEL DCS DISPLAYS TO ONLY CRITICAL ELEMENTS",
            "INFEXC                    INFINI AGENT EXCEPTION",
            "INHMSG                   RESTRICT USE OF TELETYPE TRANSFER MESSAGES",
            "INHNMC                   INHIBIT NAME CHANGE ON RETRIEVED PNRS",
            "IPSI01                     IP SIGN IN VERSION ONE",
            "LABELS                    ALLOW PRINTING OF AGENCY MAILING LABELS",
            "LMTACC                  DIRECT ACCESS USERS WITH LIMITED CAPABILITIES",
            "MGUPTE                  CREATE PASSIVE SEG WITH MG/GA TAG",
            "MNTAGT                  ALLOW AGENT TO MONITOR AUTHORIZED SETS",
            "MONEY@                 ALLOW UPDATE OF BANKERS BUYING RATE TABLES",
            "MRCHNT                  RESTRICT MERCHANT FUNCTION TO KEYWORD HOLDERS",
            "N@@@@@             CONTROL N  ENTRY VIA PAC CODE TABLE",
            "MULSET                    ALLOW SIGN-IN FROM ONE EPR INTO MULTIPLE LNIATA/S",
            "NEGAGT                   ALLOW BUILDING OF BRANCH TABLES FOR NEGOTIATED FARES",
            "NETFQD\t                ACCESS TO NET FARES APPLICABLE TO AGENTS LOCATION",
            "NETWEB                  WEB-BASED BROWSER FOR NET FARES MARK UP PROJECT",
            "NO@AAA                 INHIBIT CHANGING AAA TO THE SET/S UAT CITY",
            "NOBCHQ                  INHIBIT ACCESS TO BRANCH OFFICE QUEUES",
            "NOBDPS                   INHIBIT BOARDING PASS PRINTER ASSIGNMENT",
            "NOCTPS                   INHIBIT CORP TVL PLCY SYSTEM/FLEXIBLE PNR EDITS",
            "NODOCS                  INHIBIT ALL BOARDING CONTROL PRINTER ASSIGNMENTS",
            "NOINIS                     INHIBIT INVOICE/ITINERARY PRINTER ASSIGNMENT",
            "NOMSGQ                  INHIBIT BRANCH OFF QUEUES AND MSG QUEUES OF HOME STA",
            "NOPNRS                   INHIBIT PNR UPDATES",
            "NOQUES                   INHIBIT ACCESS TO ALL QUEUES",
            "NOSTAR                   INHIBIT UPDATES TO STARS",
            "NOTKTS                    INHIBIT TICKET PRINTER ASSIGNMENT",
            "NSPLAT                    CONTROL N* ENTRIES VIA PAC TABLE",
            "ONSNAP                   NETEGRITY SECURITY FOR ONSNAP WEB APPLICATION",
            "PTR@@@                CONTROL PTR ENTRIES VIA PAC CODE TABLE",
            "PVTAGT                    ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "PVTDIS                     ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "Q@@@@@             CONTROL Q   ENTRY VIA PAC CODE TABLE",
            "QUESUB                   ALLOWS UPDATES TO PUB-SUB INDICATORS IN QUEUES DATABASE",
            "RECHCK                   PERMIT USE OF NIGHTLY FARE RE-CHECK ",
            "REMOVE                   ALLOW REMOVAL OF INTERFACE MESSAGE FROM THE PQS QUEUE",
            "REQROB                   POSSIBLE ROBOTIC MACHINE ID",
            "RKNAME                   ABACUS SURNAME CHANGE RESTRICTION TABLE",
            "ROBAP1                   GENUINE ROBOTIC MACHINE ID",
            "ROBAP2                   GENUINE ROBOTIC MACHINE ID-2",
            "RTABLE                    AMEX- ALLOW SUBSCRIBERS TO UPD RESTRICTION TABLES",
            "S@@@@@              CONTROL S   ENTRY VIA PAC CODE TABLE",
            "SABEXC                    SABRE AGENT EXCEPTION",
            "SAMRCH                  ALLOWED TO PERFORM CK*SMSA ENTRY",
            "SASELN                    CONTROL SASE LINES FOR COMPLEX PRICING",
            "SI@@@@                CONTROL SI  ENTRY VIA PAC CODE TABLE",
            "SIRMSG                    ALLOW AGENTS TO CREATE SIGN-IN MSGS FOR THEIR OWN CITY",
            "SPRMKT                    \\SUPERMARKET AUTHORIZATION KEYWORD",
            "STCORP                    ALLOW ACCESS TO SATO DATA BASE ",
            "STMOPR                    ALLOW CMS INTERFACE QUEUE ENTRIES",
            "SUBAAA                    ALLOW AAA ENTRY FOR AGENCY - BRA DOCUMENT GENERATION",
            "SUBREJ                     ALLOW SUBSCRIBER AGENT TO SIGN-IN WITH DUTY CODE ZERO",
            "TAVAIL                      ALLOW 20 LINE CITY PAIR AVAILABILITY DISPLAY",
            "TODAGT                    ALLOW AGENT TO ISSUE TICKET ON DEPARTURE PTA",
            "TRPSCH                     PERMIT USE OF FARE TRIP SEARCH",
            "UNISTR                     ALLOW CREATION OF UNIVERSAL STAR RECORDS",
            "W@@@@@             CONTROL W   ENTRY VIA PAC CODE TABLE",
            "WPNALL                    ALLOW WPNI OR WPNC/ALL ENTRIES",
            "WSLASH                   CONTROL W/  ENTRIES VIA PAC CODE TABLE",
            "WWWUSR                SABRE INTERNET PRODUCTS THAT USSE EZGDS TO COMUNICATE",
            "XAGSSX                    AGSS CONTROL KEYWORD",
            "Y@SLH@                  CONTROL Y/  ENTRIES VIA PAC CODE TABLE",
            "1@@@@@              CONTROL 1   ENTRY VIA PAC CODE TABLE",
            "5@@@@@              CONTROL 5   ENTRY VIA PAC CODE TABLE",
            "6@@@@@              CONTROL 6   ENTRY VIA PAC CODE TABLE"});
            this.cmbKeyWord12.Location = new System.Drawing.Point(19, 513);
            this.cmbKeyWord12.Name = "cmbKeyWord12";
            this.cmbKeyWord12.Size = new System.Drawing.Size(369, 21);
            this.cmbKeyWord12.TabIndex = 25;
            this.cmbKeyWord12.SelectedIndexChanged += new System.EventHandler(this.cmbKeyWord12_SelectedIndexChanged);
            this.cmbKeyWord12.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbKeyWord9
            // 
            this.cmbKeyWord9.FormattingEnabled = true;
            this.cmbKeyWord9.Items.AddRange(new object[] {
            "",
            "AASATO                  AGENCY ACCESS TO FOCUS MANUALS - F*CDP",
            "ABAEXC                  ABACUS AGENT EXCEPTION",
            "ADSCOM                 CONTROL ADS MACHINE-TO-MACHINE NETWORK COMMUNICATION",
            "AGSTRC                  FORCE ICE DEBUG",
            "ALTDSP                   CONTROL HOTEL SHOPPING LIST DISPLAY",
            "ALUPTE                   ABACUS AND INFINI CONNECTIVITY TAG",
            "APLRST                   APPLICATIONS RESTRICT - EPR RESTRICTED TO APLCTL",
            "ARCRPT                  ALLOW PRINTING OF AGENCY ARC REPORTS",
            "ASK@@@               CONTROL *   ENTRY VIA PAC CODE TABLE ",
            "ATBRPT                   ALLOW DELETE OF TKT AUDIT TRAIL REPORT",
            "AVLSCN                   AA.COM SCAN AVAILABILTY ENTRIES/REQUEST AADVANTAGE CLS",
            "AYMADM                 SPVSR ADMINISTRATOR ROLE FOR ARM-REVENUE ADVANTAGE AGT+",
            "AYMAFM                 ALLOW ACCESS TO WEB GUI TO UPDATE SERVICE FEE RULES",
            "AYMARM                 AGENCY REVENUE MANAGMENT SUPERVISOR",
            "AYMARU                 AGENCY REVENUE MANAGMENT USER",
            "B-MAIL                    ALLOW DISPLAY/USE OF B-MAIL MESSAGE QUEUE",
            "BSRDSP                   PRICING -- BANKERS SELLING RATE DISPLAY",
            "CARCAN                  PROVIDE RATE CANVASSING WITHOUT PROVIDING RATE UPDATE",
            "CATSUP                   SUPPRESS CATEGORIES IN AN ELECTRONIC RULES DISPLAY",
            "CCVIEW                   ALLOW AGENT TO ADD CCVIEW UAT KEYWORD TO AAA&OAM",
            "COMMSG                 ALLOW PAC CODE -MS- ENTRIES FOR AGENCIES/ASSOCIATES",
            "COMSAB                  ALLOW CREATE AND MODIFY COMMERCIAL SABRE PROFILES",
            "CVRSAB                   CONVERSATIONAL SABRE TERMINAL",
            "DOTCOM                 IDENTIFY AIRLINE CONTROLLED PCC",
            "E@@@@@             CONTROL E   ENTRY VIA PAC CODE TABLE",
            "EPRDSP                   ALLOW DISPLAY OF ALL EPRS AND -H*CST- CAPABILITY",
            "ETDNAG                  ELECTRONIC TICKET DELIVERY NETWORK AGENCY AGENT ",
            "ETRMAP                  ALLOW ONLINE CREATION AND ACTIVATION OF ETRMAP FILE",
            "F@@@@@             CONTROL F   ENTRIES VIA PAC CODE TABLE  ",
            "FOXCTL                   ALLOW UPDT/CREATE OF AUTOMATED REFERENCE SYS DATABASE",
            "FS@@@@              CONTROL FS  ENTRY VIA PAC CODE TABLE",
            "GLOBAL                   ALLOW SUBSCRIBERS GLOBAL SPECTRA AND MULTI BR SPECTRA",
            "GLSAGT                   ALLOW GLOBAL SECURITY ENTRIES",
            "GMRUPD                  APPLY RESTRICTIONS TO GMR DISPLAY REQUESTS AND UPDATES",
            "GMSELL                    APPLY RESTRICTIONS TO GMR SELLS",
            "GMTIME                   DISPLAY CURRENT TIME IN GREENWICH MEAN TIME",
            "HDMRCH                 ALLOWED TO PERFORM CK*SMHD ENTRY",
            "HLPDSK                   PROVIDE HELP DESK CAPABILITIES FOR MULTI-HOSTS",
            "HODMIN                  SUPPRESS FREE TXT-HOTEL DIRECT CONNECT AVAIL DISPLAYS",
            "HODRTE                  RESTRICT HOTEL DCS DISPLAYS TO ONLY CRITICAL ELEMENTS",
            "INFEXC                    INFINI AGENT EXCEPTION",
            "INHMSG                   RESTRICT USE OF TELETYPE TRANSFER MESSAGES",
            "INHNMC                   INHIBIT NAME CHANGE ON RETRIEVED PNRS",
            "IPSI01                     IP SIGN IN VERSION ONE",
            "LABELS                    ALLOW PRINTING OF AGENCY MAILING LABELS",
            "LMTACC                  DIRECT ACCESS USERS WITH LIMITED CAPABILITIES",
            "MGUPTE                  CREATE PASSIVE SEG WITH MG/GA TAG",
            "MNTAGT                  ALLOW AGENT TO MONITOR AUTHORIZED SETS",
            "MONEY@                 ALLOW UPDATE OF BANKERS BUYING RATE TABLES",
            "MRCHNT                  RESTRICT MERCHANT FUNCTION TO KEYWORD HOLDERS",
            "N@@@@@             CONTROL N  ENTRY VIA PAC CODE TABLE",
            "MULSET                    ALLOW SIGN-IN FROM ONE EPR INTO MULTIPLE LNIATA/S",
            "NEGAGT                   ALLOW BUILDING OF BRANCH TABLES FOR NEGOTIATED FARES",
            "NETFQD\t                ACCESS TO NET FARES APPLICABLE TO AGENTS LOCATION",
            "NETWEB                  WEB-BASED BROWSER FOR NET FARES MARK UP PROJECT",
            "NO@AAA                 INHIBIT CHANGING AAA TO THE SET/S UAT CITY",
            "NOBCHQ                  INHIBIT ACCESS TO BRANCH OFFICE QUEUES",
            "NOBDPS                   INHIBIT BOARDING PASS PRINTER ASSIGNMENT",
            "NOCTPS                   INHIBIT CORP TVL PLCY SYSTEM/FLEXIBLE PNR EDITS",
            "NODOCS                  INHIBIT ALL BOARDING CONTROL PRINTER ASSIGNMENTS",
            "NOINIS                     INHIBIT INVOICE/ITINERARY PRINTER ASSIGNMENT",
            "NOMSGQ                  INHIBIT BRANCH OFF QUEUES AND MSG QUEUES OF HOME STA",
            "NOPNRS                   INHIBIT PNR UPDATES",
            "NOQUES                   INHIBIT ACCESS TO ALL QUEUES",
            "NOSTAR                   INHIBIT UPDATES TO STARS",
            "NOTKTS                    INHIBIT TICKET PRINTER ASSIGNMENT",
            "NSPLAT                    CONTROL N* ENTRIES VIA PAC TABLE",
            "ONSNAP                   NETEGRITY SECURITY FOR ONSNAP WEB APPLICATION",
            "PTR@@@                CONTROL PTR ENTRIES VIA PAC CODE TABLE",
            "PVTAGT                    ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "PVTDIS                     ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "Q@@@@@             CONTROL Q   ENTRY VIA PAC CODE TABLE",
            "QUESUB                   ALLOWS UPDATES TO PUB-SUB INDICATORS IN QUEUES DATABASE",
            "RECHCK                   PERMIT USE OF NIGHTLY FARE RE-CHECK ",
            "REMOVE                   ALLOW REMOVAL OF INTERFACE MESSAGE FROM THE PQS QUEUE",
            "REQROB                   POSSIBLE ROBOTIC MACHINE ID",
            "RKNAME                   ABACUS SURNAME CHANGE RESTRICTION TABLE",
            "ROBAP1                   GENUINE ROBOTIC MACHINE ID",
            "ROBAP2                   GENUINE ROBOTIC MACHINE ID-2",
            "RTABLE                    AMEX- ALLOW SUBSCRIBERS TO UPD RESTRICTION TABLES",
            "S@@@@@              CONTROL S   ENTRY VIA PAC CODE TABLE",
            "SABEXC                    SABRE AGENT EXCEPTION",
            "SAMRCH                  ALLOWED TO PERFORM CK*SMSA ENTRY",
            "SASELN                    CONTROL SASE LINES FOR COMPLEX PRICING",
            "SI@@@@                CONTROL SI  ENTRY VIA PAC CODE TABLE",
            "SIRMSG                    ALLOW AGENTS TO CREATE SIGN-IN MSGS FOR THEIR OWN CITY",
            "SPRMKT                    \\SUPERMARKET AUTHORIZATION KEYWORD",
            "STCORP                    ALLOW ACCESS TO SATO DATA BASE ",
            "STMOPR                    ALLOW CMS INTERFACE QUEUE ENTRIES",
            "SUBAAA                    ALLOW AAA ENTRY FOR AGENCY - BRA DOCUMENT GENERATION",
            "SUBREJ                     ALLOW SUBSCRIBER AGENT TO SIGN-IN WITH DUTY CODE ZERO",
            "TAVAIL                      ALLOW 20 LINE CITY PAIR AVAILABILITY DISPLAY",
            "TODAGT                    ALLOW AGENT TO ISSUE TICKET ON DEPARTURE PTA",
            "TRPSCH                     PERMIT USE OF FARE TRIP SEARCH",
            "UNISTR                     ALLOW CREATION OF UNIVERSAL STAR RECORDS",
            "W@@@@@             CONTROL W   ENTRY VIA PAC CODE TABLE",
            "WPNALL                    ALLOW WPNI OR WPNC/ALL ENTRIES",
            "WSLASH                   CONTROL W/  ENTRIES VIA PAC CODE TABLE",
            "WWWUSR                SABRE INTERNET PRODUCTS THAT USSE EZGDS TO COMUNICATE",
            "XAGSSX                    AGSS CONTROL KEYWORD",
            "Y@SLH@                  CONTROL Y/  ENTRIES VIA PAC CODE TABLE",
            "1@@@@@              CONTROL 1   ENTRY VIA PAC CODE TABLE",
            "5@@@@@              CONTROL 5   ENTRY VIA PAC CODE TABLE",
            "6@@@@@              CONTROL 6   ENTRY VIA PAC CODE TABLE"});
            this.cmbKeyWord9.Location = new System.Drawing.Point(19, 435);
            this.cmbKeyWord9.Name = "cmbKeyWord9";
            this.cmbKeyWord9.Size = new System.Drawing.Size(369, 21);
            this.cmbKeyWord9.TabIndex = 22;
            this.cmbKeyWord9.SelectedIndexChanged += new System.EventHandler(this.cmbKeyWord9_SelectedIndexChanged);
            this.cmbKeyWord9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbKeyWord11
            // 
            this.cmbKeyWord11.FormattingEnabled = true;
            this.cmbKeyWord11.Items.AddRange(new object[] {
            "",
            "AASATO                  AGENCY ACCESS TO FOCUS MANUALS - F*CDP",
            "ABAEXC                  ABACUS AGENT EXCEPTION",
            "ADSCOM                 CONTROL ADS MACHINE-TO-MACHINE NETWORK COMMUNICATION",
            "AGSTRC                  FORCE ICE DEBUG",
            "ALTDSP                   CONTROL HOTEL SHOPPING LIST DISPLAY",
            "ALUPTE                   ABACUS AND INFINI CONNECTIVITY TAG",
            "APLRST                   APPLICATIONS RESTRICT - EPR RESTRICTED TO APLCTL",
            "ARCRPT                  ALLOW PRINTING OF AGENCY ARC REPORTS",
            "ASK@@@               CONTROL *   ENTRY VIA PAC CODE TABLE ",
            "ATBRPT                   ALLOW DELETE OF TKT AUDIT TRAIL REPORT",
            "AVLSCN                   AA.COM SCAN AVAILABILTY ENTRIES/REQUEST AADVANTAGE CLS",
            "AYMADM                 SPVSR ADMINISTRATOR ROLE FOR ARM-REVENUE ADVANTAGE AGT+",
            "AYMAFM                 ALLOW ACCESS TO WEB GUI TO UPDATE SERVICE FEE RULES",
            "AYMARM                 AGENCY REVENUE MANAGMENT SUPERVISOR",
            "AYMARU                 AGENCY REVENUE MANAGMENT USER",
            "B-MAIL                    ALLOW DISPLAY/USE OF B-MAIL MESSAGE QUEUE",
            "BSRDSP                   PRICING -- BANKERS SELLING RATE DISPLAY",
            "CARCAN                  PROVIDE RATE CANVASSING WITHOUT PROVIDING RATE UPDATE",
            "CATSUP                   SUPPRESS CATEGORIES IN AN ELECTRONIC RULES DISPLAY",
            "CCVIEW                   ALLOW AGENT TO ADD CCVIEW UAT KEYWORD TO AAA&OAM",
            "COMMSG                 ALLOW PAC CODE -MS- ENTRIES FOR AGENCIES/ASSOCIATES",
            "COMSAB                  ALLOW CREATE AND MODIFY COMMERCIAL SABRE PROFILES",
            "CVRSAB                   CONVERSATIONAL SABRE TERMINAL",
            "DOTCOM                 IDENTIFY AIRLINE CONTROLLED PCC",
            "E@@@@@             CONTROL E   ENTRY VIA PAC CODE TABLE",
            "EPRDSP                   ALLOW DISPLAY OF ALL EPRS AND -H*CST- CAPABILITY",
            "ETDNAG                  ELECTRONIC TICKET DELIVERY NETWORK AGENCY AGENT ",
            "ETRMAP                  ALLOW ONLINE CREATION AND ACTIVATION OF ETRMAP FILE",
            "F@@@@@             CONTROL F   ENTRIES VIA PAC CODE TABLE  ",
            "FOXCTL                   ALLOW UPDT/CREATE OF AUTOMATED REFERENCE SYS DATABASE",
            "FS@@@@              CONTROL FS  ENTRY VIA PAC CODE TABLE",
            "GLOBAL                   ALLOW SUBSCRIBERS GLOBAL SPECTRA AND MULTI BR SPECTRA",
            "GLSAGT                   ALLOW GLOBAL SECURITY ENTRIES",
            "GMRUPD                  APPLY RESTRICTIONS TO GMR DISPLAY REQUESTS AND UPDATES",
            "GMSELL                    APPLY RESTRICTIONS TO GMR SELLS",
            "GMTIME                   DISPLAY CURRENT TIME IN GREENWICH MEAN TIME",
            "HDMRCH                 ALLOWED TO PERFORM CK*SMHD ENTRY",
            "HLPDSK                   PROVIDE HELP DESK CAPABILITIES FOR MULTI-HOSTS",
            "HODMIN                  SUPPRESS FREE TXT-HOTEL DIRECT CONNECT AVAIL DISPLAYS",
            "HODRTE                  RESTRICT HOTEL DCS DISPLAYS TO ONLY CRITICAL ELEMENTS",
            "INFEXC                    INFINI AGENT EXCEPTION",
            "INHMSG                   RESTRICT USE OF TELETYPE TRANSFER MESSAGES",
            "INHNMC                   INHIBIT NAME CHANGE ON RETRIEVED PNRS",
            "IPSI01                     IP SIGN IN VERSION ONE",
            "LABELS                    ALLOW PRINTING OF AGENCY MAILING LABELS",
            "LMTACC                  DIRECT ACCESS USERS WITH LIMITED CAPABILITIES",
            "MGUPTE                  CREATE PASSIVE SEG WITH MG/GA TAG",
            "MNTAGT                  ALLOW AGENT TO MONITOR AUTHORIZED SETS",
            "MONEY@                 ALLOW UPDATE OF BANKERS BUYING RATE TABLES",
            "MRCHNT                  RESTRICT MERCHANT FUNCTION TO KEYWORD HOLDERS",
            "N@@@@@             CONTROL N  ENTRY VIA PAC CODE TABLE",
            "MULSET                    ALLOW SIGN-IN FROM ONE EPR INTO MULTIPLE LNIATA/S",
            "NEGAGT                   ALLOW BUILDING OF BRANCH TABLES FOR NEGOTIATED FARES",
            "NETFQD\t                ACCESS TO NET FARES APPLICABLE TO AGENTS LOCATION",
            "NETWEB                  WEB-BASED BROWSER FOR NET FARES MARK UP PROJECT",
            "NO@AAA                 INHIBIT CHANGING AAA TO THE SET/S UAT CITY",
            "NOBCHQ                  INHIBIT ACCESS TO BRANCH OFFICE QUEUES",
            "NOBDPS                   INHIBIT BOARDING PASS PRINTER ASSIGNMENT",
            "NOCTPS                   INHIBIT CORP TVL PLCY SYSTEM/FLEXIBLE PNR EDITS",
            "NODOCS                  INHIBIT ALL BOARDING CONTROL PRINTER ASSIGNMENTS",
            "NOINIS                     INHIBIT INVOICE/ITINERARY PRINTER ASSIGNMENT",
            "NOMSGQ                  INHIBIT BRANCH OFF QUEUES AND MSG QUEUES OF HOME STA",
            "NOPNRS                   INHIBIT PNR UPDATES",
            "NOQUES                   INHIBIT ACCESS TO ALL QUEUES",
            "NOSTAR                   INHIBIT UPDATES TO STARS",
            "NOTKTS                    INHIBIT TICKET PRINTER ASSIGNMENT",
            "NSPLAT                    CONTROL N* ENTRIES VIA PAC TABLE",
            "ONSNAP                   NETEGRITY SECURITY FOR ONSNAP WEB APPLICATION",
            "PTR@@@                CONTROL PTR ENTRIES VIA PAC CODE TABLE",
            "PVTAGT                    ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "PVTDIS                     ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "Q@@@@@             CONTROL Q   ENTRY VIA PAC CODE TABLE",
            "QUESUB                   ALLOWS UPDATES TO PUB-SUB INDICATORS IN QUEUES DATABASE",
            "RECHCK                   PERMIT USE OF NIGHTLY FARE RE-CHECK ",
            "REMOVE                   ALLOW REMOVAL OF INTERFACE MESSAGE FROM THE PQS QUEUE",
            "REQROB                   POSSIBLE ROBOTIC MACHINE ID",
            "RKNAME                   ABACUS SURNAME CHANGE RESTRICTION TABLE",
            "ROBAP1                   GENUINE ROBOTIC MACHINE ID",
            "ROBAP2                   GENUINE ROBOTIC MACHINE ID-2",
            "RTABLE                    AMEX- ALLOW SUBSCRIBERS TO UPD RESTRICTION TABLES",
            "S@@@@@              CONTROL S   ENTRY VIA PAC CODE TABLE",
            "SABEXC                    SABRE AGENT EXCEPTION",
            "SAMRCH                  ALLOWED TO PERFORM CK*SMSA ENTRY",
            "SASELN                    CONTROL SASE LINES FOR COMPLEX PRICING",
            "SI@@@@                CONTROL SI  ENTRY VIA PAC CODE TABLE",
            "SIRMSG                    ALLOW AGENTS TO CREATE SIGN-IN MSGS FOR THEIR OWN CITY",
            "SPRMKT                    \\SUPERMARKET AUTHORIZATION KEYWORD",
            "STCORP                    ALLOW ACCESS TO SATO DATA BASE ",
            "STMOPR                    ALLOW CMS INTERFACE QUEUE ENTRIES",
            "SUBAAA                    ALLOW AAA ENTRY FOR AGENCY - BRA DOCUMENT GENERATION",
            "SUBREJ                     ALLOW SUBSCRIBER AGENT TO SIGN-IN WITH DUTY CODE ZERO",
            "TAVAIL                      ALLOW 20 LINE CITY PAIR AVAILABILITY DISPLAY",
            "TODAGT                    ALLOW AGENT TO ISSUE TICKET ON DEPARTURE PTA",
            "TRPSCH                     PERMIT USE OF FARE TRIP SEARCH",
            "UNISTR                     ALLOW CREATION OF UNIVERSAL STAR RECORDS",
            "W@@@@@             CONTROL W   ENTRY VIA PAC CODE TABLE",
            "WPNALL                    ALLOW WPNI OR WPNC/ALL ENTRIES",
            "WSLASH                   CONTROL W/  ENTRIES VIA PAC CODE TABLE",
            "WWWUSR                SABRE INTERNET PRODUCTS THAT USSE EZGDS TO COMUNICATE",
            "XAGSSX                    AGSS CONTROL KEYWORD",
            "Y@SLH@                  CONTROL Y/  ENTRIES VIA PAC CODE TABLE",
            "1@@@@@              CONTROL 1   ENTRY VIA PAC CODE TABLE",
            "5@@@@@              CONTROL 5   ENTRY VIA PAC CODE TABLE",
            "6@@@@@              CONTROL 6   ENTRY VIA PAC CODE TABLE"});
            this.cmbKeyWord11.Location = new System.Drawing.Point(19, 487);
            this.cmbKeyWord11.Name = "cmbKeyWord11";
            this.cmbKeyWord11.Size = new System.Drawing.Size(369, 21);
            this.cmbKeyWord11.TabIndex = 24;
            this.cmbKeyWord11.SelectedIndexChanged += new System.EventHandler(this.cmbKeyWord11_SelectedIndexChanged);
            this.cmbKeyWord11.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbKeyWord10
            // 
            this.cmbKeyWord10.FormattingEnabled = true;
            this.cmbKeyWord10.Items.AddRange(new object[] {
            "",
            "AASATO                  AGENCY ACCESS TO FOCUS MANUALS - F*CDP",
            "ABAEXC                  ABACUS AGENT EXCEPTION",
            "ADSCOM                 CONTROL ADS MACHINE-TO-MACHINE NETWORK COMMUNICATION",
            "AGSTRC                  FORCE ICE DEBUG",
            "ALTDSP                   CONTROL HOTEL SHOPPING LIST DISPLAY",
            "ALUPTE                   ABACUS AND INFINI CONNECTIVITY TAG",
            "APLRST                   APPLICATIONS RESTRICT - EPR RESTRICTED TO APLCTL",
            "ARCRPT                  ALLOW PRINTING OF AGENCY ARC REPORTS",
            "ASK@@@               CONTROL *   ENTRY VIA PAC CODE TABLE ",
            "ATBRPT                   ALLOW DELETE OF TKT AUDIT TRAIL REPORT",
            "AVLSCN                   AA.COM SCAN AVAILABILTY ENTRIES/REQUEST AADVANTAGE CLS",
            "AYMADM                 SPVSR ADMINISTRATOR ROLE FOR ARM-REVENUE ADVANTAGE AGT+",
            "AYMAFM                 ALLOW ACCESS TO WEB GUI TO UPDATE SERVICE FEE RULES",
            "AYMARM                 AGENCY REVENUE MANAGMENT SUPERVISOR",
            "AYMARU                 AGENCY REVENUE MANAGMENT USER",
            "B-MAIL                    ALLOW DISPLAY/USE OF B-MAIL MESSAGE QUEUE",
            "BSRDSP                   PRICING -- BANKERS SELLING RATE DISPLAY",
            "CARCAN                  PROVIDE RATE CANVASSING WITHOUT PROVIDING RATE UPDATE",
            "CATSUP                   SUPPRESS CATEGORIES IN AN ELECTRONIC RULES DISPLAY",
            "CCVIEW                   ALLOW AGENT TO ADD CCVIEW UAT KEYWORD TO AAA&OAM",
            "COMMSG                 ALLOW PAC CODE -MS- ENTRIES FOR AGENCIES/ASSOCIATES",
            "COMSAB                  ALLOW CREATE AND MODIFY COMMERCIAL SABRE PROFILES",
            "CVRSAB                   CONVERSATIONAL SABRE TERMINAL",
            "DOTCOM                 IDENTIFY AIRLINE CONTROLLED PCC",
            "E@@@@@             CONTROL E   ENTRY VIA PAC CODE TABLE",
            "EPRDSP                   ALLOW DISPLAY OF ALL EPRS AND -H*CST- CAPABILITY",
            "ETDNAG                  ELECTRONIC TICKET DELIVERY NETWORK AGENCY AGENT ",
            "ETRMAP                  ALLOW ONLINE CREATION AND ACTIVATION OF ETRMAP FILE",
            "F@@@@@             CONTROL F   ENTRIES VIA PAC CODE TABLE  ",
            "FOXCTL                   ALLOW UPDT/CREATE OF AUTOMATED REFERENCE SYS DATABASE",
            "FS@@@@              CONTROL FS  ENTRY VIA PAC CODE TABLE",
            "GLOBAL                   ALLOW SUBSCRIBERS GLOBAL SPECTRA AND MULTI BR SPECTRA",
            "GLSAGT                   ALLOW GLOBAL SECURITY ENTRIES",
            "GMRUPD                  APPLY RESTRICTIONS TO GMR DISPLAY REQUESTS AND UPDATES",
            "GMSELL                    APPLY RESTRICTIONS TO GMR SELLS",
            "GMTIME                   DISPLAY CURRENT TIME IN GREENWICH MEAN TIME",
            "HDMRCH                 ALLOWED TO PERFORM CK*SMHD ENTRY",
            "HLPDSK                   PROVIDE HELP DESK CAPABILITIES FOR MULTI-HOSTS",
            "HODMIN                  SUPPRESS FREE TXT-HOTEL DIRECT CONNECT AVAIL DISPLAYS",
            "HODRTE                  RESTRICT HOTEL DCS DISPLAYS TO ONLY CRITICAL ELEMENTS",
            "INFEXC                    INFINI AGENT EXCEPTION",
            "INHMSG                   RESTRICT USE OF TELETYPE TRANSFER MESSAGES",
            "INHNMC                   INHIBIT NAME CHANGE ON RETRIEVED PNRS",
            "IPSI01                     IP SIGN IN VERSION ONE",
            "LABELS                    ALLOW PRINTING OF AGENCY MAILING LABELS",
            "LMTACC                  DIRECT ACCESS USERS WITH LIMITED CAPABILITIES",
            "MGUPTE                  CREATE PASSIVE SEG WITH MG/GA TAG",
            "MNTAGT                  ALLOW AGENT TO MONITOR AUTHORIZED SETS",
            "MONEY@                 ALLOW UPDATE OF BANKERS BUYING RATE TABLES",
            "MRCHNT                  RESTRICT MERCHANT FUNCTION TO KEYWORD HOLDERS",
            "N@@@@@             CONTROL N  ENTRY VIA PAC CODE TABLE",
            "MULSET                    ALLOW SIGN-IN FROM ONE EPR INTO MULTIPLE LNIATA/S",
            "NEGAGT                   ALLOW BUILDING OF BRANCH TABLES FOR NEGOTIATED FARES",
            "NETFQD\t                ACCESS TO NET FARES APPLICABLE TO AGENTS LOCATION",
            "NETWEB                  WEB-BASED BROWSER FOR NET FARES MARK UP PROJECT",
            "NO@AAA                 INHIBIT CHANGING AAA TO THE SET/S UAT CITY",
            "NOBCHQ                  INHIBIT ACCESS TO BRANCH OFFICE QUEUES",
            "NOBDPS                   INHIBIT BOARDING PASS PRINTER ASSIGNMENT",
            "NOCTPS                   INHIBIT CORP TVL PLCY SYSTEM/FLEXIBLE PNR EDITS",
            "NODOCS                  INHIBIT ALL BOARDING CONTROL PRINTER ASSIGNMENTS",
            "NOINIS                     INHIBIT INVOICE/ITINERARY PRINTER ASSIGNMENT",
            "NOMSGQ                  INHIBIT BRANCH OFF QUEUES AND MSG QUEUES OF HOME STA",
            "NOPNRS                   INHIBIT PNR UPDATES",
            "NOQUES                   INHIBIT ACCESS TO ALL QUEUES",
            "NOSTAR                   INHIBIT UPDATES TO STARS",
            "NOTKTS                    INHIBIT TICKET PRINTER ASSIGNMENT",
            "NSPLAT                    CONTROL N* ENTRIES VIA PAC TABLE",
            "ONSNAP                   NETEGRITY SECURITY FOR ONSNAP WEB APPLICATION",
            "PTR@@@                CONTROL PTR ENTRIES VIA PAC CODE TABLE",
            "PVTAGT                    ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "PVTDIS                     ALLOW USE AND DISPLAY OF PRIVATE FARES",
            "Q@@@@@             CONTROL Q   ENTRY VIA PAC CODE TABLE",
            "QUESUB                   ALLOWS UPDATES TO PUB-SUB INDICATORS IN QUEUES DATABASE",
            "RECHCK                   PERMIT USE OF NIGHTLY FARE RE-CHECK ",
            "REMOVE                   ALLOW REMOVAL OF INTERFACE MESSAGE FROM THE PQS QUEUE",
            "REQROB                   POSSIBLE ROBOTIC MACHINE ID",
            "RKNAME                   ABACUS SURNAME CHANGE RESTRICTION TABLE",
            "ROBAP1                   GENUINE ROBOTIC MACHINE ID",
            "ROBAP2                   GENUINE ROBOTIC MACHINE ID-2",
            "RTABLE                    AMEX- ALLOW SUBSCRIBERS TO UPD RESTRICTION TABLES",
            "S@@@@@              CONTROL S   ENTRY VIA PAC CODE TABLE",
            "SABEXC                    SABRE AGENT EXCEPTION",
            "SAMRCH                  ALLOWED TO PERFORM CK*SMSA ENTRY",
            "SASELN                    CONTROL SASE LINES FOR COMPLEX PRICING",
            "SI@@@@                CONTROL SI  ENTRY VIA PAC CODE TABLE",
            "SIRMSG                    ALLOW AGENTS TO CREATE SIGN-IN MSGS FOR THEIR OWN CITY",
            "SPRMKT                    \\SUPERMARKET AUTHORIZATION KEYWORD",
            "STCORP                    ALLOW ACCESS TO SATO DATA BASE ",
            "STMOPR                    ALLOW CMS INTERFACE QUEUE ENTRIES",
            "SUBAAA                    ALLOW AAA ENTRY FOR AGENCY - BRA DOCUMENT GENERATION",
            "SUBREJ                     ALLOW SUBSCRIBER AGENT TO SIGN-IN WITH DUTY CODE ZERO",
            "TAVAIL                      ALLOW 20 LINE CITY PAIR AVAILABILITY DISPLAY",
            "TODAGT                    ALLOW AGENT TO ISSUE TICKET ON DEPARTURE PTA",
            "TRPSCH                     PERMIT USE OF FARE TRIP SEARCH",
            "UNISTR                     ALLOW CREATION OF UNIVERSAL STAR RECORDS",
            "W@@@@@             CONTROL W   ENTRY VIA PAC CODE TABLE",
            "WPNALL                    ALLOW WPNI OR WPNC/ALL ENTRIES",
            "WSLASH                   CONTROL W/  ENTRIES VIA PAC CODE TABLE",
            "WWWUSR                SABRE INTERNET PRODUCTS THAT USSE EZGDS TO COMUNICATE",
            "XAGSSX                    AGSS CONTROL KEYWORD",
            "Y@SLH@                  CONTROL Y/  ENTRIES VIA PAC CODE TABLE",
            "1@@@@@              CONTROL 1   ENTRY VIA PAC CODE TABLE",
            "5@@@@@              CONTROL 5   ENTRY VIA PAC CODE TABLE",
            "6@@@@@              CONTROL 6   ENTRY VIA PAC CODE TABLE"});
            this.cmbKeyWord10.Location = new System.Drawing.Point(19, 462);
            this.cmbKeyWord10.Name = "cmbKeyWord10";
            this.cmbKeyWord10.Size = new System.Drawing.Size(369, 21);
            this.cmbKeyWord10.TabIndex = 23;
            this.cmbKeyWord10.SelectedIndexChanged += new System.EventHandler(this.cmbKeyWord10_SelectedIndexChanged);
            this.cmbKeyWord10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblAuthorization
            // 
            this.lblAuthorization.AutoSize = true;
            this.lblAuthorization.Location = new System.Drawing.Point(155, 221);
            this.lblAuthorization.Name = "lblAuthorization";
            this.lblAuthorization.Size = new System.Drawing.Size(75, 13);
            this.lblAuthorization.TabIndex = 0;
            this.lblAuthorization.Text = "Autorizado por";
            // 
            // txtAuthorization
            // 
            this.txtAuthorization.AllowBlankSpaces = true;
            this.txtAuthorization.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAuthorization.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtAuthorization.CustomExpression = ".*";
            this.txtAuthorization.EnterColor = System.Drawing.Color.Empty;
            this.txtAuthorization.LeaveColor = System.Drawing.Color.Empty;
            this.txtAuthorization.Location = new System.Drawing.Point(236, 218);
            this.txtAuthorization.MaxLength = 20;
            this.txtAuthorization.Name = "txtAuthorization";
            this.txtAuthorization.Size = new System.Drawing.Size(152, 20);
            this.txtAuthorization.TabIndex = 13;
            this.txtAuthorization.TextChanged += new System.EventHandler(this.txtAuthorization_TextChanged);
            this.txtAuthorization.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lbPCC
            // 
            this.lbPCC.DisplayMember = "Text";
            this.lbPCC.FormattingEnabled = true;
            this.lbPCC.Location = new System.Drawing.Point(85, 65);
            this.lbPCC.Name = "lbPCC";
            this.lbPCC.Size = new System.Drawing.Size(301, 95);
            this.lbPCC.TabIndex = 26;
            this.lbPCC.ValueMember = "Value";
            this.lbPCC.Visible = false;
            this.lbPCC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbPCC_KeyDown);
            // 
            // rbnSabre
            // 
            this.rbnSabre.AutoSize = true;
            this.rbnSabre.Location = new System.Drawing.Point(18, 548);
            this.rbnSabre.Name = "rbnSabre";
            this.rbnSabre.Size = new System.Drawing.Size(69, 17);
            this.rbnSabre.TabIndex = 27;
            this.rbnSabre.TabStop = true;
            this.rbnSabre.Text = "En Sabre";
            this.rbnSabre.UseVisualStyleBackColor = true;
            // 
            // rbnMyCTS
            // 
            this.rbnMyCTS.AutoSize = true;
            this.rbnMyCTS.Location = new System.Drawing.Point(98, 548);
            this.rbnMyCTS.Name = "rbnMyCTS";
            this.rbnMyCTS.Size = new System.Drawing.Size(76, 17);
            this.rbnMyCTS.TabIndex = 28;
            this.rbnMyCTS.TabStop = true;
            this.rbnMyCTS.Text = "En MyCTS";
            this.rbnMyCTS.UseVisualStyleBackColor = true;
            // 
            // rbnBoth
            // 
            this.rbnBoth.AutoSize = true;
            this.rbnBoth.Location = new System.Drawing.Point(192, 548);
            this.rbnBoth.Name = "rbnBoth";
            this.rbnBoth.Size = new System.Drawing.Size(73, 17);
            this.rbnBoth.TabIndex = 29;
            this.rbnBoth.TabStop = true;
            this.rbnBoth.Text = "En Ambos";
            this.rbnBoth.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "AgentMail";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textAgentMail
            // 
            this.textAgentMail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textAgentMail.Location = new System.Drawing.Point(109, 194);
            this.textAgentMail.Name = "textAgentMail";
            this.textAgentMail.Size = new System.Drawing.Size(277, 20);
            this.textAgentMail.TabIndex = 11;
            this.textAgentMail.TextChanged += new System.EventHandler(this.textAgentMail_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 354);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Activa/Desactiva FlexEdita opc. de PNR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Activa/Desactiva FlexEdita opc. de PNR";
            // 
            // ucCreateFirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.textAgentMail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbnBoth);
            this.Controls.Add(this.rbnMyCTS);
            this.Controls.Add(this.rbnSabre);
            this.Controls.Add(this.txtAuthorization);
            this.Controls.Add(this.lblAuthorization);
            this.Controls.Add(this.cmbKeyWord10);
            this.Controls.Add(this.cmbKeyWord11);
            this.Controls.Add(this.cmbKeyWord9);
            this.Controls.Add(this.cmbKeyWord12);
            this.Controls.Add(this.cmbKeyWord8);
            this.Controls.Add(this.lblSUBACC);
            this.Controls.Add(this.lblPNRREL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSUBMGR);
            this.Controls.Add(this.lblCIIMGR);
            this.Controls.Add(this.lblAccess);
            this.Controls.Add(this.lblCreate);
            this.Controls.Add(this.lblMIOPR);
            this.Controls.Add(this.chkSUBACC);
            this.Controls.Add(this.chkPNRREL);
            this.Controls.Add(this.chkSUBMGR);
            this.Controls.Add(this.chkCIIMGR);
            this.Controls.Add(this.chkAccess);
            this.Controls.Add(this.chkCreate);
            this.Controls.Add(this.chkMINIOPR);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chkDutyCode);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtInitial);
            this.Controls.Add(this.txtTA);
            this.Controls.Add(this.txtPassCode);
            this.Controls.Add(this.txtCodeAgent);
            this.Controls.Add(this.lblIntial);
            this.Controls.Add(this.lblTA);
            this.Controls.Add(this.lblPassCode);
            this.Controls.Add(this.lblCodeAgent);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtQueue);
            this.Controls.Add(this.txtPCC);
            this.Controls.Add(this.txtNumberFirm);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblQueue);
            this.Controls.Add(this.lblPCC);
            this.Controls.Add(this.lblNumberFirm);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lbPCC);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucCreateFirm";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucCreateFirm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblNumberFirm;
        private System.Windows.Forms.Label lblPCC;
        private System.Windows.Forms.Label lblQueue;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private MyCTS.Forms.UI.SmartTextBox txtNumberFirm;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private MyCTS.Forms.UI.SmartTextBox txtQueue;
        private MyCTS.Forms.UI.SmartTextBox txtLastName;
        private System.Windows.Forms.Label lblCodeAgent;
        private System.Windows.Forms.Label lblPassCode;
        private System.Windows.Forms.Label lblTA;
        private System.Windows.Forms.Label lblIntial;
        private MyCTS.Forms.UI.SmartTextBox txtCodeAgent;
        private MyCTS.Forms.UI.SmartTextBox txtPassCode;
        private MyCTS.Forms.UI.SmartTextBox txtTA;
        private MyCTS.Forms.UI.SmartTextBox txtInitial;
        private MyCTS.Forms.UI.SmartTextBox txtName;
        private MyCTS.Forms.UI.SmartTextBox txtEmail;
        private System.Windows.Forms.CheckBox chkDutyCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkMINIOPR;
        private System.Windows.Forms.CheckBox chkCreate;
        private System.Windows.Forms.CheckBox chkAccess;
        private System.Windows.Forms.CheckBox chkCIIMGR;
        private System.Windows.Forms.CheckBox chkSUBMGR;
        private System.Windows.Forms.CheckBox chkPNRREL;
        private System.Windows.Forms.CheckBox chkSUBACC;
        private System.Windows.Forms.Label lblMIOPR;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.Label lblAccess;
        private System.Windows.Forms.Label lblCIIMGR;
        private System.Windows.Forms.Label lblSUBMGR;
        private System.Windows.Forms.Label lblPNRREL;
        private System.Windows.Forms.Label lblSUBACC;
        private System.Windows.Forms.ComboBox cmbKeyWord8;
        private System.Windows.Forms.ComboBox cmbKeyWord12;
        private System.Windows.Forms.ComboBox cmbKeyWord9;
        private System.Windows.Forms.ComboBox cmbKeyWord11;
        private System.Windows.Forms.ComboBox cmbKeyWord10;
        private System.Windows.Forms.Label lblAuthorization;
        private MyCTS.Forms.UI.SmartTextBox txtAuthorization;
        private System.Windows.Forms.ListBox lbPCC;
        private System.Windows.Forms.RadioButton rbnSabre;
        private System.Windows.Forms.RadioButton rbnMyCTS;
        private System.Windows.Forms.RadioButton rbnBoth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textAgentMail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
