namespace MyCTS.Presentation
{
    partial class ucDeleteAccountLine
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
            this.lblExistAccountLine = new System.Windows.Forms.Label();
            this.lblSetMap = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.chkDeleteAcountLine = new System.Windows.Forms.CheckBox();
            this.lblDeleteLinea = new System.Windows.Forms.Label();
            this.lblRange = new System.Windows.Forms.Label();
            this.lblLineNumber = new System.Windows.Forms.Label();
            this.txtRange = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLineNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.lblIndent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblExistAccountLine
            // 
            this.lblExistAccountLine.AutoSize = true;
            this.lblExistAccountLine.BackColor = System.Drawing.Color.Red;
            this.lblExistAccountLine.ForeColor = System.Drawing.Color.White;
            this.lblExistAccountLine.Location = new System.Drawing.Point(28, 44);
            this.lblExistAccountLine.Name = "lblExistAccountLine";
            this.lblExistAccountLine.Size = new System.Drawing.Size(189, 13);
            this.lblExistAccountLine.TabIndex = 0;
            this.lblExistAccountLine.Text = "Existen Lineas Contables en el Record";
            this.lblExistAccountLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSetMap
            // 
            this.lblSetMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblSetMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetMap.ForeColor = System.Drawing.Color.White;
            this.lblSetMap.Location = new System.Drawing.Point(3, 0);
            this.lblSetMap.Name = "lblSetMap";
            this.lblSetMap.Size = new System.Drawing.Size(405, 15);
            this.lblSetMap.TabIndex = 0;
            this.lblSetMap.Text = "Borrar Líneas Contables";
            this.lblSetMap.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(289, 288);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 26);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // chkDeleteAcountLine
            // 
            this.chkDeleteAcountLine.AutoSize = true;
            this.chkDeleteAcountLine.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkDeleteAcountLine.Location = new System.Drawing.Point(31, 84);
            this.chkDeleteAcountLine.Name = "chkDeleteAcountLine";
            this.chkDeleteAcountLine.Size = new System.Drawing.Size(201, 17);
            this.chkDeleteAcountLine.TabIndex = 1;
            this.chkDeleteAcountLine.Text = "¿Borrar Todas las Líneas Contables?";
            this.chkDeleteAcountLine.UseVisualStyleBackColor = true;
            this.chkDeleteAcountLine.CheckedChanged += new System.EventHandler(this.chkDeleteAcountLine_CheckedChanged);
            this.chkDeleteAcountLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblDeleteLinea
            // 
            this.lblDeleteLinea.AutoSize = true;
            this.lblDeleteLinea.ForeColor = System.Drawing.Color.Red;
            this.lblDeleteLinea.Location = new System.Drawing.Point(6, 208);
            this.lblDeleteLinea.Name = "lblDeleteLinea";
            this.lblDeleteLinea.Size = new System.Drawing.Size(402, 13);
            this.lblDeleteLinea.TabIndex = 0;
            this.lblDeleteLinea.Text = "Si las líneas contables existentes son de boletos anteriores, se recomienda borra" +
                "rlas";
            this.lblDeleteLinea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblRange.Location = new System.Drawing.Point(130, 133);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(39, 13);
            this.lblRange.TabIndex = 0;
            this.lblRange.Text = "Rango";
            // 
            // lblLineNumber
            // 
            this.lblLineNumber.AutoSize = true;
            this.lblLineNumber.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblLineNumber.Location = new System.Drawing.Point(77, 133);
            this.lblLineNumber.Name = "lblLineNumber";
            this.lblLineNumber.Size = new System.Drawing.Size(35, 13);
            this.lblLineNumber.TabIndex = 0;
            this.lblLineNumber.Text = "Línea";
            // 
            // txtRange
            // 
            this.txtRange.AllowBlankSpaces = false;
            this.txtRange.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRange.CustomExpression = ".*";
            this.txtRange.EnterColor = System.Drawing.Color.Empty;
            this.txtRange.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange.Location = new System.Drawing.Point(133, 159);
            this.txtRange.MaxLength = 2;
            this.txtRange.Name = "txtRange";
            this.txtRange.Size = new System.Drawing.Size(25, 20);
            this.txtRange.TabIndex = 3;
            this.txtRange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtLineNumber
            // 
            this.txtLineNumber.AllowBlankSpaces = false;
            this.txtLineNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLineNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtLineNumber.CustomExpression = ".*";
            this.txtLineNumber.EnterColor = System.Drawing.Color.Empty;
            this.txtLineNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtLineNumber.Location = new System.Drawing.Point(82, 159);
            this.txtLineNumber.MaxLength = 2;
            this.txtLineNumber.Name = "txtLineNumber";
            this.txtLineNumber.Size = new System.Drawing.Size(25, 20);
            this.txtLineNumber.TabIndex = 2;
            this.txtLineNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblIndent
            // 
            this.lblIndent.AutoSize = true;
            this.lblIndent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent.ForeColor = System.Drawing.Color.Black;
            this.lblIndent.Location = new System.Drawing.Point(113, 157);
            this.lblIndent.Name = "lblIndent";
            this.lblIndent.Size = new System.Drawing.Size(14, 20);
            this.lblIndent.TabIndex = 0;
            this.lblIndent.Text = "-";
            // 
            // ucDeleteAccountLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblRange);
            this.Controls.Add(this.lblLineNumber);
            this.Controls.Add(this.txtRange);
            this.Controls.Add(this.txtLineNumber);
            this.Controls.Add(this.lblIndent);
            this.Controls.Add(this.lblExistAccountLine);
            this.Controls.Add(this.lblSetMap);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.chkDeleteAcountLine);
            this.Controls.Add(this.lblDeleteLinea);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucDeleteAccountLine";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDeleteAccountLine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExistAccountLine;
        internal System.Windows.Forms.Label lblSetMap;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.CheckBox chkDeleteAcountLine;
        private System.Windows.Forms.Label lblDeleteLinea;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.Label lblLineNumber;
        private MyCTS.Forms.UI.SmartTextBox txtRange;
        private MyCTS.Forms.UI.SmartTextBox txtLineNumber;
        private System.Windows.Forms.Label lblIndent;

    }
}
