using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCTS.Services.Contracts;

namespace Test.Services.Contracts
{
    [TestClass]
    public class GetInformationToDIXTest
    {
        [TestMethod]
        public void TravelItineraryMethodTest()
        {
            GetInformationToDIX getInformationdix = new GetInformationToDIX();

            string convid = "TestSession";
            string ipcc = "5IPC";
            string securitytoken = @"Shared/IDL:IceSess\/SessMgr:1\.0.IDL/Common/!ICESMS\/RESE!ICESMSLB\/RES.LB!-3596380841176999631!999852!0!1!E2E-1";
            string RecLoc = "WJMMCZ";


            GetInformationToDIX.GetInformationToDIXObject dixObject = getInformationdix.TravelItineraryMethod(convid, ipcc, securitytoken, RecLoc);
        }
    }
}
