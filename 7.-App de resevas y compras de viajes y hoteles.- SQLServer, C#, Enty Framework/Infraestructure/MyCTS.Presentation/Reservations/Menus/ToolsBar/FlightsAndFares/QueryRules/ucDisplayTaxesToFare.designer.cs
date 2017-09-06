namespace MyCTS.Presentation
{
    partial class ucDisplayTaxesToFare
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
            this.txtLine = new MyCTS.Forms.UI.SmartTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAirline = new MyCTS.Forms.UI.SmartTextBox();
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
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Desplegar Impuestos de una Tarifa";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtLine
            // 
            this.txtLine.AllowBlankSpaces = false;
            this.txtLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLine.CharsIncluded = new char[0];
            this.txtLine.CharsNoIncluded = new char[0];
            this.txtLine.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtLine.CustomExpression = ".*";
            this.txtLine.EnterColor = System.Drawing.Color.Empty;
            this.txtLine.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine.Location = new System.Drawing.Point(146, 60);
            this.txtLine.MaxLength = 2;
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(35, 20);
            this.txtLine.TabIndex = 1;
            this.txtLine.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Línea de la Lista:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(54, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Aerolínea:";
            this.label2.Visible = false;
            // 
            // txtAirline
            // 
            this.txtAirline.AllowBlankSpaces = false;
            this.txtAirline.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirline.CharsIncluded = new char[0];
            this.txtAirline.CharsNoIncluded = new char[0];
            this.txtAirline.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirline.CustomExpression = ".*";
            this.txtAirline.EnterColor = System.Drawing.Color.Empty;
            this.txtAirline.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirline.Location = new System.Drawing.Point(146, 94);
            this.txtAirline.MaxLength = 2;
            this.txtAirline.Name = "txtAirline";
            this.txtAirline.Size = new System.Drawing.Size(35, 20);
            this.txtAirline.TabIndex = 2;
            this.txtAirline.Visible = false;
            this.txtAirline.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtAirline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(252, 142);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucDisplayTaxesToFare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAirline);
            this.Controls.Add(this.txtLine);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucDisplayTaxesToFare";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDisplayTaxesToFare_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MyCTS.Forms.UI.SmartTextBox txtAirline;
        private System.Windows.Forms.Button btnAccept;
    }
}
