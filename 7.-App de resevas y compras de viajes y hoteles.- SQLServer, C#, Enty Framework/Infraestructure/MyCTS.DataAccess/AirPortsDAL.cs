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
    public class AirPortsDAL
    {
        public List<AirPorts> GetAirPorts(string strToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.AirPortsResources.SP_GetAirPorts);
            db.AddInParameter(dbCommand, Resources.AirPortsResources.PARAM_QUERY, DbType.String, strToSearch);

            List<AirPorts> AirPortList = new List<AirPorts>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _catcitid = dr.GetOrdinal(Resources.AirPortsResources.PARAM_CATCITID);
                int _catcitname = dr.GetOrdinal(Resources.AirPortsResources.PARAM_CATCITNAME);
                int _catcouid = dr.GetOrdinal(Resources.AirPortsResources.PARAM_CATCOUID);
                int _catcouname = dr.GetOrdinal(Resources.AirPortsResources.PARAM_CATCOUNAME);
                //No se ingresaron nullables por que las columnas de las tablas no aceptan nulos
                while (dr.Read())
                {
                    AirPorts item = new AirPorts();
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
