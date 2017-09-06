using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SetDetailsPNRBL
    {
        public static void AddDetailsPNR(string recLoc, string origin, string destination, string departureTime,
            string arrivalTime, string airlineCode, string flightNumber, Nullable<DateTime> departureDate,
            string airlineRef, string traveldate,
            string location_dk, Nullable<Decimal> paxNumber, string paxType, string paxName, string paxLastName, string segmentType,
            string fareBasis, string pcc, string idGroup, string masterPNR)
        {
            SetDetailsPNRDAL objSetDetails = new SetDetailsPNRDAL();
            DateTime dtTravelDate;
            if (!DateTime.TryParse(traveldate, out dtTravelDate))
                dtTravelDate = Components.NullableHelper.Types.DateNullValue;

            try
            {
                objSetDetails.AddDetailsPNR(recLoc, origin, destination, departureTime, arrivalTime, airlineCode, flightNumber,
                    departureDate, airlineRef, dtTravelDate, location_dk, paxNumber, paxType, paxName,
                    paxLastName, segmentType, fareBasis, pcc, idGroup, masterPNR, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
            }
            catch (Exception ex)
            {
                try
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objSetDetails.AddDetailsPNR(recLoc, origin, destination, departureTime, arrivalTime, airlineCode, flightNumber,
                    departureDate, airlineRef, dtTravelDate, location_dk, paxNumber, paxType, paxName,
                    paxLastName, segmentType, fareBasis, pcc, idGroup, masterPNR, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }
                catch { }
            }
        }
    }
}
