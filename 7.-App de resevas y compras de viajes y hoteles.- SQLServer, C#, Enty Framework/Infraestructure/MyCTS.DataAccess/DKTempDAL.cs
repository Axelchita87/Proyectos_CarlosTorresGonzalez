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
    public class DKTempDAL
    {
        public List<DKTemp> GetDKTemp(string Attribute1, bool ProcessType, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.DKTempResources.SP_GetDKTemp);
            db.AddInParameter(dbCommand, Resources.DKTempResources.PARAM_QUERY, DbType.String, Attribute1);
            db.AddInParameter(dbCommand, Resources.DKTempResources.PARAM_QUERY2, DbType.Boolean, ProcessType);

            List<DKTemp> DKTempList = new List<DKTemp>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _namemycts = dr.GetOrdinal(Resources.DKTempResources.PARAM_NAMEMYCTS);
                //int _iddk = dr.GetOrdinal(Resources.DKTempResources.PARAM_IDDK);
                int _class = dr.GetOrdinal(Resources.DKTempResources.PARAM_CLASS);
                int _queue = dr.GetOrdinal(Resources.DKTempResources.PARAM_QUEUE);
                int _queue2 = dr.GetOrdinal(Resources.DKTempResources.PARAM_QUEUE2);
                int _code = dr.GetOrdinal(Resources.DKTempResources.PARAM_CODE);
                int _description = dr.GetOrdinal(Resources.DKTempResources.PARAM_DESCRIPTION);
                //int _pcc= dr.GetOrdinal(Resources.DKTempResources.PARAM_PCC);


                while (dr.Read())
                {
                    DKTemp item = new DKTemp();
                    item.NameMyCTS = (dr[_namemycts] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_namemycts);
                    //item.IDDK = dr.GetString(_iddk);
                    item.Classes = (dr[_class] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_class);
                    item.Queue = (dr[_queue] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_queue);
                    item.Queue2 = (dr[_queue2] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_queue2);
                    item.Code = (dr[_code] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_code);
                    item.Description = (dr[_description] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_description);

                    //item.PCC = (dr[_pcc] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pcc);


                    DKTempList.Add(item);
                }
            }

            return DKTempList;
        }
    }
}
