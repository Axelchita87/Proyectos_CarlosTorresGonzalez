using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class ReportVolaris
    {
        private string fecha;
        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private string volarisPNR;
        public string VolarisPNR
        {
            get { return volarisPNR; }
            set { volarisPNR = value; }
        }

        private string amount;
        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}
