using System;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;
using MyCTS.Business;

namespace MyCTS.Presentation
{
    public partial class ucClearFirm : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite Limpiar firma en Sabre 
        /// Creación:    30-Abril-10 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>
        
        public ucClearFirm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            InitialControlFocus = txtFirmNumber;
            LastControlFocus = btnAccept;
        }
        //Coloca el foco en el Numero de firma
        private void ucClearFirm_Load(object sender, EventArgs e)
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

        //Invoca los metodos de Validación y envio de comandos
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBussinessRules)
            {
                SendCommand();
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
            bool notcontinue = false;
            string result = string.Empty;
            string send = string.Empty;
            string sabre = string.Empty;
            send =string.Concat("HB", txtFirmNumber.Text);

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result=objCommand.SendReceive(send);
            }
            CommandsQik.searchResponse(result, "RESTRICTED", ref row, ref col);
            if (row != 0 || col != 0)
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive("I");
                }
                MessageBox.Show(Resources.Reservations.NO_TIENE_AUTORIZACION_LIMPIAR_FIRMAS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                notcontinue = true;
                row = 0;
                col = 0;
            }
            CommandsQik.searchResponse(result, "NEW EMPLOYEE", ref row, ref col);
            if (row != 0 || col != 0)
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive("I");
                }
                MessageBox.Show(Resources.Reservations.LA_FIRMA_NO_EXISTE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                notcontinue = true;
                row = 0;
                col = 0;
            }
            else if(!notcontinue)
            {
                send ="H/AUTH BY"+txtAuthorization.Text;
                sabre = "HPCLEAR";

                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                    objCommand.SendReceive(sabre);
                }
                MessageBox.Show(Resources.Reservations.FIRMA_LIMPIADA_EXITO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }

        }

        #endregion
        
    }
}
