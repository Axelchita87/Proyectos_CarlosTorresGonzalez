using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN2.Entity
{
    [Serializable]
    public class EntSectorCliente
    {
        #region Variables

        private int idSector;

        public int IdSector
        {
            get { return idSector; }
            set { idSector = value; }
        }
        private string sector;

        public string Sector
        {
            get { return sector; }
            set { sector = value; }
        }
        #endregion

        #region Constructor

        public EntSectorCliente()
        {
            idSector = 0;
            sector = string.Empty;
        }

        #endregion
    }
}
