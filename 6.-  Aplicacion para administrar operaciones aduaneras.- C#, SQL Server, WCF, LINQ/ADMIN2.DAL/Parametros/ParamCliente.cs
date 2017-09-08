using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMIN2.Entity;

namespace ADMIN2.DAL
{
    public class ParamCliente
    {
        public static DBParameterCollection LLenaTipoCliente(EntTipoCliente obj, string opc)
        {
            DBParameter p1 = new DBParameter("popc", opc, System.Data.DbType.String);

            DBParameter[] parms = new DBParameter[] { p1 };
            DBParameterCollection pcol = new DBParameterCollection();
            pcol.AddRange(parms);
            return pcol;
        }

        public static DBParameterCollection LLenaEstatusCliente(EntEstatusCliente obj, string opc)
        {
            DBParameter p1 = new DBParameter("popc", opc, System.Data.DbType.String);

            DBParameter[] parms = new DBParameter[] { p1 };
            DBParameterCollection pcol = new DBParameterCollection();
            pcol.AddRange(parms);
            return pcol;
        }

        public static DBParameterCollection LLenaSectorCliente(EntSectorCliente obj, string opc)
        {
            DBParameter p1 = new DBParameter("popc", opc, System.Data.DbType.String);

            DBParameter[] parms = new DBParameter[] { p1 };
            DBParameterCollection pcol = new DBParameterCollection();
            pcol.AddRange(parms);
            return pcol;
        }

        public static DBParameterCollection LLenaTipoDocumento(EntTipoDocumento obj, string opc, string tipo="")
        {
            DBParameter p1 = new DBParameter("popc", opc, System.Data.DbType.String);

            DBParameter[] parms = new DBParameter[] { p1 };
            DBParameterCollection pcol = new DBParameterCollection();
            pcol.AddRange(parms);
            return pcol;
        }

        public static DBParameterCollection LLenaEntidades(EntEntidades obj, string opc, string tipo = "")
        {
            DBParameter p1 = new DBParameter("popc", opc, System.Data.DbType.String);
            DBParameter p2 = new DBParameter("tipo", tipo, System.Data.DbType.String);
            DBParameter p3 = new DBParameter("IdEstado", obj.IdEstado, System.Data.DbType.Int32);
            DBParameter p4 = new DBParameter("IdMunicipio", obj.IdMunicipio, System.Data.DbType.Int32);
            DBParameter p5 = new DBParameter("IdCodigoPostal", obj.IdCodigo, System.Data.DbType.Int32);

            DBParameter[] parms = new DBParameter[] { p1, p2, p3, p4, p5 };
            DBParameterCollection pcol = new DBParameterCollection();
            pcol.AddRange(parms);
            return pcol;
        }

