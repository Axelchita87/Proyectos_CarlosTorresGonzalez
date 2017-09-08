using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.IO;

namespace AdminEvents
{
    public class SDIServDAL
    {
        private SqlConnection con;
        private SqlTransaction tran;
        public SDIServDAL(int prod) {
            string conx=string.Empty;
            if (prod==0)
                conx = ConfigurationManager.ConnectionStrings["cnxSDIServPre"].ConnectionString;
            else
                conx = ConfigurationManager.ConnectionStrings["cnxSDIServProd"].ConnectionString;

            con = new SqlConnection(conx);
            con.Open();
        }
        public bool begTran()
        {
            bool ini = false;
            try
            {

                tran = con.BeginTransaction();
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
                tran.Rollback();
                con.Close();
                con.Dispose();
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
                tran.Commit();
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void close()
        {

            con.Close();
            con.Dispose();

        }
        public int InsUpdSDIServ(int id, string version, string ctrl, byte[] Arch, string nombre) {
            int res = 0;
            try
            {
                SqlCommand com = new SqlCommand("spDIAAct", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@popc", "M"));
                com.Parameters.Add(new SqlParameter("@pId", id));
                com.Parameters.Add(new SqlParameter("@pver", version));
                com.Parameters.Add(new SqlParameter("@pctrl", ctrl));
                com.Parameters.Add(new SqlParameter("@pArch", Arch));
                com.Parameters.Add(new SqlParameter("@pNomArch", nombre));
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    int err = Convert.ToInt32(dr[0]);
                    if (err > 0)
                        throw new Exception(dr[1].ToString());
                    else
                        res = Convert.ToInt32(dr[2].ToString());
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            return res;
        }
        public static bool FFTP(string server, string user, string pwd, int port, string path, string file)
        {
            bool res = false;
            try
            {
                if (path != string.Empty)
                {
                    if (!path.StartsWith("/"))
                        path = "/" + path;
                    if (path.Substring(path.Length - 1, 1) == "/")
                        path = path.Substring(0, path.Length - 1);
                }
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + server + ":" + port.ToString() + path + "/" + Path.GetFileName(file));
                request.Proxy = null;
                request.Method = WebRequestMethods.Ftp.UploadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(user, pwd);
                request.UseBinary = true;
                // Copy the contents of the file to the request stream.
                StreamReader sourceStream = new StreamReader(file);
                byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close();
                request.ContentLength = fileContents.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                res = true;

                response.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

    }
}
