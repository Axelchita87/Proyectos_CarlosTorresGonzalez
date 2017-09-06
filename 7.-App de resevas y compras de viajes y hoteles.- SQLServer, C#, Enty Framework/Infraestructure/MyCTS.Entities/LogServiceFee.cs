using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class LogServiceFee
    {
        public string id { get; set; }
        public string sRecLoc { get; set; }
        public string sCodigoTarjeta { get; set; }
        public string sNumTarjeta { get; set; }
        public string sMesVencimiento { get; set; }
        public string sAnioVencimiento { get; set; }
        public string sBanco { get; set; }      
        public string sMonto { get; set; }
        public DateTime dtDate { get; set; }
        public string sStatusAut { get; set; } 
        public string sNumOperacion { get; set; }
        public string sNumAutorizacion { get; set; }
        public string sBoletos { get; set; }
        public string sRemarks { get; set; }
    }
}
