namespace MyCTS.Presentation
{
    partial class ucDecreasesIncreases
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
            this.lblRecreasesNumberPax = new System.Windows.Forms.Label();
            this.lblChangePaxNumber = new System.Windows.Forms.Label();
            this.txtRecreases1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRecreases2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRecreases3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRecreases4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtChangePaxNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(217, 254);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 27);
            this.btnAccept.TabIndex = 15;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblRecreasesNumberPax
            // 
            this.lblRecreasesNumberPax.AutoSize = true;
            this.lblRecreasesNumberPax.BackColor = System.Drawing.Color.White;
            this.lblRecreasesNumberPax.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblRecreasesNumberPax.Location = new System.Drawing.Point(37, 99);
            this.lblRecreasesNumberPax.Name = "lblRecreasesNumberPax";
            this.lblRecreasesNumberPax.Size = new System.Drawing.Size(257, 13);
            this.lblRecreasesNumberPax.TabIndex = 8;
            this.lblRecreasesNumberPax.Text = "Solo si Reduces Pax, números de nombre a eliminar  ";
            this.lblRecreasesNumberPax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChangePaxNumber
            // 
            this.lblChangePaxNumber.AutoSize = true;
            this.lblChangePaxNumber.Location = new System.Drawing.Point(37, 53);
            this.lblChangePaxNumber.Name = "lblChangePaxNumber";
            this.lblChangePaxNumber.Size = new System.Drawing.Size(130, 13);
            this.lblChangePaxNumber.TabIndex = 7;
            this.lblChangePaxNumber.Text = "Cambia Numero de Pax a:";
            this.lblChangePaxNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRecreases1
            // 
            this.txtRecreases1.AllowBlankSpaces = true;
            this.txtRecreases1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRecreases1.CharsIncluded = new char[] {
        '.'};
            this.txtRecreases1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRecreases1.CustomExpression = ".*";
            this.txtRecreases1.EnterColor = System.Drawing.Color.Empty;
            this.txtRecreases1.LeaveColor = System.Drawing.Color.Empty;
            this.txtRecreases1.Location = new System.Drawing.Point(75, 134);
            this.txtRecreases1.MaxLength = 4;
            this.txtRecreases1.Name = "txtRecreases1";
            this.txtRecreases1.Size = new System.Drawing.Size(52, 20);
            this.txtRecreases1.TabIndex = 11;
            this.txtRecreases1.TextChanged += new System.EventHandler(this.txtRecreases1_TextChanged);
            this.txtRecreases1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRecreases2
            // 
            this.txtRecreases2.AllowBlankSpaces = true;
            this.txtRecreases2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRecreases2.CharsIncluded = new char[] {
        '.'};
            this.txtRecreases2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRecreases2.CustomExpression = ".*";
            this.txtRecreases2.EnterColor = System.Drawing.Color.Empty;
            this.txtRecreases2.LeaveColor = System.Drawing.Color.Empty;
            this.txtRecreases2.Location = new System.Drawing.Point(75, 160);
            this.txtRecreases2.MaxLength = 4;
            this.txtRecreases2.Name = "txtRecreases2";
            this.txtRecreases2.Size = new System.Drawing.Size(52, 20);
            this.txtRecreases2.TabIndex = 12;
            this.txtRecreases2.TextChanged += new System.EventHandler(this.txtRecreases2_TextChanged);
            this.txtRecreases2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRecreases3
            // 
            this.txtRecreases3.AllowBlankSpaces = true;
            this.txtRecreases3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRecreases3.CharsIncluded = new char[] {
        '.'};
            this.txtRecreases3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRecreases3.CustomExpression = ".*";
            this.txtRecreases3.EnterColor = System.Drawing.Color.Empty;
            this.txtRecreases3.LeaveColor = System.Drawing.Color.Empty;
            this.txtRecreases3.Location = new System.Drawing.Point(75, 186);
            this.txtRecreases3.MaxLength = 4;
            this.txtRecreases3.Name = "txtRecreases3";
            this.txtRecreases3.Size = new System.Drawing.Size(52, 20);
            this.txtRecreases3.TabIndex = 13;
            this.txtRecreases3.TextChanged += new System.EventHandler(this.txtRecreases3_TextChanged);
            this.txtRecreases3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRecreases4
            // 
            this.txtRecreases4.AllowBlankSpaces = true;
            this.txtRecreases4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRecreases4.CharsIncluded = new char[] {
        '.'};
            this.txtRecreases4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRecreases4.CustomExpression = ".*";
            this.txtRecreases4.EnterColor = System.Drawing.Color.Empty;
            this.txtRecreases4.LeaveColor = System.Drawing.Color.Empty;
            this.txtRecreases4.Location = new System.Drawing.Point(75, 212);
            this.txtRecreases4.MaxLength = 4;
            this.txtRecreases4.Name = "txtRecreases4";
            this.txtRecreases4.Size = new System.Drawing.Size(52, 20);
            this.txtRecreases4.TabIndex = 14;
            this.txtRecreases4.TextChanged += new System.EventHandler(this.txtRecreases4_TextChanged);
            this.txtRecreases4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtChangePaxNumber
            // 
            this.txtChangePaxNumber.AllowBlankSpaces = true;
            this.txtChangePaxNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtChangePaxNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtChangePaxNumber.CustomExpression = ".*";
            this.txtChangePaxNumber.EnterColor = System.Drawing.Color.Empty;
            this.txtChangePaxNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtChangePaxNumber.Location = new System.Drawing.Point(173, 50);
            this.txtChangePaxNumber.MaxLength = 1;
            this.txtChangePaxNumber.Name = "txtChangePaxNumber";
            this.txtChangePaxNumber.Size = new System.Drawing.Size(31, 20);
            this.txtChangePaxNumber.TabIndex = 10;
            this.txtChangePaxNumber.TextChanged += new System.EventHandler(this.txtChangePaxNumber_TextChanged);
            this.txtChangePaxNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 15);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Reduce o Aumenta Pasajeros";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ucDecreasesIncreases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblRecreasesNumberPax);
            this.Controls.Add(this.lblChangePaxNumber);
            this.Controls.Add(this.txtRecreases1);
            this.Controls.Add(this.txtRecreases2);
            this.Controls.Add(this.txtRecreases3);
            this.Controls.Add(this.txtRecreases4);
            this.Controls.Add(this.txtChangePaxNumber);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucDecreasesIncreases";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDecreasesIncreases_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblRecreasesNumberPax;
        private System.Windows.Forms.Label lblChangePaxNumber;
        private MyCTS.Forms.UI.SmartTextBox txtRecreases1;
        private MyCTS.Forms.UI.SmartTextBox txtRecreases2;
        private MyCTS.Forms.UI.SmartTextBox txtRecreases3;
        private MyCTS.Forms.UI.SmartTextBox txtRecreases4;
        private MyCTS.Forms.UI.SmartTextBox txtChangePaxNumber;
        internal System.Windows.Forms.Label lblTitle;
    }
}
