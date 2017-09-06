using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class InsertPccBL
    {
        public static bool InsertPcc(string pcc, string name, string application, string type, string tool, string gds )
        {
            bool insert = true;
            InsertPccDAL objInsert = new InsertPccDAL();

            try
            {
                objInsert.InsertPcc(pcc, name, application, type, tool, gds,  CommonENT.MYCTSDB_CONNECTION);
            }
            catch
            {
                insert = false;
                objInsert.InsertPcc(pcc, name, application, type, tool, gds,  CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

            return insert;
        }
    }
}
