using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCTS.Entities;
using MyCTS.Services.Contracts;
using System.Collections.Generic;

namespace MyCTS.Test.Services.Contracts
{
    [TestClass]
    public class OTATravelItineraryFlightsTest
    {
        [TestMethod]
        public void getResumen()
        {
            string convid = "TestSession";
            string ipcc = "5IPC";
            string securitytoken = @"Shared/IDL:IceSess\/SessMgr:1\.0.IDL/Common/!ICESMS\/ACPCRTD!ICESMSLB\/CRT.LB!-3552386521615696475!1658099!0!1!E2E-1";
            string RecLoc = "PMTBZK";
            string pcc = "3L64";

            //OTATravelItineraryFlights otaTravelItineraryFlights = new OTATravelItineraryFlights();
            //SCDCResumen scdcResumen = otaTravelItineraryFlights.getResumen(convid, ipcc, securitytoken, RecLoc, pcc);
        }



        [TestMethod]
        public void getBoleto()
        {
            string convid = "TestSession";
            string ipcc = "5IPC";
            string securitytoken = @"Shared/IDL:IceSess\/SessMgr:1\.0.IDL/Common/!ICESMS\/RESG!ICESMSLB\/RES.LB!-3561918243236667865!285318!0!1!E2E-1";
            string RecLoc = "POANXL";
            string pcc = "3L64";

            //OTATravelItineraryFlights otaTravelItineraryFlights = new OTATravelItineraryFlights();
            //List<SCDCBoleto> scdcBoletos = otaTravelItineraryFlights.getBoleto(convid, ipcc, securitytoken, RecLoc, pcc);
        }
    }
}
