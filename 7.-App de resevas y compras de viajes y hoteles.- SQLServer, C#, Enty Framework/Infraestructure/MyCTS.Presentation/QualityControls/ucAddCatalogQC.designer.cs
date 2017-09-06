namespace MyCTS.Presentation
{
    partial class ucAddCatalogQC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAddCatalogQC));
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtDirectory = new MyCTS.Forms.UI.SmartTextBox();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.lblAttribute = new System.Windows.Forms.Label();
            this.txtAttribute = new MyCTS.Forms.UI.SmartTextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(291, 106);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitle.Size = new System.Drawing.Size(411, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Alta de nuevos catalogos de Quality Controls";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtDirectory
            // 
            this.txtDirectory.AllowBlankSpaces = true;
            this.txtDirectory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDirectory.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtDirectory.CustomExpression = ".*";
            this.txtDirectory.EnterColor = System.Drawing.Color.Empty;
            this.txtDirectory.LeaveColor = System.Drawing.Color.Empty;
            this.txtDirectory.Location = new System.Drawing.Point(61, 65);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(308, 20);
            this.txtDirectory.TabIndex = 2;
            this.txtDirectory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // picSearch
            // 
            this.picSearch.Image = ((System.Drawing.Image)(resources.GetObject("picSearch.Image")));
            this.picSearch.Location = new System.Drawing.Point(369, 64);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new System.Drawing.Size(22, 20);
            this.picSearch.TabIndex = 13;
            this.picSearch.TabStop = false;
            this.picSearch.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblAttribute
            // 
            this.lblAttribute.AutoSize = true;
            this.lblAttribute.Location = new System.Drawing.Point(3, 42);
            this.lblAttribute.Name = "lblAttribute";
            this.lblAttribute.Size = new System.Drawing.Size(52, 13);
            this.lblAttribute.TabIndex = 0;
            this.lblAttribute.Text = "Attribute1";
            // 
            // txtAttribute
            // 
            this.txtAttribute.AllowBlankSpaces = true;
            this.txtAttribute.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAttribute.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAttribute.CustomExpression = ".*";
            this.txtAttribute.EnterColor = System.Drawing.Color.Empty;
            this.txtAttribute.LeaveColor = System.Drawing.Color.Empty;
            this.txtAttribute.Location = new System.Drawing.Point(61, 39);
            this.txtAttribute.MaxLength = 6;
            this.txtAttribute.Name = "txtAttribute";
            this.txtAttribute.Size = new System.Drawing.Size(100, 20);
            this.txtAttribute.TabIndex = 1;
            this.txtAttribute.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(6, 68);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(43, 13);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "Archivo";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.Blue;
            this.lblDescription.Location = new System.Drawing.Point(9, 106);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(157, 13);
            this.lblDescription.TabIndex = 14;
            this.lblDescription.Text = "Tabla afectada: ClientsCatalogs";
            // 
            // ucAddCatalogQC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.txtAttribute);
            this.Controls.Add(this.lblAttribute);
            this.Controls.Add(this.picSearch);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucAddCatalogQC";
            this.Size = new System.Drawing.Size(411, 580);
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MyCTS.Forms.UI.SmartTextBox txtDirectory;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.Label lblAttribute;
        private MyCTS.Forms.UI.SmartTextBox txtAttribute;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblDescription;
    }
}
