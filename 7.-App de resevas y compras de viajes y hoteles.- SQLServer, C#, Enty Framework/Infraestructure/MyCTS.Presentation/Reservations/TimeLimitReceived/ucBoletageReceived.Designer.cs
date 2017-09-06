namespace MyCTS.Presentation
{
    partial class ucBoletageReceived
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSolicitorName = new System.Windows.Forms.Label();
            this.txtSolicitorName = new MyCTS.Forms.UI.SmartTextBox();
            this.lblReceivedFrom = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblyieldRecord = new System.Windows.Forms.Label();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.lbPCC = new System.Windows.Forms.ListBox();
            this.lblGroups = new System.Windows.Forms.Label();
            this.txtGroups = new MyCTS.Forms.UI.SmartTextBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.cerrandoLabel = new System.Windows.Forms.Label();
            this.progressBar = new GradProg.GradProg();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxReservation = new System.Windows.Forms.PictureBox();
            this.loadingPictureBox = new System.Windows.Forms.PictureBox();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReservation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "6 de Recibido";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSolicitorName
            // 
            this.lblSolicitorName.AutoSize = true;
            this.lblSolicitorName.Location = new System.Drawing.Point(7, 50);
            this.lblSolicitorName.Name = "lblSolicitorName";
            this.lblSolicitorName.Size = new System.Drawing.Size(96, 13);
            this.lblSolicitorName.TabIndex = 0;
            this.lblSolicitorName.Text = "Nombre Solicitante";
            this.lblSolicitorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSolicitorName
            // 
            this.txtSolicitorName.AllowBlankSpaces = true;
            this.txtSolicitorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSolicitorName.CharsIncluded = new char[] {
        '/'};
            this.txtSolicitorName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtSolicitorName.CustomExpression = ".*";
            this.txtSolicitorName.EnterColor = System.Drawing.Color.Empty;
            this.txtSolicitorName.LeaveColor = System.Drawing.Color.Empty;
            this.txtSolicitorName.Location = new System.Drawing.Point(164, 47);
            this.txtSolicitorName.MaxLength = 35;
            this.txtSolicitorName.Name = "txtSolicitorName";
            this.txtSolicitorName.Size = new System.Drawing.Size(232, 20);
            this.txtSolicitorName.TabIndex = 1;
            this.txtSolicitorName.TextChanged += new System.EventHandler(this.txtSolicitorName_TextChanged);
            this.txtSolicitorName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblReceivedFrom
            // 
            this.lblReceivedFrom.AutoSize = true;
            this.lblReceivedFrom.ForeColor = System.Drawing.Color.Blue;
            this.lblReceivedFrom.Location = new System.Drawing.Point(108, 16);
            this.lblReceivedFrom.Name = "lblReceivedFrom";
            this.lblReceivedFrom.Size = new System.Drawing.Size(76, 13);
            this.lblReceivedFrom.TabIndex = 0;
            this.lblReceivedFrom.Text = "RECIBIDO DE";
            this.lblReceivedFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(292, 210);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 22);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblyieldRecord
            // 
            this.lblyieldRecord.AutoSize = true;
            this.lblyieldRecord.Location = new System.Drawing.Point(7, 94);
            this.lblyieldRecord.Name = "lblyieldRecord";
            this.lblyieldRecord.Size = new System.Drawing.Size(127, 13);
            this.lblyieldRecord.TabIndex = 0;
            this.lblyieldRecord.Text = "Para ceder record al PCC";
            this.lblyieldRecord.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblyieldRecord.Visible = false;
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = true;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(164, 87);
            this.txtPCC.MaxLength = 3000;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(230, 20);
            this.txtPCC.TabIndex = 2;
            this.txtPCC.Visible = false;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lbPCC
            // 
            this.lbPCC.DisplayMember = "Text";
            this.lbPCC.FormattingEnabled = true;
            this.lbPCC.Location = new System.Drawing.Point(164, 105);
            this.lbPCC.Name = "lbPCC";
            this.lbPCC.Size = new System.Drawing.Size(230, 95);
            this.lbPCC.TabIndex = 4;
            this.lbPCC.ValueMember = "Value";
            this.lbPCC.Visible = false;
            this.lbPCC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbPCC_KeyDown);
            // 
            // lblGroups
            // 
            this.lblGroups.AutoSize = true;
            this.lblGroups.Location = new System.Drawing.Point(7, 147);
            this.lblGroups.Name = "lblGroups";
            this.lblGroups.Size = new System.Drawing.Size(156, 13);
            this.lblGroups.TabIndex = 5;
            this.lblGroups.Text = "6 Recibido para Grupos(Brithis):";
            this.lblGroups.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblGroups.Visible = false;
            // 
            // txtGroups
            // 
            this.txtGroups.AllowBlankSpaces = true;
            this.txtGroups.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGroups.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtGroups.CustomExpression = ".*";
            this.txtGroups.EnterColor = System.Drawing.Color.Empty;
            this.txtGroups.LeaveColor = System.Drawing.Color.Empty;
            this.txtGroups.Location = new System.Drawing.Point(164, 147);
            this.txtGroups.MaxLength = 35;
            this.txtGroups.Name = "txtGroups";
            this.txtGroups.Size = new System.Drawing.Size(230, 20);
            this.txtGroups.TabIndex = 3;
            this.txtGroups.Visible = false;
            this.txtGroups.TextChanged += new System.EventHandler(this.txtGroups_TextChanged);
            this.txtGroups.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.lblReceivedFrom);
            this.MainPanel.Controls.Add(this.txtGroups);
            this.MainPanel.Controls.Add(this.lbPCC);
            this.MainPanel.Controls.Add(this.lblGroups);
            this.MainPanel.Controls.Add(this.txtPCC);
            this.MainPanel.Controls.Add(this.lblyieldRecord);
            this.MainPanel.Controls.Add(this.lblSolicitorName);
            this.MainPanel.Controls.Add(this.btnAccept);
            this.MainPanel.Controls.Add(this.txtSolicitorName);
            this.MainPanel.Location = new System.Drawing.Point(6, 18);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(405, 662);
            this.MainPanel.TabIndex = 6;
            // 
            // cerrandoLabel
            // 
            this.cerrandoLabel.AutoSize = true;
            this.cerrandoLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cerrandoLabel.Location = new System.Drawing.Point(55, 292);
            this.cerrandoLabel.Name = "cerrandoLabel";
            this.cerrandoLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cerrandoLabel.Size = new System.Drawing.Size(272, 14);
            this.cerrandoLabel.TabIndex = 101;
            this.cerrandoLabel.Text = "Cerrando reservación espere por favor..";
            this.cerrandoLabel.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.White;
            this.progressBar.GradientStyle = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.progressBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.progressBar.LabelBackColour = System.Drawing.Color.DimGray;
            this.progressBar.LabelForeColour = System.Drawing.Color.LightSeaGreen;
            this.progressBar.LabelPosition = new System.Drawing.Point(0, 0);
            this.progressBar.Location = new System.Drawing.Point(22, 361);
            this.progressBar.Maximum = 100;
            this.progressBar.Minimum = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Percentage = 0;
            this.progressBar.ProgressBarBackColour = System.Drawing.Color.White;
            this.progressBar.ProgressBarForeColour = System.Drawing.Color.SteelBlue;
            this.progressBar.ShowLabel = false;
            this.progressBar.Size = new System.Drawing.Size(379, 26);
            this.progressBar.TabIndex = 100;
            this.progressBar.Value = 0;
            this.progressBar.Visible = false;
            // 
            // pictureBoxReservation
            // 
            this.pictureBoxReservation.Image = global::MyCTS.Presentation.Properties.Resources.rsz_1327971100_passport;
            this.pictureBoxReservation.Location = new System.Drawing.Point(95, 155);
            this.pictureBoxReservation.Name = "pictureBoxReservation";
            this.pictureBoxReservation.Size = new System.Drawing.Size(142, 134);
            this.pictureBoxReservation.TabIndex = 103;
            this.pictureBoxReservation.TabStop = false;
            this.pictureBoxReservation.Visible = false;
            // 
            // loadingPictureBox
            // 
            this.loadingPictureBox.Image = global::MyCTS.Presentation.Properties.Resources.loadingBlue;
            this.loadingPictureBox.Location = new System.Drawing.Point(48, 309);
            this.loadingPictureBox.Name = "loadingPictureBox";
            this.loadingPictureBox.Size = new System.Drawing.Size(267, 28);
            this.loadingPictureBox.TabIndex = 112;
            this.loadingPictureBox.TabStop = false;
            this.loadingPictureBox.Visible = false;
            // 
            // ucBoletageReceived
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.loadingPictureBox);
            this.Controls.Add(this.pictureBoxReservation);
            this.Controls.Add(this.cerrandoLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucBoletageReceived";
            this.Size = new System.Drawing.Size(416, 580);
            this.Load += new System.EventHandler(this.ucBoletageReceived_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReservation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSolicitorName;
        private MyCTS.Forms.UI.SmartTextBox txtSolicitorName;
        private System.Windows.Forms.Label lblReceivedFrom;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblyieldRecord;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private System.Windows.Forms.ListBox lbPCC;
        private System.Windows.Forms.Label lblGroups;
        private MyCTS.Forms.UI.SmartTextBox txtGroups;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label cerrandoLabel;
        private GradProg.GradProg progressBar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBoxReservation;
        private System.Windows.Forms.PictureBox loadingPictureBox;

    }
}
