using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Mail;
using Microsoft.Office.Interop.Outlook;
using System.Net;


namespace ADMIN2.DAL
{
    public class ConfiguracionCorreo
    {
        //configuración de correo Outllok
        public void senmail(string destinatarios, string mensaje, string Asunto)
        {
            try 
            {
               // string[] cr = destinatarios.Split(";");
                Application oApp1 = new Application();
                MailItem item = (MailItem)oApp1.CreateItem(OlItemType.olMailItem);
                item.BCC += destinatarios;
                item.Subject = Asunto;
                item.Body = mensaje;
                //item.Display(true);
                item.Save();
                item.Send();
               
            }
            catch(System.Exception ex)
            {
                throw (ex);
            }
        }
        public void senmail2(string destinatarios, string mensaje, string Asunto,string archivo, string para)
        {
            try
            {
                // string[] cr = destinatarios.Split(";");
                Application oApp1 = new Application();
                MailItem ema = (MailItem)oApp1.CreateItem(OlItemType.olMailItem);
                //ema. = new MailAddress(para);
                ema.To = para;
                ema.Subject = Asunto;
                ema.Body = mensaje;

                ema.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
                System.Net.Mail.Attachment archin = new System.Net.Mail.Attachment(archivo);
                ema.Attachments.Add(archivo, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                ema.Save();
                //item.Display(true);
                ema.Send();

            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
        }
        //configuración de correo Gmail
        public void STMPmail(string destnatarios, string mensaje, string asunto,string mailusu, string contraa, int puerto, string host)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(mailusu);
                msg.To.Add(new MailAddress(destnatarios));
                msg.Subject = asunto;
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.Body = mensaje;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                SmtpClient clienesmtp = new SmtpClient();
                clienesmtp.Host = host;
                clienesmtp.Port = puerto;
                clienesmtp.EnableSsl = false;
                clienesmtp.UseDefaultCredentials = false;
                clienesmtp.Credentials = new NetworkCredential(mailusu, contraa);
                clienesmtp.EnableSsl = true;
                clienesmtp.Send(msg);
            }
            catch(System.Exception ex)
            {
                throw (ex);
            }
        }

        public void STMPmail2(string destnatarios, string mensaje, string asunto, string mailusu, string contraa, int puerto, string host,string Archivo)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(mailusu);
                msg.To.Add(new MailAddress(destnatarios));
                msg.Subject = asunto;
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.Body = mensaje;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.Priority = MailPriority.High;
                System.Net.Mail.Attachment archin = new System.Net.Mail.Attachment(Archivo, System.Net.Mime.MediaTypeNames.Application.Pdf);
                msg.Attachments.Add(archin);
                
                SmtpClient clienesmtp = new SmtpClient();
                clienesmtp.Host = host;
                clienesmtp.Port = puerto;
                //clienesmtp.EnableSsl = false;
                clienesmtp.UseDefaultCredentials = false;
                clienesmtp.Credentials = new NetworkCredential(mailusu, contraa);
                clienesmtp.EnableSsl = true;
                clienesmtp.Send(msg);
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
        }
    }
}
