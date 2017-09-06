namespace MyCTS.Presentation
{
    partial class ucServicesFeePayApply
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvwCargosAplicados = new System.Windows.Forms.DataGridView();
            this.PAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MENSAJE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AUTORIZACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OPERACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvwCargosAplicados)).BeginInit();
            this.SuspendLayout();
            // 
            // gvwCargosAplicados
            // 
            this.gvwCargosAplicados.AllowUserToAddRows = false;
            this.gvwCargosAplicados.AllowUserToDeleteRows = false;
            this.gvwCargosAplicados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvwCargosAplicados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvwCargosAplicados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PAX,
            this.MONTO,
            this.ESTATUS,
            this.MENSAJE,
            this.AUTORIZACION,
            this.OPERACION});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvwCargosAplicados.DefaultCellStyle = dataGridViewCellStyle1;
            this.gvwCargosAplicados.Location = new System.Drawing.Point(3, 30);
            this.gvwCargosAplicados.Name = "gvwCargosAplicados";
            this.gvwCargosAplicados.ReadOnly = true;
            this.gvwCargosAplicados.Size = new System.Drawing.Size(414, 342);
            this.gvwCargosAplicados.TabIndex = 0;
            // 
            // PAX
            // 
            this.PAX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PAX.DataPropertyName = "PAX";
            this.PAX.HeaderText = "PAX";
            this.PAX.Name = "PAX";
            this.PAX.ReadOnly = true;
            this.PAX.Width = 53;
            // 
            // MONTO
            // 
            this.MONTO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MONTO.DataPropertyName = "MONTO";
            this.MONTO.HeaderText = "MONTO";
            this.MONTO.Name = "MONTO";
            this.MONTO.ReadOnly = true;
            this.MONTO.Width = 72;
            // 
            // ESTATUS
            // 
            this.ESTATUS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ESTATUS.DataPropertyName = "ESTATUS";
            this.ESTATUS.HeaderText = "ESTATUS";
            this.ESTATUS.Name = "ESTATUS";
            this.ESTATUS.ReadOnly = true;
            this.ESTATUS.Width = 82;
            // 
            // MENSAJE
            // 
            this.MENSAJE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MENSAJE.DataPropertyName = "MENSAJE";
            this.MENSAJE.HeaderText = "MENSAJE";
            this.MENSAJE.Name = "MENSAJE";
            this.MENSAJE.ReadOnly = true;
            this.MENSAJE.Width = 82;
            // 
            // AUTORIZACION
            // 
            this.AUTORIZACION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AUTORIZACION.DataPropertyName = "AUTORIZACION";
            this.AUTORIZACION.HeaderText = "AUTORIZACION";
            this.AUTORIZACION.Name = "AUTORIZACION";
            this.AUTORIZACION.ReadOnly = true;
            this.AUTORIZACION.Width = 113;
            // 
            // OPERACION
            // 
            this.OPERACION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.OPERACION.DataPropertyName = "OPERACION";
            this.OPERACION.HeaderText = "OPERACION";
            this.OPERACION.Name = "OPERACION";
            this.OPERACION.ReadOnly = true;
            this.OPERACION.Width = 95;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(6, 375);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 64);
            this.label1.TabIndex = 2;
            this.label1.Text = "Para los Cargos por Servicio que no fueron aplicados los debes \r\nrealizar de form" +
                "a independiente desde la siguiente opción:\r\n\r\nMódulos + Cargo por Servicio + Ing" +
                "resar Cargo por Servicio\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Resumen de cargos en línea";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Location = new System.Drawing.Point(307, 442);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(110, 24);
            this.btnFinalizar.TabIndex = 55;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // ucServicesFeePayApply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvwCargosAplicados);
            this.Name = "ucServicesFeePayApply";
            this.Size = new System.Drawing.Size(420, 623);
            this.Load += new System.EventHandler(this.ucServicesFeePayApply_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvwCargosAplicados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvwCargosAplicados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn MENSAJE;
        private System.Windows.Forms.DataGridViewTextBoxColumn AUTORIZACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn OPERACION;
        private System.Windows.Forms.Button btnFinalizar;
    }
}
