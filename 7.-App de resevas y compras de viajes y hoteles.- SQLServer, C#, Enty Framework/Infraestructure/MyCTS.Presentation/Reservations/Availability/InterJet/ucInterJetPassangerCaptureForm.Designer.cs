using System.Windows.Forms;

namespace MyCTS.Presentation
{
    partial class ucInterJetPassangerCaptureForm
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
            this.passangerGroupBox = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.secondLevelProfilePredictive = new System.Windows.Forms.ListBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.seconLevelProfileTextBox = new MyCTS.Forms.UI.SmartTextBox();
            this.passangerNationalityPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.nationalityComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.profilePredictivList = new System.Windows.Forms.ListBox();
            this.redDot = new System.Windows.Forms.Label();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backToAvailabilityButton = new System.Windows.Forms.Button();
            this.continueToPaymentButton = new System.Windows.Forms.Button();
            this.fristLevelProfileTextBox = new MyCTS.Forms.UI.SmartTextBox();
            this.fristLevelLabel = new System.Windows.Forms.Label();
            this.tblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.waitingLabel = new System.Windows.Forms.Label();
            this.profilePictureBox = new System.Windows.Forms.PictureBox();
            this.progressbar = new GradProg.GradProg();
            this.loadingPictureBox = new System.Windows.Forms.PictureBox();
            this.passangerGroupBox.SuspendLayout();
            this.passangerNationalityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.buttonsPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // passangerGroupBox
            // 
            this.passangerGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.passangerGroupBox.AutoSize = true;
            this.passangerGroupBox.Controls.Add(this.label8);
            this.passangerGroupBox.Controls.Add(this.secondLevelProfilePredictive);
            this.passangerGroupBox.Controls.Add(this.searchButton);
            this.passangerGroupBox.Controls.Add(this.seconLevelProfileTextBox);
            this.passangerGroupBox.Controls.Add(this.passangerNationalityPanel);
            this.passangerGroupBox.Controls.Add(this.label4);
            this.passangerGroupBox.Controls.Add(this.pictureBox1);
            this.passangerGroupBox.Controls.Add(this.profilePredictivList);
            this.passangerGroupBox.Controls.Add(this.redDot);
            this.passangerGroupBox.Controls.Add(this.buttonsPanel);
            this.passangerGroupBox.Controls.Add(this.fristLevelProfileTextBox);
            this.passangerGroupBox.Controls.Add(this.fristLevelLabel);
            this.passangerGroupBox.Location = new System.Drawing.Point(0, 22);
            this.passangerGroupBox.Name = "passangerGroupBox";
            this.passangerGroupBox.Size = new System.Drawing.Size(392, 476);
            this.passangerGroupBox.TabIndex = 0;
            this.passangerGroupBox.TabStop = false;
            this.passangerGroupBox.Text = "Pasajeros";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(148, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "*";
            // 
            // secondLevelProfilePredictive
            // 
            this.secondLevelProfilePredictive.DisplayMember = "Text";
            this.secondLevelProfilePredictive.FormattingEnabled = true;
            this.secondLevelProfilePredictive.Location = new System.Drawing.Point(190, 372);
            this.secondLevelProfilePredictive.Name = "secondLevelProfilePredictive";
            this.secondLevelProfilePredictive.Size = new System.Drawing.Size(120, 56);
            this.secondLevelProfilePredictive.TabIndex = 105;
            this.secondLevelProfilePredictive.ValueMember = "Value";
            this.secondLevelProfilePredictive.Visible = false;
            this.secondLevelProfilePredictive.MouseClick += new System.Windows.Forms.MouseEventHandler(this.secondLevelProfilePredictive_MouseClick);
            this.secondLevelProfilePredictive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.secondLevelProfilePredictive_KeyDown);
            // 
            // searchButton
            // 
            this.searchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.searchButton.Image = global::MyCTS.Presentation.Properties.Resources._1327964141_find;
            this.searchButton.Location = new System.Drawing.Point(354, 67);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(32, 23);
            this.searchButton.TabIndex = 11;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // seconLevelProfileTextBox
            // 
            this.seconLevelProfileTextBox.AllowBlankSpaces = true;
            this.seconLevelProfileTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.seconLevelProfileTextBox.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.seconLevelProfileTextBox.CustomExpression = ".*";
            this.seconLevelProfileTextBox.EnterColor = System.Drawing.Color.Empty;
            this.seconLevelProfileTextBox.LeaveColor = System.Drawing.Color.Empty;
            this.seconLevelProfileTextBox.Location = new System.Drawing.Point(171, 69);
            this.seconLevelProfileTextBox.Name = "seconLevelProfileTextBox";
            this.seconLevelProfileTextBox.Size = new System.Drawing.Size(177, 20);
            this.seconLevelProfileTextBox.TabIndex = 9;
            this.seconLevelProfileTextBox.TextChanged += new System.EventHandler(this.seconLevelProfileTextBox_TextChanged);
            this.seconLevelProfileTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.seconLevelProfileTextBox_KeyDown);
            // 
            // passangerNationalityPanel
            // 
            this.passangerNationalityPanel.Controls.Add(this.label2);
            this.passangerNationalityPanel.Controls.Add(this.nationalityComboBox);
            this.passangerNationalityPanel.Location = new System.Drawing.Point(3, 16);
            this.passangerNationalityPanel.Name = "passangerNationalityPanel";
            this.passangerNationalityPanel.Size = new System.Drawing.Size(349, 23);
            this.passangerNationalityPanel.TabIndex = 104;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nacionalidad de los Pasajeros:";
            // 
            // nationalityComboBox
            // 
            this.nationalityComboBox.FormattingEnabled = true;
            this.nationalityComboBox.Location = new System.Drawing.Point(169, 3);
            this.nationalityComboBox.Name = "nationalityComboBox";
            this.nationalityComboBox.Size = new System.Drawing.Size(121, 21);
            this.nationalityComboBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(22, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Perfil de Segundo Nivel :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MyCTS.Presentation.Properties.Resources.rsz_1327589390_search_2;
            this.pictureBox1.Location = new System.Drawing.Point(265, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 27);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // profilePredictivList
            // 
            this.profilePredictivList.DisplayMember = "Text";
            this.profilePredictivList.FormattingEnabled = true;
            this.profilePredictivList.Location = new System.Drawing.Point(64, 372);
            this.profilePredictivList.Name = "profilePredictivList";
            this.profilePredictivList.Size = new System.Drawing.Size(120, 56);
            this.profilePredictivList.TabIndex = 103;
            this.profilePredictivList.ValueMember = "Value";
            this.profilePredictivList.Visible = false;
            this.profilePredictivList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.profilePredictivList_MouseClick);
            this.profilePredictivList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.profilePredictivList_KeyDown);
            // 
            // redDot
            // 
            this.redDot.AutoSize = true;
            this.redDot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redDot.ForeColor = System.Drawing.Color.Red;
            this.redDot.Location = new System.Drawing.Point(148, 46);
            this.redDot.Name = "redDot";
            this.redDot.Size = new System.Drawing.Size(12, 13);
            this.redDot.TabIndex = 12;
            this.redDot.Text = "*";
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.label6);
            this.buttonsPanel.Controls.Add(this.label5);
            this.buttonsPanel.Controls.Add(this.label1);
            this.buttonsPanel.Controls.Add(this.backToAvailabilityButton);
            this.buttonsPanel.Controls.Add(this.continueToPaymentButton);
            this.buttonsPanel.Location = new System.Drawing.Point(11, 314);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(362, 52);
            this.buttonsPanel.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(170, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 102;
            this.label6.Text = "son obligatorios.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(161, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 101;
            this.label5.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Los campos marcados con ";
            // 
            // backToAvailabilityButton
            // 
            this.backToAvailabilityButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.backToAvailabilityButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backToAvailabilityButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backToAvailabilityButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backToAvailabilityButton.Location = new System.Drawing.Point(173, 19);
            this.backToAvailabilityButton.Name = "backToAvailabilityButton";
            this.backToAvailabilityButton.Size = new System.Drawing.Size(85, 23);
            this.backToAvailabilityButton.TabIndex = 19;
            this.backToAvailabilityButton.Text = "<Regresar";
            this.backToAvailabilityButton.UseVisualStyleBackColor = false;
            this.backToAvailabilityButton.Click += new System.EventHandler(this.backToAvailabilityButton_Click);
            this.backToAvailabilityButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.backToAvailabilityButton_KeyDown);
            // 
            // continueToPaymentButton
            // 
            this.continueToPaymentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.continueToPaymentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.continueToPaymentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueToPaymentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueToPaymentButton.Location = new System.Drawing.Point(264, 19);
            this.continueToPaymentButton.Name = "continueToPaymentButton";
            this.continueToPaymentButton.Size = new System.Drawing.Size(85, 23);
            this.continueToPaymentButton.TabIndex = 18;
            this.continueToPaymentButton.Text = "Continuar>";
            this.continueToPaymentButton.UseVisualStyleBackColor = false;
            this.continueToPaymentButton.Click += new System.EventHandler(this.captureContactButton_Click);
            this.continueToPaymentButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.continueToPaymentButton_KeyDown);
            // 
            // fristLevelProfileTextBox
            // 
            this.fristLevelProfileTextBox.AllowBlankSpaces = true;
            this.fristLevelProfileTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fristLevelProfileTextBox.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.fristLevelProfileTextBox.CustomExpression = ".*";
            this.fristLevelProfileTextBox.EnterColor = System.Drawing.Color.Empty;
            this.fristLevelProfileTextBox.LeaveColor = System.Drawing.Color.Empty;
            this.fristLevelProfileTextBox.Location = new System.Drawing.Point(171, 45);
            this.fristLevelProfileTextBox.Name = "fristLevelProfileTextBox";
            this.fristLevelProfileTextBox.Size = new System.Drawing.Size(121, 20);
            this.fristLevelProfileTextBox.TabIndex = 8;
            this.fristLevelProfileTextBox.TextChanged += new System.EventHandler(this.fristLevelProfileTextBox_TextChanged);
            this.fristLevelProfileTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fristLevelProfileTextBox_KeyDown);
            // 
            // fristLevelLabel
            // 
            this.fristLevelLabel.AutoSize = true;
            this.fristLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fristLevelLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fristLevelLabel.Location = new System.Drawing.Point(28, 47);
            this.fristLevelLabel.Name = "fristLevelLabel";
            this.fristLevelLabel.Size = new System.Drawing.Size(120, 12);
            this.fristLevelLabel.TabIndex = 6;
            this.fristLevelLabel.Text = "Perfil de Primer Nivel :";
            // 
            // tblLayoutMain
            // 
            this.tblLayoutMain.BackColor = System.Drawing.Color.White;
            this.tblLayoutMain.ColumnCount = 1;
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 411F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutMain.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayoutMain.Name = "tblLayoutMain";
            this.tblLayoutMain.RowCount = 1;
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.Size = new System.Drawing.Size(200, 100);
            this.tblLayoutMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 13);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Disponibilidad";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label19);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 16);
            this.panel1.TabIndex = 3;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(392, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Paso 3/8 - Captura Pasajeros";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // waitingLabel
            // 
            this.waitingLabel.AutoSize = true;
            this.waitingLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitingLabel.Location = new System.Drawing.Point(57, 292);
            this.waitingLabel.Name = "waitingLabel";
            this.waitingLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.waitingLabel.Size = new System.Drawing.Size(248, 14);
            this.waitingLabel.TabIndex = 101;
            this.waitingLabel.Text = "Obteniendo perfil espere por favor ..";
            this.waitingLabel.Visible = false;
            // 
            // profilePictureBox
            // 
            this.profilePictureBox.Image = global::MyCTS.Presentation.Properties.Resources._1327682501_People_MSN;
            this.profilePictureBox.Location = new System.Drawing.Point(111, 132);
            this.profilePictureBox.Name = "profilePictureBox";
            this.profilePictureBox.Size = new System.Drawing.Size(127, 147);
            this.profilePictureBox.TabIndex = 103;
            this.profilePictureBox.TabStop = false;
            this.profilePictureBox.Visible = false;
            // 
            // progressbar
            // 
            this.progressbar.BackColor = System.Drawing.Color.White;
            this.progressbar.GradientStyle = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.progressbar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.progressbar.LabelBackColour = System.Drawing.Color.DimGray;
            this.progressbar.LabelForeColour = System.Drawing.Color.LightSeaGreen;
            this.progressbar.LabelPosition = new System.Drawing.Point(0, 0);
            this.progressbar.Location = new System.Drawing.Point(6, 324);
            this.progressbar.Maximum = 100;
            this.progressbar.Minimum = 0;
            this.progressbar.Name = "progressbar";
            this.progressbar.Percentage = 0;
            this.progressbar.ProgressBarBackColour = System.Drawing.Color.White;
            this.progressbar.ProgressBarForeColour = System.Drawing.Color.SteelBlue;
            this.progressbar.ShowLabel = false;
            this.progressbar.Size = new System.Drawing.Size(367, 26);
            this.progressbar.TabIndex = 104;
            this.progressbar.Value = 0;
            this.progressbar.Visible = false;
            // 
            // loadingPictureBox
            // 
            this.loadingPictureBox.Image = global::MyCTS.Presentation.Properties.Resources.loadingBlue;
            this.loadingPictureBox.Location = new System.Drawing.Point(48, 309);
            this.loadingPictureBox.Name = "loadingPictureBox";
            this.loadingPictureBox.Size = new System.Drawing.Size(267, 28);
            this.loadingPictureBox.TabIndex = 108;
            this.loadingPictureBox.TabStop = false;
            this.loadingPictureBox.Visible = false;
            // 
            // ucInterJetPassangerCaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.loadingPictureBox);
            this.Controls.Add(this.progressbar);
            this.Controls.Add(this.profilePictureBox);
            this.Controls.Add(this.waitingLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.passangerGroupBox);
            this.Name = "ucInterJetPassangerCaptureForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Size = new System.Drawing.Size(654, 639);
            this.Load += new System.EventHandler(this.ucInterJetPassangerCaptureForm_Load);
            this.passangerGroupBox.ResumeLayout(false);
            this.passangerGroupBox.PerformLayout();
            this.passangerNationalityPanel.ResumeLayout(false);
            this.passangerNationalityPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.buttonsPanel.ResumeLayout(false);
            this.buttonsPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox passangerGroupBox;
        private System.Windows.Forms.TableLayoutPanel tblLayoutMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button backToAvailabilityButton;
        private System.Windows.Forms.Button continueToPaymentButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox nationalityComboBox;
        private System.Windows.Forms.Label label2;
        private MyCTS.Forms.UI.SmartTextBox seconLevelProfileTextBox;
        private MyCTS.Forms.UI.SmartTextBox fristLevelProfileTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label fristLevelLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label waitingLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Button searchButton;
        private Label label6;
        private Label label5;
        private PictureBox profilePictureBox;
        private GradProg.GradProg progressbar;
        private Label label8;
        private Label redDot;
        private PictureBox loadingPictureBox;
        private ListBox profilePredictivList;
        private Panel passangerNationalityPanel;
        private ListBox secondLevelProfilePredictive;
    }
}
