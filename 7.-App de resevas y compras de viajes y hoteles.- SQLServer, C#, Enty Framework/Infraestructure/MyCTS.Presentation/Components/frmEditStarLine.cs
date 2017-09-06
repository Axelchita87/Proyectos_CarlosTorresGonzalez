using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyCTS.Presentation.Components
{
    public partial class frmEditStarLine : Form
    {
        string oldtext = string.Empty;
        public string OldText
        {
            get { return oldtext; }
            set { oldtext = value; }
        }

        string newtext = string.Empty;
        public string NewText
        {
            get { return newtext; }
            set { newtext = value; }
        } 

        public frmEditStarLine()
        {
            InitializeComponent();
        }


        //Evento btnAddChange_Click
        private void btnAddChange_Click(object sender, EventArgs e)
        {
            AddChange();
        }

        //Evento btnAddCross_Click
        private void btnAddCross_Click(object sender, EventArgs e)
        {
            AddCrossLoraine();
        }

        #region===== MethodsClass =====

        //Agrega un change al texto de edicion
        private void AddChange()
        {
            if (!string.IsNullOrEmpty(txtEditLine.Text))
                txtEditLine.Text = string.Concat(txtEditLine.Text, Resources.Constants.CHANGE);
            else
            {
                txtEditLine.Text = Resources.Constants.CHANGE;
            }
        }

        //Agrega una cruz de lorena al texto de edicion
        private void AddCrossLoraine()
        {
            if (!string.IsNullOrEmpty(txtEditLine.Text))
                txtEditLine.Text = string.Concat(txtEditLine.Text, Resources.Constants.CROSSLORAINE);
            else
            {
                txtEditLine.Text = Resources.Constants.CROSSLORAINE;
            }
        }

        #endregion//End MethodsClass 

        private void frmEditStarLine_Load(object sender, EventArgs e)
        {
            txtEditLine.Text = OldText;
            newtext = string.Empty;
            txtEditLine.Focus();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Resources.Profiles.Constants.SAVE_CHANGES, Resources.Constants.MYCTS, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.Yes))
            {
                newtext = txtEditLine.Text;
                this.Close();
            }                            
        }

        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
                this.Close();
            else if (e.KeyData.Equals(Keys.Enter))            
                btnOK_Click(sender, e);
        }
    }
}