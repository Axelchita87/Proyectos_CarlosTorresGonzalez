namespace MyCTS.Presentation
{
    partial class ucDWLIST
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
            this.lblRecordLocalizer = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblItemtoPrint = new System.Windows.Forms.Label();
            this.tblLayoutDate = new System.Windows.Forms.TableLayoutPanel();
            this.picCalendar = new System.Windows.Forms.PictureBox();
            this.txtDateSelected = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLocalizerRecord = new MyCTS.Forms.UI.SmartTextBox();
            this.txtItemToPrint = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.tblLayoutMoveButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.tblLayoutMain.SuspendLayout();
            this.tblLayoutDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).BeginInit();
            this.tblLayoutMoveButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayoutMain
            // 
            this.tblLayoutMain.BackColor = System.Drawing.Color.White;
            this.tblLayoutMain.ColumnCount = 4;
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.8F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.2F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.tblLayoutMain.Controls.Add(this.lblTitle, 0, 0);
            this.tblLayoutMain.Controls.Add(this.lblRecordLocalizer, 1, 2);
            this.tblLayoutMain.Controls.Add(this.lblDate, 1, 4);
            this.tblLayoutMain.Controls.Add(this.lblItemtoPrint, 1, 6);
            this.tblLayoutMain.Controls.Add(this.tblLayoutDate, 1, 5);
            this.tblLayoutMain.Controls.Add(this.txtLocalizerRecord, 1, 3);
            this.tblLayoutMain.Controls.Add(this.txtItemToPrint, 1, 7);
            this.tblLayoutMain.Controls.Add(this.btnAccept, 3, 8);
            this.tblLayoutMain.Controls.Add(this.monthCalendar1, 2, 2);
            this.tblLayoutMain.Controls.Add(this.tblLayoutMoveButtons, 1, 8);
            this.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutMain.Name = "tblLayoutMain";
            this.tblLayoutMain.RowCount = 11;
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.803261F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.19674F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tblLayoutMain.Size = new System.Drawing.Size(411, 580);
            this.tblLayoutMain.TabIndex = 12;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.tblLayoutMain.SetColumnSpan(this.lblTitle, 4);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DWLIST Ingresar Record Localizador";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRecordLocalizer
            // 
            this.lblRecordLocalizer.AutoSize = true;
            this.lblRecordLocalizer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRecordLocalizer.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblRecordLocalizer.Location = new System.Drawing.Point(26, 53);
            this.lblRecordLocalizer.Name = "lblRecordLocalizer";
            this.lblRecordLocalizer.Size = new System.Drawing.Size(99, 24);
            this.lblRecordLocalizer.TabIndex = 0;
            this.lblRecordLocalizer.Text = "Record Localizador";
            this.lblRecordLocalizer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDate.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblDate.Location = new System.Drawing.Point(26, 104);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(37, 26);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Fecha";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemtoPrint
            // 
            this.lblItemtoPrint.AutoSize = true;
            this.lblItemtoPrint.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblItemtoPrint.Location = new System.Drawing.Point(26, 155);
            this.lblItemtoPrint.Name = "lblItemtoPrint";
            this.lblItemtoPrint.Size = new System.Drawing.Size(73, 26);
            this.lblItemtoPrint.TabIndex = 0;
            this.lblItemtoPrint.Text = "Item a imprimir";
            this.lblItemtoPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblLayoutDate
            // 
            this.tblLayoutDate.ColumnCount = 2;
            this.tblLayoutDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.73771F));
            this.tblLayoutDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.26229F));
            this.tblLayoutDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutDate.Controls.Add(this.picCalendar, 1, 0);
            this.tblLayoutDate.Controls.Add(this.txtDateSelected, 0, 0);
            this.tblLayoutDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutDate.Location = new System.Drawing.Point(23, 130);
            this.tblLayoutDate.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayoutDate.Name = "tblLayoutDate";
            this.tblLayoutDate.RowCount = 1;
            this.tblLayoutDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutDate.Size = new System.Drawing.Size(112, 25);
            this.tblLayoutDate.TabIndex = 2;
            // 
            // picCalendar
            // 
            this.picCalendar.BackColor = System.Drawing.Color.Transparent;
            this.picCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCalendar.Dock = System.Windows.Forms.DockStyle.Left;
            this.picCalendar.Image = global::MyCTS.Presentation.Properties.Resources.calendario;
            this.picCalendar.Location = new System.Drawing.Point(65, 3);
            this.picCalendar.Name = "picCalendar";
            this.picCalendar.Size = new System.Drawing.Size(20, 19);
            this.picCalendar.TabIndex = 64;
            this.picCalendar.TabStop = false;
            this.picCalendar.Click += new System.EventHandler(this.picCalendar_Click);
            // 
            // txtDateSelected
            // 
            this.txtDateSelected.AllowBlankSpaces = false;
            this.txtDateSelected.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDateSelected.CharsNoIncluded = new char[0];
            this.txtDateSelected.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtDateSelected.CustomExpression = ".*";
            this.txtDateSelected.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtDateSelected.EnterColor = System.Drawing.Color.Empty;
            this.txtDateSelected.HideSelection = false;
            this.txtDateSelected.LeaveColor = System.Drawing.Color.Empty;
            this.txtDateSelected.Location = new System.Drawing.Point(3, 3);
            this.txtDateSelected.MaxLength = 5;
            this.txtDateSelected.Name = "txtDateSelected";
            this.txtDateSelected.Size = new System.Drawing.Size(56, 20);
            this.txtDateSelected.TabIndex = 3;
            this.txtDateSelected.TextChanged += new System.EventHandler(this.txtDateSelected_TextChanged);
            this.txtDateSelected.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtLocalizerRecord
            // 
            this.txtLocalizerRecord.AllowBlankSpaces = false;
            this.txtLocalizerRecord.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLocalizerRecord.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtLocalizerRecord.CustomExpression = ".*";
            this.txtLocalizerRecord.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtLocalizerRecord.EnterColor = System.Drawing.Color.Empty;
            this.txtLocalizerRecord.LeaveColor = System.Drawing.Color.Empty;
            this.txtLocalizerRecord.Location = new System.Drawing.Point(26, 80);
            this.txtLocalizerRecord.MaxLength = 6;
            this.txtLocalizerRecord.Name = "txtLocalizerRecord";
            this.txtLocalizerRecord.Size = new System.Drawing.Size(74, 20);
            this.txtLocalizerRecord.TabIndex = 1;
            this.txtLocalizerRecord.TextChanged += new System.EventHandler(this.txtLocalizerRecord_TextChanged);
            this.txtLocalizerRecord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtItemToPrint
            // 
            this.txtItemToPrint.AllowBlankSpaces = false;
            this.txtItemToPrint.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtItemToPrint.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtItemToPrint.CustomExpression = ".*";
            this.txtItemToPrint.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtItemToPrint.EnterColor = System.Drawing.Color.Empty;
            this.txtItemToPrint.LeaveColor = System.Drawing.Color.Empty;
            this.txtItemToPrint.Location = new System.Drawing.Point(26, 184);
            this.txtItemToPrint.MaxLength = 4;
            this.txtItemToPrint.Name = "txtItemToPrint";
            this.txtItemToPrint.Size = new System.Drawing.Size(54, 20);
            this.txtItemToPrint.TabIndex = 4;
            this.txtItemToPrint.TextChanged += new System.EventHandler(this.txtItemToPrint_TextChanged);
            this.txtItemToPrint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(255, 223);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 8;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.monthCalendar1.Location = new System.Drawing.Point(144, 62);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 14;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            this.monthCalendar1.Leave += new System.EventHandler(this.monthCalendar1_Leave);
            this.monthCalendar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.monthCalendar1_KeyDown);
            // 
            // tblLayoutMoveButtons
            // 
            this.tblLayoutMoveButtons.ColumnCount = 2;
            this.tblLayoutMain.SetColumnSpan(this.tblLayoutMoveButtons, 2);
            this.tblLayoutMoveButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.46032F));
            this.tblLayoutMoveButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.53968F));
            this.tblLayoutMoveButtons.Controls.Add(this.btnMoveDown, 0, 0);
            this.tblLayoutMoveButtons.Controls.Add(this.btnMoveUp, 1, 0);
            this.tblLayoutMoveButtons.Location = new System.Drawing.Point(23, 220);
            this.tblLayoutMoveButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayoutMoveButtons.Name = "tblLayoutMoveButtons";
            this.tblLayoutMoveButtons.RowCount = 1;
            this.tblLayoutMoveButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutMoveButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMoveButtons.Size = new System.Drawing.Size(229, 29);
            this.tblLayoutMoveButtons.TabIndex = 5;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMoveDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveDown.Location = new System.Drawing.Point(3, 3);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(91, 23);
            this.btnMoveDown.TabIndex = 6;
            this.btnMoveDown.Text = "Av.Pag";
            this.btnMoveDown.UseVisualStyleBackColor = false;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMoveUp.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveUp.Location = new System.Drawing.Point(100, 3);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(100, 23);
            this.btnMoveUp.TabIndex = 7;
            this.btnMoveUp.Text = "Reg.Pag";
            this.btnMoveUp.UseVisualStyleBackColor = false;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // ucDWLIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblLayoutMain);
            this.Name = "ucDWLIST";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDWLIST_Load);
            this.tblLayoutMain.ResumeLayout(false);
            this.tblLayoutMain.PerformLayout();
            this.tblLayoutDate.ResumeLayout(false);
            this.tblLayoutDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).EndInit();
            this.tblLayoutMoveButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel tblLayoutMain;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblRecordLocalizer;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblItemtoPrint;
        internal System.Windows.Forms.TableLayoutPanel tblLayoutDate;
        internal System.Windows.Forms.PictureBox picCalendar;
        internal MyCTS.Forms.UI.SmartTextBox txtDateSelected;
        private MyCTS.Forms.UI.SmartTextBox txtLocalizerRecord;
        private MyCTS.Forms.UI.SmartTextBox txtItemToPrint;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TableLayoutPanel tblLayoutMoveButtons;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
    }
}
