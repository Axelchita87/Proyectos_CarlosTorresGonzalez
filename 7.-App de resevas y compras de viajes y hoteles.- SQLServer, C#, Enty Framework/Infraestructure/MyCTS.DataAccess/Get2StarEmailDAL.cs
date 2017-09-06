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
    public class Get2StarEmailDAL
    {
        public List<Star2Details> Get2StarEmail(string SearchEmail, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.Get2StarEmailResources.SP_Get2StarEmail);
            db.AddInParameter(dbCommand, Resources.Get2StarEmailResources.PARAM_EMAIL, DbType.String, SearchEmail);
            
            List<Star2Details> star2List = new List<Star2Details>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _value = dr.GetOrdinal(Resources.Get2StarEmailResources.PARAM_VALUE);
                int _level1 = dr.GetOrdinal(Resources.Get2StarEmailResources.PARAM_LEVEL1);
            

                try
                {
                    while (dr.Read())
                    {
                        Star2Details item = new Star2Details();
                        item.Name = (dr[_value] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_value);
                        item.Level1 = (dr[_level1] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_level1);
                        star2List.Add(item);
                    }
                }
                catch
                {}
            }

            return star2List;
        }
    }
}
