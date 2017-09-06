namespace MyCTS.Presentation.Reservations.Availability.InterJet
{
    partial class frmInterJetFlightsResume
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.header = new System.Windows.Forms.Label();
            this.panelInsideGroupBox = new System.Windows.Forms.Panel();
            this.totalPrice = new System.Windows.Forms.Label();
            this.seniorbody = new System.Windows.Forms.Label();
            this.childBody = new System.Windows.Forms.Label();
            this.groupBoxContainer = new System.Windows.Forms.GroupBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.OkPanel = new System.Windows.Forms.Panel();
            this.totalBalanceToPay = new System.Windows.Forms.Label();
            this.panelInsideGroupBox.SuspendLayout();
            this.groupBoxContainer.SuspendLayout();
            this.OkPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Location = new System.Drawing.Point(10, 9);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(183, 26);
            this.header.TabIndex = 0;
            this.header.Text = "Vuelo : MEX - MID \r\nSalida : 18:00 hrs Llegada : 20:00 hrs";
            // 
            // panelInsideGroupBox
            // 
            this.panelInsideGroupBox.Controls.Add(this.totalPrice);
            this.panelInsideGroupBox.Controls.Add(this.seniorbody);
            this.panelInsideGroupBox.Controls.Add(this.childBody);
            this.panelInsideGroupBox.Controls.Add(this.header);
            this.panelInsideGroupBox.Location = new System.Drawing.Point(6, 19);
            this.panelInsideGroupBox.Name = "panelInsideGroupBox";
            this.panelInsideGroupBox.Size = new System.Drawing.Size(442, 151);
            this.panelInsideGroupBox.TabIndex = 0;
            // 
            // totalPrice
            // 
            this.totalPrice.AutoSize = true;
            this.totalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPrice.Location = new System.Drawing.Point(285, 128);
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.Size = new System.Drawing.Size(148, 13);
            this.totalPrice.TabIndex = 3;
            this.totalPrice.Text = "Precio Total : $23434.43";
            // 
            // seniorbody
            // 
            this.seniorbody.AutoSize = true;
            this.seniorbody.Location = new System.Drawing.Point(292, 40);
            this.seniorbody.Name = "seniorbody";
            this.seniorbody.Size = new System.Drawing.Size(117, 78);
            this.seniorbody.TabIndex = 2;
            this.seniorbody.Text = "1 Menor \r\nTarifa base : $ 1500.33\r\n             IVA : $ 200.00\r\n             TUA:" +
                " $120.00\r\n   Descuento: $- 0.00\r\n           Total : $1600";
            // 
            // childBody
            // 
            this.childBody.AutoSize = true;
            this.childBody.Location = new System.Drawing.Point(10, 49);
            this.childBody.Name = "childBody";
            this.childBody.Size = new System.Drawing.Size(117, 78);
            this.childBody.TabIndex = 1;
            this.childBody.Text = "1 Menor \r\nTarifa base : $ 1500.33\r\n             IVA : $ 200.00\r\n            TUA :" +
                " $120.00\r\n  Descuento : $- 0.00\r\n           Total : $1600";
            // 
            // groupBoxContainer
            // 
            this.groupBoxContainer.Controls.Add(this.panelInsideGroupBox);
            this.groupBoxContainer.Location = new System.Drawing.Point(12, 12);
            this.groupBoxContainer.Name = "groupBoxContainer";
            this.groupBoxContainer.Size = new System.Drawing.Size(470, 178);
            this.groupBoxContainer.TabIndex = 2;
            this.groupBoxContainer.TabStop = false;
            this.groupBoxContainer.Text = "groupBox1";
            // 
            // acceptButton
            // 
            this.acceptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.acceptButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.acceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.acceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptButton.Location = new System.Drawing.Point(113, 27);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(85, 26);
            this.acceptButton.TabIndex = 20;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = false;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // OkPanel
            // 
            this.OkPanel.Controls.Add(this.totalBalanceToPay);
            this.OkPanel.Controls.Add(this.acceptButton);
            this.OkPanel.Location = new System.Drawing.Point(250, 196);
            this.OkPanel.Name = "OkPanel";
            this.OkPanel.Size = new System.Drawing.Size(210, 56);
            this.OkPanel.TabIndex = 21;
            // 
            // totalBalanceToPay
            // 
            this.totalBalanceToPay.AutoSize = true;
            this.totalBalanceToPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalBalanceToPay.Location = new System.Drawing.Point(2, 11);
            this.totalBalanceToPay.Name = "totalBalanceToPay";
            this.totalBalanceToPay.Size = new System.Drawing.Size(0, 13);
            this.totalBalanceToPay.TabIndex = 21;
            // 
            // frmInterJetFlightsResume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(494, 463);
            this.Controls.Add(this.OkPanel);
            this.Controls.Add(this.groupBoxContainer);
            this.Name = "frmInterJetFlightsResume";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle de Precios";
            this.LocationChanged += new System.EventHandler(this.frmInterJetFlightsResume_Load);
            this.panelInsideGroupBox.ResumeLayout(false);
            this.panelInsideGroupBox.PerformLayout();
            this.groupBoxContainer.ResumeLayout(false);
            this.OkPanel.ResumeLayout(false);
            this.OkPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Panel panelInsideGroupBox;
        private System.Windows.Forms.Label childBody;
        private System.Windows.Forms.Label seniorbody;
        private System.Windows.Forms.Label totalPrice;
        private System.Windows.Forms.GroupBox groupBoxContainer;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Panel OkPanel;
        private System.Windows.Forms.Label totalBalanceToPay;
    }
}