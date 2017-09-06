namespace MyCTS.Presentation
{
   partial class frmSerchAirLinesFare
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

      #region Código generado por el Diseñador de Windows Forms

      /// <summary>
      /// Método necesario para admitir el Diseñador. No se puede modificar
      /// el contenido del método con el editor de código.
      /// </summary>
      private void InitializeComponent()
      {
          this.components = new System.ComponentModel.Container();
          this.lblHeader = new System.Windows.Forms.Label();
          this.dgvCodesAirLines = new System.Windows.Forms.DataGridView();
          this.airLineIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.airLineNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
          this.tblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
          this.comboBox1 = new System.Windows.Forms.ComboBox();
          this.textBox1 = new MyCTS.Forms.UI.SmartTextBox();
          this.comboBox2 = new System.Windows.Forms.ComboBox();
          ((System.ComponentModel.ISupportInitialize)(this.dgvCodesAirLines)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
          this.tblLayoutMain.SuspendLayout();
          this.SuspendLayout();
          // 
          // lblHeader
          // 
          this.lblHeader.AutoSize = true;
          this.lblHeader.BackColor = System.Drawing.Color.Brown;
          this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblHeader.ForeColor = System.Drawing.Color.White;
          this.lblHeader.Location = new System.Drawing.Point(3, 0);
          this.lblHeader.Name = "lblHeader";
          this.lblHeader.Size = new System.Drawing.Size(349, 24);
          this.lblHeader.TabIndex = 7;
          this.lblHeader.Text = "Búsqueda de códigos de Aerolineas";
          this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
          this.lblHeader.Click += new System.EventHandler(this.lblHeader_Click);
          // 
          // dgvCodesAirLines
          // 
          this.dgvCodesAirLines.AllowUserToAddRows = false;
          this.dgvCodesAirLines.AllowUserToDeleteRows = false;
          this.dgvCodesAirLines.AllowUserToResizeRows = false;
          this.dgvCodesAirLines.AutoGenerateColumns = false;
          this.dgvCodesAirLines.BackgroundColor = System.Drawing.Color.FloralWhite;
          this.dgvCodesAirLines.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
          this.dgvCodesAirLines.ColumnHeadersHeight = 25;
          this.dgvCodesAirLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
          this.dgvCodesAirLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.airLineIDDataGridViewTextBoxColumn,
            this.airLineNameDataGridViewTextBoxColumn});
          this.dgvCodesAirLines.DataSource = this.bindingSource1;
          this.dgvCodesAirLines.Dock = System.Windows.Forms.DockStyle.Left;
          this.dgvCodesAirLines.GridColor = System.Drawing.Color.White;
          this.dgvCodesAirLines.Location = new System.Drawing.Point(3, 27);
          this.dgvCodesAirLines.MultiSelect = false;
          this.dgvCodesAirLines.Name = "dgvCodesAirLines";
          this.dgvCodesAirLines.ReadOnly = true;
          this.dgvCodesAirLines.RowHeadersWidth = 30;
          this.dgvCodesAirLines.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
          this.dgvCodesAirLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
          this.dgvCodesAirLines.Size = new System.Drawing.Size(349, 379);
          this.dgvCodesAirLines.TabIndex = 6;
          this.dgvCodesAirLines.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCodesAirLines_CellDoubleClick);
          // 
          // airLineIDDataGridViewTextBoxColumn
          // 
          this.airLineIDDataGridViewTextBoxColumn.DataPropertyName = "AirLineID";
          this.airLineIDDataGridViewTextBoxColumn.HeaderText = "AirLineID";
          this.airLineIDDataGridViewTextBoxColumn.Name = "airLineIDDataGridViewTextBoxColumn";
          this.airLineIDDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // airLineNameDataGridViewTextBoxColumn
          // 
          this.airLineNameDataGridViewTextBoxColumn.DataPropertyName = "AirLineName";
          this.airLineNameDataGridViewTextBoxColumn.HeaderText = "AirLineName";
          this.airLineNameDataGridViewTextBoxColumn.Name = "airLineNameDataGridViewTextBoxColumn";
          this.airLineNameDataGridViewTextBoxColumn.ReadOnly = true;
          // 
          // bindingSource1
          // 
          this.bindingSource1.DataSource = typeof(MyCTS.Entities.AirLinesFare);
          // 
          // tblLayoutMain
          // 
          this.tblLayoutMain.ColumnCount = 1;
          this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
          this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
          this.tblLayoutMain.Controls.Add(this.dgvCodesAirLines, 0, 1);
          this.tblLayoutMain.Controls.Add(this.lblHeader, 0, 0);
          this.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Left;
          this.tblLayoutMain.Location = new System.Drawing.Point(0, 0);
          this.tblLayoutMain.Name = "tblLayoutMain";
          this.tblLayoutMain.RowCount = 2;
          this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.925926F));
          this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.07407F));
          this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
          this.tblLayoutMain.Size = new System.Drawing.Size(355, 409);
          this.tblLayoutMain.TabIndex = 0;
          // 
          // comboBox1
          // 
          this.comboBox1.DisplayMember = "Text";
          this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.comboBox1.FormattingEnabled = true;
          this.comboBox1.Location = new System.Drawing.Point(361, 27);
          this.comboBox1.Name = "comboBox1";
          this.comboBox1.Size = new System.Drawing.Size(189, 21);
          this.comboBox1.TabIndex = 1;
          this.comboBox1.ValueMember = "Value";
          this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
          // 
          // textBox1
          // 
          this.textBox1.Location = new System.Drawing.Point(361, 54);
          this.textBox1.Name = "textBox1";
          this.textBox1.Size = new System.Drawing.Size(100, 20);
          this.textBox1.TabIndex = 2;
          // 
          // comboBox2
          // 
          this.comboBox2.FormattingEnabled = true;
          this.comboBox2.Location = new System.Drawing.Point(386, 148);
          this.comboBox2.Name = "comboBox2";
          this.comboBox2.Size = new System.Drawing.Size(186, 21);
          this.comboBox2.TabIndex = 3;
          // 
          // frmSerchAirLinesFare
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.White;
          this.ClientSize = new System.Drawing.Size(640, 409);
          this.Controls.Add(this.comboBox2);
          this.Controls.Add(this.textBox1);
          this.Controls.Add(this.comboBox1);
          this.Controls.Add(this.tblLayoutMain);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "frmSerchAirLinesFare";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "MyCTS";
          ((System.ComponentModel.ISupportInitialize)(this.dgvCodesAirLines)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
          this.tblLayoutMain.ResumeLayout(false);
          this.tblLayoutMain.PerformLayout();
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblHeader;
      private System.Windows.Forms.DataGridView dgvCodesAirLines;
      private System.Windows.Forms.TableLayoutPanel tblLayoutMain;
       private System.Windows.Forms.BindingSource bindingSource1;
       private System.Windows.Forms.DataGridViewTextBoxColumn airLineIDDataGridViewTextBoxColumn;
       private System.Windows.Forms.DataGridViewTextBoxColumn airLineNameDataGridViewTextBoxColumn;
       private System.Windows.Forms.ComboBox comboBox1;
       private MyCTS.Forms.UI.SmartTextBox textBox1;
       private System.Windows.Forms.ComboBox comboBox2;

   }
}