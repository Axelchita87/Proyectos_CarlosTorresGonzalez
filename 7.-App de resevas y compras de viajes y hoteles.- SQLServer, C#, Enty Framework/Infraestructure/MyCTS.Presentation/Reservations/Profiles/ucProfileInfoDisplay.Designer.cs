namespace MyCTS.Presentation
{
    partial class ucProfileInfoDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProfileInfoDisplay));
            this.toolStripProfilesInfo = new System.Windows.Forms.ToolStrip();
            this.btnAddToRecord = new System.Windows.Forms.ToolStripButton();
            this.btnRenameProfile = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteProfile = new System.Windows.Forms.ToolStripButton();
            this.btnSendToOutlook = new System.Windows.Forms.ToolStripButton();
            this.treeViewProfile = new MyCTS.Forms.UI.MultiSelectTreeview();
            this.contextMenuStripChild = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextCopyMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageProfileList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainerStarinfo = new System.Windows.Forms.SplitContainer();
            this.toolStripProfilesInfo.SuspendLayout();
            this.contextMenuStripChild.SuspendLayout();
            this.contextCopyMenuStrip.SuspendLayout();
            this.splitContainerStarinfo.Panel1.SuspendLayout();
            this.splitContainerStarinfo.Panel2.SuspendLayout();
            this.splitContainerStarinfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripProfilesInfo
            // 
            this.toolStripProfilesInfo.AutoSize = false;
            this.toolStripProfilesInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.toolStripProfilesInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripProfilesInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddToRecord,
            this.btnRenameProfile,
            this.btnDeleteProfile,
            this.btnSendToOutlook});
            this.toolStripProfilesInfo.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStripProfilesInfo.Location = new System.Drawing.Point(0, 0);
            this.toolStripProfilesInfo.Name = "toolStripProfilesInfo";
            this.toolStripProfilesInfo.Size = new System.Drawing.Size(74, 529);
            this.toolStripProfilesInfo.TabIndex = 0;
            this.toolStripProfilesInfo.Text = "toolStrip1";
            // 
            // btnAddToRecord
            // 
            this.btnAddToRecord.ForeColor = System.Drawing.Color.White;
            this.btnAddToRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnAddToRecord.Image")));
            this.btnAddToRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAddToRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddToRecord.Name = "btnAddToRecord";
            this.btnAddToRecord.Size = new System.Drawing.Size(72, 43);
            this.btnAddToRecord.Text = "Pasar";
            this.btnAddToRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddToRecord.ToolTipText = "Pasa la  Información del Perfil al Record";
            this.btnAddToRecord.Click += new System.EventHandler(this.btnAddToRecord_Click);
            // 
            // btnRenameProfile
            // 
            this.btnRenameProfile.ForeColor = System.Drawing.Color.White;
            this.btnRenameProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnRenameProfile.Image")));
            this.btnRenameProfile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRenameProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRenameProfile.Name = "btnRenameProfile";
            this.btnRenameProfile.Size = new System.Drawing.Size(72, 43);
            this.btnRenameProfile.Text = "Renombrar";
            this.btnRenameProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRenameProfile.ToolTipText = "Cambia el Nombre de Perfil";
            this.btnRenameProfile.Click += new System.EventHandler(this.btnRenameProfile_Click);
            // 
            // btnDeleteProfile
            // 
            this.btnDeleteProfile.ForeColor = System.Drawing.Color.White;
            this.btnDeleteProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteProfile.Image")));
            this.btnDeleteProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteProfile.Name = "btnDeleteProfile";
            this.btnDeleteProfile.Size = new System.Drawing.Size(72, 35);
            this.btnDeleteProfile.Text = "Borrar";
            this.btnDeleteProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeleteProfile.ToolTipText = "Borra en su Totalidad el Perfil";
            this.btnDeleteProfile.Click += new System.EventHandler(this.btnDeleteProfile_Click);
            // 
            // btnSendToOutlook
            // 
            this.btnSendToOutlook.ForeColor = System.Drawing.Color.White;
            this.btnSendToOutlook.Image = ((System.Drawing.Image)(resources.GetObject("btnSendToOutlook.Image")));
            this.btnSendToOutlook.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSendToOutlook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSendToOutlook.Name = "btnSendToOutlook";
            this.btnSendToOutlook.Size = new System.Drawing.Size(72, 43);
            this.btnSendToOutlook.Text = "OutLook";
            this.btnSendToOutlook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSendToOutlook.ToolTipText = "Exportar a OutLook";
            this.btnSendToOutlook.Visible = false;
            this.btnSendToOutlook.Click += new System.EventHandler(this.btnSendToOutlook_Click);
            // 
            // treeViewProfile
            // 
            this.treeViewProfile.BackColor = System.Drawing.Color.GhostWhite;
            this.treeViewProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewProfile.ImageIndexDefault = 3;
            this.treeViewProfile.ImageIndexSelectedOptional = 4;
            this.treeViewProfile.Location = new System.Drawing.Point(0, 0);
            this.treeViewProfile.Name = "treeViewProfile";
            this.treeViewProfile.SelectedNodes = ((System.Collections.Generic.List<System.Windows.Forms.TreeNode>)(resources.GetObject("treeViewProfile.SelectedNodes")));
            this.treeViewProfile.ShowLines = false;
            this.treeViewProfile.ShowNodeToolTips = true;
            this.treeViewProfile.Size = new System.Drawing.Size(564, 529);
            this.treeViewProfile.TabIndex = 1;
            this.treeViewProfile.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeViewProfile.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewProfile_NodeMouseClick);
            this.treeViewProfile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeViewProfile_MouseClick);
            this.treeViewProfile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeViewProfile_MouseDoubleClick);
            this.treeViewProfile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeViewProfiles_MouseDown);
            // 
            // contextMenuStripChild
            // 
            this.contextMenuStripChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem});
            this.contextMenuStripChild.Name = "contextMenuStrip1";
            this.contextMenuStripChild.Size = new System.Drawing.Size(135, 26);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editarToolStripMenuItem.Image")));
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.editarToolStripMenuItem.Text = "Editar Perfil";
            this.editarToolStripMenuItem.ToolTipText = "Edita el Dato Seleccionado del Perfil";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.copyToolStripMenuItem.Text = "Copiar";
            this.copyToolStripMenuItem.ToolTipText = "Copia el Dato Seleccionado del Perfil";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // contextCopyMenuStrip
            // 
            this.contextCopyMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.contextCopyMenuStrip.Name = "contextCopyMenuStrip";
            this.contextCopyMenuStrip.Size = new System.Drawing.Size(110, 26);
            // 
            // imageProfileList
            // 
            this.imageProfileList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageProfileList.ImageStream")));
            this.imageProfileList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageProfileList.Images.SetKeyName(0, "_starsinfo.png");
            this.imageProfileList.Images.SetKeyName(1, "_starFirstLevel.png");
            this.imageProfileList.Images.SetKeyName(2, "_starsecondlevel.png");
            this.imageProfileList.Images.SetKeyName(3, "_stargeneric.png");
            this.imageProfileList.Images.SetKeyName(4, "_stargenericselect.png");
            this.imageProfileList.Images.SetKeyName(5, "_star2catalog.png");
            this.imageProfileList.Images.SetKeyName(6, "_starintegra.png");
            this.imageProfileList.Images.SetKeyName(7, "_starintegraattribute.png");
            this.imageProfileList.Images.SetKeyName(8, "_starintegraCostumer.png");
            this.imageProfileList.Images.SetKeyName(9, "_starintegraaddress.png");
            this.imageProfileList.Images.SetKeyName(10, "_starintegrarfc.png");
            // 
            // splitContainerStarinfo
            // 
            this.splitContainerStarinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerStarinfo.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerStarinfo.Location = new System.Drawing.Point(0, 0);
            this.splitContainerStarinfo.Name = "splitContainerStarinfo";
            // 
            // splitContainerStarinfo.Panel1
            // 
            this.splitContainerStarinfo.Panel1.Controls.Add(this.toolStripProfilesInfo);
            this.splitContainerStarinfo.Panel1MinSize = 53;
            // 
            // splitContainerStarinfo.Panel2
            // 
            this.splitContainerStarinfo.Panel2.Controls.Add(this.treeViewProfile);
            this.splitContainerStarinfo.Size = new System.Drawing.Size(642, 529);
            this.splitContainerStarinfo.SplitterDistance = 74;
            this.splitContainerStarinfo.TabIndex = 2;
            // 
            // ucProfileInfoDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.splitContainerStarinfo);
            this.Name = "ucProfileInfoDisplay";
            this.Size = new System.Drawing.Size(642, 529);
            this.Load += new System.EventHandler(this.ucProfileInfoDisplay_Load);
            this.toolStripProfilesInfo.ResumeLayout(false);
            this.toolStripProfilesInfo.PerformLayout();
            this.contextMenuStripChild.ResumeLayout(false);
            this.contextCopyMenuStrip.ResumeLayout(false);
            this.splitContainerStarinfo.Panel1.ResumeLayout(false);
            this.splitContainerStarinfo.Panel2.ResumeLayout(false);
            this.splitContainerStarinfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripProfilesInfo;
        private System.Windows.Forms.ToolStripButton btnAddToRecord;
        //private System.Windows.Forms.TreeView treeViewProfile;
        private MyCTS.Forms.UI.MultiSelectTreeview treeViewProfile;
        private System.Windows.Forms.ImageList imageProfileList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripChild;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnDeleteProfile;
        private System.Windows.Forms.ToolStripButton btnRenameProfile;
        private System.Windows.Forms.SplitContainer splitContainerStarinfo;
        private System.Windows.Forms.ToolStripButton btnSendToOutlook;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextCopyMenuStrip;


    }
}
