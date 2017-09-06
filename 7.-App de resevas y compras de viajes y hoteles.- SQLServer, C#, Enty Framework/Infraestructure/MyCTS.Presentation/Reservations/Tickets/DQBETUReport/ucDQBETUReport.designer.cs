namespace MyCTS.Presentation
{
    partial class ucDQBETUReport
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
            this.txtDateBegin = new MyCTS.Forms.UI.SmartTextBox();
            this.txtDateEnd = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDel = new System.Windows.Forms.Label();
            this.lblAl = new System.Windows.Forms.Label();
            this.txtReportByDK = new MyCTS.Forms.UI.SmartTextBox();
            this.txtReportbyAirline = new MyCTS.Forms.UI.SmartTextBox();
            this.chkGenerateExcel = new System.Windows.Forms.CheckBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.chkreportByDate = new System.Windows.Forms.CheckBox();
            this.chkPeportByDK = new System.Windows.Forms.CheckBox();
            this.chkReportByAirline = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
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
            this.lblTitle.Text = "Reporte Boletos no Utilizados";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDateBegin
            // 
            this.txtDateBegin.AllowBlankSpaces = false;
            this.txtDateBegin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDateBegin.CharsIncluded = new char[] {
        '.'};
            this.txtDateBegin.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtDateBegin.CustomExpression = ".*";
            this.txtDateBegin.EnterColor = System.Drawing.Color.Empty;
            this.txtDateBegin.LeaveColor = System.Drawing.Color.Empty;
            this.txtDateBegin.Location = new System.Drawing.Point(183, 47);
            this.txtDateBegin.MaxLength = 5;
            this.txtDateBegin.Name = "txtDateBegin";
            this.txtDateBegin.Size = new System.Drawing.Size(52, 20);
            this.txtDateBegin.TabIndex = 2;
            this.txtDateBegin.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            this.txtDateBegin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.AllowBlankSpaces = false;
            this.txtDateEnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDateEnd.CharsIncluded = new char[] {
        '.'};
            this.txtDateEnd.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtDateEnd.CustomExpression = ".*";
            this.txtDateEnd.EnterColor = System.Drawing.Color.Empty;
            this.txtDateEnd.LeaveColor = System.Drawing.Color.Empty;
            this.txtDateEnd.Location = new System.Drawing.Point(261, 47);
            this.txtDateEnd.MaxLength = 5;
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.Size = new System.Drawing.Size(52, 20);
            this.txtDateEnd.TabIndex = 3;
            this.txtDateEnd.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            this.txtDateEnd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblDel
            // 
            this.lblDel.AutoSize = true;
            this.lblDel.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblDel.Location = new System.Drawing.Point(154, 50);
            this.lblDel.Name = "lblDel";
            this.lblDel.Size = new System.Drawing.Size(23, 13);
            this.lblDel.TabIndex = 0;
            this.lblDel.Text = "Del";
            // 
            // lblAl
            // 
            this.lblAl.AutoSize = true;
            this.lblAl.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblAl.Location = new System.Drawing.Point(238, 50);
            this.lblAl.Name = "lblAl";
            this.lblAl.Size = new System.Drawing.Size(15, 13);
            this.lblAl.TabIndex = 0;
            this.lblAl.Text = "al";
            // 
            // txtReportByDK
            // 
            this.txtReportByDK.AllowBlankSpaces = false;
            this.txtReportByDK.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReportByDK.CharsIncluded = new char[] {
        '.'};
            this.txtReportByDK.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtReportByDK.CustomExpression = ".*";
            this.txtReportByDK.EnterColor = System.Drawing.Color.Empty;
            this.txtReportByDK.LeaveColor = System.Drawing.Color.Empty;
            this.txtReportByDK.Location = new System.Drawing.Point(157, 104);
            this.txtReportByDK.MaxLength = 6;
            this.txtReportByDK.Name = "txtReportByDK";
            this.txtReportByDK.Size = new System.Drawing.Size(58, 20);
            this.txtReportByDK.TabIndex = 5;
            this.txtReportByDK.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            this.txtReportByDK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtReportbyAirline
            // 
            this.txtReportbyAirline.AllowBlankSpaces = false;
            this.txtReportbyAirline.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReportbyAirline.CharsIncluded = new char[] {
        '.'};
            this.txtReportbyAirline.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtReportbyAirline.CustomExpression = ".*";
            this.txtReportbyAirline.EnterColor = System.Drawing.Color.Empty;
            this.txtReportbyAirline.LeaveColor = System.Drawing.Color.Empty;
            this.txtReportbyAirline.Location = new System.Drawing.Point(157, 161);
            this.txtReportbyAirline.MaxLength = 2;
            this.txtReportbyAirline.Name = "txtReportbyAirline";
            this.txtReportbyAirline.Size = new System.Drawing.Size(30, 20);
            this.txtReportbyAirline.TabIndex = 7;
            this.txtReportbyAirline.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            this.txtReportbyAirline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkGenerateExcel
            // 
            this.chkGenerateExcel.AutoSize = true;
            this.chkGenerateExcel.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkGenerateExcel.Location = new System.Drawing.Point(13, 211);
            this.chkGenerateExcel.Name = "chkGenerateExcel";
            this.chkGenerateExcel.Size = new System.Drawing.Size(132, 17);
            this.chkGenerateExcel.TabIndex = 8;
            this.chkGenerateExcel.Text = "Generar Archivo Excel";
            this.chkGenerateExcel.UseVisualStyleBackColor = true;
            this.chkGenerateExcel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(282, 301);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 9;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // chkreportByDate
            // 
            this.chkreportByDate.AutoSize = true;
            this.chkreportByDate.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkreportByDate.Location = new System.Drawing.Point(13, 49);
            this.chkreportByDate.Name = "chkreportByDate";
            this.chkreportByDate.Size = new System.Drawing.Size(115, 17);
            this.chkreportByDate.TabIndex = 1;
            this.chkreportByDate.Text = "Reporte por fecha:";
            this.chkreportByDate.UseVisualStyleBackColor = true;
            this.chkreportByDate.CheckedChanged += new System.EventHandler(this.chkreportByDate_CheckedChanged);
            this.chkreportByDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkPeportByDK
            // 
            this.chkPeportByDK.AutoSize = true;
            this.chkPeportByDK.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkPeportByDK.Location = new System.Drawing.Point(13, 106);
            this.chkPeportByDK.Name = "chkPeportByDK";
            this.chkPeportByDK.Size = new System.Drawing.Size(103, 17);
            this.chkPeportByDK.TabIndex = 4;
            this.chkPeportByDK.Text = "Reporte por DK:";
            this.chkPeportByDK.UseVisualStyleBackColor = true;
            this.chkPeportByDK.CheckedChanged += new System.EventHandler(this.chkPeportByDK_CheckedChanged);
            this.chkPeportByDK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkReportByAirline
            // 
            this.chkReportByAirline.AutoSize = true;
            this.chkReportByAirline.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkReportByAirline.Location = new System.Drawing.Point(13, 163);
            this.chkReportByAirline.Name = "chkReportByAirline";
            this.chkReportByAirline.Size = new System.Drawing.Size(138, 17);
            this.chkReportByAirline.TabIndex = 6;
            this.chkReportByAirline.Text = "Reporte por Aereolinea:";
            this.chkReportByAirline.UseVisualStyleBackColor = true;
            this.chkReportByAirline.CheckedChanged += new System.EventHandler(this.chkReportByAirline_CheckedChanged);
            this.chkReportByAirline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // progressBar1
            // 
            this.progressBar1.AccessibleDescription = "";
            this.progressBar1.AccessibleName = "";
            this.progressBar1.BackColor = System.Drawing.Color.LightGray;
            this.progressBar1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.progressBar1.Location = new System.Drawing.Point(12, 423);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(386, 22);
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Visible = false;
            // 
            // ucDQBETUReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chkReportByAirline);
            this.Controls.Add(this.chkPeportByDK);
            this.Controls.Add(this.chkreportByDate);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.chkGenerateExcel);
            this.Controls.Add(this.txtReportbyAirline);
            this.Controls.Add(this.txtReportByDK);
            this.Controls.Add(this.lblAl);
            this.Controls.Add(this.lblDel);
            this.Controls.Add(this.txtDateEnd);
            this.Controls.Add(this.txtDateBegin);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucDQBETUReport";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDQBETUReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtDateBegin;
        private MyCTS.Forms.UI.SmartTextBox txtDateEnd;
        private System.Windows.Forms.Label lblDel;
        private System.Windows.Forms.Label lblAl;
        private MyCTS.Forms.UI.SmartTextBox txtReportByDK;
        private MyCTS.Forms.UI.SmartTextBox txtReportbyAirline;
        private System.Windows.Forms.CheckBox chkGenerateExcel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.CheckBox chkreportByDate;
        private System.Windows.Forms.CheckBox chkPeportByDK;
        private System.Windows.Forms.CheckBox chkReportByAirline;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
