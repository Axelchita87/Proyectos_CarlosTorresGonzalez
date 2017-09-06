using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace MyCTS.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class LogInterJetDAL
    {

        /// <summary>
        /// Inserts the specified ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <param name="agent">The agent.</param>
        /// <returns></returns>
        public bool Insert(InterJetTicket ticket, string agent, decimal Amount)
        {
            try
            {
                return this.Insert(ticket,agent, Amount,CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception ex)
            {
                try
                {
                    return this.Insert(ticket, agent, Amount,CommonENT.MYCTSDBBACKUP_CONNECTION);
                }catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Inserts the specified string connection.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="stringConnection">The string connection.</param>
        /// <returns></returns>
        private bool Insert(InterJetTicket ticket, string agent, decimal Amount, string stringConnection)
        {
            Database dataBase = DatabaseFactory.CreateDatabase(stringConnection);
            DbCommand dbComand = dataBase.GetStoredProcCommand("InsertInterJetLog");
            dataBase.AddInParameter(dbComand, "Agent", DbType.String, agent);
            dataBase.AddInParameter(dbComand, "ReservationCode", DbType.String, ticket.RecordLocator);
            dataBase.AddInParameter(dbComand, "Approved", DbType.Boolean, ticket.IsAprooved);
            dataBase.AddInParameter(dbComand, "Invoiced", DbType.Boolean, ticket.IsFactured);
            dataBase.AddInParameter(dbComand, "Amount", DbType.Decimal, Amount);

            int result = dataBase.ExecuteNonQuery(dbComand);

            return result > 0;

        }



        /// <summary>
        /// Approves the record.
        /// </summary>
        /// <param name="recordLocator">The record locator.</param>
        /// <returns></returns>
        public bool ApproveRecord(string recordLocator)
        {
            return this.Update(recordLocator, true, false);
        }

        /// <summary>
        /// Invoices the record.
        /// </summary>
        /// <param name="recordLocator">The record locator.</param>
        /// <returns></returns>
        public bool InvoiceRecord(string recordLocator)
        {
            return this.Update(recordLocator, true, true);
        }

        public bool InsertSabreRecord(string reservationCodeInterJet,string pnrCode)
        {

            try
            {
                return InsertPNR(reservationCodeInterJet, pnrCode, CommonENT.MYCTSDB_CONNECTION);
            }catch
            {
                try
                {
                }
                catch
                {
                   return InsertPNR(reservationCodeInterJet, pnrCode, CommonENT.MYCTSDBBACKUP_CONNECTION);

                }

            }

            return false;
        }

        private bool InsertPNR(string reservationCodeInterJet, string pnrCode,string connectionString)
        {

            Database dataBase = DatabaseFactory.CreateDatabase(connectionString);
            DbCommand dbComand = dataBase.GetStoredProcCommand("InsertPNRInterJetLog");
            dataBase.AddInParameter(dbComand, "ReservationCode", DbType.String, reservationCodeInterJet);
            dataBase.AddInParameter(dbComand, "RecordLocator", DbType.String, pnrCode);
            int result = dataBase.ExecuteNonQuery(dbComand);
            return result > 0;


        }



        /// <summary>
        /// Updates the specified record locator.
        /// </summary>
        /// <param name="recordLocator">The record locator.</param>
        /// <param name="approved">if set to <c>true</c> [approved].</param>
        /// <param name="invoiced">if set to <c>true</c> [invoiced].</param>
        /// <param name="stringConneciton">The string conneciton.</param>
        /// <returns></returns>
        private bool Update(string recordLocator, bool approved, bool invoiced,string stringConneciton)
        {
            
                Database dataBase = DatabaseFactory.CreateDatabase(stringConneciton);
                DbCommand dbComand = dataBase.GetStoredProcCommand("UpdateInterJetLog");
                dataBase.AddInParameter(dbComand, "ReservationCode", DbType.String, recordLocator);
                dataBase.AddInParameter(dbComand, "Approved", DbType.Boolean, approved);
                dataBase.AddInParameter(dbComand, "Invoiced", DbType.Boolean, invoiced);
                int result = dataBase.ExecuteNonQuery(dbComand);
                return result > 0;



        }

        /// <summary>
        /// Updates the specified record locator.
        /// </summary>
        /// <param name="recordLocator">The record locator.</param>
        /// <param name="approved">if set to <c>true</c> [approved].</param>
        /// <param name="invoiced">if set to <c>true</c> [invoiced].</param>
        /// <returns></returns>
        private bool Update(string recordLocator, bool approved, bool invoiced)
        {
            try
            {
                return this.Update(recordLocator, approved, invoiced, CommonENT.MYCTSDB_CONNECTION);

            }
            catch (Exception ex)
            {
                try
                {
                    return this.Update(recordLocator, approved, invoiced, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }catch
                {
                    return false;
                }
            }
        }


    }
}
