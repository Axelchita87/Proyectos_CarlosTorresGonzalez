namespace MyCTS.Presentation
{
    partial class ucVolarisProfileAssign
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.secondLevelProfileTextBox = new DevExpress.XtraEditors.TextEdit();
            this.firstLevelProfile = new DevExpress.XtraEditors.TextEdit();
            this.profileInputValidator = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.secondLevelProfilePredictive = new System.Windows.Forms.ListBox();
            this.fristLevelProfilePredictive = new System.Windows.Forms.ListBox();
            this.removeProfile = new DevExpress.XtraEditors.SimpleButton();
            this.passangers = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.searchProfileButton = new DevExpress.XtraEditors.SimpleButton();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.secondLevelProfileTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstLevelProfile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profileInputValidator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passangers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(11, 73);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Asignar perfil a:";
            // 
            // secondLevelProfileTextBox
            // 
            this.secondLevelProfileTextBox.Location = new System.Drawing.Point(188, 45);
            this.secondLevelProfileTextBox.Name = "secondLevelProfileTextBox";
            this.secondLevelProfileTextBox.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.secondLevelProfileTextBox.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.secondLevelProfileTextBox.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.secondLevelProfileTextBox.Properties.Mask.EditMask = "[A-Z/0-9]+";
            this.secondLevelProfileTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.secondLevelProfileTextBox.Size = new System.Drawing.Size(149, 20);
            this.secondLevelProfileTextBox.TabIndex = 1;
            this.secondLevelProfileTextBox.ToolTip = "INDIQUE EL PERFIL DE SEGUNDO NIVEL";
            this.secondLevelProfileTextBox.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "POR FAVOR INDIQUE EL PERFIL PARA CONTINUAR";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.profileInputValidator.SetValidationRule(this.secondLevelProfileTextBox, conditionValidationRule1);
            this.secondLevelProfileTextBox.TextChanged += new System.EventHandler(this.secondLevelProfileTextBox_TextChanged);
            this.secondLevelProfileTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.secondLevelProfileTextBox_KeyDown);
            // 
            // firstLevelProfile
            // 
            this.firstLevelProfile.Location = new System.Drawing.Point(11, 43);
            this.firstLevelProfile.Name = "firstLevelProfile";
            this.firstLevelProfile.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.firstLevelProfile.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.firstLevelProfile.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.firstLevelProfile.Properties.Mask.EditMask = "[A-Z0-9]+";
            this.firstLevelProfile.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.firstLevelProfile.Size = new System.Drawing.Size(149, 20);
            this.firstLevelProfile.TabIndex = 0;
            this.firstLevelProfile.ToolTip = "INDIQUE EL PERFIL DE PRIMER NIVEL";
            this.firstLevelProfile.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "POR FAVOR INDIQUE EL PERFIL ANTES DE CONTINUAR";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.profileInputValidator.SetValidationRule(this.firstLevelProfile, conditionValidationRule2);
            this.firstLevelProfile.TextChanged += new System.EventHandler(this.firstLevelProfile_TextChanged);
            this.firstLevelProfile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.firstLevelProfile_KeyDown);
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AutoSize = true;
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.secondLevelProfilePredictive);
            this.groupControl1.Controls.Add(this.fristLevelProfilePredictive);
            this.groupControl1.Controls.Add(this.removeProfile);
            this.groupControl1.Controls.Add(this.passangers);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.secondLevelProfileTextBox);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.firstLevelProfile);
            this.groupControl1.Controls.Add(this.searchProfileButton);
            this.groupControl1.Location = new System.Drawing.Point(4, 5);
            this.groupControl1.LookAndFeel.SkinName = "Office 2007 Pink";
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(387, 139);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Asignar Perfil";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(297, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 108;
            this.label1.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(118, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "*";
            // 
            // secondLevelProfilePredictive
            // 
            this.secondLevelProfilePredictive.DisplayMember = "Text";
            this.secondLevelProfilePredictive.FormattingEnabled = true;
            this.secondLevelProfilePredictive.Location = new System.Drawing.Point(188, 67);
            this.secondLevelProfilePredictive.Name = "secondLevelProfilePredictive";
            this.secondLevelProfilePredictive.Size = new System.Drawing.Size(149, 17);
            this.secondLevelProfilePredictive.TabIndex = 107;
            this.secondLevelProfilePredictive.ValueMember = "Value";
            this.secondLevelProfilePredictive.Visible = false;
            this.secondLevelProfilePredictive.MouseClick += new System.Windows.Forms.MouseEventHandler(this.secondLevelProfilePredictive_MouseClick);
            this.secondLevelProfilePredictive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.secondLevelProfilePredictive_KeyDown);
            // 
            // fristLevelProfilePredictive
            // 
            this.fristLevelProfilePredictive.DisplayMember = "Text";
            this.fristLevelProfilePredictive.FormattingEnabled = true;
            this.fristLevelProfilePredictive.Location = new System.Drawing.Point(188, 73);
            this.fristLevelProfilePredictive.Name = "fristLevelProfilePredictive";
            this.fristLevelProfilePredictive.Size = new System.Drawing.Size(149, 17);
            this.fristLevelProfilePredictive.TabIndex = 106;
            this.fristLevelProfilePredictive.ValueMember = "Value";
            this.fristLevelProfilePredictive.Visible = false;
            this.fristLevelProfilePredictive.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fristLevelProfilePredictive_MouseClick);
            this.fristLevelProfilePredictive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fristLevelProfilePredictive_KeyDown);
            // 
            // removeProfile
            // 
            this.removeProfile.Image = global::MyCTS.Presentation.Properties.Resources._1331853240_list_remove_user;
            this.removeProfile.Location = new System.Drawing.Point(210, 90);
            this.removeProfile.Name = "removeProfile";
            this.removeProfile.Size = new System.Drawing.Size(37, 23);
            this.removeProfile.TabIndex = 5;
            this.removeProfile.ToolTip = "CLICK PARA DEASIGNAR EL PERFIL";
            this.removeProfile.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.removeProfile.Visible = false;
            this.removeProfile.Click += new System.EventHandler(this.removeProfile_Click);
            // 
            // passangers
            // 
            this.passangers.Location = new System.Drawing.Point(11, 92);
            this.passangers.Name = "passangers";
            this.passangers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.passangers.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.passangers.Size = new System.Drawing.Size(144, 20);
            this.passangers.TabIndex = 3;
            this.passangers.ToolTip = "INDIQUE AL PASAJERO AL CUAL SE DESEA ASIGNAR EL PERFIL";
            this.passangers.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(188, 24);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(103, 13);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Perfil de 2do Nivel:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(11, 24);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(101, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Perfil de 1er Nivel:";
            // 
            // searchProfileButton
            // 
            this.searchProfileButton.Image = global::MyCTS.Presentation.Properties.Resources._1331853260_list_add_user;
            this.searchProfileButton.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.searchProfileButton.Location = new System.Drawing.Point(171, 90);
            this.searchProfileButton.LookAndFeel.SkinName = "Office 2007 Pink";
            this.searchProfileButton.Name = "searchProfileButton";
            this.searchProfileButton.Size = new System.Drawing.Size(33, 23);
            this.searchProfileButton.TabIndex = 4;
            this.searchProfileButton.ToolTip = "CLICK PARA ASIGNAR EL PERFIL A UN PASAJERO.";
            this.searchProfileButton.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.searchProfileButton.Click += new System.EventHandler(this.searchProfileButton_Click);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Metropolis";
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // ucVolarisProfileAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupControl1);
            this.Name = "ucVolarisProfileAssign";
            this.Size = new System.Drawing.Size(394, 147);
            this.Load += new System.EventHandler(this.ucVolarisProfileAssign_Load);
            ((System.ComponentModel.ISupportInitialize)(this.secondLevelProfileTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstLevelProfile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profileInputValidator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passangers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit firstLevelProfile;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider profileInputValidator;
        private DevExpress.XtraEditors.SimpleButton searchProfileButton;
        private DevExpress.XtraEditors.TextEdit secondLevelProfileTextBox;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit passangers;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.SimpleButton removeProfile;
        private System.Windows.Forms.ListBox fristLevelProfilePredictive;
        private System.Windows.Forms.ListBox secondLevelProfilePredictive;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider ErrorProvider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}
