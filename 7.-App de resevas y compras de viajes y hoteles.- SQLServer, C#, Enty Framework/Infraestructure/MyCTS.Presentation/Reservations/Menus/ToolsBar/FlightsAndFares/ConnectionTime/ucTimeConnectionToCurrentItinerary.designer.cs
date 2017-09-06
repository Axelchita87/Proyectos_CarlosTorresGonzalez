namespace MyCTS.Presentation
{
    partial class ucTimeConnectionToCurrentItinerary
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
            this.txtSegment1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRange1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRange2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRange3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRange4 = new MyCTS.Forms.UI.SmartTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSegment = new System.Windows.Forms.Label();
            this.lblRange = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
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
            this.lblTitle.TabIndex = 16;
            this.lblTitle.Text = "Tiempo de Conexión - Para Itinerario Actual";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.txtSegment1.Location = new System.Drawing.Point(79, 75);
            this.txtSegment1.MaxLength = 2;
            this.txtSegment1.Name = "txtSegment1";
            this.txtSegment1.Size = new System.Drawing.Size(34, 20);
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
            this.txtSegment2.Location = new System.Drawing.Point(79, 101);
            this.txtSegment2.MaxLength = 2;
            this.txtSegment2.Name = "txtSegment2";
            this.txtSegment2.Size = new System.Drawing.Size(34, 20);
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
            this.txtSegment3.Location = new System.Drawing.Point(79, 127);
            this.txtSegment3.MaxLength = 2;
            this.txtSegment3.Name = "txtSegment3";
            this.txtSegment3.Size = new System.Drawing.Size(34, 20);
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
            this.txtSegment4.Location = new System.Drawing.Point(79, 153);
            this.txtSegment4.MaxLength = 2;
            this.txtSegment4.Name = "txtSegment4";
            this.txtSegment4.Size = new System.Drawing.Size(34, 20);
            this.txtSegment4.TabIndex = 7;
            this.txtSegment4.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRange1
            // 
            this.txtRange1.AllowBlankSpaces = false;
            this.txtRange1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange1.CharsIncluded = new char[0];
            this.txtRange1.CharsNoIncluded = new char[0];
            this.txtRange1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRange1.CustomExpression = ".*";
            this.txtRange1.EnterColor = System.Drawing.Color.Empty;
            this.txtRange1.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange1.Location = new System.Drawing.Point(147, 75);
            this.txtRange1.MaxLength = 2;
            this.txtRange1.Name = "txtRange1";
            this.txtRange1.Size = new System.Drawing.Size(34, 20);
            this.txtRange1.TabIndex = 2;
            this.txtRange1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRange1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRange2
            // 
            this.txtRange2.AllowBlankSpaces = false;
            this.txtRange2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange2.CharsIncluded = new char[0];
            this.txtRange2.CharsNoIncluded = new char[0];
            this.txtRange2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRange2.CustomExpression = ".*";
            this.txtRange2.EnterColor = System.Drawing.Color.Empty;
            this.txtRange2.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange2.Location = new System.Drawing.Point(147, 101);
            this.txtRange2.MaxLength = 2;
            this.txtRange2.Name = "txtRange2";
            this.txtRange2.Size = new System.Drawing.Size(34, 20);
            this.txtRange2.TabIndex = 4;
            this.txtRange2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRange2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRange3
            // 
            this.txtRange3.AllowBlankSpaces = false;
            this.txtRange3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange3.CharsIncluded = new char[0];
            this.txtRange3.CharsNoIncluded = new char[0];
            this.txtRange3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRange3.CustomExpression = ".*";
            this.txtRange3.EnterColor = System.Drawing.Color.Empty;
            this.txtRange3.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange3.Location = new System.Drawing.Point(147, 127);
            this.txtRange3.MaxLength = 2;
            this.txtRange3.Name = "txtRange3";
            this.txtRange3.Size = new System.Drawing.Size(34, 20);
            this.txtRange3.TabIndex = 6;
            this.txtRange3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRange3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRange4
            // 
            this.txtRange4.AllowBlankSpaces = false;
            this.txtRange4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange4.CharsIncluded = new char[0];
            this.txtRange4.CharsNoIncluded = new char[0];
            this.txtRange4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRange4.CustomExpression = ".*";
            this.txtRange4.EnterColor = System.Drawing.Color.Empty;
            this.txtRange4.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange4.Location = new System.Drawing.Point(147, 153);
            this.txtRange4.MaxLength = 2;
            this.txtRange4.Name = "txtRange4";
            this.txtRange4.Size = new System.Drawing.Size(34, 20);
            this.txtRange4.TabIndex = 8;
            this.txtRange4.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRange4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(124, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "_";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(124, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "_";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(124, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "_";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(124, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "_";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(119, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 12;
            // 
            // lblSegment
            // 
            this.lblSegment.AutoSize = true;
            this.lblSegment.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblSegment.Location = new System.Drawing.Point(69, 55);
            this.lblSegment.Name = "lblSegment";
            this.lblSegment.Size = new System.Drawing.Size(55, 13);
            this.lblSegment.TabIndex = 14;
            this.lblSegment.Text = "Segmento";
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblRange.Location = new System.Drawing.Point(144, 55);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(39, 13);
            this.lblRange.TabIndex = 15;
            this.lblRange.Text = "Rango";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(266, 228);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 9;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucTimeConnectionToCurrentItinerary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblRange);
            this.Controls.Add(this.lblSegment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSegment4);
            this.Controls.Add(this.txtSegment3);
            this.Controls.Add(this.txtSegment2);
            this.Controls.Add(this.txtRange4);
            this.Controls.Add(this.txtRange3);
            this.Controls.Add(this.txtRange2);
            this.Controls.Add(this.txtRange1);
            this.Controls.Add(this.txtSegment1);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucTimeConnectionToCurrentItinerary";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucTimeConnectionToCurrentItinerary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtSegment1;
        private MyCTS.Forms.UI.SmartTextBox txtSegment2;
        private MyCTS.Forms.UI.SmartTextBox txtSegment3;
        private MyCTS.Forms.UI.SmartTextBox txtSegment4;
        private MyCTS.Forms.UI.SmartTextBox txtRange1;
        private MyCTS.Forms.UI.SmartTextBox txtRange2;
        private MyCTS.Forms.UI.SmartTextBox txtRange3;
        private MyCTS.Forms.UI.SmartTextBox txtRange4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSegment;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.Button btnAccept;
    }
}
