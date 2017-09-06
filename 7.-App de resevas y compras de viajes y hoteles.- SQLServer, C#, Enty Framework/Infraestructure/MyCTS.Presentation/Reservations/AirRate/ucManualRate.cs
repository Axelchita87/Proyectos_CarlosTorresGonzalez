using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{

    public partial class ucManualRate : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite ingresar una tarifa al record
        ///              de forma manual. Forma parte del flujo de reservaciones
        /// Creación:    Diciembre 08 -Marzo 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 
        private string sabreAnswer;
        private string money;
        private bool isValid;

        public ucManualRate()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtManualRate;
            this.LastControlFocus = btnAccept;
        }

       //Evento Load
        private void ucManualRate_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtManualRate.Focus();
        }

 
        /// <summary>
        /// Ejecución de las funciones de la mascarilla "Guarda tarifa manual al presionar el boton
        /// Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">btnAccept</param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            
            if (!IsValidBusinessRules)
            {
                CommandsSend();
                APIResponse();
            }
        }


        #region===== MethodsClass =====


        /// <summary>
        /// Validaciones de regla de negocio aplicables a esta mascarilla
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                isValid = true;
                if (string.IsNullOrEmpty(txtManualRate.Text))
                {
                    MessageBox.Show(Resources.Reservations.ING_COT_MANUAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtManualRate.Focus();
                }
                else if (txtManualRate.Text.Equals(Resources.Constants.ZERO))
                {
                    MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtManualRate.Focus();
                }
                else if ((txtManualRate.Text[0] == Convert.ToChar(Resources.Constants.ZERO)) && (txtManualRate.Text[1] == Convert.ToChar(Resources.Constants.ZERO)))
                {
                    MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtManualRate.Focus();
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
            string send;
            string saveManualRate;
            string manualRate;

            saveManualRate = Resources.Constants.COMMANDS_PQM;
            manualRate = string.Concat(Resources.Constants.INDENT,
                txtManualRate.Text);
            if (this.Parameters != null)
            {
                string parameter = this.Parameters[0];
                if (!string.IsNullOrEmpty(parameter))
                {
                    money = String.Concat(Resources.Constants.INDENT,
                        parameter);
                }

            }
            else
            {
                money = string.Empty;
            }
            send = string.Concat(saveManualRate,
                money,
                manualRate);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                
                    sabreAnswer = objCommand.SendReceive(send);
                
            }

        }



        /// <summary>
        /// Validación de errores posibles en la respuesta de MySabre
        /// </summary>
        private void APIResponse()
        {
            
                ERR_AirRateMenu.err_AirRateMenu(sabreAnswer);
                if (!ERR_AirRateMenu.Status)
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCAIR_RATE);
                }
                else
                {
                    MessageBox.Show(ERR_AirRateMenu.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
        }


        #endregion//End MethodsClass


        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====


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


        #endregion//Back to a Previous Usercontrol or Validate Enter KeyDown



        #region=====Change focus When a Textbox is Full=====

        //Evento txtManualRate1_TextChanged
        private void txtManualRate1_TextChanged(object sender, EventArgs e)
        {
            if (txtManualRate.Text.Length > 60)
            {
                btnAccept.Focus();
            }
        }
        #endregion//End Change focus When a Textbox is Full


    }
}
