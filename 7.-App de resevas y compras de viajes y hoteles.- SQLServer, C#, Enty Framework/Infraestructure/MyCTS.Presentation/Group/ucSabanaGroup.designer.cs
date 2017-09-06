namespace MyCTS.Presentation
{
    partial class ucSabanaGroup
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
            this.lblChargePerService = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPNR = new MyCTS.Forms.UI.SmartTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblInfo = new System.Windows.Forms.Label();
            this.rdoPNR = new System.Windows.Forms.RadioButton();
            this.rdoGroup = new System.Windows.Forms.RadioButton();
            this.txtGroup = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lbIDGroup = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblChargePerService
            // 
            this.lblChargePerService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblChargePerService.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChargePerService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChargePerService.ForeColor = System.Drawing.Color.White;
            this.lblChargePerService.Location = new System.Drawing.Point(0, 0);
            this.lblChargePerService.Name = "lblChargePerService";
            this.lblChargePerService.Size = new System.Drawing.Size(411, 17);
            this.lblChargePerService.TabIndex = 90;
            this.lblChargePerService.Text = "Generar Sabana de Vuelo";
            this.lblChargePerService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "Ingrese el record maestro";
            // 
            // txtPNR
            // 
            this.txtPNR.AllowBlankSpaces = false;
            this.txtPNR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPNR.CharsIncluded = new char[] {
        '.'};
            this.txtPNR.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtPNR.CustomExpression = ".*";
            this.txtPNR.EnterColor = System.Drawing.Color.Empty;
            this.txtPNR.LeaveColor = System.Drawing.Color.Empty;
            this.txtPNR.Location = new System.Drawing.Point(20, 144);
            this.txtPNR.MaxLength = 6;
            this.txtPNR.Name = "txtPNR";
            this.txtPNR.Size = new System.Drawing.Size(79, 20);
            this.txtPNR.TabIndex = 4;
            this.txtPNR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // progressBar1
            // 
            this.progressBar1.AccessibleDescription = "";
            this.progressBar1.AccessibleName = "";
            this.progressBar1.BackColor = System.Drawing.Color.LightGray;
            this.progressBar1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.progressBar1.Location = new System.Drawing.Point(12, 270);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(386, 22);
            this.progressBar1.TabIndex = 93;
            this.progressBar1.Visible = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(21, 42);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(107, 13);
            this.lblInfo.TabIndex = 91;
            this.lblInfo.Text = "Generar Reporte por:";
            // 
            // rdoPNR
            // 
            this.rdoPNR.AutoSize = true;
            this.rdoPNR.Location = new System.Drawing.Point(84, 78);
            this.rdoPNR.Name = "rdoPNR";
            this.rdoPNR.Size = new System.Drawing.Size(101, 17);
            this.rdoPNR.TabIndex = 1;
            this.rdoPNR.TabStop = true;
            this.rdoPNR.Text = "Record Maestro";
            this.rdoPNR.UseVisualStyleBackColor = true;
            this.rdoPNR.CheckedChanged += new System.EventHandler(this.rdoPNR_CheckedChanged);
            this.rdoPNR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoGroup
            // 
            this.rdoGroup.AutoSize = true;
            this.rdoGroup.Location = new System.Drawing.Point(223, 78);
            this.rdoGroup.Name = "rdoGroup";
            this.rdoGroup.Size = new System.Drawing.Size(109, 17);
            this.rdoGroup.TabIndex = 2;
            this.rdoGroup.TabStop = true;
            this.rdoGroup.Text = "Nombre de Grupo";
            this.rdoGroup.UseVisualStyleBackColor = true;
            this.rdoGroup.CheckedChanged += new System.EventHandler(this.rdoGroup_CheckedChanged);
            this.rdoGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtGroup
            // 
            this.txtGroup.AllowBlankSpaces = true;
            this.txtGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGroup.CharsIncluded = new char[] {
        '.'};
            this.txtGroup.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtGroup.CustomExpression = ".*";
            this.txtGroup.EnterColor = System.Drawing.Color.Empty;
            this.txtGroup.LeaveColor = System.Drawing.Color.Empty;
            this.txtGroup.Location = new System.Drawing.Point(20, 144);
            this.txtGroup.MaxLength = 25;
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(275, 20);
            this.txtGroup.TabIndex = 3;
            this.txtGroup.TextChanged += new System.EventHandler(this.txtGroup_TextChanged);
            this.txtGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IDGroupActions_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(278, 204);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnSabana_Click);
            // 
            // lbIDGroup
            // 
            this.lbIDGroup.DisplayMember = "Text";
            this.lbIDGroup.FormattingEnabled = true;
            this.lbIDGroup.Location = new System.Drawing.Point(20, 163);
            this.lbIDGroup.Name = "lbIDGroup";
            this.lbIDGroup.Size = new System.Drawing.Size(275, 95);
            this.lbIDGroup.TabIndex = 94;
            this.lbIDGroup.Visible = false;
            this.lbIDGroup.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbIDGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbIDGroup_KeyDown);
            // 
            // ucSabanaGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbIDGroup);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.rdoGroup);
            this.Controls.Add(this.rdoPNR);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.txtPNR);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblChargePerService);
            this.Name = "ucSabanaGroup";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucSabanaGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblChargePerService;
        private System.Windows.Forms.Label label1;
        private MyCTS.Forms.UI.SmartTextBox txtPNR;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.RadioButton rdoPNR;
        private System.Windows.Forms.RadioButton rdoGroup;
        private MyCTS.Forms.UI.SmartTextBox txtGroup;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ListBox lbIDGroup;
    }
}
