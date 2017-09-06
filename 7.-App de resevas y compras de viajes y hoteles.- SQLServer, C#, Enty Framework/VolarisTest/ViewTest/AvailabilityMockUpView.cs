using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Entities;
using MyCTS.Presentation.Reservations.Availability;

namespace VolarisTest.ViewTest
{
    public class AvailabilityMockUpView : IAvailabilityView
    {
        public string Name { get; set; }

        public void ValidateInput()
        {
            this.AvailabilityRequest.Validate();
            IsValid = true;
        }

        public bool IsValid
        { get; set; }

        public bool IsLowFare
        { get; set; }

        public bool IsSingleTrip
        { get; set; }

        public bool IsRoundTrip
        { get; set; }
        public DateTime DepartureDate
        { get; set; }
        public DateTime? ReturningDate
        { get; set; }

        public string DepartureStation
        { get; set; }
        public string ArrivalStation
        { get; set; }

        public int AdultsPassangers
        { get; set; }
        public int SeniorsPassangers
        { get; set; }

        public int ChildrenPassangers
        { get; set; }

        public int InfantPassangers
        { get; set; }

        public void HideRoundTripOption(bool hide)
        { }

        public void GotToNexStep()
        {
            
        }

        public AvailabilityRequest AvailabilityRequest
        {
            get
            {

                var availabilityRequest = new AvailabilityRequest();
                availabilityRequest.DepartureStation = this.DepartureStation;
                availabilityRequest.DepartureDateTime = this.DepartureDate;
                availabilityRequest.ArrivalStation = this.ArrivalStation;
                availabilityRequest.Pasengers.Adult.Count = this.AdultsPassangers;
                availabilityRequest.Pasengers.Senior.Count = this.SeniorsPassangers;
                availabilityRequest.Pasengers.Child.Count = this.ChildrenPassangers;
                availabilityRequest.Pasengers.Infant.Count = this.InfantPassangers;
                if (IsRoundTrip)
                {
                    availabilityRequest.BecomeRoundTrip();
                    availabilityRequest.ReturningDateTime = this.ReturningDate;
                }

                return availabilityRequest;
            }
            set
            {

            }

        }
    }
}
