using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Services.Contracts;
using System.Text.RegularExpressions;
#if (VOLARIS_PRODUCTION)
using ClipboardServices = MyCTS.Services.ClipboardService;
#else
using ClipboardServices = MyCTS.Services.ClipboardService;
#endif
using MyCTS.Business;


namespace MyCTS.Presentation
{
	public partial class ucItinerary : CustomUserControl
	{
		ClipboardServices.Itinerary itineraryPNR = new ClipboardServices.Itinerary();
		List<string[]> numSegmento = new List<string[]>();
		List<string> airline = new List<string>();
		List<string> numberFlight = new List<string>();
		List<string> classVar = new List<string>();
		List<string> dateDeparture = new List<string>();
		List<string> dateArrival = new List<string>();
		List<string> dc = new List<string>();
		List<string> departureHour = new List<string>();
		List<string> arrivalHour = new List<string>();
		List<string> arrival = new List<string>();
		List<string> departure = new List<string>();
		List<string> status = new List<string>();
		List<string> operatedBy = new List<string>();
		List<string> hotelAddress = new List<string>();
		List<string> hotelArrivalDate = new List<string>();
		List<string> hotelConfirmation = new List<string>();
		List<string> hotelDepartureDate = new List<string>();
		List<string> hotelName = new List<string>();
		List<string> hotelNumberRoom = new List<string>();
		List<string> hotelPolicies = new List<string>();
		List<string> hotelRate = new List<string>();
		List<string> hotelRoomType = new List<string>();
		List<string> hotelTelephone = new List<string>();
		List<string> carCarType = new List<string>();
		List<string> carCity = new List<string>();
		List<string> carConfirmation = new List<string>();
		List<string> carDropOffDate = new List<string>();
		List<string> carNumberCars = new List<string>();
		List<string> carPickUpDate = new List<string>();
		List<string> carRate = new List<string>();
		List<string> carRentCarName = new List<string>();

