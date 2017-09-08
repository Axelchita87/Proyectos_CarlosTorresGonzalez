using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ADMIN2.Entity
{
    [Serializable]
    public class Respuesta<T> : BaseRespuesta
    {
        /// <summary>
        /// Resultado obtenido en la ejecución del método en la capa de negocios.
        /// </summary>
        public T Resultado
        { get; set; }
        /// <summary>
    }
}
