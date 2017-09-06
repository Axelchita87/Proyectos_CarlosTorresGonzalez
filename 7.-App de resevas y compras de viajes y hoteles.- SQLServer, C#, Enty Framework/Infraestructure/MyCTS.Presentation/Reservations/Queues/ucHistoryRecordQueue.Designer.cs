namespace MyCTS.Presentation
{
    partial class ucHistoryRecordQueue
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.rdoDisplaySistemCode = new System.Windows.Forms.RadioButton();
            this.rdoDeployCustomCode = new System.Windows.Forms.RadioButton();
            this.rdoAddCustomCode = new System.Windows.Forms.RadioButton();
            this.rdoCustomCodeChange = new System.Windows.Forms.RadioButton();
            this.rdoDeleteCustomCode = new System.Windows.Forms.RadioButton();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new MyCTS.Forms.UI.SmartTextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.txtText = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPCC = new System.Windows.Forms.Label();
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
            this.lblBillingAdress.TabIndex = 0;
            this.lblBillingAdress.Text = "Referencias de Pic Codes";
            this.lblBillingAdress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(248, 384);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 9;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // rdoDisplaySistemCode
            // 
            this.rdoDisplaySistemCode.AutoSize = true;
            this.rdoDisplaySistemCode.Location = new System.Drawing.Point(24, 47);
            this.rdoDisplaySistemCode.Name = "rdoDisplaySistemCode";
            this.rdoDisplaySistemCode.Size = new System.Drawing.Size(170, 17);
            this.rdoDisplaySistemCode.TabIndex = 2;
            this.rdoDisplaySistemCode.TabStop = true;
            this.rdoDisplaySistemCode.Text = "Desplegar códigos del Sistema";
            this.rdoDisplaySistemCode.UseVisualStyleBackColor = true;
            this.rdoDisplaySistemCode.CheckedChanged += new System.EventHandler(this.rdoDisplaySistemCode_CheckedChanged);
            this.rdoDisplaySistemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoDeployCustomCode
            // 
            this.rdoDeployCustomCode.AutoSize = true;
            this.rdoDeployCustomCode.Location = new System.Drawing.Point(24, 87);
            this.rdoDeployCustomCode.Name = "rdoDeployCustomCode";
            this.rdoDeployCustomCode.Size = new System.Drawing.Size(189, 17);
            this.rdoDeployCustomCode.TabIndex = 2;
            this.rdoDeployCustomCode.TabStop = true;
            this.rdoDeployCustomCode.Text = "Desplegar cógidos  personalizados";
            this.rdoDeployCustomCode.UseVisualStyleBackColor = true;
            this.rdoDeployCustomCode.CheckedChanged += new System.EventHandler(this.rdoDeployCustomCode_CheckedChanged);
            this.rdoDeployCustomCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoAddCustomCode
            // 
            this.rdoAddCustomCode.AutoSize = true;
            this.rdoAddCustomCode.Location = new System.Drawing.Point(24, 124);
            this.rdoAddCustomCode.Name = "rdoAddCustomCode";
            this.rdoAddCustomCode.Size = new System.Drawing.Size(175, 17);
            this.rdoAddCustomCode.TabIndex = 3;
            this.rdoAddCustomCode.TabStop = true;
            this.rdoAddCustomCode.Text = "Agregar códigos personalizados";
            this.rdoAddCustomCode.UseVisualStyleBackColor = true;
            this.rdoAddCustomCode.CheckedChanged += new System.EventHandler(this.rdoAddCustomCode_CheckedChanged);
            this.rdoAddCustomCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoCustomCodeChange
            // 
            this.rdoCustomCodeChange.AutoSize = true;
            this.rdoCustomCodeChange.Location = new System.Drawing.Point(24, 168);
            this.rdoCustomCodeChange.Name = "rdoCustomCodeChange";
            this.rdoCustomCodeChange.Size = new System.Drawing.Size(176, 17);
            this.rdoCustomCodeChange.TabIndex = 4;
            this.rdoCustomCodeChange.TabStop = true;
            this.rdoCustomCodeChange.Text = "Cambiar códigos personalizados";
            this.rdoCustomCodeChange.UseVisualStyleBackColor = true;
            this.rdoCustomCodeChange.CheckedChanged += new System.EventHandler(this.rdoCustomCodeChange_CheckedChanged);
            this.rdoCustomCodeChange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoDeleteCustomCode
            // 
            this.rdoDeleteCustomCode.AutoSize = true;
            this.rdoDeleteCustomCode.Location = new System.Drawing.Point(24, 212);
            this.rdoDeleteCustomCode.Name = "rdoDeleteCustomCode";
            this.rdoDeleteCustomCode.Size = new System.Drawing.Size(166, 17);
            this.rdoDeleteCustomCode.TabIndex = 5;
            this.rdoDeleteCustomCode.TabStop = true;
            this.rdoDeleteCustomCode.Text = "Borrar códigos personalizados";
            this.rdoDeleteCustomCode.UseVisualStyleBackColor = true;
            this.rdoDeleteCustomCode.CheckedChanged += new System.EventHandler(this.rdoDeleteCustomCode_CheckedChanged);
            this.rdoDeleteCustomCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(45, 258);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(43, 13);
            this.lblCode.TabIndex = 10;
            this.lblCode.Text = "Código:";
            this.lblCode.Visible = false;
            // 
            // txtCode
            // 
            this.txtCode.AllowBlankSpaces = true;
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtCode.CustomExpression = ".*";
            this.txtCode.EnterColor = System.Drawing.Color.Empty;
            this.txtCode.LeaveColor = System.Drawing.Color.Empty;
            this.txtCode.Location = new System.Drawing.Point(94, 255);
            this.txtCode.MaxLength = 3;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(51, 20);
            this.txtCode.TabIndex = 7;
            this.txtCode.Visible = false;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(45, 299);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(37, 13);
            this.lblText.TabIndex = 12;
            this.lblText.Text = "Texto:";
            this.lblText.Visible = false;
            // 
            // txtText
            // 
            this.txtText.AllowBlankSpaces = true;
            this.txtText.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtText.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtText.CustomExpression = ".*";
            this.txtText.EnterColor = System.Drawing.Color.Empty;
            this.txtText.LeaveColor = System.Drawing.Color.Empty;
            this.txtText.Location = new System.Drawing.Point(94, 296);
            this.txtText.MaxLength = 50;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(292, 20);
            this.txtText.TabIndex = 8;
            this.txtText.Visible = false;
            this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
            this.txtText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = true;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(279, 90);
            this.txtPCC.MaxLength = 4;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(57, 20);
            this.txtPCC.TabIndex = 6;
            this.txtPCC.Visible = false;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Location = new System.Drawing.Point(245, 93);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(28, 13);
            this.lblPCC.TabIndex = 0;
            this.lblPCC.Text = "PCC";
            this.lblPCC.Visible = false;
            // 
            // ucHistoryRecordQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblPCC);
            this.Controls.Add(this.txtPCC);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.rdoDeleteCustomCode);
            this.Controls.Add(this.rdoCustomCodeChange);
            this.Controls.Add(this.rdoAddCustomCode);
            this.Controls.Add(this.rdoDeployCustomCode);
            this.Controls.Add(this.rdoDisplaySistemCode);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblBillingAdress);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucHistoryRecordQueue";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucHistoryRecordQueue_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblBillingAdress;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.RadioButton rdoDisplaySistemCode;
        private System.Windows.Forms.RadioButton rdoDeployCustomCode;
        private System.Windows.Forms.RadioButton rdoAddCustomCode;
        private System.Windows.Forms.RadioButton rdoCustomCodeChange;
        private System.Windows.Forms.RadioButton rdoDeleteCustomCode;
        private System.Windows.Forms.Label lblCode;
        private MyCTS.Forms.UI.SmartTextBox txtCode;
        private System.Windows.Forms.Label lblText;
        private MyCTS.Forms.UI.SmartTextBox txtText;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private System.Windows.Forms.Label lblPCC;
    }
}
