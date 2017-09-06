using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN2.Entity
{
    [Serializable]
    public class EntUsuario : EntPerfil
    {
        #region Variables

        private int idUsuario;
        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string clave;
        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        private bool admin;
        public bool Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        private string origen;
        public string Origen
        {
            get { return origen; }
            set { origen = value; }
        }

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

        private string correoElectronico;
        public string CorreoElectronico
        {
            get { return correoElectronico; }
            set { correoElectronico = value; }
        }

        private int activo;
        public int Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        private string activoTexto;
        public string ActivoTexto
        {
            get { return activoTexto; }
            set { activoTexto = value; }
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

        private int idSistema;
        public int IdSistema
        {
            get { return idSistema; }
            set { idSistema = value; }
        }

        private string mensaje;
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        private int validaUsuario;
        public int ValidaUsuario
        {
            get { return validaUsuario; }
            set { validaUsuario = value; }
        }

        private string fechaModifico;
        public string FechaModifico
        {
            get { return fechaModifico; }
            set { fechaModifico = value; }
        }

        #endregion

        #region Constructor
        
        public EntUsuario()
        {
            idUsuario = 0;
            usuario = string.Empty;
            nombre= string.Empty;
            clave= string.Empty;
            admin = false;
            origen = string.Empty;
            idArea = 0;
            correoElectronico= string.Empty;
            activo = 0;
            idUsuarioRegistro =0;
            idUsuarioModifico = 0;
            idSistema = 0;
            mensaje = string.Empty;
            validaUsuario = 0;
            area = string.Empty;
            activoTexto = string.Empty;
            fechaModifico = string.Empty;
        }

        public EntUsuario(
            int vidUsuario,string vusuario,string vnombre,string vclave,bool vadmin,string vorigen,int vidArea,string vcorreoElectronico,
            int vactivo, int vidUsuarioRegistro, int vidUsuarioModifico, int vidSistema,string vmensaje ,int vvalidaUsuario,
            string vactivoTexto, string varea, string vfechaModifico)
        {
            idUsuario = vidUsuario;
            usuario = vusuario;
            nombre = vnombre;
            clave = vclave;
            admin = vadmin;
            origen = vorigen;
            idArea = vidArea;
            correoElectronico = vcorreoElectronico;
            activo = vactivo;
            idUsuarioRegistro = vidUsuarioRegistro;
            idUsuarioModifico = vidUsuarioModifico;
            idSistema = vidSistema;
            mensaje = vmensaje;
            validaUsuario = vvalidaUsuario;
            activoTexto = vactivoTexto;
            area = varea;
            fechaModifico = vfechaModifico;
        }

        #endregion
    }
}
