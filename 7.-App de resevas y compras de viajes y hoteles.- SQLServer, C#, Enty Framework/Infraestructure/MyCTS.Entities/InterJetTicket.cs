using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MyCTS.Entities
{
    public class InterJetTicket
    {
        public InterJetTicket()
        {
            Agent = new InterJetAgent
                        {
                            Ticket = this
                        };
            Flights = new InterJetFlights();
            Passangers = new InterJetPassangers();
            Remarks = new InterJetRemarks();
        }

        public InterJetRemarks Remarks { get; set; }

        public InterJetAgent Agent { get; set; }

        public InterJetFlights Flights
        {
            get;
            set;
        }
        public InterJetPassangers Passangers
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the record sabre.
        /// </summary>
        /// <value>
        /// The record sabre.
        /// </value>
        public string RecordSabre
        {
            get;
            set;

        }

        public int NumberOfAdults
        {
            get
            {
                if (Passangers != null)
                {
                    return Passangers.GetAdultsPassangers().Count;
                }
                return 0;
            }

        }

        public int NumberOfSeniorsAdult
        {
            get
            {

                if (Passangers != null)
                {
                    return Passangers.GetSeniorAdultsPassangers().Count;
                }
                return 0;
            }
        }

        public int NumberOfChildren
        {
            get
            {
                if (Passangers != null)
                {
                    return Passangers.GetChildrenPassangers().Count;
                }
                return 0;
            }
        }



        public List<InterJetDetailPriceMessage> DetailsMessages
        {
            get;
            set;
        }


        public InterJetContact Contact
        {
            get;
            set;
        }
        public string RecordLocator
        {
            get;
            set;
        }

        public decimal BalanceToPay
        {
            get;
            set;
        }

        private InterJetPassangerNumberRecord record;
        public InterJetPassangerNumberRecord PassangerNumberRecord
        {
            get
            {
                if (this.record == null)
                {
                    this.record = new InterJetPassangerNumberRecord();
                }
                return this.record;
            }
            set
            {
                this.record = value;
            }
        }

        public string PaymentForm
        {
            get;
            set;
        }
        public bool IsAprooved
        {
            get;
            set;
        }

        public bool IsDeclinade
        {
            get;
            set;
        }

        public bool IsFactured
        {
            get;
            set;
        }










    }
}
