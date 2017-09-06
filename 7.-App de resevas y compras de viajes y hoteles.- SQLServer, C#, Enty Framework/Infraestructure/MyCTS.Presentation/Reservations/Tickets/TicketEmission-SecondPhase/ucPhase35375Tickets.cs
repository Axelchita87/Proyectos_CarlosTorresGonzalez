using System;
using System.Drawing;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;

namespace MyCTS.Presentation
{
    public partial class ucPhase35375Tickets : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite forzar la tarifa para la 
        ///              emisión de boleto en MySabre por segmentos o para todo el itinerario.
        ///              Forma parte del flujo de Reservaciones.
        ///              de forma manual
        /// Creación:    Diciembre 08 -Marzo 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 
        private static string phase35375;
        public static string Phase35375
        {
            get { return phase35375; }
            set { phase35375 = value; }
        }
        public static string segment;

        private string sendFirstRow;
        private string sendSecondRow;
        private string sendThirdRow;
        private string sendFourthRow;
        private string sendFifthRow;
        private string sendSixthRow;
        private string sendSeventhRow;
        private string sendEighthRow;
        private string sendAll;
        private string discountTypeBySegments;
        private string messageToSend;
        private bool isValidAllItinerary;
        private bool isValidBySegments;
        private bool statusPercentageBySegments;
        private bool statusQuantityBySegments;
        private bool statusMessageBox;
        private bool allowDecimal = true;

