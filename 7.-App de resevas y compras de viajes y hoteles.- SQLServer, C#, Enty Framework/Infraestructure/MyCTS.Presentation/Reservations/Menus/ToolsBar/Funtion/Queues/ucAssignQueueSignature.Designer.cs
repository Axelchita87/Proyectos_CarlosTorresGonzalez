namespace MyCTS.Presentation
{
    partial class ucAssignQueueSignature
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
            this.lblBillingAdress = new System.Windows.Forms.Label();
            this.lbPCC = new System.Windows.Forms.ListBox();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPCC = new System.Windows.Forms.Label();
            this.txtQueue = new MyCTS.Forms.UI.SmartTextBox();
            this.lblQueue = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtAgentCode = new MyCTS.Forms.UI.SmartTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirm = new MyCTS.Forms.UI.SmartTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBillingAdress
            // 
            this.lblBillingAdress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblBillingAdress.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBillingAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillingAdress.ForeColor = System.Drawing.Color.White;
            this.lblBillingAdress.Location = new System.Drawing.Point(0, 0);
            this.lblBillingAdress.Name = "lblBillingAdress";
            this.lblBillingAdress.Size = new System.Drawing.Size(411, 17);
            this.lblBillingAdress.TabIndex = 1;
            this.lblBillingAdress.Text = "Asigna Queue a Firma";
            this.lblBillingAdress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPCC
            // 
            this.lbPCC.DisplayMember = "Text";
            this.lbPCC.FormattingEnabled = true;
            this.lbPCC.Location = new System.Drawing.Point(145, 96);
            this.lbPCC.Name = "lbPCC";
            this.lbPCC.Size = new System.Drawing.Size(103, 43);
            this.lbPCC.TabIndex = 14;
            this.lbPCC.ValueMember = "Value";
            this.lbPCC.Visible = false;
            this.lbPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbPCC_KeyDown);
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = true;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(145, 77);
            this.txtPCC.MaxLength = 6;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(103, 20);
            this.txtPCC.TabIndex = 13;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPCC.Location = new System.Drawing.Point(21, 84);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(31, 13);
            this.lblPCC.TabIndex = 12;
            this.lblPCC.Text = "PCC:";
            // 
            // txtQueue
            // 
            this.txtQueue.AllowBlankSpaces = true;
            this.txtQueue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQueue.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtQueue.CustomExpression = ".*";
            this.txtQueue.EnterColor = System.Drawing.Color.Empty;
            this.txtQueue.LeaveColor = System.Drawing.Color.Empty;
            this.txtQueue.Location = new System.Drawing.Point(145, 41);
            this.txtQueue.MaxLength = 6;
            this.txtQueue.Name = "txtQueue";
            this.txtQueue.Size = new System.Drawing.Size(103, 20);
            this.txtQueue.TabIndex = 11;
            this.txtQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblQueue
            // 
            this.lblQueue.AutoSize = true;
            this.lblQueue.Location = new System.Drawing.Point(21, 41);
            this.lblQueue.Name = "lblQueue";
            this.lblQueue.Size = new System.Drawing.Size(74, 13);
            this.lblQueue.TabIndex = 10;
            this.lblQueue.Text = "No. de Queue";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(271, 208);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 17;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtAgentCode
            // 
            this.txtAgentCode.AllowBlankSpaces = true;
            this.txtAgentCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAgentCode.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtAgentCode.CustomExpression = ".*";
            this.txtAgentCode.EnterColor = System.Drawing.Color.Empty;
            this.txtAgentCode.LeaveColor = System.Drawing.Color.Empty;
            this.txtAgentCode.Location = new System.Drawing.Point(145, 128);
            this.txtAgentCode.MaxLength = 6;
            this.txtAgentCode.Name = "txtAgentCode";
            this.txtAgentCode.Size = new System.Drawing.Size(103, 20);
            this.txtAgentCode.TabIndex = 15;
            this.txtAgentCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Código de Agente";
            // 
            // txtFirm
            // 
            this.txtFirm.AllowBlankSpaces = true;
            this.txtFirm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFirm.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtFirm.CustomExpression = ".*";
            this.txtFirm.EnterColor = System.Drawing.Color.Empty;
            this.txtFirm.LeaveColor = System.Drawing.Color.Empty;
            this.txtFirm.Location = new System.Drawing.Point(145, 170);
            this.txtFirm.MaxLength = 4;
            this.txtFirm.Name = "txtFirm";
            this.txtFirm.Size = new System.Drawing.Size(103, 20);
            this.txtFirm.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Firma";
            // 
            // ucAssignQueueSignature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtFirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAgentCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lbPCC);
            this.Controls.Add(this.txtPCC);
            this.Controls.Add(this.lblPCC);
            this.Controls.Add(this.txtQueue);
            this.Controls.Add(this.lblQueue);
            this.Controls.Add(this.lblBillingAdress);
            this.Name = "ucAssignQueueSignature";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucAssignQueueSignature_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblBillingAdress;
        private System.Windows.Forms.ListBox lbPCC;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private System.Windows.Forms.Label lblPCC;
        private MyCTS.Forms.UI.SmartTextBox txtQueue;
        private System.Windows.Forms.Label lblQueue;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtAgentCode;
        private System.Windows.Forms.Label label1;
        private MyCTS.Forms.UI.SmartTextBox txtFirm;
        private System.Windows.Forms.Label label2;
    }
}

