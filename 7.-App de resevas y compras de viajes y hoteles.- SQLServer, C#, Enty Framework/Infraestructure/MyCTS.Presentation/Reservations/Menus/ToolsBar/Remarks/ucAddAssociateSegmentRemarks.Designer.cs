namespace MyCTS.Presentation
{
    partial class ucAddAssociateSegmentRemarks
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtLine4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLine3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLine2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLine1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment4 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblSeg = new System.Windows.Forms.Label();
            this.lbltext = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.rdoItinerary = new System.Windows.Forms.RadioButton();
            this.rdoAccounting = new System.Windows.Forms.RadioButton();
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
            this.lblTitle.Size = new System.Drawing.Size(411, 15);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Remarks Contables - Agregar";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtLine4
            // 
            this.txtLine4.AllowBlankSpaces = true;
            this.txtLine4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLine4.CharsIncluded = new char[] {
        ',',
        '.',
        '/',
        '*',
        '-'};
            this.txtLine4.CharsNoIncluded = new char[] {
        'Ñ'};
            this.txtLine4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtLine4.CustomExpression = ".*";
            this.txtLine4.EnterColor = System.Drawing.Color.Empty;
            this.txtLine4.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine4.Location = new System.Drawing.Point(72, 155);
            this.txtLine4.MaxLength = 200;
            this.txtLine4.Name = "txtLine4";
            this.txtLine4.Size = new System.Drawing.Size(317, 20);
            this.txtLine4.TabIndex = 8;
            this.txtLine4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtLine3
            // 
            this.txtLine3.AllowBlankSpaces = true;
            this.txtLine3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLine3.CharsIncluded = new char[] {
        ',',
        '.',
        '/',
        '*',
        '-'};
            this.txtLine3.CharsNoIncluded = new char[] {
        'Ñ'};
            this.txtLine3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtLine3.CustomExpression = ".*";
            this.txtLine3.EnterColor = System.Drawing.Color.Empty;
            this.txtLine3.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine3.Location = new System.Drawing.Point(72, 129);
            this.txtLine3.MaxLength = 200;
            this.txtLine3.Name = "txtLine3";
            this.txtLine3.Size = new System.Drawing.Size(317, 20);
            this.txtLine3.TabIndex = 6;
            this.txtLine3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtLine2
            // 
            this.txtLine2.AllowBlankSpaces = true;
            this.txtLine2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLine2.CharsIncluded = new char[] {
        ',',
        '.',
        '/',
        '*',
        '-'};
            this.txtLine2.CharsNoIncluded = new char[] {
        'Ñ'};
            this.txtLine2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtLine2.CustomExpression = ".*";
            this.txtLine2.EnterColor = System.Drawing.Color.Empty;
            this.txtLine2.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine2.Location = new System.Drawing.Point(72, 103);
            this.txtLine2.MaxLength = 200;
            this.txtLine2.Name = "txtLine2";
            this.txtLine2.Size = new System.Drawing.Size(317, 20);
            this.txtLine2.TabIndex = 4;
            this.txtLine2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtLine1
            // 
            this.txtLine1.AllowBlankSpaces = true;
            this.txtLine1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLine1.CharsIncluded = new char[] {
        ',',
        '.',
        '/',
        '*',
        '-'};
            this.txtLine1.CharsNoIncluded = new char[] {
        'Ñ'};
            this.txtLine1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtLine1.CustomExpression = ".*";
            this.txtLine1.EnterColor = System.Drawing.Color.Empty;
            this.txtLine1.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine1.Location = new System.Drawing.Point(72, 77);
            this.txtLine1.MaxLength = 200;
            this.txtLine1.Name = "txtLine1";
            this.txtLine1.Size = new System.Drawing.Size(317, 20);
            this.txtLine1.TabIndex = 2;
            this.txtLine1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegment1
            // 
            this.txtSegment1.AllowBlankSpaces = false;
            this.txtSegment1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment1.CharsIncluded = new char[0];
            this.txtSegment1.CharsNoIncluded = new char[0];
            this.txtSegment1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment1.CustomExpression = ".*";
            this.txtSegment1.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment1.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment1.Location = new System.Drawing.Point(24, 77);
            this.txtSegment1.MaxLength = 2;
            this.txtSegment1.Name = "txtSegment1";
            this.txtSegment1.Size = new System.Drawing.Size(33, 20);
            this.txtSegment1.TabIndex = 1;
            this.txtSegment1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegment2
            // 
            this.txtSegment2.AllowBlankSpaces = false;
            this.txtSegment2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment2.CharsIncluded = new char[0];
            this.txtSegment2.CharsNoIncluded = new char[0];
            this.txtSegment2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment2.CustomExpression = ".*";
            this.txtSegment2.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment2.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment2.Location = new System.Drawing.Point(24, 103);
            this.txtSegment2.MaxLength = 2;
            this.txtSegment2.Name = "txtSegment2";
            this.txtSegment2.Size = new System.Drawing.Size(33, 20);
            this.txtSegment2.TabIndex = 3;
            this.txtSegment2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegment3
            // 
            this.txtSegment3.AllowBlankSpaces = false;
            this.txtSegment3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment3.CharsIncluded = new char[0];
            this.txtSegment3.CharsNoIncluded = new char[0];
            this.txtSegment3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment3.CustomExpression = ".*";
            this.txtSegment3.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment3.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment3.Location = new System.Drawing.Point(24, 129);
            this.txtSegment3.MaxLength = 2;
            this.txtSegment3.Name = "txtSegment3";
            this.txtSegment3.Size = new System.Drawing.Size(33, 20);
            this.txtSegment3.TabIndex = 5;
            this.txtSegment3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegment4
            // 
            this.txtSegment4.AllowBlankSpaces = false;
            this.txtSegment4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment4.CharsIncluded = new char[0];
            this.txtSegment4.CharsNoIncluded = new char[0];
            this.txtSegment4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment4.CustomExpression = ".*";
            this.txtSegment4.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment4.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment4.Location = new System.Drawing.Point(24, 155);
            this.txtSegment4.MaxLength = 2;
            this.txtSegment4.Name = "txtSegment4";
            this.txtSegment4.Size = new System.Drawing.Size(33, 20);
            this.txtSegment4.TabIndex = 7;
            this.txtSegment4.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblSeg
            // 
            this.lblSeg.AutoSize = true;
            this.lblSeg.Location = new System.Drawing.Point(26, 58);
            this.lblSeg.Name = "lblSeg";
            this.lblSeg.Size = new System.Drawing.Size(26, 13);
            this.lblSeg.TabIndex = 9;
            this.lblSeg.Text = "Seg";
            // 
            // lbltext
            // 
            this.lbltext.AutoSize = true;
            this.lbltext.Location = new System.Drawing.Point(217, 57);
            this.lbltext.Name = "lbltext";
            this.lbltext.Size = new System.Drawing.Size(34, 13);
            this.lbltext.TabIndex = 10;
            this.lbltext.Text = "Texto";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(289, 269);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 11;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // rdoItinerary
            // 
            this.rdoItinerary.AutoSize = true;
            this.rdoItinerary.Location = new System.Drawing.Point(24, 224);
            this.rdoItinerary.Name = "rdoItinerary";
            this.rdoItinerary.Size = new System.Drawing.Size(125, 17);
            this.rdoItinerary.TabIndex = 9;
            this.rdoItinerary.TabStop = true;
            this.rdoItinerary.Text = "Remarks de Itinerario";
            this.rdoItinerary.UseVisualStyleBackColor = true;
            // 
            // rdoAccounting
            // 
            this.rdoAccounting.AutoSize = true;
            this.rdoAccounting.Location = new System.Drawing.Point(24, 257);
            this.rdoAccounting.Name = "rdoAccounting";
            this.rdoAccounting.Size = new System.Drawing.Size(117, 17);
            this.rdoAccounting.TabIndex = 10;
            this.rdoAccounting.TabStop = true;
            this.rdoAccounting.Text = "Remarks Contables";
            this.rdoAccounting.UseVisualStyleBackColor = true;
            // 
            // ucAddAssociateSegmentRemarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.rdoAccounting);
            this.Controls.Add(this.rdoItinerary);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lbltext);
            this.Controls.Add(this.lblSeg);
            this.Controls.Add(this.txtLine4);
            this.Controls.Add(this.txtLine3);
            this.Controls.Add(this.txtLine2);
            this.Controls.Add(this.txtSegment4);
            this.Controls.Add(this.txtSegment3);
            this.Controls.Add(this.txtSegment2);
            this.Controls.Add(this.txtSegment1);
            this.Controls.Add(this.txtLine1);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucAddAssociateSegmentRemarks";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucAddAssociateSegmentRemarks_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtLine4;
        private MyCTS.Forms.UI.SmartTextBox txtLine3;
        private MyCTS.Forms.UI.SmartTextBox txtLine2;
        private MyCTS.Forms.UI.SmartTextBox txtLine1;
        private MyCTS.Forms.UI.SmartTextBox txtSegment1;
        private MyCTS.Forms.UI.SmartTextBox txtSegment2;
        private MyCTS.Forms.UI.SmartTextBox txtSegment3;
        private MyCTS.Forms.UI.SmartTextBox txtSegment4;
        private System.Windows.Forms.Label lblSeg;
        private System.Windows.Forms.Label lbltext;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.RadioButton rdoItinerary;
        private System.Windows.Forms.RadioButton rdoAccounting;
    }
}
