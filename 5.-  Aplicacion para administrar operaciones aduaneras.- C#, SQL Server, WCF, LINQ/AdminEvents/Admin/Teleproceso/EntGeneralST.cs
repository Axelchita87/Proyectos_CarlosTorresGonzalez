using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AdminEvents
{
	[Serializable]
	public class EntGeneralST
	{
		private string id;
		private string descripcion;

	#region Metodos

		public string Id {
			set { id = value; }
			get { return id; }
		}

		public string Descripcion {
			set { descripcion = value; }
			get { return descripcion; }
		}


	#endregion
	#region Constructor
		public EntGeneralST(){
		}
		public EntGeneralST(string vid, string vdescripcion) {

			id = vid;
			descripcion = vdescripcion;
		}
	#endregion
	}
}