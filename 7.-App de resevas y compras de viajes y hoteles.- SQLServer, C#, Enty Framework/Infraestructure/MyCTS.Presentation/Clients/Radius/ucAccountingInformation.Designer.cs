namespace MyCTS.Presentation
{
    partial class ucAccountingInformation
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
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblClosePNR = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblEmployesNumber = new System.Windows.Forms.Label();
            this.lblCostCenter = new System.Windows.Forms.Label();
            this.txtEmployesNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.txtCostCenter = new MyCTS.Forms.UI.SmartTextBox();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.AutoScroll = true;
            this.TableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.TableLayoutPanel1.ColumnCount = 5;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.434525F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.37144F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.84353F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.77708F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.57342F));
            this.TableLayoutPanel1.Controls.Add(this.lblClosePNR, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.btnAccept, 3, 6);
            this.TableLayoutPanel1.Controls.Add(this.lblEmployesNumber, 1, 3);
            this.TableLayoutPanel1.Controls.Add(this.lblCostCenter, 1, 2);
            this.TableLayoutPanel1.Controls.Add(this.txtEmployesNumber, 2, 3);
            this.TableLayoutPanel1.Controls.Add(this.txtCostCenter, 2, 2);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 4;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.485171F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.46104F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.999137F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.999137F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.273304F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.63772F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.14449F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(411, 580);
            this.TableLayoutPanel1.TabIndex = 21;
            this.TableLayoutPanel1.TabStop = true;
            // 
            // lblClosePNR
            // 
            this.lblClosePNR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.TableLayoutPanel1.SetColumnSpan(this.lblClosePNR, 5);
            this.lblClosePNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClosePNR.ForeColor = System.Drawing.Color.White;
            this.lblClosePNR.Location = new System.Drawing.Point(3, 0);
            this.lblClosePNR.Name = "lblClosePNR";
            this.lblClosePNR.Size = new System.Drawing.Size(405, 15);
            this.lblClosePNR.TabIndex = 0;
            this.lblClosePNR.Text = "Información Cuentas Radius";
            this.lblClosePNR.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TableLayoutPanel1.SetColumnSpan(this.btnAccept, 2);
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(279, 231);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 24);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblEmployesNumber
            // 
            this.lblEmployesNumber.AutoSize = true;
            this.lblEmployesNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblEmployesNumber.ForeColor = System.Drawing.Color.Black;
            this.lblEmployesNumber.Location = new System.Drawing.Point(17, 74);
            this.lblEmployesNumber.Name = "lblEmployesNumber";
            this.lblEmployesNumber.Size = new System.Drawing.Size(109, 34);
            this.lblEmployesNumber.TabIndex = 0;
            this.lblEmployesNumber.Text = "Número de Empleado";
            this.lblEmployesNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCostCenter
            // 
            this.lblCostCenter.AutoSize = true;
            this.lblCostCenter.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCostCenter.Location = new System.Drawing.Point(17, 40);
            this.lblCostCenter.Name = "lblCostCenter";
            this.lblCostCenter.Size = new System.Drawing.Size(91, 34);
            this.lblCostCenter.TabIndex = 0;
            this.lblCostCenter.Text = "Centro de Costos:";
            this.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEmployesNumber
            // 
            this.txtEmployesNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmployesNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtEmployesNumber.CustomExpression = ".*";
            this.txtEmployesNumber.EnterColor = System.Drawing.Color.Empty;
            this.txtEmployesNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtEmployesNumber.Location = new System.Drawing.Point(182, 77);
            this.txtEmployesNumber.MaxLength = 8;
            this.txtEmployesNumber.Name = "txtEmployesNumber";
            this.txtEmployesNumber.Size = new System.Drawing.Size(91, 20);
            this.txtEmployesNumber.TabIndex = 2;
            this.txtEmployesNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtCostCenter
            // 
            this.txtCostCenter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCostCenter.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtCostCenter.CustomExpression = ".*";
            this.txtCostCenter.EnterColor = System.Drawing.Color.Empty;
            this.txtCostCenter.LeaveColor = System.Drawing.Color.Empty;
            this.txtCostCenter.Location = new System.Drawing.Point(182, 43);
            this.txtCostCenter.MaxLength = 8;
            this.txtCostCenter.Name = "txtCostCenter";
            this.txtCostCenter.Size = new System.Drawing.Size(91, 20);
            this.txtCostCenter.TabIndex = 1;
            this.txtCostCenter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucAccountingInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.TableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucAccountingInformation";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucAccountingInformation_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        private System.Windows.Forms.Label lblCostCenter;
        internal System.Windows.Forms.Label lblClosePNR;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtCostCenter;
        private MyCTS.Forms.UI.SmartTextBox txtEmployesNumber;
        private System.Windows.Forms.Label lblEmployesNumber;
    }
}
