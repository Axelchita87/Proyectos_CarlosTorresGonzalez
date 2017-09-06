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
    public class AllPCCsCompletDAL
    {
        public List<AllPCCsComplet> GetAllPCCsComplet(int OrgId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.AllPCCsCompleteResources.SP_GetAllPccsComplet);
            db.AddInParameter(dbCommand, Resources.AllPCCsCompleteResources.PARAM_ORG_ID, DbType.Int32, OrgId);

            List<AllPCCsComplet> PccList = new List<AllPCCsComplet>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _catpccid = dr.GetOrdinal(Resources.AllPCCsCompleteResources.PARAM_CATPCCID);
                int _catpccname = dr.GetOrdinal(Resources.AllPCCsCompleteResources.PARAM_CATPCCNAME);
                int _status = dr.GetOrdinal(Resources.AllPCCsCompleteResources.PARAM_STATUS);
                int _standardclass = dr.GetOrdinal(Resources.AllPCCsCompleteResources.PARAM_STANDARDCLASS);
                int _specificclass = dr.GetOrdinal(Resources.AllPCCsCompleteResources.PARAM_SPECIFICCLASS);
                int _confirmation = dr.GetOrdinal(Resources.AllPCCsCompleteResources.PARAM_CONFIRMATION);
                int _businessclass1 = dr.GetOrdinal(Resources.AllPCCsCompleteResources.PARAM_BUSINESSCLASS1);
                int _businessclass2 = dr.GetOrdinal(Resources.AllPCCsCompleteResources.PARAM_BUSINESSCLASS2);
                int _businessclass3 = dr.GetOrdinal(Resources.AllPCCsCompleteResources.PARAM_BUSINESSCLASS3);
                int _businessclass4 = dr.GetOrdinal(Resources.AllPCCsCompleteResources.PARAM_BUSINESSCLASS4);
                int _type = dr.GetOrdinal(Resources.AllPCCsCompleteResources.PARAM_TYPE);
                int _tool = dr.GetOrdinal(Resources.AllPCCsCompleteResources.PARAM_TOOL);
                int _gds = dr.GetOrdinal(Resources.AllPCCsCompleteResources.PARAM_GDS);
                int _activedate = dr.GetOrdinal(Resources.AllPCCsCompleteResources.PARAM_ACTIVEDATE);
                //int _inactivedate = dr.GetOrdinal(Resources.AllPCCsCompleteResources.PARAM_INACTIVEDATE);

                //No se ingresaron nullables por que las columnas de las tablas no aceptan nulos
                while (dr.Read())
                {
                    AllPCCsComplet item = new AllPCCsComplet();
                    item.CatPccId = (dr[_catpccid] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catpccid);
                    item.CatPccName = (dr[_catpccname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_catpccname);
                    item.Status = (dr[_status] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_status);
                    item.StandardClass = (dr[_standardclass] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_standardclass);
                    item.SpecificClass = (dr[_specificclass] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_specificclass);
                    item.Confirmation = (dr[_confirmation] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_confirmation);
                    item.BusinessClass1 = (dr[_businessclass1] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_businessclass1);
                    item.BusinessClass2 = (dr[_businessclass2] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_businessclass2);
                    item.BusinessClass3 = (dr[_businessclass3] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_businessclass3);
                    item.BusinessClass4 = (dr[_businessclass4] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_businessclass4);
                    item.Type = (dr[_type] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_type);
                    item.Tool = (dr[_tool] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_tool);
                    item.GDS = (dr[_gds] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_gds);
                    item.ActiveDate = (dr[_activedate] == DBNull.Value) ? Types.DateNullValue : dr.GetDateTime(_activedate);
                    //item.InactiveDate = (dr[_activedate] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_inactivedate);


                    PccList.Add(item);
                }
            }

            return PccList;
        }



    }
}
