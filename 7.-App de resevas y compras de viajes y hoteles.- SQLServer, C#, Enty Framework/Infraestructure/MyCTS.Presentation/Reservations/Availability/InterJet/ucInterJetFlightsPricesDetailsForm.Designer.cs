namespace MyCTS.Presentation
{
    partial class ucInterJetFlightsPricesDetailsForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.mainContainer = new System.Windows.Forms.Panel();
            this.passangerContailerControl = new MyCTS.Presentation.ucInterJetPassangerConfirmationContainerControl();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.lblPurseElectronicDisponible = new System.Windows.Forms.Label();
            this.lblPurseElectronic = new System.Windows.Forms.Label();
            this.backToContactInformation = new System.Windows.Forms.Button();
            this.backToPassangerControlButton = new System.Windows.Forms.Button();
            this.mainContainer.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(394, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Paso 5/8 - Resumen Antes de la Compra";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mainContainer
            // 
            this.mainContainer.AutoSize = true;
            this.mainContainer.Controls.Add(this.passangerContailerControl);
            this.mainContainer.Controls.Add(this.buttonPanel);
            this.mainContainer.Location = new System.Drawing.Point(3, 16);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(403, 547);
            this.mainContainer.TabIndex = 1;
            // 
            // passangerContailerControl
            // 
            this.passangerContailerControl.AutoSize = true;
            this.passangerContailerControl.BackColor = System.Drawing.Color.White;
            this.passangerContailerControl.Data = null;
            this.passangerContailerControl.InitialControlFocus = null;
            this.passangerContailerControl.LastControlFocus = null;
            this.passangerContailerControl.LightingTextBox = true;
            this.passangerContailerControl.Location = new System.Drawing.Point(3, 3);
            this.passangerContailerControl.Name = "passangerContailerControl";
            this.passangerContailerControl.Parameter = null;
            this.passangerContailerControl.Parameters = null;
            this.passangerContailerControl.Size = new System.Drawing.Size(391, 80);
            this.passangerContailerControl.TabIndex = 2;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.lblPurseElectronicDisponible);
            this.buttonPanel.Controls.Add(this.lblPurseElectronic);
            this.buttonPanel.Controls.Add(this.backToContactInformation);
            this.buttonPanel.Controls.Add(this.backToPassangerControlButton);
            this.buttonPanel.Location = new System.Drawing.Point(9, 354);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(349, 66);
            this.buttonPanel.TabIndex = 1;
            // 
            // lblPurseElectronicDisponible
            // 
            this.lblPurseElectronicDisponible.AutoSize = true;
            this.lblPurseElectronicDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurseElectronicDisponible.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblPurseElectronicDisponible.Location = new System.Drawing.Point(2, 8);
            this.lblPurseElectronicDisponible.Name = "lblPurseElectronicDisponible";
            this.lblPurseElectronicDisponible.Size = new System.Drawing.Size(124, 13);
            this.lblPurseElectronicDisponible.TabIndex = 108;
            this.lblPurseElectronicDisponible.Text = "Cantidad Disponible:";
            // 
            // lblPurseElectronic
            // 
            this.lblPurseElectronic.AutoSize = true;
            this.lblPurseElectronic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurseElectronic.Location = new System.Drawing.Point(125, 8);
            this.lblPurseElectronic.Name = "lblPurseElectronic";
            this.lblPurseElectronic.Size = new System.Drawing.Size(61, 13);
            this.lblPurseElectronic.TabIndex = 109;
            this.lblPurseElectronic.Text = "$25,000.00";
            // 
            // backToContactInformation
            // 
            this.backToContactInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.backToContactInformation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backToContactInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backToContactInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backToContactInformation.Location = new System.Drawing.Point(150, 28);
            this.backToContactInformation.Name = "backToContactInformation";
            this.backToContactInformation.Size = new System.Drawing.Size(85, 29);
            this.backToContactInformation.TabIndex = 22;
            this.backToContactInformation.Text = "<Regresar";
            this.backToContactInformation.UseVisualStyleBackColor = false;
            this.backToContactInformation.Click += new System.EventHandler(this.backToContactInformation_Click);
            // 
            // backToPassangerControlButton
            // 
            this.backToPassangerControlButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.backToPassangerControlButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backToPassangerControlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backToPassangerControlButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backToPassangerControlButton.Location = new System.Drawing.Point(241, 28);
            this.backToPassangerControlButton.Name = "backToPassangerControlButton";
            this.backToPassangerControlButton.Size = new System.Drawing.Size(85, 29);
            this.backToPassangerControlButton.TabIndex = 21;
            this.backToPassangerControlButton.Text = "Continuar>";
            this.backToPassangerControlButton.UseVisualStyleBackColor = false;
            this.backToPassangerControlButton.Click += new System.EventHandler(this.backToPaymentFormButton_Click);
            this.backToPassangerControlButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.backToPassangerControlButton_KeyDown);
            // 
            // ucInterJetFlightsPricesDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mainContainer);
            this.Name = "ucInterJetFlightsPricesDetailsForm";
            this.Size = new System.Drawing.Size(412, 610);
            this.Load += new System.EventHandler(this.ucInterJetFlightsPricesDetailsForm_Load);
            this.mainContainer.ResumeLayout(false);
            this.mainContainer.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.buttonPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button backToPassangerControlButton;
        private System.Windows.Forms.Button backToContactInformation;
        public System.Windows.Forms.Panel mainContainer;
        private ucInterJetPassangerConfirmationContainerControl passangerContailerControl;
        private System.Windows.Forms.Label lblPurseElectronicDisponible;
        private System.Windows.Forms.Label lblPurseElectronic;
    }
}

