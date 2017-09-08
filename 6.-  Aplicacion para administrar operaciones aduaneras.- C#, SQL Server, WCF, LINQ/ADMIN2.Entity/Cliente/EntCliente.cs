using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN2.Entity
{
    [Serializable]
    public class EntCliente
    {
        #region Variables

        private int claveCliente;

        public int ClaveCliente
        {
            get { return claveCliente; }
            set { claveCliente = value; }
        }
        private string nombrecliente;

        public string Nombrecliente
        {
            get { return nombrecliente; }
            set { nombrecliente = value; }
        }
        private string nombreenvios;

        public string Nombreenvios
        {
            get { return nombreenvios; }
            set { nombreenvios = value; }
        }
        private string usuarioenvios;

        public string Usuarioenvios
        {
            get { return usuarioenvios; }
            set { usuarioenvios = value; }
        }
        private string direccionenvios;

        public string Direccionenvios
        {
            get { return direccionenvios; }
            set { direccionenvios = value; }
        }
        private string ciudadenvios;

        public string Ciudadenvios
        {
            get { return ciudadenvios; }
            set { ciudadenvios = value; }
        }
        private string coloniaenvios;

        public string Coloniaenvios
        {
            get { return coloniaenvios; }
            set { coloniaenvios = value; }
        }
        private string cpenvios;

        public string Cpenvios
        {
            get { return cpenvios; }
            set { cpenvios = value; }
        }
        private string telenvios;

        public string Telenvios
        {
            get { return telenvios; }
            set { telenvios = value; }
        }
        private string edoenvios;

        public string Edoenvios
        {
            get { return edoenvios; }
            set { edoenvios = value; }
        }
        private string emailenvios;

        public string Emailenvios
        {
            get { return emailenvios; }
            set { emailenvios = value; }
        }
        private string direccioncliente;

        public string Direccioncliente
        {
            get { return direccioncliente; }
            set { direccioncliente = value; }
        }
        private string coloniacliente;

        public string Coloniacliente
        {
            get { return coloniacliente; }
            set { coloniacliente = value; }
        }
        private string codigopostalcliente;

        public string Codigopostalcliente
        {
            get { return codigopostalcliente; }
            set { codigopostalcliente = value; }
        }
        private string ciudadcliente;

        public string Ciudadcliente
        {
            get { return ciudadcliente; }
            set { ciudadcliente = value; }
        }
        private string estadocliente;

        public string Estadocliente
        {
            get { return estadocliente; }
            set { estadocliente = value; }
        }
        private string facturacioncliente;

        public string Facturacioncliente
        {
            get { return facturacioncliente; }
            set { facturacioncliente = value; }
        }
        private string rfccliente;

        public string Rfccliente
        {
            get { return rfccliente; }
            set { rfccliente = value; }
        }
        private string telefono1cliente;

        public string Telefono1cliente
        {
            get { return telefono1cliente; }
            set { telefono1cliente = value; }
        }
        private string telefono2cliente;

        public string Telefono2cliente
        {
            get { return telefono2cliente; }
            set { telefono2cliente = value; }
        }
        private string atencionpersonal1cliente;

        public string Atencionpersonal1cliente
        {
            get { return atencionpersonal1cliente; }
            set { atencionpersonal1cliente = value; }
        }
        private int statuscliente;

        public int Statuscliente
        {
            get { return statuscliente; }
            set { statuscliente = value; }
        }
        private string ejecutivo;

        public string Ejecutivo
        {
            get { return ejecutivo; }
            set { ejecutivo = value; }
        }
        private string sectorcliente;

        public string Sectorcliente
        {
            get { return sectorcliente; }
            set { sectorcliente = value; }
        }
        private string emailcliente;

        public string Emailcliente
        {
            get { return emailcliente; }
            set { emailcliente = value; }
        }
        private int iguala;

        public int Iguala
        {
            get { return iguala; }
            set { iguala = value; }
        }
        private string ejecutivofact;

        public string Ejecutivofact
        {
            get { return ejecutivofact; }
            set { ejecutivofact = value; }
        }
        private string pais;

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }
        private string idRfcEua;

        public string IdRfcEua
        {
            get { return idRfcEua; }
            set { idRfcEua = value; }
        }
        private string emailSecEnvios;

        public string EmailSecEnvios
        {
            get { return emailSecEnvios; }
            set { emailSecEnvios = value; }
        }
        private string tipoVIP;

        public string TipoVIP
        {
            get { return tipoVIP; }
            set { tipoVIP = value; }
        }

        private int totalSucursal;
        public int TotalSucursal
        {
            get { return totalSucursal; }
            set { totalSucursal = value; }
        }

        private string fechaRegistro;

        public string FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }
        private string fechaMoficacion;

        public string FechaMoficacion
        {
            get { return fechaMoficacion; }
            set { fechaMoficacion = value; }
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

        public EntCliente()
        {
            claveCliente= 0;
            nombrecliente= string.Empty;
            nombreenvios= string.Empty;
            usuarioenvios= string.Empty;
            direccionenvios= string.Empty;
            ciudadenvios= string.Empty;
            coloniaenvios= string.Empty;
            cpenvios = string.Empty;
            telenvios= string.Empty;
            edoenvios  = string.Empty;
            emailenvios= string.Empty;
            direccioncliente= string.Empty;
            coloniacliente= string.Empty;
            codigopostalcliente= string.Empty;
            ciudadcliente= string.Empty;
            estadocliente= string.Empty;
            facturacioncliente= string.Empty;
            rfccliente= string.Empty;
            telefono1cliente= string.Empty;
            telefono2cliente= string.Empty;
            atencionpersonal1cliente= string.Empty;
            statuscliente= 0;
            ejecutivo= string.Empty;
            sectorcliente= string.Empty;
            emailcliente= string.Empty;
            iguala = 0;
            ejecutivofact= string.Empty;
            pais= string.Empty;
            idRfcEua= string.Empty;
            emailSecEnvios= string.Empty;
            tipoVIP= string.Empty;
            totalSucursal=0;
            fechaRegistro= string.Empty;
            fechaMoficacion= string.Empty;
            idUsuarioRegistro = 0;
            idUsuarioModifico = 0;
        }

        #endregion
    }
}
