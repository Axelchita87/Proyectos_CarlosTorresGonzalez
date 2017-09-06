using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;
using MyCTS.Components.NullableHelper;

namespace MyCTS.DataAccess
{
    public class GetAllFirmModulesDAL
    {
        public TA GetTA(string ta, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetAllFirmModulesResources.SP_GetTA);
            db.AddInParameter(dbCommand, Resources.GetAllFirmModulesResources.PARAM_TA, DbType.String, ta);
            TA objTA = new TA();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _ta = dr.GetOrdinal(Resources.GetAllFirmModulesResources.PARAM_TA);
                int _type = dr.GetOrdinal(Resources.GetAllFirmModulesResources.PARAM_TYPE);
                int _pcc = dr.GetOrdinal(Resources.GetAllFirmModulesResources.PARAM_PCC);
                int _asigned = dr.GetOrdinal(Resources.GetAllFirmModulesResources.PARAM_ASIGNED);

                if (dr.Read())
                {
                    objTA.Code = (dr[_ta] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ta);
                    objTA.Type = (dr[_type] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_type);
                    objTA.Pcc = (dr[_pcc] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pcc);
                    objTA.Asigned = (dr[_asigned] == DBNull.Value) ? false : dr.GetBoolean(_asigned);
                }
            }
           
            return objTA;
        }

        public IATA GetIATA(string iata, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetAllFirmModulesResources.SP_GetIATA);
            db.AddInParameter(dbCommand, Resources.GetAllFirmModulesResources.PARAM_IATA, DbType.String, iata);
            IATA objIATA = new IATA();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _iata = dr.GetOrdinal(Resources.GetAllFirmModulesResources.PARAM_IATA);
                int _office = dr.GetOrdinal(Resources.GetAllFirmModulesResources.PARAM_OFFICE);
                int _pcc = dr.GetOrdinal(Resources.GetAllFirmModulesResources.PARAM_PCC);
                

                if (dr.Read())
                {
                    objIATA.Code = (dr[_iata] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_iata);
                    objIATA.Office = (dr[_office] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_office);
                    objIATA.Pcc = (dr[_pcc] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pcc);
                }
            }
            return objIATA;
        }
    }
}
