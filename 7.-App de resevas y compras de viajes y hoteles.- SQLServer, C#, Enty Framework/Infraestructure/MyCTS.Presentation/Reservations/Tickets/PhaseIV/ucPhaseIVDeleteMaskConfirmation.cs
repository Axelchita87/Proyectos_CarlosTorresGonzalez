using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucPhaseIVDeleteMaskConfirmation : CustomUserControl
    {

        /// <summary>
        /// Descripción: Confirma el borrado de las fases IV dentro de una reservación
        /// Creación:    21 septiembre 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 

        public ucPhaseIVDeleteMaskConfirmation()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoYes;
            this.LastControlFocus = btnAccept;
        }

        /// <summary>
        /// Ejecuta las acciones del userControl al ser cargado
        /// </summary>
        private void ucPhaseIVDeleteMaskConfirmation_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            rdoYes.Focus();
        }

        /// <summary>
        /// Ejecuta los metodos correspondientes al hacer click en el boton Aceptar
        /// </summary>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (rdoYes.Checked)
            {
                SendCommand();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            else
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_DELETE_MASK);
            }
        }


        #region===== MethodsClass ===== 


        /// <summary>
        /// Envia el comando de borrado de fase IV a MySabre
        /// </summary>
        private void SendCommand()
        {
            string send = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_W_CROSSLORAINE_D;
            if (!string.IsNullOrEmpty(ucPhaseIVDeleteMask.maskNumber))
            {
                send = string.Concat(send,
                    ucPhaseIVDeleteMask.maskNumber);
            }

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }
        #endregion//End MethodsClass

        #region ===== Back to a Previous Usercontrol or Validate Enter KeyDown =====

        /// <summary>
        ///  Aborta el proceso al presionar la tecla ESC o ejecuta el borrado de 
        ///  fase IV al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_DELETE_MASK);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {

                btnAccept_Click(sender, e);

            }
        }
        #endregion//End Back to a Previous Usercontrol or Validate Enter KeyDown

    }
}
