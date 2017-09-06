using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Presentation.Components;


namespace MyCTS.Presentation
{
    public partial class ucStatusEtkt : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite ver el estatus de Etkt,pertenece a Funciones
        /// Creación:    Marzo-Abril 09 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>

        private string result;

        public ucStatusEtkt()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtNumberLine;
            this.LastControlFocus = btnAccept;
            ucAvailability.IsInterJetProcess = false;
        }

        //User Control Load 
        /// <summary>
        /// Se coloca el foco en el textbox del Numero de Linea
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucStatusEtkt_Load(object sender, EventArgs e)
        {
            txtNumberLine.Focus();
        }

        //Button Accept
        /// <summary>
        /// Se realizan las validaciones despues de que el usuario ingresa datos, 
        /// se mandan los comandos y termina el proceso llamando a otro User Control 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        //Change Focus      
        private void txtNumberLine_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberLine.Text.Length > 1)
                btnAccept.Focus();
        }

        #region ===== methodsClass =====

        /// <summary>
        /// Se validan que existan los datos que son obligatorios y que 
        /// sean los datos correctos
        /// </summary>
        private bool IsValidateBusinessRules
        {
            get
            {
                string doublezero = Resources.Constants.DOUBLEZERO;
                string zero = Resources.Constants.ZERO;

                if (string.IsNullOrEmpty(txtNumberLine.Text))
                {
                    MessageBox.Show(Resources.Reservations.REQUIERE_NÚMERO_LÍNEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberLine.Focus();
                    return false;
                }
                else if (txtNumberLine.Text.Equals(doublezero) | txtNumberLine.Text.Equals(zero))
                {
                    MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumberLine.Focus();
                    return false;
                }
                else
                    return true;
            }
        }

        /// <summary>
        /// Se envia el comando de acuerdo a los campos ingresados
        /// </summary>
        private void CommandsSend()
        {
            string send;
            send = Resources.Constants.COMMANDS_WETR_AST + txtNumberLine.Text;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                result=objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Busca errores en la clase de ERR_MnuSee de acuerdo a las respuestas recibidas por el 
        /// Emulador de Sabre y de acuerdo a ellas se realizan ciertas acciones ya sea
        /// mandar un mensaje de error al usuario notificando del mismo o mandando a otro 
        /// User Control
        /// </summary>
        private void APIResponse()
        {
            if ((!string.IsNullOrEmpty(result)))
            {
                ERR_MnuSee.err_mnuSee(result);
                if (!ERR_MnuSee.Status)
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                else
                   MessageBox.Show(ERR_MnuSee.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        #endregion
    }
}
