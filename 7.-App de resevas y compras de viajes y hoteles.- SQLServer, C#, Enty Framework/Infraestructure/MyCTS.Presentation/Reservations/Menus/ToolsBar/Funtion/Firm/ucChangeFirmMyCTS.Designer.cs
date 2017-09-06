namespace MyCTS.Presentation
{
    partial class ucChangeFirmMyCTS
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
            this.txtEmail = new MyCTS.Forms.UI.SmartTextBox();
            this.txtName = new MyCTS.Forms.UI.SmartTextBox();
            this.txtTA = new MyCTS.Forms.UI.SmartTextBox();
            this.txtCodeAgent = new MyCTS.Forms.UI.SmartTextBox();
            this.lblTA = new System.Windows.Forms.Label();
            this.lblCodeAgent = new System.Windows.Forms.Label();
            this.txtLastName = new MyCTS.Forms.UI.SmartTextBox();
            this.txtQueue = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.txtNumberFirm = new MyCTS.Forms.UI.SmartTextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblQueue = new System.Windows.Forms.Label();
            this.lblPCC = new System.Windows.Forms.Label();
            this.lblNumberFirm = new System.Windows.Forms.Label();
            this.lbPCC = new System.Windows.Forms.ListBox();
            this.txtUserId = new MyCTS.Forms.UI.SmartTextBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdoSearch = new System.Windows.Forms.RadioButton();
            this.rdoChange = new System.Windows.Forms.RadioButton();
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
            this.lblTitle.Text = "Cambiar Firma en MyCTS";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(308, 291);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 12;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.AllowBlankSpaces = true;
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtEmail.CustomExpression = ".*";
            this.txtEmail.EnterColor = System.Drawing.Color.Empty;
            this.txtEmail.LeaveColor = System.Drawing.Color.Empty;
            this.txtEmail.Location = new System.Drawing.Point(100, 242);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(279, 20);
            this.txtEmail.TabIndex = 11;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtName
            // 
            this.txtName.AllowBlankSpaces = true;
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtName.CustomExpression = ".*";
            this.txtName.EnterColor = System.Drawing.Color.Empty;
            this.txtName.LeaveColor = System.Drawing.Color.Empty;
            this.txtName.Location = new System.Drawing.Point(100, 215);
            this.txtName.MaxLength = 40;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(279, 20);
            this.txtName.TabIndex = 10;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtTA
            // 
            this.txtTA.AllowBlankSpaces = true;
            this.txtTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTA.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtTA.CustomExpression = ".*";
            this.txtTA.EnterColor = System.Drawing.Color.Empty;
            this.txtTA.LeaveColor = System.Drawing.Color.Empty;
            this.txtTA.Location = new System.Drawing.Point(100, 165);
            this.txtTA.MaxLength = 6;
            this.txtTA.Name = "txtTA";
            this.txtTA.Size = new System.Drawing.Size(61, 20);
            this.txtTA.TabIndex = 8;
            this.txtTA.TextChanged += new System.EventHandler(this.txtTA_TextChanged);
            this.txtTA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtCodeAgent
            // 
            this.txtCodeAgent.AllowBlankSpaces = true;
            this.txtCodeAgent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodeAgent.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtCodeAgent.CustomExpression = ".*";
            this.txtCodeAgent.EnterColor = System.Drawing.Color.Empty;
            this.txtCodeAgent.LeaveColor = System.Drawing.Color.Empty;
            this.txtCodeAgent.Location = new System.Drawing.Point(100, 140);
            this.txtCodeAgent.MaxLength = 2;
            this.txtCodeAgent.Name = "txtCodeAgent";
            this.txtCodeAgent.Size = new System.Drawing.Size(34, 20);
            this.txtCodeAgent.TabIndex = 7;
            this.txtCodeAgent.TextChanged += new System.EventHandler(this.txtCodeAgent_TextChanged);
            this.txtCodeAgent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTA
            // 
            this.lblTA.AutoSize = true;
            this.lblTA.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTA.Location = new System.Drawing.Point(3, 168);
            this.lblTA.Name = "lblTA";
            this.lblTA.Size = new System.Drawing.Size(21, 13);
            this.lblTA.TabIndex = 0;
            this.lblTA.Text = "TA";
            // 
            // lblCodeAgent
            // 
            this.lblCodeAgent.AutoSize = true;
            this.lblCodeAgent.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblCodeAgent.Location = new System.Drawing.Point(3, 143);
            this.lblCodeAgent.Name = "lblCodeAgent";
            this.lblCodeAgent.Size = new System.Drawing.Size(81, 13);
            this.lblCodeAgent.TabIndex = 0;
            this.lblCodeAgent.Text = "Cod. de Agente";
            // 
            // txtLastName
            // 
            this.txtLastName.AllowBlankSpaces = true;
            this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtLastName.CustomExpression = ".*";
            this.txtLastName.EnterColor = System.Drawing.Color.Empty;
            this.txtLastName.LeaveColor = System.Drawing.Color.Empty;
            this.txtLastName.Location = new System.Drawing.Point(100, 190);
            this.txtLastName.MaxLength = 12;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 9;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            this.txtLastName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtQueue
            // 
            this.txtQueue.AllowBlankSpaces = true;
            this.txtQueue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQueue.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtQueue.CustomExpression = ".*";
            this.txtQueue.EnterColor = System.Drawing.Color.Empty;
            this.txtQueue.LeaveColor = System.Drawing.Color.Empty;
            this.txtQueue.Location = new System.Drawing.Point(100, 115);
            this.txtQueue.MaxLength = 3;
            this.txtQueue.Name = "txtQueue";
            this.txtQueue.Size = new System.Drawing.Size(48, 20);
            this.txtQueue.TabIndex = 6;
            this.txtQueue.TextChanged += new System.EventHandler(this.txtQueue_TextChanged);
            this.txtQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = true;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(221, 62);
            this.txtPCC.MaxLength = 4;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(114, 20);
            this.txtPCC.TabIndex = 4;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtNumberFirm
            // 
            this.txtNumberFirm.AllowBlankSpaces = true;
            this.txtNumberFirm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberFirm.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberFirm.CustomExpression = ".*";
            this.txtNumberFirm.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberFirm.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberFirm.Location = new System.Drawing.Point(100, 62);
            this.txtNumberFirm.MaxLength = 4;
            this.txtNumberFirm.Name = "txtNumberFirm";
            this.txtNumberFirm.Size = new System.Drawing.Size(63, 20);
            this.txtNumberFirm.TabIndex = 3;
            this.txtNumberFirm.TextChanged += new System.EventHandler(this.txtNumberFirm_TextChanged);
            this.txtNumberFirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblEmail.Location = new System.Drawing.Point(3, 243);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Email";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblName.Location = new System.Drawing.Point(3, 218);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(67, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Family Name";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblLastName.Location = new System.Drawing.Point(3, 193);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(60, 13);
            this.lblLastName.TabIndex = 0;
            this.lblLastName.Text = "User Name";
            // 
            // lblQueue
            // 
            this.lblQueue.AutoSize = true;
            this.lblQueue.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblQueue.Location = new System.Drawing.Point(3, 122);
            this.lblQueue.Name = "lblQueue";
            this.lblQueue.Size = new System.Drawing.Size(39, 13);
            this.lblQueue.TabIndex = 0;
            this.lblQueue.Text = "Queue";
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Location = new System.Drawing.Point(187, 65);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(28, 13);
            this.lblPCC.TabIndex = 0;
            this.lblPCC.Text = "PCC";
            // 
            // lblNumberFirm
            // 
            this.lblNumberFirm.AutoSize = true;
            this.lblNumberFirm.Location = new System.Drawing.Point(3, 65);
            this.lblNumberFirm.Name = "lblNumberFirm";
            this.lblNumberFirm.Size = new System.Drawing.Size(67, 13);
            this.lblNumberFirm.TabIndex = 0;
            this.lblNumberFirm.Text = "No. de Firma";
            // 
            // lbPCC
            // 
            this.lbPCC.DisplayMember = "Text";
            this.lbPCC.FormattingEnabled = true;
            this.lbPCC.Location = new System.Drawing.Point(221, 80);
            this.lbPCC.Name = "lbPCC";
            this.lbPCC.Size = new System.Drawing.Size(114, 95);
            this.lbPCC.TabIndex = 50;
            this.lbPCC.ValueMember = "Value";
            this.lbPCC.Visible = false;
            this.lbPCC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbPCC_KeyDown);
            // 
            // txtUserId
            // 
            this.txtUserId.AllowBlankSpaces = true;
            this.txtUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserId.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtUserId.CustomExpression = ".*";
            this.txtUserId.EnterColor = System.Drawing.Color.Empty;
            this.txtUserId.LeaveColor = System.Drawing.Color.Empty;
            this.txtUserId.Location = new System.Drawing.Point(100, 91);
            this.txtUserId.MaxLength = 40;
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(235, 20);
            this.txtUserId.TabIndex = 5;
            this.txtUserId.TextChanged += new System.EventHandler(this.txtUserId_TextChanged);
            this.txtUserId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblUserId.Location = new System.Drawing.Point(3, 94);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(38, 13);
            this.lblUserId.TabIndex = 0;
            this.lblUserId.Text = "UserId";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "¿Que deseas hacer?";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(-15, -15);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 52;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rdoSearch
            // 
            this.rdoSearch.AutoSize = true;
            this.rdoSearch.Location = new System.Drawing.Point(138, 37);
            this.rdoSearch.Name = "rdoSearch";
            this.rdoSearch.Size = new System.Drawing.Size(58, 17);
            this.rdoSearch.TabIndex = 1;
            this.rdoSearch.TabStop = true;
            this.rdoSearch.Text = "Buscar";
            this.rdoSearch.UseVisualStyleBackColor = true;
            this.rdoSearch.CheckedChanged += new System.EventHandler(this.rdoSearch_CheckedChanged);
            this.rdoSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoChange
            // 
            this.rdoChange.AutoSize = true;
            this.rdoChange.Location = new System.Drawing.Point(232, 37);
            this.rdoChange.Name = "rdoChange";
            this.rdoChange.Size = new System.Drawing.Size(68, 17);
            this.rdoChange.TabIndex = 2;
            this.rdoChange.TabStop = true;
            this.rdoChange.Text = "Modificar";
            this.rdoChange.UseVisualStyleBackColor = true;
            this.rdoChange.CheckedChanged += new System.EventHandler(this.rdoChange_CheckedChanged);
            this.rdoChange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucChangeFirmMyCTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.rdoChange);
            this.Controls.Add(this.rdoSearch);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtTA);
            this.Controls.Add(this.txtCodeAgent);
            this.Controls.Add(this.lblTA);
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
            this.Controls.Add(this.lbPCC);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucChangeFirmMyCTS";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucChangeFirmMyCTS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtEmail;
        private MyCTS.Forms.UI.SmartTextBox txtName;
        private MyCTS.Forms.UI.SmartTextBox txtTA;
        private MyCTS.Forms.UI.SmartTextBox txtCodeAgent;
        private System.Windows.Forms.Label lblTA;
        private System.Windows.Forms.Label lblCodeAgent;
        private MyCTS.Forms.UI.SmartTextBox txtLastName;
        private MyCTS.Forms.UI.SmartTextBox txtQueue;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private MyCTS.Forms.UI.SmartTextBox txtNumberFirm;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblQueue;
        private System.Windows.Forms.Label lblPCC;
        private System.Windows.Forms.Label lblNumberFirm;
        private System.Windows.Forms.ListBox lbPCC;
        private MyCTS.Forms.UI.SmartTextBox txtUserId;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rdoSearch;
        private System.Windows.Forms.RadioButton rdoChange;
    }
}
