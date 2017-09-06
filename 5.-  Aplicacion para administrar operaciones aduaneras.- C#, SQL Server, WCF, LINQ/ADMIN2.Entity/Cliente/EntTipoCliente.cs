using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN2.Entity
{
    [Serializable]
    public class EntTipoCliente
    {
        #region Variables
        private int idTipoCliente;
        public int IdTipoCliente
        {
            get { return idTipoCliente; }
            set { idTipoCliente = value; }
        }

        private string tipoCliente;
        public string TipoCliente
        {
            get { return tipoCliente; }
            set { tipoCliente = value; }
        }

        #endregion

        #region Constructor
        public EntTipoCliente()
        {
            idTipoCliente = 0;
            tipoCliente = string.Empty;
        }
        #endregion
    }
}
