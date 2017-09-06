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
    public class CatLineClassesDAL
    {
        public List<ListItem> GetAirLinesClasses(string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.AirLineClassesResource.SP_GetAirLinesClasses);
            db.AddInParameter(dbCommand, Resources.AirLineClassesResource.PARAM_QUERY, DbType.String, StrToSearch);
            List<ListItem> CatLineClassesList = new List<ListItem>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _catairlinclaid = dr.GetOrdinal(Resources.AirLineClassesResource.PARAM_CATAIRLINCLAID);
                int _catairlinclaname = dr.GetOrdinal(Resources.AirLineClassesResource.PARAM_CATAIRLINCLANAME);


                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value =dr.GetString(_catairlinclaid);
                    item.Text =string.Concat(dr.GetString(_catairlinclaid), ' ', dr.GetString(_catairlinclaname));
                    CatLineClassesList.Add(item);
                }
            }

            return CatLineClassesList;

        }
    }
}
