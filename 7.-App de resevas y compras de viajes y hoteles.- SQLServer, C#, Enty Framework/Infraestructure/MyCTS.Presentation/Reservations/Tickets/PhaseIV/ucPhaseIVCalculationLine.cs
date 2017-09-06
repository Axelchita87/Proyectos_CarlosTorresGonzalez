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
    public partial class ucPhaseIVCalculationLine : CustomUserControl
    {

        private static string sabrecommandbasefare;
        public static string sabreCommandBaseFare
        {
            get { return sabrecommandbasefare; }
            set { sabrecommandbasefare = value; }
        }

        private static string sabrecommandlinescalculation;
        public static string sabreCommandLinesCalculation
        {
            get { return sabrecommandlinescalculation; }
            set { sabrecommandlinescalculation = value; }
        }

        private static string sabrecommandfarecalculation;
        public static string sabreCommandFareCalculation
        {
            get { return sabrecommandfarecalculation; }
            set { sabrecommandfarecalculation = value; }
        }

        private string sabreAnswer;
        private string sabreConcat;
        private List<string> segmentsNumberArray = new List<string>();
        private List<string> segmentsNumberCommandArray = new List<string>();
        private List<string> segmentsArunkArray = new List<string>();
        private bool validSegmentLine;
        public static List<string> controlValues = new List<string>();
        private bool allowDecimal = true;

        public ucPhaseIVCalculationLine()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = chkConxL1;
            this.LastControlFocus = btnAccept;
        }


        /// <summary>
        /// Ejecucucion de metodos iniciales al cargar la mascarilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucPhaseIVCalculationLine_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            if (!ucCreatePhaseIV.international)
            {
                txtFareQuantity.CharsIncluded = null;
            }
            if (!Convert.ToBoolean(ParameterBL.GetParameterValue("AllowDecimalNumbers").Values))
            {
                txtEquivalentQuantity.CharsIncluded = null;
                foreach (Control tc in this.Controls)
                {
                    if (tc is SmartTextBox && tc.Name.Contains(Resources.TicketEmission.Constants.STRING_CONTAINS_TAXQUANTITY))
                        ((SmartTextBox)(tc)).CharsIncluded = null;
                }
                allowDecimal = false;
            }
            LoadpreviousControlValues();
            UnableTextBoxBackColor();
            VerifySegments();    
            VerifyFlightType();
            ActiveControls();
        }


        /// <summary>
        /// Ejecucion de metodos al presionar el boton Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidBusinessRules)
            {
                LoadFareCalculationValues();
                BuildCommandBasefare();
                BuildCommandLinesCalculation();
                LoadControlValues();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_BREAKDOWN);
                
            }
        }

        #region===== MethodsClass =====


        /// <summary>
        /// Carga los datos de los controles para mantener los valores 
        /// </summary>
        private void LoadControlValues()
        {
            //RedimControlValues(143);
            for (int i = 0; i < 143; i++)
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is SmartTextBox)
                    {
                        if (ctrl.TabIndex.Equals(i + 1))
                        {
                            controlValues.Add(ctrl.Text);
                        }
                    }
                    else if (ctrl is CheckBox)
                    {
                        if (ctrl.TabIndex.Equals(i + 1))
                        {
                            controlValues.Add(((CheckBox)(ctrl)).Checked.ToString().ToUpper());
                        }
                    }
                }
            }
            
        }


        /// <summary>
        /// Ingresa los valores previos a los controles en caso de que existan
        /// </summary>
        private void LoadpreviousControlValues()
        {
            if (!controlValues.Count.Equals(0))
            {
                for (int i = 0; i < controlValues.Count; i++)
                {
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is SmartTextBox)
                        {
                            if (ctrl.TabIndex.Equals(i + 1))
                            {
                                ctrl.Text = controlValues[i];
                            }
                        }
                        else if (ctrl is CheckBox)
                        {
                            if (ctrl.TabIndex.Equals(i + 1))
                            {
                                if(controlValues[i].Equals(Resources.TicketEmission.Constants.TRUE))
                                    ((CheckBox)(ctrl)).Checked = true;
                                else
                                    ((CheckBox)(ctrl)).Checked = false;
                            }
                        }
                    }
                }
                
            }
        }


        /// <summary>
        /// Verifica que segmentos aereos no son ARUNK para activarlos en la mascarilla
        /// </summary>
        private void VerifySegments()
        {
            string send = string.Empty;
            string sabreAnswer = string.Empty;
            int row = 0;
            int col = 0;
            int size = 1;

            send = Resources.TicketEmission.Constants.COMMANDS_AST_IAB;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }

            CommandsQik.searchResponse(sabreAnswer, "ITINERARY AIR SEGMENTS", ref row, ref col);
            if (row != 0 || col != 0)
            {
                sabreConcat = string.Empty;
                sabreConcat = sabreAnswer;
                BucleSearchAirSegments();
            }

            string[] sabreAnswerInfo = sabreAnswer.Split(new char[] { '\n' });

            for (int i = 1; i < sabreAnswerInfo.Length; i++)
            {
                if (!string.IsNullOrEmpty(sabreAnswerInfo[i]))
                {
                    col = 0;
                    row = 0;
                    CommandsQik.searchResponse(sabreAnswerInfo[i], "ARNK", ref row, ref col, 1, 1, 5, 12);
                    if (row != 0 || col != 0)
                    {
                        string segmentArunkNumber = string.Empty;
                        CommandsQik.CopyResponse(sabreAnswerInfo[i], ref segmentArunkNumber, 1, 1, 3);
                        segmentArunkNumber = segmentArunkNumber.Trim();
                        segmentsArunkArray.Add(segmentArunkNumber);
                    }
                    else
                    {
                        string segmentNumber = string.Empty;
                        CommandsQik.CopyResponse(sabreAnswerInfo[i], ref segmentNumber, 1, 1, 3);
                        segmentNumber = segmentNumber.Trim();
                        segmentsNumberArray.Add(segmentNumber);
                        size++;
                    }
                }
            }
            VerifyCommandSegments();
        }


        /// <summary>
        /// Verifica los segmentos a aplicar en el comando de linea contable
        /// </summary>
        private void VerifyCommandSegments()
        {
            string send = string.Empty;
            sabreAnswer = string.Empty;
            int row = 0;
            int col = 0;
            send = Resources.TicketEmission.Constants.COMMANDS_AST_AST_W;
            if (!string.IsNullOrEmpty(ucPhaseIVSelectMask.maskNumber))
                send = string.Concat(send,
                    ucPhaseIVSelectMask.maskNumber);

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }

            CommandsQik.searchResponse(sabreAnswer, "TA", ref row, ref col);
            if (row != 0 || col != 0)
            {
                sabreConcat = string.Empty;
                sabreConcat = sabreAnswer;
                BucleSearchAirSegments();
            }

            string[] sabreAnswerInfo = sabreConcat.Split(new char[] { '\n' });

            for (int i = 1; i < sabreAnswerInfo.Length; i++)
            {
                if (!string.IsNullOrEmpty(sabreAnswerInfo[i]))
                {
                    col = 0;
                    row = 0;
                    CommandsQik.searchResponse(sabreAnswerInfo[i], "VOID", ref row, ref col, 1, 1, 36, 60);
                    if (row == 0)
                    {
                        string segmentNumber = string.Empty;
                        CommandsQik.CopyResponse(sabreAnswerInfo[i], ref segmentNumber, 1, 1, 3);
                        segmentNumber = segmentNumber.Trim();
                        try
                        {
                            int temp = Convert.ToInt32(segmentNumber);
                            segmentsNumberCommandArray.Add(segmentNumber);
                        }
                        catch { }
                    }
                    
                }
            }

        }


        /// <summary>
        /// Verifica el tipo de vuelo para activar o desactivar las casillas de la seccion 
        /// equivalente
        /// </summary>
        private void VerifyFlightType()
        {
            if (ucCreatePhaseIV.internationalFlight)
            {
                txtEquivalentCode.Enabled = true;
                txtEquivalentCode.BackColor = Color.White;
                txtEquivalentQuantity.Enabled = true;
                txtEquivalentQuantity.BackColor = Color.White;
            }

            
        }


        /// <summary>
        /// Valida si existen mas segmentos aereos
        /// </summary>
        /// <returns></returns>
        private bool SearchAirSegments()
        {
            bool isEndOfScroll = false;
            string send = string.Empty;
            sabreAnswer = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_MD;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
            int row = 0;
            int col = 0;
            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.NOTHING_TO_SCROLL, ref row, ref col);
            if (row > 0)
            {
                isEndOfScroll = true;
            }
            else
            {
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.END_OF_SCROLL, ref row, ref col);
                if (row > 0)
                {
                    isEndOfScroll = true;
                }
                else
                {
                    sabreConcat = string.Concat("\n",
                        sabreAnswer);
                    isEndOfScroll = false;
                }
            }

            return isEndOfScroll;


        }


        /// <summary>
        /// Realiza el bucle de busqueda de segmentos aereos en el record
        /// </summary>
        private void BucleSearchAirSegments()
        {
            if (!SearchAirSegments())
                BucleSearchAirSegments();
        }


        ///// <summary>
        ///// Redimensiona el arreglo que contiene los numeros de segmentos a activar
        ///// </summary>
        ///// <param name="newsize"></param>
        //private void Redim(int newsize)
        //{
        //    string[] tempReDim = new string[newsize];
        //    if (segmentsNumberArray != null)
        //        System.Array.Copy(segmentsNumberArray, tempReDim, System.Math.Min(segmentsNumberArray.Length, tempReDim.Length));
        //    segmentsNumberArray = tempReDim;
        //}


        ///// <summary>
        ///// Redimensiona el arreglo que contiene los datos de los controles de la mascarilla
        ///// </summary>
        ///// <param name="newsize"></param>
        //private void RedimControlValues(int newsize)
        //{
        //    string[] tempReDim = new string[newsize];
        //    if (controlValues != null)
        //        System.Array.Copy(controlValues, tempReDim, System.Math.Min(controlValues.Length, tempReDim.Length));
        //    controlValues = tempReDim;
        //}


        /// <summary>
        /// Activa los controles correspondientes a los segmentos aereos del record
        /// </summary>
        private void ActiveControls()
        {
            validSegmentLine = false;
            foreach (string numberLine in segmentsNumberArray)
            {
                
                foreach (Control control in this.Controls)
                {
                    if (!(control is Label))
                    {
                        if (!ucCreatePhaseIV.bySegments)
                        {
                            if (control.Name.EndsWith(string.Concat(Resources.TicketEmission.Constants.STRING_CONTAINS_L, numberLine)) &&
                                !Regex.IsMatch(control.Name, Resources.TicketEmission.Constants.STRING_CONTAINS_TAX))
                            {
                                control.Enabled = true;
                                control.BackColor = Color.White;
                            }
                        }
                        else 
                        {
                            
                            string[] segments = ucPhaseIVBySegments.Segments.Split(new char[] { '+' });
                            foreach (string segmentExist in segments)
                            {
                                if (!string.IsNullOrEmpty(segmentExist))
                                {
                                    if (segmentExist.Equals(numberLine))
                                    {
                                        if (control.Name.EndsWith(string.Concat(Resources.TicketEmission.Constants.STRING_CONTAINS_L, numberLine)) &&
                                        !Regex.IsMatch(control.Name, Resources.TicketEmission.Constants.STRING_CONTAINS_TAX))
                                        {
                                            control.Enabled = true;
                                            control.BackColor = Color.White;
                                            validSegmentLine = true;
                                        }
                                    }
                                }
                                
                            }
                            
                        }
  
                    }
                }
                
            }
            if (ucCreatePhaseIV.bySegments && !validSegmentLine)
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.NO_INGRESADOS_SEGMENTOS_VALIDOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_PHASEIV_BY_SEGMENTS);
            }
        }

        /// <summary>
        /// establece el color de fondo de los controles inactivos
        /// </summary>
        private void UnableTextBoxBackColor()
        {
            foreach (Control txt in this.Controls)
            {
                if (txt is SmartTextBox)
                {
                    if (!txt.Enabled)
                        txt.BackColor = SystemColors.Control;
                }
            }
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
                for (int i = 1; i <= 16; i++)
                {
                    foreach (Control txt in this.Controls)
                    {
                        if (txt is TextBox)
                        {
                            if (txt.Enabled &&
                                string.IsNullOrEmpty(txt.Text) &&
                                txt.Name.EndsWith(string.Concat(Resources.TicketEmission.Constants.STRING_CONTAINS_TXTFAREBASISL, i)))
                            {
                                MessageBox.Show(string.Format(Resources.TicketEmission.Tickets.DEBES_INGRESAR_DATOS_CAMPO_FAREBASIS, i), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                isValid = false;
                                txt.Focus();
                                break;
                            }

                        }
                    }
                    if (!isValid)
                        break;

                    //foreach (Control txt in this.Controls)
                    //{
                    //    if (txt is TextBox)
                    //    {
                    //        if (txt.Enabled &&
                    //            string.IsNullOrEmpty(txt.Text) &&
                    //            txt.Name.EndsWith(string.Concat("txtMinL", i)))
                    //        {
                    //            MessageBox.Show(string.Concat("DEBES INGRESAR DATOS EN EL CAMPO MIN DE LA LÍNEA ", i), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //            isValid = false;
                    //            txt.Focus();
                    //            break;
                    //        }

                    //    }
                    //}
                    //if (!isValid)
                    //    break;

                    foreach (Control txt in this.Controls)
                    {
                        if (txt is TextBox)
                        {
                            if (txt.Enabled &&
                                string.IsNullOrEmpty(txt.Text) &&
                                txt.Name.EndsWith(string.Concat(Resources.TicketEmission.Constants.STRING_CONTAINS_TXTMAXL, i)))
                            {
                                MessageBox.Show(string.Format(Resources.TicketEmission.Tickets.DEBES_INGRESAR_DATOS_CAMPO_MAX, i), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                isValid = false;
                                txt.Focus();
                                break;
                            }

                        }
                    }
                    if (!isValid)
                        break;

                    foreach (Control txt in this.Controls)
                    {
                        if (txt is TextBox)
                        {
                            if (txt.Enabled &&
                                string.IsNullOrEmpty(txt.Text) &&
                                txt.Name.EndsWith(string.Concat(Resources.TicketEmission.Constants.STRING_CONTAINS_TXTLUGGAGEL, i)))
                            {
                                MessageBox.Show(string.Format(Resources.TicketEmission.Tickets.DEBES_INGRESAR_DATOS_CAMPO_EQUIPAJE, i), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                isValid = false;
                                txt.Focus();
                                break;
                            }

                        }
                    }
                    if (!isValid)
                        break;

                }

                if (isValid)
                {
                    for (int i = 1; i <= 20; i++)
                    {
                        foreach (Control txtTax in this.Controls)
                        {
                            if (txtTax is TextBox)
                            {
                                if (txtTax.Enabled && txtTax.Name.EndsWith(string.Concat(Resources.TicketEmission.Constants.STRING_CONTAINS_TAXQUANTITY, i)))
                                {
                                    if (allowDecimal && !string.IsNullOrEmpty(txtTax.Text) && !ValidateRegularExpression.ValidateTwoDecimalsPhaseIV(txtTax.Text))
                                    {
                                        MessageBox.Show(string.Format(Resources.TicketEmission.Tickets.FORMATO_CANTIDAD_IMPUESTO_INCORRECTO, i), Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        isValid = false;
                                        txtTax.Focus();
                                        break;
                                    }
                                }
                            }

                        }
                        if (!isValid)
                            break;

                    }
                }

                if (!isValid)
                {
                    //solo es para que no entre a los demas mensajes
                }
                else if (!string.IsNullOrEmpty(txtFareQuantity.Text) && !ValidateRegularExpression.ValidateTwoDecimalsPhaseIV(txtFareQuantity.Text) && allowDecimal)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.FORMATO_CANTIDAD_TARIFA_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isValid = false;
                    txtFareQuantity.Focus();
                }
                else if (allowDecimal && !string.IsNullOrEmpty(txtEquivalentQuantity.Text) && !ValidateRegularExpression.ValidateTwoDecimalsPhaseIV(txtEquivalentQuantity.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.FORMATO_CANTIDAD_EQUIVALENTE_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isValid = false;
                    txtEquivalentQuantity.Focus();
                }
                else if (isValid && txtFareCode.Enabled && string.IsNullOrEmpty(txtFareCode.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_INGRESAR_CODIGO_TARIFA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isValid = false;
                    txtFareCode.Focus();
                }
                else if (isValid && txtFareQuantity.Enabled && string.IsNullOrEmpty(txtFareQuantity.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_INGRESAR_TARIFA_APLICABLE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isValid = false;
                    txtFareQuantity.Focus();
                }
                else if (isValid && txtTaxQuantity1.Enabled && string.IsNullOrEmpty(txtTaxQuantity1.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_INGRESAR_CANTIDAD_IMPUESTO1, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isValid = false;
                    txtTaxQuantity1.Focus();
                }
                else if (isValid && txtTaxCode1.Enabled && string.IsNullOrEmpty(txtTaxCode1.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_INGRESAR_CODIGO_IMPUESTO1, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isValid = false;
                    txtTaxCode1.Focus();
                }
                else if (isValid && txtTaxQuantity2.Enabled && string.IsNullOrEmpty(txtTaxQuantity2.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_INGRESAR_CANTIDAD_IMPUESTO2, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isValid = false;
                    txtTaxQuantity2.Focus();
                }
                else if (isValid && txtTaxCode2.Enabled && string.IsNullOrEmpty(txtTaxCode2.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_INGRESAR_CODIGO_IMPUESTO2, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isValid = false;
                    txtTaxCode2.Focus();
                }


                return isValid;
            }
        }


        /// <summary>
        /// Arma el comando de linea de calculo
        /// </summary>
        private void LoadFareCalculationValues()
        {

            sabrecommandfarecalculation = string.Empty;
            if (!string.IsNullOrEmpty(txtITCode.Text))
                sabrecommandfarecalculation = string.Concat(Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_U,
                    txtITCode.Text);

            if(!string.IsNullOrEmpty(txtEndorsment.Text))
                sabrecommandfarecalculation = string.Concat(sabrecommandfarecalculation,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_ED_SLASH,
                    txtEndorsment.Text);

        }



        /// <summary>
        /// Arma el comando de Tarifa base e impuestos
        /// </summary>
        private void BuildCommandBasefare()
        {
            sabrecommandbasefare = string.Empty;
            sabrecommandbasefare = Resources.TicketEmission.Constants.COMMANDS_W_CROSSLORAINE_I;
            if (!string.IsNullOrEmpty(ucPhaseIVSelectMask.maskNumber))
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                    ucPhaseIVSelectMask.maskNumber);
            sabrecommandbasefare = string.Concat(sabrecommandbasefare, 
                Resources.TicketEmission.Constants.CROSS_LORAINE,
                Resources.TicketEmission.Constants.COMMANDS_Y,
                txtFareCode.Text,
                txtFareQuantity.Text);

            if (txtEquivalentCode.Enabled)
            {
                sabrecommandbasefare = string.Concat(sabreCommandBaseFare,
                    Resources.TicketEmission.Constants.CROSS_LORAINE,
                    Resources.TicketEmission.Constants.COMMANDS_E,
                    txtEquivalentCode.Text,
                    txtEquivalentQuantity.Text);
            }

            sabreCommandBaseFare = string.Concat(sabreCommandBaseFare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity1.Text,
                txtTaxCode1.Text);

            sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity2.Text,
                txtTaxCode2.Text);

            if (!string.IsNullOrEmpty(txtTaxQuantity3.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity3.Text,
                txtTaxCode3.Text);
            }

            if (!string.IsNullOrEmpty(txtTaxQuantity4.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity4.Text,
                txtTaxCode4.Text);
            }

            if (!string.IsNullOrEmpty(txtTaxQuantity5.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity5.Text,
                txtTaxCode5.Text);
            }

            if (!string.IsNullOrEmpty(txtTaxQuantity6.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity6.Text,
                txtTaxCode6.Text);
            }

            if (!string.IsNullOrEmpty(txtTaxQuantity7.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity7.Text,
                txtTaxCode7.Text);
            }

            if (!string.IsNullOrEmpty(txtTaxQuantity7.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity7.Text,
                txtTaxCode7.Text);
            }

            if (!string.IsNullOrEmpty(txtTaxQuantity8.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity8.Text,
                txtTaxCode8.Text);
            }

            if (!string.IsNullOrEmpty(txtTaxQuantity9.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity9.Text,
                txtTaxCode9.Text);
            }

            if (!string.IsNullOrEmpty(txtTaxQuantity10.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity10.Text,
                txtTaxCode10.Text);
            }

            if (!string.IsNullOrEmpty(txtTaxQuantity11.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity11.Text,
                txtTaxCode11.Text);
            }

            if (!string.IsNullOrEmpty(txtTaxQuantity12.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity12.Text,
                txtTaxCode12.Text);
            }

            if (!string.IsNullOrEmpty(txtTaxQuantity13.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity13.Text,
                txtTaxCode13.Text);
            }

            if (!string.IsNullOrEmpty(txtTaxQuantity14.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity14.Text,
                txtTaxCode14.Text);
            }

            if (!string.IsNullOrEmpty(txtTaxQuantity15.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity15.Text,
                txtTaxCode15.Text);
            }

            if (!string.IsNullOrEmpty(txtTaxQuantity16.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity16.Text,
                txtTaxCode16.Text);
            }

            if (!string.IsNullOrEmpty(txtTaxQuantity17.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity17.Text,
                txtTaxCode17.Text);
            }

            if (!string.IsNullOrEmpty(txtTaxQuantity18.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity18.Text,
                txtTaxCode18.Text);
            }

            if (!string.IsNullOrEmpty(txtTaxQuantity19.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity19.Text,
                txtTaxCode19.Text);
            }

            if (!string.IsNullOrEmpty(txtTaxQuantity20.Text))
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                Resources.TicketEmission.Constants.SLASH,
                txtTaxQuantity20.Text,
                txtTaxCode20.Text);
            }

            if (chkExentTaxes.Checked)
            {
                sabrecommandbasefare = string.Concat(sabrecommandbasefare,
                    Resources.TicketEmission.Constants.COMMANDS_SLASH_TE);
                
            }

            
        }

        private void BuildCommandLinesCalculation()
        {
            int i = 0;
            string segments = string.Empty;
            if (!segmentsNumberArray.Count.Equals(0))
            {
                foreach (string values in segmentsArunkArray)
                {
                    segments = string.Concat(segments,
                        values,
                        ",");
                }
            }

            string blankSpaces = "     ";
            sabrecommandlinescalculation = string.Empty;
            sabrecommandlinescalculation = Resources.TicketEmission.Constants.COMMANDS_W_CROSSLORAINE_I;
            if (!string.IsNullOrEmpty(ucPhaseIVSelectMask.maskNumber))
                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    ucPhaseIVSelectMask.maskNumber);

            //Linea 1
            if (txtFareBasisL1.Enabled)
            {
                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_L,
                    segmentsNumberCommandArray[i]);
                if (chkConxL1.Checked)
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.X);

                sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.INDENT,
                    txtFareBasisL1.Text);

                if (!string.IsNullOrEmpty(txtTicketDesignatorL1.Text))
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.SLASH,
                        txtTicketDesignatorL1.Text);

                if (!string.IsNullOrEmpty(txtMinL1.Text))
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        txtMinL1.Text,
                        txtMaxL1.Text);
                else
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        blankSpaces,
                        txtMaxL1.Text);

                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_AST_BA,
                    txtLuggageL1.Text);
                i++;
            }
            
            //Fin Linea 1

            //Linea 2
            if (txtFareBasisL2.Enabled)
            {
                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_L,
                    segmentsNumberCommandArray[i]);
                if (chkConxL2.Checked)
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.X);

                sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.INDENT,
                    txtFareBasisL2.Text);

                if (!string.IsNullOrEmpty(txtTicketDesignatorL2.Text))
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.SLASH,
                        txtTicketDesignatorL2.Text);

                if (!string.IsNullOrEmpty(txtMinL2.Text))
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                       txtMinL2.Text,
                        txtMaxL2.Text);
                else
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        blankSpaces,
                        txtMaxL2.Text);

                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_AST_BA,
                    txtLuggageL2.Text);
                i++;
            }
            //Fin Linea 2

            //Linea 3
            if (txtFareBasisL3.Enabled)
            {
                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_L,
                    segmentsNumberCommandArray[i]);
                if (chkConxL3.Checked)
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.X);

                sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.INDENT,
                    txtFareBasisL3.Text);

                if (!string.IsNullOrEmpty(txtTicketDesignatorL3.Text))
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.SLASH,
                        txtTicketDesignatorL3.Text);

                if (!string.IsNullOrEmpty(txtMinL3.Text))
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        txtMinL3.Text,
                        txtMaxL3.Text);
                else
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        blankSpaces,
                        txtMaxL3.Text);

                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_AST_BA,
                    txtLuggageL3.Text);
                i++;
            }
            //Fin Linea 3

            //Linea 4
            if (txtFareBasisL4.Enabled)
            {
                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_L,
                    segmentsNumberCommandArray[i]);
                if (chkConxL4.Checked)
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.X);

                sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.INDENT,
                    txtFareBasisL4.Text);

                if (!string.IsNullOrEmpty(txtTicketDesignatorL4.Text))
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.SLASH,
                        txtTicketDesignatorL4.Text);

                if (!string.IsNullOrEmpty(txtMinL4.Text))
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        txtMinL4.Text,
                        txtMaxL4.Text);
                else
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        blankSpaces,
                        txtMaxL4.Text);

                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_AST_BA,
                    txtLuggageL4.Text);
                i++;
            }
            //Fin Linea 4

            //Linea 5
            if (txtFareBasisL5.Enabled)
            {
                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_L,
                    segmentsNumberCommandArray[i]);
                if (chkConxL5.Checked)
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.X);

                sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.INDENT,
                    txtFareBasisL5.Text);

                if (!string.IsNullOrEmpty(txtTicketDesignatorL5.Text))
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.SLASH,
                        txtTicketDesignatorL5.Text);

                if (!string.IsNullOrEmpty(txtMinL5.Text))
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        txtMinL5.Text,
                        txtMaxL5.Text);
                else
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        blankSpaces,
                        txtMaxL5.Text);

                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_AST_BA,
                    txtLuggageL5.Text);
                i++;
            }
            //Fin Linea 5

            //Linea 6
            if (txtFareBasisL6.Enabled)
            {
                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_L,
                    segmentsNumberCommandArray[i]);
                if (chkConxL6.Checked)
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.X);

                sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.INDENT,
                    txtFareBasisL6.Text);

                if (!string.IsNullOrEmpty(txtTicketDesignatorL6.Text))
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.SLASH,
                        txtTicketDesignatorL6.Text);

                if (!string.IsNullOrEmpty(txtMinL6.Text))
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        txtMinL6.Text,
                        txtMaxL6.Text);
                else
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        blankSpaces,
                        txtMaxL6.Text);

                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_AST_BA,
                    txtLuggageL6.Text);
                i++;
            }
            //Fin Linea 6

            //Linea 7
            if (txtFareBasisL7.Enabled)
            {
                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_L,
                    segmentsNumberCommandArray[i]);
                if (chkConxL7.Checked)
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.X);

                sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.INDENT,
                    txtFareBasisL7.Text);

                if (!string.IsNullOrEmpty(txtTicketDesignatorL7.Text))
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.SLASH,
                        txtTicketDesignatorL7.Text);

                if (!string.IsNullOrEmpty(txtMinL7.Text))
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        txtMinL7.Text,
                        txtMaxL7.Text);
                else
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        blankSpaces,
                        txtMaxL7.Text);

                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_AST_BA,
                    txtLuggageL7.Text);
                i++;
            }
            //Fin Linea 7

            //Linea 8
            if (txtFareBasisL8.Enabled)
            {
                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_L,
                    segmentsNumberCommandArray[i]);
                if (chkConxL8.Checked)
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.X);

                sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.INDENT,
                    txtFareBasisL8.Text);

                if (!string.IsNullOrEmpty(txtTicketDesignatorL8.Text))
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.SLASH,
                        txtTicketDesignatorL8.Text);

                if (!string.IsNullOrEmpty(txtMinL8.Text))
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        txtMinL8.Text,
                        txtMaxL8.Text);
                else
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        blankSpaces,
                        txtMaxL8.Text);

                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_AST_BA,
                    txtLuggageL8.Text);
                i++;
            }
            //Fin Linea 8

            //Linea 9
            if (txtFareBasisL9.Enabled)
            {
                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_L,
                    segmentsNumberCommandArray[i]);
                if (chkConxL9.Checked)
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.X);

                sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.INDENT,
                    txtFareBasisL9.Text);

                if (!string.IsNullOrEmpty(txtTicketDesignatorL9.Text))
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.SLASH,
                        txtTicketDesignatorL9.Text);

                if (!string.IsNullOrEmpty(txtMinL9.Text))
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        txtMinL9.Text,
                        txtMaxL9.Text);
                else
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        blankSpaces,
                        txtMaxL9.Text);

                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_AST_BA,
                    txtLuggageL9.Text);
                i++;
            }
            //Fin Linea 9

            //Linea 10
            if (txtFareBasisL10.Enabled)
            {
                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_L,
                    segmentsNumberCommandArray[i]);
                if (chkConxL10.Checked)
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.X);

                sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.INDENT,
                    txtFareBasisL10.Text);

                if (!string.IsNullOrEmpty(txtTicketDesignatorL10.Text))
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.SLASH,
                        txtTicketDesignatorL10.Text);

                if (!string.IsNullOrEmpty(txtMinL10.Text))
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        txtMinL10.Text,
                        txtMaxL10.Text);
                else
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        blankSpaces,
                        txtMaxL10.Text);

                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_AST_BA,
                    txtLuggageL10.Text);
                i++;
            }
            //Fin Linea 10

            //Linea 11
            if (txtFareBasisL11.Enabled)
            {
                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_L,
                    segmentsNumberCommandArray[i]);
                if (chkConxL11.Checked)
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.X);

                sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.INDENT,
                    txtFareBasisL11.Text);

                if (!string.IsNullOrEmpty(txtTicketDesignatorL11.Text))
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.SLASH,
                        txtTicketDesignatorL11.Text);

                if (!string.IsNullOrEmpty(txtMinL11.Text))
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        txtMinL11.Text,
                        txtMaxL11.Text);
                else
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        blankSpaces,
                        txtMaxL11.Text);

                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_AST_BA,
                    txtLuggageL11.Text);
                i++;
            }
            //Fin Linea 11

            //Linea 12
            if (txtFareBasisL12.Enabled)
            {
                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_L,
                    segmentsNumberCommandArray[i]);
                if (chkConxL12.Checked)
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.X);

                sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.INDENT,
                    txtFareBasisL12.Text);

                if (!string.IsNullOrEmpty(txtTicketDesignatorL12.Text))
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.SLASH,
                        txtTicketDesignatorL12.Text);

                if (!string.IsNullOrEmpty(txtMinL12.Text))
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        txtMinL12.Text,
                        txtMaxL12.Text);
                else
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        blankSpaces,
                        txtMaxL12.Text);

                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_AST_BA,
                    txtLuggageL12.Text);
                i++;
            }
            //Fin Linea 12

            //Linea 13
            if (txtFareBasisL13.Enabled)
            {
                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_L,
                    segmentsNumberCommandArray[i]);
                if (chkConxL13.Checked)
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.X);

                sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.INDENT,
                    txtFareBasisL13.Text);

                if (!string.IsNullOrEmpty(txtTicketDesignatorL13.Text))
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.SLASH,
                        txtTicketDesignatorL13.Text);

                if (!string.IsNullOrEmpty(txtMinL13.Text))
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        txtMinL13.Text,
                        txtMaxL13.Text);
                else
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        blankSpaces,
                        txtMaxL13.Text);

                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_AST_BA,
                    txtLuggageL13.Text);
                i++;
            }
            //Fin Linea 13

            //Linea 14
            if (txtFareBasisL14.Enabled)
            {
                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_L,
                    segmentsNumberCommandArray[i]);
                if (chkConxL14.Checked)
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.X);

                sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.INDENT,
                    txtFareBasisL14.Text);

                if (!string.IsNullOrEmpty(txtTicketDesignatorL14.Text))
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.SLASH,
                        txtTicketDesignatorL14.Text);

                if (!string.IsNullOrEmpty(txtMinL14.Text))
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        txtMinL14.Text,
                        txtMaxL14.Text);
                else
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        blankSpaces,
                        txtMaxL14.Text);

                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_AST_BA,
                    txtLuggageL14.Text);
                i++;
            }
            //Fin Linea 14

            //Linea 15
            if (txtFareBasisL15.Enabled)
            {
                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_L,
                    segmentsNumberCommandArray[i]);
                if (chkConxL15.Checked)
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.X);

                sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.INDENT,
                    txtFareBasisL15.Text);

                if (!string.IsNullOrEmpty(txtTicketDesignatorL15.Text))
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.SLASH,
                        txtTicketDesignatorL15.Text);

                if (!string.IsNullOrEmpty(txtMinL15.Text))
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        txtMinL15.Text,
                        txtMaxL15.Text);
                else
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        blankSpaces,
                        txtMaxL15.Text);

                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_AST_BA,
                    txtLuggageL15.Text);
                i++;
            }
            //Fin Linea 15

            //Linea 16
            if (txtFareBasisL16.Enabled)
            {
                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_L,
                    segmentsNumberCommandArray[i]);
                if (chkConxL16.Checked)
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.X);

                sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.INDENT,
                    txtFareBasisL16.Text);

                if (!string.IsNullOrEmpty(txtTicketDesignatorL16.Text))
                    sabrecommandlinescalculation = String.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.SLASH,
                        txtTicketDesignatorL16.Text);

                if (!string.IsNullOrEmpty(txtMinL16.Text))
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        txtMinL16.Text,
                        txtMaxL16.Text);
                else
                    sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                        Resources.TicketEmission.Constants.AST,
                        blankSpaces,
                        txtMaxL16.Text);

                sabrecommandlinescalculation = string.Concat(sabrecommandlinescalculation,
                    Resources.TicketEmission.Constants.COMMANDS_AST_BA,
                    txtLuggageL16.Text);
                i++;
            }
            //Fin Linea 16
        }

        
        #endregion//End MethodsClass

        

        #region =====Back to a Previous Usercontrol or Validate Enter KeyDown=====


        /// <summary>
        /// aborta el proceso al presionar la tecla ESC
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



        #region=====Change focus When a Textbox is Full=====

        //Evento txtControl_TextChanged
        private void txtControl_TextChanged(object sender, EventArgs e)
        {
            if (sender is SmartTextBox)
            {
                if (((SmartTextBox)sender).Text.Length > ((SmartTextBox)sender).MaxLength - 1)
                {
                    foreach (Control txt in this.Controls)
                    {
                        if (txt.TabIndex.Equals(((SmartTextBox)(sender)).TabIndex + 1))
                        {
                            txt.Focus();
                        }

                    }
                }
            }

        }

        #endregion//End Change focus When a Textbox is Full



    }
}