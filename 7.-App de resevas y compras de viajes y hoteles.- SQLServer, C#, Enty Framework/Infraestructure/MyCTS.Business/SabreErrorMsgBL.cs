using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SabreErrorMsgBL
    {


       public static SabreErrorMsg GetSabreErrorMsg(string SabreErrMsg, int ModulesId)
        {
            SabreErrorMsg item = new SabreErrorMsg();
            SabreErrorMsgDAL objErrMsg = new SabreErrorMsgDAL();
            try
            {
                try
                {
                    item = objErrMsg.GetSabreErrorMsg(SabreErrMsg, ModulesId, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    item = objErrMsg.GetSabreErrorMsg(SabreErrMsg, ModulesId, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return item;

        }




    }
}
