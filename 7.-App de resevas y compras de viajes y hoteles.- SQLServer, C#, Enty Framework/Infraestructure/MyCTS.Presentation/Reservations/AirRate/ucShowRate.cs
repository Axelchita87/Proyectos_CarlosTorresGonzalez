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
    public partial class ucShowRate : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite seleccionar
        ///              alguna opción desplegada en MySabre despues de enviar el comando
        ///              WPA. Forma parte del flujo de reservaciones
        /// Creación:    Diciembre 08 -Marzo 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 
        private string sabreAnswer;
        private bool isValid;
        private bool firstEvaluation;

        public ucShowRate()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtShowRate;
            this.LastControlFocus = btnAccept;
        }


        //Evento Load
        private void ucShowRate_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            InitialValues();
        }

        /// <summary>
        /// Ejecuta las funciones de la mascarilla de "Ver opciones de cotización"
        /// al dar click en el boton Aceptar
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


        #region===== Change focus When a Textbox is Full =====

        //Evento txtShowRate_TextChanged
        private void txtShowRate_TextChanged(object sender, EventArgs e)
        {
            if (txtShowRate.Text.Length > 1)
            {
                btnAccept.Focus();
            }
        }

        #endregion


        #region===== MethodsClass =====


        /// <summary>
        /// asignación de valores iniciales envio de comando WPA
        /// y evaluación de errores
        /// </summary>
        private void InitialValues()
        {
            txtShowRate.Focus();
            string send = string.Empty;
            send = Resources.Constants.COMMANDS_WPA;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
            firstEvaluation = false; ;
            APIResponse();
        }

        /// <summary>
        /// Validaciones de regla de negocio aplicables a esta mascarilla
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                isValid = true;

                if (string.IsNullOrEmpty(txtShowRate.Text))
                {
                    MessageBox.Show(Resources.Reservations.INGRESA_RENGLON_TARIFA_A_MOSTRAR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtShowRate.Focus();
                }
                else if ((txtShowRate.Text.Equals(Resources.Constants.ZERO)) || (txtShowRate.Text.Equals(Resources.Constants.DOUBLEZERO)))
                {
                    MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtShowRate.Focus();
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
            string send = string.Empty;
            string quaLine = string.Empty;
            string showRate = string.Empty;
            string bySegments = string.Empty;
            string passPosition = string.Empty;
            string quarrelType = string.Empty;
            string money = string.Empty;
            firstEvaluation = true;
            showRate = Resources.Constants.COMMANDS_WP;
            quaLine = txtShowRate.Text;

            if ((txtShowRate.Text[0] == Convert.ToChar(Resources.Constants.ZERO)) && (2 == txtShowRate.Text.Length))
            {
                quaLine = quaLine.Remove(0, 1);
            }
            if (this.Parameters != null)
            {
                bySegments = this.Parameters[0];
                passPosition = this.Parameters[1];
                quarrelType = this.Parameters[2];
                money = string.Concat(Resources.Constants.CROSSLORAINE,
                    this.Parameters[3]);
                if (money.Equals(Resources.Constants.CROSSLORAINE))
                    money = string.Empty;
            }
            else
            {
                bySegments = string.Empty;
                passPosition = string.Empty;
                quarrelType = string.Empty;
                money = string.Empty;
            }
            send = string.Concat(showRate,
                quaLine,
                bySegments,
                passPosition,
                quarrelType,
                money);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
        }


        #region===== commons =====

        /// <summary>
        /// Validación de errores posibles en la respuesta de MySabre
        /// </summary>
        private void APIResponse()
        {
            ERR_AirRateMenu.err_AirRateMenu(sabreAnswer);
            if ((!ERR_AirRateMenu.Status) && (firstEvaluation))
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCAIR_RATE);
            }
            else if ((ERR_AirRateMenu.Status) && (!firstEvaluation))
            {
                MessageBox.Show(ERR_AirRateMenu.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if ((ERR_AirRateMenu.Status) && (firstEvaluation))
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


        #endregion//End MethodsClass

    }
}
