namespace MyCTS.Presentation
{
    partial class ucRenameProfile
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblStar2Name = new System.Windows.Forms.Label();
            this.txtStar2Name = new MyCTS.Forms.UI.SmartTextBox();
            this.lblStar1Name = new System.Windows.Forms.Label();
            this.txtStar1name = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPCC = new System.Windows.Forms.Label();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.Location = new System.Drawing.Point(263, 131);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 25);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Renombrar";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblStar2Name
            // 
            this.lblStar2Name.AutoSize = true;
            this.lblStar2Name.Location = new System.Drawing.Point(25, 99);
            this.lblStar2Name.Name = "lblStar2Name";
            this.lblStar2Name.Size = new System.Drawing.Size(80, 13);
            this.lblStar2Name.TabIndex = 0;
            this.lblStar2Name.Text = "Segundo Nivel:";
            // 
            // txtStar2Name
            // 
            this.txtStar2Name.AllowBlankSpaces = false;
            this.txtStar2Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStar2Name.CharsIncluded = new char[] {
        '/'};
            this.txtStar2Name.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtStar2Name.CustomExpression = ".*";
            this.txtStar2Name.EnterColor = System.Drawing.Color.Empty;
            this.txtStar2Name.LeaveColor = System.Drawing.Color.Empty;
            this.txtStar2Name.Location = new System.Drawing.Point(110, 96);
            this.txtStar2Name.MaxLength = 50;
            this.txtStar2Name.Name = "txtStar2Name";
            this.txtStar2Name.Size = new System.Drawing.Size(154, 20);
            this.txtStar2Name.TabIndex = 2;
            this.txtStar2Name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControls_KeyDown);
            // 
            // lblStar1Name
            // 
            this.lblStar1Name.AutoSize = true;
            this.lblStar1Name.Location = new System.Drawing.Point(25, 76);
            this.lblStar1Name.Name = "lblStar1Name";
            this.lblStar1Name.Size = new System.Drawing.Size(66, 13);
            this.lblStar1Name.TabIndex = 0;
            this.lblStar1Name.Text = "Primer Nivel:";
            // 
            // txtStar1name
            // 
            this.txtStar1name.AllowBlankSpaces = true;
            this.txtStar1name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStar1name.CharsIncluded = new char[] {
        '\0'};
            this.txtStar1name.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtStar1name.CustomExpression = ".*";
            this.txtStar1name.EnterColor = System.Drawing.Color.Empty;
            this.txtStar1name.LeaveColor = System.Drawing.Color.Empty;
            this.txtStar1name.Location = new System.Drawing.Point(110, 73);
            this.txtStar1name.MaxLength = 50;
            this.txtStar1name.Name = "txtStar1name";
            this.txtStar1name.Size = new System.Drawing.Size(154, 20);
            this.txtStar1name.TabIndex = 2;
            this.txtStar1name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControls_KeyDown);
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Location = new System.Drawing.Point(25, 51);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(31, 13);
            this.lblPCC.TabIndex = 0;
            this.lblPCC.Text = "PCC:";
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = false;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(110, 47);
            this.txtPCC.MaxLength = 30;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(154, 20);
            this.txtPCC.TabIndex = 1;
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControls_KeyDown);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.Blue;
            this.lblDescription.Location = new System.Drawing.Point(25, 25);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(209, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Ingresa el Nuevo Nombre de la Estrella de ";
            // 
            // ucRenameProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblStar2Name);
            this.Controls.Add(this.txtStar2Name);
            this.Controls.Add(this.lblStar1Name);
            this.Controls.Add(this.txtStar1name);
            this.Controls.Add(this.lblPCC);
            this.Controls.Add(this.txtPCC);
            this.Controls.Add(this.lblDescription);
            this.Name = "ucRenameProfile";
            this.Size = new System.Drawing.Size(492, 298);
            this.Load += new System.EventHandler(this.ucRenameProfile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblStar2Name;
        private MyCTS.Forms.UI.SmartTextBox txtStar2Name;
        private System.Windows.Forms.Label lblStar1Name;
        private MyCTS.Forms.UI.SmartTextBox txtStar1name;
        private System.Windows.Forms.Label lblPCC;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private System.Windows.Forms.Label lblDescription;
    }
}
