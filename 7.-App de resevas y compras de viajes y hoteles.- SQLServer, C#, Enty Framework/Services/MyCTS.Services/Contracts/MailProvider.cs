using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Services.Contracts
{
    public class MailProvider
    {
        public void SendEmail2(string from, string password, string display, string to,
            string cc, string subject, string body)
        {
            try
            {
                BuildElectronicTicket.MailProvider ws = new MyCTS.Services.BuildElectronicTicket.MailProvider();
                ws.SendEmail(from, password, display, to, cc, subject, body, string.Empty, false);
            }
            catch 
            {
                try
                {
                    BuildElectronicTicketDev.MailProvider ws = new MyCTS.Services.BuildElectronicTicketDev.MailProvider();
                    ws.SendEmail(from, password, display, to, cc, subject, body, string.Empty, false);

                }
                catch{ }
            }
        }
    }
}
