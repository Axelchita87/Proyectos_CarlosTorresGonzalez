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
    public partial class ucDecreasesIncreases : CustomUserControl
    {
        public ucDecreasesIncreases()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtChangePaxNumber;
            this.LastControlFocus = btnAccept;
        }

        private void ucDecreasesIncreases_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtChangePaxNumber.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidateBusinessRules)
            {
                CommandsSend();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }


        //KeyDown
        /// <summary>
        /// Este se usa para todos los controles en general si se oprime 
        /// Esc se manda a el User control de Welcome 
        /// Enter se manda la accion de botón de Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Escape)
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);

            if (e.KeyData == Keys.Enter)
                btnAccept_Click(sender, e);
        }

        #region ====== Change Tab =======

        private void txtChangePaxNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtChangePaxNumber.Text.Length > 0)
                txtRecreases1.Focus();
        }

        private void txtRecreases1_TextChanged(object sender, EventArgs e)
        {
            if (txtRecreases1.Text.Length > 3)
                txtRecreases2.Focus();
        }

        private void txtRecreases2_TextChanged(object sender, EventArgs e)
        {
            if (txtRecreases2.Text.Length > 3)
                txtRecreases3.Focus();
        }

        private void txtRecreases3_TextChanged(object sender, EventArgs e)
        {
            if (txtRecreases3.Text.Length > 3)
                txtRecreases4.Focus();
        }

        private void txtRecreases4_TextChanged(object sender, EventArgs e)
        {
            if (txtRecreases4.Text.Length > 3)
                btnAccept.Focus();
        }

        #endregion


        /// <summary>
        /// Valido que los campos obligatorios no esten vacios y que no 
        /// contengan datos no permitidos.
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                if (string.IsNullOrEmpty(txtChangePaxNumber.Text))
                {
                    MessageBox.Show("Requiere Ingresar el Cambio del Número de Pax", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtChangePaxNumber.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSend()
        {
            string sabre = string.Empty;
            string send = string.Empty;
            int flag_content = 0;

            send = string.Concat(send, ",", txtChangePaxNumber.Text);
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                objCommands.SendReceive(send);
            }

            if (!string.IsNullOrEmpty(txtRecreases4.Text))
            {
                sabre = string.Concat(sabre, "-", txtRecreases4.Text, "@");
                flag_content = 1;
            }

            if (!string.IsNullOrEmpty(txtRecreases3.Text))
            {
                if (flag_content == 1)
                    sabre = string.Concat(sabre, "Σ-", txtRecreases3.Text, "@");
                else
                    sabre = string.Concat(sabre, "-", txtRecreases3.Text, "@");
                flag_content = 1;
            }

            if (!string.IsNullOrEmpty(txtRecreases2.Text))
            {
                if (flag_content == 1)
                    sabre = string.Concat(sabre, "Σ-", txtRecreases2.Text, "@");
                else
                    sabre = string.Concat(sabre, "-", txtRecreases2.Text, "@");
                flag_content = 1;
            }

            if (!string.IsNullOrEmpty(txtRecreases1.Text))
            {
                if (flag_content == 1)
                    sabre = string.Concat(sabre, "Σ-", txtRecreases1.Text, "@");
                else
                    sabre = string.Concat(sabre, "-", txtRecreases1.Text, "@");
                flag_content = 1;
            }

            if (flag_content == 1)
            {
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    objCommands.SendReceive(sabre);
                }
            }


            using (CommandsAPI objCommands = new CommandsAPI())
            {
                objCommands.SendReceive("*N*I");
            }

        }


    }
}
