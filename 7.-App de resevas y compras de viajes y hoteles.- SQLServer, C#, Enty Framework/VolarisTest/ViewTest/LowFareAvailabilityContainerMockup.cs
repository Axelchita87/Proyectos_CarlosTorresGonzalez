using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability.LowFareAvailability.Container;

namespace VolarisTest.ViewTest
{
    public class LowFareAvailabilityContainerMockup : ILowFareAvailabilityViewContainer
    {


        public LowFareAvailabilityContainerMockup()
        {
            Fligths = new List<IFlight>();
        }
        #region Miembros de ILowFareAvailabilityViewContainer

        public string Name { get; set; }

        public bool IsValid
        {
            get;
            set;
        }

        public string Itinerary
        {
            get;
            set;
        }

        public string Date
        {
            get;
            set;
        }

        public List<IFlight> Fligths
        {
            get;
            set;
        }

        public MyCTS.Entities.IFlight SelectedFlight
        {
            get;
            set;
        }


        public bool FilterOK { get; set; }


        public void FilterByCompanyName(string CompanyName)
        {
            Fligths.Add(new VolarisFlight
                            {

                                ArrivalStation = "MEX",
                                ArrivalTime = DateTime.Now.AddHours(2),
                                DepartureStation = "CUN",
                                DepartureTime = DateTime.Now.AddHours(1),
                                BasePrice = 1500,
                                ID = "123",
                                OwnerCompany = "Volaris",


                            });


            //var fligth = Fligths.GetAll().FirstOrDefault(f => f.OwnerCompany.ToLower().Equals(CompanyName.ToLower()));

            //if (fligth != null)
            //{
            //    FilterOK = true;

            //}
        }


        public bool WentToNextControl { get; set; }

        #endregion

        #region Miembros de IBaseView


        /// <summary>
        /// Validates the input.
        /// </summary>
        public void ValidateInput()
        {
            ValidateSelectedFlight();
        }

        /// <summary>
        /// Validates the selected flight.
        /// </summary>
        private void ValidateSelectedFlight()
        {
            if (SelectedFlight == null)
            {
                throw new NoSelectedFlightException("No se ha seleccionado alfun vuelo disponible");
            }

            IsValid = true;


        }

        #endregion

        #region Miembros de ILowFareAvailabilityViewContainer


        public string TypeItinerary
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public AvailabilityRequest AvailabilityRequest
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public EventHandler OnSelectedFlight
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void SetError(Exception exception)
        {
            throw new NotImplementedException();
        }

        public void CleanError()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
