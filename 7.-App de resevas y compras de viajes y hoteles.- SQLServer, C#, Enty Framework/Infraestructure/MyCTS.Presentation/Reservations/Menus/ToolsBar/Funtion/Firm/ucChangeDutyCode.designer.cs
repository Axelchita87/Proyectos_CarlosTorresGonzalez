namespace MyCTS.Presentation
{
    partial class ucChangeDutyCode
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
            this.rdoAgent = new System.Windows.Forms.RadioButton();
            this.rdoSupervisor = new System.Windows.Forms.RadioButton();
            this.rdoTrainee = new System.Windows.Forms.RadioButton();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cambiar DutyCode";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rdoAgent
            // 
            this.rdoAgent.AutoSize = true;
            this.rdoAgent.Location = new System.Drawing.Point(29, 43);
            this.rdoAgent.Name = "rdoAgent";
            this.rdoAgent.Size = new System.Drawing.Size(59, 17);
            this.rdoAgent.TabIndex = 1;
            this.rdoAgent.TabStop = true;
            this.rdoAgent.Text = "Agente";
            this.rdoAgent.UseVisualStyleBackColor = true;
            this.rdoAgent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoSupervisor
            // 
            this.rdoSupervisor.AutoSize = true;
            this.rdoSupervisor.Location = new System.Drawing.Point(29, 67);
            this.rdoSupervisor.Name = "rdoSupervisor";
            this.rdoSupervisor.Size = new System.Drawing.Size(75, 17);
            this.rdoSupervisor.TabIndex = 2;
            this.rdoSupervisor.TabStop = true;
            this.rdoSupervisor.Text = "Supervisor";
            this.rdoSupervisor.UseVisualStyleBackColor = true;
            this.rdoSupervisor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoTrainee
            // 
            this.rdoTrainee.AutoSize = true;
            this.rdoTrainee.Location = new System.Drawing.Point(29, 91);
            this.rdoTrainee.Name = "rdoTrainee";
            this.rdoTrainee.Size = new System.Drawing.Size(113, 17);
            this.rdoTrainee.TabIndex = 3;
            this.rdoTrainee.TabStop = true;
            this.rdoTrainee.Text = "Aprendiz / Trainee";
            this.rdoTrainee.UseVisualStyleBackColor = true;
            this.rdoTrainee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(273, 124);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucChangeDutyCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.rdoTrainee);
            this.Controls.Add(this.rdoSupervisor);
            this.Controls.Add(this.rdoAgent);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucChangeDutyCode";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucChangeDutyCode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rdoAgent;
        private System.Windows.Forms.RadioButton rdoSupervisor;
        private System.Windows.Forms.RadioButton rdoTrainee;
        private System.Windows.Forms.Button btnAccept;
    }
}
