using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Services.Contracts;
#if (VOLARIS_PRODUCTION)
using ClipboardServices = MyCTS.Services.ClipboardService;
#else
using ClipboardServices = MyCTS.Services.ClipboardService;
#endif

namespace MyCTS.Presentation
{
	public partial class ucSearch : CustomUserControl
	{
		ClipboardServices.Search search = new ClipboardServices.Search();

		public ucSearch()
		{
			string sabreAnswer = string.Empty;
			using (CommandsAPI objCommand = new CommandsAPI())
			{
				sabreAnswer = objCommand.SendReceive("*A", 0, 0);
			}
			if (string.IsNullOrEmpty(sabreAnswer) || sabreAnswer.Trim() == "NO DATA")
			{
				MessageBox.Show("Es necesario tener Segmentos Vendidos o un PNR abierto.", "No hay segmentos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Form frm = Application.OpenForms["frmSearch"];
				if (frm != null)
				{
					InsertLogClipboardCTSBL.InsertLogClipboardCTS(DateTime.Now, Login.Agent, 3, null);
					CloseForm(frm);
				}
			}
			else
			{
				if (sabreAnswer.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)[0] == "NO NAMES")
				{
					InsertLogClipboardCTSBL.InsertLogClipboardCTS(DateTime.Now, Login.Agent, 3, null);
				}
				else
				{
					InsertLogClipboardCTSBL.InsertLogClipboardCTS(DateTime.Now, Login.Agent, 3, sabreAnswer.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)[0]);
				}

				InitializeComponent();
				wbContent.DocumentCompleted += wbContent_DocumentCompleted;
			}

		}

		void wbContent_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			HtmlElement btnAcept = wbContent.Document.GetElementById("btnAcept");
			HtmlElement btnCancel = wbContent.Document.GetElementById("btnCancel");
			if (wbContent.DocumentText.Contains("Otros Cargos - Clipboard CTS - Bargain Finder Plus"))
			{
				btnAcept.AttachEventHandler("onclick", btnAcept_Click2);
			}
			else if (wbContent.DocumentText.Contains("Busqueda - Clipboard CTS - Bargain Finder Plus"))
			{
				btnAcept.AttachEventHandler("onclick", btnAcept_Click);
			}

