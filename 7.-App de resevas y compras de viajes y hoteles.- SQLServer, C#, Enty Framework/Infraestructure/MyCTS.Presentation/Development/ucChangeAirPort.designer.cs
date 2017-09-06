namespace MyCTS.Presentation
{
    partial class ucChangeAirPort
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
            this.rdoUpdate = new System.Windows.Forms.RadioButton();
            this.rdoSearch = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCountryAirport = new MyCTS.Forms.UI.SmartTextBox();
            this.txtNameAirport = new MyCTS.Forms.UI.SmartTextBox();
            this.txtCodeAirport = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCountryAirport = new System.Windows.Forms.Label();
            this.lblNameAirport = new System.Windows.Forms.Label();
            this.lblCodeAirport = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCountryName = new MyCTS.Forms.UI.SmartTextBox();
            this.SuspendLayout();
            // 
            // rdoUpdate
            // 
            this.rdoUpdate.AutoSize = true;
            this.rdoUpdate.Location = new System.Drawing.Point(230, 34);
            this.rdoUpdate.Name = "rdoUpdate";
            this.rdoUpdate.Size = new System.Drawing.Size(68, 17);
            this.rdoUpdate.TabIndex = 13;
            this.rdoUpdate.TabStop = true;
            this.rdoUpdate.Text = "Modificar";
            this.rdoUpdate.UseVisualStyleBackColor = true;
            this.rdoUpdate.CheckedChanged += new System.EventHandler(this.rdoUpdate_CheckedChanged);
            this.rdoUpdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoSearch
            // 
            this.rdoSearch.AutoSize = true;
            this.rdoSearch.Location = new System.Drawing.Point(139, 34);
            this.rdoSearch.Name = "rdoSearch";
            this.rdoSearch.Size = new System.Drawing.Size(58, 17);
            this.rdoSearch.TabIndex = 12;
            this.rdoSearch.TabStop = true;
            this.rdoSearch.Text = "Buscar";
            this.rdoSearch.UseVisualStyleBackColor = true;
            this.rdoSearch.CheckedChanged += new System.EventHandler(this.rdoSearch_CheckedChanged);
            this.rdoSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "¿Que deseas hacer?";
            // 
            // txtCountryAirport
            // 
            this.txtCountryAirport.AllowBlankSpaces = true;
            this.txtCountryAirport.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCountryAirport.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtCountryAirport.CustomExpression = ".*";
            this.txtCountryAirport.EnterColor = System.Drawing.Color.Empty;
            this.txtCountryAirport.LeaveColor = System.Drawing.Color.Empty;
            this.txtCountryAirport.Location = new System.Drawing.Point(139, 121);
            this.txtCountryAirport.MaxLength = 2;
            this.txtCountryAirport.Name = "txtCountryAirport";
            this.txtCountryAirport.Size = new System.Drawing.Size(36, 20);
            this.txtCountryAirport.TabIndex = 16;
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
            this.txtNameAirport.Location = new System.Drawing.Point(139, 95);
            this.txtNameAirport.MaxLength = 50;
            this.txtNameAirport.Name = "txtNameAirport";
            this.txtNameAirport.Size = new System.Drawing.Size(201, 20);
            this.txtNameAirport.TabIndex = 15;
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
            this.txtCodeAirport.Location = new System.Drawing.Point(139, 69);
            this.txtCodeAirport.MaxLength = 3;
            this.txtCodeAirport.Name = "txtCodeAirport";
            this.txtCodeAirport.Size = new System.Drawing.Size(50, 20);
            this.txtCodeAirport.TabIndex = 14;
            this.txtCodeAirport.TextChanged += new System.EventHandler(this.txtCodeAirport_TextChanged);
            this.txtCodeAirport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCountryAirport
            // 
            this.lblCountryAirport.AutoSize = true;
            this.lblCountryAirport.Location = new System.Drawing.Point(12, 126);
            this.lblCountryAirport.Name = "lblCountryAirport";
            this.lblCountryAirport.Size = new System.Drawing.Size(113, 13);
            this.lblCountryAirport.TabIndex = 9;
            this.lblCountryAirport.Text = "Aeropuerto por Ciudad";
            // 
            // lblNameAirport
            // 
            this.lblNameAirport.AutoSize = true;
            this.lblNameAirport.Location = new System.Drawing.Point(12, 99);
            this.lblNameAirport.Name = "lblNameAirport";
            this.lblNameAirport.Size = new System.Drawing.Size(114, 13);
            this.lblNameAirport.TabIndex = 8;
            this.lblNameAirport.Text = "Nombre de Aeropuerto";
            // 
            // lblCodeAirport
            // 
            this.lblCodeAirport.AutoSize = true;
            this.lblCodeAirport.Location = new System.Drawing.Point(12, 72);
            this.lblCodeAirport.Name = "lblCodeAirport";
            this.lblCodeAirport.Size = new System.Drawing.Size(110, 13);
            this.lblCodeAirport.TabIndex = 7;
            this.lblCodeAirport.Text = "Código de Aeropuerto";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(240, 171);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 24);
            this.btnAccept.TabIndex = 17;
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
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Modificación de Aeropuerto";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 18;
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
            this.txtCountryName.Location = new System.Drawing.Point(139, 145);
            this.txtCountryName.MaxLength = 50;
            this.txtCountryName.Name = "txtCountryName";
            this.txtCountryName.Size = new System.Drawing.Size(201, 20);
            this.txtCountryName.TabIndex = 19;
            this.txtCountryName.TextChanged += new System.EventHandler(this.txtCountryName_TextChanged);
            this.txtCountryName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucChangeAirPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCountryName);
            this.Controls.Add(this.rdoUpdate);
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
            this.Name = "ucChangeAirPort";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucChangeAirPort_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoUpdate;
        private System.Windows.Forms.RadioButton rdoSearch;
        private System.Windows.Forms.Label label1;
        private MyCTS.Forms.UI.SmartTextBox txtCountryAirport;
        private MyCTS.Forms.UI.SmartTextBox txtNameAirport;
        private MyCTS.Forms.UI.SmartTextBox txtCodeAirport;
        private System.Windows.Forms.Label lblCountryAirport;
        private System.Windows.Forms.Label lblNameAirport;
        private System.Windows.Forms.Label lblCodeAirport;
        private System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private MyCTS.Forms.UI.SmartTextBox txtCountryName;
    }
}
