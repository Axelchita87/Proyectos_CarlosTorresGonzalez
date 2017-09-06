namespace MyCTS.Presentation.Reservations.Availability.ChargeOfServiceLowFare.PassangerChargeOfService
{
    partial class ucPassangerChargeOfServiceLowFare
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
            this.components = new System.ComponentModel.Container();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.passangerNameLabel = new DevExpress.XtraEditors.LabelControl();
            this.amountTextBox = new DevExpress.XtraEditors.TextEdit();
            this.creditCardNumberTextBox = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.applyChargeOfServiceCheck = new DevExpress.XtraEditors.CheckEdit();
            this.chargeOfServiceAssigned = new System.Windows.Forms.Panel();
            this.chargeOfServiceApply = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cardTypePicture = new System.Windows.Forms.PictureBox();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.amountTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applyChargeOfServiceCheck.Properties)).BeginInit();
            this.chargeOfServiceAssigned.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chargeOfServiceApply)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardTypePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Metropolis";
            // 
            // passangerNameLabel
            // 
            this.passangerNameLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passangerNameLabel.Location = new System.Drawing.Point(42, 3);
            this.passangerNameLabel.Name = "passangerNameLabel";
            this.passangerNameLabel.Size = new System.Drawing.Size(114, 13);
            this.passangerNameLabel.TabIndex = 0;
            this.passangerNameLabel.Text = "1.1 Passanger Name";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(123, 41);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Properties.Mask.EditMask = "[0-9]+.[0-9]{1,2}";
            this.amountTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.amountTextBox.Properties.Mask.ShowPlaceHolders = false;
            this.amountTextBox.Size = new System.Drawing.Size(80, 20);
            this.amountTextBox.TabIndex = 1;
            // 
            // creditCardNumberTextBox
            // 
            this.creditCardNumberTextBox.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditCardNumberTextBox.Location = new System.Drawing.Point(113, 22);
            this.creditCardNumberTextBox.Name = "creditCardNumberTextBox";
            this.creditCardNumberTextBox.Size = new System.Drawing.Size(18, 13);
            this.creditCardNumberTextBox.TabIndex = 2;
            this.creditCardNumberTextBox.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "$";
            // 
            // applyChargeOfServiceCheck
            // 
            this.applyChargeOfServiceCheck.Location = new System.Drawing.Point(42, 69);
            this.applyChargeOfServiceCheck.Name = "applyChargeOfServiceCheck";
            this.applyChargeOfServiceCheck.Properties.Caption = "No aplica el cargo por servicio para este pasajero";
            this.applyChargeOfServiceCheck.Size = new System.Drawing.Size(268, 19);
            this.applyChargeOfServiceCheck.TabIndex = 5;
            this.applyChargeOfServiceCheck.CheckedChanged += new System.EventHandler(this.applyChargeOfServiceCheck_CheckedChanged);
            // 
            // chargeOfServiceAssigned
            // 
            this.chargeOfServiceAssigned.AutoSize = true;
            this.chargeOfServiceAssigned.Controls.Add(this.chargeOfServiceApply);
            this.chargeOfServiceAssigned.Location = new System.Drawing.Point(214, 40);
            this.chargeOfServiceAssigned.Name = "chargeOfServiceAssigned";
            this.chargeOfServiceAssigned.Size = new System.Drawing.Size(27, 21);
            this.chargeOfServiceAssigned.TabIndex = 0;
            this.chargeOfServiceAssigned.Visible = false;
            // 
            // chargeOfServiceApply
            // 
            this.chargeOfServiceApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chargeOfServiceApply.Image = global::MyCTS.Presentation.Properties.Resources._1331932433_tick_circle;
            this.chargeOfServiceApply.Location = new System.Drawing.Point(0, 0);
            this.chargeOfServiceApply.Name = "chargeOfServiceApply";
            this.chargeOfServiceApply.Size = new System.Drawing.Size(27, 21);
            this.chargeOfServiceApply.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.chargeOfServiceApply.TabIndex = 0;
            this.chargeOfServiceApply.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.passangerNameLabel);
            this.panel1.Controls.Add(this.chargeOfServiceAssigned);
            this.panel1.Controls.Add(this.amountTextBox);
            this.panel1.Controls.Add(this.applyChargeOfServiceCheck);
            this.panel1.Controls.Add(this.creditCardNumberTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cardTypePicture);
            this.panel1.Location = new System.Drawing.Point(23, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 94);
            this.panel1.TabIndex = 6;
            // 
            // cardTypePicture
            // 
            this.cardTypePicture.Image = global::MyCTS.Presentation.Properties.Resources.unkwonCard;
            this.cardTypePicture.Location = new System.Drawing.Point(42, 22);
            this.cardTypePicture.Name = "cardTypePicture";
            this.cardTypePicture.Size = new System.Drawing.Size(52, 39);
            this.cardTypePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.cardTypePicture.TabIndex = 3;
            this.cardTypePicture.TabStop = false;
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.progressPanel1.AppearanceCaption.Options.UseFont = true;
            this.progressPanel1.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.progressPanel1.AppearanceDescription.Options.UseFont = true;
            this.progressPanel1.Caption = "Espere por favor..";
            this.progressPanel1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.progressPanel1.Description = "Asignando cargo por servicio";
            this.progressPanel1.Location = new System.Drawing.Point(64, 60);
            this.progressPanel1.LookAndFeel.SkinName = "Metropolis";
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(200, 43);
            this.progressPanel1.TabIndex = 7;
            this.progressPanel1.Text = "progressPanel1";
            this.progressPanel1.Visible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panel1);
            this.groupControl1.Location = new System.Drawing.Point(0, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(382, 125);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "-";
            // 
            // ucPassangerChargeOfServiceLowFare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.progressPanel1);
            this.Name = "ucPassangerChargeOfServiceLowFare";
            this.Size = new System.Drawing.Size(385, 131);
            this.Load += new System.EventHandler(this.ucPassangerChargeOfServiceLowFare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.amountTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applyChargeOfServiceCheck.Properties)).EndInit();
            this.chargeOfServiceAssigned.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chargeOfServiceApply)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardTypePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.LabelControl passangerNameLabel;
        private DevExpress.XtraEditors.TextEdit amountTextBox;
        private DevExpress.XtraEditors.LabelControl creditCardNumberTextBox;
        private System.Windows.Forms.PictureBox cardTypePicture;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.CheckEdit applyChargeOfServiceCheck;
        private System.Windows.Forms.Panel chargeOfServiceAssigned;
        private System.Windows.Forms.PictureBox chargeOfServiceApply;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}
