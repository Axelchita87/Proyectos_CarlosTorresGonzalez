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
    public class ProductivityRankingPerCorporativeDAL
    {
        public List<ProductivityRankingPerCorporative> GetProductivityRankingPerCorporative(int IdType, string ProductivityDate, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.ProductivityRankingPerCorporativeResources.SP_GetProductivityRankingPerCorporative);
            db.AddInParameter(dbcommand, Resources.ProductivityRankingPerCorporativeResources.PARAM_QUERY, DbType.Int32, IdType);
            db.AddInParameter(dbcommand, Resources.ProductivityRankingPerCorporativeResources.PARAM_QUERY2, DbType.String, ProductivityDate);
            dbcommand.CommandTimeout = 60;
            List<ProductivityRankingPerCorporative> ProductivityRankingPerCorporativeList = new List<ProductivityRankingPerCorporative>();

            using (IDataReader dr = db.ExecuteReader(dbcommand))
            {
                int _initialdate = dr.GetOrdinal(Resources.ProductivityRankingPerCorporativeResources.PARAM_INITIALDATE);
                int _finaldate = dr.GetOrdinal(Resources.ProductivityRankingPerCorporativeResources.PARAM_FINALDATE);
                int _agent = dr.GetOrdinal(Resources.ProductivityRankingPerCorporativeResources.PARAM_AGENT);
                int _familyname = dr.GetOrdinal(Resources.ProductivityRankingPerCorporativeResources.PARAM_FAMILYNAME);
                int _airproductivity=dr.GetOrdinal(Resources.ProductivityRankingPerCorporativeResources.PARAM_AIRPRODUCTIVITY);
                int _hotelproductivity=dr.GetOrdinal(Resources.ProductivityRankingPerCorporativeResources.PARAM_HOTELPRODUCTIVITY);
                int _autoproductivity=dr.GetOrdinal(Resources.ProductivityRankingPerCorporativeResources.PARAM_AUTOPRODUCTIVITY);
                int _pnrproductivity=dr.GetOrdinal(Resources.ProductivityRankingPerCorporativeResources.PARAM_PNRPRODUCTIVITY);
                int _cancelledpnrproductivity=dr.GetOrdinal(Resources.ProductivityRankingPerCorporativeResources.PARAM_CANCELLEDPNRPRODUCTIVITY);
                int _avgscanperpnrproductivity=dr.GetOrdinal(Resources.ProductivityRankingPerCorporativeResources.PARAM_AVGSCANPERPNRPRODUCTIVITY);
                int _emittedtktproductivity=dr.GetOrdinal(Resources.ProductivityRankingPerCorporativeResources.PARAM_EMITTEDTKTPRODUCTIVITY);
                int _cancelledtktproductivity=dr.GetOrdinal(Resources.ProductivityRankingPerCorporativeResources.PARAM_CANCELLEDTKTPRODUCTIVITY);
                int _totalpnrvstktproductivity = dr.GetOrdinal(Resources.ProductivityRankingPerCorporativeResources.PARAM_TOTALPNRVSTKTPRODUCTIVITY);


                while (dr.Read())
                {
                    ProductivityRankingPerCorporative item = new ProductivityRankingPerCorporative();
                    item.InitialDate = dr.GetDateTime(_initialdate).ToString(CommonENT.DATE_FORMAT_DEFAULT);
                    //item.InitialDate = dr.GetString(_initialdate);
                    item.FinalDate = dr.GetDateTime(_finaldate).ToString(CommonENT.DATE_FORMAT_DEFAULT);
                    //item.FinalDate = dr.GetString(_finaldate);
                    item.Agent= (dr[_agent] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_agent);
                    item.FamilyName = (dr[_familyname] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_familyname);
                    item.AirProductivity = (dr[_airproductivity] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_airproductivity);
                    item.HotelProductivity = (dr[_hotelproductivity] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_hotelproductivity);
                    item.AutoProductivity = (dr[_autoproductivity] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_autoproductivity);
                    item.PNRProductivity = (dr[_pnrproductivity] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_pnrproductivity);
                    item.CancelledPNRProductivity = (dr[_cancelledpnrproductivity] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_cancelledpnrproductivity);
                    item.AvgScanPerPNRProductivity = (dr[_avgscanperpnrproductivity] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_avgscanperpnrproductivity);
                    item.EmittedTKTProductivity = (dr[_emittedtktproductivity] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_emittedtktproductivity);
                    item.CancelledTKTProductivity = (dr[_cancelledtktproductivity] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_cancelledtktproductivity);
                    item.TotalPNRVsTKTProductivity = (dr[_totalpnrvstktproductivity] == DBNull.Value) ? Types.IntegerNullValue : dr.GetInt32(_totalpnrvstktproductivity);

                    ProductivityRankingPerCorporativeList.Add(item);
                }

            }

            return ProductivityRankingPerCorporativeList;
        }

    }
}
