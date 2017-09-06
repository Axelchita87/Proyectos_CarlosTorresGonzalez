using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    /// <summary>
    /// Summary description for CreditCard
    /// </summary>
    public class MetodoPagoVolaris
    {
        public string TipoTarjeta { get; set; }
        public string Direccion { get; set; }
        public string NumeroTarjeta { get; set; }
        public string Ciudad { get; set; }
        public string CodigoSeguridad { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string Titular { get; set; }
        public string Apellido { get; set; }
        public string CodigoPais { get; set; }
        public string Telefono { get; set; }
        public string EstadoProvincia { get; set; }
        public string Email { get; set; }
        public string CodigoPostal { get; set; }
        public string NumeroAgencia { get; set; }
        public decimal Monto { get; set; }
        public string MetodoDePago { get; set; }
        public string Moneda { get; set; }
        public TiposVolaris.PaymentMethodType TipoMetodoPago { get; set; }

        public string IP { get; set; }
        public string BlackBox { get; set; }
    }
}
