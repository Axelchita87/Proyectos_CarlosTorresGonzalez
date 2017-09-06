using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class CreditCardInfo
    {
        public string TipoTarjeta { get; set; }
        public string TipoTarjetaSabre { get; set; }
        public string NumeroTarjeta { get; set; }
        public string CodigoSeguridad { get; set; }
        public string MesVencimiento { get; set; }
        public string AnioVencimiento { get; set; }
        public string NombreTitular { get; set; }
        public bool Activo { get; set; }
        public bool Pagado { get; set; }
        public decimal MontoCargo { get; set; }
        public int PaxNumber { get; set; }
        public string PNR { get; set; }
        public string NumeroAutorizacion { get; set; }
        public string NumeroOperacion { get; set; }
        public string Remark { get; set; }
        private string tick;
        public string Ticket
        { 
            get { return tick; }
            set { tick= value;}
        }
        public string OrigenVenta { get; set; }
        public string MensajeError { get; set; }
    }
}
