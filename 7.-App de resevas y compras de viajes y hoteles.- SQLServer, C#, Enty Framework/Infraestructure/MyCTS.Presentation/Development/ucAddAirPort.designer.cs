namespace MyCTS.Presentation
{
    partial class ucAddAirPort
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
            this.lblCodeAirport = new System.Windows.Forms.Label();
            this.lblNameAirport = new System.Windows.Forms.Label();
            this.lblCountryAirport = new System.Windows.Forms.Label();
            this.txtCodeAirport = new MyCTS.Forms.UI.SmartTextBox();
            this.txtNameAirport = new MyCTS.Forms.UI.SmartTextBox();
            this.txtCountryAirport = new MyCTS.Forms.UI.SmartTextBox();
            this.txtCountryName = new MyCTS.Forms.UI.SmartTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 18);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Alta de Aeropuerto";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(255, 166);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 24);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblCodeAirport
            // 
            this.lblCodeAirport.AutoSize = true;
            this.lblCodeAirport.Location = new System.Drawing.Point(15, 45);
            this.lblCodeAirport.Name = "lblCodeAirport";
            this.lblCodeAirport.Size = new System.Drawing.Size(91, 13);
            this.lblCodeAirport.TabIndex = 0;
            this.lblCodeAirport.Text = "Código de Ciudad";
            // 
            // lblNameAirport
            // 
            this.lblNameAirport.AutoSize = true;
            this.lblNameAirport.Location = new System.Drawing.Point(15, 72);
            this.lblNameAirport.Name = "lblNameAirport";
            this.lblNameAirport.Size = new System.Drawing.Size(95, 13);
            this.lblNameAirport.TabIndex = 0;
            this.lblNameAirport.Text = "Nombre de Ciudad";
            // 
            // lblCountryAirport
            // 
            this.lblCountryAirport.AutoSize = true;
            this.lblCountryAirport.Location = new System.Drawing.Point(15, 99);
            this.lblCountryAirport.Name = "lblCountryAirport";
            this.lblCountryAirport.Size = new System.Drawing.Size(80, 13);
            this.lblCountryAirport.TabIndex = 0;
            this.lblCountryAirport.Text = "Código de País";
            // 
            // txtCodeAirport
            // 
            this.txtCodeAirport.AllowBlankSpaces = true;
            this.txtCodeAirport.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodeAirport.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtCodeAirport.CustomExpression = ".*";
            this.txtCodeAirport.EnterColor = System.Drawing.Color.Empty;
            this.txtCodeAirport.LeaveColor = System.Drawing.Color.Empty;
            this.txtCodeAirport.Location = new System.Drawing.Point(142, 42);
            this.txtCodeAirport.MaxLength = 3;
            this.txtCodeAirport.Name = "txtCodeAirport";
            this.txtCodeAirport.Size = new System.Drawing.Size(50, 20);
            this.txtCodeAirport.TabIndex = 1;
            this.txtCodeAirport.TextChanged += new System.EventHandler(this.txtCodeAirport_TextChanged);
            this.txtCodeAirport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtNameAirport
            // 
            this.txtNameAirport.AllowBlankSpaces = true;
            this.txtNameAirport.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNameAirport.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtNameAirport.CustomExpression = ".*";
            this.txtNameAirport.EnterColor = System.Drawing.Color.Empty;
            this.txtNameAirport.LeaveColor = System.Drawing.Color.Empty;
            this.txtNameAirport.Location = new System.Drawing.Point(142, 68);
            this.txtNameAirport.MaxLength = 50;
            this.txtNameAirport.Name = "txtNameAirport";
            this.txtNameAirport.Size = new System.Drawing.Size(201, 20);
            this.txtNameAirport.TabIndex = 2;
            this.txtNameAirport.TextChanged += new System.EventHandler(this.txtNameAirport_TextChanged);
            this.txtNameAirport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtCountryAirport
            // 
            this.txtCountryAirport.AllowBlankSpaces = true;
            this.txtCountryAirport.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCountryAirport.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtCountryAirport.CustomExpression = ".*";
            this.txtCountryAirport.EnterColor = System.Drawing.Color.Empty;
            this.txtCountryAirport.LeaveColor = System.Drawing.Color.Empty;
            this.txtCountryAirport.Location = new System.Drawing.Point(142, 94);
            this.txtCountryAirport.MaxLength = 2;
            this.txtCountryAirport.Name = "txtCountryAirport";
            this.txtCountryAirport.Size = new System.Drawing.Size(36, 20);
            this.txtCountryAirport.TabIndex = 3;
            this.txtCountryAirport.TextChanged += new System.EventHandler(this.txtCountryAirport_TextChanged);
            this.txtCountryAirport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtCountryName
            // 
            this.txtCountryName.AllowBlankSpaces = true;
            this.txtCountryName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCountryName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCountryName.CustomExpression = ".*";
            this.txtCountryName.EnterColor = System.Drawing.Color.Empty;
            this.txtCountryName.LeaveColor = System.Drawing.Color.Empty;
            this.txtCountryName.Location = new System.Drawing.Point(142, 120);
            this.txtCountryName.MaxLength = 50;
            this.txtCountryName.Name = "txtCountryName";
            this.txtCountryName.Size = new System.Drawing.Size(201, 20);
            this.txtCountryName.TabIndex = 4;
            this.txtCountryName.TextChanged += new System.EventHandler(this.txtCountryName_TextChanged);
            this.txtCountryName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de País";
            // 
            // ucAddAirPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCountryName);
            this.Controls.Add(this.txtCountryAirport);
            this.Controls.Add(this.txtNameAirport);
            this.Controls.Add(this.txtCodeAirport);
            this.Controls.Add(this.lblCountryAirport);
            this.Controls.Add(this.lblNameAirport);
            this.Controls.Add(this.lblCodeAirport);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucAddAirPort";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucAddAirPort_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblCodeAirport;
        private System.Windows.Forms.Label lblNameAirport;
        private System.Windows.Forms.Label lblCountryAirport;
        private MyCTS.Forms.UI.SmartTextBox txtCodeAirport;
        private MyCTS.Forms.UI.SmartTextBox txtNameAirport;
        private MyCTS.Forms.UI.SmartTextBox txtCountryAirport;
        private MyCTS.Forms.UI.SmartTextBox txtCountryName;
        private System.Windows.Forms.Label label1;
    }
}
