using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ADMIN2.Entity
{
    [Serializable]
    public class BaseRespuesta
    {
        public BaseRespuesta()
        {
            EsExitoso = false;
            MensajeUsuario = string.Empty;
            Error = string.Empty;
        }

        /// <summary>
        /// Total de registros.
        /// </summary>
        public int TotalRegistros
        { get; set; }

        /// <summary>
        /// Indica si la ejecución del método fue exitosa.
        /// </summary>
        public bool EsExitoso
        { get; set; }

        /// <summary>
        /// Mensaje que se mostrará al usuario de error.
        /// </summary>
        public string MensajeUsuario
        { get; set; }

        /// <summary>
        /// Excepción generada.
        /// </summary>
        public string Error
        { get; set; }
        
        /// <summary>
        /// Mensaje que se mostrará al usuario al crear validar si el usuario puede ser eliminado o no
        /// </summary>
        public bool MensajeEliminacion
        { get; set; }

        /// <summary>
        /// Inicializa errores.
        /// </summary>
        /// <param name="errorUsuario">Error amigable que se muestra en pantalla.</param>
        /// <param name="excepcion">Error generado para el desarrollador.</param>
        public void InicializaError(string errorUsuario = null, Exception excepcion = null)
        {
            string mensajeUsuario = string.Empty;
            string mensajeExcepcion = string.Empty;

            mensajeExcepcion = excepcion == null ?
                string.Empty : (excepcion.InnerException != null ?
                    excepcion.InnerException.Message : excepcion.Message);
            mensajeUsuario = string.IsNullOrEmpty(errorUsuario) ? string.Empty : errorUsuario;

            Error = string.IsNullOrEmpty(Error) ? mensajeExcepcion : string.Format("{0}{1}", Error, mensajeExcepcion);

            MensajeUsuario = string.IsNullOrEmpty(MensajeUsuario) ?
                mensajeUsuario : string.Format("{0}{1}", MensajeUsuario, mensajeUsuario);
        }

        /// <summary>
        /// Inicializa errores.
        /// </summary>
        /// <param name="errorUsuario">Error amigable que se muestra en pantalla.</param>
        /// <param name="errorExcepcion">Error generado para el desarrollador.</param>
        public void InicializaError(string mensajeUsuario, string errorExcepcion = null)
        {
            string usuario = string.Empty;
            string mensajeExcepcion = string.Empty;

            mensajeExcepcion = string.IsNullOrEmpty(errorExcepcion) ? string.Empty : errorExcepcion;
            usuario = string.IsNullOrEmpty(mensajeUsuario) ? string.Empty : mensajeUsuario;

            Error = string.IsNullOrEmpty(Error) ? mensajeExcepcion : string.Format("{0}{1}", Error, mensajeExcepcion);

            MensajeUsuario = string.IsNullOrEmpty(MensajeUsuario) ?
                usuario : string.Format("{0}{1}", MensajeUsuario, usuario);

          
        }

    }
}
