using System;
using System.Configuration;
using System.Diagnostics;
using System.Net.Mail;

namespace MyCTS.EventsManager
{
    public class EventsManager
    {
        public enum OrigenError
        {
            BaseDeDatos,
            CapaDePresentacion,
            CapaDeNegocios,
            CapaDeServicios,
            CapaDeComponentes
        }

        public EventsManager(Exception ex, EventLogEntryType tipoEvento, OrigenError origenError)
        {
            WriteWindowsLog(ex, tipoEvento, origenError);
        }

        public EventsManager(Exception ex, OrigenError origenError)
        {
            WriteWindowsLog(ex, origenError);
        }

        public EventsManager(EventLogEntryType tipoEvento, Exception ex)
        {
            GuardaLogErrores(tipoEvento,ex);
        }

        /// <summary>
        /// Escribe en el log de eventos cualquier falla y solicita el tipo de evento.
        /// </summary>
        /// <param name="ex">La exception</param>
        /// <param name="tipoEvento">El tipo de event</param>
        /// <param name="origenError">El Origen del evento</param>
        private void WriteWindowsLog(Exception ex, EventLogEntryType tipoEvento, OrigenError origenError)
        {
            GuardaLogErrores(tipoEvento, ex);
            if (OrigenError.BaseDeDatos == origenError)
            {
                ConfigurationManager.AppSettings.Set("MirrorOn", "On");
            }
        }

        /// <summary>
        /// Escribe en el log de eventos cualquier falla y la documenta como error.
        /// </summary>
        /// <param name="ex">La ex.</param>
        /// <param name="origenError">El origen del error</param>
        private void WriteWindowsLog(Exception ex, OrigenError origenError)
        {
            GuardaLogErrores(EventLogEntryType.Error, ex);
            SendEmail("adminmycts@ctsmex.com.mx", "mirera01", "MyCTS", ConfigurationManager.AppSettings["CorreoLog"], string.Empty,"Error de Aplicación", ConfigurationManager.AppSettings["DatosContacto"].Split('|')[0] + ":" + ConfigurationManager.AppSettings["DatosContacto"].Split('|')[1] + "\n" + ex, "", true);
            if (OrigenError.BaseDeDatos == origenError)
            {
                ConfigurationManager.AppSettings.Set("MirrorOn", "On");
            }
        }

        /// <summary>
        /// Guarda el log de errores.
        /// </summary>
        /// <param name="tipoEvento">The event</param>
        /// <param name="ex">The exception</param>
        private void GuardaLogErrores(EventLogEntryType tipoEvento, Exception ex)
        {
            string sNombre = "MyCTS";
            string sNombreSource = "Application";

            try
            {
                if (!(EventLog.SourceExists(sNombre, ".")))
                {
                    EventSourceCreationData evscd = new EventSourceCreationData(sNombre, sNombre);
                    EventLog.CreateEventSource(evscd);
                }
                EventLog ev = new EventLog(sNombre, ".", sNombre);
                ev.WriteEntry(ex.ToString(), tipoEvento, 10001);
                ev.Close();
            }
            catch (Exception)
            {
                try
                {
                    EventLog ev = new EventLog(sNombreSource, ".", sNombreSource);
                    ev.WriteEntry(ex.ToString(), tipoEvento, 10001, 6);
                    ev.Close();
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// Envía correo de notificación de cancelación
        /// </summary>
        private void SendEmail(string from, string password, string displayName, string to, string cc, string subject, string body, string document, bool isHTMLFormat)
        {
            MailMessage mail = new MailMessage();
            string[] toList = to.Split(new[] { ';' },StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < toList.Length; j++)
            {
                mail.To.Add(toList[j].Trim());
            }
            mail.From = new MailAddress(from, displayName);
            if (!string.IsNullOrEmpty(cc))
            {
                new MailAddressCollection();
                string[] ccList = cc.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < ccList.Length; i++)
                {
                    mail.CC.Add(ccList[i].Trim());
                }
            }
            if (!string.IsNullOrEmpty(document))
            {
                string[] documentList = document.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                Attachment documentToAdd = null;
                foreach (string doc in documentList)
                {
                    try
                    {
                        documentToAdd = new Attachment(doc);
                        mail.Attachments.Add(documentToAdd);
                    }
                    catch { }
                }
            }
            mail.Subject = subject;
            if (isHTMLFormat)
                mail.IsBodyHtml = true;
            mail.Body = body;
            try
            {
                SmtpClient smptMail = new SmtpClient("200.52.83.165");
                smptMail.Port = 25;
                int aux = @from.LastIndexOf("@", StringComparison.Ordinal);
                string userName = from.Substring(0, aux);
                smptMail.Credentials = new System.Net.NetworkCredential(userName, password);
                smptMail.Send(mail);
            }
            catch (Exception)
            {
            }
            finally
            {
                mail.Attachments.Dispose();
                mail.Dispose();
            }
        }
    }
}
