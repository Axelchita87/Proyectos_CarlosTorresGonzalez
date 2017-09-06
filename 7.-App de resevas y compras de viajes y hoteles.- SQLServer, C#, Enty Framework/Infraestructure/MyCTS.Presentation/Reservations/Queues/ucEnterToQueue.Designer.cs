namespace MyCTS.Presentation
{
    partial class ucEnterToQueue
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtQueue = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAdvancePosition = new MyCTS.Forms.UI.SmartTextBox();
            this.lblQueue = new System.Windows.Forms.Label();
            this.lblPCC = new System.Windows.Forms.Label();
            this.lblAdvancePosition = new System.Windows.Forms.Label();
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
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Ingresar a una Queue";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(249, 158);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtQueue
            // 
            this.txtQueue.AllowBlankSpaces = false;
            this.txtQueue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQueue.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtQueue.CustomExpression = ".*";
            this.txtQueue.EnterColor = System.Drawing.Color.Empty;
            this.txtQueue.LeaveColor = System.Drawing.Color.Empty;
            this.txtQueue.Location = new System.Drawing.Point(90, 41);
            this.txtQueue.Name = "txtQueue";
            this.txtQueue.Size = new System.Drawing.Size(29, 20);
            this.txtQueue.TabIndex = 1;
            this.txtQueue.TextChanged += new System.EventHandler(this.txtQueue_TextChanged);
            this.txtQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = false;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(90, 69);
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(45, 20);
            this.txtPCC.TabIndex = 2;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtAdvancePosition
            // 
            this.txtAdvancePosition.AllowBlankSpaces = false;
            this.txtAdvancePosition.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAdvancePosition.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtAdvancePosition.CustomExpression = ".*";
            this.txtAdvancePosition.EnterColor = System.Drawing.Color.Empty;
            this.txtAdvancePosition.LeaveColor = System.Drawing.Color.Empty;
            this.txtAdvancePosition.Location = new System.Drawing.Point(141, 96);
            this.txtAdvancePosition.Name = "txtAdvancePosition";
            this.txtAdvancePosition.Size = new System.Drawing.Size(33, 20);
            this.txtAdvancePosition.TabIndex = 3;
            this.txtAdvancePosition.TextChanged += new System.EventHandler(this.txtAdvancePosition_TextChanged);
            this.txtAdvancePosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblQueue
            // 
            this.lblQueue.AutoSize = true;
            this.lblQueue.Location = new System.Drawing.Point(35, 44);
            this.lblQueue.Name = "lblQueue";
            this.lblQueue.Size = new System.Drawing.Size(42, 13);
            this.lblQueue.TabIndex = 0;
            this.lblQueue.Text = "Queue:";
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblPCC.Location = new System.Drawing.Point(35, 72);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(31, 13);
            this.lblPCC.TabIndex = 55;
            this.lblPCC.Text = "PCC:";
            // 
            // lblAdvancePosition
            // 
            this.lblAdvancePosition.AutoSize = true;
            this.lblAdvancePosition.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblAdvancePosition.Location = new System.Drawing.Point(35, 99);
            this.lblAdvancePosition.Name = "lblAdvancePosition";
            this.lblAdvancePosition.Size = new System.Drawing.Size(100, 13);
            this.lblAdvancePosition.TabIndex = 0;
            this.lblAdvancePosition.Text = "Avanzar a posición:";
            // 
            // ucEnterToQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblAdvancePosition);
            this.Controls.Add(this.lblPCC);
            this.Controls.Add(this.lblQueue);
            this.Controls.Add(this.txtAdvancePosition);
            this.Controls.Add(this.txtPCC);
            this.Controls.Add(this.txtQueue);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucEnterToQueue";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucEnterToQueue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtQueue;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private MyCTS.Forms.UI.SmartTextBox txtAdvancePosition;
        private System.Windows.Forms.Label lblQueue;
        private System.Windows.Forms.Label lblPCC;
        private System.Windows.Forms.Label lblAdvancePosition;
    }
}
