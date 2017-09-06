using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Business;
using MyCTS.Entities;
using System.Threading;

namespace MyCTS.Services.Contracts
{
    public class InterJetAvailability : IAvailabilitySearchable
    {
        #region Miembros de IAvailabilitySearchable

        public Entities.AvailabilityRequest Request { get; set; }

        #endregion

        #region Miembros de IService<List<IFlight>>

        public List<Entities.IFlight> Call()
        {
            var serviceManager = new InterJetServiceManager();

            var flights = serviceManager.GetAvailability(Request).Cast<IFlight>().ToList();
            return flights;
        }

        #endregion

        #region Miembros de IAvailabilitySearchable


        public string CompanyName
        {
            get { return "InterJet"; }
        }

        #endregion
    }
}
