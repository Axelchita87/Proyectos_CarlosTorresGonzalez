namespace MyCTS.Presentation
{
    partial class ucAddAirLinesFare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAddAirLinesFare));
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblCodeAirline = new System.Windows.Forms.Label();
            this.AirlineName = new System.Windows.Forms.Label();
            this.lblAut = new System.Windows.Forms.Label();
            this.lblMan = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.lblMix = new System.Windows.Forms.Label();
            this.lblMisc = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.txtCodeAirline = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAirlineName = new MyCTS.Forms.UI.SmartTextBox();
            this.cmbCCAut = new System.Windows.Forms.ComboBox();
            this.cmbMan = new System.Windows.Forms.ComboBox();
            this.cmbCash = new System.Windows.Forms.ComboBox();
            this.cmbPMix = new System.Windows.Forms.ComboBox();
            this.cmbMisce = new System.Windows.Forms.ComboBox();
            this.cmbOpManual = new System.Windows.Forms.ComboBox();
            this.lblOpManual = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.btnSearchImage = new System.Windows.Forms.Button();
            this.lblInfoNOImage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.lblTitle.Text = "Alta de Aerolíneas ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(263, 430);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 24);
            this.btnAccept.TabIndex = 8;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblCodeAirline
            // 
            this.lblCodeAirline.AutoSize = true;
            this.lblCodeAirline.Location = new System.Drawing.Point(14, 36);
            this.lblCodeAirline.Name = "lblCodeAirline";
            this.lblCodeAirline.Size = new System.Drawing.Size(78, 13);
            this.lblCodeAirline.TabIndex = 0;
            this.lblCodeAirline.Text = "Cod. Aerolínea";
            // 
            // AirlineName
            // 
            this.AirlineName.AutoSize = true;
            this.AirlineName.Location = new System.Drawing.Point(14, 59);
            this.AirlineName.Name = "AirlineName";
            this.AirlineName.Size = new System.Drawing.Size(93, 13);
            this.AirlineName.TabIndex = 0;
            this.AirlineName.Text = "Nom de Aerolínea";
            // 
            // lblAut
            // 
            this.lblAut.AutoSize = true;
            this.lblAut.Location = new System.Drawing.Point(14, 83);
            this.lblAut.Name = "lblAut";
            this.lblAut.Size = new System.Drawing.Size(74, 13);
            this.lblAut.TabIndex = 0;
            this.lblAut.Text = "CCAutomatico";
            // 
            // lblMan
            // 
            this.lblMan.AutoSize = true;
            this.lblMan.Location = new System.Drawing.Point(14, 110);
            this.lblMan.Name = "lblMan";
            this.lblMan.Size = new System.Drawing.Size(68, 13);
            this.lblMan.TabIndex = 0;
            this.lblMan.Text = "CCMananual";
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Location = new System.Drawing.Point(14, 137);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(31, 13);
            this.lblCash.TabIndex = 0;
            this.lblCash.Text = "Cash";
            // 
            // lblMix
            // 
            this.lblMix.AutoSize = true;
            this.lblMix.Location = new System.Drawing.Point(14, 160);
            this.lblMix.Name = "lblMix";
            this.lblMix.Size = new System.Drawing.Size(60, 13);
            this.lblMix.TabIndex = 0;
            this.lblMix.Text = "Pago Mixto";
            // 
            // lblMisc
            // 
            this.lblMisc.AutoSize = true;
            this.lblMisc.Location = new System.Drawing.Point(14, 184);
            this.lblMisc.Name = "lblMisc";
            this.lblMisc.Size = new System.Drawing.Size(61, 13);
            this.lblMisc.TabIndex = 0;
            this.lblMisc.Text = "Miscelaneo";
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(14, 386);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(271, 13);
            this.lblWarning.TabIndex = 0;
            this.lblWarning.Text = "No olvidar dar de alta la imagen del logo de la Aerolínea";
            // 
            // txtCodeAirline
            // 
            this.txtCodeAirline.AllowBlankSpaces = true;
            this.txtCodeAirline.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodeAirline.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtCodeAirline.CustomExpression = ".*";
            this.txtCodeAirline.EnterColor = System.Drawing.Color.Empty;
            this.txtCodeAirline.LeaveColor = System.Drawing.Color.Empty;
            this.txtCodeAirline.Location = new System.Drawing.Point(113, 33);
            this.txtCodeAirline.MaxLength = 2;
            this.txtCodeAirline.Name = "txtCodeAirline";
            this.txtCodeAirline.Size = new System.Drawing.Size(43, 20);
            this.txtCodeAirline.TabIndex = 1;
            this.txtCodeAirline.TextChanged += new System.EventHandler(this.txtCodeAirline_TextChanged);
            this.txtCodeAirline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtAirlineName
            // 
            this.txtAirlineName.AllowBlankSpaces = true;
            this.txtAirlineName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirlineName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtAirlineName.CustomExpression = ".*";
            this.txtAirlineName.EnterColor = System.Drawing.Color.Empty;
            this.txtAirlineName.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirlineName.Location = new System.Drawing.Point(113, 57);
            this.txtAirlineName.MaxLength = 50;
            this.txtAirlineName.Name = "txtAirlineName";
            this.txtAirlineName.Size = new System.Drawing.Size(198, 20);
            this.txtAirlineName.TabIndex = 2;
            this.txtAirlineName.TextChanged += new System.EventHandler(this.txtAirlineName_TextChanged);
            this.txtAirlineName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbCCAut
            // 
            this.cmbCCAut.FormattingEnabled = true;
            this.cmbCCAut.Items.AddRange(new object[] {
            "",
            "True",
            "False"});
            this.cmbCCAut.Location = new System.Drawing.Point(113, 80);
            this.cmbCCAut.Name = "cmbCCAut";
            this.cmbCCAut.Size = new System.Drawing.Size(59, 21);
            this.cmbCCAut.TabIndex = 3;
            this.cmbCCAut.TextChanged += new System.EventHandler(this.cmbCCAut_TextChanged);
            // 
            // cmbMan
            // 
            this.cmbMan.FormattingEnabled = true;
            this.cmbMan.Items.AddRange(new object[] {
            "",
            "True",
            "False"});
            this.cmbMan.Location = new System.Drawing.Point(113, 106);
            this.cmbMan.Name = "cmbMan";
            this.cmbMan.Size = new System.Drawing.Size(59, 21);
            this.cmbMan.TabIndex = 4;
            this.cmbMan.TextChanged += new System.EventHandler(this.cmbMan_TextChanged);
            // 
            // cmbCash
            // 
            this.cmbCash.FormattingEnabled = true;
            this.cmbCash.Items.AddRange(new object[] {
            "",
            "True",
            "False"});
            this.cmbCash.Location = new System.Drawing.Point(113, 131);
            this.cmbCash.Name = "cmbCash";
            this.cmbCash.Size = new System.Drawing.Size(59, 21);
            this.cmbCash.TabIndex = 5;
            this.cmbCash.TextChanged += new System.EventHandler(this.cmbCash_TextChanged);
            // 
            // cmbPMix
            // 
            this.cmbPMix.FormattingEnabled = true;
            this.cmbPMix.Items.AddRange(new object[] {
            "",
            "True",
            "False"});
            this.cmbPMix.Location = new System.Drawing.Point(113, 156);
            this.cmbPMix.Name = "cmbPMix";
            this.cmbPMix.Size = new System.Drawing.Size(59, 21);
            this.cmbPMix.TabIndex = 6;
            this.cmbPMix.TextChanged += new System.EventHandler(this.cmbPMix_TextChanged);
            // 
            // cmbMisce
            // 
            this.cmbMisce.FormattingEnabled = true;
            this.cmbMisce.Items.AddRange(new object[] {
            "",
            "True",
            "False"});
            this.cmbMisce.Location = new System.Drawing.Point(113, 180);
            this.cmbMisce.Name = "cmbMisce";
            this.cmbMisce.Size = new System.Drawing.Size(59, 21);
            this.cmbMisce.TabIndex = 7;
            this.cmbMisce.TextChanged += new System.EventHandler(this.cmbMisce_TextChanged);
            // 
            // cmbOpManual
            // 
            this.cmbOpManual.FormattingEnabled = true;
            this.cmbOpManual.Items.AddRange(new object[] {
            "",
            "True",
            "False"});
            this.cmbOpManual.Location = new System.Drawing.Point(113, 204);
            this.cmbOpManual.Name = "cmbOpManual";
            this.cmbOpManual.Size = new System.Drawing.Size(59, 21);
            this.cmbOpManual.TabIndex = 10;
            // 
            // lblOpManual
            // 
            this.lblOpManual.AutoSize = true;
            this.lblOpManual.Location = new System.Drawing.Point(14, 208);
            this.lblOpManual.Name = "lblOpManual";
            this.lblOpManual.Size = new System.Drawing.Size(56, 13);
            this.lblOpManual.TabIndex = 9;
            this.lblOpManual.Text = "OpManual";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(17, 263);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(359, 110);
            this.pictureBox1.TabIndex = 62;
            this.pictureBox1.TabStop = false;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(56, 244);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(95, 13);
            this.lblImage.TabIndex = 60;
            this.lblImage.Text = "Seleccionar Imgen";
            // 
            // btnSearchImage
            // 
            this.btnSearchImage.BackColor = System.Drawing.Color.LightGray;
            this.btnSearchImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchImage.BackgroundImage")));
            this.btnSearchImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchImage.Location = new System.Drawing.Point(17, 230);
            this.btnSearchImage.Name = "btnSearchImage";
            this.btnSearchImage.Size = new System.Drawing.Size(33, 27);
            this.btnSearchImage.TabIndex = 57;
            this.btnSearchImage.UseVisualStyleBackColor = false;
            this.btnSearchImage.Click += new System.EventHandler(this.btnSearchImage_Click);
            // 
            // lblInfoNOImage
            // 
            this.lblInfoNOImage.AutoSize = true;
            this.lblInfoNOImage.Location = new System.Drawing.Point(23, 277);
            this.lblInfoNOImage.Name = "lblInfoNOImage";
            this.lblInfoNOImage.Size = new System.Drawing.Size(0, 13);
            this.lblInfoNOImage.TabIndex = 63;
            this.lblInfoNOImage.Visible = false;
            // 
            // ucAddAirLinesFare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblInfoNOImage);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.btnSearchImage);
            this.Controls.Add(this.cmbOpManual);
            this.Controls.Add(this.lblOpManual);
            this.Controls.Add(this.cmbMisce);
            this.Controls.Add(this.cmbPMix);
            this.Controls.Add(this.cmbCash);
            this.Controls.Add(this.cmbMan);
            this.Controls.Add(this.cmbCCAut);
            this.Controls.Add(this.txtAirlineName);
            this.Controls.Add(this.txtCodeAirline);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.lblMisc);
            this.Controls.Add(this.lblMix);
            this.Controls.Add(this.lblCash);
            this.Controls.Add(this.lblMan);
            this.Controls.Add(this.lblAut);
            this.Controls.Add(this.AirlineName);
            this.Controls.Add(this.lblCodeAirline);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucAddAirLinesFare";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucAddAirLinesFare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblCodeAirline;
        private System.Windows.Forms.Label AirlineName;
        private System.Windows.Forms.Label lblAut;
        private System.Windows.Forms.Label lblMan;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Label lblMix;
        private System.Windows.Forms.Label lblMisc;
        private System.Windows.Forms.Label lblWarning;
        private MyCTS.Forms.UI.SmartTextBox txtCodeAirline;
        private MyCTS.Forms.UI.SmartTextBox txtAirlineName;
        private System.Windows.Forms.ComboBox cmbCCAut;
        private System.Windows.Forms.ComboBox cmbMan;
        private System.Windows.Forms.ComboBox cmbCash;
        private System.Windows.Forms.ComboBox cmbPMix;
        private System.Windows.Forms.ComboBox cmbMisce;
        private System.Windows.Forms.ComboBox cmbOpManual;
        private System.Windows.Forms.Label lblOpManual;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Button btnSearchImage;
        private System.Windows.Forms.Label lblInfoNOImage;
    }
}
