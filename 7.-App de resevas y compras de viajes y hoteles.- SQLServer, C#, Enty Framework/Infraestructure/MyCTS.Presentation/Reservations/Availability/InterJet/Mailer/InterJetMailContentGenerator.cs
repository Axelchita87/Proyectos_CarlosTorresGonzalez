using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using System.Collections.Specialized;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Mailer
{
    /// <summary>
    /// Clase que genera el contenido Html que es enviado en correo de confirmacion al agente.
    /// </summary>
    public class InterJetMailContentGenerator
    {


        /// <summary>
        /// Gets or sets the ticket.
        /// </summary>
        /// <value>
        /// The ticket.
        /// </value>
        public InterJetTicket Ticket { get; set; }


        /// <summary>
        /// Gets the content of the passanger.
        /// </summary>
        /// <returns>el contenido html de la informacion de pasajeros</returns>
        private string GetPassangerContent()
        {
            string topinfo = @"<p class='MsoNormal'>
            <b><span style='font-size: 12.0pt; font-family: Times New Roman,serif'>PASAJEROS</span></b>
            <span style='font-size: 12.0pt; font-family: Times New Roman ,serif'><o:p></o:p></span></p>";
            string content = "";
            if (Ticket != null)
            {

                int paxCounter = 1;
                foreach (var passanger in this.Ticket.Passangers.GetAll())
                {
                    string contentToAppend =
                        string.Format(
                            @"<p class='MsoListParagraph' style='margin-left: 18.0pt; text-indent: -18.0pt; mso-list: l0 level1 lfo2'>
                              <![if !supportLists]><span style='font-size: 12.0pt; font-family: 'Times New Roman','serif>
                              <span style='mso-list: Ignore'>{0}.
                               <span style='font: 7.0pt 'Times New Roman'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               </span></span></span><![endif]>
                              <span style='font-size: 12.0pt; font-family: 'Times New Roman','serif'>{1}<o:p></o:p></span></p>",
                                     paxCounter,
                                     passanger.FullName);
                    content = string.Concat(content, contentToAppend);
                    paxCounter += 1;
                }
            }
            return string.Concat(topinfo, content);
        }

        /// <summary>
        /// Gets the content of the flights.
        /// </summary>
        /// <returns>el contenido html de la informacion de pasajeros</returns>
        private string GetPricesContent()
        {
            string topInfo = @"<p class='MsoNormal'>
            <b><span style='font-size: 12.0pt; font-family: Times New Roman,serif'>DETALLE DE
                PRECIOS</span></b>
              <span style='font-size: 12.0pt; font-family: Times New Roman,serif'><o:p></o:p></span></p>";
            string content = "";
            if (Ticket != null)
            {
                decimal totalPayed = Ticket.Flights.GetAllFlights().Sum(f => f.TotalPayed);
                decimal totalBasePrice = Ticket.Flights.GetAllFlights().Sum(f => f.TotalBasePrice);
                decimal totalTaxes = Ticket.Flights.GetAllFlights().Sum(f => f.IvaTotal) +
                                     Ticket.Flights.GetAllFlights().Sum(f => f.TUATotal) +
                                     Ticket.Flights.GetAllFlights().Sum(f => f.TotalExtraTaxes);

                content = string.Format(@"<p class='MsoNormal'>
                    <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>Tarifa InterJet:&nbsp;
                        {0}<o:p></o:p></span></p>
                <p class='MsoNormal'>
                    <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>Impuestos:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        {1}<o:p></o:p></span></p>
                <p class='MsoNormal'>
                    <b><span style='font-size: 12.0pt; font-family: Times New Roman,serif'>Precio Total:&nbsp;
                        {2} MXN(Pesos Mexicanos)<o:p></o:p></span></b></p>
                <p class='MsoNormal'>
                    <b><span style='font-size: 12.0pt; font-family: Times New Roman,serif'>
                        <o:p>&nbsp;</o:p></span></b></p>",
                                                 totalBasePrice.ToString("c",new CultureInfo("es-MX")),
                                                 totalTaxes.ToString("c", new CultureInfo("es-MX")),
                                                 totalPayed.ToString("c", new CultureInfo("es-MX")));

            }
            return string.Concat(topInfo, content);
        }

        /// <summary>
        /// Gets the content of the prices.
        /// </summary>
        /// <returns>
        /// el contenido html de los precios
        /// </returns>
        private string GetFlightsContent()
        {
            string topInfo = @"<p class='MsoNormal' style='mso-margin-top-alt: auto; mso-margin-bottom-alt: auto'>
            <b>
             <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>SALIDA:<o:p></o:p></span>
            </b>
            </p>";
            string content = "";
            var cultureInfo = new CultureInfo("es-MX");
            if (Ticket != null)
            {

                foreach (var flight in Ticket.Flights.GetAllFlights())
                {
                    string contentToAppend = string.Format(@"  
                                                <p class='MsoNormal'>
                                                    <b><span style='font-size: 12.0pt; font-family: Times New Roman,serif'; color: black'>
                                                        Viaje de {0} - Clase {6}<o:p></o:p></span></b></p>
                                                <p class='MsoNormal'>
                                                    <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>{1}
                                                    <o:p></o:p></span></p>
                                                <p class='MsoNormal'>
                                                    <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>Saliendo de
                                                        {2} en {3} hrs.<o:p></o:p></span></p>
                                                <p class='MsoNormal'>
                                                    <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>Hacia 
                                                        {4} en {5} hrs.<o:p></o:p></span></p>
                                                <p class='MsoNormal'>
                                                    <span style='font-family: Times New Roman,serif; color: #1F497D'>
                                                      <o:p>&nbsp;</o:p></span></p>"
                                                    ,
                                                     flight.IntineraryString,
                                                     flight.DepartureTime.ToString("ddd, MMM dd, yyyy", cultureInfo),
                                                     flight.DepartureStation,
                                                     flight.DepartureTime.ToString("HH:mm"),
                                                     flight.ArrivalStation,
                                                     flight.ArrivalDateTime.ToString("HH:mm"),
                                                     flight.Information.ClassOfService
                                              );
                    content = string.Concat(content, contentToAppend);
                }

            }
            return string.Concat(topInfo, content);
        }

        /// <summary>
        /// Gets the content of the HTML.
        /// </summary>
        /// <returns>El contenido html del correo de interjet</returns>
        public string GetHtmlContent()
        {
            #region Header del documento html
            string html = @"<html xmlns:v='urn:schemas-microsoft-com:vml' xmlns:o='urn:schemas-microsoft-com:office:office'
                                xmlns:w='urn:schemas-microsoft-com:office:word' xmlns:m='http://schemas.microsoft.com/office/2004/12/omml'
                                xmlns='http://www.w3.org/TR/REC-html40'>
                                <head>
                                    <meta name='Generator' content='Microsoft Word 12 (filtered medium)'>
                                    <!--[if !mso]><style>v\:* {behavior:url(#default#VML);}
                                o\:* {behavior:url(#default#VML);}
                                w\:* {behavior:url(#default#VML);}
                                .shape {behavior:url(#default#VML);}
                                </style><![endif]-->
                                    <style>
                                        <!
                                        -- /* Font Definitions */ @
                                        font-face
                                        {
                                            font-family: 'Cambria Math';
                                            panose-1: 2 4 5 3 5 4 6 3 2 4;
                                        }
                                        @font-face
                                        {
                                            font-family: Calibri;
                                            panose-1: 2 15 5 2 2 2 4 3 2 4;
                                        }
                                        @font-face
                                        {
                                            font-family: Tahoma;
                                            panose-1: 2 11 6 4 3 5 4 4 2 4;
                                        }
                                        /* Style Definitions */
                                        p.MsoNormal, li.MsoNormal, div.MsoNormal
                                        {
                                            margin: 0cm;
                                            margin-bottom: .0001pt;
                                            font-size: 11.0pt;
                                            font-family: 'Calibri' , 'sans-serif';
                                        }
                                        a:link, span.MsoHyperlink
                                        {
                                            mso-style-priority: 99;
                                            color: blue;
                                            text-decoration: underline;
                                        }
                                        a:visited, span.MsoHyperlinkFollowed
                                        {
                                            mso-style-priority: 99;
                                            color: purple;
                                            text-decoration: underline;
                                        }
                                        p.MsoAcetate, li.MsoAcetate, div.MsoAcetate
                                        {
                                            mso-style-priority: 99;
                                            mso-style-link: 'Texto de globo Car';
                                            margin: 0cm;
                                            margin-bottom: .0001pt;
                                            font-size: 8.0pt;
                                            font-family: 'Tahoma' , 'sans-serif';
                                        }
                                        p.MsoListParagraph, li.MsoListParagraph, div.MsoListParagraph
                                        {
                                            mso-style-priority: 34;
                                            margin-top: 0cm;
                                            margin-right: 0cm;
                                            margin-bottom: 0cm;
                                            margin-left: 36.0pt;
                                            margin-bottom: .0001pt;
                                            font-size: 11.0pt;
                                            font-family: 'Calibri' , 'sans-serif';
                                        }
                                        span.TextodegloboCar
                                        {
                                            mso-style-name: 'Texto de globo Car';
                                            mso-style-priority: 99;
                                            mso-style-link: 'Texto de globo';
                                            font-family: 'Tahoma' , 'sans-serif';
                                        }
                                        span.EstiloCorreo20
                                        {
                                            mso-style-type: personal;
                                            font-family: 'Calibri' , 'sans-serif';
                                            color: windowtext;
                                        }
                                        span.EstiloCorreo21
                                        {
                                            mso-style-type: personal;
                                            font-family: 'Calibri' , 'sans-serif';
                                            color: #1F497D;
                                        }
                                        span.EstiloCorreo22
                                        {
                                            mso-style-type: personal;
                                            font-family: 'Calibri' , 'sans-serif';
                                            color: #1F497D;
                                        }
                                        span.EstiloCorreo24
                                        {
                                            mso-style-type: personal-reply;
                                            font-family: 'Calibri' , 'sans-serif';
                                            color: #1F497D;
                                        }
                                        .MsoChpDefault
                                        {
                                            mso-style-type: export-only;
                                            font-size: 10.0pt;
                                        }
                                        @page WordSection1
                                        {
                                            size: 612.0pt 792.0pt;
                                            margin: 72.0pt 72.0pt 72.0pt 72.0pt;
                                        }
                                        div.WordSection1
                                        {
                                            page: WordSection1;
                                        }
                                        /* List Definitions */
                                        @list@listl0{mso-list-id:298269292;mso-list-type:hybrid;mso-list-template-ids:-471421714134873103134873113134873115134873103134873113134873115134873103134873113134873115;}
                                        @listl0:level1{mso-level-tab-stop:none;mso-level-number-position:left;margin-left:18.0pt;text-indent:-18.0pt;}
                                        @listl0:level2{mso-level-number-format:alpha-lower;mso-level-tab-stop:none;mso-level-number-position:left;margin-left:54.0pt;text-indent:-18.0pt;}
                                        @listl0:level3{mso-level-number-format:roman-lower;mso-level-tab-stop:none;mso-level-number-position:right;margin-left:90.0pt;text-indent:-9.0pt;}
                                        @listl0:level4{mso-level-tab-stop:none;mso-level-number-position:left;margin-left:126.0pt;text-indent:-18.0pt;}
                                        @listl0:level5{mso-level-number-format:alpha-lower;mso-level-tab-stop:none;mso-level-number-position:left;margin-left:162.0pt;text-indent:-18.0pt;}
                                        @listl0:level6{mso-level-number-format:roman-lower;mso-level-tab-stop:none;mso-level-number-position:right;margin-left:198.0pt;text-indent:-9.0pt;}
                                        @listl0:level7{mso-level-tab-stop:none;mso-level-number-position:left;margin-left:234.0pt;text-indent:-18.0pt;}
                                        @listl0:level8{mso-level-number-format:alpha-lower;mso-level-tab-stop:none;mso-level-number-position:left;margin-left:270.0pt;text-indent:-18.0pt;}
                                        @listl0:level9{mso-level-number-format:roman-lower;mso-level-tab-stop:none;mso-level-number-position:right;margin-left:306.0pt;text-indent:-9.0pt;}
                                        ol
                                        {
                                            margin-bottom: 0cm;
                                        }
                                        ul
                                        {
                                            margin-bottom: 0cm;
                                        }
                                        -- ></style>
                                    <!--[if gte mso 9]><xml>
                                <o:shapedefaults v:ext='edit' spidmax='1026' />
                                </xml><![endif]-->
                                    <!--[if gte mso 9]><xml>
                                <o:shapelayout v:ext='edit'>
                                <o:idmap v:ext='edit' data='1' />
                                </o:shapelayout></xml><![endif]-->
                                </head> 
                                <body lang='ES-MX' link='blue' vlink='purple'>
                                <div class='WordSection1'>


        <p class='MsoNormal'>
            <img width='370' height='123' id='Imagen_x0020_1' 
                src='http://201.149.13.14:5498/WSInterjet/CTS2012.png'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;
            <img width='300' height='128' id='Imagen_x0020_2'
                src='http://201.149.13.14:5498/WSInterjet/LogoInterJet.jpg'><o:p></o:p></p>

                                <p class='MsoNormal'>
                                    <span style='color: #1F497D'>
                                 <o:p>&nbsp;</o:p></span></p> ";
            #endregion
            html = string.Concat(html, "<%Content%>");
            html = string.Concat(html, "</div></body></html>");
            return html;
        }

        /// <summary>
        /// 
        /// </summary>
        private ListDictionary _replacement;

        /// <summary>
        /// Gets the replacement.
        /// </summary>
        private ListDictionary Replacement
        {
            get { return _replacement ?? (_replacement = new ListDictionary()); }
        }

        /// <summary>
        /// Gets the flight information.
        /// </summary>
        /// <returns></returns>
        private string GetFlightInformation()
        {

            var cultureInfo = new CultureInfo("es-MX");
            #region Contenido de la informacion del vuelo
            string flightInformation = string.Format(@"
            <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>Fecha de Compra:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               {0}<o:p></o:p></span></p>
        <p class='MsoNormal'>
            <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>Estatus:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Confirmado<o:p></o:p></span></p>
        <p class='MsoNormal'>
            <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>Clave de InterJet:&nbsp;&nbsp;
                {1}<o:p></o:p></span></p>
        <p class='MsoNormal'>
            <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>Clave de Sabre:&nbsp;&nbsp;&nbsp;&nbsp;
                {2}<o:p></o:p></span></p>
        <p class='MsoNormal' style='mso-margin-top-alt: auto; mso-margin-bottom-alt: auto;
            text-align: justify; mso-line-height-alt: 10.5pt'>
            <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>La clave de
                confirmación es la referencia para obtener tu pase de abordar o para documentarte
                directamente en el aeropuerto antes de la salida de tu vuelo. No olvides que en
                cualquier momento te puede ser requerida una identificación oficial.<o:p></o:p></span></p>
        <p class='MsoNormal'>
            <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>Para más información
                comunícate al 11 02 55 55 en el DF o al 01 800 01 12345 del interior de la república.<o:p></o:p></span></p>
         <p class='MsoNormal'>
            <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>
                &nbsp;
                <o:p></o:p></span></p>
               ", DateTime.Now.ToString("ddd, MMM dd, yyyy", cultureInfo),
                    Ticket.RecordLocator,
                    Ticket.RecordSabre);
            #endregion
            return flightInformation;

        }


        /// <summary>
        /// Gets the content of the contact information.
        /// </summary>
        /// <returns></returns>
        public string GetContactInformationContent()
        {
            #region contenido html de la informacion del contacto
            string content = string.Format(@"
           <p class='MsoNormal'>
            <b><span style='font-size: 12.0pt; font-family: Times New Roman,serif'>INFORMACION
                DE CONTACTO<o:p></o:p></span></b></p>
        <p class='MsoNormal'>
            <b><span style='font-size: 12.0pt; font-family:Times New Roman,serif'>Dirección
                domicilio:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <span style='color: #1F497D'><o:p></o:p></span></span></b></p>
        <p class='MsoNormal'>
            <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>
              {0}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<o:p></o:p></span></p>
        <p class='MsoNormal'>
            <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>
         {1} {2}&nbsp;<span style='color: #1F497D'><o:p></o:p></span></span></p>
        <p class='MsoNormal'>
            <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>
          {3}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <span style='color: #1F497D'>
                    <o:p>
                    </o:p></span></span></p>
        <p class='MsoNormal'>
            <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>
                {4}, &nbsp; {5} &nbsp; {12}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <o:p>
                </o:p></span></p>
        <p class='MsoNormal'>
            <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>
               {6}&nbsp;&nbsp;<span
                style='color: #1F497D'><o:p></o:p></span></span></p>
        <p class='MsoNormal'>
            <span style='color: #1F497D'>
                <o:p>&nbsp;</o:p></span></p>
        <p class='MsoNormal'>
            <b><span style='font-size: 12.0pt; font-family: Times New Roman,serif'>Número(s)
                telefónico(s)<o:p></o:p></span></b></p>
        <p class='MsoNormal'>
            <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>Primario:&nbsp;&nbsp;{7}<o:p></o:p></span></p>
        <p class='MsoNormal'>
            <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>Alterno:<span
                style='color: #1F497D'> </span>{8}<o:p></o:p></span></p>
        <p class='MsoNormal'>
            <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>Celular:&nbsp;&nbsp;{9}<o:p></o:p></span></p>
        <p class='MsoNormal'>
            <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>Fax:&nbsp;&nbsp;&nbsp;&nbsp;{10}&nbsp;
                <o:p>
                </o:p></span></p>
        <p class='MsoNormal'>
            <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>Email:&nbsp;&nbsp;
                <a href='mailto:{11}'>{11}</a><o:p></o:p></span></p>
        <p class='MsoNormal'>
            <span style='font-size: 12.0pt; font-family: Times New Roman,serif'>
                <o:p>&nbsp;</o:p></span></p> ",
                                              Ticket.Contact.FullName,
                                              Ticket.Contact.Address1,
                                              Ticket.Contact.Address2,
                                              Ticket.Contact.Address3,
                                              Ticket.Contact.City,
                                              Ticket.Contact.State,
                                              Ticket.Contact.Country,
                                              Ticket.Contact.PrimaryTelephone,
                                              Ticket.Contact.AlternTelephone,
                                              Ticket.Contact.CellPhone,
                                              Ticket.Contact.Fax,
                                              Ticket.Contact.Email,
                                              Ticket.Contact.PostalCode
                            );
            #endregion
            return content;
        }

        /// <summary>
        /// Gets the content of the footer.
        /// </summary>
        /// <returns></returns>
        public string GetFooterContent()
        {
            #region Contendio del footer
            string content = @" <table class='MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='border-collapse: collapse'>
            <tr>
                <td colspan='10' style='padding: .75pt .75pt .75pt .75pt'>
                    <p class='MsoNormal'>
                        <b><i><span style='font-size: 15.0pt; font-family: Times New Roman,serif'>Es importante
                            tome en cuenta NO CONTESTAR A ESTE CORREO ya que es una cuenta de administración
                            y no recibirá respuesta alguna.</span></i></b><b><span style='font-size: 12.0pt;
                                font-family: Times New Roman,serif'><o:p></o:p></span></b></p>
                </td>
            </tr>
            <tr>
                <td colspan='10' style='padding: .75pt .75pt .75pt .75pt'>
                </td>
            </tr>
            <tr>
                <td style='padding: .75pt .75pt .75pt .75pt'>
                    <p class='MsoNormal'>
                        <span style='font-family: 'Calibri','sans-serif'> &nbsp; </span><span
                            style='font-size: 12.0pt; font-family:'Times New Roman','serif'><o:p></o:p></span></p>

                    <p class='MsoNormal'>
                        <strong><span style='font-family: 'Calibri','sans-serif'>Corporate Travel Services</span></strong><span
                            style='font-size: 12.0pt; font-family:'Times New Roman','serif'><o:p></o:p></span></p>
                </td>
                <td style='padding: .75pt .75pt .75pt .75pt'>
                </td>
                <td style='padding: .75pt .75pt .75pt .75pt'>
                </td>
                <td style='padding: .75pt .75pt .75pt .75pt'>
                </td>
                <td style='padding: .75pt .75pt .75pt .75pt'>
                </td>
                <td style='padding: .75pt .75pt .75pt .75pt'>
                </td>
                <td style='padding: .75pt .75pt .75pt .75pt'>
                </td>
                <td style='padding: .75pt .75pt .75pt .75pt'>
                </td>
                <td style='padding: .75pt .75pt .75pt .75pt'>
                </td>
                <td style='padding: .75pt .75pt .75pt .75pt'>
                </td>
            </tr>
            <tr style='height: 15.75pt'>
                <td colspan='10' style='padding: .75pt .75pt .75pt .75pt; height: 15.75pt'>
                    <p class='MsoNormal'>
                        <span style='font-size: 10.0pt; font-family: 'Tahoma','sans-serif'>Tel: +55 85252222</span><span
                            style='font-size: 12.0pt; font-family: 'Times New Roman','serif''><o:p></o:p></span></p>
                </td>
            </tr>
            <tr>
                <td colspan='10' style='padding: .75pt .75pt .75pt .75pt'>
                    <p class='MsoNormal'>
                        <span style='font-size: 10.0pt; font-family: 'Tahoma','sans-serif'>Fax: +55 85252233</span><span
                            style='font-size: 12.0pt; font-family: 'Times New Roman','serif'><o:p></o:p></span></p>
                </td>
            </tr>
        </table>";
            #endregion
            return content;
        }

        /// <summary>
        /// Gets the resplacement.
        /// </summary>
        /// <returns></returns>
        public ListDictionary GetResplacement()
        {
            var dictionary = new ListDictionary();
            string content = GetFlightInformation() + GetPassangerContent() + GetFlightsContent() + GetPricesContent() +
                             GetContactInformationContent() + GetFooterContent();
            dictionary.Add("<%Content%>", content);
            return dictionary;

        }

    }
}
