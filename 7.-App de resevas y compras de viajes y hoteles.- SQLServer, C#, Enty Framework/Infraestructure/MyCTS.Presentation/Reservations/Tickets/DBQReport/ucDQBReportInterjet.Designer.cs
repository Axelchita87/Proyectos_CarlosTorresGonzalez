﻿namespace MyCTS.Presentation
{
    partial class ucDQBReportInterjet
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.chkPrintReport = new System.Windows.Forms.CheckBox();
            this.chkFileReport = new System.Windows.Forms.CheckBox();
            this.picCalendar = new System.Windows.Forms.PictureBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtDate = new MyCTS.Forms.UI.SmartTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 302);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(314, 257);
            this.dataGridView1.TabIndex = 85;
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
            this.lblTitle.TabIndex = 84;
            this.lblTitle.Text = "Emisión de Reporte DQB";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkPrintReport
            // 
            this.chkPrintReport.AutoSize = true;
            this.chkPrintReport.Location = new System.Drawing.Point(26, 145);
            this.chkPrintReport.Name = "chkPrintReport";
            this.chkPrintReport.Size = new System.Drawing.Size(116, 17);
            this.chkPrintReport.TabIndex = 79;
            this.chkPrintReport.Text = "Mostrar en pantalla";
            this.chkPrintReport.UseVisualStyleBackColor = true;
            // 
            // chkFileReport
            // 
            this.chkFileReport.AutoSize = true;
            this.chkFileReport.Location = new System.Drawing.Point(26, 111);
            this.chkFileReport.Name = "chkFileReport";
            this.chkFileReport.Size = new System.Drawing.Size(117, 17);
            this.chkFileReport.TabIndex = 78;
            this.chkFileReport.Text = "Reporte en archivo";
            this.chkFileReport.UseVisualStyleBackColor = true;
            // 
            // picCalendar
            // 
            this.picCalendar.BackColor = System.Drawing.Color.Transparent;
            this.picCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCalendar.Image = global::MyCTS.Presentation.Properties.Resources.calendario;
            this.picCalendar.Location = new System.Drawing.Point(205, 48);
            this.picCalendar.Name = "picCalendar";
            this.picCalendar.Size = new System.Drawing.Size(20, 18);
            this.picCalendar.TabIndex = 83;
            this.picCalendar.TabStop = false;
            this.picCalendar.Click += new System.EventHandler(this.picCalendar_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.monthCalendar1.Location = new System.Drawing.Point(155, 73);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 82;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            this.monthCalendar1.Leave += new System.EventHandler(this.monthCalendar1_Leave);
            this.monthCalendar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.monthCalendar1_KeyDown);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblDate.Location = new System.Drawing.Point(24, 55);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(93, 13);
            this.lblDate.TabIndex = 81;
            this.lblDate.Text = "Fecha del reporte:";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(266, 240);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 80;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
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
            this.txtDate.Location = new System.Drawing.Point(123, 46);
            this.txtDate.MaxLength = 7;
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(76, 20);
            this.txtDate.TabIndex = 86;
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            this.txtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDate_KeyDown);
            // 
            // ucDQBReportInterjet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.chkPrintReport);
            this.Controls.Add(this.chkFileReport);
            this.Controls.Add(this.picCalendar);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnAccept);
            this.Name = "ucDQBReportInterjet";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDQBReportInterjet_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucDQBReportInterjet_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBox chkPrintReport;
        private System.Windows.Forms.CheckBox chkFileReport;
        internal System.Windows.Forms.PictureBox picCalendar;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtDate;

    }
}