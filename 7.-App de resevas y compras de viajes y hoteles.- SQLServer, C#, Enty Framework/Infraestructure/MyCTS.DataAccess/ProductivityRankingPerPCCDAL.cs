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
    public class ProductivityRankingPerPCCDAL
    {
        public List<ProductivityRankingPerPCC> GetProductivityRankingPerPCC(int IdType, string ProductivityDate,string PCC, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbcommand = db.GetStoredProcCommand(Resources.ProductivityRankingPerPCCResources.SP_GetProductivityRankingPerPCC);
            db.AddInParameter(dbcommand, Resources.ProductivityRankingPerPCCResources.PARAM_QUERY, DbType.Int32, IdType);
            db.AddInParameter(dbcommand, Resources.ProductivityRankingPerPCCResources.PARAM_QUERY2, DbType.String, ProductivityDate);
            db.AddInParameter(dbcommand, Resources.ProductivityRankingPerPCCResources.PARAM_QUERY3, DbType.String, PCC);

            dbcommand.CommandTimeout = 60;
            List<ProductivityRankingPerPCC> ProductivityRankingPerPCCList = new List<ProductivityRankingPerPCC>();

            using (IDataReader dr = db.ExecuteReader(dbcommand))
            {
                int _initialdate = dr.GetOrdinal(Resources.ProductivityRankingPerCorporativeResources.PARAM_INITIALDATE);
                int _finaldate = dr.GetOrdinal(Resources.ProductivityRankingPerCorporativeResources.PARAM_FINALDATE);
                int _agent = dr.GetOrdinal(Resources.ProductivityRankingPerPCCResources.PARAM_AGENT);
                int _familyname = dr.GetOrdinal(Resources.ProductivityRankingPerPCCResources.PARAM_FAMILYNAME);
                int _airproductivity = dr.GetOrdinal(Resources.ProductivityRankingPerPCCResources.PARAM_AIRPRODUCTIVITY);
                int _hotelproductivity = dr.GetOrdinal(Resources.ProductivityRankingPerPCCResources.PARAM_HOTELPRODUCTIVITY);
                int _autoproductivity = dr.GetOrdinal(Resources.ProductivityRankingPerPCCResources.PARAM_AUTOPRODUCTIVITY);
                int _pnrproductivity = dr.GetOrdinal(Resources.ProductivityRankingPerPCCResources.PARAM_PNRPRODUCTIVITY);
                int _cancelledpnrproductivity = dr.GetOrdinal(Resources.ProductivityRankingPerPCCResources.PARAM_CANCELLEDPNRPRODUCTIVITY);
                int _avgscanperpnrproductivity = dr.GetOrdinal(Resources.ProductivityRankingPerPCCResources.PARAM_AVGSCANPERPNRPRODUCTIVITY);
                int _emittedtktproductivity = dr.GetOrdinal(Resources.ProductivityRankingPerPCCResources.PARAM_EMITTEDTKTPRODUCTIVITY);
                int _cancelledtktproductivity = dr.GetOrdinal(Resources.ProductivityRankingPerPCCResources.PARAM_CANCELLEDTKTPRODUCTIVITY);
                int _totalpnrvstktproductivity = dr.GetOrdinal(Resources.ProductivityRankingPerPCCResources.PARAM_TOTALPNRVSTKTPRODUCTIVITY);


                while (dr.Read())
                {
                    ProductivityRankingPerPCC item = new ProductivityRankingPerPCC();
                    item.InitialDate = dr.GetDateTime(_initialdate).ToString(CommonENT.DATE_FORMAT_DEFAULT);
                    //item.InitialDate = dr.GetString(_initialdate);
                    item.FinalDate = dr.GetDateTime(_finaldate).ToString(CommonENT.DATE_FORMAT_DEFAULT);
                    //item.FinalDate = dr.GetString(_finaldate);
                    item.Agent = (dr[_agent] == DBNull.Value) ? Types.StringNullValue : dr.GetString(_agent);
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

                    ProductivityRankingPerPCCList.Add(item);
                } 

            }

            return ProductivityRankingPerPCCList;
        }

    }
}
