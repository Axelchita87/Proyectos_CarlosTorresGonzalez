using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class ValidateConcludedPNRBL
    {
        public static int ValidateConcludedPNR(string pnr, int orgid)
        {
            int count = 0;

            ValidateConcludedPNRDAL objValidate = new ValidateConcludedPNRDAL();

            try
            {
                count = objValidate.ValidateConcludedPNR(pnr, orgid, CommonENT.MYCTSDB_CONNECTION);
            }
            catch
            {
                count = objValidate.ValidateConcludedPNR(pnr, orgid, CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

            return count;
        }
    }
}
