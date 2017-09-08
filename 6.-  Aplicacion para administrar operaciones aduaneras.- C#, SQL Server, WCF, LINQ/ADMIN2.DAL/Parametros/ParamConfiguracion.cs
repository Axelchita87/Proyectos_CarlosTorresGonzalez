using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMIN2.Entity;
using System.Data;

namespace ADMIN2.DAL
{
    public class ParamConfiguracion
    {

        public static DBParameterCollection LLenaUsuarios(EntUsuario obj, string opc, string tipo)
        {
            DBParameter p1 = new DBParameter("popc", opc, System.Data.DbType.String);
            DBParameter p2 = new DBParameter("poptipo", tipo);
            DBParameter p3 = new DBParameter("IdUsuario", obj.IdUsuario, System.Data.DbType.Int32);
            DBParameter p4 = new DBParameter("IdSistema", obj.IdSistema, System.Data.DbType.Int32);
            DBParameter p5 = new DBParameter("Usuario", obj.Usuario);
            DBParameter p6 = new DBParameter("nombre", obj.Nombre);
            DBParameter p7 = new DBParameter("clave", obj.Clave);
            DBParameter p8 = new DBParameter("origen", obj.Origen);
            DBParameter p9 = new DBParameter("Activo", obj.Activo, System.Data.DbType.Int32);
            DBParameter p10 = new DBParameter("IdUsuarioRegistro", obj.IdUsuarioRegistro, System.Data.DbType.Int32);
            DBParameter p11 = new DBParameter("IdUsuarioModifico", obj.IdUsuarioModifico, System.Data.DbType.Int32);
            DBParameter p12 = new DBParameter("IdPerfil", obj.IdPerfil, System.Data.DbType.Int32);
            DBParameter p13 = new DBParameter("IdArea", obj.IdArea, System.Data.DbType.Int32);
            DBParameter p14 = new DBParameter("CorreoElectronico", obj.CorreoElectronico);

            DBParameter[] parms = new DBParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14 };            
            DBParameterCollection pcol = new DBParameterCollection();
            pcol.AddRange(parms);
            return pcol;
        }

        public static DBParameterCollection LLenaPerfiles(EntPerfil obj, string opc, string tipo)
        {
            DBParameter p1 = new DBParameter("popc", opc, System.Data.DbType.String);
            DBParameter p2 = new DBParameter("poptipo", tipo);
            DBParameter p3 = new DBParameter("IdSistema", obj.IdSistema, System.Data.DbType.Int32);
            DBParameter p4 = new DBParameter("Perfil", obj.Perfil);
            DBParameter p5 = new DBParameter("IdUsuario", obj.IdUsuarioRegistro, System.Data.DbType.Int32);
            DBParameter p6 = new DBParameter("IdPerfil", obj.IdPerfil, System.Data.DbType.Int32);
            DBParameter p7 = new DBParameter("IdPantalla", obj.IdPantalla, System.Data.DbType.Int32);
            DBParameter p8 = new DBParameter("IdPermiso", obj.IdPermiso, System.Data.DbType.Int32);
            DBParameter p9 = new DBParameter("TipoPermiso", obj.ST_C_AP_LEER);
            DBParameter p10 = new DBParameter("IdUsuarioModifico", obj.IdUsuarioModifico, System.Data.DbType.Int32);

            DBParameter[] parms = new DBParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9,p10};
            DBParameterCollection pcol = new DBParameterCollection();
            pcol.AddRange(parms);
            return pcol;
        }

        public static DBParameterCollection LLenaAreas(EntArea obj, string opc)
        {
            DBParameter p1 = new DBParameter("popc", opc, System.Data.DbType.String);
            DBParameter p2 = new DBParameter("IdArea", obj.IdArea, System.Data.DbType.Int32);

            DBParameter[] parms = new DBParameter[] { p1, p2 };
            DBParameterCollection pcol = new DBParameterCollection();
            pcol.AddRange(parms);
            return pcol;
        }

        public static DBParameterCollection LLenaPantallas(EntPantalla obj, string opc, string ptipo)
        {
            DBParameter p1 = new DBParameter("popc", opc, System.Data.DbType.String);
            DBParameter p2 = new DBParameter("IdSistema", obj.IdSistema, System.Data.DbType.Int32);
            DBParameter p3 = new DBParameter("IdPantalla", obj.IdPantalla, System.Data.DbType.Int32);
            DBParameter p4 = new DBParameter("ptipo", ptipo, System.Data.DbType.String);

            DBParameter[] parms = new DBParameter[] { p1, p2, p3, p4 };
            DBParameterCollection pcol = new DBParameterCollection();
            pcol.AddRange(parms);
            return pcol;
        }

    }
}
