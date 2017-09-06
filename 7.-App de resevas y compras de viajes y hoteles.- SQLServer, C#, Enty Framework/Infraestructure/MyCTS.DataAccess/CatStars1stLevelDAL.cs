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
    public class CatStars1stLevelDAL
    {
        public List<CatStars1stLevel> GetStars1stCatalog(int OrgId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatStars1stLevelResources.SP_GetStars1stLevelCatalog);
            db.AddInParameter(dbCommand, Resources.CatStars1stLevelResources.PARAM_ORG_ID, DbType.Int32, OrgId);

            List<CatStars1stLevel> Stars1List = new List<CatStars1stLevel>();
            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                int _pccid = dr.GetOrdinal(Resources.CatStars1stLevelResources.PARAM_PCCID);
                int _star1name = dr.GetOrdinal(Resources.CatStars1stLevelResources.PARAM_STARS1NAME);
                int _starl2exist = dr.GetOrdinal(Resources.CatStars1stLevelResources.PARAM_STARSL2EXIST);

                while (dr.Read())
                {
                    CatStars1stLevel item = new CatStars1stLevel();
                    item.Pccid = (dr[_pccid] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pccid);
                    item.Star1Name = (dr[_star1name] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_star1name);
                    item.StarL2Exist = dr.GetBoolean(_starl2exist);
                    Stars1List.Add(item);
                }
            }

            return Stars1List;
        }
    }
}
