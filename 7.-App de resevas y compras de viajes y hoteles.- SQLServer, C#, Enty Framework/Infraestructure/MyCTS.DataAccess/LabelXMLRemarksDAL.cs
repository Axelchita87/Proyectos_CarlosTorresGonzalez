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
    public class LabelXMLRemarksDAL
    {
        public List<LabelXMLRemarks> GetLabelXMLRemarks(string Attribute1, string IDProcess, string RemarkValue, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.LabelXMLRemarksResources.SP_GetLabelXMLRemarks);
            db.AddInParameter(dbCommand, Resources.LabelXMLRemarksResources.PARAM_QUERY1, DbType.String, Attribute1);
            db.AddInParameter(dbCommand, Resources.LabelXMLRemarksResources.PARAM_QUERY2, DbType.String, IDProcess);
            db.AddInParameter(dbCommand, Resources.LabelXMLRemarksResources.PARAM_QUERY4, DbType.String, RemarkValue);

            List<LabelXMLRemarks> LabelXMLRemarksList = new List<LabelXMLRemarks>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _xmlactuallabel = dr.GetOrdinal(Resources.LabelXMLRemarksResources.PARAM_XMLACTUALLABEL);
                int _xmlfuturelabel = dr.GetOrdinal(Resources.LabelXMLRemarksResources.PARAM_XMLFUTURELABEL);


                while (dr.Read())
                {
                    LabelXMLRemarks item = new LabelXMLRemarks();

                    item.XMLActualLabel = (dr[_xmlactuallabel] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_xmlactuallabel);
                    item.XMLFutureLabel = (dr[_xmlfuturelabel] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_xmlfuturelabel);
                    LabelXMLRemarksList.Add(item);
                }

            }
            return LabelXMLRemarksList;
        }

    }
}
