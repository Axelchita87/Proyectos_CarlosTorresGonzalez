using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GroupCodeLabelBL
    {
        public static List<GroupCodeLabel> GetLabelXMLRemarks(string RemarkValue)
        {
            List<GroupCodeLabel> GetLabelXMLRemarksList = new List<GroupCodeLabel>();
            GroupCodeLabelDAL objLabelXMLRemarks = new GroupCodeLabelDAL();
            try
            {
                try
                {
                    GetLabelXMLRemarksList = objLabelXMLRemarks.GetGroupCodeLabel(RemarkValue, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    GetLabelXMLRemarksList = objLabelXMLRemarks.GetGroupCodeLabel(RemarkValue, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return GetLabelXMLRemarksList;

        }

    }
}
