using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class InterJetFlightController
    {



        public static bool IsDirectFlight(string departure, string destination)
        {

            return InterJetPointToPointDAL.IsDirectFlight(departure, destination);
        }

        public static IEnumerable<string> GetDestination(string departure)
        {

            return InterJetPointToPointDAL.GetDestination(departure);
        }

        public static bool IsInternational(string departure, string destination)
        {
            return InterJetPointToPointDAL.IsInternational(departure, destination);
        }

        public static bool IsInterJetRoute(string departure,string destination)
        {
            return InterJetPointToPointDAL.IsInterJetRoute(departure,destination);
        }
    }
}
