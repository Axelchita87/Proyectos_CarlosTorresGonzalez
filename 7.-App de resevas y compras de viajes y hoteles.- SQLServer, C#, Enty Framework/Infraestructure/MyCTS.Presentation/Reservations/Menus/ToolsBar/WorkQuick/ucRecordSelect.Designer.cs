namespace MyCTS.Presentation
{
    partial class ucRecordSelect
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtRecordNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.lblRecordNumber = new System.Windows.Forms.Label();
            this.lblRecord = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Selección Record";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(240, 213);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnAccept_KeyUp);
            // 
            // txtRecordNumber
            // 
            this.txtRecordNumber.AllowBlankSpaces = true;
            this.txtRecordNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRecordNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRecordNumber.CustomExpression = ".*";
            this.txtRecordNumber.EnterColor = System.Drawing.Color.Empty;
            this.txtRecordNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtRecordNumber.Location = new System.Drawing.Point(159, 53);
            this.txtRecordNumber.MaxLength = 2;
            this.txtRecordNumber.Name = "txtRecordNumber";
            this.txtRecordNumber.Size = new System.Drawing.Size(38, 20);
            this.txtRecordNumber.TabIndex = 1;
            this.txtRecordNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblRecordNumber
            // 
            this.lblRecordNumber.AutoSize = true;
            this.lblRecordNumber.Location = new System.Drawing.Point(18, 56);
            this.lblRecordNumber.Name = "lblRecordNumber";
            this.lblRecordNumber.Size = new System.Drawing.Size(135, 13);
            this.lblRecordNumber.TabIndex = 4;
            this.lblRecordNumber.Text = "Ingresa Numero de Record";
            this.lblRecordNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Location = new System.Drawing.Point(18, 141);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(119, 13);
            this.lblRecord.TabIndex = 6;
            this.lblRecord.Text = "¿Es el record deseado?";
            this.lblRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRecord.Visible = false;
            // 
            // btnYes
            // 
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Location = new System.Drawing.Point(143, 132);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(36, 31);
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
            this.btnNo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Location = new System.Drawing.Point(185, 132);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(36, 31);
            this.btnNo.TabIndex = 3;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Visible = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            this.btnNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnNo_KeyUp);
            this.btnNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucRecordSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.txtRecordNumber);
            this.Controls.Add(this.lblRecordNumber);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucRecordSelect";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucRecordSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtRecordNumber;
        private System.Windows.Forms.Label lblRecordNumber;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
    }
}
