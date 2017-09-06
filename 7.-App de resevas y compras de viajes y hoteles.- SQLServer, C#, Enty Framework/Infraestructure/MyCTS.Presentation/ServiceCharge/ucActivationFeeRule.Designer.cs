namespace MyCTS.Presentation
{
    partial class ucActivationFeeRule
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
            this.txtRuleNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.lblRuleNumber = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtInfoRuleByAttribute1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtInfoRuleNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.lblInfoRuleByAttribute = new System.Windows.Forms.Label();
            this.lblInfoActivationRule = new System.Windows.Forms.Label();
            this.btnActivation = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
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
            this.lblTitle.Size = new System.Drawing.Size(411, 17);
            this.lblTitle.TabIndex = 45;
            this.lblTitle.Text = "Cargo por Servicio";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRuleNumber
            // 
            this.txtRuleNumber.AllowBlankSpaces = false;
            this.txtRuleNumber.BackColor = System.Drawing.SystemColors.Window;
            this.txtRuleNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRuleNumber.CharsIncluded = new char[0];
            this.txtRuleNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRuleNumber.CustomExpression = ".*";
            this.txtRuleNumber.EnterColor = System.Drawing.Color.White;
            this.txtRuleNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtRuleNumber.Location = new System.Drawing.Point(160, 59);
            this.txtRuleNumber.MaxLength = 3;
            this.txtRuleNumber.Name = "txtRuleNumber";
            this.txtRuleNumber.Size = new System.Drawing.Size(45, 20);
            this.txtRuleNumber.TabIndex = 1;
            this.txtRuleNumber.TextChanged += new System.EventHandler(this.txtRuleNumber_TextChanged);
            this.txtRuleNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblRuleNumber
            // 
            this.lblRuleNumber.AutoSize = true;
            this.lblRuleNumber.Location = new System.Drawing.Point(61, 62);
            this.lblRuleNumber.Name = "lblRuleNumber";
            this.lblRuleNumber.Size = new System.Drawing.Size(93, 13);
            this.lblRuleNumber.TabIndex = 45;
            this.lblRuleNumber.Text = "Número de Regla:";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(270, 124);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtInfoRuleByAttribute1
            // 
            this.txtInfoRuleByAttribute1.AllowBlankSpaces = true;
            this.txtInfoRuleByAttribute1.BackColor = System.Drawing.SystemColors.Window;
            this.txtInfoRuleByAttribute1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInfoRuleByAttribute1.CharsIncluded = new char[0];
            this.txtInfoRuleByAttribute1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtInfoRuleByAttribute1.CustomExpression = ".*";
            this.txtInfoRuleByAttribute1.EnterColor = System.Drawing.Color.White;
            this.txtInfoRuleByAttribute1.LeaveColor = System.Drawing.Color.Empty;
            this.txtInfoRuleByAttribute1.Location = new System.Drawing.Point(18, 132);
            this.txtInfoRuleByAttribute1.MaxLength = 200;
            this.txtInfoRuleByAttribute1.Multiline = true;
            this.txtInfoRuleByAttribute1.Name = "txtInfoRuleByAttribute1";
            this.txtInfoRuleByAttribute1.ReadOnly = true;
            this.txtInfoRuleByAttribute1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfoRuleByAttribute1.Size = new System.Drawing.Size(378, 118);
            this.txtInfoRuleByAttribute1.TabIndex = 2;
            this.txtInfoRuleByAttribute1.Visible = false;
            this.txtInfoRuleByAttribute1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtInfoRuleNumber
            // 
            this.txtInfoRuleNumber.AllowBlankSpaces = true;
            this.txtInfoRuleNumber.BackColor = System.Drawing.SystemColors.Window;
            this.txtInfoRuleNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInfoRuleNumber.CharsIncluded = new char[0];
            this.txtInfoRuleNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtInfoRuleNumber.CustomExpression = ".*";
            this.txtInfoRuleNumber.EnterColor = System.Drawing.Color.White;
            this.txtInfoRuleNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtInfoRuleNumber.Location = new System.Drawing.Point(18, 299);
            this.txtInfoRuleNumber.MaxLength = 200;
            this.txtInfoRuleNumber.Multiline = true;
            this.txtInfoRuleNumber.Name = "txtInfoRuleNumber";
            this.txtInfoRuleNumber.ReadOnly = true;
            this.txtInfoRuleNumber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfoRuleNumber.Size = new System.Drawing.Size(378, 118);
            this.txtInfoRuleNumber.TabIndex = 3;
            this.txtInfoRuleNumber.Visible = false;
            this.txtInfoRuleNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblInfoRuleByAttribute
            // 
            this.lblInfoRuleByAttribute.AutoSize = true;
            this.lblInfoRuleByAttribute.Location = new System.Drawing.Point(30, 102);
            this.lblInfoRuleByAttribute.Name = "lblInfoRuleByAttribute";
            this.lblInfoRuleByAttribute.Size = new System.Drawing.Size(35, 13);
            this.lblInfoRuleByAttribute.TabIndex = 45;
            this.lblInfoRuleByAttribute.Text = "label1";
            this.lblInfoRuleByAttribute.Visible = false;
            // 
            // lblInfoActivationRule
            // 
            this.lblInfoActivationRule.AutoSize = true;
            this.lblInfoActivationRule.Location = new System.Drawing.Point(30, 283);
            this.lblInfoActivationRule.Name = "lblInfoActivationRule";
            this.lblInfoActivationRule.Size = new System.Drawing.Size(35, 13);
            this.lblInfoActivationRule.TabIndex = 45;
            this.lblInfoActivationRule.Text = "label1";
            this.lblInfoActivationRule.Visible = false;
            // 
            // btnActivation
            // 
            this.btnActivation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnActivation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivation.Location = new System.Drawing.Point(270, 459);
            this.btnActivation.Name = "btnActivation";
            this.btnActivation.Size = new System.Drawing.Size(110, 24);
            this.btnActivation.TabIndex = 5;
            this.btnActivation.Text = "Activar Regla";
            this.btnActivation.UseVisualStyleBackColor = false;
            this.btnActivation.Visible = false;
            this.btnActivation.Click += new System.EventHandler(this.btnActivation_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(64, 459);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 24);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Limpiar Valores";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ucActivationFeeRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblInfoActivationRule);
            this.Controls.Add(this.lblInfoRuleByAttribute);
            this.Controls.Add(this.txtInfoRuleNumber);
            this.Controls.Add(this.txtInfoRuleByAttribute1);
            this.Controls.Add(this.btnActivation);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblRuleNumber);
            this.Controls.Add(this.txtRuleNumber);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucActivationFeeRule";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucActivationFeeRule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyCTS.Forms.UI.SmartTextBox txtInfoRuleByAttribute1;
        private MyCTS.Forms.UI.SmartTextBox txtInfoRuleNumber;
        private System.Windows.Forms.Label lblInfoRuleByAttribute;
        private System.Windows.Forms.Label lblInfoActivationRule;
        private System.Windows.Forms.Button btnActivation;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblRuleNumber;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtRuleNumber;
        private System.Windows.Forms.Label lblTitle;
    }
}
