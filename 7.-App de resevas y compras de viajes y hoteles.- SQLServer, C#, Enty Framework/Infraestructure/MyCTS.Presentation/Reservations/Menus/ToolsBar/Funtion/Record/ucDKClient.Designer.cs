namespace MyCTS.Presentation
{
    partial class ucDKClient
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
            this.lblNumberClientDK = new System.Windows.Forms.Label();
            this.txtDK = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lbDK = new System.Windows.Forms.ListBox();
            this.backToFlightPriceDetails = new System.Windows.Forms.Button();
            this.container = new System.Windows.Forms.Panel();
            this.container2 = new System.Windows.Forms.Panel();
            this.lblextendedDescription = new DevExpress.XtraEditors.LabelControl();
            this.Description1 = new MyCTS.Forms.UI.SmartTextBox();
            this.Description2 = new MyCTS.Forms.UI.SmartTextBox();
            this.errorContainer = new System.Windows.Forms.Panel();
            this.errorLabel = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.container.SuspendLayout();
            this.container2.SuspendLayout();
            this.errorContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNumberClientDK
            // 
            this.lblNumberClientDK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblNumberClientDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberClientDK.ForeColor = System.Drawing.Color.White;
            this.lblNumberClientDK.Location = new System.Drawing.Point(3, 0);
            this.lblNumberClientDK.Name = "lblNumberClientDK";
            this.lblNumberClientDK.Size = new System.Drawing.Size(405, 14);
            this.lblNumberClientDK.TabIndex = 0;
            this.lblNumberClientDK.Text = "Número de Cliente (DK)";
            this.lblNumberClientDK.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDK
            // 
            this.txtDK.AllowBlankSpaces = false;
            this.txtDK.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDK.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtDK.CustomExpression = ".*";
            this.txtDK.EnterColor = System.Drawing.Color.Empty;
            this.txtDK.LeaveColor = System.Drawing.Color.Empty;
            this.txtDK.Location = new System.Drawing.Point(100, 2);
            this.txtDK.MaxLength = 3000;
            this.txtDK.Name = "txtDK";
            this.txtDK.Size = new System.Drawing.Size(234, 20);
            this.txtDK.TabIndex = 1;
            this.txtDK.TextChanged += new System.EventHandler(this.customerDkTextBox_Properties_KeyDown);
            this.txtDK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(265, 164);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 40);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lbDK
            // 
            this.lbDK.DisplayMember = "Text";
            this.lbDK.FormattingEnabled = true;
            this.lbDK.Location = new System.Drawing.Point(3, 278);
            this.lbDK.Name = "lbDK";
            this.lbDK.Size = new System.Drawing.Size(234, 95);
            this.lbDK.TabIndex = 3;
            this.lbDK.ValueMember = "Value";
            this.lbDK.Visible = false;
            // 
            // backToFlightPriceDetails
            // 
            this.backToFlightPriceDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.backToFlightPriceDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backToFlightPriceDetails.Location = new System.Drawing.Point(159, 164);
            this.backToFlightPriceDetails.Name = "backToFlightPriceDetails";
            this.backToFlightPriceDetails.Size = new System.Drawing.Size(100, 40);
            this.backToFlightPriceDetails.TabIndex = 4;
            this.backToFlightPriceDetails.Text = "<Regresar";
            this.backToFlightPriceDetails.UseVisualStyleBackColor = false;
            this.backToFlightPriceDetails.Visible = false;
            this.backToFlightPriceDetails.Click += new System.EventHandler(this.backToFlightPriceDetails_Click);
            // 
            // container
            // 
            this.container.Controls.Add(this.container2);
            this.container.Controls.Add(this.backToFlightPriceDetails);
            this.container.Controls.Add(this.btnAccept);
            this.container.Controls.Add(this.errorContainer);
            this.container.Controls.Add(this.labelControl3);
            this.container.Controls.Add(this.txtDK);
            this.container.Location = new System.Drawing.Point(4, 42);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(404, 230);
            this.container.TabIndex = 15;
            // 
            // container2
            // 
            this.container2.Controls.Add(this.lblextendedDescription);
            this.container2.Controls.Add(this.Description1);
            this.container2.Controls.Add(this.Description2);
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
            // Description1
            // 
            this.Description1.AllowBlankSpaces = true;
            this.Description1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Description1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.Description1.CustomExpression = ".*";
            this.Description1.EnterColor = System.Drawing.Color.Empty;
            this.Description1.LeaveColor = System.Drawing.Color.Empty;
            this.Description1.Location = new System.Drawing.Point(3, 28);
            this.Description1.MaxLength = 50;
            this.Description1.Name = "Description1";
            this.Description1.Size = new System.Drawing.Size(384, 20);
            this.Description1.TabIndex = 48;
            this.Description1.Tag = "";
            // 
            // Description2
            // 
            this.Description2.AllowBlankSpaces = true;
            this.Description2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Description2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.Description2.CustomExpression = ".*";
            this.Description2.EnterColor = System.Drawing.Color.Empty;
            this.Description2.LeaveColor = System.Drawing.Color.Empty;
            this.Description2.Location = new System.Drawing.Point(3, 54);
            this.Description2.MaxLength = 50;
            this.Description2.Name = "Description2";
            this.Description2.Size = new System.Drawing.Size(384, 20);
            this.Description2.TabIndex = 49;
            this.Description2.Tag = "";
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
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(9, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(85, 14);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Ingresa el DK:";
            // 
            // ucDKClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.container);
            this.Controls.Add(this.lbDK);
            this.Controls.Add(this.lblNumberClientDK);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucDKClient";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.DKClient_Load);
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.container2.ResumeLayout(false);
            this.container2.PerformLayout();
            this.errorContainer.ResumeLayout(false);
            this.errorContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblNumberClientDK;
        private MyCTS.Forms.UI.SmartTextBox txtDK;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ListBox lbDK;
        private System.Windows.Forms.Button backToFlightPriceDetails;
        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.Panel container2;
        private DevExpress.XtraEditors.LabelControl lblextendedDescription;
        private MyCTS.Forms.UI.SmartTextBox Description1;
        private MyCTS.Forms.UI.SmartTextBox Description2;
        private System.Windows.Forms.Panel errorContainer;
        private DevExpress.XtraEditors.LabelControl errorLabel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}
