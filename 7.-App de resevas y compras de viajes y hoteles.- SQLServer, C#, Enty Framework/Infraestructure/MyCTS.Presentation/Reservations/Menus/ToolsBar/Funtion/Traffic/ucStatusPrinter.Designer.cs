namespace MyCTS.Presentation
{
    partial class ucStatusPrinter
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
            this.tblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblChangeType = new System.Windows.Forms.Label();
            this.lblOptionQuote = new System.Windows.Forms.Label();
            this.rdoLiberateMessages = new System.Windows.Forms.RadioButton();
            this.rdoStopImpression = new System.Windows.Forms.RadioButton();
            this.rdoEaserChoketMessage = new System.Windows.Forms.RadioButton();
            this.rdoDeployStatus = new System.Windows.Forms.RadioButton();
            this.btnAccept = new System.Windows.Forms.Button();
            this.tblLayoutMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayoutMain
            // 
            this.tblLayoutMain.BackColor = System.Drawing.Color.White;
            this.tblLayoutMain.ColumnCount = 4;
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.470988F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.87835F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.57178F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.44039F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.Controls.Add(this.lblChangeType, 0, 0);
            this.tblLayoutMain.Controls.Add(this.lblOptionQuote, 1, 2);
            this.tblLayoutMain.Controls.Add(this.rdoLiberateMessages, 1, 3);
            this.tblLayoutMain.Controls.Add(this.rdoStopImpression, 1, 4);
            this.tblLayoutMain.Controls.Add(this.rdoEaserChoketMessage, 1, 5);
            this.tblLayoutMain.Controls.Add(this.rdoDeployStatus, 1, 6);
            this.tblLayoutMain.Controls.Add(this.btnAccept, 3, 8);
            this.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutMain.Name = "tblLayoutMain";
            this.tblLayoutMain.RowCount = 10;
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.413793F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.275862F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.274676F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.482759F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.827586F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.655172F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.172414F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.931035F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.58621F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.212924F));
            this.tblLayoutMain.Size = new System.Drawing.Size(411, 580);
            this.tblLayoutMain.TabIndex = 16;
            // 
            // lblChangeType
            // 
            this.lblChangeType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.tblLayoutMain.SetColumnSpan(this.lblChangeType, 4);
            this.lblChangeType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChangeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeType.ForeColor = System.Drawing.Color.White;
            this.lblChangeType.Location = new System.Drawing.Point(3, 0);
            this.lblChangeType.Name = "lblChangeType";
            this.lblChangeType.Size = new System.Drawing.Size(405, 14);
            this.lblChangeType.TabIndex = 0;
            this.lblChangeType.Text = "Estatus de Impresoras";
            this.lblChangeType.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblOptionQuote
            // 
            this.lblOptionQuote.AutoSize = true;
            this.lblOptionQuote.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblOptionQuote.Location = new System.Drawing.Point(25, 33);
            this.lblOptionQuote.Name = "lblOptionQuote";
            this.lblOptionQuote.Size = new System.Drawing.Size(152, 30);
            this.lblOptionQuote.TabIndex = 0;
            this.lblOptionQuote.Text = "Selecciona la opcion a cotizar:";
            this.lblOptionQuote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoLiberateMessages
            // 
            this.rdoLiberateMessages.AutoSize = true;
            this.rdoLiberateMessages.Checked = true;
            this.rdoLiberateMessages.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoLiberateMessages.Location = new System.Drawing.Point(25, 66);
            this.rdoLiberateMessages.Name = "rdoLiberateMessages";
            this.rdoLiberateMessages.Size = new System.Drawing.Size(105, 20);
            this.rdoLiberateMessages.TabIndex = 1;
            this.rdoLiberateMessages.TabStop = true;
            this.rdoLiberateMessages.Text = "Liberar Mensajes";
            this.rdoLiberateMessages.UseVisualStyleBackColor = true;
            this.rdoLiberateMessages.CheckedChanged += new System.EventHandler(this.rdoLiberateMessages_CheckedChanged);
            this.rdoLiberateMessages.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoStopImpression
            // 
            this.rdoStopImpression.AutoSize = true;
            this.rdoStopImpression.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoStopImpression.Location = new System.Drawing.Point(25, 92);
            this.rdoStopImpression.Name = "rdoStopImpression";
            this.rdoStopImpression.Size = new System.Drawing.Size(111, 22);
            this.rdoStopImpression.TabIndex = 2;
            this.rdoStopImpression.TabStop = true;
            this.rdoStopImpression.Text = "Detener Impresión";
            this.rdoStopImpression.UseVisualStyleBackColor = true;
            this.rdoStopImpression.CheckedChanged += new System.EventHandler(this.rdoStopImpression_CheckedChanged);
            this.rdoStopImpression.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoEaserChoketMessage
            // 
            this.rdoEaserChoketMessage.AutoSize = true;
            this.rdoEaserChoketMessage.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoEaserChoketMessage.Location = new System.Drawing.Point(25, 120);
            this.rdoEaserChoketMessage.Name = "rdoEaserChoketMessage";
            this.rdoEaserChoketMessage.Size = new System.Drawing.Size(146, 21);
            this.rdoEaserChoketMessage.TabIndex = 3;
            this.rdoEaserChoketMessage.TabStop = true;
            this.rdoEaserChoketMessage.Text = "Borrar Mensajes Atorados";
            this.rdoEaserChoketMessage.UseVisualStyleBackColor = true;
            this.rdoEaserChoketMessage.CheckedChanged += new System.EventHandler(this.rdoEaserChoketMessage_CheckedChanged);
            this.rdoEaserChoketMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoDeployStatus
            // 
            this.rdoDeployStatus.AutoSize = true;
            this.rdoDeployStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoDeployStatus.Location = new System.Drawing.Point(25, 147);
            this.rdoDeployStatus.Name = "rdoDeployStatus";
            this.rdoDeployStatus.Size = new System.Drawing.Size(122, 24);
            this.rdoDeployStatus.TabIndex = 4;
            this.rdoDeployStatus.TabStop = true;
            this.rdoDeployStatus.Text = "Redespliega Estatus";
            this.rdoDeployStatus.UseVisualStyleBackColor = true;
            this.rdoDeployStatus.CheckedChanged += new System.EventHandler(this.rdoDeployStatus_CheckedChanged);
            this.rdoDeployStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(292, 223);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucStatusPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tblLayoutMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucStatusPrinter";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucStatusPrinter_Load);
            this.tblLayoutMain.ResumeLayout(false);
            this.tblLayoutMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel tblLayoutMain;
        internal System.Windows.Forms.Label lblChangeType;
        private System.Windows.Forms.Label lblOptionQuote;
        private System.Windows.Forms.RadioButton rdoLiberateMessages;
        private System.Windows.Forms.RadioButton rdoStopImpression;
        private System.Windows.Forms.RadioButton rdoEaserChoketMessage;
        private System.Windows.Forms.RadioButton rdoDeployStatus;
        private System.Windows.Forms.Button btnAccept;
    }
}
