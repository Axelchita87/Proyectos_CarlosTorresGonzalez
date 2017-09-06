namespace MyCTS.Presentation
{
    partial class ucUpdateImages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucUpdateImages));
            this.lblTitle = new System.Windows.Forms.Label();
            this.rdoBanerImage = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.rdoUpdateImgAirline = new System.Windows.Forms.RadioButton();
            this.rdoUpdateImgTicket = new System.Windows.Forms.RadioButton();
            this.btnSearchImage = new System.Windows.Forms.Button();
            this.txtAirline = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAirlineCode = new System.Windows.Forms.Label();
            this.lblURL = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lblInfoNOImage = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.lblTitle.TabIndex = 46;
            this.lblTitle.Text = "Actualizar Imágenes";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoBanerImage
            // 
            this.rdoBanerImage.AutoSize = true;
            this.rdoBanerImage.Location = new System.Drawing.Point(19, 111);
            this.rdoBanerImage.Name = "rdoBanerImage";
            this.rdoBanerImage.Size = new System.Drawing.Size(184, 17);
            this.rdoBanerImage.TabIndex = 3;
            this.rdoBanerImage.TabStop = true;
            this.rdoBanerImage.Text = "Insertar archivo en BannerImages";
            this.rdoBanerImage.UseVisualStyleBackColor = true;
            this.rdoBanerImage.CheckedChanged += new System.EventHandler(this.rdoBanerImage_CheckedChanged);
            this.rdoBanerImage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Seleccione una opción";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(286, 113);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(95, 13);
            this.lblImage.TabIndex = 50;
            this.lblImage.Text = "Seleccionar Imgen";
            this.lblImage.Visible = false;
            // 
            // rdoUpdateImgAirline
            // 
            this.rdoUpdateImgAirline.AutoSize = true;
            this.rdoUpdateImgAirline.Location = new System.Drawing.Point(19, 88);
            this.rdoUpdateImgAirline.Name = "rdoUpdateImgAirline";
            this.rdoUpdateImgAirline.Size = new System.Drawing.Size(199, 17);
            this.rdoUpdateImgAirline.TabIndex = 2;
            this.rdoUpdateImgAirline.TabStop = true;
            this.rdoUpdateImgAirline.Text = "Actualiza o Inserta Imagen Aerolínea";
            this.rdoUpdateImgAirline.UseVisualStyleBackColor = true;
            this.rdoUpdateImgAirline.CheckedChanged += new System.EventHandler(this.rdoUpdateImgAirline_CheckedChanged);
            this.rdoUpdateImgAirline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoUpdateImgTicket
            // 
            this.rdoUpdateImgTicket.AutoSize = true;
            this.rdoUpdateImgTicket.Location = new System.Drawing.Point(19, 65);
            this.rdoUpdateImgTicket.Name = "rdoUpdateImgTicket";
            this.rdoUpdateImgTicket.Size = new System.Drawing.Size(166, 17);
            this.rdoUpdateImgTicket.TabIndex = 1;
            this.rdoUpdateImgTicket.TabStop = true;
            this.rdoUpdateImgTicket.Text = "Actualiza Imagen Tiket Printer";
            this.rdoUpdateImgTicket.UseVisualStyleBackColor = true;
            this.rdoUpdateImgTicket.CheckedChanged += new System.EventHandler(this.rdoUpdateImgTicket_CheckedChanged);
            this.rdoUpdateImgTicket.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnSearchImage
            // 
            this.btnSearchImage.BackColor = System.Drawing.Color.LightGray;
            this.btnSearchImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchImage.BackgroundImage")));
            this.btnSearchImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchImage.Location = new System.Drawing.Point(247, 101);
            this.btnSearchImage.Name = "btnSearchImage";
            this.btnSearchImage.Size = new System.Drawing.Size(33, 27);
            this.btnSearchImage.TabIndex = 4;
            this.btnSearchImage.UseVisualStyleBackColor = false;
            this.btnSearchImage.Visible = false;
            this.btnSearchImage.Click += new System.EventHandler(this.btnSearchImage_Click);
            // 
            // txtAirline
            // 
            this.txtAirline.AllowBlankSpaces = false;
            this.txtAirline.BackColor = System.Drawing.SystemColors.Window;
            this.txtAirline.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirline.CharsIncluded = new char[0];
            this.txtAirline.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirline.CustomExpression = ".*";
            this.txtAirline.EnterColor = System.Drawing.Color.White;
            this.txtAirline.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirline.Location = new System.Drawing.Point(22, 147);
            this.txtAirline.MaxLength = 2;
            this.txtAirline.Name = "txtAirline";
            this.txtAirline.Size = new System.Drawing.Size(45, 20);
            this.txtAirline.TabIndex = 5;
            this.txtAirline.Visible = false;
            this.txtAirline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblAirlineCode
            // 
            this.lblAirlineCode.AutoSize = true;
            this.lblAirlineCode.Location = new System.Drawing.Point(73, 150);
            this.lblAirlineCode.Name = "lblAirlineCode";
            this.lblAirlineCode.Size = new System.Drawing.Size(172, 13);
            this.lblAirlineCode.TabIndex = 54;
            this.lblAirlineCode.Text = "Codigo de Aerolínea (2 caracteres)";
            this.lblAirlineCode.Visible = false;
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblURL.Location = new System.Drawing.Point(19, 196);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(132, 13);
            this.lblURL.TabIndex = 55;
            this.lblURL.Text = "URL asociada a la imagen";
            this.lblURL.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(22, 231);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(359, 110);
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(271, 458);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 8;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Visible = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(22, 174);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(359, 20);
            this.txtURL.TabIndex = 6;
            this.txtURL.Visible = false;
            this.txtURL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblInfoNOImage
            // 
            this.lblInfoNOImage.AutoSize = true;
            this.lblInfoNOImage.Location = new System.Drawing.Point(19, 231);
            this.lblInfoNOImage.Name = "lblInfoNOImage";
            this.lblInfoNOImage.Size = new System.Drawing.Size(0, 13);
            this.lblInfoNOImage.TabIndex = 58;
            this.lblInfoNOImage.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(135, 458);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.Blue;
            this.lblDescription.Location = new System.Drawing.Point(20, 357);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(165, 91);
            this.lblDescription.TabIndex = 59;
            this.lblDescription.Text = "Descripción de Códigos\r\nNúm. 1 para Welcome\r\nNúm. 2 para Cargos por Servicios\r\nNú" +
                "m. 3 para PDF\r\nNúm. 4 para Script\r\nNúm. 77 inactivos\r\n\r\n";
            // 
            // ucUpdateImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblInfoNOImage);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.lblAirlineCode);
            this.Controls.Add(this.txtAirline);
            this.Controls.Add(this.rdoBanerImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.btnSearchImage);
            this.Controls.Add(this.rdoUpdateImgAirline);
            this.Controls.Add(this.rdoUpdateImgTicket);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucUpdateImages";
            this.Size = new System.Drawing.Size(411, 580);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rdoBanerImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.RadioButton rdoUpdateImgAirline;
        private System.Windows.Forms.RadioButton rdoUpdateImgTicket;
        private System.Windows.Forms.Button btnSearchImage;
        private MyCTS.Forms.UI.SmartTextBox txtAirline;
        private System.Windows.Forms.Label lblAirlineCode;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label lblInfoNOImage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDescription;
    }
}
