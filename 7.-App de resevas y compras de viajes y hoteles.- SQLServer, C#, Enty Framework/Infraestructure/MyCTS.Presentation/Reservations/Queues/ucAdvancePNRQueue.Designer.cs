namespace MyCTS.Presentation
{
    partial class ucAdvancePNRQueue
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
            this.lblCountRecordsInQueue = new System.Windows.Forms.Label();
            this.lblAhead = new System.Windows.Forms.Label();
            this.rdoIgnoreRecord = new System.Windows.Forms.RadioButton();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblSelectOption = new System.Windows.Forms.Label();
            this.rdoFinalizeTransaction = new System.Windows.Forms.RadioButton();
            this.rdoRemoveRecord = new System.Windows.Forms.RadioButton();
            this.lblDisplaceRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtForward = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAhead = new MyCTS.Forms.UI.SmartTextBox();
            this.SuspendLayout();
            // 
            // lblCountRecordsInQueue
            // 
            this.lblCountRecordsInQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblCountRecordsInQueue.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCountRecordsInQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountRecordsInQueue.ForeColor = System.Drawing.Color.White;
            this.lblCountRecordsInQueue.Location = new System.Drawing.Point(0, 0);
            this.lblCountRecordsInQueue.Name = "lblCountRecordsInQueue";
            this.lblCountRecordsInQueue.Size = new System.Drawing.Size(411, 17);
            this.lblCountRecordsInQueue.TabIndex = 0;
            this.lblCountRecordsInQueue.Text = "Avanzar PNR en Queue";
            this.lblCountRecordsInQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAhead
            // 
            this.lblAhead.AutoSize = true;
            this.lblAhead.Location = new System.Drawing.Point(32, 267);
            this.lblAhead.Name = "lblAhead";
            this.lblAhead.Size = new System.Drawing.Size(52, 13);
            this.lblAhead.TabIndex = 0;
            this.lblAhead.Text = "Adelante:";
            this.lblAhead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoIgnoreRecord
            // 
            this.rdoIgnoreRecord.AutoSize = true;
            this.rdoIgnoreRecord.Location = new System.Drawing.Point(35, 80);
            this.rdoIgnoreRecord.Name = "rdoIgnoreRecord";
            this.rdoIgnoreRecord.Size = new System.Drawing.Size(95, 17);
            this.rdoIgnoreRecord.TabIndex = 1;
            this.rdoIgnoreRecord.TabStop = true;
            this.rdoIgnoreRecord.Text = "Ignorar registro";
            this.rdoIgnoreRecord.UseVisualStyleBackColor = true;
            this.rdoIgnoreRecord.CheckedChanged += new System.EventHandler(this.rdoIgnoreRecord_CheckedChanged);
            this.rdoIgnoreRecord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(243, 366);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblSelectOption
            // 
            this.lblSelectOption.AutoSize = true;
            this.lblSelectOption.Location = new System.Drawing.Point(32, 40);
            this.lblSelectOption.Name = "lblSelectOption";
            this.lblSelectOption.Size = new System.Drawing.Size(119, 13);
            this.lblSelectOption.TabIndex = 0;
            this.lblSelectOption.Text = "Selecciona una opción:";
            this.lblSelectOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoFinalizeTransaction
            // 
            this.rdoFinalizeTransaction.AutoSize = true;
            this.rdoFinalizeTransaction.Location = new System.Drawing.Point(35, 118);
            this.rdoFinalizeTransaction.Name = "rdoFinalizeTransaction";
            this.rdoFinalizeTransaction.Size = new System.Drawing.Size(121, 17);
            this.rdoFinalizeTransaction.TabIndex = 2;
            this.rdoFinalizeTransaction.TabStop = true;
            this.rdoFinalizeTransaction.Text = "Finalizar transacción";
            this.rdoFinalizeTransaction.UseVisualStyleBackColor = true;
            this.rdoFinalizeTransaction.CheckedChanged += new System.EventHandler(this.rdoFinalizeTransaction_CheckedChanged);
            this.rdoFinalizeTransaction.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoRemoveRecord
            // 
            this.rdoRemoveRecord.AutoSize = true;
            this.rdoRemoveRecord.Location = new System.Drawing.Point(35, 157);
            this.rdoRemoveRecord.Name = "rdoRemoveRecord";
            this.rdoRemoveRecord.Size = new System.Drawing.Size(105, 17);
            this.rdoRemoveRecord.TabIndex = 3;
            this.rdoRemoveRecord.TabStop = true;
            this.rdoRemoveRecord.Text = "Remover registro";
            this.rdoRemoveRecord.UseVisualStyleBackColor = true;
            this.rdoRemoveRecord.CheckedChanged += new System.EventHandler(this.rdoRemoveRecord_CheckedChanged);
            this.rdoRemoveRecord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblDisplaceRecords
            // 
            this.lblDisplaceRecords.AutoSize = true;
            this.lblDisplaceRecords.Location = new System.Drawing.Point(32, 226);
            this.lblDisplaceRecords.Name = "lblDisplaceRecords";
            this.lblDisplaceRecords.Size = new System.Drawing.Size(150, 13);
            this.lblDisplaceRecords.TabIndex = 0;
            this.lblDisplaceRecords.Text = "Desplazar records en Queues:";
            this.lblDisplaceRecords.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Atras:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtForward
            // 
            this.txtForward.AllowBlankSpaces = true;
            this.txtForward.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtForward.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtForward.CustomExpression = ".*";
            this.txtForward.EnterColor = System.Drawing.Color.Empty;
            this.txtForward.LeaveColor = System.Drawing.Color.Empty;
            this.txtForward.Location = new System.Drawing.Point(195, 264);
            this.txtForward.MaxLength = 5;
            this.txtForward.Name = "txtForward";
            this.txtForward.Size = new System.Drawing.Size(50, 20);
            this.txtForward.TabIndex = 5;
            this.txtForward.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtAhead
            // 
            this.txtAhead.AllowBlankSpaces = true;
            this.txtAhead.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAhead.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtAhead.CustomExpression = ".*";
            this.txtAhead.EnterColor = System.Drawing.Color.Empty;
            this.txtAhead.LeaveColor = System.Drawing.Color.Empty;
            this.txtAhead.Location = new System.Drawing.Point(90, 264);
            this.txtAhead.MaxLength = 5;
            this.txtAhead.Name = "txtAhead";
            this.txtAhead.Size = new System.Drawing.Size(50, 20);
            this.txtAhead.TabIndex = 4;
            this.txtAhead.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucAdvancePNRQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtForward);
            this.Controls.Add(this.lblDisplaceRecords);
            this.Controls.Add(this.rdoRemoveRecord);
            this.Controls.Add(this.rdoFinalizeTransaction);
            this.Controls.Add(this.lblSelectOption);
            this.Controls.Add(this.lblCountRecordsInQueue);
            this.Controls.Add(this.lblAhead);
            this.Controls.Add(this.rdoIgnoreRecord);
            this.Controls.Add(this.txtAhead);
            this.Controls.Add(this.btnAccept);
            this.Name = "ucAdvancePNRQueue";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucAdvancePNRQueue_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblCountRecordsInQueue;
        private System.Windows.Forms.Label lblAhead;
        private System.Windows.Forms.RadioButton rdoIgnoreRecord;
        private MyCTS.Forms.UI.SmartTextBox txtAhead;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblSelectOption;
        private System.Windows.Forms.RadioButton rdoFinalizeTransaction;
        private System.Windows.Forms.RadioButton rdoRemoveRecord;
        private System.Windows.Forms.Label lblDisplaceRecords;
        private System.Windows.Forms.Label label3;
        private MyCTS.Forms.UI.SmartTextBox txtForward;
    }
}
