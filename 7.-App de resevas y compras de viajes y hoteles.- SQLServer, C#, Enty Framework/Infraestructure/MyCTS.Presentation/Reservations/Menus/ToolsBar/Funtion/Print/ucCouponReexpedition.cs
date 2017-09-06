using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucCouponReexpedition : CustomUserControl
    {
        /// <summary>
        /// Descripción: Mascarilla que permite reexpedir cupon al enviar el comando
        ///              respectivo con el numero de boleto. Pertenece a la seccion Imprimir del 
        ///              modulo de Funciones 
        /// Creación:    10 Julio 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        private bool isValid;

        public ucCouponReexpedition()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtNumberTicket;
            this.LastControlFocus = btnAccept;
        }

        /// <summary>
        /// Carga de la mascarilla de "Reexpedir Cupon" y valores iniciales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCouponReexpedition_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            PreviousValidation();
        }


        /// <summary>
        /// Ejecución de funciones de la mascarilla de "Reexpedir Cupon"
        /// cuando se presiona el boton Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!isValidBusinessRules)
            {
                CommandsSend();
            }
        }

        #region===== MethodsClass =====


        /// <summary>
        /// Validación de itinerario presente en MySabre
        /// </summary>
        private void PreviousValidation()
        {
            string result = string.Empty;
            string send = Resources.Constants.COMMANDS_AST_I;
            int row = 0;
            int col = 0;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result = objCommand.SendReceive(send);
            }
            CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.NO_ITIN, ref row, ref col);
            if (row != 0 || col != 0)
            {
                MessageBox.Show(Resources.Reservations.NO_EXISTE_ITINERARIO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            else 
            {
                send = Resources.Constants.COMMANDS_AST_T_AST_HT;
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive(send);
                }
                txtNumberTicket.Focus();
            }

        }


        /// <summary>
        /// Validación de reglas de negocio pertenecientes a esta mascarilla
        /// </summary>
        /// <returns></returns>
        private bool isValidBusinessRules
        {
            get
            {
                isValid = true;
                if (string.IsNullOrEmpty(txtNumberTicket.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESE_NUMERO_BOLETO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberTicket.Focus();
                }
                else if (!string.IsNullOrEmpty(txtNumberTicket.Text) && (!txtNumberTicket.Text.Length.Equals(13)))
                {
                    MessageBox.Show(Resources.Reservations.NUMERO_BOLETO_DEBE_SER_TRECE_DIGITOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberTicket.Focus();
                }
                else
                {
                    isValid = false;
                }
                return isValid;
            }
        }


        /// <summary>
        /// Armado y envio del comando correspondiente de esta mascarilla aMySabre
        /// </summary>
        private void CommandsSend()
        {
            string send = string.Concat(Resources.Constants.COMMANDS_W_CROSSLORAINE_RG,
                txtNumberTicket.Text,
                Resources.Constants.COMMANDS_CROSSLORAINE_RE);


            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }
        #endregion//End MethodsClass


        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====


        /// <summary>
        /// Aborta el proceso al presionar la tecla ESC o ejecuta la función de la 
        /// mascarilla al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
            {
                VolarisSession.Clean();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }
        }


        #endregion//Back to a Previous Usercontrol or Validate Enter KeyDown



        #region=====Change focus When a Textbox is Full=====

        //Evento txtNumberTicket_TextChanged
        private void txtNumberTicket_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberTicket.Text.Length > 12)
            {
                btnAccept.Focus();
            }
        }

        #endregion//End Change focus When a Textbox is Full
       
    }
}
