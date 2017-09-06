namespace MyCTS.Presentation
{
    partial class ucDeletePCCs
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
            this.txtPCCName = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.lblBussinessClass4 = new System.Windows.Forms.Label();
            this.lblBussinessClass3 = new System.Windows.Forms.Label();
            this.lblBussinessClass2 = new System.Windows.Forms.Label();
            this.lblBussinessClass1 = new System.Windows.Forms.Label();
            this.lblConfirmation = new System.Windows.Forms.Label();
            this.lblSpecificClass = new System.Windows.Forms.Label();
            this.lblStandardClass = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPCCName = new System.Windows.Forms.Label();
            this.lblPCC = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoSearch = new System.Windows.Forms.RadioButton();
            this.rdoDelete = new System.Windows.Forms.RadioButton();
            this.cmbBussinessClass4 = new System.Windows.Forms.ComboBox();
            this.cmbBussinessClass3 = new System.Windows.Forms.ComboBox();
            this.cmbBussinessClass2 = new System.Windows.Forms.ComboBox();
            this.cmbBussinessClass1 = new System.Windows.Forms.ComboBox();
            this.cmbConfirmation = new System.Windows.Forms.ComboBox();
            this.cmbSpecificClass = new System.Windows.Forms.ComboBox();
            this.cmbStandardClass = new System.Windows.Forms.ComboBox();
            this.cmbEstatus = new System.Windows.Forms.ComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPCCName
            // 
            this.txtPCCName.AllowBlankSpaces = true;
            this.txtPCCName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCCName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPCCName.CustomExpression = ".*";
            this.txtPCCName.EnterColor = System.Drawing.Color.Empty;
            this.txtPCCName.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCCName.Location = new System.Drawing.Point(126, 94);
            this.txtPCCName.MaxLength = 50;
            this.txtPCCName.Name = "txtPCCName";
            this.txtPCCName.Size = new System.Drawing.Size(241, 20);
            this.txtPCCName.TabIndex = 4;
            this.txtPCCName.TextChanged += new System.EventHandler(this.txtPCCName_TextChanged);
            this.txtPCCName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = true;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(126, 70);
            this.txtPCC.MaxLength = 4;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(59, 20);
            this.txtPCC.TabIndex = 3;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblBussinessClass4
            // 
            this.lblBussinessClass4.AutoSize = true;
            this.lblBussinessClass4.Location = new System.Drawing.Point(17, 287);
            this.lblBussinessClass4.Name = "lblBussinessClass4";
            this.lblBussinessClass4.Size = new System.Drawing.Size(102, 13);
            this.lblBussinessClass4.TabIndex = 0;
            this.lblBussinessClass4.Text = "Clase de Negocios4";
            // 
            // lblBussinessClass3
            // 
            this.lblBussinessClass3.AutoSize = true;
            this.lblBussinessClass3.Location = new System.Drawing.Point(17, 264);
            this.lblBussinessClass3.Name = "lblBussinessClass3";
            this.lblBussinessClass3.Size = new System.Drawing.Size(102, 13);
            this.lblBussinessClass3.TabIndex = 0;
            this.lblBussinessClass3.Text = "Clase de Negocios3";
            // 
            // lblBussinessClass2
            // 
            this.lblBussinessClass2.AutoSize = true;
            this.lblBussinessClass2.Location = new System.Drawing.Point(17, 242);
            this.lblBussinessClass2.Name = "lblBussinessClass2";
            this.lblBussinessClass2.Size = new System.Drawing.Size(102, 13);
            this.lblBussinessClass2.TabIndex = 0;
            this.lblBussinessClass2.Text = "Clase de Negocios2";
            // 
            // lblBussinessClass1
            // 
            this.lblBussinessClass1.AutoSize = true;
            this.lblBussinessClass1.Location = new System.Drawing.Point(17, 218);
            this.lblBussinessClass1.Name = "lblBussinessClass1";
            this.lblBussinessClass1.Size = new System.Drawing.Size(102, 13);
            this.lblBussinessClass1.TabIndex = 0;
            this.lblBussinessClass1.Text = "Clase de Negocios1";
            // 
            // lblConfirmation
            // 
            this.lblConfirmation.AutoSize = true;
            this.lblConfirmation.Location = new System.Drawing.Point(17, 194);
            this.lblConfirmation.Name = "lblConfirmation";
            this.lblConfirmation.Size = new System.Drawing.Size(68, 13);
            this.lblConfirmation.TabIndex = 0;
            this.lblConfirmation.Text = "Confirmación";
            // 
            // lblSpecificClass
            // 
            this.lblSpecificClass.AutoSize = true;
            this.lblSpecificClass.Location = new System.Drawing.Point(17, 167);
            this.lblSpecificClass.Name = "lblSpecificClass";
            this.lblSpecificClass.Size = new System.Drawing.Size(85, 13);
            this.lblSpecificClass.TabIndex = 0;
            this.lblSpecificClass.Text = "Clase Especifica";
            // 
            // lblStandardClass
            // 
            this.lblStandardClass.AutoSize = true;
            this.lblStandardClass.Location = new System.Drawing.Point(17, 141);
            this.lblStandardClass.Name = "lblStandardClass";
            this.lblStandardClass.Size = new System.Drawing.Size(78, 13);
            this.lblStandardClass.TabIndex = 0;
            this.lblStandardClass.Text = "Clase Estándar";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(17, 118);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Estatus";
            // 
            // lblPCCName
            // 
            this.lblPCCName.AutoSize = true;
            this.lblPCCName.Location = new System.Drawing.Point(17, 93);
            this.lblPCCName.Name = "lblPCCName";
            this.lblPCCName.Size = new System.Drawing.Size(68, 13);
            this.lblPCCName.TabIndex = 0;
            this.lblPCCName.Text = "Nombre PCC";
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Location = new System.Drawing.Point(17, 70);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(28, 13);
            this.lblPCC.TabIndex = 0;
            this.lblPCC.Text = "PCC";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(245, 318);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 24);
            this.btnAccept.TabIndex = 13;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 18);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Baja de PCC";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Que deseas hacer?";
            // 
            // rdoSearch
            // 
            this.rdoSearch.AutoSize = true;
            this.rdoSearch.Location = new System.Drawing.Point(144, 39);
            this.rdoSearch.Name = "rdoSearch";
            this.rdoSearch.Size = new System.Drawing.Size(58, 17);
            this.rdoSearch.TabIndex = 1;
            this.rdoSearch.TabStop = true;
            this.rdoSearch.Text = "Buscar";
            this.rdoSearch.UseVisualStyleBackColor = true;
            this.rdoSearch.CheckedChanged += new System.EventHandler(this.rdoSearch_CheckedChanged);
            this.rdoSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoDelete
            // 
            this.rdoDelete.AutoSize = true;
            this.rdoDelete.Location = new System.Drawing.Point(227, 39);
            this.rdoDelete.Name = "rdoDelete";
            this.rdoDelete.Size = new System.Drawing.Size(61, 17);
            this.rdoDelete.TabIndex = 2;
            this.rdoDelete.TabStop = true;
            this.rdoDelete.Text = "Eliminar";
            this.rdoDelete.UseVisualStyleBackColor = true;
            this.rdoDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbBussinessClass4
            // 
            this.cmbBussinessClass4.DisplayMember = "Text";
            this.cmbBussinessClass4.FormattingEnabled = true;
            this.cmbBussinessClass4.Items.AddRange(new object[] {
            ""});
            this.cmbBussinessClass4.Location = new System.Drawing.Point(126, 284);
            this.cmbBussinessClass4.MaxLength = 1;
            this.cmbBussinessClass4.Name = "cmbBussinessClass4";
            this.cmbBussinessClass4.Size = new System.Drawing.Size(44, 21);
            this.cmbBussinessClass4.TabIndex = 12;
            this.cmbBussinessClass4.ValueMember = "Value";
            this.cmbBussinessClass4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbBussinessClass3
            // 
            this.cmbBussinessClass3.DisplayMember = "Text";
            this.cmbBussinessClass3.FormattingEnabled = true;
            this.cmbBussinessClass3.Items.AddRange(new object[] {
            ""});
            this.cmbBussinessClass3.Location = new System.Drawing.Point(126, 260);
            this.cmbBussinessClass3.MaxLength = 1;
            this.cmbBussinessClass3.Name = "cmbBussinessClass3";
            this.cmbBussinessClass3.Size = new System.Drawing.Size(44, 21);
            this.cmbBussinessClass3.TabIndex = 11;
            this.cmbBussinessClass3.ValueMember = "Value";
            this.cmbBussinessClass3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbBussinessClass2
            // 
            this.cmbBussinessClass2.DisplayMember = "Text";
            this.cmbBussinessClass2.FormattingEnabled = true;
            this.cmbBussinessClass2.Items.AddRange(new object[] {
            ""});
            this.cmbBussinessClass2.Location = new System.Drawing.Point(126, 237);
            this.cmbBussinessClass2.MaxLength = 1;
            this.cmbBussinessClass2.Name = "cmbBussinessClass2";
            this.cmbBussinessClass2.Size = new System.Drawing.Size(44, 21);
            this.cmbBussinessClass2.TabIndex = 10;
            this.cmbBussinessClass2.ValueMember = "Value";
            this.cmbBussinessClass2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbBussinessClass1
            // 
            this.cmbBussinessClass1.DisplayMember = "Text";
            this.cmbBussinessClass1.FormattingEnabled = true;
            this.cmbBussinessClass1.Items.AddRange(new object[] {
            ""});
            this.cmbBussinessClass1.Location = new System.Drawing.Point(126, 213);
            this.cmbBussinessClass1.MaxLength = 1;
            this.cmbBussinessClass1.Name = "cmbBussinessClass1";
            this.cmbBussinessClass1.Size = new System.Drawing.Size(44, 21);
            this.cmbBussinessClass1.TabIndex = 9;
            this.cmbBussinessClass1.ValueMember = "Value";
            this.cmbBussinessClass1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbConfirmation
            // 
            this.cmbConfirmation.DisplayMember = "Text";
            this.cmbConfirmation.FormattingEnabled = true;
            this.cmbConfirmation.Items.AddRange(new object[] {
            "",
            "Y",
            "N"});
            this.cmbConfirmation.Location = new System.Drawing.Point(126, 189);
            this.cmbConfirmation.MaxLength = 1;
            this.cmbConfirmation.Name = "cmbConfirmation";
            this.cmbConfirmation.Size = new System.Drawing.Size(44, 21);
            this.cmbConfirmation.TabIndex = 8;
            this.cmbConfirmation.ValueMember = "Value";
            this.cmbConfirmation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbSpecificClass
            // 
            this.cmbSpecificClass.DisplayMember = "Text";
            this.cmbSpecificClass.FormattingEnabled = true;
            this.cmbSpecificClass.Items.AddRange(new object[] {
            ""});
            this.cmbSpecificClass.Location = new System.Drawing.Point(126, 166);
            this.cmbSpecificClass.MaxLength = 1;
            this.cmbSpecificClass.Name = "cmbSpecificClass";
            this.cmbSpecificClass.Size = new System.Drawing.Size(44, 21);
            this.cmbSpecificClass.TabIndex = 7;
            this.cmbSpecificClass.ValueMember = "Value";
            this.cmbSpecificClass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbStandardClass
            // 
            this.cmbStandardClass.DisplayMember = "Text";
            this.cmbStandardClass.FormattingEnabled = true;
            this.cmbStandardClass.Items.AddRange(new object[] {
            ""});
            this.cmbStandardClass.Location = new System.Drawing.Point(126, 142);
            this.cmbStandardClass.MaxLength = 1;
            this.cmbStandardClass.Name = "cmbStandardClass";
            this.cmbStandardClass.Size = new System.Drawing.Size(44, 21);
            this.cmbStandardClass.TabIndex = 6;
            this.cmbStandardClass.ValueMember = "Value";
            this.cmbStandardClass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.DisplayMember = "Text";
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.Items.AddRange(new object[] {
            "",
            "A",
            "I"});
            this.cmbEstatus.Location = new System.Drawing.Point(126, 118);
            this.cmbEstatus.MaxLength = 1;
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(44, 21);
            this.cmbEstatus.TabIndex = 5;
            this.cmbEstatus.ValueMember = "Value";
            this.cmbEstatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MyCTS.Entities.AirLinesClass);
            // 
            // ucDeletePCCs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmbBussinessClass4);
            this.Controls.Add(this.cmbBussinessClass3);
            this.Controls.Add(this.cmbBussinessClass2);
            this.Controls.Add(this.cmbBussinessClass1);
            this.Controls.Add(this.cmbConfirmation);
            this.Controls.Add(this.cmbSpecificClass);
            this.Controls.Add(this.cmbStandardClass);
            this.Controls.Add(this.cmbEstatus);
            this.Controls.Add(this.rdoDelete);
            this.Controls.Add(this.rdoSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPCCName);
            this.Controls.Add(this.txtPCC);
            this.Controls.Add(this.lblBussinessClass4);
            this.Controls.Add(this.lblBussinessClass3);
            this.Controls.Add(this.lblBussinessClass2);
            this.Controls.Add(this.lblBussinessClass1);
            this.Controls.Add(this.lblConfirmation);
            this.Controls.Add(this.lblSpecificClass);
            this.Controls.Add(this.lblStandardClass);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPCCName);
            this.Controls.Add(this.lblPCC);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucDeletePCCs";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDeletePCCs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyCTS.Forms.UI.SmartTextBox txtPCCName;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private System.Windows.Forms.Label lblBussinessClass4;
        private System.Windows.Forms.Label lblBussinessClass3;
        private System.Windows.Forms.Label lblBussinessClass2;
        private System.Windows.Forms.Label lblBussinessClass1;
        private System.Windows.Forms.Label lblConfirmation;
        private System.Windows.Forms.Label lblSpecificClass;
        private System.Windows.Forms.Label lblStandardClass;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPCCName;
        private System.Windows.Forms.Label lblPCC;
        private System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoSearch;
        private System.Windows.Forms.RadioButton rdoDelete;
        private System.Windows.Forms.ComboBox cmbBussinessClass4;
        private System.Windows.Forms.ComboBox cmbBussinessClass3;
        private System.Windows.Forms.ComboBox cmbBussinessClass2;
        private System.Windows.Forms.ComboBox cmbBussinessClass1;
        private System.Windows.Forms.ComboBox cmbConfirmation;
        private System.Windows.Forms.ComboBox cmbSpecificClass;
        private System.Windows.Forms.ComboBox cmbStandardClass;
        private System.Windows.Forms.ComboBox cmbEstatus;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}
