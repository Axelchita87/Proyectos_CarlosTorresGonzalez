using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminEvents
{
    public class EntUsuario_
    {
        private int id;
        private string usuario;
        private string password;
        private string nombre;
        private int dia;
        private int saai;
        private int sita;
        private int sitaw;
        private int cove;
        private int online;
        private int status;
        private string estatusDes;
        private string noCte;
        private string noSerie;
        private string suc;
        private int coa;

        #region
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Dia
        {
            get { return dia; }
            set { dia = value; }
        }
        public int Saai
        {
            get { return saai; }
            set { saai = value; }
        }
        public int Sita
        {
            get { return sita; }
            set { sita = value; }
        }
        public int Sitaw
        {
            get { return sitaw; }
            set { sitaw = value; }
        }
        public int Cove
        {
            get { return cove; }
            set { cove = value; }
        }
        public int Online
        {
            get { return online; }
            set { online = value; }
        }
        public int Coa
        {
            get { return coa; }
            set { coa = value; }
        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        public string Estatus
        {
            get { return estatusDes; }
            set { estatusDes = value; }
        }
        public string NoCte
        {
            get { return noCte; }
            set { noCte = value; }
        }
        public string NoSerie
        {
            get { return noSerie; }
            set { noSerie = value; }
        }
        public string Suc
        {
            get { return suc; }
            set { suc = value; }
        }


        #endregion

        #region
        public EntUsuario_()
        {
            id = 0;
            usuario = string.Empty;
            password = string.Empty;
            nombre = string.Empty;
            dia = 0;
            saai = 0;
            sita = 0;
            sitaw = 0;
            cove = 0;
            online = 0;
            status = 0;
            estatusDes = string.Empty;
            noCte = string.Empty;
            noSerie = string.Empty;
            suc = string.Empty;
            coa = 0;
        }
        public EntUsuario_(int vid, string vusuario, string vpassword, string vnombre, int vdia, int vsaai,
                          int vsita, int vsitaw, int vcove, int vonline, int vstatus, string vestatusDes, string vNoCte, string vNoSerie, string vSuc, int vcoa)
        {
            id = 0;
            usuario = string.Empty;
            password = string.Empty;
            nombre = string.Empty;
            dia = 0;
            saai = 0;
            sita = 0;
            sitaw = 0;
            cove = 0;
            online = 0;
            status = 0;
            estatusDes = vestatusDes;
            noCte = vNoCte;
            noSerie = vNoSerie;
            suc = vSuc;
            coa = vcoa;
        }
        #endregion
    }
}
