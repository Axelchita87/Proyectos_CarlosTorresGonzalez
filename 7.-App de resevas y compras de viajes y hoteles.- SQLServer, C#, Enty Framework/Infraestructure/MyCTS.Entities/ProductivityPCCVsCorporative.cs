using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class ProductivityPCCVsCorporative
    {
       
            private string familyname;
            public string FamilyName
            {
                get { return familyname; }
                set { familyname = value; }
            }

            private string reportdate;
            public string ReportDate
            {
                get { return reportdate; }
                set { reportdate = value; }
            }

            private int labourdays1;
            public int LabourDays1
            {
                get { return labourdays1; }
                set { labourdays1 = value; }
            }

            private int labourdays2;
            public int LabourDays2
            {
                get { return labourdays2; }
                set { labourdays2 = value; }
            }

            private string finaldate1;
            public string FinalDate1
            {
                get { return finaldate1; }
                set { finaldate1 = value; }
            }

            private string finaldate2;
            public string FinalDate2
            {
                get { return finaldate2; }
                set { finaldate2 = value; }
            }

            private string initialdate1;
            public string InitialDate1
            {
                get { return initialdate1; }
                set { initialdate1 = value; }
            }

            private string initialdate2;
            public string InitialDate2
            {
                get { return initialdate2; }
                set { initialdate2 = value; }
            }

            private int airsegment1;
            public int AirSegment1
            {
                get { return airsegment1; }
                set { airsegment1 = value; }
            }

            private int airsegment2;
            public int AirSegment2
            {
                get { return airsegment2; }
                set { airsegment2 = value; }
            }

            private int hotelsegment1;
            public int HotelSegment1
            {
                get { return hotelsegment1; }
                set { hotelsegment1 = value; }
            }

            private int hotelsegment2;
            public int HotelSegment2
            {
                get { return hotelsegment2; }
                set { hotelsegment2 = value; }
            }


            private int autosegment1;
            public int AutoSegment1
            {
                get { return autosegment1; }
                set { autosegment1 = value; }
            }

            private int autosegment2;
            public int AutoSegment2
            {
                get { return autosegment2; }
                set { autosegment2 = value; }
            }

            private int totalsegment1;
            public int TotalSegment1
            {
                get { return totalsegment1; }
                set { totalsegment1 = value; }
            }


            private int totalsegment2;
            public int TotalSegment2
            {
                get { return totalsegment2; }
                set { totalsegment2 = value; }
            }

            private int totalpnr1;
            public int TotalPNR1
            {
                get { return totalpnr1; }
                set { totalpnr1 = value; }
            }

            private int totalpnr2;
            public int TotalPNR2
            {
                get { return totalpnr2; }
                set { totalpnr2 = value; }
            }

            private int cancelledpnr1;
            public int CancelledPNR1
            {
                get { return cancelledpnr1; }
                set { cancelledpnr1 = value; }
            }

            private int cancelledpnr2;
            public int CancelledPNR2
            {
                get { return cancelledpnr2; }
                set { cancelledpnr2 = value; }
            }

            private int scansaverage1;
            public int ScansAverage1
            {
                get { return scansaverage1; }
                set { scansaverage1 = value; }
            }

            private int scansaverage2;
            public int ScansAverage2
            {
                get { return scansaverage2; }
                set { scansaverage2 = value; }
            }

            private int emittedtkt1;
            public int EmittedTKT1
            {
                get { return emittedtkt1; }
                set { emittedtkt1 = value; }
            }

            private int emittedtkt2;
            public int EmittedTKT2
            {
                get { return emittedtkt2; }
                set { emittedtkt2 = value; }
            }

            private int cancelledtkt1;
            public int CancelledTKT1
            {
                get { return cancelledtkt1; }
                set { cancelledtkt1 = value; }
            }

            private int cancelledtkt2;
            public int CancelledTKT2
            {
                get { return cancelledtkt2; }
                set { cancelledtkt2 = value; }
            }

            private int recordvsticket1;
            public int RecordVsTicket1
            {
                get { return recordvsticket1; }
                set { recordvsticket1 = value; }
            }

            private int recordvsticket2;
            public int RecordVsTicket2
            {
                get { return recordvsticket2; }
                set { recordvsticket2 = value; }
            }


            private int avgairsegment1;
            public int AvgAirSegment1
            {
                get { return avgairsegment1; }
                set { avgairsegment1 = value; }
            }

            private int avgairsegment2;
            public int AvgAirSegment2
            {
                get { return avgairsegment2; }
                set { avgairsegment2 = value; }
            }

            private int avghotelsegment1;
            public int AvgHotelSegment1
            {
                get { return avghotelsegment1; }
                set { avghotelsegment1 = value; }
            }

            private int avghotelsegment2;
            public int AvgHotelSegment2
            {
                get { return avghotelsegment2; }
                set { avghotelsegment2 = value; }
            }

            private int avgautosegment1;
            public int AvgAutoSegment1
            {
                get { return avgautosegment1; }
                set { avgautosegment1 = value; }
            }

            private int avgautosegment2;
            public int AvgAutoSegment2
            {
                get { return avgautosegment2; }
                set { avgautosegment2 = value; }
            }


            private int avgtotalsegment1;
            public int AvgTotalSegment1
            {
                get { return avgtotalsegment1; }
                set { avgtotalsegment1 = value; }
            }

            private int avgtotalsegment2;
            public int AvgTotalSegment2
            {
                get { return avgtotalsegment2; }
                set { avgtotalsegment2 = value; }
            }

            private int avgrecords1;
            public int AvgRecords1
            {
                get { return avgrecords1; }
                set { avgrecords1 = value; }
            }

            private int avgrecords2;
            public int AvgRecords2
            {
                get { return avgrecords2; }
                set { avgrecords2 = value; }
            }

            private int avgcancelledrecords1;
            public int AvgCancelledRecords1
            {
                get { return avgcancelledrecords1; }
                set { avgcancelledrecords1 = value; }
            }


            private int avgcancelledrecords2;
            public int AvgCancelledRecords2
            {
                get { return avgcancelledrecords2; }
                set { avgcancelledrecords2 = value; }
            }



            private int avgscanavgperrecord1;
            public int AvgScanAvgPerRecord1
            {
                get { return avgscanavgperrecord1; }
                set { avgscanavgperrecord1 = value; }
            }

            private int avgscanavgperrecord2;
            public int AvgScanAvgPerRecord2
            {
                get { return avgscanavgperrecord2; }
                set { avgscanavgperrecord2 = value; }
            }


            private int avgemittedtkt1;
            public int AvgEmittedTKT1
            {
                get { return avgemittedtkt1; }
                set { avgemittedtkt1 = value; }
            }

            private int avgemittedtkt2;
            public int AvgEmittedTKT2
            {
                get { return avgemittedtkt2; }
                set { avgemittedtkt2 = value; }
            }

            private int avgcancelledtkt1;
            public int AvgCancelledTKT1
            {
                get { return avgcancelledtkt1; }
                set { avgcancelledtkt1 = value; }
            }

            private int avgcancelledtkt2;
            public int AvgCancelledTKT2
            {
                get { return avgcancelledtkt2; }
                set { avgcancelledtkt2 = value; }
            }

            private int avgrecordvsticket1;
            public int AvgRecordVsTicket1
            {
                get { return avgrecordvsticket1; }
                set { avgrecordvsticket1 = value; }
            }

            private int avgrecordvsticket2;
            public int AvgRecordVsTicket2
            {
                get { return avgrecordvsticket2; }
                set { avgrecordvsticket2 = value; }
            }


            private int airsegmentproductivity1;
            public int AirSegmentProductivity1
            {
                get { return airsegmentproductivity1; }
                set { airsegmentproductivity1 = value; }
            }

            private int hotelsegmentproductivity1;
            public int HotelSegmentProductivity1
            {
                get { return hotelsegmentproductivity1; }
                set { hotelsegmentproductivity1 = value; }
            }

            private int autosegmentproductivity1;
            public int AutoSegmentProductivity1
            {
                get { return autosegmentproductivity1; }
                set { autosegmentproductivity1 = value; }
            }

            private int totalsegmentproductivity1;
            public int TotalSegmentProductivity1
            {
                get { return totalsegmentproductivity1; }
                set { totalsegmentproductivity1 = value; }
            }


            private int recordsproductivity1;
            public int RecordsProductivity1
            {
                get { return recordsproductivity1; }
                set { recordsproductivity1 = value; }
            }

            private int cancelledrecordsproductivity1;
            public int CancelledRecordsProductivity1
            {
                get { return cancelledrecordsproductivity1; }
                set { cancelledrecordsproductivity1 = value; }
            }

            private int avgscanperrecordproductivity1;
            public int AvgScanPerRecordProductivity1
            {
                get { return avgscanperrecordproductivity1; }
                set { avgscanperrecordproductivity1 = value; }
            }

            private int emittedtktproductivity1;
            public int EmittedTKTProductivity1
            {
                get { return emittedtktproductivity1; }
                set { emittedtktproductivity1 = value; }
            }

            private int cancelledtktproductivity1;
            public int CancelledTKTProductivity1
            {
                get { return cancelledtktproductivity1; }
                set { cancelledtktproductivity1 = value; }
            }

            private int totalrecordvstktproductivity1;
            public int TotalRecordVsTKTProductivity1
            {
                get { return totalrecordvstktproductivity1; }
                set { totalrecordvstktproductivity1 = value; }
            }

            ////////////////////////


            private int airsegmentproductivity2;
            public int AirSegmentProductivity2
            {
                get { return airsegmentproductivity2; }
                set { airsegmentproductivity2 = value; }
            }

            private int hotelsegmentproductivity2;
            public int HotelSegmentProductivity2
            {
                get { return hotelsegmentproductivity2; }
                set { hotelsegmentproductivity2 = value; }
            }

            private int autosegmentproductivity2;
            public int AutoSegmentProductivity2
            {
                get { return autosegmentproductivity2; }
                set { autosegmentproductivity2 = value; }
            }

            private int totalsegmentproductivity2;
            public int TotalSegmentProductivity2
            {
                get { return totalsegmentproductivity2; }
                set { totalsegmentproductivity2 = value; }
            }


            private int recordsproductivity2;
            public int RecordsProductivity2
            {
                get { return recordsproductivity2; }
                set { recordsproductivity2 = value; }
            }

            private int cancelledrecordsproductivity2;
            public int CancelledRecordsProductivity2
            {
                get { return cancelledrecordsproductivity2; }
                set { cancelledrecordsproductivity2 = value; }
            }

            private int avgscanperrecordproductivity2;
            public int AvgScanPerRecordProductivity2
            {
                get { return avgscanperrecordproductivity2; }
                set { avgscanperrecordproductivity2 = value; }
            }

            private int emittedtktproductivity2;
            public int EmittedTKTProductivity2
            {
                get { return emittedtktproductivity2; }
                set { emittedtktproductivity2 = value; }
            }

            private int cancelledtktproductivity2;
            public int CancelledTKTProductivity2
            {
                get { return cancelledtktproductivity2; }
                set { cancelledtktproductivity2 = value; }
            }

            private int totalrecordvstktproductivity2;
            public int TotalRecordVsTKTProductivity2
            {
                get { return totalrecordvstktproductivity2; }
                set { totalrecordvstktproductivity2 = value; }
            }

            /////////////////////////////

            private int airsegmentproductivity;
            public int AirSegmentProductivity
            {
                get { return airsegmentproductivity; }
                set { airsegmentproductivity = value; }
            }

            private int hotelsegmentproductivity;
            public int HotelSegmentProductivity
            {
                get { return hotelsegmentproductivity; }
                set { hotelsegmentproductivity = value; }
            }

            private int autosegmentproductivity;
            public int AutoSegmentProductivity
            {
                get { return autosegmentproductivity; }
                set { autosegmentproductivity = value; }
            }

            private int totalsegmentproductivity;
            public int TotalSegmentProductivity
            {
                get { return totalsegmentproductivity; }
                set { totalsegmentproductivity = value; }
            }

            private int totalrecordsproductivity;
            public int TotalRecordsProductivity
            {
                get { return totalrecordsproductivity; }
                set { totalrecordsproductivity = value; }
            }


            private int cancelledrecordsproductivity;
            public int CancelledRecordsProductivity
            {
                get { return cancelledrecordsproductivity; }
                set { cancelledrecordsproductivity = value; }
            }

            private int scansaverageproductivity;
            public int ScansAverageProductivity
            {
                get { return scansaverageproductivity; }
                set { scansaverageproductivity = value; }
            }

            private int emittedtktproductivity;
            public int EmittedTKTProductivity
            {
                get { return emittedtktproductivity; }
                set { emittedtktproductivity = value; }
            }

            private int cancelledtktproductivity;
            public int CancelledTKTProductivity
            {
                get { return cancelledtktproductivity; }
                set { cancelledtktproductivity = value; }
            }

            private int recordvstktproductivity;
            public int RecordVsTKTProductivity
            {
                get { return recordvstktproductivity; }
                set { recordvstktproductivity = value; }
            }


        
    }
}
