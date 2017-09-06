using System;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucDeleteTA : CustomUserControl
    {
        public ucDeleteTA()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            InitialControlFocus = txtTA;
            LastControlFocus = btnAccept;
            txtTA.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateBussinessRules)
            {
                if (DeleteAllFirmModulesBL.DeleteTA(txtTA.Text))
                {
                    MessageBox.Show("El número de TA ha sido eliminado", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTA.Text = string.Empty;
                    txtTA.Focus();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error favor de reportarlo a sistemas", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether [validate bussiness rules].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [validate bussiness rules]; otherwise, <c>false</c>.
        /// </value>
        public bool ValidateBussinessRules
        {
            get
            {
                bool isValid = true;

                if (txtTA.Text.Length < 6)
                {
                    MessageBox.Show("El número TA debe tener 6 números", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isValid = false;
                }
                else
                {
                    TA ta = GetAllFirmModulesBL.GetTA(txtTA.Text);

                    if (!string.IsNullOrEmpty(ta.Code))
                    {
                        txtTA.Text = ta.Code;
                    }
                    else
                    {
                        MessageBox.Show("El número de TA no existe, debe ser dado de alta", Resources.Constants.MYCTS,
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isValid = false;
                    }
                }
                return isValid;
            }
        }


        //KeyDown
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        
    }
}
