using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCTS.Services.Contracts;
using System.Collections.Generic;

namespace Test.Services.Contracts
{
    [TestClass]
    public class OTATravelItineraryHotelsTest
    {
        [TestMethod]
        public void getHotelValues()
        {
            OTATravelItineraryHotels traveItinerary = new OTATravelItineraryHotels();
            string convid = "TestSession";
            string ipcc = "5IPC";
            string securitytoken = @"Shared/IDL:IceSess\/SessMgr:1\.0.IDL/Common/!ICESMS\/ACPCRTC!ICESMSLB\/CRT.LB!-3542560328249528447!935530!0!1!E2E-1";
            string RecLoc = "MWJKHB";
            //string RecLoc = "LUAMUE";
            string sixReceived = "Ricardo";
            string agente = "Ricardo";
            string mail = "ticbrito@gmail.com";
            string RFC = "BIOR870916CN3";
            List<string> lstcommission = new List<string>();

            //List<MyCTS.Entities.OTATravelItineraryObjectHotel> servicios = traveItinerary.getHotelValues(convid, ipcc, securitytoken, RecLoc, sixReceived, agente, mail, RFC, lstcommission);

        }
    }
}
