using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN2.DAL
{
    public class DALBaseMSQL : IDisposable
    {
        protected string conx = string.Empty;
        protected SqlConnection conm = null;
        protected SqlTransaction tranm = null;

        public void Dispose()
        {
        }

        ~DALBaseMSQL()
        {
            conm.Close();
            conm.Dispose();
        }

        public DALBaseMSQL()
        {
            conx = ConfigurationManager.ConnectionStrings["conxAdm"].ConnectionString;
            conm = new SqlConnection(conx);
            conm.Open();
        }

        #region Metodos Genericos
        public bool begTran()
        {
            bool ini = false;
            try
            {

                tranm = conm.BeginTransaction();
                ini = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ini;
        }
        public void roll_back()
        {
            try
            {
                tranm.Rollback();
                conm.Close();
                conm.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void commit()
        {
            try
            {
                tranm.Commit();
                if (conm != null && conm.State == ConnectionState.Open)
                {
                    conm.Close();
                    conm.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void close()
        {
            conm.Close();
            conm.Dispose();
        }

        public string ReadFile(string file)
        {
            string res = File.ReadAllText(file, Encoding.Default);
            return res;
        }

        #endregion

        /// <summary>
        /// Método que ejecuta una consulta SQL y regresa los resultados obtenidos
        /// </summary>
        /// <param name="queryString">Consulta SQL a ejecutar</param>
        /// <returns>Regresa un DataSet con los resultados de la consulta SQL</returns>
        public DataTable EjecutarConsulta(string queryString)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(queryString, conm);

                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conm.Close();
            }
        }
    }
}
