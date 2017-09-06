namespace MyCTS.Presentation
{
    partial class ucSpecialServicesInfo
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
            this.lblAirLine1 = new System.Windows.Forms.Label();
            this.txtAirline1 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblInformation1 = new System.Windows.Forms.Label();
            this.txtInformation1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtInformation2 = new MyCTS.Forms.UI.SmartTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAirline2 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAirline2 = new System.Windows.Forms.Label();
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
            this.lblTitle.Text = "Información de otros Servicios";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblAirLine1
            // 
            this.lblAirLine1.AutoSize = true;
            this.lblAirLine1.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblAirLine1.Location = new System.Drawing.Point(39, 46);
            this.lblAirLine1.Name = "lblAirLine1";
            this.lblAirLine1.Size = new System.Drawing.Size(62, 13);
            this.lblAirLine1.TabIndex = 0;
            this.lblAirLine1.Text = "Aereolínea:";
            // 
            // txtAirline1
            // 
            this.txtAirline1.AllowBlankSpaces = false;
            this.txtAirline1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirline1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirline1.CustomExpression = ".*";
            this.txtAirline1.EnterColor = System.Drawing.Color.Empty;
            this.txtAirline1.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirline1.Location = new System.Drawing.Point(42, 65);
            this.txtAirline1.MaxLength = 2;
            this.txtAirline1.Name = "txtAirline1";
            this.txtAirline1.Size = new System.Drawing.Size(25, 20);
            this.txtAirline1.TabIndex = 1;
            this.txtAirline1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtAirline1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblInformation1
            // 
            this.lblInformation1.AutoSize = true;
            this.lblInformation1.ForeColor = System.Drawing.Color.Black;
            this.lblInformation1.Location = new System.Drawing.Point(39, 100);
            this.lblInformation1.Name = "lblInformation1";
            this.lblInformation1.Size = new System.Drawing.Size(65, 13);
            this.lblInformation1.TabIndex = 0;
            this.lblInformation1.Text = "Información:";
            // 
            // txtInformation1
            // 
            this.txtInformation1.AllowBlankSpaces = true;
            this.txtInformation1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInformation1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtInformation1.CustomExpression = ".*";
            this.txtInformation1.EnterColor = System.Drawing.Color.Empty;
            this.txtInformation1.LeaveColor = System.Drawing.Color.Empty;
            this.txtInformation1.Location = new System.Drawing.Point(42, 116);
            this.txtInformation1.MaxLength = 50;
            this.txtInformation1.Name = "txtInformation1";
            this.txtInformation1.Size = new System.Drawing.Size(339, 20);
            this.txtInformation1.TabIndex = 2;
            this.txtInformation1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtInformation1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtInformation2
            // 
            this.txtInformation2.AllowBlankSpaces = true;
            this.txtInformation2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInformation2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtInformation2.CustomExpression = ".*";
            this.txtInformation2.EnterColor = System.Drawing.Color.Empty;
            this.txtInformation2.LeaveColor = System.Drawing.Color.Empty;
            this.txtInformation2.Location = new System.Drawing.Point(42, 233);
            this.txtInformation2.MaxLength = 50;
            this.txtInformation2.Name = "txtInformation2";
            this.txtInformation2.Size = new System.Drawing.Size(339, 20);
            this.txtInformation2.TabIndex = 4;
            this.txtInformation2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtInformation2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(39, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Información:";
            // 
            // txtAirline2
            // 
            this.txtAirline2.AllowBlankSpaces = false;
            this.txtAirline2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirline2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirline2.CustomExpression = ".*";
            this.txtAirline2.EnterColor = System.Drawing.Color.Empty;
            this.txtAirline2.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirline2.Location = new System.Drawing.Point(42, 182);
            this.txtAirline2.MaxLength = 2;
            this.txtAirline2.Name = "txtAirline2";
            this.txtAirline2.Size = new System.Drawing.Size(25, 20);
            this.txtAirline2.TabIndex = 3;
            this.txtAirline2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtAirline2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblAirline2
            // 
            this.lblAirline2.AutoSize = true;
            this.lblAirline2.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblAirline2.Location = new System.Drawing.Point(39, 163);
            this.lblAirline2.Name = "lblAirline2";
            this.lblAirline2.Size = new System.Drawing.Size(62, 13);
            this.lblAirline2.TabIndex = 0;
            this.lblAirline2.Text = "Aereolínea:";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(281, 288);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucSpecialServicesInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtInformation2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAirline2);
            this.Controls.Add(this.lblAirline2);
            this.Controls.Add(this.txtInformation1);
            this.Controls.Add(this.lblInformation1);
            this.Controls.Add(this.txtAirline1);
            this.Controls.Add(this.lblAirLine1);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucSpecialServicesInfo";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucSpecialServicesInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAirLine1;
        private MyCTS.Forms.UI.SmartTextBox txtAirline1;
        private System.Windows.Forms.Label lblInformation1;
        private MyCTS.Forms.UI.SmartTextBox txtInformation1;
        private MyCTS.Forms.UI.SmartTextBox txtInformation2;
        private System.Windows.Forms.Label label1;
        private MyCTS.Forms.UI.SmartTextBox txtAirline2;
        private System.Windows.Forms.Label lblAirline2;
        private System.Windows.Forms.Button btnAccept;
    }
}
