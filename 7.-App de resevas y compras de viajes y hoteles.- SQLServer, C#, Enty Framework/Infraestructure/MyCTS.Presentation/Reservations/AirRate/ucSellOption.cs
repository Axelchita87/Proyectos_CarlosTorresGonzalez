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
    public partial class ucSellOption : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite seleccionar alguna opción
        ///              desplegada despues de haber ejecutado el comando de la mascarilla
        ///              "Buscar otros vuelos". Forma parte del flujo de reservaciones
        /// Creación:    Diciembre 08 -Marzo 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 
        private bool StatusSellOption;
        private bool isValid;
        private string sabreAnswer;

        public ucSellOption()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
             ControlStyles.UserPaint |
             ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = chkSellOption;
            this.LastControlFocus = btnAccept;
        }


        /// <summary>
        /// Carga de valores iniciales en la mascarilla y 
        /// asignación de foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSellOption_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtOptionToSell.Enabled = false;
            txtOptionToSell.BackColor = SystemColors.Control;
            chkCancelItinerary.Enabled = false;
            btnMoveDown.Enabled = false;
            btnMoveUp.Enabled = false;
            chkSellOption.Focus();
            chkSellOption.Checked = true;
        }


        /// <summary>
        /// Ejecuta las funciones de la mascarilla de "Vende alguna opción
        /// desplegada" al dar click en el boton Aceptar
        /// </summary>
        /// <param name="sender">btnAccept</param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!IsValidBusinessRules)
            {
                CommandsSend();
                APIResponse();
            }
        }


        /// <summary>
        /// Ejecuta la función pageMoveUp() al dar click en el boton Reg.Pag
        /// </summary>
        /// <param name="sender">btnMoveUp</param>
        /// <param name="e"></param>
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            PageMoveUp();
        }


        /// <summary>
        /// Ejecuta la función pageMoveDown() al dar click en el boton Av.Pag
        /// </summary>
        /// <param name="sender">btnMoveDown</param>
        /// <param name="e"></param>
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            PageMoveDown();
        }


        #region===== Enabled disabled Controls when chkSellOption is Checked =====

        /// <summary>
        /// Habilita o deshabilita ciertos controles cuando la opción de "Vende alguna opción
        /// desplegada" esta activa o no
        /// </summary>
        /// <param name="sender">chkSellOption</param>
        /// <param name="e"></param>
        private void chkSellOption_CheckedChanged(object sender, EventArgs e)
        {
            StatusSellOption = chkSellOption.Checked;
            if (StatusSellOption)
            {
                txtOptionToSell.Enabled = true;
                chkCancelItinerary.Enabled = true;
                txtOptionToSell.BackColor = Color.White;
                btnMoveDown.Enabled = true;
                btnMoveUp.Enabled = true;
            }
            else
            {
                txtOptionToSell.Text = string.Empty;
                chkCancelItinerary.Checked = false;
                txtOptionToSell.Enabled = false;
                txtOptionToSell.BackColor = SystemColors.Control;
                chkCancelItinerary.Enabled = false;
                btnMoveDown.Enabled = false;
                btnMoveUp.Enabled = false;
            }
        }

        #endregion



        #region ===== Back to a Previous Usercontrol or Validate Enter KeyDown =====

        /// <summary>
        /// Regreso a la mascarilla de "Cotizacíon Aérea" al presionar la tecla ESC
        /// o ejecutar las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCAIR_RATE);



            if (e.KeyData.Equals(Keys.Enter))
            {

                btnAccept_Click(sender, e);
            }


        }
        #endregion



        #region===== Change Focus when a Textbox is Full =====

        //Evento txtOptionToSell_TextChanged
        private void txtOptionToSell_TextChanged(object sender, EventArgs e)
        {
            if (txtOptionToSell.Text.Length > 1)
            {
                chkCancelItinerary.Focus();
            }
        }

        #endregion



        #region===== methodsClass =====

        /// <summary>
        /// Validaciones de regla de negocio aplicables a esta mascarilla
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                isValid = true;

                if ((StatusSellOption) && (string.IsNullOrEmpty(txtOptionToSell.Text)))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_RENGLON_OPCION_A_VENDER, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOptionToSell.Focus();

                }
                else if ((txtOptionToSell.Text.Equals(Resources.Constants.ZERO)) || (txtOptionToSell.Text.Equals(Resources.Constants.DOUBLEZERO)))
                {
                    MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOptionToSell.Focus();

                }
                else
                {
                    isValid = false;
                }
                return isValid;
            }
        }


        /// <summary>
        /// Armado y envio del comando respectivo de la mascarilla 
        /// a MySabre
        /// </summary>
        private void CommandsSend()
        {
            string SellOptionDisplayed = string.Empty;
            string OptionToSell = string.Empty;
            string CancelItinerary = string.Empty;
            string send = string.Empty;
            bool StatusCancelItinerary;

            SellOptionDisplayed = Resources.Constants.COMMANDS_WC_CROSSLORAINE;
            OptionToSell = txtOptionToSell.Text;
            CancelItinerary = Resources.Constants.COMMANDS_X;
            StatusSellOption = chkSellOption.Checked;
            StatusCancelItinerary = chkCancelItinerary.Checked;
            int i = 0;
            bool num = int.TryParse(txtOptionToSell.Text, out i);

            if (StatusSellOption)
            {
                if (!StatusCancelItinerary)
                {
                    CancelItinerary = string.Empty;
                }
                send = string.Concat(SellOptionDisplayed,
                OptionToSell,
                CancelItinerary);
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(send);
                }
            }
        }



        #region ===== commons =====

        /// <summary>
        /// Validación de errores posibles en la respuesta de MySabre
        /// </summary>
        private void APIResponse()
        {
            if (!string.IsNullOrEmpty(sabreAnswer))
            {
                ERR_AirRateMenu.err_AirRateMenu(sabreAnswer);
            }
            if ((!ERR_AirRateMenu.Status))
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCAIR_RATE);
            }
            else
            {
                MessageBox.Show(ERR_AirRateMenu.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        /// <summary>
        /// Muestra las opciones previas en MySabre al enviar el comando MU a MySabre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageMoveUp()
        {
            string send;
            send = Resources.Constants.COMMANDS_MU;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        /// <summary>
        /// Muestra mas opciones en MySabre al enviar el comando MD a MySabre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageMoveDown()
        {
            string send;
            send = Resources.Constants.COMMANDS_MD;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(send);
            }
        }


        #endregion//End commons

        #endregion//End methodsClass

    }
}
