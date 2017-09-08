using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMIN2.Entity;
using ADMIN2.DAL;

namespace ADMIN2.BR
{
    public class BrCliente
    {
        #region Cliente

        public Respuesta<List<EntTipoCliente>> GetConsultaTipoCliente(EntTipoCliente obj)
        {
            DalCliente cliente = new DalCliente();
            Respuesta<List<EntTipoCliente>> respuesta = new Respuesta<List<EntTipoCliente>>();

            try
            {
                respuesta.Resultado = cliente.GetConsultaTipoCliente(obj);
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

        public Respuesta<List<EntEstatusCliente>> GetConsultaEstatusCliente(EntEstatusCliente obj)
        {
            DalCliente cliente = new DalCliente();
            Respuesta<List<EntEstatusCliente>> respuesta = new Respuesta<List<EntEstatusCliente>>();

            try
            {
                respuesta.Resultado = cliente.GetConsultaEstatusCliente(obj);
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

        public Respuesta<List<EntSectorCliente>> GetConsultaSectorCliente(EntSectorCliente obj)
        {
            DalCliente cliente = new DalCliente();
            Respuesta<List<EntSectorCliente>> respuesta = new Respuesta<List<EntSectorCliente>>();

            try
            {
                respuesta.Resultado = cliente.GetConsultaSectorCliente(obj);
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

        public Respuesta<List<EntTipoDocumento>> GetConsultaTipoDocumento(EntTipoDocumento obj)
        {
            DalCliente cliente = new DalCliente();
            Respuesta<List<EntTipoDocumento>> respuesta = new Respuesta<List<EntTipoDocumento>>();

            try
            {
                respuesta.Resultado = cliente.GetConsultaTipoDocumento(obj);
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

        public Respuesta<List<EntEntidades>> GetConsultaEntidades(EntEntidades obj)
        {
            DalCliente cliente = new DalCliente();
            Respuesta<List<EntEntidades>> respuesta = new Respuesta<List<EntEntidades>>();

            try
            {
                respuesta.Resultado = cliente.GetConsultaEntidades(obj,"A");
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

        public Respuesta<List<EntEntidades>> GetConsultaMunicipios(EntEntidades obj, string tipo = "B")
        {
            DalCliente cliente = new DalCliente();
            Respuesta<List<EntEntidades>> respuesta = new Respuesta<List<EntEntidades>>();

            try
            {
                respuesta.Resultado = cliente.GetConsultaMunicipios(obj, tipo);
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

        public Respuesta<List<EntEntidades>> GetConsultaColonias(EntEntidades obj, string tipo = "C")
        {
            DalCliente cliente = new DalCliente();
            Respuesta<List<EntEntidades>> respuesta = new Respuesta<List<EntEntidades>>();

            try
            {
                respuesta.Resultado = cliente.GetConsultaColonias(obj, tipo);
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

        public Respuesta<List<EntEntidades>> GetConsultaCodigoPostal(EntEntidades obj, string tipo = "D")
        {
            DalCliente cliente = new DalCliente();
            Respuesta<List<EntEntidades>> respuesta = new Respuesta<List<EntEntidades>>();

            try
            {
                respuesta.Resultado = cliente.GetConsultaCodigoPostal(obj, tipo);
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

        public Respuesta<List<EntCliente>> GetConsultaClientes(EntCliente obj)
        {
            DalCliente cliente = new DalCliente();
            Respuesta<List<EntCliente>> respuesta = new Respuesta<List<EntCliente>>();

            try
            {
                respuesta.Resultado = cliente.GetConsultaClientes(obj, "A");
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

        public Respuesta<List<EntCliente>> GetConsultaConsecutivoCliente(EntCliente obj)
        {
            DalCliente cliente = new DalCliente();
            Respuesta<List<EntCliente>> respuesta = new Respuesta<List<EntCliente>>();

            try
            {
                respuesta.Resultado = cliente.GetConsultaConsecutivoCliente(obj, "B");
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

        public Respuesta<List<EntCliente>> GetValidaRFC(EntCliente obj)
        {
            DalCliente cliente = new DalCliente();
            Respuesta<List<EntCliente>> respuesta = new Respuesta<List<EntCliente>>();

            try
            {
                respuesta.Resultado = cliente.GetValidaRFC(obj, "C");
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

        public Respuesta<int> InsUpdClientes(EntCliente ObjIn, string opc, string tipo)
        {
            DalCliente cliente = new DalCliente();
            Respuesta<int> respuesta = new Respuesta<int>();
            try
            {
                cliente.begTran();
                respuesta.Resultado = cliente.InsUpdClientes(ObjIn, opc, tipo);
                if (respuesta.Resultado > 0)
                {
                    respuesta.EsExitoso = true;
                    cliente.commit();
                }
            }
            catch (Exception ex)
            {
                respuesta.InicializaError(excepcion: ex);
                cliente.roll_back();
            }
            finally
            {
                cliente.close();
            }
            return respuesta;
        }

        #endregion

        #region Sucursal

        public Respuesta<List<EntSucursal>> GetConsultaSucursales(EntSucursal obj)
        {
            DalCliente cliente = new DalCliente();
            Respuesta<List<EntSucursal>> respuesta = new Respuesta<List<EntSucursal>>();

            try
            {
                respuesta.Resultado = cliente.GetConsultaSucursales(obj, "A");
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

        public Respuesta<List<EntSucursal>> GetValidaSucursalRFC(EntSucursal obj)
        {
            DalCliente cliente = new DalCliente();
            Respuesta<List<EntSucursal>> respuesta = new Respuesta<List<EntSucursal>>();

            try
            {
                respuesta.Resultado = cliente.GetValidaSucursalRFC(obj, "B");
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

        public Respuesta<int> InsUpdSucursal(EntSucursal ObjIn, string opc, string tipo)
        {
            DalCliente cliente = new DalCliente();
            Respuesta<int> respuesta = new Respuesta<int>();
            try
            {
                cliente.begTran();
                respuesta.Resultado = cliente.InsUpdSucursal(ObjIn, opc, tipo);
                if (respuesta.Resultado > 0)
                {
                    respuesta.EsExitoso = true;
                    cliente.commit();
                }
            }
            catch (Exception ex)
            {
                respuesta.InicializaError(excepcion: ex);
                cliente.roll_back();
            }
            finally
            {
                cliente.close();
            }
            return respuesta;
        }

        public Respuesta<int> DelSucursal(EntSucursal ObjIn)
        {
            DalCliente cliente = new DalCliente();
            Respuesta<int> respuesta = new Respuesta<int>();
            try
            {
                cliente.begTran();
                respuesta.Resultado = cliente.InsUpdSucursal(ObjIn, "B", "");
                if (respuesta.Resultado > 0)
                {
                    respuesta.EsExitoso = true;
                    cliente.commit();
                }
            }
            catch (Exception ex)
            {
                respuesta.InicializaError(excepcion: ex);
                cliente.roll_back();
            }
            finally
            {
                cliente.close();
            }
            return respuesta;
        }

        #endregion
    }
}