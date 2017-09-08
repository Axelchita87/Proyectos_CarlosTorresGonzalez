using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AdminEvents
{
	[Serializable]
	public class EntGeneral
	{
        private int filtro;
		private int id;
		private string descripcion;

	#region Metodos
        public int Filtro
        {
            set { filtro = value; }
            get { return filtro; }
        }

		public int Id {
			set { id = value; }
			get { return id; }
		}

		public string Descripcion {
			set { descripcion = value; }
			get { return descripcion; }
		}


	#endregion
	#region Constructor
		public EntGeneral(){
		}
		public EntGeneral(int vid, string vdescripcion) {

			id = vid;
			descripcion = vdescripcion;
		}
	#endregion
	}
}