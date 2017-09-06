namespace MyCTS.Presentation
{
    partial class ucCreatePhaseIV
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
            this.lblPassengerType = new System.Windows.Forms.Label();
            this.txtPassengerType = new MyCTS.Forms.UI.SmartTextBox();
            this.chkInternationalFlight = new System.Windows.Forms.CheckBox();
            this.chkBySegments = new System.Windows.Forms.CheckBox();
            this.btnAccept = new System.Windows.Forms.Button();
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
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Creación de Fase IV - Pag 1";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPassengerType
            // 
            this.lblPassengerType.AutoSize = true;
            this.lblPassengerType.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblPassengerType.Location = new System.Drawing.Point(40, 46);
            this.lblPassengerType.Name = "lblPassengerType";
            this.lblPassengerType.Size = new System.Drawing.Size(90, 13);
            this.lblPassengerType.TabIndex = 0;
            this.lblPassengerType.Text = "Tipo de Pasajero:";
            // 
            // txtPassengerType
            // 
            this.txtPassengerType.AllowBlankSpaces = false;
            this.txtPassengerType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassengerType.CharsIncluded = new char[] {
        '.'};
            this.txtPassengerType.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtPassengerType.CustomExpression = ".*";
            this.txtPassengerType.EnterColor = System.Drawing.Color.Empty;
            this.txtPassengerType.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassengerType.Location = new System.Drawing.Point(145, 43);
            this.txtPassengerType.MaxLength = 3;
            this.txtPassengerType.Name = "txtPassengerType";
            this.txtPassengerType.Size = new System.Drawing.Size(35, 20);
            this.txtPassengerType.TabIndex = 1;
            this.txtPassengerType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkInternationalFlight
            // 
            this.chkInternationalFlight.AutoSize = true;
            this.chkInternationalFlight.Location = new System.Drawing.Point(43, 75);
            this.chkInternationalFlight.Name = "chkInternationalFlight";
            this.chkInternationalFlight.Size = new System.Drawing.Size(143, 17);
            this.chkInternationalFlight.TabIndex = 2;
            this.chkInternationalFlight.Text = "¿Es Vuelo internacional?";
            this.chkInternationalFlight.UseVisualStyleBackColor = true;
            this.chkInternationalFlight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkBySegments
            // 
            this.chkBySegments.AutoSize = true;
            this.chkBySegments.Location = new System.Drawing.Point(43, 107);
            this.chkBySegments.Name = "chkBySegments";
            this.chkBySegments.Size = new System.Drawing.Size(110, 17);
            this.chkBySegments.TabIndex = 3;
            this.chkBySegments.Text = "¿Por Segmentos?";
            this.chkBySegments.UseVisualStyleBackColor = true;
            this.chkBySegments.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(263, 131);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucCreatePhaseIV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.chkBySegments);
            this.Controls.Add(this.chkInternationalFlight);
            this.Controls.Add(this.txtPassengerType);
            this.Controls.Add(this.lblPassengerType);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucCreatePhaseIV";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucCreatePhaseIV_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPassengerType;
        private MyCTS.Forms.UI.SmartTextBox txtPassengerType;
        private System.Windows.Forms.CheckBox chkInternationalFlight;
        private System.Windows.Forms.CheckBox chkBySegments;
        private System.Windows.Forms.Button btnAccept;
    }
}
