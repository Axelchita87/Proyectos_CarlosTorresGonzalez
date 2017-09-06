using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucEnterToQueue : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite ingresar a una Queue en especifico.
        ///              Parte del modulo de Queues
        /// Creación:    Junio 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 
        public ucEnterToQueue()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtQueue;
            this.LastControlFocus = btnAccept;
        }


        //Evento Load
        private void ucEnterToQueue_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtQueue.Focus();
        }


        /// <summary>
        /// Ejecuta las funciones de la mascarilla de "Entrar a Queue"
        /// </summary>
        /// <param name="sender">btnAccept</param>
        /// <param name="e"></param>
 
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!IsValidBusinessRules)
            {
                CommandsSend();
            }
        }


        #region===== MethodsClass =====

        /// <summary>
        /// Reglas de negocio de la mascarilla correspondiente
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                bool isValid = true;
                if (string.IsNullOrEmpty(txtQueue.Text))
                {
                    MessageBox.Show(Resources.Queues.Queues.INGRESA_NUMERO_QUEUE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQueue.Focus();
                }
                else if (Convert.ToInt32(txtQueue.Text) > Convert.ToInt32(Resources.Queues.Constants.QUEUE_511))
                {
                    MessageBox.Show(Resources.Queues.Queues.QUEUE_NO_MAYOR_510, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQueue.Focus();
                }
                else
                {
                    isValid = false;
                }
                return isValid;
            }
        }


        /// <summary>
        /// Armado y envio del comando a mySabre
        /// </summary>
        private void CommandsSend()
        {
            string send = string.Empty;
            string queue = string.Empty;
            string pcc = string.Empty;
            string advancePosition = string.Empty;
            string enterToQueue = Resources.Queues.Constants.COMMANDS_Q_SLASH;

            queue = txtQueue.Text;
            if (!string.IsNullOrEmpty(txtPCC.Text))
            {
                pcc = txtPCC.Text;
            }
            else
            {
                pcc = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtAdvancePosition.Text))
            {
                advancePosition = string.Concat(Resources.Queues.Constants.COMMANDS_CROSSLORAINE_NM_INDENT,
                    txtAdvancePosition.Text);
            }
            else
            {
                advancePosition = string.Empty;
            }

            send = string.Concat(enterToQueue,
                pcc,
                queue,
                advancePosition);

            using (CommandsAPI objectCommand = new CommandsAPI())
            {
                objectCommand.SendReceive(send);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        #endregion//End methodsClass



        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====

        /// <summary>
        /// Aborta el proceso al presionar la tecla ESC o ejecuta
        /// las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }

        }

        #endregion//Back to a Previous Usercontrol or Validate Enter KeyDown

        
        
        #region=====Textbox Controls Text Change Events=====

        //Evento txtQueue_TextChanged
        private void txtQueue_TextChanged(object sender, EventArgs e)
        {
            if (txtQueue.Text.Length > 2)
            {
                txtPCC.Focus();
            }
        }

        //Evento txtPCC_TextChanged
        private void txtPCC_TextChanged(object sender, EventArgs e)
        {
            if (txtPCC.Text.Length > 3)
            {
                txtAdvancePosition.Focus();
            }
        }

        //Evento txtAdvancePosition_TextChanged
        private void txtAdvancePosition_TextChanged(object sender, EventArgs e)
        {
            if (txtAdvancePosition.Text.Length > 3)
            {
                btnAccept.Focus();
            }
        }

        #endregion//End Textbox Controls Text Change Events


    }
}
