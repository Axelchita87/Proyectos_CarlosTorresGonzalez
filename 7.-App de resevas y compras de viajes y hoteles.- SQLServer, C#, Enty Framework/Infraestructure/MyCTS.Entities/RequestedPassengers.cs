using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class RequestedPassengers
    {


        public RequestedPassengers()
        {
            Adult = new RequestedPassanger();
            Senior = new RequestedPassanger();
            Child = new RequestedPassanger();
            Infant = new RequestedPassanger();

        }
        /// <summary>
        /// Gets or sets the adult.
        /// </summary>
        /// <value>
        /// The adult.
        /// </value>
        public RequestedPassanger Adult { get; set; }
        /// <summary>
        /// Gets or sets the senior.
        /// </summary>
        /// <value>
        /// The senior.
        /// </value>
        public RequestedPassanger Senior { get; set; }
        /// <summary>
        /// Gets or sets the child.
        /// </summary>
        /// <value>
        /// The child.
        /// </value>
        public RequestedPassanger Child { get; set; }
        /// <summary>
        /// Gets or sets the infant.
        /// </summary>
        /// <value>
        /// The infant.
        /// </value>
        public RequestedPassanger Infant { get; set; }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        public void Validate()
        {
            this.ValidateNumberOfPassanger();
        }

        /// <summary>
        /// Gets the total.
        /// </summary>
        public int Total
        {
            get
            {
                int totalOfPassangers = 0;
                totalOfPassangers += Adult.Count;
                totalOfPassangers += Senior.Count;
                totalOfPassangers += Child.Count;
                totalOfPassangers += Infant.Count;
                return totalOfPassangers;

            }
        }
        /// <summary>
        /// Gets the total of adults.
        /// </summary>
        private int TotalOfAdults
        {
            get { return Adult.Count + Senior.Count; }
        }

        /// <summary>
        /// Validates the number of passanger.
        /// </summary>
        private void ValidateNumberOfPassanger()
        {

            if (Total > 9)
            {
                throw new InvalidNumberOfPassangersExeception(
                    "El numero de pasajeros no puede ser mayor a 9 pasajeros por reserva.")
                          {
                              ErrorCode = ErrorCode.TooMannyPassangers
                          };
            }
            if (Total == 0)
            {
                throw new InvalidNumberOfPassangersExeception("No se ha ingresado el numero de pasajeros.")
                          {
                              ErrorCode = ErrorCode.NoPassangers
                          };
            }

            if (Infant.Count > TotalOfAdults)
            {
                throw new InvalidNumberOfPassangersExeception(
                    "El numero de pasajeros infantes es mayor que los pasajeros adultos.")
                          {
                              ErrorCode = ErrorCode.TooManyInfants
                          };
            }



        }
    }
}
