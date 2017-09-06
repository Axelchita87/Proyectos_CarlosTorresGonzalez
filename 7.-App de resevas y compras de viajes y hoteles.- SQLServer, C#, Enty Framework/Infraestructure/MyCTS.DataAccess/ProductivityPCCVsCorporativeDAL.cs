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
   public class ProductivityPCCVsCorporativeDAL
    {
        public List<ProductivityPCCVsCorporative> GetProductivityPCCVsCorporative(string PCC, string ProductivityDate, int IdType, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand(Resources.ProductivityPCCVsCorporativeResources.SP_GetProductivityPCCVsCorporative);
            db.AddInParameter(dbCommand, Resources.ProductivityPCCVsCorporativeResources.PARAM_QUERY, DbType.String, PCC);
            db.AddInParameter(dbCommand, Resources.ProductivityPCCVsCorporativeResources.PARAM_QUERY2, DbType.String, ProductivityDate);
            db.AddInParameter(dbCommand, Resources.ProductivityPCCVsCorporativeResources.PARAM_QUERY3, DbType.Int32, IdType);

            List<ProductivityPCCVsCorporative> ProductivityPCCVsCorporativeList = new List<ProductivityPCCVsCorporative>();

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {

                //int _familyname = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_FAMILYNAME);
                int _reportdate = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_REPORTDATE);

                int _labourdays1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_LABOURDAYS1);
                int _initialdate1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_INITIALDATE1);
                int _finaldate1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_FINALDATE1);
                int _airsegment1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AIRSEGMENT1);

                int _hotelsegment1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_HOTELSEGMENT1);
                int _autosegment1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AUTOSEGMENT1);
                int _totalsegment1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_TOTALSEGMENT1);

                int _totalpnr1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_TOTALPNR1);
                int _cancelledpnr1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_CANCELLEDPNR1);
                int _scansaverage1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_SCANSAVERAGE1);
                int _emittedtkt1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_EMITTEDTKT1);
                int _cancelledtkt1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_CANCELLEDTKT1);
                int _recordvsticket1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_RECORDSVSTICKET1);

                int _avgairsegment1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGAIRSEGMENT1);
                int _avghotelsegment1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGHOTELSEGMENT1);
                int _avgautosegment1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGAUTOSEGMENT1);
                int _avgtotalsegment1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGTOTALSEGMENT1);

                int _avgrecords1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGRECORDS1);
                int _avgcancelledrecords1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGCANCELLEDRECORDS1);
                int _avgscanavgperrecord1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGSCANAVGPERRECORD1);
                int _avgemittedtkt1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGEMITTEDTKT1);
                int _avgcancelledtkt1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGCANCELLEDTKT1);
                int _avgrecordvsticket1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGRECORDSVSTICKET1);

                int _airsegmentproductivity1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AIRSEGMENTPRODUCTIVITY1);
                int _hotelsegmentproductivity1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_HOTELSEGMENTPRODUCTIVITY1);
                int _autosegmentproductivity1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AUTOSEGMENTPRODUCTIVITY1);
                int _totalsegmentproductivity1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_TOTALSEGMENTPRODUCTIVITY1);
                int _recordsproductivity1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_RECORDSPRODUCTIVITY1);
                int _cancelledrecordsproductivity1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_CANCELLEDRECORDSPRODUCTIVITY1);
                int _avgscanperrecordproductivity1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGSCANPERRECORDPRODUCTIVITY1);
                int _emittedtktproductivity1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_EMITTEDTKTPRODUCTIVITY1);
                int _cancelledtktproductivity1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_CANCELLEDTKTPRODUCTIVITY1);
                int _totalrecordvstktproductivity1 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_TOTALRECORDSVSTKTPRODUCTIVITY1);


                int _labourdays2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_LABOURDAYS2);
                int _initialdate2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_INITIALDATE2);
                int _finaldate2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_FINALDATE2);
                int _airsegment2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AIRSEGMENT2);
                int _hotelsegment2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_HOTELSEGMENT2);
                int _autosegment2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AUTOSEGMENT2);
                int _totalsegment2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_TOTALSEGMENT2);
                int _totalpnr2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_TOTALPNR2);
                int _cancelledpnr2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_CANCELLEDPNR2);
                int _scansaverage2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_SCANSAVERAGE2);
                int _emittedtkt2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_EMITTEDTKT2);
                int _cancelledtkt2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_CANCELLEDTKT2);
                int _recordvsticket2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_RECORDSVSTICKET2);
                int _avgairsegment2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGAIRSEGMENT2);
                int _avghotelsegment2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGHOTELSEGMENT2);
                int _avgautosegment2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGAUTOSEGMENT2);
                int _avgtotalsegment2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGTOTALSEGMENT2);
                int _avgrecords2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGRECORDS2);
                int _avgcancelledrecords2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGCANCELLEDRECORDS2);
                int _avgscanavgperrecord2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGSCANAVGPERRECORD2);
                int _avgemittedtkt2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGEMITTEDTKT2);
                int _avgcancelledtkt2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGCANCELLEDTKT2);
                int _avgrecordvsticket2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGRECORDSVSTICKET2);
                int _airsegmentproductivity2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AIRSEGMENTPRODUCTIVITY2);
                int _hotelsegmentproductivity2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_HOTELSEGMENTPRODUCTIVITY2);
                int _autosegmentproductivity2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AUTOSEGMENTPRODUCTIVITY2);
                int _totalsegmentproductivity2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_TOTALSEGMENTPRODUCTIVITY2);
                int _recordsproductivity2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_RECORDSPRODUCTIVITY2);
                int _cancelledrecordsproductivity2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_CANCELLEDRECORDSPRODUCTIVITY2);
                int _avgscanperrecordproductivity2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AVGSCANPERRECORDPRODUCTIVITY2);
                int _emittedtktproductivity2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_EMITTEDTKTPRODUCTIVITY2);
                int _cancelledtktproductivity2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_CANCELLEDRECORDSPRODUCTIVITY2);
                int _totalrecordvstktproductivity2 = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_TOTALRECORDSVSTKTPRODUCTIVITY2);


                int _airsegmentproductivity = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AIRSEGMENTPRODUCTIVITY);
                int _hotelsegmentproductivity = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_HOTELSEGMENTPRODUCTIVITY);
                int _autosegmentproductivity = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_AUTOSEGMENTPRODUCTIVITY);
                int _totalsegmentproductivity = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_TOTALSEGMENTPRODUCTIVITY);
                int _totalrecordsproductivity = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_TOTALRECORDSPRODUCTIVITY);
                int _cancelledrecordsproductivity = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_CANCELLEDRECORDSPRODUCTIVITY);
                int _scansaverageproductivity = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_SCANSAVERAGEPRODUCTIVITY);
                int _emittedtktproductivity = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_EMITTEDTKTPRODUCTIVITY);
                int _cancelledtktproductivity = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_CANCELLEDRECORDSPRODUCTIVITY);
                int _recordvstktproductivity = dr.GetOrdinal(Resources.ProductivityPCCVsCorporativeResources.PARAM_RECORDSVSTKTPRODUCTIVITY);



                while (dr.Read())
                {
                    ProductivityPCCVsCorporative item = new ProductivityPCCVsCorporative();

                    //item.FamilyName = dr.GetString(_familyname);
                    item.ReportDate = dr.GetDateTime(_reportdate).ToString(CommonENT.DATE_FORMAT_DEFAULT);
                    //item.ReportDate = dr.GetString(_reportdate);

                    item.LabourDays1 = (dr[_labourdays1] == null) ? Types.IntegerNullValue : dr.GetInt32(_labourdays1);
                    item.LabourDays2 = (dr[_labourdays2] == null) ? Types.IntegerNullValue : dr.GetInt32(_labourdays2);
                    item.InitialDate1 = dr.GetDateTime(_initialdate1).ToString(CommonENT.DATE_FORMAT_DEFAULT);
                    //item.InitialDate1 = dr.GetString(_initialdate1);
                    item.FinalDate1 = dr.GetDateTime(_finaldate1).ToString(CommonENT.DATE_FORMAT_DEFAULT);
                    //item.FinalDate1 = dr.GetString(_finaldate1);
                    item.InitialDate2 = dr.GetDateTime(_initialdate2).ToString(CommonENT.DATE_FORMAT_DEFAULT);
                    //item.InitialDate2 = dr.GetString(_initialdate2);
                    item.FinalDate2 = dr.GetDateTime(_finaldate2).ToString(CommonENT.DATE_FORMAT_DEFAULT);
                    //item.FinalDate2 = dr.GetString(_finaldate2);
                    item.AirSegment1 = (dr[_airsegment1] == null) ? Types.IntegerNullValue : dr.GetInt32(_airsegment1);
                    item.AirSegment2 = (dr[_airsegment2] == null) ? Types.IntegerNullValue : dr.GetInt32(_airsegment2);
                    item.HotelSegment1 = (dr[_hotelsegment1] == null) ? Types.IntegerNullValue : dr.GetInt32(_hotelsegment1);
                    item.HotelSegment2 = (dr[_hotelsegment2] == null) ? Types.IntegerNullValue : dr.GetInt32(_hotelsegment2);
                    item.AutoSegment1 = (dr[_autosegment1] == null) ? Types.IntegerNullValue : dr.GetInt32(_autosegment1);
                    item.AutoSegment2 = (dr[_autosegment2] == null) ? Types.IntegerNullValue : dr.GetInt32(_autosegment2);
                    item.TotalSegment1 = (dr[_totalsegment1] == null) ? Types.IntegerNullValue : dr.GetInt32(_totalsegment1);
                    item.TotalSegment2 = (dr[_totalsegment2] == null) ? Types.IntegerNullValue : dr.GetInt32(_totalsegment2);

                    item.TotalPNR1 = (dr[_totalpnr1] == null) ? Types.IntegerNullValue : dr.GetInt32(_totalpnr1);
                    item.TotalPNR2 = (dr[_totalpnr2] == null) ? Types.IntegerNullValue : dr.GetInt32(_totalpnr2);
                    item.CancelledPNR1 = (dr[_cancelledpnr1] == null) ? Types.IntegerNullValue : dr.GetInt32(_cancelledpnr1);
                    item.CancelledPNR2 = (dr[_cancelledpnr2] == null) ? Types.IntegerNullValue : dr.GetInt32(_cancelledpnr2);
                    item.ScansAverage1 = (dr[_scansaverage1] == null) ? Types.IntegerNullValue : dr.GetInt32(_scansaverage1);
                    item.ScansAverage2 = (dr[_scansaverage2] == null) ? Types.IntegerNullValue : dr.GetInt32(_scansaverage2);
                    item.EmittedTKT1 = (dr[_emittedtkt1] == null) ? Types.IntegerNullValue : dr.GetInt32(_emittedtkt1);
                    item.EmittedTKT2 = (dr[_emittedtkt2] == null) ? Types.IntegerNullValue : dr.GetInt32(_emittedtkt2);
                    item.CancelledTKT1 = (dr[_cancelledtkt1] == null) ? Types.IntegerNullValue : dr.GetInt32(_cancelledtkt1);
                    item.CancelledTKT2 = (dr[_cancelledtkt2] == null) ? Types.IntegerNullValue : dr.GetInt32(_cancelledtkt2);
                    item.RecordVsTicket1 = (dr[_recordvsticket1] == null) ? Types.IntegerNullValue : dr.GetInt32(_recordvsticket1);
                    item.RecordVsTicket2 = (dr[_recordvsticket2] == null) ? Types.IntegerNullValue : dr.GetInt32(_recordvsticket2);


                    item.AvgAirSegment1 = (dr[_avgairsegment1] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgairsegment1);
                    item.AvgAirSegment2 = (dr[_avgairsegment2] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgairsegment2);
                    item.AvgHotelSegment1 = (dr[_avghotelsegment1] == null) ? Types.IntegerNullValue : dr.GetInt32(_avghotelsegment1);
                    item.AvgHotelSegment2 = (dr[_avghotelsegment2] == null) ? Types.IntegerNullValue : dr.GetInt32(_avghotelsegment2);
                    item.AvgAutoSegment1 = (dr[_avgautosegment1] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgautosegment1);
                    item.AvgAutoSegment2 = (dr[_avgautosegment2] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgautosegment2);
                    item.AvgTotalSegment1 = (dr[_avgtotalsegment1] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgtotalsegment1);
                    item.AvgTotalSegment2 = (dr[_avgtotalsegment2] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgtotalsegment2);


                    item.AvgRecords1 = (dr[_avgrecords1] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgrecords1);
                    item.AvgRecords2 = (dr[_avgrecords2] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgrecords2);
                    item.AvgCancelledRecords1 = (dr[_avgcancelledrecords1] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgcancelledrecords1);
                    item.AvgCancelledRecords2 = (dr[_avgcancelledrecords2] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgcancelledrecords2);
                    item.AvgScanAvgPerRecord1 = (dr[_avgscanavgperrecord1] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgscanavgperrecord1);
                    item.AvgScanAvgPerRecord2 = (dr[_avgscanavgperrecord2] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgscanavgperrecord2);
                    item.AvgEmittedTKT1 = (dr[_avgemittedtkt1] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgemittedtkt1);
                    item.AvgEmittedTKT2 = (dr[_avgemittedtkt2] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgemittedtkt2);
                    item.AvgCancelledTKT1 = (dr[_avgcancelledtkt1] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgcancelledtkt1);
                    item.AvgCancelledTKT2 = (dr[_avgcancelledtkt2] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgcancelledtkt2);
                    item.AvgRecordVsTicket1 = (dr[_avgrecordvsticket1] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgrecordvsticket1);
                    item.AvgRecordVsTicket2 = (dr[_avgrecordvsticket2] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgrecordvsticket2);
                    item.AirSegmentProductivity1 = (dr[_airsegmentproductivity1] == null) ? Types.IntegerNullValue : dr.GetInt32(_airsegmentproductivity1);
                    item.AirSegmentProductivity2 = (dr[_airsegmentproductivity2] == null) ? Types.IntegerNullValue : dr.GetInt32(_airsegmentproductivity2);
                    item.HotelSegmentProductivity1 = (dr[_hotelsegmentproductivity1] == null) ? Types.IntegerNullValue : dr.GetInt32(_hotelsegmentproductivity1);
                    item.HotelSegmentProductivity2 = (dr[_hotelsegmentproductivity2] == null) ? Types.IntegerNullValue : dr.GetInt32(_hotelsegmentproductivity2);
                    item.AutoSegmentProductivity1 = (dr[_autosegmentproductivity1] == null) ? Types.IntegerNullValue : dr.GetInt32(_autosegmentproductivity1);
                    item.AutoSegmentProductivity2 = (dr[_autosegmentproductivity2] == null) ? Types.IntegerNullValue : dr.GetInt32(_autosegmentproductivity2);
                    item.TotalSegmentProductivity1 = (dr[_totalsegmentproductivity1] == null) ? Types.IntegerNullValue : dr.GetInt32(_totalsegmentproductivity1);
                    item.TotalSegmentProductivity2 = (dr[_totalsegmentproductivity2] == null) ? Types.IntegerNullValue : dr.GetInt32(_totalsegmentproductivity2);
                    item.RecordsProductivity1 = (dr[_recordsproductivity1] == null) ? Types.IntegerNullValue : dr.GetInt32(_recordsproductivity1);
                    item.RecordsProductivity2 = (dr[_recordsproductivity2] == null) ? Types.IntegerNullValue : dr.GetInt32(_recordsproductivity2);
                    item.CancelledRecordsProductivity1 = (dr[_cancelledrecordsproductivity1] == null) ? Types.IntegerNullValue : dr.GetInt32(_cancelledrecordsproductivity1);
                    item.CancelledRecordsProductivity2 = (dr[_cancelledrecordsproductivity2] == null) ? Types.IntegerNullValue : dr.GetInt32(_cancelledrecordsproductivity2);
                    item.AvgScanPerRecordProductivity1 = (dr[_avgscanperrecordproductivity1] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgscanperrecordproductivity1);
                    item.AvgScanPerRecordProductivity2 = (dr[_avgscanperrecordproductivity2] == null) ? Types.IntegerNullValue : dr.GetInt32(_avgscanperrecordproductivity2);
                    item.EmittedTKTProductivity1 = (dr[_emittedtktproductivity1] == null) ? Types.IntegerNullValue : dr.GetInt32(_emittedtktproductivity1);
                    item.EmittedTKTProductivity2 = (dr[_emittedtktproductivity2] == null) ? Types.IntegerNullValue : dr.GetInt32(_emittedtktproductivity2);
                    item.CancelledTKTProductivity1 = (dr[_cancelledtktproductivity1] == null) ? Types.IntegerNullValue : dr.GetInt32(_cancelledtktproductivity1);
                    item.CancelledTKTProductivity2 = (dr[_cancelledtktproductivity2] == null) ? Types.IntegerNullValue : dr.GetInt32(_cancelledtktproductivity2);
                    item.TotalRecordVsTKTProductivity1 = (dr[_totalrecordvstktproductivity1] == null) ? Types.IntegerNullValue : dr.GetInt32(_totalrecordvstktproductivity1);
                    item.TotalRecordVsTKTProductivity2 = (dr[_totalrecordvstktproductivity2] == null) ? Types.IntegerNullValue : dr.GetInt32(_totalrecordvstktproductivity2);
                    item.AirSegmentProductivity = (dr[_airsegmentproductivity] == null) ? Types.IntegerNullValue : dr.GetInt32(_airsegmentproductivity);
                    item.HotelSegmentProductivity = (dr[_hotelsegmentproductivity] == null) ? Types.IntegerNullValue : dr.GetInt32(_hotelsegmentproductivity);
                    item.AutoSegmentProductivity = (dr[_autosegmentproductivity] == null) ? Types.IntegerNullValue : dr.GetInt32(_autosegmentproductivity);
                    item.TotalSegmentProductivity = (dr[_totalsegmentproductivity] == null) ? Types.IntegerNullValue : dr.GetInt32(_totalsegmentproductivity);
                    item.TotalRecordsProductivity = (dr[_totalrecordsproductivity] == null) ? Types.IntegerNullValue : dr.GetInt32(_totalrecordsproductivity);
                    item.CancelledRecordsProductivity = (dr[_cancelledrecordsproductivity] == null) ? Types.IntegerNullValue : dr.GetInt32(_cancelledrecordsproductivity);
                    item.ScansAverageProductivity = (dr[_scansaverageproductivity] == null) ? Types.IntegerNullValue : dr.GetInt32(_scansaverageproductivity);
                    item.EmittedTKTProductivity = (dr[_emittedtktproductivity] == null) ? Types.IntegerNullValue : dr.GetInt32(_emittedtktproductivity);
                    item.CancelledTKTProductivity = (dr[_cancelledtktproductivity] == null) ? Types.IntegerNullValue : dr.GetInt32(_cancelledtktproductivity);
                    item.RecordVsTKTProductivity = (dr[_recordvstktproductivity] == null) ? Types.IntegerNullValue : dr.GetInt32(_recordvstktproductivity);


                    ProductivityPCCVsCorporativeList.Add(item);

                }
            }

            return ProductivityPCCVsCorporativeList;
        }

    }
}
