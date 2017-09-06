namespace MyCTS.Presentation
{
    partial class ucHotelsAvailabilty
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
            this.smartTextBox1 = new MyCTS.Forms.UI.SmartTextBox();
            this.smartTextBox2 = new MyCTS.Forms.UI.SmartTextBox();
            this.SuspendLayout();
            // 
            // smartTextBox1
            // 
            this.smartTextBox1.AllowBlankSpaces = true;
            this.smartTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.smartTextBox1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.smartTextBox1.CustomExpression = ".*";
            this.smartTextBox1.EnterColor = System.Drawing.Color.Empty;
            this.smartTextBox1.LeaveColor = System.Drawing.Color.Empty;
            this.smartTextBox1.Location = new System.Drawing.Point(33, 17);
            this.smartTextBox1.Name = "smartTextBox1";
            this.smartTextBox1.Size = new System.Drawing.Size(100, 20);
            this.smartTextBox1.TabIndex = 0;
            // 
            // smartTextBox2
            // 
            this.smartTextBox2.AllowBlankSpaces = true;
            this.smartTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.smartTextBox2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.smartTextBox2.CustomExpression = ".*";
            this.smartTextBox2.EnterColor = System.Drawing.Color.Empty;
            this.smartTextBox2.LeaveColor = System.Drawing.Color.Empty;
            this.smartTextBox2.Location = new System.Drawing.Point(33, 305);
            this.smartTextBox2.Name = "smartTextBox2";
            this.smartTextBox2.Size = new System.Drawing.Size(100, 20);
            this.smartTextBox2.TabIndex = 1;
            // 
            // ucHotelsAvailabilty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.smartTextBox2);
            this.Controls.Add(this.smartTextBox1);
            this.Name = "ucHotelsAvailabilty";
            this.Size = new System.Drawing.Size(411, 580);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyCTS.Forms.UI.SmartTextBox smartTextBox1;
        private MyCTS.Forms.UI.SmartTextBox smartTextBox2;

    }
}
