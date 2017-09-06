using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class Promo
    {
        private string airline;
        public string Airline
        {
            get { return airline; }
            set { airline = value; }
        }

        private string typeCard;
        public string TypeCard
        {
            get { return typeCard; }
            set { typeCard = value; }
        }

        private string emissionBank;
        public string EmissionBank
        {
            get { return emissionBank; }
            set { emissionBank = value; }
        }

        private DateTime datePromoBegin;
        public DateTime DatePromoBegin
        {
            get { return datePromoBegin; }
            set { datePromoBegin = value; }
        }

        private DateTime datePromoEnd;
        public DateTime DatePromoEnd
        {
            get { return datePromoEnd; }
            set { datePromoEnd = value; }
        }

        private string monthsWithInterest;
        public string MonthsWithInterest
        {
            get { return monthsWithInterest; }
            set { monthsWithInterest = value; }
        }

        private string monthsWithoutInterest;
        public string MonthsWithoutInterest
        {
            get { return monthsWithoutInterest; }
            set { monthsWithoutInterest = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string amount;
        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private string origen;
        public string Origen
        {
            get { return origen; }
            set { origen = value; }
        }

        private string destination;
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        private string origenZone;
        public string OrigenZone
        {
            get { return origenZone; }
            set { origenZone = value; }
        }

        private string destinationZone;
        public string DestinationZone
        {
            get { return destinationZone; }
            set { destinationZone = value; }
        }

        private string countryEmission;
        public string CountryEmission
        {
            get { return countryEmission; }
            set { countryEmission = value; }
        }

        private bool sharedFlight;
        public bool SharedFlight
        {
            get { return sharedFlight; }
            set { sharedFlight = value; }
        }

        private string includedClasses;
        public string IncludedClasses
        {
            get { return includedClasses; }
            set { includedClasses = value; }
        }

        private string excludedClasses;
        public string ExcludedClasses
        {
            get { return excludedClasses; }
            set { excludedClasses = value; }
        }

        private bool applyDatePromoFlight;
        public bool ApplyDatePromoFlight
        {
            get { return applyDatePromoFlight; }
            set { applyDatePromoFlight = value; }
        }

    }
}
