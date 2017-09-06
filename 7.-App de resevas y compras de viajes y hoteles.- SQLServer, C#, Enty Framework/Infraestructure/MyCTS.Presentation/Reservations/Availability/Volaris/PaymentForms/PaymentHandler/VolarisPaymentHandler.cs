using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Services.Contracts.Volaris;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.PaymentForms.PaymentHandler
{
    public abstract class VolarisPaymentHandler
    {
        private VolarisServiceManager _serviceManager;

        public VolarisServiceManager ServiceManager
        {
            get { return _serviceManager ?? (_serviceManager = new VolarisServiceManager()); }
        }

        public abstract void Commit(VolarisReservation reservation);
    }
}
