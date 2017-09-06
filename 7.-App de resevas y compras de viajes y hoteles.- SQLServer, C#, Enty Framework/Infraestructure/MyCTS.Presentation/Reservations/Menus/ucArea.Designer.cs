namespace MyCTS.Presentation
{
    partial class ucArea
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
            this.tblLayoutArea = new System.Windows.Forms.TableLayoutPanel();
            this.lblArea = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.tblLayoutArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayoutArea
            // 
            this.tblLayoutArea.BackColor = System.Drawing.Color.LightGray;
            this.tblLayoutArea.ColumnCount = 2;
            this.tblLayoutArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.52153F));
            this.tblLayoutArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.47847F));
            this.tblLayoutArea.Controls.Add(this.lblArea, 0, 0);
            this.tblLayoutArea.Controls.Add(this.cmbArea, 1, 0);
            this.tblLayoutArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutArea.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutArea.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayoutArea.Name = "tblLayoutArea";
            this.tblLayoutArea.RowCount = 1;
            this.tblLayoutArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutArea.Size = new System.Drawing.Size(101, 25);
            this.tblLayoutArea.TabIndex = 0;
            // 
            // lblArea
            // 
            this.lblArea.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblArea.Location = new System.Drawing.Point(3, 0);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(44, 25);
            this.lblArea.TabIndex = 0;
            this.lblArea.Text = "Área:";
            this.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Items.AddRange(new object[] {
            global::MyCTS.Presentation.Resources.ErrorMessages.INTERJET_DEPARTURE_NOT_FOUND,
            "A",
            "B",
            "C",
            "D Airport",
            "E eTkt",
            "F Consolid"});
            this.cmbArea.Location = new System.Drawing.Point(53, 3);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(39, 21);
            this.cmbArea.TabIndex = 0;
            this.cmbArea.TabStop = false;
            this.cmbArea.SelectedIndexChanged += new System.EventHandler(this.cmbArea_SelectedIndexChanged);
            // 
            // ucArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tblLayoutArea);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucArea";
            this.Size = new System.Drawing.Size(101, 25);
            this.tblLayoutArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblLayoutArea;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.ComboBox cmbArea;

    }
}
