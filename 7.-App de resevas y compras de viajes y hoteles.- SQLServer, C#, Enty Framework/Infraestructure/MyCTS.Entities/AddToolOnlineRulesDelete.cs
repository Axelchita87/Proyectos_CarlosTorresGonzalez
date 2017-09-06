using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class AddToolOnlineRulesDelete
    {
        private string corporative;
        public string Corporative
        {
            get { return corporative; }
            set { corporative = value; }
        }

        private string toolonline;
        public string ToolOnline
        {
            get { return toolonline; }
            set { toolonline = value; }
        }

        private string attribute1;
        public string Attribute1
        {
            get { return attribute1; }
            set { attribute1 = value; }
        }

        private string pcc;
        public string PCC
        {
            get { return pcc; }
            set { pcc = value; }
        }

        private string supervisor;
        public string Supervisor
        {
            get { return supervisor; }
            set { supervisor = value; }
        }

        private int? supagente;
        public int? SupAgente
        {
            get { return supagente; }
            set { supagente = value; }
        }

        private string supstatus;
        public string SupStatus
        {
            get { return supstatus; }
            set { supstatus = value; }
        }

        public List<ConsultorCRUD> Consultores { get; set; }

        private DateTime fechaInsert;
        public DateTime FechaInsert
        {
            get { return fechaInsert; }
            set { fechaInsert = value; }
        }

        private int insertBy;
        public int InsertBy
        {
            get { return insertBy; }
            set { insertBy = value; }
        }

        private DateTime fechaUpdate;
        public DateTime FechaUpdate
        {
            get { return fechaUpdate; }
            set { fechaUpdate = value; }
        }

        private int updateBy;
        public int UpdateBy
        {
            get { return updateBy; }
            set { updateBy = value; }
        }

        private DateTime fechaDelete;
        public DateTime FechaDelete
        {
            get { return fechaDelete; }
            set { fechaDelete = value; }
        }

        private int deleteBy;
        public int DeleteBy
        {
            get { return deleteBy; }
            set { deleteBy = value; }
        }
    }
}
