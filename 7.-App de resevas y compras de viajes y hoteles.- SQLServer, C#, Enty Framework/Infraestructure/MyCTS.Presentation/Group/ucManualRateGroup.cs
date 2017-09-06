using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    public partial class ucManualRateGroup : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite ingresar una tarifa al record
        ///              de forma manual. Forma parte del flujo de reservaciones
        /// Creación:    22 -Sept- 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Jessica
        /// </summary>
        
        private string sabreAnswer;
        private string send;
        public static bool manualRateGroup;

        public ucManualRateGroup()
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
            if (IsValidBusinessRules)
            {
                CommandsSend();
                APIResponse();
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(Resources.Constants.COMMANDS_AST_IO);
                    APIResponseSegment();
                }
                manualRateGroup = true;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCBOLETAGE_RECEIVED);
            }
        }

        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====

        /// <summary>
        /// Regreso a la mascarilla de "welcome" al presionar la tecla ESC
        /// o ejecutar las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            if (e.KeyData.Equals(Keys.Enter))
                btnAccept_Click(sender, e);
        }

        #endregion//Back to a Previous Usercontrol or Validate Enter KeyDown

        #region=====Change focus When a Textbox is Full=====

        //Evento txtManualRate1_TextChanged
        private void txtManualRate1_TextChanged(object sender, EventArgs e)
        {
            if (txtManualRate.Text.Length > 60)
                btnAccept.Focus();
        }

        #endregion//End Change focus When a Textbox is Full

        #region===== MethodsClass =====

        /// <summary>
        /// Validaciones de regla de negocio aplicables a esta mascarilla
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                if (string.IsNullOrEmpty(txtManualRate.Text))
                {
                    MessageBox.Show(Resources.Reservations.ING_COT_MANUAL, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtManualRate.Focus();
                    return false;
                }
                else if (txtManualRate.Text.Equals(Resources.Constants.ZERO))
                {
                    MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtManualRate.Focus();
                    return false;
                }
                else if ((txtManualRate.Text[0] == Convert.ToChar(Resources.Constants.ZERO)) && (txtManualRate.Text[1] == Convert.ToChar(Resources.Constants.ZERO)))
                {
                    MessageBox.Show(Resources.Reservations.CERO_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtManualRate.Focus();
                    return false;
                }
                else
                    return true;
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
            string money = string.Empty;
            saveManualRate = Resources.Constants.COMMANDS_PQM;
            manualRate = string.Concat(Resources.Constants.INDENT,
                txtManualRate.Text);
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
                //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCAIR_RATE);
            }
            else
                MessageBox.Show(ERR_AirRateMenu.CustomUserMsg, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// En este se tiene que aumentar 300 dias a la fecha actual para mandar
        /// el comando con la nueva fecha y las instucciones para realizar el 
        /// segmento de protección
        /// </summary>
        private void SegmentProtection()
        {
            string datefinal = string.Empty;
            DateTime lastDate = DateTime.Now.AddDays(300);
            datefinal = lastDate.ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
            send = string.Format(Resources.Constants.COMMANDS_SEGMENT_PROTECTION,
                    datefinal);
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                objCommand.SendReceive(Resources.Constants.COMMANDS_0A);
                objCommand.SendReceive(send);
            }
        }

        /// <summary>
        /// Se busca si existe un Segmento de Protección
        /// </summary>
        private void APIResponseSegment()
        {
            if ((!string.IsNullOrEmpty(sabreAnswer)))
            {
                ERR_ConcludeReservation.err_concludereservation(sabreAnswer);
                if (!ERR_ConcludeReservation.Segment)
                    SegmentProtection();
            }
        }

        #endregion//End MethodsClass
    }
}
