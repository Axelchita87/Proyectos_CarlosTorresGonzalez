namespace MyCTS.Presentation
{
    partial class ucAccountsRecordQueues
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
            this.txtCodePseudoCity = new MyCTS.Forms.UI.SmartTextBox();
            this.lblColony = new System.Windows.Forms.Label();
            this.lblBillingAdress = new System.Windows.Forms.Label();
            this.lblQueue = new System.Windows.Forms.Label();
            this.lblStreet = new System.Windows.Forms.Label();
            this.txtQueue = new MyCTS.Forms.UI.SmartTextBox();
            this.txtQueue2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRange = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblRange = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCodePseudoCity
            // 
            this.txtCodePseudoCity.AllowBlankSpaces = true;
            this.txtCodePseudoCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodePseudoCity.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtCodePseudoCity.CustomExpression = ".*";
            this.txtCodePseudoCity.EnterColor = System.Drawing.Color.Empty;
            this.txtCodePseudoCity.LeaveColor = System.Drawing.Color.Empty;
            this.txtCodePseudoCity.Location = new System.Drawing.Point(122, 123);
            this.txtCodePseudoCity.MaxLength = 4;
            this.txtCodePseudoCity.Name = "txtCodePseudoCity";
            this.txtCodePseudoCity.Size = new System.Drawing.Size(65, 20);
            this.txtCodePseudoCity.TabIndex = 4;
            this.txtCodePseudoCity.TextChanged += new System.EventHandler(this.txtCodePseudoCity_TextChanged);
            this.txtCodePseudoCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblColony
            // 
            this.lblColony.AutoSize = true;
            this.lblColony.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblColony.Location = new System.Drawing.Point(14, 126);
            this.lblColony.Name = "lblColony";
            this.lblColony.Size = new System.Drawing.Size(102, 13);
            this.lblColony.TabIndex = 0;
            this.lblColony.Text = "Código Pseudo City:";
            // 
            // lblBillingAdress
            // 
            this.lblBillingAdress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblBillingAdress.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBillingAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillingAdress.ForeColor = System.Drawing.Color.White;
            this.lblBillingAdress.Location = new System.Drawing.Point(0, 0);
            this.lblBillingAdress.Name = "lblBillingAdress";
            this.lblBillingAdress.Size = new System.Drawing.Size(411, 17);
            this.lblBillingAdress.TabIndex = 0;
            this.lblBillingAdress.Text = "Cuentas Record en Queue";
            this.lblBillingAdress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQueue
            // 
            this.lblQueue.AutoSize = true;
            this.lblQueue.Location = new System.Drawing.Point(14, 37);
            this.lblQueue.Name = "lblQueue";
            this.lblQueue.Size = new System.Drawing.Size(39, 13);
            this.lblQueue.TabIndex = 0;
            this.lblQueue.Text = "Queue";
            this.lblQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(71, 65);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(10, 13);
            this.lblStreet.TabIndex = 0;
            this.lblStreet.Text = "-";
            // 
            // txtQueue
            // 
            this.txtQueue.AllowBlankSpaces = true;
            this.txtQueue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQueue.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtQueue.CustomExpression = ".*";
            this.txtQueue.EnterColor = System.Drawing.Color.Empty;
            this.txtQueue.LeaveColor = System.Drawing.Color.Empty;
            this.txtQueue.Location = new System.Drawing.Point(17, 62);
            this.txtQueue.MaxLength = 3;
            this.txtQueue.Name = "txtQueue";
            this.txtQueue.Size = new System.Drawing.Size(48, 20);
            this.txtQueue.TabIndex = 1;
            this.txtQueue.TextChanged += new System.EventHandler(this.txtQueue_TextChanged);
            this.txtQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtQueue2
            // 
            this.txtQueue2.AllowBlankSpaces = true;
            this.txtQueue2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQueue2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtQueue2.CustomExpression = ".*";
            this.txtQueue2.EnterColor = System.Drawing.Color.Empty;
            this.txtQueue2.LeaveColor = System.Drawing.Color.Empty;
            this.txtQueue2.Location = new System.Drawing.Point(17, 88);
            this.txtQueue2.MaxLength = 3;
            this.txtQueue2.Name = "txtQueue2";
            this.txtQueue2.Size = new System.Drawing.Size(48, 20);
            this.txtQueue2.TabIndex = 3;
            this.txtQueue2.TextChanged += new System.EventHandler(this.txtQueue2_TextChanged);
            this.txtQueue2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRange
            // 
            this.txtRange.AllowBlankSpaces = true;
            this.txtRange.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtRange.CustomExpression = ".*";
            this.txtRange.EnterColor = System.Drawing.Color.Empty;
            this.txtRange.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange.Location = new System.Drawing.Point(87, 62);
            this.txtRange.MaxLength = 3;
            this.txtRange.Name = "txtRange";
            this.txtRange.Size = new System.Drawing.Size(45, 20);
            this.txtRange.TabIndex = 2;
            this.txtRange.TextChanged += new System.EventHandler(this.txtRange_TextChanged);
            this.txtRange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(236, 222);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblRange.Location = new System.Drawing.Point(84, 37);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(39, 13);
            this.lblRange.TabIndex = 0;
            this.lblRange.Text = "Rango";
            // 
            // ucAccountsRecordQueues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtCodePseudoCity);
            this.Controls.Add(this.lblColony);
            this.Controls.Add(this.lblBillingAdress);
            this.Controls.Add(this.lblQueue);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.txtQueue);
            this.Controls.Add(this.txtQueue2);
            this.Controls.Add(this.txtRange);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblRange);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucAccountsRecordQueues";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucAccountsRecordQueues_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyCTS.Forms.UI.SmartTextBox txtCodePseudoCity;
        private System.Windows.Forms.Label lblColony;
        internal System.Windows.Forms.Label lblBillingAdress;
        private System.Windows.Forms.Label lblQueue;
        private System.Windows.Forms.Label lblStreet;
        private MyCTS.Forms.UI.SmartTextBox txtQueue;
        private MyCTS.Forms.UI.SmartTextBox txtQueue2;
        private MyCTS.Forms.UI.SmartTextBox txtRange;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblRange;
    }
}
