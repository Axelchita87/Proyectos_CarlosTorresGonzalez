namespace MyCTS.Presentation
{
    partial class ucLineRate
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
            this.txtLineRate = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblLineRate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 15);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Desplegar Regla de Tarifa";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtLineRate
            // 
            this.txtLineRate.AllowBlankSpaces = false;
            this.txtLineRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLineRate.CharsIncluded = new char[0];
            this.txtLineRate.CharsNoIncluded = new char[0];
            this.txtLineRate.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtLineRate.CustomExpression = ".*";
            this.txtLineRate.EnterColor = System.Drawing.Color.Empty;
            this.txtLineRate.LeaveColor = System.Drawing.Color.Empty;
            this.txtLineRate.Location = new System.Drawing.Point(160, 58);
            this.txtLineRate.MaxLength = 2;
            this.txtLineRate.Name = "txtLineRate";
            this.txtLineRate.Size = new System.Drawing.Size(42, 20);
            this.txtLineRate.TabIndex = 1;
            this.txtLineRate.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtLineRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(239, 141);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblLineRate
            // 
            this.lblLineRate.AutoSize = true;
            this.lblLineRate.Location = new System.Drawing.Point(59, 61);
            this.lblLineRate.Name = "lblLineRate";
            this.lblLineRate.Size = new System.Drawing.Size(94, 13);
            this.lblLineRate.TabIndex = 12;
            this.lblLineRate.Text = "Línea de la Tarifa:";
            // 
            // ucLineRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblLineRate);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtLineRate);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucLineRate";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucLineRate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtLineRate;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblLineRate;
    }
}
