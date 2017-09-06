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
    public class GetQCIDCtrlDAL
    {
        public List<GetQCIDCtrl> GetQCIDCtrl(string idCtrl, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetQCIDCtrlResources.SP_GetQCIDCtrl);
            db.AddInParameter(dbCommand, Resources.GetQCIDCtrlResources.PARAM_QUERY, DbType.String, idCtrl);

            List<GetQCIDCtrl> GetQCIDCtrlList = new List<GetQCIDCtrl>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _idctrl = dr.GetOrdinal(Resources.GetQCIDCtrlResources.PARAM_IDCTRL);

                while (dr.Read())
                {
                    GetQCIDCtrl item = new GetQCIDCtrl();
                    item.IDCtrl = dr.GetString(_idctrl);
                    GetQCIDCtrlList.Add(item);
                }
                return GetQCIDCtrlList;
            }
        }

    }
}
