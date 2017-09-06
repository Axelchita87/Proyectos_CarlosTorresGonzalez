namespace MyCTS.Presentation
{
    partial class ucBoletageDate
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLimitTime = new System.Windows.Forms.Label();
            this.lbl7TAW = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtDateSelected = new MyCTS.Forms.UI.SmartTextBox();
            this.picCalendar = new System.Windows.Forms.PictureBox();
            this.lblComent = new System.Windows.Forms.Label();
            this.txtComment = new MyCTS.Forms.UI.SmartTextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.tblLayoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).BeginInit();
            this.SuspendLayout();
            // 
            // tblLayoutMain
            // 
            this.tblLayoutMain.AutoScroll = true;
            this.tblLayoutMain.BackColor = System.Drawing.Color.White;
            this.tblLayoutMain.ColumnCount = 5;
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.6545F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.40876F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.76156F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.71289F));
            this.tblLayoutMain.Controls.Add(this.lblTitle, 0, 0);
            this.tblLayoutMain.Controls.Add(this.lblLimitTime, 1, 3);
            this.tblLayoutMain.Controls.Add(this.lbl7TAW, 2, 3);
            this.tblLayoutMain.Controls.Add(this.btnAccept, 4, 7);
            this.tblLayoutMain.Controls.Add(this.txtDateSelected, 3, 3);
            this.tblLayoutMain.Controls.Add(this.picCalendar, 4, 3);
            this.tblLayoutMain.Controls.Add(this.lblComent, 1, 5);
            this.tblLayoutMain.Controls.Add(this.txtComment, 2, 5);
            this.tblLayoutMain.Controls.Add(this.monthCalendar1, 2, 2);
            this.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutMain.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayoutMain.Name = "tblLayoutMain";
            this.tblLayoutMain.RowCount = 9;
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.26679F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.642166F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.255319F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.222437F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.50677F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.10906F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tblLayoutMain.Size = new System.Drawing.Size(411, 580);
            this.tblLayoutMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.tblLayoutMain.SetColumnSpan(this.lblTitle, 5);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Fecha de Boletaje";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLimitTime
            // 
            this.lblLimitTime.AutoSize = true;
            this.lblLimitTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLimitTime.Location = new System.Drawing.Point(48, 57);
            this.lblLimitTime.Name = "lblLimitTime";
            this.lblLimitTime.Size = new System.Drawing.Size(75, 24);
            this.lblLimitTime.TabIndex = 4;
            this.lblLimitTime.Text = "Tiempo Limite:";
            this.lblLimitTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl7TAW
            // 
            this.lbl7TAW.AutoSize = true;
            this.lbl7TAW.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl7TAW.Location = new System.Drawing.Point(136, 57);
            this.lbl7TAW.Name = "lbl7TAW";
            this.lbl7TAW.Size = new System.Drawing.Size(38, 24);
            this.lbl7TAW.TabIndex = 5;
            this.lbl7TAW.Text = "7TAW";
            this.lbl7TAW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(258, 208);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 27);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtDateSelected
            // 
            this.txtDateSelected.AllowBlankSpaces = true;
            this.txtDateSelected.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDateSelected.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtDateSelected.CustomExpression = ".*";
            this.txtDateSelected.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtDateSelected.EnterColor = System.Drawing.Color.Empty;
            this.txtDateSelected.LeaveColor = System.Drawing.Color.Empty;
            this.txtDateSelected.Location = new System.Drawing.Point(186, 60);
            this.txtDateSelected.MaxLength = 5;
            this.txtDateSelected.Name = "txtDateSelected";
            this.txtDateSelected.Size = new System.Drawing.Size(65, 20);
            this.txtDateSelected.TabIndex = 2;
            this.txtDateSelected.TextChanged += new System.EventHandler(this.txtDateSelected_TextChanged);
            this.txtDateSelected.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // picCalendar
            // 
            this.picCalendar.BackColor = System.Drawing.Color.Transparent;
            this.picCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCalendar.Dock = System.Windows.Forms.DockStyle.Left;
            this.picCalendar.Image = global::MyCTS.Presentation.Properties.Resources.calendario;
            this.picCalendar.Location = new System.Drawing.Point(258, 60);
            this.picCalendar.Name = "picCalendar";
            this.picCalendar.Size = new System.Drawing.Size(20, 18);
            this.picCalendar.TabIndex = 65;
            this.picCalendar.TabStop = false;
            this.picCalendar.Click += new System.EventHandler(this.picCalendar_Click);
            // 
            // lblComent
            // 
            this.lblComent.AutoSize = true;
            this.lblComent.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblComent.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblComent.Location = new System.Drawing.Point(48, 103);
            this.lblComent.Name = "lblComent";
            this.lblComent.Size = new System.Drawing.Size(60, 27);
            this.lblComent.TabIndex = 6;
            this.lblComent.Text = "Comentario";
            // 
            // txtComment
            // 
            this.txtComment.AllowBlankSpaces = true;
            this.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblLayoutMain.SetColumnSpan(this.txtComment, 3);
            this.txtComment.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtComment.CustomExpression = ".*";
            this.txtComment.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtComment.EnterColor = System.Drawing.Color.Empty;
            this.txtComment.LeaveColor = System.Drawing.Color.Empty;
            this.txtComment.Location = new System.Drawing.Point(136, 106);
            this.txtComment.MaxLength = 25;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(192, 20);
            this.txtComment.TabIndex = 3;
            this.txtComment.TextChanged += new System.EventHandler(this.txtComment_TextChanged);
            this.txtComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.monthCalendar1.Location = new System.Drawing.Point(142, 44);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 66;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            this.monthCalendar1.Leave += new System.EventHandler(this.monthCalendar1_Leave);
            this.monthCalendar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.monthCalendar1_KeyDown);
            // 
            // ucBoletageDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblLayoutMain);
            this.Name = "ucBoletageDate";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucBoletageDate_Load);
            this.tblLayoutMain.ResumeLayout(false);
            this.tblLayoutMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel tblLayoutMain;
        private System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLimitTime;
        private System.Windows.Forms.Label lbl7TAW;
        private System.Windows.Forms.Label lblComent;
        private MyCTS.Forms.UI.SmartTextBox txtDateSelected;
        private MyCTS.Forms.UI.SmartTextBox txtComment;
        internal System.Windows.Forms.PictureBox picCalendar;
        private System.Windows.Forms.MonthCalendar monthCalendar1;

    }
}
