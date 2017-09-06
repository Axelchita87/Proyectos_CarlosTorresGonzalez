namespace MyCTS.Presentation
{
    partial class ucDisplayHistoricRules
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
            this.txtOrigin = new MyCTS.Forms.UI.SmartTextBox();
            this.txtDestino = new MyCTS.Forms.UI.SmartTextBox();
            this.txtDateDeparture = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAirline = new MyCTS.Forms.UI.SmartTextBox();
            this.txtFareBasis = new MyCTS.Forms.UI.SmartTextBox();
            this.lblOrigin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDateBoletage = new MyCTS.Forms.UI.SmartTextBox();
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
            this.lblTitle.TabIndex = 28;
            this.lblTitle.Text = "Desplegar Reglas por Categorías";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtOrigin
            // 
            this.txtOrigin.AllowBlankSpaces = false;
            this.txtOrigin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrigin.CharsIncluded = new char[0];
            this.txtOrigin.CharsNoIncluded = new char[0];
            this.txtOrigin.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtOrigin.CustomExpression = ".*";
            this.txtOrigin.EnterColor = System.Drawing.Color.Empty;
            this.txtOrigin.LeaveColor = System.Drawing.Color.Empty;
            this.txtOrigin.Location = new System.Drawing.Point(140, 62);
            this.txtOrigin.MaxLength = 3;
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.Size = new System.Drawing.Size(59, 20);
            this.txtOrigin.TabIndex = 1;
            this.txtOrigin.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtOrigin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtDestino
            // 
            this.txtDestino.AllowBlankSpaces = false;
            this.txtDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDestino.CharsIncluded = new char[0];
            this.txtDestino.CharsNoIncluded = new char[0];
            this.txtDestino.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtDestino.CustomExpression = ".*";
            this.txtDestino.EnterColor = System.Drawing.Color.Empty;
            this.txtDestino.LeaveColor = System.Drawing.Color.Empty;
            this.txtDestino.Location = new System.Drawing.Point(140, 88);
            this.txtDestino.MaxLength = 3;
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(59, 20);
            this.txtDestino.TabIndex = 2;
            this.txtDestino.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtDestino.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtDateDeparture
            // 
            this.txtDateDeparture.AllowBlankSpaces = false;
            this.txtDateDeparture.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDateDeparture.CharsIncluded = new char[0];
            this.txtDateDeparture.CharsNoIncluded = new char[0];
            this.txtDateDeparture.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtDateDeparture.CustomExpression = ".*";
            this.txtDateDeparture.EnterColor = System.Drawing.Color.Empty;
            this.txtDateDeparture.LeaveColor = System.Drawing.Color.Empty;
            this.txtDateDeparture.Location = new System.Drawing.Point(140, 140);
            this.txtDateDeparture.MaxLength = 7;
            this.txtDateDeparture.Name = "txtDateDeparture";
            this.txtDateDeparture.Size = new System.Drawing.Size(103, 20);
            this.txtDateDeparture.TabIndex = 4;
            this.txtDateDeparture.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtDateDeparture.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
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
            this.txtAirline.Location = new System.Drawing.Point(140, 166);
            this.txtAirline.MaxLength = 2;
            this.txtAirline.Name = "txtAirline";
            this.txtAirline.Size = new System.Drawing.Size(40, 20);
            this.txtAirline.TabIndex = 5;
            this.txtAirline.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtAirline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtFareBasis
            // 
            this.txtFareBasis.AllowBlankSpaces = false;
            this.txtFareBasis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFareBasis.CharsIncluded = new char[0];
            this.txtFareBasis.CharsNoIncluded = new char[0];
            this.txtFareBasis.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtFareBasis.CustomExpression = ".*";
            this.txtFareBasis.EnterColor = System.Drawing.Color.Empty;
            this.txtFareBasis.LeaveColor = System.Drawing.Color.Empty;
            this.txtFareBasis.Location = new System.Drawing.Point(140, 192);
            this.txtFareBasis.MaxLength = 15;
            this.txtFareBasis.Name = "txtFareBasis";
            this.txtFareBasis.Size = new System.Drawing.Size(150, 20);
            this.txtFareBasis.TabIndex = 6;
            this.txtFareBasis.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtFareBasis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblOrigin
            // 
            this.lblOrigin.AutoSize = true;
            this.lblOrigin.Location = new System.Drawing.Point(39, 65);
            this.lblOrigin.Name = "lblOrigin";
            this.lblOrigin.Size = new System.Drawing.Size(41, 13);
            this.lblOrigin.TabIndex = 29;
            this.lblOrigin.Text = "Origen:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Destino:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Fecha de Boletaje:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Fecha de Salida:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Aerolínea:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Fare Basis:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkCyan;
            this.label6.Location = new System.Drawing.Point(249, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "DDMMMYY";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DarkCyan;
            this.label7.Location = new System.Drawing.Point(249, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "DDMMMYY";
            // 
            // txtDateBoletage
            // 
            this.txtDateBoletage.AllowBlankSpaces = false;
            this.txtDateBoletage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDateBoletage.CharsIncluded = new char[0];
            this.txtDateBoletage.CharsNoIncluded = new char[0];
            this.txtDateBoletage.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtDateBoletage.CustomExpression = ".*";
            this.txtDateBoletage.EnterColor = System.Drawing.Color.Empty;
            this.txtDateBoletage.LeaveColor = System.Drawing.Color.Empty;
            this.txtDateBoletage.Location = new System.Drawing.Point(141, 114);
            this.txtDateBoletage.MaxLength = 7;
            this.txtDateBoletage.Name = "txtDateBoletage";
            this.txtDateBoletage.Size = new System.Drawing.Size(102, 20);
            this.txtDateBoletage.TabIndex = 3;
            this.txtDateBoletage.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtDateBoletage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(264, 248);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucDisplayHistoricRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOrigin);
            this.Controls.Add(this.txtFareBasis);
            this.Controls.Add(this.txtAirline);
            this.Controls.Add(this.txtDateDeparture);
            this.Controls.Add(this.txtDateBoletage);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.txtOrigin);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucDisplayHistoricRules";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDisplayHistoricRules_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtOrigin;
        private MyCTS.Forms.UI.SmartTextBox txtDestino;
        private MyCTS.Forms.UI.SmartTextBox txtDateDeparture;
        private MyCTS.Forms.UI.SmartTextBox txtAirline;
        private MyCTS.Forms.UI.SmartTextBox txtFareBasis;
        private System.Windows.Forms.Label lblOrigin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private MyCTS.Forms.UI.SmartTextBox txtDateBoletage;
        private System.Windows.Forms.Button btnAccept;
    }
}
