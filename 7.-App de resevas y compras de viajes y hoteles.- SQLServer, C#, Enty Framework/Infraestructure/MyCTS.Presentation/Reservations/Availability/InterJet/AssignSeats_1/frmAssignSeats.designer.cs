using MyCTS.Presentation.Resources;
namespace MyCTS.Presentation
{
    partial class frmAssignSeats
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pasajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Selecciona = new System.Windows.Forms.DataGridViewImageColumn();
            this.Segmento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAlerta = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblAirPlane = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblgray = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblgreen = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lblSelect = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Pasajero,
            this.Asiento,
            this.Selecciona,
            this.Segmento});
            this.dataGridView1.Location = new System.Drawing.Point(12, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(406, 150);
            this.dataGridView1.TabIndex = 230;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 20;
            // 
            // Pasajero
            // 
            this.Pasajero.FillWeight = 80F;
            this.Pasajero.HeaderText = "Pasajero";
            this.Pasajero.Name = "Pasajero";
            this.Pasajero.ReadOnly = true;
            // 
            // Asiento
            // 
            this.Asiento.HeaderText = "Asiento";
            this.Asiento.Name = "Asiento";
            this.Asiento.ReadOnly = true;
            this.Asiento.Width = 80;
            // 
            // Selecciona
            // 
            this.Selecciona.HeaderText = "Selecciona";
            this.Selecciona.Name = "Selecciona";
            this.Selecciona.Width = 80;
            // 
            // Segmento
            // 
            this.Segmento.HeaderText = "Segmento";
            this.Segmento.Name = "Segmento";
            // 
            // lblAlerta
            // 
            this.lblAlerta.AutoSize = true;
            this.lblAlerta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlerta.ForeColor = System.Drawing.Color.Black;
            this.lblAlerta.Location = new System.Drawing.Point(9, 231);
            this.lblAlerta.Name = "lblAlerta";
            this.lblAlerta.Size = new System.Drawing.Size(0, 17);
            this.lblAlerta.TabIndex = 381;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(164, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 35);
            this.button1.TabIndex = 535;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblAirPlane
            // 
            this.lblAirPlane.AutoSize = true;
            this.lblAirPlane.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirPlane.Location = new System.Drawing.Point(552, 9);
            this.lblAirPlane.Name = "lblAirPlane";
            this.lblAirPlane.Size = new System.Drawing.Size(0, 18);
            this.lblAirPlane.TabIndex = 538;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Location = new System.Drawing.Point(486, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 775);
            this.panel1.TabIndex = 539;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Selecciona";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 80;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Silver;
            this.textBox1.Location = new System.Drawing.Point(127, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(21, 20);
            this.textBox1.TabIndex = 540;
            // 
            // lblgray
            // 
            this.lblgray.AutoSize = true;
            this.lblgray.Location = new System.Drawing.Point(99, 36);
            this.lblgray.Name = "lblgray";
            this.lblgray.Size = new System.Drawing.Size(71, 13);
            this.lblgray.TabIndex = 541;
            this.lblgray.Text = "No disponible";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.YellowGreen;
            this.textBox2.Location = new System.Drawing.Point(193, 10);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(23, 20);
            this.textBox2.TabIndex = 542;
            // 
            // lblgreen
            // 
            this.lblgreen.AutoSize = true;
            this.lblgreen.Location = new System.Drawing.Point(179, 36);
            this.lblgreen.Name = "lblgreen";
            this.lblgreen.Size = new System.Drawing.Size(56, 13);
            this.lblgreen.TabIndex = 543;
            this.lblgreen.Text = "Disponible";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Yellow;
            this.textBox3.Location = new System.Drawing.Point(262, 10);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(25, 20);
            this.textBox3.TabIndex = 544;
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(244, 35);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(72, 13);
            this.lblSelect.TabIndex = 545;
            this.lblSelect.Text = "Seleccionado";
            // 
            // frmAssignSeats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(768, 812);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.lblgreen);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblgray);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblAirPlane);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblAlerta);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmAssignSeats";
            this.Text = "Asignación de asientos Interjet";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblAlerta;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblAirPlane;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pasajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asiento;
        private System.Windows.Forms.DataGridViewImageColumn Selecciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn Segmento;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblgray;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblgreen;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblSelect;
    }
}

