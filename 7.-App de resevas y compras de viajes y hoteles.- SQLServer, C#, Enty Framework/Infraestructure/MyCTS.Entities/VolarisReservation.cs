using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class VolarisReservation
    {

        /// <summary>
        /// 
        /// </summary>
        private VolarisPassangers _passangers;

        /// <summary>
        /// Gets or sets the passangers.
        /// </summary>
        /// <value>
        /// The passangers.
        /// </value>
        public VolarisPassangers Passangers
        {
            get { return _passangers; }
            set
            {
                _passangers = value;
                _passangers.Reservation = this;
            }
        }

        public VolarisProfile Profile { get; set; }


        /// <summary>
        /// 
        /// </summary>
        private VolarisItinerary _itinerary;

        /// <summary>
        /// Gets or sets the itinerary.
        /// </summary>
        /// <value>
        /// The itinerary.
        /// </value>
        public VolarisItinerary Itinerary
        {
            get { return _itinerary; }
            set
            {
                _itinerary = value;
                _itinerary.Reservation = this;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VolarisReservation"/> class.
        /// </summary>
        public VolarisReservation()
        {
            _passangers = new VolarisPassangers()
                              {

                              };
            _itinerary = new VolarisItinerary()
                             {
                                 Reservation = this
                             };
            Status = VolarisReservationStatus.None;
            RecordLocator = new VolarisRecordLocator();
            Payment = new VolarisPayment();
            CustomerDk = new VolarisCustomerDk();
            HostCommands = new VolarisHostCommands
                               {
                                   Reservation = this
                               };
            Remarks = new VolarisRemarks();
            Agent = new VolarisAgent
                        {
                            Reservation = this
                        };
            Profile = new VolarisProfile();
        }

        public VolarisAgent Agent { get; set; }
        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        /// <value>
        /// The contact.
        /// </value>
        public VolarisContact Contact { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public VolarisReservationStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the record locator.
        /// </summary>
        /// <value>
        /// The record locator.
        /// </value>
        public VolarisRecordLocator RecordLocator { get; set; }

        /// <summary>
        /// Gets or sets the payment.
        /// </summary>
        /// <value>
        /// The payment.
        /// </value>
        public VolarisPayment Payment { get; set; }
        /// <summary>
        /// Gets or sets the customer dk.
        /// </summary>
        /// <value>
        /// The customer dk.
        /// </value>
        public VolarisCustomerDk CustomerDk { get; set; }

        public VolarisHostCommands HostCommands { get; set; }

        public VolarisRemarks Remarks { get; set; }
    }
}
