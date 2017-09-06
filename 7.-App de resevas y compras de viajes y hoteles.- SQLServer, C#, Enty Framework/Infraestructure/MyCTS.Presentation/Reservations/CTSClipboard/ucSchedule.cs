using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCTS.Services.Contracts;
using MyCTS.Presentation.Components;
using MyCTS.Business;
#if (VOLARIS_PRODUCTION)
using ClipboardServices = MyCTS.Services.ClipboardService;
#else
using ClipboardServices = MyCTS.Services.ClipboardService;
#endif

namespace MyCTS.Presentation
{
	public partial class ucSchedule : CustomUserControl
	{
		public ucSchedule()
		{
			InsertLogClipboardCTSBL.InsertLogClipboardCTS(DateTime.Now, Login.Agent, 1, null);
			InitializeComponent();
			wbContent.DocumentCompleted += wbContent_DocumentCompleted;
		}

		void wbContent_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			HtmlElement btnAcept = wbContent.Document.GetElementById("btnAcept");
			btnAcept.AttachEventHandler("onclick", btnAcept_Click);
		}

		private void btnAcept_Click(object sender, EventArgs e)
		{
			HtmlElement txtDepartureDate = wbContent.Document.GetElementById("txtDepartureDate");
			HtmlElement txtDeparture = wbContent.Document.GetElementById("txtDeparture");
			HtmlElement txtArrival = wbContent.Document.GetElementById("txtArrival");
			HtmlElement ckbSabre = wbContent.Document.GetElementById("ckbSabre");
			HtmlElement ckbInterjet = wbContent.Document.GetElementById("ckbInterjet");
			HtmlElement ckbVolaris = wbContent.Document.GetElementById("ckbVolaris");
			HtmlElement txtStartHour = wbContent.Document.GetElementById("txtStartHour");
			HtmlElement txtFinalHour = wbContent.Document.GetElementById("txtFinalHour");
			HtmlElement ckbIndFlights = wbContent.Document.GetElementById("ckbIndFlights");
			HtmlElement ckbSharedCodes = wbContent.Document.GetElementById("ckbSharedCodes");
			HtmlElement ckbShowWeekly = wbContent.Document.GetElementById("ckbShowWeekly");
			HtmlElement ckbIncludeAircraft = wbContent.Document.GetElementById("ckbIncludeAircraft");
			HtmlElement txtAirlineInclude1 = wbContent.Document.GetElementById("txtAirlineInclude1");
			HtmlElement txtAirlineInclude2 = wbContent.Document.GetElementById("txtAirlineInclude2");
			HtmlElement txtAirlineInclude3 = wbContent.Document.GetElementById("txtAirlineInclude3");
			HtmlElement txtAirlineExclude1 = wbContent.Document.GetElementById("txtAirlineExclude1");
			HtmlElement txtAirlineExclude2 = wbContent.Document.GetElementById("txtAirlineExclude2");
			HtmlElement txtAirlineExclude3 = wbContent.Document.GetElementById("txtAirlineExclude3");
			List<string> airlines = new List<string>();

			if (!string.IsNullOrEmpty(txtDepartureDate.GetAttribute("Value")) && !string.IsNullOrEmpty(txtArrival.GetAttribute("Value")) && !string.IsNullOrEmpty(txtDeparture.GetAttribute("Value")))
			{
				if (bool.Parse(ckbSabre.GetAttribute("Checked")))
				{
					airlines.Add("HC");
				}
				if (bool.Parse(ckbVolaris.GetAttribute("Checked")))
				{
					airlines.Add("Y4");
				}
				if (bool.Parse(ckbInterjet.GetAttribute("Checked")))
				{
					airlines.Add("4O");
				}


				bool isExcludeFlights = false;

				if (string.IsNullOrEmpty(txtAirlineInclude1.GetAttribute("Value")) && string.IsNullOrEmpty(txtAirlineInclude2.GetAttribute("Value")) && string.IsNullOrEmpty(txtAirlineInclude3.GetAttribute("Value")))
				{
					airlines.Add(txtAirlineExclude1.GetAttribute("Value").ToUpper());
					airlines.Add(txtAirlineExclude2.GetAttribute("Value").ToUpper());
					airlines.Add(txtAirlineExclude3.GetAttribute("Value").ToUpper());
					isExcludeFlights = true;
				}
				else
				{
					airlines.Add(txtAirlineInclude1.GetAttribute("Value").ToUpper());
					airlines.Add(txtAirlineInclude2.GetAttribute("Value").ToUpper());
					airlines.Add(txtAirlineInclude3.GetAttribute("Value").ToUpper());
				}
				ClipboardService service = new ClipboardService();
				string startHour = string.Empty;
				if (!string.IsNullOrEmpty(txtStartHour.GetAttribute("Value")))
				{
					switch (txtStartHour.GetAttribute("Value").Length)
					{
						case 1:
							startHour = string.Concat("00:0", txtStartHour.GetAttribute("Value"));
							break;
						case 2:
							startHour = string.Concat("00:", txtStartHour.GetAttribute("Value"));
							break;
						case 3:
							startHour = string.Concat("0", txtStartHour.GetAttribute("Value")[0], ":", txtStartHour.GetAttribute("Value").Substring(1, 2));
							break;
						case 4:
							startHour = string.Concat(txtStartHour.GetAttribute("Value").Substring(0, 2), ":", txtStartHour.GetAttribute("Value").Substring(2, 2));
							break;
					}
				}
				string finalHour = string.Empty;
				if (!string.IsNullOrEmpty(txtFinalHour.GetAttribute("Value")))
				{
					switch (txtFinalHour.GetAttribute("Value").Length)
					{
						case 1:
							finalHour = string.Concat("00:0", txtFinalHour.GetAttribute("Value"));
							break;
						case 2:
							finalHour = string.Concat("00:", txtFinalHour.GetAttribute("Value"));
							break;
						case 3:
							finalHour = string.Concat("0", txtFinalHour.GetAttribute("Value")[0], ":", txtFinalHour.GetAttribute("Value").Substring(1, 2));
							break;
						case 4:
							finalHour = string.Concat(txtFinalHour.GetAttribute("Value").Substring(0, 2), ":", txtFinalHour.GetAttribute("Value").Substring(2, 2));
							break;
					}
				}

				DateTime departureDate = new DateTime();

				if (txtDepartureDate.GetAttribute("Value").ToUpper().Equals("29FEB"))
				{
					if (DateTime.Today <= new DateTime(DateTime.Today.Year, 2, 28))
					{
						departureDate = DateTime.ParseExact(txtDepartureDate.GetAttribute("Value"), "ddMMM", new System.Globalization.CultureInfo("en-US"));
					}
					else
					{
						departureDate = DateTime.ParseExact(string.Concat(txtDepartureDate.GetAttribute("Value"), DateTime.Today.AddYears(1).Year.ToString("0000")), "ddMMMyyyy", new System.Globalization.CultureInfo("en-US"));
					}
				}
				else
				{
					departureDate = DateTime.ParseExact(txtDepartureDate.GetAttribute("Value"), "ddMMM", new System.Globalization.CultureInfo("en-US"));
				}

				ClipboardServices.Schedule schedule = service.CopyReport(txtDeparture.GetAttribute("Value").ToUpper(), txtArrival.GetAttribute("Value").ToUpper(), departureDate < DateTime.Today ? departureDate.AddYears(1) : departureDate, bool.Parse(ckbIndFlights.GetAttribute("Checked")), bool.Parse(ckbSharedCodes.GetAttribute("Checked")), bool.Parse(ckbShowWeekly.GetAttribute("Checked")), bool.Parse(ckbIncludeAircraft.GetAttribute("Checked")), isExcludeFlights, startHour, finalHour, airlines);
				if (schedule.Trips.Count == 0)
				{
					MessageBox.Show("No se encontrarón resultados con los datos proporcionados.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					ClipboardServices.File file = service.CopyReport(schedule);

					try
					{
						DataObject obj = new DataObject();
						obj.SetData(DataFormats.Html, new System.IO.MemoryStream(
						   file.Buffer));
						Clipboard.SetDataObject(obj, true);
						if (MessageBox.Show("Se ha copiado el reporte a tu portapapeles.", "Reporte copiado", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
						{
							Form frm = Application.OpenForms["frmSchedule"];
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
			}
			else
			{

				if (string.IsNullOrEmpty(txtDepartureDate.GetAttribute("Value")))
				{
					MessageBox.Show("Es necesario que introduzca la fecha.", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else if (string.IsNullOrEmpty(txtArrival.GetAttribute("Value")))
				{
					MessageBox.Show("Es necesario que introduzca el destino.", "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else if (string.IsNullOrEmpty(txtDeparture.GetAttribute("Value")))
				{
					MessageBox.Show("Es necesario que introduzca el origen.", "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
	}
}
