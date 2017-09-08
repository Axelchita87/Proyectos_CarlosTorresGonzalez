using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminEvents;
namespace AdminEvents
{
    public class DALEventosSDI
    {
        #region Procedimientos de almacenamiento
        const string SP_ARIONINPC = "proc_IndiceNPC";
        const string SP_EQUIVALENCIADLL = "proc_EqDolares";
        const string SP_TELE = "proc_Files";
        const string SP_USUARIO = "proc_Usuarios3";
        const string SP_USUARIO2 = "proc_Usuarios2";
        #endregion

        string conexion = ConfigurationManager.ConnectionStrings["ConEventosSDI"].ConnectionString;

        internal DataSet GetConsultaEventosSDI(string FechaInicio, string FechaFin, int IdProducto, bool Demos = false)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    DataSet ds = new DataSet();
                    con.Open();
                    DataTable dt = new DataTable();

                    SqlCommand cmmd = new SqlCommand(Demos ? "proc_DemosSDI" : "proc_EventosSDI", con);
                    cmmd.CommandType = CommandType.StoredProcedure;
                    cmmd.Parameters.AddWithValue("@popc", 'V');
                    if (FechaInicio != string.Empty && FechaFin != string.Empty)
                    {
                        cmmd.Parameters.AddWithValue("@PCUANDO", Convert.ToDateTime(FechaInicio));
                        cmmd.Parameters.AddWithValue("@PFECHFIN", Convert.ToDateTime(FechaFin));
                    }
                    if (IdProducto > 0)
                    {
                        cmmd.Parameters.AddWithValue("@PIDPRODUCTO", IdProducto);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmmd);
                    da.Fill(ds);

                    con.Close();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        internal int InsActEventosSDI(int id, DateTime cuando, DateTime FechFin, string descripcion, string lugar, int IdProducto = 1, string Duracion = "", string Alcance = "", string Dirigido = "", string Modalidad = "", string opc = "", bool Demos = false)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {




                    int respuesta = 0;
                    int error = 0;
                    int idc = 0;
                    string descError = string.Empty;
                    con.Open();
                    DataTable dt = new DataTable();

                    SqlCommand cmmd = new SqlCommand(Demos ? "proc_DemosSDI" : "proc_EventosSDI", con);
                    cmmd.CommandType = CommandType.StoredProcedure;
                    cmmd.Parameters.AddWithValue("@popc", opc);
                    cmmd.Parameters.AddWithValue("@PID", id);
                    cmmd.Parameters.AddWithValue("@PCUANDO", cuando);
                    cmmd.Parameters.AddWithValue("@PDESCRIPCION", descripcion);
                    cmmd.Parameters.AddWithValue("@PLUGAR", lugar);
                    cmmd.Parameters.AddWithValue("@PFECHFIN", FechFin);
                    cmmd.Parameters.AddWithValue("@PIDPRODUCTO", IdProducto);
                    cmmd.Parameters.AddWithValue("@PDURACION", Duracion);
                    cmmd.Parameters.AddWithValue("@PALCANCE", Alcance);
                    cmmd.Parameters.AddWithValue("@PDIRIGIDO", Dirigido);
                    cmmd.Parameters.AddWithValue("@PMODALIDAD", Modalidad);

                    SqlDataReader dr = cmmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr[0] != DBNull.Value) error = Convert.ToInt32(dr[0]);
                        if (dr[1] != DBNull.Value) descError = dr[1].ToString();
                        if (dr[2] != DBNull.Value) idc = Convert.ToInt32(dr[2]);
                        if (error == 0)
                        {
                            respuesta = idc;
                        }
                    }

                    con.Close();
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        

        
                      
        /// <summary>
        /// Consulta los archivos de descarga
        /// </summary>
        public DataSet GetConsultaTele(EntTeles ent, string opc)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    DataSet ds = new DataSet();
                    con.Open();
                    DataTable dt = new DataTable();

                    SqlCommand cmmd = new SqlCommand(SP_TELE, con);
                    cmmd.CommandType = CommandType.StoredProcedure;
                    cmmd.Parameters.AddWithValue("@popc", opc);
                    cmmd.Parameters.AddWithValue("@pid", ent.Id);
                    cmmd.Parameters.AddWithValue("@psistema", ent.Sistema);
                    cmmd.Parameters.AddWithValue("@ptitulo", ent.Titulo);
                    cmmd.Parameters.AddWithValue("@ptamanio", ent.Tamaño);
                    cmmd.Parameters.AddWithValue("@purl", ent.Url);
                    cmmd.Parameters.AddWithValue("@pdescripción", ent.Descripcion);

                    SqlDataAdapter da = new SqlDataAdapter(cmmd);
                    da.Fill(ds);

                    con.Close();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Inserta en la tabla de IndiceNPC
        /// </summary>
        /// <param name="opc">opcion de la accion a realizar C:Cambio B:Borrado A:Agregar</param>
        /// <param name="ent">entidad con la información a subir</param>
        /// <returns></returns>
        internal int InsActTele(string opc, EntTeles ent)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    int respuesta = 0;
                    int error = 0;
                    int idc = 0;
                    string descError = string.Empty;
                    con.Open();
                    DataTable dt = new DataTable();

