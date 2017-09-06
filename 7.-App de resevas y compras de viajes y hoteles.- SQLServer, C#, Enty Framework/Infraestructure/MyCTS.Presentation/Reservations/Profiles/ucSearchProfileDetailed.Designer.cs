namespace MyCTS.Presentation
{
    partial class ucSearchProfileDetailed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSearchProfileDetailed));
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblStar2Name = new System.Windows.Forms.Label();
            this.txtStar2Name = new MyCTS.Forms.UI.SmartTextBox();
            this.lblStar1Name = new System.Windows.Forms.Label();
            this.txtStar1name = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPCC = new System.Windows.Forms.Label();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.listViewProfiles = new System.Windows.Forms.ListView();
            this.Stars = new System.Windows.Forms.ColumnHeader();
            this.Level = new System.Windows.Forms.ColumnHeader();
            this.imageProfileList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainerSearch = new System.Windows.Forms.SplitContainer();
            this.splitContainerSearch.Panel1.SuspendLayout();
            this.splitContainerSearch.Panel2.SuspendLayout();
            this.splitContainerSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.Blue;
            this.lblDescription.Location = new System.Drawing.Point(21, 10);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(252, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Ingresa PCC y Estrella de Primer y/o segundo nivel: ";
            // 
            // lblStar2Name
            // 
            this.lblStar2Name.AutoSize = true;
            this.lblStar2Name.Location = new System.Drawing.Point(21, 84);
            this.lblStar2Name.Name = "lblStar2Name";
            this.lblStar2Name.Size = new System.Drawing.Size(80, 13);
            this.lblStar2Name.TabIndex = 0;
            this.lblStar2Name.Text = "Segundo Nivel:";
            // 
            // txtStar2Name
            // 
            this.txtStar2Name.AllowBlankSpaces = false;
            this.txtStar2Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStar2Name.CharsIncluded = new char[] {
        '/'};
            this.txtStar2Name.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtStar2Name.CustomExpression = ".*";
            this.txtStar2Name.EnterColor = System.Drawing.Color.Empty;
            this.txtStar2Name.LeaveColor = System.Drawing.Color.Empty;
            this.txtStar2Name.Location = new System.Drawing.Point(106, 81);
            this.txtStar2Name.MaxLength = 50;
            this.txtStar2Name.Name = "txtStar2Name";
            this.txtStar2Name.Size = new System.Drawing.Size(154, 20);
            this.txtStar2Name.TabIndex = 3;
            this.txtStar2Name.TextChanged += new System.EventHandler(this.txtStar2Name_TextChanged);
            this.txtStar2Name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControls_KeyDown);
            // 
            // lblStar1Name
            // 
            this.lblStar1Name.AutoSize = true;
            this.lblStar1Name.Location = new System.Drawing.Point(21, 61);
            this.lblStar1Name.Name = "lblStar1Name";
            this.lblStar1Name.Size = new System.Drawing.Size(66, 13);
            this.lblStar1Name.TabIndex = 0;
            this.lblStar1Name.Text = "Primer Nivel:";
            // 
            // txtStar1name
            // 
            this.txtStar1name.AllowBlankSpaces = true;
            this.txtStar1name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStar1name.CharsIncluded = new char[] {
        '\0'};
            this.txtStar1name.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtStar1name.CustomExpression = ".*";
            this.txtStar1name.EnterColor = System.Drawing.Color.Empty;
            this.txtStar1name.LeaveColor = System.Drawing.Color.Empty;
            this.txtStar1name.Location = new System.Drawing.Point(106, 58);
            this.txtStar1name.MaxLength = 50;
            this.txtStar1name.Name = "txtStar1name";
            this.txtStar1name.Size = new System.Drawing.Size(154, 20);
            this.txtStar1name.TabIndex = 2;
            this.txtStar1name.TextChanged += new System.EventHandler(this.txtStar1name_TextChanged);
            this.txtStar1name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControls_KeyDown);
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Location = new System.Drawing.Point(21, 36);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(31, 13);
            this.lblPCC.TabIndex = 0;
            this.lblPCC.Text = "PCC:";
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = false;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(106, 32);
            this.txtPCC.MaxLength = 30;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(154, 20);
            this.txtPCC.TabIndex = 1;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControls_KeyDown);
            // 
            // listViewProfiles
            // 
            this.listViewProfiles.BackColor = System.Drawing.Color.GhostWhite;
            this.listViewProfiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Stars,
            this.Level});
            this.listViewProfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewProfiles.Location = new System.Drawing.Point(0, 0);
            this.listViewProfiles.Name = "listViewProfiles";
            this.listViewProfiles.ShowItemToolTips = true;
            this.listViewProfiles.Size = new System.Drawing.Size(492, 174);
            this.listViewProfiles.TabIndex = 4;
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
            this.Stars.Width = 215;
            // 
            // Level
            // 
            this.Level.DisplayIndex = 0;
            this.Level.Tag = "Nivel de estrella";
            this.Level.Text = "Nivel";
            this.Level.Width = 40;
            // 
            // imageProfileList
            // 
            this.imageProfileList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageProfileList.ImageStream")));
            this.imageProfileList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageProfileList.Images.SetKeyName(0, "_starFirstLevel.png");
            this.imageProfileList.Images.SetKeyName(1, "_starsecondlevel.png");
            // 
            // splitContainerSearch
            // 
            this.splitContainerSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSearch.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerSearch.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSearch.Name = "splitContainerSearch";
            this.splitContainerSearch.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSearch.Panel1
            // 
            this.splitContainerSearch.Panel1.Controls.Add(this.lblDescription);
            this.splitContainerSearch.Panel1.Controls.Add(this.lblStar2Name);
            this.splitContainerSearch.Panel1.Controls.Add(this.txtPCC);
            this.splitContainerSearch.Panel1.Controls.Add(this.txtStar2Name);
            this.splitContainerSearch.Panel1.Controls.Add(this.lblPCC);
            this.splitContainerSearch.Panel1.Controls.Add(this.lblStar1Name);
            this.splitContainerSearch.Panel1.Controls.Add(this.txtStar1name);
            this.splitContainerSearch.Panel1MinSize = 110;
            // 
            // splitContainerSearch.Panel2
            // 
            this.splitContainerSearch.Panel2.Controls.Add(this.listViewProfiles);
            this.splitContainerSearch.Size = new System.Drawing.Size(492, 298);
            this.splitContainerSearch.SplitterDistance = 120;
            this.splitContainerSearch.TabIndex = 5;
            // 
            // ucSearchProfileDetailed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.splitContainerSearch);
            this.Name = "ucSearchProfileDetailed";
            this.Size = new System.Drawing.Size(492, 298);
            this.Load += new System.EventHandler(this.ucSearchProfileDetailed_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucSearchProfileDetailed_KeyDown);
            this.splitContainerSearch.Panel1.ResumeLayout(false);
            this.splitContainerSearch.Panel1.PerformLayout();
            this.splitContainerSearch.Panel2.ResumeLayout(false);
            this.splitContainerSearch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblStar2Name;
        private MyCTS.Forms.UI.SmartTextBox txtStar2Name;
        private System.Windows.Forms.Label lblStar1Name;
        private MyCTS.Forms.UI.SmartTextBox txtStar1name;
        private System.Windows.Forms.Label lblPCC;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private System.Windows.Forms.ListView listViewProfiles;
        private System.Windows.Forms.ColumnHeader Stars;
        private System.Windows.Forms.ColumnHeader Level;
        private System.Windows.Forms.ImageList imageProfileList;
        private System.Windows.Forms.SplitContainer splitContainerSearch;
    }
}
