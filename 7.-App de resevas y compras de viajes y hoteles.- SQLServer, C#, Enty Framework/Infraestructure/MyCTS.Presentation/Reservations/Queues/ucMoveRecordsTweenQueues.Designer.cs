namespace MyCTS.Presentation
{
    partial class ucMoveRecordsTweenQueues
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
            this.lblPCCDestiny = new System.Windows.Forms.Label();
            this.txtPCCDestiny = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDestinyQueue = new System.Windows.Forms.Label();
            this.txtDestinyQueue = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPCCOrigin = new System.Windows.Forms.Label();
            this.txtPCCOrigin = new MyCTS.Forms.UI.SmartTextBox();
            this.lblMoveRecordTweenQueues = new System.Windows.Forms.Label();
            this.lblOriginQueue = new System.Windows.Forms.Label();
            this.txtOriginQueue = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPCCDestiny
            // 
            this.lblPCCDestiny.AutoSize = true;
            this.lblPCCDestiny.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblPCCDestiny.Location = new System.Drawing.Point(180, 104);
            this.lblPCCDestiny.Name = "lblPCCDestiny";
            this.lblPCCDestiny.Size = new System.Drawing.Size(31, 13);
            this.lblPCCDestiny.TabIndex = 10;
            this.lblPCCDestiny.Text = "PCC:";
            this.lblPCCDestiny.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPCCDestiny
            // 
            this.txtPCCDestiny.AllowBlankSpaces = true;
            this.txtPCCDestiny.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCCDestiny.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPCCDestiny.CustomExpression = ".*";
            this.txtPCCDestiny.EnterColor = System.Drawing.Color.Empty;
            this.txtPCCDestiny.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCCDestiny.Location = new System.Drawing.Point(217, 101);
            this.txtPCCDestiny.MaxLength = 4;
            this.txtPCCDestiny.Name = "txtPCCDestiny";
            this.txtPCCDestiny.Size = new System.Drawing.Size(50, 20);
            this.txtPCCDestiny.TabIndex = 14;
            this.txtPCCDestiny.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblDestinyQueue
            // 
            this.lblDestinyQueue.AutoSize = true;
            this.lblDestinyQueue.Location = new System.Drawing.Point(20, 104);
            this.lblDestinyQueue.Name = "lblDestinyQueue";
            this.lblDestinyQueue.Size = new System.Drawing.Size(81, 13);
            this.lblDestinyQueue.TabIndex = 9;
            this.lblDestinyQueue.Text = "Queue Destino:";
            this.lblDestinyQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDestinyQueue
            // 
            this.txtDestinyQueue.AllowBlankSpaces = true;
            this.txtDestinyQueue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDestinyQueue.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtDestinyQueue.CustomExpression = ".*";
            this.txtDestinyQueue.EnterColor = System.Drawing.Color.Empty;
            this.txtDestinyQueue.LeaveColor = System.Drawing.Color.Empty;
            this.txtDestinyQueue.Location = new System.Drawing.Point(101, 101);
            this.txtDestinyQueue.MaxLength = 3;
            this.txtDestinyQueue.Name = "txtDestinyQueue";
            this.txtDestinyQueue.Size = new System.Drawing.Size(50, 20);
            this.txtDestinyQueue.TabIndex = 13;
            this.txtDestinyQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblPCCOrigin
            // 
            this.lblPCCOrigin.AutoSize = true;
            this.lblPCCOrigin.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblPCCOrigin.Location = new System.Drawing.Point(180, 57);
            this.lblPCCOrigin.Name = "lblPCCOrigin";
            this.lblPCCOrigin.Size = new System.Drawing.Size(31, 13);
            this.lblPCCOrigin.TabIndex = 6;
            this.lblPCCOrigin.Text = "PCC:";
            this.lblPCCOrigin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPCCOrigin
            // 
            this.txtPCCOrigin.AllowBlankSpaces = true;
            this.txtPCCOrigin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCCOrigin.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPCCOrigin.CustomExpression = ".*";
            this.txtPCCOrigin.EnterColor = System.Drawing.Color.Empty;
            this.txtPCCOrigin.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCCOrigin.Location = new System.Drawing.Point(217, 54);
            this.txtPCCOrigin.MaxLength = 4;
            this.txtPCCOrigin.Name = "txtPCCOrigin";
            this.txtPCCOrigin.Size = new System.Drawing.Size(50, 20);
            this.txtPCCOrigin.TabIndex = 12;
            this.txtPCCOrigin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblMoveRecordTweenQueues
            // 
            this.lblMoveRecordTweenQueues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblMoveRecordTweenQueues.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMoveRecordTweenQueues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoveRecordTweenQueues.ForeColor = System.Drawing.Color.White;
            this.lblMoveRecordTweenQueues.Location = new System.Drawing.Point(0, 0);
            this.lblMoveRecordTweenQueues.Name = "lblMoveRecordTweenQueues";
            this.lblMoveRecordTweenQueues.Size = new System.Drawing.Size(411, 17);
            this.lblMoveRecordTweenQueues.TabIndex = 7;
            this.lblMoveRecordTweenQueues.Text = "Mover Records de Queue a Queue";
            this.lblMoveRecordTweenQueues.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOriginQueue
            // 
            this.lblOriginQueue.AutoSize = true;
            this.lblOriginQueue.Location = new System.Drawing.Point(22, 57);
            this.lblOriginQueue.Name = "lblOriginQueue";
            this.lblOriginQueue.Size = new System.Drawing.Size(76, 13);
            this.lblOriginQueue.TabIndex = 8;
            this.lblOriginQueue.Text = "Queue Origen:";
            this.lblOriginQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOriginQueue
            // 
            this.txtOriginQueue.AllowBlankSpaces = true;
            this.txtOriginQueue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOriginQueue.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtOriginQueue.CustomExpression = ".*";
            this.txtOriginQueue.EnterColor = System.Drawing.Color.Empty;
            this.txtOriginQueue.LeaveColor = System.Drawing.Color.Empty;
            this.txtOriginQueue.Location = new System.Drawing.Point(101, 54);
            this.txtOriginQueue.MaxLength = 3;
            this.txtOriginQueue.Name = "txtOriginQueue";
            this.txtOriginQueue.Size = new System.Drawing.Size(50, 20);
            this.txtOriginQueue.TabIndex = 11;
            this.txtOriginQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(217, 200);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 15;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucMoveRecordsTweenQueues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblPCCDestiny);
            this.Controls.Add(this.txtPCCDestiny);
            this.Controls.Add(this.lblDestinyQueue);
            this.Controls.Add(this.txtDestinyQueue);
            this.Controls.Add(this.lblPCCOrigin);
            this.Controls.Add(this.txtPCCOrigin);
            this.Controls.Add(this.lblMoveRecordTweenQueues);
            this.Controls.Add(this.lblOriginQueue);
            this.Controls.Add(this.txtOriginQueue);
            this.Controls.Add(this.btnAccept);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucMoveRecordsTweenQueues";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucMoveRecordsTweenQueues_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPCCDestiny;
        private MyCTS.Forms.UI.SmartTextBox txtPCCDestiny;
        private System.Windows.Forms.Label lblDestinyQueue;
        private MyCTS.Forms.UI.SmartTextBox txtDestinyQueue;
        private System.Windows.Forms.Label lblPCCOrigin;
        private MyCTS.Forms.UI.SmartTextBox txtPCCOrigin;
        internal System.Windows.Forms.Label lblMoveRecordTweenQueues;
        private System.Windows.Forms.Label lblOriginQueue;
        private MyCTS.Forms.UI.SmartTextBox txtOriginQueue;
        private System.Windows.Forms.Button btnAccept;
    }
}
