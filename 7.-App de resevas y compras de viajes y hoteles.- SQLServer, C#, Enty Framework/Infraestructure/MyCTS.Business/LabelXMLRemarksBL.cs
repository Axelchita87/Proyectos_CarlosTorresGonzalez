using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class LabelXMLRemarksBL
    {
        public static List<LabelXMLRemarks> GetLabelXMLRemarks(string Attribute1, string IDProcess, string RemarkValue)
        {
            List<LabelXMLRemarks> GetLabelXMLRemarksList = new List<LabelXMLRemarks>();
            LabelXMLRemarksDAL objLabelXMLRemarks = new LabelXMLRemarksDAL();
            try
            {
                try
                {
                    GetLabelXMLRemarksList = objLabelXMLRemarks.GetLabelXMLRemarks(Attribute1, IDProcess, RemarkValue, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    GetLabelXMLRemarksList = objLabelXMLRemarks.GetLabelXMLRemarks(Attribute1, IDProcess, RemarkValue, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return GetLabelXMLRemarksList;

        }
    }
}