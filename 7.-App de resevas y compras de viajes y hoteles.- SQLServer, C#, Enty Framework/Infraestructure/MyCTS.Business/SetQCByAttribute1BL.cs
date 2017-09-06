using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class SetQCByAttribute1BL
    {
        public static SetQCByAttribute1 GetAttribute(string attribute1, string status, string statusSite)
        {

            SetQCByAttribute1 Attribute = new SetQCByAttribute1();
            SetQCByAttribute1DAL objAttribute = new SetQCByAttribute1DAL();
            try
            {
                try
                {
                    Attribute = objAttribute.GetAttribute(attribute1, status, statusSite, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    Attribute = objAttribute.GetAttribute(attribute1, status, statusSite, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return Attribute;

        }
    }
}
