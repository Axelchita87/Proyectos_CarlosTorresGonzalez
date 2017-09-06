using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class VolarisLoggerDAL
    {

        public int InsertReservation()
        {
            try
            {
                return InserReservation(CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception)
            {

                try
                {
                    return InserReservation(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch
                {

                }
            }



            return 0;
        }

        public int UpdateReservation(string volarisPnr, string sabrePnr, VolarisReservationStatus status)
        {
            try
            {
                return UpdateReservation(volarisPnr, sabrePnr, status, CommonENT.MYCTSDB_CONNECTION);
            }
            catch
            {
                try
                {
                    return UpdateReservation(volarisPnr, sabrePnr,status, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch (Exception)
                {


                }
            }


            return 0;
        }

        private int InserReservation(string connectionString)
        {
            Database dataBase = DatabaseFactory.CreateDatabase(connectionString);
            DbCommand dbComand = dataBase.GetStoredProcCommand("InsertVolarisReservation");

            dataBase.AddInParameter(dbComand, "VolarisPNR", DbType.String, VolarisSession.PNR);
            dataBase.AddInParameter(dbComand, "Approved", DbType.Boolean,
                                    VolarisSession.StatusPaymnet == VolarisPaymentStatus.Approved);
            dataBase.AddInParameter(dbComand, "Invoiced", DbType.Boolean,false);
            dataBase.AddInParameter(dbComand, "SabrePNR", DbType.String, VolarisSession.PNRSabre);
            dataBase.AddInParameter(dbComand, "Agent", DbType.String, VolarisSession.Agent);
            dataBase.AddInParameter(dbComand, "AgentMail", DbType.String, VolarisSession.EmailAgent);
            dataBase.AddInParameter(dbComand, "AuthCode", DbType.String, "");
            dataBase.AddInParameter(dbComand, "Date", DbType.DateTime, DateTime.Now);
            dataBase.AddInParameter(dbComand, "Amount", DbType.Decimal, VolarisSession.PagoTotal);

            int result = dataBase.ExecuteNonQuery(dbComand);
            return result;
        }

        private int UpdateReservation(string volarisPnr, string sabrePnr, VolarisReservationStatus status, string connectionString)
         {
            Database dataBase = DatabaseFactory.CreateDatabase(connectionString);
            DbCommand dbComand = dataBase.GetStoredProcCommand("UpdateVolarisLog");

            dataBase.AddInParameter(dbComand, "Invoiced", DbType.Boolean,
                                    VolarisSession.ReservationStatus == VolarisReservationStatus.Invoiced);
            dataBase.AddInParameter(dbComand, "SabrePNR", DbType.String, VolarisSession.PNRSabre);
            dataBase.AddInParameter(dbComand, "VolarisPNR", DbType.String, VolarisSession.PNR);
            int result = dataBase.ExecuteNonQuery(dbComand);
            return result;
        }
    }
}
