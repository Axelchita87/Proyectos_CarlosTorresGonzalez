using AdminEvents;
using AdminEvents.AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminEvents
{
    public class TlsDescarga
    {
        public string pathFile { get; set; }
        DALEventosSDI ejec = new DALEventosSDI();

        public void CargaDatosjs()
        {
            try
            {
                string Archivo = ConfigurationManager.AppSettings["ArchivoJSTele"];
                FileInfo dir = new FileInfo(Archivo);
                pathFile = System.IO.Path.Combine(dir.Directory.ToString(), Archivo);
                DataSet dsEventos = new DataSet();

                MemoryStream stream1 = new MemoryStream();
                DataContractJsonSerializer ser;
                DataTable dtEventos = new DataTable();
                EntTeles entTELE = new EntTeles();

                dsEventos = ejec.GetConsultaTele(entTELE, "V");
                dtEventos = dsEventos.Tables[0];


                List<EntTeles> lsteq = new List<EntTeles>();

                if (dtEventos.Rows.Count > 0)
                {
                    foreach (DataRow item in dtEventos.Rows)
                    {
                        EntTeles evento = new EntTeles();
                        evento.Id = Convert.ToInt32(item[0]);
                        evento.Sistema = item[1].ToString();
                        evento.Titulo = item[2].ToString();
                        evento.Tamaño = Convert.ToInt32(item[3]);
                        evento.Url = item[4].ToString();
                        evento.Descripcion = item[5].ToString();

                        lsteq.Add(evento);
                    }
                    ser = new DataContractJsonSerializer(typeof(List<EntTeles>));

                    ser.WriteObject(stream1, lsteq);
                }
                else
                {
                    MessageBox.Show("No existen datos que mostrar", "La consulta no arroja información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                stream1.Position = 0;
                StreamReader sr = new StreamReader(stream1);

                System.IO.StreamWriter sw = new System.IO.StreamWriter(pathFile);
                string txto = sr.ReadToEnd();
                sw.WriteLine(txto);
                sw.Close();

                if (pathFile != string.Empty)
                {
                    ConexionFTP ftp = new ConexionFTP();
                    ConexionFTP2 ftp2 = new ConexionFTP2();

                    string file = System.IO.Path.GetFileName(pathFile);

                    bool res = ftp.SubirFTPArchivo(pathFile);

                    if (res)
                    {
                        res = ftp2.SubirFTPArchivo(pathFile);
                        if (res)
                        {
                            MessageBox.Show("Se actualizó la información en la página Web de SDI.", "Se actualizó la información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se puedo subir el archivo", "Operación sin exito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puedo subir el archivo", "Operación sin exito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InstDatos(string Sistema, string NombreArchivo, string Tamaño, string Descripcion)
        {
            try
            {
                EntTeles entt = new EntTeles();
                DataSet dsEventos = new DataSet();
                if (Sistema == "SITA")
                    entt.Sistema = "SAAI";
                else
                    entt.Sistema = Sistema;
                dsEventos = ejec.GetConsultaTele(entt, "M");
                DataTable dtEventos = new DataTable();
                dtEventos = dsEventos.Tables[0];
                entt = new EntTeles();
                foreach (DataRow item in dtEventos.Rows)
                    entt.Id = Convert.ToInt32(item[0]) + 1;

                entt.Sistema = Sistema;
                entt.Titulo = NombreArchivo;
                entt.Tamaño = Convert.ToInt32(Tamaño);
                if (Sistema == "SITA")
                {
                    entt.Sistema = "SAAI";
                    entt.Url = "../SDI_Updates/SAAI/" + NombreArchivo;
                }
                else
                {
                    entt.Sistema = Sistema;
                    entt.Url = "../SDI_Updates/" + Sistema + "/" + NombreArchivo;
                }

                entt.Descripcion = Descripcion;
                string opci = "A";
                int res = ejec.InsActTele(opci, entt);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
