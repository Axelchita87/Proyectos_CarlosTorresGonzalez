namespace MyCTS.Presentation
{
    partial class ucPCC
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
            this.lblPCC = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.lbPCC = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cambiar  PCC";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Location = new System.Drawing.Point(42, 44);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(98, 13);
            this.lblPCC.TabIndex = 0;
            this.lblPCC.Text = "Selecciona el PCC:";
            this.lblPCC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(269, 138);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = true;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(42, 66);
            this.txtPCC.MaxLength = 3000;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(327, 20);
            this.txtPCC.TabIndex = 1;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lbPCC
            // 
            this.lbPCC.DisplayMember = "Text";
            this.lbPCC.FormattingEnabled = true;
            this.lbPCC.Location = new System.Drawing.Point(42, 84);
            this.lbPCC.Name = "lbPCC";
            this.lbPCC.Size = new System.Drawing.Size(327, 95);
            this.lbPCC.TabIndex = 3;
            this.lbPCC.ValueMember = "Value";
            this.lbPCC.Visible = false;
            this.lbPCC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbPCC_KeyDown);
            // 
            // ucPCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtPCC);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblPCC);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lbPCC);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucPCC";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucPCC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPCC;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private System.Windows.Forms.ListBox lbPCC;

    }
}
