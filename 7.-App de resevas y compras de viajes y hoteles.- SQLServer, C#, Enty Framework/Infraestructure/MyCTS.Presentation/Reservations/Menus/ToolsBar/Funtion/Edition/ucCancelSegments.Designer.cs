namespace MyCTS.Presentation
{
    partial class ucCancelSegments
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
            this.tblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblCancelSegments = new System.Windows.Forms.Label();
            this.lblCancelItinerary = new System.Windows.Forms.Label();
            this.txtSegmentFinish = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAl = new System.Windows.Forms.Label();
            this.lblCancelSegment = new System.Windows.Forms.Label();
            this.txtSegmentInitial = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.tblLayoutMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayoutMain
            // 
            this.tblLayoutMain.AutoScroll = true;
            this.tblLayoutMain.BackColor = System.Drawing.Color.White;
            this.tblLayoutMain.ColumnCount = 6;
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.167792F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.12048F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.21898F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.352798F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.49148F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.46715F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.Controls.Add(this.lblCancelSegments, 0, 0);
            this.tblLayoutMain.Controls.Add(this.lblCancelItinerary, 1, 2);
            this.tblLayoutMain.Controls.Add(this.txtSegmentFinish, 4, 4);
            this.tblLayoutMain.Controls.Add(this.lblAl, 3, 4);
            this.tblLayoutMain.Controls.Add(this.lblCancelSegment, 1, 4);
            this.tblLayoutMain.Controls.Add(this.txtSegmentInitial, 2, 4);
            this.tblLayoutMain.Controls.Add(this.btnAccept, 5, 6);
            this.tblLayoutMain.Controls.Add(this.btnNo, 3, 2);
            this.tblLayoutMain.Controls.Add(this.btnYes, 2, 2);
            this.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.tblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutMain.Name = "tblLayoutMain";
            this.tblLayoutMain.RowCount = 10;
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.931035F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.37931F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.862069F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.793103F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.655172F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.310345F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.7931F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.16949F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.830507F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.05085F));
            this.tblLayoutMain.Size = new System.Drawing.Size(411, 580);
            this.tblLayoutMain.TabIndex = 23;
            this.tblLayoutMain.TabStop = true;
            // 
            // lblCancelSegments
            // 
            this.lblCancelSegments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.tblLayoutMain.SetColumnSpan(this.lblCancelSegments, 6);
            this.lblCancelSegments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelSegments.ForeColor = System.Drawing.Color.White;
            this.lblCancelSegments.Location = new System.Drawing.Point(3, 0);
            this.lblCancelSegments.Name = "lblCancelSegments";
            this.lblCancelSegments.Size = new System.Drawing.Size(405, 14);
            this.lblCancelSegments.TabIndex = 0;
            this.lblCancelSegments.Text = "Cancelar Segmentos";
            this.lblCancelSegments.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCancelItinerary
            // 
            this.lblCancelItinerary.AutoSize = true;
            this.lblCancelItinerary.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCancelItinerary.ForeColor = System.Drawing.Color.Black;
            this.lblCancelItinerary.Location = new System.Drawing.Point(20, 25);
            this.lblCancelItinerary.Name = "lblCancelItinerary";
            this.lblCancelItinerary.Size = new System.Drawing.Size(104, 34);
            this.lblCancelItinerary.TabIndex = 0;
            this.lblCancelItinerary.Text = "¿Cancela Itinerario?:";
            this.lblCancelItinerary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSegmentFinish
            // 
            this.txtSegmentFinish.AllowBlankSpaces = true;
            this.txtSegmentFinish.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegmentFinish.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegmentFinish.CustomExpression = ".*";
            this.txtSegmentFinish.EnterColor = System.Drawing.Color.Empty;
            this.txtSegmentFinish.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegmentFinish.Location = new System.Drawing.Point(220, 84);
            this.txtSegmentFinish.MaxLength = 2;
            this.txtSegmentFinish.Name = "txtSegmentFinish";
            this.txtSegmentFinish.Size = new System.Drawing.Size(40, 20);
            this.txtSegmentFinish.TabIndex = 4;
            this.txtSegmentFinish.Visible = false;
            this.txtSegmentFinish.TextChanged += new System.EventHandler(this.txtSegmentFinish_TextChanged);
            this.txtSegmentFinish.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblAl
            // 
            this.lblAl.AutoSize = true;
            this.lblAl.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblAl.Location = new System.Drawing.Point(198, 81);
            this.lblAl.Name = "lblAl";
            this.lblAl.Size = new System.Drawing.Size(15, 27);
            this.lblAl.TabIndex = 10;
            this.lblAl.Text = "al";
            this.lblAl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAl.Visible = false;
            // 
            // lblCancelSegment
            // 
            this.lblCancelSegment.AutoSize = true;
            this.lblCancelSegment.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCancelSegment.Location = new System.Drawing.Point(20, 81);
            this.lblCancelSegment.Name = "lblCancelSegment";
            this.lblCancelSegment.Size = new System.Drawing.Size(116, 27);
            this.lblCancelSegment.TabIndex = 0;
            this.lblCancelSegment.Text = "Segmentos a cancelar:";
            this.lblCancelSegment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCancelSegment.Visible = false;
            // 
            // txtSegmentInitial
            // 
            this.txtSegmentInitial.AllowBlankSpaces = true;
            this.txtSegmentInitial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegmentInitial.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegmentInitial.CustomExpression = ".*";
            this.txtSegmentInitial.EnterColor = System.Drawing.Color.Empty;
            this.txtSegmentInitial.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegmentInitial.Location = new System.Drawing.Point(156, 84);
            this.txtSegmentInitial.MaxLength = 2;
            this.txtSegmentInitial.Name = "txtSegmentInitial";
            this.txtSegmentInitial.Size = new System.Drawing.Size(34, 20);
            this.txtSegmentInitial.TabIndex = 3;
            this.txtSegmentInitial.Visible = false;
            this.txtSegmentInitial.TextChanged += new System.EventHandler(this.txtSegmentInitial_TextChanged);
            this.txtSegmentInitial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(296, 165);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnNo
            // 
            this.tblLayoutMain.SetColumnSpan(this.btnNo, 2);
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Location = new System.Drawing.Point(198, 28);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(36, 28);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            this.btnNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnNo_KeyUp);
            this.btnNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnYes
            // 
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnYes.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Location = new System.Drawing.Point(156, 28);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(36, 28);
            this.btnYes.TabIndex = 1;
            this.btnYes.Text = "Si";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            this.btnYes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnYes_KeyUp);
            this.btnYes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucCancelSegments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tblLayoutMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucCancelSegments";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucCancelSegments_Load);
            this.tblLayoutMain.ResumeLayout(false);
            this.tblLayoutMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel tblLayoutMain;
        internal System.Windows.Forms.Label lblCancelSegments;
        private System.Windows.Forms.Label lblCancelSegment;
        private MyCTS.Forms.UI.SmartTextBox txtSegmentInitial;
        private MyCTS.Forms.UI.SmartTextBox txtSegmentFinish;
        private System.Windows.Forms.Label lblCancelItinerary;
        private System.Windows.Forms.Label lblAl;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
    }
}
