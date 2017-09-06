namespace MyCTS.Presentation
{
    partial class ucVolarisContactInformationCapture
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule5 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.email = new DevExpress.XtraEditors.TextEdit();
            this.emailConfirmation = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.telephone = new DevExpress.XtraEditors.TextEdit();
            this.telLada = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cellPhone = new DevExpress.XtraEditors.TextEdit();
            this.cellLada = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.EmptyControlValidator = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.EmailComparartor = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.email.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailConfirmation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.telephone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.telLada.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellLada.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmptyControlValidator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailComparartor)).BeginInit();
            this.SuspendLayout();
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(5, 88);
            this.email.Name = "email";
            this.email.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.email.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.email.Properties.Mask.EditMask = "[A-Z0-9_]+@[A-Z0-9]+\\.[A-Z.]{2,4}+";
            this.email.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.email.Properties.Mask.ShowPlaceHolders = false;
            this.email.Size = new System.Drawing.Size(158, 20);
            this.email.TabIndex = 4;
            conditionValidationRule5.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule5.ErrorText = "INDIQUE EL CORREO ELECTRONICO POR FAVOR";
            conditionValidationRule5.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.EmptyControlValidator.SetValidationRule(this.email, conditionValidationRule5);
            this.email.TextChanged += new System.EventHandler(this.email_TextChanged);
            // 
            // emailConfirmation
            // 
            this.emailConfirmation.Location = new System.Drawing.Point(182, 87);
            this.emailConfirmation.Name = "emailConfirmation";
            this.emailConfirmation.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.emailConfirmation.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.emailConfirmation.Properties.Mask.EditMask = "[A-Z0-9_]+@[A-Z0-9]+\\.[A-Z.]{2,4}+";
            this.emailConfirmation.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.emailConfirmation.Properties.Mask.ShowPlaceHolders = false;
            this.emailConfirmation.Size = new System.Drawing.Size(178, 20);
            this.emailConfirmation.TabIndex = 5;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "INDIQUE EL CORREO ELECTRONICO DE CONFIRMACION POR FAVOR";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.EmptyControlValidator.SetValidationRule(this.emailConfirmation, conditionValidationRule1);
            this.emailConfirmation.TextChanged += new System.EventHandler(this.emailConfirmation_TextChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.emailConfirmation);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.email);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.telephone);
            this.groupControl1.Controls.Add(this.telLada);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.cellPhone);
            this.groupControl1.Controls.Add(this.cellLada);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(390, 123);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Información de Contacto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(363, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(117, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(326, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "*";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Location = new System.Drawing.Point(182, 68);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(175, 13);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "Confirmación de Correo(Email):";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(5, 68);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(106, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Correo Electronico:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(182, 24);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(138, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Telefono(Lada-numero):";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(231, 43);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(4, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "-";
            // 
            // telephone
            // 
            this.telephone.Location = new System.Drawing.Point(241, 42);
            this.telephone.Name = "telephone";
            this.telephone.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.telephone.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.telephone.Properties.Mask.EditMask = "[0-9]+";
            this.telephone.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.telephone.Properties.Mask.ShowPlaceHolders = false;
            this.telephone.Size = new System.Drawing.Size(119, 20);
            this.telephone.TabIndex = 3;
            conditionValidationRule2.ErrorText = "INDIQUE EL NUMERO TELEFONICO";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.EmptyControlValidator.SetValidationRule(this.telephone, conditionValidationRule2);
            this.telephone.TextChanged += new System.EventHandler(this.telephone_TextChanged);
            // 
            // telLada
            // 
            this.telLada.Location = new System.Drawing.Point(182, 42);
            this.telLada.Name = "telLada";
            this.telLada.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.telLada.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.telLada.Properties.Mask.EditMask = "\\d{0,5}";
            this.telLada.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.telLada.Properties.Mask.ShowPlaceHolders = false;
            this.telLada.Size = new System.Drawing.Size(42, 20);
            this.telLada.TabIndex = 2;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "INDIQUE LA LADA DEL TELEFONO";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.EmptyControlValidator.SetValidationRule(this.telLada, conditionValidationRule3);
            this.telLada.TextChanged += new System.EventHandler(this.telLada_TextChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(53, 43);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(4, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "-";
            // 
            // cellPhone
            // 
            this.cellPhone.Location = new System.Drawing.Point(63, 42);
            this.cellPhone.Name = "cellPhone";
            this.cellPhone.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cellPhone.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.cellPhone.Properties.Mask.EditMask = "[0-9]+";
            this.cellPhone.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.cellPhone.Properties.Mask.ShowPlaceHolders = false;
            this.cellPhone.Size = new System.Drawing.Size(100, 20);
            this.cellPhone.TabIndex = 1;
            // 
            // cellLada
            // 
            this.cellLada.Location = new System.Drawing.Point(5, 42);
            this.cellLada.Name = "cellLada";
            this.cellLada.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cellLada.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.cellLada.Properties.Mask.EditMask = "\\d{0,5}";
            this.cellLada.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.cellLada.Properties.Mask.ShowPlaceHolders = false;
            this.cellLada.Size = new System.Drawing.Size(42, 20);
            this.cellLada.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(5, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(128, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Celular(Lada-numero):";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Metropolis";
            // 
            // ucVolarisContactInformationCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "ucVolarisContactInformationCapture";
            this.Size = new System.Drawing.Size(396, 131);
            this.Load += new System.EventHandler(this.ucVolarisContactInformationCapture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.email.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailConfirmation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.telephone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.telLada.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellLada.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmptyControlValidator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailComparartor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit email;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit telephone;
        private DevExpress.XtraEditors.TextEdit telLada;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit cellPhone;
        private DevExpress.XtraEditors.TextEdit cellLada;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit emailConfirmation;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider EmptyControlValidator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider EmailComparartor;

    }
}
