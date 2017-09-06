using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using MyCTS.Business;

namespace MyCTS.Presentation
{
    public partial class ucPasscodeTemp : CustomUserControl
    {

        /// <summary>
        /// Descripcion: Permite Asignar password temporal en Sabre 
        /// Creación:    30-Abril-10 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>
        
        public ucPasscodeTemp()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtFirmNumber;
            this.LastControlFocus = btnAccept;
        }

        //Extrae el User Name y lo asigna al textbos y coloca el foco en el txt
        private void ucPasscodeTemp_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            string agent = string.Empty;
            CatQueue item = CatQueueBL.GetQueue(Login.Firm, Login.PCC);
            if (!string.IsNullOrEmpty(item.Agent))
            {
                agent = item.Agent;
            }
            txtAuthorization.Text = agent;
            txtFirmNumber.Focus();
        }

        //Llama a los metodos de validación y envió de comandos
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinessRules)
                SendCommand();
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

        #region ==== Change Focus ====
        //Cambia de foco dependio de los caracteres permitidos
        private void txtFirmNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtFirmNumber.Text.Length > 3)
                txtAuthorization.Focus();
        }

        private void txtAuthorization_TextChanged(object sender, EventArgs e)
        {
            if (txtAuthorization.Text.Length > 14)
                txtPasswordTemp.Focus();
        }

        private void txtPasswordTemp_TextChanged(object sender, EventArgs e)
        {
            if (txtPasswordTemp.Text.Length > 7)
                btnAccept.Focus();
        }

        #endregion

        #region ======= Methods ========
        //Valida que los campos obligatorios no esten vacios
        private bool IsValidBussinessRules
        {
            get
            {
                bool isVaid = false;
                if (string.IsNullOrEmpty(txtFirmNumber.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_NUMERO_FIRMA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFirmNumber.Focus();
                }
                else if (string.IsNullOrEmpty(txtAuthorization.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_AUTORIZADO_POR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAuthorization.Focus();
                }
                else if (string.IsNullOrEmpty(txtPasswordTemp.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_INGRESAR_PASSCODE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPasswordTemp.Focus();
                }
                else
                {
                    isVaid = true;
                }
                return isVaid;
            }
        }

        //Manda comando o muestra los datos deacuerdo a la opción elegida
        private void SendCommand()
        {
            int col = 0;
            int row = 0;

            string result = string.Empty;
            string send = string.Empty;
            string sabre = string.Empty;
            string he = string.Empty;

            send = string.Concat("HB", txtFirmNumber.Text);

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(send);
            }
            CommandsQik.searchResponse(result, "NEW EMPLOYEE", ref row, ref col);
            if (row != 0 || col != 0)
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive("I");
                }
                MessageBox.Show(Resources.Reservations.LA_FIRMA_NO_EXISTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                row = 0;
                col = 0;
            }
            else
            {
                send = "H/AUTH BY " + txtAuthorization.Text;
                sabre = "H/PASS"+ txtPasswordTemp.Text;
                he = "HE";

                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                    objCommand.SendReceive(sabre);
                   result= objCommand.SendReceive(he);
                   objCommand.SendReceive("I");
                }
                CommandsQik.searchResponse(result, "DONE", ref row, ref col);
                if (row != 0 || col != 0)
                {
                    MessageBox.Show(Resources.Reservations.PASSCODE_TEMPORAL_ASIGNADO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
                else
                    MessageBox.Show(Resources.Reservations.PRESENTO_ERROR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        #endregion
        
    }
}
