namespace MyCTS.Presentation
{
    partial class ucDeleteFirm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAuthorization = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtNumberFirm = new MyCTS.Forms.UI.SmartTextBox();
            this.lblFirmNumber = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPCC = new System.Windows.Forms.Label();
            this.lbPCC = new System.Windows.Forms.ListBox();
            this.lblQueue = new System.Windows.Forms.Label();
            this.txtQueue = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAgent = new MyCTS.Forms.UI.SmartTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbnBoth = new System.Windows.Forms.RadioButton();
            this.rbnMyCTS = new System.Windows.Forms.RadioButton();
            this.rbnSabre = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Autorizado por";
            // 
            // txtAuthorization
            // 
            this.txtAuthorization.AllowBlankSpaces = true;
            this.txtAuthorization.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAuthorization.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtAuthorization.CustomExpression = ".*";
            this.txtAuthorization.EnterColor = System.Drawing.Color.Empty;
            this.txtAuthorization.LeaveColor = System.Drawing.Color.Empty;
            this.txtAuthorization.Location = new System.Drawing.Point(100, 146);
            this.txtAuthorization.MaxLength = 15;
            this.txtAuthorization.Name = "txtAuthorization";
            this.txtAuthorization.Size = new System.Drawing.Size(100, 20);
            this.txtAuthorization.TabIndex = 5;
            this.txtAuthorization.TextChanged += new System.EventHandler(this.txtAuthorization_TextChanged);
            this.txtAuthorization.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(286, 270);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtNumberFirm
            // 
            this.txtNumberFirm.AllowBlankSpaces = true;
            this.txtNumberFirm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberFirm.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberFirm.CustomExpression = ".*";
            this.txtNumberFirm.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberFirm.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberFirm.Location = new System.Drawing.Point(100, 40);
            this.txtNumberFirm.MaxLength = 4;
            this.txtNumberFirm.Name = "txtNumberFirm";
            this.txtNumberFirm.Size = new System.Drawing.Size(68, 20);
            this.txtNumberFirm.TabIndex = 1;
            this.txtNumberFirm.TextChanged += new System.EventHandler(this.txtNumberFirm_TextChanged);
            this.txtNumberFirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblFirmNumber
            // 
            this.lblFirmNumber.AutoSize = true;
            this.lblFirmNumber.Location = new System.Drawing.Point(16, 43);
            this.lblFirmNumber.Name = "lblFirmNumber";
            this.lblFirmNumber.Size = new System.Drawing.Size(67, 13);
            this.lblFirmNumber.TabIndex = 0;
            this.lblFirmNumber.Text = "No. de Firma";
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
            this.lblTitle.Text = "Eliminar Firma";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = true;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(100, 115);
            this.txtPCC.MaxLength = 4;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(113, 20);
            this.txtPCC.TabIndex = 4;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Location = new System.Drawing.Point(16, 125);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(28, 13);
            this.lblPCC.TabIndex = 0;
            this.lblPCC.Text = "PCC";
            // 
            // lbPCC
            // 
            this.lbPCC.DisplayMember = "Text";
            this.lbPCC.FormattingEnabled = true;
            this.lbPCC.Location = new System.Drawing.Point(100, 133);
            this.lbPCC.Name = "lbPCC";
            this.lbPCC.Size = new System.Drawing.Size(114, 95);
            this.lbPCC.TabIndex = 46;
            this.lbPCC.ValueMember = "Value";
            this.lbPCC.Visible = false;
            this.lbPCC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbPCC_KeyDown);
            // 
            // lblQueue
            // 
            this.lblQueue.AutoSize = true;
            this.lblQueue.Location = new System.Drawing.Point(16, 71);
            this.lblQueue.Name = "lblQueue";
            this.lblQueue.Size = new System.Drawing.Size(39, 13);
            this.lblQueue.TabIndex = 0;
            this.lblQueue.Text = "Queue";
            // 
            // txtQueue
            // 
            this.txtQueue.AllowBlankSpaces = true;
            this.txtQueue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQueue.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtQueue.CustomExpression = ".*";
            this.txtQueue.EnterColor = System.Drawing.Color.Empty;
            this.txtQueue.LeaveColor = System.Drawing.Color.Empty;
            this.txtQueue.Location = new System.Drawing.Point(100, 64);
            this.txtQueue.MaxLength = 3;
            this.txtQueue.Name = "txtQueue";
            this.txtQueue.Size = new System.Drawing.Size(49, 20);
            this.txtQueue.TabIndex = 2;
            this.txtQueue.TextChanged += new System.EventHandler(this.txtQueue_TextChanged);
            // 
            // txtAgent
            // 
            this.txtAgent.AllowBlankSpaces = true;
            this.txtAgent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAgent.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtAgent.CustomExpression = ".*";
            this.txtAgent.EnterColor = System.Drawing.Color.Empty;
            this.txtAgent.LeaveColor = System.Drawing.Color.Empty;
            this.txtAgent.Location = new System.Drawing.Point(100, 90);
            this.txtAgent.MaxLength = 2;
            this.txtAgent.Name = "txtAgent";
            this.txtAgent.Size = new System.Drawing.Size(38, 20);
            this.txtAgent.TabIndex = 3;
            this.txtAgent.TextChanged += new System.EventHandler(this.txtAgent_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cod. Agent";
            // 
            // rbnBoth
            // 
            this.rbnBoth.AutoSize = true;
            this.rbnBoth.Location = new System.Drawing.Point(14, 273);
            this.rbnBoth.Name = "rbnBoth";
            this.rbnBoth.Size = new System.Drawing.Size(73, 17);
            this.rbnBoth.TabIndex = 49;
            this.rbnBoth.TabStop = true;
            this.rbnBoth.Text = "En Ambos";
            this.rbnBoth.UseVisualStyleBackColor = true;
            // 
            // rbnMyCTS
            // 
            this.rbnMyCTS.AutoSize = true;
            this.rbnMyCTS.Location = new System.Drawing.Point(179, 273);
            this.rbnMyCTS.Name = "rbnMyCTS";
            this.rbnMyCTS.Size = new System.Drawing.Size(76, 17);
            this.rbnMyCTS.TabIndex = 48;
            this.rbnMyCTS.TabStop = true;
            this.rbnMyCTS.Text = "En MyCTS";
            this.rbnMyCTS.UseVisualStyleBackColor = true;
            // 
            // rbnSabre
            // 
            this.rbnSabre.AutoSize = true;
            this.rbnSabre.Location = new System.Drawing.Point(99, 273);
            this.rbnSabre.Name = "rbnSabre";
            this.rbnSabre.Size = new System.Drawing.Size(69, 17);
            this.rbnSabre.TabIndex = 47;
            this.rbnSabre.TabStop = true;
            this.rbnSabre.Text = "En Sabre";
            this.rbnSabre.UseVisualStyleBackColor = true;
            // 
            // ucDeleteFirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.rbnBoth);
            this.Controls.Add(this.rbnMyCTS);
            this.Controls.Add(this.rbnSabre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAgent);
            this.Controls.Add(this.txtQueue);
            this.Controls.Add(this.lblQueue);
            this.Controls.Add(this.txtPCC);
            this.Controls.Add(this.lblPCC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAuthorization);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtNumberFirm);
            this.Controls.Add(this.lblFirmNumber);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lbPCC);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucDeleteFirm";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDeleteFirm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private MyCTS.Forms.UI.SmartTextBox txtAuthorization;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtNumberFirm;
        private System.Windows.Forms.Label lblFirmNumber;
        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private System.Windows.Forms.Label lblPCC;
        private System.Windows.Forms.ListBox lbPCC;
        private System.Windows.Forms.Label lblQueue;
        private MyCTS.Forms.UI.SmartTextBox txtQueue;
        private MyCTS.Forms.UI.SmartTextBox txtAgent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbnBoth;
        private System.Windows.Forms.RadioButton rbnMyCTS;
        private System.Windows.Forms.RadioButton rbnSabre;
    }
}
