namespace MyCTS.Presentation
{
    partial class ucLowFareEndRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLowFareEndRecord));
            this.lblTitle = new System.Windows.Forms.Label();
            this._group = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtApplicant = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this._message = new DevExpress.XtraEditors.LabelControl();
            this.endRecordButton = new System.Windows.Forms.Button();
            this.errrorMessageContainer = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorMessage = new DevExpress.XtraEditors.LabelControl();
            this.loadingControl1 = new MyCTS.Presentation.Components.LoadingControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._group)).BeginInit();
            this._group.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtApplicant.Properties)).BeginInit();
            this.errrorMessageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(384, 13);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "Cierre de Record Interfaces";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // _group
            // 
            this._group.Controls.Add(this.tableLayoutPanel1);
            this._group.Location = new System.Drawing.Point(3, 16);
            this._group.Name = "_group";
            this._group.Size = new System.Drawing.Size(384, 324);
            this._group.TabIndex = 15;
            this._group.Text = "Cierre de Record";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 375F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.errrorMessageContainer, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.02021F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.97979F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(375, 278);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.txtApplicant);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this._message);
            this.panel1.Controls.Add(this.endRecordButton);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 102);
            this.panel1.TabIndex = 23;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.Location = new System.Drawing.Point(279, 76);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(369, 11);
            this.labelControl3.TabIndex = 26;
            this.labelControl3.Text = "*opcional";
            // 
            // txtApplicant
            // 
            this.txtApplicant.Location = new System.Drawing.Point(80, 71);
            this.txtApplicant.Name = "txtApplicant";
            this.txtApplicant.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApplicant.Size = new System.Drawing.Size(193, 20);
            this.txtApplicant.TabIndex = 25;
            this.txtApplicant.ToolTip = "Indique el solicitante de la factura, en caso de que no lo requiera se tomara el " +
    "agente firmado";
            this.txtApplicant.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.Location = new System.Drawing.Point(16, 74);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(369, 11);
            this.labelControl2.TabIndex = 24;
            this.labelControl2.Text = "Solicitante:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(37, 54);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(369, 11);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "! Haz click  para empezar el proceso de facturación automatica !";
            // 
            // _message
            // 
            this._message.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._message.Location = new System.Drawing.Point(105, 3);
            this._message.Name = "_message";
            this._message.Size = new System.Drawing.Size(121, 16);
            this._message.TabIndex = 19;
            this._message.Text = "Genera tu  Factura";
            // 
            // endRecordButton
            // 
            this.endRecordButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.endRecordButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.endRecordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.endRecordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endRecordButton.ForeColor = System.Drawing.Color.Black;
            this.endRecordButton.Location = new System.Drawing.Point(115, 25);
            this.endRecordButton.Name = "endRecordButton";
            this.endRecordButton.Size = new System.Drawing.Size(100, 23);
            this.endRecordButton.TabIndex = 18;
            this.endRecordButton.Text = "Generar";
            this.endRecordButton.UseVisualStyleBackColor = false;
            this.endRecordButton.Click += new System.EventHandler(this.endRecordButton_Click);
            // 
            // errrorMessageContainer
            // 
            this.errrorMessageContainer.Controls.Add(this.pictureBox1);
            this.errrorMessageContainer.Controls.Add(this.errorMessage);
            this.errrorMessageContainer.Location = new System.Drawing.Point(3, 111);
            this.errrorMessageContainer.Name = "errrorMessageContainer";
            this.errrorMessageContainer.Size = new System.Drawing.Size(369, 159);
            this.errrorMessageContainer.TabIndex = 23;
            this.errrorMessageContainer.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(115, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // errorMessage
            // 
            this.errorMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.errorMessage.Location = new System.Drawing.Point(2, 56);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(369, 11);
            this.errorMessage.TabIndex = 20;
            this.errorMessage.Text = "--";
            // 
            // loadingControl1
            // 
            this.loadingControl1.BackColor = System.Drawing.Color.White;
            this.loadingControl1.ImageToShow = null;
            this.loadingControl1.Location = new System.Drawing.Point(27, 40);
            this.loadingControl1.MessageToShow = "Generando...";
            this.loadingControl1.Name = "loadingControl1";
            this.loadingControl1.Size = new System.Drawing.Size(305, 199);
            this.loadingControl1.TabIndex = 17;
            this.loadingControl1.Visible = false;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Metropolis";
            // 
            // ucLowFareEndRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this._group);
            this.Controls.Add(this.loadingControl1);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucLowFareEndRecord";
            this.Size = new System.Drawing.Size(390, 343);
            this.Load += new System.EventHandler(this.ucLowFareEndRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this._group)).EndInit();
            this._group.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtApplicant.Properties)).EndInit();
            this.errrorMessageContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private DevExpress.XtraEditors.GroupControl _group;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.Button endRecordButton;
        private DevExpress.XtraEditors.LabelControl _message;
        private MyCTS.Presentation.Components.LoadingControl loadingControl1;
        private DevExpress.XtraEditors.LabelControl errorMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel errrorMessageContainer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtApplicant;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
