using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;

namespace MyCTS.Presentation
{
    public partial class ucQualitiesByPax : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite validar si los controles de calidad 
        ///              se deben aplicar a todos los pasajeros o solo a algunos
        /// Creación:    05 Octubre 09
        /// Solicito:    Guillermo Granados
        /// Autor:       Angel Trejo
        /// </summary>
        /// 

        private static string numberone;
        public static string numberOne
        {
            get { return numberone; }
            set { numberone = value; }
        }

        private static string numbertwo;
        public static string numberTwo
        {
            get { return numbertwo; }
            set { numbertwo = value; }
        }

        private static string numberthree;
        public static string numberThree
        {
            get { return numberthree; }
            set { numberthree = value; }
        }

        private static string numberfour;
        public static string numberFour
        {
            get { return numberfour; }
            set { numberfour = value; }
        }

        private static string passengers;
        public static string Passengers
        {
            get { return passengers; }
            set { passengers = value; }
        }

        private static string sabreconcat;
        public static string sabreConcat
        {
            get { return sabreconcat; }
            set { sabreconcat = value; }
        }

        public static int pax;
        public static int Pax
        {
            get { return pax; }
            set { pax = value; }
        }

        public static DateTime dayTime;
        public static DateTime DayTime
        {
            get { return dayTime; }
            set { dayTime = value; }
        }

        public static string[] arraypassengers = new string[0];
        private static string sabreAnswer;
        public static string extendDescription = string.Empty;


        private int max, min, total;
        private bool isValid = false;

        public ucQualitiesByPax()
        {
            InitializeComponent();
            this.InitialControlFocus = rdoYes;
            this.LastControlFocus = btnAccept;
        }

        private void rdoYes_CheckedChanged(object sender, EventArgs e)
        {
            showControls(false);
            arraypassengers = null;
            isValid = false;
        }

        private void rdoNo_CheckedChanged(object sender, EventArgs e)
        {
            showControls(true);
            txtName1.Text = string.Empty;
            txtName2.Text = string.Empty;
            txtName3.Text = string.Empty;
            txtName4.Text = string.Empty;
        }

