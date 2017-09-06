namespace MyCTS.Presentation
{
    partial class ucDeleteAirLinesFare
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
            this.txtAirlineName = new MyCTS.Forms.UI.SmartTextBox();
            this.txtCodeAirline = new MyCTS.Forms.UI.SmartTextBox();
            this.lblMisc = new System.Windows.Forms.Label();
            this.lblMix = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.lblMan = new System.Windows.Forms.Label();
            this.lblAut = new System.Windows.Forms.Label();
            this.AirlineName = new System.Windows.Forms.Label();
            this.lblCodeAirline = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoSearch = new System.Windows.Forms.RadioButton();
            this.rdoDelete = new System.Windows.Forms.RadioButton();
            this.cmbMisce = new System.Windows.Forms.ComboBox();
            this.cmbPMix = new System.Windows.Forms.ComboBox();
            this.cmbCash = new System.Windows.Forms.ComboBox();
            this.cmbMan = new System.Windows.Forms.ComboBox();
            this.cmbCCAut = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtAirlineName
            // 
            this.txtAirlineName.AllowBlankSpaces = true;
            this.txtAirlineName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirlineName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtAirlineName.CustomExpression = ".*";
            this.txtAirlineName.EnterColor = System.Drawing.Color.Empty;
            this.txtAirlineName.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirlineName.Location = new System.Drawing.Point(118, 93);
            this.txtAirlineName.MaxLength = 50;
            this.txtAirlineName.Name = "txtAirlineName";
            this.txtAirlineName.Size = new System.Drawing.Size(198, 20);
            this.txtAirlineName.TabIndex = 4;
            this.txtAirlineName.TextChanged += new System.EventHandler(this.txtAirlineName_TextChanged);
            this.txtAirlineName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtCodeAirline
            // 
            this.txtCodeAirline.AllowBlankSpaces = true;
            this.txtCodeAirline.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodeAirline.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtCodeAirline.CustomExpression = ".*";
            this.txtCodeAirline.EnterColor = System.Drawing.Color.Empty;
            this.txtCodeAirline.LeaveColor = System.Drawing.Color.Empty;
            this.txtCodeAirline.Location = new System.Drawing.Point(118, 69);
            this.txtCodeAirline.MaxLength = 2;
            this.txtCodeAirline.Name = "txtCodeAirline";
            this.txtCodeAirline.Size = new System.Drawing.Size(43, 20);
            this.txtCodeAirline.TabIndex = 3;
            this.txtCodeAirline.TextChanged += new System.EventHandler(this.txtCodeAirline_TextChanged);
            this.txtCodeAirline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblMisc
            // 
            this.lblMisc.AutoSize = true;
            this.lblMisc.Location = new System.Drawing.Point(19, 220);
            this.lblMisc.Name = "lblMisc";
            this.lblMisc.Size = new System.Drawing.Size(61, 13);
            this.lblMisc.TabIndex = 0;
            this.lblMisc.Text = "Miscelaneo";
            // 
            // lblMix
            // 
            this.lblMix.AutoSize = true;
            this.lblMix.Location = new System.Drawing.Point(19, 196);
            this.lblMix.Name = "lblMix";
            this.lblMix.Size = new System.Drawing.Size(60, 13);
            this.lblMix.TabIndex = 0;
            this.lblMix.Text = "Pago Mixto";
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Location = new System.Drawing.Point(19, 173);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(31, 13);
            this.lblCash.TabIndex = 0;
            this.lblCash.Text = "Cash";
            // 
            // lblMan
            // 
            this.lblMan.AutoSize = true;
            this.lblMan.Location = new System.Drawing.Point(19, 146);
            this.lblMan.Name = "lblMan";
            this.lblMan.Size = new System.Drawing.Size(68, 13);
            this.lblMan.TabIndex = 0;
            this.lblMan.Text = "CCMananual";
            // 
            // lblAut
            // 
            this.lblAut.AutoSize = true;
            this.lblAut.Location = new System.Drawing.Point(19, 119);
            this.lblAut.Name = "lblAut";
            this.lblAut.Size = new System.Drawing.Size(74, 13);
            this.lblAut.TabIndex = 0;
            this.lblAut.Text = "CCAutomatico";
            // 
            // AirlineName
            // 
            this.AirlineName.AutoSize = true;
            this.AirlineName.Location = new System.Drawing.Point(19, 95);
            this.AirlineName.Name = "AirlineName";
            this.AirlineName.Size = new System.Drawing.Size(93, 13);
            this.AirlineName.TabIndex = 0;
            this.AirlineName.Text = "Nom de Aerolínea";
            // 
            // lblCodeAirline
            // 
            this.lblCodeAirline.AutoSize = true;
            this.lblCodeAirline.Location = new System.Drawing.Point(19, 72);
            this.lblCodeAirline.Name = "lblCodeAirline";
            this.lblCodeAirline.Size = new System.Drawing.Size(78, 13);
            this.lblCodeAirline.TabIndex = 0;
            this.lblCodeAirline.Text = "Cod. Aerolínea";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(242, 249);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 24);
            this.btnAccept.TabIndex = 10;
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
            this.lblTitle.Text = "Baja de Aerolíneas ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Que deseas hacer?";
            // 
            // rdoSearch
            // 
            this.rdoSearch.AutoSize = true;
            this.rdoSearch.Location = new System.Drawing.Point(143, 41);
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
            this.rdoDelete.Location = new System.Drawing.Point(228, 43);
            this.rdoDelete.Name = "rdoDelete";
            this.rdoDelete.Size = new System.Drawing.Size(46, 17);
            this.rdoDelete.TabIndex = 2;
            this.rdoDelete.TabStop = true;
            this.rdoDelete.Text = "Baja";
            this.rdoDelete.UseVisualStyleBackColor = true;
            this.rdoDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbMisce
            // 
            this.cmbMisce.FormattingEnabled = true;
            this.cmbMisce.Items.AddRange(new object[] {
            "",
            "True",
            "False"});
            this.cmbMisce.Location = new System.Drawing.Point(118, 216);
            this.cmbMisce.Name = "cmbMisce";
            this.cmbMisce.Size = new System.Drawing.Size(59, 21);
            this.cmbMisce.TabIndex = 9;
            this.cmbMisce.TextChanged += new System.EventHandler(this.cmbMisce_TextChanged);
            // 
            // cmbPMix
            // 
            this.cmbPMix.FormattingEnabled = true;
            this.cmbPMix.Items.AddRange(new object[] {
            "",
            "True",
            "False"});
            this.cmbPMix.Location = new System.Drawing.Point(118, 192);
            this.cmbPMix.Name = "cmbPMix";
            this.cmbPMix.Size = new System.Drawing.Size(59, 21);
            this.cmbPMix.TabIndex = 8;
            this.cmbPMix.TextChanged += new System.EventHandler(this.cmbPMix_TextChanged);
            // 
            // cmbCash
            // 
            this.cmbCash.FormattingEnabled = true;
            this.cmbCash.Items.AddRange(new object[] {
            "",
            "True",
            "False"});
            this.cmbCash.Location = new System.Drawing.Point(118, 167);
            this.cmbCash.Name = "cmbCash";
            this.cmbCash.Size = new System.Drawing.Size(59, 21);
            this.cmbCash.TabIndex = 7;
            this.cmbCash.TextChanged += new System.EventHandler(this.cmbCash_TextChanged);
            // 
            // cmbMan
            // 
            this.cmbMan.FormattingEnabled = true;
            this.cmbMan.Items.AddRange(new object[] {
            "",
            "True",
            "False"});
            this.cmbMan.Location = new System.Drawing.Point(118, 142);
            this.cmbMan.Name = "cmbMan";
            this.cmbMan.Size = new System.Drawing.Size(59, 21);
            this.cmbMan.TabIndex = 6;
            this.cmbMan.TextChanged += new System.EventHandler(this.cmbMan_TextChanged);
            // 
            // cmbCCAut
            // 
            this.cmbCCAut.FormattingEnabled = true;
            this.cmbCCAut.Items.AddRange(new object[] {
            "",
            "True",
            "False"});
            this.cmbCCAut.Location = new System.Drawing.Point(118, 116);
            this.cmbCCAut.Name = "cmbCCAut";
            this.cmbCCAut.Size = new System.Drawing.Size(59, 21);
            this.cmbCCAut.TabIndex = 5;
            this.cmbCCAut.TextChanged += new System.EventHandler(this.cmbCCAut_TextChanged);
            // 
            // ucDeleteAirLinesFare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmbMisce);
            this.Controls.Add(this.cmbPMix);
            this.Controls.Add(this.cmbCash);
            this.Controls.Add(this.cmbMan);
            this.Controls.Add(this.cmbCCAut);
            this.Controls.Add(this.rdoDelete);
            this.Controls.Add(this.rdoSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAirlineName);
            this.Controls.Add(this.txtCodeAirline);
            this.Controls.Add(this.lblMisc);
            this.Controls.Add(this.lblMix);
            this.Controls.Add(this.lblCash);
            this.Controls.Add(this.lblMan);
            this.Controls.Add(this.lblAut);
            this.Controls.Add(this.AirlineName);
            this.Controls.Add(this.lblCodeAirline);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucDeleteAirLinesFare";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDeleteAirLinesFare_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyCTS.Forms.UI.SmartTextBox txtAirlineName;
        private MyCTS.Forms.UI.SmartTextBox txtCodeAirline;
        private System.Windows.Forms.Label lblMisc;
        private System.Windows.Forms.Label lblMix;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Label lblMan;
        private System.Windows.Forms.Label lblAut;
        private System.Windows.Forms.Label AirlineName;
        private System.Windows.Forms.Label lblCodeAirline;
        private System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoSearch;
        private System.Windows.Forms.RadioButton rdoDelete;
        private System.Windows.Forms.ComboBox cmbMisce;
        private System.Windows.Forms.ComboBox cmbPMix;
        private System.Windows.Forms.ComboBox cmbCash;
        private System.Windows.Forms.ComboBox cmbMan;
        private System.Windows.Forms.ComboBox cmbCCAut;
    }
}
