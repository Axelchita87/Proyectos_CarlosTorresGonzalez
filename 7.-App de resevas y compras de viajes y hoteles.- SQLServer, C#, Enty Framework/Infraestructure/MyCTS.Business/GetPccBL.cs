using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetPccBL
    {
        public static PCC GetPcc(string pcc)
        {
            PCC objPcc=new PCC();
            GetPccDAL objGetPcc = new GetPccDAL();

            try
            {
                objPcc = objGetPcc.GetPcc(pcc, CommonENT.MYCTSDB_CONNECTION);
            }
            catch
            {
                objPcc = objGetPcc.GetPcc(pcc, CommonENT.MYCTSDBBACKUP_CONNECTION);
            }

            return objPcc;
        }
    }
}
