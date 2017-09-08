using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMIN2.Entity;
using ADMIN2.DAL;
using System.Data;

namespace ADMIN2.DAL
{
    public class DalCliente : DALBase
    {
        public DalCliente()
        {
            db = DBHelper.GetInstance("conxAdm");
            conm = db.GetConnObject();
        }

        #region Cliente

        public List<EntTipoCliente> GetConsultaTipoCliente(EntTipoCliente Dobj)
        {
            List<EntTipoCliente> lst = new List<EntTipoCliente>();
            DBParameterCollection pcol = ParamCliente.LLenaTipoCliente(Dobj, Comunes.BUSCAR);
            using (dr = db.ExecuteDataReader(Procedimientos.SpCatTipoCliente, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntTipoCliente obj = new EntTipoCliente();
                    if (dr["TipoCliente"] != DBNull.Value) obj.TipoCliente = (dr["TipoCliente"].ToString());
                    if (dr["IdTipoCliente"] != DBNull.Value) obj.IdTipoCliente = Convert.ToInt32(dr["IdTipoCliente"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;

        }

        public List<EntEstatusCliente> GetConsultaEstatusCliente(EntEstatusCliente Dobj)
        {
            List<EntEstatusCliente> lst = new List<EntEstatusCliente>();
            DBParameterCollection pcol = ParamCliente.LLenaEstatusCliente(Dobj, Comunes.BUSCAR);
            using (dr = db.ExecuteDataReader(Procedimientos.SpCatEstatusCliente, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntEstatusCliente obj = new EntEstatusCliente();
                    if (dr["Estatus"] != DBNull.Value) obj.Estatus = (dr["Estatus"].ToString());
                    if (dr["IdEstatus"] != DBNull.Value) obj.IdEstatus = Convert.ToInt32(dr["IdEstatus"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;

        }

        public List<EntSectorCliente> GetConsultaSectorCliente(EntSectorCliente Dobj)
        {
            List<EntSectorCliente> lst = new List<EntSectorCliente>();
            DBParameterCollection pcol = ParamCliente.LLenaSectorCliente(Dobj, Comunes.BUSCAR);
            using (dr = db.ExecuteDataReader(Procedimientos.SpCatSectorCliente, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntSectorCliente obj = new EntSectorCliente();
                    if (dr["Sector"] != DBNull.Value) obj.Sector = (dr["Sector"].ToString());
                    if (dr["IdSector"] != DBNull.Value) obj.IdSector = Convert.ToInt32(dr["IdSector"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;

        }

        public List<EntTipoDocumento> GetConsultaTipoDocumento(EntTipoDocumento Dobj, string tipo="")
        {
            List<EntTipoDocumento> lst = new List<EntTipoDocumento>();
            DBParameterCollection pcol = ParamCliente.LLenaTipoDocumento(Dobj, Comunes.BUSCAR, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpCatTipoDocumento, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntTipoDocumento obj = new EntTipoDocumento();
                    if (dr["Documento"] != DBNull.Value) obj.Documento = (dr["Documento"].ToString());
                    if (dr["IdDocumento"] != DBNull.Value) obj.IdDocumento = Convert.ToInt32(dr["IdDocumento"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public List<EntEntidades> GetConsultaEntidades(EntEntidades Dobj, string tipo="")
        {
            List<EntEntidades> lst = new List<EntEntidades>();
            DBParameterCollection pcol = ParamCliente.LLenaEntidades(Dobj, Comunes.BUSCAR, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpEntidadesConsulta, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntEntidades obj = new EntEntidades();
                    if (dr["IdEstadoInt"] != DBNull.Value) obj.IdEstado = Convert.ToInt32(dr["IdEstadoInt"].ToString());
                    if (dr["d_estado"] != DBNull.Value) obj.D_estado = (dr["d_estado"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;

        }

        public List<EntEntidades> GetConsultaMunicipios(EntEntidades Dobj, string tipo = "")
        {
            List<EntEntidades> lst = new List<EntEntidades>();
            DBParameterCollection pcol = ParamCliente.LLenaEntidades(Dobj, Comunes.BUSCAR, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpEntidadesConsulta, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntEntidades obj = new EntEntidades();
                    if (dr["id_mnpio"] != DBNull.Value) obj.IdMunicipio = Convert.ToInt32(dr["id_mnpio"].ToString());
                    if (dr["D_mnpio"] != DBNull.Value) obj.D_mnpio = (dr["D_mnpio"].ToString());
                    if (dr["d_estado"] != DBNull.Value) obj.D_estado = (dr["d_estado"].ToString());                                   
                    lst.Add(obj);
                }
            }
            return lst;

        }

        public List<EntEntidades> GetConsultaColonias(EntEntidades Dobj, string tipo = "")
        {
            List<EntEntidades> lst = new List<EntEntidades>();
            DBParameterCollection pcol = ParamCliente.LLenaEntidades(Dobj, Comunes.BUSCAR, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpEntidadesConsulta, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntEntidades obj = new EntEntidades();
                    if (dr["id_codigo"] != DBNull.Value) obj.IdCodigo = Convert.ToInt32(dr["id_codigo"].ToString());
                    if (dr["d_asenta"] != DBNull.Value) obj.D_asenta = (dr["d_asenta"].ToString());
                    if (dr["D_mnpio"] != DBNull.Value) obj.D_mnpio = (dr["D_mnpio"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;

        }

        public List<EntEntidades> GetConsultaCodigoPostal(EntEntidades Dobj, string tipo = "")
        {
            List<EntEntidades> lst = new List<EntEntidades>();
            DBParameterCollection pcol = ParamCliente.LLenaEntidades(Dobj, Comunes.BUSCAR, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpEntidadesConsulta, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntEntidades obj = new EntEntidades();                    
                    if (dr["id_codigo"] != DBNull.Value) obj.IdCodigo = Convert.ToInt32(dr["id_codigo"].ToString());
                    if (dr["d_asenta"] != DBNull.Value) obj.D_asenta = (dr["d_asenta"].ToString());
                    if (dr["id_mnpio"] != DBNull.Value) obj.IdMunicipio = Convert.ToInt32(dr["id_mnpio"].ToString());
                    if (dr["D_mnpio"] != DBNull.Value) obj.D_mnpio = (dr["D_mnpio"].ToString());
                    if (dr["IdEstadoInt"] != DBNull.Value) obj.IdEstado = Convert.ToInt32(dr["IdEstadoInt"].ToString());
                    if (dr["d_estado"] != DBNull.Value) obj.D_estado = (dr["d_estado"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;
        }
                
        public List<EntCliente> GetConsultaClientes(EntCliente Dobj, string tipo = "")
        {
            Genericas gen = new Genericas();
            List<EntCliente> lst = new List<EntCliente>();
            DBParameterCollection pcol = ParamCliente.LLenaCliente(Dobj, Comunes.BUSCAR, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpCliente, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntCliente obj = new EntCliente();
                    if (dr["clave_cliente"] != DBNull.Value) obj.ClaveCliente = Convert.ToInt32(gen.SetCampo(dr["clave_cliente"].ToString()));
                    if (dr["TipoVIP"] != DBNull.Value) obj.TipoVIP = (gen.SetCampo(dr["TipoVIP"].ToString()));
                    if (dr["status_cliente"] != DBNull.Value) obj.Statuscliente = Convert.ToInt32(gen.SetCampo(dr["status_cliente"].ToString()));
                    if (dr["iguala"] != DBNull.Value) obj.Iguala = Convert.ToInt32(gen.SetCampo(dr["iguala"].ToString()));
                    if (dr["FechaRegistro"] != DBNull.Value) obj.FechaRegistro = (gen.SetCampo(dr["FechaRegistro"].ToString()));
                    if (dr["FechaModifico"] != DBNull.Value) obj.FechaMoficacion = (gen.SetCampo(dr["FechaModifico"].ToString()));
                    if (dr["nombre_cliente"] != DBNull.Value) obj.Nombrecliente = (gen.SetCampo(dr["nombre_cliente"].ToString()));
                    if (dr["rfc_cliente"] != DBNull.Value) obj.Rfccliente = (gen.SetCampo(dr["rfc_cliente"].ToString()));
                    if (dr["IdRfcEua"] != DBNull.Value) obj.IdRfcEua = (gen.SetCampo(dr["IdRfcEua"].ToString()));
                    if (dr["facturacion_cliente"] != DBNull.Value) obj.Facturacioncliente = (gen.SetCampo(dr["facturacion_cliente"].ToString()));
                    if (dr["sector_cliente"] != DBNull.Value) obj.Sectorcliente = (gen.SetCampo(dr["sector_cliente"].ToString()));
                    if (dr["direccion_cliente"] != DBNull.Value) obj.Direccioncliente = (gen.SetCampo(dr["direccion_cliente"].ToString()));
                    if (dr["colonia_cliente"] != DBNull.Value) obj.Coloniacliente = (gen.SetCampo(dr["colonia_cliente"].ToString()));
                    if (dr["codigo_postal_cliente"] != DBNull.Value) obj.Codigopostalcliente = (gen.SetCampo(dr["codigo_postal_cliente"].ToString()));
                    if (dr["ciudad_cliente"] != DBNull.Value) obj.Ciudadcliente = (gen.SetCampo(dr["ciudad_cliente"].ToString()));
                    if (dr["estado_cliente"] != DBNull.Value) obj.Estadocliente = (gen.SetCampo(dr["estado_cliente"].ToString()));
                    if (dr["PAIS"] != DBNull.Value) obj.Pais = (gen.SetCampo(dr["PAIS"].ToString()));
                    if (dr["telefono1_cliente"] != DBNull.Value) obj.Telefono1cliente = (gen.SetCampo(dr["telefono1_cliente"].ToString()));
                    if (dr["telefono2_cliente"] != DBNull.Value) obj.Telefono2cliente = (gen.SetCampo(dr["telefono2_cliente"].ToString()));
                    if (dr["e_mail_cliente"] != DBNull.Value) obj.Emailcliente = (gen.SetCampo(dr["e_mail_cliente"].ToString()));
                    if (dr["EmailSecEnvios"] != DBNull.Value) obj.EmailSecEnvios = (gen.SetCampo(dr["EmailSecEnvios"].ToString()));
                    if (dr["atencion_personal1_cliente"] != DBNull.Value) obj.Atencionpersonal1cliente = (gen.SetCampo(dr["atencion_personal1_cliente"].ToString()));
                    if (dr["ejecutivo"] != DBNull.Value) obj.Ejecutivo = (gen.SetCampo(dr["ejecutivo"].ToString()));
                    if (dr["nombre_envios"] != DBNull.Value) obj.Nombreenvios = (gen.SetCampo(dr["nombre_envios"].ToString()));
                    if (dr["usuario_envios"] != DBNull.Value) obj.Usuarioenvios = (gen.SetCampo(dr["usuario_envios"].ToString()));
                    if (dr["direccion_envios"] != DBNull.Value) obj.Direccionenvios = (gen.SetCampo(dr["direccion_envios"].ToString()));
                    if (dr["colonia_envios"] != DBNull.Value) obj.Coloniaenvios = (gen.SetCampo(dr["colonia_envios"].ToString()));
                    if (dr["cp_envios"] != DBNull.Value) obj.Cpenvios = (gen.SetCampo(dr["cp_envios"].ToString()));
                    if (dr["ciudad_envios"] != DBNull.Value) obj.Ciudadenvios = (gen.SetCampo(dr["ciudad_envios"].ToString()));
                    if (dr["edo_envios"] != DBNull.Value) obj.Edoenvios = (gen.SetCampo(dr["edo_envios"].ToString()));
                    if (dr["tel_envios"] != DBNull.Value) obj.Telenvios = (gen.SetCampo(dr["tel_envios"].ToString()));
                    if (dr["email_envios"] != DBNull.Value) obj.Emailenvios = (gen.SetCampo(dr["email_envios"].ToString()));
                    if (dr["NoSucursal"] != DBNull.Value) obj.TotalSucursal = Convert.ToInt32(gen.SetCampo(dr["NoSucursal"].ToString()));
                    if (dr["ejecutivo_fact"] != DBNull.Value) obj.Ejecutivofact = (gen.SetCampo(dr["ejecutivo_fact"].ToString()));
                    lst.Add(obj);
                }
            }
            return lst;

        }

        public List<EntCliente> GetConsultaConsecutivoCliente(EntCliente Dobj, string tipo = "")
        {
            Genericas gen = new Genericas();
            List<EntCliente> lst = new List<EntCliente>();
            DBParameterCollection pcol = ParamCliente.LLenaCliente(Dobj, Comunes.BUSCAR, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpCliente, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntCliente obj = new EntCliente();
                    if (dr["ConsecutivoCliente"] != DBNull.Value) obj.ClaveCliente = Convert.ToInt32(gen.SetCampo(dr["ConsecutivoCliente"].ToString()));
                    lst.Add(obj);
                }
            }
            return lst;

        }

        public List<EntCliente> GetValidaRFC(EntCliente Dobj, string tipo = "")
        {
            Genericas gen = new Genericas();
            List<EntCliente> lst = new List<EntCliente>();
            DBParameterCollection pcol = ParamCliente.LLenaCliente(Dobj, Comunes.BUSCAR, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpCliente, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntCliente obj = new EntCliente();
                    if (dr["rfc_cliente"] != DBNull.Value) obj.Rfccliente = (gen.SetCampo(dr["rfc_cliente"].ToString()));
                    lst.Add(obj);
                }
            }
            return lst;

        }

        public int InsUpdClientes(EntCliente Dobj, string opc, string tipo)
        {
            Respuesta<int> res = new Respuesta<int>();

            DBParameterCollection pcol = ParamCliente.LLenaCliente(Dobj, opc, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpCliente, pcol, conm, tranm, CommandType.StoredProcedure))
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

        #region Sucursal

        public List<EntSucursal> GetConsultaSucursales(EntSucursal Dobj, string tipo = "")
        {
            List<EntSucursal> lst = new List<EntSucursal>();
            DBParameterCollection pcol = ParamCliente.LLenaSucursal(Dobj, Comunes.BUSCAR, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpSucursal, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    Genericas gen = new Genericas();
                    EntSucursal obj = new EntSucursal();
                    if (dr["clave_cliente"] != DBNull.Value) obj.Clave_cliente = gen.SetCampo(Convert.ToInt32(dr["clave_cliente"].ToString()));
                    if (dr["status_sucursal"] != DBNull.Value) obj.Status_sucursal = gen.SetCampo((dr["status_sucursal"].ToString()));
                    if (dr["Estatus"] != DBNull.Value) obj.Estatus = gen.SetCampo((dr["Estatus"].ToString()));
                    if (dr["fecha_apertura"] != DBNull.Value) obj.Fecha_apertura = gen.SetCampo((dr["fecha_apertura"].ToString()));
                    if (dr["FechaModifico"] != DBNull.Value) obj.FechaModifico1 = gen.SetCampo((dr["FechaModifico"].ToString()));
                    if (dr["nsucursal"] != DBNull.Value) obj.Nsucursal = gen.SetCampo(Convert.ToInt32(dr["nsucursal"].ToString()));
                    if (dr["sucursal"] != DBNull.Value) obj.Sucursal = gen.SetCampo((dr["sucursal"].ToString()));
                    if (dr["rfc_sucursal"] != DBNull.Value) obj.Rfc_sucursal = gen.SetCampo((dr["rfc_sucursal"].ToString()));
                    if (dr["sector_cliente"] != DBNull.Value) obj.Sector_cliente = gen.SetCampo((dr["sector_cliente"].ToString()));
                    if (dr["factura_sucursal"] != DBNull.Value) obj.Factura_sucursal = gen.SetCampo((dr["factura_sucursal"].ToString()));
                    if (dr["direccion_sucursal"] != DBNull.Value) obj.Direccion_sucursal = gen.SetCampo((dr["direccion_sucursal"].ToString()));
                    if (dr["colonia_sucursal"] != DBNull.Value) obj.Colonia_sucursal = gen.SetCampo((dr["colonia_sucursal"].ToString()));
                    if (dr["codigo_postal_sucursal"] != DBNull.Value) obj.Codigo_postal_sucursal = gen.SetCampo(Convert.ToInt32(dr["codigo_postal_sucursal"].ToString()));
                    if (dr["ciudad_sucursal"] != DBNull.Value) obj.Ciudad_sucursal = gen.SetCampo((dr["ciudad_sucursal"].ToString()));
                    if (dr["estado_sucursal"] != DBNull.Value) obj.Estado_sucursal = gen.SetCampo((dr["estado_sucursal"].ToString()));
                    if (dr["telefono1_sucursal"] != DBNull.Value) obj.Telefono1_sucursal = gen.SetCampo((dr["telefono1_sucursal"].ToString()));
                    if (dr["telefono2_sucursal"] != DBNull.Value) obj.Telefono2_sucursal = gen.SetCampo((dr["telefono2_sucursal"].ToString()));
                    if (dr["atencion_personal2_sucursal"] != DBNull.Value) obj.Atencion_personal2_sucursal = gen.SetCampo((dr["atencion_personal2_sucursal"].ToString()));
                    if (dr["e_mail"] != DBNull.Value) obj.E_mail = gen.SetCampo((dr["e_mail"].ToString()));
                    if (dr["atencion_personal1_sucursal"] != DBNull.Value) obj.Atencion_personal1_sucursal = gen.SetCampo((dr["atencion_personal1_sucursal"].ToString()));
                    if (dr["EmailCobranza"] != DBNull.Value) obj.EmailCobranza1 = gen.SetCampo((dr["EmailCobranza"].ToString()));
                    if (dr["observaciones"] != DBNull.Value) obj.Observaciones = gen.SetCampo((dr["observaciones"].ToString()));
                    if (dr["nombre_envios_sucursal"] != DBNull.Value) obj.Nombre_envios_sucursal = gen.SetCampo((dr["nombre_envios_sucursal"].ToString()));
                    if (dr["usuario_envios_sucursal"] != DBNull.Value) obj.Usuario_envios_sucursal = gen.SetCampo((dr["usuario_envios_sucursal"].ToString()));
                    if (dr["direccion_envios_sucursal"] != DBNull.Value) obj.Direccion_envios_sucursal = gen.SetCampo((dr["direccion_envios_sucursal"].ToString()));
                    if (dr["colonia_envios_sucursal"] != DBNull.Value) obj.Colonia_envios_sucursal = gen.SetCampo((dr["colonia_envios_sucursal"].ToString()));
                    if (dr["cp_envios_sucursal"] != DBNull.Value) obj.Cp_envios_sucursal = gen.SetCampo((dr["cp_envios_sucursal"].ToString()));
                    if (dr["ciudad_envios_sucursal"] != DBNull.Value) obj.Ciudad_envios_sucursal = gen.SetCampo((dr["ciudad_envios_sucursal"].ToString()));
                    if (dr["edo_envios_sucursal"] != DBNull.Value) obj.Edo_envios_sucursal = gen.SetCampo((dr["edo_envios_sucursal"].ToString()));
                    if (dr["tel_envios_sucursal"] != DBNull.Value) obj.Tel_envios_sucursal = gen.SetCampo((dr["tel_envios_sucursal"].ToString()));
                    if (dr["email_envios_sucursal"] != DBNull.Value) obj.Email_envios_sucursal = gen.SetCampo((dr["email_envios_sucursal"].ToString()));
                    if (dr["ejecutivo"] != DBNull.Value) obj.Ejecutivo = gen.SetCampo((dr["ejecutivo"].ToString()));
                    if (dr["usuario"] != DBNull.Value) obj.Usuario = gen.SetCampo((dr["usuario"].ToString()));
                    lst.Add(obj);
                }
            }
            return lst;

        }

        public List<EntSucursal> GetValidaSucursalRFC(EntSucursal Dobj, string tipo = "")
        {
            Genericas gen = new Genericas();
            List<EntSucursal> lst = new List<EntSucursal>();
            DBParameterCollection pcol = ParamCliente.LLenaSucursal(Dobj, Comunes.BUSCAR, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpSucursal, pcol, conm, tranm, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    EntSucursal obj = new EntSucursal();
                    if (dr["rfc_sucursal"] != DBNull.Value) obj.Rfc_sucursal = (gen.SetCampo(dr["rfc_sucursal"].ToString()));
                    lst.Add(obj);
                }
            }
            return lst;

        }

        public int InsUpdSucursal(EntSucursal Dobj, string opc, string tipo)
        {
            Respuesta<int> res = new Respuesta<int>();

            DBParameterCollection pcol = ParamCliente.LLenaSucursal(Dobj, opc, tipo);
            using (dr = db.ExecuteDataReader(Procedimientos.SpSucursal, pcol, conm, tranm, CommandType.StoredProcedure))
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

    }
}
