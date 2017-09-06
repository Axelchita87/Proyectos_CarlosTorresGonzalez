using System.Collections.Generic;
using MyCTS.DataAccess;
using MyCTS.Entities;
using System.Linq;

namespace MyCTS.Business
{
    public class InterJetPointToPointBL
    {

        private InterJetPointToPointDAL _dataAcces;

        private InterJetPointToPointDAL DataAcces
        {
            get{

                if(_dataAcces == null)
                {
                    _dataAcces = new InterJetPointToPointDAL();
                }
                return _dataAcces;
            }
        }

        public List<InterJetPointToPoint> GetPointToPointFlights()
        {

            return DataAcces.GetPointToPointDestinations();
        }

        public List<string> GetDestinations(string departureStation)
        {


            return null;

        }


    }
}
