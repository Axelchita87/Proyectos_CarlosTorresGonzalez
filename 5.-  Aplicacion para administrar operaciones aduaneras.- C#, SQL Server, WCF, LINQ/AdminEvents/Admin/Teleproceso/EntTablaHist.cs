using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AdminEvents
{
	[Serializable]
	public class EntTablaHist
	{
		private string tabla;
		private List<int> llave;
		private string tablahist;
        private List<string> camposad;

	#region Metodos

		public string Tabla {
			set { tabla = value; }
			get { return tabla; }
		}

		public List<int> Llave {
			set { llave = value; }
			get { return llave; }
		}

		public string TablaHist {
			set { tablahist = value; }
			get { return tablahist; }
		}
        public List<string> CamposAd
        {
            set { camposad = value; }
            get { return camposad; }
        }


	#endregion
	#region Constructor
		public EntTablaHist(){
		}
		public EntTablaHist(string vtabla, List<int> vllave, string vtablahist, List<string> vcamposad) {

			tabla = vtabla;
			llave = vllave;
			tablahist = vtablahist;
            camposad = vcamposad;
		}
	#endregion
	}
}