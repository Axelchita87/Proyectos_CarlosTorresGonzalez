namespace MyCTS.Presentation
{
    partial class ucExitFromQueue
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
            this.lblSelectOption = new System.Windows.Forms.Label();
            this.lblExitFromQueue = new System.Windows.Forms.Label();
            this.rdoFinalize = new System.Windows.Forms.RadioButton();
            this.btnAccept = new System.Windows.Forms.Button();
            this.rdoIgnoreAndDisplay = new System.Windows.Forms.RadioButton();
            this.rdoFinalizeAndDisplay = new System.Windows.Forms.RadioButton();
            this.rdoIgnore = new System.Windows.Forms.RadioButton();
            this.rdoRemove = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblSelectOption
            // 
            this.lblSelectOption.AutoSize = true;
            this.lblSelectOption.Location = new System.Drawing.Point(32, 50);
            this.lblSelectOption.Name = "lblSelectOption";
            this.lblSelectOption.Size = new System.Drawing.Size(119, 13);
            this.lblSelectOption.TabIndex = 0;
            this.lblSelectOption.Text = "Selecciona una opción:";
            this.lblSelectOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExitFromQueue
            // 
            this.lblExitFromQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblExitFromQueue.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblExitFromQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExitFromQueue.ForeColor = System.Drawing.Color.White;
            this.lblExitFromQueue.Location = new System.Drawing.Point(0, 0);
            this.lblExitFromQueue.Name = "lblExitFromQueue";
            this.lblExitFromQueue.Size = new System.Drawing.Size(411, 17);
            this.lblExitFromQueue.TabIndex = 0;
            this.lblExitFromQueue.Text = "Salir de Queues";
            this.lblExitFromQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoFinalize
            // 
            this.rdoFinalize.AutoSize = true;
            this.rdoFinalize.Location = new System.Drawing.Point(35, 89);
            this.rdoFinalize.Name = "rdoFinalize";
            this.rdoFinalize.Size = new System.Drawing.Size(63, 17);
            this.rdoFinalize.TabIndex = 1;
            this.rdoFinalize.TabStop = true;
            this.rdoFinalize.Text = "Finalizar";
            this.rdoFinalize.UseVisualStyleBackColor = true;
            this.rdoFinalize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(243, 321);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoIgnoreAndDisplay
            // 
            this.rdoIgnoreAndDisplay.AutoSize = true;
            this.rdoIgnoreAndDisplay.Location = new System.Drawing.Point(35, 229);
            this.rdoIgnoreAndDisplay.Name = "rdoIgnoreAndDisplay";
            this.rdoIgnoreAndDisplay.Size = new System.Drawing.Size(124, 17);
            this.rdoIgnoreAndDisplay.TabIndex = 5;
            this.rdoIgnoreAndDisplay.TabStop = true;
            this.rdoIgnoreAndDisplay.Text = "Ignorar y redesplegar";
            this.rdoIgnoreAndDisplay.UseVisualStyleBackColor = true;
            this.rdoIgnoreAndDisplay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoFinalizeAndDisplay
            // 
            this.rdoFinalizeAndDisplay.AutoSize = true;
            this.rdoFinalizeAndDisplay.Location = new System.Drawing.Point(35, 193);
            this.rdoFinalizeAndDisplay.Name = "rdoFinalizeAndDisplay";
            this.rdoFinalizeAndDisplay.Size = new System.Drawing.Size(129, 17);
            this.rdoFinalizeAndDisplay.TabIndex = 4;
            this.rdoFinalizeAndDisplay.TabStop = true;
            this.rdoFinalizeAndDisplay.Text = "Finalizar y redesplegar";
            this.rdoFinalizeAndDisplay.UseVisualStyleBackColor = true;
            this.rdoFinalizeAndDisplay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoIgnore
            // 
            this.rdoIgnore.AutoSize = true;
            this.rdoIgnore.Location = new System.Drawing.Point(35, 158);
            this.rdoIgnore.Name = "rdoIgnore";
            this.rdoIgnore.Size = new System.Drawing.Size(58, 17);
            this.rdoIgnore.TabIndex = 3;
            this.rdoIgnore.TabStop = true;
            this.rdoIgnore.Text = "Ignorar";
            this.rdoIgnore.UseVisualStyleBackColor = true;
            this.rdoIgnore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoRemove
            // 
            this.rdoRemove.AutoSize = true;
            this.rdoRemove.Location = new System.Drawing.Point(35, 124);
            this.rdoRemove.Name = "rdoRemove";
            this.rdoRemove.Size = new System.Drawing.Size(68, 17);
            this.rdoRemove.TabIndex = 2;
            this.rdoRemove.TabStop = true;
            this.rdoRemove.Text = "Remover";
            this.rdoRemove.UseVisualStyleBackColor = true;
            this.rdoRemove.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucExitFromQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.rdoRemove);
            this.Controls.Add(this.rdoIgnore);
            this.Controls.Add(this.rdoFinalizeAndDisplay);
            this.Controls.Add(this.rdoIgnoreAndDisplay);
            this.Controls.Add(this.lblSelectOption);
            this.Controls.Add(this.lblExitFromQueue);
            this.Controls.Add(this.rdoFinalize);
            this.Controls.Add(this.btnAccept);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucExitFromQueue";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucExitFromQueue_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectOption;
        internal System.Windows.Forms.Label lblExitFromQueue;
        private System.Windows.Forms.RadioButton rdoFinalize;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.RadioButton rdoIgnoreAndDisplay;
        private System.Windows.Forms.RadioButton rdoFinalizeAndDisplay;
        private System.Windows.Forms.RadioButton rdoIgnore;
        private System.Windows.Forms.RadioButton rdoRemove;
    }
}
