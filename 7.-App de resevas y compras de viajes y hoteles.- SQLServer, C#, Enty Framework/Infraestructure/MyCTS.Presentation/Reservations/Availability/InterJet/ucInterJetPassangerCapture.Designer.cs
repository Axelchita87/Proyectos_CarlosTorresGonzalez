namespace MyCTS.Presentation.Reservations.Availability.InterJet
{
    partial class ucInterJetPassangerCapture
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.contactLabel = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.ComboBox();
            this.Contact = new System.Windows.Forms.CheckBox();
            this.Suffix = new System.Windows.Forms.ComboBox();
            this.dateOfBirthUserControl = new MyCTS.Presentation.Reservations.Availability.InterJet.ucInterJetPassangerDateOfBirth();
            this.label6 = new System.Windows.Forms.Label();
            this.GroupBoxPassanger = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Name_ = new MyCTS.Forms.UI.SmartTextBox();
            this.LastName = new MyCTS.Forms.UI.SmartTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.GroupBoxPassanger.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Titulo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(144, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Apellido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(254, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Sufijo";
            // 
            // contactLabel
            // 
            this.contactLabel.AutoSize = true;
            this.contactLabel.ForeColor = System.Drawing.Color.DarkCyan;
            this.contactLabel.Location = new System.Drawing.Point(198, 118);
            this.contactLabel.Name = "contactLabel";
            this.contactLabel.Size = new System.Drawing.Size(62, 13);
            this.contactLabel.TabIndex = 19;
            this.contactLabel.Text = "¿Contacto?";
            // 
            // Title
            // 
            this.Title.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Title.FormattingEnabled = true;
            this.Title.Location = new System.Drawing.Point(10, 32);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(62, 21);
            this.Title.TabIndex = 21;
            this.Title.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Title_KeyDown);
            // 
            // Contact
            // 
            this.Contact.AutoSize = true;
            this.Contact.Location = new System.Drawing.Point(220, 134);
            this.Contact.Name = "Contact";
            this.Contact.Size = new System.Drawing.Size(15, 14);
            this.Contact.TabIndex = 24;
            this.Contact.UseVisualStyleBackColor = true;
            this.Contact.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Contact_KeyDown);
            // 
            // Suffix
            // 
            this.Suffix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Suffix.FormattingEnabled = true;
            this.Suffix.Location = new System.Drawing.Point(248, 75);
            this.Suffix.Name = "Suffix";
            this.Suffix.Size = new System.Drawing.Size(59, 21);
            this.Suffix.TabIndex = 25;
            this.Suffix.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Suffix_KeyDown);
            // 
            // dateOfBirthUserControl
            // 
            this.dateOfBirthUserControl.Data = null;
            this.dateOfBirthUserControl.DateOfBirth = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dateOfBirthUserControl.InitialControlFocus = null;
            this.dateOfBirthUserControl.IsForInfant = false;
            this.dateOfBirthUserControl.LastControlFocus = null;
            this.dateOfBirthUserControl.LightingTextBox = true;
            this.dateOfBirthUserControl.Location = new System.Drawing.Point(9, 125);
            this.dateOfBirthUserControl.Name = "dateOfBirthUserControl";
            this.dateOfBirthUserControl.Parameter = null;
            this.dateOfBirthUserControl.Parameters = null;
            this.dateOfBirthUserControl.Size = new System.Drawing.Size(187, 32);
            this.dateOfBirthUserControl.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkCyan;
            this.label6.Location = new System.Drawing.Point(12, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Fecha de Nacimiento";
            // 
            // GroupBoxPassanger
            // 
            this.GroupBoxPassanger.BackColor = System.Drawing.Color.White;
            this.GroupBoxPassanger.Controls.Add(this.label9);
            this.GroupBoxPassanger.Controls.Add(this.label8);
            this.GroupBoxPassanger.Controls.Add(this.label7);
            this.GroupBoxPassanger.Controls.Add(this.Name_);
            this.GroupBoxPassanger.Controls.Add(this.LastName);
            this.GroupBoxPassanger.Controls.Add(this.label6);
            this.GroupBoxPassanger.Controls.Add(this.label2);
            this.GroupBoxPassanger.Controls.Add(this.dateOfBirthUserControl);
            this.GroupBoxPassanger.Controls.Add(this.label3);
            this.GroupBoxPassanger.Controls.Add(this.Suffix);
            this.GroupBoxPassanger.Controls.Add(this.label4);
            this.GroupBoxPassanger.Controls.Add(this.Contact);
            this.GroupBoxPassanger.Controls.Add(this.label5);
            this.GroupBoxPassanger.Controls.Add(this.contactLabel);
            this.GroupBoxPassanger.Controls.Add(this.Title);
            this.GroupBoxPassanger.Location = new System.Drawing.Point(3, 3);
            this.GroupBoxPassanger.Name = "GroupBoxPassanger";
            this.GroupBoxPassanger.Size = new System.Drawing.Size(325, 171);
            this.GroupBoxPassanger.TabIndex = 28;
            this.GroupBoxPassanger.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(198, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(60, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(60, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "*";
            // 
            // Name_
            // 
            this.Name_.AllowBlankSpaces = false;
            this.Name_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Name_.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.Name_.CustomExpression = ".*";
            this.Name_.EnterColor = System.Drawing.Color.Empty;
            this.Name_.LeaveColor = System.Drawing.Color.Empty;
            this.Name_.Location = new System.Drawing.Point(9, 75);
            this.Name_.Name = "Name_";
            this.Name_.Size = new System.Drawing.Size(84, 20);
            this.Name_.TabIndex = 30;
            this.Name_.TextChanged += new System.EventHandler(this.Name__TextChanged);
            this.Name_.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Name__KeyDown);
            // 
            // LastName
            // 
            this.LastName.AllowBlankSpaces = false;
            this.LastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.LastName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.LastName.CustomExpression = ".*";
            this.LastName.EnterColor = System.Drawing.Color.Empty;
            this.LastName.LeaveColor = System.Drawing.Color.Empty;
            this.LastName.Location = new System.Drawing.Point(122, 75);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(100, 20);
            this.LastName.TabIndex = 29;
            this.LastName.TextChanged += new System.EventHandler(this.LastName_TextChanged);
            this.LastName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LastName_KeyDown);
            // 
            // ucInterJetPassangerCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupBoxPassanger);
            this.Name = "ucInterJetPassangerCapture";
            this.Size = new System.Drawing.Size(332, 177);
            this.Load += new System.EventHandler(this.ucInterJetPassangerCapture_Load);
            this.GroupBoxPassanger.ResumeLayout(false);
            this.GroupBoxPassanger.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label contactLabel;
        private System.Windows.Forms.ComboBox Title;
        private System.Windows.Forms.CheckBox Contact;
        private System.Windows.Forms.ComboBox Suffix;
        private ucInterJetPassangerDateOfBirth dateOfBirthUserControl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox GroupBoxPassanger;
        private MyCTS.Forms.UI.SmartTextBox Name_;
        private MyCTS.Forms.UI.SmartTextBox LastName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;




    }
}
