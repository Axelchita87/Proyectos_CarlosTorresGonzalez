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
    public class SabreErrorMsgDAL
    {
       

       public SabreErrorMsg GetSabreErrorMsg(string SabreErrMsg, int ModuleId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.SabreErrorMsgResources.SP_GetSabreErrorMsg);
            db.AddInParameter(dbCommand, Resources.SabreErrorMsgResources.PARAM_QUERY2, DbType.String, SabreErrMsg);
            db.AddInParameter(dbCommand, Resources.SabreErrorMsgResources.PARAM_QUERY1, DbType.Int32, ModuleId);

            SabreErrorMsg item = new SabreErrorMsg();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _cuserrmsgusermsg = dr.GetOrdinal(Resources.SabreErrorMsgResources.PARAM_CUSERRMSGUSERMSG);
                int _cuserrmsgmodulesrc = dr.GetOrdinal(Resources.SabreErrorMsgResources.PARAM_CUSERRMSGMODULESRC);

                if (dr.Read())
                {
                    item.CusErrMsgUserMsg = dr.GetString(_cuserrmsgusermsg);
                    item.CusErrMsgModuleSrc = (dr[_cuserrmsgmodulesrc]==DBNull.Value) ? Types.StringNullValue : dr.GetString(_cuserrmsgmodulesrc);
                   
                }
            }

            return item;
        }
    }
}