		public ucItinerary()
		{
			string sabreAnswer = string.Empty;
			using (CommandsAPI objCommand = new CommandsAPI())
			{
				sabreAnswer = objCommand.SendReceive("OIATH", 0, 0);
			}
			if (sabreAnswer.Contains("SIGN IN"))
			{
				MessageBox.Show("Debe de iniciar sesión para continuar.", "Sesión cerrada.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Form frm = Application.OpenForms["frmItinerary"];
				if (frm != null)
				{
					InsertLogClipboardCTSBL.InsertLogClipboardCTS(DateTime.Now, Login.Agent, 2, null);
					CloseForm(frm);
				}
			}
			else if (string.IsNullOrEmpty(sabreAnswer) || sabreAnswer.Trim() == "NO DATA")
			{
				MessageBox.Show("Es necesario tener Segmentos Vendidos o un PNR abierto.", "No hay segmentos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Form frm = Application.OpenForms["frmItinerary"];
				if (frm != null)
				{
					InsertLogClipboardCTSBL.InsertLogClipboardCTS(DateTime.Now, Login.Agent, 2, null);
					CloseForm(frm);
				}
			}
			else if (sabreAnswer.Trim() == "NOTHING")
			{
				MessageBox.Show("Se ha perdido la conexion entre MySAbre y MyCTS. Por favor, cierre y vuelva a abrir la aplicación.", "Conexion perdida.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Form frm = Application.OpenForms["frmItinerary"];
				if (frm != null)
				{
					InsertLogClipboardCTSBL.InsertLogClipboardCTS(DateTime.Now, Login.Agent, 2, null);
					CloseForm(frm);
				}
			}
			else if (sabreAnswer.Trim() == "UTL PNR")
			{
				MessageBox.Show("Por favor verifique que el PNR sea correcto.", "PNR Inexistente.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Form frm = Application.OpenForms["frmItinerary"];
				if (frm != null)
				{
					InsertLogClipboardCTSBL.InsertLogClipboardCTS(DateTime.Now, Login.Agent, 2, null);
					CloseForm(frm);
				}
			}
			else
			{
				string sessionId = sabreAnswer.Replace("ATH:", string.Empty).Replace("\n", string.Empty).Trim();

				ClipboardService service = new ClipboardService();
				itineraryPNR = service.CopyReportModified(sessionId);

				frmPreloading frm = null;
				bool isError = false;
				List<string> PQs = new List<string>();
				List<string> nameRules = new List<string>();

				if (itineraryPNR.ErrorMessage != null)
				{
					isError = true;
					MessageBox.Show(itineraryPNR.ErrorMessage.Message, "Error desde el servicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Form form = Application.OpenForms["frmItinerary"];
					if (form != null)
					{
						CloseForm(form);
						InsertLogClipboardCTSBL.InsertLogClipboardCTS(DateTime.Now, Login.Agent, 2, null);
					}
				}
				else
				{
					InsertLogClipboardCTSBL.InsertLogClipboardCTS(DateTime.Now, Login.Agent, 2, itineraryPNR.Booking);
					InitializeComponent();
					frm = new frmPreloading(this);
					frm.Show();
					foreach (ClipboardServices.PaxQuote pq in itineraryPNR.PQs)
					{
						PQs.Add(string.Concat(pq.Currency, pq.Fare, '|', pq.Currency, pq.Taxes, '|', pq.Currency, pq.Total));
						foreach (string code in pq.FareBasisCode)
						{
							nameRules.Add(code.Split('|')[0]);
						}
					}
				}

				//frmPreloading frm = null;
				//bool isError = false;
				List<List<string>> rules = new List<List<string>>();
				//List<string> destinys = new List<string>();
				//List<string> fareBasisData = new List<string>();
				//List<string> nameRules = new List<string>();
				//List<string> PQs = new List<string>();
				string lastDayPurchase = string.Empty;
				//Regex regexPNR = new Regex(@"^[A-Z]{6}");
				//if (regexPNR.IsMatch(sabreAnswer.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim()))
				//{
				//    // Realizar busqueda por WS
				//    ClipboardService service = new ClipboardService();
				//    itineraryPNR = service.CopyReport(sabreAnswer.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim());
				//    if (itineraryPNR.ErrorMessage != null)
				//    {
				//        isError = true;
				//        MessageBox.Show(itineraryPNR.ErrorMessage.Message, "Error desde el servicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//        Form form = Application.OpenForms["frmItinerary"];
				//        if (form != null)
				//        {
				//            CloseForm(form);
				//        }
				//    }
				//    else
				//    {
				//        InitializeComponent();
				//        frm = new frmPreloading(this);
				//        frm.Show();
				//        foreach (MyCTS.Services.ClipboardService.PaxQuote pq in itineraryPNR.PQs)
				//        {
				//            PQs.Add(string.Concat(pq.Currency, pq.Fare, '|', pq.Currency, pq.Taxes, '|', pq.Currency, pq.Total));
				//            foreach (string code in pq.FareBasisCode)
				//            {
				//                nameRules.Add(code.Split('|')[0]);

				//                //ClipboardServiceClient client = new ClipboardServiceClient();
				//                //try
				//                //{
				//                //    client.Open();
				//                //    rules.Add(client.ExecuteSabreCommand(new List<string>() { code.Split('|')[1] })[0]);
				//                //}
				//                //catch
				//                //{
				//                //}
				//                //finally
				//                //{
				//                //    if (client.State != System.ServiceModel.CommunicationState.Closed)
				//                //    {
				//                //        client.Close();
				//                //    }
				//                //}

				//                //using (CommandsAPI objCommand = new CommandsAPI())
				//                //{
				//                //    bool isFinish = false;
				//                //    rules.Add(objCommand.SendReceive(code.Split('|')[1], 0, 0));

				//                //    while (!isFinish)
				//                //    {
				//                //        string moreRules = sabreAnswer = objCommand.SendReceive("MD", 0, 0);
				//                //        rules[rules.Count - 1] += "\n" + moreRules;

				//                //        if (moreRules.Contains("END OF SCROLL"))
				//                //        {
				//                //            isFinish = true;
				//                //        }
				//                //    }
				//                //}
				//            }
				//        }
				//    }
				//    //foreach (var item in itineraryPNR.Flights)
				//    //{

				//    //        using (CommandsAPI objCommand = new CommandsAPI())
				//    //        {
				//    //            if (!string.IsNullOrEmpty(rules))
				//    //            {
				//    //                rules += "\n";
				//    //            }

				//    //            rules += objCommand.SendReceive(string.Concat("RD", item.Departure, item.Arrival, item.DepartureDate, "ELQBG-" + item.Airline, "*06/07/15/16/35").ToUpper(), 0, 0);
				//    //        }

				//    //}
				//}
				//else
				//{
				//    InitializeComponent();
				//    frm = new frmPreloading(this);
				//    frm.Show();
				//    Regex regexAirline = new Regex("^[A-Z]{2}$");
				//    Regex regexAirlineFlight = new Regex(@"^[A-Z]{2}\d{4}[A-Z]$");
				//    Regex regexFlightClass = new Regex(@"^\d{1,3}[A-Z]$");
				//    Regex regexDate = new Regex(@"^\d{2}[A-Z]{3}$");
				//    Regex regexOriDest = new Regex(@"^[A-Z]{6}$");
				//    Regex regexOriDestAdd = new Regex(@"^[A-Z]{6}[*][A-Z]{2}\d$");
				//    Regex regexAddOriDest = new Regex(@"^\d[*][A-Z]{6}$");
				//    Regex regexHour = new Regex(@"^\d{4}$");
				//    Regex regexDC = new Regex(@"^/[A-Z]{4}$");
				//    Regex regexStatus = new Regex(@"^/[A-Z]$");
				//    Regex regexAddressHotel = new Regex(@"^[A-Z]{3}$");
				//    Regex regexArrivalDateHotel = new Regex(@"^IN\d{2}[A-Z]{3}$");
				//    Regex regexConfirmationHotel = new Regex(@"^AGT\d{8}$");
				//    Regex regexDepartureDateHotel = new Regex(@"^T-OUT\d{2}[A-Z]{3}$");
				//    Regex regexRateHotel = new Regex(@"^RR\d+.\d{2}[A-Z]{3}$");
				//    Regex regexCityCar = new Regex(@"^[A-Z]{3}$");
				//    Regex regexCarType = new Regex(@"^[A-Z]{2}$");
				//    Regex regexDateCar = new Regex(@"^\d{2}[A-Z]{3}$");
				//    Regex regexRateCar = new Regex(@"^RG-[A-Z]{3}\d+.\d{2}$");

				//    string typeSegment = string.Empty;
				//    string segmentHotel = string.Empty;
				//    bool isFinish = false;

				//    bool isNameHotel = true;
				//    //bool add = false;
				//    int indexFlight = 0;
				//    int indexCar = 0;
				//    int indexHotel = 0;
				//    do
				//    {

				//        if (sabreAnswer.Trim().Contains("END OF SCROLL") || sabreAnswer.Trim().Contains("NOTHING TO SCROLL"))
				//        {
				//            isFinish = true;
				//        }


				//        foreach (string segment in sabreAnswer.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
				//        {
				//            int rest = 0;
				//            if (typeSegment == "HOTEL")
				//            {

				//                for (int i = 0; i < segment.Split(' ').Length; i++)
				//                {
				//                    if (segment.Split(' ')[i].Contains("/"))
				//                    {
				//                        isNameHotel = false;
				//                        segmentHotel += segment.Split(' ')[i].Contains("/");
				//                        for (int j = i; j < segment.Split(' ').Length; j++)
				//                        {
				//                            segmentHotel += " " + segment.Split(' ')[i];
				//                        }
				//                        if (segment.Contains("CF-"))
				//                        {
				//                            typeSegment = string.Empty;
				//                            //Colocar valores
				//                            hotelName[hotelName.Count - 1] = hotelName[hotelName.Count - 1].Replace(hotelName[hotelName.Count - 1].Split(' ')[hotelName[hotelName.Count - 1].Split(' ').Length - 1], string.Empty).Trim();
				//                            foreach (string word in segmentHotel.Split('/'))
				//                            {
				//                                if (regexConfirmationHotel.IsMatch(word))
				//                                {
				//                                    hotelConfirmation[hotelRate.Count - 1] = word;
				//                                }
				//                                if (regexRateHotel.IsMatch(word))
				//                                {
				//                                    hotelRate[hotelRate.Count - 1] = word.Replace("RR", "");
				//                                }
				//                            }
				//                        }
				//                        break;
				//                    }
				//                    if (isNameHotel)
				//                    {
				//                        if (!string.IsNullOrEmpty(hotelName[hotelName.Count - 1]))
				//                        {
				//                            hotelName[hotelName.Count - 1] = string.Concat(hotelName[hotelName.Count - 1], " ");
				//                        }
				//                        hotelName[hotelName.Count - 1] = string.Concat(hotelName[hotelName.Count - 1], segment.Split(' ')[i]);
				//                    }
				//                    else
				//                    {
				//                        segmentHotel += " " + segment.Split(' ')[i];
				//                    }
				//                }
				//            }
				//            else if (typeSegment == "CAR")
				//            {
				//                foreach (string words in segment.Split(' '))
				//                {
				//                    foreach (string word in words.Split('/'))
				//                    {
				//                        if (regexRateCar.IsMatch(word))
				//                        {
				//                            carRate[carRate.Count - 1] = word.Replace("RG-", string.Empty);
				//                        }
				//                    }
				//                }
				//            }

				//            if (int.TryParse(segment.Trim().Split(' ')[0], out rest))
				//            {
				//                if (segment.Contains(" HHL "))
				//                {
				//                    numSegmento.Add(new string[] { segment.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0], "HOTEL", (indexHotel++).ToString() });

				//                    hotelAddress.Add(string.Empty);
				//                    hotelArrivalDate.Add(string.Empty);
				//                    hotelConfirmation.Add(string.Empty);
				//                    hotelDepartureDate.Add(string.Empty);
				//                    hotelName.Add(string.Empty);
				//                    hotelNumberRoom.Add(string.Empty);
				//                    hotelPolicies.Add(string.Empty);
				//                    hotelRate.Add(string.Empty);
				//                    hotelRoomType.Add(string.Empty);
				//                    hotelTelephone.Add(string.Empty);

				//                    typeSegment = "HOTEL";
				//                    hotelAddress[hotelAddress.Count - 1] = segment.Trim().Split(' ')[5];
				//                    hotelArrivalDate[hotelArrivalDate.Count - 1] = segment.Trim().Split(' ')[6].Replace("IN", string.Empty);

				//                    hotelDepartureDate[hotelDepartureDate.Count - 1] = segment.Trim().Split(' ')[7].Substring(segment.Trim().Split(' ')[7].IndexOf("OUT")).Replace("OUT", string.Empty);

				//                    for (int i = 14; i < segment.Trim().Split(' ').Length; i++)
				//                    {
				//                        if (!string.IsNullOrEmpty(hotelName[hotelName.Count - 1]))
				//                        {
				//                            hotelName[hotelName.Count - 1] = string.Concat(hotelName[hotelName.Count - 1], " ");
				//                        }
				//                        hotelName[hotelName.Count - 1] = string.Concat(hotelName[hotelName.Count - 1], segment.Trim().Split(' ')[i]);
				//                    }

				//                }
				//                else if (segment.Trim().Contains(" CAR "))
				//                {
				//                    typeSegment = "CAR";
				//                    numSegmento.Add(new string[] { segment.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0], "CAR", (indexCar++).ToString() });
				//                    carCarType.Add(string.Empty);
				//                    carCity.Add(string.Empty);
				//                    carConfirmation.Add(string.Empty);
				//                    carDropOffDate.Add(string.Empty);
				//                    carNumberCars.Add(string.Empty);
				//                    carPickUpDate.Add(string.Empty);
				//                    carRate.Add(string.Empty);
				//                    carRentCarName.Add(string.Empty);

				//                    Car car = new Car();
				//                    carCarType[carCarType.Count - 1] = segment.Trim().Split(' ')[3];
				//                    carCity[carCity.Count - 1] = segment.Trim().Split(' ')[8].Substring(0, 3);
				//                    carConfirmation[carConfirmation.Count - 1] = string.Empty;
				//                    carDropOffDate[carDropOffDate.Count - 1] = string.Concat(segment.Trim().Split(' ')[8].Split('/')[1], " ", segment.Trim().Split(' ')[8].Split('/')[4].Replace("RET-", string.Empty).Insert(2, ":"));
				//                    carNumberCars[carNumberCars.Count - 1] = string.Empty;
				//                    carPickUpDate[carPickUpDate.Count - 1] = string.Concat(segment.Trim().Split(' ')[4], " ", segment.Trim().Split(' ')[8].Split('/')[3].Replace("ARR-", string.Empty).Insert(2, ":"));
				//                    carRentCarName[carRentCarName.Count - 1] = segment.Trim().Split(' ')[8].Split('/')[2];
				//                }
				//                else if (segment.Trim().Contains("ARNK"))
				//                {
				//                }
				//                else if (segment.Contains("SEGMENTO DE PROTECCION"))
				//                {
				//                }
				//                else if (segment.Contains("/GAX") && !segment.Contains(" /GAX"))
				//                {
				//                }
				//                else if (segment.Contains("/GVI") && !segment.Contains(" /GVI"))
				//                {
				//                }
				//                else if (segment.Contains("/GCA") && !segment.Contains(" /GCA"))
				//                {
				//                }
				//                else if (segment.Contains("/DAX") && !segment.Contains(" /DAX"))
				//                {
				//                }
				//                else if (segment.Contains("/DVI") && !segment.Contains(" /DVI"))
				//                {
				//                }
				//                else if (segment.Contains("/DCA") && !segment.Contains(" /DCA"))
				//                {
				//                }
				//                else
				//                {
				//                    typeSegment = string.Empty;
				//                    bool IsDepartureHour = true;
				//                    bool IsDepartureDate = true;
				//                    numSegmento.Add(new string[] { segment.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0], "AIR", (indexFlight++).ToString() });
				//                    airline.Add(string.Empty);
				//                    numberFlight.Add(string.Empty);
				//                    classVar.Add(string.Empty);
				//                    dateDeparture.Add(string.Empty);
				//                    dateArrival.Add(string.Empty);
				//                    dc.Add(string.Empty);
				//                    departureHour.Add(string.Empty);
				//                    arrivalHour.Add(string.Empty);
				//                    arrival.Add(string.Empty);
				//                    departure.Add(string.Empty);
				//                    status.Add(string.Empty);
				//                    operatedBy.Add(string.Empty);

				//                    for (int i = 1; i < segment.Trim().Split(' ').Length; i++)
				//                    {

				//                        if (regexAirline.IsMatch(segment.Trim().Split(' ')[i]))
				//                        {
				//                            airline[airline.Count - 1] = segment.Trim().Split(' ')[i];
				//                        }
				//                        else if (regexAirlineFlight.IsMatch(segment.Trim().Split(' ')[i]))
				//                        {
				//                            airline[airline.Count - 1] = segment.Trim().Split(' ')[i].Substring(0, 2);
				//                            numberFlight[numberFlight.Count - 1] = segment.Trim().Split(' ')[i].Substring(2, 4);
				//                            classVar[classVar.Count - 1] = segment.Trim().Split(' ')[i].Substring(6, 1);
				//                        }
				//                        else if (regexDate.IsMatch(segment.Trim().Split(' ')[i]))
				//                        {
				//                            if (IsDepartureDate)
				//                            {
				//                                dateDeparture[dateDeparture.Count - 1] = DateTime.ParseExact(segment.Trim().Split(' ')[i], "ddMMM", System.Globalization.CultureInfo.InvariantCulture).ToString("ddd dd MMM", new System.Globalization.CultureInfo("en-US"));
				//                                IsDepartureDate = false;
				//                            }
				//                            else
				//                            {
				//                                dateArrival[dateArrival.Count - 1] = DateTime.ParseExact(segment.Trim().Split(' ')[i], "ddMMM", System.Globalization.CultureInfo.InvariantCulture).ToString("ddd dd MMM", new System.Globalization.CultureInfo("en-US"));
				//                                IsDepartureDate = true;
				//                            }
				//                        }
				//                        else if (regexDC.IsMatch(segment.Trim().Split(' ')[i]))
				//                        {
				//                            dc[dc.Count - 1] = segment.Trim().Split(' ')[i];
				//                        }
				//                        else if (regexFlightClass.IsMatch(segment.Trim().Split(' ')[i]))
				//                        {
				//                            numberFlight[numberFlight.Count - 1] = segment.Trim().Split(' ')[i].Remove(segment.Trim().Split(' ')[i].Length - 1);
				//                            classVar[classVar.Count - 1] = segment.Trim().Split(' ')[i].Substring(segment.Trim().Split(' ')[i].Length - 1);
				//                        }
				//                        else if (regexHour.IsMatch(segment.Trim().Split(' ')[i]))
				//                        {
				//                            if (IsDepartureHour)
				//                            {
				//                                departureHour[departureHour.Count - 1] = string.Concat(segment.Trim().Split(' ')[i].Substring(0, 2), ":", segment.Trim().Split(' ')[i].Substring(2, 2));
				//                                IsDepartureHour = false;
				//                            }
				//                            else
				//                            {
				//                                arrivalHour[arrivalHour.Count - 1] = string.Concat(segment.Trim().Split(' ')[i].Substring(0, 2), ":", segment.Trim().Split(' ')[i].Substring(2, 2));
				//                                IsDepartureHour = true;
				//                            }
				//                        }
				//                        else if (regexOriDest.IsMatch(segment.Trim().Split(' ')[i]))
				//                        {
				//                            //add = true;
				//                            departure[departure.Count - 1] = segment.Trim().Split(' ')[i].Substring(0, 3);
				//                            arrival[arrival.Count - 1] = segment.Trim().Split(' ')[i].Substring(3, 3);
				//                        }
				//                        else if (regexOriDestAdd.IsMatch(segment.Trim().Split(' ')[i]))
				//                        {
				//                            //add = true;
				//                            departure[departure.Count - 1] = segment.Trim().Split(' ')[i].Substring(0, 3);
				//                            arrival[arrival.Count - 1] = segment.Trim().Split(' ')[i].Substring(3, 3);
				//                        }
				//                        else if (regexAddOriDest.IsMatch(segment.Trim().Split(' ')[i]))
				//                        {
				//                            departure[departure.Count - 1] = segment.Trim().Split(' ')[i].Substring(2, 3);
				//                            arrival[arrival.Count - 1] = segment.Trim().Split(' ')[i].Substring(5, 3);
				//                        }
				//                        else if (regexStatus.IsMatch(segment.Trim().Split(' ')[i]))
				//                        {
				//                            status[status.Count - 1] = segment.Trim().Split(' ')[i];
				//                        }
				//                    }
				//                }
				//            }

				//            //if (add)
				//            //{
				//            //    add = false;
				//            //    using (CommandsAPI objCommand = new CommandsAPI())
				//            //    {
				//            //        if (!string.IsNullOrEmpty(rules))
				//            //        {
				//            //            rules += "\n";
				//            //        }

				//            //        rules += objCommand.SendReceive(string.Concat("RD", departure[departure.Count - 1], arrival[arrival.Count - 1], DateTime.ParseExact(dateDeparture[dateDeparture.Count - 1], "ddd dd MMM", new System.Globalization.CultureInfo("en-US")).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")), "ELQBG-" + airline[airline.Count - 1], "*06/07/15/16/35").ToUpper(), 0, 0);
				//            //    }
				//            //}
				//        }

				//        using (CommandsAPI objCommand = new CommandsAPI())
				//        {
				//            sabreAnswer = objCommand.SendReceive("MD", 0, 0);
				//        }
				//    } while (!isFinish);

				//    using (CommandsAPI objCommand = new CommandsAPI())
				//    {
				//        objCommand.SendReceive("PQ", 0, 0);
				//        sabreAnswer = objCommand.SendReceive("*PQ", 0, 0);
				//    }
				//    //List<string> PQs = new List<string>();
				//    //string lastDayPurchase = string.Empty;
				//    Regex regexFare = new Regex(@"[\w]+(\dEND)$");
				//    Regex regexNumber = new Regex(@"^\d{2}$");
				//    Regex regexFareBasis = new Regex(@"^\d{2}[ ]([O]|[X])[ ]([A-Z]|[0-9]|[ ])+[‡]*$");
				//    if (!sabreAnswer.Trim().Contains("NO PQ RECORD SUMMARY"))
				//    {
				//        if (sabreAnswer.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim() != "NO NAMES")
				//        {
				//        }
				//        int countPQ = 8;
				//        bool isEnd = false;
				//        int countMD = 1;

				//        do
				//        {
				//            List<string> typeFare = new List<string>();
				//            string origin = string.Empty;
				//            string destiny = string.Empty;
				//            foreach (string pq in sabreAnswer.Replace("‡", "\n").Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
				//            {


				//                if (pq.Trim().Contains("END OF SCROLL") || pq.Trim().Contains("NOTHING TO SCROLL"))
				//                {
				//                    isEnd = true;
				//                    break;
				//                }
				//                if (pq.Trim().StartsWith("BASE FARE"))
				//                {
				//                    countPQ = 1;
				//                }
				//                if (countPQ == 2)
				//                {
				//                    if (pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length == 3)
				//                    {
				//                        PQs.Add(
				//                            string.Concat(pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0], "|",
				//                            pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("XT", ""), "|",
				//                            pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2].Replace("ADT", ""))
				//                            );
				//                    }
				//                    else if (pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length == 4)
				//                    {
				//                        PQs.Add(
				//                            string.Concat(pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1], "|",
				//                            pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2].Replace("XT", ""), "|",
				//                            pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3].Replace("ADT", ""))
				//                            );
				//                    }
				//                }


				//                if (regexFareBasis.IsMatch(pq.Trim()) && pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1] != "X")
				//                {
				//                    destinys.Add(pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2]);
				//                    fareBasisData.Add(string.Concat(pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5], "|", pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7], "|", pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3]));
				//                }
				//                else if (new Regex(@"^[A-Z]{3}$").IsMatch(pq.Trim()))
				//                {
				//                    destinys.Add(pq.Trim());

				//                    rules.Add(new List<string>());
				//                    for (int i = 0; i < fareBasisData.Count; i++)
				//                    {
				//                        rules[rules.Count - 1].Add(
				//                            string.Concat(
				//                            string.Concat(fareBasisData[i].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries)[1], " - ",
				//                            destinys[i],
				//                            destinys[i + 1]),
				//                            "|",
				//                            string.Concat("RD", destinys[i], destinys[i + 1], fareBasisData[i].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries)[0], fareBasisData[i].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries)[1], "-" + fareBasisData[i].Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries)[2], "*06/07/15/16/35")
				//                            ));
				//                    }
				//                    destinys = new List<string>();
				//                    fareBasisData = new List<string>();
				//                }

				//                //if (!string.IsNullOrEmpty(pq.Trim()))
				//                //{
				//                //    foreach (string find in pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries))
				//                //    {
				//                //        if (regexFare.IsMatch(find))
				//                //        {
				//                //            origin = pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].Substring(0, 3);
				//                //            destiny = pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2].Substring(0, 3);
				//                //        }
				//                //    }
				//                //}

				//                if (pq.Contains("LAST DAY TO PURCHASE"))
				//                {
				//                    lastDayPurchase = pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//                }

				//                //foreach (string rule in typeFare)
				//                //{
				//                //    if (pq.Trim().Contains(rule))
				//                //    {
				//                //        ClipboardServiceClient client = new ClipboardServiceClient();

				//                //        try
				//                //        {
				//                //            client.Open();
				//                //            rules.Add(client.ExecuteSabreCommand(new List<string>() { string.Concat("RD", origin, destiny, pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length - 2].Substring(0, 5), rule, "-" + pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3].Substring(0, 2), "*06/07/15/16/35").ToUpper() })[0]);
				//                //            if (pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2] == origin)
				//                //            {
				//                //                nameRules.Add(string.Concat(rule, " - ", origin, destiny));
				//                //            }
				//                //            else
				//                //            {
				//                //                nameRules.Add(string.Concat(rule, " - ", destiny, origin));
				//                //            }
				//                //        }
				//                //        catch
				//                //        {
				//                //        }
				//                //        finally
				//                //        {
				//                //            if (client.State != System.ServiceModel.CommunicationState.Closed)
				//                //            {
				//                //                client.Close();
				//                //            }
				//                //        }
				//                //        //using (CommandsAPI objCommand = new CommandsAPI())
				//                //        //{
				//                //        //    bool isFinish = false;
				//                //        //    rules.Add(objCommand.SendReceive(string.Concat("RD", origin, destiny, pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length - 2].Substring(0, 5), rule, "-" + pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3].Substring(0, 2), "*06/07/15/16/35").ToUpper(), 0, 0));
				//                //        //    while (!isFinish)
				//                //        //    {
				//                //        //        string moreRules = sabreAnswer = objCommand.SendReceive("MD", 0, 0);
				//                //        //        rules[rules.Count - 1] += "\n" + moreRules;
				//                //        //        if (moreRules.Contains("END OF SCROLL"))
				//                //        //        {
				//                //        //            rules[rules.Count - 1].Replace("‡END OF SCROLL‡", string.Empty);

				//                //        //            isFinish = true;
				//                //        //        }
				//                //        //    }
				//                //        //    if (pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2] == origin)
				//                //        //    {
				//                //        //        nameRules.Add(string.Concat(rule, " - ", origin, destiny));
				//                //        //    }
				//                //        //    else
				//                //        //    {
				//                //        //        nameRules.Add(string.Concat(rule, " - ", destiny, origin));
				//                //        //    }

				//                //        //}
				//                //        break;
				//                //    }
				//                //}

				//                if (pq.Contains("ADT-01"))
				//                {
				//                    foreach (string rule in pq.Replace("ADT-01", "").Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries))
				//                    {
				//                        typeFare.Add(rule);
				//                    }
				//                }
				//                countPQ++;
				//            }
				//            if (!isEnd)
				//            {
				//                using (CommandsAPI objCommand = new CommandsAPI())
				//                {
				//                    objCommand.SendReceive("*PQ", 0, 0);
				//                    for (int i = 0; i < countMD; i++)
				//                    {
				//                        sabreAnswer = objCommand.SendReceive("MD", 0, 0);
				//                    }
				//                    countMD++;
				//                }
				//            }
				//        } while (!isEnd);
				//    }

				//}
				if (!isError)
				{
					#region busqueda de PQ y ultimo dia de compra
					/*
                using (CommandsAPI objCommand = new CommandsAPI())
                {
                    objCommand.SendReceive("PQ", 0, 0);
                    sabreAnswer = objCommand.SendReceive("*PQ", 0, 0);
                }
                List<string> PQs = new List<string>();
                string lastDayPurchase = string.Empty;
                Regex regexFare = new Regex(@"^[\w]+(\dEND)$");
                Regex regexNumber = new Regex(@"^\d{2}$");
                if (!sabreAnswer.Trim().Contains("NO PQ RECORD SUMMARY"))
                {
                    if (sabreAnswer.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim() != "NO NAMES")
                    {
                    }
                    int countPQ = 8;
                    bool isEnd = false;
                    int countMD = 1;
                    do
                    {
                        List<string> typeFare = new List<string>();
                        string origin = string.Empty;
                        string destiny = string.Empty;
                        foreach (string pq in sabreAnswer.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (pq.Trim().Contains("END OF SCROLL") || pq.Trim().Contains("NOTHING TO SCROLL"))
                            {
                                isEnd = true;
                                break;
                            }
                            if (pq.Trim().StartsWith("BASE FARE"))
                            {
                                countPQ = 1;
                            }
                            if (countPQ == 2)
                            {
                                if (pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length == 3)
                                {
                                    PQs.Add(
                                        string.Concat(pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].Replace("MXN", ""), "|",
                                        pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("XT", ""), "|",
                                        pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2].Replace("MXN", "").Replace("ADT", ""))
                                        );
                                }
                                else if (pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length == 4)
                                {
                                    PQs.Add(
                                        string.Concat(pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("MXN", ""), "|",
                                        pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2].Replace("XT", ""), "|",
                                        pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3].Replace("MXN", "").Replace("ADT", ""))
                                        );
                                }
                            }
                            if (!string.IsNullOrEmpty(pq.Trim()))
                            {
                                if (regexFare.IsMatch(pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length - 1].Trim()))
                                {
                                    origin = pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0];
                                    destiny = pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2];
                                }
                            }

                            if (pq.Contains("LAST DAY TO PURCHASE"))
                            {
                                lastDayPurchase = pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
                            }

                            //foreach (string rule in typeFare)
                            //{
                            //    if (pq.Trim().Contains(rule))
                            //    {
                            //        using (CommandsAPI objCommand = new CommandsAPI())
                            //        {
                            //            bool isFinish = false;
                            //            rules.Add(objCommand.SendReceive(string.Concat("RD", origin, destiny, pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length - 2].Substring(0, 5), rule, "-" + pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3].Substring(0, 2), "*06/07/15/16/35").ToUpper(), 0, 0));
                            //            while (!isFinish)
                            //            {
                            //                string moreRules = sabreAnswer = objCommand.SendReceive("MD", 0, 0);
                            //                rules[rules.Count - 1] += "\n" + moreRules;
                            //                if (moreRules.Contains("END OF SCROLL"))
                            //                {
                            //                    isFinish = true;
                            //                }
                            //            }
                            //            if (pq.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2] == origin)
                            //            {
                            //                nameRules.Add(string.Concat(rule, " - ", origin, destiny));
                            //            }
                            //            else
                            //            {
                            //                nameRules.Add(string.Concat(rule, " - ", destiny, origin));
                            //            }

                            //        }
                            //        break;
                            //    }
                            //}

                            //if (pq.Contains("ADT-01"))
                            //{
                            //    foreach (string rule in pq.Replace("ADT-01", "").Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                            //    {
                            //        typeFare.Add(rule);
                            //    }
                            //}
                            countPQ++;
                        }
                        if (!isEnd)
                        {
                            using (CommandsAPI objCommand = new CommandsAPI())
                            {
                                objCommand.SendReceive("*PQ", 0, 0);
                                for (int i = 0; i < countMD; i++)
                                {
                                    sabreAnswer = objCommand.SendReceive("MD", 0, 0);
                                }
                                countMD++;
                            }
                        }
                    } while (!isEnd);
                }
                */
					#endregion
					#region html
					string html = @"<html lang=""es-MX"" xml:lang=""es-MX"" xmlns=""http://www.w3.org/1999/xhtml"">
<head>
    <meta charset=""utf-8"" />
    <title></title>
    <script language=""JavaScript""> //Common functions for all dropdowns

        /*--------------------------------------------------------------
              http://chakrabarty.com/pp_editable_dropdown.html
              http://chakrabarty.com/combobox.html
        --------------------------------------------------------------*/

        /*----------------------------------------------
        The Common functions used for all dropdowns are:
        -----------------------------------------------
      
        -- function FindKeyCode(e)
        -- function FindKeyChar(e)
        -- function fnLeftToRight(getdropdown)
        -- function fnRightToLeft(getdropdown)
      
        --------------------------- source: http://chakrabarty.com/pp_editable_dropdown.html */

        function fnLeftToRight(getdropdown) {
            getdropdown.style.direction = ""ltr"";
        }

        function fnRightToLeft(getdropdown) {
            getdropdown.style.direction = ""rtl"";
        }


        /*
        Since Internet Explorer and NetscapeFirefoxChrome have different
        ways of returning the key code, displaying keys
        browser-independently is a bit harder.
        However, you can create a script that displays keys
        for either browser.
        The following function will display each key
        in the status line:
      
        The ""FindKey.."" function receives the ""event"" object
        from the event handler and stores it in the variable ""e"".
        It checks whether the ""e.which"" property exists (for NetscapeFirefoxChrome),
        and stores it in the ""keycode"" variable if present.
        Otherwise, it assumes the browser is Internet Explorer
        and assigns to keycode the ""e.keyCode"" property.
        */

        function FindKeyCode(e) {
            if (e.which) {
                keycode = e.which;  //NetscapeFirefoxChrome
            }
            else {
                keycode = e.keyCode; //Internet Explorer
            }

            //alert(""FindKeyCode""+ keycode);
            return keycode;
        }

        function FindKeyChar(e) {
            keycode = FindKeyCode(e);
            if ((keycode == 8) || (keycode == 127)) {
                character = ""backspace""
            }
            else if ((keycode == 46)) {
                character = ""delete""
            }
            else {
                character = String.fromCharCode(keycode);
            }
            //alert(""FindKey""+ character);
            return character;
        }

</script>


<script language=""JavaScript""> //Dropdown specific functions, which manipulate dropdown specific global variables
    //for the dropdown lstDropDown_D

    /*----------------------------------------------
    Dropdown specific global variables are:
    -----------------------------------------------
    1) vEditableOptionIndex_D   --> this needs to be set by Programmer!! See explanation.
    2) vEditableOptionText_D    --> this needs to be set by Programmer!! See explanation.
    3) vUseActualTexbox_D       --> this needs to be set by Programmer!! See explanation.
    4) vPreviousSelectIndex_D
    5) vSelectIndex_D
    6) vSelectChange_D
  
    --------------------------- source: http://chakrabarty.com/pp_editable_dropdown.html */

    /*----------------------------------------------
    Dropdown specific functions
    (which manipulate dropdown specific global variables)
    -----------------------------------------------
    1) function fnChangeHandler_D(getdropdown)
    2) function fnFocusHandler_D (getdropdown)
    3) function fnKeyPressHandler_D(getdropdown, e)
    4) function fnKeyUpHandler_D(getdropdown, e)
    5) function fnKeyDownHandler_D(getdropdown, e)
  
    --------------------------- source: http://chakrabarty.com/pp_editable_dropdown.html */

    /*------------------------------------------------
    IMPORTANT: Global Variable required to be SET by programmer
    -------------------------- source: http://chakrabarty.com/pp_editable_dropdown.html  */

    var vEditableOptionIndex_D = 5;

    // Give Index of Editable option in the dropdown.
    // For eg.
    // if first option is editable then vEditableOptionIndex_D = 0;
    // if second option is editable then vEditableOptionIndex_D = 1;
    // if third option is editable then vEditableOptionIndex_D = 2;
    // if last option is editable then vEditableOptionIndex_D = (length of dropdown - 1).
    // Note: the value of vEditableOptionIndex_D cannot be greater than (length of dropdown - 1)

    var vEditableOptionText_D = ""--?--"";

    // Give the default text of the Editable option in the dropdown.
    // For eg.
    // if the editable option is <option ...>--?--</option>,
    // then set vEditableOptionText_D = ""--?--"";

    var vUseActualTexbox_D = ""no"";
    // = ""no"" ...
    //      default is 'no' because there is no need to use an actual textbox if using a PC (with physical keyboard)
    //      if using iPad/iPhone or Android device, which usually have a virtual soft keyboard, then textbox will automatically show up next to dropdown on those devices
    // = ""yes"" ...
    //      set this to 'yes' if and only if you want an actual textbox to show up next to dropdown at all times (even on devices with physical keyboards)

    /*------------------------------------------------
    Global Variables required for
    fnChangeHandler_D(), fnKeyPressHandler_D() and fnKeyUpHandler_D()
    for Editable Dropdowns
    -------------------------- source: http://chakrabarty.com/pp_editable_dropdown.html  */

    var vPreviousSelectIndex_D = 0;
    // Contains the Previously Selected Index, set to 0 by default

    var vSelectIndex_D = 0;
    // Contains the Currently Selected Index, set to 0 by default

    var vSelectChange_D = 'MANUAL_DLICK';
    // Indicates whether Change in dropdown selected option
    // was due to a Manual Click
    // or instead due to System properties of dropdown.

    // vSelectChange_D = 'MANUAL_DLICK' indicates that
    // the jump to a non-editable option in the dropdown was due
    // to a Manual click (i.e.,changed on purpose by user).

    // vSelectChange_D = 'AUTO_SYSTEM' indicates that
    // the jump to a non-editable option was due to System properties of dropdown
    // (i.e.,user did not change the option in the dropdown;
    // instead an automatic jump happened due to inbuilt
    // dropdown properties of browser on typing of a character )

    /*------------------------------------------------
    Functions required for  Editable Dropdowns
    -------------------------- source: http://chakrabarty.com/pp_editable_dropdown.html  */

    function fnSanityCheck_D(getdropdown) {
        if (vEditableOptionIndex_D > (getdropdown.options.length - 1)) {
            alert(""PROGRAMMING ERROR: The value of variable vEditableOptionIndex_... cannot be greater than (length of dropdown - 1)"");
            return false;
        }
    }

    function fnKeyDownHandler_D(getdropdown, e) {
        fnSanityCheck_D(getdropdown);

        // Press [ <- ] and [ -> ] arrow keys on the keyboard to change alignment/flow.
        // ...go to Start : Press  [ <- ] Arrow Key
        // ...go to End : Press [ -> ] Arrow Key
        // (this is useful when the edited-text content exceeds the ListBox-fixed-width)
        // This works best on Internet Explorer, and not on NetscapeFirefoxChrome

        var vEventKeyCode = FindKeyCode(e);

        // Press left/right arrow keys
        if (vEventKeyCode == 37) {
            fnLeftToRight(getdropdown);
        }
        if (vEventKeyCode == 39) {
            fnRightToLeft(getdropdown);
        }

        // Delete key pressed
        if (vEventKeyCode == 46) {
            if (getdropdown.options.length != 0)
                // if dropdown is not empty
            {
                if (getdropdown.options.selectedIndex == vEditableOptionIndex_D)
                    // if option is the Editable field
                {
                    getdropdown.options[getdropdown.options.selectedIndex].text = '';
                    getdropdown.options[getdropdown.options.selectedIndex].value = '';
                }
            }
        }

        // backspace key pressed
        if (vEventKeyCode == 8 || vEventKeyCode == 127) {
            if (getdropdown.options.length != 0)
                // if dropdown is not empty
            {
                if (getdropdown.options.selectedIndex == vEditableOptionIndex_D)
                    // if option is the Editable field
                {
                    // make Editable option Null if it is being edited for the first time
                    if ((getdropdown[vEditableOptionIndex_D].text == vEditableOptionText_D) || (getdropdown[vEditableOptionIndex_D].value == vEditableOptionText_D)) {
                        getdropdown.options[getdropdown.options.selectedIndex].text = '';
                        getdropdown.options[getdropdown.options.selectedIndex].value = '';
                    }
                    else {
                        getdropdown.options[getdropdown.options.selectedIndex].text = getdropdown.options[getdropdown.options.selectedIndex].text.slice(0, -1);
                        getdropdown.options[getdropdown.options.selectedIndex].value = getdropdown.options[getdropdown.options.selectedIndex].value.slice(0, -1);
                    }
                }
            }
            if (e.which) //NetscapeFirefoxChrome
            {
                e.which = '';
            }
            else //Internet Explorer
            {
                e.keyCode = '';
            }
            if (e.cancelBubble)	  //Internet Explorer
            {
                e.cancelBubble = true;
                e.returnValue = false;
            }
            if (e.stopPropagation)	 //NetscapeFirefoxChrome
            {
                e.stopPropagation();
            }
            if (e.preventDefault)	 //NetscapeFirefoxChrome
            {
                e.preventDefault();
            }
        }
    }

    function fnFocusHandler_D(getdropdown) {
        //use textbox for devices such as android and ipad that don't have a physical keyboard (textbox allows use of virtual soft keyboard)
        if ((navigator.userAgent.toLowerCase().search(/android|ipad|iphone|ipod/) > -1) || (vUseActualTexbox_D == 'yes')) {
            if (getdropdown[(vEditableOptionIndex_D)].selected == true) {
                document.getElementById('textboxoption_D').style.visibility = '';
                document.getElementById('textboxoption_D').style.display = '';
            }
            else {
                document.getElementById('textboxoption_D').style.visibility = 'hidden';
                document.getElementById('textboxoption_D').style.display = 'none';
            }
        }
    }

    function fnChangeHandler_D(getdropdown) {
        fnSanityCheck_D(getdropdown);

        vPreviousSelectIndex_D = vSelectIndex_D;
        // Contains the Previously Selected Index

        vSelectIndex_D = getdropdown.options.selectedIndex;
        // Contains the Currently Selected Index

        if ((vPreviousSelectIndex_D == (vEditableOptionIndex_D)) && (vSelectIndex_D != (vEditableOptionIndex_D)) && (vSelectChange_D != 'MANUAL_DLICK'))
            // To Set value of Index variables - source: http://chakrabarty.com/pp_editable_dropdown.html
        {
            getdropdown[(vEditableOptionIndex_D)].selected = true;
            vPreviousSelectIndex_D = vSelectIndex_D;
            vSelectIndex_D = getdropdown.options.selectedIndex;
            vSelectChange_D = 'MANUAL_DLICK';
            // Indicates that the Change in dropdown selected
            // option was due to a Manual Click
        }

        //use textbox for devices such as android and ipad that don't have a physical keyboard (textbox allows use of virtual soft keyboard)
        if ((navigator.userAgent.toLowerCase().search(/android|ipad|iphone|ipod/) > -1) || (vUseActualTexbox_D == 'yes')) {
            fnFocusHandler_D(getdropdown);
        }

    }

    function fnKeyPressHandler_D(getdropdown, e) {
        fnSanityCheck_D(getdropdown);

        keycode = FindKeyCode(e);
        keychar = FindKeyChar(e);

        // Check for allowable Characters
        // The various characters allowable for entry into Editable option..
        // may be customized by minor modifications in the code (if condition below)
        // (you need to know the keycode/ASCII value of the  character to be allowed/disallowed.
        // - source: http://chakrabarty.com/pp_editable_dropdown.html

        if ((keycode > 47 && keycode < 59) || (keycode > 62 && keycode < 127) || (keycode == 32)) {
            var vAllowableCharacter = ""yes"";
        }
        else {
            var vAllowableCharacter = ""no"";
        }

        //alert(window); alert(window.event);

        if (getdropdown.options.length != 0)
            // if dropdown is not empty
            if (getdropdown.options.selectedIndex == (vEditableOptionIndex_D))
                // if selected option the Editable option of the dropdown
            {

                // Empty space (ascii 32)  is not captured by NetscapeFirefoxChrome when .text is used
                // NetscapeFirefoxChrome removes extra spaces at end of string when .text is used
                // NetscapeFirefoxChrome allows one empty space at end of string when .value is used
                // Hence, use .value insead of .text
                var vEditString = getdropdown[vEditableOptionIndex_D].value;

                // make Editable option Null if it is being edited for the first time
                if (vAllowableCharacter == ""yes"") {
                    if ((getdropdown[vEditableOptionIndex_D].text == vEditableOptionText_D) || (getdropdown[vEditableOptionIndex_D].value == vEditableOptionText_D))
                        vEditString = """";
                }

                if (vAllowableCharacter == ""yes"")
                    // To handle addition of a character - source: http://chakrabarty.com/pp_editable_dropdown.html
                {
                    vEditString += String.fromCharCode(keycode);
                    // Concatenate Enter character to Editable string

                    // The following portion handles the ""automatic Jump"" bug
                    // The ""automatic Jump"" bug (Description):
                    //   If a alphabet is entered (while editing)
                    //   ...which is contained as a first character in one of the read-only options
                    //   ..the focus automatically ""jumps"" to the read-only option
                    //   (-- this is a common property of normal dropdowns
                    //    ..but..is undesirable while editing).

                    var i = 0;
                    var vEnteredChar = String.fromCharCode(keycode);
                    var vUpperCaseEnteredChar = vEnteredChar;
                    var vLowerCaseEnteredChar = vEnteredChar;


                    if (((keycode) >= 97) && ((keycode) <= 122))
                        // if vEnteredChar lowercase
                        vUpperCaseEnteredChar = String.fromCharCode(keycode - 32);
                    // This is UpperCase


                    if (((keycode) >= 65) && ((keycode) <= 90))
                        // if vEnteredChar is UpperCase
                        vLowerCaseEnteredChar = String.fromCharCode(keycode + 32);
                    // This is lowercase

                    if (e.which) //For NetscapeFirefoxChrome
                    {
                        // Compare the typed character (into the editable option)
                        // with the first character of all the other
                        // options (non-editable).

                        // To note if the jump to the non-editable option was due
                        // to a Manual click (i.e.,changed on purpose by user)
                        // or instead due to System properties of dropdown
                        // (i.e.,user did not change the option in the dropdown;
                        // instead an automatic jump happened due to inbuilt
                        // dropdown properties of browser on typing of a character )

                        for (i = 0; i <= (getdropdown.options.length - 1) ; i++) {
                            if (i != vEditableOptionIndex_D) {
                                var vEnteredDigitNumber = getdropdown[vEditableOptionIndex_D].text.length;
                                var vFirstReadOnlyChar = getdropdown[i].text.substring(0, 1);
                                var vEquivalentReadOnlyChar = getdropdown[i].text.substring(vEnteredDigitNumber, vEnteredDigitNumber + 1);
                                if (vEnteredDigitNumber >= getdropdown[i].text.length) {
                                    vEquivalentReadOnlyChar = vFirstReadOnlyChar;
                                }
                                if ((vEquivalentReadOnlyChar == vUpperCaseEnteredChar) || (vEquivalentReadOnlyChar == vLowerCaseEnteredChar)
                                  || (vFirstReadOnlyChar == vUpperCaseEnteredChar) || (vFirstReadOnlyChar == vLowerCaseEnteredChar)) {
                                    vSelectChange_D = 'AUTO_SYSTEM';
                                    // Indicates that the Change in dropdown selected
                                    // option was due to System properties of dropdown
                                    break;
                                }
                                else {
                                    vSelectChange_D = 'MANUAL_DLICK';
                                    // Indicates that the Change in dropdown selected
                                    // option was due to a Manual Click
                                }
                            }
                        }
                    }
                }

                // Set the new edited string into the Editable option
                getdropdown.options[vEditableOptionIndex_D].text = vEditString;
                getdropdown.options[vEditableOptionIndex_D].value = vEditString;

                return false;
            }
        return true;
    }

    function fnKeyUpHandler_D(getdropdown, e) {
        fnSanityCheck_D(getdropdown);

        if (e.which) // NetscapeFirefoxChrome
        {
            if (vSelectChange_D == 'AUTO_SYSTEM') {
                // if editable dropdown option jumped while editing
                // (due to typing of a character which is the first character of some other option)
                // then go back to the editable option.
                getdropdown[(vEditableOptionIndex_D)].selected = true;
                vSelectChange_D = 'MANUAL_CLICK';
            }

            var vEventKeyCode = FindKeyCode(e);
            // if [ <- ] or [ -> ] arrow keys are pressed, select the editable option
            if ((vEventKeyCode == 37) || (vEventKeyCode == 39)) {
                getdropdown[vEditableOptionIndex_D].selected = true;
            }
        }
    }

    /*-------------------------------------------------------------------------------------------- source: http://chakrabarty.com/pp_editable_dropdown.html */

</script> <!--end of script for dropdown lstDropDown_D -->
    <script language=""JavaScript""> //Dropdown specific functions, which manipulate dropdown specific global variables
        //for the dropdown lstDropDown_F

        /*----------------------------------------------
        Dropdown specific global variables are:
        -----------------------------------------------
        1) vEditableOptionIndex_F   --> this needs to be set by Programmer!! See explanation.
        2) vEditableOptionText_F    --> this needs to be set by Programmer!! See explanation.
        3) vUseActualTexbox_F       --> this needs to be set by Programmer!! See explanation.
        4) vPreviousSelectIndex_F
        5) vSelectIndex_F
        6) vSelectChange_F
      
        --------------------------- source: http://chakrabarty.com/pp_editable_Fropdown.html */

        /*----------------------------------------------
        Dropdown specific functions
        (which manipulate dropdown specific global variables)
        -----------------------------------------------
        1) function fnChangeHandler_F(getdropdown)
        2) function fnFocusHandler_F (getdropdown)
        3) function fnKeyPressHandler_F(getdropdown, e)
        4) function fnKeyUpHandler_F(getdropdown, e)
        5) function fnKeyDownHandler_F(getdropdown, e)
      
        --------------------------- source: http://chakrabarty.com/pp_editable_Fropdown.html */

        /*------------------------------------------------
        IMPORTANT: Global Variable required to be SET by programmer
        -------------------------- source: http://chakrabarty.com/pp_editable_Fropdown.html  */

        var vEditableOptionIndex_F = 4;

        // Give Index of Editable option in the dropdown.
        // For eg.
        // if first option is editable then vEditableOptionIndex_F = 0;
        // if second option is editable then vEditableOptionIndex_F = 1;
        // if third option is editable then vEditableOptionIndex_F = 2;
        // if last option is editable then vEditableOptionIndex_F = (length of dropdown - 1).
        // Note: the value of vEditableOptionIndex_F cannot be greater than (length of dropdown - 1)

        var vEditableOptionText_F = ""--?--"";

        // Give the default text of the Editable option in the dropdown.
        // For eg.
        // if the editable option is <option ...>--?--</option>,
        // then set vEditableOptionText_F = ""--?--"";

        var vUseActualTexbox_F = ""no"";
        // = ""no"" ...
        //      default is 'no' because there is no need to use an actual textbox if using a PC (with physical keyboard)
        //      if using iPad/iPhone or Android device, which usually have a virtual soft keyboard, then textbox will automatically show up next to dropdown on those devices
        // = ""yes"" ...
        //      set this to 'yes' if and only if you want an actual textbox to show up next to dropdown at all times (even on devices with physical keyboards)

        /*------------------------------------------------
        Global Variables required for
        fnChangeHandler_F(), fnKeyPressHandler_F() and fnKeyUpHandler_F()
        for Editable Dropdowns
        -------------------------- source: http://chakrabarty.com/pp_editable_Fropdown.html  */

        var vPreviousSelectIndex_F = 0;
        // Contains the Previously Selected Index, set to 0 by default

        var vSelectIndex_F = 0;
        // Contains the Currently Selected Index, set to 0 by default

        var vSelectChange_F = 'MANUAL_FLICK';
        // Indicates whether Change in dropdown selected option
        // was due to a Manual Click
        // or instead due to System properties of dropdown.

        // vSelectChange_F = 'MANUAL_FLICK' indicates that
        // the jump to a non-editable option in the dropdown was due
        // to a Manual click (i.e.,changed on purpose by user).

        // vSelectChange_F = 'AUTO_SYSTEM' indicates that
        // the jump to a non-editable option was due to System properties of dropdown
        // (i.e.,user did not change the option in the dropdown;
        // instead an automatic jump happened due to inbuilt
        // dropdown properties of browser on typing of a character )

        /*------------------------------------------------
        Functions required for  Editable Dropdowns
        -------------------------- source: http://chakrabarty.com/pp_editable_Fropdown.html  */

        function fnSanityCheck_F(getdropdown) {
            if (vEditableOptionIndex_F > (getdropdown.options.length - 1)) {
                alert(""PROGRAMMING ERROR: The value of variable vEditableOptionIndex_... cannot be greater than (length of dropdown - 1)"");
                return false;
            }
        }

        function fnKeyDownHandler_F(getdropdown, e) {
            fnSanityCheck_F(getdropdown);

            // Press [ <- ] and [ -> ] arrow keys on the keyboard to change alignment/flow.
            // ...go to Start : Press  [ <- ] Arrow Key
            // ...go to End : Press [ -> ] Arrow Key
            // (this is useful when the edited-text content exceeds the ListBox-fixed-width)
            // This works best on Internet Explorer, and not on NetscapeFirefoxChrome

            var vEventKeyCode = FindKeyCode(e);

            // Press left/right arrow keys
            if (vEventKeyCode == 37) {
                fnLeftToRight(getdropdown);
            }
            if (vEventKeyCode == 39) {
                fnRightToLeft(getdropdown);
            }

            // Delete key pressed
            if (vEventKeyCode == 46) {
                if (getdropdown.options.length != 0)
                    // if dropdown is not empty
                {
                    if (getdropdown.options.selectedIndex == vEditableOptionIndex_F)
                        // if option is the Editable field
                    {
                        getdropdown.options[getdropdown.options.selectedIndex].text = '';
                        getdropdown.options[getdropdown.options.selectedIndex].value = '';
                    }
                }
            }

            // backspace key pressed
            if (vEventKeyCode == 8 || vEventKeyCode == 127) {
                if (getdropdown.options.length != 0)
                    // if dropdown is not empty
                {
                    if (getdropdown.options.selectedIndex == vEditableOptionIndex_F)
                        // if option is the Editable field
                    {
                        // make Editable option Null if it is being edited for the first time
                        if ((getdropdown[vEditableOptionIndex_F].text == vEditableOptionText_F) || (getdropdown[vEditableOptionIndex_F].value == vEditableOptionText_F)) {
                            getdropdown.options[getdropdown.options.selectedIndex].text = '';
                            getdropdown.options[getdropdown.options.selectedIndex].value = '';
                        }
                        else {
                            getdropdown.options[getdropdown.options.selectedIndex].text = getdropdown.options[getdropdown.options.selectedIndex].text.slice(0, -1);
                            getdropdown.options[getdropdown.options.selectedIndex].value = getdropdown.options[getdropdown.options.selectedIndex].value.slice(0, -1);
                        }
                    }
                }
                if (e.which) //NetscapeFirefoxChrome
                {
                    e.which = '';
                }
                else //Internet Explorer
                {
                    e.keyCode = '';
                }
                if (e.cancelBubble)	  //Internet Explorer
                {
                    e.cancelBubble = true;
                    e.returnValue = false;
                }
                if (e.stopPropagation)	 //NetscapeFirefoxChrome
                {
                    e.stopPropagation();
                }
                if (e.preventDefault)	 //NetscapeFirefoxChrome
                {
                    e.preventDefault();
                }
            }
        }

        function fnFocusHandler_F(getdropdown) {
            //use textbox for devices such as android and ipad that don't have a physical keyboard (textbox allows use of virtual soft keyboard)
            if ((navigator.userAgent.toLowerCase().search(/android|ipad|iphone|ipod/) > -1) || (vUseActualTexbox_F == 'yes')) {
                if (getdropdown[(vEditableOptionIndex_F)].selected == true) {
                    document.getElementById('textboxoption_F').style.visibility = '';
                    document.getElementById('textboxoption_F').style.display = '';
                }
                else {
                    document.getElementById('textboxoption_F').style.visibility = 'hidden';
                    document.getElementById('textboxoption_F').style.display = 'none';
                }
            }
        }

        function fnChangeHandler_F(getdropdown) {
            fnSanityCheck_F(getdropdown);

            vPreviousSelectIndex_F = vSelectIndex_F;
            // Contains the Previously Selected Index

            vSelectIndex_F = getdropdown.options.selectedIndex;
            // Contains the Currently Selected Index

            if ((vPreviousSelectIndex_F == (vEditableOptionIndex_F)) && (vSelectIndex_F != (vEditableOptionIndex_F)) && (vSelectChange_F != 'MANUAL_FLICK'))
                // To Set value of Index variables - source: http://chakrabarty.com/pp_editable_Fropdown.html
            {
                getdropdown[(vEditableOptionIndex_F)].selected = true;
                vPreviousSelectIndex_F = vSelectIndex_F;
                vSelectIndex_F = getdropdown.options.selectedIndex;
                vSelectChange_F = 'MANUAL_FLICK';
                // Indicates that the Change in dropdown selected
                // option was due to a Manual Click
            }

            //use textbox for devices such as android and ipad that don't have a physical keyboard (textbox allows use of virtual soft keyboard)
            if ((navigator.userAgent.toLowerCase().search(/android|ipad|iphone|ipod/) > -1) || (vUseActualTexbox_F == 'yes')) {
                fnFocusHandler_F(getdropdown);
            }

        }

        function fnKeyPressHandler_F(getdropdown, e) {
            fnSanityCheck_F(getdropdown);

            keycode = FindKeyCode(e);
            keychar = FindKeyChar(e);

            // Check for allowable Characters
            // The various characters allowable for entry into Editable option..
            // may be customized by minor modifications in the code (if condition below)
            // (you need to know the keycode/ASCII value of the  character to be allowed/disallowed.
            // - source: http://chakrabarty.com/pp_editable_Fropdown.html

            if ((keycode > 47 && keycode < 59) || (keycode > 62 && keycode < 127) || (keycode == 32)) {
                var vAllowableCharacter = ""yes"";
            }
            else {
                var vAllowableCharacter = ""no"";
            }

            //alert(window); alert(window.event);

            if (getdropdown.options.length != 0)
                // if dropdown is not empty
                if (getdropdown.options.selectedIndex == (vEditableOptionIndex_F))
                    // if selected option the Editable option of the dropdown
                {

                    // Empty space (ascii 32)  is not captured by NetscapeFirefoxChrome when .text is used
                    // NetscapeFirefoxChrome removes extra spaces at end of string when .text is used
                    // NetscapeFirefoxChrome allows one empty space at end of string when .value is used
                    // Hence, use .value insead of .text
                    var vEditString = getdropdown[vEditableOptionIndex_F].value;

                    // make Editable option Null if it is being edited for the first time
                    if (vAllowableCharacter == ""yes"") {
                        if ((getdropdown[vEditableOptionIndex_F].text == vEditableOptionText_F) || (getdropdown[vEditableOptionIndex_F].value == vEditableOptionText_F))
                            vEditString = """";
                    }

                    if (vAllowableCharacter == ""yes"")
                        // To handle addition of a character - source: http://chakrabarty.com/pp_editable_Fropdown.html
                    {
                        vEditString += String.fromCharCode(keycode);
                        // Concatenate Enter character to Editable string

                        // The following portion handles the ""automatic Jump"" bug
                        // The ""automatic Jump"" bug (Description):
                        //   If a alphabet is entered (while editing)
                        //   ...which is contained as a first character in one of the read-only options
                        //   ..the focus automatically ""jumps"" to the read-only option
                        //   (-- this is a common property of normal dropdowns
                        //    ..but..is undesirable while editing).

                        var i = 0;
                        var vEnteredChar = String.fromCharCode(keycode);
                        var vUpperCaseEnteredChar = vEnteredChar;
                        var vLowerCaseEnteredChar = vEnteredChar;


                        if (((keycode) >= 97) && ((keycode) <= 122))
                            // if vEnteredChar lowercase
                            vUpperCaseEnteredChar = String.fromCharCode(keycode - 32);
                        // This is UpperCase


                        if (((keycode) >= 65) && ((keycode) <= 90))
                            // if vEnteredChar is UpperCase
                            vLowerCaseEnteredChar = String.fromCharCode(keycode + 32);
                        // This is lowercase

                        if (e.which) //For NetscapeFirefoxChrome
                        {
                            // Compare the typed character (into the editable option)
                            // with the first character of all the other
                            // options (non-editable).

                            // To note if the jump to the non-editable option was due
                            // to a Manual click (i.e.,changed on purpose by user)
                            // or instead due to System properties of dropdown
                            // (i.e.,user did not change the option in the dropdown;
                            // instead an automatic jump happened due to inbuilt
                            // dropdown properties of browser on typing of a character )

                            for (i = 0; i <= (getdropdown.options.length - 1) ; i++) {
                                if (i != vEditableOptionIndex_F) {
                                    var vEnteredDigitNumber = getdropdown[vEditableOptionIndex_F].text.length;
                                    var vFirstReadOnlyChar = getdropdown[i].text.substring(0, 1);
                                    var vEquivalentReadOnlyChar = getdropdown[i].text.substring(vEnteredDigitNumber, vEnteredDigitNumber + 1);
                                    if (vEnteredDigitNumber >= getdropdown[i].text.length) {
                                        vEquivalentReadOnlyChar = vFirstReadOnlyChar;
                                    }
                                    if ((vEquivalentReadOnlyChar == vUpperCaseEnteredChar) || (vEquivalentReadOnlyChar == vLowerCaseEnteredChar)
                                      || (vFirstReadOnlyChar == vUpperCaseEnteredChar) || (vFirstReadOnlyChar == vLowerCaseEnteredChar)) {
                                        vSelectChange_F = 'AUTO_SYSTEM';
                                        // Indicates that the Change in dropdown selected
                                        // option was due to System properties of dropdown
                                        break;
                                    }
                                    else {
                                        vSelectChange_F = 'MANUAL_FLICK';
                                        // Indicates that the Change in dropdown selected
                                        // option was due to a Manual Click
                                    }
                                }
                            }
                        }
                    }

                    // Set the new edited string into the Editable option
                    getdropdown.options[vEditableOptionIndex_F].text = vEditString;
                    getdropdown.options[vEditableOptionIndex_F].value = vEditString;

                    return false;
                }
            return true;
        }

        function fnKeyUpHandler_F(getdropdown, e) {
            fnSanityCheck_F(getdropdown);

            if (e.which) // NetscapeFirefoxChrome
            {
                if (vSelectChange_F == 'AUTO_SYSTEM') {
                    // if editable dropdown option jumped while editing
                    // (due to typing of a character which is the first character of some other option)
                    // then go back to the editable option.
                    getdropdown[(vEditableOptionIndex_F)].selected = true;
                    vSelectChange_F = 'MANUAL_CLICK';
                }

                var vEventKeyCode = FindKeyCode(e);
                // if [ <- ] or [ -> ] arrow keys are pressed, select the editable option
                if ((vEventKeyCode == 37) || (vEventKeyCode == 39)) {
                    getdropdown[vEditableOptionIndex_F].selected = true;
                }
            }
        }

        /*-------------------------------------------------------------------------------------------- source: http://chakrabarty.com/pp_editable_Fropdown.html */

</script> <!--end of script for dropdown lstDropDown_F -->

    <script language=""JavaScript""> //Dropdown specific functions, which manipulate dropdown specific global variables
        //for the dropdown lstDropDown_G

        /*----------------------------------------------
        Dropdown specific global variables are:
        -----------------------------------------------
        1) vEditableOptionIndex_G   --> this needs to be set by Programmer!! See explanation.
        2) vEditableOptionText_G    --> this needs to be set by Programmer!! See explanation.
        3) vUseActualTexbox_G       --> this needs to be set by Programmer!! See explanation.
        4) vPreviousSelectIndex_G
        5) vSelectIndex_G
        6) vSelectChange_G
      
        --------------------------- source: http://chakrabarty.com/pp_editable_Gropdown.html */

        /*----------------------------------------------
        Dropdown specific functions
        (which manipulate dropdown specific global variables)
        -----------------------------------------------
        1) function fnChangeHandler_G(getdropdown)
        2) function fnFocusHandler_G (getdropdown)
        3) function fnKeyPressHandler_G(getdropdown, e)
        4) function fnKeyUpHandler_G(getdropdown, e)
        5) function fnKeyDownHandler_G(getdropdown, e)
      
        --------------------------- source: http://chakrabarty.com/pp_editable_Gropdown.html */

        /*------------------------------------------------
        IMPORTANT: Global Variable required to be SET by programmer
        -------------------------- source: http://chakrabarty.com/pp_editable_Gropdown.html  */

        var vEditableOptionIndex_G = 4;

        // Give Index of Editable option in the dropdown.
        // For eg.
        // if first option is editable then vEditableOptionIndex_G = 0;
        // if second option is editable then vEditableOptionIndex_G = 1;
        // if third option is editable then vEditableOptionIndex_G = 2;
        // if last option is editable then vEditableOptionIndex_G = (length of dropdown - 1).
        // Note: the value of vEditableOptionIndex_G cannot be greater than (length of dropdown - 1)

        var vEditableOptionText_G = ""--?--"";

        // Give the default text of the Editable option in the dropdown.
        // For eg.
        // if the editable option is <option ...>--?--</option>,
        // then set vEditableOptionText_G = ""--?--"";

        var vUseActualTexbox_G = ""no"";
        // = ""no"" ...
        //      default is 'no' because there is no need to use an actual textbox if using a PC (with physical keyboard)
        //      if using iPad/iPhone or Android device, which usually have a virtual soft keyboard, then textbox will automatically show up next to dropdown on those devices
        // = ""yes"" ...
        //      set this to 'yes' if and only if you want an actual textbox to show up next to dropdown at all times (even on devices with physical keyboards)

        /*------------------------------------------------
        Global Variables required for
        fnChangeHandler_G(), fnKeyPressHandler_G() and fnKeyUpHandler_G()
        for Editable Dropdowns
        -------------------------- source: http://chakrabarty.com/pp_editable_Gropdown.html  */

        var vPreviousSelectIndex_G = 0;
        // Contains the Previously Selected Index, set to 0 by default

        var vSelectIndex_G = 0;
        // Contains the Currently Selected Index, set to 0 by default

        var vSelectChange_G = 'MANUAL_GLICK';
        // Indicates whether Change in dropdown selected option
        // was due to a Manual Click
        // or instead due to System properties of dropdown.

        // vSelectChange_G = 'MANUAL_GLICK' indicates that
        // the jump to a non-editable option in the dropdown was due
        // to a Manual click (i.e.,changed on purpose by user).

        // vSelectChange_G = 'AUTO_SYSTEM' indicates that
        // the jump to a non-editable option was due to System properties of dropdown
        // (i.e.,user did not change the option in the dropdown;
        // instead an automatic jump happened due to inbuilt
        // dropdown properties of browser on typing of a character )

        /*------------------------------------------------
        Functions required for  Editable Dropdowns
        -------------------------- source: http://chakrabarty.com/pp_editable_Gropdown.html  */

        function fnSanityCheck_G(getdropdown) {
            if (vEditableOptionIndex_G > (getdropdown.options.length - 1)) {
                alert(""PROGRAMMING ERROR: The value of variable vEditableOptionIndex_... cannot be greater than (length of dropdown - 1)"");
                return false;
            }
        }

        function fnKeyDownHandler_G(getdropdown, e) {
            fnSanityCheck_G(getdropdown);

            // Press [ <- ] and [ -> ] arrow keys on the keyboard to change alignment/flow.
            // ...go to Start : Press  [ <- ] Arrow Key
            // ...go to End : Press [ -> ] Arrow Key
            // (this is useful when the edited-text content exceeds the ListBox-fixed-width)
            // This works best on Internet Explorer, and not on NetscapeFirefoxChrome

            var vEventKeyCode = FindKeyCode(e);

            // Press left/right arrow keys
            if (vEventKeyCode == 37) {
                fnLeftToRight(getdropdown);
            }
            if (vEventKeyCode == 39) {
                fnRightToLeft(getdropdown);
            }

            // Delete key pressed
            if (vEventKeyCode == 46) {
                if (getdropdown.options.length != 0)
                    // if dropdown is not empty
                {
                    if (getdropdown.options.selectedIndex == vEditableOptionIndex_G)
                        // if option is the Editable field
                    {
                        getdropdown.options[getdropdown.options.selectedIndex].text = '';
                        getdropdown.options[getdropdown.options.selectedIndex].value = '';
                    }
                }
            }

            // backspace key pressed
            if (vEventKeyCode == 8 || vEventKeyCode == 127) {
                if (getdropdown.options.length != 0)
                    // if dropdown is not empty
                {
                    if (getdropdown.options.selectedIndex == vEditableOptionIndex_G)
                        // if option is the Editable field
                    {
                        // make Editable option Null if it is being edited for the first time
                        if ((getdropdown[vEditableOptionIndex_G].text == vEditableOptionText_G) || (getdropdown[vEditableOptionIndex_G].value == vEditableOptionText_G)) {
                            getdropdown.options[getdropdown.options.selectedIndex].text = '';
                            getdropdown.options[getdropdown.options.selectedIndex].value = '';
                        }
                        else {
                            getdropdown.options[getdropdown.options.selectedIndex].text = getdropdown.options[getdropdown.options.selectedIndex].text.slice(0, -1);
                            getdropdown.options[getdropdown.options.selectedIndex].value = getdropdown.options[getdropdown.options.selectedIndex].value.slice(0, -1);
                        }
                    }
                }
                if (e.which) //NetscapeFirefoxChrome
                {
                    e.which = '';
                }
                else //Internet Explorer
                {
                    e.keyCode = '';
                }
                if (e.cancelBubble)	  //Internet Explorer
                {
                    e.cancelBubble = true;
                    e.returnValue = false;
                }
                if (e.stopPropagation)	 //NetscapeFirefoxChrome
                {
                    e.stopPropagation();
                }
                if (e.preventDefault)	 //NetscapeFirefoxChrome
                {
                    e.preventDefault();
                }
            }
        }

        function fnFocusHandler_G(getdropdown) {
            //use textbox for devices such as android and ipad that don't have a physical keyboard (textbox allows use of virtual soft keyboard)
            if ((navigator.userAgent.toLowerCase().search(/android|ipad|iphone|ipod/) > -1) || (vUseActualTexbox_G == 'yes')) {
                if (getdropdown[(vEditableOptionIndex_G)].selected == true) {
                    document.getElementById('textboxoption_G').style.visibility = '';
                    document.getElementById('textboxoption_G').style.display = '';
                }
                else {
                    document.getElementById('textboxoption_G').style.visibility = 'hidden';
                    document.getElementById('textboxoption_G').style.display = 'none';
                }
            }
        }

        function fnChangeHandler_G(getdropdown) {
            fnSanityCheck_G(getdropdown);

            vPreviousSelectIndex_G = vSelectIndex_G;
            // Contains the Previously Selected Index

            vSelectIndex_G = getdropdown.options.selectedIndex;
            // Contains the Currently Selected Index

            if ((vPreviousSelectIndex_G == (vEditableOptionIndex_G)) && (vSelectIndex_G != (vEditableOptionIndex_G)) && (vSelectChange_G != 'MANUAL_GLICK'))
                // To Set value of Index variables - source: http://chakrabarty.com/pp_editable_Gropdown.html
            {
                getdropdown[(vEditableOptionIndex_G)].selected = true;
                vPreviousSelectIndex_G = vSelectIndex_G;
                vSelectIndex_G = getdropdown.options.selectedIndex;
                vSelectChange_G = 'MANUAL_GLICK';
                // Indicates that the Change in dropdown selected
                // option was due to a Manual Click
            }

            //use textbox for devices such as android and ipad that don't have a physical keyboard (textbox allows use of virtual soft keyboard)
            if ((navigator.userAgent.toLowerCase().search(/android|ipad|iphone|ipod/) > -1) || (vUseActualTexbox_G == 'yes')) {
                fnFocusHandler_G(getdropdown);
            }

        }

        function fnKeyPressHandler_G(getdropdown, e) {
            fnSanityCheck_G(getdropdown);

            keycode = FindKeyCode(e);
            keychar = FindKeyChar(e);

            // Check for allowable Characters
            // The various characters allowable for entry into Editable option..
            // may be customized by minor modifications in the code (if condition below)
            // (you need to know the keycode/ASCII value of the  character to be allowed/disallowed.
            // - source: http://chakrabarty.com/pp_editable_Gropdown.html

            if ((keycode > 47 && keycode < 59) || (keycode > 62 && keycode < 127) || (keycode == 32)) {
                var vAllowableCharacter = ""yes"";
            }
            else {
                var vAllowableCharacter = ""no"";
            }

            //alert(window); alert(window.event);

            if (getdropdown.options.length != 0)
                // if dropdown is not empty
                if (getdropdown.options.selectedIndex == (vEditableOptionIndex_G))
                    // if selected option the Editable option of the dropdown
                {

                    // Empty space (ascii 32)  is not captured by NetscapeFirefoxChrome when .text is used
                    // NetscapeFirefoxChrome removes extra spaces at end of string when .text is used
                    // NetscapeFirefoxChrome allows one empty space at end of string when .value is used
                    // Hence, use .value insead of .text
                    var vEditString = getdropdown[vEditableOptionIndex_G].value;

                    // make Editable option Null if it is being edited for the first time
                    if (vAllowableCharacter == ""yes"") {
                        if ((getdropdown[vEditableOptionIndex_G].text == vEditableOptionText_G) || (getdropdown[vEditableOptionIndex_G].value == vEditableOptionText_G))
                            vEditString = """";
                    }

                    if (vAllowableCharacter == ""yes"")
                        // To handle addition of a character - source: http://chakrabarty.com/pp_editable_Gropdown.html
                    {
                        vEditString += String.fromCharCode(keycode);
                        // Concatenate Enter character to Editable string

                        // The following portion handles the ""automatic Jump"" bug
                        // The ""automatic Jump"" bug (Description):
                        //   If a alphabet is entered (while editing)
                        //   ...which is contained as a first character in one of the read-only options
                        //   ..the focus automatically ""jumps"" to the read-only option
                        //   (-- this is a common property of normal dropdowns
                        //    ..but..is undesirable while editing).

                        var i = 0;
                        var vEnteredChar = String.fromCharCode(keycode);
                        var vUpperCaseEnteredChar = vEnteredChar;
                        var vLowerCaseEnteredChar = vEnteredChar;


                        if (((keycode) >= 97) && ((keycode) <= 122))
                            // if vEnteredChar lowercase
                            vUpperCaseEnteredChar = String.fromCharCode(keycode - 32);
                        // This is UpperCase


                        if (((keycode) >= 65) && ((keycode) <= 90))
                            // if vEnteredChar is UpperCase
                            vLowerCaseEnteredChar = String.fromCharCode(keycode + 32);
                        // This is lowercase

                        if (e.which) //For NetscapeFirefoxChrome
                        {
                            // Compare the typed character (into the editable option)
                            // with the first character of all the other
                            // options (non-editable).

                            // To note if the jump to the non-editable option was due
                            // to a Manual click (i.e.,changed on purpose by user)
                            // or instead due to System properties of dropdown
                            // (i.e.,user did not change the option in the dropdown;
                            // instead an automatic jump happened due to inbuilt
                            // dropdown properties of browser on typing of a character )

                            for (i = 0; i <= (getdropdown.options.length - 1) ; i++) {
                                if (i != vEditableOptionIndex_G) {
                                    var vEnteredDigitNumber = getdropdown[vEditableOptionIndex_G].text.length;
                                    var vFirstReadOnlyChar = getdropdown[i].text.substring(0, 1);
                                    var vEquivalentReadOnlyChar = getdropdown[i].text.substring(vEnteredDigitNumber, vEnteredDigitNumber + 1);
                                    if (vEnteredDigitNumber >= getdropdown[i].text.length) {
                                        vEquivalentReadOnlyChar = vFirstReadOnlyChar;
                                    }
                                    if ((vEquivalentReadOnlyChar == vUpperCaseEnteredChar) || (vEquivalentReadOnlyChar == vLowerCaseEnteredChar)
                                      || (vFirstReadOnlyChar == vUpperCaseEnteredChar) || (vFirstReadOnlyChar == vLowerCaseEnteredChar)) {
                                        vSelectChange_G = 'AUTO_SYSTEM';
                                        // Indicates that the Change in dropdown selected
                                        // option was due to System properties of dropdown
                                        break;
                                    }
                                    else {
                                        vSelectChange_G = 'MANUAL_GLICK';
                                        // Indicates that the Change in dropdown selected
                                        // option was due to a Manual Click
                                    }
                                }
                            }
                        }
                    }

                    // Set the new edited string into the Editable option
                    getdropdown.options[vEditableOptionIndex_G].text = vEditString;
                    getdropdown.options[vEditableOptionIndex_G].value = vEditString;

                    return false;
                }
            return true;
        }

        function fnKeyUpHandler_G(getdropdown, e) {
            fnSanityCheck_G(getdropdown);

            if (e.which) // NetscapeFirefoxChrome
            {
                if (vSelectChange_G == 'AUTO_SYSTEM') {
                    // if editable dropdown option jumped while editing
                    // (due to typing of a character which is the first character of some other option)
                    // then go back to the editable option.
                    getdropdown[(vEditableOptionIndex_G)].selected = true;
                    vSelectChange_G = 'MANUAL_CLICK';
                }

                var vEventKeyCode = FindKeyCode(e);
                // if [ <- ] or [ -> ] arrow keys are pressed, select the editable option
                if ((vEventKeyCode == 37) || (vEventKeyCode == 39)) {
                    getdropdown[vEditableOptionIndex_G].selected = true;
                }
            }
        }

        /*-------------------------------------------------------------------------------------------- source: http://chakrabarty.com/pp_editable_Gropdown.html */

</script> <!--end of script for dropdown lstDropDown_G -->

    <script language=""JavaScript""> //Dropdown specific functions, which manipulate dropdown specific global variables
        //for the dropdown lstDropDown_H

        /*----------------------------------------------
        Dropdown specific global variables are:
        -----------------------------------------------
        1) vEditableOptionIndex_H   --> this needs to be set by Programmer!! See explanation.
        2) vEditableOptionText_H    --> this needs to be set by Programmer!! See explanation.
        3) vUseActualTexbox_H       --> this needs to be set by Programmer!! See explanation.
        4) vPreviousSelectIndex_H
        5) vSelectIndex_H
        6) vSelectChange_H
      
        --------------------------- source: http://chakrabarty.com/pp_editable_Hropdown.html */

        /*----------------------------------------------
        Dropdown specific functions
        (which manipulate dropdown specific global variables)
        -----------------------------------------------
        1) function fnChangeHandler_H(getdropdown)
        2) function fnFocusHandler_H (getdropdown)
        3) function fnKeyPressHandler_H(getdropdown, e)
        4) function fnKeyUpHandler_H(getdropdown, e)
        5) function fnKeyDownHandler_H(getdropdown, e)
      
        --------------------------- source: http://chakrabarty.com/pp_editable_Hropdown.html */

        /*------------------------------------------------
        IMPORTANT: Global Variable required to be SET by programmer
        -------------------------- source: http://chakrabarty.com/pp_editable_Hropdown.html  */

        var vEditableOptionIndex_H = 3;

        // Give Index of Editable option in the dropdown.
        // For eg.
        // if first option is editable then vEditableOptionIndex_H = 0;
        // if second option is editable then vEditableOptionIndex_H = 1;
        // if third option is editable then vEditableOptionIndex_H = 2;
        // if last option is editable then vEditableOptionIndex_H = (length of dropdown - 1).
        // Note: the value of vEditableOptionIndex_H cannot be greater than (length of dropdown - 1)

        var vEditableOptionText_H = ""--?--"";

        // Give the default text of the Editable option in the dropdown.
        // For eg.
        // if the editable option is <option ...>--?--</option>,
        // then set vEditableOptionText_H = ""--?--"";

        var vUseActualTexbox_H = ""no"";
        // = ""no"" ...
        //      default is 'no' because there is no need to use an actual textbox if using a PC (with physical keyboard)
        //      if using iPad/iPhone or Android device, which usually have a virtual soft keyboard, then textbox will automatically show up next to dropdown on those devices
        // = ""yes"" ...
        //      set this to 'yes' if and only if you want an actual textbox to show up next to dropdown at all times (even on devices with physical keyboards)

        /*------------------------------------------------
        Global Variables required for
        fnChangeHandler_H(), fnKeyPressHandler_H() and fnKeyUpHandler_H()
        for Editable Dropdowns
        -------------------------- source: http://chakrabarty.com/pp_editable_Hropdown.html  */

        var vPreviousSelectIndex_H = 0;
        // Contains the Previously Selected Index, set to 0 by default

        var vSelectIndex_H = 0;
        // Contains the Currently Selected Index, set to 0 by default

        var vSelectChange_H = 'MANUAL_HLICK';
        // Indicates whether Change in dropdown selected option
        // was due to a Manual Click
        // or instead due to System properties of dropdown.

        // vSelectChange_H = 'MANUAL_HLICK' indicates that
        // the jump to a non-editable option in the dropdown was due
        // to a Manual click (i.e.,changed on purpose by user).

        // vSelectChange_H = 'AUTO_SYSTEM' indicates that
        // the jump to a non-editable option was due to System properties of dropdown
        // (i.e.,user did not change the option in the dropdown;
        // instead an automatic jump happened due to inbuilt
        // dropdown properties of browser on typing of a character )

        /*------------------------------------------------
        Functions required for  Editable Dropdowns
        -------------------------- source: http://chakrabarty.com/pp_editable_Hropdown.html  */

        function fnSanityCheck_H(getdropdown) {
            if (vEditableOptionIndex_H > (getdropdown.options.length - 1)) {
                alert(""PROGRAMMING ERROR: The value of variable vEditableOptionIndex_... cannot be greater than (length of dropdown - 1)"");
                return false;
            }
        }

        function fnKeyDownHandler_H(getdropdown, e) {
            fnSanityCheck_H(getdropdown);

            // Press [ <- ] and [ -> ] arrow keys on the keyboard to change alignment/flow.
            // ...go to Start : Press  [ <- ] Arrow Key
            // ...go to End : Press [ -> ] Arrow Key
            // (this is useful when the edited-text content exceeds the ListBox-fixed-width)
            // This works best on Internet Explorer, and not on NetscapeFirefoxChrome

            var vEventKeyCode = FindKeyCode(e);

            // Press left/right arrow keys
            if (vEventKeyCode == 37) {
                fnLeftToRight(getdropdown);
            }
            if (vEventKeyCode == 39) {
                fnRightToLeft(getdropdown);
            }

            // Delete key pressed
            if (vEventKeyCode == 46) {
                if (getdropdown.options.length != 0)
                    // if dropdown is not empty
                {
                    if (getdropdown.options.selectedIndex == vEditableOptionIndex_H)
                        // if option is the Editable field
                    {
                        getdropdown.options[getdropdown.options.selectedIndex].text = '';
                        getdropdown.options[getdropdown.options.selectedIndex].value = '';
                    }
                }
            }

            // backspace key pressed
            if (vEventKeyCode == 8 || vEventKeyCode == 127) {
                if (getdropdown.options.length != 0)
                    // if dropdown is not empty
                {
                    if (getdropdown.options.selectedIndex == vEditableOptionIndex_H)
                        // if option is the Editable field
                    {
                        // make Editable option Null if it is being edited for the first time
                        if ((getdropdown[vEditableOptionIndex_H].text == vEditableOptionText_H) || (getdropdown[vEditableOptionIndex_H].value == vEditableOptionText_H)) {
                            getdropdown.options[getdropdown.options.selectedIndex].text = '';
                            getdropdown.options[getdropdown.options.selectedIndex].value = '';
                        }
                        else {
                            getdropdown.options[getdropdown.options.selectedIndex].text = getdropdown.options[getdropdown.options.selectedIndex].text.slice(0, -1);
                            getdropdown.options[getdropdown.options.selectedIndex].value = getdropdown.options[getdropdown.options.selectedIndex].value.slice(0, -1);
                        }
                    }
                }
                if (e.which) //NetscapeFirefoxChrome
                {
                    e.which = '';
                }
                else //Internet Explorer
                {
                    e.keyCode = '';
                }
                if (e.cancelBubble)	  //Internet Explorer
                {
                    e.cancelBubble = true;
                    e.returnValue = false;
                }
                if (e.stopPropagation)	 //NetscapeFirefoxChrome
                {
                    e.stopPropagation();
                }
                if (e.preventDefault)	 //NetscapeFirefoxChrome
                {
                    e.preventDefault();
                }
            }
        }

        function fnFocusHandler_H(getdropdown) {
            //use textbox for devices such as android and ipad that don't have a physical keyboard (textbox allows use of virtual soft keyboard)
            if ((navigator.userAgent.toLowerCase().search(/android|ipad|iphone|ipod/) > -1) || (vUseActualTexbox_H == 'yes')) {
                if (getdropdown[(vEditableOptionIndex_H)].selected == true) {
                    document.getElementById('textboxoption_H').style.visibility = '';
                    document.getElementById('textboxoption_H').style.display = '';
                }
                else {
                    document.getElementById('textboxoption_H').style.visibility = 'hidden';
                    document.getElementById('textboxoption_H').style.display = 'none';
                }
            }
        }

        function fnChangeHandler_H(getdropdown) {
            fnSanityCheck_H(getdropdown);

            vPreviousSelectIndex_H = vSelectIndex_H;
            // Contains the Previously Selected Index

            vSelectIndex_H = getdropdown.options.selectedIndex;
            // Contains the Currently Selected Index

            if ((vPreviousSelectIndex_H == (vEditableOptionIndex_H)) && (vSelectIndex_H != (vEditableOptionIndex_H)) && (vSelectChange_H != 'MANUAL_HLICK'))
                // To Set value of Index variables - source: http://chakrabarty.com/pp_editable_Hropdown.html
            {
                getdropdown[(vEditableOptionIndex_H)].selected = true;
                vPreviousSelectIndex_H = vSelectIndex_H;
                vSelectIndex_H = getdropdown.options.selectedIndex;
                vSelectChange_H = 'MANUAL_HLICK';
                // Indicates that the Change in dropdown selected
                // option was due to a Manual Click
            }

            //use textbox for devices such as android and ipad that don't have a physical keyboard (textbox allows use of virtual soft keyboard)
            if ((navigator.userAgent.toLowerCase().search(/android|ipad|iphone|ipod/) > -1) || (vUseActualTexbox_H == 'yes')) {
                fnFocusHandler_H(getdropdown);
            }

        }

        function fnKeyPressHandler_H(getdropdown, e) {
            fnSanityCheck_H(getdropdown);

            keycode = FindKeyCode(e);
            keychar = FindKeyChar(e);

            // Check for allowable Characters
            // The various characters allowable for entry into Editable option..
            // may be customized by minor modifications in the code (if condition below)
            // (you need to know the keycode/ASCII value of the  character to be allowed/disallowed.
            // - source: http://chakrabarty.com/pp_editable_Hropdown.html

            if ((keycode > 47 && keycode < 59) || (keycode > 62 && keycode < 127) || (keycode == 32)) {
                var vAllowableCharacter = ""yes"";
            }
            else {
                var vAllowableCharacter = ""no"";
            }

            //alert(window); alert(window.event);

            if (getdropdown.options.length != 0)
                // if dropdown is not empty
                if (getdropdown.options.selectedIndex == (vEditableOptionIndex_H))
                    // if selected option the Editable option of the dropdown
                {

                    // Empty space (ascii 32)  is not captured by NetscapeFirefoxChrome when .text is used
                    // NetscapeFirefoxChrome removes extra spaces at end of string when .text is used
                    // NetscapeFirefoxChrome allows one empty space at end of string when .value is used
                    // Hence, use .value insead of .text
                    var vEditString = getdropdown[vEditableOptionIndex_H].value;

                    // make Editable option Null if it is being edited for the first time
                    if (vAllowableCharacter == ""yes"") {
                        if ((getdropdown[vEditableOptionIndex_H].text == vEditableOptionText_H) || (getdropdown[vEditableOptionIndex_H].value == vEditableOptionText_H))
                            vEditString = """";
                    }

                    if (vAllowableCharacter == ""yes"")
                        // To handle addition of a character - source: http://chakrabarty.com/pp_editable_Hropdown.html
                    {
                        vEditString += String.fromCharCode(keycode);
                        // Concatenate Enter character to Editable string

                        // The following portion handles the ""automatic Jump"" bug
                        // The ""automatic Jump"" bug (Description):
                        //   If a alphabet is entered (while editing)
                        //   ...which is contained as a first character in one of the read-only options
                        //   ..the focus automatically ""jumps"" to the read-only option
                        //   (-- this is a common property of normal dropdowns
                        //    ..but..is undesirable while editing).

                        var i = 0;
                        var vEnteredChar = String.fromCharCode(keycode);
                        var vUpperCaseEnteredChar = vEnteredChar;
                        var vLowerCaseEnteredChar = vEnteredChar;


                        if (((keycode) >= 97) && ((keycode) <= 122))
                            // if vEnteredChar lowercase
                            vUpperCaseEnteredChar = String.fromCharCode(keycode - 32);
                        // This is UpperCase


                        if (((keycode) >= 65) && ((keycode) <= 90))
                            // if vEnteredChar is UpperCase
                            vLowerCaseEnteredChar = String.fromCharCode(keycode + 32);
                        // This is lowercase

                        if (e.which) //For NetscapeFirefoxChrome
                        {
                            // Compare the typed character (into the editable option)
                            // with the first character of all the other
                            // options (non-editable).

                            // To note if the jump to the non-editable option was due
                            // to a Manual click (i.e.,changed on purpose by user)
                            // or instead due to System properties of dropdown
                            // (i.e.,user did not change the option in the dropdown;
                            // instead an automatic jump happened due to inbuilt
                            // dropdown properties of browser on typing of a character )

                            for (i = 0; i <= (getdropdown.options.length - 1) ; i++) {
                                if (i != vEditableOptionIndex_H) {
                                    var vEnteredDigitNumber = getdropdown[vEditableOptionIndex_H].text.length;
                                    var vFirstReadOnlyChar = getdropdown[i].text.substring(0, 1);
                                    var vEquivalentReadOnlyChar = getdropdown[i].text.substring(vEnteredDigitNumber, vEnteredDigitNumber + 1);
                                    if (vEnteredDigitNumber >= getdropdown[i].text.length) {
                                        vEquivalentReadOnlyChar = vFirstReadOnlyChar;
                                    }
                                    if ((vEquivalentReadOnlyChar == vUpperCaseEnteredChar) || (vEquivalentReadOnlyChar == vLowerCaseEnteredChar)
                                      || (vFirstReadOnlyChar == vUpperCaseEnteredChar) || (vFirstReadOnlyChar == vLowerCaseEnteredChar)) {
                                        vSelectChange_H = 'AUTO_SYSTEM';
                                        // Indicates that the Change in dropdown selected
                                        // option was due to System properties of dropdown
                                        break;
                                    }
                                    else {
                                        vSelectChange_H = 'MANUAL_HLICK';
                                        // Indicates that the Change in dropdown selected
                                        // option was due to a Manual Click
                                    }
                                }
                            }
                        }
                    }

                    // Set the new edited string into the Editable option
                    getdropdown.options[vEditableOptionIndex_H].text = vEditString;
                    getdropdown.options[vEditableOptionIndex_H].value = vEditString;

                    return false;
                }
            return true;
        }

        function fnKeyUpHandler_H(getdropdown, e) {
            fnSanityCheck_H(getdropdown);

            if (e.which) // NetscapeFirefoxChrome
            {
                if (vSelectChange_H == 'AUTO_SYSTEM') {
                    // if editable dropdown option jumped while editing
                    // (due to typing of a character which is the first character of some other option)
                    // then go back to the editable option.
                    getdropdown[(vEditableOptionIndex_H)].selected = true;
                    vSelectChange_H = 'MANUAL_CLICK';
                }

                var vEventKeyCode = FindKeyCode(e);
                // if [ <- ] or [ -> ] arrow keys are pressed, select the editable option
                if ((vEventKeyCode == 37) || (vEventKeyCode == 39)) {
                    getdropdown[vEditableOptionIndex_H].selected = true;
                }
            }
        }

        /*-------------------------------------------------------------------------------------------- source: http://chakrabarty.com/pp_editable_Hropdown.html */

</script> <!--end of script for dropdown lstDropDown_H -->

    <script language=""JavaScript""> //Dropdown specific functions, which manipulate dropdown specific global variables
        //for the dropdown lstDropDown_I

        /*----------------------------------------------
        Dropdown specific global variables are:
        -----------------------------------------------
        1) vEditableOptionIndex_I   --> this needs to be set by Programmer!! See explanation.
        2) vEditableOptionText_I    --> this needs to be set by Programmer!! See explanation.
        3) vUseActualTexbox_I       --> this needs to be set by Programmer!! See explanation.
        4) vPreviousSelectIndex_I
        5) vSelectIndex_I
        6) vSelectChange_I
      
        --------------------------- source: http://chakrabarty.com/pp_editable_Iropdown.html */

        /*----------------------------------------------
        Dropdown specific functions
        (which manipulate dropdown specific global variables)
        -----------------------------------------------
        1) function fnChangeHandler_I(getdropdown)
        2) function fnFocusHandler_I (getdropdown)
        3) function fnKeyPressHandler_I(getdropdown, e)
        4) function fnKeyUpHandler_I(getdropdown, e)
        5) function fnKeyDownHandler_I(getdropdown, e)
      
        --------------------------- source: http://chakrabarty.com/pp_editable_Iropdown.html */

        /*------------------------------------------------
        IMPORTANT: Global Variable required to be SET by programmer
        -------------------------- source: http://chakrabarty.com/pp_editable_Iropdown.html  */

        var vEditableOptionIndex_I = 2;

        // Give Index of Editable option in the dropdown.
        // For eg.
        // if first option is editable then vEditableOptionIndex_I = 0;
        // if second option is editable then vEditableOptionIndex_I = 1;
        // if third option is editable then vEditableOptionIndex_I = 2;
        // if last option is editable then vEditableOptionIndex_I = (length of dropdown - 1).
        // Note: the value of vEditableOptionIndex_I cannot be greater than (length of dropdown - 1)

        var vEditableOptionText_I = ""--?--"";

        // Give the default text of the Editable option in the dropdown.
        // For eg.
        // if the editable option is <option ...>--?--</option>,
        // then set vEditableOptionText_I = ""--?--"";

        var vUseActualTexbox_I = ""no"";
        // = ""no"" ...
        //      default is 'no' because there is no need to use an actual textbox if using a PC (with physical keyboard)
        //      if using iPad/iPhone or Android device, which usually have a virtual soft keyboard, then textbox will automatically show up next to dropdown on those devices
        // = ""yes"" ...
        //      set this to 'yes' if and only if you want an actual textbox to show up next to dropdown at all times (even on devices with physical keyboards)

        /*------------------------------------------------
        Global Variables required for
        fnChangeHandler_I(), fnKeyPressHandler_I() and fnKeyUpHandler_I()
        for Editable Dropdowns
        -------------------------- source: http://chakrabarty.com/pp_editable_Iropdown.html  */

        var vPreviousSelectIndex_I = 0;
        // Contains the Previously Selected Index, set to 0 by default

        var vSelectIndex_I = 0;
        // Contains the Currently Selected Index, set to 0 by default

        var vSelectChange_I = 'MANUAL_ILICK';
        // Indicates whether Change in dropdown selected option
        // was due to a Manual Click
        // or instead due to System properties of dropdown.

        // vSelectChange_I = 'MANUAL_ILICK' indicates that
        // the jump to a non-editable option in the dropdown was due
        // to a Manual click (i.e.,changed on purpose by user).

        // vSelectChange_I = 'AUTO_SYSTEM' indicates that
        // the jump to a non-editable option was due to System properties of dropdown
        // (i.e.,user did not change the option in the dropdown;
        // instead an automatic jump happened due to inbuilt
        // dropdown properties of browser on typing of a character )

        /*------------------------------------------------
        Functions required for  Editable Dropdowns
        -------------------------- source: http://chakrabarty.com/pp_editable_Iropdown.html  */

        function fnSanityCheck_I(getdropdown) {
            if (vEditableOptionIndex_I > (getdropdown.options.length - 1)) {
                alert(""PROGRAMMING ERROR: The value of variable vEditableOptionIndex_... cannot be greater than (length of dropdown - 1)"");
                return false;
            }
        }

        function fnKeyDownHandler_I(getdropdown, e) {
            fnSanityCheck_I(getdropdown);

            // Press [ <- ] and [ -> ] arrow keys on the keyboard to change alignment/flow.
            // ...go to Start : Press  [ <- ] Arrow Key
            // ...go to End : Press [ -> ] Arrow Key
            // (this is useful when the edited-text content exceeds the ListBox-fixed-width)
            // This works best on Internet Explorer, and not on NetscapeFirefoxChrome

            var vEventKeyCode = FindKeyCode(e);

            // Press left/right arrow keys
            if (vEventKeyCode == 37) {
                fnLeftToRight(getdropdown);
            }
            if (vEventKeyCode == 39) {
                fnRightToLeft(getdropdown);
            }

            // Delete key pressed
            if (vEventKeyCode == 46) {
                if (getdropdown.options.length != 0)
                    // if dropdown is not empty
                {
                    if (getdropdown.options.selectedIndex == vEditableOptionIndex_I)
                        // if option is the Editable field
                    {
                        getdropdown.options[getdropdown.options.selectedIndex].text = '';
                        getdropdown.options[getdropdown.options.selectedIndex].value = '';
                    }
                }
            }

            // backspace key pressed
            if (vEventKeyCode == 8 || vEventKeyCode == 127) {
                if (getdropdown.options.length != 0)
                    // if dropdown is not empty
                {
                    if (getdropdown.options.selectedIndex == vEditableOptionIndex_I)
                        // if option is the Editable field
                    {
                        // make Editable option Null if it is being edited for the first time
                        if ((getdropdown[vEditableOptionIndex_I].text == vEditableOptionText_I) || (getdropdown[vEditableOptionIndex_I].value == vEditableOptionText_I)) {
                            getdropdown.options[getdropdown.options.selectedIndex].text = '';
                            getdropdown.options[getdropdown.options.selectedIndex].value = '';
                        }
                        else {
                            getdropdown.options[getdropdown.options.selectedIndex].text = getdropdown.options[getdropdown.options.selectedIndex].text.slice(0, -1);
                            getdropdown.options[getdropdown.options.selectedIndex].value = getdropdown.options[getdropdown.options.selectedIndex].value.slice(0, -1);
                        }
                    }
                }
                if (e.which) //NetscapeFirefoxChrome
                {
                    e.which = '';
                }
                else //Internet Explorer
                {
                    e.keyCode = '';
                }
                if (e.cancelBubble)	  //Internet Explorer
                {
                    e.cancelBubble = true;
                    e.returnValue = false;
                }
                if (e.stopPropagation)	 //NetscapeFirefoxChrome
                {
                    e.stopPropagation();
                }
                if (e.preventDefault)	 //NetscapeFirefoxChrome
                {
                    e.preventDefault();
                }
            }
        }

        function fnFocusHandler_I(getdropdown) {
            //use textbox for devices such as android and ipad that don't have a physical keyboard (textbox allows use of virtual soft keyboard)
            if ((navigator.userAgent.toLowerCase().search(/android|ipad|iphone|ipod/) > -1) || (vUseActualTexbox_I == 'yes')) {
                if (getdropdown[(vEditableOptionIndex_I)].selected == true) {
                    document.getElementById('textboxoption_I').style.visibility = '';
                    document.getElementById('textboxoption_I').style.display = '';
                }
                else {
                    document.getElementById('textboxoption_I').style.visibility = 'hidden';
                    document.getElementById('textboxoption_I').style.display = 'none';
                }
            }
        }

        function fnChangeHandler_I(getdropdown) {
            fnSanityCheck_I(getdropdown);

            vPreviousSelectIndex_I = vSelectIndex_I;
            // Contains the Previously Selected Index

            vSelectIndex_I = getdropdown.options.selectedIndex;
            // Contains the Currently Selected Index

            if ((vPreviousSelectIndex_I == (vEditableOptionIndex_I)) && (vSelectIndex_I != (vEditableOptionIndex_I)) && (vSelectChange_I != 'MANUAL_ILICK'))
                // To Set value of Index variables - source: http://chakrabarty.com/pp_editable_Iropdown.html
            {
                getdropdown[(vEditableOptionIndex_I)].selected = true;
                vPreviousSelectIndex_I = vSelectIndex_I;
                vSelectIndex_I = getdropdown.options.selectedIndex;
                vSelectChange_I = 'MANUAL_ILICK';
                // Indicates that the Change in dropdown selected
                // option was due to a Manual Click
            }

            //use textbox for devices such as android and ipad that don't have a physical keyboard (textbox allows use of virtual soft keyboard)
            if ((navigator.userAgent.toLowerCase().search(/android|ipad|iphone|ipod/) > -1) || (vUseActualTexbox_I == 'yes')) {
                fnFocusHandler_I(getdropdown);
            }

        }

        function fnKeyPressHandler_I(getdropdown, e) {
            fnSanityCheck_I(getdropdown);

            keycode = FindKeyCode(e);
            keychar = FindKeyChar(e);

            // Check for allowable Characters
            // The various characters allowable for entry into Editable option..
            // may be customized by minor modifications in the code (if condition below)
            // (you need to know the keycode/ASCII value of the  character to be allowed/disallowed.
            // - source: http://chakrabarty.com/pp_editable_Iropdown.html

            if ((keycode > 47 && keycode < 59) || (keycode > 62 && keycode < 127) || (keycode == 32)) {
                var vAllowableCharacter = ""yes"";
            }
            else {
                var vAllowableCharacter = ""no"";
            }

            //alert(window); alert(window.event);

            if (getdropdown.options.length != 0)
                // if dropdown is not empty
                if (getdropdown.options.selectedIndex == (vEditableOptionIndex_I))
                    // if selected option the Editable option of the dropdown
                {

                    // Empty space (ascii 32)  is not captured by NetscapeFirefoxChrome when .text is used
                    // NetscapeFirefoxChrome removes extra spaces at end of string when .text is used
                    // NetscapeFirefoxChrome allows one empty space at end of string when .value is used
                    // Hence, use .value insead of .text
                    var vEditString = getdropdown[vEditableOptionIndex_I].value;

                    // make Editable option Null if it is being edited for the first time
                    if (vAllowableCharacter == ""yes"") {
                        if ((getdropdown[vEditableOptionIndex_I].text == vEditableOptionText_I) || (getdropdown[vEditableOptionIndex_I].value == vEditableOptionText_I))
                            vEditString = """";
                    }

                    if (vAllowableCharacter == ""yes"")
                        // To handle addition of a character - source: http://chakrabarty.com/pp_editable_Iropdown.html
                    {
                        vEditString += String.fromCharCode(keycode);
                        // Concatenate Enter character to Editable string

                        // The following portion handles the ""automatic Jump"" bug
                        // The ""automatic Jump"" bug (Description):
                        //   If a alphabet is entered (while editing)
                        //   ...which is contained as a first character in one of the read-only options
                        //   ..the focus automatically ""jumps"" to the read-only option
                        //   (-- this is a common property of normal dropdowns
                        //    ..but..is undesirable while editing).

                        var i = 0;
                        var vEnteredChar = String.fromCharCode(keycode);
                        var vUpperCaseEnteredChar = vEnteredChar;
                        var vLowerCaseEnteredChar = vEnteredChar;


                        if (((keycode) >= 97) && ((keycode) <= 122))
                            // if vEnteredChar lowercase
                            vUpperCaseEnteredChar = String.fromCharCode(keycode - 32);
                        // This is UpperCase


                        if (((keycode) >= 65) && ((keycode) <= 90))
                            // if vEnteredChar is UpperCase
                            vLowerCaseEnteredChar = String.fromCharCode(keycode + 32);
                        // This is lowercase

                        if (e.which) //For NetscapeFirefoxChrome
                        {
                            // Compare the typed character (into the editable option)
                            // with the first character of all the other
                            // options (non-editable).

                            // To note if the jump to the non-editable option was due
                            // to a Manual click (i.e.,changed on purpose by user)
                            // or instead due to System properties of dropdown
                            // (i.e.,user did not change the option in the dropdown;
                            // instead an automatic jump happened due to inbuilt
                            // dropdown properties of browser on typing of a character )

                            for (i = 0; i <= (getdropdown.options.length - 1) ; i++) {
                                if (i != vEditableOptionIndex_I) {
                                    var vEnteredDigitNumber = getdropdown[vEditableOptionIndex_I].text.length;
                                    var vFirstReadOnlyChar = getdropdown[i].text.substring(0, 1);
                                    var vEquivalentReadOnlyChar = getdropdown[i].text.substring(vEnteredDigitNumber, vEnteredDigitNumber + 1);
                                    if (vEnteredDigitNumber >= getdropdown[i].text.length) {
                                        vEquivalentReadOnlyChar = vFirstReadOnlyChar;
                                    }
                                    if ((vEquivalentReadOnlyChar == vUpperCaseEnteredChar) || (vEquivalentReadOnlyChar == vLowerCaseEnteredChar)
                                      || (vFirstReadOnlyChar == vUpperCaseEnteredChar) || (vFirstReadOnlyChar == vLowerCaseEnteredChar)) {
                                        vSelectChange_I = 'AUTO_SYSTEM';
                                        // Indicates that the Change in dropdown selected
                                        // option was due to System properties of dropdown
                                        break;
                                    }
                                    else {
                                        vSelectChange_I = 'MANUAL_ILICK';
                                        // Indicates that the Change in dropdown selected
                                        // option was due to a Manual Click
                                    }
                                }
                            }
                        }
                    }

                    // Set the new edited string into the Editable option
                    getdropdown.options[vEditableOptionIndex_I].text = vEditString;
                    getdropdown.options[vEditableOptionIndex_I].value = vEditString;

                    return false;
                }
            return true;
        }

        function fnKeyUpHandler_I(getdropdown, e) {
            fnSanityCheck_I(getdropdown);

            if (e.which) // NetscapeFirefoxChrome
            {
                if (vSelectChange_I == 'AUTO_SYSTEM') {
                    // if editable dropdown option jumped while editing
                    // (due to typing of a character which is the first character of some other option)
                    // then go back to the editable option.
                    getdropdown[(vEditableOptionIndex_I)].selected = true;
                    vSelectChange_I = 'MANUAL_CLICK';
                }

                var vEventKeyCode = FindKeyCode(e);
                // if [ <- ] or [ -> ] arrow keys are pressed, select the editable option
                if ((vEventKeyCode == 37) || (vEventKeyCode == 39)) {
                    getdropdown[vEditableOptionIndex_I].selected = true;
                }
            }
        }

        /*-------------------------------------------------------------------------------------------- source: http://chakrabarty.com/pp_editable_Iropdown.html */

</script> <!--end of script for dropdown lstDropDown_I -->

    <script language=""JavaScript""> //Dropdown specific functions, which manipulate dropdown specific global variables
        //for the dropdown lstDropDown_J

        /*----------------------------------------------
        Dropdown specific global variables are:
        -----------------------------------------------
        1) vEditableOptionIndex_J   --> this needs to be set by Programmer!! See explanation.
        2) vEditableOptionText_J    --> this needs to be set by Programmer!! See explanation.
        3) vUseActualTexbox_J       --> this needs to be set by Programmer!! See explanation.
        4) vPreviousSelectIndex_J
        5) vSelectIndex_J
        6) vSelectChange_J
      
        --------------------------- source: http://chakrabarty.com/pp_editable_Jropdown.html */

        /*----------------------------------------------
        Dropdown specific functions
        (which manipulate dropdown specific global variables)
        -----------------------------------------------
        1) function fnChangeHandler_J(getdropdown)
        2) function fnFocusHandler_J (getdropdown)
        3) function fnKeyPressHandler_J(getdropdown, e)
        4) function fnKeyUpHandler_J(getdropdown, e)
        5) function fnKeyDownHandler_J(getdropdown, e)
      
        --------------------------- source: http://chakrabarty.com/pp_editable_Jropdown.html */

        /*------------------------------------------------
        IMPORTANT: Global Variable required to be SET by programmer
        -------------------------- source: http://chakrabarty.com/pp_editable_Jropdown.html  */

        var vEditableOptionIndex_J = 2;

        // Give Index of Editable option in the dropdown.
        // For eg.
        // if first option is editable then vEditableOptionIndex_J = 0;
        // if second option is editable then vEditableOptionIndex_J = 1;
        // if third option is editable then vEditableOptionIndex_J = 2;
        // if last option is editable then vEditableOptionIndex_J = (length of dropdown - 1).
        // Note: the value of vEditableOptionIndex_J cannot be greater than (length of dropdown - 1)

        var vEditableOptionText_J = ""--?--"";

        // Give the default text of the Editable option in the dropdown.
        // For eg.
        // if the editable option is <option ...>--?--</option>,
        // then set vEditableOptionText_J = ""--?--"";

        var vUseActualTexbox_J = ""no"";
        // = ""no"" ...
        //      default is 'no' because there is no need to use an actual textbox if using a PC (with physical keyboard)
        //      if using iPad/iPhone or Android device, which usually have a virtual soft keyboard, then textbox will automatically show up next to dropdown on those devices
        // = ""yes"" ...
        //      set this to 'yes' if and only if you want an actual textbox to show up next to dropdown at all times (even on devices with physical keyboards)

        /*------------------------------------------------
        Global Variables required for
        fnChangeHandler_J(), fnKeyPressHandler_J() and fnKeyUpHandler_J()
        for Editable Dropdowns
        -------------------------- source: http://chakrabarty.com/pp_editable_Jropdown.html  */

        var vPreviousSelectIndex_J = 0;
        // Contains the Previously Selected Index, set to 0 by default

        var vSelectIndex_J = 0;
        // Contains the Currently Selected Index, set to 0 by default

        var vSelectChange_J = 'MANUAL_JLICK';
        // Indicates whether Change in dropdown selected option
        // was due to a Manual Click
        // or instead due to System properties of dropdown.

        // vSelectChange_J = 'MANUAL_JLICK' indicates that
        // the jump to a non-editable option in the dropdown was due
        // to a Manual click (i.e.,changed on purpose by user).

        // vSelectChange_J = 'AUTO_SYSTEM' indicates that
        // the jump to a non-editable option was due to System properties of dropdown
        // (i.e.,user did not change the option in the dropdown;
        // instead an automatic jump happened due to inbuilt
        // dropdown properties of browser on typing of a character )

        /*------------------------------------------------
        Functions required for  Editable Dropdowns
        -------------------------- source: http://chakrabarty.com/pp_editable_Jropdown.html  */

        function fnSanityCheck_J(getdropdown) {
            if (vEditableOptionIndex_J > (getdropdown.options.length - 1)) {
                alert(""PROGRAMMING ERROR: The value of variable vEditableOptionIndex_... cannot be greater than (length of dropdown - 1)"");
                return false;
            }
        }

        function fnKeyDownHandler_J(getdropdown, e) {
            fnSanityCheck_J(getdropdown);

            // Press [ <- ] and [ -> ] arrow keys on the keyboard to change alignment/flow.
            // ...go to Start : Press  [ <- ] Arrow Key
            // ...go to End : Press [ -> ] Arrow Key
            // (this is useful when the edited-text content exceeds the ListBox-fixed-width)
            // This works best on Internet Explorer, and not on NetscapeFirefoxChrome

            var vEventKeyCode = FindKeyCode(e);

            // Press left/right arrow keys
            if (vEventKeyCode == 37) {
                fnLeftToRight(getdropdown);
            }
            if (vEventKeyCode == 39) {
                fnRightToLeft(getdropdown);
            }

            // Delete key pressed
            if (vEventKeyCode == 46) {
                if (getdropdown.options.length != 0)
                    // if dropdown is not empty
                {
                    if (getdropdown.options.selectedIndex == vEditableOptionIndex_J)
                        // if option is the Editable field
                    {
                        getdropdown.options[getdropdown.options.selectedIndex].text = '';
                        getdropdown.options[getdropdown.options.selectedIndex].value = '';
                    }
                }
            }

            // backspace key pressed
            if (vEventKeyCode == 8 || vEventKeyCode == 127) {
                if (getdropdown.options.length != 0)
                    // if dropdown is not empty
                {
                    if (getdropdown.options.selectedIndex == vEditableOptionIndex_J)
                        // if option is the Editable field
                    {
                        // make Editable option Null if it is being edited for the first time
                        if ((getdropdown[vEditableOptionIndex_J].text == vEditableOptionText_J) || (getdropdown[vEditableOptionIndex_J].value == vEditableOptionText_J)) {
                            getdropdown.options[getdropdown.options.selectedIndex].text = '';
                            getdropdown.options[getdropdown.options.selectedIndex].value = '';
                        }
                        else {
                            getdropdown.options[getdropdown.options.selectedIndex].text = getdropdown.options[getdropdown.options.selectedIndex].text.slice(0, -1);
                            getdropdown.options[getdropdown.options.selectedIndex].value = getdropdown.options[getdropdown.options.selectedIndex].value.slice(0, -1);
                        }
                    }
                }
                if (e.which) //NetscapeFirefoxChrome
                {
                    e.which = '';
                }
                else //Internet Explorer
                {
                    e.keyCode = '';
                }
                if (e.cancelBubble)	  //Internet Explorer
                {
                    e.cancelBubble = true;
                    e.returnValue = false;
                }
                if (e.stopPropagation)	 //NetscapeFirefoxChrome
                {
                    e.stopPropagation();
                }
                if (e.preventDefault)	 //NetscapeFirefoxChrome
                {
                    e.preventDefault();
                }
            }
        }

        function fnFocusHandler_J(getdropdown) {
            //use textbox for devices such as android and ipad that don't have a physical keyboard (textbox allows use of virtual soft keyboard)
            if ((navigator.userAgent.toLowerCase().search(/android|ipad|iphone|ipod/) > -1) || (vUseActualTexbox_J == 'yes')) {
                if (getdropdown[(vEditableOptionIndex_J)].selected == true) {
                    document.getElementById('textboxoption_J').style.visibility = '';
                    document.getElementById('textboxoption_J').style.display = '';
                }
                else {
                    document.getElementById('textboxoption_J').style.visibility = 'hidden';
                    document.getElementById('textboxoption_J').style.display = 'none';
                }
            }
        }

        function fnChangeHandler_J(getdropdown) {
            fnSanityCheck_J(getdropdown);

            vPreviousSelectIndex_J = vSelectIndex_J;
            // Contains the Previously Selected Index

            vSelectIndex_J = getdropdown.options.selectedIndex;
            // Contains the Currently Selected Index

            if ((vPreviousSelectIndex_J == (vEditableOptionIndex_J)) && (vSelectIndex_J != (vEditableOptionIndex_J)) && (vSelectChange_J != 'MANUAL_JLICK'))
                // To Set value of Index variables - source: http://chakrabarty.com/pp_editable_Jropdown.html
            {
                getdropdown[(vEditableOptionIndex_J)].selected = true;
                vPreviousSelectIndex_J = vSelectIndex_J;
                vSelectIndex_J = getdropdown.options.selectedIndex;
                vSelectChange_J = 'MANUAL_JLICK';
                // Indicates that the Change in dropdown selected
                // option was due to a Manual Click
            }

            //use textbox for devices such as android and ipad that don't have a physical keyboard (textbox allows use of virtual soft keyboard)
            if ((navigator.userAgent.toLowerCase().search(/android|ipad|iphone|ipod/) > -1) || (vUseActualTexbox_J == 'yes')) {
                fnFocusHandler_J(getdropdown);
            }

        }

        function fnKeyPressHandler_J(getdropdown, e) {
            fnSanityCheck_J(getdropdown);

            keycode = FindKeyCode(e);
            keychar = FindKeyChar(e);

            // Check for allowable Characters
            // The various characters allowable for entry into Editable option..
            // may be customized by minor modifications in the code (if condition below)
            // (you need to know the keycode/ASCII value of the  character to be allowed/disallowed.
            // - source: http://chakrabarty.com/pp_editable_Jropdown.html

            if ((keycode > 47 && keycode < 59) || (keycode > 62 && keycode < 127) || (keycode == 32)) {
                var vAllowableCharacter = ""yes"";
            }
            else {
                var vAllowableCharacter = ""no"";
            }

            //alert(window); alert(window.event);

            if (getdropdown.options.length != 0)
                // if dropdown is not empty
                if (getdropdown.options.selectedIndex == (vEditableOptionIndex_J))
                    // if selected option the Editable option of the dropdown
                {

                    // Empty space (ascii 32)  is not captured by NetscapeFirefoxChrome when .text is used
                    // NetscapeFirefoxChrome removes extra spaces at end of string when .text is used
                    // NetscapeFirefoxChrome allows one empty space at end of string when .value is used
                    // Hence, use .value insead of .text
                    var vEditString = getdropdown[vEditableOptionIndex_J].value;

                    // make Editable option Null if it is being edited for the first time
                    if (vAllowableCharacter == ""yes"") {
                        if ((getdropdown[vEditableOptionIndex_J].text == vEditableOptionText_J) || (getdropdown[vEditableOptionIndex_J].value == vEditableOptionText_J))
                            vEditString = """";
                    }

                    if (vAllowableCharacter == ""yes"")
                        // To handle addition of a character - source: http://chakrabarty.com/pp_editable_Jropdown.html
                    {
                        vEditString += String.fromCharCode(keycode);
                        // Concatenate Enter character to Editable string

                        // The following portion handles the ""automatic Jump"" bug
                        // The ""automatic Jump"" bug (Description):
                        //   If a alphabet is entered (while editing)
                        //   ...which is contained as a first character in one of the read-only options
                        //   ..the focus automatically ""jumps"" to the read-only option
                        //   (-- this is a common property of normal dropdowns
                        //    ..but..is undesirable while editing).

                        var i = 0;
                        var vEnteredChar = String.fromCharCode(keycode);
                        var vUpperCaseEnteredChar = vEnteredChar;
                        var vLowerCaseEnteredChar = vEnteredChar;


                        if (((keycode) >= 97) && ((keycode) <= 122))
                            // if vEnteredChar lowercase
                            vUpperCaseEnteredChar = String.fromCharCode(keycode - 32);
                        // This is UpperCase


                        if (((keycode) >= 65) && ((keycode) <= 90))
                            // if vEnteredChar is UpperCase
                            vLowerCaseEnteredChar = String.fromCharCode(keycode + 32);
                        // This is lowercase

                        if (e.which) //For NetscapeFirefoxChrome
                        {
                            // Compare the typed character (into the editable option)
                            // with the first character of all the other
                            // options (non-editable).

                            // To note if the jump to the non-editable option was due
                            // to a Manual click (i.e.,changed on purpose by user)
                            // or instead due to System properties of dropdown
                            // (i.e.,user did not change the option in the dropdown;
                            // instead an automatic jump happened due to inbuilt
                            // dropdown properties of browser on typing of a character )

                            for (i = 0; i <= (getdropdown.options.length - 1) ; i++) {
                                if (i != vEditableOptionIndex_J) {
                                    var vEnteredDigitNumber = getdropdown[vEditableOptionIndex_J].text.length;
                                    var vFirstReadOnlyChar = getdropdown[i].text.substring(0, 1);
                                    var vEquivalentReadOnlyChar = getdropdown[i].text.substring(vEnteredDigitNumber, vEnteredDigitNumber + 1);
                                    if (vEnteredDigitNumber >= getdropdown[i].text.length) {
                                        vEquivalentReadOnlyChar = vFirstReadOnlyChar;
                                    }
                                    if ((vEquivalentReadOnlyChar == vUpperCaseEnteredChar) || (vEquivalentReadOnlyChar == vLowerCaseEnteredChar)
                                      || (vFirstReadOnlyChar == vUpperCaseEnteredChar) || (vFirstReadOnlyChar == vLowerCaseEnteredChar)) {
                                        vSelectChange_J = 'AUTO_SYSTEM';
                                        // Indicates that the Change in dropdown selected
                                        // option was due to System properties of dropdown
                                        break;
                                    }
                                    else {
                                        vSelectChange_J = 'MANUAL_JLICK';
                                        // Indicates that the Change in dropdown selected
                                        // option was due to a Manual Click
                                    }
                                }
                            }
                        }
                    }

                    // Set the new edited string into the Editable option
                    getdropdown.options[vEditableOptionIndex_J].text = vEditString;
                    getdropdown.options[vEditableOptionIndex_J].value = vEditString;

                    return false;
                }
            return true;
        }

        function fnKeyUpHandler_J(getdropdown, e) {
            fnSanityCheck_J(getdropdown);

            if (e.which) // NetscapeFirefoxChrome
            {
                if (vSelectChange_J == 'AUTO_SYSTEM') {
                    // if editable dropdown option jumped while editing
                    // (due to typing of a character which is the first character of some other option)
                    // then go back to the editable option.
                    getdropdown[(vEditableOptionIndex_J)].selected = true;
                    vSelectChange_J = 'MANUAL_CLICK';
                }

                var vEventKeyCode = FindKeyCode(e);
                // if [ <- ] or [ -> ] arrow keys are pressed, select the editable option
                if ((vEventKeyCode == 37) || (vEventKeyCode == 39)) {
                    getdropdown[vEditableOptionIndex_J].selected = true;
                }
            }
        }

        /*-------------------------------------------------------------------------------------------- source: http://chakrabarty.com/pp_editable_Jropdown.html */

</script> <!--end of script for dropdown lstDropDown_J -->

    <script>
		
		function testNumber(txt) {
			var patt = new RegExp('^\\d+([\\.][\\d]+)?$');
			var id = '';
			switch(txt.id){
				case 'txtFare':
					id = 'tdFare';
				break;
				case 'txtTaxes':
					id = 'tdTaxes';
				break;
				case 'txtMarks':
					id = 'tdMarks';
				break;
				case 'txtCharge':
					id = 'tdCharge';
				break;
				case 'txtTotal':
					id = 'tdTotal';
				break;
			}
			var td = document.getElementById(id);
			var txtFare = document.getElementById('txtFare');
			var txtTaxes = document.getElementById('txtTaxes');
			var txtMarks = document.getElementById('txtMarks');
			var txtCharge = document.getElementById('txtCharge');
			var txtTotal = document.getElementById('txtTotal');
			if(txt.value == ''){
				td.style.color = ""black"";
				var fare = 0.0;
				var taxes = 0.0;
				var marks = 0.0;
				var charge = 0.0;
				
				if(txtFare.value != ''){
					fare = txtFare.value;
				}
				if(txtTaxes.value != ''){
					taxes = txtTaxes.value;
				}
				if(txtMarks.value != ''){
					marks = txtMarks.value;
				}
				if(txtCharge.value != ''){
					charge = txtCharge.value;
				}
                
				var total = parseFloat(fare) + parseFloat(marks) + parseFloat(taxes) + parseFloat(charge);
				txtTotal.value = (total);
			}
			else if(!txt.value.match(patt)){
				txt.value = '';
				td.style.color = ""red"";
				txt.focus();				
				if(txt.id == 'txtFare'){
					txtTotal.value = txtTaxes.value;
				}
				else if(txt.id == 'txtTaxes'){
					txtTotal.value = txtFare.value;
				}
			}
			else{
				td.style.color = ""black"";
				var fare = 0.0;
				var taxes = 0.0;
				var marks = 0.0;
				var charge = 0.0;
				if(txtFare.value != ''){
					fare = txtFare.value;
				}
				if(txtTaxes.value != ''){
					taxes = txtTaxes.value;
				}
				if(txtMarks.value != ''){
					marks = txtMarks.value;
				}
				if(txtCharge.value != ''){
					charge = txtCharge.value;
				}
				var total = parseFloat(fare) + parseFloat(marks) + parseFloat(taxes) + parseFloat(charge);
				txtTotal.value = (total);
			}
		}
		
		function testSegments(txt) {
			var patt = new RegExp('^\\d+(((([,]\\d+)*)|([-]\\d+(?![-])))*)$');
			var tdSegments = document.getElementById('tdSegments')
			if(!txt.value.match(patt)){
				txt.value = '';
				tdSegments.style.color = ""red""
				txt.focus();
			}
			else{
				tdSegments.style.color = ""#008B8B""
			}
		}
		
        function ChangesOptions(ddl) {
            var fare = document.getElementById(""txtFare"");
            var taxes = document.getElementById(""txtTaxes"");
            var charge = document.getElementById(""txtCharge"");
            var total = document.getElementById(""txtTotal"");
            var currency = document.getElementById(""hdCurrency"")
            var ddlSegment = document.getElementById(""ddlSegment"");            

            switch(ddl.selectedIndex) {
                case 0:

                    ddlSegment.options.length = 0;
                    ddlSegment.options[0] = new Option(""Seleccione codigo de tarifa"", ""0"", true, true);
                    currency.value = '';
                    fare.value = '';
                    taxes.value = '';
                    charge.value = '';
                    total.value = ''
                    break;";

					Regex regexCurrency = new Regex(@"^[A-Z]{3}((\d+[.]\d+)|(\d+))$");
					if (itineraryPNR.PQs != null)
					{
						for (int i = 0; i < itineraryPNR.PQs.Count; i++)
						{
							html += @"case " + (i + 1).ToString() + @":
                    ";

							html += @"ddlSegment.options.length = 0;
                    ddlSegment.options[0] = new Option(""Seleccione codigo de tarifa"", ""0"", true, true);";
							for (int j = 0; j < itineraryPNR.PQs[i].FareBasisCode.Count; j++)
							{
								html += @"
                    ddlSegment.options[" + (j + 1).ToString() + @"] = new Option(""" + itineraryPNR.PQs[i].FareBasisCode[j].Split('|')[0] + @""", """ + (j + 1).ToString() + @""", false, false);
";
							}

							string strTemp = itineraryPNR.PQs[i].Currency;
							html += @"currency.value = '" + strTemp + @"';
";
							strTemp = itineraryPNR.PQs[i].Fare;
							html += @"fare.value = '" + strTemp + @"';
";
							strTemp = itineraryPNR.PQs[i].Taxes;
							html += @"taxes.value = '" + strTemp + @"';
";
							html += @"charge.value = '0';
";
							strTemp = itineraryPNR.PQs[i].Total;
							html += @"total.value = '" + strTemp + @"';
                    break;
";
						}
					}
					else
					{
						for (int i = 0; i < rules.Count; i++)
						{
							html += @"case " + (i + 1).ToString() + @":
                    ";

							html += @"ddlSegment.options.length = 0;
                    ddlSegment.options[0] = new Option(""Seleccione codigo de tarifa"", ""0"", true, true);";
							for (int j = 0; j < rules[i].Count; j++)
							{
								html += @"
                    ddlSegment.options[" + (j + 1).ToString() + @"] = new Option(""" + rules[i][j].Split('|')[0] + @""", """ + (j + 1).ToString() + @""", false, false);
";
							}

							string strTemp = regexCurrency.IsMatch(PQs[i].Split('|')[0]) ? PQs[i].Split('|')[0].Substring(0, 3) : regexCurrency.IsMatch(PQs[i].Split('|')[1]) ? PQs[i].Split('|')[1].Substring(0, 3) : regexCurrency.IsMatch(PQs[i - 1].Split('|')[2]) ? PQs[i - 1].Split('|')[2].Substring(0, 3) : "MXN";
							html += @"currency.value = '" + strTemp + @"';
";
							strTemp = regexCurrency.IsMatch(PQs[i].Split('|')[0]) ? PQs[i].Split('|')[0].Substring(3) : PQs[i].Split('|')[0];
							html += @"fare.value = '" + strTemp + @"';
";
							strTemp = regexCurrency.IsMatch(PQs[i].Split('|')[1]) ? PQs[i].Split('|')[1].Substring(3) : PQs[i].Split('|')[1];
							html += @"taxes.value = '" + strTemp + @"';
";
							html += @"charge.value = '0';
";
							strTemp = regexCurrency.IsMatch(PQs[i].Split('|')[2]) ? PQs[i].Split('|')[2].Substring(3) : PQs[i].Split('|')[2];
							html += @"total.value = '" + strTemp + @"';
                    break;
";
						}

						//                        for (int i = 1; i <= PQs.Count; i++)
						//                        {
						//                            html += @"case " + i + @":
						//                    ";
						//                            string strTemp = regexCurrency.IsMatch(PQs[i - 1].Split('|')[0]) ? PQs[i - 1].Split('|')[0].Substring(0, 3) : regexCurrency.IsMatch(PQs[i - 1].Split('|')[1]) ? PQs[i - 1].Split('|')[1].Substring(0, 3) : regexCurrency.IsMatch(PQs[i - 1].Split('|')[2]) ? PQs[i - 1].Split('|')[2].Substring(0, 3) : "MXN";
						//                            html += @"currency.value = '" + strTemp + @"';
						//";
						//                            strTemp = regexCurrency.IsMatch(PQs[i - 1].Split('|')[0]) ? PQs[i - 1].Split('|')[0].Substring(3) : PQs[i - 1].Split('|')[0];
						//                            html += @"fare.value = '" + strTemp + @"';
						//";
						//                            strTemp = regexCurrency.IsMatch(PQs[i - 1].Split('|')[1]) ? PQs[i - 1].Split('|')[1].Substring(3) : PQs[i - 1].Split('|')[1];
						//                            html += @"taxes.value = '" + strTemp + @"';
						//";
						//                            html += @"charge.value = '0';
						//";
						//                            strTemp = regexCurrency.IsMatch(PQs[i - 1].Split('|')[2]) ? PQs[i - 1].Split('|')[2].Substring(3) : PQs[i - 1].Split('|')[2];
						//                            html += @"total.value = '" + strTemp + @"';
						//                    break;
						//";
						//                        }
					}
					html += @"}
                
        }

        function loadRules(){
            var rules = document.getElementById(""txtRules"");
			var ddlSegment = document.getElementById(""ddlSegment"");
            var lstPQ = document.getElementById(""lstPQ"");
            rules.style.display = """";";
					if (itineraryPNR.PQs != null)
					{
						html += @"switch(lstPQ.value){";
						for (int i = 0; i < itineraryPNR.PQs.Count; i++)
						{
							html += @"case '" + (i + 1).ToString() + @"':";
							html += @"switch(ddlSegment.value){
				case '0':
					rules.value = 'Debe seleccionar un codigo de tarifa.';
					break;";
							for (int j = 0; j < itineraryPNR.PQs[i].FareBasisCode.Count; j++)
							{

								html += @"case '" + (j + 1).ToString() + @"':
                                rules.value = '";
								ClipboardServices.ClipboardServiceClient client = new ClipboardServices.ClipboardServiceClient();
								try
								{
									client.Open();
									html += client.ExecuteSabreCommand(new List<string>() { itineraryPNR.PQs[i].FareBasisCode[j].Split('|')[1] })[0].Replace("\n", "\\n");
								}
								catch
								{
								}
								finally
								{
									if (client.State != System.ServiceModel.CommunicationState.Closed)
									{
										client.Close();
									}
								}
								html += @"';
                    break;";
							}
							html += @"}
                        break;";
						}
						html += @"}";
					}
					else
					{
						html += @"switch(lstPQ.value){";
						for (int i = 0; i < rules.Count; i++)
						{
							html += @"case '" + (i + 1).ToString() + @"':";
							html += @"switch(ddlSegment.value){
				case '0':
					rules.value = 'Debe seleccionar un codigo de tarifa.';
					break;";
							for (int j = 0; j < rules[i].Count; j++)
							{

								html += @"case '" + (j + 1).ToString() + @"':
                                rules.value = '";
								ClipboardServices.ClipboardServiceClient client = new ClipboardServices.ClipboardServiceClient();
								try
								{
									client.Open();
									html += client.ExecuteSabreCommand(new List<string>() { rules[i][j].Split('|')[1] })[0].Replace("\n", "\\n");
								}
								catch
								{
								}
								finally
								{
									if (client.State != System.ServiceModel.CommunicationState.Closed)
									{
										client.Close();
									}
								}
								html += @"';
                    break;";
							}
							html += @"}
                        break;";
						}
						html += @"}";

						//                        html += @"switch(ddlSegment.value){
						//				case '0':
						//					rules.value = 'Debe seleccionar un codigo de tarifa.';
						//					break;";

						//                        for (int i = 1; i <= rules.Count; i++)
						//                        {
						//                            html += @"case '" + i + @"':
						//					rules.value = '" + rules[i - 1].Replace("\n", "\\n") + @"';
						//					break;";
						//                        }
						//                        html += @"}";
					}
					html += @"	
        }
        
        function check(ckb) {
            if (ckb.name == 'ckbAddFare') {
                var pq = document.getElementById(""lstPQ"");
                var fare = document.getElementById(""txtFare"");
                var taxes = document.getElementById(""txtTaxes"");
                var marks = document.getElementById(""txtMarks"");
                var charge = document.getElementById(""txtCharge"");
                var total = document.getElementById(""txtTotal"");
                if (ckb.checked) {
                    pq.disabled = false;
                    fare.disabled = false;
                    taxes.disabled = false;
                    marks.disabled = false;
                    charge.disabled = false;
                    total.disabled = false;
                }
                else {
                    pq.disabled = true;
                    fare.disabled = true;
                    taxes.disabled = true;
                    marks.disabled = true;
                    charge.disabled = true;
                    total.disabled = true;
                }
            }
            else {
                var cancel = document.getElementById(""ddlCancel"");
                var chanBefDep = document.getElementById(""ddlChBDep"");
                var chanAftDep = document.getElementById(""ddlChADep"");
                var minStay = document.getElementById(""ddlMinStay"");
                var maxStay = document.getElementById(""ddlMaxStay"");
                var lastDay = document.getElementById(""ddlLastDay"");
                var visaReq = document.getElementById(""txtVisaReq"");
                var notes = document.getElementById(""txtNotes"");
                if (ckb.checked) {
                    cancel.disabled = false;
                    chanAftDep.disabled = false;
                    chanBefDep.disabled = false;
                    minStay.disabled = false;
                    maxStay.disabled = false;
                    lastDay.disabled = false;
                    visaReq.disabled = false;
                    notes.disabled = false;
                }
                else {
                    cancel.disabled = true;
                    chanAftDep.disabled = true;
                    chanBefDep.disabled = true;
                    minStay.disabled = true;
                    maxStay.disabled = true;
                    lastDay.disabled = true;
                    visaReq.disabled = true;
                    notes.disabled = true;
                }
            }

        }
    </script>
</head>
<body>
    <input type=""hidden"" value="""" id=""hdCurrency"" />
    <div style=""background-color: #538BD0; color: white; font-family: Arial, sans-serif; font-size: 8.25pt; font-weight: bold; text-align: center;"">
        Itinerario - Clipboard CTS
    </div>
    <div>
        <table style=""width:450px"">
            <tr>
                <td id=""tdSegments"" style=""color: #008B8B; font-family: Arial, sans-serif; font-size: 8.25pt; font-family: Arial, sans-serif; font-size: 8.25pt;"">Segmento:</td>
                <td>
                    <input type=""text"" id=""txtSegments"" style=""font-family: Arial, sans-serif; font-size: 8.25pt; height: 20;"" onchange=""testSegments(this);"" /></td>
                <td style=""font-family: Arial, sans-serif; font-size: 8.25pt;"">(En blanco para todo el itinerario)</td>
            </tr>
            <tr>
                <td></td>
                <td style=""font-family: Arial, sans-serif; font-size: 8.25pt;"">Ej. 1,3-5,7</td>
            </tr>
        </table>
    </div>
    <div style=""float: right;"">
        <table style=""width: 322px"">
            <tr>
                <td>
                    <input id=""btnSeeFares"" type=""button"" value=""Ver Reglas de la Tarifa"" onclick=""loadRules()"" style=""background-color: #FFFFC0; border-style: solid; border-width: 1px;  width:130; height: 20px; font-family: Arial, sans-serif; font-size: 8.25pt;"" /></td>
                <td>
					<select name=""ddlSegment"" id=""ddlSegment"" style=""width: 235px;"">
						<option value=""0"">Seleccione codigo de tarifa</option>";

					if (itineraryPNR.PQs == null)
					{
						for (int i = 1; i <= nameRules.Count; i++)
						{
							html += @"<option value=""" + i + @""">" + nameRules[i - 1] + @"</option>";
						}
					}
					html += @"</select>
					</td>
            </tr>
            <tr>
                <td colspan=""2"" width=""322px"" style=""font-family: Arial, sans-serif; font-size: 8.25pt;"">
                    <textarea rows=""4"" cols=""50"" readonly=""readonly"" style=""background-color: white; color: black; font-family: Arial, sans-serif; font-size: 8.25pt; border: 1px solid black; width: 363px; height: 416px; display: none;"" id=""txtRules""></textarea>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table style=""width:450px"">
            <tr>
                <td colspan=""4"" style=""font-family: Arial, sans-serif; font-size: 8.25pt;"">
					<input type=""checkbox"" id=""ckbShowImages"" name=""ckbShowImages"" checked=""checked"" height=""17""><font color=""#008B8B"" style=""vertical-align: 20%;"" >Mostrar Logos de Aerolíneas</font></input>
				</td>
            </tr>
        </table>
        <table style=""width:450px"">
            <tr>
                <td colspan=""4"" style=""font-family: Arial, sans-serif; font-size: 8.25pt;"">
                    <input type=""checkbox"" id=""ckbAddFare"" name=""ckbAddFare"" onclick=""check(this)"" height=""17""><font color=""#008B8B"" style=""vertical-align: 20%;"" >Agregar Tarifa e Impuestos</font></input></td>
            </tr>
        </table>
        <table style=""border-style: solid; border-width: 1px; border-color: black; width: 450px;"">
            <tr>
                <td style=""font-family: Arial, sans-serif; font-size: 8.25pt;"">PQ #:</td>
                <td rowspan=""3"" style=""font-family: Arial, sans-serif; font-size: 8.25pt; width: 78px;"">
                    <select multiple=""multiple"" style=""height: 60px; width: 71px; font-family: Arial, sans-serif; font-size: 8.25pt;"" disabled=""disabled"" id=""lstPQ"" onchange=""ChangesOptions(this);"">";
					if (PQs.Count > 0)
					{
						html += @"    <option value=""0"">Restaurar</option>";
					}
					for (int i = 1; i <= PQs.Count; i++)
					{
						html += @"<option value=""" + i + @""">" + i + @"</option>";
					}
					html += @"</select>
                </td>
                <td style=""width: 123px;"" ></td>
                <td></td>
            </tr>
            <tr>
                <td style=""height: 27px;""></td>
                <td id=""tdFare"" style=""height: 27px; width: 123px; font-family: Arial, sans-serif; font-size: 8.25pt;"">Tarifa:</td>
                <td style=""height: 27px;"">
                    <input id=""txtFare"" type=""text"" disabled=""disabled"" style=""font-family: Arial, sans-serif; font-size: 8.25pt; height: 20;"" onchange=""testNumber(this);"" /></td>
            </tr>
            <tr>
                <td></td>
                <td id=""tdTaxes"" style=""width: 123px; font-family: Arial, sans-serif; font-size: 8.25pt;"" >Impuestos:</td>
                <td>
                    <input id=""txtTaxes"" type=""text"" disabled=""disabled"" style=""font-family: Arial, sans-serif; font-size: 8.25pt; height: 20;"" onchange=""testNumber(this);"" /></td>
            </tr>
            <tr>
                <td></td>
                <td style=""width: 78px;""></td>
                <td id=""tdMarks"" style=""width: 123px; font-family: Arial, sans-serif; font-size: 8.25pt;"">Markover(oculto):</td>
                <td>
                    <input id=""txtMarks"" type=""text"" disabled=""disabled"" style=""font-family: Arial, sans-serif; font-size: 8.25pt; height: 20;"" onchange=""testNumber(this);"" /></td>
            </tr>
            <tr>
                <td style=""height: 26px;""></td>
                <td style=""height: 26px;
            width: 78px;""></td>
                <td id=""tdCharge"" style=""height: 26px; width: 123px; font-family: Arial, sans-serif; font-size: 8.25pt;"">Cargo por Servicio:</td>
                <td style=""height: 26px;"">
                    <input id=""txtCharge"" type=""text"" disabled=""disabled"" style=""font-family: Arial, sans-serif; font-size: 8.25pt; height: 20;"" onchange=""testNumber(this);"" /></td>
            </tr>
            <tr>
                <td></td>
                <td style=""width: 78px;""></td>
                <td id=""tdTotal"" style=""width: 123px; font-family: Arial, sans-serif; font-size: 8.25pt;"">Total:</td>
                <td>
                    <input id=""txtTotal"" type=""text"" disabled=""disabled"" style=""font-family: Arial, sans-serif; font-size: 8.25pt; height: 20;"" onchange=""testNumber(this);"" /></td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <td style=""font-family: Arial, sans-serif; font-size: 8.25pt;"">
                    <input type=""checkbox"" id=""ckbAddRules"" name=""ckbAddRules"" onclick=""check(this)"" height=""17"">
                        <font color=""#008B8B"" style=""vertical-align: 20%"" >Incluir Reglas</font>
                    </input>
                </td>
            </tr>
        </table>
        <table style=""border-style: solid; border-width: 1px; border-color: black; width: 450px"">
            <tr>
                <td style=""width: 184px; font-family: Arial, sans-serif; font-size: 8.25pt;"">Cancelación:</td>
                <td>
                    <!--<select style=""width: 235px"" id=""ddlCancel"" disabled=""disabled"">
                        <option value=""0"" selected=""selected"">Seleccione Regla.</option>
                        <option value=""1"">Cancellations and Refounds Allowed</option>
                        <option value=""2"">Cancellation Permitted</option>
                        <option value=""3"">Non Refundable</option>
                        <option value=""4"">Fees and Penalties Aply</option>
                    </select>-->
                    <select name=""ddlCancel"" id=""ddlCancel"" onKeyDown=""fnKeyDownHandler_D(this, event);"" onKeyUp=""fnKeyUpHandler_D(this, event); return false;"" onKeyPress = ""return fnKeyPressHandler_D(this, event);""  onChange=""fnChangeHandler_D(this);"" onFocus=""fnFocusHandler_D(this);"" disabled=""disabled"" style=""font-family: Arial, sans-serif; font-size: 8.25pt; width: 235px;"">
                        <option value="""" selected=""selected"" >Seleccione Regla.</option>
                        <option>Cancellations and Refounds Allowed</option>
                        <option>Cancellation Permitted</option>
                        <option>Non Refundable</option>
                        <option>Fees and Penalties Apply</option>
                        <option value="""" style=""font-family:Courier,monospace;color:#ff0000;background-color:#ffff00;"">Otra opción, escriba aquí.</option> <!-- This is the Editable Option -->
                    </select>
                    <input type=""text"" id=""textboxoption_D"" style=""visibility:hidden;display:none;width:150pt"" value=""select option or type here"" onfocus=""this.value = document.getElementById('ddlCancel').options[vEditableOptionIndex_D].text"" onKeyUp=""document.getElementById('ddlCancel').options[vEditableOptionIndex_D].text=this.value; document.getElementById('ddlCancel').options[vEditableOptionIndex_D].value=this.value;"" onblur=""document.getElementById('ddlCancel').options[vEditableOptionIndex_D].text=this.value; document.getElementById('ddlCancel').options[vEditableOptionIndex_D].value=this.value; document.getElementById('ddlCancel').focus();""></input>

                    <!--<input type=""text"" name=""ddlCancel"" list=""optionsCancel"" value=""Selecciona Regla."" style=""width: 235px"" id=""ddlCancel"" disabled=""disabled"" />
                    <datalist id=""optionsCancel"">
                        <option value=""Seleccione Regla."">Seleccione Regla.</option>
                        <option value=""Cancellations and Refounds Allowed"">Cancellations and Refounds Allowed</option>
                        <option value=""Cancellation Permitted"">Cancellation Permitted</option>
                        <option value=""Non Refundable"">Non Refundable</option>
                        <option value=""Fees and Penalties Apply"">Fees and Penalties Apply</option>
                    </datalist>-->
                </td>
            </tr>
            <tr>
                <td style=""width: 184px; font-family: Arial, sans-serif; font-size: 8.25pt;"">Cambios antes de la Salida:</td>
                <td>
                    <!--<select style=""width: 235px"" id=""ddlChBDep"" disabled=""disabled"">
                        <option value=""0"" selected=""selected"">Seleccione Regla.</option>
                        <option value=""1"">No Restrictions</option>
                        <option value=""2"">Changes Permitted</option>
                        <option value=""3"">Changes Not Permitted</option>
                    </select>-->
                    <!--<input type=""text"" name=""ddlChBDep"" list=""optionChBDep"" value=""Selecciona Regla."" style=""width: 235px"" id=""ddlChBDep"" disabled=""disabled"" />
                    <datalist id=""optionChBDep"">
                        <option value=""Seleccione Regla."" selected=""selected"">Seleccione Regla.</option>
                        <option value=""No Restrictions"">No Restrictions</option>
                        <option value=""Changes Permitted"">Changes Permitted</option>
                        <option value=""Changes Not Permitted"">Changes Not Permitted</option>
                    </datalist>-->
                    <select name=""ddlChBDep"" id=""ddlChBDep"" onKeyDown=""fnKeyDownHandler_F(this, event);"" onKeyUp=""fnKeyUpHandler_F(this, event); return false;"" onKeyPress = ""return fnKeyPressHandler_F(this, event);""  onChange=""fnChangeHandler_F(this);"" onFocus=""fnFocusHandler_F(this);"" disabled=""disabled"" style=""font-family: Arial, sans-serif; font-size: 8.25pt; width: 235px;"">
                        <option value="""" selected=""selected"">Seleccione Regla.</option>
                        <option>No Restrictions</option>
                        <option>Changes Permitted</option>
                        <option>Changes Not Permitted</option>
                        <option value="""" style=""font-family:Courier,monospace;color:#ff0000;background-color:#ffff00;"">Otra opción, escriba aquí.</option> <!-- This is the Editable Option -->
                    </select>
                    <input type=""text"" id=""textboxoption_F"" style=""visibility:hidden;display:none;width:150pt"" value=""select option or type here"" onfocus=""this.value = document.getElementById('ddlChBDep').options[vEditableOptionIndex_F].text"" onKeyUp=""document.getElementById('ddlChBDep').options[vEditableOptionIndex_F].text=this.value; document.getElementById('ddlChBDep').options[vEditableOptionIndex_F].value=this.value;"" onblur=""document.getElementById('ddlChBDep').options[vEditableOptionIndex_F].text=this.value; document.getElementById('ddlChBDep').options[vEditableOptionIndex_F].value=this.value; document.getElementById('ddlChBDep').focus();""></input>
                </td>
            </tr>
            <tr>
                <td style=""width: 184px; font-family: Arial, sans-serif; font-size: 8.25pt;"">Cambios después de la Salida:</td>
                <td>
                    <!--<select style=""width: 235px"" id=""ddlChADep"" disabled=""disabled"">
                        <option value=""0"" selected=""selected"">Seleccione Regla.</option>
                        <option value=""1"">No Restrictions</option>
                        <option value=""2"">Changes Permitted</option>
                        <option value=""3"">Changes Not Permitted</option>
                    </select>-->
                    <!--<input type=""text"" name=""ddlChADep"" list=""optionChADep"" value=""Selecciona Regla."" style=""width: 235px"" id=""ddlChADep"" disabled=""disabled"" />
                    <datalist id=""optionChADep"">
                        <option value=""Seleccione Regla."" selected=""selected"">Seleccione Regla.</option>
                        <option value=""No Restrictions"">No Restrictions</option>
                        <option value=""Changes Permitted"">Changes Permitted</option>
                        <option value=""Changes Not Permitted"">Changes Not Permitted</option>
                    </datalist>-->
                    <select name=""ddlChADep"" id=""ddlChADep"" onKeyDown=""fnKeyDownHandler_G(this, event);"" onKeyUp=""fnKeyUpHandler_G(this, event); return false;"" onKeyPress = ""return fnKeyPressHandler_G(this, event);""  onChange=""fnChangeHandler_G(this);"" onFocus=""fnFocusHandler_G(this);"" disabled=""disabled"" style=""font-family: Arial, sans-serif; font-size: 8.25pt; width: 235px;"">
                        <option value="""" selected=""selected"">Seleccione Regla.</option>
                        <option>No Restrictions</option>
                        <option>Changes Permitted</option>
                        <option>Changes Not Permitted</option>
                        <option value="""" style=""font-family:Courier,monospace;color:#ff0000;background-color:#ffff00;"">Otra opción, escriba aquí.</option> <!-- This is the Editable Option -->
                    </select>
                    <input type=""text"" id=""textboxoption_G"" style=""visibility:hidden;display:none;width:150pt"" value=""select option or type here"" onfocus=""this.value = document.getElementById('ddlChADep').options[vEditableOptionIndex_G].text"" onKeyUp=""document.getElementById('ddlChADep').options[vEditableOptionIndex_G].text=this.value; document.getElementById('ddlChADep').options[vEditableOptionIndex_G].value=this.value;"" onblur=""document.getElementById('ddlChADep').options[vEditableOptionIndex_G].text=this.value; document.getElementById('ddlChADep').options[vEditableOptionIndex_G].value=this.value; document.getElementById('ddlChADep').focus();""></input>
                </td>
            </tr>
            <tr>
                <td style=""width: 184px; font-family: Arial, sans-serif; font-size: 8.25pt;"">Estadía Miníma:</td>
                <td>
                    <!--<select style=""width: 235px"" id=""ddlMinStay"" disabled=""disabled"">
                        <option value=""0"" selected=""selected"">Seleccione Regla.</option>
                        <option value=""1"">No Restrictions</option>
                        <option value=""2"">Saturday Nigth</option>
                    </select>-->
                    <!--<input type=""text"" name=""ddlMinStay"" list=""optionMinStay"" value=""Selecciona Regla."" style=""width: 235px"" id=""ddlMinStay"" disabled=""disabled"" />
                    <datalist id=""optionMinStay"">
                        <option value=""Seleccione Regla."" selected=""selected"">Seleccione Regla.</option>
                        <option value=""No Restrictions"">No Restrictions</option>
                        <option value=""Saturday Nigth"">Saturday Nigth</option>
                    </datalist>-->
                    <select name=""ddlMinStay"" id=""ddlMinStay"" onKeyDown=""fnKeyDownHandler_H(this, event);"" onKeyUp=""fnKeyUpHandler_H(this, event); return false;"" onKeyPress = ""return fnKeyPressHandler_H(this, event);""  onChange=""fnChangeHandler_H(this);"" onFocus=""fnFocusHandler_H(this);"" disabled=""disabled"" style=""font-family: Arial, sans-serif; font-size: 8.25pt; width: 235px;"">
                        <option value="""" selected=""selected"">Seleccione Regla.</option>
                        <option>No Restrictions</option>
                        <option>Saturday Nigth</option>
                        <option value="""" style=""font-family:Courier,monospace;color:#ff0000;background-color:#ffff00;"">Otra opción, escriba aquí.</option> <!-- This is the Editable Option -->
                    </select>
                    <input type=""text"" id=""textboxoption_H"" style=""visibility:hidden;display:none;width:150pt"" value=""select option or type here"" onfocus=""this.value = document.getElementById('ddlMinStay').options[vEditableOptionIndex_H].text"" onKeyUp=""document.getElementById('ddlMinStay').options[vEditableOptionIndex_H].text=this.value; document.getElementById('ddlMinStay').options[vEditableOptionIndex_H].value=this.value;"" onblur=""document.getElementById('ddlMinStay').options[vEditableOptionIndex_H].text=this.value; document.getElementById('ddlMinStay').options[vEditableOptionIndex_H].value=this.value; document.getElementById('ddlMinStay').focus();""></input>
                </td>
            </tr>
            <tr>
                <td style=""width: 184px; font-family: Arial, sans-serif; font-size: 8.25pt;"">Estadía Máxima:</td>
                <td>
                    <!--<select style=""width: 235px"" id=""ddlMaxStay"" disabled=""disabled"">
                        <option value=""0"" selected=""selected"">Seleccione Regla.</option>
                        <option value=""1"">No Restrictions</option>
                    </select>-->
                    <!--<input type=""text"" name=""ddlMaxStay"" list=""optionMaxStay"" value=""Selecciona Regla."" style=""width: 235px"" id=""ddlMaxStay"" disabled=""disabled"" />
                    <datalist id=""optionMaxStay"">
                        <option value=""Seleccione Regla."" selected=""selected"">Seleccione Regla.</option>
                        <option value=""No Restrictions"">No Restrictions</option>
                    </datalist>-->
                    <select name=""ddlMaxStay"" id=""ddlMaxStay"" onKeyDown=""fnKeyDownHandler_I(this, event);"" onKeyUp=""fnKeyUpHandler_I(this, event); return false;"" onKeyPress = ""return fnKeyPressHandler_I(this, event);""  onChange=""fnChangeHandler_I(this);"" onFocus=""fnFocusHandler_I(this);"" disabled=""disabled"" style=""font-family: Arial, sans-serif; font-size: 8.25pt; width: 235px;"">
                        <option value="""" selected=""selected"">Seleccione Regla.</option>
                        <option>No Restrictions</option>
                        <option value="""" style=""font-family:Courier,monospace;color:#ff0000;background-color:#ffff00;"">Otra opción, escriba aquí.</option> <!-- This is the Editable Option -->
                    </select>
                    <input type=""text"" id=""textboxoption_I"" style=""visibility:hidden;display:none;width:150pt"" value=""select option or type here"" onfocus=""this.value = document.getElementById('ddlMaxStay').options[vEditableOptionIndex_I].text"" onKeyUp=""document.getElementById('ddlMaxStay').options[vEditableOptionIndex_I].text=this.value; document.getElementById('ddlMaxStay').options[vEditableOptionIndex_I].value=this.value;"" onblur=""document.getElementById('ddlMaxStay').options[vEditableOptionIndex_I].text=this.value; document.getElementById('ddlMaxStay').options[vEditableOptionIndex_I].value=this.value; document.getElementById('ddlMaxStay').focus();""></input>
                </td>
            </tr>
            <tr>
                <td style=""width: 184px; font-family: Arial, sans-serif; font-size: 8.25pt;"">Último día de compra:</td>
                <td>
                    <!--<select style=""width: 235px"" id=""ddlLastDay"" disabled=""disabled"">
                        <option value=""0"" selected=""selected"">Seleccione Regla.</option>
                        <option value=""1"">Extraer el tiempo límite del PQ elegido</option>
                    </select>-->
                    <!--<input type=""text"" name=""ddlLastDay"" list=""optionLastDay"" value=""Selecciona Regla."" style=""width: 235px"" id=""ddlLastDay"" disabled=""disabled"" />
                    <datalist id=""optionLastDay"">
                        <option value=""Seleccione Regla."" selected=""selected"">Seleccione Regla.</option>
                        <option value=""Extraer el tiempo límite del PQ elegido"">Extraer el tiempo límite del PQ elegido</option>
                    </datalist>-->
                    <select name=""ddlLastDay"" id=""ddlLastDay"" onKeyDown=""fnKeyDownHandler_J(this, event);"" onKeyUp=""fnKeyUpHandler_J(this, event); return false;"" onKeyPress = ""return fnKeyPressHandler_J(this, event);""  onChange=""fnChangeHandler_J(this);"" onFocus=""fnFocusHandler_I(this);"" disabled=""disabled"" style=""font-family: Arial, sans-serif; font-size: 8.25pt; width: 235px;"">
                        <option value="""" selected=""selected"">Seleccione Regla.</option><option>";
					html += !string.IsNullOrEmpty(lastDayPurchase) ? lastDayPurchase : string.Empty;
					html += @"</option><option value="""" style=""font-family:Courier,monospace;color:#ff0000;background-color:#ffff00;"">Otra opción, escriba aquí.</option> <!-- This is the Editable Option -->
                    </select>
                    <input type=""text"" id=""textboxoption_J"" style=""visibility:hidden;display:none;width:150pt"" value=""select option or type here"" onfocus=""this.value = document.getElementById('ddlLastDay').options[vEditableOptionIndex_J].text"" onKeyUp=""document.getElementById('ddlLastDay').options[vEditableOptionIndex_J].text=this.value; document.getElementById('ddlLastDay').options[vEditableOptionIndex_J].value=this.value;"" onblur=""document.getElementById('ddlLastDay').options[vEditableOptionIndex_J].text=this.value; document.getElementById('ddlLastDay').options[vEditableOptionIndex_J].value=this.value; document.getElementById('ddlLastDay').focus();""></input>
                </td>
            </tr>
            <tr>
                <td style=""width: 184px; font-family: Arial, sans-serif; font-size: 8.25pt;"">Requisitos de Visa:</td>
                <td>
                    <input type=""text"" style=""width: 167px; font-family: Arial, sans-serif; font-size: 8.25pt; height: 20;"" id=""txtVisaReq"" disabled=""disabled"" />
                </td>
            </tr>
            <tr>
                <td style=""width: 184px; font-family: Arial, sans-serif; font-size: 8.25pt;"">Notas:</td>
                <td>
                    <input type=""text"" style=""width: 167px; font-family: Arial, sans-serif; font-size: 8.25pt; height: 20;"" id=""txtNotes"" disabled=""disabled"" />
                </td>
            </tr>
            <tr>
                <td colspan=""2"" style=""color: red; font-weight: bold; font-family: Arial, sans-serif; font-size: 8.25pt;"">Por favor, revise las reglas de la tarifa.</td>
            </tr>
            <tr>
                <td colspan=""2"" style=""color: red; font-weight: bold; font-family: Arial, sans-serif; font-size: 8.25pt;"">CTS no se hace responsable por la mala interpretación de las reglas.</td>
            </tr>
        </table>
    </div>
    <div>
        <table width=""450px"">
            <tr>
                <td style=""width: 112px;""></td>
                <td style=""width: 112px;""></td>
                <td style=""width: 113px; text-align: right;"">
                    <input id=""btnAcept"" type=""button"" value=""Aceptar"" style=""background-color: #FFFFC0; border-style: solid; border-width: 1px; width: 60px; height: 20px; font-family: Arial, sans-serif; font-size: 8.25pt;"" /></td> <!--Cambio-->
                <td style=""width: 113px;"">
                    <input id=""btnCancel"" type=""button"" value=""Cancelar"" style=""background-color: #FFFFC0; border-style: solid; border-width: 1px;  width: 60px; height: 20px; font-family: Arial, sans-serif; font-size: 8.25pt;"" /></td><!--cambio-->
            </tr>
        </table>
    </div>
</body>
</html>";
					#endregion
					#region funciona
					//wbContent.Navigate("about:blank");
					//HtmlDocument doc = this.wbContent.Document;
					//doc.Write(string.Empty);
					//wbContent.DocumentText = @"<HTML><HEAD></HEAD><BODY><input id=""txtPrueba"" type=""text""/><input type=""submit""/></BODY></HTML>";
					#endregion
					wbContent.Navigate("about:blank");
					wbContent.Document.OpenNew(false);
					wbContent.Document.Write(html);
					//wbContent.Document.Write(@"<HTML><HEAD><script>function enter(){alert('hola mundo');}</script></HEAD><BODY><input id=""txtPrueba"" type=""text""/><input type=""submit"" onClick=""enter()""/></BODY></HTML>");
					wbContent.Refresh();
					wbContent.DocumentCompleted += wbContent_DocumentCompleted;
					//HtmlElement theButton = wbContent.Document.GetElementById("btnAcept");
					//theButton.AttachEventHandler("onclick", BotonPrueba);
					//theButton.Click += BotonPrueba;
					frm.Close();
				}
				else
				{

				}
			}

		}

		delegate void CloseMethod(Form form);
		static private void CloseForm(Form form)
		{
			if (!form.IsDisposed)
			{
				if (form.InvokeRequired)
				{
					CloseMethod method = new CloseMethod(CloseForm);
					form.Invoke(method, new object[] { form });
				}
				else
				{
					form.Close();
				}
			}
		}

		void wbContent_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			HtmlElement btnAcept = wbContent.Document.GetElementById("btnAcept");
			HtmlElement btnCancel = wbContent.Document.GetElementById("btnCancel");
			HtmlElement btnSeeFares = wbContent.Document.GetElementById("btnSeeFares");
			btnAcept.AttachEventHandler("onclick", btnAcept_Click);
			btnCancel.AttachEventHandler("onclick", btnCancel_Click);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (CommandsAPI objCommand = new CommandsAPI())
			{
				string sabreAnswer = objCommand.SendReceive("*A");
			}
		}

		private void wbContent_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			int i = wbContent.Controls.Count;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			//this.Parent.Controls.Remove(this);
			Form frm = Application.OpenForms["frmItinerary"];
			if (frm != null)
			{
				CloseForm(frm);
			}
		}

		private void btnAcept_Click(object sender, EventArgs e)
		{

			HtmlElement txtSegments = wbContent.Document.GetElementById("txtSegments");
			HtmlElement hdCurrency = wbContent.Document.GetElementById("hdCurrency");
			HtmlElement lstPQ = wbContent.Document.GetElementById("lstPQ");
			HtmlElement txtFare = wbContent.Document.GetElementById("txtFare");
			HtmlElement txtTaxes = wbContent.Document.GetElementById("txtTaxes");
			HtmlElement txtMarks = wbContent.Document.GetElementById("txtMarks");
			HtmlElement txtCharge = wbContent.Document.GetElementById("txtCharge");
			HtmlElement txtTotal = wbContent.Document.GetElementById("txtTotal");
			HtmlElement ddlCancel = wbContent.Document.GetElementById("ddlCancel");
			HtmlElement ddlChBDep = wbContent.Document.GetElementById("ddlChBDep");
			HtmlElement ddlChADep = wbContent.Document.GetElementById("ddlChADep");
			HtmlElement ddlMinStay = wbContent.Document.GetElementById("ddlMinStay");
			HtmlElement ddlMaxStay = wbContent.Document.GetElementById("ddlMaxStay");
			HtmlElement ddlLastDay = wbContent.Document.GetElementById("ddlLastDay");
			HtmlElement txtVisaReq = wbContent.Document.GetElementById("txtVisaReq");
			HtmlElement txtNotes = wbContent.Document.GetElementById("txtNotes");
			HtmlElement ckbAddFare = wbContent.Document.GetElementById("ckbAddFare");
			HtmlElement ckbAddRules = wbContent.Document.GetElementById("ckbAddRules");
			HtmlElement ckbShowImages = wbContent.Document.GetElementById("ckbShowImages");

			string segments = string.Empty;

			if (string.IsNullOrEmpty(txtSegments.GetAttribute("Value")))
			{
				segments = "*";
				ClipboardServices.Itinerary itinerary = new ClipboardServices.Itinerary();



				if (itineraryPNR.Trips != null)
				{
					itinerary.Booking = itineraryPNR.Booking;
					itinerary.CancellationPolicy = itineraryPNR.CancellationPolicy;
					itinerary.Trips = new List<ClipboardServices.Trip>();

					int account = 0;

					foreach (ClipboardServices.Trip trip in itineraryPNR.Trips)
					{
						account += trip.Cars.Count + trip.Flights.Count + trip.Hotels.Count;

						if (itinerary.Trips == null)
						{
							itinerary.Trips = new List<ClipboardServices.Trip>();
						}

						itinerary.Trips.Add(new ClipboardServices.Trip());
						itinerary.Trips[itinerary.Trips.Count - 1].Cars = new List<ClipboardServices.Car>();
						itinerary.Trips[itinerary.Trips.Count - 1].Flights = new List<ClipboardServices.Flight>();
						itinerary.Trips[itinerary.Trips.Count - 1].Hotels = new List<ClipboardServices.Hotel>();

						foreach (ClipboardServices.Flight flight in trip.Flights)
						{
							itinerary.Trips[itinerary.Trips.Count - 1].Flights.Add(new ClipboardServices.Flight()
							{
								AircraftType = flight.AircraftType,
								Arrival = flight.Arrival,
								ArrivalTerminal = flight.ArrivalTerminal,
								Airline = flight.Airline,
								ArrivalDate = flight.ArrivalDate,
								ArrivalHour = flight.ArrivalHour,
								BookingAirline = flight.BookingAirline,
								Class = flight.Class,
								Departure = flight.Departure,
								DepartureDate = flight.DepartureDate,
								DepartureHour = flight.DepartureHour,
								DepartureTerminal = flight.DepartureTerminal,
								Effective = flight.Effective,
								ExtensionData = flight.ExtensionData,
								FlightNumber = flight.FlightNumber,
								FlightTime = flight.FlightTime,
								Friday = flight.Friday,
								Logo = flight.Logo,
								Monday = flight.Monday,
								Operated = flight.Operated,
								PlusDays = flight.PlusDays,
								Saturday = flight.Saturday,
								Seat = flight.Seat,
								Stops = flight.Stops,
								Sunday = flight.Sunday,
								Thursday = flight.Thursday,
								Tuesday = flight.Tuesday,
								Until = flight.Until,
								Wednesday = flight.Wednesday,
								SegmentNumber = flight.SegmentNumber
							});
						}

						foreach (ClipboardServices.Hotel hotel in trip.Hotels)
						{
							itinerary.Trips[itinerary.Trips.Count - 1].Hotels.Add(new ClipboardServices.Hotel()
							{
								Address = hotel.Address,
								ArrivalDate = hotel.ArrivalDate,
								Confirmation = hotel.Confirmation,
								DepartureDate = hotel.DepartureDate,
								ExtensionData = hotel.ExtensionData,
								Name = hotel.Name,
								NumberRoom = hotel.NumberRoom,
								Policies = hotel.Policies,
								Rate = hotel.Rate,
								RoomType = hotel.RoomType,
								Telephone = hotel.Telephone,
								SegmentNumber = hotel.SegmentNumber
							});
						}

						foreach (ClipboardServices.Car car in trip.Cars)
						{
							itinerary.Trips[itinerary.Trips.Count - 1].Cars.Add(new ClipboardServices.Car()
							{
								CarType = car.CarType,
								City = car.City,
								Confirmation = car.Confirmation,
								DropOffDate = car.DropOffDate,
								ExtensionData = car.ExtensionData,
								NumberCars = car.NumberCars,
								PickUpDate = car.PickUpDate,
								Rate = car.Rate,
								RentCarName = car.RentCarName,
								SegmentNumber = car.SegmentNumber
							});
						}
					}


					itinerary.ChangesAftDep = itineraryPNR.ChangesAftDep;
					itinerary.ChangesBefDep = itineraryPNR.ChangesBefDep;
					itinerary.LastDayPurchase = itineraryPNR.LastDayPurchase;
					itinerary.MaxStay = itineraryPNR.MaxStay;
					itinerary.MinStay = itineraryPNR.MinStay;
					itinerary.Name = itineraryPNR.Name;
					itinerary.Notes = itineraryPNR.Notes;
					itinerary.Rate = itineraryPNR.Rate;
					itinerary.ShowRules = itineraryPNR.ShowRules;
					itinerary.VisaReq = itineraryPNR.VisaReq;
				}

				if (lstPQ.Enabled)
				{
					itinerary.PQs = new List<ClipboardServices.PaxQuote>();
					itinerary.PQs.Add(new ClipboardServices.PaxQuote());
					itinerary.PQs[0].Fare = (decimal.Parse(string.IsNullOrEmpty(txtFare.GetAttribute("Value")) ? "0" : txtFare.GetAttribute("Value")) + decimal.Parse(string.IsNullOrEmpty(txtMarks.GetAttribute("Value")) ? "0" : txtMarks.GetAttribute("Value"))).ToString("0.00", new System.Globalization.CultureInfo("es-MX"));
					itinerary.PQs[0].ServiceFee = decimal.Parse(string.IsNullOrEmpty(txtCharge.GetAttribute("Value")) ? "0" : txtCharge.GetAttribute("Value")).ToString("0.00", new System.Globalization.CultureInfo("es-MX"));
					itinerary.PQs[0].Taxes = decimal.Parse(string.IsNullOrEmpty(txtTaxes.GetAttribute("Value")) ? "0" : txtTaxes.GetAttribute("Value")).ToString("0.00", new System.Globalization.CultureInfo("es-MX"));
					itinerary.PQs[0].Total = decimal.Parse(string.IsNullOrEmpty(txtTotal.GetAttribute("Value")) ? "0" : txtTotal.GetAttribute("Value")).ToString("0.00", new System.Globalization.CultureInfo("es-MX"));
					itinerary.PQs[0].Currency = string.IsNullOrEmpty(itinerary.PQs[0].Currency) ? hdCurrency.GetAttribute("Value") : itinerary.PQs[0].Currency;

					if (itinerary.PQs[0].Total == "0.00" && itinerary.PQs[0].Taxes == "0.00" && itinerary.PQs[0].ServiceFee == "0.00" && itinerary.PQs[0].Fare == "0.00")
					{
						itinerary.ShowFare = false;
					}
					else
					{
						itinerary.ShowFare = true;
					}
				}

				if (ddlCancel.Enabled)
				{
					itinerary.ShowRules = true;
					foreach (HtmlElement child in ddlCancel.All)
					{
						if (child.GetAttribute("tagName") == "OPTION")
						{
							if (child.GetAttribute("selected") == "True")
							{
								itinerary.CancellationPolicy = child.GetAttribute("text").Trim() != "Seleccione Regla." ? child.GetAttribute("text").Trim() : string.Empty;
								break;
							}
						}
					}

					foreach (HtmlElement child in ddlChADep.All)
					{
						if (child.GetAttribute("tagName") == "OPTION")
						{
							if (child.GetAttribute("selected") == "True")
							{
								itinerary.ChangesAftDep = child.GetAttribute("text").Trim() != "Seleccione Regla." ? child.GetAttribute("text").Trim() : string.Empty;
								break;
							}
						}
					}

					foreach (HtmlElement child in ddlChBDep.All)
					{
						if (child.GetAttribute("tagName") == "OPTION")
						{
							if (child.GetAttribute("selected") == "True")
							{
								itinerary.ChangesBefDep = child.GetAttribute("text").Trim() != "Seleccione Regla." ? child.GetAttribute("text").Trim() : string.Empty;
								break;
							}
						}
					}

					foreach (HtmlElement child in ddlMinStay.All)
					{
						if (child.GetAttribute("tagName") == "OPTION")
						{
							if (child.GetAttribute("selected") == "True")
							{
								itinerary.MinStay = child.GetAttribute("text").Trim() != "Seleccione Regla." ? child.GetAttribute("text").Trim() : string.Empty;
								break;
							}
						}
					}

					foreach (HtmlElement child in ddlMaxStay.All)
					{
						if (child.GetAttribute("tagName") == "OPTION")
						{
							if (child.GetAttribute("selected") == "True")
							{
								itinerary.MaxStay = child.GetAttribute("text").Trim() != "Seleccione Regla." ? child.GetAttribute("text").Trim() : string.Empty;
								break;
							}
						}
					}

					foreach (HtmlElement child in ddlLastDay.All)
					{
						if (child.GetAttribute("tagName") == "OPTION")
						{
							if (child.GetAttribute("selected") == "True")
							{
								itinerary.LastDayPurchase = child.GetAttribute("text").Trim() != "Seleccione Regla." ? child.GetAttribute("text").Trim() : string.Empty;
								break;
							}
						}
					}

					//int selectedIndex = ((int)ddlCancel.GetType().InvokeMember("selectedIndex", System.Reflection.BindingFlags.GetProperty, null, ddlCancel, null));
					//itinerary.CancellationPolicy = selectedIndex != -1 ? ddlCancel.Children[selectedIndex].InnerText : string.Empty;
					//selectedIndex = ((int)ddlChADep.GetType().InvokeMember("selectedIndex", System.Reflection.BindingFlags.GetProperty, null, ddlChADep, null));
					//itinerary.ChangesAftDep = selectedIndex != -1 ? ddlChADep.Children[selectedIndex].InnerText : string.Empty;
					//selectedIndex = ((int)ddlChBDep.GetType().InvokeMember("selectedIndex", System.Reflection.BindingFlags.GetProperty, null, ddlChBDep, null));
					//itinerary.ChangesBefDep = selectedIndex != -1 ? ddlChBDep.Children[selectedIndex].InnerText : string.Empty;
					//selectedIndex = ((int)ddlMinStay.GetType().InvokeMember("selectedIndex", System.Reflection.BindingFlags.GetProperty, null, ddlMinStay, null));
					//itinerary.MinStay = selectedIndex != -1 ? ddlMinStay.Children[selectedIndex].InnerText : string.Empty;
					//selectedIndex = ((int)ddlMaxStay.GetType().InvokeMember("selectedIndex", System.Reflection.BindingFlags.GetProperty, null, ddlMaxStay, null));
					//itinerary.MaxStay = selectedIndex != -1 ? ddlMaxStay.Children[selectedIndex].InnerText : string.Empty;
					//selectedIndex = ((int)ddlLastDay.GetType().InvokeMember("selectedIndex", System.Reflection.BindingFlags.GetProperty, null, ddlLastDay, null));
					//itinerary.LastDayPurchase = selectedIndex != -1 ? ddlLastDay.Children[selectedIndex].InnerText : string.Empty;
					itinerary.VisaReq = txtVisaReq.GetAttribute("Value");
					itinerary.Notes = txtNotes.GetAttribute("Value");
				}
				if (itinerary.Trips == null)
				{
					itinerary.Trips = new List<ClipboardServices.Trip>();
				}
				if (itinerary.Trips.Count == 0)
				{
					itinerary.Trips.Add(new ClipboardServices.Trip());
					if (itinerary.Trips[0].Flights == null)
					{
						itinerary.Trips[0].Flights = new List<ClipboardServices.Flight>();
					}

					if (itinerary.Trips[0].Flights.Count == 0)
					{
						List<ClipboardServices.Flight> flights = new List<ClipboardServices.Flight>();
						List<ClipboardServices.Hotel> hotels = new List<ClipboardServices.Hotel>();
						List<ClipboardServices.Car> cars = new List<ClipboardServices.Car>();
						int indexFlight = 0;
						int indexHotel = 0;
						int indexCar = 0;

						foreach (string[] x in numSegmento)
						{
							//List<int> numSegmento = new List<int>();
							//List<string> airline = new List<string>();
							//List<string> numberFlight = new List<string>();
							//List<string> classVar = new List<string>();
							//List<string> dateDeparture = new List<string>();
							//List<string> dateArrival = new List<string>();
							//List<string> dc = new List<string>();
							//List<string> departureHour = new List<string>();
							//List<string> arrivalHour = new List<string>();
							//List<string> arrival = new List<string>();
							//List<string> departure = new List<string>();
							//List<string> status = new List<string>();
							//List<string> operatedBy = new List<string>();
							if (x[1] == "AIR")
							{
								itinerary.Trips[0].ShowFlight = true;

								ClipboardServices.Flight flight = new ClipboardServices.Flight();
								flight.Airline = airline[indexFlight];
								flight.FlightNumber = numberFlight[indexFlight];
								flight.Class = classVar[indexFlight];

								if (dateDeparture[indexFlight].ToUpper().Contains("29 FEB"))
								{
									if (DateTime.Today <= new DateTime(DateTime.Today.Year, 2, 28))
									{
										flight.DepartureDate = DateTime.ParseExact(dateDeparture[indexFlight], "ddd dd MMM", new System.Globalization.CultureInfo("en-US")).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
									}
									else
									{
										flight.DepartureDate = DateTime.ParseExact(string.Concat(dateDeparture[indexFlight], " ", DateTime.Today.AddYears(1).Year.ToString("0000")), "ddd dd MMM yyyy", new System.Globalization.CultureInfo("en-US")).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
									}
								}
								else
								{
									flight.DepartureDate = DateTime.ParseExact(dateDeparture[indexFlight], "ddd dd MMM", new System.Globalization.CultureInfo("en-US")).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
								}

								if ((string.IsNullOrEmpty(dateArrival[indexFlight]) ? dateDeparture[indexFlight] : dateArrival[indexFlight]).ToUpper().Contains("29 FEB"))
								{
									if (DateTime.Today <= new DateTime(DateTime.Today.Year, 2, 28))
									{
										flight.ArrivalDate = DateTime.ParseExact(string.IsNullOrEmpty(dateArrival[indexFlight]) ? dateDeparture[indexFlight] : dateArrival[indexFlight], "ddd dd MMM", new System.Globalization.CultureInfo("en-US")).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
									}
									else
									{
										flight.ArrivalDate = DateTime.ParseExact(string.Concat((string.IsNullOrEmpty(dateArrival[indexFlight]) ? dateDeparture[indexFlight] : dateArrival[indexFlight]), " ", DateTime.Today.AddYears(1).Year.ToString("0000")), "ddd dd MMM yyyy", new System.Globalization.CultureInfo("en-US")).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
									}
								}
								else
								{
									flight.ArrivalDate = DateTime.ParseExact(string.IsNullOrEmpty(dateArrival[indexFlight]) ? dateDeparture[indexFlight] : dateArrival[indexFlight], "ddd dd MMM", new System.Globalization.CultureInfo("en-US")).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
								}

								flight.DepartureHour = departureHour[indexFlight];
								flight.ArrivalHour = arrivalHour[indexFlight];
								flight.Arrival = arrival[indexFlight];
								flight.Departure = departure[indexFlight];
								flight.Operated = operatedBy[indexFlight];
								flight.SegmentNumber = x[0];

								flights.Add(flight);

								indexFlight++;
							}
							else if (x[1] == "HOTEL")
							{
								itinerary.Trips[0].ShowHotels = true;

								ClipboardServices.Hotel hotel = new ClipboardServices.Hotel();
								hotel.Address = hotelAddress[indexHotel];
								hotel.ArrivalDate = hotelArrivalDate[indexHotel];
								hotel.Confirmation = hotelConfirmation[indexHotel];
								hotel.DepartureDate = hotelDepartureDate[indexHotel];
								hotel.Name = hotelName[indexHotel];
								hotel.NumberRoom = hotelNumberRoom[indexHotel];
								hotel.Policies = hotelPolicies[indexHotel];
								hotel.Rate = hotelRate[indexHotel];
								hotel.RoomType = hotelRoomType[indexHotel];
								hotel.Telephone = hotelTelephone[indexHotel];
								hotel.SegmentNumber = x[0];

								hotels.Add(hotel);

								indexHotel++;
							}
							else if (x[1] == "CAR")
							{
								itinerary.Trips[0].ShowCars = true;

								ClipboardServices.Car car = new ClipboardServices.Car();
								car.CarType = carCarType[indexCar];
								car.City = carCity[indexCar];
								car.Confirmation = carConfirmation[indexCar];

								if (carDropOffDate[indexCar].ToUpper().Contains("29FEB"))
								{
									if (DateTime.Today <= new DateTime(DateTime.Today.Year, 2, 28))
									{
										car.DropOffDate = DateTime.ParseExact(carDropOffDate[indexCar], "ddMMM HH:mm", new System.Globalization.CultureInfo("en-US")).ToString("MM-ddTHH:mm");
									}
									else
									{
										car.DropOffDate = DateTime.ParseExact(string.Concat(carDropOffDate[indexCar].Split(' ')[0], DateTime.Today.AddYears(1).Year.ToString("0000"), " ", carDropOffDate[indexCar].Split(' ')[1]), "ddMMMyyyy HH:mm", new System.Globalization.CultureInfo("en-US")).ToString("MM-ddTHH:mm");
									}
								}
								else
								{
									car.DropOffDate = DateTime.ParseExact(carDropOffDate[indexCar], "ddMMM HH:mm", new System.Globalization.CultureInfo("en-US")).ToString("MM-ddTHH:mm");
								}

								car.NumberCars = carNumberCars[indexCar];

								if (carPickUpDate[indexCar].ToUpper().Contains("29FEB"))
								{
									if (DateTime.Today <= new DateTime(DateTime.Today.Year, 2, 28))
									{
										car.PickUpDate = DateTime.ParseExact(carPickUpDate[indexCar], "ddMMM HH:mm", new System.Globalization.CultureInfo("en-US")).ToString("MM-ddTHH:mm");
									}
									else
									{
										car.PickUpDate = DateTime.ParseExact(string.Concat(carPickUpDate[indexCar].Split(' ')[0], DateTime.Today.AddYears(1).Year.ToString("0000"), " ", carPickUpDate[indexCar].Split(' ')[1]), "ddMMMyyyy HH:mm", new System.Globalization.CultureInfo("en-US")).ToString("MM-ddTHH:mm");
									}
								}
								else
								{
									car.PickUpDate = DateTime.ParseExact(carPickUpDate[indexCar], "ddMMM HH:mm", new System.Globalization.CultureInfo("en-US")).ToString("MM-ddTHH:mm");
								}

								car.Rate = carRate[indexCar];
								car.RentCarName = carRentCarName[indexCar];
								car.SegmentNumber = x[0];

								cars.Add(car);

								indexCar++;
							}
						}

						itinerary.Trips[0].Flights = flights;
						itinerary.Trips[0].Cars = cars;
						itinerary.Trips[0].Hotels = hotels;
					}
				}

				itinerary.ShowAirlines = ckbShowImages.GetAttribute("Checked") == "True";

				ClipboardService service = new ClipboardService();
				ClipboardServices.File file = service.CopyReport(itinerary);

				try
				{
					DataObject obj = new DataObject();
					obj.SetData(DataFormats.Html, new System.IO.MemoryStream(
					   file.Buffer));
					Clipboard.SetDataObject(obj, true);
					if (MessageBox.Show("Se ha copiado el reporte a tu portapapeles.", "Reporte copiado", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
					{
						Form frm = Application.OpenForms["frmItinerary"];
						if (frm != null)
						{
							CloseForm(frm);
						}
					}
				}
				catch
				{
					MessageBox.Show("Ocurrio un problema al copiar el reporte al portapapeles.", "Reporte no copiado", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				ClipboardServices.Itinerary itinerary = new ClipboardServices.Itinerary();
				foreach (string segment1 in txtSegments.GetAttribute("Value").Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
				{
					if (segment1.Contains("-"))
					{
						foreach (string segment2 in segment1.Trim().Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries))
						{
							if (!string.IsNullOrEmpty(segments))
							{
								segments += ",";
							}

							segments += segment2.Trim(); ;
						}
					}
					else
					{
						if (!string.IsNullOrEmpty(segments))
						{
							segments += ",";
						}

						segments += segment1.Trim(); ;
					}
				}

				bool isCorrect = true;

				if (itineraryPNR.Trips == null)
				{
					itineraryPNR.Trips = new List<ClipboardServices.Trip>();
				}

				if (itineraryPNR.Trips.Count != 0)
				{
					itinerary.Booking = itineraryPNR.Booking;
					itinerary.CancellationPolicy = itineraryPNR.CancellationPolicy;

					int account = 0;

					foreach (ClipboardServices.Trip trip in itineraryPNR.Trips)
					{
						account += trip.Cars.Count + trip.Flights.Count + trip.Hotels.Count;

						if (itinerary.Trips == null)
						{
							itinerary.Trips = new List<ClipboardServices.Trip>();
						}

						itinerary.Trips.Add(new ClipboardServices.Trip());
						itinerary.Trips[itinerary.Trips.Count - 1].Cars = new List<ClipboardServices.Car>();
						itinerary.Trips[itinerary.Trips.Count - 1].Flights = new List<ClipboardServices.Flight>();
						itinerary.Trips[itinerary.Trips.Count - 1].Hotels = new List<ClipboardServices.Hotel>();

						foreach (ClipboardServices.Flight flight in trip.Flights)
						{
							itinerary.Trips[itinerary.Trips.Count - 1].Flights.Add(new ClipboardServices.Flight()
							{
								AircraftType = flight.AircraftType,
								Arrival = flight.Arrival,
								Airline = flight.Airline,
								ArrivalDate = flight.ArrivalDate,
								ArrivalHour = flight.ArrivalHour,
								ArrivalTerminal = flight.ArrivalTerminal,
								BookingAirline = flight.BookingAirline,
								Class = flight.Class,
								Departure = flight.Departure,
								DepartureDate = flight.DepartureDate,
								DepartureTerminal = flight.DepartureTerminal,
								DepartureHour = flight.DepartureHour,
								Effective = flight.Effective,
								ExtensionData = flight.ExtensionData,
								FlightNumber = flight.FlightNumber,
								FlightTime = flight.FlightTime,
								Friday = flight.Friday,
								Logo = flight.Logo,
								Monday = flight.Monday,
								Operated = flight.Operated,
								PlusDays = flight.PlusDays,
								Saturday = flight.Saturday,
								Seat = flight.Seat,
								Stops = flight.Stops,
								Sunday = flight.Sunday,
								Thursday = flight.Thursday,
								Tuesday = flight.Tuesday,
								Until = flight.Until,
								Wednesday = flight.Wednesday,
								SegmentNumber = flight.SegmentNumber
							});
						}

						foreach (ClipboardServices.Hotel hotel in trip.Hotels)
						{
							itinerary.Trips[itinerary.Trips.Count - 1].Hotels.Add(new ClipboardServices.Hotel()
							{
								Address = hotel.Address,
								ArrivalDate = hotel.ArrivalDate,
								Confirmation = hotel.Confirmation,
								DepartureDate = hotel.DepartureDate,
								ExtensionData = hotel.ExtensionData,
								Name = hotel.Name,
								NumberRoom = hotel.NumberRoom,
								Policies = hotel.Policies,
								Rate = hotel.Rate,
								RoomType = hotel.RoomType,
								Telephone = hotel.Telephone,
								SegmentNumber = hotel.SegmentNumber
							});
						}

						foreach (ClipboardServices.Car car in trip.Cars)
						{
							itinerary.Trips[itinerary.Trips.Count - 1].Cars.Add(new ClipboardServices.Car()
							{
								CarType = car.CarType,
								City = car.City,
								Confirmation = car.Confirmation,
								DropOffDate = car.DropOffDate,
								ExtensionData = car.ExtensionData,
								NumberCars = car.NumberCars,
								PickUpDate = car.PickUpDate,
								Rate = car.Rate,
								RentCarName = car.RentCarName,
								SegmentNumber = car.SegmentNumber
							});
						}
					}

					itinerary.ChangesAftDep = itineraryPNR.ChangesAftDep;
					itinerary.ChangesBefDep = itineraryPNR.ChangesBefDep;
					//foreach (Services.ClipboardService.PaxQuote pq in itineraryPNR.PQs)
					//{
					//    Services.ClipboardService.PaxQuote localPQ = new Services.ClipboardService.PaxQuote();
					//    localPQ.Fare = pq.Fare;
					//    localPQ.Taxes = pq.Taxes;
					//    localPQ.Total = pq.Total;
					//    itinerary.PQs.Add(localPQ);
					//}




					itinerary.LastDayPurchase = itineraryPNR.LastDayPurchase;
					itinerary.MaxStay = itineraryPNR.MaxStay;
					itinerary.MinStay = itineraryPNR.MinStay;
					itinerary.Name = itineraryPNR.Name;
					itinerary.Notes = itineraryPNR.Notes;
					itinerary.Rate = itineraryPNR.Rate;
					itinerary.ShowFare = itineraryPNR.ShowFare;
					itinerary.ShowRules = itineraryPNR.ShowRules;
					itinerary.VisaReq = itineraryPNR.VisaReq;

					foreach (string segment in segments.Split(','))
					{
						int j = 0;

						if (!int.TryParse(segment, out j))
						{
							isCorrect = false;
							break;
						}

						if (int.Parse(segment) > account)
						{
							isCorrect = false;
							break;
						}
					}

					for (int i = itinerary.Trips[0].Flights.Count; i >= 1; i--)
					{
						bool isLocalized = false;

						foreach (string segment in segments.Split(','))
						{
							if (int.Parse(itinerary.Trips[0].Flights[i - 1].SegmentNumber) == int.Parse(segment))
							{
								isLocalized = true;
								break;
							}
						}

						if (!isLocalized)
						{
							itinerary.Trips[0].Flights.RemoveAt(i - 1);
						}
						else
						{
							isCorrect = true;
						}
					}
				}
				else
				{
					List<ClipboardServices.Flight> flights = new List<ClipboardServices.Flight>();
					List<ClipboardServices.Hotel> hotels = new List<ClipboardServices.Hotel>();
					List<ClipboardServices.Car> cars = new List<ClipboardServices.Car>();
					if (itinerary.Trips == null)
					{
						itinerary.Trips = new List<ClipboardServices.Trip>();
						itinerary.Trips.Add(new ClipboardServices.Trip());
					}

					foreach (string segmentReq in segments.Split(','))
					{
						foreach (string[] segmentAvail in numSegmento)
						{
							if (int.Parse(segmentAvail[0]) == int.Parse(segmentReq))
							{
								if (segmentAvail[1] == "AIR")
								{
									itinerary.Trips[0].ShowFlight = true;

									ClipboardServices.Flight flight = new ClipboardServices.Flight();
									flight.Airline = airline[int.Parse(segmentAvail[2])];
									flight.FlightNumber = numberFlight[int.Parse(segmentAvail[2])];
									flight.Class = classVar[int.Parse(segmentAvail[2])];

									if (dateDeparture[int.Parse(segmentAvail[2])].ToUpper().Contains("29 FEB"))
									{
										if (DateTime.Today <= new DateTime(DateTime.Today.Year, 2, 28))
										{
											flight.DepartureDate = DateTime.ParseExact(dateDeparture[int.Parse(segmentAvail[2])], "ddd dd MMM", new System.Globalization.CultureInfo("en-US")).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
										}
										else
										{
											flight.DepartureDate = DateTime.ParseExact(string.Concat(dateDeparture[int.Parse(segmentAvail[2])], " ", DateTime.Today.AddYears(1).Year.ToString("0000")), "ddd dd MMM yyyy", new System.Globalization.CultureInfo("en-US")).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
										}
									}
									else
									{
										flight.DepartureDate = DateTime.ParseExact(dateDeparture[int.Parse(segmentAvail[2])], "ddd dd MMM", new System.Globalization.CultureInfo("en-US")).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
									}

									if ((string.IsNullOrEmpty(dateArrival[int.Parse(segmentAvail[2])]) ? dateDeparture[int.Parse(segmentAvail[2])] : dateArrival[int.Parse(segmentAvail[2])]).ToUpper().Contains("29 FEB"))
									{
										if (DateTime.Today <= new DateTime(DateTime.Today.Year, 2, 28))
										{
											flight.ArrivalDate = DateTime.ParseExact(string.IsNullOrEmpty(dateArrival[int.Parse(segmentAvail[2])]) ? dateDeparture[int.Parse(segmentAvail[2])] : dateArrival[int.Parse(segmentAvail[2])], "ddd dd MMM", new System.Globalization.CultureInfo("en-US")).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
										}
										else
										{
											flight.ArrivalDate = DateTime.ParseExact(string.Concat((string.IsNullOrEmpty(dateArrival[int.Parse(segmentAvail[2])]) ? dateDeparture[int.Parse(segmentAvail[2])] : dateArrival[int.Parse(segmentAvail[2])]), " ", DateTime.Today.AddYears(1).Year.ToString("0000")), "ddd dd MMM yyyy", new System.Globalization.CultureInfo("en-US")).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
										}
									}
									else
									{
										flight.ArrivalDate = DateTime.ParseExact(string.IsNullOrEmpty(dateArrival[int.Parse(segmentAvail[2])]) ? dateDeparture[int.Parse(segmentAvail[2])] : dateArrival[int.Parse(segmentAvail[2])], "ddd dd MMM", new System.Globalization.CultureInfo("en-US")).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
									}

									flight.DepartureHour = departureHour[int.Parse(segmentAvail[2])];
									flight.ArrivalHour = arrivalHour[int.Parse(segmentAvail[2])];
									flight.Arrival = arrival[int.Parse(segmentAvail[2])];
									flight.Departure = departure[int.Parse(segmentAvail[2])];
									flight.Operated = operatedBy[int.Parse(segmentAvail[2])];
									flight.SegmentNumber = segmentAvail[0];

									flights.Add(flight);
								}
								else if (segmentAvail[1] == "HOTEL")
								{
									itinerary.Trips[0].ShowHotels = true;

									ClipboardServices.Hotel hotel = new ClipboardServices.Hotel();
									hotel.Address = hotelAddress[int.Parse(segmentAvail[2])];
									hotel.ArrivalDate = hotelArrivalDate[int.Parse(segmentAvail[2])];
									hotel.Confirmation = hotelConfirmation[int.Parse(segmentAvail[2])];
									hotel.DepartureDate = hotelDepartureDate[int.Parse(segmentAvail[2])];
									hotel.Name = hotelName[int.Parse(segmentAvail[2])];
									hotel.NumberRoom = hotelRoomType[int.Parse(segmentAvail[2])];
									hotel.Policies = hotelPolicies[int.Parse(segmentAvail[2])];
									hotel.Rate = hotelRate[int.Parse(segmentAvail[2])];
									hotel.RoomType = hotelRoomType[int.Parse(segmentAvail[2])];
									hotel.Telephone = hotelTelephone[int.Parse(segmentAvail[2])];
									hotel.SegmentNumber = segmentAvail[0];

									hotels.Add(hotel);

								}
								else if (segmentAvail[1] == "CAR")
								{
									itinerary.Trips[0].ShowCars = true;

									ClipboardServices.Car car = new ClipboardServices.Car();
									car.CarType = carCarType[int.Parse(segmentAvail[2])];
									car.City = carCity[int.Parse(segmentAvail[2])];
									car.Confirmation = carConfirmation[int.Parse(segmentAvail[2])];

									if (carDropOffDate[int.Parse(segmentAvail[2])].ToUpper().Contains("29FEB"))
									{
										if (DateTime.Today <= new DateTime(DateTime.Today.Year, 2, 28))
										{
											car.DropOffDate = DateTime.ParseExact(carDropOffDate[int.Parse(segmentAvail[2])], "ddMMM HH:mm", new System.Globalization.CultureInfo("en-US")).ToString("MM-ddTHH:mm");
										}
										else
										{
											car.DropOffDate = DateTime.ParseExact(string.Concat(carDropOffDate[int.Parse(segmentAvail[2])].Split(' ')[0], DateTime.Today.AddYears(1).Year.ToString("0000"), " ", carDropOffDate[int.Parse(segmentAvail[2])].Split(' ')[1]), "ddMMMyyyy HH:mm", new System.Globalization.CultureInfo("en-US")).ToString("MM-ddTHH:mm");
										}
									}
									else
									{
										car.DropOffDate = DateTime.ParseExact(carDropOffDate[int.Parse(segmentAvail[2])], "ddMMM HH:mm", new System.Globalization.CultureInfo("en-US")).ToString("MM-ddTHH:mm");
									}

									car.NumberCars = carNumberCars[int.Parse(segmentAvail[2])];

									if (carPickUpDate[int.Parse(segmentAvail[2])].ToUpper().Contains("29FEB"))
									{
										if (DateTime.Today <= new DateTime(DateTime.Today.Year, 2, 28))
										{
											car.PickUpDate = DateTime.ParseExact(carPickUpDate[int.Parse(segmentAvail[2])], "ddMMM HH:mm", new System.Globalization.CultureInfo("en-US")).ToString("MM-ddTHH:mm");
										}
										else
										{
											car.PickUpDate = DateTime.ParseExact(string.Concat(carPickUpDate[int.Parse(segmentAvail[2])].Split(' ')[0], DateTime.Today.AddYears(1).Year.ToString("0000"), " ", carPickUpDate[int.Parse(segmentAvail[2])].Split(' ')[1]), "ddMMMyyyy HH:mm", new System.Globalization.CultureInfo("en-US")).ToString("MM-ddTHH:mm");
										}
									}
									else
									{
										car.PickUpDate = DateTime.ParseExact(carPickUpDate[int.Parse(segmentAvail[2])], "ddMMM HH:mm", new System.Globalization.CultureInfo("en-US")).ToString("MM-ddTHH:mm");
									}

									car.Rate = carRate[int.Parse(segmentAvail[2])];
									car.RentCarName = carRentCarName[int.Parse(segmentAvail[2])];
									car.SegmentNumber = segmentAvail[0];

									cars.Add(car);
								}

								break;
							}
						}
					}

					itinerary.Trips[0].Flights = flights;
					itinerary.Trips[0].Cars = cars;
					itinerary.Trips[0].Hotels = hotels;

					foreach (string segment in segments.Split(','))
					{
						int j = 0;

						if (!int.TryParse(segment, out j))
						{
							isCorrect = false;
							break;
						}

						bool isLocated = false;

						foreach (string[] i in numSegmento)
						{
							if (int.Parse(i[0]) == int.Parse(segment))
							{
								isLocated = true;
								break;
							}
						}

						if (!isLocated)
						{
							isCorrect = false;
							break;
						}
					}
				}

				if (isCorrect)
				{
					if (lstPQ.Enabled)
					{
						itinerary.PQs = new List<ClipboardServices.PaxQuote>();
						itinerary.PQs.Add(new ClipboardServices.PaxQuote());
						itinerary.PQs[0].Fare = (decimal.Parse(string.IsNullOrEmpty(txtFare.GetAttribute("Value")) ? "0" : txtFare.GetAttribute("Value")) + decimal.Parse(string.IsNullOrEmpty(txtMarks.GetAttribute("Value")) ? "0" : txtMarks.GetAttribute("Value"))).ToString("0.00", new System.Globalization.CultureInfo("es-MX"));
						itinerary.PQs[0].Taxes = decimal.Parse(string.IsNullOrEmpty(txtTaxes.GetAttribute("Value")) ? "0" : txtTaxes.GetAttribute("Value")).ToString("0.00", new System.Globalization.CultureInfo("es-MX"));
						itinerary.PQs[0].ServiceFee = decimal.Parse(string.IsNullOrEmpty(txtCharge.GetAttribute("Value")) ? "0" : txtCharge.GetAttribute("Value")).ToString("0.00", new System.Globalization.CultureInfo("es-MX"));
						itinerary.PQs[0].Total = decimal.Parse(string.IsNullOrEmpty(txtTotal.GetAttribute("Value")) ? "0" : txtTotal.GetAttribute("Value")).ToString("0.00", new System.Globalization.CultureInfo("es-MX"));
						itinerary.PQs[0].Currency = string.IsNullOrEmpty(itinerary.PQs[0].Currency) ? hdCurrency.GetAttribute("Value") : itinerary.PQs[0].Currency;

						if (itinerary.PQs[0].Total == "0.00" && itinerary.PQs[0].Taxes == "0.00" && itinerary.PQs[0].ServiceFee == "0.00" && itinerary.PQs[0].Fare == "0.00")
						{
							itinerary.ShowFare = false;
						}
						else
						{
							itinerary.ShowFare = true;
						}
					}

					if (ddlCancel.Enabled)
					{
						itinerary.ShowRules = true;
						int selectedIndex = ((int)ddlCancel.GetType().InvokeMember("selectedIndex", System.Reflection.BindingFlags.GetProperty, null, ddlCancel, null));
						itinerary.CancellationPolicy = selectedIndex != -1 ? ddlCancel.Children[selectedIndex].InnerText : string.Empty;
						selectedIndex = ((int)ddlChADep.GetType().InvokeMember("selectedIndex", System.Reflection.BindingFlags.GetProperty, null, ddlChADep, null));
						itinerary.ChangesAftDep = selectedIndex != -1 ? ddlChADep.Children[selectedIndex].InnerText : string.Empty;
						selectedIndex = ((int)ddlChBDep.GetType().InvokeMember("selectedIndex", System.Reflection.BindingFlags.GetProperty, null, ddlChBDep, null));
						itinerary.ChangesBefDep = selectedIndex != -1 ? ddlChBDep.Children[selectedIndex].InnerText : string.Empty;
						selectedIndex = ((int)ddlMinStay.GetType().InvokeMember("selectedIndex", System.Reflection.BindingFlags.GetProperty, null, ddlMinStay, null));
						itinerary.MinStay = selectedIndex != -1 ? ddlMinStay.Children[selectedIndex].InnerText : string.Empty;
						selectedIndex = ((int)ddlMaxStay.GetType().InvokeMember("selectedIndex", System.Reflection.BindingFlags.GetProperty, null, ddlMaxStay, null));
						itinerary.MaxStay = selectedIndex != -1 ? ddlMaxStay.Children[selectedIndex].InnerText : string.Empty;
						selectedIndex = ((int)ddlLastDay.GetType().InvokeMember("selectedIndex", System.Reflection.BindingFlags.GetProperty, null, ddlLastDay, null));
						itinerary.LastDayPurchase = selectedIndex != -1 ? ddlLastDay.Children[selectedIndex].InnerText : string.Empty;
						itinerary.VisaReq = txtVisaReq.GetAttribute("Value");
						itinerary.Notes = txtNotes.GetAttribute("Value");
					}

					itinerary.ShowAirlines = ckbShowImages.GetAttribute("Checked") == "True";

					ClipboardService service = new ClipboardService();
					ClipboardServices.File file = service.CopyReport(itinerary);

					try
					{
						DataObject obj = new DataObject();
						obj.SetData(DataFormats.Html, new System.IO.MemoryStream(
						   file.Buffer));
						Clipboard.SetDataObject(obj, true);

						if (MessageBox.Show("Se ha copiado el reporte a tu portapapeles.", "Reporte copiado", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
						{
							Form frm = Application.OpenForms["frmItinerary"];
							if (frm != null)
							{
								CloseForm(frm);
							}
						}
					}
					catch
					{
						MessageBox.Show("Ocurrio un problema al copiar el reporte al portapapeles.", "Reporte no copiado", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					MessageBox.Show("Por favor, verifique que los segmentos seleccionados existan entre los segmentos apartados.", "Segmento no encontrado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void InitializeComponent()
		{
			this.wbContent = new System.Windows.Forms.WebBrowser();
			this.SuspendLayout();
			// 
			// wbContent
			// 
			this.wbContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wbContent.Location = new System.Drawing.Point(0, 0);
			this.wbContent.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbContent.Name = "wbContent";
			this.wbContent.ScrollBarsEnabled = false;
			this.wbContent.Size = new System.Drawing.Size(900, 575);
			this.wbContent.TabIndex = 0;
			// 
			// ucItinerary
			// 
			this.Controls.Add(this.wbContent);
			this.Name = "ucItinerary";
			this.Size = new System.Drawing.Size(900, 575);
			this.ResumeLayout(false);

		}
	}
}