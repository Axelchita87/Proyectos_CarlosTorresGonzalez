using System;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucDeletePcc : CustomUserControl
    {
        public ucDeletePcc()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            InitialControlFocus = txtPcc;
            LastControlFocus = btnAccept;
            txtPcc.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateBussinessRules)
            {
                if (DeletePccBL.DeletePcc(txtPcc.Text))
                {
                    MessageBox.Show("Se ha eliminado el Pcc correctamente ", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPcc.Text = string.Empty;
                    txtPcc.Focus();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error durante la eliminación", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private bool ValidateBussinessRules
        {
            get
            {
                bool isValid = true;

                if (string.IsNullOrEmpty(txtPcc.Text))
                {
                    MessageBox.Show("Requiere el Pcc", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPcc.Focus();
                    isValid = false;
                }
                if (txtPcc.Text.Length<4)
                {
                    MessageBox.Show("El Pcc debe tener 4 caractéres", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPcc.Focus();
                    isValid = false;
                }
                return isValid;
            }
        }


        #region
        //KeyDownListBox
        private void BackEnterUserControlListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);

            if (e.KeyCode == Keys.Down)
            {
                if (lbPCC.Items.Count > 0)
                {
                    lbPCC.SelectedIndex = 0;
                    lbPCC.Focus();
                }
            }
        }


        /// <summary>
        /// Handles the KeyDown event of the BackEnterUserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }


        //Despliega opciones y elige opción con la tecla Enter     
        private void lbPCC_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            TextBox txt = txtPcc;

            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                lbPCC.Visible = false;
                txt.Focus();
            }
        }

      
        private void txtPcc_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            Common.SetListBoxPCCs(txt, lbPCC);
        }

        private void ListBox_MouseClick(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            TextBox txt = txtPcc;

            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            lbPCC.Visible = false;
            txt.Focus();
        }

        #endregion

    }
}
