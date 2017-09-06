using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN2.Entity
{
    [Serializable]
    public class EntPantalla
    {
        #region Variables

        private int idPantalla;
        public int IdPantalla
        {
            get { return idPantalla; }
            set { idPantalla = value; }
        }

        private int idSistema;
        public int IdSistema
        {
            get { return idSistema; }
            set { idSistema = value; }
        }

        private string modulo;
        public string Modulo
        {
            get { return modulo; }
            set { modulo = value; }
        }

        private string subMenu;
        public string SubMenu
        {
            get { return subMenu; }
            set { subMenu = value; }
        }

        private string pantalla;
        public string Pantalla
        {
            get { return pantalla; }
            set { pantalla = value; }
        }

        private string nombrePantalla;
        public string NombrePantalla
        {
            get { return nombrePantalla; }
            set { nombrePantalla = value; }
        }

        private int idPerfil;
        public int IdPerfil
        {
            get { return idPerfil; }
            set { idPerfil = value; }
        }

        private string rutaPantalla;
        public string RutaPantalla
        {
            get { return rutaPantalla; }
            set { rutaPantalla = value; }
        }
        

        #endregion

        #region Constructor

        public EntPantalla()
        {
            idPantalla = 0;
            idSistema = 0;
            modulo = string.Empty;
            subMenu = string.Empty;
            pantalla = string.Empty;
            nombrePantalla = string.Empty;
            idPerfil = 0;
            rutaPantalla = string.Empty;
        }

        #endregion

    }
}
