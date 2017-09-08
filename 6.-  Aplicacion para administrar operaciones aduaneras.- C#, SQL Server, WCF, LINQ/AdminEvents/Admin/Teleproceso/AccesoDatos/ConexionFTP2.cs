using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdminEvents.AccesoDatos
{
    class ConexionFTP2
    {
        #region parámetros FTP
        string server = ConfigurationManager.AppSettings["servFTP2"],
                   path = ConfigurationManager.AppSettings["pathFTP2"],
                   user = ConfigurationManager.AppSettings["userFTP2"],
                   pwd = ConfigurationManager.AppSettings["pwdFTP2"];
        int port = Convert.ToInt32(ConfigurationManager.AppSettings["portFTP2"]);
        #endregion

        public bool SubirFTPArchivo(string file)
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

        public bool FFTPTele(string path, string file)
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
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + server + ":" + port.ToString() + "/" + path);
                request.Proxy = null;
                request.Method = WebRequestMethods.Ftp.UploadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(user, pwd);
                request.UseBinary = true;
                // Copy the contents of the file to the request stream.
                //StreamReader sourceStream = new StreamReader(file);
                FileStream stream = File.OpenRead(file);
                //byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                byte[] fileContents = new byte[stream.Length];
                //sourceStream.Close();
                stream.Read(fileContents, 0, fileContents.Length);

                stream.Close();
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

        public bool DeleteFileOnServer(string fileName)
        {
            Uri serverUri = new Uri("ftp://" + server + ":" + port.ToString() + path + "TiposCambio2.js");

            // The serverUri parameter should use the ftp:// scheme.
            // It contains the name of the server file that is to be deleted.
            // Example: ftp://contoso.com/someFile.txt.
            // 

            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Proxy = null;
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.Credentials = new NetworkCredential(user, pwd);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine("Delete status: {0}", response.StatusDescription);
            response.Close();
            return true;
        }
    }
}
