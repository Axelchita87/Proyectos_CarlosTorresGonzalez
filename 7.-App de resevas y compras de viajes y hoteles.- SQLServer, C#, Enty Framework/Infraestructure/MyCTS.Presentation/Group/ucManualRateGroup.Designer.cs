namespace MyCTS.Presentation
{

    partial class ucManualRateGroup
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
            this.tblLayout1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtManualRate = new MyCTS.Forms.UI.SmartTextBox();
            this.lblManualRate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.tblLayout1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayout1
            // 
            this.tblLayout1.AutoScroll = true;
            this.tblLayout1.BackColor = System.Drawing.Color.White;
            this.tblLayout1.ColumnCount = 4;
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.72181F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.27819F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 203F));
            this.tblLayout1.Controls.Add(this.txtManualRate, 1, 3);
            this.tblLayout1.Controls.Add(this.lblManualRate, 1, 2);
            this.tblLayout1.Controls.Add(this.lblTitle, 0, 0);
            this.tblLayout1.Controls.Add(this.btnAccept, 3, 4);
            this.tblLayout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayout1.Location = new System.Drawing.Point(0, 0);
            this.tblLayout1.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayout1.Name = "tblLayout1";
            this.tblLayout1.RowCount = 9;
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.267056F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.350097F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.609284F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.80851F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.48188F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.51676F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tblLayout1.Size = new System.Drawing.Size(411, 580);
            this.tblLayout1.TabIndex = 0;
            // 
            // txtManualRate
            // 
            this.txtManualRate.AllowBlankSpaces = true;
            this.txtManualRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtManualRate.CharsIncluded = new char[] {
        '.'};
            this.tblLayout1.SetColumnSpan(this.txtManualRate, 3);
            this.txtManualRate.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtManualRate.CustomExpression = ".*";
            this.txtManualRate.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtManualRate.EnterColor = System.Drawing.Color.Empty;
            this.txtManualRate.LeaveColor = System.Drawing.Color.Empty;
            this.txtManualRate.Location = new System.Drawing.Point(15, 60);
            this.txtManualRate.MaxLength = 61;
            this.txtManualRate.Name = "txtManualRate";
            this.txtManualRate.Size = new System.Drawing.Size(393, 20);
            this.txtManualRate.TabIndex = 1;
            this.txtManualRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblManualRate
            // 
            this.lblManualRate.AutoSize = true;
            this.tblLayout1.SetColumnSpan(this.lblManualRate, 2);
            this.lblManualRate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblManualRate.Location = new System.Drawing.Point(15, 35);
            this.lblManualRate.Name = "lblManualRate";
            this.lblManualRate.Size = new System.Drawing.Size(135, 22);
            this.lblManualRate.TabIndex = 0;
            this.lblManualRate.Text = "Ingresa Cotización Manual:";
            this.lblManualRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.tblLayout1.SetColumnSpan(this.lblTitle, 4);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Almacena Cotización Manual";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(210, 98);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucManualRateGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblLayout1);
            this.Name = "ucManualRateGroup";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucManualRate_Load);
            this.tblLayout1.ResumeLayout(false);
            this.tblLayout1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel tblLayout1;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblManualRate;
        internal System.Windows.Forms.Label lblTitle;
        internal MyCTS.Forms.UI.SmartTextBox txtManualRate;
    }
}
