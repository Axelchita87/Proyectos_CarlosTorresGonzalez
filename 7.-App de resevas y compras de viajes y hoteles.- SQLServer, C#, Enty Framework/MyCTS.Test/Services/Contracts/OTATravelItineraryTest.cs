using System;
using MyCTS.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Test.Services.Contracts
{
    [TestClass]
    public class OTATravelItineraryTest
    {
        [TestMethod]
        public void TravelItineraryMethodTest()
        {
            OTATravelItinerary otaTravelItinerary = new OTATravelItinerary();
            string convid = "TestSession";
            string ipcc = "5IPC";
            string securitytoken = @"Shared/IDL:IceSess\/SessMgr:1\.0.IDL/Common/!ICESMS\/CERTG!ICESMSLB\/CRT.LB!-3582489441614247771!1115462!0!1!E2E-1";
            string RecLoc = "MBWEVX";

            OTATravelItinerary.OTATravelItineraryObject otaTravelItineraryObject = otaTravelItinerary.TravelItineraryMethod(convid, ipcc, securitytoken, RecLoc);
        }
    }
}
