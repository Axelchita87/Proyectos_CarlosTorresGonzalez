using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN2.Entity
{
    [Serializable]
    public class EntBitacora
    {
        #region Variables

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string accion;
        public string Accion
        {
            get { return accion; }
            set { accion = value; }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string fechaRegistro;
        public string FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        private int idSistema;
        public int IdSistema
        {
            get { return idSistema; }
            set { idSistema = value; }
        }

        #endregion

        #region Constructor

        public EntBitacora()
        {
            usuario= string.Empty;
            accion = string.Empty;
            descripcion = string.Empty;
            fechaRegistro = string.Empty;
            idSistema = 0;
        }

        public EntBitacora(int eIdSistema)
        {
            usuario = string.Empty;
            accion = string.Empty;
            descripcion = string.Empty;
            fechaRegistro = string.Empty;
            idSistema = eIdSistema;
        } 

        #endregion
    }
}
