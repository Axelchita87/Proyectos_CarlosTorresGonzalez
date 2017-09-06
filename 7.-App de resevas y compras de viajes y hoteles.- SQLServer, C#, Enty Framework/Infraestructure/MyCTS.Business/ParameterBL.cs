using System;
using MyCTS.Entities;
using MyCTS.DataAccess;


namespace MyCTS.Business
{
    public class ParameterBL
    {
        public static Parameter GetParameterValue(string ParameterName)
        {
            Parameter parameter = new Parameter();
            ParameterDAL objParameter = new ParameterDAL();
            try
            {
                try
                {
                    parameter = objParameter.GetParameterValue(ParameterName, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    parameter = objParameter.GetParameterValue(ParameterName, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                
            }
            catch
            { }

            return parameter;
        }
       
        public static void UpdateComissionBoardURL(string ParameterName, string url)
        {
            Parameter parameter = new Parameter();
            ParameterDAL objParameter = new ParameterDAL();           
            try
            {
                objParameter.UpdateComissionBoardUrl(url, ParameterName, CommonENT.MYCTSDB_CONNECTION);
                objParameter.UpdateComissionBoardUrl(url, ParameterName, CommonENT.MYCTSDBBACKUP_CONNECTION);
            }
            catch (Exception ex)
            {
                new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                
            }                     
    }
    }
}
