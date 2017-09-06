namespace MyCTS.Presentation
{
    partial class ucQREX
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
            this.btnCross = new System.Windows.Forms.Button();
            this.txtCommand = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAcept = new System.Windows.Forms.Button();
            this.lblCommand = new System.Windows.Forms.Label();
            this.lblQREX = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoGenerate = new System.Windows.Forms.RadioButton();
            this.rdoWillPrice = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnCross
            // 
            this.btnCross.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCross.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCross.Location = new System.Drawing.Point(262, 178);
            this.btnCross.Name = "btnCross";
            this.btnCross.Size = new System.Drawing.Size(110, 24);
            this.btnCross.TabIndex = 58;
            this.btnCross.Text = "Agregar  ‡";
            this.btnCross.UseVisualStyleBackColor = false;
            this.btnCross.Click += new System.EventHandler(this.btnCross_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.AllowBlankSpaces = true;
            this.txtCommand.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCommand.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCommand.CustomExpression = ".*";
            this.txtCommand.EnterColor = System.Drawing.Color.Empty;
            this.txtCommand.LeaveColor = System.Drawing.Color.Empty;
            this.txtCommand.Location = new System.Drawing.Point(87, 122);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(285, 20);
            this.txtCommand.TabIndex = 57;
            this.txtCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAcept
            // 
            this.btnAcept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAcept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAcept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcept.Location = new System.Drawing.Point(262, 269);
            this.btnAcept.Name = "btnAcept";
            this.btnAcept.Size = new System.Drawing.Size(110, 24);
            this.btnAcept.TabIndex = 59;
            this.btnAcept.Text = "Aceptar";
            this.btnAcept.UseVisualStyleBackColor = false;
            this.btnAcept.Click += new System.EventHandler(this.btnAcept_Click);
            // 
            // lblCommand
            // 
            this.lblCommand.AutoSize = true;
            this.lblCommand.Location = new System.Drawing.Point(49, 125);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(32, 13);
            this.lblCommand.TabIndex = 56;
            this.lblCommand.Text = "WFR";
            // 
            // lblQREX
            // 
            this.lblQREX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblQREX.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblQREX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQREX.ForeColor = System.Drawing.Color.White;
            this.lblQREX.Location = new System.Drawing.Point(0, 0);
            this.lblQREX.Name = "lblQREX";
            this.lblQREX.Size = new System.Drawing.Size(411, 17);
            this.lblQREX.TabIndex = 55;
            this.lblQREX.Text = "Emisión de Boleto QREX";
            this.lblQREX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Introduzca el formato para emisión de QREX";
            // 
            // rdoGenerate
            // 
            this.rdoGenerate.AutoSize = true;
            this.rdoGenerate.Location = new System.Drawing.Point(87, 172);
            this.rdoGenerate.Name = "rdoGenerate";
            this.rdoGenerate.Size = new System.Drawing.Size(50, 17);
            this.rdoGenerate.TabIndex = 64;
            this.rdoGenerate.TabStop = true;
            this.rdoGenerate.Text = "Emitir";
            this.rdoGenerate.UseVisualStyleBackColor = true;
            // 
            // rdoWillPrice
            // 
            this.rdoWillPrice.AutoSize = true;
            this.rdoWillPrice.Location = new System.Drawing.Point(87, 148);
            this.rdoWillPrice.Name = "rdoWillPrice";
            this.rdoWillPrice.Size = new System.Drawing.Size(57, 17);
            this.rdoWillPrice.TabIndex = 63;
            this.rdoWillPrice.TabStop = true;
            this.rdoWillPrice.Text = "Cotizar";
            this.rdoWillPrice.UseVisualStyleBackColor = true;
            // 
            // ucQREX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.rdoGenerate);
            this.Controls.Add(this.rdoWillPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCross);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.btnAcept);
            this.Controls.Add(this.lblCommand);
            this.Controls.Add(this.lblQREX);
            this.Name = "ucQREX";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucQREX_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCross;
        private MyCTS.Forms.UI.SmartTextBox txtCommand;
        private System.Windows.Forms.Button btnAcept;
        private System.Windows.Forms.Label lblCommand;
        internal System.Windows.Forms.Label lblQREX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoGenerate;
        private System.Windows.Forms.RadioButton rdoWillPrice;
    }
}
