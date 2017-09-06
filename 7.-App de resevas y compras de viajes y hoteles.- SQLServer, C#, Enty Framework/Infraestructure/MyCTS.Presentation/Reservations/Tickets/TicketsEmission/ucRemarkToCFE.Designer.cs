namespace MyCTS.Presentation
{
    partial class ucRemarkToCFE
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
            this.rdoMexicana = new System.Windows.Forms.RadioButton();
            this.rdoChangeBussinesClass = new System.Windows.Forms.RadioButton();
            this.rdoCanNotChangeBussinesClass = new System.Windows.Forms.RadioButton();
            this.rdoAeromexico = new System.Windows.Forms.RadioButton();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.lblTitle.Text = "Opción Aplicada al Record";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rdoMexicana
            // 
            this.rdoMexicana.AutoSize = true;
            this.rdoMexicana.Location = new System.Drawing.Point(62, 73);
            this.rdoMexicana.Name = "rdoMexicana";
            this.rdoMexicana.Size = new System.Drawing.Size(226, 17);
            this.rdoMexicana.TabIndex = 1;
            this.rdoMexicana.TabStop = true;
            this.rdoMexicana.Text = "SE MANDAN A TRABAJAR A MEXICANA";
            this.rdoMexicana.UseVisualStyleBackColor = true;
            this.rdoMexicana.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdoAeromexico_KeyDown);
            // 
            // rdoChangeBussinesClass
            // 
            this.rdoChangeBussinesClass.AutoSize = true;
            this.rdoChangeBussinesClass.Location = new System.Drawing.Point(62, 96);
            this.rdoChangeBussinesClass.Name = "rdoChangeBussinesClass";
            this.rdoChangeBussinesClass.Size = new System.Drawing.Size(219, 17);
            this.rdoChangeBussinesClass.TabIndex = 2;
            this.rdoChangeBussinesClass.TabStop = true;
            this.rdoChangeBussinesClass.Text = "SE CAMBIARON A CLASE NEGOCIADA";
            this.rdoChangeBussinesClass.UseVisualStyleBackColor = true;
            this.rdoChangeBussinesClass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdoAeromexico_KeyDown);
            // 
            // rdoCanNotChangeBussinesClass
            // 
            this.rdoCanNotChangeBussinesClass.AutoSize = true;
            this.rdoCanNotChangeBussinesClass.Location = new System.Drawing.Point(62, 119);
            this.rdoCanNotChangeBussinesClass.Name = "rdoCanNotChangeBussinesClass";
            this.rdoCanNotChangeBussinesClass.Size = new System.Drawing.Size(256, 17);
            this.rdoCanNotChangeBussinesClass.TabIndex = 3;
            this.rdoCanNotChangeBussinesClass.TabStop = true;
            this.rdoCanNotChangeBussinesClass.Text = "NO SE PUDO CAMBIAR A CLASE NEGOCIADA";
            this.rdoCanNotChangeBussinesClass.UseVisualStyleBackColor = true;
            this.rdoCanNotChangeBussinesClass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdoAeromexico_KeyDown);
            // 
            // rdoAeromexico
            // 
            this.rdoAeromexico.AutoSize = true;
            this.rdoAeromexico.Location = new System.Drawing.Point(62, 143);
            this.rdoAeromexico.Name = "rdoAeromexico";
            this.rdoAeromexico.Size = new System.Drawing.Size(177, 17);
            this.rdoAeromexico.TabIndex = 4;
            this.rdoAeromexico.TabStop = true;
            this.rdoAeromexico.Text = "FORZO TARIFA AEROMEXICO";
            this.rdoAeromexico.UseVisualStyleBackColor = true;
            this.rdoAeromexico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdoAeromexico_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(259, 212);
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
            this.label1.Location = new System.Drawing.Point(28, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Seleccione una de las siguientes opciones:";
            // 
            // ucRemarkToCFE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.rdoAeromexico);
            this.Controls.Add(this.rdoCanNotChangeBussinesClass);
            this.Controls.Add(this.rdoChangeBussinesClass);
            this.Controls.Add(this.rdoMexicana);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucRemarkToCFE";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucRemarkToCFE_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rdoMexicana;
        private System.Windows.Forms.RadioButton rdoChangeBussinesClass;
        private System.Windows.Forms.RadioButton rdoCanNotChangeBussinesClass;
        private System.Windows.Forms.RadioButton rdoAeromexico;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label1;
    }
}
