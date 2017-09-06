using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Services.Contracts
{
    public class BuildElectronicTicketCFEContract
    {
        public void SendInfoToBuilPDF(
            string[] ticketNumber, string[] urlVirtuallyThere, string airline,
            string from, string password, string to, string displayName)
        {
            try
            {
                BuildElectronicTicketCFE.PDFGeneratorCFEWS obj = new BuildElectronicTicketCFE.PDFGeneratorCFEWS();
                obj.BuildPDFDocumentsCFE(ticketNumber, urlVirtuallyThere,
                airline, from, password, to, displayName);

                //obj.Dispose();


            }
            catch
            {
                //try
                //{
                //    BuildElectronicTicketCFEDev.MailProvider obj = new BuildElectronicTicketCFEDev.MailProvider();
                //    obj.BuildPDFDocuments(ticketNumber, urlVirtuallyThere,
                //        airline, from, password, to, displayName);

                //}
                //catch { }
            }
        }
    }
}
