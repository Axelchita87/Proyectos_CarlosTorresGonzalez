using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN2.DAL
{
    public class Procedimientos
    {

        #region Clientes

        public const string SpCatTipoCliente = "SpCatTipoCliente";
        public const string SpCatEstatusCliente="SpCatEstatusCliente";
        public const string SpCatSectorCliente= "SpCatSectorCliente";
        public const string SpCatTipoDocumento = "SpCatTipoDocumento";
        public const string SpEntidadesConsulta = "SpEntidadesConsulta";
        public const string SpCliente = "SpCliente";
        public const string SpSucursal="SpSucursal";

        #endregion

        #region Producción

        #endregion

        #region Administración

        public const string SpBitacora = "SpBitacora";

        #endregion

        #region Consultoría

        #endregion

        #region Soporte Técnico

        #endregion

        #region Reportes

        #endregion

        #region Configuración

        public const string SpUsuarios = "SpUsuarios";
        public const string SpPerfiles = "SpPerfiles";
        public const string SpAreas = "SpAreas";
        public const string SpPantallas = "SpPantallas";

        #endregion

    }
}
