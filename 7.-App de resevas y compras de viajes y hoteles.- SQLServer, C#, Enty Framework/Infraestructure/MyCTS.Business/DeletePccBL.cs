using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class DeletePccBL
    {
        public static bool DeletePcc(string pcc)
        {
            bool delete = true;
            DeletePccDAL objDelete=new DeletePccDAL();
            try
            {
                try
                {
                    objDelete.DeletePcc(pcc, CommonENT.MYCTSDB_CONNECTION);
                }
                catch
                {
                    delete = false;
                    objDelete.DeletePcc(pcc, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            {
                delete = false;
            }

            return delete;
        }
    }
}
