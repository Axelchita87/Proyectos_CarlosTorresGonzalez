using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN2.Entity
{
    [Serializable]
    public class EntTipoDocumento
    {
        #region Variables

        private int idDocumento;

        public int IdDocumento
        {
            get { return idDocumento; }
            set { idDocumento = value; }
        }
        private string documento;

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }
        private string rutaOrigen;

        public string RutaOrigen
        {
            get { return rutaOrigen; }
            set { rutaOrigen = value; }
        }
        private string rutaDestino;

        public string RutaDestino
        {
            get { return rutaDestino; }
            set { rutaDestino = value; }
        }
        private string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }
        private string nombreDocumento;

        public string NombreDocumento
        {
            get { return nombreDocumento; }
            set { nombreDocumento = value; }
        }

        #endregion

        #region Constructor

        public EntTipoDocumento()
        {
            idDocumento = 0;
            documento = string.Empty;
            rutaOrigen= string.Empty;
            rutaDestino= string.Empty;
            observaciones = string.Empty;
            nombreDocumento = string.Empty;
        }
        #endregion

    }
}
