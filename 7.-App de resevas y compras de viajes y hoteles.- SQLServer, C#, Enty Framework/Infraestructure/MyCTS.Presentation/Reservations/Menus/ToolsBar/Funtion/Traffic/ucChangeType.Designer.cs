namespace MyCTS.Presentation
{
    partial class ucChangeType
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
            this.tblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblChangeType = new System.Windows.Forms.Label();
            this.txtDateSelect = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.picCalender = new System.Windows.Forms.PictureBox();
            this.tblLayoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCalender)).BeginInit();
            this.SuspendLayout();
            // 
            // tblLayoutMain
            // 
            this.tblLayoutMain.BackColor = System.Drawing.Color.White;
            this.tblLayoutMain.ColumnCount = 5;
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.192587F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.87835F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.67883F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.326034F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.73723F));
            this.tblLayoutMain.Controls.Add(this.lblChangeType, 0, 0);
            this.tblLayoutMain.Controls.Add(this.txtDateSelect, 2, 2);
            this.tblLayoutMain.Controls.Add(this.lblDateTime, 1, 2);
            this.tblLayoutMain.Controls.Add(this.btnAccept, 3, 4);
            this.tblLayoutMain.Controls.Add(this.monthCalendar1, 2, 1);
            this.tblLayoutMain.Controls.Add(this.picCalender, 4, 2);
            this.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutMain.Name = "tblLayoutMain";
            this.tblLayoutMain.RowCount = 10;
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.418491F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.282238F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.284943F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.700729F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.29197F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.52798F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.24087F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.8434F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.18826F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.221124F));
            this.tblLayoutMain.Size = new System.Drawing.Size(411, 580);
            this.tblLayoutMain.TabIndex = 15;
            // 
            // lblChangeType
            // 
            this.lblChangeType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.tblLayoutMain.SetColumnSpan(this.lblChangeType, 5);
            this.lblChangeType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChangeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeType.ForeColor = System.Drawing.Color.White;
            this.lblChangeType.Location = new System.Drawing.Point(3, 0);
            this.lblChangeType.Name = "lblChangeType";
            this.lblChangeType.Size = new System.Drawing.Size(405, 14);
            this.lblChangeType.TabIndex = 0;
            this.lblChangeType.Text = "Tipo de Cambio";
            this.lblChangeType.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDateSelect
            // 
            this.txtDateSelect.AllowBlankSpaces = true;
            this.txtDateSelect.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblLayoutMain.SetColumnSpan(this.txtDateSelect, 2);
            this.txtDateSelect.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtDateSelect.CustomExpression = ".*";
            this.txtDateSelect.EnterColor = System.Drawing.Color.Empty;
            this.txtDateSelect.LeaveColor = System.Drawing.Color.Empty;
            this.txtDateSelect.Location = new System.Drawing.Point(227, 36);
            this.txtDateSelect.MaxLength = 7;
            this.txtDateSelect.Name = "txtDateSelect";
            this.txtDateSelect.Size = new System.Drawing.Size(62, 20);
            this.txtDateSelect.TabIndex = 1;
            this.txtDateSelect.TextChanged += new System.EventHandler(this.txtDateSelect_TextChanged);
            this.txtDateSelect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDateTime.Location = new System.Drawing.Point(24, 33);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(195, 30);
            this.lblDateTime.TabIndex = 0;
            this.lblDateTime.Text = "Ingresa la fecha para día en especifico:";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tblLayoutMain.SetColumnSpan(this.btnAccept, 2);
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(274, 99);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(233, 23);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 3;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            this.monthCalendar1.Leave += new System.EventHandler(this.monthCalendar1_Leave);
            this.monthCalendar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.monthCalendar1_KeyDown);
            // 
            // picCalender
            // 
            this.picCalender.Image = global::MyCTS.Presentation.Properties.Resources.calendario;
            this.picCalender.Location = new System.Drawing.Point(299, 36);
            this.picCalender.Name = "picCalender";
            this.picCalender.Size = new System.Drawing.Size(17, 23);
            this.picCalender.TabIndex = 76;
            this.picCalender.TabStop = false;
            this.picCalender.Click += new System.EventHandler(this.picCalender_Click);
            // 
            // ucChangeType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tblLayoutMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucChangeType";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucChangeType_Load);
            this.tblLayoutMain.ResumeLayout(false);
            this.tblLayoutMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCalender)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel tblLayoutMain;
        internal System.Windows.Forms.Label lblChangeType;
        private MyCTS.Forms.UI.SmartTextBox txtDateSelect;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.PictureBox picCalender;
    }
}
