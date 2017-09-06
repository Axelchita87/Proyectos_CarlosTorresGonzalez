using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class ExtrasViajeVolaris
    {
        public ExtrasViajeVolaris()
        {
        }

        public ExtrasViajeVolaris(string origen, string destino, int numeroPasajero, string codigoSSR)
        {
            Origen = origen;
            Destino = destino;
            NumeroPasajero = numeroPasajero;
            CodigoSSR = codigoSSR;
        }

        public string Destino { get; set; }
        public string Origen { get; set; }
        public int NumeroPasajero { get; set; }
        public string CodigoSSR { get; set; }
    }
}
