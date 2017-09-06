using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public interface IPassanger
    {
        string FullName { get; set; }
        string ID { get; set; }

        bool IsNotAPassanger { get; set; }

        string Autorizacion { get; set; }
        string Operacion { get; set; }

    }
}
