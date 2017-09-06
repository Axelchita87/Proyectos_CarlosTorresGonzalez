using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace MyCTS.Entities
{
    public class InterJetAvailabilityUserInput
    {
        
        public string ArrivalStation
        {
            get;
            set;
        }
        public string DepartureStation
        {
            get;
            set;
        }
        public DateTime BeginDate
        {
            get;
            set;
        }
        public DateTime EndDate
        {
            get;
            set;
        }

        public string PaxResidentCountry
        {
            get;
            set;

        }

        public DateTime ReturningDate
        {
            get;
            set;
        }
        public bool IsOneWayTrip
        {
            get;
            set;
        }

        public bool IsRoundTrip
        {
            get;
            set;
        }

        public int AdultsPassangers
        {
            get;
            set;
        }

        public int SeniorsPassangers
        {
            get;
            set;
        }
        public int ChildsPassangers
        {
            get;
            set;
        }

        public int InfantsPassangers
        {
            get;
            set;
        }

        public string DepartureFlightInformation
        {
            get
            {
                return this.GetFlightInformation("SALIDA", this.BeginDate);
            }
        }


        private string GetFlightInformation(string action, DateTime dateOfDeparture)
        {
            CultureInfo cultureInfo = new CultureInfo("Es-MX");
            string dayofTheWeekInSpanish = cultureInfo.DateTimeFormat.GetDayName(dateOfDeparture.DayOfWeek);
            string monthInSpanish = cultureInfo.DateTimeFormat.GetMonthName(dateOfDeparture.Month);
            return string.Format("{4} : {0} {1},{2} {3}", dayofTheWeekInSpanish.ToUpper(), dateOfDeparture.Day, monthInSpanish.ToUpper(), dateOfDeparture.ToString("yyyy"), action);
        }

        public string DepartureFlightIntineraryInformation
        {
            get
            {
                return string.Format("{0} - {1} ", this.DepartureStation, this.ArrivalStation);

            }
        }

        public string ReturningFlightInformation
        {
            get
            {
                return this.GetFlightInformation("REGRESO", this.ReturningDate);
            }
        }

        public string ReturningFlightIntineraryInformation
        {
            get
            {
                return string.Format("{0} - {1} ", this.ArrivalStation, this.DepartureStation);
            }
        }

        public short PassangerCount
        {
            get
            {
                return Convert.ToInt16(this.AdultsPassangers + this.SeniorsPassangers + this.ChildsPassangers);
            }
        }


        public bool HasAdultsPassangers
        {
            get
            {
                return this.AdultsPassangers > 0;
            }
        }
        public bool HasSeniorsPassangers
        {
            get
            {
                return this.SeniorsPassangers > 0;
            }
        }
        public bool HasChildrenPassangers
        {
            get
            {
                return this.ChildsPassangers > 0;
            }
        }

        public bool HasInfantPassanger
        {
            get
            {
                return this.InfantsPassangers > 0;
            }
        }

        public bool IsInternationalItinerary { get; set; }
        public bool IsInternationalFlight
        {
            get
            {

                if (this.DepartureStation.Equals("SAT") && this.ArrivalStation.Equals("MEX"))
                {
                    return true;
                }

                if (this.DepartureStation.Equals("MEX") && this.ArrivalStation.Equals("SAT"))
                {
                    return true;
                }
                if (this.DepartureStation.Equals("TLC") && this.ArrivalStation.Equals("SAT"))
                {
                    return true;
                }
                if (this.DepartureStation.Equals("SAT") && this.ArrivalStation.Equals("TLC"))
                {
                    return true;
                }
                if (this.DepartureStation.Equals("MEX") && this.ArrivalStation.Equals("MIA"))
                {
                    return true;
                }

                if (this.DepartureStation.Equals("MIA") && this.ArrivalStation.Equals("MEX"))
                {
                    return true;
                }
                return false;
            }
        }


        public void Validate()
        {
            this.ValidatePassangers();


        }
        /// <summary>
        /// 
        /// </summary>
        private void ValidatePassangers()
        {

            int numberOfPassanger = this.AdultsPassangers + this.ChildsPassangers + this.SeniorsPassangers;

            if (numberOfPassanger <= 0)
            {
                throw new Exception("Por favor, indique el número de pasajeros.".ToUpper());
            }

            int adultPassangers = this.AdultsPassangers + this.SeniorsPassangers;

            if (this.InfantsPassangers > adultPassangers)
            {
                throw new Exception("Existen mas infantes que pasajeros adultos, solo es permitido un infante por pasajero adulto.".ToUpper());
            }

            if (this.PassangerCount > 9)
            {
                throw new Exception("El número maximo de pasajeros se ha excedido, solo es permitido hasta 9 pasajeros por vuelo.".ToUpper());
            }


        }





    }

}
