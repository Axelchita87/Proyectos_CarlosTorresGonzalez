namespace MyCTS.Presentation
{
    partial class ucWelcome
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTA = new System.Windows.Forms.Label();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.lblInformacion = new System.Windows.Forms.Label();
            this.BannerBox = new System.Windows.Forms.PictureBox();
            this.timerImages = new System.Windows.Forms.Timer(this.components);
            this.toolTipBannerBox = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblStateConection = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BannerBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTA
            // 
            this.lblTA.AutoSize = true;
            this.lblTA.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTA.ForeColor = System.Drawing.Color.Red;
            this.lblTA.Location = new System.Drawing.Point(9, 427);
            this.lblTA.Name = "lblTA";
            this.lblTA.Size = new System.Drawing.Size(0, 15);
            this.lblTA.TabIndex = 14;
            this.lblTA.Visible = false;
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(49)))), ((int)(((byte)(123)))));
            this.lblBienvenido.Location = new System.Drawing.Point(6, 124);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(394, 48);
            this.lblBienvenido.TabIndex = 13;
            // 
            // lblInformacion
            // 
            this.lblInformacion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(49)))), ((int)(((byte)(123)))));
            this.lblInformacion.Location = new System.Drawing.Point(6, 181);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(401, 226);
            this.lblInformacion.TabIndex = 12;
            // 
            // BannerBox
            // 
            this.BannerBox.BackColor = System.Drawing.Color.White;
            this.BannerBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BannerBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BannerBox.InitialImage = null;
            this.BannerBox.Location = new System.Drawing.Point(9, 12);
            this.BannerBox.Name = "BannerBox";
            this.BannerBox.Size = new System.Drawing.Size(400, 450);
            this.BannerBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BannerBox.TabIndex = 15;
            this.BannerBox.TabStop = false;
            this.BannerBox.Tag = "Da Doble Click Sobre la Imagen para ver los Detalles";
            this.BannerBox.Visible = false;
            this.BannerBox.DoubleClick += new System.EventHandler(this.BannerBox_DoubleClick);
            // 
            // timerImages
            // 
            this.timerImages.Tick += new System.EventHandler(this.timerImages_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = global::MyCTS.Presentation.Properties.Resources.logoMyCTS2;
            this.pictureBox2.Location = new System.Drawing.Point(311, 477);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(110, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // lblStateConection
            // 
            this.lblStateConection.AutoSize = true;
            this.lblStateConection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStateConection.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblStateConection.Location = new System.Drawing.Point(152, 512);
            this.lblStateConection.Name = "lblStateConection";
            this.lblStateConection.Size = new System.Drawing.Size(153, 13);
            this.lblStateConection.TabIndex = 17;
            this.lblStateConection.Text = "Conectado correctamente";
            // 
            // ucWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblStateConection);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.BannerBox);
            this.Controls.Add(this.lblTA);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.lblInformacion);
            this.Name = "ucWelcome";
            this.Size = new System.Drawing.Size(418, 537);
            this.Load += new System.EventHandler(this.ucWelcome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BannerBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTA;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Label lblInformacion;
        private System.Windows.Forms.PictureBox BannerBox;
        private System.Windows.Forms.Timer timerImages;
        private System.Windows.Forms.ToolTip toolTipBannerBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblStateConection;
    }
}
