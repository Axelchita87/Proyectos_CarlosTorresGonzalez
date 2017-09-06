namespace MyCTS.Presentation
{
    partial class ucChangeClassService
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
            this.txtRange4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtClass4 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblIndent4 = new System.Windows.Forms.Label();
            this.txtSegment4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRange3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRange2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRange1 = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtClass3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtClass2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtClass1 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblIndent3 = new System.Windows.Forms.Label();
            this.txtSegment3 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblIndent2 = new System.Windows.Forms.Label();
            this.txtSegment2 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblIndent1 = new System.Windows.Forms.Label();
            this.txtSegment1 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblRange = new System.Windows.Forms.Label();
            this.lblSegment = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRange4
            // 
            this.txtRange4.AllowBlankSpaces = false;
            this.txtRange4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange4.CharsIncluded = new char[0];
            this.txtRange4.CharsNoIncluded = new char[0];
            this.txtRange4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRange4.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtRange4.EnterColor = System.Drawing.Color.Empty;
            this.txtRange4.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange4.Location = new System.Drawing.Point(112, 180);
            this.txtRange4.MaxLength = 2;
            this.txtRange4.Name = "txtRange4";
            this.txtRange4.Size = new System.Drawing.Size(25, 20);
            this.txtRange4.TabIndex = 11;
            this.txtRange4.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRange4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtClass4
            // 
            this.txtClass4.AllowBlankSpaces = false;
            this.txtClass4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClass4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtClass4.CustomExpression = ".*";
            this.txtClass4.EnterColor = System.Drawing.Color.Empty;
            this.txtClass4.LeaveColor = System.Drawing.Color.Empty;
            this.txtClass4.Location = new System.Drawing.Point(181, 180);
            this.txtClass4.MaxLength = 1;
            this.txtClass4.Name = "txtClass4";
            this.txtClass4.Size = new System.Drawing.Size(25, 20);
            this.txtClass4.TabIndex = 12;
            this.txtClass4.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtClass4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblIndent4
            // 
            this.lblIndent4.AutoSize = true;
            this.lblIndent4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent4.ForeColor = System.Drawing.Color.Black;
            this.lblIndent4.Location = new System.Drawing.Point(87, 178);
            this.lblIndent4.Name = "lblIndent4";
            this.lblIndent4.Size = new System.Drawing.Size(14, 20);
            this.lblIndent4.TabIndex = 0;
            this.lblIndent4.Text = "-";
            // 
            // txtSegment4
            // 
            this.txtSegment4.AllowBlankSpaces = false;
            this.txtSegment4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment4.CharsIncluded = new char[0];
            this.txtSegment4.CharsNoIncluded = new char[0];
            this.txtSegment4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment4.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtSegment4.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment4.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment4.Location = new System.Drawing.Point(49, 180);
            this.txtSegment4.MaxLength = 2;
            this.txtSegment4.Name = "txtSegment4";
            this.txtSegment4.Size = new System.Drawing.Size(25, 20);
            this.txtSegment4.TabIndex = 10;
            this.txtSegment4.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRange3
            // 
            this.txtRange3.AllowBlankSpaces = false;
            this.txtRange3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange3.CharsIncluded = new char[0];
            this.txtRange3.CharsNoIncluded = new char[0];
            this.txtRange3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRange3.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtRange3.EnterColor = System.Drawing.Color.Empty;
            this.txtRange3.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange3.Location = new System.Drawing.Point(112, 152);
            this.txtRange3.MaxLength = 2;
            this.txtRange3.Name = "txtRange3";
            this.txtRange3.Size = new System.Drawing.Size(25, 20);
            this.txtRange3.TabIndex = 8;
            this.txtRange3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRange3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRange2
            // 
            this.txtRange2.AllowBlankSpaces = false;
            this.txtRange2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange2.CharsIncluded = new char[0];
            this.txtRange2.CharsNoIncluded = new char[0];
            this.txtRange2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRange2.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtRange2.EnterColor = System.Drawing.Color.Empty;
            this.txtRange2.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange2.Location = new System.Drawing.Point(112, 121);
            this.txtRange2.MaxLength = 2;
            this.txtRange2.Name = "txtRange2";
            this.txtRange2.Size = new System.Drawing.Size(25, 20);
            this.txtRange2.TabIndex = 5;
            this.txtRange2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRange2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRange1
            // 
            this.txtRange1.AllowBlankSpaces = false;
            this.txtRange1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange1.CharsIncluded = new char[0];
            this.txtRange1.CharsNoIncluded = new char[0];
            this.txtRange1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRange1.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtRange1.EnterColor = System.Drawing.Color.Empty;
            this.txtRange1.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange1.Location = new System.Drawing.Point(112, 90);
            this.txtRange1.MaxLength = 2;
            this.txtRange1.Name = "txtRange1";
            this.txtRange1.Size = new System.Drawing.Size(25, 20);
            this.txtRange1.TabIndex = 2;
            this.txtRange1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRange1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(268, 215);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 13;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtClass3
            // 
            this.txtClass3.AllowBlankSpaces = false;
            this.txtClass3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClass3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtClass3.CustomExpression = ".*";
            this.txtClass3.EnterColor = System.Drawing.Color.Empty;
            this.txtClass3.LeaveColor = System.Drawing.Color.Empty;
            this.txtClass3.Location = new System.Drawing.Point(181, 152);
            this.txtClass3.MaxLength = 1;
            this.txtClass3.Name = "txtClass3";
            this.txtClass3.Size = new System.Drawing.Size(25, 20);
            this.txtClass3.TabIndex = 9;
            this.txtClass3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtClass3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtClass2
            // 
            this.txtClass2.AllowBlankSpaces = false;
            this.txtClass2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClass2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtClass2.CustomExpression = ".*";
            this.txtClass2.EnterColor = System.Drawing.Color.Empty;
            this.txtClass2.LeaveColor = System.Drawing.Color.Empty;
            this.txtClass2.Location = new System.Drawing.Point(181, 121);
            this.txtClass2.MaxLength = 1;
            this.txtClass2.Name = "txtClass2";
            this.txtClass2.Size = new System.Drawing.Size(25, 20);
            this.txtClass2.TabIndex = 6;
            this.txtClass2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtClass2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtClass1
            // 
            this.txtClass1.AllowBlankSpaces = false;
            this.txtClass1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClass1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtClass1.CustomExpression = ".*";
            this.txtClass1.EnterColor = System.Drawing.Color.Empty;
            this.txtClass1.LeaveColor = System.Drawing.Color.Empty;
            this.txtClass1.Location = new System.Drawing.Point(181, 90);
            this.txtClass1.MaxLength = 1;
            this.txtClass1.Name = "txtClass1";
            this.txtClass1.Size = new System.Drawing.Size(25, 20);
            this.txtClass1.TabIndex = 3;
            this.txtClass1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtClass1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblClass.Location = new System.Drawing.Point(176, 64);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(36, 13);
            this.lblClass.TabIndex = 0;
            this.lblClass.Text = "Clase ";
            // 
            // lblIndent3
            // 
            this.lblIndent3.AutoSize = true;
            this.lblIndent3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent3.ForeColor = System.Drawing.Color.Black;
            this.lblIndent3.Location = new System.Drawing.Point(87, 150);
            this.lblIndent3.Name = "lblIndent3";
            this.lblIndent3.Size = new System.Drawing.Size(14, 20);
            this.lblIndent3.TabIndex = 0;
            this.lblIndent3.Text = "-";
            // 
            // txtSegment3
            // 
            this.txtSegment3.AllowBlankSpaces = false;
            this.txtSegment3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment3.CharsIncluded = new char[0];
            this.txtSegment3.CharsNoIncluded = new char[0];
            this.txtSegment3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment3.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtSegment3.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment3.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment3.Location = new System.Drawing.Point(49, 152);
            this.txtSegment3.MaxLength = 2;
            this.txtSegment3.Name = "txtSegment3";
            this.txtSegment3.Size = new System.Drawing.Size(25, 20);
            this.txtSegment3.TabIndex = 7;
            this.txtSegment3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblIndent2
            // 
            this.lblIndent2.AutoSize = true;
            this.lblIndent2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent2.ForeColor = System.Drawing.Color.Black;
            this.lblIndent2.Location = new System.Drawing.Point(87, 119);
            this.lblIndent2.Name = "lblIndent2";
            this.lblIndent2.Size = new System.Drawing.Size(14, 20);
            this.lblIndent2.TabIndex = 0;
            this.lblIndent2.Text = "-";
            // 
            // txtSegment2
            // 
            this.txtSegment2.AllowBlankSpaces = false;
            this.txtSegment2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment2.CharsIncluded = new char[0];
            this.txtSegment2.CharsNoIncluded = new char[0];
            this.txtSegment2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment2.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtSegment2.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment2.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment2.Location = new System.Drawing.Point(49, 121);
            this.txtSegment2.MaxLength = 2;
            this.txtSegment2.Name = "txtSegment2";
            this.txtSegment2.Size = new System.Drawing.Size(25, 20);
            this.txtSegment2.TabIndex = 4;
            this.txtSegment2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblIndent1
            // 
            this.lblIndent1.AutoSize = true;
            this.lblIndent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent1.ForeColor = System.Drawing.Color.Black;
            this.lblIndent1.Location = new System.Drawing.Point(87, 88);
            this.lblIndent1.Name = "lblIndent1";
            this.lblIndent1.Size = new System.Drawing.Size(14, 20);
            this.lblIndent1.TabIndex = 0;
            this.lblIndent1.Text = "-";
            // 
            // txtSegment1
            // 
            this.txtSegment1.AllowBlankSpaces = false;
            this.txtSegment1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment1.CharsIncluded = new char[0];
            this.txtSegment1.CharsNoIncluded = new char[0];
            this.txtSegment1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment1.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtSegment1.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment1.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment1.Location = new System.Drawing.Point(49, 90);
            this.txtSegment1.MaxLength = 2;
            this.txtSegment1.Name = "txtSegment1";
            this.txtSegment1.Size = new System.Drawing.Size(25, 20);
            this.txtSegment1.TabIndex = 1;
            this.txtSegment1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblRange.Location = new System.Drawing.Point(109, 64);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(39, 13);
            this.lblRange.TabIndex = 0;
            this.lblRange.Text = "Rango";
            // 
            // lblSegment
            // 
            this.lblSegment.AutoSize = true;
            this.lblSegment.ForeColor = System.Drawing.Color.Black;
            this.lblSegment.Location = new System.Drawing.Point(34, 64);
            this.lblSegment.Name = "lblSegment";
            this.lblSegment.Size = new System.Drawing.Size(55, 13);
            this.lblSegment.TabIndex = 0;
            this.lblSegment.Text = "Segmento";
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
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cambia Clase de Servicio";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ucChangeClassService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtRange4);
            this.Controls.Add(this.txtClass4);
            this.Controls.Add(this.lblIndent4);
            this.Controls.Add(this.txtSegment4);
            this.Controls.Add(this.txtRange3);
            this.Controls.Add(this.txtRange2);
            this.Controls.Add(this.txtRange1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtClass3);
            this.Controls.Add(this.txtClass2);
            this.Controls.Add(this.txtClass1);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.lblIndent3);
            this.Controls.Add(this.txtSegment3);
            this.Controls.Add(this.lblIndent2);
            this.Controls.Add(this.txtSegment2);
            this.Controls.Add(this.lblIndent1);
            this.Controls.Add(this.txtSegment1);
            this.Controls.Add(this.lblRange);
            this.Controls.Add(this.lblSegment);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucChangeClassService";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucChangeSegmentStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyCTS.Forms.UI.SmartTextBox txtRange4;
        private MyCTS.Forms.UI.SmartTextBox txtClass4;
        private System.Windows.Forms.Label lblIndent4;
        private MyCTS.Forms.UI.SmartTextBox txtSegment4;
        private MyCTS.Forms.UI.SmartTextBox txtRange3;
        private MyCTS.Forms.UI.SmartTextBox txtRange2;
        private MyCTS.Forms.UI.SmartTextBox txtRange1;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtClass3;
        private MyCTS.Forms.UI.SmartTextBox txtClass2;
        private MyCTS.Forms.UI.SmartTextBox txtClass1;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblIndent3;
        private MyCTS.Forms.UI.SmartTextBox txtSegment3;
        private System.Windows.Forms.Label lblIndent2;
        private MyCTS.Forms.UI.SmartTextBox txtSegment2;
        private System.Windows.Forms.Label lblIndent1;
        private MyCTS.Forms.UI.SmartTextBox txtSegment1;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.Label lblSegment;
        internal System.Windows.Forms.Label lblTitle;
    }
}
