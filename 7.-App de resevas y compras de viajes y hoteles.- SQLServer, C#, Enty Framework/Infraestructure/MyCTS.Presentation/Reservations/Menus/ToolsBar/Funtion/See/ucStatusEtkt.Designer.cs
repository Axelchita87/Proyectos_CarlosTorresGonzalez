namespace MyCTS.Presentation
{
    partial class ucStatusEtkt
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
            this.txtNumberLine = new MyCTS.Forms.UI.SmartTextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.tblLayout1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayout1
            // 
            this.tblLayout1.BackColor = System.Drawing.Color.White;
            this.tblLayout1.ColumnCount = 5;
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.316206F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.06083F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.92457F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.62774F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.88785F));
            this.tblLayout1.Controls.Add(this.lblNumberLine, 1, 2);
            this.tblLayout1.Controls.Add(this.txtNumberLine, 2, 2);
            this.tblLayout1.Controls.Add(this.lblTitle, 0, 0);
            this.tblLayout1.Controls.Add(this.btnAccept, 4, 4);
            this.tblLayout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayout1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblLayout1.Location = new System.Drawing.Point(0, 0);
            this.tblLayout1.Name = "tblLayout1";
            this.tblLayout1.RowCount = 10;
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.033284F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.77785F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.268335F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.275862F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.034483F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.793103F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.55172F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.78418F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.15311F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.207859F));
            this.tblLayout1.Size = new System.Drawing.Size(411, 580);
            this.tblLayout1.TabIndex = 14;
            // 
            // lblNumberLine
            // 
            this.lblNumberLine.AutoSize = true;
            this.lblNumberLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblNumberLine.Location = new System.Drawing.Point(20, 33);
            this.lblNumberLine.Name = "lblNumberLine";
            this.lblNumberLine.Size = new System.Drawing.Size(89, 30);
            this.lblNumberLine.TabIndex = 0;
            this.lblNumberLine.Text = "Número de línea:";
            this.lblNumberLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.txtNumberLine.Location = new System.Drawing.Point(123, 36);
            this.txtNumberLine.MaxLength = 2;
            this.txtNumberLine.Name = "txtNumberLine";
            this.txtNumberLine.Size = new System.Drawing.Size(34, 20);
            this.txtNumberLine.TabIndex = 1;
            this.txtNumberLine.TextChanged += new System.EventHandler(this.txtNumberLine_TextChanged);
            this.txtNumberLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
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
            this.lblTitle.Size = new System.Drawing.Size(405, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Estatus de eTkt por Número de Línea";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(252, 85);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucStatusEtkt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tblLayout1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucStatusEtkt";
            this.Size = new System.Drawing.Size(411, 580);
            this.tblLayout1.ResumeLayout(false);
            this.tblLayout1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel tblLayout1;
        private System.Windows.Forms.Label lblNumberLine;
        private MyCTS.Forms.UI.SmartTextBox txtNumberLine;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
    }
}
