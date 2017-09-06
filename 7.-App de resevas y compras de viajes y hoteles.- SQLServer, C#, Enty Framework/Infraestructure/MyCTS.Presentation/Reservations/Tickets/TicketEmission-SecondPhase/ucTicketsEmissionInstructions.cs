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
    public partial class ucTicketsEmissionInstructions : CustomUserControl
    {
        /// <summary>
        /// Descripción: User Control que permite ingresar los parametros para la
        ///              emision del boleto y guarda los valores para despues ser enviados
        ///              Pertenece al flujo de emisión de boleto de la aplicación.
        /// Creación:    Mayo - Junio 09, Modificación: 24-junio-10
        /// Cambio:      Aumentar XC  Solicito: Guillermo Granados
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 
        private static string tickettype;
        public static string ticketType
        {
            get { return tickettype; }
            set { tickettype = value; }
        }

        private static string phaseivnumber;
        public static string phaseIVNumber
        {
            get { return phaseivnumber; }
            set { phaseivnumber = value; }
        }

        private static string airline;
        public static string Airline
        {
            get { return airline; }
            set { airline = value; }
        }

        private static string airlinename;
        public static string AirlineName
        {
            get { return airlinename; }
            set { airlinename = value; }
        }

        private static string commission;
        public static string Commission
        {
            get { return commission; }
            set { commission = value; }
        }

        private static string waypayment;
        public static string wayPayment
        {
            get { return waypayment; }
            set { waypayment = value; }
        }

        private static string quanegociated;
        public static string quaNegociated
        {
            get { return quanegociated; }
            set { quanegociated = value; }
        }

        private static string corporateid;
        public static string corporateID
        {
            get { return corporateid; }
            set { corporateid = value; }
        }

        private static string accountcode;
        public static string accountCode
        {
            get { return accountcode; }
            set { accountcode = value; }
        }

        private static string tourcode;
        public static string tourCode
        {
            get { return tourcode; }
            set { tourcode = value; }
        }

        private static string tourcodeagreements;
        public static string tourCodeAgreements
        {
            get { return tourcodeagreements; }
            set { tourcodeagreements = value; }
        }

        private static string endorsement;
        public static string Endorsement
        {
            get { return endorsement; }
            set { endorsement = value; }
        }

        private static string endorsementtext;
        public static string EndorsementText
        {
            get { return endorsementtext; }
            set { endorsementtext = value; }
        }

        private static string bynames;
        public static string byNames
        {
            get { return bynames; }
            set { bynames = value; }
        }

        private static string bysegments;
        public static string bySegments
        {
            get { return bysegments; }
            set { bysegments = value; }
        }

        private static string quarreltype;
        public static string quarrelType
        {
            get { return quarreltype; }
            set { quarreltype = value; }
        }

        private static string printitinerary;
        public static string printItinerary
        {
            get { return printitinerary; }
            set { printitinerary = value; }
        }

        private static bool avoidmorelowfare;
        public static bool avoidMoreLowFare
        {
            get { return avoidmorelowfare; }
            set { avoidmorelowfare = value; }
        }

        private static bool showuctaxes;
        public static bool showUcTaxes
        {
            get { return showuctaxes; }
            set { showuctaxes = value; }
        }

        private static string faretype;
        public static string fareType
        {
            get { return faretype; }
            set { faretype = value; }
        }


        private static string osi;
        public static string OSI
        {
            get { return osi; }
            set { osi = value; }
        }

        private static string xc;
        public static string XC
        {
            get { return xc; }
            set { xc = value; }
        }

        private static AuthCode codeAuth;
        public static AuthCode CodeAuth
        {
            get { return codeAuth; }
            set { codeAuth = value; }
        }

        private static AirLineFare airlinefare;
        public static AirLineFare Airlinefare
        {
            get { return airlinefare; }
            set { airlinefare = value; }
        }

        
        private static string baseFare;
        private static string total;
        public static bool WithCharge = false;
        public static bool WithoutCharge = false;
        public static bool cash;

        private bool isValid;
        private bool statusParamReceived;
        private bool statusValidAirline;
        private TextBox txt;
        public static bool xrCommand = false;

        public ucTicketsEmissionInstructions()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = rdoNormalTicket;
            this.LastControlFocus = btnAccept;
        }

        //ucTicketsEmissionInstructions load
        private void ucTicketsEmissionInstructions_Load(object sender, EventArgs e)
        {
            //pictureBox1.Visible = false;
            txtAirLine.Enabled = true;
            ucAvailability.IsInterJetProcess = false;
            total = string.Empty;
            baseFare = string.Empty;
            WithCharge = false;
            WithoutCharge = false;
            tickettype = string.Empty;
            phaseivnumber = string.Empty;
            airline = string.Empty;
            airlinename = string.Empty;
            commission = string.Empty;
            waypayment = string.Empty;
            quanegociated = string.Empty;
            corporateid = string.Empty;
            accountcode = string.Empty;
            tourcode = string.Empty;
            tourcodeagreements = string.Empty;
            endorsement = string.Empty;
            endorsementtext = string.Empty;
            bynames = string.Empty;
            bysegments = string.Empty;
            quarreltype = string.Empty;
            printitinerary = string.Empty;
            avoidmorelowfare = false;
            showuctaxes = false;
            faretype = string.Empty;
            osi = string.Empty;
            xc = string.Empty;
            AuthCode codeAuth = null;
            AirLineFare airlinefare = null;
            ucFormPayment.CommandGetAuthorizationCode = string.Empty;
            
            faretype = string.Empty;
            LoadInitialStatements();
            HideListboxControls();
            Previousvalues();
            ValidateConsolid();
            AssignPaxNumberValues();
            GetRemarkCSC();
            //else if (!string.IsNullOrEmpty(CodeAuth.PNR))
            //{
            //    foreach (Control ctrl in this.tblLayoutPaymentWay.Controls)
            //    {
            //        if (!ctrl.Name.Equals("rdoMixPayment"))
            //        {
            //            ctrl.Enabled = false;
            //        }
            //        else
            //            ctrl.Select();
            //    }
            //}
            ucPhase35375Tickets.segment = string.Empty;            
            chkCommandXR.Checked = xrCommand;
        }

        //btnAccept_Click event
        private void btnAccept_Click(object sender, EventArgs e)
        {
            ucCalculateServiceCharge.Clean();
            airline = string.Empty;
            airlinefare = AirLineFareBL.GetOneAirLineFare(txtAirLine.Text);
            List<ListItem> airLinesList = CatPAirlinesFareBL.GetAirLinesFare(txtAirLine.Text);
            if (airLinesList.Count.Equals(0))
            {
                statusValidAirline = true;
            }
            else
            {
                statusValidAirline = false;
            }
            if (!IsValidBusinessRules)
            {
                PreviousCommand();
                LoadParametersValues();
            }
            
        }

        #region===== MethodsClass =====

        /// <summary>
        ///  Establecimiento de valores iniciales de los controles
        /// </summary>
        private void LoadInitialStatements()
        {
            rdoNormalTicket.Checked = true;
            rdoNormalTicket.Focus();
            rdoAmericanExpress.Checked = true;
            chkQuaNegociated.Checked = true;
            chkCorporateID.Checked = true;
            chkAccountCode.Checked = true;
            chkTourCode.Checked = true;
            chkMarks.Checked = true;
            chkByNames.Checked = true;
            chkBySegments.Checked = true;
            chkQuaNegociated.Checked = false;
            chkCorporateID.Checked = false;
            chkAccountCode.Checked = false;
            chkXC.Checked = false;
            chkTourCode.Checked = false;
            chkMarks.Checked = false;
            chkByNames.Checked = false;
            chkBySegments.Checked = false;
            if (ucPresentRecord.Phase_IV.Equals(true))
            {
                rdoPhaseIV.Checked = true;
            }
        }

        /// <summary>
        ///  Esconde el listbox de aereolínea
        /// </summary>
        private void HideListboxControls()
        {
            lbAirlines.BringToFront();
            lbAirlines.Visible = false;
        }

        /// <summary>
        ///  Asigna valores previamente ingresados por el usuario
        /// </summary>
        private void Previousvalues()
        {
            if (userControlsPreviousValues.TicketsEmissionInstructionsParameters != null)
            {
                statusParamReceived = true;
                rdoNormalTicket.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[0].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                rdoPhase35375.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[1].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                rdoPhaseIV.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[2].ToUpper().ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                txtPhaseIVNumber.Text = userControlsPreviousValues.TicketsEmissionInstructionsParameters[3];
                chkWithCharge.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[40].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                chkWithoutCharge.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[41].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                if (chkWithCharge.Checked)
                {
                    WithCharge = true;
                    WithoutCharge = false;
                }
                if (chkWithoutCharge.Checked)
                {
                    WithoutCharge = true;
                    WithCharge = false;
                }
                txtAirLine.Text = userControlsPreviousValues.TicketsEmissionInstructionsParameters[4];
                txtCommissionPercentage.Text = userControlsPreviousValues.TicketsEmissionInstructionsParameters[5];
                rdoAmericanExpress.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[6].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                rdoCreditCard.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[7].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                rdoCash.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[8].ToUpper().ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                rdoMixPayment.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[9].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                rdoMiscelaneous.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[10].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                chkQuaNegociated.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[11].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                txtQuaNegociated.Text = userControlsPreviousValues.TicketsEmissionInstructionsParameters[12];
                chkAvoidMoreLowFare.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[13].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                chkCorporateID.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[14].ToUpper().ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                txtCorporateId.Text = userControlsPreviousValues.TicketsEmissionInstructionsParameters[15];
                chkAccountCode.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[16].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                chkXC.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[39].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                chkTourCode.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[17].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                txtTourCode.Text = userControlsPreviousValues.TicketsEmissionInstructionsParameters[18];
                chkMarks.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[20].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                rdoAdd.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[21].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                rdoRewrite.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[22].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                txtMarks.Text = userControlsPreviousValues.TicketsEmissionInstructionsParameters[23];
                chkByNames.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[24].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                txtName1.Text = userControlsPreviousValues.TicketsEmissionInstructionsParameters[25];
                txtName2.Text = userControlsPreviousValues.TicketsEmissionInstructionsParameters[26];
                txtName3.Text = userControlsPreviousValues.TicketsEmissionInstructionsParameters[27];
                txtName4.Text = userControlsPreviousValues.TicketsEmissionInstructionsParameters[28];
                chkBySegments.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[29].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                txtSegment1.Text = userControlsPreviousValues.TicketsEmissionInstructionsParameters[30];
                txtSegment2.Text = userControlsPreviousValues.TicketsEmissionInstructionsParameters[31];
                txtSegment3.Text = userControlsPreviousValues.TicketsEmissionInstructionsParameters[32];
                txtSegment4.Text = userControlsPreviousValues.TicketsEmissionInstructionsParameters[33];
                txtSegment5.Text = userControlsPreviousValues.TicketsEmissionInstructionsParameters[34];
                txtSegment6.Text = userControlsPreviousValues.TicketsEmissionInstructionsParameters[35];
                chkTaxes.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[36].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                //chkPrintItinerary.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[37].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                chkPublic.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[37].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                chkPrivate.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[38].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                //chkPrivate.Checked = (userControlsPreviousValues.TicketsEmissionInstructionsParameters[39].ToUpper().Equals(Resources.TicketEmission.Constants.TRUE));
                cmbClientAgreement.SelectedIndex = Convert.ToInt32(userControlsPreviousValues.TicketsEmissionInstructionsParameters[19]);
                userControlsPreviousValues.TicketsEmissionInstructionsParameters = null;
                statusParamReceived = false;
            }

        }

        /// <summary>
        /// Borra las lineas contables para segmentos
        /// </summary>
        private void PreviousCommand()
        {
            if (chkBySegments.Checked)
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
        }

        /// <summary>
        ///  Carga de parametros en variables para el armado
        /// del comando de emision de boleto en variables estaticas 
        /// y continuacion de flujo
        /// </summary>
        private void LoadParametersValues()
        {
            string name1 = string.Empty;
            string name2 = string.Empty;
            string name3 = string.Empty;
            string name4 = string.Empty;
            string segment1 = string.Empty;
            string segment2 = string.Empty;
            string segment3 = string.Empty;
            string segment4 = string.Empty;
            string segment5 = string.Empty;
            string segment6 = string.Empty;

            if (rdoNormalTicket.Checked)
            {
                tickettype = rdoNormalTicket.Name;
            }
            else if (rdoPhase35375.Checked)
            {
                tickettype = rdoPhase35375.Name;
            }
            else if (rdoPhaseIV.Checked)
            {
                tickettype = rdoPhaseIV.Name;
                phaseIVNumber = txtPhaseIVNumber.Text;
            }

            if (!string.IsNullOrEmpty(txtAirLine.Text))
            {
                airline = string.Empty;
                airline = txtAirLine.Text;
                List<ListItem> airLinesList = CatPAirlinesFareBL.GetAirLinesFare(txtAirLine.Text);
                airlinename = airLinesList[0].Value;//airLinesList[0].CatAirLinFarName;

            }
            else
            {
                airline = string.Empty;
            }

            if (!string.IsNullOrEmpty(txtCommissionPercentage.Text))
            {
                commission = string.Concat(Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_KP,
                    txtCommissionPercentage.Text);
            }
            else
            {
                commission = string.Empty;
            }

            if (rdoAmericanExpress.Checked)
            {
                waypayment = rdoAmericanExpress.Name;
            }
            else if (rdoCreditCard.Checked)
            {
                waypayment = rdoCreditCard.Name;
            }
            else if (rdoMixPayment.Checked)
            {
                waypayment = rdoMixPayment.Name;
            }
            else if (rdoMiscelaneous.Checked)
            {
                waypayment = rdoMiscelaneous.Name;
            }
            else
            {
                waypayment = rdoCash.Name;
            }

            if ((chkQuaNegociated.Checked) &&
                (!string.IsNullOrEmpty(txtQuaNegociated.Text)))
            {
                quanegociated = txtQuaNegociated.Text;
            }
            else
            {
                quanegociated = string.Empty;
            }

            if ((chkQuaNegociated.Checked) &&
                (chkAvoidMoreLowFare.Checked))
            {
                avoidmorelowfare = true;
            }
            else
            {
                avoidmorelowfare = false;
            }

            if ((chkCorporateID.Checked) &&
                (!string.IsNullOrEmpty(txtCorporateId.Text)))
            {
                corporateid = txtCorporateId.Text;
                if (chkXC.Checked)
                    xc = "¥XC";
            }
            else
            {
                corporateid = string.Empty;
                if (string.IsNullOrEmpty(xc))
                    xc = string.Empty;
            }

            if ((chkAccountCode.Checked) &&
                (!string.IsNullOrEmpty(txtAccountCode.Text)))
            {
                accountcode = txtAccountCode.Text;
                if (chkXC.Checked)
                    xc = "¥XC";
            }
            else
            {
                accountcode = string.Empty;
                if (string.IsNullOrEmpty(xc))
                    xc = string.Empty;
            }

            if ((chkTourCode.Checked) &&
                (!string.IsNullOrEmpty(txtTourCode.Text)))
            {
                tourcode = txtTourCode.Text;
            }
            else
            {
                tourcode = string.Empty;
            }

            if ((chkTourCode.Checked) &&
                (!string.IsNullOrEmpty(cmbClientAgreement.Text)))
            {
                char[] sep1 = { '-' };
                string[] arr1 = cmbClientAgreement.Text.Split(sep1);
                tourcodeagreements = arr1[0].Trim();
            }
            else
            {
                tourcodeagreements = string.Empty;
            }

            if ((chkMarks.Checked) &&
                (rdoAdd.Checked))
            {
                endorsement = rdoAdd.Name;
            }
            else if ((chkMarks.Checked) &&
                (rdoRewrite.Checked))
            {
                endorsement = rdoRewrite.Name;
            }
            else
            {
                endorsement = string.Empty;
            }

            if ((chkMarks.Checked) &&
                (!string.IsNullOrEmpty(txtMarks.Text)))
            {
                endorsementtext = txtMarks.Text;
            }
            else
            {
                endorsementtext = string.Empty;
            }


            if (!string.IsNullOrEmpty(txtName2.Text))
            {
                name2 = string.Concat(Resources.Constants.INDENT,
                    txtName2.Text);
            }
            else
            {
                name2 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtName3.Text))
            {
                name3 = string.Concat(Resources.Constants.SLASH,
                    txtName3.Text);
            }
            else
            {
                name3 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtName4.Text))
            {
                name4 = string.Concat(Resources.Constants.SLASH,
                    txtName4.Text);
            }
            else
            {
                name4 = string.Empty;
            }
            name1 = txtName1.Text;
            if (!rdoPhaseIV.Checked)
            {
                bynames = string.Concat(Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_N,
                name1,
                name2,
                name3,
                name4);
            }
            else
            {
                bynames = string.Concat(Resources.TicketEmission.Constants.COMMANDS_N,
                name1,
                name2,
                name3,
                name4);
            }
            if (!chkByNames.Checked)
            {
                bynames = string.Empty;
            }

            if (!string.IsNullOrEmpty(txtSegment2.Text))
            {
                segment2 = string.Concat(Resources.Constants.INDENT,
                    txtSegment2.Text);
            }
            else
            {
                segment2 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtSegment3.Text))
            {
                segment3 = string.Concat(Resources.Constants.SLASH,
                    txtSegment3.Text);
            }
            else
            {
                segment3 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtSegment4.Text))
            {
                segment4 = string.Concat(Resources.Constants.SLASH,
                    txtSegment4.Text);
            }
            else
            {
                segment4 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtSegment5.Text))
            {
                segment5 = string.Concat(Resources.Constants.SLASH,
                    txtSegment5.Text);
            }
            else
            {
                segment5 = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtSegment6.Text))
            {
                segment6 = string.Concat(Resources.Constants.SLASH,
                    txtSegment6.Text);
            }
            else
            {
                segment6 = string.Empty;
            }
            segment1 = txtSegment1.Text;
            bySegments = string.Concat(Resources.Constants.COMMANDS_CROSSLORAINE_S,
            segment1,
            segment2,
            segment3,
            segment4,
            segment5,
            segment6);
            if (!chkBySegments.Checked)
            {
                bysegments = string.Empty;
            }

            if (chkTaxes.Checked)
            {
                showuctaxes = true;
            }
            else
            {
                showuctaxes = false;
            }


            //if (chkPrintItinerary.Checked)
            //{
            //    printitinerary = Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_DPB;
            //}
            //else
            //{
            //    printitinerary = Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_DPE;
            //}

            printitinerary = Resources.TicketEmission.Constants.COMMANDS_CROSSLORAINE_DPB;

            if (chkPublic.Checked)
            {
                quarreltype = Resources.Constants.COMMANDS_CROSSLORAINE_PL;
            }
            else if (chkPrivate.Checked)
            {
                quarreltype = Resources.Constants.COMMANDS_CROSSLORAINE_PV;
            }
            else if ((!chkPublic.Checked) &&
            (!chkPrivate.Checked))
            {
                quarreltype = string.Empty;
            }
            //string[] sendInfo = new string[] {rdoNormalTicket.Checked.ToString(), rdoPhase35375.Checked.ToString(),
            //    rdoPhaseIV.Checked.ToString(), txtPhaseIVNumber.Text, txtAirLine.Text, txtCommissionPercentage.Text, rdoAmericanExpress.Checked.ToString(),
            //    rdoCreditCard.Checked.ToString(), rdoCash.Checked.ToString(), rdoMixPayment.Checked.ToString(), rdoMiscelaneous.Checked.ToString(), 
            //    chkQuaNegociated.Checked.ToString(), txtQuaNegociated.Text, chkAvoidMoreLowFare.Checked.ToString(), chkCorporateID.Checked.ToString(),
            //    txtCorporateId.Text, chkAccountCode.Checked.ToString(), chkTourCode.Checked.ToString(),txtTourCode.Text, cmbClientAgreement.SelectedIndex.ToString(),
            //    chkMarks.Checked.ToString(), rdoAdd.Checked.ToString(), rdoRewrite.Checked.ToString(), txtMarks.Text, chkByNames.Checked.ToString(),
            //    txtName1.Text, txtName2.Text, txtName3.Text, txtName4.Text, chkBySegments.Checked.ToString(), txtSegment1.Text, txtSegment2.Text, txtSegment3.Text,
            //    txtSegment4.Text, txtSegment5.Text, txtSegment6.Text, chkTaxes.Checked.ToString(), chkPrintItinerary.Checked.ToString(), chkPublic.Checked.ToString(),
            //    chkPrivate.Checked.ToString(),chkXC.Checked.ToString(),chkWithCharge.Checked.ToString(),chkWithoutCharge.Checked.ToString()};

            string[] sendInfo = new string[] {rdoNormalTicket.Checked.ToString(), rdoPhase35375.Checked.ToString(),
                rdoPhaseIV.Checked.ToString(), txtPhaseIVNumber.Text, txtAirLine.Text, txtCommissionPercentage.Text, rdoAmericanExpress.Checked.ToString(),
                rdoCreditCard.Checked.ToString(), rdoCash.Checked.ToString(), rdoMixPayment.Checked.ToString(), rdoMiscelaneous.Checked.ToString(), 
                chkQuaNegociated.Checked.ToString(), txtQuaNegociated.Text, chkAvoidMoreLowFare.Checked.ToString(), chkCorporateID.Checked.ToString(),
                txtCorporateId.Text, chkAccountCode.Checked.ToString(), chkTourCode.Checked.ToString(),txtTourCode.Text, cmbClientAgreement.SelectedIndex.ToString(),
                chkMarks.Checked.ToString(), rdoAdd.Checked.ToString(), rdoRewrite.Checked.ToString(), txtMarks.Text, chkByNames.Checked.ToString(),
                txtName1.Text, txtName2.Text, txtName3.Text, txtName4.Text, chkBySegments.Checked.ToString(), txtSegment1.Text, txtSegment2.Text, txtSegment3.Text,
                txtSegment4.Text, txtSegment5.Text, txtSegment6.Text, chkTaxes.Checked.ToString(),  chkPublic.Checked.ToString(),
                chkPrivate.Checked.ToString(),chkXC.Checked.ToString(),chkWithCharge.Checked.ToString(),chkWithoutCharge.Checked.ToString()};
            userControlsPreviousValues.TicketsEmissionInstructionsParameters = sendInfo;

            if (chkQuaNegociated.Checked)
                faretype = quanegociated;
            else if (chkCorporateID.Checked)
                faretype = corporateid;
            else if (chkAccountCode.Checked)
                faretype = accountcode;   

            xrCommand = chkCommandXR.Checked;

            if (chkWithCharge.Checked || chkWithoutCharge.Checked)
            {
                cash = false;

                if (rdoCash.Checked || chkWithoutCharge.Checked)
                {
                    if (!string.IsNullOrEmpty(ucFormPayment.FormPayment))
                        ucFormPayment.FormPayment = string.Empty;
                    cash = true;
                }

                Loader.AddToPanel(Loader.Zone.Middle, this, "ucRevisedCharge");
            }
            else if (rdoCash.Checked)
            {
                if (!string.IsNullOrEmpty(ucFormPayment.FormPayment))
                {
                    ucFormPayment.FormPayment = string.Empty;
                }
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCPHASE_35375_TICKETS);

            }
            else if (!rdoCash.Checked && ucTicketsEmissionInstructions.ticketType.Equals("rdoPhase35375"))
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCPHASE_35375_TICKETS);
            }
            else if (showuctaxes)
            {
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCTAXES);
            }
            else
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UCFORMPAYMENT);

        }

        /// <summary>
        ///  Reglas de negocio aplicables a esta mascarilla
        /// </summary>
        /// <returns></returns>
        private bool IsValidBusinessRules
        {
            get
            {
                string messageToSend = string.Empty;
                isValid = true;
                if ((rdoPhaseIV.Checked) &&
                    (string.IsNullOrEmpty(txtPhaseIVNumber.Text)))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_INGRESAR_NUM_FASE_IV, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhaseIVNumber.Focus();
                }
                else if ((rdoPhaseIV.Checked) &&
                (!chkByNames.Checked))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.FASEIV_NECESITA_OPCION_POR_NOMBRES, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkByNames.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtAirLine.Text)) &&
                    (!txtAirLine.Text.Length.Equals(2)))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.COD_AEREOLINEA_DEBE_SER_DOS_CARAC, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirLine.Focus();
                }
                else if (string.IsNullOrEmpty(txtAirLine.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_INGRESAR_COD_AEREOLINEA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirLine.Focus();
                }
                else if (statusValidAirline)
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.COD_AEROLINEA_NO_PERMITIDO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirLine.Focus();
                }
                else if (string.IsNullOrEmpty(txtCommissionPercentage.Text))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_INGRESAR_PORCANTAJE_COMISION, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAirLine.Focus();
                }
                else if ((chkQuaNegociated.Checked) &&
                    (string.IsNullOrEmpty(txtQuaNegociated.Text)))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.INGRESA_COD_TARIFA_NEGOCIADA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQuaNegociated.Focus();
                }
                else if ((chkCorporateID.Checked) &&
                    (string.IsNullOrEmpty(txtCorporateId.Text)))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.INGRESA_NUM_CORPORATE_ID, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCorporateId.Focus();
                }
                else if ((!string.IsNullOrEmpty(txtCorporateId.Text) && (!ValidateRegularExpression.ValidateCorporateIdFormat(txtCorporateId.Text))))
                {
                    messageToSend = string.Format(Resources.TicketEmission.Tickets.FORMATO_CORPORATE_ID_NO_ES_CORRECTO, "\n");
                    MessageBox.Show(messageToSend, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCorporateId.Focus();
                }
                else if ((chkAccountCode.Checked) &&
                    (string.IsNullOrEmpty(txtAccountCode.Text)))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.INGRESA_NUM_ACCOUNT_CODE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAccountCode.Focus();
                }
                else if ((chkQuaNegociated.Checked) &&
                    ((chkCorporateID.Checked) || (chkAccountCode.Checked)))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.TARIFA_NEGOCIADA_CORPORATEID_O_ACCOUNT_CODE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkCorporateID.Checked = false;
                    chkAccountCode.Checked = false;
                    chkQuaNegociated.Focus();
                }
                else if ((chkCorporateID.Checked) &&
                    ((chkQuaNegociated.Checked) || (chkAccountCode.Checked)))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.TARIFA_NEGOCIADA_CORPORATEID_O_ACCOUNT_CODE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkQuaNegociated.Checked = false;
                    chkAccountCode.Checked = false;
                    chkCorporateID.Focus();
                }
                else if ((chkAccountCode.Checked) &&
                    ((chkQuaNegociated.Checked) || (chkCorporateID.Checked)))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.TARIFA_NEGOCIADA_CORPORATEID_O_ACCOUNT_CODE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkCorporateID.Checked = false;
                    chkQuaNegociated.Checked = false;
                    chkAccountCode.Focus();
                }
                else if ((chkTourCode.Checked) &&
               (string.IsNullOrEmpty(txtTourCode.Text)))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_INGRESAR_COD_IT, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTourCode.Focus();
                }
                else if ((chkTourCode.Checked) &&
               ((string.IsNullOrEmpty(cmbClientAgreement.Text))))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_INGRESAR_TIPO_IT, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbClientAgreement.Focus();
                }
                else if ((chkMarks.Checked) &&
                    (rdoAdd.Checked) &&
                    (string.IsNullOrEmpty(txtMarks.Text)))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_INGRESAR_DATOS_AGREGAR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMarks.Focus();
                }
                else if ((chkMarks.Checked) &&
               (rdoRewrite.Checked) &&
               (string.IsNullOrEmpty(txtMarks.Text)))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_INGRESAR_DATOS_SOBREESCRIBIR, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMarks.Focus();
                }
                else if ((chkBySegments.Checked) &&
               (string.IsNullOrEmpty(txtSegment1.Text)) &&
               (string.IsNullOrEmpty(txtSegment2.Text)) &&
               (string.IsNullOrEmpty(txtSegment3.Text)) &&
               (string.IsNullOrEmpty(txtSegment4.Text)) &&
               (string.IsNullOrEmpty(txtSegment5.Text)) &&
               (string.IsNullOrEmpty(txtSegment6.Text)))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.ING_AL_MENOS_UN_SEGMENTO, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment1.Focus();
                }
                else if ((chkBySegments.Checked) &&
               (string.IsNullOrEmpty(txtSegment1.Text)) &&
               ((!string.IsNullOrEmpty(txtSegment2.Text)) ||
               (!string.IsNullOrEmpty(txtSegment3.Text)) ||
               (!string.IsNullOrEmpty(txtSegment4.Text)) ||
               (!string.IsNullOrEmpty(txtSegment5.Text)) ||
               (!string.IsNullOrEmpty(txtSegment6.Text))))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.DEBES_ING_PRIMER_SEG_PARA_ING_OTROS, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSegment1.Focus();
                }
                else if ((chkByNames.Checked) &&
                (string.IsNullOrEmpty(txtName1.Text)) &&
                (string.IsNullOrEmpty(txtName2.Text)) &&
                (string.IsNullOrEmpty(txtName3.Text)) &&
                (string.IsNullOrEmpty(txtName4.Text)))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.ING_AL_MENOS_UN_NOMBRE, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName1.Focus();
                }
                else if ((chkByNames.Checked) &&
                (string.IsNullOrEmpty(txtName1.Text)) &&
                ((!string.IsNullOrEmpty(txtName2.Text)) ||
                (!string.IsNullOrEmpty(txtName3.Text)) ||
                (!string.IsNullOrEmpty(txtName4.Text))))
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
                else if ((chkPublic.Checked) && (chkPrivate.Checked))
                {
                    MessageBox.Show(Resources.TicketEmission.Tickets.INGRESA_TARIFA_PUBLICA_O_PRIVADA, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkPrivate.Checked = false;
                    chkPublic.Checked = false;
                    chkPublic.Focus();
                }
                else if (rdoCash.Checked && string.IsNullOrEmpty(ucFormPayment.C28))
                {
                    MessageBox.Show("Se debe indicar la forma de pago del cliente a CTS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmGenericFOPCTS frm = new frmGenericFOPCTS(0, string.Empty);
                    frm.Show();
                    frm.BringToFront();
                }
                //else if (rdoCash.Checked && !string.IsNullOrEmpty(ucFormPayment.C28) && !ucFormPayment.C28.EndsWith("CA"))
                //{
                //    MessageBox.Show("Se debe indicar la forma de pago del cliente a CTS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    frmGenericFOPCTS frm = new frmGenericFOPCTS(0, string.Empty);
                //    frm.Show();
                //    frm.BringToFront();
                //}
                else
                {
                    isValid = false;
                }

                return isValid;
            }
        }

        /// <summary>
        ///  Inhabilita y deshabilita ciertos controles cuando la opción
        /// "Normal" esta seelccionada
        /// </summary>
        private void rdoNormalTicketEnableDisableControls()
        {
            WithChargeDisableControls(true, true);
            txtPhaseIVNumber.Enabled = false;
            txtPhaseIVNumber.Text = string.Empty;
            txtPhaseIVNumber.BackColor = SystemColors.Control;
            chkQuaNegociated.Enabled = true;
            chkQuaNegociated.Checked = false;
            chkCorporateID.Enabled = true;
            chkCorporateID.Checked = false;
            chkAccountCode.Enabled = true;
            chkAccountCode.Checked = false;
            chkXC.Enabled = false;
            chkTaxes.Enabled = true;
            chkTaxes.Checked = false;
            if (!string.IsNullOrEmpty(txtName1.Text))
            {
                //chkByNames.Enabled = true;
                chkByNames.Select();
            }
            chkBySegments.Enabled = true;
            chkBySegments.Checked = false;
        }

        /// <summary>
        ///  Inhabilita y deshabilita ciertos controles cuando
        /// la opción "Fase 3.5 y 3.75" esta habilitada
        /// </summary>
        private void rdoPhase35375EnableDisableControls()
        {
            if (chkWithCharge.Checked)
                WithChargeDisableControls(false, true);
            else
                WithChargeDisableControls(true, true);

            txtPhaseIVNumber.Enabled = false;
            txtPhaseIVNumber.Text = string.Empty;
            txtPhaseIVNumber.BackColor = SystemColors.Control;
            //chkByNames.Checked = false;
            if (!string.IsNullOrEmpty(txtName1.Text))
            {
                //chkByNames.Enabled = true;
                chkByNames.Select();
            }

            chkBySegments.Checked = false;
            chkBySegments.Enabled = false;
            chkQuaNegociated.Enabled = true;
            chkQuaNegociated.Checked = false;
            chkCorporateID.Enabled = true;
            chkCorporateID.Checked = false;
            chkAccountCode.Enabled = true;
            chkAccountCode.Checked = false;
            chkXC.Enabled = false;
            chkTaxes.Enabled = true;
            chkTaxes.Checked = false;

        }

        /// <summary>
        ///  Inhabilita y deshabilita ciertos controles cuando
        /// la opción "Fase IV" esta habilitada
        /// </summary>
        private void rdoPhaseIVEnableDisableControls()
        {
            WithChargeDisableControls(true, true);
            chkQuaNegociated.Enabled = false;
            chkQuaNegociated.Checked = false;
            chkCorporateID.Enabled = false;
            chkCorporateID.Checked = false;
            chkAccountCode.Enabled = false;
            chkAccountCode.Checked = false;
            chkXC.Enabled = false;
            chkTaxes.Enabled = false;
            chkTaxes.Checked = false;
            txtPhaseIVNumber.Enabled = true;
            txtPhaseIVNumber.Text = string.Empty;
            txtPhaseIVNumber.BackColor = Color.White;
            if (!string.IsNullOrEmpty(txtName1.Text))
            {
                //chkByNames.Enabled = true;
                chkByNames.Select();
            }
            chkBySegments.Checked = false;
            chkBySegments.Enabled = true;
        }

        /// <summary>
        /// Activa y Desactiva los controles
        /// </summary>
        /// <param name="show">boleano que define activo/inactivo</param>
        /// <param name="show2">boleano que define activo/inactivo</param>
        private void WithChargeDisableControls(bool show, bool show2)
        {
            if (CodeAuth == null)
            {
                rdoMixPayment.Enabled = show;
                rdoMiscelaneous.Enabled = show;
                rdoCash.Enabled = show2;
                rdoAmericanExpress.Enabled = show2;
                rdoCreditCard.Enabled = show2;
            }
        }

        /// <summary>
        ///  Inhabilita y deshabilita ciertos controles cuando
        /// la opción "Tarifa negociada" esta habilitada
        /// </summary>
        private void chkQuaNegociatedEnableDisableControls()
        {
            bool statusQuaNegociated = chkQuaNegociated.Checked;
            txtQuaNegociated.Enabled = statusQuaNegociated;
            chkAvoidMoreLowFare.Enabled = statusQuaNegociated;

            if (statusQuaNegociated)
            {
                txtQuaNegociated.BackColor = Color.White;
                chkAvoidMoreLowFare.Enabled = true;
                chkAvoidMoreLowFare.Checked = false;
            }
            else
            {
                txtQuaNegociated.Text = string.Empty;
                txtQuaNegociated.BackColor = SystemColors.Control;
                chkAvoidMoreLowFare.Enabled = false;
                chkAvoidMoreLowFare.Checked = false;
            }

        }

        /// <summary>
        ///  Inhabilita y deshabilita ciertos controles cuando
        /// la opción "Corporate ID" esta habilitada
        /// </summary>
        private void chkCorporateIDEnableDisableControls()
        {
            bool statusCorporateID = chkCorporateID.Checked;
            txtCorporateId.Enabled = statusCorporateID;
            chkXC.Enabled = statusCorporateID;

            if (statusCorporateID)
            {
                txtCorporateId.BackColor = Color.White;
            }
            else
            {
                txtCorporateId.Text = string.Empty;
                txtCorporateId.BackColor = SystemColors.Control;
            }
        }

        /// <summary>
        ///  Inhabilita y deshabilita ciertos controles cuando
        /// la opción "Account Code" esta habilitada
        /// </summary>
        private void chkAccountCodeEnableDisableControls()
        {
            bool statusAccountCode = chkAccountCode.Checked;
            txtAccountCode.Enabled = statusAccountCode;
            chkXC.Enabled = statusAccountCode;

            if (statusAccountCode)
            {
                txtAccountCode.BackColor = Color.White;
            }
            else
            {
                txtAccountCode.Text = string.Empty;
                txtAccountCode.BackColor = SystemColors.Control;
            }
        }

        /// <summary>
        ///  Inhabilita y deshabilita ciertos controles cuando
        /// la opción "Tour Code" esta habilitada
        /// </summary>
        private void chkTourCodeEnableDisableControls()
        {
            bool statusTourCode = chkTourCode.Checked;
            txtTourCode.Enabled = statusTourCode;
            cmbClientAgreement.Enabled = statusTourCode;

            if (statusTourCode)
            {
                LoadDBInformation();
                txtTourCode.BackColor = Color.White;
            }
            else
            {
                txtTourCode.Text = string.Empty;
                txtTourCode.BackColor = SystemColors.Control;
                cmbClientAgreement.Items.Clear();

                List<CatITTourCodes> listITTourCodes = CatITTourCodesBL.GetITTourCodes();
                int len = listITTourCodes.Count;
                if (!len.Equals(0))
                {
                    for (int i = 0; i < len; i++)
                    {
                        ListItem li = new ListItem();
                        li.Text = string.Format("{0} - {1}",
                            listITTourCodes[i].CommandIT,
                            listITTourCodes[i].Description);
                        li.Value = listITTourCodes[i].CommandIT;
                        cmbClientAgreement.Items.Add(li);
                    }
                    lbAirlines.DisplayMember = Resources.Constants.TEXT;
                    lbAirlines.ValueMember = Resources.Constants.VALUE;
                    bool valueTourCode = chkTourCode.Checked;
                    txtTourCode.Enabled = statusTourCode;
                    cmbClientAgreement.Enabled = statusTourCode;

                    if (valueTourCode)
                    {
                        txtTourCode.BackColor = Color.White;
                    }
                    else
                    {
                        txtTourCode.Text = string.Empty;
                        txtTourCode.BackColor = SystemColors.Control;
                        cmbClientAgreement.Text = string.Empty;
                    }

                }
            }
        }

        /// <summary>
        ///  Inhabilita y deshabilita ciertos controles cuando
        /// la opción "Endosos" esta habilitada
        /// </summary>
        private void chkMarksEnableDisableControls()
        {
            bool statusMarks = chkMarks.Checked;
            rdoAdd.Enabled = statusMarks;
            rdoRewrite.Enabled = statusMarks;
            txtMarks.Enabled = statusMarks;


            if (statusMarks)
            {
                rdoAdd.Checked = true;
                txtMarks.BackColor = Color.White;
            }
            else
            {
                txtMarks.Text = string.Empty;
                txtMarks.BackColor = SystemColors.Control;
                rdoAdd.Checked = false;
                rdoRewrite.Checked = false;

            }
        }

        /// <summary>
        ///  Inhabilita y deshabilita ciertos controles cuando
        /// la opción "Por nombres" esta habilitada
        /// </summary>
        private void chkByNamesEnableDisableControls()
        {
            bool statusByNames = chkByNames.Checked;
            txtName1.Enabled = statusByNames;
            txtName2.Enabled = statusByNames;
            txtName3.Enabled = statusByNames;
            txtName4.Enabled = statusByNames;

            if (statusByNames)
            {
                txtName1.BackColor = Color.White;
                txtName2.BackColor = Color.White;
                txtName3.BackColor = Color.White;
                txtName4.BackColor = Color.White;
            }

            else if (string.IsNullOrEmpty(txtName1.Text))
            {
                txtName1.Text = string.Empty;
                txtName2.Text = string.Empty;
                txtName3.Text = string.Empty;
                txtName4.Text = string.Empty;
                txtName1.BackColor = SystemColors.Control;
                txtName2.BackColor = SystemColors.Control;
                txtName3.BackColor = SystemColors.Control;
                txtName4.BackColor = SystemColors.Control;
            }
        }

        /// <summary>
        ///  Inhabilita y deshabilita ciertos controles cuando
        /// la opción "Por segmentos" esta habilitada
        /// </summary>
        private void bySegmentsEnableDisableControls()
        {
            bool statusBySegments = chkBySegments.Checked;
            txtSegment1.Enabled = statusBySegments;
            txtSegment2.Enabled = statusBySegments;
            txtSegment3.Enabled = statusBySegments;
            txtSegment4.Enabled = statusBySegments;
            txtSegment5.Enabled = statusBySegments;
            txtSegment6.Enabled = statusBySegments;

            if (statusBySegments)
            {

                txtSegment1.BackColor = Color.White;
                txtSegment2.BackColor = Color.White;
                txtSegment3.BackColor = Color.White;
                txtSegment4.BackColor = Color.White;
                txtSegment5.BackColor = Color.White;
                txtSegment6.BackColor = Color.White;
            }
            else
            {
                txtSegment1.Text = string.Empty;
                txtSegment2.Text = string.Empty;
                txtSegment3.Text = string.Empty;
                txtSegment4.Text = string.Empty;
                txtSegment5.Text = string.Empty;
                txtSegment6.Text = string.Empty;
                txtSegment1.BackColor = SystemColors.Control;
                txtSegment2.BackColor = SystemColors.Control;
                txtSegment3.BackColor = SystemColors.Control;
                txtSegment4.BackColor = SystemColors.Control;
                txtSegment5.BackColor = SystemColors.Control;
                txtSegment6.BackColor = SystemColors.Control;
            }
        }

        /// <summary>
        ///  carga de valores de base da datos cuando el txtAirLine
        /// tiene un código de aereolínea válido
        /// </summary>
        private void LoadDBInformation()
        {
            cmbClientAgreement.Items.Clear();
            List<ComissionAgreements> ComissionAgreementList = ComissionAgreementsBL.GetComissionAgreements(ucFirstValidations.Attribute1, txtAirLine.Text, ucRatingActualFare.internationalFlight, ucRemarksClass.BookingClass);
            if (ComissionAgreementList.Count != 0)
            {
                if ((!string.IsNullOrEmpty(ComissionAgreementList[0].ITCCommand) &&
                    (!string.IsNullOrEmpty(ComissionAgreementList[0].ITCode))))
                {
                    cmbClientAgreement.Items.Add(ComissionAgreementList[0].ITCCommand);
                    List<CatITTourCodes> listITTourCodes = CatITTourCodesBL.GetITTourCodes();
                    int len = listITTourCodes.Count;
                    if (!len.Equals(0))
                    {
                        for (int i = 0; i < len; i++)
                        {
                            ListItem li = new ListItem();
                            li.Text = string.Format("{0} - {1}",
                                listITTourCodes[i].CommandIT,
                                listITTourCodes[i].Description);
                            li.Value = listITTourCodes[i].CommandIT;
                            cmbClientAgreement.Items.Add(li);
                        }
                        lbAirlines.DisplayMember = Resources.Constants.TEXT;
                        lbAirlines.ValueMember = Resources.Constants.VALUE;
                        bool statusTourCode = chkTourCode.Checked;
                        txtTourCode.Enabled = statusTourCode;
                        cmbClientAgreement.Enabled = statusTourCode;

                        if (statusTourCode)
                        {
                            txtTourCode.BackColor = Color.White;
                        }
                        else
                        {
                            txtTourCode.Text = string.Empty;
                            txtTourCode.BackColor = SystemColors.Control;
                            cmbClientAgreement.Text = string.Empty;
                        }

                    }
                    txtTourCode.Text = ComissionAgreementList[0].ITCode;
                    if (!chkTourCode.Checked)
                    {
                        chkTourCode.Checked = true;
                        //txtTourCode.Enabled = false;
                        cmbClientAgreement.SelectedIndex = 0;
                        //cmbClientAgreement.Enabled = false;
                    }
                    else
                    {
                        //txtTourCode.Enabled = false;
                        cmbClientAgreement.SelectedIndex = 0;
                        //cmbClientAgreement.Enabled = false;
                    }
                }
                else if (!string.IsNullOrEmpty(ComissionAgreementList[0].TourCode))
                {
                    txtTourCode.Text = ComissionAgreementList[0].TourCode;
                    List<CatITTourCodes> listITTourCodes = CatITTourCodesBL.GetITTourCodes();
                    int len = listITTourCodes.Count;
                    if (!len.Equals(0))
                    {
                        for (int i = 0; i < len; i++)
                        {
                            ListItem li = new ListItem();
                            li.Text = string.Format("{0} - {1}",
                                listITTourCodes[i].CommandIT,
                                listITTourCodes[i].Description);
                            li.Value = listITTourCodes[i].CommandIT;
                            cmbClientAgreement.Items.Add(li);
                        }
                        lbAirlines.DisplayMember = Resources.Constants.TEXT;
                        lbAirlines.ValueMember = Resources.Constants.VALUE;
                        chkTourCode.Checked = true;
                        txtTourCode.Enabled = true;
                        cmbClientAgreement.Enabled = true;
                        txtTourCode.BackColor = Color.White;
                        cmbClientAgreement.SelectedIndex = 0;
                    }
                }
                else
                {
                    txtTourCode.Text = string.Empty;
                    List<CatITTourCodes> listITTourCodes = CatITTourCodesBL.GetITTourCodes();
                    int len = listITTourCodes.Count;
                    if (!len.Equals(0))
                    {
                        for (int i = 0; i < len; i++)
                        {
                            ListItem li = new ListItem();
                            li.Text = string.Format("{0} - {1}",
                                listITTourCodes[i].CommandIT,
                                listITTourCodes[i].Description);
                            li.Value = listITTourCodes[i].CommandIT;
                            cmbClientAgreement.Items.Add(li);
                        }
                        lbAirlines.DisplayMember = Resources.Constants.TEXT;
                        lbAirlines.ValueMember = Resources.Constants.VALUE;
                        bool statusTourCode = chkTourCode.Checked;
                        txtTourCode.Enabled = statusTourCode;
                        cmbClientAgreement.Enabled = statusTourCode;

                        if (statusTourCode)
                        {
                            txtTourCode.BackColor = Color.White;
                        }
                        else
                        {
                            txtTourCode.Text = string.Empty;
                            txtTourCode.BackColor = SystemColors.Control;
                            cmbClientAgreement.Text = string.Empty;
                        }

                    }
                }

            }
            else
            {
                List<CatITTourCodes> listITTourCodes = CatITTourCodesBL.GetITTourCodes();
                int len = listITTourCodes.Count;
                if (!len.Equals(0))
                {
                    for (int i = 0; i < len; i++)
                    {
                        ListItem li = new ListItem();
                        li.Text = string.Format("{0} - {1}",
                            listITTourCodes[i].CommandIT,
                            listITTourCodes[i].Description);
                        li.Value = listITTourCodes[i].CommandIT;
                        cmbClientAgreement.Items.Add(li);
                    }
                    lbAirlines.DisplayMember = Resources.Constants.TEXT;
                    lbAirlines.ValueMember = Resources.Constants.VALUE;
                    bool statusTourCode = chkTourCode.Checked;
                    txtTourCode.Enabled = statusTourCode;
                    cmbClientAgreement.Enabled = statusTourCode;

                    if (statusTourCode)
                    {
                        txtTourCode.BackColor = Color.White;
                    }
                    else
                    {
                        txtTourCode.Text = string.Empty;
                        txtTourCode.BackColor = SystemColors.Control;
                        cmbClientAgreement.Text = string.Empty;
                    }

                }

            }
        }

        /// <summary>
        /// Verifica si el corporativo es Consolid, y si es asi le asigna por default
        /// la opción de imprimir itinerario
        /// </summary>
        private void ValidateConsolid()
        {
            if (activeStepsCorporativeQC.CorporativeQualityControls[0].Attribute1.Equals(Resources.TicketEmission.Constants.CONSOLID))
            {
                //chkPrintItinerary.Checked = true;  
            }
        }

        /// <summary>
        /// Asigna valores de pasajeros previos del user control de definicion de pasajeros
        /// </summary>
        private void AssignPaxNumberValues()
        {
            if (!string.IsNullOrEmpty(ucQualitiesByPax.Passengers))
            {
                chkByNames.Checked = true;
                txtName1.Text = ucQualitiesByPax.numberOne;
                txtName2.Text = ucQualitiesByPax.numberTwo;
                txtName3.Text = ucQualitiesByPax.numberThree;
                txtName4.Text = ucQualitiesByPax.numberFour;
            }
        }

        //establece la forma de pago permitida del boleto por aereolinea
        private void SetFormPayment()
        {
            List<AirlineFOP> AirlineFOP = AirlineFOPBL.GetAirlinFOP(txtAirLine.Text);
            if (AirlineFOP.Count > 0)
            {

                if (CodeAuth == null)
                {
                    rdoAmericanExpress.Enabled = AirlineFOP[0].CCAut;
                    rdoCreditCard.Enabled = AirlineFOP[0].CCMan;
                    rdoCash.Enabled = AirlineFOP[0].Cash;
                    rdoMiscelaneous.Enabled = AirlineFOP[0].Misc;
                    rdoMixPayment.Enabled = AirlineFOP[0].PMix;
                }
                

                foreach (Control ctrl in tblLayoutPaymentWay.Controls)
                {
                    if (ctrl is RadioButton)
                    {
                        if (ctrl.Enabled)
                        {
                            ((RadioButton)(ctrl)).Checked = true;
                            break;
                        }
                    }
                }

                if (chkWithCharge.Checked)
                    WithChargeDisableControls(false, true);
                else if (chkWithoutCharge.Checked)
                    WithChargeDisableControls(false, false);

            }
            else
            {
                if (CodeAuth == null)
                {
                    rdoAmericanExpress.Enabled = true;
                    rdoCreditCard.Enabled = true;
                    rdoCash.Enabled = true;
                    rdoMiscelaneous.Enabled = true;
                    rdoMixPayment.Enabled = true;
                }
            }


        }

        private void GetRemarkCSC()
        {
            codeAuth = GetAuthCodeBL.GetAuthCode(ucFirstValidations.LocatorRecord);

            if (!string.IsNullOrEmpty(codeAuth.PNR))
            {
                MessageBox.Show(Resources.TicketEmission.Tickets.EXISTE_CODIGO_AUTH + "\n\n CÖDIGO: " +CodeAuth.Code + "\n TARJETA: " + CodeAuth.CardType + "\n BANCO: " + CodeAuth.Bank.ToUpper() + "\n MONTO: " + CodeAuth.Amount + "\n FORMATO DE COTIZACIÓN: " + CodeAuth.CommandWP, 
                    Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!ucFormPayment.ReturnForMisc)
                {
                    GetBaseFare(codeAuth.CommandWP);

                    if (!string.IsNullOrEmpty(total))
                    {
                        if ((System.Convert.ToInt32(codeAuth.Amount) <= System.Convert.ToInt32(total)))
                        {
                            foreach (Control ctrl in this.tblLayoutPaymentWay.Controls)
                            {
                                if (!ctrl.Name.Equals("rdoAmericanExpress"))
                                {
                                    ctrl.Enabled = false;
                                }
                                else
                                    ctrl.Select();
                            }
                        }
                        else if (System.Convert.ToInt32(codeAuth.Amount) > System.Convert.ToInt32(total))
                        {
                            foreach (Control ctrl in this.tblLayoutPaymentWay.Controls)
                            {
                                if (!ctrl.Name.Equals("rdoMixPayment"))
                                {
                                    ctrl.Enabled = false;
                                }
                                else
                                    ctrl.Select();
                            }
                        }
                    }
                }
                else
                {
                    foreach (Control ctrl in this.tblLayoutPaymentWay.Controls)
                    {
                        if (!ctrl.Name.Equals("rdoMixPayment"))
                        {
                            ctrl.Enabled = false;
                        }
                        else
                            ctrl.Select();
                    }
                }

                if (!string.IsNullOrEmpty(codeAuth.CommandWP))
                {
                    string[] parts = codeAuth.CommandWP.Split('‡');
                    txtAirLine.Text = parts[0].Substring(parts[0].Length - 2, 2);
                    errorProvider1.SetError(txtAirLine, "Para realizar la emisión con otra aerolínea, debes cancelar la autorización pendiente");
                    txtAirLine.Enabled = false;
                }
            }
        }


        /// <summary>
        /// Obtinen el monto de los boletos que se van a emitir de acuerdo al
        /// numero de segmentos, aerolínea con que se emite y otros aspectos; 
        /// esto se hace via API
        /// </summary>
        private void GetBaseFare(string commandSend)
        {
           
            string sabreAnswer = string.Empty;
           
            string[] rows;
            
            int row = 0;
            int col = 0;
            MyCTS.Presentation.Parameters.TimeExtendedAPI = true;
            try
            {
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    sabreAnswer = objCommand.SendReceive(commandSend);
                }
            }
            catch { }
            MyCTS.Presentation.Parameters.TimeExtendedAPI = false;
            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.TOTAL, ref row, ref col, 1, 4, 30, 64);
                if (row != 0 || col != 0)
                {
                    string temp_total = string.Empty;
                    rows = sabreAnswer.Split('\n');
                    for (int i = 0; i < rows.Length; i++)
                    {
                        if (rows[i].Contains("TTL"))
                        {
                            temp_total = rows[i].Substring(50, rows[i].Length - 50);

                        }
                    }

                    temp_total = temp_total.Replace("TTL", Resources.TicketEmission.Constants.SPACE);
                    temp_total = temp_total.Trim();
                    total = temp_total;

                }
            }

            row = 0; col = 0;
            MyCTS.Presentation.Parameters.TimeExtendedAPI = false;
            CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.TOTAL, ref row, ref col, 1, 4, 30, 64);
                if (row != 0 || col != 0)
                {
                    row = row + 1;
                    CommandsQik.CopyResponse(sabreAnswer, ref baseFare, row, 5, 14);
                    baseFare = baseFare.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE).Trim();
                }
                row = 0;
                col = 0;
                CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.EQUIV_AMT, ref row, ref col, 1, 4, 15, 40);
                if (row != 0 || col != 0)
                {
                    row = row + 1;
                    baseFare = string.Empty;
                    CommandsQik.CopyResponse(sabreAnswer, ref baseFare, row, 19, 14);
                    baseFare = baseFare.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE).Trim();

                }
                else
                {
                    CommandsQik.searchResponse(sabreAnswer, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col, 1, 4, 1, 20);
                    if (row != 0 || col != 0)
                    {
                        row = row + 1;
                        baseFare = string.Empty;
                        CommandsQik.CopyResponse(sabreAnswer, ref baseFare, row, 5, 14);
                        baseFare = baseFare.Replace(Resources.TicketEmission.Constants.MXN, Resources.TicketEmission.Constants.SPACE).Trim();
                    }
                }
            }

            if (!sabreAnswer.Contains("TTL"))
            {
                baseFare = string.Empty;
                total = string.Empty;
            }

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
                ucAllQualityControls.counter = ucAllQualityControls.counter - 1;
                ucAllQualityControls.originOfSale.RemoveAt(ucAllQualityControls.counter);
                ucAllQualityControls.ListBussinesUnit.RemoveAt(ucAllQualityControls.counter);
                CodeAuth=null;
                ucFormPayment.ReturnForMisc = false;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_ALL_QUALITY_CONTROLS);
            }
            if (e.KeyData.Equals(Keys.Enter))
            {

                btnAccept_Click(sender, e);
            }

        }
        #endregion//End Back to a Previous Usercontrol or Validate Enter KeyDown

        #region===== Enable Disable Controls =====

        //Evento rdoNormalTicket_CheckedChanged 
        private void rdoNormalTicket_CheckedChanged(object sender, EventArgs e)
        {
            rdoNormalTicketEnableDisableControls();
        }


        //Evento rdoPhase35375_CheckedChanged 
        private void rdoPhase35375_CheckedChanged(object sender, EventArgs e)
        {
            rdoPhase35375EnableDisableControls();
        }


        //Evento rdoPhaseIV_CheckedChanged 
        private void rdoPhaseIV_CheckedChanged(object sender, EventArgs e)
        {
            rdoPhaseIVEnableDisableControls();
        }


        //Evento chkQuaNegociated_CheckedChanged 
        private void chkQuaNegociated_CheckedChanged(object sender, EventArgs e)
        {
            chkQuaNegociatedEnableDisableControls();
        }


        //Evento chkCorporateID_CheckedChanged 
        private void chkCorporateID_CheckedChanged(object sender, EventArgs e)
        {
            chkCorporateIDEnableDisableControls();
        }


        //Evento chkAccountCode_CheckedChanged 
        private void chkAccountCode_CheckedChanged(object sender, EventArgs e)
        {
            chkAccountCodeEnableDisableControls();
        }


        //Evento chkTourCode_CheckedChanged 
        private void chkTourCode_CheckedChanged(object sender, EventArgs e)
        {
            chkTourCodeEnableDisableControls();
        }


        //Evento chkMarks_CheckedChanged 
        private void chkMarks_CheckedChanged(object sender, EventArgs e)
        {
            chkMarksEnableDisableControls();
        }


        //Evento chkByNames_CheckedChanged 
        private void chkByNames_CheckedChanged(object sender, EventArgs e)
        {
            chkByNamesEnableDisableControls();
        }


        //Evento chkBySegments_CheckedChanged 
        private void chkBySegments_CheckedChanged(object sender, EventArgs e)
        {
            bySegmentsEnableDisableControls();
        }

        #endregion//End Enable Disable Controls

        #region===== listbox Controls Events=====

        //Evento lbAirlines_KeyDown 
        private void lbAirlines_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox ListBox = (ListBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                ListItem li = (ListItem)ListBox.SelectedItem;
                txt.Text = li.Value;
                airlinename = li.Text;
                ListBox.Visible = false;
                txt.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                lbAirlines.Visible = false;
                txt.Focus();
            }

        }


        //Evento HideListbox_Airlines 
        private void HideListbox_Airlines(object sender, EventArgs e)
        {
            lbAirlines.Visible = false;
        }


        //Evento AirlinesActions_KeyDown 
        private void AirlinesActions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                CodeAuth = null;
                ucFormPayment.ReturnForMisc = false;
                ucAllQualityControls.counter = ucAllQualityControls.counter - 1;
                ucAllQualityControls.originOfSale.RemoveAt(ucAllQualityControls.counter);
                ucAllQualityControls.ListBussinesUnit.RemoveAt(ucAllQualityControls.counter);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_ALL_QUALITY_CONTROLS);
            }
            if (e.KeyData == Keys.Enter)
            {
                btnAccept_Click(sender, e);
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lbAirlines.Items.Count > 0)
                {
                    lbAirlines.SelectedIndex = 0;
                    lbAirlines.Focus();
                    lbAirlines.Visible = true;
                    lbAirlines.Focus();
                }
            }

        }


        //Evento txtAirlinesControls_Leave 
        private void txtAirlinesControls_Leave(object sender, EventArgs e)
        {
            lbAirlines.Visible = false;
        }


        //Evento ListBox_MouseClick 
        private void ListBox_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            ListItem li = (ListItem)listBox.SelectedItem;
            txt.Text = li.Value;
            listBox.Visible = false;
            txt.Focus();
        }
        #endregion//End lbControls events

        #region=====Textbox Controls Text Change Events=====

        /// <summary>
        ///  Muestra predictivo de aereolinea y manda a llamar la función loadDBInformation()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAirLine_TextChanged(object sender, EventArgs e)
        {
            if (!statusParamReceived)
            {
                txt = (TextBox)sender;
                Common.SetListBoxPAirlines(txt, lbAirlines);
                if (txtAirLine.Text.Length == 2)
                {
                    List<ComissionAgreements> ComissionAgreementList = ComissionAgreementsBL.GetComissionAgreements(string.Empty, txtAirLine.Text, ucRatingActualFare.internationalFlight, string.Empty);
                    if (ComissionAgreementList.Count != 0)
                    {
                        if (ucRatingActualFare.internationalFlight.Equals(true))
                        {
                            txtCommissionPercentage.Text = ComissionAgreementList[0].InternationalCommision;
                        }
                        else
                        {
                            txtCommissionPercentage.Text = ComissionAgreementList[0].DomesticCommision;
                        }
                        osi = string.Empty;
                        if (!string.IsNullOrEmpty(ComissionAgreementList[0].OSI))
                        {
                            osi = string.Concat(Resources.TicketEmission.Constants.COMMANDS_THREE,
                                ComissionAgreementList[0].OSI);
                        }
                    }
                    SetFormPayment();
                }

            }
            LoadDBInformation();
            if (chkWithoutCharge.Checked)
                rdoAmericanExpress.Checked = false;
        }

        //Evento txtPhaseIVNumber_TextChanged 
        private void txtPhaseIVNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtPhaseIVNumber.Text.Length > 0)
            {
                txtAirLine.Focus();
            }
        }

        //Evento txtName1_TextChanged 
        private void txtName1_TextChanged(object sender, EventArgs e)
        {
            if (txtName1.Text.Length > 3)
            {
                txtName2.Focus();
            }
        }

        //Evento txtName2_TextChanged 
        private void txtName2_TextChanged(object sender, EventArgs e)
        {
            if (txtName2.Text.Length > 3)
            {
                txtName3.Focus();
            }
        }

        //Evento txtName3_TextChanged 
        private void txtName3_TextChanged(object sender, EventArgs e)
        {
            if (txtName3.Text.Length > 3)
            {
                txtName4.Focus();
            }
        }

        //Evento txtName4_TextChanged 
        private void txtName4_TextChanged(object sender, EventArgs e)
        {
            if (txtName4.Text.Length > 3)
            {
                chkBySegments.Focus();
            }
        }

        //Evento txtSegment1_TextChanged 
        private void txtSegment1_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment1.Text.Length > 1)
            {
                txtSegment2.Focus();
            }
        }

        //Evento txtSegment2_TextChanged 
        private void txtSegment2_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment2.Text.Length > 1)
            {
                txtSegment3.Focus();
            }
        }

        //Evento txtSegment3_TextChanged 
        private void txtSegment3_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment3.Text.Length > 1)
            {
                txtSegment4.Focus();
            }
        }

        //Evento txtSegment4_TextChanged 
        private void txtSegment4_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment4.Text.Length > 1)
            {
                txtSegment5.Focus();
            }
        }

        //Evento txtSegment5_TextChanged 
        private void txtSegment5_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment5.Text.Length > 1)
            {
                txtSegment6.Focus();
            }
        }

        //Evento txtSegment6_TextChanged 
        private void txtSegment6_TextChanged(object sender, EventArgs e)
        {
            if (txtSegment6.Text.Length > 1)
            {
                chkTaxes.Focus();
            }
        }

        //Activa y desactiva controles
        private void chkWithCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWithCharge.Checked)
            {
                WithChargeDisableControls(false, true);
                chkWithoutCharge.Checked = false;
                WithCharge = true;
                WithoutCharge = false;
                rdoAmericanExpress.Checked = true;
            }
            else if (!chkWithoutCharge.Checked)
            {
                rdoAmericanExpress.Checked = true;
                WithChargeDisableControls(true, true);
                WithCharge = false;
                WithoutCharge = false;
            }
        }

        //Activa y desactiva controles
        private void chkWithoutCharge_CheckedChanged(object sender, EventArgs e)
        {

            if (chkWithoutCharge.Checked)
            {
                rdoAmericanExpress.Checked = false;
                WithChargeDisableControls(false, false);
                chkWithCharge.Checked = false;
                WithCharge = false;
                WithoutCharge = true;
            }
            else if (!chkWithCharge.Checked)
            {
                rdoAmericanExpress.Checked = true;
                WithChargeDisableControls(true, true);
                WithCharge = false;
                WithoutCharge = false;
            }
        }

        #endregion

        private void rdoCash_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCash.Checked)
            {
                frmGenericFOPCTS frm = new frmGenericFOPCTS(0, string.Empty);
                frm.ShowDialog();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Parameter url = ParameterBL.GetParameterValue("TablaComisiones");
            System.Diagnostics.Process.Start(url.Values);
        }


        public static bool ReturnForMisc = false;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                ucAllQualityControls.counter = ucAllQualityControls.counter - 1;
                ucAllQualityControls.originOfSale.RemoveAt(ucAllQualityControls.counter);
                ucAllQualityControls.ListBussinesUnit.RemoveAt(ucAllQualityControls.counter);
                CodeAuth=null;
                ucFormPayment.ReturnForMisc = false;
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_ALL_QUALITY_CONTROLS);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
