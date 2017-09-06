namespace MyCTS.Presentation.Components
{
    partial class frmEditStarLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditStarLine));
            this.btnOK = new System.Windows.Forms.Button();
            this.txtEditLine = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnAddChange = new System.Windows.Forms.Button();
            this.btnAddCross = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(316, 81);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtEditLine
            // 
            this.txtEditLine.AllowBlankSpaces = true;
            this.txtEditLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEditLine.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtEditLine.CustomExpression = ".*";
            this.txtEditLine.EnterColor = System.Drawing.Color.Empty;
            this.txtEditLine.LeaveColor = System.Drawing.Color.Empty;
            this.txtEditLine.Location = new System.Drawing.Point(12, 43);
            this.txtEditLine.MaxLength = 65;
            this.txtEditLine.Name = "txtEditLine";
            this.txtEditLine.Size = new System.Drawing.Size(404, 20);
            this.txtEditLine.TabIndex = 1;
            this.txtEditLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.White;
            this.lblDescription.Location = new System.Drawing.Point(12, 18);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(172, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Ingresa el Nuevo Valor de la Línea";
            // 
            // btnAddChange
            // 
            this.btnAddChange.BackColor = System.Drawing.Color.Crimson;
            this.btnAddChange.ForeColor = System.Drawing.Color.White;
            this.btnAddChange.Location = new System.Drawing.Point(12, 81);
            this.btnAddChange.Name = "btnAddChange";
            this.btnAddChange.Size = new System.Drawing.Size(75, 23);
            this.btnAddChange.TabIndex = 2;
            this.btnAddChange.Text = "Agrega ¤";
            this.btnAddChange.UseVisualStyleBackColor = false;
            this.btnAddChange.Click += new System.EventHandler(this.btnAddChange_Click);
            // 
            // btnAddCross
            // 
            this.btnAddCross.BackColor = System.Drawing.Color.BlueViolet;
            this.btnAddCross.ForeColor = System.Drawing.Color.White;
            this.btnAddCross.Location = new System.Drawing.Point(93, 81);
            this.btnAddCross.Name = "btnAddCross";
            this.btnAddCross.Size = new System.Drawing.Size(75, 23);
            this.btnAddCross.TabIndex = 3;
            this.btnAddCross.Text = "Agrega ‡";
            this.btnAddCross.UseVisualStyleBackColor = false;
            this.btnAddCross.Click += new System.EventHandler(this.btnAddCross_Click);
            // 
            // frmEditStarLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(428, 151);
            this.Controls.Add(this.btnAddCross);
            this.Controls.Add(this.btnAddChange);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtEditLine);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditStarLine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edita Contenido de Estrella";
            this.Load += new System.EventHandler(this.frmEditStarLine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private MyCTS.Forms.UI.SmartTextBox txtEditLine;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnAddChange;
        private System.Windows.Forms.Button btnAddCross;
    }
}