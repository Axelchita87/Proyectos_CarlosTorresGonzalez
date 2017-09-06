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
    public class SetClientsCatalogsNextelDAL
    {

        public List<SetClientsCatalogsNextel> SetClientsCatalogsNextel(string connectionName, string Client, string Attribute1, string Attribute2,
                                                                        string Attribute3)
        {
            List<SetClientsCatalogsNextel> SetClientsCatalogsNextelList;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionName);
                DbCommand dbCommand = db.GetStoredProcCommand(Resources.SetClientsCatalogsNextelResources.SP_SetClientsCatalogsNextel);
                db.AddInParameter(dbCommand, Resources.SetClientsCatalogsNextelResources.PARAM_QUERY1, DbType.String, Client);
                db.AddInParameter(dbCommand, Resources.SetClientsCatalogsNextelResources.PARAM_QUERY2, DbType.String, Attribute1);
                db.AddInParameter(dbCommand, Resources.SetClientsCatalogsNextelResources.PARAM_QUERY3, DbType.String, Attribute2);
                db.AddInParameter(dbCommand, Resources.SetClientsCatalogsNextelResources.PARAM_QUERY4, DbType.String, Attribute3);
                SetClientsCatalogsNextelList = new List<SetClientsCatalogsNextel>();
                using (IDataReader dr = db.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        SetClientsCatalogsNextel item = new SetClientsCatalogsNextel();
                        SetClientsCatalogsNextelList.Add(item);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return SetClientsCatalogsNextelList;
        }
    }
}