			btnCancel.AttachEventHandler("onclick", btnCancel_Click);
		}

		private void btnAcept_Click(object sender, EventArgs e)
		{
			frmPreloading frm = new frmPreloading(this);
			frm.Show();
			string sabreAnswer = string.Empty;
			HtmlElement lblFormat = wbContent.Document.GetElementById("lblFormat");
			HtmlElement txtSegments = wbContent.Document.GetElementById("txtSegments");
			HtmlElement txtCurrency = wbContent.Document.GetElementById("txtCurrency");

			using (CommandsAPI objCommand = new CommandsAPI())
			{
				sabreAnswer = objCommand.SendReceive("*A", 0, 0);
			}

			GetLCCAirlinesBL bl = new GetLCCAirlinesBL();
			List<string> airlinesLCC = bl.GetLCCAirlines();
			CatSubTypePaxBL paxBL = new CatSubTypePaxBL();
			List<string> passengerTypes = paxBL.CatSubTypePax();
			List<string[]> numberSegments = new List<string[]>();

			foreach (string segment in sabreAnswer.Replace("‡", "\n").Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
			{
				int rest = 0;
				if (int.TryParse(segment.Trim().Split(' ')[0], out rest))
				{
					bool isLCC = false;

					foreach (string airline in airlinesLCC)
					{
						if (segment.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1].Substring(0, 2) == airline)
						{
							isLCC = true;
							break;
						}
					}

					if (isLCC)
					{
						numberSegments.Add(new string[] { segment.Trim().Split(' ')[0], "LCC" });
					}
					else
					{
						numberSegments.Add(new string[] { segment.Trim().Split(' ')[0],
                            string.IsNullOrEmpty(segment.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1])
                            ?
                            string.IsNullOrEmpty(segment.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2])
                            ?
                            segment.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3]
                            :
                            segment.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2]
                            :
                            segment.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1] });

						if (numberSegments[numberSegments.Count - 1][1] != "LCC" && numberSegments[numberSegments.Count - 1][1] != "CAR" && numberSegments[numberSegments.Count - 1][1] != "SEA" && numberSegments[numberSegments.Count - 1][1] != "HHL" && numberSegments[numberSegments.Count - 1][1] != "OTH" && numberSegments[numberSegments.Count - 1][1] != "ARNK")
						{
							numberSegments[numberSegments.Count - 1][1] = numberSegments[numberSegments.Count - 1][1].Substring(0, 2);
						}
					}
				}
			}

			string segments = string.Empty;

			foreach (string s in txtSegments.GetAttribute("Value").Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
			{
				if (s.Contains("-"))
				{
					foreach (string s2 in s.Trim().Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries))
					{
						if (!string.IsNullOrEmpty(segments))
						{
							segments += ",";
						}

						segments += s2.Trim(); ;
					}
				}
				else
				{
					if (!string.IsNullOrEmpty(segments))
					{
						segments += ",";
					}

					segments += s.Trim(); ;
				}
			}

			bool isCorrect = true;
			bool isLowCC = false;

			if (!string.IsNullOrEmpty(segments))
			{
				foreach (string segment in segments.Split(','))
				{
					int j = 0;

					if (!int.TryParse(segment, out j))
					{
						isCorrect = false;
						break;
					}

					if (int.Parse(segment) > numberSegments.Count || int.Parse(segment) < 1)
					{
						isCorrect = false;
						break;
					}

					foreach (string[] numberSegment in numberSegments)
					{
						if (int.Parse(numberSegment[0]) == int.Parse(segment))
						{
							if (numberSegment[1] == "LCC" || numberSegment[1] == "CAR" || numberSegment[1] == "SEA" || numberSegment[1] == "HHL" || numberSegment[1] == "OTH" || numberSegment[1] == "ARNK")
							{
								isLowCC = true;
								break;
							}
						}
					}

					if (isLowCC)
					{
						break;
					}
				}
			}

			if (string.IsNullOrEmpty(txtSegments.GetAttribute("Value").Trim()))
			{
				isLowCC = true;
				foreach (string[] numberSegment in numberSegments)
				{
					if (numberSegment[1] != "LCC" && numberSegment[1] != "CAR" && numberSegment[1] != "SEA" && numberSegment[1] != "HHL" && numberSegment[1] != "OTH" && numberSegment[1] != "ARNK")
					{
						isLowCC = false;
						break;
					}
				}
			}

			if (isLowCC)
			{
				frm.Close();
				MessageBox.Show("Segmentos seleccionados no aplican para Bargain Finder Plus", "Segmentos no compatibles.", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else if (isCorrect)
			{
				using (CommandsAPI2 objCommand = new CommandsAPI2())
				{
					//if (!string.IsNullOrEmpty(60000))
					sabreAnswer = objCommand.SendReceive("OIATH", 0, 0);
					//else
					//  sabreAnswer = objCommand.SendReceiveEmission(lblFormat.InnerText, 1, 1, 6000);
				}

				string sessionId = sabreAnswer.Replace("ATH:", string.Empty).Replace("\n", string.Empty).Trim();

				ClipboardService service = new ClipboardService();

				search = service.CopyReport(sessionId, lblFormat.InnerText);


				////using (CommandsAPI2 objCommand = new CommandsAPI2())
				////{
				////    //if (!string.IsNullOrEmpty(60000))
				////    sabreAnswer = objCommand.SendReceiveEmission(lblFormat.InnerText, 0, 0, Convert.ToInt32("6000"));
				////    //else
				////    //  sabreAnswer = objCommand.SendReceiveEmission(lblFormat.InnerText, 1, 1, 6000);
				////}



				//////using (CommandsAPI2 objCommand = new CommandsAPI2())
				//////{
				//////    sabreAnswer = objCommand.SendReceive(lblFormat.InnerText,0, 0).Replace("‡", "\n");
				//////}

				////string segmentID = string.Empty;
				////search.Options = new List<Services.ClipboardService.Option>();
				////Regex regexSharedFlight = new Regex(@"^/([*]|[A-Z]){2}$");

				////foreach (string segment in sabreAnswer.Replace("‡", "\n").Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
				////{
				////    if (string.IsNullOrEmpty(segment.Trim()))
				////    {
				////        continue;
				////    }
				////    if (segment.StartsWith("CURRENT ITINERARY-"))
				////    {
				////        // Empieza Itinerario Actual
				////        search.CurrentItinerary = new Services.ClipboardService.Option();
				////        search.CurrentItinerary.Passengers = new List<Services.ClipboardService.Traveller>();
				////        search.CurrentItinerary.Flights = new List<Services.ClipboardService.Flight>();
				////        search.CurrentItinerary.Currency = string.IsNullOrEmpty(txtCurrency.GetAttribute("Value")) ? "MXN" : txtCurrency.GetAttribute("Value");
				////        segmentID = "CURRENT";
				////    }

				////    if (segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].Contains("OPTION") && !segment.Contains("NUMBER"))
				////    {
				////        search.Options.Add(new Services.ClipboardService.Option());
				////        search.Options[search.Options.Count - 1].Passengers = new List<Services.ClipboardService.Traveller>();
				////        search.Options[search.Options.Count - 1].Flights = new List<Services.ClipboardService.Flight>();
				////        search.Options[search.Options.Count - 1].Currency = string.IsNullOrEmpty(txtCurrency.GetAttribute("Value")) ? "MXN" : txtCurrency.GetAttribute("Value");
				////        segmentID = "OPTION";
				////    }

				////    int n = 0;

				////    if (segmentID == "CURRENT")
				////    {
				////        foreach (string type in passengerTypes)
				////        {
				////            Regex regexType = new Regex(string.Concat(@"^\d+", type, "$"));
				////            if (regexType.IsMatch(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0]))
				////            {
				////                search.CurrentItinerary.Passengers.Add(new Services.ClipboardService.Traveller
				////                {
				////                    Currency = string.IsNullOrEmpty(txtCurrency.GetAttribute("Value")) ? "MXN" : txtCurrency.GetAttribute("Value"),
				////                    Quantity = segment.Substring(segment.IndexOf(type.ToUpper()) - 4, 4).Trim(),
				////                    Type = type.ToUpper(),
				////                    Cost = segment.Substring(segment.IndexOf(type.ToUpper())).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1],
				////                    Total = segment.Substring(segment.IndexOf(type.ToUpper())).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2]
				////                });
				////                break;
				////            }
				////        }

				////        if (segment.Contains("OPERATED"))
				////        {
				////            bool contains = false;

				////            foreach (string type in passengerTypes)
				////            {
				////                if (segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].Contains(type.ToUpper()))
				////                {
				////                    contains = true;
				////                    break;
				////                }
				////            }

				////            if (contains)
				////            {
				////                search.CurrentItinerary.Flights[search.CurrentItinerary.Flights.Count - 1].Operated = segment.Substring(segment.IndexOf("OPERATED BY")).Replace("OPERATED BY", string.Empty).Split('‡')[0].Trim();
				////            }
				////            else
				////            {
				////                search.CurrentItinerary.Flights[search.CurrentItinerary.Flights.Count - 1].Operated = segment.Substring(segment.IndexOf("OPERATED BY")).Replace("OPERATED BY", string.Empty).Trim();
				////            }
				////        }

				////        if (segment.Contains("TOTAL FARE"))
				////        {
				////            search.CurrentItinerary.Fare = segment.Substring(segment.IndexOf("TOTAL FARE")).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				////            search.CurrentItinerary.Total = segment.Substring(segment.IndexOf("TOTAL FARE")).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				////        }
				////        else if (int.TryParse(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0], out n))
				////        {
				////            if (segment.Contains("‡"))
				////            {
				////                foreach (string seg in segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries))
				////                {
				////                    if (int.TryParse(seg.Split(' ')[0], out n))
				////                    {
				////                        if (seg.Contains("/**"))
				////                        {
				////                            Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				////                            if (seg.StartsWith("OPERATED BY"))
				////                            {
				////                                flight.AircraftType = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				////                                flight.Airline = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				////                                flight.Arrival = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8];
				////                                flight.ArrivalDate = DateTime.ParseExact(seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				////                                flight.ArrivalHour = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10].Insert(2, ":");
				////                                flight.Class = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				////                                flight.Departure = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				////                                flight.DepartureDate = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5];
				////                                flight.DepartureHour = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				////                                flight.FlightNumber = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				////                                flight.PlusDays = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12];
				////                                flight.Stops = "0";
				////                            }
				////                            else
				////                            {
				////                                flight.AircraftType = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				////                                flight.Airline = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				////                                flight.Arrival = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8];
				////                                flight.ArrivalDate = DateTime.ParseExact(seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				////                                flight.ArrivalHour = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10].Insert(2, ":");
				////                                flight.Class = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				////                                flight.Departure = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				////                                flight.DepartureDate = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5];
				////                                flight.DepartureHour = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				////                                flight.FlightNumber = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				////                                flight.PlusDays = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12];
				////                                flight.Stops = "0";
				////                            }

				////                            search.CurrentItinerary.Flights.Add(flight);
				////                        }
				////                        else
				////                        {
				////                            Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				////                            flight.AircraftType = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10];
				////                            flight.Airline = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				////                            flight.Arrival = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				////                            flight.ArrivalDate = DateTime.ParseExact(seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				////                            flight.ArrivalHour = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				////                            flight.Class = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				////                            flight.Departure = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[6];
				////                            flight.DepartureDate = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				////                            flight.DepartureHour = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8].Insert(2, ":");
				////                            flight.FlightNumber = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2];
				////                            flight.PlusDays = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				////                            flight.Stops = "0";

				////                            search.CurrentItinerary.Flights.Add(flight);
				////                        }
				////                    }
				////                }
				////            }
				////            else
				////            {
				////                bool isShared = false;

				////                foreach (string seg in segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
				////                {
				////                    if (regexSharedFlight.IsMatch(seg))
				////                    {
				////                        isShared = true;
				////                        break;
				////                    }
				////                }

				////                if (isShared)
				////                {
				////                    Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				////                    flight.AircraftType = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				////                    flight.Airline = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				////                    flight.Arrival = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8];
				////                    flight.ArrivalDate = DateTime.ParseExact(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				////                    flight.ArrivalHour = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10].Insert(2, ":");
				////                    flight.Class = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				////                    flight.Departure = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				////                    flight.DepartureDate = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5];
				////                    flight.DepartureHour = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				////                    flight.FlightNumber = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				////                    flight.PlusDays = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12];
				////                    flight.Stops = "0";

				////                    search.CurrentItinerary.Flights.Add(flight);
				////                }
				////                else
				////                {
				////                    Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				////                    flight.AircraftType = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10];
				////                    flight.Airline = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				////                    flight.Arrival = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				////                    flight.ArrivalDate = DateTime.ParseExact(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				////                    flight.ArrivalHour = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				////                    flight.Class = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				////                    flight.Departure = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[6];
				////                    flight.DepartureDate = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				////                    flight.DepartureHour = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8].Insert(2, ":");
				////                    flight.FlightNumber = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2];
				////                    flight.PlusDays = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				////                    flight.Stops = "0";

				////                    search.CurrentItinerary.Flights.Add(flight);
				////                }
				////            }
				////        }
				////        else if (segment.StartsWith("OPERATED BY"))
				////        {
				////            if (segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries).Length > 1)
				////            {
				////                bool isShared = false;

				////                foreach (string seg in segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
				////                {
				////                    if (regexSharedFlight.IsMatch(seg))
				////                    {
				////                        isShared = true;
				////                        break;
				////                    }
				////                }

				////                if (isShared)
				////                {
				////                    Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				////                    flight.AircraftType = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				////                    flight.Airline = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				////                    flight.Arrival = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8];
				////                    flight.ArrivalDate = DateTime.ParseExact(segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				////                    flight.ArrivalHour = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10].Insert(2, ":");
				////                    flight.Class = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				////                    flight.Departure = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				////                    flight.DepartureDate = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5];
				////                    flight.DepartureHour = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				////                    flight.FlightNumber = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				////                    flight.PlusDays = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12];
				////                    flight.Stops = "0";

				////                    search.CurrentItinerary.Flights.Add(flight);
				////                }
				////                else
				////                {
				////                    Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				////                    flight.AircraftType = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10];
				////                    flight.Airline = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				////                    flight.Arrival = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				////                    flight.ArrivalDate = DateTime.ParseExact(segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				////                    flight.ArrivalHour = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				////                    flight.Class = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				////                    flight.Departure = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[6];
				////                    flight.DepartureDate = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				////                    flight.DepartureHour = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8].Insert(2, ":");
				////                    flight.FlightNumber = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2];
				////                    flight.PlusDays = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				////                    flight.Stops = "0";

				////                    search.CurrentItinerary.Flights.Add(flight);
				////                }
				////            }
				////        }
				////    }
				////    else if (segmentID == "OPTION")
				////    {
				////        foreach (string type in passengerTypes)
				////        {
				////            Regex regexType = new Regex(string.Concat(@"^\d+", type, "$"));
				////            if (regexType.IsMatch(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0]))
				////            {
				////                search.Options[search.Options.Count - 1].Passengers.Add(new Services.ClipboardService.Traveller
				////                {
				////                    Currency = string.IsNullOrEmpty(txtCurrency.GetAttribute("Value")) ? "MXN" : txtCurrency.GetAttribute("Value"),
				////                    Quantity = segment.Substring(segment.IndexOf(type.ToUpper()) - 4, 4).Trim(),
				////                    Type = type.ToUpper(),
				////                    Cost = segment.Substring(segment.IndexOf(type.ToUpper())).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1],
				////                    Total = segment.Substring(segment.IndexOf(type.ToUpper())).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2]
				////                });
				////                break;
				////            }
				////        }

				////        if (segment.Contains("OPERATED"))
				////        {
				////            search.Options[search.Options.Count - 1].Flights[search.Options[search.Options.Count - 1].Flights.Count - 1].Operated = segment.Substring(segment.IndexOf("OPERATED BY")).Replace("OPERATED BY", string.Empty).Trim();
				////        }

				////        if (segment.Contains("TOTAL FARE"))
				////        {
				////            search.Options[search.Options.Count - 1].Fare = segment.Substring(segment.IndexOf("TOTAL FARE")).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				////            search.Options[search.Options.Count - 1].Total = segment.Substring(segment.IndexOf("TOTAL FARE")).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				////        }
				////        else if (int.TryParse(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0], out n))
				////        {
				////            if (segment.Contains("‡"))
				////            {
				////                foreach (string seg in segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries))
				////                {
				////                    if (int.TryParse(seg.Split(' ')[0], out n))
				////                    {
				////                        if (seg.Contains("/**"))
				////                        {
				////                            Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				////                            if (seg.StartsWith("OPERATED BY"))
				////                            {
				////                                flight.AircraftType = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				////                                flight.Airline = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				////                                flight.Arrival = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8];
				////                                flight.ArrivalDate = DateTime.ParseExact(seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				////                                flight.ArrivalHour = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10].Insert(2, ":");
				////                                flight.Class = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				////                                flight.Departure = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				////                                flight.DepartureDate = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5];
				////                                flight.DepartureHour = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				////                                flight.FlightNumber = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				////                                flight.PlusDays = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12];
				////                                flight.Stops = "0";
				////                            }
				////                            else
				////                            {
				////                                flight.AircraftType = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				////                                flight.Airline = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				////                                flight.Arrival = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8];
				////                                flight.ArrivalDate = DateTime.ParseExact(seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				////                                flight.ArrivalHour = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10].Insert(2, ":");
				////                                flight.Class = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				////                                flight.Departure = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				////                                flight.DepartureDate = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5];
				////                                flight.DepartureHour = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				////                                flight.FlightNumber = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				////                                flight.PlusDays = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12];
				////                                flight.Stops = "0";
				////                            }

				////                            search.Options[search.Options.Count - 1].Flights.Add(flight);
				////                        }
				////                        else
				////                        {
				////                            Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				////                            flight.AircraftType = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10];
				////                            flight.Airline = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				////                            flight.Arrival = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				////                            flight.ArrivalDate = DateTime.ParseExact(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				////                            flight.ArrivalHour = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				////                            flight.Class = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				////                            flight.Departure = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[6];
				////                            flight.DepartureDate = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				////                            flight.DepartureHour = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8].Insert(2, ":");
				////                            flight.FlightNumber = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2];
				////                            flight.PlusDays = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				////                            flight.Stops = "0";

				////                            search.Options[search.Options.Count - 1].Flights.Add(flight);
				////                        }
				////                    }
				////                }
				////            }
				////            else
				////            {
				////                bool isShared = false;

				////                foreach (string seg in segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
				////                {
				////                    if (regexSharedFlight.IsMatch(seg))
				////                    {
				////                        isShared = true;
				////                        break;
				////                    }
				////                }

				////                if (isShared)
				////                {
				////                    Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				////                    flight.AircraftType = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				////                    flight.Airline = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				////                    flight.Arrival = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8];
				////                    flight.ArrivalDate = DateTime.ParseExact(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				////                    flight.ArrivalHour = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10].Insert(2, ":");
				////                    flight.Class = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				////                    flight.Departure = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				////                    flight.DepartureDate = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5];
				////                    flight.DepartureHour = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				////                    flight.FlightNumber = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				////                    flight.PlusDays = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12];
				////                    flight.Stops = "0";

				////                    search.Options[search.Options.Count - 1].Flights.Add(flight);
				////                }
				////                else
				////                {
				////                    Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				////                    flight.AircraftType = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10];
				////                    flight.Airline = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				////                    flight.Arrival = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				////                    flight.ArrivalDate = DateTime.ParseExact(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				////                    flight.ArrivalHour = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				////                    flight.Class = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				////                    flight.Departure = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[6];
				////                    flight.DepartureDate = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				////                    flight.DepartureHour = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8].Insert(2, ":");
				////                    flight.FlightNumber = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2];
				////                    flight.PlusDays = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				////                    flight.Stops = "0";

				////                    search.Options[search.Options.Count - 1].Flights.Add(flight);
				////                }
				////            }
				////        }
				////        else if (segment.StartsWith("OPERATED BY"))
				////        {
				////            if (segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries).Length > 1)
				////            {
				////                bool isShared = false;

				////                foreach (string seg in segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
				////                {
				////                    if (regexSharedFlight.IsMatch(seg))
				////                    {
				////                        isShared = true;
				////                        break;
				////                    }
				////                }

				////                if (isShared)
				////                {
				////                    Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				////                    flight.AircraftType = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				////                    flight.Airline = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				////                    flight.Arrival = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8];
				////                    flight.ArrivalDate = DateTime.ParseExact(segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				////                    flight.ArrivalHour = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10].Insert(2, ":");
				////                    flight.Class = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				////                    flight.Departure = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				////                    flight.DepartureDate = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5];
				////                    flight.DepartureHour = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				////                    flight.FlightNumber = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				////                    flight.PlusDays = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12];
				////                    flight.Stops = "0";

				////                    search.Options[search.Options.Count - 1].Flights.Add(flight);
				////                }
				////                else
				////                {
				////                    Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				////                    flight.AircraftType = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10];
				////                    flight.Airline = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				////                    flight.Arrival = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				////                    flight.ArrivalDate = DateTime.ParseExact(segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				////                    flight.ArrivalHour = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				////                    flight.Class = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				////                    flight.Departure = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[6];
				////                    flight.DepartureDate = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				////                    flight.DepartureHour = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8].Insert(2, ":");
				////                    flight.FlightNumber = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2];
				////                    flight.PlusDays = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				////                    flight.Stops = "0";

				////                    search.Options[search.Options.Count - 1].Flights.Add(flight);
				////                }
				////            }
				////        }
				////    }
				////}

				//while (!sabreAnswer.Contains("END OF SCROLL"))
				//{
				//    using (CommandsAPI objCommand = new CommandsAPI())
				//    {
				//        sabreAnswer = objCommand.SendReceive("MD", 0, 0).Replace("‡", "\n"); ;
				//    }

				//    foreach (string segment in sabreAnswer.Replace("‡", "\n").Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
				//    {
				//        if (string.IsNullOrEmpty(segment.Trim()))
				//        {
				//            continue;
				//        }

				//        if (segment.StartsWith("CURRENT ITINERARY-"))
				//        {
				//            // Empieza Itinerario Actual
				//            search.CurrentItinerary = new Services.ClipboardService.Option();
				//            search.CurrentItinerary.Passengers = new List<Services.ClipboardService.Traveller>();
				//            search.CurrentItinerary.Flights = new List<Services.ClipboardService.Flight>();
				//            segmentID = "CURRENT";
				//            search.CurrentItinerary.Currency = string.IsNullOrEmpty(txtCurrency.GetAttribute("Value")) ? "MXN" : txtCurrency.GetAttribute("Value");
				//        }

				//        if (segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].Contains("OPTION") && !segment.Contains("NUMBER"))
				//        {
				//            search.Options.Add(new Services.ClipboardService.Option());
				//            search.Options[search.Options.Count - 1].Passengers = new List<Services.ClipboardService.Traveller>();
				//            search.Options[search.Options.Count - 1].Flights = new List<Services.ClipboardService.Flight>();
				//            search.Options[search.Options.Count - 1].Currency = string.IsNullOrEmpty(txtCurrency.GetAttribute("Value")) ? "MXN" : txtCurrency.GetAttribute("Value");
				//            segmentID = "OPTION";
				//        }

				//        int n = 0;

				//        if (segmentID == "CURRENT")
				//        {
				//            foreach (string type in passengerTypes)
				//            {
				//                Regex regexType = new Regex(string.Concat(@"^\d+", type, "$"));
				//                if (regexType.IsMatch(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0]))
				//                {
				//                    search.CurrentItinerary.Passengers.Add(new Services.ClipboardService.Traveller
				//                    {
				//                        Currency = string.IsNullOrEmpty(txtCurrency.GetAttribute("Value")) ? "MXN" : txtCurrency.GetAttribute("Value"),
				//                        Quantity = segment.Substring(segment.IndexOf(type.ToUpper()) - 4, 4).Trim(),
				//                        Type = type.ToUpper(),
				//                        Cost = segment.Substring(segment.IndexOf(type.ToUpper())).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1],
				//                        Total = segment.Substring(segment.IndexOf(type.ToUpper())).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2]
				//                    });
				//                    break;
				//                }
				//            }

				//            if (segment.Contains("OPERATED"))
				//            {
				//                bool contains = false;

				//                foreach (string type in passengerTypes)
				//                {
				//                    if (segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].Contains(type.ToUpper()))
				//                    {
				//                        contains = true;
				//                        break;
				//                    }
				//                }

				//                if (contains)
				//                {
				//                    search.CurrentItinerary.Flights[search.CurrentItinerary.Flights.Count - 1].Operated = segment.Substring(segment.IndexOf("OPERATED BY")).Replace("OPERATED BY", string.Empty).Split('‡')[0].Trim();
				//                }
				//                else
				//                {
				//                    search.CurrentItinerary.Flights[search.CurrentItinerary.Flights.Count - 1].Operated = segment.Substring(segment.IndexOf("OPERATED BY")).Replace("OPERATED BY", string.Empty).Trim();
				//                }
				//            }

				//            if (segment.Contains("TOTAL FARE"))
				//            {
				//                search.CurrentItinerary.Fare = segment.Substring(segment.IndexOf("TOTAL FARE")).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//                search.CurrentItinerary.Total = segment.Substring(segment.IndexOf("TOTAL FARE")).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//            }
				//            else if (int.TryParse(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0], out n))
				//            {
				//                if (segment.Contains("‡"))
				//                {
				//                    foreach (string seg in segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries))
				//                    {
				//                        if (int.TryParse(seg.Split(' ')[0], out n))
				//                        {
				//                            if (seg.Contains("/**"))
				//                            {
				//                                Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				//                                if (segment.StartsWith("OPERATED BY"))
				//                                {
				//                                    flight.AircraftType = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				//                                    flight.Airline = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				//                                    flight.Arrival = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8];
				//                                    flight.ArrivalDate = DateTime.ParseExact(seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				//                                    flight.ArrivalHour = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10].Insert(2, ":");
				//                                    flight.Class = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//                                    flight.Departure = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				//                                    flight.DepartureDate = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5];
				//                                    flight.DepartureHour = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				//                                    flight.FlightNumber = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				//                                    flight.PlusDays = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12];
				//                                    flight.Stops = "0";
				//                                }
				//                                else
				//                                {
				//                                    flight.AircraftType = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				//                                    flight.Airline = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				//                                    flight.Arrival = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8];
				//                                    flight.ArrivalDate = DateTime.ParseExact(seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				//                                    flight.ArrivalHour = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10].Insert(2, ":");
				//                                    flight.Class = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//                                    flight.Departure = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				//                                    flight.DepartureDate = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5];
				//                                    flight.DepartureHour = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				//                                    flight.FlightNumber = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				//                                    flight.PlusDays = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12];
				//                                    flight.Stops = "0";
				//                                }

				//                                search.CurrentItinerary.Flights.Add(flight);
				//                            }
				//                            else
				//                            {
				//                                Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				//                                flight.AircraftType = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10];
				//                                flight.Airline = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				//                                flight.Arrival = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				//                                flight.ArrivalDate = DateTime.ParseExact(seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				//                                flight.ArrivalHour = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				//                                flight.Class = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				//                                flight.Departure = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[6];
				//                                flight.DepartureDate = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//                                flight.DepartureHour = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8].Insert(2, ":");
				//                                flight.FlightNumber = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2];
				//                                flight.PlusDays = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				//                                flight.Stops = "0";

				//                                search.CurrentItinerary.Flights.Add(flight);
				//                            }
				//                        }
				//                    }
				//                }
				//                else
				//                {
				//                    bool isShared = false;

				//                    foreach (string seg in segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
				//                    {
				//                        if (regexSharedFlight.IsMatch(seg))
				//                        {
				//                            isShared = true;
				//                            break;
				//                        }
				//                    }

				//                    if (isShared)
				//                    {
				//                        Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				//                        flight.AircraftType = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				//                        flight.Airline = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				//                        flight.Arrival = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8];
				//                        flight.ArrivalDate = DateTime.ParseExact(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				//                        flight.ArrivalHour = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10].Insert(2, ":");
				//                        flight.Class = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//                        flight.Departure = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				//                        flight.DepartureDate = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5];
				//                        flight.DepartureHour = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				//                        flight.FlightNumber = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				//                        flight.PlusDays = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12];
				//                        flight.Stops = "0";

				//                        search.CurrentItinerary.Flights.Add(flight);
				//                    }
				//                    else
				//                    {
				//                        Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				//                        flight.AircraftType = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10];
				//                        flight.Airline = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				//                        flight.Arrival = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				//                        flight.ArrivalDate = DateTime.ParseExact(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				//                        flight.ArrivalHour = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				//                        flight.Class = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				//                        flight.Departure = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[6];
				//                        flight.DepartureDate = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//                        flight.DepartureHour = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8].Insert(2, ":");
				//                        flight.FlightNumber = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2];
				//                        flight.PlusDays = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				//                        flight.Stops = "0";

				//                        search.CurrentItinerary.Flights.Add(flight);
				//                    }
				//                }
				//            }
				//            else if (segment.StartsWith("OPERATED BY"))
				//            {
				//                if (segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries).Length > 1)
				//                {
				//                    if (int.TryParse(segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0], out n))
				//                    {
				//                        bool isShared = false;

				//                        foreach (string seg in segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
				//                        {
				//                            if (regexSharedFlight.IsMatch(seg))
				//                            {
				//                                isShared = true;
				//                                break;
				//                            }
				//                        }

				//                        if (isShared)
				//                        {
				//                            Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				//                            flight.AircraftType = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				//                            flight.Airline = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				//                            flight.Arrival = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8];
				//                            flight.ArrivalDate = DateTime.ParseExact(segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				//                            flight.ArrivalHour = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10].Insert(2, ":");
				//                            flight.Class = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//                            flight.Departure = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				//                            flight.DepartureDate = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5];
				//                            flight.DepartureHour = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				//                            flight.FlightNumber = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				//                            flight.PlusDays = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12];
				//                            flight.Stops = "0";

				//                            search.CurrentItinerary.Flights.Add(flight);
				//                        }
				//                        else
				//                        {
				//                            Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				//                            flight.AircraftType = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10];
				//                            flight.Airline = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				//                            flight.Arrival = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				//                            flight.ArrivalDate = DateTime.ParseExact(segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				//                            flight.ArrivalHour = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				//                            flight.Class = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				//                            flight.Departure = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[6];
				//                            flight.DepartureDate = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//                            flight.DepartureHour = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8].Insert(2, ":");
				//                            flight.FlightNumber = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2];
				//                            flight.PlusDays = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				//                            flight.Stops = "0";

				//                            search.CurrentItinerary.Flights.Add(flight);
				//                        }
				//                    }
				//                }
				//            }
				//        }
				//        else if (segmentID == "OPTION")
				//        {
				//            foreach (string type in passengerTypes)
				//            {
				//                Regex regexType = new Regex(string.Concat(@"^\d+", type, "$"));
				//                if (regexType.IsMatch(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0]))
				//                {
				//                    search.Options[search.Options.Count - 1].Passengers.Add(new Services.ClipboardService.Traveller
				//                    {
				//                        Currency = string.IsNullOrEmpty(txtCurrency.GetAttribute("Value")) ? "MXN" : txtCurrency.GetAttribute("Value"),
				//                        Quantity = segment.Substring(segment.IndexOf(type.ToUpper()) - 4, 4).Trim(),
				//                        Type = type.ToUpper(),
				//                        Cost = segment.Substring(segment.IndexOf(type.ToUpper())).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1],
				//                        Total = segment.Substring(segment.IndexOf(type.ToUpper())).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2]
				//                    });
				//                    break;
				//                }
				//            }

				//            if (segment.Contains("OPERATED"))
				//            {
				//                bool contains = false;

				//                foreach (string type in passengerTypes)
				//                {
				//                    if (segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].Contains(type.ToUpper()))
				//                    {
				//                        contains = true;
				//                        break;
				//                    }
				//                }

				//                if (contains)
				//                {
				//                    search.Options[search.Options.Count - 1].Flights[search.Options[search.Options.Count - 1].Flights.Count - 1].Operated = segment.Substring(segment.IndexOf("OPERATED BY")).Replace("OPERATED BY", string.Empty).Split('‡')[0].Trim();
				//                }
				//                else
				//                {
				//                    search.Options[search.Options.Count - 1].Flights[search.Options[search.Options.Count - 1].Flights.Count - 1].Operated = segment.Substring(segment.IndexOf("OPERATED BY")).Replace("OPERATED BY", string.Empty).Trim();
				//                }
				//            }

				//            if (segment.Contains("TOTAL FARE"))
				//            {
				//                search.Options[search.Options.Count - 1].Fare = segment.Substring(segment.IndexOf("TOTAL FARE")).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//                search.Options[search.Options.Count - 1].Total = segment.Substring(segment.IndexOf("TOTAL FARE")).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//            }
				//            else if (int.TryParse(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0], out n))
				//            {
				//                if (segment.Contains("‡"))
				//                {
				//                    foreach (string seg in segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries))
				//                    {
				//                        if (int.TryParse(seg.Split(' ')[0], out n))
				//                        {
				//                            if (seg.Contains("/**"))
				//                            {
				//                                Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				//                                if (segment.StartsWith("OPERATED BY"))
				//                                {
				//                                    flight.AircraftType = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				//                                    flight.Airline = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				//                                    flight.Arrival = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8];
				//                                    flight.ArrivalDate = DateTime.ParseExact(seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				//                                    flight.ArrivalHour = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10].Insert(2, ":");
				//                                    flight.Class = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//                                    flight.Departure = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				//                                    flight.DepartureDate = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5];
				//                                    flight.DepartureHour = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				//                                    flight.FlightNumber = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				//                                    flight.PlusDays = seg.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12];
				//                                    flight.Stops = "0";
				//                                }
				//                                else
				//                                {
				//                                    flight.AircraftType = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				//                                    flight.Airline = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				//                                    flight.Arrival = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8];
				//                                    flight.ArrivalDate = DateTime.ParseExact(seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				//                                    flight.ArrivalHour = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10].Insert(2, ":");
				//                                    flight.Class = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//                                    flight.Departure = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				//                                    flight.DepartureDate = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5];
				//                                    flight.DepartureHour = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				//                                    flight.FlightNumber = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				//                                    flight.PlusDays = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12];
				//                                    flight.Stops = "0";
				//                                }

				//                                search.Options[search.Options.Count - 1].Flights.Add(flight);
				//                            }
				//                            else
				//                            {
				//                                Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				//                                flight.AircraftType = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10];
				//                                flight.Airline = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				//                                flight.Arrival = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				//                                flight.ArrivalDate = DateTime.ParseExact(seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				//                                flight.ArrivalHour = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				//                                flight.Class = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				//                                flight.Departure = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[6];
				//                                flight.DepartureDate = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//                                flight.DepartureHour = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8].Insert(2, ":");
				//                                flight.FlightNumber = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2];
				//                                flight.PlusDays = seg.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				//                                flight.Stops = "0";

				//                                search.Options[search.Options.Count - 1].Flights.Add(flight);
				//                            }
				//                        }
				//                    }
				//                }
				//                else
				//                {
				//                    bool isShared = false;

				//                    foreach (string seg in segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
				//                    {
				//                        if (regexSharedFlight.IsMatch(seg))
				//                        {
				//                            isShared = true;
				//                            break;
				//                        }
				//                    }

				//                    if (isShared)
				//                    {
				//                        Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				//                        flight.AircraftType = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				//                        flight.Airline = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				//                        flight.Arrival = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8];
				//                        flight.ArrivalDate = DateTime.ParseExact(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				//                        flight.ArrivalHour = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10].Insert(2, ":");
				//                        flight.Class = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//                        flight.Departure = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				//                        flight.DepartureDate = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5];
				//                        flight.DepartureHour = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				//                        flight.FlightNumber = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				//                        flight.PlusDays = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12];
				//                        flight.Stops = "0";

				//                        search.Options[search.Options.Count - 1].Flights.Add(flight);
				//                    }
				//                    else
				//                    {
				//                        Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				//                        flight.AircraftType = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10];
				//                        flight.Airline = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				//                        flight.Arrival = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				//                        flight.ArrivalDate = DateTime.ParseExact(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				//                        flight.ArrivalHour = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				//                        flight.Class = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				//                        flight.Departure = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[6];
				//                        flight.DepartureDate = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//                        flight.DepartureHour = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8].Insert(2, ":");
				//                        flight.FlightNumber = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2];
				//                        flight.PlusDays = segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				//                        flight.Stops = "0";

				//                        search.Options[search.Options.Count - 1].Flights.Add(flight);
				//                    }
				//                }
				//            }
				//            else if (segment.StartsWith("OPERATED BY"))
				//            {
				//                if (segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries).Length > 1)
				//                {
				//                    if (int.TryParse(segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0], out n))
				//                    {
				//                        bool isShared = false;

				//                        foreach (string seg in segment.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
				//                        {
				//                            if (regexSharedFlight.IsMatch(seg))
				//                            {
				//                                isShared = true;
				//                                break;
				//                            }
				//                        }

				//                        if (isShared)
				//                        {
				//                            Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				//                            flight.AircraftType = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				//                            flight.Airline = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				//                            flight.Arrival = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8];
				//                            flight.ArrivalDate = DateTime.ParseExact(segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				//                            flight.ArrivalHour = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10].Insert(2, ":");
				//                            flight.Class = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//                            flight.Departure = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				//                            flight.DepartureDate = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5];
				//                            flight.DepartureHour = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				//                            flight.FlightNumber = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				//                            flight.PlusDays = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[12];
				//                            flight.Stops = "0";

				//                            search.Options[search.Options.Count - 1].Flights.Add(flight);
				//                        }
				//                        else
				//                        {
				//                            Services.ClipboardService.Flight flight = new Services.ClipboardService.Flight();

				//                            flight.AircraftType = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[10];
				//                            flight.Airline = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
				//                            flight.Arrival = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[7];
				//                            flight.ArrivalDate = DateTime.ParseExact(segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4], "ddMMM", new System.Globalization.CultureInfo("en-US")).AddDays(double.Parse(segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11])).ToString("ddMMM", new System.Globalization.CultureInfo("en-US")).ToUpper();
				//                            flight.ArrivalHour = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[9].Insert(2, ":");
				//                            flight.Class = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
				//                            flight.Departure = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[6];
				//                            flight.DepartureDate = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
				//                            flight.DepartureHour = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[8].Insert(2, ":");
				//                            flight.FlightNumber = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2];
				//                            flight.PlusDays = segment.Split(new string[] { "‡" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[11];
				//                            flight.Stops = "0";

				//                            search.Options[search.Options.Count - 1].Flights.Add(flight);
				//                        }
				//                    }
				//                }
				//            }
				//        }
				//    }
				//}

				if (search.ErrorMessage != null)
				{
					frm.Close();
					MessageBox.Show(search.ErrorMessage.Message, "Error en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{

					ClipboardServices.ClipboardServiceClient client = new ClipboardServices.ClipboardServiceClient();
					string html = string.Empty;
					bool isError = false;

					try
					{
						client.Open();
						if (string.IsNullOrEmpty(search.CurrentItinerary != null ? search.CurrentItinerary.Total : string.Empty))
						{
							search.CurrentItinerary = null;
						}
						html = client.GetSearchHTMLMarkOverSelection(search).Replace("WPNI", lblFormat.InnerText).Replace("CustomVar", search.Options.Count.ToString());

					}
					catch (Exception ex)
					{
						frm.Close();
						MessageBox.Show(ex.Message, "Error en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
						isError = true;
					}
					finally
					{
						if (client.State != System.ServiceModel.CommunicationState.Closed)
						{
							client.Close();
						}
					}

					if (!isError)
					{
						//panel1.Visible = false;
						//panel2.Visible = true;
						wbContent.Navigate("about:blank");
						wbContent.Document.OpenNew(true);
						wbContent.Document.Write(html);
						wbContent.Refresh();
						this.ResizeRedraw = true;
						this.SetClientSizeCore(590, 575);
						frm.Close();
						//wbContent.DocumentCompleted += wbContent_DocumentCompleted2;
					}
				}
			}
			else
			{
				frm.Close();
				MessageBox.Show("Segmentos seleccionados no encontrados. Favor de introducir segmentos dentro del rango.", "Segmentos no encontrados", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnAcept_Click2(object sender, EventArgs e)
		{
			frmPreloading frm = new frmPreloading(this);
			frm.Show();
			List<int> indexIgnorades = new List<int>();

			for (int i = search.Options.Count; i > 0; i--)
			{
				if (wbContent.Document.GetElementById(string.Concat("ckbOption", i.ToString())).GetAttribute("checked").ToUpper() == "TRUE")
				{
					for (int j = 0; j < search.Options[i - 1].Passengers.Count; j++)
					{
						search.Options[i - 1].Passengers[j].Total = float.Parse(string.IsNullOrEmpty(search.Options[i - 1].Passengers[j].Total) ? "0" : search.Options[i - 1].Passengers[j].Total).ToString("0.00", new System.Globalization.CultureInfo("es-MX"));
						search.Options[i - 1].Passengers[j].Cost = float.Parse(string.IsNullOrEmpty(search.Options[i - 1].Passengers[j].Cost) ? "0" : search.Options[i - 1].Passengers[j].Cost).ToString("0.00", new System.Globalization.CultureInfo("es-MX"));
					}

					search.Options[i - 1].Total = (float.Parse(search.Options[i - 1].Total) + float.Parse(wbContent.Document.GetElementById(string.Concat("txtOption", i.ToString())).GetAttribute("Value"))).ToString("0.00", new System.Globalization.CultureInfo("es-MX"));
					search.Options[i - 1].Fare = (float.Parse(search.Options[i - 1].Fare) + float.Parse(wbContent.Document.GetElementById(string.Concat("txtOption", i.ToString())).GetAttribute("Value"))).ToString("0.00", new System.Globalization.CultureInfo("es-MX"));
				}
				else
				{
					indexIgnorades.Add(i);
				}
			}

			foreach (int i in indexIgnorades)
			{
				search.Options.RemoveAt(i - 1);
			}

			if (!string.IsNullOrEmpty(search.CurrentItinerary != null ? search.CurrentItinerary.Total : ""))
			{
				if (wbContent.Document.GetElementById("ckbCurrent").GetAttribute("checked").ToUpper() == "TRUE")
				{
					for (int i = 0; i < search.CurrentItinerary.Passengers.Count; i++)
					{
						search.CurrentItinerary.Passengers[i].Total = float.Parse(string.IsNullOrEmpty(search.CurrentItinerary.Passengers[i].Total) ? "0" : search.CurrentItinerary.Passengers[i].Total).ToString("0.00", new System.Globalization.CultureInfo("es-MX"));
						search.CurrentItinerary.Passengers[i].Cost = float.Parse(string.IsNullOrEmpty(search.CurrentItinerary.Passengers[i].Cost) ? "0" : search.CurrentItinerary.Passengers[i].Cost).ToString("0.00", new System.Globalization.CultureInfo("es-MX"));
					}

					search.CurrentItinerary.Total = (float.Parse(search.CurrentItinerary.Total) + float.Parse(wbContent.Document.GetElementById("txtCurrent").GetAttribute("Value"))).ToString("0.00", new System.Globalization.CultureInfo("es-MX"));
					search.CurrentItinerary.Fare = (float.Parse(search.CurrentItinerary.Fare) + float.Parse(wbContent.Document.GetElementById("txtCurrent").GetAttribute("Value"))).ToString("0.00", new System.Globalization.CultureInfo("es-MX"));
				}
				else
				{
					search.CurrentItinerary = null;
				}
			}

			ClipboardServices.ClipboardServiceClient client = new ClipboardServices.ClipboardServiceClient();

			ClipboardServices.File file = new ClipboardServices.File();

			bool isError = false;

			try
			{
				client.Open();
				file = client.GetSearchReportClipboardFormated(search);
			}
			catch (Exception ex)
			{
				frm.Close();
				MessageBox.Show("Ocurrio un problema con el servidor.", "Reporte no copiado", MessageBoxButtons.OK, MessageBoxIcon.Error);
				isError = true;
			}
			finally
			{
				if (client.State != System.ServiceModel.CommunicationState.Closed)
				{
					client.Close();
				}
			}

			if (!isError)
			{
				try
				{
					DataObject obj = new DataObject();
					obj.SetData(DataFormats.Html, new System.IO.MemoryStream(
					   file.Buffer));
					Clipboard.SetDataObject(obj, true);
					frm.Close();
					if (MessageBox.Show("Se ha copiado el reporte a tu portapapeles.", "Reporte copiado", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
					{
						Form form = Application.OpenForms["frmSearch"];
						if (form != null)
						{
							CloseForm(form);
						}
					}
				}
				catch
				{
					frm.Close();
					MessageBox.Show("Ocurrio un problema al copiar el reporte al portapapeles.", "Reporte no copiado", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Form frm = Application.OpenForms["frmSearch"];
			if (frm != null)
			{
				CloseForm(frm);
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
	}
}