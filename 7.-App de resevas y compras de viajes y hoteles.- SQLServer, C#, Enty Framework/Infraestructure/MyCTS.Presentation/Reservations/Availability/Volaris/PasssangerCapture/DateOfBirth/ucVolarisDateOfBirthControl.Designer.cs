namespace MyCTS.Presentation
{
    partial class ucVolarisDateOfBirthControl
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.dayComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.monthComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.yearComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Error = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dayComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Error)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(119, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Fecha de Nacimiento:";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Metropolis";
            // 
            // dayComboBox
            // 
            this.dayComboBox.Location = new System.Drawing.Point(3, 23);
            this.dayComboBox.Name = "dayComboBox";
            this.dayComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dayComboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dayComboBox.Size = new System.Drawing.Size(48, 20);
            this.dayComboBox.TabIndex = 0;
            // 
            // monthComboBox
            // 
            this.monthComboBox.EditValue = "";
            this.monthComboBox.Location = new System.Drawing.Point(57, 23);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.monthComboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.monthComboBox.Size = new System.Drawing.Size(87, 20);
            this.monthComboBox.TabIndex = 1;
            // 
            // yearComboBox
            // 
            this.yearComboBox.Location = new System.Drawing.Point(150, 23);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.yearComboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.yearComboBox.Size = new System.Drawing.Size(71, 20);
            this.yearComboBox.TabIndex = 2;
            // 
            // Error
            // 
            this.Error.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(128, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "*";
            // 
            // ucVolarisDateOfBirthControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yearComboBox);
            this.Controls.Add(this.monthComboBox);
            this.Controls.Add(this.dayComboBox);
            this.Controls.Add(this.labelControl1);
            this.Name = "ucVolarisDateOfBirthControl";
            this.Size = new System.Drawing.Size(258, 54);
            this.Load += new System.EventHandler(this.ucVolarisDateOfBirthControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dayComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.ComboBoxEdit dayComboBox;
        private DevExpress.XtraEditors.ComboBoxEdit monthComboBox;
        private DevExpress.XtraEditors.ComboBoxEdit yearComboBox;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider Error;
        private System.Windows.Forms.Label label4;
    }
}
