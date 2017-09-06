using System;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Collections.Specialized;
using MyCTS.Entities;
using System.ComponentModel;
using MyCTS.Business;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Mailer
{
    /// <summary>
    /// Clase que se encarga de armar los correos al agente una vez que se haya realizado la reservacion
    /// </summary>
    public class InterJetMailer
    {

        /// <summary>
        /// Almacena una instancia de la definicion del correo.
        /// </summary>
        private MailDefinition _oMailDefinition;

        /// <summary>
        /// Gets the mailer.
        /// </summary>
        private MailDefinition Mailer
        {
            get
            {

                return _oMailDefinition ?? (_oMailDefinition = new MailDefinition
                                                                   {
                                                                       Priority = MailPriority.Normal,
                                                                       IsBodyHtml = true,

                                                                   });
            }
        }

        /// <summary>
        /// Almacena una referencia del cliente que se encarga de enviar los correos.
        /// </summary>
        private SmtpClient _oSmtpClient;

        /// <summary>
        /// Gets the SMTP client.
        /// </summary>
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


        /// <summary>
        /// Gets or sets the ticket.
        /// </summary>
        /// <value>
        /// The ticket.
        /// </value>
        public InterJetTicket Ticket { get; set; }


        /// <summary>
        /// Almacena una instanacion del generador de html para el correo de interjet.
        /// </summary>
        private InterJetMailContentGenerator _generator;

        /// <summary>
        /// Gets the HTML generator.
        /// </summary>
        private InterJetMailContentGenerator HtmlGenerator
        {
            get
            {
                return _generator ?? (_generator = new InterJetMailContentGenerator
                                                       {
                                                           Ticket = Ticket
                                                       });
            }
        }


        /// <summary>
        /// Envia el correo de confirmacion al agente una vez que se ha realizado la reservacion.
        /// </summary>
        public void SendConfirmationMail()
        {

            try
            {
                string subject = string.Format("Reservación de InterJet - {0} - Codigo de Confirmación: {1}", Ticket.Contact.FullName, Ticket.RecordLocator);
                SendMail(Login.Mail, HtmlGenerator.GetResplacement(), HtmlGenerator.GetHtmlContent(), subject);
                this.StartMailerWorker();
            }
            catch
            {
                int a = 2;
            }
        }



        private BackgroundWorker MailerWorker
        {
            get;
            set;
        }


        private void StartMailerWorker()
        {
            MailerWorker = new BackgroundWorker();
            MailerWorker.DoWork += new DoWorkEventHandler(MailerWorker_DoWork);
            MailerWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MailerWorker_RunWorkerCompleted);
            MailerWorker.RunWorkerAsync(this.Ticket);
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the MailerWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        void MailerWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                StopMailerWorker();
            }
            finally
            {

                MailerWorker.Dispose();
            }
        }

        /// <summary>
        /// Handles the DoWork event of the MailerWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        void MailerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            MyCTS.Entities.Parameter parameter = ParameterBL.GetParameterValue("InterJetConfirmationMails");

            if (parameter != null && !string.IsNullOrEmpty(parameter.Values))
            {
                string[] mails = parameter.Values.Split('|');
                if (mails.Length > 0)
                {
                    var htmlGenerator = new InterJetMailContentGenerator
                                                         {
                                                             Ticket = (InterJetTicket)e.Argument
                                                         };

                    foreach (string mail in mails)
                    {
                        if (!string.IsNullOrEmpty(mail))
                        {
                            string subject = string.Format(
                                "Reservación de InterJet - {0} - Codigo de Confirmación: {1}", Ticket.Contact.FullName,
                                Ticket.RecordLocator);
                            SendMail(mail, htmlGenerator.GetResplacement(), htmlGenerator.GetHtmlContent(), subject);
                        }

                    }


                }




            }



        }

        private void StopMailerWorker()
        {

            MailerWorker.DoWork -= new DoWorkEventHandler(MailerWorker_DoWork);
            MailerWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(MailerWorker_RunWorkerCompleted);
        }
        /// <summary>
        /// Sends the DIN confirmation.
        /// </summary>
        public void SendDINConfirmation()
        {
            try
            {
                //string subject = string.Format("Reserva Generada InterJet Codigo Reservacion {0}", DateTime.Now);
                //string body = string.Format("Agent: {0} \n Reserva InterJet :{1} \n PNRSABRE :{2} \n", Login.Mail,
                //                            Ticket.RecordLocator, Ticket.RecordSabre);

                //SendMail("ggranados@ctsmex.com.mx", new ListDictionary(), body, subject);
            }
            catch
            {


            }


        }

        /// <summary>
        /// Se encarga de mandar los correos electronicos dados los eventos de interjet.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="replacement">The replacement.</param>
        /// <param name="contentBody">The content body.</param>
        /// <param name="subject">The subject.</param>
        private void SendMail(string email, ListDictionary replacement, string contentBody, string subject)
        {
            MailMessage msg = Mailer.CreateMailMessage(email, replacement, contentBody,
                                                       new System.Web.UI.Control());
            msg.Subject = subject;
            SmtpClient.Send(msg);
        }

        private void SendMail(string email, ListDictionary replacement, string contentBody, string subject, string cc)
        {
            Mailer.CC = cc;
            MailMessage msg = Mailer.CreateMailMessage(email, replacement, contentBody,
                                                       new System.Web.UI.Control());
            msg.Subject = subject;
            SmtpClient.Send(msg);
        }

        /// <summary>
        /// Envia el correo error hacia el desarrollador cuando sucede un error.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public void SendErrorEmail(string errorMessage)
        {
            try
            {

                var dictionary = new ListDictionary();
                dictionary.Add("<%Agent%>", Login.Agent);
                dictionary.Add("<%Email%>", Login.Mail);
                dictionary.Add("<%Error%>", errorMessage);
                dictionary.Add("<%Record%>", string.IsNullOrEmpty(Ticket.RecordLocator) ? "No se genero" : Ticket.RecordLocator);

                string body = @"Agent : <%Agent%><br>
                                Email : <%Email%> <br>
                                Error : <%Error%><br>
                                Record : <%Record%><br>
                               ";
                string subject = string.Format("Error Ocurrido InterJet - {0}",
                                 DateTime.Now.ToString(CultureInfo.CurrentCulture));
                SendMail("jgutierrez@ctsmex.com.mx", dictionary, body, subject, "agutierrez@ctsmex.com.mx");

            }
            catch
            {

            }

        }






    }
}
