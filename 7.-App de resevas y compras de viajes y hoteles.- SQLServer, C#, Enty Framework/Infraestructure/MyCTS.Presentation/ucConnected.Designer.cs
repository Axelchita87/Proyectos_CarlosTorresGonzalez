namespace MyCTS.Presentation
{
   partial class ucConnected
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucConnected));
          this.label1 = new System.Windows.Forms.Label();
          this.pictureBox1 = new System.Windows.Forms.PictureBox();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
          this.SuspendLayout();
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label1.ForeColor = System.Drawing.Color.DarkGreen;
          this.label1.Location = new System.Drawing.Point(152, 512);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(153, 13);
          this.label1.TabIndex = 0;
          this.label1.Text = "Conectado correctamente";
          // 
          // pictureBox1
          // 
          this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
          this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
          this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
          this.pictureBox1.Location = new System.Drawing.Point(311, 477);
          this.pictureBox1.Name = "pictureBox1";
          this.pictureBox1.Size = new System.Drawing.Size(100, 50);
          this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
          this.pictureBox1.TabIndex = 12;
          this.pictureBox1.TabStop = false;
          // 
          // ucConnected
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.White;
          this.Controls.Add(this.pictureBox1);
          this.Controls.Add(this.label1);
          this.Name = "ucConnected";
          this.Size = new System.Drawing.Size(427, 537);
          this.Load += new System.EventHandler(this.ucConnected_Load);
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
       private System.Windows.Forms.PictureBox pictureBox1;
   }
}
