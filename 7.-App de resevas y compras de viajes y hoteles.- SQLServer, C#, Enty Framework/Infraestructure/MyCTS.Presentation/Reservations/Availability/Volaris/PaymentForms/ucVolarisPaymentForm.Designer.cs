namespace MyCTS.Presentation
{
    partial class ucVolarisPaymentForm
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
            this.volarisBanner1 = new MyCTS.Presentation.Reservations.Availability.Volaris.Banner.VolarisBanner();
            this.lblTitle = new System.Windows.Forms.Label();
            this.loadingControl = new MyCTS.Presentation.Components.LoadingControl();
            this.waitingForControls1 = new MyCTS.Presentation.Components.WaitingForControls();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.buyButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.mainContainer = new System.Windows.Forms.TableLayoutPanel();
            this.ucVolarisErrorRecovery1 = new MyCTS.Presentation.Reservations.Availability.Volaris.ErrorRecovery.ucVolarisErrorRecovery();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // volarisBanner1
            // 
            this.volarisBanner1.AutoSize = true;
            this.volarisBanner1.Location = new System.Drawing.Point(3, 16);
            this.volarisBanner1.Name = "volarisBanner1";
            this.volarisBanner1.Size = new System.Drawing.Size(389, 49);
            this.volarisBanner1.TabIndex = 20;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(-3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(396, 13);
            this.lblTitle.TabIndex = 21;
            this.lblTitle.Text = "Forma de pago";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadingControl
            // 
            this.loadingControl.BackColor = System.Drawing.Color.White;
            this.loadingControl.ImageToShow = null;
            this.loadingControl.Location = new System.Drawing.Point(38, 167);
            this.loadingControl.MessageToShow = "Solicitando información...";
            this.loadingControl.Name = "loadingControl";
            this.loadingControl.Size = new System.Drawing.Size(281, 195);
            this.loadingControl.TabIndex = 23;
            this.loadingControl.Visible = false;
            // 
            // waitingForControls1
            // 
            this.waitingForControls1.AutoSize = true;
            this.waitingForControls1.Location = new System.Drawing.Point(116, 206);
            this.waitingForControls1.MessageToShow = "Cargando...";
            this.waitingForControls1.Name = "waitingForControls1";
            this.waitingForControls1.Size = new System.Drawing.Size(90, 77);
            this.waitingForControls1.TabIndex = 24;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.button1);
            this.buttonPanel.Controls.Add(this.buyButton);
            this.buttonPanel.Location = new System.Drawing.Point(100, 637);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(295, 37);
            this.buttonPanel.TabIndex = 27;
            this.buttonPanel.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(90, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 25);
            this.button1.TabIndex = 18;
            this.button1.Text = "<Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // buyButton
            // 
            this.buyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buyButton.Location = new System.Drawing.Point(170, 3);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(85, 25);
            this.buyButton.TabIndex = 17;
            this.buyButton.Text = "Comprar";
            this.buyButton.UseVisualStyleBackColor = false;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(244, 598);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // mainContainer
            // 
            this.mainContainer.AutoSize = true;
            this.mainContainer.ColumnCount = 1;
            this.mainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainContainer.Location = new System.Drawing.Point(3, 71);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.RowCount = 1;
            this.mainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainContainer.Size = new System.Drawing.Size(390, 28);
            this.mainContainer.TabIndex = 28;
            this.mainContainer.Visible = false;
            // 
            // ucVolarisErrorRecovery1
            // 
            this.ucVolarisErrorRecovery1.AutoSize = true;
            this.ucVolarisErrorRecovery1.Error = null;
            this.ucVolarisErrorRecovery1.Location = new System.Drawing.Point(3, 144);
            this.ucVolarisErrorRecovery1.Name = "ucVolarisErrorRecovery1";
            this.ucVolarisErrorRecovery1.Size = new System.Drawing.Size(396, 218);
            this.ucVolarisErrorRecovery1.TabIndex = 29;
            this.ucVolarisErrorRecovery1.Visible = false;
            // 
            // ucVolarisPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ucVolarisErrorRecovery1);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.waitingForControls1);
            this.Controls.Add(this.loadingControl);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.volarisBanner1);
            this.Name = "ucVolarisPaymentForm";
            this.Size = new System.Drawing.Size(408, 677);
            this.Load += new System.EventHandler(this.ucVolarisPaymentForm_Load);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyCTS.Presentation.Reservations.Availability.Volaris.Banner.VolarisBanner volarisBanner1;
        public System.Windows.Forms.Label lblTitle;
        private MyCTS.Presentation.Components.LoadingControl loadingControl;
        private MyCTS.Presentation.Components.WaitingForControls waitingForControls1;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.TableLayoutPanel mainContainer;
        private System.Windows.Forms.Button button2;
        private MyCTS.Presentation.Reservations.Availability.Volaris.ErrorRecovery.ucVolarisErrorRecovery ucVolarisErrorRecovery1;
    }
}
