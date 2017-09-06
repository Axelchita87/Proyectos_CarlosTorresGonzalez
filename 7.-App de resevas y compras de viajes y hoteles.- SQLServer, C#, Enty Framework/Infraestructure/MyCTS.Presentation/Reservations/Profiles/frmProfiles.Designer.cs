namespace MyCTS.Presentation
{
    partial class frmProfiles
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfiles));
            this.toolStripProfileMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownOptionProfiles = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuSearchDetailedProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemNewProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCreateProfile2ndLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStriplblSearch = new System.Windows.Forms.ToolStripLabel();
            this.toolStriptxtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextDK = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStriplblSearch1 = new System.Windows.Forms.ToolStripLabel();
            this.pnlProfiles = new System.Windows.Forms.Panel();
            this.TxtContadorRegistros = new System.Windows.Forms.Label();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripProfileMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripProfileMenu
            // 
            this.toolStripProfileMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.toolStripProfileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownOptionProfiles,
            this.toolStriplblSearch,
            this.toolStriptxtSearch,
            this.toolStripLabel2,
            this.toolStripTextDK});
            this.toolStripProfileMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripProfileMenu.Name = "toolStripProfileMenu";
            this.toolStripProfileMenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripProfileMenu.Size = new System.Drawing.Size(642, 25);
            this.toolStripProfileMenu.Stretch = true;
            this.toolStripProfileMenu.TabIndex = 1;
            this.toolStripProfileMenu.TabStop = true;
            this.toolStripProfileMenu.Text = "toolStrip1";
            this.toolStripProfileMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripProfileMenu_ItemClicked);
            // 
            // toolStripDropDownOptionProfiles
            // 
            this.toolStripDropDownOptionProfiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownOptionProfiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuSearchDetailedProfile,
            this.ToolStripMenuItemNewProfile,
            this.ToolStripMenuItemCreateProfile2ndLevel});
            this.toolStripDropDownOptionProfiles.ForeColor = System.Drawing.Color.White;
            this.toolStripDropDownOptionProfiles.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownOptionProfiles.Image")));
            this.toolStripDropDownOptionProfiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownOptionProfiles.Name = "toolStripDropDownOptionProfiles";
            this.toolStripDropDownOptionProfiles.Size = new System.Drawing.Size(58, 22);
            this.toolStripDropDownOptionProfiles.Text = "Perfiles";
            this.toolStripDropDownOptionProfiles.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // ToolStripMenuSearchDetailedProfile
            // 
            this.ToolStripMenuSearchDetailedProfile.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuSearchDetailedProfile.Image")));
            this.ToolStripMenuSearchDetailedProfile.Name = "ToolStripMenuSearchDetailedProfile";
            this.ToolStripMenuSearchDetailedProfile.Size = new System.Drawing.Size(208, 22);
            this.ToolStripMenuSearchDetailedProfile.Text = "Busqueda Avanzada";
            this.ToolStripMenuSearchDetailedProfile.ToolTipText = "Buscar perfil definido";
            this.ToolStripMenuSearchDetailedProfile.Visible = false;
            this.ToolStripMenuSearchDetailedProfile.Click += new System.EventHandler(this.ToolStripMenuSearchDetailedProfile_Click);
            // 
            // ToolStripMenuItemNewProfile
            // 
            this.ToolStripMenuItemNewProfile.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItemNewProfile.Image")));
            this.ToolStripMenuItemNewProfile.Name = "ToolStripMenuItemNewProfile";
            this.ToolStripMenuItemNewProfile.Size = new System.Drawing.Size(208, 22);
            this.ToolStripMenuItemNewProfile.Text = "Crear Perfil Primer Nivel";
            this.ToolStripMenuItemNewProfile.ToolTipText = "Crea Perfil Nuevo de Primer Nivel";
            this.ToolStripMenuItemNewProfile.Click += new System.EventHandler(this.ToolStripMenuItemNewProfile_Click);
            // 
            // ToolStripMenuItemCreateProfile2ndLevel
            // 
            this.ToolStripMenuItemCreateProfile2ndLevel.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItemCreateProfile2ndLevel.Image")));
            this.ToolStripMenuItemCreateProfile2ndLevel.Name = "ToolStripMenuItemCreateProfile2ndLevel";
            this.ToolStripMenuItemCreateProfile2ndLevel.Size = new System.Drawing.Size(208, 22);
            this.ToolStripMenuItemCreateProfile2ndLevel.Text = "Crea Perfil Segundo Nivel";
            this.ToolStripMenuItemCreateProfile2ndLevel.ToolTipText = "Crea Perfil Nuevo de Segundo Nivel";
            this.ToolStripMenuItemCreateProfile2ndLevel.Click += new System.EventHandler(this.ToolStripMenuItemCreateProfile2ndLevel_Click);
            // 
            // toolStriplblSearch
            // 
            this.toolStriplblSearch.AutoToolTip = true;
            this.toolStriplblSearch.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolStriplblSearch.ForeColor = System.Drawing.Color.White;
            this.toolStriplblSearch.Margin = new System.Windows.Forms.Padding(12, 1, 0, 2);
            this.toolStriplblSearch.Name = "toolStriplblSearch";
            this.toolStriplblSearch.Size = new System.Drawing.Size(102, 22);
            this.toolStriplblSearch.Text = "Buscar por Apellido:";
            this.toolStriplblSearch.ToolTipText = "Ingresa algun nombre de perfil en el cuadro de texto";
            // 
            // toolStriptxtSearch
            // 
            this.toolStriptxtSearch.AutoToolTip = true;
            this.toolStriptxtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.toolStriptxtSearch.MaxLength = 40;
            this.toolStriptxtSearch.Name = "toolStriptxtSearch";
            this.toolStriptxtSearch.Size = new System.Drawing.Size(110, 25);
            this.toolStriptxtSearch.ToolTipText = "Buscar perfil";
            this.toolStriptxtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStriptxtSearch_KeyPress);
            this.toolStriptxtSearch.TextChanged += new System.EventHandler(this.toolStriptxtSearch_TextChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoToolTip = true;
            this.toolStripLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolStripLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(12, 1, 0, 2);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(78, 22);
            this.toolStripLabel2.Text = "Buscar por DK:";
            this.toolStripLabel2.ToolTipText = "Ingresa algun nombre de perfil en el cuadro de texto";
            // 
            // toolStripTextDK
            // 
            this.toolStripTextDK.AutoToolTip = true;
            this.toolStripTextDK.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.toolStripTextDK.MaxLength = 20;
            this.toolStripTextDK.Name = "toolStripTextDK";
            this.toolStripTextDK.Size = new System.Drawing.Size(110, 25);
            this.toolStripTextDK.ToolTipText = "Buscar DK";
            this.toolStripTextDK.TextChanged += new System.EventHandler(this.toolStripTextDK_TextChanged);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.AutoToolTip = true;
            this.toolStripLabel4.Font = new System.Drawing.Font("Tahoma", 6.25F);
            this.toolStripLabel4.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(10, 22);
            this.toolStripLabel4.Text = "o";
            // 
            // toolStriplblSearch1
            // 
            this.toolStriplblSearch1.ForeColor = System.Drawing.Color.White;
            this.toolStriplblSearch1.Name = "toolStriplblSearch1";
            this.toolStriplblSearch1.Size = new System.Drawing.Size(70, 22);
            this.toolStriplblSearch1.Text = "Buscar por DK:";
            this.toolStriplblSearch1.ToolTipText = "Ingresa algun nombre de perfil en el cuadro de texto";
            // 
            // pnlProfiles
            // 
            this.pnlProfiles.AutoScroll = true;
            this.pnlProfiles.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlProfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProfiles.Location = new System.Drawing.Point(0, 25);
            this.pnlProfiles.Margin = new System.Windows.Forms.Padding(0);
            this.pnlProfiles.Name = "pnlProfiles";
            this.pnlProfiles.Size = new System.Drawing.Size(642, 548);
            this.pnlProfiles.TabIndex = 2;
            this.pnlProfiles.TabStop = true;
            this.pnlProfiles.Enter += new System.EventHandler(this.pnlProfiles_Enter);
            // 
            // TxtContadorRegistros
            // 
            this.TxtContadorRegistros.BackColor = System.Drawing.Color.LightGray;
            this.TxtContadorRegistros.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtContadorRegistros.Location = new System.Drawing.Point(0, 550);
            this.TxtContadorRegistros.Name = "TxtContadorRegistros";
            this.TxtContadorRegistros.Size = new System.Drawing.Size(642, 23);
            this.TxtContadorRegistros.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 22);
            // 
            // frmProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(642, 573);
            this.Controls.Add(this.TxtContadorRegistros);
            this.Controls.Add(this.pnlProfiles);
            this.Controls.Add(this.toolStripProfileMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmProfiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Módulo de Perfiles";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProfiles_FormClosed);
            this.Load += new System.EventHandler(this.frmProfiles_Load);
            this.toolStripProfileMenu.ResumeLayout(false);
            this.toolStripProfileMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripProfileMenu;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownOptionProfiles;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuSearchDetailedProfile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemNewProfile;
        private System.Windows.Forms.ToolStripLabel toolStriplblSearch;
        private System.Windows.Forms.ToolStripLabel toolStriplblSearch1;
        private System.Windows.Forms.ToolStripTextBox toolStriptxtSearch;
        private System.Windows.Forms.ToolStripTextBox toolStriptxtSearch1;
        private System.Windows.Forms.Panel pnlProfiles;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCreateProfile2ndLevel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextDK;
        private System.Windows.Forms.Label TxtContadorRegistros;
        //private System.Windows.Forms.Label progressLabel;
        //private GradProg.GradProg gradProg1;
        public System.Windows.Forms.ProgressBar prbUpdate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;


    }
}
