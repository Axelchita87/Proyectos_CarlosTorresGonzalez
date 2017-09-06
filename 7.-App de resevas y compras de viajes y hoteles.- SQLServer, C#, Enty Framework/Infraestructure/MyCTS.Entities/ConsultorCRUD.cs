using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class ConsultorCRUD
    {
        public ConsultorCRUD()
        {

        }

        public ConsultorCRUD(string consultor, int? agente, string pcc, string status)
        {
            Consultor = consultor;
            Agent = agente;
            PCC = pcc;
            Status = status;
        }

        public string Consultor { get; set; }
        public int? Agent { get; set; }
        public string Status { get; set; }
        public string PCC { get; set; }
    }
}
