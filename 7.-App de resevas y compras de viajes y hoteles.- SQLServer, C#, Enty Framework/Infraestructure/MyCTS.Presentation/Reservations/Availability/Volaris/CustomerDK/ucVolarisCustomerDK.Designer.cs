namespace MyCTS.Presentation
{
    partial class ucVolarisCustomerDK
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.volarisBanner1 = new MyCTS.Presentation.Reservations.Availability.Volaris.Banner.VolarisBanner();
            this.lblNumberClientDK = new System.Windows.Forms.Label();
            this.customerDkTextBox = new DevExpress.XtraEditors.TextEdit();
            this.dkValidator = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.container = new System.Windows.Forms.Panel();
            this.container2 = new System.Windows.Forms.Panel();
            this.lblextendedDescription = new DevExpress.XtraEditors.LabelControl();
            this.txtDescription1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtDescription2 = new MyCTS.Forms.UI.SmartTextBox();
            this.errorContainer = new System.Windows.Forms.Panel();
            this.errorLabel = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnAccept = new System.Windows.Forms.Button();
            this.waitingForControls1 = new MyCTS.Presentation.Components.WaitingForControls();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.customerDkTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dkValidator)).BeginInit();
            this.container.SuspendLayout();
            this.container2.SuspendLayout();
            this.errorContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // volarisBanner1
            // 
            this.volarisBanner1.AutoSize = true;
            this.volarisBanner1.Location = new System.Drawing.Point(17, 17);
            this.volarisBanner1.Name = "volarisBanner1";
            this.volarisBanner1.Size = new System.Drawing.Size(289, 49);
            this.volarisBanner1.TabIndex = 0;
            // 
            // lblNumberClientDK
            // 
            this.lblNumberClientDK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblNumberClientDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberClientDK.ForeColor = System.Drawing.Color.White;
            this.lblNumberClientDK.Location = new System.Drawing.Point(3, 0);
            this.lblNumberClientDK.Name = "lblNumberClientDK";
            this.lblNumberClientDK.Size = new System.Drawing.Size(405, 14);
            this.lblNumberClientDK.TabIndex = 3;
            this.lblNumberClientDK.Text = "Número de Cliente (DK)";
            this.lblNumberClientDK.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // customerDkTextBox
            // 
            this.customerDkTextBox.Location = new System.Drawing.Point(100, 3);
            this.customerDkTextBox.Name = "customerDkTextBox";
            this.customerDkTextBox.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.customerDkTextBox.Properties.Mask.EditMask = "[A-Z0-9]{6}";
            this.customerDkTextBox.Properties.Mask.IgnoreMaskBlank = false;
            this.customerDkTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.customerDkTextBox.Properties.Mask.SaveLiteral = false;
            this.customerDkTextBox.Properties.Mask.ShowPlaceHolders = false;
            this.customerDkTextBox.Properties.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customerDkTextBox_Properties_KeyDown);
            this.customerDkTextBox.Size = new System.Drawing.Size(214, 20);
            this.customerDkTextBox.TabIndex = 6;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Por favor introduce el DK del cliente antes de continuar.";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.dkValidator.SetValidationRule(this.customerDkTextBox, conditionValidationRule1);
            this.customerDkTextBox.TextChanged += new System.EventHandler(this.customerDkTextBox_TextChanged);
            // 
            // container
            // 
            this.container.Controls.Add(this.container2);
            this.container.Controls.Add(this.errorContainer);
            this.container.Controls.Add(this.customerDkTextBox);
            this.container.Controls.Add(this.labelControl1);
            this.container.Controls.Add(this.btnAccept);
            this.container.Location = new System.Drawing.Point(3, 112);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(404, 190);
            this.container.TabIndex = 8;
            // 
            // container2
            // 
            this.container2.Controls.Add(this.lblextendedDescription);
            this.container2.Controls.Add(this.txtDescription1);
            this.container2.Controls.Add(this.txtDescription2);
            this.container2.Location = new System.Drawing.Point(9, 58);
            this.container2.Name = "container2";
            this.container2.Size = new System.Drawing.Size(390, 84);
            this.container2.TabIndex = 11;
            this.container2.Visible = false;
            // 
            // lblextendedDescription
            // 
            this.lblextendedDescription.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblextendedDescription.Appearance.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblextendedDescription.Location = new System.Drawing.Point(10, 8);
            this.lblextendedDescription.Name = "lblextendedDescription";
            this.lblextendedDescription.Size = new System.Drawing.Size(188, 14);
            this.lblextendedDescription.TabIndex = 50;
            this.lblextendedDescription.Text = "Ingresa Descripción extendida:";
            // 
            // txtDescription1
            // 
            this.txtDescription1.AllowBlankSpaces = true;
            this.txtDescription1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtDescription1.CustomExpression = ".*";
            this.txtDescription1.EnterColor = System.Drawing.Color.Empty;
            this.txtDescription1.LeaveColor = System.Drawing.Color.Empty;
            this.txtDescription1.Location = new System.Drawing.Point(3, 28);
            this.txtDescription1.MaxLength = 50;
            this.txtDescription1.Name = "txtDescription1";
            this.txtDescription1.Size = new System.Drawing.Size(384, 20);
            this.txtDescription1.TabIndex = 48;
            this.txtDescription1.Tag = "";
            this.txtDescription1.TextChanged += new System.EventHandler(this.txtDescription1_TextChanged);
            // 
            // txtDescription2
            // 
            this.txtDescription2.AllowBlankSpaces = true;
            this.txtDescription2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtDescription2.CustomExpression = ".*";
            this.txtDescription2.EnterColor = System.Drawing.Color.Empty;
            this.txtDescription2.LeaveColor = System.Drawing.Color.Empty;
            this.txtDescription2.Location = new System.Drawing.Point(3, 54);
            this.txtDescription2.MaxLength = 50;
            this.txtDescription2.Name = "txtDescription2";
            this.txtDescription2.Size = new System.Drawing.Size(384, 20);
            this.txtDescription2.TabIndex = 49;
            this.txtDescription2.Tag = "";
            this.txtDescription2.TextChanged += new System.EventHandler(this.txtDescription2_TextChanged);
            // 
            // errorContainer
            // 
            this.errorContainer.AutoSize = true;
            this.errorContainer.Controls.Add(this.errorLabel);
            this.errorContainer.Controls.Add(this.labelControl2);
            this.errorContainer.Location = new System.Drawing.Point(89, 25);
            this.errorContainer.Name = "errorContainer";
            this.errorContainer.Size = new System.Drawing.Size(250, 27);
            this.errorContainer.TabIndex = 10;
            this.errorContainer.Visible = false;
            // 
            // errorLabel
            // 
            this.errorLabel.Location = new System.Drawing.Point(16, 3);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(4, 13);
            this.errorLabel.TabIndex = 1;
            this.errorLabel.Text = "-";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Location = new System.Drawing.Point(3, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(7, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "*";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(9, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(85, 14);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Ingresa el DK:";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(239, 164);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // waitingForControls1
            // 
            this.waitingForControls1.AutoSize = true;
            this.waitingForControls1.Location = new System.Drawing.Point(121, 351);
            this.waitingForControls1.MessageToShow = "Cargando...";
            this.waitingForControls1.Name = "waitingForControls1";
            this.waitingForControls1.Size = new System.Drawing.Size(90, 77);
            this.waitingForControls1.TabIndex = 9;
            this.waitingForControls1.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(328, 323);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Visible = false;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // ucVolarisCustomerDK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.waitingForControls1);
            this.Controls.Add(this.container);
            this.Controls.Add(this.lblNumberClientDK);
            this.Controls.Add(this.volarisBanner1);
            this.Name = "ucVolarisCustomerDK";
            this.Size = new System.Drawing.Size(410, 402);
            this.Load += new System.EventHandler(this.ucVolarisCustomerDK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerDkTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dkValidator)).EndInit();
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.container2.ResumeLayout(false);
            this.container2.PerformLayout();
            this.errorContainer.ResumeLayout(false);
            this.errorContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyCTS.Presentation.Reservations.Availability.Volaris.Banner.VolarisBanner volarisBanner1;
        internal System.Windows.Forms.Label lblNumberClientDK;
        private DevExpress.XtraEditors.TextEdit customerDkTextBox;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dkValidator;
        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.Panel errorContainer;
        private DevExpress.XtraEditors.LabelControl errorLabel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private MyCTS.Presentation.Components.WaitingForControls waitingForControls1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Panel container2;
        private System.Windows.Forms.Button btnAccept;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblextendedDescription;
        private MyCTS.Forms.UI.SmartTextBox txtDescription1;
        private MyCTS.Forms.UI.SmartTextBox txtDescription2;
    }
}
