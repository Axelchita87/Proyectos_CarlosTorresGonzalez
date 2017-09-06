using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class ErrorLogServiceCharge
    {
        public string StatusTransaccion { get; set; }
        public string MensajitoAmistoso { get; set; }
        public string NumeroAutorizacion { get; set; }
        public string NumeroOperacion { get; set; }
        public DateTime Fecha_creacion { get; set; }
    }
}
