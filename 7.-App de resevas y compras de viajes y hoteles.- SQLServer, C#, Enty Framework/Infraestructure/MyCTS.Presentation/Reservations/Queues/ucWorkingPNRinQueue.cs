using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;


namespace MyCTS.Presentation
{
    public partial class ucWorkingPNRinQueue : CustomUserControl
    {

        /// <summary>
        /// Descripción: User Control que permite realizar una serie de opciones
        ///              cuando se esta dentro de una Queue. Pertenece al Modulo de Queues
        /// Creación:    16 Julio 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 
        public ucWorkingPNRinQueue()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoNextQueue;
            this.LastControlFocus = btnAccept;
        }


        /// <summary>
        /// Dexcripción: Carga de la mascarilla denominada "Trabajar Record en Queue" y asignación de foco
        /// al control rdoNextQueue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucWorkingPNRinQueue_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            rdoNextQueue.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (rdoNextQueue.Checked)
                NextQueueSendcommand();
            else if (rdoShowInstructions.Checked)
                ShowInstructionsSendCommand();
            else if (rdoShowHistoryInQueue.Checked)
                ShowHistoryInQueueSendCommand();
            else if (rdoDeletePNRinQueue.Checked)
                DeletePNRinQueueSendCommand();
            else if (rdoOutOfQueue.Checked)
                OutOfQueueSendCommand();
            else if (rdoConcludeChanges.Checked)
                ConcludeChangesSendCommand();

        }

        #region===== MethodsClass =====

        /// <summary>
        /// Manda el comando a MySabre repectivo de la opción
        /// "Siguiente Queue"
        /// </summary>
        private void NextQueueSendcommand()
        {
            string send = Resources.Queues.Constants.COMMANDS_I;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Manda el comando a MySabre repectivo de la opción
        /// "Muestra instrucciones"
        /// </summary>
        private void ShowInstructionsSendCommand()
        {
            string send = Resources.Queues.Constants.COMMANDS_Q_AST;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Manda el comando a MySabre repectivo de la opción
        /// "Muestra Historia en Queue"
        /// </summary>
        private void ShowHistoryInQueueSendCommand()
        {
            string send = Resources.Queues.Constants.COMMANDS_QH;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Manda el comando a MySabre repectivo de la opción
        /// "Borra Record en Queue"
        /// </summary>
        private void DeletePNRinQueueSendCommand()
        {
            string send = Resources.Queues.Constants.COMMANDS_QR;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Manda el comando a MySabre repectivo de la opción
        /// "Salir de Queue"
        /// </summary>
        private void OutOfQueueSendCommand()
        {
            string send = Resources.Queues.Constants.COMMANDS_QXI;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Manda el comando a MySabre repectivo de la opción
        /// "Concluir Cambios en Record"
        /// </summary>
        private void ConcludeChangesSendCommand()
        {
            string send = Resources.Queues.Constants.COMMANDS_EWL;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send, 0, 1);
            }
        }

        #endregion//End MethodsClass

        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====


        /// <summary>
        /// Aborta el proceso al presionar la tecla ESC
        /// o ejecutar las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }
        }


        #endregion//Back to a Previous Usercontrol or Validate Enter KeyDown


    }
}