                    SqlCommand cmmd = new SqlCommand(SP_TELE, con);
                    cmmd.CommandType = CommandType.StoredProcedure;
                    cmmd.Parameters.AddWithValue("@popc", opc);
                    cmmd.Parameters.AddWithValue("@pid", ent.Id);
                    cmmd.Parameters.AddWithValue("@psistema", ent.Sistema);
                    cmmd.Parameters.AddWithValue("@ptitulo", ent.Titulo);
                    cmmd.Parameters.AddWithValue("@ptamanio", ent.Tamaño);
                    cmmd.Parameters.AddWithValue("@purl", ent.Url);
                    cmmd.Parameters.AddWithValue("@pdescripción", ent.Descripcion);

                    SqlDataReader dr = cmmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr[0] != DBNull.Value) error = Convert.ToInt32(dr[0]);
                        if (dr[1] != DBNull.Value) descError = dr[1].ToString();
                        if (dr[2] != DBNull.Value) idc = Convert.ToInt32(dr[2]);
                        if (error == 0)
                        {
                            respuesta = idc;
                        }
                    }

                    con.Close();
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Consulta de los usuarios
        /// </summary>
        public DataSet GetConsultaUsuario(EntUsuario_ ent, string opc)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    DataSet ds = new DataSet();
                    con.Open();
                    DataTable dt = new DataTable();

                    SqlCommand cmmd = new SqlCommand(SP_USUARIO, con);
                    cmmd.CommandType = CommandType.StoredProcedure;
                    cmmd.Parameters.AddWithValue("@popc", opc);
                    cmmd.Parameters.AddWithValue("@puserid", ent.Id);
                    cmmd.Parameters.AddWithValue("@pusuario", ent.Usuario);
                    cmmd.Parameters.AddWithValue("@pno_serie", ent.NoSerie);//Agregado
                    cmmd.Parameters.AddWithValue("@ppassword", ent.Password);
                    cmmd.Parameters.AddWithValue("@pnombre", ent.Nombre);
                    cmmd.Parameters.AddWithValue("@pdia", ent.Dia);
                    cmmd.Parameters.AddWithValue("@psaai", ent.Saai);
                    cmmd.Parameters.AddWithValue("@psita", ent.Sita);
                    cmmd.Parameters.AddWithValue("@psitaw", ent.Sitaw);
                    cmmd.Parameters.AddWithValue("@pCOVE", ent.Cove);
                    cmmd.Parameters.AddWithValue("@pOnLine", ent.Online);
                    cmmd.Parameters.AddWithValue("@pstatus", ent.Status);

                    SqlDataAdapter da = new SqlDataAdapter(cmmd);
                    da.Fill(ds);

                    con.Close();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Inserta en la tabla de Usuarios
        /// </summary>
        /// <param name="opc">opcion de la accion a realizar C:Cambio B:Borrado A:Agregar</param>
        /// <param name="ent">entidad con la información a subir</param>
        /// <returns></returns>
        internal int InsActUsuario(string opc, EntUsuario_ ent)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    int respuesta = 0;
                    int error = 0;
                    int idc = 0;
                    string descError = string.Empty;
                    con.Open();
                    DataTable dt = new DataTable();

                    SqlCommand cmmd = new SqlCommand(SP_USUARIO, con);
                    cmmd.CommandType = CommandType.StoredProcedure;
                    cmmd.Parameters.AddWithValue("@popc", opc);
                    cmmd.Parameters.AddWithValue("@puserid", ent.Id);
                    cmmd.Parameters.AddWithValue("@pusuario", ent.Usuario);
                    cmmd.Parameters.AddWithValue("@pno_serie", ent.NoSerie);//Agregado
                    cmmd.Parameters.AddWithValue("@ppassword", ent.Password);
                    cmmd.Parameters.AddWithValue("@pnombre", ent.Nombre);
                    cmmd.Parameters.AddWithValue("@pdia", ent.Dia);
                    cmmd.Parameters.AddWithValue("@psaai", ent.Saai);
                    cmmd.Parameters.AddWithValue("@psita", ent.Sita);
                    cmmd.Parameters.AddWithValue("@psitaw", ent.Sitaw);
                    cmmd.Parameters.AddWithValue("@pCOVE", ent.Cove);
                    cmmd.Parameters.AddWithValue("@pOnLine", ent.Online);
                    cmmd.Parameters.AddWithValue("@pstatus", ent.Status);
                    cmmd.Parameters.AddWithValue("@pCOA", ent.Coa);

                    SqlDataReader dr = cmmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr[0] != DBNull.Value) error = Convert.ToInt32(dr[0]);
                        if (dr[1] != DBNull.Value) descError = dr[1].ToString();
                        if (dr[2] != DBNull.Value) idc = Convert.ToInt32(dr[2]);
                        if (error == 0)
                        {
                            respuesta = idc;
                        }
                    }

                    con.Close();
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
    }
}
