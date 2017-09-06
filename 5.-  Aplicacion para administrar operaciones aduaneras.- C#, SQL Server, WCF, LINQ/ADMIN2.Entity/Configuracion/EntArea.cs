using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN2.Entity
{
    [Serializable]
    public class EntArea
    {
        #region Variables

        private int idArea;
        public int IdArea
        {
            get { return idArea; }
            set { idArea = value; }
        }

        private string area;   
        public string Area
        {
            get { return area; }
            set { area = value; }
        }

        private string abreviatura;
        public string Abreviatura
        {
            get { return abreviatura; }
            set { abreviatura = value; }
        }
        
        #endregion

        #region Constructor

        public EntArea()
        {
            idArea = 0;
            area = string.Empty;
            abreviatura = string.Empty;
        }
        
        #endregion
    }
}
