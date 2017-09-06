namespace MyCTS.Presentation
{
    partial class ucTelephone
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtPhone1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPhone2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPhone3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPhone4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtType1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtType2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtType3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtType4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtExt1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtExt2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtExt3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLine = new MyCTS.Forms.UI.SmartTextBox();
            this.rdoAdd = new System.Windows.Forms.RadioButton();
            this.rdoDelete = new System.Windows.Forms.RadioButton();
            this.txtRange = new MyCTS.Forms.UI.SmartTextBox();
            this.txtExt4 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblNumbers = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblExtention = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblRange = new System.Windows.Forms.Label();
            this.lblGuion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 15);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Telefono";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPhone1
            // 
            this.txtPhone1.AllowBlankSpaces = false;
            this.txtPhone1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPhone1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPhone1.CustomExpression = ".*";
            this.txtPhone1.EnterColor = System.Drawing.Color.Empty;
            this.txtPhone1.LeaveColor = System.Drawing.Color.Empty;
            this.txtPhone1.Location = new System.Drawing.Point(51, 94);
            this.txtPhone1.MaxLength = 20;
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(133, 20);
            this.txtPhone1.TabIndex = 2;
            this.txtPhone1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPhone1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPhone2
            // 
            this.txtPhone2.AllowBlankSpaces = false;
            this.txtPhone2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPhone2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPhone2.CustomExpression = ".*";
            this.txtPhone2.EnterColor = System.Drawing.Color.Empty;
            this.txtPhone2.LeaveColor = System.Drawing.Color.Empty;
            this.txtPhone2.Location = new System.Drawing.Point(51, 120);
            this.txtPhone2.MaxLength = 20;
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(133, 20);
            this.txtPhone2.TabIndex = 5;
            this.txtPhone2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPhone2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPhone3
            // 
            this.txtPhone3.AllowBlankSpaces = false;
            this.txtPhone3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPhone3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPhone3.CustomExpression = ".*";
            this.txtPhone3.EnterColor = System.Drawing.Color.Empty;
            this.txtPhone3.LeaveColor = System.Drawing.Color.Empty;
            this.txtPhone3.Location = new System.Drawing.Point(51, 146);
            this.txtPhone3.MaxLength = 20;
            this.txtPhone3.Name = "txtPhone3";
            this.txtPhone3.Size = new System.Drawing.Size(133, 20);
            this.txtPhone3.TabIndex = 8;
            this.txtPhone3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPhone3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPhone4
            // 
            this.txtPhone4.AllowBlankSpaces = false;
            this.txtPhone4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPhone4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPhone4.CustomExpression = ".*";
            this.txtPhone4.EnterColor = System.Drawing.Color.Empty;
            this.txtPhone4.LeaveColor = System.Drawing.Color.Empty;
            this.txtPhone4.Location = new System.Drawing.Point(51, 172);
            this.txtPhone4.MaxLength = 20;
            this.txtPhone4.Name = "txtPhone4";
            this.txtPhone4.Size = new System.Drawing.Size(133, 20);
            this.txtPhone4.TabIndex = 11;
            this.txtPhone4.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPhone4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtType1
            // 
            this.txtType1.AllowBlankSpaces = false;
            this.txtType1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtType1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtType1.CustomExpression = ".*";
            this.txtType1.EnterColor = System.Drawing.Color.Empty;
            this.txtType1.LeaveColor = System.Drawing.Color.Empty;
            this.txtType1.Location = new System.Drawing.Point(204, 94);
            this.txtType1.MaxLength = 1;
            this.txtType1.Name = "txtType1";
            this.txtType1.Size = new System.Drawing.Size(28, 20);
            this.txtType1.TabIndex = 3;
            this.txtType1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtType1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtType2
            // 
            this.txtType2.AllowBlankSpaces = false;
            this.txtType2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtType2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtType2.CustomExpression = ".*";
            this.txtType2.EnterColor = System.Drawing.Color.Empty;
            this.txtType2.LeaveColor = System.Drawing.Color.Empty;
            this.txtType2.Location = new System.Drawing.Point(204, 120);
            this.txtType2.MaxLength = 1;
            this.txtType2.Name = "txtType2";
            this.txtType2.Size = new System.Drawing.Size(28, 20);
            this.txtType2.TabIndex = 6;
            this.txtType2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtType2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtType3
            // 
            this.txtType3.AllowBlankSpaces = false;
            this.txtType3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtType3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtType3.CustomExpression = ".*";
            this.txtType3.EnterColor = System.Drawing.Color.Empty;
            this.txtType3.LeaveColor = System.Drawing.Color.Empty;
            this.txtType3.Location = new System.Drawing.Point(204, 146);
            this.txtType3.MaxLength = 1;
            this.txtType3.Name = "txtType3";
            this.txtType3.Size = new System.Drawing.Size(28, 20);
            this.txtType3.TabIndex = 9;
            this.txtType3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtType3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtType4
            // 
            this.txtType4.AllowBlankSpaces = false;
            this.txtType4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtType4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtType4.CustomExpression = ".*";
            this.txtType4.EnterColor = System.Drawing.Color.Empty;
            this.txtType4.LeaveColor = System.Drawing.Color.Empty;
            this.txtType4.Location = new System.Drawing.Point(204, 172);
            this.txtType4.MaxLength = 1;
            this.txtType4.Name = "txtType4";
            this.txtType4.Size = new System.Drawing.Size(28, 20);
            this.txtType4.TabIndex = 12;
            this.txtType4.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtType4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtExt1
            // 
            this.txtExt1.AllowBlankSpaces = false;
            this.txtExt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExt1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtExt1.CustomExpression = ".*";
            this.txtExt1.EnterColor = System.Drawing.Color.Empty;
            this.txtExt1.LeaveColor = System.Drawing.Color.Empty;
            this.txtExt1.Location = new System.Drawing.Point(251, 94);
            this.txtExt1.MaxLength = 5;
            this.txtExt1.Name = "txtExt1";
            this.txtExt1.Size = new System.Drawing.Size(41, 20);
            this.txtExt1.TabIndex = 4;
            this.txtExt1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtExt1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtExt2
            // 
            this.txtExt2.AllowBlankSpaces = false;
            this.txtExt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExt2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtExt2.CustomExpression = ".*";
            this.txtExt2.EnterColor = System.Drawing.Color.Empty;
            this.txtExt2.LeaveColor = System.Drawing.Color.Empty;
            this.txtExt2.Location = new System.Drawing.Point(251, 120);
            this.txtExt2.MaxLength = 5;
            this.txtExt2.Name = "txtExt2";
            this.txtExt2.Size = new System.Drawing.Size(41, 20);
            this.txtExt2.TabIndex = 7;
            this.txtExt2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtExt2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtExt3
            // 
            this.txtExt3.AllowBlankSpaces = false;
            this.txtExt3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExt3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtExt3.CustomExpression = ".*";
            this.txtExt3.EnterColor = System.Drawing.Color.Empty;
            this.txtExt3.LeaveColor = System.Drawing.Color.Empty;
            this.txtExt3.Location = new System.Drawing.Point(251, 146);
            this.txtExt3.MaxLength = 5;
            this.txtExt3.Name = "txtExt3";
            this.txtExt3.Size = new System.Drawing.Size(41, 20);
            this.txtExt3.TabIndex = 10;
            this.txtExt3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtExt3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtLine
            // 
            this.txtLine.AllowBlankSpaces = false;
            this.txtLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLine.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtLine.CustomExpression = ".*";
            this.txtLine.EnterColor = System.Drawing.Color.Empty;
            this.txtLine.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine.Location = new System.Drawing.Point(38, 296);
            this.txtLine.MaxLength = 2;
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(41, 20);
            this.txtLine.TabIndex = 15;
            this.txtLine.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoAdd
            // 
            this.rdoAdd.AutoSize = true;
            this.rdoAdd.Checked = true;
            this.rdoAdd.Location = new System.Drawing.Point(17, 44);
            this.rdoAdd.Name = "rdoAdd";
            this.rdoAdd.Size = new System.Drawing.Size(62, 17);
            this.rdoAdd.TabIndex = 1;
            this.rdoAdd.TabStop = true;
            this.rdoAdd.Text = "Agregar";
            this.rdoAdd.UseVisualStyleBackColor = true;
            this.rdoAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoDelete
            // 
            this.rdoDelete.AutoSize = true;
            this.rdoDelete.Location = new System.Drawing.Point(17, 246);
            this.rdoDelete.Name = "rdoDelete";
            this.rdoDelete.Size = new System.Drawing.Size(53, 17);
            this.rdoDelete.TabIndex = 14;
            this.rdoDelete.Text = "Borrar";
            this.rdoDelete.UseVisualStyleBackColor = true;
            this.rdoDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRange
            // 
            this.txtRange.AllowBlankSpaces = false;
            this.txtRange.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRange.CustomExpression = ".*";
            this.txtRange.EnterColor = System.Drawing.Color.Empty;
            this.txtRange.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange.Location = new System.Drawing.Point(111, 296);
            this.txtRange.MaxLength = 2;
            this.txtRange.Name = "txtRange";
            this.txtRange.Size = new System.Drawing.Size(41, 20);
            this.txtRange.TabIndex = 16;
            this.txtRange.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtExt4
            // 
            this.txtExt4.AllowBlankSpaces = false;
            this.txtExt4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExt4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtExt4.CustomExpression = ".*";
            this.txtExt4.EnterColor = System.Drawing.Color.Empty;
            this.txtExt4.LeaveColor = System.Drawing.Color.Empty;
            this.txtExt4.Location = new System.Drawing.Point(251, 172);
            this.txtExt4.MaxLength = 5;
            this.txtExt4.Name = "txtExt4";
            this.txtExt4.Size = new System.Drawing.Size(41, 20);
            this.txtExt4.TabIndex = 13;
            this.txtExt4.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtExt4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblNumbers
            // 
            this.lblNumbers.AutoSize = true;
            this.lblNumbers.Location = new System.Drawing.Point(89, 78);
            this.lblNumbers.Name = "lblNumbers";
            this.lblNumbers.Size = new System.Drawing.Size(52, 13);
            this.lblNumbers.TabIndex = 4;
            this.lblNumbers.Text = "Números:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(204, 78);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(28, 13);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Tipo";
            // 
            // lblExtention
            // 
            this.lblExtention.AutoSize = true;
            this.lblExtention.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblExtention.Location = new System.Drawing.Point(257, 78);
            this.lblExtention.Name = "lblExtention";
            this.lblExtention.Size = new System.Drawing.Size(25, 13);
            this.lblExtention.TabIndex = 4;
            this.lblExtention.Text = "Ext.";
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.ForeColor = System.Drawing.Color.Black;
            this.lblLine.Location = new System.Drawing.Point(40, 280);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(35, 13);
            this.lblLine.TabIndex = 4;
            this.lblLine.Text = "Línea";
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblRange.Location = new System.Drawing.Point(111, 280);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(39, 13);
            this.lblRange.TabIndex = 4;
            this.lblRange.Text = "Rango";
            // 
            // lblGuion
            // 
            this.lblGuion.AutoSize = true;
            this.lblGuion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuion.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblGuion.Location = new System.Drawing.Point(88, 295);
            this.lblGuion.Name = "lblGuion";
            this.lblGuion.Size = new System.Drawing.Size(15, 20);
            this.lblGuion.TabIndex = 4;
            this.lblGuion.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "_____________________________________";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(251, 316);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 17;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucTelephone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRange);
            this.Controls.Add(this.lblGuion);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.lblExtention);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblNumbers);
            this.Controls.Add(this.rdoDelete);
            this.Controls.Add(this.rdoAdd);
            this.Controls.Add(this.txtType4);
            this.Controls.Add(this.txtType3);
            this.Controls.Add(this.txtType2);
            this.Controls.Add(this.txtRange);
            this.Controls.Add(this.txtLine);
            this.Controls.Add(this.txtExt4);
            this.Controls.Add(this.txtExt3);
            this.Controls.Add(this.txtExt2);
            this.Controls.Add(this.txtExt1);
            this.Controls.Add(this.txtType1);
            this.Controls.Add(this.txtPhone4);
            this.Controls.Add(this.txtPhone3);
            this.Controls.Add(this.txtPhone2);
            this.Controls.Add(this.txtPhone1);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucTelephone";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucTelephone_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtPhone1;
        private MyCTS.Forms.UI.SmartTextBox txtPhone2;
        private MyCTS.Forms.UI.SmartTextBox txtPhone3;
        private MyCTS.Forms.UI.SmartTextBox txtPhone4;
        private MyCTS.Forms.UI.SmartTextBox txtType1;
        private MyCTS.Forms.UI.SmartTextBox txtType2;
        private MyCTS.Forms.UI.SmartTextBox txtType3;
        private MyCTS.Forms.UI.SmartTextBox txtType4;
        private MyCTS.Forms.UI.SmartTextBox txtExt1;
        private MyCTS.Forms.UI.SmartTextBox txtExt2;
        private MyCTS.Forms.UI.SmartTextBox txtExt3;
        private MyCTS.Forms.UI.SmartTextBox txtLine;
        private System.Windows.Forms.RadioButton rdoAdd;
        private System.Windows.Forms.RadioButton rdoDelete;
        private MyCTS.Forms.UI.SmartTextBox txtRange;
        private MyCTS.Forms.UI.SmartTextBox txtExt4;
        private System.Windows.Forms.Label lblNumbers;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblExtention;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.Label lblGuion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAccept;
    }
}
