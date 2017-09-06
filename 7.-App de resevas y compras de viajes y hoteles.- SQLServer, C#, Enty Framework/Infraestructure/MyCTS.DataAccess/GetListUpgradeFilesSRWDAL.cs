using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
    public class GetListUpgradeFilesSRWDAL
    {
        public List<UpgradeFileSRW> GetListUpgradeFilesSRW(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.UpgradeFilesResources.SP_GETFILESUPGRADE);


            List<UpgradeFileSRW> getListUpgradeFilesSRW = new List<UpgradeFileSRW>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _nombreDoc = dr.GetOrdinal(Resources.UpgradeFilesResources.PARAM_NOMBREDOC);
                int _extension = dr.GetOrdinal(Resources.UpgradeFilesResources.PARAM_EXTENSION);

                while (dr.Read())
                {
                    UpgradeFileSRW item = new UpgradeFileSRW();
                    item.NombreDoc = (dr[_nombreDoc] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_nombreDoc);
                    item.Extension = (dr[_extension] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_extension);
                    getListUpgradeFilesSRW.Add(item);
                }
            }
            return getListUpgradeFilesSRW;
        }
    }
}
