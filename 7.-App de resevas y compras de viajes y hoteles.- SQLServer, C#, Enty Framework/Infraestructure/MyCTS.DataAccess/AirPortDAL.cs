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
    public class AirPortDAL
    {
        public List<AirPort> GetAirPort(string catAirPorCode, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.AirPortResources.SP_GetAirPort);
            db.AddInParameter(dbCommand, Resources.AirPortResources.PARAM_QUERY, DbType.String, catAirPorCode);

            List<AirPort> AirPortList = new List<AirPort>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _catcitid = dr.GetOrdinal(Resources.AirPortResources.PARAM_CATCITID);
                int _catcitname = dr.GetOrdinal(Resources.AirPortResources.PARAM_CATCITNAME);
                int _catcouid = dr.GetOrdinal(Resources.AirPortResources.PARAM_CATCOUID);
                int _catcouname = dr.GetOrdinal(Resources.AirPortResources.PARAM_CATCOUNAME);
                //No se ingresaron nullables por que las columnas de las tablas no aceptan nulos
                while (dr.Read())
                {
                    AirPort item = new AirPort();
                    item.CatCitId = dr.GetString(_catcitid);
                    item.CatCitName = dr.GetString(_catcitname);
                    item.CatCouId = dr.GetString(_catcouid);
                    item.CatCouName = (dr[_catcouname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catcouname);
                    AirPortList.Add(item);
                }
            }

            return AirPortList;
        }

    }
}
