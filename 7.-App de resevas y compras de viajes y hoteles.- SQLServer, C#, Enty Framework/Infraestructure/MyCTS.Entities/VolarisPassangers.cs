using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class VolarisPassangers
    {


        /// <summary>
        /// 
        /// </summary>
        private readonly List<IVolarisPassanger> _passangers;

        private VolarisReservation _reservation;
        /// <summary>
        /// Gets or sets the reservation.
        /// </summary>
        /// <value>
        /// The reservation.
        /// </value>
        public VolarisReservation Reservation
        {

            get { return _reservation; }
            set
            {

                _reservation = value;

                if (_passangers.Any())
                {
                    foreach (var volarisPassanger in _passangers)
                    {
                        volarisPassanger.Reservation = value;
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VolarisPassangers"/> class.
        /// </summary>
        public VolarisPassangers()
        {
            _passangers = new List<IVolarisPassanger>();


        }

        public bool IsTicketInUse(string ticket)
        {

            return _passangers.Any(p => !string.IsNullOrEmpty(p.eTicket) && p.eTicket.Equals(ticket));
        }
        /// <summary>
        /// Adds the specified passanger.
        /// </summary>
        /// <param name="passangers"> </param>
        public void Add(List<IVolarisPassanger> passangers)
        {


            foreach (var volarisPassanger in passangers)
            {
                var nextNumber = _passangers.Any() ? _passangers.Max(p => p.Number) + 1 : 1;
                volarisPassanger.Number = nextNumber;
                volarisPassanger.Reservation = Reservation;
                _passangers.Add(volarisPassanger);
            }


        }

        public void Add(IVolarisPassanger passanger)
        {
            Add(new List<IVolarisPassanger>() { passanger });
        }

        /// <summary>
        /// Removes the specified passanger.
        /// </summary>
        /// <param name="passanger">The passanger.</param>
        public void Remove(IVolarisPassanger passanger)
        {
            _passangers.Remove(passanger);

        }

        public void Clear()
        {

            if (_passangers.Any())
            {
                _passangers.Clear();
            }
        }


        public List<IVolarisPassanger> GetAll()
        {
            return _passangers;
        }
        public int GetTotalOfPassanger()
        {
            return GetAll().Count;
        }
        public List<IVolarisPassanger> GetAdultsAndChildren()
        {
            return _passangers.Where(p => !(p is VolarisInfantPassanger)).ToList();
        }

        public List<VolarisAdultPassanger> GetAdults()
        {

            return _passangers.Where(p => p is VolarisAdultPassanger).Cast<VolarisAdultPassanger>().ToList();

        }
        public int GetNumbreOfAdults()
        {

            return GetAdults().Count;

        }

        public bool HasAdults
        { get { return this.GetNumbreOfAdults() > 0; } }


        public List<VolarisChildPassanger> GetChildren()
        {

            return _passangers.Where(p => p is VolarisChildPassanger).Cast<VolarisChildPassanger>().ToList();

        }

        public int GetNumberOfChildren()
        {

            return GetChildren().Count;
        }

        public bool HasChildren
        {

            get { return this.GetNumberOfChildren() > 0; }
        }

        public List<VolarisInfantPassanger> GetInfants()
        {

            return _passangers.Where(p => p is VolarisInfantPassanger).Cast<VolarisInfantPassanger>().ToList();

        }

        public int GetNumberOfInfants()
        {

            return GetInfants().Count;
        }

        public bool HasInfants
        {
            get
            {
                return this.GetNumberOfInfants() > 0;
            }
        }

        public IVolarisPassanger SearchByPassangerNumber(int paxNumber)
        {

            if (_passangers.Any())
            {
                return _passangers.FirstOrDefault(p => p.Number == paxNumber);

            }
            return null;
        }


    }
}
