namespace MyCTS.Presentation
{
    partial class ucDeleteAlAgreements
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
            this.txtOSI = new MyCTS.Forms.UI.SmartTextBox();
            this.txtTourCode = new MyCTS.Forms.UI.SmartTextBox();
            this.txtDomesticComission = new MyCTS.Forms.UI.SmartTextBox();
            this.txtInternationalComission = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAgreementCode = new MyCTS.Forms.UI.SmartTextBox();
            this.lblOSI = new System.Windows.Forms.Label();
            this.lblTourCode = new System.Windows.Forms.Label();
            this.lblDomesticComission = new System.Windows.Forms.Label();
            this.lblInternationalComission = new System.Windows.Forms.Label();
            this.lblAgreementCode = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rdoSearch = new System.Windows.Forms.RadioButton();
            this.rdoDelete = new System.Windows.Forms.RadioButton();
            this.lblQuest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtOSI
            // 
            this.txtOSI.AllowBlankSpaces = true;
            this.txtOSI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOSI.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtOSI.CustomExpression = ".*";
            this.txtOSI.EnterColor = System.Drawing.Color.Empty;
            this.txtOSI.LeaveColor = System.Drawing.Color.Empty;
            this.txtOSI.Location = new System.Drawing.Point(139, 164);
            this.txtOSI.MaxLength = 50;
            this.txtOSI.Name = "txtOSI";
            this.txtOSI.Size = new System.Drawing.Size(235, 20);
            this.txtOSI.TabIndex = 7;
            this.txtOSI.TextChanged += new System.EventHandler(this.txtOSI_TextChanged);
            this.txtOSI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtTourCode
            // 
            this.txtTourCode.AllowBlankSpaces = true;
            this.txtTourCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTourCode.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtTourCode.CustomExpression = ".*";
            this.txtTourCode.EnterColor = System.Drawing.Color.Empty;
            this.txtTourCode.LeaveColor = System.Drawing.Color.Empty;
            this.txtTourCode.Location = new System.Drawing.Point(139, 136);
            this.txtTourCode.MaxLength = 50;
            this.txtTourCode.Name = "txtTourCode";
            this.txtTourCode.Size = new System.Drawing.Size(235, 20);
            this.txtTourCode.TabIndex = 6;
            this.txtTourCode.TextChanged += new System.EventHandler(this.txtTourCode_TextChanged);
            this.txtTourCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtDomesticComission
            // 
            this.txtDomesticComission.AllowBlankSpaces = true;
            this.txtDomesticComission.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDomesticComission.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtDomesticComission.CustomExpression = ".*";
            this.txtDomesticComission.EnterColor = System.Drawing.Color.Empty;
            this.txtDomesticComission.LeaveColor = System.Drawing.Color.Empty;
            this.txtDomesticComission.Location = new System.Drawing.Point(139, 110);
            this.txtDomesticComission.MaxLength = 2;
            this.txtDomesticComission.Name = "txtDomesticComission";
            this.txtDomesticComission.Size = new System.Drawing.Size(34, 20);
            this.txtDomesticComission.TabIndex = 5;
            this.txtDomesticComission.TextChanged += new System.EventHandler(this.txtDomesticComission_TextChanged);
            this.txtDomesticComission.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtInternationalComission
            // 
            this.txtInternationalComission.AllowBlankSpaces = true;
            this.txtInternationalComission.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInternationalComission.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtInternationalComission.CustomExpression = ".*";
            this.txtInternationalComission.EnterColor = System.Drawing.Color.Empty;
            this.txtInternationalComission.LeaveColor = System.Drawing.Color.Empty;
            this.txtInternationalComission.Location = new System.Drawing.Point(139, 85);
            this.txtInternationalComission.MaxLength = 2;
            this.txtInternationalComission.Name = "txtInternationalComission";
            this.txtInternationalComission.Size = new System.Drawing.Size(34, 20);
            this.txtInternationalComission.TabIndex = 4;
            this.txtInternationalComission.TextChanged += new System.EventHandler(this.txtInternationalComission_TextChanged);
            this.txtInternationalComission.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtAgreementCode
            // 
            this.txtAgreementCode.AllowBlankSpaces = true;
            this.txtAgreementCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAgreementCode.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAgreementCode.CustomExpression = ".*";
            this.txtAgreementCode.EnterColor = System.Drawing.Color.Empty;
            this.txtAgreementCode.LeaveColor = System.Drawing.Color.Empty;
            this.txtAgreementCode.Location = new System.Drawing.Point(139, 58);
            this.txtAgreementCode.MaxLength = 2;
            this.txtAgreementCode.Name = "txtAgreementCode";
            this.txtAgreementCode.Size = new System.Drawing.Size(34, 20);
            this.txtAgreementCode.TabIndex = 3;
            this.txtAgreementCode.TextChanged += new System.EventHandler(this.txtAgreementCode_TextChanged);
            this.txtAgreementCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblOSI
            // 
            this.lblOSI.AutoSize = true;
            this.lblOSI.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblOSI.Location = new System.Drawing.Point(17, 164);
            this.lblOSI.Name = "lblOSI";
            this.lblOSI.Size = new System.Drawing.Size(25, 13);
            this.lblOSI.TabIndex = 0;
            this.lblOSI.Text = "OSI";
            // 
            // lblTourCode
            // 
            this.lblTourCode.AutoSize = true;
            this.lblTourCode.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTourCode.Location = new System.Drawing.Point(17, 139);
            this.lblTourCode.Name = "lblTourCode";
            this.lblTourCode.Size = new System.Drawing.Size(57, 13);
            this.lblTourCode.TabIndex = 0;
            this.lblTourCode.Text = "Tour Code";
            // 
            // lblDomesticComission
            // 
            this.lblDomesticComission.AutoSize = true;
            this.lblDomesticComission.Location = new System.Drawing.Point(17, 113);
            this.lblDomesticComission.Name = "lblDomesticComission";
            this.lblDomesticComission.Size = new System.Drawing.Size(102, 13);
            this.lblDomesticComission.TabIndex = 0;
            this.lblDomesticComission.Text = "Comisión Domestica";
            // 
            // lblInternationalComission
            // 
            this.lblInternationalComission.AutoSize = true;
            this.lblInternationalComission.Location = new System.Drawing.Point(17, 88);
            this.lblInternationalComission.Name = "lblInternationalComission";
            this.lblInternationalComission.Size = new System.Drawing.Size(113, 13);
            this.lblInternationalComission.TabIndex = 0;
            this.lblInternationalComission.Text = "Comisión Internacional";
            // 
            // lblAgreementCode
            // 
            this.lblAgreementCode.AutoSize = true;
            this.lblAgreementCode.Location = new System.Drawing.Point(17, 61);
            this.lblAgreementCode.Name = "lblAgreementCode";
            this.lblAgreementCode.Size = new System.Drawing.Size(53, 13);
            this.lblAgreementCode.TabIndex = 0;
            this.lblAgreementCode.Text = "Aerolínea";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(274, 199);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 24);
            this.btnAccept.TabIndex = 8;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(6, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 18);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Baja de Agreement";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rdoSearch
            // 
            this.rdoSearch.AutoSize = true;
            this.rdoSearch.Location = new System.Drawing.Point(139, 32);
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
            this.rdoDelete.Location = new System.Drawing.Point(215, 32);
            this.rdoDelete.Name = "rdoDelete";
            this.rdoDelete.Size = new System.Drawing.Size(61, 17);
            this.rdoDelete.TabIndex = 2;
            this.rdoDelete.TabStop = true;
            this.rdoDelete.Text = "Eliminar";
            this.rdoDelete.UseVisualStyleBackColor = true;
            this.rdoDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblQuest
            // 
            this.lblQuest.AutoSize = true;
            this.lblQuest.Location = new System.Drawing.Point(17, 32);
            this.lblQuest.Name = "lblQuest";
            this.lblQuest.Size = new System.Drawing.Size(106, 13);
            this.lblQuest.TabIndex = 0;
            this.lblQuest.Text = "¿Que deseas hacer?";
            // 
            // ucDeleteAlAgreements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblQuest);
            this.Controls.Add(this.rdoDelete);
            this.Controls.Add(this.rdoSearch);
            this.Controls.Add(this.txtOSI);
            this.Controls.Add(this.txtTourCode);
            this.Controls.Add(this.txtDomesticComission);
            this.Controls.Add(this.txtInternationalComission);
            this.Controls.Add(this.txtAgreementCode);
            this.Controls.Add(this.lblOSI);
            this.Controls.Add(this.lblTourCode);
            this.Controls.Add(this.lblDomesticComission);
            this.Controls.Add(this.lblInternationalComission);
            this.Controls.Add(this.lblAgreementCode);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucDeleteAlAgreements";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDeleteAlAgreements_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyCTS.Forms.UI.SmartTextBox txtOSI;
        private MyCTS.Forms.UI.SmartTextBox txtTourCode;
        private MyCTS.Forms.UI.SmartTextBox txtDomesticComission;
        private MyCTS.Forms.UI.SmartTextBox txtInternationalComission;
        private MyCTS.Forms.UI.SmartTextBox txtAgreementCode;
        private System.Windows.Forms.Label lblOSI;
        private System.Windows.Forms.Label lblTourCode;
        private System.Windows.Forms.Label lblDomesticComission;
        private System.Windows.Forms.Label lblInternationalComission;
        private System.Windows.Forms.Label lblAgreementCode;
        private System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rdoSearch;
        private System.Windows.Forms.RadioButton rdoDelete;
        private System.Windows.Forms.Label lblQuest;
    }
}
