using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMIN2.Entity;
using ADMIN2.DAL;
namespace ADMIN2.BR
{
    public class BrConfiguracion
    {

        #region Usuarios

        public Respuesta<List<EntUsuario>> GetValidaUsuario(EntUsuario obj)
        {
            DalConfiguracion usu = new DalConfiguracion();
            Respuesta<List<EntUsuario>> respuesta = new Respuesta<List<EntUsuario>>();

            try
            {
                respuesta.Resultado = usu.GetValidaUsuario(obj, "E");
                if (respuesta.Resultado != null && respuesta.Resultado.Count() > 0)
                {
                    respuesta.EsExitoso = true;
                    respuesta.TotalRegistros = respuesta.Resultado.Count();

                }
                else
                {
                    respuesta.EsExitoso = false;
                    respuesta.TotalRegistros = respuesta.Resultado.Count();
                }
            }
            catch (Exception ex)
            {
                respuesta.InicializaError(excepcion: ex);
            }
            return respuesta;
        }

        public Respuesta<List<EntUsuario>> GetConsultaUsuarios(EntUsuario obj)
        {
            DalConfiguracion usu = new DalConfiguracion();
            Respuesta<List<EntUsuario>> respuesta = new Respuesta<List<EntUsuario>>();

            try
            {
                respuesta.Resultado = usu.GetConsultaUsuarios(obj, "D");
                if (respuesta.Resultado != null && respuesta.Resultado.Count() > 0)
                {
                    respuesta.EsExitoso = true;
                    respuesta.TotalRegistros = respuesta.Resultado.Count();

                }
                else
                {
                    respuesta.EsExitoso = false;
                    respuesta.TotalRegistros = respuesta.Resultado.Count();
                }
            }
            catch (Exception ex)
            {
                respuesta.InicializaError(excepcion: ex);
            }
            return respuesta;
        }

        public Respuesta<List<EntUsuario>> GetConsultaUsuario(EntUsuario obj)
        {
            DalConfiguracion usu = new DalConfiguracion();
            Respuesta<List<EntUsuario>> respuesta = new Respuesta<List<EntUsuario>>();

            try
            {
                respuesta.Resultado = usu.GetConsultaUsuario(obj, "A");
                if (respuesta.Resultado != null && respuesta.Resultado.Count() > 0)
                {
                    respuesta.EsExitoso = true;
                    respuesta.TotalRegistros = respuesta.Resultado.Count();

                }
                else
                {
                    respuesta.EsExitoso = false;
                    respuesta.TotalRegistros = respuesta.Resultado.Count();
                }
            }
            catch (Exception ex)
            {
                respuesta.InicializaError(excepcion: ex);
            }
            return respuesta;
        }

        public Respuesta<int> InsUpdUsuarios(EntUsuario ObjIn,string opc, string tipo)
        {
            DalConfiguracion usu = new DalConfiguracion();
            Respuesta<int> respuesta = new Respuesta<int>();
            try
            {
                usu.begTran();
                respuesta.Resultado = usu.InsUpdUsuarios(ObjIn,opc, tipo);
                if (respuesta.Resultado > 0)
                {
                    respuesta.EsExitoso = true;                    
                    usu.commit();
                }
            }
            catch (Exception ex)
            {
                respuesta.InicializaError(excepcion: ex);
                usu.roll_back();
            }
            finally
            {
                usu.close();
            }
            return respuesta;
        }

        #endregion

        #region Perfiles

        public Respuesta<List<EntPerfil>> GetConsultaPerfiles(EntPerfil obj)
        {
            DalConfiguracion usu = new DalConfiguracion();
            Respuesta<List<EntPerfil>> respuesta = new Respuesta<List<EntPerfil>>();

            try
            {
                respuesta.Resultado = usu.GetConsultaPerfiles(obj, "A");
                if (respuesta.Resultado != null && respuesta.Resultado.Count() > 0)
                {
                    respuesta.EsExitoso = true;
                    respuesta.TotalRegistros = respuesta.Resultado.Count();

                }
                else
                {
                    respuesta.EsExitoso = false;
                    respuesta.TotalRegistros = respuesta.Resultado.Count();
                }
            }
            catch (Exception ex)
            {
                respuesta.InicializaError(excepcion: ex);
            }
            return respuesta;
        }

