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
    public class CatBusinessUnitsDAL
    {
        public List<CatBusinessUnits> GetBusinessUnits(int OrgId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.CatBusinessUnitsResources.SP_GetBusinessUnits);
            db.AddInParameter(dbcommand, Resources.CatBusinessUnitsResources.PARAM_ORG_ID, DbType.Int32, OrgId);
            //Este StoredProcedure no lleva parametros
            //Lista de parametros

            List<CatBusinessUnits> GetBusinessUnitsList = new List<CatBusinessUnits>();
            using (IDataReader dr = db.ExecuteReader(dbcommand))
            {
                int _idbusinessunits = dr.GetOrdinal(Resources.CatBusinessUnitsResources._IDBUSINESSUNITS);
                int _name = dr.GetOrdinal(Resources.CatBusinessUnitsResources.PARAM_NAME);
                int _idintegra = dr.GetOrdinal(Resources.CatBusinessUnitsResources.PARAM_ID_INTEGRA);
                //int _pcc = dr.GetOrdinal(Resources.CatBusinessUnitsResources.PARAM_PCC);

                while (dr.Read())
                {
                    CatBusinessUnits item = new CatBusinessUnits();
                    item.IDBusinessUnits = (dr[_idbusinessunits] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_idbusinessunits);
                    item.Name = (dr[_name] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_name);
                    item.IDIntegra = (dr[_idintegra] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_idintegra);
                    GetBusinessUnitsList.Add(item);
                }

            }
            return GetBusinessUnitsList;


        }

    }
}
