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
    public class AllPccsDAL
    {
        public List<AllPccs> GetAllPccs(string strToSearch, int OrgId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.AllPccsResources.SP_GetAllPccs);
            db.AddInParameter(dbCommand, Resources.AllPccsResources.PARAM_QUERY, DbType.String, strToSearch);
            db.AddInParameter(dbCommand, Resources.AllPccsResources.PARAM_ORG_ID, DbType.Int32, OrgId);

            List<AllPccs> PccList = new List<AllPccs>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _catpccid = dr.GetOrdinal(Resources.AllPccsResources.PARAM_CATPCCID);
                int _catpccname = dr.GetOrdinal(Resources.AllPccsResources.PARAM_CATPCCNAME);
                int _status = dr.GetOrdinal(Resources.AllPccsResources.PARAM_STATUS);
                int _standardclass = dr.GetOrdinal(Resources.AllPccsResources.PARAM_STANDARDCLASS);
                int _specificclass = dr.GetOrdinal(Resources.AllPccsResources.PARAM_SPECIFICCLASS);
                int _confirmation = dr.GetOrdinal(Resources.AllPccsResources.PARAM_CONFIRMATION);
                int _businessclass1 = dr.GetOrdinal(Resources.AllPccsResources.PARAM_BUSINESSCLASS1);
                int _businessclass2 = dr.GetOrdinal(Resources.AllPccsResources.PARAM_BUSINESSCLASS2);
                int _businessclass3 = dr.GetOrdinal(Resources.AllPccsResources.PARAM_BUSINESSCLASS3);
                int _businessclass4 = dr.GetOrdinal(Resources.AllPccsResources.PARAM_BUSINESSCLASS4);


                //No se ingresaron nullables por que las columnas de las tablas no aceptan nulos
                while (dr.Read())
                {
                    AllPccs item = new AllPccs();
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

                    PccList.Add(item);
                }
            }

            return PccList;
        }


    }
}
