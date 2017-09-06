using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class DatosPasajerosVolaris
    {
        public PasajerosVolaris AddPassenger { get; set; }
        public DateTime BirthDay { get; set; }

        public DatosPasajerosVolaris()
        {
        }

         public DatosPasajerosVolaris(PasajerosVolaris addPassenger, DateTime birthDay)
        {
            AddPassenger = addPassenger;
            BirthDay = birthDay;
        }

         
    }
}
