using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class DocumentsBL
    {

        public static Documents GetSingleDocument(string docName)
        {
            Documents item = null;
            DocumentsDAL objDocument = new DocumentsDAL();
            try
            {
                try
                {
                    item = objDocument.GetSingleDocument(docName, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    item = objDocument.GetSingleDocument(docName, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
                
            }
            catch { }

            return item;

        }
    }
}
