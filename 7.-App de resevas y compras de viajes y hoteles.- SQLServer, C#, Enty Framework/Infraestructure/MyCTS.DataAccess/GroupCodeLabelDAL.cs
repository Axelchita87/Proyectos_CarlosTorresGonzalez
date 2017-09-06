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
    public class GroupCodeLabelDAL
    {
        public List<GroupCodeLabel> GetGroupCodeLabel(string RemarkValue, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GroupCodeLabelResources.SP_GetGroupCodeLabel);
            db.AddInParameter(dbCommand, Resources.GroupCodeLabelResources.PARAM_QUERY, DbType.String, RemarkValue);

            List<GroupCodeLabel> LabelXMLRemarksList = new List<GroupCodeLabel>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _xmlfuturelabel = dr.GetOrdinal(Resources.GroupCodeLabelResources.PARAM_XMLFUTURELABEL);


                while (dr.Read())
                {
                    GroupCodeLabel item = new GroupCodeLabel();
                    item.XMLFutureLabel = (dr[_xmlfuturelabel] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_xmlfuturelabel);
                    LabelXMLRemarksList.Add(item);
                }

            }
            return LabelXMLRemarksList;
        }

    }
}
