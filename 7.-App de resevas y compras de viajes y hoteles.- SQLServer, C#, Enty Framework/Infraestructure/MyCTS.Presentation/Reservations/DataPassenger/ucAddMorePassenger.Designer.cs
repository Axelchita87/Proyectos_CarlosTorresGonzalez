using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    partial class ucAddMorePassenger
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
            this.lblAddPassenger1 = new System.Windows.Forms.Label();
            this.txtName1B = new MyCTS.Forms.UI.SmartTextBox();
            this.txtEmail1c = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLastName2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtName2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtEmail2c = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLastName3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtName3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtEmail3c = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLastName4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtName4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtEmail4c = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLastName5 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtName5 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtEmail5c = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLastName6 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtName6 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtEmail6c = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLastName7 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtName7 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtEmail7c = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLastName8 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtName8 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtEmail8c = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblAddMorePassenger = new System.Windows.Forms.Label();
            this.txtLastName1A = new MyCTS.Forms.UI.SmartTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAddPassenger1
            // 
            this.lblAddPassenger1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblAddPassenger1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddPassenger1.ForeColor = System.Drawing.Color.White;
            this.lblAddPassenger1.Location = new System.Drawing.Point(0, 0);
            this.lblAddPassenger1.Name = "lblAddPassenger1";
            this.lblAddPassenger1.Size = new System.Drawing.Size(568, 25);
            this.lblAddPassenger1.TabIndex = 0;
            this.lblAddPassenger1.Text = "Agregar más Pasajeros";
            this.lblAddPassenger1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAddPassenger1.Click += new System.EventHandler(this.lblAddPassenger1_Click);
            // 
            // txtName1B
            // 
            this.txtName1B.AllowBlankSpaces = true;
            this.txtName1B.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName1B.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtName1B.CustomExpression = ".*";
            this.txtName1B.EnterColor = System.Drawing.Color.Empty;
            this.txtName1B.LeaveColor = System.Drawing.Color.Empty;
            this.txtName1B.Location = new System.Drawing.Point(219, 148);
            this.txtName1B.MaxLength = 25;
            this.txtName1B.Name = "txtName1B";
            this.txtName1B.NextControl = this.txtEmail1c;
            this.txtName1B.Size = new System.Drawing.Size(143, 20);
            this.txtName1B.TabIndex = 4;
            this.txtName1B.Visible = false;
            this.txtName1B.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtName1B.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtEmail1c
            // 
            this.txtEmail1c.AllowBlankSpaces = true;
            this.txtEmail1c.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail1c.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtEmail1c.CustomExpression = ".*";
            this.txtEmail1c.EnterColor = System.Drawing.Color.Empty;
            this.txtEmail1c.LeaveColor = System.Drawing.Color.Empty;
            this.txtEmail1c.Location = new System.Drawing.Point(410, 148);
            this.txtEmail1c.MaxLength = 60;
            this.txtEmail1c.Name = "txtEmail1c";
            this.txtEmail1c.NextControl = this.txtLastName2;
            this.txtEmail1c.Size = new System.Drawing.Size(140, 20);
            this.txtEmail1c.TabIndex = 5;
            this.txtEmail1c.Visible = false;
            this.txtEmail1c.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtLastName2
            // 
            this.txtLastName2.AllowBlankSpaces = true;
            this.txtLastName2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtLastName2.CustomExpression = ".*";
            this.txtLastName2.EnterColor = System.Drawing.Color.Empty;
            this.txtLastName2.LeaveColor = System.Drawing.Color.Empty;
            this.txtLastName2.Location = new System.Drawing.Point(25, 179);
            this.txtLastName2.MaxLength = 60;
            this.txtLastName2.Name = "txtLastName2";
            this.txtLastName2.NextControl = this.txtName2;
            this.txtLastName2.Size = new System.Drawing.Size(145, 20);
            this.txtLastName2.TabIndex = 6;
            this.txtLastName2.Visible = false;
            this.txtLastName2.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtLastName2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtName2
            // 
            this.txtName2.AllowBlankSpaces = true;
            this.txtName2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtName2.CustomExpression = ".*";
            this.txtName2.EnterColor = System.Drawing.Color.Empty;
            this.txtName2.LeaveColor = System.Drawing.Color.Empty;
            this.txtName2.Location = new System.Drawing.Point(219, 179);
            this.txtName2.MaxLength = 25;
            this.txtName2.Name = "txtName2";
            this.txtName2.NextControl = this.txtEmail2c;
            this.txtName2.Size = new System.Drawing.Size(143, 20);
            this.txtName2.TabIndex = 7;
            this.txtName2.Visible = false;
            this.txtName2.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtName2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtEmail2c
            // 
            this.txtEmail2c.AllowBlankSpaces = true;
            this.txtEmail2c.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail2c.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtEmail2c.CustomExpression = ".*";
            this.txtEmail2c.EnterColor = System.Drawing.Color.Empty;
            this.txtEmail2c.LeaveColor = System.Drawing.Color.Empty;
            this.txtEmail2c.Location = new System.Drawing.Point(410, 179);
            this.txtEmail2c.MaxLength = 60;
            this.txtEmail2c.Name = "txtEmail2c";
            this.txtEmail2c.NextControl = this.txtLastName3;
            this.txtEmail2c.Size = new System.Drawing.Size(140, 20);
            this.txtEmail2c.TabIndex = 8;
            this.txtEmail2c.Visible = false;
            // 
            // txtLastName3
            // 
            this.txtLastName3.AllowBlankSpaces = true;
            this.txtLastName3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtLastName3.CustomExpression = ".*";
            this.txtLastName3.EnterColor = System.Drawing.Color.Empty;
            this.txtLastName3.LeaveColor = System.Drawing.Color.Empty;
            this.txtLastName3.Location = new System.Drawing.Point(25, 211);
            this.txtLastName3.MaxLength = 60;
            this.txtLastName3.Name = "txtLastName3";
            this.txtLastName3.NextControl = this.txtName3;
            this.txtLastName3.Size = new System.Drawing.Size(145, 20);
            this.txtLastName3.TabIndex = 9;
            this.txtLastName3.Visible = false;
            this.txtLastName3.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtLastName3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtName3
            // 
            this.txtName3.AllowBlankSpaces = true;
            this.txtName3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtName3.CustomExpression = ".*";
            this.txtName3.EnterColor = System.Drawing.Color.Empty;
            this.txtName3.LeaveColor = System.Drawing.Color.Empty;
            this.txtName3.Location = new System.Drawing.Point(219, 211);
            this.txtName3.MaxLength = 25;
            this.txtName3.Name = "txtName3";
            this.txtName3.NextControl = this.txtEmail3c;
            this.txtName3.Size = new System.Drawing.Size(143, 20);
            this.txtName3.TabIndex = 10;
            this.txtName3.Visible = false;
            this.txtName3.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtName3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtEmail3c
            // 
            this.txtEmail3c.AllowBlankSpaces = true;
            this.txtEmail3c.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail3c.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtEmail3c.CustomExpression = ".*";
            this.txtEmail3c.EnterColor = System.Drawing.Color.Empty;
            this.txtEmail3c.LeaveColor = System.Drawing.Color.Empty;
            this.txtEmail3c.Location = new System.Drawing.Point(410, 211);
            this.txtEmail3c.MaxLength = 60;
            this.txtEmail3c.Name = "txtEmail3c";
            this.txtEmail3c.NextControl = this.txtLastName4;
            this.txtEmail3c.Size = new System.Drawing.Size(140, 20);
            this.txtEmail3c.TabIndex = 11;
            this.txtEmail3c.Visible = false;
            // 
            // txtLastName4
            // 
            this.txtLastName4.AllowBlankSpaces = true;
            this.txtLastName4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtLastName4.CustomExpression = ".*";
            this.txtLastName4.EnterColor = System.Drawing.Color.Empty;
            this.txtLastName4.LeaveColor = System.Drawing.Color.Empty;
            this.txtLastName4.Location = new System.Drawing.Point(25, 242);
            this.txtLastName4.MaxLength = 25;
            this.txtLastName4.Name = "txtLastName4";
            this.txtLastName4.NextControl = this.txtName4;
            this.txtLastName4.Size = new System.Drawing.Size(145, 20);
            this.txtLastName4.TabIndex = 12;
            this.txtLastName4.Visible = false;
            this.txtLastName4.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtLastName4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtName4
            // 
            this.txtName4.AllowBlankSpaces = true;
            this.txtName4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtName4.CustomExpression = ".*";
            this.txtName4.EnterColor = System.Drawing.Color.Empty;
            this.txtName4.LeaveColor = System.Drawing.Color.Empty;
            this.txtName4.Location = new System.Drawing.Point(219, 242);
            this.txtName4.MaxLength = 25;
            this.txtName4.Name = "txtName4";
            this.txtName4.NextControl = this.txtEmail4c;
            this.txtName4.Size = new System.Drawing.Size(143, 20);
            this.txtName4.TabIndex = 13;
            this.txtName4.Visible = false;
            this.txtName4.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtName4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtEmail4c
            // 
            this.txtEmail4c.AllowBlankSpaces = true;
            this.txtEmail4c.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail4c.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtEmail4c.CustomExpression = ".*";
            this.txtEmail4c.EnterColor = System.Drawing.Color.Empty;
            this.txtEmail4c.LeaveColor = System.Drawing.Color.Empty;
            this.txtEmail4c.Location = new System.Drawing.Point(410, 242);
            this.txtEmail4c.MaxLength = 60;
            this.txtEmail4c.Name = "txtEmail4c";
            this.txtEmail4c.NextControl = this.txtLastName5;
            this.txtEmail4c.Size = new System.Drawing.Size(140, 20);
            this.txtEmail4c.TabIndex = 14;
            this.txtEmail4c.Visible = false;
            // 
            // txtLastName5
            // 
            this.txtLastName5.AllowBlankSpaces = true;
            this.txtLastName5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName5.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtLastName5.CustomExpression = ".*";
            this.txtLastName5.EnterColor = System.Drawing.Color.Empty;
            this.txtLastName5.LeaveColor = System.Drawing.Color.Empty;
            this.txtLastName5.Location = new System.Drawing.Point(25, 276);
            this.txtLastName5.MaxLength = 25;
            this.txtLastName5.Name = "txtLastName5";
            this.txtLastName5.NextControl = this.txtName5;
            this.txtLastName5.Size = new System.Drawing.Size(145, 20);
            this.txtLastName5.TabIndex = 15;
            this.txtLastName5.Visible = false;
            this.txtLastName5.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtLastName5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtName5
            // 
            this.txtName5.AllowBlankSpaces = true;
            this.txtName5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName5.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtName5.CustomExpression = ".*";
            this.txtName5.EnterColor = System.Drawing.Color.Empty;
            this.txtName5.LeaveColor = System.Drawing.Color.Empty;
            this.txtName5.Location = new System.Drawing.Point(219, 276);
            this.txtName5.MaxLength = 25;
            this.txtName5.Name = "txtName5";
            this.txtName5.NextControl = this.txtEmail5c;
            this.txtName5.Size = new System.Drawing.Size(143, 20);
            this.txtName5.TabIndex = 16;
            this.txtName5.Visible = false;
            this.txtName5.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtName5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtEmail5c
            // 
            this.txtEmail5c.AllowBlankSpaces = true;
            this.txtEmail5c.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail5c.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtEmail5c.CustomExpression = ".*";
            this.txtEmail5c.EnterColor = System.Drawing.Color.Empty;
            this.txtEmail5c.LeaveColor = System.Drawing.Color.Empty;
            this.txtEmail5c.Location = new System.Drawing.Point(410, 276);
            this.txtEmail5c.MaxLength = 60;
            this.txtEmail5c.Name = "txtEmail5c";
            this.txtEmail5c.NextControl = this.txtLastName6;
            this.txtEmail5c.Size = new System.Drawing.Size(140, 20);
            this.txtEmail5c.TabIndex = 17;
            this.txtEmail5c.Visible = false;
            // 
            // txtLastName6
            // 
            this.txtLastName6.AllowBlankSpaces = true;
            this.txtLastName6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName6.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtLastName6.CustomExpression = ".*";
            this.txtLastName6.EnterColor = System.Drawing.Color.Empty;
            this.txtLastName6.LeaveColor = System.Drawing.Color.Empty;
            this.txtLastName6.Location = new System.Drawing.Point(25, 306);
            this.txtLastName6.MaxLength = 25;
            this.txtLastName6.Name = "txtLastName6";
            this.txtLastName6.NextControl = this.txtName6;
            this.txtLastName6.Size = new System.Drawing.Size(145, 20);
            this.txtLastName6.TabIndex = 18;
            this.txtLastName6.Visible = false;
            this.txtLastName6.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtLastName6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtName6
            // 
            this.txtName6.AllowBlankSpaces = true;
            this.txtName6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName6.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtName6.CustomExpression = ".*";
            this.txtName6.EnterColor = System.Drawing.Color.Empty;
            this.txtName6.LeaveColor = System.Drawing.Color.Empty;
            this.txtName6.Location = new System.Drawing.Point(219, 306);
            this.txtName6.MaxLength = 25;
            this.txtName6.Name = "txtName6";
            this.txtName6.NextControl = this.txtEmail6c;
            this.txtName6.Size = new System.Drawing.Size(143, 20);
            this.txtName6.TabIndex = 19;
            this.txtName6.Visible = false;
            this.txtName6.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtName6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtEmail6c
            // 
            this.txtEmail6c.AllowBlankSpaces = true;
            this.txtEmail6c.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail6c.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtEmail6c.CustomExpression = ".*";
            this.txtEmail6c.EnterColor = System.Drawing.Color.Empty;
            this.txtEmail6c.LeaveColor = System.Drawing.Color.Empty;
            this.txtEmail6c.Location = new System.Drawing.Point(410, 306);
            this.txtEmail6c.MaxLength = 60;
            this.txtEmail6c.Name = "txtEmail6c";
            this.txtEmail6c.NextControl = this.txtLastName7;
            this.txtEmail6c.Size = new System.Drawing.Size(140, 20);
            this.txtEmail6c.TabIndex = 20;
            this.txtEmail6c.Visible = false;
            // 
            // txtLastName7
            // 
            this.txtLastName7.AllowBlankSpaces = true;
            this.txtLastName7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName7.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtLastName7.CustomExpression = ".*";
            this.txtLastName7.EnterColor = System.Drawing.Color.Empty;
            this.txtLastName7.LeaveColor = System.Drawing.Color.Empty;
            this.txtLastName7.Location = new System.Drawing.Point(25, 337);
            this.txtLastName7.MaxLength = 25;
            this.txtLastName7.Name = "txtLastName7";
            this.txtLastName7.NextControl = this.txtName7;
            this.txtLastName7.Size = new System.Drawing.Size(145, 20);
            this.txtLastName7.TabIndex = 21;
            this.txtLastName7.Visible = false;
            this.txtLastName7.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtLastName7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtName7
            // 
            this.txtName7.AllowBlankSpaces = true;
            this.txtName7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName7.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtName7.CustomExpression = ".*";
            this.txtName7.EnterColor = System.Drawing.Color.Empty;
            this.txtName7.LeaveColor = System.Drawing.Color.Empty;
            this.txtName7.Location = new System.Drawing.Point(219, 337);
            this.txtName7.MaxLength = 25;
            this.txtName7.Name = "txtName7";
            this.txtName7.NextControl = this.txtEmail7c;
            this.txtName7.Size = new System.Drawing.Size(143, 20);
            this.txtName7.TabIndex = 22;
            this.txtName7.Visible = false;
            this.txtName7.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtName7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtEmail7c
            // 
            this.txtEmail7c.AllowBlankSpaces = true;
            this.txtEmail7c.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail7c.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtEmail7c.CustomExpression = ".*";
            this.txtEmail7c.EnterColor = System.Drawing.Color.Empty;
            this.txtEmail7c.LeaveColor = System.Drawing.Color.Empty;
            this.txtEmail7c.Location = new System.Drawing.Point(410, 337);
            this.txtEmail7c.MaxLength = 60;
            this.txtEmail7c.Name = "txtEmail7c";
            this.txtEmail7c.NextControl = this.txtLastName8;
            this.txtEmail7c.Size = new System.Drawing.Size(140, 20);
            this.txtEmail7c.TabIndex = 23;
            this.txtEmail7c.Visible = false;
            // 
            // txtLastName8
            // 
            this.txtLastName8.AllowBlankSpaces = true;
            this.txtLastName8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName8.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtLastName8.CustomExpression = ".*";
            this.txtLastName8.EnterColor = System.Drawing.Color.Empty;
            this.txtLastName8.LeaveColor = System.Drawing.Color.Empty;
            this.txtLastName8.Location = new System.Drawing.Point(25, 368);
            this.txtLastName8.MaxLength = 24;
            this.txtLastName8.Name = "txtLastName8";
            this.txtLastName8.NextControl = this.txtName8;
            this.txtLastName8.Size = new System.Drawing.Size(145, 20);
            this.txtLastName8.TabIndex = 24;
            this.txtLastName8.Visible = false;
            this.txtLastName8.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtLastName8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtName8
            // 
            this.txtName8.AllowBlankSpaces = true;
            this.txtName8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName8.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtName8.CustomExpression = ".*";
            this.txtName8.EnterColor = System.Drawing.Color.Empty;
            this.txtName8.LeaveColor = System.Drawing.Color.Empty;
            this.txtName8.Location = new System.Drawing.Point(219, 368);
            this.txtName8.MaxLength = 25;
            this.txtName8.Name = "txtName8";
            this.txtName8.NextControl = this.txtEmail8c;
            this.txtName8.Size = new System.Drawing.Size(143, 20);
            this.txtName8.TabIndex = 25;
            this.txtName8.Visible = false;
            this.txtName8.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtName8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtName8.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName16_KeyUp);
            // 
            // txtEmail8c
            // 
            this.txtEmail8c.AllowBlankSpaces = true;
            this.txtEmail8c.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail8c.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtEmail8c.CustomExpression = ".*";
            this.txtEmail8c.EnterColor = System.Drawing.Color.Empty;
            this.txtEmail8c.LeaveColor = System.Drawing.Color.Empty;
            this.txtEmail8c.Location = new System.Drawing.Point(410, 368);
            this.txtEmail8c.MaxLength = 60;
            this.txtEmail8c.Name = "txtEmail8c";
            this.txtEmail8c.NextControl = this.btnAccept;
            this.txtEmail8c.Size = new System.Drawing.Size(140, 20);
            this.txtEmail8c.TabIndex = 26;
            this.txtEmail8c.Visible = false;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAccept.Location = new System.Drawing.Point(279, 419);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(66, 23);
            this.btnAccept.TabIndex = 27;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.bntAccept_Click);
            this.btnAccept.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnAccept_KeyUp);
            this.btnAccept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(238, 114);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nombre:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblName.Visible = false;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(33, 114);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(47, 13);
            this.lblLastName.TabIndex = 0;
            this.lblLastName.Text = "Apellido:";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLastName.Visible = false;
            // 
            // lblAddMorePassenger
            // 
            this.lblAddMorePassenger.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddMorePassenger.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblAddMorePassenger.Location = new System.Drawing.Point(180, 42);
            this.lblAddMorePassenger.Name = "lblAddMorePassenger";
            this.lblAddMorePassenger.Size = new System.Drawing.Size(84, 41);
            this.lblAddMorePassenger.TabIndex = 0;
            this.lblAddMorePassenger.Text = "¿Agregar más pasajeros?";
            this.lblAddMorePassenger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLastName1A
            // 
            this.txtLastName1A.AllowBlankSpaces = true;
            this.txtLastName1A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName1A.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtLastName1A.CustomExpression = ".*";
            this.txtLastName1A.EnterColor = System.Drawing.Color.Empty;
            this.txtLastName1A.LeaveColor = System.Drawing.Color.Empty;
            this.txtLastName1A.Location = new System.Drawing.Point(25, 148);
            this.txtLastName1A.Name = "txtLastName1A";
            this.txtLastName1A.NextControl = this.txtLastName2;
            this.txtLastName1A.Size = new System.Drawing.Size(145, 20);
            this.txtLastName1A.TabIndex = 3;
            this.txtLastName1A.Visible = false;
            this.txtLastName1A.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtLastName1A.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnYes);
            this.groupBox1.Controls.Add(this.btnNo);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(325, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(108, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnYes
            // 
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Location = new System.Drawing.Point(6, 7);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(44, 36);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "Si";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            this.btnYes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnYes_KeyUp);
            this.btnYes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnNo
            // 
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Location = new System.Drawing.Point(56, 7);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(44, 36);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            this.btnNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnNo_KeyUp);
            this.btnNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(410, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-mail:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(22, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "*";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(227, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "*";
            this.label3.Visible = false;
            // 
            // ucAddMorePassenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName1B);
            this.Controls.Add(this.lblAddPassenger1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName2);
            this.Controls.Add(this.txtName3);
            this.Controls.Add(this.lblAddMorePassenger);
            this.Controls.Add(this.txtName4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtName5);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtName6);
            this.Controls.Add(this.txtLastName1A);
            this.Controls.Add(this.txtName7);
            this.Controls.Add(this.txtLastName8);
            this.Controls.Add(this.txtName8);
            this.Controls.Add(this.txtEmail3c);
            this.Controls.Add(this.txtEmail4c);
            this.Controls.Add(this.txtEmail1c);
            this.Controls.Add(this.txtLastName7);
            this.Controls.Add(this.txtEmail2c);
            this.Controls.Add(this.txtLastName6);
            this.Controls.Add(this.txtLastName5);
            this.Controls.Add(this.txtLastName4);
            this.Controls.Add(this.txtEmail5c);
            this.Controls.Add(this.txtLastName3);
            this.Controls.Add(this.txtEmail6c);
            this.Controls.Add(this.txtLastName2);
            this.Controls.Add(this.txtEmail7c);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtEmail8c);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucAddMorePassenger";
            this.Size = new System.Drawing.Size(571, 580);
            this.Load += new System.EventHandler(this.ucAddMorePassenger_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblAddPassenger1;
        private MyCTS.Forms.UI.SmartTextBox txtLastName1A;
        private MyCTS.Forms.UI.SmartTextBox txtLastName2;
        private MyCTS.Forms.UI.SmartTextBox txtLastName3;
        private MyCTS.Forms.UI.SmartTextBox txtLastName4;
        private MyCTS.Forms.UI.SmartTextBox txtLastName5;
        private MyCTS.Forms.UI.SmartTextBox txtLastName6;
        private MyCTS.Forms.UI.SmartTextBox txtLastName7;
        private MyCTS.Forms.UI.SmartTextBox txtLastName8;
        private MyCTS.Forms.UI.SmartTextBox txtName1B;
        private MyCTS.Forms.UI.SmartTextBox txtName2;
        private MyCTS.Forms.UI.SmartTextBox txtName3;
        private MyCTS.Forms.UI.SmartTextBox txtName4;
        private MyCTS.Forms.UI.SmartTextBox txtName5;
        private MyCTS.Forms.UI.SmartTextBox txtName6;
        private MyCTS.Forms.UI.SmartTextBox txtName7;
        private MyCTS.Forms.UI.SmartTextBox txtName8;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblAddMorePassenger;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private SmartTextBox txtEmail1c;
        private SmartTextBox txtEmail2c;
        private SmartTextBox txtEmail3c;
        private SmartTextBox txtEmail4c;
        private SmartTextBox txtEmail5c;
        private SmartTextBox txtEmail6c;
        private SmartTextBox txtEmail7c;
        private SmartTextBox txtEmail8c;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

    }
}
