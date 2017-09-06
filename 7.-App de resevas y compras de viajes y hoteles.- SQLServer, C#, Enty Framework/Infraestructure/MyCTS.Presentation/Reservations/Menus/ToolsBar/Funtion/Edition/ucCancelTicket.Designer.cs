namespace MyCTS.Presentation
{
    partial class ucCancelTicket
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
            this.components = new System.ComponentModel.Container();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblCancelTicket = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtNumberLine = new MyCTS.Forms.UI.SmartTextBox();
            this.lblNumberLine = new System.Windows.Forms.Label();
            this.tblLayout1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblOtherTkt = new System.Windows.Forms.Label();
            this.btnYesOther = new System.Windows.Forms.Button();
            this.btnNoOther = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tblLayout1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNo
            // 
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Location = new System.Drawing.Point(252, 79);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(36, 29);
            this.btnNo.TabIndex = 3;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Visible = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            this.btnNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnNo_KeyUp);
            this.btnNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnYes
            // 
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnYes.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Location = new System.Drawing.Point(209, 79);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(36, 29);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "Si";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Visible = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            this.btnYes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnYes_KeyUp);
            this.btnYes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(252, 211);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnAccept_KeyUp);
            this.btnAccept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCancelTicket
            // 
            this.lblCancelTicket.AutoSize = true;
            this.tblLayout1.SetColumnSpan(this.lblCancelTicket, 2);
            this.lblCancelTicket.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCancelTicket.ForeColor = System.Drawing.Color.Black;
            this.lblCancelTicket.Location = new System.Drawing.Point(20, 76);
            this.lblCancelTicket.Name = "lblCancelTicket";
            this.lblCancelTicket.Size = new System.Drawing.Size(183, 35);
            this.lblCancelTicket.TabIndex = 0;
            this.lblCancelTicket.Text = "¿Estas seguro de cancelar el Boleto?";
            this.lblCancelTicket.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCancelTicket.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.tblLayout1.SetColumnSpan(this.lblTitle, 5);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cancela Boleto";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtNumberLine
            // 
            this.txtNumberLine.AllowBlankSpaces = true;
            this.txtNumberLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberLine.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberLine.CustomExpression = ".*";
            this.txtNumberLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtNumberLine.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberLine.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberLine.Location = new System.Drawing.Point(123, 34);
            this.txtNumberLine.MaxLength = 2;
            this.txtNumberLine.Name = "txtNumberLine";
            this.txtNumberLine.Size = new System.Drawing.Size(34, 20);
            this.txtNumberLine.TabIndex = 1;
            this.txtNumberLine.TextChanged += new System.EventHandler(this.txtNumberLine_TextChanged);
            this.txtNumberLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblNumberLine
            // 
            this.lblNumberLine.AutoSize = true;
            this.lblNumberLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblNumberLine.Location = new System.Drawing.Point(20, 31);
            this.lblNumberLine.Name = "lblNumberLine";
            this.lblNumberLine.Size = new System.Drawing.Size(89, 22);
            this.lblNumberLine.TabIndex = 0;
            this.lblNumberLine.Text = "Número de línea:";
            this.lblNumberLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblLayout1
            // 
            this.tblLayout1.BackColor = System.Drawing.Color.White;
            this.tblLayout1.ColumnCount = 5;
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.324111F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.10672F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.96289F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.6472F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.95907F));
            this.tblLayout1.Controls.Add(this.lblNumberLine, 1, 2);
            this.tblLayout1.Controls.Add(this.txtNumberLine, 2, 2);
            this.tblLayout1.Controls.Add(this.lblTitle, 0, 0);
            this.tblLayout1.Controls.Add(this.lblCancelTicket, 1, 4);
            this.tblLayout1.Controls.Add(this.btnYes, 3, 4);
            this.tblLayout1.Controls.Add(this.btnNo, 4, 4);
            this.tblLayout1.Controls.Add(this.btnAccept, 4, 8);
            this.tblLayout1.Controls.Add(this.lblOtherTkt, 1, 6);
            this.tblLayout1.Controls.Add(this.btnYesOther, 3, 6);
            this.tblLayout1.Controls.Add(this.btnNoOther, 4, 6);
            this.tblLayout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayout1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblLayout1.Location = new System.Drawing.Point(0, 0);
            this.tblLayout1.Name = "tblLayout1";
            this.tblLayout1.RowCount = 11;
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.894554F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.650803F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.948679F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.113208F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.087547F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.429434F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.551724F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.827586F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.70037F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.64301F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.015409F));
            this.tblLayout1.Size = new System.Drawing.Size(411, 580);
            this.tblLayout1.TabIndex = 12;
            // 
            // lblOtherTkt
            // 
            this.lblOtherTkt.AutoSize = true;
            this.tblLayout1.SetColumnSpan(this.lblOtherTkt, 2);
            this.lblOtherTkt.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblOtherTkt.Location = new System.Drawing.Point(20, 142);
            this.lblOtherTkt.Name = "lblOtherTkt";
            this.lblOtherTkt.Size = new System.Drawing.Size(147, 38);
            this.lblOtherTkt.TabIndex = 0;
            this.lblOtherTkt.Text = "¿Desea cancelar otro boleto?";
            this.lblOtherTkt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOtherTkt.Visible = false;
            // 
            // btnYesOther
            // 
            this.btnYesOther.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYesOther.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnYesOther.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnYesOther.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnYesOther.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYesOther.Location = new System.Drawing.Point(209, 145);
            this.btnYesOther.Name = "btnYesOther";
            this.btnYesOther.Size = new System.Drawing.Size(36, 31);
            this.btnYesOther.TabIndex = 4;
            this.btnYesOther.Text = "Si";
            this.btnYesOther.UseVisualStyleBackColor = true;
            this.btnYesOther.Visible = false;
            this.btnYesOther.Click += new System.EventHandler(this.btnYesOther_Click);
            // 
            // btnNoOther
            // 
            this.btnNoOther.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNoOther.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNoOther.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnNoOther.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnNoOther.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoOther.Location = new System.Drawing.Point(252, 145);
            this.btnNoOther.Name = "btnNoOther";
            this.btnNoOther.Size = new System.Drawing.Size(36, 31);
            this.btnNoOther.TabIndex = 5;
            this.btnNoOther.Text = "No";
            this.btnNoOther.UseVisualStyleBackColor = true;
            this.btnNoOther.Visible = false;
            this.btnNoOther.Click += new System.EventHandler(this.btnNoOther_Click);
            // 
            // ucCancelTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblLayout1);
            this.Name = "ucCancelTicket";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucCancelTicket_Load);
            this.tblLayout1.ResumeLayout(false);
            this.tblLayout1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblCancelTicket;
        internal System.Windows.Forms.TableLayoutPanel tblLayout1;
        private System.Windows.Forms.Label lblNumberLine;
        private MyCTS.Forms.UI.SmartTextBox txtNumberLine;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnYesOther;
        private System.Windows.Forms.Label lblOtherTkt;
        private System.Windows.Forms.Button btnNoOther;
        private System.Windows.Forms.BindingSource bindingSource1;

    }
}