        public static DBParameterCollection LLenaCliente(EntCliente obj, string opc, string tipo = "")
        {            
            DBParameter p1 = new DBParameter("popc", opc, System.Data.DbType.String);
            DBParameter p2 = new DBParameter("tipo", tipo, System.Data.DbType.String);
            DBParameter p3 = new DBParameter("ClaveCliente", obj.ClaveCliente, System.Data.DbType.Int32);
            DBParameter p4 = new DBParameter("nombre_cliente", obj.Nombrecliente, System.Data.DbType.String);
            DBParameter p5 = new DBParameter("nombre_envios", obj.Nombreenvios, System.Data.DbType.String);
            DBParameter p6 = new DBParameter("usuario_envios", obj.Usuarioenvios, System.Data.DbType.String);
            DBParameter p7 = new DBParameter("direccion_envios", obj.Direccionenvios, System.Data.DbType.String);
            DBParameter p8 = new DBParameter("ciudad_envios", obj.Ciudadenvios, System.Data.DbType.String);
            DBParameter p9 = new DBParameter("colonia_envios", obj.Coloniaenvios, System.Data.DbType.String);
            DBParameter p10 = new DBParameter("cp_envios", obj.Cpenvios, System.Data.DbType.String);
            DBParameter p11 = new DBParameter("tel_envios", obj.Telenvios, System.Data.DbType.String);
            DBParameter p12 = new DBParameter("edo_envios", obj.Edoenvios, System.Data.DbType.String);
            DBParameter p13 = new DBParameter("email_envios", obj.Emailenvios, System.Data.DbType.String);
            DBParameter p14 = new DBParameter("direccion_cliente", obj.Direccioncliente, System.Data.DbType.String);
            DBParameter p15 = new DBParameter("colonia_cliente", obj.Coloniacliente, System.Data.DbType.String);
            DBParameter p16 = new DBParameter("codigo_postal_cliente", obj.Codigopostalcliente, System.Data.DbType.String);
            DBParameter p17 = new DBParameter("ciudad_cliente", obj.Ciudadcliente, System.Data.DbType.String);
            DBParameter p18 = new DBParameter("estado_cliente", obj.Estadocliente, System.Data.DbType.String);
            DBParameter p19 = new DBParameter("facturacion_cliente", obj.Facturacioncliente, System.Data.DbType.String);
            DBParameter p20 = new DBParameter("rfc_cliente", obj.Rfccliente, System.Data.DbType.String);
            DBParameter p21 = new DBParameter("telefono1_cliente", obj.Telefono1cliente, System.Data.DbType.String);
            DBParameter p22 = new DBParameter("telefono2_cliente", obj.Telefono2cliente, System.Data.DbType.String);
            DBParameter p23 = new DBParameter("atencion_personal1_cliente", obj.Atencionpersonal1cliente, System.Data.DbType.String);
            DBParameter p24 = new DBParameter("status_cliente", obj.Statuscliente, System.Data.DbType.Int32);
            DBParameter p25 = new DBParameter("ejecutivo", obj.Ejecutivo, System.Data.DbType.String);
            DBParameter p26 = new DBParameter("sector_cliente", obj.Sectorcliente, System.Data.DbType.String);
            DBParameter p27 = new DBParameter("e_mail_cliente", obj.Emailcliente, System.Data.DbType.String);
            DBParameter p28 = new DBParameter("iguala", obj.Iguala, System.Data.DbType.Int32);
            DBParameter p29 = new DBParameter("ejecutivo_fact", obj.Ejecutivofact, System.Data.DbType.String);
            DBParameter p30 = new DBParameter("PAIS", obj.Pais, System.Data.DbType.String);
            DBParameter p31 = new DBParameter("IdRfcEua", obj.IdRfcEua, System.Data.DbType.String);
            DBParameter p32 = new DBParameter("EmailSecEnvios", obj.EmailSecEnvios, System.Data.DbType.String);
            DBParameter p33 = new DBParameter("TipoVIP", obj.TipoVIP, System.Data.DbType.String);
            DBParameter p34 = new DBParameter("IdUsuarioRegistro", obj.IdUsuarioRegistro, System.Data.DbType.Int32);
            DBParameter p35 = new DBParameter("IdUsuarioModifico", obj.IdUsuarioModifico, System.Data.DbType.Int32);
            DBParameter[] parms = new DBParameter[] { p1, p2, p3, p4, p5,p6,p7,p8,p9,p10,
                                                    p11,p12,p13,p14,p15,p16,p17,p18,p19,p20,
                                                    p21,p22,p23,p24,p25,p26,p27,p28,p29,p30,
                                                    p31,p32,p33, p34, p35};
            DBParameterCollection pcol = new DBParameterCollection();

            pcol.AddRange(parms);
            return pcol;
        }

