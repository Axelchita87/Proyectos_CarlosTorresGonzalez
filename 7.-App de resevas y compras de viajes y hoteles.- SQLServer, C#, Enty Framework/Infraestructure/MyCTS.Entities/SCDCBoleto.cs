using System;

namespace MyCTS.Entities
{
    public class SCDCBoleto
    {
        private string recLoc;
        public string RecLoc { get { return recLoc; } set { recLoc = value; } }

        private DateTime fechaCreacion;
        public DateTime FechaCreacion { get { return fechaCreacion; } set { fechaCreacion = value; } }

        private string segmento;
        public string Segmento { get { return segmento; } set { segmento = value; } }

        private string numeroBoleto;
        public string NumeroBoleto { get { return numeroBoleto; } set { numeroBoleto = value; } }

        private string nombre;
        public string Nombre { get { return nombre; } set { nombre = value; } }

        private DateTime fechaEmision;
        public DateTime FechaEmision { get { return fechaEmision; } set { fechaEmision = value; } }

        private DateTime fecha;
        public DateTime Fecha { get { return fecha; } set { fecha = value; } }

        private string boletoElectronico;
        public string BoletoElectronico { get { return boletoElectronico; } set { boletoElectronico = value; } }

        private string indicador;
        public string Indicador { get { return indicador; } set { indicador = value; } }

        private string pais;
        public string Pais { get { return pais; } set { pais = value; } }

        private string indicador2;
        public string Indicador2 { get { return indicador2; } set { indicador2 = value; } }

        private string pcc;
        public string Pcc { get { return pcc; } set { pcc = value; } }
    }
}
