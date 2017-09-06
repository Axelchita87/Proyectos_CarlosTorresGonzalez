using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Presentation.Components;


namespace MyCTS.Presentation
{
    public partial class ucStatusPrinter : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Permite ver el estatus de las impresoras,pertenece a Funciones
        /// Creación:    Marzo-Abril 09 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Jessica Gutierrez 
        /// </summary>
        
        public ucStatusPrinter()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoLiberateMessages;
            this.LastControlFocus = btnAccept;
        }

        //User Control Load
        /// <summary>
        /// Se le asigna el foco al radio button de Liberar Mensajes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucStatusPrinter_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            rdoLiberateMessages.Focus();
        }

        //Button Accept 
        /// <summary>
        /// De acuerdo a la opción se va a una función para 
        /// mandar los comandos correspondentes a ese radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (rdoLiberateMessages.Checked)
                LiberateMessagesCommandsSend();
            if (rdoStopImpression.Checked)
                StopImpressionCommandsSend();
            if (rdoEaserChoketMessage.Checked)
                EaserChoketMessageCommandsSend();
            if (rdoDeployStatus.Checked)
                DeployStatusCommandsSend();
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

        #region ====== Change TabStop =======

        //TabStop EaserChoketMessage
        private void rdoEaserChoketMessage_CheckedChanged(object sender, EventArgs e)
        {
            TabStopControls();
        }

        //TabStop DeployStatus
        private void rdoDeployStatus_CheckedChanged(object sender, EventArgs e)
        {
            TabStopControls();
        }

        //TabStop LiberateMessages
        private void rdoLiberateMessages_CheckedChanged(object sender, EventArgs e)
        {
            TabStopControls();
        }

        //TabStopImpression
        private void rdoStopImpression_CheckedChanged(object sender, EventArgs e)
        {
            TabStopControls();
        }

        #endregion

        #region ===== methodsClass =====

        /// <summary>
        /// Manda los comandos de acuerdo al radio button
        /// </summary>
        private void LiberateMessagesCommandsSend()
        {
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_T_HOLD);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_B_HOLD);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_I_HOLD);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_P_HOLD);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_T);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_B);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_I);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_P);
            }
        }

        /// <summary>
        /// Manda los comandos de acuerdo al radio button
        /// </summary>
        private void StopImpressionCommandsSend()
        {
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_T_HOLD);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_B_HOLD);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_I_HOLD);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_P_HOLD);
            }
        }

        /// <summary>
        /// Manda los comandos de acuerdo al radio button
        /// </summary>
        private void EaserChoketMessageCommandsSend()
        {
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_T_HOLD);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_B_HOLD);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_I_HOLD);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_P_HOLD);

                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_T_CLEAR);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_B_CLEAR);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_I_CLEAR);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_P_CLEAR);

                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_T);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_B);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_I);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_P);
            }
        }

        /// <summary>
        /// Manda los comandos de acuerdo al radio button
        /// </summary>
        private void DeployStatusCommandsSend()
        {
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_T_STATUS);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_B_STATUS);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_I_STATUS);
                objCommand.SendReceive(Resources.Constants.COMMANDS_RL_SLASH_P_STATUS);
            }
        }

        /// <summary>
        /// Esta función hace que el Tab sea obligado a pasar por todos los
        /// controles por que sin esta función no se podia recorrer con 
        /// el Tabulador los radios
        /// </summary>
        private void TabStopControls()
        {
            rdoDeployStatus.TabStop = true;
            rdoEaserChoketMessage.TabStop = true;
            rdoLiberateMessages.TabStop = true;
            rdoStopImpression.TabStop = true;
        }

        #endregion
    }
}