        public Respuesta<List<EntPerfil>> GetConsultaPerfileAcceso(EntPerfil obj, string tipo)
        {
            DalConfiguracion usu = new DalConfiguracion();
            Respuesta<List<EntPerfil>> respuesta = new Respuesta<List<EntPerfil>>();

            try
            {
                respuesta.Resultado = usu.GetConsultaPerfileAcceso(obj, tipo);
                if (respuesta.Resultado != null && respuesta.Resultado.Count() > 0)
                {
                    respuesta.EsExitoso = true;
                    respuesta.TotalRegistros = respuesta.Resultado.Count();
                }
                else
                {
                    respuesta.EsExitoso = false;
                    respuesta.TotalRegistros = respuesta.Resultado.Count();
                }
            }
            catch (Exception ex)
            {
                respuesta.InicializaError(excepcion: ex);
            }
            return respuesta;
        }

        public Respuesta<List<EntPerfil>> GetConsultaPerfileAccesoUsuario(EntPerfil obj)
        {
            DalConfiguracion usu = new DalConfiguracion();
            Respuesta<List<EntPerfil>> respuesta = new Respuesta<List<EntPerfil>>();

            try
            {
                respuesta.Resultado = usu.GetConsultaPerfileAccesoUsuario(obj, "C");
                if (respuesta.Resultado != null && respuesta.Resultado.Count() > 0)
                {
                    respuesta.EsExitoso = true;
                    respuesta.TotalRegistros = respuesta.Resultado.Count();

                }
                else
                {
                    respuesta.EsExitoso = false;
                    respuesta.TotalRegistros = respuesta.Resultado.Count();
                }
            }
            catch (Exception ex)
            {
                respuesta.InicializaError(excepcion: ex);
            }
            return respuesta;
        }

        public Respuesta<int> InsUpdPerfiles(EntPerfil ObjIn, string opc, string tipo)
        {
            DalConfiguracion usu = new DalConfiguracion();
            Respuesta<int> respuesta = new Respuesta<int>();
            try
            {
                usu.begTran();
                respuesta.Resultado = usu.InsUpdPerfiles(ObjIn, opc, tipo);
                if (respuesta.Resultado > 0)
                {
                    respuesta.EsExitoso = true;
                    usu.commit();
                }
            }
            catch (Exception ex)
            {
                respuesta.InicializaError(excepcion: ex);
                usu.roll_back();
            }
            finally
            {
                usu.close();
            }
            return respuesta;
        }

        #endregion

        #region Areas

        public Respuesta<List<EntArea>> GetConsultaAreas(EntArea obj)
        {
            DalConfiguracion usu = new DalConfiguracion();
            Respuesta<List<EntArea>> respuesta = new Respuesta<List<EntArea>>();

            try
            {
                respuesta.Resultado = usu.GetConsultaAreas(obj);
                if (respuesta.Resultado != null && respuesta.Resultado.Count() > 0)
                {
                    respuesta.EsExitoso = true;
                    respuesta.TotalRegistros = respuesta.Resultado.Count();
                }
                else
                {
                    respuesta.EsExitoso = false;
                    respuesta.TotalRegistros = respuesta.Resultado.Count();
                }
            }
            catch (Exception ex)
            {
                respuesta.InicializaError(excepcion: ex);
            }
            return respuesta;
        }

        #endregion

        #region Pantallas

        public Respuesta<List<EntPantalla>> GetConsultaPantallas(EntPantalla obj, string tipo)
        {
            DalConfiguracion usu = new DalConfiguracion();
            Respuesta<List<EntPantalla>> respuesta = new Respuesta<List<EntPantalla>>();

            try
            {
                respuesta.Resultado = usu.GetConsultaPantallas(obj, tipo);
                if (respuesta.Resultado != null && respuesta.Resultado.Count() > 0)
                {
                    respuesta.EsExitoso = true;
                    respuesta.TotalRegistros = respuesta.Resultado.Count();
                }
                else
                {
                    respuesta.EsExitoso = false;
                    respuesta.TotalRegistros = respuesta.Resultado.Count();
                }
            }
            catch (Exception ex)
            {
                respuesta.InicializaError(excepcion: ex);
            }
            return respuesta;
        }

        #endregion
       
    }
}
