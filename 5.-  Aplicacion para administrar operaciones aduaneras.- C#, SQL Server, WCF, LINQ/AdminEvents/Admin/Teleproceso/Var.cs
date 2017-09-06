using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminEvents
{
    public class Var
    {
        private  static List<EntGeneral> tbs;
        private static string tbactual;
        private static List<DataTable> modtables;
        private static List<EntEncript> tabencript = new List<EntEncript>() {new EntEncript("d2ifra",new List<int>(){0,2,4,5}), 
            new EntEncript("d7ifra",new List<int>{0,2,4,5}), new EntEncript("d3ifra",new List<int>(){0,2,4,5}),new EntEncript("d2itrat", new List<int>(){0,1,3,17}),
            new EntEncript("d7itrat", new List<int>(){0,1,3,17}),new EntEncript("d3itrat", new List<int>(){0,1,3,17}),new EntEncript("d2iperm", new List<int>(){0,3}),new EntEncript("d7iperm",new List<int>(){0,3}),
            new EntEncript("d3iperm", new List<int>(){0,3}),new EntEncript("d2eperm",new List<int>(){0,3}),new EntEncript("d7eperm", new List<int>(){0,3}),new EntEncript("d3eperm", new List<int>(){0,3}),
            new EntEncript("d2ihperm", new List<int>(){0,3}),new EntEncript("d7ihperm",new List<int>(){0,3}),new EntEncript("d3ihperm", new List<int>(){0,3}),new EntEncript("d2ehperm",new List<int>(){0,3}),new EntEncript("d7ehperm", new List<int>(){0,3}),new EntEncript("d3ehperm", new List<int>(){0,3}),
            new EntEncript("d2icc", new List<int>(){0,2,4,5,6}),new EntEncript("d7icc",new List<int>(){0,2,4,5,6}),new EntEncript("d3icc",new List<int>(){0,2,4,5,6}),new EntEncript("d2ihcc",new List<int>(){0,2,4,5,6}),
            new EntEncript("d7ihcc",new List<int>(){0,2,4,5,6}),new EntEncript("d3ihcc",new List<int>(){0,2,4,5,6}),new EntEncript("d2isecre",new List<int>(){0,2,4,5,6}), new EntEncript("d7isecre",new List<int>(){0,2,4,5,6}),
            new EntEncript("d3isecre",new List<int>(){0,2,4,5,6})};
        private static List<EntTablaHist> tabhist = new List<EntTablaHist>(){ 
            new EntTablaHist("d3iperm",new List<int>(){0,1,2},"d3ihperm",new List<string>(){"fecha_do"}),
            new EntTablaHist("d3eperm",new List<int>(){0,1,2},"d3ehperm",new List<string>(){"fecha_do"}),new EntTablaHist("d3icc",new List<int>(){0,3,8},"d3ihcc", new List<string>(){"fecha_baj"}),
            new EntTablaHist("d3iccn1",new List<int>(){0,1},"d3ihccn1", new List<string>(){"fecha_baj","fecha"})

        };
        private static List<string> tablascodigo = new List<string>() { "d3ifra", "d7ifra", "d2ifra", "d3itrat", "d3inrego", "d3itlcco", "d3idtlc", "d3ictlcs", "d3ihistl", "d3idesgr", "D3IPERDE", "D3IART4", "D3INTLC", "D3INTLC", "D3IOTLC", "D3ICLCON", "D3INCLCO", "D3INTLCS",
        "D3ITLCNO","D3ICUPA","D3ECUPA","D3ICUPR","D3ECUPR","D3ICUPT","D3ITLCAR","D3IPTLC","D3IAZUC","D3EAZUC","D3IALCAP","D3IALH","D3IALC","D3IALHAP","D3IALCNO","D3IALCAR","D3IALHNO","D3IALHAR","D3IALAD6","D3IDECRE","D3IALADI","D3IHALAD","D3IALCUP","D3IFF","D3IHFF","D3INFF",
        "D3IMMEX","D3IMMEXN","D3ISECT","D3IHSECT","D3IPS4","D3IHPS4","D3IANE7","D3IANE8","D3IANE9","D3IANE10","D3IANE11","D3IANE14","D3IANE17","D3IANE21","D3IANE23","D3IANE28","D3IANE30","D3EANE10","D3EANE12","D3EANE14","D3EANE21","D3EANE30","D3INNOMS","D3ENNOMS","D3IHNNOM","D3EHNNOM","D3INETIQ","D3ENETIQ","D3IHNETI","D3EHNETI",
        "D3INTEX","D3IPREP","D3IHPREP","D3IPRED","D3IHPRED","D3IISAN","D3IHISAN","D3IIEPS","D3IHIEPS","D3IPERM","D3EPERM","D3IHPERM","D3INPER","D3ISECRE","D3ICC","D3IHCC","D3ICCN1","D3ICCA3","D3DGR","D3LABDGR","D3ICFP","D3ECFP","D3ICF","D3ECF","D3ICFD","D3ECFD","D3NQUIM",
        "D3IIVAL","D3IHIVAL","D3IIVAP","D3IIVAC","D3IIVAA","D3IHIVAA","D3IHIS","D3IHDES","D3IHUNI","D3IVEH","D3IVIG","D3IFNCT","D3ISINP","D3ICHKCH","D3NOTPR","D3INOTEX","D3ITEXTO"};
        private static List<EntEncript> tablacampotexto = new List<EntEncript>() { new EntEncript("D3IPERM", new List<int>() { 1, 2 }), new EntEncript("D3EPERM", new List<int>() { 1, 2 }), new EntEncript("D3ISECRE", new List<int>() { 0, 1 }), new EntEncript("D3INPER", new List<int>() { 0, 1 }) };

        private static List<string> tablasappend = new List<string>() { "appifra", "appitrat", "appifraad", "appinnoms", "appihnnom", "appinetiq", "appihneti", "appintex", "appicc", "appihcc", "appiccn1", "appihccn1", "appiperm", "appihperm", "appeperm", "appehperm", "appisecre", 
        "appinper", "appinrego", "appiane7", "appiane8", "appiane9", "appiane10", "appiane14", "appiane17", "appiane21", "appiane23", "appiane28", "appiane30", "appeane10", "appeane12", "appeane14", "appeane21", "appeane23", "appeane30", "appialad6", "appihalad", "appialcap", "appialhap", "appisect", "appitexto", "appimmexn", "appiap", "appantep" };

        private static List<EntEncript> tabappencript = new List<EntEncript>() {new EntEncript("appifra",new List<int>(){0,2,4,5}),new EntEncript("appitrat", new List<int>(){0,1,3,17}),new EntEncript("appiperm", new List<int>(){0,3}),new EntEncript("appeperm", new List<int>(){0,3}),
            new EntEncript("appihperm", new List<int>(){0,3}),new EntEncript("appehperm", new List<int>(){0,3}),
            new EntEncript("appicc",new List<int>(){0,2,4,5,6}),new EntEncript("appihcc",new List<int>(){0,2,4,5,6}),new EntEncript("appisecre",new List<int>(){0,2,4,5,6})};

        private static string bitacora;
        public List<EntGeneral> Tables {
            get { return tbs; }
            set { tbs = value; }
        }
        public string TbActual
        {
            get { return tbactual; }
            set { tbactual = value; }
        }
        public List<DataTable> Modtables {
            get { return  modtables; }
            set { modtables = value; }

        }
        public List<EntEncript> Tabencript {
            get { return tabencript; }
        }

        public List<EntEncript> Tabappencript
        {
            get { return tabappencript; }
        }
        public List<EntTablaHist> TabHist {
            get { return tabhist; }
        }
        public string Bitacora {
            get { return bitacora; }
            set { bitacora = value; }
        }
        public List<string> TablasCodigo
        {
            get { return tablascodigo; }
        }

        public List<string> TablasAppend
        {
            get { return tablasappend; }
        }

        public List<EntEncript> TablacampoTexto
        {
            get { return tablacampotexto; }
        }

    }
}
