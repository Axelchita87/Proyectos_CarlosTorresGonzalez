namespace MyCTS.Presentation
{
    partial class ucHistoryRecordInQueue
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
            this.lblHistoryRecordInQueue = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.rdoOrderedByFile = new System.Windows.Forms.RadioButton();
            this.rdoInFile = new System.Windows.Forms.RadioButton();
            this.rdoActualInOrderByDate = new System.Windows.Forms.RadioButton();
            this.rdoActualInOrderByQueue = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblHistoryRecordInQueue
            // 
            this.lblHistoryRecordInQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblHistoryRecordInQueue.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHistoryRecordInQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistoryRecordInQueue.ForeColor = System.Drawing.Color.White;
            this.lblHistoryRecordInQueue.Location = new System.Drawing.Point(0, 0);
            this.lblHistoryRecordInQueue.Name = "lblHistoryRecordInQueue";
            this.lblHistoryRecordInQueue.Size = new System.Drawing.Size(411, 17);
            this.lblHistoryRecordInQueue.TabIndex = 0;
            this.lblHistoryRecordInQueue.Text = "Historia de Record en Queue";
            this.lblHistoryRecordInQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(205, 232);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoOrderedByFile
            // 
            this.rdoOrderedByFile.AutoSize = true;
            this.rdoOrderedByFile.Location = new System.Drawing.Point(29, 165);
            this.rdoOrderedByFile.Name = "rdoOrderedByFile";
            this.rdoOrderedByFile.Size = new System.Drawing.Size(128, 17);
            this.rdoOrderedByFile.TabIndex = 4;
            this.rdoOrderedByFile.TabStop = true;
            this.rdoOrderedByFile.Text = "Ordenada por archivo";
            this.rdoOrderedByFile.UseVisualStyleBackColor = true;
            this.rdoOrderedByFile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoInFile
            // 
            this.rdoInFile.AutoSize = true;
            this.rdoInFile.Location = new System.Drawing.Point(29, 126);
            this.rdoInFile.Name = "rdoInFile";
            this.rdoInFile.Size = new System.Drawing.Size(73, 17);
            this.rdoInFile.TabIndex = 3;
            this.rdoInFile.TabStop = true;
            this.rdoInFile.Text = "Archivado";
            this.rdoInFile.UseVisualStyleBackColor = true;
            this.rdoInFile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoActualInOrderByDate
            // 
            this.rdoActualInOrderByDate.AutoSize = true;
            this.rdoActualInOrderByDate.Location = new System.Drawing.Point(29, 88);
            this.rdoActualInOrderByDate.Name = "rdoActualInOrderByDate";
            this.rdoActualInOrderByDate.Size = new System.Drawing.Size(148, 17);
            this.rdoActualInOrderByDate.TabIndex = 2;
            this.rdoActualInOrderByDate.TabStop = true;
            this.rdoActualInOrderByDate.Text = "Actual en orden por fecha";
            this.rdoActualInOrderByDate.UseVisualStyleBackColor = true;
            this.rdoActualInOrderByDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoActualInOrderByQueue
            // 
            this.rdoActualInOrderByQueue.AutoSize = true;
            this.rdoActualInOrderByQueue.Location = new System.Drawing.Point(29, 48);
            this.rdoActualInOrderByQueue.Name = "rdoActualInOrderByQueue";
            this.rdoActualInOrderByQueue.Size = new System.Drawing.Size(153, 17);
            this.rdoActualInOrderByQueue.TabIndex = 1;
            this.rdoActualInOrderByQueue.TabStop = true;
            this.rdoActualInOrderByQueue.Text = "Actual en orden por Queue";
            this.rdoActualInOrderByQueue.UseVisualStyleBackColor = true;
            this.rdoActualInOrderByQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucHistoryRecordInQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.rdoActualInOrderByQueue);
            this.Controls.Add(this.rdoOrderedByFile);
            this.Controls.Add(this.rdoInFile);
            this.Controls.Add(this.rdoActualInOrderByDate);
            this.Controls.Add(this.lblHistoryRecordInQueue);
            this.Controls.Add(this.btnAccept);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucHistoryRecordInQueue";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucHistoryRecordInQueue_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblHistoryRecordInQueue;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.RadioButton rdoOrderedByFile;
        private System.Windows.Forms.RadioButton rdoInFile;
        private System.Windows.Forms.RadioButton rdoActualInOrderByDate;
        private System.Windows.Forms.RadioButton rdoActualInOrderByQueue;
    }
}
