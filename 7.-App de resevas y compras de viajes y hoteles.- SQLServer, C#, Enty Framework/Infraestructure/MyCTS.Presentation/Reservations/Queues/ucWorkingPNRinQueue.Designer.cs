namespace MyCTS.Presentation
{
    partial class ucWorkingPNRinQueue
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
            this.rdoNextQueue = new System.Windows.Forms.RadioButton();
            this.rdoDeletePNRinQueue = new System.Windows.Forms.RadioButton();
            this.rdoShowHistoryInQueue = new System.Windows.Forms.RadioButton();
            this.rdoShowInstructions = new System.Windows.Forms.RadioButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.tbLayoutOptions = new System.Windows.Forms.TableLayoutPanel();
            this.rdoOutOfQueue = new System.Windows.Forms.RadioButton();
            this.rdoConcludeChanges = new System.Windows.Forms.RadioButton();
            this.lblOptionSelect = new System.Windows.Forms.Label();
            this.tbLayoutOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoNextQueue
            // 
            this.rdoNextQueue.AutoSize = true;
            this.rdoNextQueue.Location = new System.Drawing.Point(3, 3);
            this.rdoNextQueue.Name = "rdoNextQueue";
            this.rdoNextQueue.Size = new System.Drawing.Size(104, 17);
            this.rdoNextQueue.TabIndex = 2;
            this.rdoNextQueue.TabStop = true;
            this.rdoNextQueue.Text = "Siguiente Queue";
            this.rdoNextQueue.UseVisualStyleBackColor = true;
            this.rdoNextQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoDeletePNRinQueue
            // 
            this.rdoDeletePNRinQueue.AutoSize = true;
            this.rdoDeletePNRinQueue.Location = new System.Drawing.Point(3, 103);
            this.rdoDeletePNRinQueue.Name = "rdoDeletePNRinQueue";
            this.rdoDeletePNRinQueue.Size = new System.Drawing.Size(129, 17);
            this.rdoDeletePNRinQueue.TabIndex = 6;
            this.rdoDeletePNRinQueue.TabStop = true;
            this.rdoDeletePNRinQueue.Text = "Quitar PNR de Queue";
            this.rdoDeletePNRinQueue.UseVisualStyleBackColor = true;
            this.rdoDeletePNRinQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoShowHistoryInQueue
            // 
            this.rdoShowHistoryInQueue.AutoSize = true;
            this.rdoShowHistoryInQueue.Location = new System.Drawing.Point(3, 53);
            this.rdoShowHistoryInQueue.Name = "rdoShowHistoryInQueue";
            this.rdoShowHistoryInQueue.Size = new System.Drawing.Size(151, 17);
            this.rdoShowHistoryInQueue.TabIndex = 4;
            this.rdoShowHistoryInQueue.TabStop = true;
            this.rdoShowHistoryInQueue.Text = "Muestra Historia en Queue";
            this.rdoShowHistoryInQueue.UseVisualStyleBackColor = true;
            this.rdoShowHistoryInQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoShowInstructions
            // 
            this.rdoShowInstructions.AutoSize = true;
            this.rdoShowInstructions.Location = new System.Drawing.Point(3, 28);
            this.rdoShowInstructions.Name = "rdoShowInstructions";
            this.rdoShowInstructions.Size = new System.Drawing.Size(129, 17);
            this.rdoShowInstructions.TabIndex = 3;
            this.rdoShowInstructions.TabStop = true;
            this.rdoShowInstructions.Text = "Muestra Instrucciones";
            this.rdoShowInstructions.UseVisualStyleBackColor = true;
            this.rdoShowInstructions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Trabajar Record  en Queue";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(224, 241);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 8;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // tbLayoutOptions
            // 
            this.tbLayoutOptions.ColumnCount = 1;
            this.tbLayoutOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutOptions.Controls.Add(this.rdoNextQueue, 0, 0);
            this.tbLayoutOptions.Controls.Add(this.rdoShowInstructions, 0, 1);
            this.tbLayoutOptions.Controls.Add(this.rdoShowHistoryInQueue, 0, 2);
            this.tbLayoutOptions.Controls.Add(this.rdoOutOfQueue, 0, 5);
            this.tbLayoutOptions.Controls.Add(this.rdoDeletePNRinQueue, 0, 4);
            this.tbLayoutOptions.Controls.Add(this.rdoConcludeChanges, 0, 3);
            this.tbLayoutOptions.Location = new System.Drawing.Point(42, 63);
            this.tbLayoutOptions.Name = "tbLayoutOptions";
            this.tbLayoutOptions.RowCount = 6;
            this.tbLayoutOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tbLayoutOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tbLayoutOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tbLayoutOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tbLayoutOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tbLayoutOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbLayoutOptions.Size = new System.Drawing.Size(218, 153);
            this.tbLayoutOptions.TabIndex = 1;
            this.tbLayoutOptions.TabStop = true;
            // 
            // rdoOutOfQueue
            // 
            this.rdoOutOfQueue.AutoSize = true;
            this.rdoOutOfQueue.Location = new System.Drawing.Point(3, 128);
            this.rdoOutOfQueue.Name = "rdoOutOfQueue";
            this.rdoOutOfQueue.Size = new System.Drawing.Size(95, 17);
            this.rdoOutOfQueue.TabIndex = 7;
            this.rdoOutOfQueue.TabStop = true;
            this.rdoOutOfQueue.Text = "Salir de Queue";
            this.rdoOutOfQueue.UseVisualStyleBackColor = true;
            this.rdoOutOfQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoConcludeChanges
            // 
            this.rdoConcludeChanges.AutoSize = true;
            this.rdoConcludeChanges.Location = new System.Drawing.Point(3, 78);
            this.rdoConcludeChanges.Name = "rdoConcludeChanges";
            this.rdoConcludeChanges.Size = new System.Drawing.Size(159, 17);
            this.rdoConcludeChanges.TabIndex = 5;
            this.rdoConcludeChanges.TabStop = true;
            this.rdoConcludeChanges.Text = "Concluir Cambios en Record";
            this.rdoConcludeChanges.UseVisualStyleBackColor = true;
            this.rdoConcludeChanges.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblOptionSelect
            // 
            this.lblOptionSelect.AutoSize = true;
            this.lblOptionSelect.Location = new System.Drawing.Point(42, 34);
            this.lblOptionSelect.Name = "lblOptionSelect";
            this.lblOptionSelect.Size = new System.Drawing.Size(119, 13);
            this.lblOptionSelect.TabIndex = 0;
            this.lblOptionSelect.Text = "Selecciona una opción:";
            // 
            // ucWorkingPNRinQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblOptionSelect);
            this.Controls.Add(this.tbLayoutOptions);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnAccept);
            this.Name = "ucWorkingPNRinQueue";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucWorkingPNRinQueue_Load);
            this.tbLayoutOptions.ResumeLayout(false);
            this.tbLayoutOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoNextQueue;
        private System.Windows.Forms.RadioButton rdoDeletePNRinQueue;
        private System.Windows.Forms.RadioButton rdoShowHistoryInQueue;
        private System.Windows.Forms.RadioButton rdoShowInstructions;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TableLayoutPanel tbLayoutOptions;
        private System.Windows.Forms.RadioButton rdoOutOfQueue;
        private System.Windows.Forms.Label lblOptionSelect;
        private System.Windows.Forms.RadioButton rdoConcludeChanges;
    }
}
