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

namespace MyCTS.Presentation
{
    public partial class ucCreatePhaseIV : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite realizar la emisión de un boleto de tipo
        ///              fase IV.
        /// Creación:    31 Agosto 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 

        
        private static string passengertype;
        public static string passengerType
        {
            get { return passengertype; }
            set { passengertype = value; }
        }

        private static string command;
        public static string Command
        {
            get { return command; }
            set { command = value; }
        }

        private static bool bysegments;
        public static bool bySegments
        {
            get { return bysegments; }
            set { bysegments = value; }
        }

        private static bool internationalflight;
        public static bool internationalFlight
        {
            get { return internationalflight; }
            set { internationalflight = value; }
        }

       public static bool international=false;

        public ucCreatePhaseIV()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtPassengerType;
            this.LastControlFocus = btnAccept;
        }

        /// <summary>
        /// Carga el user control y genera las rutinas pertinentes
        /// para aplicar la regla de negocio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCreatePhaseIV_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            LoadInitialValues();
        }

        /// <summary>
        /// Ejecuta las funciones para continuar con el flujo de fase IV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!IsValidBusinessRules)
            {
                LoadNextStep();
            }
        }

        #region===== MethodsClass =====

        /// <summary>
        /// Carga los valores iniciales del user control
        /// </summary>
        private void LoadInitialValues()
        {
            international = false;
            internationalflight = false;
            bysegments = false;
            passengertype = string.Empty;
            command = string.Empty;
            txtPassengerType.Focus();
        }

        /// <summary>
        /// Validaciones de regla de negocio aplicables a esta mascarilla
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                bool isValid = true;
                if (!string.IsNullOrEmpty(txtPassengerType.Text) && txtPassengerType.Text.Length < 3)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.CODIGO_TIPO_PAX_TRES_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassengerType.Focus();
                }
                else
                {
                    isValid = false;
                }
                return isValid;
            }
        }

        /// <summary>
        /// Carga el siguiente user control deacuerdo a las opciones seleccionadas
        /// y establece los valores de las variables estaticas
        /// </summary>
        private void LoadNextStep()
        {
            if (!string.IsNullOrEmpty(txtPassengerType.Text))
                passengertype = txtPassengerType.Text;
            if (chkInternationalFlight.Checked)
            {
                internationalflight = true;
                international = true;
            }
            if (chkBySegments.Checked)
            {
                bysegments = true;
                BuildSabreCommand();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_BY_SEGMENTS);
            }
            else
            {
                ucPhaseIVBySegments.commandBySegments = string.Empty;
                BuildSabreCommand();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_SELECT_MASK);
            }
        }

        /// <summary>
        /// Construye y envia el comando principal del user control al emulador
        /// de MySabre
        /// </summary>
        private void BuildSabreCommand()
        {
            string send = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_W_CROSSLORAINE_C;
            if (!string.IsNullOrEmpty(ucCreatePhaseIV.passengerType))
                send = string.Concat(send,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_P,
                    ucCreatePhaseIV.passengerType);
            command = send;

        }

        #endregion//End MethodsClass


        #region ===== Back to a Previous Usercontrol or Validate Enter KeyDown =====

        /// <summary>
        ///  Aborta el proceso al presionar la tecla ESC o continua con el flujo 
        /// de emision de boleto al presionar la tecla ENTER
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
        #endregion//End Back to a Previous Usercontrol or Validate Enter KeyDown

       
    }
}
