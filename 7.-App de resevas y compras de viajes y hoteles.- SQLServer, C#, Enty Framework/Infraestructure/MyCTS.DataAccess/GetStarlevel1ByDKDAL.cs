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
    public class GetStarlevel1ByDKDAL
    {
        public List<Star1stLevelInfo> ObjGetStar1ByDk(string customerDk, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.GetStarLevel1ByDk.SP_GetStar1profileByDk);
            db.AddInParameter(dbCommand, Resources.GetStarLevel1ByDk.PARAM_dk, DbType.String, customerDk);
          

            var objStar1StLevelInfoList = new List<Star1stLevelInfo>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {                
                int _level1 = dr.GetOrdinal(Resources.Star1stLevelInfoResources.PARAM_LEVEL1);
               
                while (dr.Read())
                {
                    Star1stLevelInfo item = new Star1stLevelInfo();
                    
                    item.Level1 = (dr[_level1] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_level1);
                    
                    objStar1StLevelInfoList.Add(item);
                }
            }

            return objStar1StLevelInfoList;
        }
    }
}
