using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SetProductivityMailStatusBL
    {
        public void SetProductivityMailStatus(string Firm, string Pcc)
        {
            SetProductivityMailStatusDAL SetStatus = new SetProductivityMailStatusDAL();
            try
            {

                try
                {
                    SetStatus.SetProductivityMailStatus(Firm, Pcc, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    SetStatus.SetProductivityMailStatus(Firm, Pcc, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch
            { }
        }
    }
}
