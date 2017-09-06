using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Entities;


namespace MyCTS.Presentation
{
    public partial class ucAssignOrNotPrinters : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite asignar o desasignar impresoras al usuario
        ///              con otras serie de opciones relacionadas a la asignación de impresoras
        /// Creación:    Marzo - Abril 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 
        private string send;
        private bool isValid;

        public ucAssignOrNotPrinters()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoPrinterProfile;
            this.LastControlFocus = btnAccept;
        }

        //Evento Load
        private void ucAssignOrNotPrinters_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            rdoPrinterProfile.Focus();
        }


        /// <summary>
        /// Ejecución de funciones de la mascarilla al presionar el boton Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (rdoPrinterProfile.Checked)
            {

                if (!IsValidBusinessRules)
                {
                    PrinterProfileCommandsSend();
                }
            }
            else if (rdoTickets.Checked)
            {
                if (!IsValidBusinessRules)
                {
                    TicketsCommandsSend();
                }
            }
            else if (rdoItineraryInvoice.Checked)
            {
                if (!IsValidBusinessRules)
                {
                    ItineraryInvoiceCommandsSend();
                }
            }
            else if (rdoHardCopy.Checked)
            {
                if (!IsValidBusinessRules)
                {
                    HardCopyCommandsSend();
                }
            }
        }


        //Evento rdoPrinterProfile_CheckedChanged
        private void rdoPrinterProfile_CheckedChanged(object sender, EventArgs e)
        {
            PrinterProfileTextProperties();
        }

        //Evento rdoTickets_CheckedChanged
        private void rdoTickets_CheckedChanged(object sender, EventArgs e)
        {
            TicketsTextProperties();
        }

        //Evento rdoItineraryInvoice_CheckedChanged
        private void rdoItineraryInvoice_CheckedChanged(object sender, EventArgs e)
        {
            ItineraryInvoiceTextProperties();
        }

        //Evento rdoHardCopy_CheckedChanged
        private void rdoHardCopy_CheckedChanged(object sender, EventArgs e)
        {
            HardCopyTextProperties();
        }

        //Evento chkAssign_CheckedChanged
        private void chkAssign_CheckedChanged(object sender, EventArgs e)
        {
            EnableControl();
        }

        //Evento chkNotAssign_CheckedChanged
        private void chkNotAssign_CheckedChanged(object sender, EventArgs e)
        {
            DisableControl();
        }

        //Evento txtValue_TextChanged
        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            txtValueChangeFocus();
        }


        #region===== MethodsClass =====


        #region===== rdoPrinterProfile =====

        
        /// <summary>
        /// Modifica los valores de txtValue cuando la opción
        /// "Perfil de impresora" es seleccionada
        /// </summary>
        private void PrinterProfileTextProperties()
        {
            txtValue.Text = string.Empty;
            lblInstructions.Text = Resources.Constants.INGRESA_PERFIL_IMPRESION;
            txtValue.MaxLength = 1;
            txtValue.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
        }


        /// <summary>
        /// Armado y envio del comando a MySabre cuando la opción 
        /// "Perfil de impresora" esta seleccionada y se presiona el boton Aceptar
        /// </summary>
        private void PrinterProfileCommandsSend()
        {
            string printerProfile;
            send = string.Empty;
            if (chkAssign.Checked)
            {
                printerProfile = Resources.Constants.COMMANDS_PPS;
                send = string.Concat(printerProfile,
                    txtValue.Text);

            }
            else if (chkNotAssign.Checked)
            {
                send = Resources.Constants.COMMANDS_PPO;
            }
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }

        #endregion//End rdoPrinterProfile



        #region=====rdoTickets =====

        /// <summary>
        /// Armado y envio del comando a MySabre cuando la opción 
        /// "Boletos" esta seleccionada y se presiona el boton Aceptar
        /// </summary>
        private void TicketsCommandsSend()
        {
            string tickets;
            send = string.Empty;
            if (chkAssign.Checked)
            {
                tickets = Resources.Constants.COMMANDS_W_AST_MX;
                send = string.Concat(tickets,
                    txtValue.Text);
            }
            else if (chkNotAssign.Checked)
            {
                send = Resources.Constants.COMMANDS_W_AST_NO;
            }
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }


        /// <summary>
        /// Modifica los valores de txtValue cuando la opción
        /// "Boletos" es seleccionada
        /// </summary>
        private void TicketsTextProperties()
        {
            lblInstructions.Text = Resources.Constants.INGRESA_TA_BOLETOS;
            txtValue.MaxLength = 6;
            txtValue.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
        }

        #endregion//End rdoTickets



        #region===== rdoItineraryInvoice =====

        /// <summary>
        /// Armado y envio del comando a MySabre cuando la opción 
        /// "Itinerario/Factura" esta seleccionada y se presiona el boton Aceptar
        /// </summary>
        private void ItineraryInvoiceCommandsSend()
        {
            string itineraryInvoice;
            send = string.Empty;
            if (chkAssign.Checked)
            {
                itineraryInvoice = Resources.Constants.COMMANDS_DSIV;
                send = string.Concat(itineraryInvoice,
                    txtValue.Text);
            }
            else if (chkNotAssign.Checked)
            {
                send = Resources.Constants.COMMANDS_DSNO;
            }
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }


        /// <summary>
        /// Modifica los valores de txtValue cuando la opción
        /// "Itinerario/Factura" es seleccionada
        /// </summary>
        private void ItineraryInvoiceTextProperties()
        {
            lblInstructions.Text = Resources.Constants.INGRESA_TA_ITINERARIO_FACT;
            txtValue.MaxLength = 6;
            txtValue.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
        }


        #endregion//End rdoItineraryInvoice



        #region===== rdoHardCopy =====

        /// <summary>
        /// Armado y envio del comando a MySabre cuando la opción 
        /// "HardCopy" esta seleccionada y se presiona el boton Aceptar
        /// </summary>
        private void HardCopyCommandsSend()
        {
            string hardCopy;
            send = string.Empty;
            if (chkAssign.Checked)
            {
                hardCopy = Resources.Constants.COMMANDS_PTR_SLASH;
                send = string.Concat(hardCopy,
                    txtValue.Text);
            }
            else if (chkNotAssign.Checked)
            {
                send = Resources.Constants.COMMANDS_PTR_SLASH_END;
            }
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
        }


        /// <summary>
        /// Modifica los valores de txtValue cuando la opción
        /// "HarCopy" es seleccionada
        /// </summary>
        private void HardCopyTextProperties()
        {
            lblInstructions.Text = Resources.Constants.INGRESA_TA_HARDCOPY;
            txtValue.MaxLength = 6;
            txtValue.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
        }


        #endregion// End rdoHardCopy



        /// <summary>
        /// Habilita el control txtValue la opción "Asignar" es seleccionada
        /// </summary>
        private void EnableControl()
        {
            if (chkAssign.Checked)
            {
                txtValue.Enabled = true;
                txtValue.BackColor = Color.White;
            }

        }


        /// <summary>
        /// Inhabilita el control txtValue la opción "Des-asignar" es seleccionada
        /// </summary>
        private void DisableControl()
        {
            if (chkNotAssign.Checked)
            {
                txtValue.Text = string.Empty;
                txtValue.BackColor = SystemColors.Control;
                txtValue.Enabled = false;
            }
            else
            {
                txtValue.BackColor = Color.White;
                txtValue.Enabled = true;
            }

        }



        #region===== Commons =====

        /// <summary>
        /// Reglas de negocio aplicables a esta mascarilla
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                isValid = true;

                if ((rdoPrinterProfile.Checked) &&
                    (!string.IsNullOrEmpty(txtValue.Text)) &&
                    (txtValue.Text.Length != 1) &&
                    (txtValue.Enabled.Equals(true)))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_NUM_PERFIL_IMPRESION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtValue.Focus();
                }
                else if ((!rdoPrinterProfile.Checked) &&
                    (!string.IsNullOrEmpty(txtValue.Text)) &&
                    (txtValue.Text.Length != 6) &&
                    (txtValue.Enabled.Equals(true)))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_SEIS_CARAC_TA_SOLICITADA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtValue.Focus();
                }
                else if ((!chkAssign.Checked) && (!chkNotAssign.Checked))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_SELECCIONAR_ASIGNAR_O_NO_ASIGNAR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkAssign.Focus();
                }
                else if ((chkAssign.Checked) && (chkNotAssign.Checked))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_SELECC_ASIG_O_DES_ASIG_IMPR_NO_AMBAS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkNotAssign.Checked = false;
                    chkAssign.Focus();
                }
                else if ((string.IsNullOrEmpty(txtValue.Text)) &&
                    (txtValue.Enabled.Equals(true)))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_PERFIL_O_TA_SOLICITADA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtValue.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtValue.Text)) &&
               (txtValue.Enabled.Equals(true)) &&
                    (Regex.IsMatch(txtValue.Text, " ")))
                {
                    MessageBox.Show(Resources.Reservations.NO_ESPACIO_TA_SOLICITADA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtValue.Focus();
                }
                else
                {
                    isValid = false;
                }
                return isValid;
            }
        }


        /// <summary>
        /// Asignación de foco al siguiente elemento cuando txtValue esta lleno 
        /// dependiendo de la opción selccionada
        /// </summary>
        private void txtValueChangeFocus()
        {
            if (rdoPrinterProfile.Checked)
            {
                if (txtValue.Text.Length > 0)
                {
                    btnAccept.Focus();
                }
            }
            else
            {
                if (txtValue.Text.Length > 5)
                {
                    btnAccept.Focus();
                }
            }
        }

        #endregion//End Commons


        #endregion//End MethodsClass



        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====


        /// <summary>
        /// Aborta el proceso al presionar la tecla ESC o ejecuta las funciones
        /// de la mascarilla al presionar la tecla ENTER
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



    }
}