        public ucPhase35375Tickets()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            InitialControlFocus = rdoQuaAllItinerary;
            LastControlFocus = btnAccept;
        }

        /// <summary>
        /// Carga de la mascarilla de "Fase 3.5 y 3.75" y asignación de valores
        /// iniciales y foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucPhase35375_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            if (!Convert.ToBoolean(ParameterBL.GetParameterValue("AllowDecimalNumbers").Values))
            {
                txtDiscount.CharsIncluded = null;
                txtDiscountS1.CharsIncluded = null;
                txtDiscountS2.CharsIncluded = null;
                txtDiscountS3.CharsIncluded = null;
                txtDiscountS4.CharsIncluded = null;
                txtDiscountS5.CharsIncluded = null;
                txtDiscountS6.CharsIncluded = null;
                txtDiscountS7.CharsIncluded = null;
                txtDiscountS8.CharsIncluded = null;
                allowDecimal = false;
            }
            if (ucTicketsEmissionInstructions.ticketType.Equals(Resources.TicketEmission.Constants.PHASE35375))
            {
                rdoQuaAllItinerary.Checked = true;
                rdoQuaAllItinerary.Focus();
                //previousvalues();
            }
            else
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTAXES);
            }
        }


        /// <summary>
        /// Ejecución de las funciones de la pantalla de "fase 3.5 y 3.75"
        /// al presionar el boton Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">btnAccept</param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (rdoQuaAllItinerary.Checked)
            {
                if (!IsValidBusinessRulesAllItinerary)
                {
                    QuaAllItineraryCommandsSend();
                    LoadNextStep();
                }
            }
            else if (rdoQuaBySegments.Checked)
            {
                if (!IsValidBusinessRulesBySegments)
                {
                    QuaBySegmentsCommandsSend();
                    LoadNextStep();
                }
            }

        }



        #region ===== methodsClass =====


        #region===== rdoQuaAllItinerary =====


        /// <summary>
        /// Habilita o Deshabilita ciertos controles cuando la opción
        /// "Para todo el itinerario" esta activa
        /// </summary>
        private void QuaAllItineraryEnableDisableControls()
        {
            txtFareBasis.Enabled = true;
            txtFareBasis.BackColor = Color.White;
            txtFareBasisToShow.Enabled = true;
            txtFareBasisToShow.BackColor = Color.White;
            txtDiscount.Enabled = true;
            txtDiscount.BackColor = Color.White;
            txtTicketDesignator.Enabled = true;
            txtTicketDesignator.BackColor = Color.White;
            rdoPercentage.Enabled = true;
            rdoQuantity.Enabled = true;

            txtBeginS1.Enabled = false;
            txtBeginS1.BackColor = SystemColors.Control;
            txtBeginS1.Text = string.Empty;
            txtEndS1.Enabled = false;
            txtEndS1.BackColor = SystemColors.Control;
            txtEndS1.Text = string.Empty;
            txtFareBasisS1.Enabled = false;
            txtFareBasisS1.BackColor = SystemColors.Control;
            txtFareBasisS1.Text = string.Empty;
            txtFareBasisTS1.Enabled = false;
            txtFareBasisTS1.BackColor = SystemColors.Control;
            txtFareBasisTS1.Text = string.Empty;
            txtDiscountS1.Enabled = false;
            txtDiscountS1.BackColor = SystemColors.Control;
            txtDiscountS1.Text = string.Empty;
            txtTicketDesignatorS1.Enabled = false;
            txtTicketDesignatorS1.BackColor = SystemColors.Control;
            txtTicketDesignatorS1.Text = string.Empty;


            txtBeginS2.Enabled = false;
            txtBeginS2.BackColor = SystemColors.Control;
            txtBeginS2.Text = string.Empty;
            txtEndS2.Enabled = false;
            txtEndS2.BackColor = SystemColors.Control;
            txtEndS2.Text = string.Empty;
            txtFareBasisS2.Enabled = false;
            txtFareBasisS2.BackColor = SystemColors.Control;
            txtFareBasisS2.Text = string.Empty;
            txtFareBasisTS2.Enabled = false;
            txtFareBasisTS2.BackColor = SystemColors.Control;
            txtFareBasisTS2.Text = string.Empty;
            txtDiscountS2.Enabled = false;
            txtDiscountS2.BackColor = SystemColors.Control;
            txtDiscountS2.Text = string.Empty;
            txtTicketDesignatorS2.Enabled = false;
            txtTicketDesignatorS2.BackColor = SystemColors.Control;
            txtTicketDesignatorS2.Text = string.Empty;

            txtBeginS3.Enabled = false;
            txtBeginS3.BackColor = SystemColors.Control;
            txtBeginS3.Text = string.Empty;
            txtEndS3.Enabled = false;
            txtEndS3.BackColor = SystemColors.Control;
            txtEndS3.Text = string.Empty;
            txtFareBasisS3.Enabled = false;
            txtFareBasisS3.BackColor = SystemColors.Control;
            txtFareBasisS3.Text = string.Empty;
            txtFareBasisTS3.Enabled = false;
            txtFareBasisTS3.BackColor = SystemColors.Control;
            txtFareBasisTS3.Text = string.Empty;
            txtDiscountS3.Enabled = false;
            txtDiscountS3.BackColor = SystemColors.Control;
            txtDiscountS3.Text = string.Empty;
            txtTicketDesignatorS3.Enabled = false;
            txtTicketDesignatorS3.BackColor = SystemColors.Control;
            txtTicketDesignatorS3.Text = string.Empty;



            txtBeginS4.Enabled = false;
            txtBeginS4.BackColor = SystemColors.Control;
            txtBeginS4.Text = string.Empty;
            txtEndS4.Enabled = false;
            txtEndS4.BackColor = SystemColors.Control;
            txtEndS4.Text = string.Empty;
            txtFareBasisS4.Enabled = false;
            txtFareBasisS4.BackColor = SystemColors.Control;
            txtFareBasisS4.Text = string.Empty;
            txtFareBasisTS4.Enabled = false;
            txtFareBasisTS4.BackColor = SystemColors.Control;
            txtFareBasisTS4.Text = string.Empty;
            txtDiscountS4.Enabled = false;
            txtDiscountS4.BackColor = SystemColors.Control;
            txtDiscountS4.Text = string.Empty;
            txtTicketDesignatorS4.Enabled = false;
            txtTicketDesignatorS4.BackColor = SystemColors.Control;
            txtTicketDesignatorS4.Text = string.Empty;


            txtBeginS5.Enabled = false;
            txtBeginS5.BackColor = SystemColors.Control;
            txtBeginS5.Text = string.Empty;
            txtEndS5.Enabled = false;
            txtEndS5.BackColor = SystemColors.Control;
            txtEndS5.Text = string.Empty;
            txtFareBasisS5.Enabled = false;
            txtFareBasisS5.BackColor = SystemColors.Control;
            txtFareBasisS5.Text = string.Empty;
            txtFareBasisTS5.Enabled = false;
            txtFareBasisTS5.BackColor = SystemColors.Control;
            txtFareBasisTS5.Text = string.Empty;
            txtDiscountS5.Enabled = false;
            txtDiscountS5.BackColor = SystemColors.Control;
            txtDiscountS5.Text = string.Empty;
            txtTicketDesignatorS5.Enabled = false;
            txtTicketDesignatorS5.BackColor = SystemColors.Control;
            txtTicketDesignatorS5.Text = string.Empty;

            txtBeginS6.Enabled = false;
            txtBeginS6.BackColor = SystemColors.Control;
            txtBeginS6.Text = string.Empty;
            txtEndS6.Enabled = false;
            txtEndS6.BackColor = SystemColors.Control;
            txtEndS6.Text = string.Empty;
            txtFareBasisS6.Enabled = false;
            txtFareBasisS6.BackColor = SystemColors.Control;
            txtFareBasisS6.Text = string.Empty;
            txtFareBasisTS6.Enabled = false;
            txtFareBasisTS6.BackColor = SystemColors.Control;
            txtFareBasisTS6.Text = string.Empty;
            txtDiscountS6.Enabled = false;
            txtDiscountS6.BackColor = SystemColors.Control;
            txtDiscountS6.Text = string.Empty;
            txtTicketDesignatorS6.Enabled = false;
            txtTicketDesignatorS6.BackColor = SystemColors.Control;
            txtTicketDesignatorS6.Text = string.Empty;

            txtBeginS7.Enabled = false;
            txtBeginS7.BackColor = SystemColors.Control;
            txtBeginS7.Text = string.Empty;
            txtEndS7.Enabled = false;
            txtEndS7.BackColor = SystemColors.Control;
            txtEndS7.Text = string.Empty;
            txtFareBasisS7.Enabled = false;
            txtFareBasisS7.BackColor = SystemColors.Control;
            txtFareBasisS7.Text = string.Empty;
            txtFareBasisTS7.Enabled = false;
            txtFareBasisTS7.BackColor = SystemColors.Control;
            txtFareBasisTS7.Text = string.Empty;
            txtDiscountS7.Enabled = false;
            txtDiscountS7.BackColor = SystemColors.Control;
            txtDiscountS7.Text = string.Empty;
            txtTicketDesignatorS7.Enabled = false;
            txtTicketDesignatorS7.BackColor = SystemColors.Control;
            txtTicketDesignatorS7.Text = string.Empty;

            txtBeginS8.Enabled = false;
            txtBeginS8.BackColor = SystemColors.Control;
            txtBeginS8.Text = string.Empty;
            txtEndS8.Enabled = false;
            txtEndS8.BackColor = SystemColors.Control;
            txtEndS8.Text = string.Empty;
            txtFareBasisS8.Enabled = false;
            txtFareBasisS8.BackColor = SystemColors.Control;
            txtFareBasisS8.Text = string.Empty;
            txtFareBasisTS8.Enabled = false;
            txtFareBasisTS8.BackColor = SystemColors.Control;
            txtFareBasisTS8.Text = string.Empty;
            txtDiscountS8.Enabled = false;
            txtDiscountS8.BackColor = SystemColors.Control;
            txtDiscountS8.Text = string.Empty;
            txtTicketDesignatorS8.Enabled = false;
            txtTicketDesignatorS8.BackColor = SystemColors.Control;
            txtTicketDesignatorS8.Text = string.Empty;

            rdoQuantityBySegments.Checked = false;
            rdoQuantityBySegments.Enabled = false;
            rdoPercentageBySegments.Checked = false;
            rdoPercentageBySegments.Enabled = false;


        }


        /// <summary>
        /// Reglas de Negocio aplicables cuando la opción "Para todo el 
        /// itinerario esta activa
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRulesAllItinerary
        {
            get
            {
                isValidAllItinerary = true;
                if ((string.IsNullOrEmpty(txtFareBasis.Text)) &&
                       (string.IsNullOrEmpty(txtFareBasisToShow.Text)) &&
                       (string.IsNullOrEmpty(txtDiscount.Text)) &&
                       (string.IsNullOrEmpty(txtTicketDesignator.Text)) &&
                       (!rdoPercentage.Checked) &&
                       (!rdoQuantity.Checked))
                {
                    MessageBox.Show(Resources.Reservations.DEBES_ING_DATOS_EN_UN_CAMPO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFareBasis.Focus();
                }
                else if ((string.IsNullOrEmpty(txtDiscount.Text)) &&
                      (!string.IsNullOrEmpty(txtTicketDesignator.Text)))
                {
                    MessageBox.Show(Resources.Reservations.REQ_DESC_INGRESO_TICKET_DESIGNATOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDiscount.Focus();
                }
                //else if ((!string.IsNullOrEmpty(txtDiscount.Text)) &&
                // (string.IsNullOrEmpty(txtTicketDesignator.Text)))
                //{
                //    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_TICKET_DESIGNATOR_DESC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtTicketDesignator.Focus();
                //}
                else if ((string.IsNullOrEmpty(txtDiscount.Text)) &&
               ((rdoPercentage.Checked) ||
               (rdoQuantity.Checked)))
                {
                    messageToSend = string.Format(Resources.Reservations.INGRESA_DESC_A_APLICAR, "\n");
                    MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (rdoPercentage.Checked)
                    {
                        rdoPercentage.Checked = false;
                    }
                    else if (rdoQuantity.Checked)
                    {
                        rdoQuantity.Checked = false;
                    }
                    txtDiscount.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtDiscount.Text)) &&
                (!rdoPercentage.Checked) &&
                (!rdoQuantity.Checked))
                {
                    MessageBox.Show(Resources.Reservations.SELECCIONA_TIPO_DESC_A_APLICAR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rdoPercentage.Focus();
                }
                else if (allowDecimal && (rdoQuantity.Checked) && (!ValidateRegularExpression.ValidateTwoDecimalNumbers(txtDiscount.Text)))
                {
                    messageToSend = string.Format(Resources.Reservations.DES_CANT_DOS_DECIMALES, "\n");
                    MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if ((rdoPercentage.Checked) && (!string.IsNullOrEmpty(txtDiscount.Text)) && (txtDiscount.Text.Length > 3))
                {
                    messageToSend = string.Format(Resources.Reservations.DES_PORCENTAJE_DOS_NUMEROS, "\n");
                    MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    isValidAllItinerary = false;
                }
                return isValidAllItinerary;
            }
        }
        /// <summary>
        /// Armado y envio del comando correspondiente a la opción 
        /// "Para todo el itinerario"
        /// </summary>
        private void QuaAllItineraryCommandsSend()
        {
            //string sabreAnswer;
            string sendAllItinerary;
            string quaAllItinerary;
            string fareBasis;
            string fareBasisToShow;
            string ticketDesignator;
            string discount;
            string discountType;
            string passType;
            string passPosition;
            quaAllItinerary = Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_Q;
            passType = string.Empty;
            passPosition = string.Empty;
            if (!string.IsNullOrEmpty(txtFareBasis.Text))
            {
                fareBasis = txtFareBasis.Text;
            }
            else
            {
                fareBasis = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtFareBasisToShow.Text))
            {
                fareBasisToShow = string.Concat(Resources.Constants.INDENT,
                txtFareBasisToShow.Text);
            }
            else
            {
                fareBasisToShow = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtTicketDesignator.Text))
            {
                ticketDesignator = string.Concat(Resources.Constants.INDENT,
                    txtTicketDesignator.Text);
            }
            else
            {
                ticketDesignator = string.Empty;
            }
            if ((rdoQuantity.Checked) &&
                (!string.IsNullOrEmpty(txtDiscount.Text)))
            {
                discountType = Resources.Constants.COMMANDS_SLASH_SLASH_DA;
            }
            else if ((rdoPercentage.Checked) &&
                (!string.IsNullOrEmpty(txtDiscount.Text)))
            {
                discountType = Resources.Constants.COMMANDS_SLASH_SLASH_DP;
            }
            else
            {
                discountType = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtDiscount.Text))
            {
                discount = txtDiscount.Text;
            }
            else
            {
                discount = string.Empty;
            }
            sendAllItinerary = string.Concat(quaAllItinerary,
                fareBasis,
                fareBasisToShow,
                discountType,
                discount,
                ticketDesignator,
                passType,
                passPosition);

            phase35375 = sendAllItinerary;

            //string[] sendInfo = new string[] {rdoQuaAllItinerary.Checked.ToString(), txtFareBasis.Text, txtFareBasisToShow.Text,
            //    txtDiscount.Text, txtTicketDesignator.Text,rdoQuantity.Checked.ToString(), rdoPercentage.Checked.ToString(),
            //    rdoQuaBySegments.Checked.ToString(), txtBeginS1.Text, txtEndS1.Text, txtFareBasisS1.Text, txtFareBasisTS1.Text,
            //    txtDiscountS1.Text, txtTicketDesignatorS1.Text, txtBeginS2.Text, txtEndS2.Text, txtFareBasisS2.Text, txtFareBasisTS2.Text,
            //    txtDiscountS2.Text, txtTicketDesignatorS2.Text,txtBeginS3.Text, txtEndS3.Text, txtFareBasisS3.Text, txtFareBasisTS3.Text, 
            //    txtDiscountS3.Text, txtTicketDesignatorS3.Text, txtBeginS4.Text, txtEndS4.Text, txtFareBasisS4.Text, txtFareBasisTS4.Text,
            //    txtDiscountS4.Text, txtTicketDesignatorS4.Text, txtBeginS5.Text, txtEndS5.Text, txtFareBasisS5.Text, txtFareBasisTS5.Text, 
            //    txtDiscountS5.Text, txtTicketDesignatorS5.Text, txtBeginS6.Text, txtEndS6.Text,  txtFareBasisS6.Text, txtFareBasisTS6.Text,
            //    txtDiscountS6.Text, txtTicketDesignatorS6.Text, txtBeginS7.Text, txtEndS7.Text, txtFareBasisS7.Text, txtFareBasisTS7.Text,
            //    txtDiscountS7.Text, txtTicketDesignatorS7.Text, txtBeginS8.Text, txtEndS8.Text, txtFareBasisS8.Text, txtFareBasisTS8.Text,
            //    txtDiscountS8.Text, txtTicketDesignatorS8.Text, rdoQuaBySegments.Checked.ToString(), rdoPercentageBySegments.Checked.ToString()};

            //userControlsPreviousValues.Phase35375TicketsParameters = sendInfo;

        }





        #endregion//End rdoQuaAllItinerary



        #region===== rdoQuaBySegments =====

        /// <summary>
        /// Habilita o Deshabilita ciertos controles cuando la opción
        /// "Por segmentos" esta activa
        /// </summary>
        private void QuaBySegmentsEnableDisableControls()
        {
            //Deshabilitar componentes para todo el itinerario
            txtFareBasis.Enabled = false;
            txtFareBasis.BackColor = SystemColors.Control;
            txtFareBasis.Text = string.Empty;
            txtFareBasisToShow.Enabled = false;
            txtFareBasisToShow.BackColor = SystemColors.Control;
            txtFareBasisToShow.Text = string.Empty;
            txtDiscount.Enabled = false;
            txtDiscount.BackColor = SystemColors.Control;
            txtDiscount.Text = string.Empty;
            txtTicketDesignator.Enabled = false;
            txtTicketDesignator.BackColor = SystemColors.Control;
            txtTicketDesignator.Text = string.Empty;
            rdoPercentage.Checked = false;
            rdoPercentage.Enabled = false;
            rdoQuantity.Checked = false;
            rdoQuantity.Enabled = false;

            //Habilitar controles de opcion por segmentos
            txtBeginS1.Enabled = true;
            txtBeginS1.BackColor = Color.White;
            txtEndS1.Enabled = true;
            txtEndS1.BackColor = Color.White;
            txtFareBasisS1.Enabled = true;
            txtFareBasisS1.BackColor = Color.White;
            txtFareBasisTS1.Enabled = true;
            txtFareBasisTS1.BackColor = Color.White;
            txtDiscountS1.Enabled = true;
            txtDiscountS1.BackColor = Color.White;
            txtTicketDesignatorS1.Enabled = true;
            txtTicketDesignatorS1.BackColor = Color.White;

            txtBeginS2.Enabled = true;
            txtBeginS2.BackColor = Color.White;
            txtEndS2.Enabled = true;
            txtEndS2.BackColor = Color.White;
            txtFareBasisS2.Enabled = true;
            txtFareBasisS2.BackColor = Color.White;
            txtFareBasisTS2.Enabled = true;
            txtFareBasisTS2.BackColor = Color.White;
            txtDiscountS2.Enabled = true;
            txtDiscountS2.BackColor = Color.White;
            txtTicketDesignatorS2.Enabled = true;
            txtTicketDesignatorS2.BackColor = Color.White;

            txtBeginS3.Enabled = true;
            txtBeginS3.BackColor = Color.White;
            txtEndS3.Enabled = true;
            txtEndS3.BackColor = Color.White;
            txtFareBasisS3.Enabled = true;
            txtFareBasisS3.BackColor = Color.White;
            txtFareBasisTS3.Enabled = true;
            txtFareBasisTS3.BackColor = Color.White;
            txtDiscountS3.Enabled = true;
            txtDiscountS3.BackColor = Color.White;
            txtTicketDesignatorS3.Enabled = true;
            txtTicketDesignatorS3.BackColor = Color.White;

            txtBeginS4.Enabled = true;
            txtBeginS4.BackColor = Color.White;
            txtEndS4.Enabled = true;
            txtEndS4.BackColor = Color.White;
            txtFareBasisS4.Enabled = true;
            txtFareBasisS4.BackColor = Color.White;
            txtFareBasisTS4.Enabled = true;
            txtFareBasisTS4.BackColor = Color.White;
            txtDiscountS4.Enabled = true;
            txtDiscountS4.BackColor = Color.White;
            txtTicketDesignatorS4.Enabled = true;
            txtTicketDesignatorS4.BackColor = Color.White;

            txtBeginS5.Enabled = true;
            txtBeginS5.BackColor = Color.White;
            txtEndS5.Enabled = true;
            txtEndS5.BackColor = Color.White;
            txtFareBasisS5.Enabled = true;
            txtFareBasisS5.BackColor = Color.White;
            txtFareBasisTS5.Enabled = true;
            txtFareBasisTS5.BackColor = Color.White;
            txtDiscountS5.Enabled = true;
            txtDiscountS5.BackColor = Color.White;
            txtTicketDesignatorS5.Enabled = true;
            txtTicketDesignatorS5.BackColor = Color.White;

            txtBeginS6.Enabled = true;
            txtBeginS6.BackColor = Color.White;
            txtEndS6.Enabled = true;
            txtEndS6.BackColor = Color.White;
            txtFareBasisS6.Enabled = true;
            txtFareBasisS6.BackColor = Color.White;
            txtFareBasisTS6.Enabled = true;
            txtFareBasisTS6.BackColor = Color.White;
            txtDiscountS6.Enabled = true;
            txtDiscountS6.BackColor = Color.White;
            txtTicketDesignatorS6.Enabled = true;
            txtTicketDesignatorS6.BackColor = Color.White;

            txtBeginS7.Enabled = true;
            txtBeginS7.BackColor = Color.White;
            txtEndS7.Enabled = true;
            txtEndS7.BackColor = Color.White;
            txtFareBasisS7.Enabled = true;
            txtFareBasisS7.BackColor = Color.White;
            txtFareBasisTS7.Enabled = true;
            txtFareBasisTS7.BackColor = Color.White;
            txtDiscountS7.Enabled = true;
            txtDiscountS7.BackColor = Color.White;
            txtTicketDesignatorS7.Enabled = true;
            txtTicketDesignatorS7.BackColor = Color.White;

            txtBeginS8.Enabled = true;
            txtBeginS8.BackColor = Color.White;
            txtEndS8.Enabled = true;
            txtEndS8.BackColor = Color.White;
            txtFareBasisS8.Enabled = true;
            txtFareBasisS8.BackColor = Color.White;
            txtFareBasisTS8.Enabled = true;
            txtFareBasisTS8.BackColor = Color.White;
            txtDiscountS8.Enabled = true;
            txtDiscountS8.BackColor = Color.White;
            txtTicketDesignatorS8.Enabled = true;
            txtTicketDesignatorS8.BackColor = Color.White;
            rdoQuantityBySegments.Enabled = true;
            rdoPercentageBySegments.Enabled = true;

        }



        /// <summary>
        /// Reglas de Negocio aplicables cuando la opción "Por segmentos" 
        /// esta activa
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRulesBySegments
        {
            get
            {
                statusQuantityBySegments = rdoQuantityBySegments.Checked;
                statusPercentageBySegments = rdoPercentageBySegments.Checked;
                statusMessageBox = false;
                CleanPreviousValues();
                BusinnesRulesFirstRow();
                if (!isValidBySegments)
                {
                    BusinnesRulesSecondRow();
                    BusinessRulesThirdRow();
                    BusinessRulesFourthRow();
                    BusinessRulesFifthRow();
                    BusinessRulesSixthRow();
                    BusinessRulesSeventhRow();
                    BusinessRulesEighthRow();
                }
                return isValidBySegments;
            }
        }


        /// <summary>
        /// Reglas de Negocio aplicables cuando la opción "Por segmentos" 
        /// esta activa para la primera fila
        /// </summary>
        /// <returns></returns>
        private void BusinnesRulesFirstRow()
        {
            statusMessageBox = false;
            if ((string.IsNullOrEmpty(txtBeginS1.Text)) &&
            (string.IsNullOrEmpty(txtEndS1.Text)) &&
            (string.IsNullOrEmpty(txtFareBasisS1.Text)) &&
            (string.IsNullOrEmpty(txtFareBasisTS1.Text) &&
            (string.IsNullOrEmpty(txtDiscountS1.Text)) &&
            (string.IsNullOrEmpty(txtTicketDesignatorS1.Text)) &&
            (!statusPercentageBySegments) &&
            (!statusQuantityBySegments)))
            {
                MessageBox.Show(Resources.Reservations.DEBES_INGRESAR_DATOS_PRIMERA_FILA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtBeginS1.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtBeginS1.Text)) &&
                (string.IsNullOrEmpty(txtEndS1.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisS1.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisTS1.Text) &&
                (string.IsNullOrEmpty(txtDiscountS1.Text)) &&
                (string.IsNullOrEmpty(txtTicketDesignatorS1.Text)) &&
                (!statusPercentageBySegments) &&
                (!statusQuantityBySegments)))
            {
                messageToSend = string.Format(Resources.Reservations.INGRESA_PRIMERA_FILA_CON_DATO_ADICIONAL, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtFareBasisS1.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtBeginS1.Text)) &&
                (!string.IsNullOrEmpty(txtEndS1.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisS1.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisTS1.Text) &&
                (string.IsNullOrEmpty(txtDiscountS1.Text)) &&
                (string.IsNullOrEmpty(txtTicketDesignatorS1.Text)) &&
                (!statusPercentageBySegments) &&
                (!statusQuantityBySegments)))
            {
                messageToSend = string.Format(Resources.Reservations.INGRESA_FARE_BASIS_FBASIS_A_MOSTRAR_DESC_TDESIGNATOR, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtFareBasisS1.Focus();

            }
            else if ((string.IsNullOrEmpty(txtBeginS1.Text)) &&
                ((!string.IsNullOrEmpty(txtEndS1.Text)) ||
                (!string.IsNullOrEmpty(txtFareBasisS1.Text)) ||
                (!string.IsNullOrEmpty(txtFareBasisTS1.Text) ||
                (!string.IsNullOrEmpty(txtDiscountS1.Text)) ||
                (!string.IsNullOrEmpty(txtTicketDesignatorS1.Text)) ||
                (statusPercentageBySegments) ||
                (statusQuantityBySegments))))
            {
                messageToSend = string.Format(Resources.Reservations.DEBES_ING_SEGMENTO_INICIO_PRIMERA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtBeginS1.Focus();
            }

            else if ((string.IsNullOrEmpty(txtDiscountS1.Text)) &&
                ((statusPercentageBySegments) ||
                (statusQuantityBySegments)))
            {
                messageToSend = string.Format(Resources.Reservations.INGRESA_DESC_A_APLICAR_PRIMERA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                if (statusPercentageBySegments)
                {
                    rdoPercentageBySegments.Checked = false;
                }
                else if (statusQuantityBySegments)
                {
                    rdoQuantityBySegments.Checked = false;
                }
                txtDiscountS1.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtDiscountS1.Text)) &&
            (!statusQuantityBySegments) &&
            (!statusPercentageBySegments))
            {
                MessageBox.Show(Resources.Reservations.SELECCIONA_TIPO_DESC_A_APLICAR_PRIMERA_FILA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                rdoPercentageBySegments.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtTicketDesignatorS1.Text)) &&
            (string.IsNullOrEmpty(txtDiscountS1.Text)))
            {
                MessageBox.Show(Resources.Reservations.REQ_DESC_INGRESO_TICKET_DESIGNATOR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS1.Focus();
            }
            //else if ((string.IsNullOrEmpty(txtTicketDesignatorS1.Text)) &&
            //(!string.IsNullOrEmpty(txtDiscountS1.Text)))
            //{
            //    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_TICKET_DESIGNATOR_DESC_PRIMERA_FILA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    statusMessageBox = true;
            //    txtTicketDesignatorS1.Focus();
            //}
            else if (allowDecimal && (statusQuantityBySegments) && (!string.IsNullOrEmpty(txtDiscountS1.Text)) && (!ValidateRegularExpression.ValidateTwoDecimalNumbers(txtDiscountS1.Text)))
            {
                messageToSend = string.Format(Resources.Reservations.DES_CANT_DOS_DECIMALES_PRIMERA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS1.Focus();
            }
            else if ((statusPercentageBySegments) && (!string.IsNullOrEmpty(txtDiscountS1.Text)) && (Convert.ToInt32(txtDiscountS1.Text) > 100))
            {
                messageToSend = string.Format(Resources.Reservations.DES_PORCENTAJE_DOS_NUMEROS_PRIMERA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS1.Focus();
            }

            isValidBySegments = statusMessageBox;
        }


        /// <summary>
        /// Reglas de Negocio aplicables cuando la opción "Por segmentos" 
        /// esta activa para la segunda fila
        /// </summary>
        /// <returns></returns>
        private void BusinnesRulesSecondRow()
        {
            if ((!string.IsNullOrEmpty(txtBeginS2.Text)) &&
               (string.IsNullOrEmpty(txtEndS2.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisS2.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisTS2.Text) &&
               (string.IsNullOrEmpty(txtDiscountS2.Text)) &&
               (string.IsNullOrEmpty(txtTicketDesignatorS2.Text))))
            {
                messageToSend = string.Format(Resources.Reservations.INGRESA_SEGUNDA_FILA_CON_DATO_ADICIONAL, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtFareBasisS2.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtBeginS2.Text)) &&
               (!string.IsNullOrEmpty(txtEndS2.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisS2.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisTS2.Text) &&
               (string.IsNullOrEmpty(txtDiscountS2.Text)) &&
               (string.IsNullOrEmpty(txtTicketDesignatorS2.Text))))
            {
                messageToSend = string.Format(Resources.Reservations.INGRESA_FARE_BASIS_FBASIS_A_MOSTRAR_DESC_TDESIGNATOR_SEGUNDA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtFareBasisS2.Focus();
            }
            else if ((string.IsNullOrEmpty(txtBeginS2.Text)) &&
                ((!string.IsNullOrEmpty(txtEndS2.Text)) ||
                (!string.IsNullOrEmpty(txtFareBasisS2.Text)) ||
                (!string.IsNullOrEmpty(txtFareBasisTS2.Text)) ||
                (!string.IsNullOrEmpty(txtDiscountS2.Text)) ||
                (!string.IsNullOrEmpty(txtTicketDesignatorS2.Text))))
            {
                messageToSend = string.Format(Resources.Reservations.DEBES_ING_SEGMENTO_INICIO_SEGUNDA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtBeginS2.Focus();
            }
            else if ((string.IsNullOrEmpty(txtDiscountS2.Text)) &&
            (!string.IsNullOrEmpty(txtTicketDesignatorS2.Text)))
            {
                messageToSend = string.Format(Resources.Reservations.REQ_DESC_TICKET_DESIGNATOR_SEGUNDA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS2.Focus();

            }
            //else if ((string.IsNullOrEmpty(txtTicketDesignatorS2.Text)) &&
            //(!string.IsNullOrEmpty(txtDiscountS2.Text)))
            //{
            //    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_TICKET_DESIGNATOR_DESC_SEGUNDA_FILA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    statusMessageBox = true;
            //    txtTicketDesignatorS2.Focus();
            //}
            else if ((!string.IsNullOrEmpty(txtDiscountS2.Text)) &&
           (!statusPercentageBySegments) &&
           (!statusQuantityBySegments))
            {
                MessageBox.Show(Resources.Reservations.SELECCIONA_TIPO_DES_APLICAR_SEGUNDA_FILA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                rdoPercentageBySegments.Focus();
            }
            else if (allowDecimal && (statusQuantityBySegments) && (!string.IsNullOrEmpty(txtDiscountS2.Text)) && (!ValidateRegularExpression.ValidateTwoDecimalNumbers(txtDiscountS2.Text)))
            {
                messageToSend = string.Format(Resources.Reservations.DES_CANT_DOS_DECIMALES_SEGUNDA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS2.Focus();
            }
            else if ((statusPercentageBySegments) && (!string.IsNullOrEmpty(txtDiscountS2.Text)) && (Convert.ToInt32(txtDiscountS2.Text) > 100))
            {
                messageToSend = string.Format(Resources.Reservations.DES_PORCENTAJE_DOS_NUMEROS_SEGUNDA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS2.Focus();
            }

            isValidBySegments = statusMessageBox;
        }


        /// <summary>
        /// Reglas de Negocio aplicables cuando la opción "Por segmentos" 
        /// esta activa para la tercera fila
        /// </summary>
        /// <returns></returns>
        private void BusinessRulesThirdRow()
        {
            if ((!string.IsNullOrEmpty(txtBeginS3.Text)) &&
               (string.IsNullOrEmpty(txtEndS3.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisS3.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisTS3.Text) &&
               (string.IsNullOrEmpty(txtDiscountS3.Text)) &&
               (string.IsNullOrEmpty(txtTicketDesignatorS3.Text))))
            {
                messageToSend = string.Format(Resources.Reservations.INGRESA_TERCERA_FILA_CON_DATO_ADICIONAL, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtFareBasisS3.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtBeginS3.Text)) &&
                (!string.IsNullOrEmpty(txtEndS3.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisS3.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisTS3.Text) &&
                (string.IsNullOrEmpty(txtDiscountS3.Text)) &&
                (string.IsNullOrEmpty(txtTicketDesignatorS3.Text))))
            {
                messageToSend = string.Format(Resources.Reservations.INGRESA_FARE_BASIS_FBASIS_A_MOSTRAR_DESC_TDESIGNATOR_TERCERA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtFareBasisS3.Focus();
            }
            else if ((string.IsNullOrEmpty(txtBeginS3.Text)) &&
                ((!string.IsNullOrEmpty(txtEndS3.Text)) ||
                (!string.IsNullOrEmpty(txtFareBasisS3.Text)) ||
                (!string.IsNullOrEmpty(txtFareBasisTS3.Text) ||
                (!string.IsNullOrEmpty(txtDiscountS3.Text)) ||
                (!string.IsNullOrEmpty(txtTicketDesignatorS3.Text)))))
            {
                messageToSend = string.Format(Resources.Reservations.DEBES_ING_SEGMENTO_INICIO_TERCERA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtBeginS3.Focus();
            }
            else if ((string.IsNullOrEmpty(txtDiscountS3.Text)) &&
               (!string.IsNullOrEmpty(txtTicketDesignatorS3.Text)))
            {
                messageToSend = string.Format(Resources.Reservations.REQ_DESC_TICKET_DESIGNATOR_TERCERA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS3.Focus();
            }
            //else if ((string.IsNullOrEmpty(txtTicketDesignatorS3.Text)) &&
            //(!string.IsNullOrEmpty(txtDiscountS3.Text)))
            //{
            //    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_TICKET_DESIGNATOR_DESC_TERCERA_FILA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    statusMessageBox = true;
            //    txtTicketDesignatorS3.Focus();
            //}
            else if ((!string.IsNullOrEmpty(txtDiscountS3.Text)) &&
           (!statusPercentageBySegments) &&
           (!statusQuantityBySegments))
            {
                MessageBox.Show(Resources.Reservations.SELECCIONA_TIPO_DES_APLICAR_TERCERA_FILA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                rdoPercentageBySegments.Focus();
            }
            else if (allowDecimal && (statusQuantityBySegments) && (!string.IsNullOrEmpty(txtDiscountS3.Text)) && (!ValidateRegularExpression.ValidateTwoDecimalNumbers(txtDiscountS3.Text)))
            {
                messageToSend = string.Format(Resources.Reservations.DES_CANT_DOS_DECIMALES_TERCERA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS3.Focus();
            }
            else if ((statusPercentageBySegments) && (!string.IsNullOrEmpty(txtDiscountS3.Text)) && (Convert.ToInt32(txtDiscountS3.Text) > 100))
            {
                messageToSend = string.Format(Resources.Reservations.DES_PORCENTAJE_DOS_NUMEROS_TERCERA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS3.Focus();
            }

            isValidBySegments = statusMessageBox;
        }


        /// <summary>
        /// Reglas de Negocio aplicables cuando la opción "Por segmentos" 
        /// esta activa para la cuarta fila
        /// </summary>
        /// <returns></returns>
        private void BusinessRulesFourthRow()
        {
            if ((!string.IsNullOrEmpty(txtBeginS4.Text)) &&
               (string.IsNullOrEmpty(txtEndS4.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisS4.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisTS4.Text) &&
               (string.IsNullOrEmpty(txtDiscountS4.Text)) &&
               (string.IsNullOrEmpty(txtTicketDesignatorS4.Text))))
            {
                messageToSend = string.Format(Resources.Reservations.INGRESA_CUARTA_FILA_CON_DATO_ADICIONAL, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtFareBasisS4.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtBeginS4.Text)) &&
                (!string.IsNullOrEmpty(txtEndS4.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisS4.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisTS4.Text) &&
                (string.IsNullOrEmpty(txtDiscountS4.Text)) &&
                (string.IsNullOrEmpty(txtTicketDesignatorS4.Text))))
            {
                messageToSend = string.Format(Resources.Reservations.INGRESA_FARE_BASIS_FBASIS_A_MOSTRAR_DESC_TDESIGNATOR_CUARTA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtFareBasisS4.Focus();
            }
            else if ((string.IsNullOrEmpty(txtBeginS4.Text)) &&
                ((!string.IsNullOrEmpty(txtEndS4.Text)) ||
                (!string.IsNullOrEmpty(txtFareBasisS4.Text)) ||
                (!string.IsNullOrEmpty(txtFareBasisTS4.Text) ||
                (!string.IsNullOrEmpty(txtDiscountS4.Text)))))
            {
                messageToSend = string.Format(Resources.Reservations.DEBES_ING_SEGMENTO_INICIO_CUARTA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtBeginS4.Focus();
            }
            else if ((string.IsNullOrEmpty(txtDiscountS4.Text)) &&
               (!string.IsNullOrEmpty(txtTicketDesignatorS4.Text)))
            {
                messageToSend = string.Format(Resources.Reservations.REQ_DESC_TICKET_DESIGNATOR_CUARTA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS4.Focus();
            }
            //else if ((string.IsNullOrEmpty(txtTicketDesignatorS4.Text)) &&
            //   (!string.IsNullOrEmpty(txtDiscountS4.Text)))
            //{
            //    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_TICKET_DESIGNATOR_DESC_CUARTA_FILA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    statusMessageBox = true;
            //    txtTicketDesignatorS4.Focus();
            //}
            else if ((!string.IsNullOrEmpty(txtDiscountS4.Text)) &&
           (!statusPercentageBySegments) &&
           (!statusQuantityBySegments))
            {
                MessageBox.Show(Resources.Reservations.SELECCIONA_TIPO_DES_APLICAR_CUARTA_FILA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                rdoPercentageBySegments.Focus();
            }
            else if (allowDecimal && (statusQuantityBySegments) && (!string.IsNullOrEmpty(txtDiscountS4.Text)) && (!ValidateRegularExpression.ValidateTwoDecimalNumbers(txtDiscountS4.Text)))
            {
                messageToSend = string.Format(Resources.Reservations.DES_CANT_DOS_DECIMALES_CUARTA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS4.Focus();
            }
            else if ((statusPercentageBySegments) && (!string.IsNullOrEmpty(txtDiscountS4.Text)) && (Convert.ToInt32(txtDiscountS4.Text) > 100))
            {
                messageToSend = string.Format(Resources.Reservations.DES_PORCENTAJE_DOS_NUMEROS_CUARTA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS4.Focus();
            }

            isValidBySegments = statusMessageBox;
        }


        /// <summary>
        /// Reglas de Negocio aplicables cuando la opción "Por segmentos" 
        /// esta activa para la quinta fila
        /// </summary>
        /// <returns></returns>
        private void BusinessRulesFifthRow()
        {
            if ((!string.IsNullOrEmpty(txtBeginS5.Text)) &&
                (string.IsNullOrEmpty(txtEndS5.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisS5.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisTS5.Text) &&
                (string.IsNullOrEmpty(txtDiscountS5.Text)) &&
                (string.IsNullOrEmpty(txtTicketDesignatorS5.Text))))
            {
                messageToSend = string.Format(Resources.Reservations.INGRESA_QUINTA_FILA_CON_DATO_ADICIONAL, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtFareBasisS5.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtBeginS5.Text)) &&
                (!string.IsNullOrEmpty(txtEndS5.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisS5.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisTS5.Text) &&
                (string.IsNullOrEmpty(txtDiscountS5.Text)) &&
                (string.IsNullOrEmpty(txtTicketDesignatorS5.Text))))
            {
                messageToSend = string.Format(Resources.Reservations.INGRESA_FARE_BASIS_FBASIS_A_MOSTRAR_DESC_TDESIGNATOR_QUINTA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtFareBasisS5.Focus();
            }
            else if ((string.IsNullOrEmpty(txtBeginS5.Text)) &&
                ((!string.IsNullOrEmpty(txtEndS5.Text)) ||
                (!string.IsNullOrEmpty(txtFareBasisS5.Text)) ||
                (!string.IsNullOrEmpty(txtFareBasisTS5.Text) ||
                (!string.IsNullOrEmpty(txtDiscountS5.Text)) ||
                (!string.IsNullOrEmpty(txtTicketDesignatorS5.Text)))))
            {
                messageToSend = string.Format(Resources.Reservations.DEBES_ING_SEGMENTO_INICIO_QUINTA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtBeginS5.Focus();
            }
            else if ((string.IsNullOrEmpty(txtDiscountS5.Text)) &&
               (!string.IsNullOrEmpty(txtTicketDesignatorS5.Text)))
            {
                messageToSend = string.Format(Resources.Reservations.REQ_DESC_TICKET_DESIGNATOR_QUINTA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS5.Focus();
            }
            //else if ((string.IsNullOrEmpty(txtTicketDesignatorS5.Text)) &&
            //   (!string.IsNullOrEmpty(txtDiscountS5.Text)))
            //{
            //    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_TICKET_DESIGNATOR_DESC_QUINTA_FILA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    statusMessageBox = true;
            //    txtTicketDesignatorS5.Focus();
            //}
            else if ((!string.IsNullOrEmpty(txtDiscountS5.Text)) &&
            (!statusPercentageBySegments) &&
            (!statusQuantityBySegments))
            {
                MessageBox.Show(Resources.Reservations.SELECCIONA_TIPO_DES_APLICAR_QUINTA_FILA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                rdoPercentageBySegments.Focus();

            }
            else if (allowDecimal && (statusQuantityBySegments) && (!string.IsNullOrEmpty(txtDiscountS5.Text)) && (!ValidateRegularExpression.ValidateTwoDecimalNumbers(txtDiscountS5.Text)))
            {
                messageToSend = string.Format(Resources.Reservations.DES_CANT_DOS_DECIMALES_QUINTA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS5.Focus();
            }
            else if ((statusPercentageBySegments) && (!string.IsNullOrEmpty(txtDiscountS5.Text)) && (Convert.ToInt32(txtDiscountS5.Text) > 100))
            {
                messageToSend = string.Format(Resources.Reservations.DES_PORCENTAJE_DOS_NUMEROS_QUINTA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS5.Focus();
            }

            isValidBySegments = statusMessageBox;
        }


        /// <summary>
        /// Reglas de Negocio aplicables cuando la opción "Por segmentos" 
        /// esta activa para la sexta fila
        /// </summary>
        /// <returns></returns>
        private void BusinessRulesSixthRow()
        {
            if ((!string.IsNullOrEmpty(txtBeginS6.Text)) &&
               (string.IsNullOrEmpty(txtEndS6.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisS6.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisTS6.Text) &&
               (string.IsNullOrEmpty(txtDiscountS6.Text)) &&
               (string.IsNullOrEmpty(txtTicketDesignatorS6.Text))))
            {
                messageToSend = string.Format(Resources.Reservations.INGRESA_SEXTA_FILA_CON_DATO_ADICIONAL, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtFareBasisS6.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtBeginS6.Text)) &&
               (!string.IsNullOrEmpty(txtEndS6.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisS6.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisTS6.Text) &&
               (string.IsNullOrEmpty(txtDiscountS6.Text)) &&
               (string.IsNullOrEmpty(txtTicketDesignatorS6.Text))))
            {
                messageToSend = string.Format(Resources.Reservations.INGRESA_FARE_BASIS_FBASIS_A_MOSTRAR_DESC_TDESIGNATOR_SEXTA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtFareBasisS6.Focus();
            }
            else if ((string.IsNullOrEmpty(txtBeginS6.Text)) &&
                ((!string.IsNullOrEmpty(txtEndS6.Text)) ||
                (!string.IsNullOrEmpty(txtFareBasisS6.Text)) ||
                (!string.IsNullOrEmpty(txtFareBasisTS6.Text) ||
                (!string.IsNullOrEmpty(txtDiscountS6.Text)) ||
                (!string.IsNullOrEmpty(txtTicketDesignatorS6.Text)))))
            {
                messageToSend = string.Format(Resources.Reservations.DEBES_ING_SEGMENTO_INICIO_SEXTA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtBeginS6.Focus();
            }
            else if ((string.IsNullOrEmpty(txtDiscountS6.Text)) &&
               (!string.IsNullOrEmpty(txtTicketDesignatorS6.Text)))
            {
                messageToSend = string.Format(Resources.Reservations.REQ_DESC_TICKET_DESIGNATOR_SEXTA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS6.Focus();
            }
            //else if ((string.IsNullOrEmpty(txtTicketDesignatorS6.Text)) &&
            //   (!string.IsNullOrEmpty(txtDiscountS6.Text)))
            //{
            //    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_TICKET_DESIGNATOR_DESC_SEXTA_FILA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    statusMessageBox = true;
            //    txtTicketDesignatorS6.Focus();
            //}
            else if ((!string.IsNullOrEmpty(txtDiscountS6.Text)) &&
            (!statusPercentageBySegments) &&
            (!statusQuantityBySegments))
            {
                MessageBox.Show(Resources.Reservations.SELECCIONA_TIPO_DES_APLICAR_SEXTA_FILA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                rdoPercentageBySegments.Focus();
            }
            else if (allowDecimal && (statusQuantityBySegments) && (!string.IsNullOrEmpty(txtDiscountS6.Text)) && (!ValidateRegularExpression.ValidateTwoDecimalNumbers(txtDiscountS6.Text)))
            {
                messageToSend = string.Format(Resources.Reservations.DES_CANT_DOS_DECIMALES_SEXTA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS6.Focus();
            }
            else if ((statusPercentageBySegments) && (!string.IsNullOrEmpty(txtDiscountS6.Text)) && (Convert.ToInt32(txtDiscountS6.Text) > 100))
            {
                messageToSend = string.Format(Resources.Reservations.DES_PORCENTAJE_DOS_NUMEROS_SEXTA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS6.Focus();
            }

            isValidBySegments = statusMessageBox;
        }


        /// <summary>
        /// Reglas de Negocio aplicables cuando la opción "Por segmentos" 
        /// esta activa para la septima fila
        /// </summary>
        /// <returns></returns>
        private void BusinessRulesSeventhRow()
        {
            if ((!string.IsNullOrEmpty(txtBeginS7.Text)) &&
                (string.IsNullOrEmpty(txtEndS7.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisS7.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisTS7.Text) &&
                (string.IsNullOrEmpty(txtDiscountS7.Text)) &&
                (string.IsNullOrEmpty(txtTicketDesignatorS7.Text))))
            {
                messageToSend = string.Format(Resources.Reservations.INGRESA_SEPTIMA_FILA_CON_DATO_ADICIONAL, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtFareBasisS7.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtBeginS7.Text)) &&
                (!string.IsNullOrEmpty(txtEndS7.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisS7.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisTS7.Text) &&
                (string.IsNullOrEmpty(txtDiscountS7.Text)) &&
                (string.IsNullOrEmpty(txtTicketDesignatorS7.Text))))
            {
                messageToSend = string.Format(Resources.Reservations.INGRESA_FARE_BASIS_FBASIS_A_MOSTRAR_DESC_TDESIGNATOR_SEPTIMA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtFareBasisS7.Focus();
            }
            else if ((string.IsNullOrEmpty(txtBeginS7.Text)) &&
                ((!string.IsNullOrEmpty(txtEndS7.Text)) ||
                (!string.IsNullOrEmpty(txtFareBasisS7.Text)) ||
                (!string.IsNullOrEmpty(txtFareBasisTS7.Text) ||
                (!string.IsNullOrEmpty(txtDiscountS7.Text)) ||
                (!string.IsNullOrEmpty(txtTicketDesignatorS7.Text)))))
            {
                messageToSend = string.Format(Resources.Reservations.DEBES_ING_SEGMENTO_INICIO_SEPTIMA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtBeginS7.Focus();
            }
            else if ((string.IsNullOrEmpty(txtDiscountS7.Text)) &&
            (!string.IsNullOrEmpty(txtTicketDesignatorS7.Text)))
            {
                messageToSend = string.Format(Resources.Reservations.REQ_DESC_TICKET_DESIGNATOR_SEPTIMA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS7.Focus();
            }
            //else if ((string.IsNullOrEmpty(txtTicketDesignatorS7.Text)) &&
            //    (!string.IsNullOrEmpty(txtDiscountS7.Text)))
            //{
            //    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_TICKET_DESIGNATOR_DESC_SEPTIMA_FILA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    statusMessageBox = true;
            //    txtTicketDesignatorS7.Focus();
            //}
            else if ((!string.IsNullOrEmpty(txtDiscountS7.Text)) &&
           (!statusPercentageBySegments) &&
           (!statusQuantityBySegments))
            {
                MessageBox.Show(Resources.Reservations.SELECCIONA_TIPO_DES_APLICAR_SEPTIMA_FILA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
            }
            else if (allowDecimal && (statusQuantityBySegments) && (!string.IsNullOrEmpty(txtDiscountS7.Text)) && (!ValidateRegularExpression.ValidateTwoDecimalNumbers(txtDiscountS7.Text)))
            {
                messageToSend = string.Format(Resources.Reservations.DES_CANT_DOS_DECIMALES_SEPTIMA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS7.Focus();
            }
            else if ((statusPercentageBySegments) && (!string.IsNullOrEmpty(txtDiscountS7.Text)) && (Convert.ToInt32(txtDiscountS7.Text) > 100))
            {
                messageToSend = string.Format(Resources.Reservations.DES_PORCENTAJE_DOS_NUMEROS_SEPTIMA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS7.Focus();
            }

            isValidBySegments = statusMessageBox;
        }


        /// <summary>
        /// Reglas de Negocio aplicables cuando la opción "Por segmentos" 
        /// esta activa para la octava fila
        /// </summary>
        /// <returns></returns>
        private void BusinessRulesEighthRow()
        {
            if ((!string.IsNullOrEmpty(txtBeginS8.Text)) &&
                (string.IsNullOrEmpty(txtEndS8.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisS8.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisTS8.Text) &&
                (string.IsNullOrEmpty(txtDiscountS8.Text)) &&
                (string.IsNullOrEmpty(txtTicketDesignatorS8.Text))))
            {
                messageToSend = string.Format(Resources.Reservations.INGRESA_OCTAVA_FILA_CON_DATO_ADICIONAL, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtFareBasisS8.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtBeginS8.Text)) &&
                (!string.IsNullOrEmpty(txtEndS8.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisS8.Text)) &&
                (string.IsNullOrEmpty(txtFareBasisTS8.Text) &&
                (string.IsNullOrEmpty(txtDiscountS8.Text)) &&
                (string.IsNullOrEmpty(txtTicketDesignatorS8.Text))))
            {
                messageToSend = string.Format(Resources.Reservations.INGRESA_FARE_BASIS_FBASIS_A_MOSTRAR_DESC_TDESIGNATOR_OCTAVA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtFareBasisS8.Focus();
            }
            else if ((string.IsNullOrEmpty(txtBeginS8.Text)) &&
                ((!string.IsNullOrEmpty(txtEndS8.Text)) ||
                (!string.IsNullOrEmpty(txtFareBasisS8.Text)) ||
                (!string.IsNullOrEmpty(txtFareBasisTS8.Text) ||
                (!string.IsNullOrEmpty(txtDiscountS8.Text)) ||
                (!string.IsNullOrEmpty(txtTicketDesignatorS8.Text)))))
            {
                messageToSend = string.Format(Resources.Reservations.DEBES_ING_SEGMENTO_INICIO_OCTAVA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtBeginS8.Focus();
            }
            else if ((string.IsNullOrEmpty(txtDiscountS8.Text)) &&
            (!string.IsNullOrEmpty(txtTicketDesignatorS8.Text)))
            {
                messageToSend = string.Format(Resources.Reservations.REQ_DESC_TICKET_DESIGNATOR_OCTAVA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS8.Focus();

            }
            //else if ((string.IsNullOrEmpty(txtTicketDesignatorS8.Text)) &&
            //(!string.IsNullOrEmpty(txtDiscountS8.Text)))
            //{
            //    MessageBox.Show(Resources.TicketEmission.Tickets.REQUIERE_TICKET_DESIGNATOR_DESC_OCTAVA_FILA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    statusMessageBox = true;
            //    txtTicketDesignatorS8.Focus();
            //}
            else if ((!string.IsNullOrEmpty(txtDiscountS8.Text)) &&
           (!statusPercentageBySegments) &&
           (!statusQuantityBySegments))
            {
                MessageBox.Show(Resources.Reservations.SELECCIONA_TIPO_DES_APLICAR_OCTAVA_FILA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                rdoPercentageBySegments.Focus();
            }
            else if (allowDecimal && (statusQuantityBySegments) && (!string.IsNullOrEmpty(txtDiscountS8.Text)) && (!ValidateRegularExpression.ValidateTwoDecimalNumbers(txtDiscountS8.Text)))
            {
                messageToSend = string.Format(Resources.Reservations.DES_CANT_DOS_DECIMALES_OCTAVA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS8.Focus();
            }
            else if ((rdoPercentageBySegments.Checked) && (!string.IsNullOrEmpty(txtDiscountS8.Text)) && (Convert.ToInt32(txtDiscountS8.Text) > 100))
            {
                messageToSend = string.Format(Resources.Reservations.DES_PORCENTAJE_DOS_NUMEROS_OCTAVA_FILA, "\n");
                MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusMessageBox = true;
                txtDiscountS8.Focus();
            }

            isValidBySegments = statusMessageBox;
        }


        /// <summary>
        /// Construcción de comando a MySabre cuando la opción "Por segmentos" 
        /// esta activa
        /// </summary>
        /// <returns></returns>
        private void QuaBySegmentsCommandsSend()
        {
            CommandsSendFirstRow();
            CommandsSendSecondRow();
            CommandsSendThirdRow();
            CommandsSendFourthRow();
            CommandsSendFifthRow();
            CommandsSendSixthRow();
            CommandsSendSeventhRow();
            CommandsSendEighthRow();
            sendAll = string.Concat(sendFirstRow,
                    sendSecondRow,
                    sendThirdRow,
                    sendFourthRow,
                    sendFifthRow,
                    sendSixthRow,
                    sendSeventhRow,
                    sendEighthRow);
            phase35375 = sendAll;
            //string[] sendInfo = new string[] {rdoQuaAllItinerary.Checked.ToString(), txtFareBasis.Text, txtFareBasisToShow.Text,
            //    txtDiscount.Text, txtTicketDesignator.Text,rdoQuantity.Checked.ToString(), rdoPercentage.Checked.ToString(),
            //    rdoQuaBySegments.Checked.ToString(), txtBeginS1.Text, txtEndS1.Text, txtFareBasisS1.Text, txtFareBasisTS1.Text,
            //    txtDiscountS1.Text, txtTicketDesignatorS1.Text, txtBeginS2.Text, txtEndS2.Text, txtFareBasisS2.Text, txtFareBasisTS2.Text,
            //    txtDiscountS2.Text, txtTicketDesignatorS2.Text,txtBeginS3.Text, txtEndS3.Text, txtFareBasisS3.Text, txtFareBasisTS3.Text, 
            //    txtDiscountS3.Text, txtTicketDesignatorS3.Text, txtBeginS4.Text, txtEndS4.Text, txtFareBasisS4.Text, txtFareBasisTS4.Text,
            //    txtDiscountS4.Text, txtTicketDesignatorS4.Text, txtBeginS5.Text, txtEndS5.Text, txtFareBasisS5.Text, txtFareBasisTS5.Text, 
            //    txtDiscountS5.Text, txtTicketDesignatorS5.Text, txtBeginS6.Text, txtEndS6.Text,  txtFareBasisS6.Text, txtFareBasisTS6.Text,
            //    txtDiscountS6.Text, txtTicketDesignatorS6.Text, txtBeginS7.Text, txtEndS7.Text, txtFareBasisS7.Text, txtFareBasisTS7.Text,
            //    txtDiscountS7.Text, txtTicketDesignatorS7.Text, txtBeginS8.Text, txtEndS8.Text, txtFareBasisS8.Text, txtFareBasisTS8.Text,
            //    txtDiscountS8.Text, txtTicketDesignatorS8.Text, rdoQuaBySegments.Checked.ToString(), rdoPercentageBySegments.Checked.ToString()};

            //userControlsPreviousValues.Phase35375TicketsParameters = sendInfo;
        }



        /// <summary>
        /// Construcción del comando a MySabre cuando la opción "Por segmentos" 
        /// esta activa para la primera fila
        /// </summary>
        /// <returns></returns>
        private void CommandsSendFirstRow()
        {
            string beginS1;
            string endS1;
            string fareBasisS1;
            string fareBasisTS1;
            string ticketDesignatorS1;
            string discountS1;

            if (!string.IsNullOrEmpty(txtBeginS1.Text))
            {
                beginS1 = txtBeginS1.Text;
            }
            else
            {
                beginS1 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtEndS1.Text))
            {
                endS1 = string.Concat(Resources.Constants.INDENT,
                    txtEndS1.Text);
            }
            else
            {
                endS1 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtFareBasisS1.Text))
            {
                fareBasisS1 = txtFareBasisS1.Text;
            }
            else
            {
                fareBasisS1 = string.Empty;

            }
            if (!string.IsNullOrEmpty(txtFareBasisTS1.Text))
            {
                fareBasisTS1 = string.Concat(Resources.Constants.INDENT,
                  txtFareBasisTS1.Text);
            }
            else
            {
                fareBasisTS1 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtTicketDesignatorS1.Text))
            {
                ticketDesignatorS1 = string.Concat(Resources.Constants.INDENT,
                    txtTicketDesignatorS1.Text);
            }
            else
            {
                ticketDesignatorS1 = string.Empty;
            }
            if ((statusQuantityBySegments) &&
                (!string.IsNullOrEmpty(txtDiscountS1.Text)))
            {
                discountTypeBySegments = Resources.Constants.COMMANDS_SLASH_SLASH_DA;
            }
            else if ((statusPercentageBySegments) &&
                (!string.IsNullOrEmpty(txtDiscountS1.Text)))
            {
                discountTypeBySegments = Resources.Constants.COMMANDS_SLASH_SLASH_DP;
            }
            else
            {
                discountTypeBySegments = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtDiscountS1.Text))
            {
                discountS1 = txtDiscountS1.Text;
            }
            else
            {
                discountS1 = string.Empty;
            }
            sendFirstRow = string.Concat(beginS1,
                endS1,
                Resources.Constants.COMMANDS_AST_Q,
                fareBasisS1,
                fareBasisTS1,
                discountTypeBySegments,
                discountS1,
                ticketDesignatorS1);
            if (sendFirstRow != Resources.Constants.COMMANDS_AST_Q)
            {
                sendFirstRow = string.Concat(Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_S,
                    sendFirstRow);
            }
            if (sendFirstRow.Equals(Resources.Constants.COMMANDS_AST_Q))
            {
                sendFirstRow = string.Empty;
            }
        }


        /// <summary>
        /// Construcción del comando a MySabre cuando la opción "Por segmentos" 
        /// esta activa para la segunda fila
        /// </summary>
        /// <returns></returns>
        private void CommandsSendSecondRow()
        {
            string beginS2;
            string endS2;
            string fareBasisS2;
            string fareBasisTS2;
            string ticketDesignatorS2;
            string discountS2;

            if (!string.IsNullOrEmpty(txtBeginS2.Text))
            {
                beginS2 = string.Concat(Resources.Constants.COMMANDS_S,
                    txtBeginS2.Text);
            }
            else
            {
                beginS2 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtEndS2.Text))
            {
                endS2 = string.Concat(Resources.Constants.INDENT,
                    txtEndS2.Text);
            }
            else
            {
                endS2 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtFareBasisS2.Text))
            {
                fareBasisS2 = txtFareBasisS2.Text;
            }
            else
            {
                fareBasisS2 = string.Empty;

            }
            if (!string.IsNullOrEmpty(txtFareBasisTS2.Text))
            {
                fareBasisTS2 = string.Concat(Resources.Constants.INDENT,
                  txtFareBasisTS2.Text);
            }
            else
            {
                fareBasisTS2 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtTicketDesignatorS2.Text))
            {
                ticketDesignatorS2 = string.Concat(Resources.Constants.INDENT,
                    txtTicketDesignatorS2.Text);
            }
            else
            {
                ticketDesignatorS2 = string.Empty;
            }
            if ((statusQuantityBySegments) &&
                (!string.IsNullOrEmpty(txtDiscountS2.Text)))
            {
                discountTypeBySegments = Resources.Constants.COMMANDS_SLASH_SLASH_DA;
            }
            else if ((statusPercentageBySegments) &&
                (!string.IsNullOrEmpty(txtDiscountS2.Text)))
            {
                discountTypeBySegments = Resources.Constants.COMMANDS_SLASH_SLASH_DP;
            }
            else
            {
                discountTypeBySegments = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtDiscountS2.Text))
            {
                discountS2 = txtDiscountS2.Text;
            }
            else
            {
                discountS2 = string.Empty;
            }
            sendSecondRow = string.Concat(beginS2,
                endS2,
                Resources.Constants.COMMANDS_AST_Q,
                fareBasisS2,
                fareBasisTS2,
                discountTypeBySegments,
                discountS2,
                ticketDesignatorS2);
            if (sendSecondRow.Equals(Resources.Constants.COMMANDS_AST_Q))
            {
                sendSecondRow = string.Empty;
            }
            else
            {
                sendSecondRow = string.Concat(Resources.Constants.CROSSLORAINE,
                    sendSecondRow);
            }
        }


        /// <summary>
        /// Construcción del comando a MySabre cuando la opción "Por segmentos" 
        /// esta activa para la tercera fila
        /// </summary>
        /// <returns></returns>
        private void CommandsSendThirdRow()
        {
            string beginS3;
            string endS3;
            string fareBasisS3;
            string fareBasisTS3;
            string ticketDesignatorS3;
            string discountS3;
            if (!string.IsNullOrEmpty(txtBeginS3.Text))
            {
                beginS3 = string.Concat(Resources.Constants.COMMANDS_S,
                    txtBeginS3.Text);
            }
            else
            {
                beginS3 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtEndS3.Text))
            {
                endS3 = string.Concat(Resources.Constants.INDENT,
                    txtEndS3.Text);
            }
            else
            {
                endS3 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtFareBasisS3.Text))
            {
                fareBasisS3 = txtFareBasisS3.Text;
            }
            else
            {
                fareBasisS3 = string.Empty;

            }
            if (!string.IsNullOrEmpty(txtFareBasisTS3.Text))
            {
                fareBasisTS3 = string.Concat(Resources.Constants.INDENT,
                  txtFareBasisTS3.Text);
            }
            else
            {
                fareBasisTS3 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtTicketDesignatorS3.Text))
            {
                ticketDesignatorS3 = string.Concat(Resources.Constants.INDENT,
                    txtTicketDesignatorS3.Text);
            }
            else
            {
                ticketDesignatorS3 = string.Empty;
            }
            if ((statusQuantityBySegments) &&
                (!string.IsNullOrEmpty(txtDiscountS3.Text)))
            {
                discountTypeBySegments = Resources.Constants.COMMANDS_SLASH_SLASH_DA;
            }
            else if ((statusPercentageBySegments) &&
                (!string.IsNullOrEmpty(txtDiscountS3.Text)))
            {
                discountTypeBySegments = Resources.Constants.COMMANDS_SLASH_SLASH_DP;
            }
            else
            {
                discountTypeBySegments = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtDiscountS3.Text))
            {
                discountS3 = txtDiscountS3.Text;
            }
            else
            {
                discountS3 = string.Empty;
            }
            sendThirdRow = string.Concat(beginS3,
                            endS3,
                            Resources.Constants.COMMANDS_AST_Q,
                            fareBasisS3,
                            fareBasisTS3,
                            discountTypeBySegments,
                            discountS3,
                            ticketDesignatorS3);
            if (sendThirdRow.Equals(Resources.Constants.COMMANDS_AST_Q))
            {
                sendThirdRow = string.Empty;
            }
            else
            {
                sendThirdRow = string.Concat(Resources.Constants.CROSSLORAINE,
                    sendThirdRow);
            }


        }


        /// <summary>
        /// Construcción del comando a MySabre cuando la opción "Por segmentos" 
        /// esta activa para la cuarta fila
        /// </summary>
        /// <returns></returns>
        private void CommandsSendFourthRow()
        {

            string beginS4;
            string endS4;
            string fareBasisS4;
            string fareBasisTS4;
            string ticketDesignatorS4;
            string discountS4;
            if (!string.IsNullOrEmpty(txtBeginS4.Text))
            {
                beginS4 = string.Concat(Resources.Constants.COMMANDS_S,
                        txtBeginS4.Text);
            }
            else
            {
                beginS4 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtEndS4.Text))
            {
                endS4 = string.Concat(Resources.Constants.INDENT,
                        txtEndS4.Text);
            }
            else
            {
                endS4 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtFareBasisS4.Text))
            {
                fareBasisS4 = txtFareBasisS4.Text;
            }
            else
            {
                fareBasisS4 = string.Empty;

            }
            if (!string.IsNullOrEmpty(txtFareBasisTS4.Text))
            {
                fareBasisTS4 = string.Concat(Resources.Constants.INDENT,
                         txtFareBasisTS4.Text);
            }
            else
            {
                fareBasisTS4 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtTicketDesignatorS4.Text))
            {
                ticketDesignatorS4 = string.Concat(Resources.Constants.INDENT,
                          txtTicketDesignatorS4.Text);
            }
            else
            {
                ticketDesignatorS4 = string.Empty;
            }
            if ((statusQuantityBySegments) &&
            (!string.IsNullOrEmpty(txtDiscountS4.Text)))
            {
                discountTypeBySegments = Resources.Constants.COMMANDS_SLASH_SLASH_DA;
            }
            else if ((statusPercentageBySegments) &&
            (!string.IsNullOrEmpty(txtDiscountS4.Text)))
            {
                discountTypeBySegments = Resources.Constants.COMMANDS_SLASH_SLASH_DP;
            }
            else
            {
                discountTypeBySegments = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtDiscountS4.Text))
            {
                discountS4 = txtDiscountS4.Text;
            }
            else
            {
                discountS4 = string.Empty;
            }
            sendFourthRow = string.Concat(beginS4,
                endS4,
                Resources.Constants.COMMANDS_AST_Q,
                fareBasisS4,
                fareBasisTS4,
                discountTypeBySegments,
                discountS4,
                ticketDesignatorS4);
            if (sendFourthRow.Equals(Resources.Constants.COMMANDS_AST_Q))
            {
                sendFourthRow = string.Empty;
            }
            else
            {
                sendFourthRow = string.Concat(Resources.Constants.CROSSLORAINE,
                    sendFourthRow);
            }
        }


        /// <summary>
        /// Construcción del comando a MySabre cuando la opción "Por segmentos" 
        /// esta activa para la quinta fila
        /// </summary>
        /// <returns></returns>
        private void CommandsSendFifthRow()
        {
            string beginS5;
            string endS5;
            string fareBasisS5;
            string fareBasisTS5;
            string ticketDesignatorS5;
            string discountS5;
            if (!string.IsNullOrEmpty(txtBeginS5.Text))
            {
                beginS5 = string.Concat(Resources.Constants.COMMANDS_S,
                    txtBeginS5.Text);
            }
            else
            {
                beginS5 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtEndS5.Text))
            {
                endS5 = string.Concat(Resources.Constants.INDENT,
                    txtEndS5.Text);
            }
            else
            {
                endS5 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtFareBasisS5.Text))
            {
                fareBasisS5 = txtFareBasisS5.Text;
            }
            else
            {
                fareBasisS5 = string.Empty;

            }
            if (!string.IsNullOrEmpty(txtFareBasisTS5.Text))
            {
                fareBasisTS5 = string.Concat(Resources.Constants.INDENT,
                  txtFareBasisTS5.Text);
            }
            else
            {
                fareBasisTS5 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtTicketDesignatorS5.Text))
            {
                ticketDesignatorS5 = string.Concat(Resources.Constants.INDENT,
                    txtTicketDesignatorS5.Text);
            }
            else
            {
                ticketDesignatorS5 = string.Empty;
            }
            if ((statusQuantityBySegments) &&
                (!string.IsNullOrEmpty(txtDiscountS5.Text)))
            {
                discountTypeBySegments = Resources.Constants.COMMANDS_SLASH_SLASH_DA;
            }
            else if ((statusPercentageBySegments) &&
                (!string.IsNullOrEmpty(txtDiscountS5.Text)))
            {
                discountTypeBySegments = Resources.Constants.COMMANDS_SLASH_SLASH_DP;
            }
            else
            {
                discountTypeBySegments = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtDiscountS5.Text))
            {
                discountS5 = txtDiscountS5.Text;
            }
            else
            {
                discountS5 = string.Empty;
            }
            sendFifthRow = string.Concat(beginS5,
                endS5,
                Resources.Constants.COMMANDS_AST_Q,
                fareBasisS5,
                fareBasisTS5,
                discountTypeBySegments,
                discountS5,
                ticketDesignatorS5);
            if (sendFifthRow.Equals(Resources.Constants.COMMANDS_AST_Q))
            {
                sendFifthRow = string.Empty;
            }
            else
            {
                sendFifthRow = string.Concat(Resources.Constants.CROSSLORAINE,
                    sendFifthRow);
            }
        }


        /// <summary>
        /// Construcción del comando a MySabre cuando la opción "Por segmentos" 
        /// esta activa para la sexta fila
        /// </summary>
        /// <returns></returns>
        private void CommandsSendSixthRow()
        {
            string beginS6;
            string endS6;
            string fareBasisS6;
            string fareBasisTS6;
            string ticketDesignatorS6;
            string discountS6;

            if (!string.IsNullOrEmpty(txtBeginS6.Text))
            {
                beginS6 = string.Concat(Resources.Constants.COMMANDS_S,
                    txtBeginS6.Text);
            }
            else
            {
                beginS6 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtEndS6.Text))
            {
                endS6 = string.Concat(Resources.Constants.INDENT,
                    txtEndS6.Text);
            }
            else
            {
                endS6 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtFareBasisS6.Text))
            {
                fareBasisS6 = txtFareBasisS6.Text;
            }
            else
            {
                fareBasisS6 = string.Empty;

            }
            if (!string.IsNullOrEmpty(txtFareBasisTS6.Text))
            {
                fareBasisTS6 = string.Concat(Resources.Constants.INDENT,
                  txtFareBasisTS6.Text);
            }
            else
            {
                fareBasisTS6 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtTicketDesignatorS6.Text))
            {
                ticketDesignatorS6 = string.Concat(Resources.Constants.INDENT,
                    txtTicketDesignatorS6.Text);
            }
            else
            {
                ticketDesignatorS6 = string.Empty;
            }
            if ((statusQuantityBySegments) &&
                (!string.IsNullOrEmpty(txtDiscountS6.Text)))
            {
                discountTypeBySegments = Resources.Constants.COMMANDS_SLASH_SLASH_DA;
            }
            else if ((statusPercentageBySegments) &&
                (!string.IsNullOrEmpty(txtDiscountS6.Text)))
            {
                discountTypeBySegments = Resources.Constants.COMMANDS_SLASH_SLASH_DP;
            }
            else
            {
                discountTypeBySegments = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtDiscountS6.Text))
            {
                discountS6 = txtDiscountS6.Text;
            }
            else
            {
                discountS6 = string.Empty;
            }
            sendSixthRow = string.Concat(beginS6,
                endS6,
                Resources.Constants.COMMANDS_AST_Q,
                fareBasisS6,
                fareBasisTS6,
                discountTypeBySegments,
                discountS6,
                ticketDesignatorS6);
            if (sendSixthRow.Equals(Resources.Constants.COMMANDS_AST_Q))
            {
                sendSixthRow = string.Empty;
            }
            else
            {
                sendSixthRow = string.Concat(Resources.Constants.CROSSLORAINE,
                    sendSixthRow);
            }
        }


        /// <summary>
        /// Construcción del comando a MySabre cuando la opción "Por segmentos" 
        /// esta activa para la septima fila
        /// </summary>
        /// <returns></returns>
        private void CommandsSendSeventhRow()
        {
            string beginS7;
            string endS7;
            string fareBasisS7;
            string fareBasisTS7;
            string ticketDesignatorS7;
            string discountS7;
            if (!string.IsNullOrEmpty(txtBeginS7.Text))
            {
                beginS7 = string.Concat(Resources.Constants.COMMANDS_S,
                    txtBeginS7.Text);
            }
            else
            {
                beginS7 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtEndS7.Text))
            {
                endS7 = string.Concat(Resources.Constants.INDENT,
                    txtEndS7.Text);
            }
            else
            {
                endS7 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtFareBasisS7.Text))
            {
                fareBasisS7 = txtFareBasisS7.Text;
            }
            else
            {
                fareBasisS7 = string.Empty;

            }
            if (!string.IsNullOrEmpty(txtFareBasisTS7.Text))
            {
                fareBasisTS7 = string.Concat(Resources.Constants.INDENT,
                  txtFareBasisTS7.Text);
            }
            else
            {
                fareBasisTS7 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtTicketDesignatorS7.Text))
            {
                ticketDesignatorS7 = string.Concat(Resources.Constants.INDENT,
                    txtTicketDesignatorS7.Text);
            }
            else
            {
                ticketDesignatorS7 = string.Empty;
            }
            if ((statusQuantityBySegments) &&
                (!string.IsNullOrEmpty(txtDiscountS7.Text)))
            {
                discountTypeBySegments = Resources.Constants.COMMANDS_SLASH_SLASH_DA;
            }
            else if ((statusPercentageBySegments) &&
                (!string.IsNullOrEmpty(txtDiscountS7.Text)))
            {
                discountTypeBySegments = Resources.Constants.COMMANDS_SLASH_SLASH_DP;
            }
            else
            {
                discountTypeBySegments = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtDiscountS7.Text))
            {
                discountS7 = txtDiscountS7.Text;
            }
            else
            {
                discountS7 = string.Empty;
            }
            sendSeventhRow = string.Concat(beginS7,
                endS7,
                Resources.Constants.COMMANDS_AST_Q,
                fareBasisS7,
                fareBasisTS7,
                discountTypeBySegments,
                discountS7,
                ticketDesignatorS7);
            if (sendSeventhRow.Equals(Resources.Constants.COMMANDS_AST_Q))
            {
                sendSeventhRow = string.Empty;
            }
            else
            {
                sendSeventhRow = string.Concat(Resources.Constants.CROSSLORAINE,
                    sendSeventhRow);
            }
        }


        /// <summary>
        /// Construcción del comando a MySabre cuando la opción "Por segmentos" 
        /// esta activa para la octava fila
        /// </summary>
        /// <returns></returns>
        private void CommandsSendEighthRow()
        {
            string beginS8;
            string endS8;
            string fareBasisS8;
            string fareBasisTS8;
            string ticketDesignatorS8;
            string discountS8;
            if (!string.IsNullOrEmpty(txtBeginS8.Text))
            {
                beginS8 = string.Concat(Resources.Constants.COMMANDS_S,
                    txtBeginS8.Text);
            }
            else
            {
                beginS8 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtEndS8.Text))
            {
                endS8 = string.Concat(Resources.Constants.INDENT,
                    txtEndS8.Text);
            }
            else
            {
                endS8 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtFareBasisS8.Text))
            {
                fareBasisS8 = txtFareBasisS8.Text;
            }
            else
            {
                fareBasisS8 = string.Empty;

            }
            if (!string.IsNullOrEmpty(txtFareBasisTS8.Text))
            {
                fareBasisTS8 = string.Concat(Resources.Constants.INDENT,
                  txtFareBasisTS8.Text);
            }
            else
            {
                fareBasisTS8 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtTicketDesignatorS8.Text))
            {
                ticketDesignatorS8 = string.Concat(Resources.Constants.INDENT,
                    txtTicketDesignatorS8.Text);
            }
            else
            {
                ticketDesignatorS8 = string.Empty;
            }
            if ((statusQuantityBySegments) &&
                (!string.IsNullOrEmpty(txtDiscountS8.Text)))
            {
                discountTypeBySegments = Resources.Constants.COMMANDS_SLASH_SLASH_DA;
            }
            else if ((statusPercentageBySegments) &&
                (!string.IsNullOrEmpty(txtDiscountS8.Text)))
            {
                discountTypeBySegments = Resources.Constants.COMMANDS_SLASH_SLASH_DP;
            }
            else
            {
                discountTypeBySegments = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtDiscountS8.Text))
            {
                discountS8 = txtDiscountS8.Text;
            }
            else
            {
                discountS8 = string.Empty;
            }
            sendEighthRow = string.Concat(beginS8,
                endS8,
                Resources.Constants.COMMANDS_AST_Q,
                fareBasisS8,
                fareBasisTS8,
                discountTypeBySegments,
                discountS8,
                ticketDesignatorS8);
            if (sendEighthRow.Equals(Resources.Constants.COMMANDS_AST_Q))
            {
                sendEighthRow = string.Empty;
            }
            else
            {
                sendEighthRow = string.Concat(Resources.Constants.CROSSLORAINE,
                    sendEighthRow);
            }
            sendAll = string.Concat(sendFirstRow,
            sendSecondRow,
            sendThirdRow,
            sendFourthRow,
            sendFifthRow,
            sendSixthRow,
            sendSeventhRow,
            sendEighthRow);
        }


        #endregion//End rdoQuaBySegments


        /// <summary>
        /// Establecimiento de variables ocupadas en el armado del comando
        /// a vacio
        /// </summary>
        private void CleanPreviousValues()
        {
            if ((string.IsNullOrEmpty(txtBeginS1.Text)) &&
               (string.IsNullOrEmpty(txtEndS1.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisS1.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisTS1.Text) &&
               (string.IsNullOrEmpty(txtDiscountS1.Text)) &&
               (string.IsNullOrEmpty(txtTicketDesignatorS1.Text))))
            {
                sendFirstRow = string.Empty;
            }
            if ((string.IsNullOrEmpty(txtBeginS2.Text)) &&
               (string.IsNullOrEmpty(txtEndS2.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisS2.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisTS2.Text) &&
               (string.IsNullOrEmpty(txtDiscountS2.Text)) &&
               (string.IsNullOrEmpty(txtTicketDesignatorS2.Text))))
            {
                sendSecondRow = string.Empty;
            }
            if ((string.IsNullOrEmpty(txtBeginS3.Text)) &&
               (string.IsNullOrEmpty(txtEndS3.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisS3.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisTS3.Text) &&
               (string.IsNullOrEmpty(txtDiscountS3.Text)) &&
               (string.IsNullOrEmpty(txtTicketDesignatorS3.Text))))
            {
                sendThirdRow = string.Empty;
            }
            if ((string.IsNullOrEmpty(txtBeginS4.Text)) &&
               (string.IsNullOrEmpty(txtEndS4.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisS4.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisTS4.Text) &&
               (string.IsNullOrEmpty(txtDiscountS4.Text)) &&
               (string.IsNullOrEmpty(txtTicketDesignatorS4.Text))))
            {
                sendFourthRow = string.Empty;
            }
            if ((string.IsNullOrEmpty(txtBeginS5.Text)) &&
               (string.IsNullOrEmpty(txtEndS5.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisS5.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisTS5.Text) &&
               (string.IsNullOrEmpty(txtDiscountS5.Text)) &&
               (string.IsNullOrEmpty(txtTicketDesignatorS5.Text))))
            {
                sendFifthRow = string.Empty;
            }
            if ((string.IsNullOrEmpty(txtBeginS6.Text)) &&
               (string.IsNullOrEmpty(txtEndS6.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisS6.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisTS6.Text) &&
               (string.IsNullOrEmpty(txtDiscountS6.Text)) &&
               (string.IsNullOrEmpty(txtTicketDesignatorS6.Text))))
            {
                sendSixthRow = string.Empty;
            }
            if ((string.IsNullOrEmpty(txtBeginS7.Text)) &&
               (string.IsNullOrEmpty(txtEndS7.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisS7.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisTS7.Text) &&
               (string.IsNullOrEmpty(txtDiscountS7.Text)) &&
               (string.IsNullOrEmpty(txtTicketDesignatorS7.Text))))
            {
                sendSeventhRow = string.Empty;
            }
            if ((string.IsNullOrEmpty(txtBeginS8.Text)) &&
               (string.IsNullOrEmpty(txtEndS8.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisS8.Text)) &&
               (string.IsNullOrEmpty(txtFareBasisTS8.Text) &&
               (string.IsNullOrEmpty(txtDiscountS8.Text)) &&
               (string.IsNullOrEmpty(txtTicketDesignatorS8.Text))))
            {
                sendEighthRow = string.Empty;
            }
        }

        //Load previous values
        private void Previousvalues()
        {
            if (userControlsPreviousValues.Phase35375TicketsParameters != null)
            {
                rdoQuaAllItinerary.Checked = (userControlsPreviousValues.Phase35375TicketsParameters[0].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));       
                txtFareBasis.Text = userControlsPreviousValues.Phase35375TicketsParameters[1];
                txtFareBasisToShow.Text = userControlsPreviousValues.Phase35375TicketsParameters[2];
                txtDiscount.Text = userControlsPreviousValues.Phase35375TicketsParameters[3];
                txtTicketDesignator.Text = userControlsPreviousValues.Phase35375TicketsParameters[4];
                rdoQuantity.Checked = (userControlsPreviousValues.Phase35375TicketsParameters[5].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                rdoPercentage.Checked = (userControlsPreviousValues.Phase35375TicketsParameters[6].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                rdoQuaBySegments.Checked = (userControlsPreviousValues.Phase35375TicketsParameters[7].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                txtBeginS1.Text = userControlsPreviousValues.Phase35375TicketsParameters[8];
                txtEndS1.Text = userControlsPreviousValues.Phase35375TicketsParameters[9];
                txtFareBasisS1.Text = userControlsPreviousValues.Phase35375TicketsParameters[10];
                txtFareBasisTS1.Text = userControlsPreviousValues.Phase35375TicketsParameters[11];
                txtDiscountS1.Text = userControlsPreviousValues.Phase35375TicketsParameters[12];
                txtTicketDesignatorS1.Text = userControlsPreviousValues.Phase35375TicketsParameters[13];
                txtBeginS2.Text = userControlsPreviousValues.Phase35375TicketsParameters[14];
                txtEndS2.Text = userControlsPreviousValues.Phase35375TicketsParameters[15];
                txtFareBasisS2.Text = userControlsPreviousValues.Phase35375TicketsParameters[16];
                txtFareBasisTS2.Text = userControlsPreviousValues.Phase35375TicketsParameters[17];
                txtDiscountS2.Text = userControlsPreviousValues.Phase35375TicketsParameters[18];
                txtTicketDesignatorS2.Text = userControlsPreviousValues.Phase35375TicketsParameters[19];
                txtBeginS3.Text = userControlsPreviousValues.Phase35375TicketsParameters[20];
                txtEndS3.Text = userControlsPreviousValues.Phase35375TicketsParameters[21];
                txtFareBasisS3.Text = userControlsPreviousValues.Phase35375TicketsParameters[22];
                txtFareBasisTS3.Text = userControlsPreviousValues.Phase35375TicketsParameters[23];
                txtDiscountS3.Text = userControlsPreviousValues.Phase35375TicketsParameters[24];
                txtTicketDesignatorS3.Text = userControlsPreviousValues.Phase35375TicketsParameters[25];
                txtBeginS4.Text = userControlsPreviousValues.Phase35375TicketsParameters[26];
                txtEndS4.Text = userControlsPreviousValues.Phase35375TicketsParameters[27];
                txtFareBasisS4.Text = userControlsPreviousValues.Phase35375TicketsParameters[28];
                txtFareBasisTS4.Text = userControlsPreviousValues.Phase35375TicketsParameters[29];
                txtDiscountS4.Text = userControlsPreviousValues.Phase35375TicketsParameters[30];
                txtTicketDesignatorS4.Text = userControlsPreviousValues.Phase35375TicketsParameters[31];
                txtBeginS5.Text = userControlsPreviousValues.Phase35375TicketsParameters[32];
                txtEndS5.Text = userControlsPreviousValues.Phase35375TicketsParameters[33];
                txtFareBasisS5.Text = userControlsPreviousValues.Phase35375TicketsParameters[34];
                txtFareBasisTS5.Text = userControlsPreviousValues.Phase35375TicketsParameters[35];
                txtDiscountS5.Text = userControlsPreviousValues.Phase35375TicketsParameters[36];
               txtTicketDesignatorS5.Text = userControlsPreviousValues.Phase35375TicketsParameters[37];
               txtBeginS6.Text = userControlsPreviousValues.Phase35375TicketsParameters[38];
               txtEndS6.Text = userControlsPreviousValues.Phase35375TicketsParameters[39];
               txtFareBasisS6.Text = userControlsPreviousValues.Phase35375TicketsParameters[40];
               txtFareBasisTS6.Text = userControlsPreviousValues.Phase35375TicketsParameters[41];
               txtDiscountS6.Text = userControlsPreviousValues.Phase35375TicketsParameters[42];
               txtTicketDesignatorS6.Text = userControlsPreviousValues.Phase35375TicketsParameters[43];
               txtBeginS7.Text = userControlsPreviousValues.Phase35375TicketsParameters[44];
               txtEndS7.Text = userControlsPreviousValues.Phase35375TicketsParameters[45];
               txtFareBasisS7.Text = userControlsPreviousValues.Phase35375TicketsParameters[46];
               txtFareBasisTS7.Text = userControlsPreviousValues.Phase35375TicketsParameters[47];
               txtDiscountS7.Text = userControlsPreviousValues.Phase35375TicketsParameters[48];
               txtTicketDesignatorS7.Text = userControlsPreviousValues.Phase35375TicketsParameters[49];
               txtBeginS8.Text = userControlsPreviousValues.Phase35375TicketsParameters[50];
               txtEndS8.Text = userControlsPreviousValues.Phase35375TicketsParameters[51];
               txtFareBasisS8.Text = userControlsPreviousValues.Phase35375TicketsParameters[52];
               txtFareBasisTS8.Text = userControlsPreviousValues.Phase35375TicketsParameters[53];
               txtDiscountS8.Text = userControlsPreviousValues.Phase35375TicketsParameters[54];
               txtTicketDesignatorS8.Text = userControlsPreviousValues.Phase35375TicketsParameters[55];
               rdoQuaBySegments.Checked = (userControlsPreviousValues.Phase35375TicketsParameters[56].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
               rdoPercentageBySegments.Checked = (userControlsPreviousValues.Phase35375TicketsParameters[57].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
               userControlsPreviousValues.Phase35375TicketsParameters = null;       
            }

        }
        #region===== commons =====

        /// <summary>
        /// Validación de posibles errores en la respuesta de MySabre
        /// </summary>
        private void LoadNextStep()
        {
            Segment();
            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTAXES);
        }
        #endregion//End commons

        private void Segment()
        {
            segment = string.Empty;
            if(rdoQuaBySegments.Checked)
            {
                PreviousCommand();

                segment=string.Concat(txtBeginS1.Text);
                if(!string.IsNullOrEmpty(txtEndS1.Text))
                segment=string.Concat(segment,"-",txtEndS1.Text);
                if (!string.IsNullOrEmpty(txtBeginS2.Text))
                    segment = string.Concat(segment,"/", txtBeginS2.Text);
                if (!string.IsNullOrEmpty(txtEndS2.Text))
                    segment = string.Concat(segment, "-", txtEndS2.Text);
                if (!string.IsNullOrEmpty(txtBeginS3.Text))
                    segment = string.Concat(segment, "/", txtBeginS3.Text);
                if (!string.IsNullOrEmpty(txtEndS3.Text))
                    segment = string.Concat(segment, "-", txtEndS3.Text);
                if (!string.IsNullOrEmpty(txtBeginS4.Text))
                    segment = string.Concat(segment, "/", txtBeginS4.Text);
                if (!string.IsNullOrEmpty(txtEndS4.Text))
                    segment = string.Concat(segment, "-", txtEndS4.Text);
                if (!string.IsNullOrEmpty(txtBeginS5.Text))
                    segment = string.Concat(segment, "/", txtBeginS5.Text);
                if (!string.IsNullOrEmpty(txtEndS5.Text))
                    segment = string.Concat(segment, "-", txtEndS5.Text);
                if (!string.IsNullOrEmpty(txtBeginS6.Text))
                    segment = string.Concat(segment, "/", txtBeginS6.Text);
                if (!string.IsNullOrEmpty(txtEndS6.Text))
                    segment = string.Concat(segment, "-", txtEndS6.Text);
                if (!string.IsNullOrEmpty(txtBeginS7.Text))
                    segment = string.Concat(segment, "/", txtBeginS7.Text);
                if (!string.IsNullOrEmpty(txtEndS7.Text))
                    segment = string.Concat(segment, "-", txtEndS7.Text);
                if (!string.IsNullOrEmpty(txtBeginS8.Text))
                    segment = string.Concat(segment, "/", txtBeginS8.Text);
                if (!string.IsNullOrEmpty(txtEndS8.Text))
                    segment = string.Concat(segment, "-", txtEndS8.Text);
            }
        }

        /// <summary>
        /// Borra las lineas contables para segmentos
        /// </summary>
        private void PreviousCommand()
        {
            int row = 0;
            int col = 0;
            string result = string.Empty;
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                result = objCommands.SendReceive(Resources.Constants.COMMANDS_AST_PAC);
            }

            CommandsQik.searchResponse(result, "ACCOUNTING DATA", ref row, ref col);
            if (row != 0 || col != 0)
            {
                using (CommandsAPI objCommands = new CommandsAPI())
                {
                    objCommands.SendReceive("AC¤ALL");
                }
            }
            
        }

        #endregion//End methodsClass



        #region=====Enabled disabled Controls=====

        /// <summary>
        /// Ejecuta en método quaAllItineraryEnableDisableControls()
        /// cuando la opción "Para todo el itinerario" esta activa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoQuaAllItinerary_CheckedChanged(object sender, EventArgs e)
        {
            QuaAllItineraryEnableDisableControls();
        }


        /// <summary>
        /// Ejecuta en método quaBySegmentsEnableDisableControls()
        /// cuando la opción "Por segmentos" esta activa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoQuaBySegments_CheckedChanged(object sender, EventArgs e)
        {
            QuaBySegmentsEnableDisableControls();
        }

        #endregion//End Enabled disabled Controls



        #region===== Change focus when a Textbox is Full =====


        //Evento txtFareBasis_TextChanged
        private void txtFareBasis_TextChanged(object sender, EventArgs e)
        {
            if (txtFareBasis.Text.Length > 11)
                txtFareBasisToShow.Focus();
        }


        //Evento txtFareBasisToShow_TextChanged
        private void txtFareBasisToShow_TextChanged(object sender, EventArgs e)
        {
            if (txtFareBasisToShow.Text.Length > 11)
                txtDiscount.Focus();
        }


        //Evento txtDiscount_TextChanged
        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text.Length > 7)
                txtTicketDesignator.Focus();
        }


        //Evento txtTicketDesignator_TextChanged
        private void txtTicketDesignator_TextChanged(object sender, EventArgs e)
        {
            if (txtTicketDesignator.Text.Length > 11)
                rdoPercentage.Focus();
        }


        //Evento txtBeginS1_TextChanged
        private void txtBeginS1_TextChanged(object sender, EventArgs e)
        {
            if (txtBeginS1.Text.Length > 1)
            {
                txtEndS1.Focus();
            }
        }


        //Evento txtEndS1_TextChanged
        private void txtEndS1_TextChanged(object sender, EventArgs e)
        {
            if (txtEndS1.Text.Length > 1)
            {
                txtFareBasisS1.Focus();
            }
        }


        //Evento txtFareBasisS1_TextChanged
        private void txtFareBasisS1_TextChanged(object sender, EventArgs e)
        {
            if (txtFareBasisS1.Text.Length > 11)
            {
                txtFareBasisTS1.Focus();
            }
        }


        //Evento txtFareBasisTS1_TextChanged
        private void txtFareBasisTS1_TextChanged(object sender, EventArgs e)
        {
            if (txtFareBasisTS1.Text.Length > 11)
            {
                txtDiscountS1.Focus();
            }
        }


        //Evento txtDiscountS1_TextChanged
        private void txtDiscountS1_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscountS1.Text.Length > 7)
            {
                txtTicketDesignatorS1.Focus();
            }
        }


        //Evento txtTicketDesignatorS1_TextChanged
        private void txtTicketDesignatorS1_TextChanged(object sender, EventArgs e)
        {
            if (txtTicketDesignatorS1.Text.Length > 11)
            {
                txtBeginS2.Focus();
            }
        }


        //Evento txtBeginS2_TextChanged
        private void txtBeginS2_TextChanged(object sender, EventArgs e)
        {
            if (txtBeginS2.Text.Length > 1)
            {
                txtEndS2.Focus();
            }
        }


        //Evento txtEndS2_TextChanged
        private void txtEndS2_TextChanged(object sender, EventArgs e)
        {
            if (txtEndS2.Text.Length > 1)
            {
                txtFareBasisS2.Focus();
            }

        }


        //Evento txtFareBasisS2_TextChanged
        private void txtFareBasisS2_TextChanged(object sender, EventArgs e)
        {
            if (txtFareBasisS2.Text.Length > 11)
            {
                txtFareBasisTS2.Focus();
            }
        }


        //Evento txtFareBasisTS2_TextChanged
        private void txtFareBasisTS2_TextChanged(object sender, EventArgs e)
        {
            if (txtFareBasisTS2.Text.Length > 11)
            {
                txtDiscountS2.Focus();
            }
        }


        //Evento txtDiscountS2_TextChanged
        private void txtDiscountS2_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscountS2.Text.Length > 7)
            {
                txtTicketDesignatorS2.Focus();
            }
        }


        //Evento txtTicketDesignatorS2_TextChanged
        private void txtTicketDesignatorS2_TextChanged(object sender, EventArgs e)
        {
            if (txtTicketDesignatorS2.Text.Length > 11)
            {
                txtBeginS3.Focus();
            }
        }


        //Evento txtBeginS3_TextChanged
        private void txtBeginS3_TextChanged(object sender, EventArgs e)
        {
            if (txtBeginS3.Text.Length > 1)
            {
                txtEndS3.Focus();
            }
        }


        //Evento txtEndS3_TextChanged
        private void txtEndS3_TextChanged(object sender, EventArgs e)
        {
            if (txtEndS3.Text.Length > 1)
            {
                txtFareBasisS3.Focus();
            }

        }


        //Evento txtFareBasisS3_TextChanged
        private void txtFareBasisS3_TextChanged(object sender, EventArgs e)
        {
            if (txtFareBasisS3.Text.Length > 11)
            {
                txtFareBasisTS3.Focus();
            }
        }


        //Evento txtFareBasisTS3_TextChanged
        private void txtFareBasisTS3_TextChanged(object sender, EventArgs e)
        {
            if (txtFareBasisTS3.Text.Length > 11)
            {
                txtDiscountS3.Focus();
            }
        }


        //Evento txtDiscountS3_TextChanged
        private void txtDiscountS3_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscountS3.Text.Length > 7)
            {
                txtTicketDesignatorS3.Focus();
            }
        }


        //Evento txtTicketDesignatorS3_TextChanged
        private void txtTicketDesignatorS3_TextChanged(object sender, EventArgs e)
        {
            if (txtTicketDesignatorS3.Text.Length > 11)
            {
                txtBeginS4.Focus();
            }
        }


        //Evento txtBeginS4_TextChanged
        private void txtBeginS4_TextChanged(object sender, EventArgs e)
        {
            if (txtBeginS4.Text.Length > 1)
            {
                txtEndS4.Focus();
            }
        }


        //Evento txtEndS4_TextChanged
        private void txtEndS4_TextChanged(object sender, EventArgs e)
        {
            if (txtEndS4.Text.Length > 1)
            {
                txtFareBasisS4.Focus();
            }
        }


        //Evento txtFareBasisS4_TextChanged
        private void txtFareBasisS4_TextChanged(object sender, EventArgs e)
        {
            if (txtFareBasisS4.Text.Length > 11)
            {
                txtFareBasisTS4.Focus();
            }
        }


        //Evento txtFareBasisTS4_TextChanged
        private void txtFareBasisTS4_TextChanged(object sender, EventArgs e)
        {
            if (txtFareBasisTS4.Text.Length > 11)
            {
                txtDiscountS4.Focus();

            }
        }


        //Evento txtDiscountS4_TextChanged
        private void txtDiscountS4_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscountS4.Text.Length > 7)
            {
                txtTicketDesignatorS4.Focus();
            }
        }


        //Evento txtTicketDesignatorS4_TextChanged
        private void txtTicketDesignatorS4_TextChanged(object sender, EventArgs e)
        {
            if (txtTicketDesignatorS4.Text.Length > 11)
            {
                txtBeginS5.Focus();
            }
        }


        //Evento txtBeginS5_TextChanged
        private void txtBeginS5_TextChanged(object sender, EventArgs e)
        {
            if (txtBeginS5.Text.Length > 1)
            {
                txtEndS5.Focus();
            }
        }


        //Evento txtEndS5_TextChanged
        private void txtEndS5_TextChanged(object sender, EventArgs e)
        {
            if (txtEndS5.Text.Length > 1)
            {
                txtFareBasisS5.Focus();
            }
        }


        //Evento txtFareBasisS5_TextChanged
        private void txtFareBasisS5_TextChanged(object sender, EventArgs e)
        {
            if (txtFareBasisS5.Text.Length > 11)
            {
                txtFareBasisTS5.Focus();
            }
        }


        //Evento txtFareBasisTS5_TextChanged
        private void txtFareBasisTS5_TextChanged(object sender, EventArgs e)
        {
            if (txtFareBasisTS5.Text.Length > 11)
            {
                txtDiscountS5.Focus();
            }
        }


        //Evento txtDiscountS5_TextChanged
        private void txtDiscountS5_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscountS5.Text.Length > 7)
            {
                txtTicketDesignatorS5.Focus();
            }
        }


        //Evento txtTicketDesignatorS5_TextChanged
        private void txtTicketDesignatorS5_TextChanged(object sender, EventArgs e)
        {
            if (txtTicketDesignatorS5.Text.Length > 11)
            {
                txtBeginS6.Focus();
            }
        }


        //Evento txtBeginS6_TextChanged
        private void txtBeginS6_TextChanged(object sender, EventArgs e)
        {
            if (txtBeginS6.Text.Length > 1)
            {
                txtEndS6.Focus();
            }
        }


        //Evento txtEndS6_TextChanged
        private void txtEndS6_TextChanged(object sender, EventArgs e)
        {
            if (txtEndS6.Text.Length > 1)
            {
                txtFareBasisS6.Focus();
            }
        }


        //Evento txtFareBasisS6_TextChanged
        private void txtFareBasisS6_TextChanged(object sender, EventArgs e)
        {
            if (txtFareBasisS6.Text.Length > 11)
            {
                txtFareBasisTS6.Focus();
            }
        }


        //Evento txtFareBasisTS6_TextChanged
        private void txtFareBasisTS6_TextChanged(object sender, EventArgs e)
        {
            if (txtFareBasisTS6.Text.Length > 11)
            {
                txtDiscountS6.Focus();
            }
        }


        //Evento txtDiscountS6_TextChanged
        private void txtDiscountS6_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscountS6.Text.Length > 7)
            {
                txtTicketDesignatorS6.Focus();
            }
        }


        //Evento txtTicketDesignatorS6_TextChanged
        private void txtTicketDesignatorS6_TextChanged(object sender, EventArgs e)
        {
            if (txtTicketDesignatorS6.Text.Length > 11)
            {
                txtBeginS7.Focus();
            }
        }


        //Evento txtBeginS7_TextChanged
        private void txtBeginS7_TextChanged(object sender, EventArgs e)
        {
            if (txtBeginS7.Text.Length > 1)
            {
                txtEndS7.Focus();
            }
        }


        //Evento txtEndS7_TextChanged
        private void txtEndS7_TextChanged(object sender, EventArgs e)
        {
            if (txtEndS7.Text.Length > 1)
            {
                txtFareBasisS7.Focus();
            }
        }


        //Evento txtFareBasisS7_TextChanged
        private void txtFareBasisS7_TextChanged(object sender, EventArgs e)
        {
            if (txtFareBasisS7.Text.Length > 11)
            {
                txtFareBasisTS7.Focus();
            }
        }


        //Evento txtFareBasisTS7_TextChanged
        private void txtFareBasisTS7_TextChanged(object sender, EventArgs e)
        {
            if (txtFareBasisTS7.Text.Length > 11)
            {
                txtDiscountS7.Focus();
            }
        }


        //Evento txtDiscountS7_TextChanged
        private void txtDiscountS7_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscountS7.Text.Length > 7)
            {
                txtTicketDesignatorS7.Focus();
            }
        }


        //Evento txtTicketDesignatorS7_TextChanged
        private void txtTicketDesignatorS7_TextChanged(object sender, EventArgs e)
        {
            if (txtTicketDesignatorS7.Text.Length > 11)
            {
                txtBeginS8.Focus();
            }
        }


        //Evento txtBeginS8_TextChanged
        private void txtBeginS8_TextChanged(object sender, EventArgs e)
        {
            if (txtBeginS8.Text.Length > 1)
            {
                txtEndS8.Focus();
            }
        }


        //Evento txtEndS8_TextChanged
        private void txtEndS8_TextChanged(object sender, EventArgs e)
        {
            if (txtEndS8.Text.Length > 1)
            {
                txtFareBasisS8.Focus();
            }
        }


        //Evento txtFareBasisS8_TextChanged
        private void txtFareBasisS8_TextChanged(object sender, EventArgs e)
        {
            if (txtFareBasisS8.Text.Length > 11)
            {
                txtFareBasisTS8.Focus();
            }
        }


        //Evento txtFareBasisTS8_TextChanged
        private void txtFareBasisTS8_TextChanged(object sender, EventArgs e)
        {
            if (txtFareBasisTS8.Text.Length > 11)
            {
                txtDiscountS8.Focus();
            }
        }


        //Evento txtDiscountS8_TextChanged
        private void txtDiscountS8_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscountS8.Text.Length > 7)
            {
                txtTicketDesignatorS8.Focus();
            }
        }


        //Evento txtTicketDesignatorS8_TextChanged
        private void txtTicketDesignatorS8_TextChanged(object sender, EventArgs e)
        {
            if (txtTicketDesignatorS8.Text.Length > 11)
            {
                rdoPercentageBySegments.Focus();
            }
        }

        #endregion//End Change focus when a Textbox is Full



        #region ========== Back to a Previous Usercontrol or Validate Enter KeyDown =====

        /// <summary>
        /// Regreso a la mascarilla de "Cotizacíon Aérea" al presionar la tecla ESC
        /// o ejecutar las funciones al presionar la tecla ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                //if (!string.IsNullOrEmpty(ucAllQualityControls.tempChargeService) && ucAllQualityControls.counter < 10)
                //    Loader.AddToPanel(Loader.Zone.Middle, this, "ucCalculateServiceCharge");
                //else
                //    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTICKETSEMISSIONINSTRUCTIONS);
            }

            if (e.KeyData.Equals(Keys.Enter))
            {
                btnAccept_Click(sender, e);
            }
        }
        #endregion//End Back to a Previous Usercontrol or Validate Enter KeyDown





    }
}