namespace MyCTS.Presentation
{
    partial class ucCancelTicketDQB
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
            this.lblNumberLine = new System.Windows.Forms.Label();
            this.txtNumberTicket = new MyCTS.Forms.UI.SmartTextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCancelTicket = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblCancelDQB = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.tblLayout1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayout1
            // 
            this.tblLayout1.BackColor = System.Drawing.Color.White;
            this.tblLayout1.ColumnCount = 5;
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.324111F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.35048F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.16788F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.975669F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.90268F));
            this.tblLayout1.Controls.Add(this.lblNumberLine, 1, 4);
            this.tblLayout1.Controls.Add(this.txtNumberTicket, 2, 4);
            this.tblLayout1.Controls.Add(this.lblTitle, 0, 0);
            this.tblLayout1.Controls.Add(this.lblCancelTicket, 1, 6);
            this.tblLayout1.Controls.Add(this.btnAccept, 4, 8);
            this.tblLayout1.Controls.Add(this.lblCancelDQB, 1, 2);
            this.tblLayout1.Controls.Add(this.btnYes, 3, 6);
            this.tblLayout1.Controls.Add(this.btnNo, 4, 6);
            this.tblLayout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayout1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblLayout1.Location = new System.Drawing.Point(0, 0);
            this.tblLayout1.Name = "tblLayout1";
            this.tblLayout1.RowCount = 12;
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.766327F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.559954F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.118293F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.777219F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.283024F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.275862F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.034483F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.137931F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.65517F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.131F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.17153F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.837529F));
            this.tblLayout1.Size = new System.Drawing.Size(411, 580);
            this.tblLayout1.TabIndex = 13;
            // 
            // lblNumberLine
            // 
            this.lblNumberLine.AutoSize = true;
            this.lblNumberLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblNumberLine.Location = new System.Drawing.Point(20, 92);
            this.lblNumberLine.Name = "lblNumberLine";
            this.lblNumberLine.Size = new System.Drawing.Size(95, 24);
            this.lblNumberLine.TabIndex = 0;
            this.lblNumberLine.Text = "Número de Boleto:";
            this.lblNumberLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNumberTicket
            // 
            this.txtNumberTicket.AllowBlankSpaces = true;
            this.txtNumberTicket.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblLayout1.SetColumnSpan(this.txtNumberTicket, 2);
            this.txtNumberTicket.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberTicket.CustomExpression = ".*";
            this.txtNumberTicket.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtNumberTicket.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberTicket.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberTicket.Location = new System.Drawing.Point(123, 95);
            this.txtNumberTicket.MaxLength = 13;
            this.txtNumberTicket.Name = "txtNumberTicket";
            this.txtNumberTicket.Size = new System.Drawing.Size(100, 20);
            this.txtNumberTicket.TabIndex = 1;
            this.txtNumberTicket.TextChanged += new System.EventHandler(this.txtNumberLine_TextChanged);
            this.txtNumberTicket.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
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
            // lblCancelTicket
            // 
            this.lblCancelTicket.AutoSize = true;
            this.tblLayout1.SetColumnSpan(this.lblCancelTicket, 2);
            this.lblCancelTicket.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCancelTicket.Location = new System.Drawing.Point(20, 135);
            this.lblCancelTicket.Name = "lblCancelTicket";
            this.lblCancelTicket.Size = new System.Drawing.Size(183, 35);
            this.lblCancelTicket.TabIndex = 0;
            this.lblCancelTicket.Text = "¿Estas seguro de cancelar el Boleto?";
            this.lblCancelTicket.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCancelTicket.Visible = false;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(249, 197);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnAccept_KeyUp);
            // 
            // lblCancelDQB
            // 
            this.lblCancelDQB.AutoSize = true;
            this.tblLayout1.SetColumnSpan(this.lblCancelDQB, 4);
            this.lblCancelDQB.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCancelDQB.ForeColor = System.Drawing.Color.Blue;
            this.lblCancelDQB.Location = new System.Drawing.Point(20, 42);
            this.lblCancelDQB.Name = "lblCancelDQB";
            this.lblCancelDQB.Size = new System.Drawing.Size(379, 23);
            this.lblCancelDQB.TabIndex = 0;
            this.lblCancelDQB.Text = "Cancelar un boleto Registrado en DQB  que no fue reflejado dentro del Record";
            this.lblCancelDQB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnYes
            // 
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnYes.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Location = new System.Drawing.Point(209, 138);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(33, 29);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "Si";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Visible = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            this.btnYes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnYes_KeyUp);
            this.btnYes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnNo
            // 
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Location = new System.Drawing.Point(249, 138);
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
            // ucCancelTicketDQB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tblLayout1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucCancelTicketDQB";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucCancelTicketDQB_Load);
            this.tblLayout1.ResumeLayout(false);
            this.tblLayout1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel tblLayout1;
        private System.Windows.Forms.Label lblNumberLine;
        private MyCTS.Forms.UI.SmartTextBox txtNumberTicket;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCancelTicket;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblCancelDQB;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
    }
}
