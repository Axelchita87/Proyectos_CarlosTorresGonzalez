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
    public class LowFareAirLinesErrorLoggerDAL
    {

        public void Log(LowFareAirLinesError error)
        {

            try
            {
                Log(error, CommonENT.MYCTSDB_CONNECTION);
            }
            catch (Exception exee)
            {
                try
                {
                    Log(error, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                catch (Exception exe)
                {

                }
            }


        }

        private void Log(LowFareAirLinesError error, string connectionString)
        {
            Database dataBase = DatabaseFactory.CreateDatabase(connectionString);
            DbCommand dbComand = dataBase.GetStoredProcCommand("InsertLowFareAirLinesError");
            dataBase.AddInParameter(dbComand, "Agent", DbType.String, error.Agent);
            dataBase.AddInParameter(dbComand, "ErrorMessage", DbType.String, error.ErrorMessage);
            dataBase.AddInParameter(dbComand, "AirLine", DbType.String, error.AirLine);
            dataBase.AddInParameter(dbComand, "Date", DbType.DateTime, error.Date);
            dataBase.AddInParameter(dbComand, "ServiceName", DbType.String, error.ServiceName);

            int result = dataBase.ExecuteNonQuery(dbComand);
        }
    }
}
