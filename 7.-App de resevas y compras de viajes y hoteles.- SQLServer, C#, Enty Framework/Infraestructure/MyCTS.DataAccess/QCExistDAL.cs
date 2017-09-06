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
    public class QCExistDAL
    {
        public List<QCExist> GetQCExist(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.QCExistResources.SP_GetQC);
            List<QCExist> QCExistList = new List<QCExist>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _qcdescription = dr.GetOrdinal(Resources.QCExistResources.PARAM_QCDescription);
                int _qclabel = dr.GetOrdinal(Resources.QCExistResources.PARAM_QCLabel);



                while (dr.Read())
                {
                    QCExist item = new QCExist();

                    item.QCDescription = (dr[_qcdescription] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_qcdescription);
                    item.QCLabel = (dr[_qclabel] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_qclabel);
                    QCExistList.Add(item);
                }

            }
            return QCExistList;
        }

    }
}
