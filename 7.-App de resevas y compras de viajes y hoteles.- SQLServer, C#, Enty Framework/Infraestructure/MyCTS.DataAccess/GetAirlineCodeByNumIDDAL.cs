using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace MyCTS.DataAccess
{
    public class GetAirlineCodeByNumIDDAL
    {
        public string GetAirlineCode(string strToSearch, string connection)
        {
            Database db = DatabaseFactory.CreateDatabase(connection);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetAirlineCodeByNumIDResources.SP_GETAIRLINECODEBYNUMID);
            db.AddInParameter(dbCommand, Resources.GetAirlineCodeByNumIDResources.PARAM_QUERY1, DbType.String, strToSearch);
            string codeAirline = string.Empty;
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _catAirline = dr.GetOrdinal(Resources.GetAirlineCodeByNumIDResources.PARAM_AIRLINE_CODE);
                if (dr.Read())
                {
                    codeAirline = dr.GetString(_catAirline);
                }
            }
            return codeAirline;
        }
    }
}
