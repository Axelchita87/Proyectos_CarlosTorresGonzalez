using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Services.Contracts
{
    public class BuildElectronicTicketContract
    {
        public void SendInfoToBuilPDF(
            string[] ticketNumber, string[] urlVirtuallyThere, string airline,
            string from, string password, string to, string displayName)
        {
            try
            {
                BuildElectronicTicket.MailProvider obj = new BuildElectronicTicket.MailProvider();
                obj.BuildPDFDocuments(ticketNumber, urlVirtuallyThere,
                    airline, from, password, to, displayName);

            }
            catch 
            {
                try
                {
                    BuildElectronicTicketDev.MailProvider obj = new BuildElectronicTicketDev.MailProvider();
                    obj.BuildPDFDocuments(ticketNumber, urlVirtuallyThere,
                        airline, from, password, to, displayName);

                }
                catch { }
            }
        }

        public void SendPDFDocuments(string ticket, string mail, string ccMail, string urlVirtuallyThere,
            string from, string pass, string displayName)
        {
            try
            {
                BuildElectronicTicket.MailProvider obj = new BuildElectronicTicket.MailProvider();
                obj.SendPDFDocuments(ticket, mail, ccMail, urlVirtuallyThere, from, pass, displayName);
            }
            catch 
            {
                try
                {
                    BuildElectronicTicketDev.MailProvider obj = new BuildElectronicTicketDev.MailProvider();
                    obj.SendPDFDocuments(ticket, mail, ccMail, urlVirtuallyThere, from, pass, displayName);
                }
                catch { }
            }
        }

        public string Encrypt(string Input)
        {
            try
            {
                BuildElectronicTicket.MailProvider obj = new BuildElectronicTicket.MailProvider();
                return obj.Encrypt(Input);
            }
            catch
            {
                //return string.Empty; }
                try
                {
                    BuildElectronicTicketDev.MailProvider obj = new BuildElectronicTicketDev.MailProvider();
                    return obj.Encrypt(Input);
                }
                catch { return string.Empty; }

            }
        }
    }
}
