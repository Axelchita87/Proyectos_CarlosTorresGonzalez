using ADMIN2.DAL.Parametros;
using ADMIN2.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN2.DAL
{
    /// <summary>
    /// Configuración AdminEvents
    /// </summary>
    public class DalConfiguracionADE: DALBase
    {
        public DalConfiguracionADE()
        {
            db = DBHelper.GetInstance("conxAdm");
            conm = db.GetConnObject();
        }

        #region Configuracion

        #region Usuarios

        public List<EntUsuario> GetValidaUsuario(EntUsuario Dobj, string tipo)
        {
            List<EntUsuario> lst = new List<EntUsuario>();
            DBParameterCollection pcol = ParamConfiguracionADE.LLenaUsuarios(Dobj, Comunes.BUSCAR, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpUsuarios, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntUsuario obj = new EntUsuario();
                    if (dr["Nombre"] != DBNull.Value) obj.Nombre = (dr["Nombre"].ToString());
                    if (dr["ValidaUser"] != DBNull.Value) obj.ValidaUsuario = Convert.ToInt32(dr["ValidaUser"].ToString());
                    if (dr["IdUsuario"] != DBNull.Value) obj.IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString());
                    if (dr["IdSistema"] != DBNull.Value) obj.IdUsuario = Convert.ToInt32(dr["IdSistema"].ToString());
                    if (dr["Mensaje"] != DBNull.Value) obj.Mensaje = (dr["Mensaje"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public List<EntUsuario> GetConsultaUsuarios(EntUsuario Dobj, string tipo)
        {
            List<EntUsuario> lst = new List<EntUsuario>();
            DBParameterCollection pcol = ParamConfiguracionADE.LLenaUsuarios(Dobj, Comunes.BUSCAR, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpUsuarios, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntUsuario obj = new EntUsuario();
                    if (dr["IdUsuario"] != DBNull.Value) obj.IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString());
                    if (dr["NombreArea"] != DBNull.Value) obj.Area = (dr["NombreArea"].ToString());
                    if (dr["AREA"] != DBNull.Value) obj.IdArea = Convert.ToInt32(dr["AREA"].ToString());
                    if (dr["nombre"] != DBNull.Value) obj.Nombre = (dr["nombre"].ToString());
                    if (dr["CorreoElectronico"] != DBNull.Value) obj.CorreoElectronico = (dr["CorreoElectronico"].ToString());
                    if (dr["FechaModifico"] != DBNull.Value) obj.FechaModifico = (dr["FechaModifico"].ToString());
                    if (dr["Activo"] != DBNull.Value) obj.ActivoTexto = (dr["Activo"].ToString());
                    if (dr["Usuario"] != DBNull.Value) obj.Usuario = (dr["Usuario"].ToString());
                    if (dr["clave"] != DBNull.Value) obj.Clave = (dr["clave"].ToString());
                    if (dr["IdPerfil"] != DBNull.Value) obj.IdPerfil = Convert.ToInt32(dr["IdPerfil"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;

        }

        public int InsUpdUsuarios(EntUsuario Dobj, string opc, string tipo)
        {
            Respuesta<int> res = new Respuesta<int>();

            DBParameterCollection pcol = ParamConfiguracionADE.LLenaUsuarios(Dobj, opc, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpUsuarios, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    res = ExisteError(dr);
                    if (!res.EsExitoso) throw new Exception(res.MensajeUsuario);
                    else return res.TotalRegistros;
                }
            }
            return 0;
        }

        public List<EntUsuario> GetConsultaUsuario(EntUsuario Dobj, string tipo)
        {
            List<EntUsuario> lst = new List<EntUsuario>();
            DBParameterCollection pcol = ParamConfiguracionADE.LLenaUsuarios(Dobj, Comunes.BUSCAR, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpUsuarios, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntUsuario obj = new EntUsuario();
                    if (dr["IdUsuario"] != DBNull.Value) obj.IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString());
                    if (dr["Nombre"] != DBNull.Value) obj.Nombre = (dr["Nombre"].ToString());
                    if (dr["admin"] != DBNull.Value) obj.Admin = Convert.ToBoolean(dr["admin"].ToString());
                    if (dr["IdArea"] != DBNull.Value) obj.IdArea = Convert.ToInt32(dr["IdArea"].ToString());
                    if (dr["CorreoElectronico"] != DBNull.Value) obj.CorreoElectronico = (dr["CorreoElectronico"].ToString());
                    if (dr["IdPerfil"] != DBNull.Value) obj.IdPerfil = Convert.ToInt32(dr["IdPerfil"].ToString());
                    if (dr["IdSistema"] != DBNull.Value) obj.IdSistema = Convert.ToInt32(dr["IdSistema"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;
        }

        #endregion

        #region Perfiles

        public List<EntPerfil> GetConsultaPerfiles(EntPerfil Dobj, string tipo)
        {
            List<EntPerfil> lst = new List<EntPerfil>();
            DBParameterCollection pcol = ParamConfiguracionADE.LLenaPerfiles(Dobj, Comunes.BUSCAR, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpPerfiles, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntPerfil obj = new EntPerfil();
                    if (dr["Perfil"] != DBNull.Value) obj.Perfil = (dr["Perfil"].ToString());
                    if (dr["IdPerfil"] != DBNull.Value) obj.IdPerfil = Convert.ToInt32(dr["IdPerfil"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;

        }

        public List<EntPerfil> GetConsultaPerfileAcceso(EntPerfil Dobj, string tipo)
        {
            List<EntPerfil> lst = new List<EntPerfil>();
            DBParameterCollection pcol = ParamConfiguracionADE.LLenaPerfiles(Dobj, Comunes.BUSCAR, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpPerfiles, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntPerfil obj = new EntPerfil();
                    if (dr["Pantalla"] != DBNull.Value) obj.RutaPantalla = (dr["Pantalla"].ToString());
                    if (dr["IdPerfil"] != DBNull.Value) obj.IdPerfil = Convert.ToInt32(dr["IdPerfil"].ToString());
                    if (dr["IdPantalla"] != DBNull.Value) obj.IdPantalla = Convert.ToInt32(dr["IdPantalla"].ToString());
                    if (dr["IdPermiso"] != DBNull.Value) obj.IdPermiso = Convert.ToInt32(dr["IdPermiso"].ToString());
                    if (dr["ST_C_AP_LEER"] != DBNull.Value) obj.ST_C_AP_LEER = Convert.ToBoolean(dr["ST_C_AP_LEER"]);
                    if (dr["ST_C_AP_LEERYESCRIBIR"] != DBNull.Value) obj.ST_C_AP_LEERYESCRIBIR = Convert.ToBoolean(dr["ST_C_AP_LEERYESCRIBIR"]);

                    lst.Add(obj);
                }
            }
            return lst;

        }

        public List<EntPerfil> GetConsultaPerfileAccesoUsuario(EntPerfil Dobj, string tipo)
        {
            List<EntPerfil> lst = new List<EntPerfil>();
            DBParameterCollection pcol = ParamConfiguracionADE.LLenaPerfiles(Dobj, Comunes.BUSCAR, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpPerfiles, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntPerfil obj = new EntPerfil();
                    if (dr["NombrePantalla"] != DBNull.Value) obj.NombrePantalla = (dr["NombrePantalla"].ToString());
                    if (dr["IdPermiso"] != DBNull.Value) obj.IdPermiso = Convert.ToInt32(dr["IdPermiso"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;

        }

        public int InsUpdPerfiles(EntPerfil Dobj, string opc, string tipo)
        {
            Respuesta<int> res = new Respuesta<int>();

            DBParameterCollection pcol = ParamConfiguracionADE.LLenaPerfiles(Dobj, opc, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpPerfiles, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    res = ExisteError(dr);
                    if (!res.EsExitoso) throw new Exception(res.MensajeUsuario);
                    else return res.TotalRegistros;
                }
            }
            return 0;
        }

        #endregion

        #region Areas

        public List<EntArea> GetConsultaAreas(EntArea Dobj)
        {
            List<EntArea> lst = new List<EntArea>();
            DBParameterCollection pcol = ParamConfiguracionADE.LLenaAreas(Dobj, Comunes.BUSCAR);
            using (dr = db.ExecuteDataReader(Procedimientos.SpAreas, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntArea obj = new EntArea();
                    if (dr["DESCRIPCION"] != DBNull.Value) obj.Area = (dr["DESCRIPCION"].ToString());
                    if (dr["ORIGEN"] != DBNull.Value) obj.Abreviatura = (dr["ORIGEN"].ToString());
                    if (dr["AREA"] != DBNull.Value) obj.IdArea = Convert.ToInt32(dr["AREA"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;

        }

        #endregion

        #region Pantallas

        public List<EntPantalla> GetConsultaPantallas(EntPantalla Dobj, string tipo)
        {
            List<EntPantalla> lst = new List<EntPantalla>();
            DBParameterCollection pcol = ParamConfiguracionADE.LLenaPantallas(Dobj, Comunes.BUSCAR, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpPantallas, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntPantalla obj = new EntPantalla();
                    if (dr["IdPantalla"] != DBNull.Value) obj.IdPantalla = Convert.ToInt32(dr["IdPantalla"].ToString());
                    if (dr["Módulo"] != DBNull.Value) obj.Modulo = (dr["Módulo"].ToString());
                    if (dr["SubMenu"] != DBNull.Value) obj.SubMenu = (dr["SubMenu"].ToString());
                    if (dr["Pantalla"] != DBNull.Value) obj.Pantalla = (dr["Pantalla"].ToString());
                    if (dr["NombrePantalla"] != DBNull.Value) obj.NombrePantalla = (dr["NombrePantalla"].ToString());
                    if (dr["RutaPantalla"] != DBNull.Value) obj.RutaPantalla = (dr["RutaPantalla"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;

        }

        #endregion

        #endregion
    }
}
