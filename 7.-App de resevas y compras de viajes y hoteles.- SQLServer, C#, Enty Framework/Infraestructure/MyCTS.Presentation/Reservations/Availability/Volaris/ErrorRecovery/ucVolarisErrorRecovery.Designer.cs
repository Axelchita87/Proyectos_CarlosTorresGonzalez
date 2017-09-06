namespace MyCTS.Presentation.Reservations.Availability.Volaris.ErrorRecovery
{
    partial class ucVolarisErrorRecovery
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
            this.header = new System.Windows.Forms.Label();
            this.container = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.optionOne = new System.Windows.Forms.Button();
            this.option = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.container.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header.ForeColor = System.Drawing.Color.Black;
            this.header.Location = new System.Drawing.Point(84, 17);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(74, 25);
            this.header.TabIndex = 1;
            this.header.Text = "Error";
            // 
            // container
            // 
            this.container.AutoSize = true;
            this.container.ColumnCount = 1;
            this.container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 390F));
            this.container.Controls.Add(this.panel1, 0, 1);
            this.container.Controls.Add(this.label2, 0, 0);
            this.container.Location = new System.Drawing.Point(3, 67);
            this.container.Name = "container";
            this.container.RowCount = 2;
            this.container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.container.Size = new System.Drawing.Size(390, 148);
            this.container.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 79);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.optionOne);
            this.panel2.Controls.Add(this.option);
            this.panel2.Location = new System.Drawing.Point(66, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(174, 31);
            this.panel2.TabIndex = 28;
            // 
            // optionOne
            // 
            this.optionOne.AutoSize = true;
            this.optionOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.optionOne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optionOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionOne.Location = new System.Drawing.Point(3, 3);
            this.optionOne.Name = "optionOne";
            this.optionOne.Size = new System.Drawing.Size(74, 25);
            this.optionOne.TabIndex = 18;
            this.optionOne.Text = "Reintentar";
            this.optionOne.UseVisualStyleBackColor = true;
            this.optionOne.Click += new System.EventHandler(this.optionOne_Click);
            // 
            // option
            // 
            this.option.AutoSize = true;
            this.option.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.option.Cursor = System.Windows.Forms.Cursors.Hand;
            this.option.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.option.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.option.Location = new System.Drawing.Point(83, 3);
            this.option.Name = "option";
            this.option.Size = new System.Drawing.Size(85, 25);
            this.option.TabIndex = 17;
            this.option.Text = "Cancelar";
            this.option.UseVisualStyleBackColor = false;
            this.option.Click += new System.EventHandler(this.option_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "-";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MyCTS.Presentation.Properties.Resources._dialog_information;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ucVolarisErrorRecovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.container);
            this.Controls.Add(this.header);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ucVolarisErrorRecovery";
            this.Size = new System.Drawing.Size(396, 218);
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.TableLayoutPanel container;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button optionOne;
        private System.Windows.Forms.Button option;
    }
}
