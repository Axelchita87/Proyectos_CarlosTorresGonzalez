using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;
using MyCTS.Components.NullableHelper;

namespace MyCTS.DataAccess
{
    public class AirlineFOPDAL
    {
        public List<AirlineFOP> GetAirlineFOPList(string AirlineToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.AirlineFOPResources.SP_GetAirLinFOP);
            db.AddInParameter(dbCommand, Resources.AirlineFOPResources.PARAM_QUERY, DbType.String, AirlineToSearch);


            List<AirlineFOP> AirlineFOPList = new List<AirlineFOP>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _catairlinfarid = dr.GetOrdinal(Resources.AirlineFOPResources.PARAM_CATAIRLINFARID);
                int _catairlinfarname = dr.GetOrdinal(Resources.AirlineFOPResources.PARAM_CATAIRLINFARNAME);
                int _ccaut = dr.GetOrdinal(Resources.AirlineFOPResources.PARAM_CCAUT);
                int _ccman = dr.GetOrdinal(Resources.AirlineFOPResources.PARAM_CCMAN);
                int _cash = dr.GetOrdinal(Resources.AirlineFOPResources.PARAM_CASH);
                int _misc = dr.GetOrdinal(Resources.AirlineFOPResources.PARAM_MISC);
                int _pmix = dr.GetOrdinal(Resources.AirlineFOPResources.PARAM_PMIX);


                while (dr.Read())
                {
                    AirlineFOP item = new AirlineFOP();
                    item.CatAirLinFarId = (dr[_catairlinfarid] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catairlinfarid);
                    item.CatAirLinFarName = (dr[_catairlinfarname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catairlinfarname);
                    item.CCAut = dr.GetBoolean(_ccaut);
                    item.CCMan = dr.GetBoolean(_ccman);
                    item.Cash = dr.GetBoolean(_cash);
                    item.Misc = dr.GetBoolean(_misc);
                    item.PMix = dr.GetBoolean(_pmix);
                    AirlineFOPList.Add(item);
                }
            }

            return AirlineFOPList;
        }
    }
}
