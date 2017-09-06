namespace MyCTS.Presentation
{
    partial class frmFormOfPaypemt
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormOfPaypemt));
            this.rdoAmericanExpress = new System.Windows.Forms.RadioButton();
            this.rdoCash = new System.Windows.Forms.RadioButton();
            this.rdoCreditCard = new System.Windows.Forms.RadioButton();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblCardType = new System.Windows.Forms.Label();
            this.lblNumberCard = new System.Windows.Forms.Label();
            this.lblDateExpired = new System.Windows.Forms.Label();
            this.txtTypeCard = new MyCTS.Forms.UI.SmartTextBox();
            this.txtNumberCard = new MyCTS.Forms.UI.SmartTextBox();
            this.txtMonth = new MyCTS.Forms.UI.SmartTextBox();
            this.txtYear = new MyCTS.Forms.UI.SmartTextBox();
            this.lblSlash = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbTypeCard = new System.Windows.Forms.ListBox();
            this.lbSystem = new System.Windows.Forms.ListBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdoAmericanExpress
            // 
            this.rdoAmericanExpress.AutoSize = true;
            this.rdoAmericanExpress.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rdoAmericanExpress.Location = new System.Drawing.Point(49, 44);
            this.rdoAmericanExpress.Name = "rdoAmericanExpress";
            this.rdoAmericanExpress.Size = new System.Drawing.Size(179, 17);
            this.rdoAmericanExpress.TabIndex = 144;
            this.rdoAmericanExpress.TabStop = true;
            this.rdoAmericanExpress.Text = "Tarjeta de crédito (Aut. Sistema).";
            this.rdoAmericanExpress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoAmericanExpress.UseVisualStyleBackColor = true;
            this.rdoAmericanExpress.CheckedChanged += new System.EventHandler(this.rdoAmericanExpress_CheckedChanged);
            this.rdoAmericanExpress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoCash
            // 
            this.rdoCash.AutoSize = true;
            this.rdoCash.Location = new System.Drawing.Point(49, 94);
            this.rdoCash.Name = "rdoCash";
            this.rdoCash.Size = new System.Drawing.Size(67, 17);
            this.rdoCash.TabIndex = 146;
            this.rdoCash.TabStop = true;
            this.rdoCash.Text = "Efectivo.";
            this.rdoCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoCash.UseVisualStyleBackColor = true;
            this.rdoCash.ClientSizeChanged += new System.EventHandler(this.rdoAmericanExpress_CheckedChanged);
            this.rdoCash.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoCreditCard
            // 
            this.rdoCreditCard.AutoSize = true;
            this.rdoCreditCard.Location = new System.Drawing.Point(49, 69);
            this.rdoCreditCard.Name = "rdoCreditCard";
            this.rdoCreditCard.Size = new System.Drawing.Size(177, 17);
            this.rdoCreditCard.TabIndex = 145;
            this.rdoCreditCard.TabStop = true;
            this.rdoCreditCard.Text = "Tarjeta de crédito (Aut. Manual).";
            this.rdoCreditCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoCreditCard.UseVisualStyleBackColor = true;
            this.rdoCreditCard.CheckedChanged += new System.EventHandler(this.rdoAmericanExpress_CheckedChanged);
            this.rdoCreditCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 18);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(142, 13);
            this.lblInfo.TabIndex = 149;
            this.lblInfo.Text = "Selecciona la forma de pago";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(127, 198);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(27, 13);
            this.lblMonth.TabIndex = 153;
            this.lblMonth.Text = "Mes";
            this.lblMonth.Visible = false;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(185, 198);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(26, 13);
            this.lblYear.TabIndex = 154;
            this.lblYear.Text = "Año";
            this.lblYear.Visible = false;
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.Location = new System.Drawing.Point(11, 126);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(79, 13);
            this.lblCardType.TabIndex = 152;
            this.lblCardType.Text = "Tipo de Tarjeta";
            this.lblCardType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCardType.Visible = false;
            // 
            // lblNumberCard
            // 
            this.lblNumberCard.AutoSize = true;
            this.lblNumberCard.Location = new System.Drawing.Point(11, 153);
            this.lblNumberCard.Name = "lblNumberCard";
            this.lblNumberCard.Size = new System.Drawing.Size(91, 13);
            this.lblNumberCard.TabIndex = 150;
            this.lblNumberCard.Text = "Número de tarjeta";
            this.lblNumberCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNumberCard.Visible = false;
            // 
            // lblDateExpired
            // 
            this.lblDateExpired.AutoSize = true;
            this.lblDateExpired.Location = new System.Drawing.Point(11, 182);
            this.lblDateExpired.Name = "lblDateExpired";
            this.lblDateExpired.Size = new System.Drawing.Size(97, 13);
            this.lblDateExpired.TabIndex = 151;
            this.lblDateExpired.Text = "Fecha vencimiento";
            this.lblDateExpired.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDateExpired.Visible = false;
            // 
            // txtTypeCard
            // 
            this.txtTypeCard.AllowBlankSpaces = true;
            this.txtTypeCard.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTypeCard.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtTypeCard.CustomExpression = ".*";
            this.txtTypeCard.EnterColor = System.Drawing.Color.Empty;
            this.txtTypeCard.LeaveColor = System.Drawing.Color.Empty;
            this.txtTypeCard.Location = new System.Drawing.Point(130, 123);
            this.txtTypeCard.Name = "txtTypeCard";
            this.txtTypeCard.Size = new System.Drawing.Size(224, 20);
            this.txtTypeCard.TabIndex = 155;
            this.txtTypeCard.Visible = false;
            this.txtTypeCard.TextChanged += new System.EventHandler(this.txtTypeCard_TextChanged);
            this.txtTypeCard.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtTypeCard_PreviewKeyDown);
            this.txtTypeCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTypeCard_KeyDown);
            // 
            // txtNumberCard
            // 
            this.txtNumberCard.AllowBlankSpaces = false;
            this.txtNumberCard.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberCard.CharsIncluded = new char[0];
            this.txtNumberCard.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberCard.CustomExpression = ".*";
            this.txtNumberCard.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberCard.Font = new System.Drawing.Font("Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.txtNumberCard.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberCard.Location = new System.Drawing.Point(130, 150);
            this.txtNumberCard.MaxLength = 16;
            this.txtNumberCard.Name = "txtNumberCard";
            this.txtNumberCard.PasswordChar = '·';
            this.txtNumberCard.Size = new System.Drawing.Size(117, 22);
            this.txtNumberCard.TabIndex = 156;
            this.txtNumberCard.Visible = false;
            this.txtNumberCard.TextChanged += new System.EventHandler(this.txtYear_TextChanged);
            this.txtNumberCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtNumberCard.Leave += new System.EventHandler(this.txtNumberCard_Leave);
            // 
            // txtMonth
            // 
            this.txtMonth.AllowBlankSpaces = true;
            this.txtMonth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMonth.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtMonth.CustomExpression = ".*";
            this.txtMonth.EnterColor = System.Drawing.Color.Empty;
            this.txtMonth.LeaveColor = System.Drawing.Color.Empty;
            this.txtMonth.Location = new System.Drawing.Point(130, 175);
            this.txtMonth.MaxLength = 2;
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(31, 20);
            this.txtMonth.TabIndex = 157;
            this.txtMonth.Visible = false;
            this.txtMonth.TextChanged += new System.EventHandler(this.txtYear_TextChanged);
            this.txtMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtYear
            // 
            this.txtYear.AllowBlankSpaces = true;
            this.txtYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtYear.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtYear.CustomExpression = ".*";
            this.txtYear.EnterColor = System.Drawing.Color.Empty;
            this.txtYear.LeaveColor = System.Drawing.Color.Empty;
            this.txtYear.Location = new System.Drawing.Point(185, 175);
            this.txtYear.MaxLength = 2;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(29, 20);
            this.txtYear.TabIndex = 158;
            this.txtYear.Visible = false;
            this.txtYear.TextChanged += new System.EventHandler(this.txtYear_TextChanged);
            this.txtYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblSlash
            // 
            this.lblSlash.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSlash.AutoSize = true;
            this.lblSlash.Location = new System.Drawing.Point(167, 178);
            this.lblSlash.Name = "lblSlash";
            this.lblSlash.Size = new System.Drawing.Size(12, 13);
            this.lblSlash.TabIndex = 159;
            this.lblSlash.Text = "/";
            this.lblSlash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSlash.Visible = false;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(128, 257);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 159;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(244, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 160;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbTypeCard
            // 
            this.lbTypeCard.DisplayMember = "Text";
            this.lbTypeCard.FormattingEnabled = true;
            this.lbTypeCard.Location = new System.Drawing.Point(130, 139);
            this.lbTypeCard.Name = "lbTypeCard";
            this.lbTypeCard.Size = new System.Drawing.Size(224, 95);
            this.lbTypeCard.TabIndex = 161;
            this.lbTypeCard.ValueMember = "Value";
            this.lbTypeCard.Visible = false;
            this.lbTypeCard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbTypeCard_MouseClick);
            this.lbTypeCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbTypeCard_KeyDown);
            // 
            // lbSystem
            // 
            this.lbSystem.FormattingEnabled = true;
            this.lbSystem.Items.AddRange(new object[] {
            "AX AMERICAN EXPRESS",
            "TP UATP- AIR TRAVEL CARD",
            "CH CHEQUE",
            "TR TRANSFERENCIA"});
            this.lbSystem.Location = new System.Drawing.Point(130, 139);
            this.lbSystem.Name = "lbSystem";
            this.lbSystem.Size = new System.Drawing.Size(224, 95);
            this.lbSystem.TabIndex = 162;
            this.lbSystem.Visible = false;
            this.lbSystem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSystem_MouseClick);
            this.lbSystem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbSystem_KeyDown);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Image = global::MyCTS.Presentation.Properties.Resources._1327964141_find;
            this.btnShow.Location = new System.Drawing.Point(253, 150);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(23, 20);
            this.btnShow.TabIndex = 163;
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // frmFormOfPaypemt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(369, 293);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblCardType);
            this.Controls.Add(this.lblNumberCard);
            this.Controls.Add(this.lblDateExpired);
            this.Controls.Add(this.txtTypeCard);
            this.Controls.Add(this.txtNumberCard);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblSlash);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.rdoAmericanExpress);
            this.Controls.Add(this.rdoCash);
            this.Controls.Add(this.rdoCreditCard);
            this.Controls.Add(this.lbSystem);
            this.Controls.Add(this.lbTypeCard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFormOfPaypemt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyCTS-Forma de Pago para Cargo por Servicio";
            this.Load += new System.EventHandler(this.frmFormOfPaypemt_Load);
            this.Shown += new System.EventHandler(this.frmFormOfPaypemt_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoAmericanExpress;
        private System.Windows.Forms.RadioButton rdoCash;
        private System.Windows.Forms.RadioButton rdoCreditCard;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.Label lblNumberCard;
        private System.Windows.Forms.Label lblDateExpired;
        private MyCTS.Forms.UI.SmartTextBox txtTypeCard;
        private MyCTS.Forms.UI.SmartTextBox txtNumberCard;
        private MyCTS.Forms.UI.SmartTextBox txtMonth;
        private MyCTS.Forms.UI.SmartTextBox txtYear;
        private System.Windows.Forms.Label lblSlash;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lbTypeCard;
        private System.Windows.Forms.ListBox lbSystem;
        private System.Windows.Forms.Button btnShow;
    }
}
