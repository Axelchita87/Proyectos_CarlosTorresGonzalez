namespace MyCTS.Presentation
{
    partial class ucAdminQueuesProceso
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSelectOption = new System.Windows.Forms.Label();
            this.lblName1 = new System.Windows.Forms.Label();
            this.lblQueue1 = new System.Windows.Forms.Label();
            this.lblPCC1 = new System.Windows.Forms.Label();
            this.lblPicCode1 = new System.Windows.Forms.Label();
            this.txtQueue1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtQueue2 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPicCode2 = new System.Windows.Forms.Label();
            this.lblPCC2 = new System.Windows.Forms.Label();
            this.lblQueue2 = new System.Windows.Forms.Label();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.lblLine2 = new System.Windows.Forms.Label();
            this.lblName3 = new System.Windows.Forms.Label();
            this.txtQueue3 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPicCode3 = new System.Windows.Forms.Label();
            this.lblPCC3 = new System.Windows.Forms.Label();
            this.lblQueue3 = new System.Windows.Forms.Label();
            this.lblName4 = new System.Windows.Forms.Label();
            this.txtQueue4 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPicCode4 = new System.Windows.Forms.Label();
            this.lblPCC4 = new System.Windows.Forms.Label();
            this.lblQueue4 = new System.Windows.Forms.Label();
            this.lblLine3 = new System.Windows.Forms.Label();
            this.lblLine4 = new System.Windows.Forms.Label();
            this.lblName5 = new System.Windows.Forms.Label();
            this.txtQueue5 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPicCode5 = new System.Windows.Forms.Label();
            this.lblPCC5 = new System.Windows.Forms.Label();
            this.lblQueue5 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnAddQueue = new System.Windows.Forms.Button();
            this.txtName3 = new MyCTS.Forms.UI.SmartTextBox();
            this.chkDelete1 = new System.Windows.Forms.CheckBox();
            this.chkDelete2 = new System.Windows.Forms.CheckBox();
            this.chkDelete3 = new System.Windows.Forms.CheckBox();
            this.chkDelete4 = new System.Windows.Forms.CheckBox();
            this.chkDelete5 = new System.Windows.Forms.CheckBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.cmbPCC1 = new System.Windows.Forms.ComboBox();
            this.cmbPCC2 = new System.Windows.Forms.ComboBox();
            this.cmbPCC3 = new System.Windows.Forms.ComboBox();
            this.cmbPCC4 = new System.Windows.Forms.ComboBox();
            this.cmbPCC5 = new System.Windows.Forms.ComboBox();
            this.txtName4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtName5 = new MyCTS.Forms.UI.SmartTextBox();
            this.cmbPicCode1 = new System.Windows.Forms.ComboBox();
            this.cmbPicCode2 = new System.Windows.Forms.ComboBox();
            this.cmbPicCode3 = new System.Windows.Forms.ComboBox();
            this.cmbPicCode4 = new System.Windows.Forms.ComboBox();
            this.cmbPicCode5 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Administración de Queues - Herramientas Online";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSelectOption
            // 
            this.lblSelectOption.AutoSize = true;
            this.lblSelectOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectOption.ForeColor = System.Drawing.Color.Red;
            this.lblSelectOption.Location = new System.Drawing.Point(3, 26);
            this.lblSelectOption.Name = "lblSelectOption";
            this.lblSelectOption.Size = new System.Drawing.Size(137, 13);
            this.lblSelectOption.TabIndex = 0;
            this.lblSelectOption.Text = "Selecciona una opción";
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName1.Location = new System.Drawing.Point(5, 50);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(76, 13);
            this.lblName1.TabIndex = 0;
            this.lblName1.Text = "Confirmados";
            // 
            // lblQueue1
            // 
            this.lblQueue1.AutoSize = true;
            this.lblQueue1.Location = new System.Drawing.Point(18, 76);
            this.lblQueue1.Name = "lblQueue1";
            this.lblQueue1.Size = new System.Drawing.Size(39, 13);
            this.lblQueue1.TabIndex = 0;
            this.lblQueue1.Text = "Queue";
            this.lblQueue1.Visible = false;
            // 
            // lblPCC1
            // 
            this.lblPCC1.AutoSize = true;
            this.lblPCC1.Location = new System.Drawing.Point(72, 77);
            this.lblPCC1.Name = "lblPCC1";
            this.lblPCC1.Size = new System.Drawing.Size(28, 13);
            this.lblPCC1.TabIndex = 0;
            this.lblPCC1.Text = "PCC";
            this.lblPCC1.Visible = false;
            // 
            // lblPicCode1
            // 
            this.lblPicCode1.AutoSize = true;
            this.lblPicCode1.Location = new System.Drawing.Point(168, 75);
            this.lblPicCode1.Name = "lblPicCode1";
            this.lblPicCode1.Size = new System.Drawing.Size(47, 13);
            this.lblPicCode1.TabIndex = 0;
            this.lblPicCode1.Text = "PicCode";
            this.lblPicCode1.Visible = false;
            // 
            // txtQueue1
            // 
            this.txtQueue1.AllowBlankSpaces = true;
            this.txtQueue1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQueue1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtQueue1.CustomExpression = ".*";
            this.txtQueue1.EnterColor = System.Drawing.Color.Empty;
            this.txtQueue1.LeaveColor = System.Drawing.Color.Empty;
            this.txtQueue1.Location = new System.Drawing.Point(21, 93);
            this.txtQueue1.Name = "txtQueue1";
            this.txtQueue1.Size = new System.Drawing.Size(38, 20);
            this.txtQueue1.TabIndex = 1;
            this.txtQueue1.Visible = false;
            // 
            // txtQueue2
            // 
            this.txtQueue2.AllowBlankSpaces = true;
            this.txtQueue2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQueue2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtQueue2.CustomExpression = ".*";
            this.txtQueue2.EnterColor = System.Drawing.Color.Empty;
            this.txtQueue2.LeaveColor = System.Drawing.Color.Empty;
            this.txtQueue2.Location = new System.Drawing.Point(21, 179);
            this.txtQueue2.Name = "txtQueue2";
            this.txtQueue2.Size = new System.Drawing.Size(38, 20);
            this.txtQueue2.TabIndex = 5;
            this.txtQueue2.Visible = false;
            // 
            // lblPicCode2
            // 
            this.lblPicCode2.AutoSize = true;
            this.lblPicCode2.Location = new System.Drawing.Point(176, 163);
            this.lblPicCode2.Name = "lblPicCode2";
            this.lblPicCode2.Size = new System.Drawing.Size(47, 13);
            this.lblPicCode2.TabIndex = 0;
            this.lblPicCode2.Text = "PicCode";
            this.lblPicCode2.Visible = false;
            // 
            // lblPCC2
            // 
            this.lblPCC2.AutoSize = true;
            this.lblPCC2.Location = new System.Drawing.Point(72, 163);
            this.lblPCC2.Name = "lblPCC2";
            this.lblPCC2.Size = new System.Drawing.Size(28, 13);
            this.lblPCC2.TabIndex = 0;
            this.lblPCC2.Text = "PCC";
            this.lblPCC2.Visible = false;
            // 
            // lblQueue2
            // 
            this.lblQueue2.AutoSize = true;
            this.lblQueue2.Location = new System.Drawing.Point(18, 162);
            this.lblQueue2.Name = "lblQueue2";
            this.lblQueue2.Size = new System.Drawing.Size(39, 13);
            this.lblQueue2.TabIndex = 0;
            this.lblQueue2.Text = "Queue";
            this.lblQueue2.Visible = false;
            // 
            // lblLine1
            // 
            this.lblLine1.AutoSize = true;
            this.lblLine1.Location = new System.Drawing.Point(5, 116);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(385, 13);
            this.lblLine1.TabIndex = 0;
            this.lblLine1.Text = "_______________________________________________________________";
            this.lblLine1.Visible = false;
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName2.Location = new System.Drawing.Point(5, 137);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(70, 13);
            this.lblName2.TabIndex = 0;
            this.lblName2.Text = "Pendientes";
            // 
            // lblLine2
            // 
            this.lblLine2.AutoSize = true;
            this.lblLine2.Location = new System.Drawing.Point(5, 202);
            this.lblLine2.Name = "lblLine2";
            this.lblLine2.Size = new System.Drawing.Size(385, 13);
            this.lblLine2.TabIndex = 0;
            this.lblLine2.Text = "_______________________________________________________________";
            this.lblLine2.Visible = false;
            // 
            // lblName3
            // 
            this.lblName3.AutoSize = true;
            this.lblName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName3.Location = new System.Drawing.Point(5, 227);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(54, 13);
            this.lblName3.TabIndex = 0;
            this.lblName3.Text = "Nombre:";
            this.lblName3.Visible = false;
            // 
            // txtQueue3
            // 
            this.txtQueue3.AllowBlankSpaces = true;
            this.txtQueue3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQueue3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtQueue3.CustomExpression = ".*";
            this.txtQueue3.EnterColor = System.Drawing.Color.Empty;
            this.txtQueue3.LeaveColor = System.Drawing.Color.Empty;
            this.txtQueue3.Location = new System.Drawing.Point(21, 269);
            this.txtQueue3.Name = "txtQueue3";
            this.txtQueue3.Size = new System.Drawing.Size(38, 20);
            this.txtQueue3.TabIndex = 10;
            this.txtQueue3.Visible = false;
            // 
            // lblPicCode3
            // 
            this.lblPicCode3.AutoSize = true;
            this.lblPicCode3.Location = new System.Drawing.Point(176, 253);
            this.lblPicCode3.Name = "lblPicCode3";
            this.lblPicCode3.Size = new System.Drawing.Size(47, 13);
            this.lblPicCode3.TabIndex = 0;
            this.lblPicCode3.Text = "PicCode";
            this.lblPicCode3.Visible = false;
            // 
            // lblPCC3
            // 
            this.lblPCC3.AutoSize = true;
            this.lblPCC3.Location = new System.Drawing.Point(72, 253);
            this.lblPCC3.Name = "lblPCC3";
            this.lblPCC3.Size = new System.Drawing.Size(28, 13);
            this.lblPCC3.TabIndex = 0;
            this.lblPCC3.Text = "PCC";
            this.lblPCC3.Visible = false;
            // 
            // lblQueue3
            // 
            this.lblQueue3.AutoSize = true;
            this.lblQueue3.Location = new System.Drawing.Point(18, 252);
            this.lblQueue3.Name = "lblQueue3";
            this.lblQueue3.Size = new System.Drawing.Size(39, 13);
            this.lblQueue3.TabIndex = 0;
            this.lblQueue3.Text = "Queue";
            this.lblQueue3.Visible = false;
            // 
            // lblName4
            // 
            this.lblName4.AutoSize = true;
            this.lblName4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName4.Location = new System.Drawing.Point(5, 314);
            this.lblName4.Name = "lblName4";
            this.lblName4.Size = new System.Drawing.Size(54, 13);
            this.lblName4.TabIndex = 0;
            this.lblName4.Text = "Nombre:";
            this.lblName4.Visible = false;
            // 
            // txtQueue4
            // 
            this.txtQueue4.AllowBlankSpaces = true;
            this.txtQueue4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQueue4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtQueue4.CustomExpression = ".*";
            this.txtQueue4.EnterColor = System.Drawing.Color.Empty;
            this.txtQueue4.LeaveColor = System.Drawing.Color.Empty;
            this.txtQueue4.Location = new System.Drawing.Point(21, 356);
            this.txtQueue4.Name = "txtQueue4";
            this.txtQueue4.Size = new System.Drawing.Size(38, 20);
            this.txtQueue4.TabIndex = 15;
            this.txtQueue4.Visible = false;
            // 
            // lblPicCode4
            // 
            this.lblPicCode4.AutoSize = true;
            this.lblPicCode4.Location = new System.Drawing.Point(176, 340);
            this.lblPicCode4.Name = "lblPicCode4";
            this.lblPicCode4.Size = new System.Drawing.Size(47, 13);
            this.lblPicCode4.TabIndex = 0;
            this.lblPicCode4.Text = "PicCode";
            this.lblPicCode4.Visible = false;
            // 
            // lblPCC4
            // 
            this.lblPCC4.AutoSize = true;
            this.lblPCC4.Location = new System.Drawing.Point(72, 340);
            this.lblPCC4.Name = "lblPCC4";
            this.lblPCC4.Size = new System.Drawing.Size(28, 13);
            this.lblPCC4.TabIndex = 0;
            this.lblPCC4.Text = "PCC";
            this.lblPCC4.Visible = false;
            // 
            // lblQueue4
            // 
            this.lblQueue4.AutoSize = true;
            this.lblQueue4.Location = new System.Drawing.Point(18, 339);
            this.lblQueue4.Name = "lblQueue4";
            this.lblQueue4.Size = new System.Drawing.Size(39, 13);
            this.lblQueue4.TabIndex = 0;
            this.lblQueue4.Text = "Queue";
            this.lblQueue4.Visible = false;
            // 
            // lblLine3
            // 
            this.lblLine3.AutoSize = true;
            this.lblLine3.Location = new System.Drawing.Point(5, 292);
            this.lblLine3.Name = "lblLine3";
            this.lblLine3.Size = new System.Drawing.Size(385, 13);
            this.lblLine3.TabIndex = 0;
            this.lblLine3.Text = "_______________________________________________________________";
            this.lblLine3.Visible = false;
            // 
            // lblLine4
            // 
            this.lblLine4.AutoSize = true;
            this.lblLine4.Location = new System.Drawing.Point(5, 379);
            this.lblLine4.Name = "lblLine4";
            this.lblLine4.Size = new System.Drawing.Size(385, 13);
            this.lblLine4.TabIndex = 0;
            this.lblLine4.Text = "_______________________________________________________________";
            this.lblLine4.Visible = false;
            // 
            // lblName5
            // 
            this.lblName5.AutoSize = true;
            this.lblName5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName5.Location = new System.Drawing.Point(5, 401);
            this.lblName5.Name = "lblName5";
            this.lblName5.Size = new System.Drawing.Size(54, 13);
            this.lblName5.TabIndex = 0;
            this.lblName5.Text = "Nombre:";
            this.lblName5.Visible = false;
            // 
            // txtQueue5
            // 
            this.txtQueue5.AllowBlankSpaces = true;
            this.txtQueue5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQueue5.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtQueue5.CustomExpression = ".*";
            this.txtQueue5.EnterColor = System.Drawing.Color.Empty;
            this.txtQueue5.LeaveColor = System.Drawing.Color.Empty;
            this.txtQueue5.Location = new System.Drawing.Point(21, 443);
            this.txtQueue5.Name = "txtQueue5";
            this.txtQueue5.Size = new System.Drawing.Size(38, 20);
            this.txtQueue5.TabIndex = 20;
            this.txtQueue5.Visible = false;
            // 
            // lblPicCode5
            // 
            this.lblPicCode5.AutoSize = true;
            this.lblPicCode5.Location = new System.Drawing.Point(176, 427);
            this.lblPicCode5.Name = "lblPicCode5";
            this.lblPicCode5.Size = new System.Drawing.Size(47, 13);
            this.lblPicCode5.TabIndex = 0;
            this.lblPicCode5.Text = "PicCode";
            this.lblPicCode5.Visible = false;
            // 
            // lblPCC5
            // 
            this.lblPCC5.AutoSize = true;
            this.lblPCC5.Location = new System.Drawing.Point(72, 427);
            this.lblPCC5.Name = "lblPCC5";
            this.lblPCC5.Size = new System.Drawing.Size(28, 13);
            this.lblPCC5.TabIndex = 0;
            this.lblPCC5.Text = "PCC";
            this.lblPCC5.Visible = false;
            // 
            // lblQueue5
            // 
            this.lblQueue5.AutoSize = true;
            this.lblQueue5.Location = new System.Drawing.Point(18, 426);
            this.lblQueue5.Name = "lblQueue5";
            this.lblQueue5.Size = new System.Drawing.Size(39, 13);
            this.lblQueue5.TabIndex = 0;
            this.lblQueue5.Text = "Queue";
            this.lblQueue5.Visible = false;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(278, 498);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 25;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnAddQueue
            // 
            this.btnAddQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAddQueue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddQueue.Location = new System.Drawing.Point(153, 498);
            this.btnAddQueue.Name = "btnAddQueue";
            this.btnAddQueue.Size = new System.Drawing.Size(100, 23);
            this.btnAddQueue.TabIndex = 24;
            this.btnAddQueue.Text = "Agregar Queue";
            this.btnAddQueue.UseVisualStyleBackColor = false;
            this.btnAddQueue.Click += new System.EventHandler(this.btnAddQueue_Click);
            // 
            // txtName3
            // 
            this.txtName3.AllowBlankSpaces = true;
            this.txtName3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtName3.CustomExpression = ".*";
            this.txtName3.EnterColor = System.Drawing.Color.Empty;
            this.txtName3.LeaveColor = System.Drawing.Color.Empty;
            this.txtName3.Location = new System.Drawing.Point(75, 224);
            this.txtName3.Name = "txtName3";
            this.txtName3.Size = new System.Drawing.Size(100, 20);
            this.txtName3.TabIndex = 9;
            this.txtName3.Visible = false;
            // 
            // chkDelete1
            // 
            this.chkDelete1.AutoSize = true;
            this.chkDelete1.Location = new System.Drawing.Point(334, 93);
            this.chkDelete1.Name = "chkDelete1";
            this.chkDelete1.Size = new System.Drawing.Size(62, 17);
            this.chkDelete1.TabIndex = 4;
            this.chkDelete1.Text = "Eliminar";
            this.chkDelete1.UseVisualStyleBackColor = true;
            this.chkDelete1.Visible = false;
            // 
            // chkDelete2
            // 
            this.chkDelete2.AutoSize = true;
            this.chkDelete2.Location = new System.Drawing.Point(334, 179);
            this.chkDelete2.Name = "chkDelete2";
            this.chkDelete2.Size = new System.Drawing.Size(62, 17);
            this.chkDelete2.TabIndex = 8;
            this.chkDelete2.Text = "Eliminar";
            this.chkDelete2.UseVisualStyleBackColor = true;
            this.chkDelete2.Visible = false;
            // 
            // chkDelete3
            // 
            this.chkDelete3.AutoSize = true;
            this.chkDelete3.Location = new System.Drawing.Point(334, 269);
            this.chkDelete3.Name = "chkDelete3";
            this.chkDelete3.Size = new System.Drawing.Size(62, 17);
            this.chkDelete3.TabIndex = 13;
            this.chkDelete3.Text = "Eliminar";
            this.chkDelete3.UseVisualStyleBackColor = true;
            this.chkDelete3.Visible = false;
            // 
            // chkDelete4
            // 
            this.chkDelete4.AutoSize = true;
            this.chkDelete4.Location = new System.Drawing.Point(334, 356);
            this.chkDelete4.Name = "chkDelete4";
            this.chkDelete4.Size = new System.Drawing.Size(62, 17);
            this.chkDelete4.TabIndex = 18;
            this.chkDelete4.Text = "Eliminar";
            this.chkDelete4.UseVisualStyleBackColor = true;
            this.chkDelete4.Visible = false;
            // 
            // chkDelete5
            // 
            this.chkDelete5.AutoSize = true;
            this.chkDelete5.Location = new System.Drawing.Point(334, 443);
            this.chkDelete5.Name = "chkDelete5";
            this.chkDelete5.Size = new System.Drawing.Size(62, 17);
            this.chkDelete5.TabIndex = 23;
            this.chkDelete5.Text = "Eliminar";
            this.chkDelete5.UseVisualStyleBackColor = true;
            this.chkDelete5.Visible = false;
            // 
            // cmbPCC1
            // 
            this.cmbPCC1.DisplayMember = "Text";
            this.cmbPCC1.FormattingEnabled = true;
            this.cmbPCC1.Location = new System.Drawing.Point(75, 91);
            this.cmbPCC1.Name = "cmbPCC1";
            this.cmbPCC1.Size = new System.Drawing.Size(86, 21);
            this.cmbPCC1.TabIndex = 2;
            this.cmbPCC1.ValueMember = "Value";
            this.cmbPCC1.Visible = false;
            this.cmbPCC1.SelectedIndexChanged += new System.EventHandler(this.cmbPicCodeGeneric_SelectedIndexChanged);
            // 
            // cmbPCC2
            // 
            this.cmbPCC2.DisplayMember = "Text";
            this.cmbPCC2.FormattingEnabled = true;
            this.cmbPCC2.Location = new System.Drawing.Point(75, 179);
            this.cmbPCC2.Name = "cmbPCC2";
            this.cmbPCC2.Size = new System.Drawing.Size(86, 21);
            this.cmbPCC2.TabIndex = 6;
            this.cmbPCC2.ValueMember = "Value";
            this.cmbPCC2.Visible = false;
            this.cmbPCC2.SelectedIndexChanged += new System.EventHandler(this.cmbPicCodeGeneric_SelectedIndexChanged);
            // 
            // cmbPCC3
            // 
            this.cmbPCC3.DisplayMember = "Text";
            this.cmbPCC3.FormattingEnabled = true;
            this.cmbPCC3.Location = new System.Drawing.Point(75, 269);
            this.cmbPCC3.Name = "cmbPCC3";
            this.cmbPCC3.Size = new System.Drawing.Size(86, 21);
            this.cmbPCC3.TabIndex = 11;
            this.cmbPCC3.ValueMember = "Value";
            this.cmbPCC3.Visible = false;
            this.cmbPCC3.SelectedIndexChanged += new System.EventHandler(this.cmbPicCodeGeneric_SelectedIndexChanged);
            // 
            // cmbPCC4
            // 
            this.cmbPCC4.DisplayMember = "Text";
            this.cmbPCC4.FormattingEnabled = true;
            this.cmbPCC4.Location = new System.Drawing.Point(75, 356);
            this.cmbPCC4.Name = "cmbPCC4";
            this.cmbPCC4.Size = new System.Drawing.Size(86, 21);
            this.cmbPCC4.TabIndex = 16;
            this.cmbPCC4.ValueMember = "Value";
            this.cmbPCC4.Visible = false;
            this.cmbPCC4.SelectedIndexChanged += new System.EventHandler(this.cmbPicCodeGeneric_SelectedIndexChanged);
            // 
            // cmbPCC5
            // 
            this.cmbPCC5.DisplayMember = "Text";
            this.cmbPCC5.FormattingEnabled = true;
            this.cmbPCC5.Location = new System.Drawing.Point(75, 443);
            this.cmbPCC5.Name = "cmbPCC5";
            this.cmbPCC5.Size = new System.Drawing.Size(86, 21);
            this.cmbPCC5.TabIndex = 21;
            this.cmbPCC5.ValueMember = "Value";
            this.cmbPCC5.Visible = false;
            this.cmbPCC5.SelectedIndexChanged += new System.EventHandler(this.cmbPicCodeGeneric_SelectedIndexChanged);
            // 
            // txtName4
            // 
            this.txtName4.AllowBlankSpaces = true;
            this.txtName4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtName4.CustomExpression = ".*";
            this.txtName4.EnterColor = System.Drawing.Color.Empty;
            this.txtName4.LeaveColor = System.Drawing.Color.Empty;
            this.txtName4.Location = new System.Drawing.Point(75, 314);
            this.txtName4.Name = "txtName4";
            this.txtName4.Size = new System.Drawing.Size(100, 20);
            this.txtName4.TabIndex = 14;
            this.txtName4.Visible = false;
            // 
            // txtName5
            // 
            this.txtName5.AllowBlankSpaces = true;
            this.txtName5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName5.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtName5.CustomExpression = ".*";
            this.txtName5.EnterColor = System.Drawing.Color.Empty;
            this.txtName5.LeaveColor = System.Drawing.Color.Empty;
            this.txtName5.Location = new System.Drawing.Point(75, 398);
            this.txtName5.Name = "txtName5";
            this.txtName5.Size = new System.Drawing.Size(100, 20);
            this.txtName5.TabIndex = 19;
            this.txtName5.Visible = false;
            // 
            // cmbPicCode1
            // 
            this.cmbPicCode1.DisplayMember = "Text";
            this.cmbPicCode1.FormattingEnabled = true;
            this.cmbPicCode1.Location = new System.Drawing.Point(167, 91);
            this.cmbPicCode1.Name = "cmbPicCode1";
            this.cmbPicCode1.Size = new System.Drawing.Size(161, 21);
            this.cmbPicCode1.TabIndex = 3;
            this.cmbPicCode1.ValueMember = "Value";
            this.cmbPicCode1.Visible = false;
            this.cmbPicCode1.SelectedIndexChanged += new System.EventHandler(this.cmbPicCodeGeneric_SelectedIndexChanged);
            // 
            // cmbPicCode2
            // 
            this.cmbPicCode2.DisplayMember = "Text";
            this.cmbPicCode2.FormattingEnabled = true;
            this.cmbPicCode2.Location = new System.Drawing.Point(167, 179);
            this.cmbPicCode2.Name = "cmbPicCode2";
            this.cmbPicCode2.Size = new System.Drawing.Size(161, 21);
            this.cmbPicCode2.TabIndex = 7;
            this.cmbPicCode2.ValueMember = "Value";
            this.cmbPicCode2.Visible = false;
            this.cmbPicCode2.SelectedIndexChanged += new System.EventHandler(this.cmbPicCodeGeneric_SelectedIndexChanged);
            // 
            // cmbPicCode3
            // 
            this.cmbPicCode3.DisplayMember = "Text";
            this.cmbPicCode3.FormattingEnabled = true;
            this.cmbPicCode3.Location = new System.Drawing.Point(167, 268);
            this.cmbPicCode3.Name = "cmbPicCode3";
            this.cmbPicCode3.Size = new System.Drawing.Size(161, 21);
            this.cmbPicCode3.TabIndex = 12;
            this.cmbPicCode3.ValueMember = "Value";
            this.cmbPicCode3.Visible = false;
            this.cmbPicCode3.SelectedIndexChanged += new System.EventHandler(this.cmbPicCodeGeneric_SelectedIndexChanged);
            // 
            // cmbPicCode4
            // 
            this.cmbPicCode4.DisplayMember = "Text";
            this.cmbPicCode4.FormattingEnabled = true;
            this.cmbPicCode4.Location = new System.Drawing.Point(167, 356);
            this.cmbPicCode4.Name = "cmbPicCode4";
            this.cmbPicCode4.Size = new System.Drawing.Size(161, 21);
            this.cmbPicCode4.TabIndex = 17;
            this.cmbPicCode4.ValueMember = "Value";
            this.cmbPicCode4.Visible = false;
            this.cmbPicCode4.SelectedIndexChanged += new System.EventHandler(this.cmbPicCodeGeneric_SelectedIndexChanged);
            // 
            // cmbPicCode5
            // 
            this.cmbPicCode5.DisplayMember = "Text";
            this.cmbPicCode5.FormattingEnabled = true;
            this.cmbPicCode5.Location = new System.Drawing.Point(167, 443);
            this.cmbPicCode5.Name = "cmbPicCode5";
            this.cmbPicCode5.Size = new System.Drawing.Size(161, 21);
            this.cmbPicCode5.TabIndex = 22;
            this.cmbPicCode5.ValueMember = "Value";
            this.cmbPicCode5.Visible = false;
            this.cmbPicCode5.SelectedIndexChanged += new System.EventHandler(this.cmbPicCodeGeneric_SelectedIndexChanged);
            // 
            // ucAdminQueuesProceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmbPicCode5);
            this.Controls.Add(this.cmbPicCode4);
            this.Controls.Add(this.cmbPicCode3);
            this.Controls.Add(this.cmbPicCode2);
            this.Controls.Add(this.cmbPicCode1);
            this.Controls.Add(this.txtName5);
            this.Controls.Add(this.txtName4);
            this.Controls.Add(this.cmbPCC5);
            this.Controls.Add(this.cmbPCC4);
            this.Controls.Add(this.cmbPCC3);
            this.Controls.Add(this.cmbPCC2);
            this.Controls.Add(this.cmbPCC1);
            this.Controls.Add(this.chkDelete5);
            this.Controls.Add(this.chkDelete4);
            this.Controls.Add(this.chkDelete3);
            this.Controls.Add(this.chkDelete2);
            this.Controls.Add(this.chkDelete1);
            this.Controls.Add(this.txtName3);
            this.Controls.Add(this.btnAddQueue);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblName5);
            this.Controls.Add(this.txtQueue5);
            this.Controls.Add(this.lblPicCode5);
            this.Controls.Add(this.lblPCC5);
            this.Controls.Add(this.lblQueue5);
            this.Controls.Add(this.lblLine4);
            this.Controls.Add(this.lblLine3);
            this.Controls.Add(this.lblName4);
            this.Controls.Add(this.txtQueue4);
            this.Controls.Add(this.lblPicCode4);
            this.Controls.Add(this.lblPCC4);
            this.Controls.Add(this.lblQueue4);
            this.Controls.Add(this.lblName3);
            this.Controls.Add(this.txtQueue3);
            this.Controls.Add(this.lblPicCode3);
            this.Controls.Add(this.lblPCC3);
            this.Controls.Add(this.lblQueue3);
            this.Controls.Add(this.lblLine2);
            this.Controls.Add(this.lblName2);
            this.Controls.Add(this.lblLine1);
            this.Controls.Add(this.txtQueue2);
            this.Controls.Add(this.lblPicCode2);
            this.Controls.Add(this.lblPCC2);
            this.Controls.Add(this.lblQueue2);
            this.Controls.Add(this.txtQueue1);
            this.Controls.Add(this.lblPicCode1);
            this.Controls.Add(this.lblPCC1);
            this.Controls.Add(this.lblQueue1);
            this.Controls.Add(this.lblName1);
            this.Controls.Add(this.lblSelectOption);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucAdminQueuesProceso";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucAdminQueuesProceso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSelectOption;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Label lblQueue1;
        private System.Windows.Forms.Label lblPCC1;
        private System.Windows.Forms.Label lblPicCode1;
        private Forms.UI.SmartTextBox txtQueue1;
        private Forms.UI.SmartTextBox txtQueue2;
        private System.Windows.Forms.Label lblPicCode2;
        private System.Windows.Forms.Label lblPCC2;
        private System.Windows.Forms.Label lblQueue2;
        private System.Windows.Forms.Label lblLine1;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label lblLine2;
        private System.Windows.Forms.Label lblName3;
        private Forms.UI.SmartTextBox txtQueue3;
        private System.Windows.Forms.Label lblPicCode3;
        private System.Windows.Forms.Label lblPCC3;
        private System.Windows.Forms.Label lblQueue3;
        private System.Windows.Forms.Label lblName4;
        private Forms.UI.SmartTextBox txtQueue4;
        private System.Windows.Forms.Label lblPicCode4;
        private System.Windows.Forms.Label lblPCC4;
        private System.Windows.Forms.Label lblQueue4;
        private System.Windows.Forms.Label lblLine3;
        private System.Windows.Forms.Label lblLine4;
        private System.Windows.Forms.Label lblName5;
        private Forms.UI.SmartTextBox txtQueue5;
        private System.Windows.Forms.Label lblPicCode5;
        private System.Windows.Forms.Label lblPCC5;
        private System.Windows.Forms.Label lblQueue5;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnAddQueue;
        private Forms.UI.SmartTextBox txtName3;
        private System.Windows.Forms.CheckBox chkDelete1;
        private System.Windows.Forms.CheckBox chkDelete2;
        private System.Windows.Forms.CheckBox chkDelete3;
        private System.Windows.Forms.CheckBox chkDelete4;
        private System.Windows.Forms.CheckBox chkDelete5;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.ComboBox cmbPCC1;
        private System.Windows.Forms.ComboBox cmbPCC2;
        private System.Windows.Forms.ComboBox cmbPCC3;
        private System.Windows.Forms.ComboBox cmbPCC4;
        private System.Windows.Forms.ComboBox cmbPCC5;
        private Forms.UI.SmartTextBox txtName4;
        private Forms.UI.SmartTextBox txtName5;
        private System.Windows.Forms.ComboBox cmbPicCode1;
        private System.Windows.Forms.ComboBox cmbPicCode2;
        private System.Windows.Forms.ComboBox cmbPicCode3;
        private System.Windows.Forms.ComboBox cmbPicCode4;
        private System.Windows.Forms.ComboBox cmbPicCode5;
    }
}
