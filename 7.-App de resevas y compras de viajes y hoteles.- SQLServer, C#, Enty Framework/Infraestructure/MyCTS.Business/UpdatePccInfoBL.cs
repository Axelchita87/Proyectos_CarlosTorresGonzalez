using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class UpdatePccInfoBL
    {
        public static bool UpdatePcc(string pcc, string name, string type, string tool, string gds, string application)
        {
            bool update = true;
            UpdatePccInfoDAL objUpdate = new UpdatePccInfoDAL();

            try
            {
                objUpdate.UpdatePcc(pcc, name, application, type, tool, gds, CommonENT.MYCTSDB_CONNECTION);
            }
            catch
            {
                update = false;
                objUpdate.UpdatePcc(pcc, name, application, type, tool, gds, CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

            return update;
        }
    }
}
