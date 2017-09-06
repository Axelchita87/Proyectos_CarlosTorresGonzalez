using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class GetPccDAL
    {
        public PCC GetPcc(string pcc, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetPccResources.SP_GetPcc);
            db.AddInParameter(dbCommand, Resources.GetPccResources.PARAM_PCC, DbType.String, pcc);

            PCC Pcc = new PCC();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _pcc = dr.GetOrdinal(Resources.GetPccResources.PARAM_CAT_PCC_ID);
                int _name = dr.GetOrdinal(Resources.GetPccResources.PARAM_CAT_PCC_NAME);
                int _application = dr.GetOrdinal(Resources.GetPccResources.PARAM_APPLICATION_ID);
                int _tipo = dr.GetOrdinal(Resources.GetPccResources.PARAM_TYPE);
                int _tool = dr.GetOrdinal(Resources.GetPccResources.PARAM_TOOL);
                int _gds = dr.GetOrdinal(Resources.GetPccResources.PARAM_GDS);


                try
                {
                    if (dr.Read())
                    {
                        Guid guid = new Guid();
                        Pcc.PccCode = (dr[_pcc] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pcc);
                        Pcc.Name = (dr[_name] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_name);
                        Pcc.Tipo = (dr[_tipo] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_tipo);
                        Pcc.Tool = (dr[_tool] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_tool);
                        Pcc.GDS = (dr[_gds] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_gds);
                        guid = dr.GetGuid(_application);
                        Pcc.Type = Convert.ToString(guid);
                    }
                }
                catch { }
            }
            return Pcc;
        }
    }
}
