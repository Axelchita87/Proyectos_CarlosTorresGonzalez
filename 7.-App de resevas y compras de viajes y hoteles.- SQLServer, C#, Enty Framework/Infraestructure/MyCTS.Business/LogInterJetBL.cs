using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class LogInterJetBL
    {

        /// <summary>
        /// 
        /// </summary>
        private LogInterJetDAL dataAcces;

        /// <summary>
        /// Gets the data acces.
        /// </summary>
        private LogInterJetDAL DataAcces
        {
            get
            {
                return dataAcces ?? (dataAcces = new LogInterJetDAL());
            }
        }

        /// <summary>
        /// Inserts the specified ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <param name="agent">The agent.</param>
        /// <returns></returns>
        public bool Insert(InterJetTicket ticket, string agent, decimal Amount)
        {
            return DataAcces.Insert(ticket, agent, Amount);
        }

        /// <summary>
        /// Inserts the PNR.
        /// </summary>
        /// <param name="reservationCodeInterJet">The reservation code inter jet.</param>
        /// <param name="pnrCode">The PNR code.</param>
        /// <returns></returns>
        public bool InsertSabreRecord(string reservationCodeInterJet, string pnrCode)
        {
            return DataAcces.InsertSabreRecord(reservationCodeInterJet, pnrCode);
        }

        /// <summary>
        /// Approves the record.
        /// </summary>
        /// <param name="recordLocator">The record locator.</param>
        /// <returns></returns>
        public bool ApproveRecord(string recordLocator)
        {
            return DataAcces.ApproveRecord(recordLocator);
        }

        /// <summary>
        /// Invoices the record.
        /// </summary>
        /// <param name="recordLocator">The record locator.</param>
        /// <returns></returns>
        public bool InvoiceRecord(string recordLocator)
        {
            return DataAcces.InvoiceRecord(recordLocator);
        }



    }
}
