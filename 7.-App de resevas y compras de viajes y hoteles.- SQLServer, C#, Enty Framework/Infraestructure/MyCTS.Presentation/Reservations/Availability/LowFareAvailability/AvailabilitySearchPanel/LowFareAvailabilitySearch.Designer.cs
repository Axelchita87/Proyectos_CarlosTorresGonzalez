namespace MyCTS.Presentation
{
    partial class LowFareAvailabilitySearch
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
            DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule compareAgainstControlValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule compareAgainstControlValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LowFareAvailabilitySearch));
            this.departureDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.returningDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.singleFlightCheckBox = new DevExpress.XtraEditors.CheckEdit();
            this.roundTripCheckBox = new DevExpress.XtraEditors.CheckEdit();
            this.departureStationTextBox = new DevExpress.XtraEditors.TextEdit();
            this.arrivalStationTextBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.searchButton = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.departurePredictive = new System.Windows.Forms.ListBox();
            this.returningDatePanel = new System.Windows.Forms.Panel();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ControlEmptyNessValidator = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.DateRangeValidator = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.arrivalPredictive = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.departureDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.returningDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.returningDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.singleFlightCheckBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundTripCheckBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureStationTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalStationTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.returningDatePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ControlEmptyNessValidator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateRangeValidator)).BeginInit();
            this.SuspendLayout();
            // 
            // departureDateEdit
            // 
            this.departureDateEdit.EditValue = null;
            this.departureDateEdit.Location = new System.Drawing.Point(10, 114);
            this.departureDateEdit.Name = "departureDateEdit";
            this.departureDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.departureDateEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.departureDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.departureDateEdit.Size = new System.Drawing.Size(132, 20);
            this.departureDateEdit.TabIndex = 4;
            compareAgainstControlValidationRule3.CompareControlOperator = DevExpress.XtraEditors.DXErrorProvider.CompareControlOperator.Less;
            compareAgainstControlValidationRule3.Control = this.returningDateEdit;
            compareAgainstControlValidationRule3.ErrorText = "LA FECHA DE SALIDA NO PUEDE SER MAYOR A LA DE REGRESO";
            compareAgainstControlValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.DateRangeValidator.SetValidationRule(this.departureDateEdit, compareAgainstControlValidationRule3);
            this.departureDateEdit.EditValueChanged += new System.EventHandler(this.departureDateEdit_EditValueChanged);
            this.departureDateEdit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.departureDateEdit_MouseClick);
            // 
            // returningDateEdit
            // 
            this.returningDateEdit.EditValue = null;
            this.returningDateEdit.Location = new System.Drawing.Point(3, 22);
            this.returningDateEdit.Name = "returningDateEdit";
            this.returningDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.returningDateEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.returningDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.returningDateEdit.Size = new System.Drawing.Size(132, 20);
            this.returningDateEdit.TabIndex = 5;
            compareAgainstControlValidationRule4.CompareControlOperator = DevExpress.XtraEditors.DXErrorProvider.CompareControlOperator.Greater;
            compareAgainstControlValidationRule4.Control = this.departureDateEdit;
            compareAgainstControlValidationRule4.ErrorText = "LA FECHA DE REGRESO NO PUEDE SER MENOR QUE LA DE SALIDA";
            compareAgainstControlValidationRule4.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.DateRangeValidator.SetValidationRule(this.returningDateEdit, compareAgainstControlValidationRule4);
            this.returningDateEdit.EditValueChanged += new System.EventHandler(this.returningDateEdit_EditValueChanged);
            this.returningDateEdit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.returningDateEdit_MouseClick);
            // 
            // singleFlightCheckBox
            // 
            this.singleFlightCheckBox.Location = new System.Drawing.Point(8, 24);
            this.singleFlightCheckBox.Name = "singleFlightCheckBox";
            this.singleFlightCheckBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleFlightCheckBox.Properties.Appearance.Options.UseFont = true;
            this.singleFlightCheckBox.Properties.Caption = "Sencillo";
            this.singleFlightCheckBox.Size = new System.Drawing.Size(75, 19);
            this.singleFlightCheckBox.TabIndex = 0;
            this.singleFlightCheckBox.CheckedChanged += new System.EventHandler(this.singleFlightCheckBox_CheckedChanged);
            // 
            // roundTripCheckBox
            // 
            this.roundTripCheckBox.Location = new System.Drawing.Point(89, 24);
            this.roundTripCheckBox.Name = "roundTripCheckBox";
            this.roundTripCheckBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundTripCheckBox.Properties.Appearance.Options.UseFont = true;
            this.roundTripCheckBox.Properties.Caption = "Redondo";
            this.roundTripCheckBox.Size = new System.Drawing.Size(75, 19);
            this.roundTripCheckBox.TabIndex = 1;
            this.roundTripCheckBox.CheckedChanged += new System.EventHandler(this.roundTripCheckBox_CheckedChanged);
            // 
            // departureStationTextBox
            // 
            this.departureStationTextBox.Location = new System.Drawing.Point(10, 68);
            this.departureStationTextBox.Name = "departureStationTextBox";
            this.departureStationTextBox.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.departureStationTextBox.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.departureStationTextBox.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.departureStationTextBox.Properties.Mask.EditMask = "\\p{L}+";
            this.departureStationTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.departureStationTextBox.Properties.Mask.ShowPlaceHolders = false;
            this.departureStationTextBox.Size = new System.Drawing.Size(154, 20);
            this.departureStationTextBox.TabIndex = 2;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "INDIQUE LA CUIDAD DE SALIDA";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.ControlEmptyNessValidator.SetValidationRule(this.departureStationTextBox, conditionValidationRule1);
            this.departureStationTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.departureStationTextBox_KeyDown);
            this.departureStationTextBox.TextChanged += new System.EventHandler(this.departureStationTextBox_TextChanged);
            // 
            // arrivalStationTextBox
            // 
            this.arrivalStationTextBox.Location = new System.Drawing.Point(187, 68);
            this.arrivalStationTextBox.Name = "arrivalStationTextBox";
            this.arrivalStationTextBox.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.arrivalStationTextBox.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.arrivalStationTextBox.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.arrivalStationTextBox.Properties.Mask.EditMask = "\\p{L}+";
            this.arrivalStationTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.arrivalStationTextBox.Properties.Mask.ShowPlaceHolders = false;
            this.arrivalStationTextBox.Size = new System.Drawing.Size(154, 20);
            this.arrivalStationTextBox.TabIndex = 3;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "INDIQUE LA CUIDAD DE REGRESO";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.ControlEmptyNessValidator.SetValidationRule(this.arrivalStationTextBox, conditionValidationRule2);
            this.arrivalStationTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.arrivalStationTextBox_KeyDown);
            this.arrivalStationTextBox.TextChanged += new System.EventHandler(this.arrivalStationTextBox_TextChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(10, 49);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Salida :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(187, 49);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Destino:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(10, 98);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(90, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Fecha de Salida:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(103, 13);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Fecha de Regreso:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(148, 114);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 113;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(144, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 114;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(10, 140);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 6;
            this.searchButton.Text = "Buscar Vuelos";
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.AutoSize = true;
            this.groupControl1.Controls.Add(this.arrivalPredictive);
            this.groupControl1.Controls.Add(this.departurePredictive);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.arrivalStationTextBox);
            this.groupControl1.Controls.Add(this.returningDatePanel);
            this.groupControl1.Controls.Add(this.roundTripCheckBox);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.departureDateEdit);
            this.groupControl1.Controls.Add(this.searchButton);
            this.groupControl1.Controls.Add(this.pictureBox1);
            this.groupControl1.Controls.Add(this.singleFlightCheckBox);
            this.groupControl1.Controls.Add(this.departureStationTextBox);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(373, 198);
            this.groupControl1.TabIndex = 116;
            this.groupControl1.Text = "Modificar Busqueda";
            // 
            // departurePredictive
            // 
            this.departurePredictive.DisplayMember = "Text";
            this.departurePredictive.FormattingEnabled = true;
            this.departurePredictive.Location = new System.Drawing.Point(137, 155);
            this.departurePredictive.MaximumSize = new System.Drawing.Size(185, 95);
            this.departurePredictive.Name = "departurePredictive";
            this.departurePredictive.ScrollAlwaysVisible = true;
            this.departurePredictive.Size = new System.Drawing.Size(185, 17);
            this.departurePredictive.TabIndex = 117;
            this.departurePredictive.ValueMember = "Value";
            this.departurePredictive.Visible = false;
            this.departurePredictive.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbAirlines_MouseClick);
            this.departurePredictive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbAirlines_KeyDown);
            // 
            // returningDatePanel
            // 
            this.returningDatePanel.Controls.Add(this.returningDateEdit);
            this.returningDatePanel.Controls.Add(this.labelControl4);
            this.returningDatePanel.Controls.Add(this.pictureBox2);
            this.returningDatePanel.Location = new System.Drawing.Point(187, 94);
            this.returningDatePanel.Name = "returningDatePanel";
            this.returningDatePanel.Size = new System.Drawing.Size(167, 43);
            this.returningDatePanel.TabIndex = 116;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Metropolis";
            // 
            // arrivalPredictive
            // 
            this.arrivalPredictive.DisplayMember = "Text";
            this.arrivalPredictive.FormattingEnabled = true;
            this.arrivalPredictive.Location = new System.Drawing.Point(169, 143);
            this.arrivalPredictive.MaximumSize = new System.Drawing.Size(185, 95);
            this.arrivalPredictive.Name = "arrivalPredictive";
            this.arrivalPredictive.ScrollAlwaysVisible = true;
            this.arrivalPredictive.Size = new System.Drawing.Size(185, 17);
            this.arrivalPredictive.TabIndex = 118;
            this.arrivalPredictive.ValueMember = "Value";
            this.arrivalPredictive.Visible = false;
            this.arrivalPredictive.MouseClick += new System.Windows.Forms.MouseEventHandler(this.arrivalPredictive_MouseClick);
            this.arrivalPredictive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.arrivalPredictive_KeyDown);
            // 
            // LowFareAvailabilitySearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupControl1);
            this.Name = "LowFareAvailabilitySearch";
            this.Size = new System.Drawing.Size(379, 204);
            ((System.ComponentModel.ISupportInitialize)(this.departureDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.returningDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.returningDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.singleFlightCheckBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundTripCheckBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureStationTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalStationTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.returningDatePanel.ResumeLayout(false);
            this.returningDatePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ControlEmptyNessValidator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateRangeValidator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit departureDateEdit;
        private DevExpress.XtraEditors.DateEdit returningDateEdit;
        private DevExpress.XtraEditors.CheckEdit singleFlightCheckBox;
        private DevExpress.XtraEditors.CheckEdit roundTripCheckBox;
        private DevExpress.XtraEditors.TextEdit departureStationTextBox;
        private DevExpress.XtraEditors.TextEdit arrivalStationTextBox;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        internal System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.SimpleButton searchButton;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.Panel returningDatePanel;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider ControlEmptyNessValidator;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider DateRangeValidator;
        private System.Windows.Forms.ListBox departurePredictive;
        private System.Windows.Forms.ListBox arrivalPredictive;
    }
}
