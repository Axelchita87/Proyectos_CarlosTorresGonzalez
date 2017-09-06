using System;
using System.Collections.Generic;
using System.Text;
using MyCTS.Business;
using MyCTS.Entities;
using MyCTS.Services.Contracts;

namespace MyCTS.Presentation.Components
{
    public class CreateFilePDFTicket
    {
        public static void CreateFilesPDF(List<string> tickets)
        {
            Parameter mailToSend = ParameterBL.GetParameterValue("MailThatSendFeeRule");
            Parameter mailPassword = ParameterBL.GetParameterValue("PasswordThatMailToSend");
            Parameter displyName = ParameterBL.GetParameterValue("NameSendEmail");
            string[] tiketsArray = new string[tickets.Count];
            string[] virtuallyThere = new string[tickets.Count];
            List<GetLinkByTkt> indexList = null;
            for (int j = 0; j < tickets.Count; j++)
            {
                tiketsArray[j] = tickets[j];
                indexList = new List<GetLinkByTkt>();
                indexList = GetLinkByTktBL.GetLinkByTkt(tickets[j].Substring(3, 10), Login.OrgId);
                if (indexList.Count > 0)
                    virtuallyThere[j] = indexList[0].LinkVirtuallyThere;
                else
                    virtuallyThere[j] = "http://www.google.com.mx";
            }
            if (tickets.Count > 0)
            {
                try
                {
                    string mail = Login.Mail;
                    if (!string.IsNullOrEmpty(ucSendTicketPrinter.TempCCMail))
                    {
                        mail = string.Concat(mail, ";", ucSendTicketPrinter.TempCCMail);
                        ucSendTicketPrinter.TempCCMail = string.Empty;
                    }
                    if (ucFirstValidations.Attribute1 != null)
                    {
                        if (ucFirstValidations.Attribute1.Equals(Resources.TicketEmission.Constants.ATTRIBUTE1_CFE100))
                        {
                            BuildElectronicTicketCFEContract ws = new BuildElectronicTicketCFEContract();
                            ws.SendInfoToBuilPDF(tiketsArray, virtuallyThere,
                            ucTicketsEmissionInstructions.Airline, mailToSend.Values,
                            mailPassword.Values, mail, displyName.Values);
                        }
                        else
                        {
                            BuildElectronicTicketContract ws = new BuildElectronicTicketContract();
                            ws.SendInfoToBuilPDF(tiketsArray, virtuallyThere,
                            ucTicketsEmissionInstructions.Airline, mailToSend.Values,
                            mailPassword.Values, mail, displyName.Values);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(ucSendTicketPrinter.DK))
                        {
                            GetAttribute1 attribute1 = GetAttribute1BL.GetAttribute(ucSendTicketPrinter.DK, Login.OrgId);
                            if (attribute1.Attribute1.Equals(Resources.TicketEmission.Constants.ATTRIBUTE1_CFE100))
                            {
                                BuildElectronicTicketCFEContract ws = new BuildElectronicTicketCFEContract();
                                ws.SendInfoToBuilPDF(tiketsArray, virtuallyThere,
                                ucTicketsEmissionInstructions.Airline, mailToSend.Values,
                                mailPassword.Values, mail, displyName.Values);
                            }
                            else
                            {
                                BuildElectronicTicketContract ws = new BuildElectronicTicketContract();
                                ws.SendInfoToBuilPDF(tiketsArray, virtuallyThere,
                                ucTicketsEmissionInstructions.Airline, mailToSend.Values,
                                mailPassword.Values, mail, displyName.Values);
                            }
                            ucSendTicketPrinter.DK = string.Empty;
                        }
                        else
                        {
                            BuildElectronicTicketContract ws = new BuildElectronicTicketContract();
                            ws.SendInfoToBuilPDF(tiketsArray, virtuallyThere,
                            ucTicketsEmissionInstructions.Airline, mailToSend.Values,
                            mailPassword.Values, mail, displyName.Values);
                        }
                    }
                }
                catch { }
            }
        }
        public static void ReSendPDFDocumnets(string ticketNumber, string urlVirtuallyThere, string ccMail)
        {
            Parameter mailToSend = ParameterBL.GetParameterValue("MailThatSendFeeRule");
            Parameter mailPassword = ParameterBL.GetParameterValue("PasswordThatMailToSend");
            Parameter displyName = ParameterBL.GetParameterValue("NameSendEmail");
            try
            {
                BuildElectronicTicketContract ws = new BuildElectronicTicketContract();
                ws.SendPDFDocuments(ticketNumber, Login.Mail, ccMail, urlVirtuallyThere, mailToSend.Values, mailPassword.Values,
                    displyName.Values);
            }
            catch { }
        }
    }
}
