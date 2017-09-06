using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminEvents
{
    public class EntTeles
    {
        private int id;
        private string sistema;
        private string titulo;
        private int tamaño;
        private string url;
        private string descripcion;


        #region
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Sistema
        {
            get { return sistema; }
            set { sistema = value; }
        }
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public int Tamaño
        {
            get { return tamaño; }
            set { tamaño = value; }
        }
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        #endregion

        #region
        public EntTeles()
        {
            id = 0;
            sistema = string.Empty;
            titulo = string.Empty;
            tamaño = 0;
            url = string.Empty;
            descripcion = string.Empty;

        }
        public EntTeles(int vid, string vsistema, string vtitulo, int vtamaño, string vurl, string vdescripcion)
        {
            id = vid;
            sistema = vsistema;
            titulo = vtitulo;
            tamaño = vtamaño;
            url = vurl;
            descripcion = vdescripcion;

        }
        #endregion
    }
}
