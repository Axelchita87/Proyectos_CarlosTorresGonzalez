using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class ImpuestosBajoCosto
    {
        public static string Id { get; set; }
        public static string ImpuestosObtenidos { get; set; }
        public static string ImpuestosMostrados { get; set; }
        public static string PNRBajoCosto { get; set; }
        public static string LineaContable { get; set; }
        public static string PNRSabre { get; set; }
        public static DateTime FechaCreacion { get; set; }

        public static bool continuePayment { get; set; }

    }
}
