namespace MyCTS.Presentation
{
    partial class ucAddProfileInfo
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblStar1Name = new System.Windows.Forms.Label();
            this.txtDescription = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPCC = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmbLineType = new System.Windows.Forms.ComboBox();
            this.btnAddCross = new System.Windows.Forms.Button();
            this.btnAddChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.ForeColor = System.Drawing.Color.Black;
            this.btnAccept.Location = new System.Drawing.Point(351, 150);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 25);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblStar1Name
            // 
            this.lblStar1Name.AutoSize = true;
            this.lblStar1Name.Location = new System.Drawing.Point(11, 96);
            this.lblStar1Name.Name = "lblStar1Name";
            this.lblStar1Name.Size = new System.Drawing.Size(66, 13);
            this.lblStar1Name.TabIndex = 0;
            this.lblStar1Name.Text = "Descripción:";
            // 
            // txtDescription
            // 
            this.txtDescription.AllowBlankSpaces = true;
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.CharsIncluded = new char[] {
        '*',
        ':',
        ',',
        '-',
        '.',
        '/',
        '@',
        '/',
        '‡'};
            this.txtDescription.CharsNoIncluded = new char[] {
        'Ñ'};
            this.txtDescription.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtDescription.CustomExpression = ".*";
            this.txtDescription.EnterColor = System.Drawing.Color.Empty;
            this.txtDescription.LeaveColor = System.Drawing.Color.Empty;
            this.txtDescription.Location = new System.Drawing.Point(14, 112);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(437, 20);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControls_KeyDown);
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Location = new System.Drawing.Point(11, 48);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(71, 13);
            this.lblPCC.TabIndex = 0;
            this.lblPCC.Text = "Tipo de linea:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.Blue;
            this.lblDescription.Location = new System.Drawing.Point(11, 22);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(160, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Ingresa la información solicitada:";
            // 
            // cmbLineType
            // 
            this.cmbLineType.DisplayMember = "Text";
            this.cmbLineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLineType.FormattingEnabled = true;
            this.cmbLineType.Location = new System.Drawing.Point(14, 64);
            this.cmbLineType.Name = "cmbLineType";
            this.cmbLineType.Size = new System.Drawing.Size(217, 21);
            this.cmbLineType.TabIndex = 1;
            this.cmbLineType.ValueMember = "Value";
            this.cmbLineType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControls_KeyDown);
            // 
            // btnAddCross
            // 
            this.btnAddCross.BackColor = System.Drawing.Color.BlueViolet;
            this.btnAddCross.ForeColor = System.Drawing.Color.White;
            this.btnAddCross.Location = new System.Drawing.Point(104, 150);
            this.btnAddCross.Name = "btnAddCross";
            this.btnAddCross.Size = new System.Drawing.Size(75, 23);
            this.btnAddCross.TabIndex = 4;
            this.btnAddCross.Text = "Agrega ‡";
            this.btnAddCross.UseVisualStyleBackColor = false;
            this.btnAddCross.Click += new System.EventHandler(this.btnAddCross_Click);
            // 
            // btnAddChange
            // 
            this.btnAddChange.BackColor = System.Drawing.Color.Crimson;
            this.btnAddChange.ForeColor = System.Drawing.Color.White;
            this.btnAddChange.Location = new System.Drawing.Point(23, 150);
            this.btnAddChange.Name = "btnAddChange";
            this.btnAddChange.Size = new System.Drawing.Size(75, 23);
            this.btnAddChange.TabIndex = 3;
            this.btnAddChange.Text = "Agrega ¤";
            this.btnAddChange.UseVisualStyleBackColor = false;
            this.btnAddChange.Click += new System.EventHandler(this.btnAddChange_Click);
            // 
            // ucAddProfileInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.btnAddCross);
            this.Controls.Add(this.btnAddChange);
            this.Controls.Add(this.cmbLineType);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblStar1Name);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblPCC);
            this.Controls.Add(this.lblDescription);
            this.Name = "ucAddProfileInfo";
            this.Size = new System.Drawing.Size(492, 298);
            this.Load += new System.EventHandler(this.ucAddProfileInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblStar1Name;
        private MyCTS.Forms.UI.SmartTextBox txtDescription;
        private System.Windows.Forms.Label lblPCC;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ComboBox cmbLineType;
        private System.Windows.Forms.Button btnAddCross;
        private System.Windows.Forms.Button btnAddChange;
    }
}
