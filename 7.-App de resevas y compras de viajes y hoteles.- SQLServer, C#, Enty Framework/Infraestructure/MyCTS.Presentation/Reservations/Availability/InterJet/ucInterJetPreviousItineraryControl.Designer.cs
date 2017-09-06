namespace MyCTS.Presentation
{
    partial class ucInterJetPreviousItineraryControl
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
            this.itineraryString = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.departureTime = new System.Windows.Forms.Label();
            this.arrivalTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flightNumberLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // itineraryString
            // 
            this.itineraryString.AutoSize = true;
            this.itineraryString.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itineraryString.ForeColor = System.Drawing.Color.DarkBlue;
            this.itineraryString.Location = new System.Drawing.Point(31, 25);
            this.itineraryString.Name = "itineraryString";
            this.itineraryString.Size = new System.Drawing.Size(11, 13);
            this.itineraryString.TabIndex = 0;
            this.itineraryString.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sale :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Llega:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MyCTS.Presentation.Properties.Resources.rsz_1327439336_plane;
            this.pictureBox1.Location = new System.Drawing.Point(108, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 33);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // departureTime
            // 
            this.departureTime.AutoSize = true;
            this.departureTime.Location = new System.Drawing.Point(51, 38);
            this.departureTime.Name = "departureTime";
            this.departureTime.Size = new System.Drawing.Size(10, 13);
            this.departureTime.TabIndex = 4;
            this.departureTime.Text = "-";
            // 
            // arrivalTime
            // 
            this.arrivalTime.AutoSize = true;
            this.arrivalTime.Location = new System.Drawing.Point(51, 58);
            this.arrivalTime.Name = "arrivalTime";
            this.arrivalTime.Size = new System.Drawing.Size(10, 13);
            this.arrivalTime.TabIndex = 5;
            this.arrivalTime.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "No. Vuelo";
            // 
            // flightNumberLabel
            // 
            this.flightNumberLabel.AutoSize = true;
            this.flightNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flightNumberLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.flightNumberLabel.Location = new System.Drawing.Point(81, 0);
            this.flightNumberLabel.Name = "flightNumberLabel";
            this.flightNumberLabel.Size = new System.Drawing.Size(35, 13);
            this.flightNumberLabel.TabIndex = 7;
            this.flightNumberLabel.Text = "2523";
            // 
            // ucInterJetPreviousItineraryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flightNumberLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.arrivalTime);
            this.Controls.Add(this.departureTime);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.itineraryString);
            this.Name = "ucInterJetPreviousItineraryControl";
            this.Size = new System.Drawing.Size(151, 77);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label itineraryString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label departureTime;
        private System.Windows.Forms.Label arrivalTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label flightNumberLabel;
    }
}