        private void ucQualitiesByPax_Load(object sender, EventArgs e)
        {
            VolarisSession.Clean();
            ucAvailability.IsInterJetProcess = false;
            string attribute = string.Empty;
            bool cfeRemark = Convert.ToBoolean(ParameterBL.GetParameterValue("ActivateRemarkToCFE").Values);
            if (!ucEndReservation.isFlowHotel)
            {
                attribute = ucFirstValidations.Attribute1.Substring(3, 3);
            }
            else
            {
                attribute = ucQCHotels.Attribute1.Substring(3, 3);
            }
            if (attribute.Equals("990"))
                showDescription(false);
            else
                showDescription(true);

            if (ucEndReservation.isFlowHotel)
            {
                if (ucQCHotels.Attribute1.Equals("CFE100") && cfeRemark && !ucRemarkToCFE.Status)
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCREMARKTOCFE);
                    return;
                }
                else
                    ucRemarkToCFE.Status = false;

            }
            else
            {
                if (ucFirstValidations.Attribute1.Equals("CFE100") && cfeRemark && !ucRemarkToCFE.Status)
                {
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCREMARKTOCFE);
                    return;
                }
                else
                    ucRemarkToCFE.Status = false;
            }
            dayTime = DateTime.Now;
            ucFormPayment.C28 = string.Empty;
            LoadCreditCardTypeOption();
            rdoYes.Checked = true;
            rdoYes.Focus();
            ucAllQualityControls.originOfSale.Clear();
            ucAllQualityControls.ListBussinesUnit.Clear();
            numberone = string.Empty;
            numbertwo = string.Empty;
            numberthree = string.Empty;
            numberfour = string.Empty;
            passengers = string.Empty;
            pax = 0;
            sabreAnswer = string.Empty;
            if (string.IsNullOrEmpty(sabreconcat))
            {
                commandSend();
                bucleFindEndScroll();
            }
        }



        private void btnAccept_Click(object sender, EventArgs e)
        {
            extendDescription = string.Empty;

            if (!string.IsNullOrEmpty(txtDescription1.Text) | (!string.IsNullOrEmpty(txtDescription2.Text)))
            {
               string send = string.Empty;
                send = Resources.TicketEmission.Constants.COMMANDS_FIVE_POINT;
                if (!string.IsNullOrEmpty(txtDescription1.Text))
                {
                    send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_DES01_IDENT,
                        txtDescription1.Text);
                    if (!string.IsNullOrEmpty(txtDescription2.Text))
                    {
                        send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_ENDIT_5_DES02_INDENT,
                            txtDescription2.Text);
                    }
                }

                else if (!string.IsNullOrEmpty(txtDescription2.Text))
                {
                    send = string.Concat(send, Resources.TicketEmission.Constants.COMMANDS_DES02_INDENT,
                        txtDescription2.Text);
                }

                extendDescription = send;
            }

            if (rdoYes.Checked)
            {
                passengerNumbers();
                CreditCardSelecType();
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_ALL_QUALITY_CONTROLS);
            }
            else
            {
                if (isValidBussinesRules())
                {
                    buildString();
                    if (!calculatePassengers())
                    {
                        if (!deleteDuplicateValues())
                        {
                            CreditCardSelecType();
                            Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_ALL_QUALITY_CONTROLS);
                        }
                    }
                }

            }

        }

        /// <summary>
        /// Validación para el tratamiento cuando se presiona la tecla
        /// Esc y cuando se oprime enter
        /// </summary>
        private void BackEnterUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            string dk = string.Empty;
            if (e.KeyData == Keys.Escape)
            {
                if (!ucEndReservation.isFlowHotel)
                {
                   
                    dk = ucFirstValidations.DK;
                    dk = dk.Substring(3, 3);

                    if (dk == Resources.TicketEmission.ValitationLabels.NUMBER_990)
                    {
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCBILLINGADRESS);
                    }
                    else
                    {
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                }
                else
                {
                    dk = ucQCHotels.DK;
                    dk = dk.Substring(3, 3);
                    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                }
            }

            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }

        }

        #region===== MethodsClass =====


        /// <summary>
        /// reinicializa el proceso de buscar remarks contables
        /// </summary>
        private void bucleFindEndScroll()
        {
            sendScrollCommand();
            if (!searchEndScroll())
            {
                bucleFindEndScroll();
            }

        }

        /// <summary>
        /// Manda el comando para verificar si el record contiene mas remarks contables
        /// </summary>
        private void sendScrollCommand()
        {
            string send = string.Empty;
            send = string.Empty;
            sabreAnswer = string.Empty;
            send = Resources.TicketEmission.Constants.COMMANDS_MD;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
        }


        /// <summary>
        /// Valida el fin del despliegue de remarks contables en MySabre
        /// </summary>
        /// <returns></returns>
        private bool searchEndScroll()
        {
            int row = 0;
            int col = 0;
            bool endScroll = false;
            row = 0;
            col = 0;
            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.SCROLL_CROSS_LORAINE, ref row, ref col);
            if (row != 0 && col >= 0)
            {
                endScroll = true;
            }
            else
            {
                sabreconcat = string.Concat(sabreconcat,
                    "\n",
                    sabreAnswer,
                    "?");
                endScroll = false;
            }
            return endScroll;
        }

        /// <summary>
        /// Activación  o desactivación de las cajas de texto para la 
        /// selección de pasajeros
        /// </summary>
        private void showControls(bool value)
        {
            txtName1.Visible = value;
            txtName2.Visible = value;
            txtName3.Visible = value;
            txtName4.Visible = value;
            lbl10.Visible = value;
            lbl8.Visible = value;
            lbl9.Visible = value;
            lblNumberPassanger.Visible = value;
        }

        /// <summary>
        /// Muestra los controles de Descripción larga 
        /// solo para Attributos diferentes de 990
        /// </summary>
        /// <param name="show">pide un valor boleano</param>
        private void showDescription(bool show)
        {
         lblDescription.Visible = show;
         txtDescription1.Visible = show;
         txtDescription2.Visible = show;
        }

        /// <summary>
        /// Método para la obtención del número de pasajeros
        /// en el record
        /// </summary>
        private void commandSend()
        {
            sabreAnswer = string.Empty;
            string searchPax = Resources.TicketEmission.Constants.COMMANDS_TN;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(searchPax);
            }
            sabreconcat = string.Concat(sabreAnswer,
                "?");

        }

        /// <summary>
        /// Calcula el número de pasajeros en el record
        /// </summary>
        private void passengerNumbers()
        {
            string passenger = string.Empty;
            string infant = string.Empty;
            int row = 0;
            int col = 0;
            bool findPaxNumber = false;
            sabreconcat = sabreconcat.Replace("‡", "\n");
            string[] answerBlock = sabreconcat.Split(new char[] { '?' });
            foreach (string sabreResult in answerBlock)
            {
                if (!string.IsNullOrEmpty(sabreResult))
                {
                    if (!findPaxNumber)
                    {
                        CommandsQik.searchResponse(sabreResult, Resources.TicketEmission.ValitationLabels.NBR_IN_PARTY, ref row, ref col);
                        if (row != 0 || col != 0)
                        {
                            findPaxNumber = true;
                            CommandsQik.CopyResponse(sabreResult, ref passenger, row, 15, 20);
                            passenger = passenger.Trim();
                        }
                    }
                    row = 0;
                    col = 0;

                    CommandsQik.searchResponse(sabreResult, Resources.TicketEmission.ValitationLabels.PLUS_INFANTS, ref row, ref col);
                    if (row != 0 || col != 0)
                    {
                        CommandsQik.CopyResponse(sabreResult, ref infant, row, 15, 20);
                        infant = infant.Trim();
                        break;
                    }
                    else
                    {
                        infant = Resources.TicketEmission.Constants.COMMANDS_ZERO;
                    }
                }

            }
            pax = Convert.ToInt32(infant) + Convert.ToInt32(passenger);

        }

        /// <summary>
        /// Evalua las reglas del negocio aplicadas para este user control
        /// (evitando invocación de metodos sin envio de parametros)
        /// </summary>
        private bool isValidBussinesRules()
        {
            isValid = false;
            if ((string.IsNullOrEmpty(txtName1.Text)) &&
            (string.IsNullOrEmpty(txtName2.Text)) &&
            (string.IsNullOrEmpty(txtName3.Text)) &&
            (string.IsNullOrEmpty(txtName4.Text)))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.ING_AL_MENOS_UN_NOMBRE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName1.Focus();
            }
            else if (((string.IsNullOrEmpty(txtName1.Text)) &&
            ((!string.IsNullOrEmpty(txtName2.Text)) ||
            (!string.IsNullOrEmpty(txtName3.Text)) ||
            (!string.IsNullOrEmpty(txtName4.Text)))))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_ING_PRIMER_NOMBRE_PARA_ING_OTRO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName1.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtName1.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtName1.Text))))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.FORMATO_POSICION_NOMBRE_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName1.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtName2.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtName2.Text))))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.FORMATO_POSICION_NOMBRE_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName2.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtName3.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtName3.Text))))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.FORMATO_POSICION_NOMBRE_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName3.Focus();
            }
            else if ((!string.IsNullOrEmpty(txtName4.Text) && (!ValidateRegularExpression.ValidateOneorTwoPlusDecimalNumber(txtName4.Text))))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.FORMATO_POSICION_NOMBRE_INCORRECTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName4.Focus();
            }
            else
            {
                isValid = true;
            }
            return isValid;
        }

        /// <summary>
        /// Método para calcular el número de pasajeros a los 
        /// que se les debe aplicar los Qualities Controls, siempre 
        /// y cuando existan en el record
        /// </summary>
        private bool calculatePassengers()
        {
            bool validPaxNumber = false;
            bool isValidSegments = false;
            string passenger = string.Empty;
            string infant = string.Empty;
            int row = 0;
            int col = 0;
            foreach (string paxNumber in arraypassengers)
            {
                sabreconcat = sabreconcat.Replace("‡", "\n");
                string[] answerBlock = sabreconcat.Split(new char[] { '?' });
                foreach (string sabreResult in answerBlock)
                {
                    if (!string.IsNullOrEmpty(sabreResult))
                    {
                        if (!string.IsNullOrEmpty(paxNumber))
                        {
                            col = 0;
                            row = 0;
                            validPaxNumber = false;
                            string passengerInFormat = string.Empty;
                            int index = paxNumber.IndexOf(".");
                            passengerInFormat = paxNumber.Insert(index + 1, " ");
                            CommandsQik.searchResponse(sabreResult, passengerInFormat, ref row, ref col);
                            if (row > 0)
                            {
                                validPaxNumber = true;
                                pax++;
                                break;

                            }
                        }
                    }
                }
                if (!validPaxNumber)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NUMERO_PAX_NO_VALIDOS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName1.Focus();
                    isValidSegments = true;
                    break;
                }
            }
            return isValidSegments;
        }

        /// <summary>
        /// Método que construye la cadena para evaluar los segmentos solicitados
        /// por el usuario
        /// </summary>
        private void buildString()
        {
            if (isValid == true)
            {
                total = 0;
                passengers = string.Empty;
                arraypassengers = null;
                if (!string.IsNullOrEmpty(txtName1.Text) && string.IsNullOrEmpty(txtName2.Text))
                {
                    total = 1;
                    numberone = txtName1.Text;
                    numberone = numberone.Substring(0, 2);
                    numberone = numberone.Trim(new char[] { '.' });
                    passengers = numberone;
                    passengers = string.Concat(passengers,
                        ".1",
                        "+");
                    numberone = txtName1.Text;
                }
                if (!string.IsNullOrEmpty(txtName1.Text) && !string.IsNullOrEmpty(txtName2.Text))
                {
                    numberone = txtName1.Text;
                    numbertwo = txtName2.Text;
                    numberone = numberone.Substring(0, 2);
                    numbertwo = numbertwo.Substring(0, 2);
                    numberone = numberone.Trim(new char[] { '.' });
                    numbertwo = numbertwo.Trim(new char[] { '.' });
                    max = Convert.ToInt32(numbertwo);
                    min = Convert.ToInt32(numberone);
                    if (max < min)
                    {
                        int aux = max;
                        max = min;
                        min = aux;
                    }
                    total = (max - min) + 1;
                    for (int i = min; i <= max; i++)
                    {
                        passengers = string.Concat(passengers,
                            i,
                            ".1",
                            "+");
                    }
                    numberone = txtName1.Text;
                    numbertwo = txtName2.Text;
                }
                if (!string.IsNullOrEmpty(txtName3.Text))
                {
                    numberthree = txtName3.Text;
                    numberthree = numberthree.Substring(0, 2);
                    numberthree = numberthree.Trim(new char[] { '.' });
                    passengers = string.Concat(passengers,
                        numberthree,
                        ".1",
                        "+");
                    total = total + 1;
                    numberthree = txtName3.Text;
                }
                if (!string.IsNullOrEmpty(txtName4.Text))
                {
                    numberfour = txtName4.Text;
                    numberfour = numberfour.Substring(0, 2);
                    numberfour = numberfour.Trim(new char[] { '.' });
                    passengers = string.Concat(passengers,
                        numberfour,
                        ".1");
                    total = total + 1;
                    numberfour = txtName4.Text;
                }
                passengers = passengers.TrimEnd(new char[] { '+' });
                arraypassengers = passengers.Split(new char[] { '+' });
            }

        }

        /// <summary>
        /// Método para la evaluación de numeros repetidos en nuestra 
        /// cadena de pasajeros
        /// </summary>
        private bool deleteDuplicateValues()
        {
            int counter = 0;
            bool isDuplicate = false;
            string[] temp = passengers.Split(new char[] { '+' });
            foreach (string value in temp)
            {
                counter = 0;
                foreach (string duplicate in temp)
                {
                    if (value.Equals(duplicate))
                    {
                        counter++;
                    }
                }
                if (counter > 1)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.NUM_PAX_DUPLICADO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isDuplicate = true;
                    break;
                }

            }

            return isDuplicate;

        }

        private void CreditCardSelecType()
        {
            if (chkClient.Checked)
            {
                ucFormPayment.C28 = Resources.TicketEmission.ValitationLabels.CLIENT;

            }
            else if (chkCTS.Checked)
            {
                ucFormPayment.C28 = Resources.TicketEmission.ValitationLabels.CTS;
            }
           
        }


        private void LoadCreditCardTypeOption()
        {
            if (!ucMenuReservations.qualityControls)
            {
                pnlCreditCardType.Enabled = false;
                pnlCreditCardType.Visible = false;
                ucMenuReservations.qualityControls = false;
            }
            else
            {
                pnlCreditCardType.Enabled = true;
                pnlCreditCardType.Visible = true;
                //ucMenuReservations.qualityControls = false;
            }
        }

        #endregion

        #region=====CheckBox Checked Changed=====

        private void CreditCardType_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control chk in pnlCreditCardType.Controls)
            {
                if (chk is CheckBox)
                {
                    if (((CheckBox)(sender)).Checked.Equals(true))
                    {
                        if (!chk.Name.Equals(((CheckBox)(sender)).Name))
                            ((CheckBox)(chk)).Checked = false;
                    }
                }
            }
        }

        #endregion//End CheckBox Checked Changed

        public static bool ReturnForMisc = false;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                ReturnForMisc = false;
                //Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCBILLINGADRESS);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
