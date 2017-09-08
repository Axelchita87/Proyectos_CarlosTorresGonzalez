using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMIN2.Entity;
using System.Data;

namespace ADMIN2.DAL
{
    public class DalConsultoria : DALBase
    {
        public DalConsultoria()
        {
            db = DBHelper.GetInstance("conxAdm");
            conm = db.GetConnObject();
        }
    }
}
