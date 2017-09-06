namespace MyCTS.Presentation.Reservations.Menus.ToolsBar.Funtion.Edition
{
    partial class frmCorporateConsulting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCorporateConsulting));
            this.dgvConsultaCorporativo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaCorporativo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConsultaCorporativo
            // 
            this.dgvConsultaCorporativo.AllowUserToOrderColumns = true;
            this.dgvConsultaCorporativo.BackgroundColor = System.Drawing.Color.MistyRose;
            this.dgvConsultaCorporativo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConsultaCorporativo.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsultaCorporativo.Location = new System.Drawing.Point(-2, 0);
            this.dgvConsultaCorporativo.Name = "dgvConsultaCorporativo";
            this.dgvConsultaCorporativo.Size = new System.Drawing.Size(1361, 632);
            this.dgvConsultaCorporativo.TabIndex = 4;
            this.dgvConsultaCorporativo.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvConsultaCorporativo_ColumnHeaderMouseClick);
            // 
            // frmCorporateConsulting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 633);
            this.Controls.Add(this.dgvConsultaCorporativo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCorporateConsulting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Corporativo - Herramientas Online";
            this.Load += new System.EventHandler(this.frmCorporateConsulting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaCorporativo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConsultaCorporativo;
    }
}