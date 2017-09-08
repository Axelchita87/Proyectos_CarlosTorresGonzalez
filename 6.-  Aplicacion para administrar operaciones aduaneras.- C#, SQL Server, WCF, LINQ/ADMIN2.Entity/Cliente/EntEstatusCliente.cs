using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN2.Entity
{
    [Serializable]
    public class EntEstatusCliente
    {
        #region Variables

        private int idEstatus;
        public int IdEstatus
        {
            get { return idEstatus; }
            set { idEstatus = value; }
        }

        private string estatus;
        public string Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }



        #endregion

        #region Constructor

        public EntEstatusCliente()
        {
            idEstatus = 0;
            estatus = string.Empty;
        } 

        #endregion
    }
}
