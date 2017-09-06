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
    public class CatStars2ndLevelDAL
    {
        public List<CatStars2ndLevel> GetStars2ndCatalog(string connectionName)
        {
            var Stars2List = new List<CatStars2ndLevel>();
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionName);
                DbCommand dbCommand =
                    db.GetStoredProcCommand(Resources.CatStars2ndLevelResources.SP_GetStars2ndLevelCatalog);
                using (IDataReader dr = db.ExecuteReader(dbCommand))
                {

                    int _pccid = dr.GetOrdinal(Resources.CatStars2ndLevelResources.PARAM_PCCID);
                    int _star1id = dr.GetOrdinal(Resources.CatStars2ndLevelResources.PARAM_STAR1ID);
                    int _star2name = dr.GetOrdinal(Resources.CatStars2ndLevelResources.PARAM_STAR2NAME);

                    while (dr.Read())
                    {
                        CatStars2ndLevel item = new CatStars2ndLevel();
                        item.Pccid = (dr[_pccid] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_pccid);
                        item.Star1id = (dr[_star1id] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_star1id);
                        item.Star2Name = (dr[_star2name] == DBNull.Value)
                                             ? Types.StringNullValue
                                             : dr.GetString(_star2name);
                        Stars2List.Add(item);
                    }
                }
            }
            catch (Exception exe)
            {
                var exee = exe;
                var e = exee;
            }

            return Stars2List;
        }
    }
}