        public static DBParameterCollection LLenaSucursal(EntSucursal obj, string opc, string tipo = "")
        {
            DBParameter p1 = new DBParameter("popc", opc, System.Data.DbType.String);
            DBParameter p2 = new DBParameter("tipo", tipo, System.Data.DbType.String);
            DBParameter p3 = new DBParameter("clave_cliente", obj.Clave_cliente, System.Data.DbType.Int32);
            DBParameter p4 = new DBParameter("nsucursal", obj.Nsucursal, System.Data.DbType.Int32);
            DBParameter p5 = new DBParameter("sucursal", obj.Sucursal, System.Data.DbType.String);
            DBParameter p6 = new DBParameter("factura_sucursal", obj.Factura_sucursal, System.Data.DbType.String);
            DBParameter p7 = new DBParameter("direccion_sucursal", obj.Direccion_sucursal, System.Data.DbType.String);
            DBParameter p8 = new DBParameter("colonia_sucursal", obj.Colonia_sucursal, System.Data.DbType.String);
            DBParameter p9 = new DBParameter("ciudad_sucursal", obj.Ciudad_sucursal, System.Data.DbType.String);
            DBParameter p10 = new DBParameter("codigo_postal_sucursal", obj.Codigo_postal_sucursal, System.Data.DbType.Int32);
            DBParameter p11 = new DBParameter("estado_sucursal", obj.Estado_sucursal, System.Data.DbType.String);
            DBParameter p12 = new DBParameter("telefono1_sucursal", obj.Telefono1_sucursal, System.Data.DbType.String);
            DBParameter p13 = new DBParameter("telefono2_sucursal", obj.Telefono2_sucursal, System.Data.DbType.String);
            DBParameter p14 = new DBParameter("nombre_envios_sucursal", obj.Nombre_envios_sucursal, System.Data.DbType.String);
            DBParameter p15 = new DBParameter("usuario_envios_sucursal", obj.Usuario_envios_sucursal, System.Data.DbType.String);
            DBParameter p16 = new DBParameter("direccion_envios_sucursal", obj.Direccion_envios_sucursal, System.Data.DbType.String);
            DBParameter p17 = new DBParameter("ciudad_envios_sucursal", obj.Ciudad_envios_sucursal, System.Data.DbType.String);
            DBParameter p18 = new DBParameter("colonia_envios_sucursal", obj.Colonia_envios_sucursal, System.Data.DbType.String);
            DBParameter p19 = new DBParameter("cp_envios_sucursal", obj.Cp_envios_sucursal, System.Data.DbType.String);
            DBParameter p20 = new DBParameter("tel_envios_sucursal", obj.Tel_envios_sucursal, System.Data.DbType.String);
            DBParameter p21 = new DBParameter("edo_envios_sucursal", obj.Edo_envios_sucursal, System.Data.DbType.String);
            DBParameter p22 = new DBParameter("email_envios_sucursal", obj.Email_envios_sucursal, System.Data.DbType.String);
            DBParameter p23 = new DBParameter("atencion_personal1_sucursal", obj.Atencion_personal1_sucursal, System.Data.DbType.String);
            DBParameter p24 = new DBParameter("atencion_personal2_sucursal", obj.Atencion_personal2_sucursal, System.Data.DbType.String);
            DBParameter p25 = new DBParameter("status_sucursal", obj.Status_sucursal, System.Data.DbType.String);
            DBParameter p26 = new DBParameter("ejecutivo", obj.Ejecutivo, System.Data.DbType.String);
            DBParameter p27 = new DBParameter("fecha_apertura", obj.Fecha_apertura, System.Data.DbType.String);
            DBParameter p28 = new DBParameter("e_mail", obj.E_mail, System.Data.DbType.String);
            DBParameter p29 = new DBParameter("observaciones", obj.Observaciones, System.Data.DbType.String);
            DBParameter p30 = new DBParameter("usuario", obj.Usuario, System.Data.DbType.String);
            DBParameter p31 = new DBParameter("FechaModifico", obj.FechaModifico1, System.Data.DbType.String);
            DBParameter p32 = new DBParameter("rfc_sucursal", obj.Rfc_sucursal, System.Data.DbType.String);
            DBParameter p33 = new DBParameter("sector_cliente", obj.Sector_cliente, System.Data.DbType.String);
            DBParameter p34 = new DBParameter("EmailCobranza", obj.EmailCobranza1, System.Data.DbType.String);
            DBParameter p35 = new DBParameter("IdUsuarioRegistro", obj.IdUsuarioRegistro1, System.Data.DbType.Int32);
            DBParameter p36 = new DBParameter("IdUsuarioModifico", obj.IdUsuarioModifico1, System.Data.DbType.Int32);

            DBParameter[] parms = new DBParameter[] { p1, p2, p3, p4, p5,p6,p7,p8,p9,p10,
                                                    p11,p12,p13,p14,p15,p16,p17,p18,p19,p20,
                                                    p21,p22,p23,p24,p25,p26,p27,p28,p29,p30,
                                                    p31,p32,p33, p34, p35, p36};

            DBParameterCollection pcol = new DBParameterCollection();
            pcol.AddRange(parms);
            return pcol;
        }

    }
}

