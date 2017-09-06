using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyCTS.DataAccess
{
    public class VolarisPointToPointDAL
    {
        public VolarisPointToPoint GetPointToPointFlightsV2(string departure, string arrival, string conexion)
        {
            try
            {
                Database dataBase = DatabaseFactory.CreateDatabase(conexion);
                DbCommand dataBaseCommand = dataBase.GetStoredProcCommand("GetVolarisPointToPointV2");
                dataBase.AddInParameter(dataBaseCommand, "@To", DbType.String,departure);
                dataBase.AddInParameter(dataBaseCommand, "@From", DbType.String, arrival);
                var point = new VolarisPointToPoint();
                using (IDataReader dataReader = dataBase.ExecuteReader(dataBaseCommand))
                {
                    int id = dataReader.GetOrdinal("ID");
                    int pointTo = dataReader.GetOrdinal("To");
                    int pointFrom = dataReader.GetOrdinal("From");
                    int isInternational = dataReader.GetOrdinal("IsInternational");
                    while (dataReader.Read())
                    {
                        point.ID = dataReader.GetInt32(id);
                        point.To = dataReader.GetString(pointTo);
                        point.From = dataReader.GetString(pointFrom);
                        point.IsInternational = dataReader.GetBoolean(isInternational);
                    }
                }
                return point;
            }
            catch (Exception ex)
            {
                return new VolarisPointToPoint();
            }



        }
    }
}
