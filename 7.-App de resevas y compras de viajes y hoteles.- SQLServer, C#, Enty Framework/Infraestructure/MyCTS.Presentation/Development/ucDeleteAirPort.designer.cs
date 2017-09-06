namespace MyCTS.Presentation
{
    partial class ucDeleteAirPort
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
            this.txtCountryAirport = new MyCTS.Forms.UI.SmartTextBox();
            this.txtNameAirport = new MyCTS.Forms.UI.SmartTextBox();
            this.txtCodeAirport = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCountryAirport = new System.Windows.Forms.Label();
            this.lblNameAirport = new System.Windows.Forms.Label();
            this.lblCodeAirport = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoSearch = new System.Windows.Forms.RadioButton();
            this.rdoDelete = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCountryName = new MyCTS.Forms.UI.SmartTextBox();
            this.SuspendLayout();
            // 
            // txtCountryAirport
            // 
            this.txtCountryAirport.AllowBlankSpaces = true;
            this.txtCountryAirport.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCountryAirport.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtCountryAirport.CustomExpression = ".*";
            this.txtCountryAirport.EnterColor = System.Drawing.Color.Empty;
            this.txtCountryAirport.LeaveColor = System.Drawing.Color.Empty;
            this.txtCountryAirport.Location = new System.Drawing.Point(145, 115);
            this.txtCountryAirport.MaxLength = 2;
            this.txtCountryAirport.Name = "txtCountryAirport";
            this.txtCountryAirport.Size = new System.Drawing.Size(36, 20);
            this.txtCountryAirport.TabIndex = 5;
            this.txtCountryAirport.TextChanged += new System.EventHandler(this.txtCountryAirport_TextChanged);
            this.txtCountryAirport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtNameAirport
            // 
            this.txtNameAirport.AllowBlankSpaces = true;
            this.txtNameAirport.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNameAirport.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtNameAirport.CustomExpression = ".*";
            this.txtNameAirport.EnterColor = System.Drawing.Color.Empty;
            this.txtNameAirport.LeaveColor = System.Drawing.Color.Empty;
            this.txtNameAirport.Location = new System.Drawing.Point(145, 89);
            this.txtNameAirport.MaxLength = 50;
            this.txtNameAirport.Name = "txtNameAirport";
            this.txtNameAirport.Size = new System.Drawing.Size(201, 20);
            this.txtNameAirport.TabIndex = 4;
            this.txtNameAirport.TextChanged += new System.EventHandler(this.txtNameAirport_TextChanged);
            this.txtNameAirport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtCodeAirport
            // 
            this.txtCodeAirport.AllowBlankSpaces = true;
            this.txtCodeAirport.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodeAirport.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtCodeAirport.CustomExpression = ".*";
            this.txtCodeAirport.EnterColor = System.Drawing.Color.Empty;
            this.txtCodeAirport.LeaveColor = System.Drawing.Color.Empty;
            this.txtCodeAirport.Location = new System.Drawing.Point(145, 63);
            this.txtCodeAirport.MaxLength = 3;
            this.txtCodeAirport.Name = "txtCodeAirport";
            this.txtCodeAirport.Size = new System.Drawing.Size(50, 20);
            this.txtCodeAirport.TabIndex = 3;
            this.txtCodeAirport.TextChanged += new System.EventHandler(this.txtCodeAirport_TextChanged);
            this.txtCodeAirport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCountryAirport
            // 
            this.lblCountryAirport.AutoSize = true;
            this.lblCountryAirport.Location = new System.Drawing.Point(18, 120);
            this.lblCountryAirport.Name = "lblCountryAirport";
            this.lblCountryAirport.Size = new System.Drawing.Size(113, 13);
            this.lblCountryAirport.TabIndex = 0;
            this.lblCountryAirport.Text = "Aeropuerto por Ciudad";
            // 
            // lblNameAirport
            // 
            this.lblNameAirport.AutoSize = true;
            this.lblNameAirport.Location = new System.Drawing.Point(18, 93);
            this.lblNameAirport.Name = "lblNameAirport";
            this.lblNameAirport.Size = new System.Drawing.Size(114, 13);
            this.lblNameAirport.TabIndex = 0;
            this.lblNameAirport.Text = "Nombre de Aeropuerto";
            // 
            // lblCodeAirport
            // 
            this.lblCodeAirport.AutoSize = true;
            this.lblCodeAirport.Location = new System.Drawing.Point(18, 66);
            this.lblCodeAirport.Name = "lblCodeAirport";
            this.lblCodeAirport.Size = new System.Drawing.Size(110, 13);
            this.lblCodeAirport.TabIndex = 0;
            this.lblCodeAirport.Text = "Código de Aeropuerto";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(246, 171);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 24);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
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
            this.lblTitle.Text = "Baja de Aeropuerto";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Que deseas hacer?";
            // 
            // rdoSearch
            // 
            this.rdoSearch.AutoSize = true;
            this.rdoSearch.Location = new System.Drawing.Point(145, 34);
            this.rdoSearch.Name = "rdoSearch";
            this.rdoSearch.Size = new System.Drawing.Size(58, 17);
            this.rdoSearch.TabIndex = 1;
            this.rdoSearch.TabStop = true;
            this.rdoSearch.Text = "Buscar";
            this.rdoSearch.UseVisualStyleBackColor = true;
            this.rdoSearch.CheckedChanged += new System.EventHandler(this.rdoSearch_CheckedChanged);
            // 
            // rdoDelete
            // 
            this.rdoDelete.AutoSize = true;
            this.rdoDelete.Location = new System.Drawing.Point(236, 34);
            this.rdoDelete.Name = "rdoDelete";
            this.rdoDelete.Size = new System.Drawing.Size(46, 17);
            this.rdoDelete.TabIndex = 2;
            this.rdoDelete.TabStop = true;
            this.rdoDelete.Text = "Baja";
            this.rdoDelete.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre de País";
            // 
            // txtCountryName
            // 
            this.txtCountryName.AllowBlankSpaces = true;
            this.txtCountryName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCountryName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCountryName.CustomExpression = ".*";
            this.txtCountryName.EnterColor = System.Drawing.Color.Empty;
            this.txtCountryName.LeaveColor = System.Drawing.Color.Empty;
            this.txtCountryName.Location = new System.Drawing.Point(145, 139);
            this.txtCountryName.MaxLength = 50;
            this.txtCountryName.Name = "txtCountryName";
            this.txtCountryName.Size = new System.Drawing.Size(201, 20);
            this.txtCountryName.TabIndex = 6;
            this.txtCountryName.TextChanged += new System.EventHandler(this.txtCountryName_TextChanged);
            this.txtCountryName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucDeleteAirPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCountryName);
            this.Controls.Add(this.rdoDelete);
            this.Controls.Add(this.rdoSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCountryAirport);
            this.Controls.Add(this.txtNameAirport);
            this.Controls.Add(this.txtCodeAirport);
            this.Controls.Add(this.lblCountryAirport);
            this.Controls.Add(this.lblNameAirport);
            this.Controls.Add(this.lblCodeAirport);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucDeleteAirPort";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDeleteAirPort_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyCTS.Forms.UI.SmartTextBox txtCountryAirport;
        private MyCTS.Forms.UI.SmartTextBox txtNameAirport;
        private MyCTS.Forms.UI.SmartTextBox txtCodeAirport;
        private System.Windows.Forms.Label lblCountryAirport;
        private System.Windows.Forms.Label lblNameAirport;
        private System.Windows.Forms.Label lblCodeAirport;
        private System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoSearch;
        private System.Windows.Forms.RadioButton rdoDelete;
        private System.Windows.Forms.Label label2;
        private MyCTS.Forms.UI.SmartTextBox txtCountryName;
    }
}
