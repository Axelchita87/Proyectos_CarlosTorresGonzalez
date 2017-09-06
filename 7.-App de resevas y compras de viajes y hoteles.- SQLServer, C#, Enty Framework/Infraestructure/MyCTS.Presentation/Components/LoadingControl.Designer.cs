namespace MyCTS.Presentation.Components
{
    partial class LoadingControl
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
            this.loadingPictureBox = new System.Windows.Forms.PictureBox();
            this.airPlaneLoadingPicture = new System.Windows.Forms.PictureBox();
            this.msgToShowLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.airPlaneLoadingPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // loadingPictureBox
            // 
            this.loadingPictureBox.Image = global::MyCTS.Presentation.Properties.Resources.loadingBlue;
            this.loadingPictureBox.Location = new System.Drawing.Point(12, 163);
            this.loadingPictureBox.Name = "loadingPictureBox";
            this.loadingPictureBox.Size = new System.Drawing.Size(266, 28);
            this.loadingPictureBox.TabIndex = 108;
            this.loadingPictureBox.TabStop = false;
            // 
            // airPlaneLoadingPicture
            // 
            this.airPlaneLoadingPicture.Image = global::MyCTS.Presentation.Properties.Resources.rsz_avialability;
            this.airPlaneLoadingPicture.Location = new System.Drawing.Point(59, 18);
            this.airPlaneLoadingPicture.Name = "airPlaneLoadingPicture";
            this.airPlaneLoadingPicture.Size = new System.Drawing.Size(143, 139);
            this.airPlaneLoadingPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.airPlaneLoadingPicture.TabIndex = 107;
            this.airPlaneLoadingPicture.TabStop = false;
            // 
            // msgToShowLabel
            // 
            this.msgToShowLabel.AutoSize = true;
            this.msgToShowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgToShowLabel.Location = new System.Drawing.Point(19, 145);
            this.msgToShowLabel.Name = "msgToShowLabel";
            this.msgToShowLabel.Size = new System.Drawing.Size(127, 15);
            this.msgToShowLabel.TabIndex = 109;
            this.msgToShowLabel.Text = "Buscando vuelos...";
            // 
            // LoadingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.msgToShowLabel);
            this.Controls.Add(this.loadingPictureBox);
            this.Controls.Add(this.airPlaneLoadingPicture);
            this.Name = "LoadingControl";
            this.Size = new System.Drawing.Size(281, 195);
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.airPlaneLoadingPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox loadingPictureBox;
        private System.Windows.Forms.PictureBox airPlaneLoadingPicture;
        private System.Windows.Forms.Label msgToShowLabel;
    }
}
