namespace MyCTS.Presentation
{
    partial class ucSellOption
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
            this.txtOptionToSell = new MyCTS.Forms.UI.SmartTextBox();
            this.chkCancelItinerary = new System.Windows.Forms.CheckBox();
            this.chkSellOption = new System.Windows.Forms.CheckBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.tblLayoutMoveButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.tblLayoutMain.SuspendLayout();
            this.tblLayoutMoveButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayoutMain
            // 
            this.tblLayoutMain.BackColor = System.Drawing.Color.White;
            this.tblLayoutMain.ColumnCount = 6;
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.918334F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.55172F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.55172F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tblLayoutMain.Controls.Add(this.txtOptionToSell, 4, 3);
            this.tblLayoutMain.Controls.Add(this.chkCancelItinerary, 3, 4);
            this.tblLayoutMain.Controls.Add(this.chkSellOption, 1, 2);
            this.tblLayoutMain.Controls.Add(this.lbl1, 3, 3);
            this.tblLayoutMain.Controls.Add(this.lblTitle, 0, 0);
            this.tblLayoutMain.Controls.Add(this.btnAccept, 5, 6);
            this.tblLayoutMain.Controls.Add(this.tblLayoutMoveButtons, 1, 6);
            this.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutMain.Name = "tblLayoutMain";
            this.tblLayoutMain.RowCount = 9;
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.447471F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.048543F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.019417F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.407767F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.620155F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.51163F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tblLayoutMain.Size = new System.Drawing.Size(411, 580);
            this.tblLayoutMain.TabIndex = 9;
            // 
            // txtOptionToSell
            // 
            this.txtOptionToSell.AllowBlankSpaces = false;
            this.txtOptionToSell.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOptionToSell.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtOptionToSell.CustomExpression = ".*";
            this.txtOptionToSell.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtOptionToSell.EnterColor = System.Drawing.Color.Empty;
            this.txtOptionToSell.LeaveColor = System.Drawing.Color.Empty;
            this.txtOptionToSell.Location = new System.Drawing.Point(154, 66);
            this.txtOptionToSell.MaxLength = 2;
            this.txtOptionToSell.Name = "txtOptionToSell";
            this.txtOptionToSell.Size = new System.Drawing.Size(25, 20);
            this.txtOptionToSell.TabIndex = 2;
            this.txtOptionToSell.TextChanged += new System.EventHandler(this.txtOptionToSell_TextChanged);
            this.txtOptionToSell.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkCancelItinerary
            // 
            this.chkCancelItinerary.AutoSize = true;
            this.tblLayoutMain.SetColumnSpan(this.chkCancelItinerary, 2);
            this.chkCancelItinerary.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkCancelItinerary.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkCancelItinerary.Location = new System.Drawing.Point(50, 92);
            this.chkCancelItinerary.Name = "chkCancelItinerary";
            this.chkCancelItinerary.Size = new System.Drawing.Size(155, 25);
            this.chkCancelItinerary.TabIndex = 3;
            this.chkCancelItinerary.Text = "¿cancelar Itinerario Actual?";
            this.chkCancelItinerary.UseVisualStyleBackColor = true;
            this.chkCancelItinerary.CheckedChanged += new System.EventHandler(this.txtOptionToSell_TextChanged);
            this.chkCancelItinerary.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkSellOption
            // 
            this.chkSellOption.AutoSize = true;
            this.tblLayoutMain.SetColumnSpan(this.chkSellOption, 4);
            this.chkSellOption.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkSellOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSellOption.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkSellOption.Location = new System.Drawing.Point(15, 38);
            this.chkSellOption.Name = "chkSellOption";
            this.chkSellOption.Size = new System.Drawing.Size(213, 22);
            this.chkSellOption.TabIndex = 1;
            this.chkSellOption.Text = "¿Vende una de las opciones ofrecidas?";
            this.chkSellOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSellOption.UseVisualStyleBackColor = true;
            this.chkSellOption.CheckedChanged += new System.EventHandler(this.chkSellOption_CheckedChanged);
            this.chkSellOption.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl1.Location = new System.Drawing.Point(50, 63);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(98, 26);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "¿Opción a vender?";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.tblLayoutMain.SetColumnSpan(this.lblTitle, 6);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Vender Alguna Opción Desplegada";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(258, 156);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // tblLayoutMoveButtons
            // 
            this.tblLayoutMoveButtons.ColumnCount = 2;
            this.tblLayoutMain.SetColumnSpan(this.tblLayoutMoveButtons, 4);
            this.tblLayoutMoveButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.46032F));
            this.tblLayoutMoveButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.53968F));
            this.tblLayoutMoveButtons.Controls.Add(this.btnMoveDown, 0, 0);
            this.tblLayoutMoveButtons.Controls.Add(this.btnMoveUp, 1, 0);
            this.tblLayoutMoveButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutMoveButtons.Location = new System.Drawing.Point(12, 153);
            this.tblLayoutMoveButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayoutMoveButtons.Name = "tblLayoutMoveButtons";
            this.tblLayoutMoveButtons.RowCount = 1;
            this.tblLayoutMoveButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutMoveButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMoveButtons.Size = new System.Drawing.Size(243, 29);
            this.tblLayoutMoveButtons.TabIndex = 4;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMoveDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveDown.Location = new System.Drawing.Point(3, 3);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(97, 23);
            this.btnMoveDown.TabIndex = 5;
            this.btnMoveDown.Text = "Av.Pag";
            this.btnMoveDown.UseVisualStyleBackColor = false;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMoveUp.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveUp.Location = new System.Drawing.Point(106, 3);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(100, 23);
            this.btnMoveUp.TabIndex = 6;
            this.btnMoveUp.Text = "Reg.Pag";
            this.btnMoveUp.UseVisualStyleBackColor = false;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // ucSellOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tblLayoutMain);
            this.InitialControlFocus = this.chkSellOption;
            this.LastControlFocus = this.btnAccept;
            this.Name = "ucSellOption";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucSellOption_Load);
            this.tblLayoutMain.ResumeLayout(false);
            this.tblLayoutMain.PerformLayout();
            this.tblLayoutMoveButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel tblLayoutMain;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.CheckBox chkSellOption;
        private System.Windows.Forms.Label lbl1;
        private MyCTS.Forms.UI.SmartTextBox txtOptionToSell;
        private System.Windows.Forms.CheckBox chkCancelItinerary;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.TableLayoutPanel tblLayoutMoveButtons;
        private System.Windows.Forms.Button btnMoveUp;
    }
}
