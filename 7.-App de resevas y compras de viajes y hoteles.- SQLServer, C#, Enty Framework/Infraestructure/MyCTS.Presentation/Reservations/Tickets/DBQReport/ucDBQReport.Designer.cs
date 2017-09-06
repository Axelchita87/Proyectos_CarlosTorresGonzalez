namespace MyCTS.Presentation
{
    partial class ucDBQReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDBQReport));
            this.chkPrintReport = new System.Windows.Forms.CheckBox();
            this.chkFileReport = new System.Windows.Forms.CheckBox();
            this.picCalendar = new System.Windows.Forms.PictureBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.txtDate = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.chkmpd = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).BeginInit();
            this.SuspendLayout();
            // 
            // chkPrintReport
            // 
            this.chkPrintReport.AutoSize = true;
            this.chkPrintReport.Location = new System.Drawing.Point(37, 138);
            this.chkPrintReport.Name = "chkPrintReport";
            this.chkPrintReport.Size = new System.Drawing.Size(97, 17);
            this.chkPrintReport.TabIndex = 3;
            this.chkPrintReport.Text = "Imprimir reporte";
            this.chkPrintReport.UseVisualStyleBackColor = true;
            this.chkPrintReport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkFileReport
            // 
            this.chkFileReport.AutoSize = true;
            this.chkFileReport.Location = new System.Drawing.Point(37, 108);
            this.chkFileReport.Name = "chkFileReport";
            this.chkFileReport.Size = new System.Drawing.Size(117, 17);
            this.chkFileReport.TabIndex = 2;
            this.chkFileReport.Text = "Reporte en archivo";
            this.chkFileReport.UseVisualStyleBackColor = true;
            this.chkFileReport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // picCalendar
            // 
            this.picCalendar.BackColor = System.Drawing.Color.Transparent;
            this.picCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCalendar.Image = ((System.Drawing.Image)(resources.GetObject("picCalendar.Image")));
            this.picCalendar.Location = new System.Drawing.Point(216, 41);
            this.picCalendar.Name = "picCalendar";
            this.picCalendar.Size = new System.Drawing.Size(20, 18);
            this.picCalendar.TabIndex = 68;
            this.picCalendar.TabStop = false;
            this.picCalendar.Click += new System.EventHandler(this.picCalendar_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.monthCalendar1.Location = new System.Drawing.Point(166, 66);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 67;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            this.monthCalendar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.monthCalendar1_KeyDown);
            this.monthCalendar1.Leave += new System.EventHandler(this.monthCalendar1_Leave);
            // 
            // txtDate
            // 
            this.txtDate.AllowBlankSpaces = false;
            this.txtDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDate.CharsIncluded = new char[] {
        '.'};
            this.txtDate.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtDate.CustomExpression = ".*";
            this.txtDate.EnterColor = System.Drawing.Color.Empty;
            this.txtDate.LeaveColor = System.Drawing.Color.Empty;
            this.txtDate.Location = new System.Drawing.Point(134, 41);
            this.txtDate.MaxLength = 7;
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(76, 20);
            this.txtDate.TabIndex = 1;
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            this.txtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblDate.Location = new System.Drawing.Point(35, 48);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(93, 13);
            this.lblDate.TabIndex = 11;
            this.lblDate.Text = "Fecha del reporte:";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(277, 233);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
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
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Emisión de Reporte DQB";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkmpd
            // 
            this.chkmpd.AutoSize = true;
            this.chkmpd.Location = new System.Drawing.Point(37, 81);
            this.chkmpd.Name = "chkmpd";
            this.chkmpd.Size = new System.Drawing.Size(76, 17);
            this.chkmpd.TabIndex = 72;
            this.chkmpd.Text = "DQB EMD";
            this.chkmpd.UseVisualStyleBackColor = true;
            // 
            // ucDBQReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chkmpd);
            this.Controls.Add(this.chkPrintReport);
            this.Controls.Add(this.chkFileReport);
            this.Controls.Add(this.picCalendar);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucDBQReport";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDBQReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkPrintReport;
        private System.Windows.Forms.CheckBox chkFileReport;
        internal System.Windows.Forms.PictureBox picCalendar;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private Forms.UI.SmartTextBox txtDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBox chkmpd;

    }
}
