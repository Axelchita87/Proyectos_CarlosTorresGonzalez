using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN2.DAL
{
    public class Genericas
    {
        public const string TextLeft = "Left";
        public const string TextCenter = "Center";
        public const string TextRight = "Right";

        #region Entidades

        #region Clientes

        public const string EntEntidades = "ADMIN2.Entity.EntEntidades";
        public const string EntCliente = "ADMIN2.Entity.EntCliente";
        public const string EntSucursal = "ADMIN2.Entity.EntSucursal";

        #endregion

        #region Producción

        #endregion

        #region Administración

        public const string EntBitacora = "ADMIN2.Entity.EntBitacora";

        #endregion

        #region Consultoría

        #endregion

        #region Soporte Técnico

        #endregion

        #region Reportes

        #endregion

        #region Configuración

        public const string EntUsuario = "ADMIN2.Entity.EntUsuario";
        public const string EntPerfil = "ADMIN2.Entity.EntPerfil";

        #endregion


        #endregion

        #region Catalogos

        #region Clientes

        public const string CatEntidades = "CatEntidades";
        public const string CatMunicipios="CatMunicipios";
        public const string CatColonias= "CatColonias";
        public const string CatCodigoPostal = "CatCodigoPostal";
        public const string CatCliente = "CatCliente";
        public const string CatSucursal = "CatSucursal";

        #endregion

        #region Producción

        #endregion

        #region Administración

        public const string CatBitacoraCambios = "CatBitacoraCambios";

        #endregion

        #region Consultoría

        #endregion

        #region Soporte Técnico

        #endregion

        #region Reportes

        #endregion

        #region Configuración

        public const string CatUsuarios = "CatUsuarios";
        public const string CatPerfiles = "CatPerfiles";

        #endregion

        #endregion

        #region Generales

        public string SetCampo(string campo)
        {

            return campo == string.Empty ? "" : campo;
        }

        public int SetCampo(int campo)
        {

            return campo == 0 ? 0 : campo;
        }

        #endregion
        
    }
}
