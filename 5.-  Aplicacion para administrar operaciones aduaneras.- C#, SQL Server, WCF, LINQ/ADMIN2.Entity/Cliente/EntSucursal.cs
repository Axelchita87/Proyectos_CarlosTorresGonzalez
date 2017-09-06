using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN2.Entity
{
    [Serializable]
    public class EntSucursal
    {
        #region Variables

        private int clave_cliente;

        public int Clave_cliente
        {
            get { return clave_cliente; }
            set { clave_cliente = value; }
        }
        private int nsucursal;

        public int Nsucursal
        {
            get { return nsucursal; }
            set { nsucursal = value; }
        }
        private string sucursal;

        public string Sucursal
        {
            get { return sucursal; }
            set { sucursal = value; }
        }
        private string factura_sucursal;

        public string Factura_sucursal
        {
            get { return factura_sucursal; }
            set { factura_sucursal = value; }
        }
        private string direccion_sucursal;

        public string Direccion_sucursal
        {
            get { return direccion_sucursal; }
            set { direccion_sucursal = value; }
        }
        private string colonia_sucursal;

        public string Colonia_sucursal
        {
            get { return colonia_sucursal; }
            set { colonia_sucursal = value; }
        }
        private string ciudad_sucursal;

        public string Ciudad_sucursal
        {
            get { return ciudad_sucursal; }
            set { ciudad_sucursal = value; }
        }
        private int codigo_postal_sucursal;

        public int Codigo_postal_sucursal
        {
            get { return codigo_postal_sucursal; }
            set { codigo_postal_sucursal = value; }
        }
        private string estado_sucursal;

        public string Estado_sucursal
        {
            get { return estado_sucursal; }
            set { estado_sucursal = value; }
        }
        private string telefono1_sucursal;

        public string Telefono1_sucursal
        {
            get { return telefono1_sucursal; }
            set { telefono1_sucursal = value; }
        }
        private string telefono2_sucursal;

        public string Telefono2_sucursal
        {
            get { return telefono2_sucursal; }
            set { telefono2_sucursal = value; }
        }
        private string nombre_envios_sucursal;

        public string Nombre_envios_sucursal
        {
            get { return nombre_envios_sucursal; }
            set { nombre_envios_sucursal = value; }
        }
        private string usuario_envios_sucursal;

        public string Usuario_envios_sucursal
        {
            get { return usuario_envios_sucursal; }
            set { usuario_envios_sucursal = value; }
        }
        private string direccion_envios_sucursal;

        public string Direccion_envios_sucursal
        {
            get { return direccion_envios_sucursal; }
            set { direccion_envios_sucursal = value; }
        }
        private string ciudad_envios_sucursal;

        public string Ciudad_envios_sucursal
        {
            get { return ciudad_envios_sucursal; }
            set { ciudad_envios_sucursal = value; }
        }
        private string colonia_envios_sucursal;

        public string Colonia_envios_sucursal
        {
            get { return colonia_envios_sucursal; }
            set { colonia_envios_sucursal = value; }
        }
        private string cp_envios_sucursal;

        public string Cp_envios_sucursal
        {
            get { return cp_envios_sucursal; }
            set { cp_envios_sucursal = value; }
        }
        private string tel_envios_sucursal;

        public string Tel_envios_sucursal
        {
            get { return tel_envios_sucursal; }
            set { tel_envios_sucursal = value; }
        }
        private string edo_envios_sucursal;

        public string Edo_envios_sucursal
        {
            get { return edo_envios_sucursal; }
            set { edo_envios_sucursal = value; }
        }
        private string email_envios_sucursal;

        public string Email_envios_sucursal
        {
            get { return email_envios_sucursal; }
            set { email_envios_sucursal = value; }
        }
        private string atencion_personal1_sucursal;

        public string Atencion_personal1_sucursal
        {
            get { return atencion_personal1_sucursal; }
            set { atencion_personal1_sucursal = value; }
        }
        private string atencion_personal2_sucursal;

        public string Atencion_personal2_sucursal
        {
            get { return atencion_personal2_sucursal; }
            set { atencion_personal2_sucursal = value; }
        }
        private string status_sucursal;

        public string Status_sucursal
        {
            get { return status_sucursal; }
            set { status_sucursal = value; }
        }
        private string ejecutivo;

        private string estatus;
        public string Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }

        public string Ejecutivo
        {
            get { return ejecutivo; }
            set { ejecutivo = value; }
        }
        private string fecha_apertura;

        public string Fecha_apertura
        {
            get { return fecha_apertura; }
            set { fecha_apertura = value; }
        }
        private string e_mail;

        public string E_mail
        {
            get { return e_mail; }
            set { e_mail = value; }
        }
        private string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        private string FechaModifico;

        public string FechaModifico1
        {
            get { return FechaModifico; }
            set { FechaModifico = value; }
        }
        private string rfc_sucursal;

        public string Rfc_sucursal
        {
            get { return rfc_sucursal; }
            set { rfc_sucursal = value; }
        }
        private string sector_cliente;

        public string Sector_cliente
        {
            get { return sector_cliente; }
            set { sector_cliente = value; }
        }
        private string EmailCobranza;

        public string EmailCobranza1
        {
            get { return EmailCobranza; }
            set { EmailCobranza = value; }
        }
        private int IdUsuarioRegistro;

        public int IdUsuarioRegistro1
        {
            get { return IdUsuarioRegistro; }
            set { IdUsuarioRegistro = value; }
        }
        private int IdUsuarioModifico;

        public int IdUsuarioModifico1
        {
            get { return IdUsuarioModifico; }
            set { IdUsuarioModifico = value; }
        }


        #endregion

        #region Constructor

        public EntSucursal()
        {
            clave_cliente = 0;
            nsucursal = 0;
            sucursal = string.Empty;
            factura_sucursal = string.Empty;
            direccion_sucursal = string.Empty;
            colonia_sucursal = string.Empty;
            ciudad_sucursal = string.Empty;
            codigo_postal_sucursal = 0;
            estado_sucursal = string.Empty;
            telefono1_sucursal = string.Empty;
            telefono2_sucursal = string.Empty;
            nombre_envios_sucursal = string.Empty;
            usuario_envios_sucursal = string.Empty;
            direccion_envios_sucursal = string.Empty;
            ciudad_envios_sucursal = string.Empty;
            colonia_envios_sucursal = string.Empty;
            cp_envios_sucursal = string.Empty;
            tel_envios_sucursal = string.Empty;
            edo_envios_sucursal = string.Empty;
            email_envios_sucursal = string.Empty;
            atencion_personal1_sucursal = string.Empty;
            atencion_personal2_sucursal = string.Empty;
            status_sucursal = string.Empty;
            ejecutivo = string.Empty;
            fecha_apertura = string.Empty;
            e_mail = string.Empty;
            observaciones = string.Empty;
            usuario = string.Empty;
            FechaModifico = string.Empty;
            rfc_sucursal = string.Empty;
            sector_cliente = string.Empty;
            EmailCobranza = string.Empty;
            IdUsuarioRegistro = 0;
            IdUsuarioModifico = 0;
            estatus = string.Empty;
        }

        public EntSucursal(int cveCliente)
        {
            clave_cliente = cveCliente;
            nsucursal = 0;
            sucursal = string.Empty;
            factura_sucursal = string.Empty;
            direccion_sucursal = string.Empty;
            colonia_sucursal = string.Empty;
            ciudad_sucursal = string.Empty;
            codigo_postal_sucursal = 0;
            estado_sucursal = string.Empty;
            telefono1_sucursal = string.Empty;
            telefono2_sucursal = string.Empty;
            nombre_envios_sucursal = string.Empty;
            usuario_envios_sucursal = string.Empty;
            direccion_envios_sucursal = string.Empty;
            ciudad_envios_sucursal = string.Empty;
            colonia_envios_sucursal = string.Empty;
            cp_envios_sucursal = string.Empty;
            tel_envios_sucursal = string.Empty;
            edo_envios_sucursal = string.Empty;
            email_envios_sucursal = string.Empty;
            atencion_personal1_sucursal = string.Empty;
            atencion_personal2_sucursal = string.Empty;
            status_sucursal = string.Empty;
            ejecutivo = string.Empty;
            fecha_apertura = string.Empty;
            e_mail = string.Empty;
            observaciones = string.Empty;
            usuario = string.Empty;
            FechaModifico = string.Empty;
            rfc_sucursal = string.Empty;
            sector_cliente = string.Empty;
            EmailCobranza = string.Empty;
            IdUsuarioRegistro = 0;
            IdUsuarioModifico = 0;
            estatus = string.Empty;
        }


        public EntSucursal(int cveCliente, int NoSucursal )
        {
            clave_cliente = cveCliente;
            nsucursal = NoSucursal;
            sucursal = string.Empty;
            factura_sucursal = string.Empty;
            direccion_sucursal = string.Empty;
            colonia_sucursal = string.Empty;
            ciudad_sucursal = string.Empty;
            codigo_postal_sucursal = 0;
            estado_sucursal = string.Empty;
            telefono1_sucursal = string.Empty;
            telefono2_sucursal = string.Empty;
            nombre_envios_sucursal = string.Empty;
            usuario_envios_sucursal = string.Empty;
            direccion_envios_sucursal = string.Empty;
            ciudad_envios_sucursal = string.Empty;
            colonia_envios_sucursal = string.Empty;
            cp_envios_sucursal = string.Empty;
            tel_envios_sucursal = string.Empty;
            edo_envios_sucursal = string.Empty;
            email_envios_sucursal = string.Empty;
            atencion_personal1_sucursal = string.Empty;
            atencion_personal2_sucursal = string.Empty;
            status_sucursal = string.Empty;
            ejecutivo = string.Empty;
            fecha_apertura = string.Empty;
            e_mail = string.Empty;
            observaciones = string.Empty;
            usuario = string.Empty;
            FechaModifico = string.Empty;
            rfc_sucursal = string.Empty;
            sector_cliente = string.Empty;
            EmailCobranza = string.Empty;
            IdUsuarioRegistro = 0;
            IdUsuarioModifico = 0;
            estatus = string.Empty;
        }

        #endregion
    }
}
