using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class CxSHoteles
    {
        public DateTime FechaRegistro { get; set; }
        public string PNR { get; set; }
        public string TransaccionId { get; set; }
        public string Reservacion { get; set; }
        public string Factura { get; set; }
        public string Serie { get; set; }
        public string FacturaCargo { get; set; }
        public string SerieCargo { get; set; }
        public int OrganizacionId { get; set; }
        public int Id { get; set; }
        public string Autorization { get; set; }
        public string Operation { get; set; }
        public string NumeroTarjeta { get; set; }
        public string FormaDePago { get; set; }
        public decimal Monto { get; set; }
    }
}
