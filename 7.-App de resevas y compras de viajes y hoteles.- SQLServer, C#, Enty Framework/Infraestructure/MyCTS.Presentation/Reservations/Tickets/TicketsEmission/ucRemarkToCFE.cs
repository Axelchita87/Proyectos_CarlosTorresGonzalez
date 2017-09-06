using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucRemarkToCFE : CustomUserControl
    {
        public ucRemarkToCFE()
        {
            InitializeComponent();
        }

        private static bool status;
        public static bool Status
        {
            get { return status; }
            set { status = value; }
        }

        private void ucRemarkToCFE_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string sabre;
            if (!rdoAeromexico.Checked && !rdoCanNotChangeBussinesClass.Checked
                && !rdoChangeBussinesClass.Checked && !rdoMexicana.Checked)
                MessageBox.Show("DEBE SELECCIONAR UNA DE LAS OPCIONES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                status = true;
                if (rdoAeromexico.Checked)
                    sabre = rdoAeromexico.Text;
                else if (rdoCanNotChangeBussinesClass.Checked)
                    sabre = rdoCanNotChangeBussinesClass.Text;
                else if (rdoChangeBussinesClass.Checked)
                    sabre = rdoChangeBussinesClass.Text;
                else
                    sabre = rdoMexicana.Text;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(string.Concat("5H-MYCTS-", sabre));
                }
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_QUALITIES_BY_PAX);
            }
        }

        private void rdoAeromexico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                status = false;
                string dk = ucFirstValidations.DK;
                dk = dk.Substring(3, 3);
                if (dk == Resources.TicketEmission.ValitationLabels.NUMBER_990)
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCBILLINGADRESS);
                else
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            else if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }
    }
}
