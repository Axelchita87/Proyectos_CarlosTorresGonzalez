using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class InterJetReport
    {
        private string fecha;
        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private string tipo_reporte;
        public string Tipo_reporte
        {
            get { return tipo_reporte; }
            set { tipo_reporte = value; }
        }

        private string amount;
        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}
