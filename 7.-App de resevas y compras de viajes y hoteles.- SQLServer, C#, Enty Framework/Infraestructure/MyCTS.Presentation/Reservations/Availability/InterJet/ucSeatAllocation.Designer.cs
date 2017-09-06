namespace MyCTS.Presentation
{
    partial class ucSeatAllocation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.btnAcept = new System.Windows.Forms.Button();
            this.lblNumberClientDK = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblAssingSeat = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new GradProg.GradProg();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblFly = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selección de Asientos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Para seleccionar tus asientos ";
            // 
            // confirmButton
            // 
            this.confirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.confirmButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.Location = new System.Drawing.Point(171, 44);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(117, 25);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "Presiona aquí";
            this.confirmButton.UseVisualStyleBackColor = false;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // btnAcept
            // 
            this.btnAcept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAcept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAcept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcept.Location = new System.Drawing.Point(42, 8);
            this.btnAcept.Name = "btnAcept";
            this.btnAcept.Size = new System.Drawing.Size(117, 25);
            this.btnAcept.TabIndex = 3;
            this.btnAcept.Text = "Continuar";
            this.btnAcept.UseVisualStyleBackColor = false;
            this.btnAcept.Click += new System.EventHandler(this.btnAcept_Click);
            // 
            // lblNumberClientDK
            // 
            this.lblNumberClientDK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblNumberClientDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberClientDK.ForeColor = System.Drawing.Color.White;
            this.lblNumberClientDK.Location = new System.Drawing.Point(3, 3);
            this.lblNumberClientDK.Name = "lblNumberClientDK";
            this.lblNumberClientDK.Size = new System.Drawing.Size(405, 14);
            this.lblNumberClientDK.TabIndex = 0;
            this.lblNumberClientDK.Text = "Paso 7/8 - Asignación de asientos";
            this.lblNumberClientDK.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAcept);
            this.panel1.Location = new System.Drawing.Point(184, 497);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 48);
            this.panel1.TabIndex = 35;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(365, 150);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.Visible = false;
            // 
            // lblAssingSeat
            // 
            this.lblAssingSeat.AutoSize = true;
            this.lblAssingSeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssingSeat.Location = new System.Drawing.Point(148, 93);
            this.lblAssingSeat.Name = "lblAssingSeat";
            this.lblAssingSeat.Size = new System.Drawing.Size(135, 13);
            this.lblAssingSeat.TabIndex = 0;
            this.lblAssingSeat.Text = "Asientos Selecionados";
            this.lblAssingSeat.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.GradientStyle = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.progressBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.progressBar1.LabelBackColour = System.Drawing.Color.DimGray;
            this.progressBar1.LabelForeColour = System.Drawing.Color.LightSeaGreen;
            this.progressBar1.LabelPosition = new System.Drawing.Point(0, 0);
            this.progressBar1.Location = new System.Drawing.Point(19, 283);
            this.progressBar1.Maximum = 100;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Percentage = 0;
            this.progressBar1.ProgressBarBackColour = System.Drawing.Color.White;
            this.progressBar1.ProgressBarForeColour = System.Drawing.Color.SteelBlue;
            this.progressBar1.ShowLabel = false;
            this.progressBar1.Size = new System.Drawing.Size(372, 26);
            this.progressBar1.TabIndex = 111;
            this.progressBar1.Value = 0;
            this.progressBar1.Visible = false;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(22, 266);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(135, 15);
            this.lblSearch.TabIndex = 112;
            this.lblSearch.Text = "Buscando vuelos ....";
            this.lblSearch.Visible = false;
            // 
            // lblFly
            // 
            this.lblFly.AutoSize = true;
            this.lblFly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFly.Location = new System.Drawing.Point(22, 266);
            this.lblFly.Name = "lblFly";
            this.lblFly.Size = new System.Drawing.Size(41, 13);
            this.lblFly.TabIndex = 113;
            this.lblFly.Text = "label3";
            this.lblFly.Visible = false;
            // 
            // ucSeatAllocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblFly);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblAssingSeat);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNumberClientDK);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucSeatAllocation";
            this.Size = new System.Drawing.Size(411, 592);
            this.Load += new System.EventHandler(this.ucSeatAllocation_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button btnAcept;
        internal System.Windows.Forms.Label lblNumberClientDK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblAssingSeat;
        private System.Windows.Forms.Timer timer1;
        private GradProg.GradProg progressBar1;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblFly;
    }
}
