using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web.UI.WebControls;
using MyCTS.Entities;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.Mailer
{
    public class VolarisMailer
    {

        public VolarisReservation Reservation { get; set; }
        private SmtpClient _oSmtpClient;

        private SmtpClient SmtpClient
        {

            get
            {
                return _oSmtpClient ?? (_oSmtpClient = new SmtpClient
                                                           {
                                                               Host = "mail.ctsmex.com.mx",
                                                               Port = 25,
                                                           });
            }
        }

        private readonly MailDefinition _mailDefinition;

        public VolarisMailer()
        {
            _mailDefinition = new MailDefinition();

            _mailDefinition.BodyFileName = Properties.Resources.VolarisMail;
            _mailDefinition.IsBodyHtml = true;
        }


        public void SendTest()
        {
            var replacements = new ListDictionary();
            replacements.Add("<%BuyDate%>", DateTime.Now.ToString(" dddd dd MMMM yyyy ", new CultureInfo("es-MX")));
            replacements.Add("<%Status%>", VolarisSession.ReservationStatus.ToString());
            replacements.Add("<%VolarisPNR%>", VolarisSession.PNR);
            replacements.Add("<%SabrePNR%>", VolarisSession.PNRSabre);
            replacements.Add("<%PassangersMarkUp%>", GetPassangersMarkup());
            replacements.Add("<%FlightMarkup%>", GetFlightsMarkup());
            replacements.Add("<%TOTALBASEPRICE%>",
                             VolarisSession.BasePriceTotal.ToString("c", new CultureInfo("es-MX")));
            replacements.Add("<%TOTALTAXES%>", VolarisSession.TaxesTotal.ToString("c", new CultureInfo("es-MX")));
            replacements.Add("<%TOTALPRICE%>", VolarisSession.PagoTotal.ToString("c", new CultureInfo("es-MX")));

            var tel = "85252222";
            if (tel != null)
            {
                replacements.Add("<%TELEPHONE%>", "85252222");
            }
            var mail = Login.Mail;
            if (mail != null)
            {
                replacements.Add("<%EMAIL%>", mail);
            }

            MailMessage msg2 = _mailDefinition.CreateMailMessage(Login.Mail, replacements,
                                                                _mailDefinition.BodyFileName,
                                                                new System.Web.UI.Control());

            var subject = string.Format("Reservación de Volaris -{0}- Codigo de Confirmación : {1}",
                                         Login.NombreCompleto,
                                         VolarisSession.PNR);
            //msg1.Subject = subject;
            msg2.Subject = subject;
            //SmtpClient.Send(msg1);
            SmtpClient.Send(msg2);

        }


        private string GetPassangersMarkup()
        {
            string markup = string.Empty;
            foreach (var pax in VolarisSession.InterJetPassangers)
            {

                markup += string.Format(PassangerMarkupTemplate, pax.ID, pax.FullName);
            }
            return markup;
        }

        private string GetFlightsMarkup()
        {
            string markUp = string.Empty;
            var departure = VolarisSession.ItinerarioVolaris;
            markUp += GetFlightMarkup(departure);
            return markUp;
        }

        private string GetFlightMarkup(List<ItineraryFlowVolaris> flight)
        {
            string markUp = string.Empty;
            string typeFly=string.Empty;
            for (int i = 0; i < flight.Count; i++)
            {
                if(flight[i].TipoVuelo.ToString()=="OnlyTrip")
                {
                    typeFly="Salida";
                }
                else
                {
                    typeFly="Regreso";
                }

                markUp += string.Format(FlightMarkup, typeFly, flight[i].Origen, flight[i].Destino);
                markUp += string.Format(SegmentMarkup,
                                            flight[i].FechaInicio.ToString("dddd dd MMMM yyy", new CultureInfo("es-MX")).ToUpper(),
                                             flight[i].Origen,
                                             flight[i].FechaInicio.ToString("HH:mm"),
                                             flight[i].Destino,
                                             flight[i].FechaLlegada.ToString("HH:mm")
                                            );
            }
            return markUp;
        }



        private const string PassangerMarkupTemplate = @"<p class='MsoListParagraph' style=
    'margin-left: 18.0pt; text-indent: -18.0pt; mso-list: l0 level1 lfo2'>
    <![if !supportLists]> <span style='font-size: 12.0pt; font-family:' times="" new=
    ""><span style='mso-list: Ignore'>{0} <span style='font: 7.0pt' times="" new=
    "">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span> <![endif]> <span style=
    'font-size: 12.0pt; font-family:' times="" new="">{1}</span></p>";


        private const string FlightMarkup =
            @"    <p class='MsoNormal' style='mso-margin-top-alt: auto; mso-margin-bottom-alt: auto'>
    <b><span style=
    'font-size: 12.0pt; font-family: Times New Roman,serif'>{0}:</span></b></p>

    <p class='MsoNormal'><b><span>Viaje de {1} - {2}
      </span></b></p>";
        private const string SegmentMarkup = @"   <p class='MsoNormal'><span>{0}</span></p>
    <p class='MsoNormal'><span style=
    'font-size: 12.0pt; font-family: Times New Roman,serif'>Saliendo de {1} en {2}
    hrs.</span></p>
    <p class='MsoNormal'><span style=
    'font-size: 12.0pt; font-family: Times New Roman,serif'>Hacia {3} en {4}
    hrs.</span></p>
    <p class='MsoNormal'><span style=
    'font-family: Times New Roman,serif; color: #1F497D'>&nbsp;</span></p>

       ";

    }
}
