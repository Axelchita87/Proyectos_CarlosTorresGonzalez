namespace MyCTS.Presentation
{
    partial class ucSplitConfirmation
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.rdoYes = new System.Windows.Forms.RadioButton();
            this.rdoNo = new System.Windows.Forms.RadioButton();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 15);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "División de Record Confirmación";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(30, 42);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(201, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "¿Ha sido correcta la división del Record?";
            // 
            // rdoYes
            // 
            this.rdoYes.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoYes.AutoSize = true;
            this.rdoYes.FlatAppearance.CheckedBackColor = System.Drawing.Color.Orange;
            this.rdoYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoYes.Location = new System.Drawing.Point(51, 89);
            this.rdoYes.Name = "rdoYes";
            this.rdoYes.Size = new System.Drawing.Size(28, 25);
            this.rdoYes.TabIndex = 1;
            this.rdoYes.TabStop = true;
            this.rdoYes.Text = "Si";
            this.rdoYes.UseVisualStyleBackColor = true;
            this.rdoYes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoNo
            // 
            this.rdoNo.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoNo.AutoSize = true;
            this.rdoNo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Orange;
            this.rdoNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoNo.Location = new System.Drawing.Point(107, 89);
            this.rdoNo.Name = "rdoNo";
            this.rdoNo.Size = new System.Drawing.Size(33, 25);
            this.rdoNo.TabIndex = 2;
            this.rdoNo.TabStop = true;
            this.rdoNo.Text = "No";
            this.rdoNo.UseVisualStyleBackColor = true;
            this.rdoNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(220, 188);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.ForeColor = System.Drawing.Color.Blue;
            this.lblMessage.Location = new System.Drawing.Point(30, 136);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(358, 35);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "RECUERDA QUE SOLO DEBE EXISTIR UN ARUNK Y SEGMENTO DE PROTECCCION AL FINAL DEL RE" +
                "CORD";
            // 
            // ucSplitConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.rdoNo);
            this.Controls.Add(this.rdoYes);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucSplitConfirmation";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucSplitConfirmation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RadioButton rdoYes;
        private System.Windows.Forms.RadioButton rdoNo;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblMessage;

    }
}
