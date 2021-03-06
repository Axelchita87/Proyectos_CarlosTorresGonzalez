﻿namespace MyCTS.Presentation
{
    partial class ucProductivityPCC
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
            this.rdoMonth = new System.Windows.Forms.RadioButton();
            this.rdoWeek = new System.Windows.Forms.RadioButton();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbWeek = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.progressBar1 = new GradProg.GradProg();
            this.lblLoader = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtAgent = new MyCTS.Forms.UI.SmartTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // rdoMonth
            // 
            this.rdoMonth.AutoSize = true;
            this.rdoMonth.Location = new System.Drawing.Point(239, 68);
            this.rdoMonth.Name = "rdoMonth";
            this.rdoMonth.Size = new System.Drawing.Size(65, 17);
            this.rdoMonth.TabIndex = 2;
            this.rdoMonth.TabStop = true;
            this.rdoMonth.Text = "Mensual";
            this.rdoMonth.UseVisualStyleBackColor = true;
            this.rdoMonth.CheckedChanged += new System.EventHandler(this.rdoMonth_CheckedChanged);
            this.rdoMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoWeek
            // 
            this.rdoWeek.AutoSize = true;
            this.rdoWeek.Location = new System.Drawing.Point(6, 68);
            this.rdoWeek.Name = "rdoWeek";
            this.rdoWeek.Size = new System.Drawing.Size(66, 17);
            this.rdoWeek.TabIndex = 1;
            this.rdoWeek.TabStop = true;
            this.rdoWeek.Text = "Semanal";
            this.rdoWeek.UseVisualStyleBackColor = true;
            this.rdoWeek.CheckedChanged += new System.EventHandler(this.rdoWeek_CheckedChanged);
            this.rdoWeek.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(276, 231);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Elige la forma en quieres tu reporte:";
            // 
            // cmbMonth
            // 
            this.cmbMonth.DisplayMember = "Text";
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            ""});
            this.cmbMonth.Location = new System.Drawing.Point(239, 91);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(153, 21);
            this.cmbMonth.TabIndex = 4;
            this.cmbMonth.ValueMember = "Value";
            this.cmbMonth.Visible = false;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            this.cmbMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbWeek
            // 
            this.cmbWeek.DisplayMember = "Text";
            this.cmbWeek.FormattingEnabled = true;
            this.cmbWeek.Items.AddRange(new object[] {
            ""});
            this.cmbWeek.Location = new System.Drawing.Point(4, 91);
            this.cmbWeek.Name = "cmbWeek";
            this.cmbWeek.Size = new System.Drawing.Size(222, 21);
            this.cmbWeek.TabIndex = 3;
            this.cmbWeek.ValueMember = "Value";
            this.cmbWeek.Visible = false;
            this.cmbWeek.SelectedIndexChanged += new System.EventHandler(this.cmbWeek_SelectedIndexChanged);
            this.cmbWeek.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Reporte de Productividad por PCC";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.GradientStyle = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.progressBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.progressBar1.LabelBackColour = System.Drawing.Color.DimGray;
            this.progressBar1.LabelForeColour = System.Drawing.Color.LightSeaGreen;
            this.progressBar1.LabelPosition = new System.Drawing.Point(0, 0);
            this.progressBar1.Location = new System.Drawing.Point(12, 140);
            this.progressBar1.Maximum = 100;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Percentage = 0;
            this.progressBar1.ProgressBarBackColour = System.Drawing.Color.White;
            this.progressBar1.ProgressBarForeColour = System.Drawing.Color.SteelBlue;
            this.progressBar1.ShowLabel = false;
            this.progressBar1.Size = new System.Drawing.Size(372, 26);
            this.progressBar1.TabIndex = 34;
            this.progressBar1.Value = 0;
            this.progressBar1.Visible = false;
            // 
            // lblLoader
            // 
            this.lblLoader.AutoSize = true;
            this.lblLoader.Location = new System.Drawing.Point(14, 172);
            this.lblLoader.Name = "lblLoader";
            this.lblLoader.Size = new System.Drawing.Size(257, 13);
            this.lblLoader.TabIndex = 33;
            this.lblLoader.Text = "Por favor espere mientras se carga la información . . .";
            this.lblLoader.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Agente";
            this.label2.Visible = false;
            // 
            // txtAgent
            // 
            this.txtAgent.AllowBlankSpaces = true;
            this.txtAgent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAgent.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtAgent.CustomExpression = ".*";
            this.txtAgent.EnterColor = System.Drawing.Color.Empty;
            this.txtAgent.LeaveColor = System.Drawing.Color.Empty;
            this.txtAgent.Location = new System.Drawing.Point(58, 114);
            this.txtAgent.Name = "txtAgent";
            this.txtAgent.Size = new System.Drawing.Size(100, 20);
            this.txtAgent.TabIndex = 35;
            this.txtAgent.Visible = false;
            // 
            // ucProductivityPCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAgent);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblLoader);
            this.Controls.Add(this.rdoMonth);
            this.Controls.Add(this.rdoWeek);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.cmbWeek);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucProductivityPCC";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucProductivityPCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoMonth;
        private System.Windows.Forms.RadioButton rdoWeek;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbWeek;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private GradProg.GradProg progressBar1;
        private System.Windows.Forms.Label lblLoader;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private MyCTS.Forms.UI.SmartTextBox txtAgent;
    }
}
