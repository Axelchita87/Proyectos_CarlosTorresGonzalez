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
    public class CatCostCenterDAL
    {
        //public List<CatCostCenter> GetCostCenters(string DKToSearch, string StrToSearch)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatCostCentersResources.SP_GetCostCenters);
        //    db.AddInParameter(dbCommand, Resources.CatCostCentersResources.PARAM_QUERY, DbType.String, DKToSearch);
        //    db.AddInParameter(dbCommand, Resources.CatCostCentersResources.PARAM_QUERY2, DbType.String, StrToSearch);


        //    List<CatCostCenter> CatCostCenterList = new List<CatCostCenter>();

        //    using (IDataReader dr = db.ExecuteReader(dbCommand))
        //    {
        //        int _idcc = dr.GetOrdinal(Resources.CatCostCentersResources.PARAM_IDCC);
        //        int _ccname = dr.GetOrdinal(Resources.CatCostCentersResources.PARAM_CCNAME);


        //        while (dr.Read())
        //        {
        //            CatCostCenter item = new CatCostCenter();
        //            item.IDCC = dr.GetString(_idcc);
        //            item.CCName = (dr[_ccname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ccname);

        //            CatCostCenterList.Add(item);
        //        }
        //    }
        //    return CatCostCenterList;
        //}

        public List<ListItem> GetCostCenters(string DKToSearch, string StrToSearch, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.CatCostCentersResources.SP_GetCostCenters);
            db.AddInParameter(dbCommand, Resources.CatCostCentersResources.PARAM_QUERY, DbType.String, DKToSearch);
            db.AddInParameter(dbCommand, Resources.CatCostCentersResources.PARAM_QUERY2, DbType.String, StrToSearch);


            List<ListItem> CatCostCenterList = new List<ListItem>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                int _idcc = dr.GetOrdinal(Resources.CatCostCentersResources.PARAM_IDCC);
                int _ccname = dr.GetOrdinal(Resources.CatCostCentersResources.PARAM_CCNAME);


                while (dr.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = dr.GetString(_idcc);
                    item.Text = string.Concat((dr.GetString(_idcc)), ' ', ((dr[_ccname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ccname)));
                    //item.IDCC = dr.GetString(_idcc);
                    //item.CCName = (dr[_ccname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_ccname);

                    CatCostCenterList.Add(item);
                }
            }
            return CatCostCenterList;
        }
    }
}
