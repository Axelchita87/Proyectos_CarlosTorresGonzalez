using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Services;
using MyCTS.Services.Contracts;
using MyCTS.Business;
using MyCTS.Entities;
using System.Diagnostics;
using System.IO;


namespace MyCTS.Presentation
{
    public partial class ucGetDIX : CustomUserControl
    {
        /// <summary>
        /// Descripcion: Obtiene la información de los segmentos aereos, de hotel y de
        /// auto por record para el armado del archivo DIX
        /// Creación:    Marzo 2010 , Modificación:*
        /// Cambio:      *    , Solicito *
        /// Autor:       Angel Trejo
        /// </summary>
        public ucGetDIX()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            this.InitialControlFocus = txtPNR;
            this.LastControlFocus = btnAccept;
        }

        #region ====== Globals Variables ======

        GetInformationToDIX.GetInformationToDIXObject myObject = null;
        private string informationDIX = string.Empty;
        private string dateSegmnet = string.Empty;
        private bool status = true;

        #endregion //Globals Variables

        public class InformationByItinerary
        {
            public DateTime date;
            public int indexInList;
            public string typeSegment;
        }

        private void ucGetDIX_Load(object sender, EventArgs e)
        {
            ucAvailability.IsInterJetProcess = false;
            txtPNR.Focus();
            string send = "*A";
            string sabreAnswer = string.Empty;
            string pnr = string.Empty;
            using (CommandsAPI objCommand = new CommandsAPI())
            {
                sabreAnswer = objCommand.SendReceive(send);
            }
            string resultAux = sabreAnswer.Replace("‡", "\n");
            string[] sabreAnswerInfo = resultAux.Split(new char[] { '\n' });
            int row = 0;
            int col = 0;
            CommandsQik.searchResponse(sabreAnswer, "NO DATA", ref row, ref col);
            if (row != 0 && col >= 0)
            {
                MessageBox.Show("NO EXISTE RECORD PRESENTE", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }

            else if (sabreAnswerInfo.Length > 0 && sabreAnswerInfo[0].Length == 6 && ValidateRegularExpression.ValidatePNR(sabreAnswerInfo[0]))
            {
                CommandsAPI2.send_MessageToEmulator("CTP EDITS IN PROGRESS....PLEASE WAIT....\n" +
                "OK " + sabreAnswerInfo[0] + "\nEXPORT I AND I IN PROGRESS");
                txtPNR.Text = sabreAnswerInfo[0];
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive("I", 0, 0);
                }
                GetInformationDIX();
            }
            else
            {
                MessageBox.Show("IGNORE Y RECUPERE EL RECORD", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        /// <summary>
        /// Acciones que se ejecutan el dar click en el boton aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPNR.Text))
            {
                MessageBox.Show("DEBE INGRESAR EL RECORD LOCALIZADOR", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPNR.Focus();
            }
            else if (txtPNR.TextLength != txtPNR.MaxLength)
            {
                MessageBox.Show("EL FORMATO DEL RECORD LOCALIZADOR DEBE SER DE 6 CARACTERES", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPNR.Focus();
            }
            else
                GetInformationDIX();
        }


        #region ====== Methods Class ======

        /// <summary>
        /// Obtiene la información de los segmentos de un record para crear el DIX
        /// </summary>
        private void GetInformationDIX()
        {
            using (WSSessionSabre obj = new WSSessionSabre())
            {
                 obj.OpenConnection();
                 if (obj.IsConnected)
                 {
                     myObject = new GetInformationToDIX().TravelItineraryMethod(obj.ConversationId, obj.IPcc, obj.SecurityToken, txtPNR.Text);
                 }
            }
            if (myObject != null && myObject.Status)
                {
                if (myObject.Response == "PNR OF GROUP")
                {
                    MessageBox.Show("RECORD LOCALIZADOR DE GRUPO, NO SE PUEDE OBTENER SU INFORMACIÓN", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPNR.Focus();
                }
                else
                {
                    try
                    {
                        if (myObject.namePassengerList.Count > 0)
                        {
                            informationDIX = string.Concat("                                             ATN: ",
                                myObject.namePassengerList[0].paxName,
                                (!string.IsNullOrEmpty(myObject.namePassengerList[0].paxRef) ? " REF: " : ""),
                                myObject.namePassengerList[0].paxRef, "\n");
                            for (int i = 1; i < myObject.namePassengerList.Count; i++)
                            {
                                informationDIX = string.Concat(informationDIX,
                                    "                                                  ",
                                    myObject.namePassengerList[i].paxName,
                                    (!string.IsNullOrEmpty(myObject.namePassengerList[i].paxRef) ? " REF: " : ""),
                                    myObject.namePassengerList[i].paxRef, "\n");
                            }
                        }
                        if (myObject.remarkInvoicesList.Count > 0)
                        {
                            informationDIX = string.Concat(informationDIX, "\n",
                                "                                             DIR: ", myObject.remarkInvoicesList[0], "\n");
                            for (int i = 1; i < myObject.remarkInvoicesList.Count; i++)
                            {
                                informationDIX = string.Concat(informationDIX,
                                    "                                                  ",
                                    myObject.remarkInvoicesList[i], "\n");
                            }
                        }
                        informationDIX = string.Concat(informationDIX,
                            "\n\n\n",
                            "NO. DE CLIENTE: ", myObject.LocationDK, "\n",
                            "      VENDEDOR: ", myObject.Agent, "\n",
                            "   CLAVE SABRE: ", txtPNR.Text, "\n",
                            "         FECHA: ", DateTime.Now.ToString("dd-MMM-yyyy").ToUpper(), "\n");
                        if (myObject.hotelList.Count > 0 || myObject.autoList.Count > 0)
                        {
                            List<InformationByItinerary> segmenByDateList = new List<InformationByItinerary>();
                            for (int i = 0; i < myObject.listItineraryInfo.Count; i++)
                            {
                                InformationByItinerary item = new InformationByItinerary();
                                item.date = Convert.ToDateTime(myObject.listItineraryInfo[i].dateFlight);
                                item.indexInList = i;
                                item.typeSegment = "Vuelo";
                                segmenByDateList.Add(item);
                            }
                            for (int i = 0; i < myObject.hotelList.Count; i++)
                            {
                                InformationByItinerary item = new InformationByItinerary();
                                item.date = Convert.ToDateTime(myObject.hotelList[i].startDate);
                                item.indexInList = i;
                                item.typeSegment = "Hotel";
                                segmenByDateList.Add(item);
                            }
                            for (int i = 0; i < myObject.autoList.Count; i++)
                            {
                                InformationByItinerary item = new InformationByItinerary();
                                item.date = Convert.ToDateTime(myObject.autoList[i].dateRent);
                                item.indexInList = i;
                                item.typeSegment = "Auto";
                                segmenByDateList.Add(item);
                            }
                            segmenByDateList.Sort(delegate(InformationByItinerary segment1, InformationByItinerary segment2)
                            {
                                return segment1.date.CompareTo(segment2.date);
                            });
                            for (int i = 0; i < segmenByDateList.Count; i++)
                            {
                                if (segmenByDateList[i].typeSegment == "Vuelo")
                                    BuildAirInformation(segmenByDateList[i].indexInList);
                                else if (segmenByDateList[i].typeSegment == "Auto")
                                    BuildCarInformation(segmenByDateList[i].indexInList);
                                else if (segmenByDateList[i].typeSegment == "Hotel")
                                    BuildHotelInformation(segmenByDateList[i].indexInList);
                            }
                        }
                        else
                            for (int i = 0; i < myObject.listItineraryInfo.Count; i++)
                                BuildAirInformation(i);

                        for (int i = 0; i < myObject.segmentProtectionList.Count; i++)
                        {
                            List<ListItem> cityCodeSegmentProtection = CatCitiesBL.GetCities(myObject.segmentProtectionList[i].locationCode);
                            myObject.segmentProtectionList[i].locationCode = cityCodeSegmentProtection[0].Text.Substring(4, cityCodeSegmentProtection[0].Text.Length - 4);
                            if (myObject.segmentProtectionList[i].daySegment == "Sunday")
                                myObject.segmentProtectionList[i].daySegment = "Domingo";
                            else if (myObject.segmentProtectionList[i].daySegment == "Monday")
                                myObject.segmentProtectionList[i].daySegment = "Lunes";
                            else if (myObject.segmentProtectionList[i].daySegment == "Tuesday")
                                myObject.segmentProtectionList[i].daySegment = "Martes";
                            else if (myObject.segmentProtectionList[i].daySegment == "Wednesday")
                                myObject.segmentProtectionList[i].daySegment = "Miercoles";
                            else if (myObject.segmentProtectionList[i].daySegment == "Thursday")
                                myObject.segmentProtectionList[i].daySegment = "Jueves";
                            else if (myObject.segmentProtectionList[i].daySegment == "Friday")
                                myObject.segmentProtectionList[i].daySegment = "Viernes";
                            else if (myObject.segmentProtectionList[i].daySegment == "Saturday")
                                myObject.segmentProtectionList[i].daySegment = "Sabado";
                            informationDIX = string.Concat(informationDIX, "\n",
                                myObject.segmentProtectionList[i].dateSegment, "  -  ",
                                myObject.segmentProtectionList[i].daySegment.ToUpper(), "\n",
                                "  OTRO    ",
                                myObject.segmentProtectionList[i].locationCode, "\n",
                                "          ",
                                myObject.segmentProtectionList[i].textSegment, "\n");
                        }
                        informationDIX = string.Concat(informationDIX, "\n");
                        for (int k = 0; k < myObject.remarksList.Count; k++)
                        {
                            if (string.IsNullOrEmpty(myObject.remarksList[k].segmentNumber))
                                informationDIX = string.Concat(informationDIX,
                                    myObject.remarksList[k].remark, "\n");
                        }
                    }
                    catch
                    {
                       status = false;
                    }
                    if (status)
                        BuildTXT(informationDIX);
                    else
                    {
                        MessageBox.Show("ERROR EN LA ESCRITURA DEL RECORD, FAVOR DE REPORTARLO A SISTEMAS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
                    }
                }
            }
            else
            {
                if (myObject != null)
                    MessageBox.Show(myObject.Response, Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("ERROR EN EL WEB SERVICE, FAVOR DE REPORTARLO A SISTEMAS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        /// <summary>
        /// Obtiene información de los segmentos aereos
        /// </summary>
        /// <param name="j">indice del segmento en su respectiva lista</param>
        private void BuildAirInformation(int j)
        {
            try
            {
                string tempAirLine = string.Empty;
                string tempAirLineClass = string.Empty;
                string descrptionMeal = string.Empty;
                List<CatAirlines> airlineList = CatAirlinesBL.GetAirlines(myObject.listItineraryInfo[j].airline);
                List<ListItem> originList = CatCitiesBL.GetCities(myObject.listItineraryInfo[j].origin);
                List<ListItem> destinationList = CatCitiesBL.GetCities(myObject.listItineraryInfo[j].destination);
                List<ListItem> airlineClass = CatLineClassesBL.GetAirLinesClasses(myObject.listItineraryInfo[j].resBookDesigCode);
                if (!string.IsNullOrEmpty(myObject.listItineraryInfo[j].codeMeal) && myObject.listItineraryInfo[j].codeMeal.Length == 1)
                    descrptionMeal = GetCodeMealToDIXBL.GetCodeMealToDIX(myObject.listItineraryInfo[j].codeMeal).ToUpper();
                else if (!string.IsNullOrEmpty(myObject.listItineraryInfo[j].codeMeal) && myObject.listItineraryInfo[j].codeMeal.Length > 1)
                    descrptionMeal = "MULTI MEALS";
                else
                    descrptionMeal = string.Empty;
                tempAirLineClass = (airlineClass[0].Text.Contains("TURISTA") ? "ECONOMICA" : airlineClass[0].Text.Substring(2, airlineClass[0].Text.Length - 2));
                tempAirLine = airlineList[0].CatAirLinName;
                myObject.listItineraryInfo[j].origin = originList[0].Text.Substring(4, originList[0].Text.Length - 4);
                myObject.listItineraryInfo[j].destination = destinationList[0].Text.Substring(4, destinationList[0].Text.Length - 4);
                if (myObject.listItineraryInfo[j].dayFlight == "Sunday")
                    myObject.listItineraryInfo[j].dayFlight = "Domingo";
                else if (myObject.listItineraryInfo[j].dayFlight == "Monday")
                    myObject.listItineraryInfo[j].dayFlight = "Lunes";
                else if (myObject.listItineraryInfo[j].dayFlight == "Tuesday")
                    myObject.listItineraryInfo[j].dayFlight = "Martes";
                else if (myObject.listItineraryInfo[j].dayFlight == "Wednesday")
                    myObject.listItineraryInfo[j].dayFlight = "Miercoles";
                else if (myObject.listItineraryInfo[j].dayFlight == "Thursday")
                    myObject.listItineraryInfo[j].dayFlight = "Jueves";
                else if (myObject.listItineraryInfo[j].dayFlight == "Friday")
                    myObject.listItineraryInfo[j].dayFlight = "Viernes";
                else if (myObject.listItineraryInfo[j].dayFlight == "Saturday")
                    myObject.listItineraryInfo[j].dayFlight = "Sabado";
                if (myObject.listItineraryInfo[j].dateFlight.ToString("dd-MMM-yyyy").ToUpper() != dateSegmnet)
                    informationDIX = string.Concat(informationDIX, "\n", myObject.listItineraryInfo[j].dateFlight.ToString("dd-MMM-yyyy").ToUpper(), "  -  ", myObject.listItineraryInfo[j].dayFlight.ToUpper(), "\n");
                dateSegmnet = myObject.listItineraryInfo[j].dateFlight.ToString("dd-MMM-yyyy").ToUpper();
                informationDIX = string.Concat(informationDIX, "  VUELO   ",
                    tempAirLine.PadRight(28, ' '),
                    "VLO: ",
                    myObject.listItineraryInfo[j].airline,
                    myObject.listItineraryInfo[j].flightNumber,
                    "   ", tempAirLineClass.PadRight(15, ' '),
                    descrptionMeal, "\n");
                if (!string.IsNullOrEmpty(myObject.listItineraryInfo[j].operatingAirline))
                    informationDIX = string.Concat(informationDIX, "          ", "OPERATED BY ", myObject.listItineraryInfo[j].operatingAirline, "\n");
                informationDIX = string.Concat(informationDIX,
                    "          SAL  ",
                    myObject.listItineraryInfo[j].origin.PadRight(37, ' '),
                    myObject.listItineraryInfo[j].timeDeparture,
                    "          ", myObject.listItineraryInfo[j].equipment, "\n");
                if (!string.IsNullOrEmpty(myObject.listItineraryInfo[j].terminalDeparture))
                    informationDIX = string.Concat(informationDIX,
                        "          DEPART: ",
                        myObject.listItineraryInfo[j].terminalDeparture.PadRight(49, ' '),
                        myObject.listItineraryInfo[j].durationFlight, "\n");
                else
                    informationDIX = string.Concat(informationDIX,
                        myObject.listItineraryInfo[j].durationFlight.PadLeft(77, ' '), "\n");
                if (!dateSegmnet.Equals(myObject.listItineraryInfo[j].dateArrival.ToString("dd-MMM-yyyy").ToUpper()))
                {
                    if (Convert.ToString(myObject.listItineraryInfo[j].dateArrival.DayOfWeek).Equals("Sunday"))
                        informationDIX = string.Concat(informationDIX, myObject.listItineraryInfo[j].dateArrival.ToString("dd-MMM-yyyy").ToUpper(), "  -  ", "Domingo", "\n");
                    else if (Convert.ToString(myObject.listItineraryInfo[j].dateArrival.DayOfWeek).Equals("Monday"))
                        informationDIX = string.Concat(informationDIX, myObject.listItineraryInfo[j].dateArrival.ToString("dd-MMM-yyyy").ToUpper(), "  -  ", "Lunes", "\n");
                    else if (Convert.ToString(myObject.listItineraryInfo[j].dateArrival.DayOfWeek).Equals("Tuesday"))
                        informationDIX = string.Concat(informationDIX, myObject.listItineraryInfo[j].dateArrival.ToString("dd-MMM-yyyy").ToUpper(), "  -  ", "Martes", "\n");
                    else if (Convert.ToString(myObject.listItineraryInfo[j].dateArrival.DayOfWeek).Equals("Wednesday"))
                        informationDIX = string.Concat(informationDIX, myObject.listItineraryInfo[j].dateArrival.ToString("dd-MMM-yyyy").ToUpper(), "  -  ", "Miercoles", "\n");
                    else if (Convert.ToString(myObject.listItineraryInfo[j].dateArrival.DayOfWeek).Equals("Thursday"))
                        informationDIX = string.Concat(informationDIX, myObject.listItineraryInfo[j].dateArrival.ToString("dd-MMM-yyyy").ToUpper(), "  -  ", "Jueves", "\n");
                    else if (Convert.ToString(myObject.listItineraryInfo[j].dateArrival.DayOfWeek).Equals("Friday"))
                        informationDIX = string.Concat(informationDIX, myObject.listItineraryInfo[j].dateArrival.ToString("dd-MMM-yyyy").ToUpper(), "  -  ", "Viernes", "\n");
                    else if (Convert.ToString(myObject.listItineraryInfo[j].dateArrival.DayOfWeek).Equals("Saturday"))
                        informationDIX = string.Concat(informationDIX, myObject.listItineraryInfo[j].dateArrival.ToString("dd-MMM-yyyy").ToUpper(), "  -  ", "Sabado", "\n");
                    dateSegmnet = myObject.listItineraryInfo[j].dateArrival.ToString("dd-MMM-yyyy").ToUpper();
                }
                informationDIX = string.Concat(informationDIX,
                    "          LLEG ",
                    myObject.listItineraryInfo[j].destination.PadRight(37, ' '),
                    myObject.listItineraryInfo[j].timeArrival,
                    "          ", (myObject.listItineraryInfo[j].escala == true) ? "CON ESCALA" : "SIN ESCALA", "\n");
                if (!string.IsNullOrEmpty(myObject.listItineraryInfo[j].terminalArrival))
                    informationDIX = string.Concat(informationDIX,
                        "          ARRIVE: ",
                        myObject.listItineraryInfo[j].terminalArrival.PadRight(49, ' '),
                        "CLAVE: ",
                        myObject.listItineraryInfo[j].airlineRef, "\n");
                else
                    informationDIX = string.Concat(informationDIX,
                        "CLAVE: ".PadLeft(74, ' '),
                        myObject.listItineraryInfo[j].airlineRef, "\n");
                int aux = 0;
                string custLoyalty = string.Empty;
                if (myObject.listItineraryInfo[j].seatsNumber != null)
                    for (int i = 0; i < myObject.listItineraryInfo[j].seatsNumber.Count; i++)
                    {
                        string temp = myObject.listItineraryInfo[j].seatsNumber[i].paxNumber;
                        for (int k = 0; k < myObject.namePassengerList.Count; k++)
                        {
                            if (myObject.namePassengerList[k].paxNumber == temp)
                            {
                                aux = k;
                                break;
                            }
                        }
                        if (myObject.namePassengerList[aux].custLoyalty.Count > 0)
                            for (int h = 0; h < myObject.namePassengerList[aux].custLoyalty.Count; h++)
                                if (myObject.namePassengerList[aux].custLoyalty[h].Substring(0, 2) == myObject.listItineraryInfo[j].airline)
                                {
                                    custLoyalty = myObject.namePassengerList[aux].custLoyalty[h];
                                    break;
                                }
                        informationDIX = string.Concat(informationDIX,
                            "          ",
                            myObject.namePassengerList[aux].paxName.PadRight(27, ' '),
                            " ASIENTO-",
                            myObject.listItineraryInfo[j].seatsNumber[i].seatNumber, "   ", custLoyalty, "\n");
                    }
                else
                {
                    for (int g = 0; g < myObject.namePassengerList.Count; g++)
                        if (myObject.namePassengerList[g].custLoyalty.Count > 0)
                            for (int q = 0; q < myObject.namePassengerList[g].custLoyalty.Count; q++)
                            {
                                if (myObject.namePassengerList[g].custLoyalty[q].Substring(0, 2) == myObject.listItineraryInfo[j].airline)
                                {
                                    informationDIX = string.Concat(informationDIX,
                                        "          ",
                                        myObject.namePassengerList[g].paxName.PadRight(25, ' '),
                                        "   ",
                                        myObject.namePassengerList[g].custLoyalty[q], "\n");
                                    break;
                                }
                            }
                }
                for (int i = 0; i < myObject.remarksList.Count; i++)
                {
                    if (!string.IsNullOrEmpty(myObject.remarksList[i].segmentNumber) &&
                        myObject.remarksList[i].segmentNumber == myObject.listItineraryInfo[j].segment)
                        informationDIX = string.Concat(informationDIX,
                            "          ",
                            myObject.remarksList[i].remark, "\n");
                }
            }
            catch
            {
                status = false;
            }
        }

        /// <summary>
        /// Obtiene información de los segmentos de auto
        /// </summary>
        /// <param name="i">indice del segmento en su respectiva lista</param>
        private void BuildCarInformation(int i)
        {
            try
            {
                string dayOfWeek = string.Empty;
                List<ListItem> cityCarRent = CatCitiesBL.GetCities(myObject.autoList[i].locationCode);
                myObject.autoList[i].locationCode = cityCarRent[0].Text.Substring(4, cityCarRent[0].Text.Length - 4);
                myObject.autoList[i].vendorCode = GetCatCarVenCodNameBL.GetCatCarVenCodName(myObject.autoList[i].vendorCode);
                myObject.autoList[i].equipType = GetCatCarTypCodDescriptionBL.GetCatCarTypCodDescription(myObject.autoList[i].equipType);
                if (!string.IsNullOrEmpty(myObject.autoList[i].specialEquip))
                    myObject.autoList[i].specialEquip = GetCatCarEquCodNameBL.GetCatCarEquCodName(myObject.autoList[i].specialEquip);
                if (myObject.autoList[i].dateRent.DayOfWeek.ToString() == "Sunday")
                    dayOfWeek = "Domingo";
                else if (myObject.autoList[i].dateRent.DayOfWeek.ToString() == "Monday")
                    dayOfWeek = "Lunes";
                else if (myObject.autoList[i].dateRent.DayOfWeek.ToString() == "Tuesday")
                    dayOfWeek = "Martes";
                else if (myObject.autoList[i].dateRent.DayOfWeek.ToString() == "Wednesday")
                    dayOfWeek = "Miercoles";
                else if (myObject.autoList[i].dateRent.DayOfWeek.ToString() == "Thursday")
                    dayOfWeek = "Jueves";
                else if (myObject.autoList[i].dateRent.DayOfWeek.ToString() == "Friday")
                    dayOfWeek = "Viernes";
                else if (myObject.autoList[i].dateRent.DayOfWeek.ToString() == "Saturday")
                    dayOfWeek = "Sabado";
                if (myObject.autoList[i].dateRent.ToString("dd-MMM-yyyy").ToUpper() != dateSegmnet)
                    informationDIX = string.Concat(informationDIX, "\n", myObject.autoList[i].dateRent.ToString("dd-MMM-yyyy").ToUpper(),
                        "  -  ", dayOfWeek.ToUpper(), "\n");
                dateSegmnet = myObject.autoList[i].dateRent.ToString("dd-MMM-yyyy").ToUpper();
                informationDIX = string.Concat(informationDIX,
                    "  AUTO    ",
                    myObject.autoList[i].locationCode.PadRight(28, ' '),
                    myObject.autoList[i].vendorCode.Trim().PadRight(28, ' '),
                    (!string.IsNullOrEmpty(myObject.autoList[i].corporateID)) ? "ID EMPRESA-" + myObject.autoList[i].corporateID : "", "\n");
                if (!string.IsNullOrEmpty(myObject.autoList[i].hourStart))
                    informationDIX = string.Concat(informationDIX,
                        "          RECOGER-", myObject.autoList[i].hourStart.PadRight(20, ' '),
                        myObject.autoList[i].equipType, "\n");
                else
                    informationDIX = string.Concat(informationDIX,
                        "                                        ",
                        myObject.autoList[i].equipType, "\n");
                informationDIX = string.Concat(informationDIX,
                    "          DEVOLVER-",
                    myObject.autoList[i].dateReturnCar.PadRight(19, ' '),
                    (!string.IsNullOrEmpty(myObject.autoList[i].clientID) ? myObject.autoList[i].clientID : ""), "\n");
                informationDIX = string.Concat(informationDIX,
                    "          LLEGADA GARANTIZADA", "\n");
                informationDIX = string.Concat(informationDIX,
                    "          TARIFA-".PadRight(39, ' '),
                    myObject.autoList[i].mileage.PadRight(26, ' '),
                    (!string.IsNullOrEmpty(myObject.autoList[i].kilometraje)) ? myObject.autoList[i].kilometraje.Substring(0, myObject.autoList[i].kilometraje.Length - 3) + " KILOMETRAJE ILIMITADO" : string.Empty, "\n");
                informationDIX = string.Concat(informationDIX,
                    "          DIA EXTRA-".PadRight(38, ' '),
                    "KM/MI GRATIS ".PadRight(28, ' '),
                    myObject.autoList[i].amount1, "\n");
                informationDIX = string.Concat(informationDIX,
                    "          HORA EXTRA-".PadRight(38, ' '),
                    "POR KM/MI".PadRight(28, ' '),
                    myObject.autoList[i].amount2, "\n");
                if (!string.IsNullOrEmpty(myObject.autoList[i].specialEquip))
                    informationDIX = string.Concat(informationDIX,
                        "          ",
                        myObject.autoList[i].specialEquip, "\n");
                informationDIX = string.Concat(informationDIX,
                    "          NUM. DE CONFIRMACION".PadRight(38, ' '),
                    myObject.autoList[i].confirmationNumber, "\n");
                if (!string.IsNullOrEmpty(myObject.autoList[i].phoneNumber))
                    informationDIX = string.Concat(informationDIX,
                        "          LLAME AL ",
                        myObject.autoList[i].phoneNumber, "\n");
                if (!string.IsNullOrEmpty(myObject.autoList[i].passengerName))
                    informationDIX = string.Concat(informationDIX,
                        "          RESP PARA: ",
                        myObject.autoList[i].passengerName, "\n");
            }
            catch
            {
                status = false;
            }                        
        }

        /// <summary>
        /// Obtiene informacion de los segmentos de hotel
        /// </summary>
        /// <param name="i">indice del segmento en su respectiva list</param>
        private void BuildHotelInformation(int i)
        {
            try
            {
                string dayOfWeek = string.Empty;
                List<ListItem> cityHotel = CatCitiesBL.GetCities(myObject.hotelList[i].hotelCityCode);
                List<ListItem> codeHotel = CatHotelsBL.GetHotels_Predictive(myObject.hotelList[i].chainCode);
                myObject.hotelList[i].hotelCityCode = cityHotel[0].Text.Substring(4, cityHotel[0].Text.Length - 4);
                myObject.hotelList[i].chainCode = codeHotel[0].Text2;
                if (myObject.hotelList[i].startDate.DayOfWeek.ToString() == "Sunday")
                    dayOfWeek = "Domingo";
                else if (myObject.hotelList[i].startDate.DayOfWeek.ToString() == "Monday")
                    dayOfWeek = "Lunes";
                else if (myObject.hotelList[i].startDate.DayOfWeek.ToString() == "Tuesday")
                    dayOfWeek = "Martes";
                else if (myObject.hotelList[i].startDate.DayOfWeek.ToString() == "Wednesday")
                    dayOfWeek = "Miercoles";
                else if (myObject.hotelList[i].startDate.DayOfWeek.ToString() == "Thursday")
                    dayOfWeek = "Jueves";
                else if (myObject.hotelList[i].startDate.DayOfWeek.ToString() == "Friday")
                    dayOfWeek = "Viernes";
                else if (myObject.hotelList[i].startDate.DayOfWeek.ToString() == "Saturday")
                    dayOfWeek = "Sabado";
                if (myObject.hotelList[i].startDate.ToString("dd-MMM-yyyy").ToUpper() != dateSegmnet)
                    informationDIX = string.Concat(informationDIX, "\n",
                        myObject.hotelList[i].startDate.ToString("dd-MMM-yyyy").ToUpper(),
                        "  -  ",
                        dayOfWeek, "\n");
                dateSegmnet = myObject.hotelList[i].startDate.ToString("dd-MMM-yyyy").ToUpper();
                informationDIX = string.Concat(informationDIX,
                    "  HOTEL   ", myObject.hotelList[i].hotelCityCode.PadRight(35, ' '),
                    "SALIDA-",
                    myObject.hotelList[i].endDate, "\n");
                informationDIX = string.Concat(informationDIX,
                    "          ",
                    myObject.hotelList[i].chainCode.PadRight(35, ' '),
                    myObject.hotelList[i].duration,
                    " NOCHES", "\n");
                informationDIX = string.Concat(informationDIX,
                    "          ",
                    myObject.hotelList[i].hotelName.PadRight(35, ' '),
                    myObject.hotelList[i].roomNumbers,
                    (Convert.ToInt32(myObject.hotelList[i].roomNumbers) > 1) ? " HABITACIONES" : " HABITACION", "\n");
                for (int j = 0; j < myObject.hotelList[i].address.Count; j++)
                {
                    if (j == 0)
                        informationDIX = string.Concat(informationDIX,
                            "          ",
                            myObject.hotelList[i].address[j].PadRight(35, ' '),
                            myObject.hotelList[i].shortText, "\n");
                    else if (j == 1)
                        informationDIX = string.Concat(informationDIX,
                            "          ",
                            myObject.hotelList[i].address[j].PadRight(35, ' '),
                            "TARIFA-",
                            (string.IsNullOrEmpty(myObject.hotelList[i].textAmount) ? myObject.hotelList[i].amount : myObject.hotelList[i].textAmount),
                            (!string.IsNullOrEmpty(myObject.hotelList[i].correncyCode)) ? myObject.hotelList[i].correncyCode + " POR NOCHE" : " POR NOCHE", "\n");
                    else if (j == 2 && !string.IsNullOrEmpty(myObject.hotelList[i].daysBeforeCancel))
                        informationDIX = string.Concat(informationDIX,
                            "          ",
                            myObject.hotelList[i].address[j].PadRight(35, ' '),
                            "CANCELAR ",
                            myObject.hotelList[i].daysBeforeCancel.Substring(0, 2),
                            (myObject.hotelList[i].daysBeforeCancel.Substring(2, 1) == "H") ? " HORAS ANTES DE LA LLEGADA" : " DIAS ANTES DE LA LLEGADA", "\n");
                    else
                        informationDIX = string.Concat(informationDIX,
                            "          ",
                            myObject.hotelList[i].address[j], "\n");
                }
                if (myObject.hotelList[i].address.Count == 0)
                {
                    informationDIX = string.Concat(informationDIX,
                            "          ".PadRight(45, ' '),
                            myObject.hotelList[i].shortText, "\n");
                    informationDIX = string.Concat(informationDIX,
                        "          ".PadRight(45, ' '),
                        "TARIFA-",
                        (string.IsNullOrEmpty(myObject.hotelList[i].textAmount) ? myObject.hotelList[i].amount : myObject.hotelList[i].textAmount),
                        (!string.IsNullOrEmpty(myObject.hotelList[i].correncyCode)) ? myObject.hotelList[i].correncyCode + " POR NOCHE" : " POR NOCHE", "\n");
                    if (!string.IsNullOrEmpty(myObject.hotelList[i].daysBeforeCancel))
                        informationDIX = string.Concat(informationDIX,
                                "          ".PadRight(45, ' '),
                                "CANCELAR ",
                                myObject.hotelList[i].daysBeforeCancel.Substring(0, 2),
                                (myObject.hotelList[i].daysBeforeCancel.Substring(2, 1) == "H") ? " HORAS ANTES DE LA LLEGADA" : " DIAS ANTES DE LA LLEGADA", "\n");
                }
                if (myObject.hotelList[i].address.Count == 1)
                {
                    informationDIX = string.Concat(informationDIX,
                       "          ".PadRight(45, ' '),
                       "TARIFA-",
                       (string.IsNullOrEmpty(myObject.hotelList[i].textAmount) ? myObject.hotelList[i].amount : myObject.hotelList[i].textAmount),
                       (!string.IsNullOrEmpty(myObject.hotelList[i].correncyCode)) ? myObject.hotelList[i].correncyCode + " POR NOCHE" : " POR NOCHE", "\n");
                    if (!string.IsNullOrEmpty(myObject.hotelList[i].daysBeforeCancel))
                        informationDIX = string.Concat(informationDIX,
                                "          ".PadRight(45, ' '),
                                "CANCELAR ",
                                myObject.hotelList[i].daysBeforeCancel.Substring(0, 2),
                               (myObject.hotelList[i].daysBeforeCancel.Substring(2, 1) == "H") ? " HORAS ANTES DE LA LLEGADA" : " DIAS ANTES DE LA LLEGADA", "\n");
                }
                if (myObject.hotelList[i].address.Count == 2
                    && !string.IsNullOrEmpty(myObject.hotelList[i].daysBeforeCancel))
                {
                    informationDIX = string.Concat(informationDIX,
                                "          ".PadRight(45, ' '),
                                "CANCELAR ",
                                myObject.hotelList[i].daysBeforeCancel.Substring(0, 2),
                                (myObject.hotelList[i].daysBeforeCancel.Substring(2, 1) == "H") ? " HORAS ANTES DE LA LLEGADA" : " DIAS ANTES DE LA LLEGADA", "\n");
                }
                if (!string.IsNullOrEmpty(myObject.hotelList[i].phone))
                    informationDIX = string.Concat(informationDIX,
                        "          ",
                        myObject.hotelList[i].phone, "\n");
                if (!string.IsNullOrEmpty(myObject.hotelList[i].fax))
                    informationDIX = string.Concat(informationDIX,
                        "          ",
                        myObject.hotelList[i].fax, "\n");
                informationDIX = string.Concat(informationDIX,
                    "          LLEGADA GARANTIZADA", "\n");
                if (!string.IsNullOrEmpty(myObject.hotelList[i].confirmationNumber))
                    informationDIX = string.Concat(informationDIX,
                        "          CONFIRMACION ",
                        myObject.hotelList[i].confirmationNumber, "\n");
                if (!string.IsNullOrEmpty(myObject.hotelList[i].specialPrefs))
                    informationDIX = string.Concat(informationDIX,
                        "          ",
                        myObject.hotelList[i].specialPrefs, "\n");
            }
            catch
            {
                status = false;
            }
        }

        /// <summary>
        /// Armado del archivo TXT que se muestra al usuario
        /// </summary>
        /// <param name="text">Texton que se el muestra aln usuario</param>
        private void BuildTXT(string text)
        {
            try
            {
                Microsoft.VisualBasic.Devices.Computer MyComputer = new Microsoft.VisualBasic.Devices.Computer();
                string fileName = string.Empty;
                fileName = MyComputer.FileSystem.SpecialDirectories.Temp;
                fileName = fileName + string.Format("\\TempFile_{0}.txt", Guid.NewGuid().ToString());
                using (StreamWriter x = File.AppendText(fileName))
                {

                    string[] linesToWrite = text.Split(new char[] { '\n' });
                    foreach (string line in linesToWrite)
                    {
                        x.WriteLine(line);
                    }
                    x.Flush();
                    x.Close();
                }
                Process.Start("notepad", fileName);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
            catch
            {
                MessageBox.Show("ERROR EN LA ESCRITURA DEL RECORD, FAVOR DE REPORTARLO A SISTEMAS", Resources.Constants.MYCTS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loader.AddToPanel(Loader.Zone.Middle, this, Resources.Constants.UCWELCOME);
            }
        }

        /// <summary>
        /// Cambia el foco cuando la caja de texto esta llena
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPNR_TextChanged(object sender, EventArgs e)
        {
            if (txtPNR.TextLength == txtPNR.MaxLength)
                btnAccept.Focus();
        }

        #endregion //Methods Class

    }
}
