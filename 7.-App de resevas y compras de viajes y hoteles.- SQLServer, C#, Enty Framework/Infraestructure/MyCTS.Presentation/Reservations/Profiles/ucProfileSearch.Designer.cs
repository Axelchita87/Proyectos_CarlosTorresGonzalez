namespace MyCTS.Presentation
{
    partial class ucProfileSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProfileSearch));
            this.listViewProfiles = new System.Windows.Forms.ListView();
            this.Stars = new System.Windows.Forms.ColumnHeader();
            this.Level = new System.Windows.Forms.ColumnHeader();
            this.DK = new System.Windows.Forms.ColumnHeader();
            this.Email = new System.Windows.Forms.ColumnHeader();
            this.imageProfileList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // listViewProfiles
            // 
            this.listViewProfiles.BackColor = System.Drawing.Color.GhostWhite;
            this.listViewProfiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Stars,
            this.Level,
            this.DK,
            this.Email});
            this.listViewProfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewProfiles.Location = new System.Drawing.Point(0, 0);
            this.listViewProfiles.Name = "listViewProfiles";
            this.listViewProfiles.ShowItemToolTips = true;
            this.listViewProfiles.Size = new System.Drawing.Size(642, 529);
            this.listViewProfiles.TabIndex = 0;
            this.listViewProfiles.UseCompatibleStateImageBehavior = false;
            this.listViewProfiles.View = System.Windows.Forms.View.SmallIcon;
            this.listViewProfiles.DoubleClick += new System.EventHandler(this.listViewProfiles_DoubleClick);
            this.listViewProfiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewProfiles_KeyDown);
            // 
            // Stars
            // 
            this.Stars.DisplayIndex = 1;
            this.Stars.Tag = "Nombre Estrella";
            this.Stars.Text = "Estrella";
            this.Stars.Width = 248;
            // 
            // Level
            // 
            this.Level.DisplayIndex = 0;
            this.Level.Tag = "Nivel de estrella";
            this.Level.Text = "Nivel";
            this.Level.Width = 40;
            // 
            // DK
            // 
            this.DK.Tag = "Nivel de estrella";
            this.DK.Text = "DK";
            // 
            // Email
            // 
            this.Email.Text = "E-mail";
            this.Email.Width = 270;
            // 
            // imageProfileList
            // 
            this.imageProfileList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageProfileList.ImageStream")));
            this.imageProfileList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageProfileList.Images.SetKeyName(0, "_starFirstLevel.png");
            this.imageProfileList.Images.SetKeyName(1, "_starsecondlevel.png");
            // 
            // ucProfileSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.listViewProfiles);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucProfileSearch";
            this.Size = new System.Drawing.Size(642, 528);
            this.Load += new System.EventHandler(this.ucProfileSearch_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewProfiles;
        private System.Windows.Forms.ColumnHeader Stars;
        private System.Windows.Forms.ColumnHeader Level;
        private System.Windows.Forms.ColumnHeader DK;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ImageList imageProfileList;


    }
}
