using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Services.Contracts.Volaris;
using MyCTS.Business;

namespace MyCTS.Services.Contracts
{
    public class VolarisAvailability : IAvailabilitySearchable
    {



        #region Miembros de IAvailabilitySearchable

        public Entities.AvailabilityRequest Request { get; set; }

        #endregion

        #region Miembros de IService<List<IFlight>>

        public List<Entities.IFlight> Call()
        {

            var volarisManager = new VolarisServiceManager();
            var flights = volarisManager.GetAvailability(Request);
            return flights;
            
           
        }

        #endregion

        #region Miembros de IAvailabilitySearchable


        public string CompanyName
        {
            get { return "Volaris"; }
        }

        #endregion
    }
}
