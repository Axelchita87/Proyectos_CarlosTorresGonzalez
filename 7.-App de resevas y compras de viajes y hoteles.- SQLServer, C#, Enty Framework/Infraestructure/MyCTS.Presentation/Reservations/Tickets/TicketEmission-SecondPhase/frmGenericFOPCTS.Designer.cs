namespace MyCTS.Presentation
{
    partial class frmGenericFOPCTS
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
            this.btnShowCTS = new System.Windows.Forms.Button();
            this.lblCardTypeCTS = new System.Windows.Forms.Label();
            this.lblCardNumberCTS = new System.Windows.Forms.Label();
            this.txtNumberCardCTS = new MyCTS.Forms.UI.SmartTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.cmbTypeCard = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnShowCTS
            // 
            this.btnShowCTS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnShowCTS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowCTS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowCTS.Image = global::MyCTS.Presentation.Properties.Resources._1327964141_find;
            this.btnShowCTS.Location = new System.Drawing.Point(254, 49);
            this.btnShowCTS.Name = "btnShowCTS";
            this.btnShowCTS.Size = new System.Drawing.Size(23, 20);
            this.btnShowCTS.TabIndex = 104;
            this.btnShowCTS.UseVisualStyleBackColor = false;
            this.btnShowCTS.Click += new System.EventHandler(this.btnShowCTS_Click);
            // 
            // lblCardTypeCTS
            // 
            this.lblCardTypeCTS.AutoSize = true;
            this.lblCardTypeCTS.Location = new System.Drawing.Point(12, 25);
            this.lblCardTypeCTS.Name = "lblCardTypeCTS";
            this.lblCardTypeCTS.Size = new System.Drawing.Size(79, 13);
            this.lblCardTypeCTS.TabIndex = 101;
            this.lblCardTypeCTS.Text = "Tipo de Tarjeta";
            this.lblCardTypeCTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCardNumberCTS
            // 
            this.lblCardNumberCTS.AutoSize = true;
            this.lblCardNumberCTS.Location = new System.Drawing.Point(12, 52);
            this.lblCardNumberCTS.Name = "lblCardNumberCTS";
            this.lblCardNumberCTS.Size = new System.Drawing.Size(91, 13);
            this.lblCardNumberCTS.TabIndex = 100;
            this.lblCardNumberCTS.Text = "Número de tarjeta";
            this.lblCardNumberCTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNumberCardCTS
            // 
            this.txtNumberCardCTS.AllowBlankSpaces = false;
            this.txtNumberCardCTS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberCardCTS.CharsIncluded = new char[0];
            this.txtNumberCardCTS.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberCardCTS.CustomExpression = ".*";
            this.txtNumberCardCTS.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberCardCTS.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberCardCTS.Location = new System.Drawing.Point(131, 49);
            this.txtNumberCardCTS.MaxLength = 16;
            this.txtNumberCardCTS.Name = "txtNumberCardCTS";
            this.txtNumberCardCTS.Size = new System.Drawing.Size(117, 20);
            this.txtNumberCardCTS.TabIndex = 103;
            this.txtNumberCardCTS.Leave += new System.EventHandler(this.txtCardNumberCTS_Leave);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(247, 159);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 162;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(131, 159);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 161;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // cmbTypeCard
            // 
            this.cmbTypeCard.DisplayMember = "Text";
            this.cmbTypeCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeCard.FormattingEnabled = true;
            this.cmbTypeCard.Items.AddRange(new object[] {
            "- Selecciona Forma de Pago -"});
            this.cmbTypeCard.Location = new System.Drawing.Point(131, 22);
            this.cmbTypeCard.Name = "cmbTypeCard";
            this.cmbTypeCard.Size = new System.Drawing.Size(226, 21);
            this.cmbTypeCard.TabIndex = 163;
            this.cmbTypeCard.ValueMember = "Value";
            this.cmbTypeCard.SelectedIndexChanged += new System.EventHandler(this.cmbTypeCard_SelectedIndexChanged);
            this.cmbTypeCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTypeCard_KeyDown);
            // 
            // frmGenericFOPCTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 293);
            this.Controls.Add(this.cmbTypeCard);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnShowCTS);
            this.Controls.Add(this.lblCardTypeCTS);
            this.Controls.Add(this.lblCardNumberCTS);
            this.Controls.Add(this.txtNumberCardCTS);
            this.Name = "frmGenericFOPCTS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGenericFOPCTS";
            this.Load += new System.EventHandler(this.frmGenericFOPCTS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowCTS;
        private System.Windows.Forms.Label lblCardTypeCTS;
        private System.Windows.Forms.Label lblCardNumberCTS;
        private MyCTS.Forms.UI.SmartTextBox txtNumberCardCTS;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ComboBox cmbTypeCard;
    }
}
