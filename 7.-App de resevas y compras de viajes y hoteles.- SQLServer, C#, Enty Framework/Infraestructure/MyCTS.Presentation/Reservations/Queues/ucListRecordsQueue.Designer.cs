namespace MyCTS.Presentation
{
    partial class ucListRecordsQueue
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
            this.lblListRecordsQueue = new System.Windows.Forms.Label();
            this.lblQueue = new System.Windows.Forms.Label();
            this.txtQueue = new MyCTS.Forms.UI.SmartTextBox();
            this.txtpcc = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblPCC = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblListRecordsQueue
            // 
            this.lblListRecordsQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblListRecordsQueue.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListRecordsQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListRecordsQueue.ForeColor = System.Drawing.Color.White;
            this.lblListRecordsQueue.Location = new System.Drawing.Point(0, 0);
            this.lblListRecordsQueue.Name = "lblListRecordsQueue";
            this.lblListRecordsQueue.Size = new System.Drawing.Size(411, 17);
            this.lblListRecordsQueue.TabIndex = 0;
            this.lblListRecordsQueue.Text = "Lista de Records en Queue";
            this.lblListRecordsQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQueue
            // 
            this.lblQueue.AutoSize = true;
            this.lblQueue.Location = new System.Drawing.Point(14, 44);
            this.lblQueue.Name = "lblQueue";
            this.lblQueue.Size = new System.Drawing.Size(39, 13);
            this.lblQueue.TabIndex = 0;
            this.lblQueue.Text = "Queue";
            this.lblQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtQueue
            // 
            this.txtQueue.AllowBlankSpaces = true;
            this.txtQueue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQueue.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtQueue.CustomExpression = ".*";
            this.txtQueue.EnterColor = System.Drawing.Color.Empty;
            this.txtQueue.LeaveColor = System.Drawing.Color.Empty;
            this.txtQueue.Location = new System.Drawing.Point(17, 78);
            this.txtQueue.MaxLength = 3;
            this.txtQueue.Name = "txtQueue";
            this.txtQueue.Size = new System.Drawing.Size(46, 20);
            this.txtQueue.TabIndex = 1;
            this.txtQueue.TextChanged += new System.EventHandler(this.txtQueue_TextChanged);
            this.txtQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtpcc
            // 
            this.txtpcc.AllowBlankSpaces = true;
            this.txtpcc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpcc.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtpcc.CustomExpression = ".*";
            this.txtpcc.EnterColor = System.Drawing.Color.Empty;
            this.txtpcc.LeaveColor = System.Drawing.Color.Empty;
            this.txtpcc.Location = new System.Drawing.Point(84, 78);
            this.txtpcc.MaxLength = 4;
            this.txtpcc.Name = "txtpcc";
            this.txtpcc.Size = new System.Drawing.Size(53, 20);
            this.txtpcc.TabIndex = 2;
            this.txtpcc.TextChanged += new System.EventHandler(this.txtpcc_TextChanged);
            this.txtpcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(221, 163);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblPCC.Location = new System.Drawing.Point(88, 44);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(28, 13);
            this.lblPCC.TabIndex = 0;
            this.lblPCC.Text = "PCC";
            // 
            // ucListRecordsQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblListRecordsQueue);
            this.Controls.Add(this.lblQueue);
            this.Controls.Add(this.txtQueue);
            this.Controls.Add(this.txtpcc);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblPCC);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucListRecordsQueue";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucListRecordsQueue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblListRecordsQueue;
        private System.Windows.Forms.Label lblQueue;
        private MyCTS.Forms.UI.SmartTextBox txtQueue;
        private MyCTS.Forms.UI.SmartTextBox txtpcc;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblPCC;
    }
}
