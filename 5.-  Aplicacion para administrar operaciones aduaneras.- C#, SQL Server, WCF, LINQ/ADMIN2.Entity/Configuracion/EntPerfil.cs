using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN2.Entity
{
    [Serializable]
    public class EntPerfil: EntPantalla
    {
        #region Variables
        private int idPerfil;
        public int IdPerfil
        {
            get { return idPerfil; }
            set { idPerfil = value; }
        }

        private string perfil;
        public string Perfil
        {
            get { return perfil; }
            set { perfil = value; }
        }
        
        private int idPermiso;
        public int IdPermiso
        {
            get { return idPermiso; }
            set { idPermiso = value; }
        }

        private int idSistema;
        public int IdSistema
        {
            get { return idSistema; }
            set { idSistema = value; }
        }

        private int idUsuario;
        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        private bool _ST_C_AP_LEER;
        public bool ST_C_AP_LEER
        {
            get { return _ST_C_AP_LEER; }
            set { _ST_C_AP_LEER = value; }
        }

        private bool _ST_C_AP_LEERYESCRIBIR;
        public bool ST_C_AP_LEERYESCRIBIR
        {
            get { return _ST_C_AP_LEERYESCRIBIR; }
            set { _ST_C_AP_LEERYESCRIBIR = value; }
        }

        private int idUsuarioRegistro;
        public int IdUsuarioRegistro
        {
            get { return idUsuarioRegistro; }
            set { idUsuarioRegistro = value; }
        }

        private int idUsuarioModifico;

        public int IdUsuarioModifico
        {
            get { return idUsuarioModifico; }
            set { idUsuarioModifico = value; }
        }

        #endregion

        #region Constructor

        public EntPerfil()
        {
            idPerfil = 0;
            perfil = string.Empty;
            idPermiso = 0;
            idSistema=0;
            idUsuario = 0;
            ST_C_AP_LEER = false;
            ST_C_AP_LEERYESCRIBIR = false;
            idUsuarioRegistro = 0;
            idUsuarioModifico = 0;
        }

        public EntPerfil(int vidPerfil, string vperfil, int vidPermiso, int vidSistema, int vidUsuario)
        {
            idPerfil = vidPerfil;
            perfil = vperfil;
            idPermiso = vidPermiso;
            idSistema = vidSistema;
            idUsuario = vidUsuario;
        }

        #endregion
    }
}
