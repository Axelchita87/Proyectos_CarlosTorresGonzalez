using MyCTS.Entities;
using MyCTS.DataAccess;
using System;

namespace MyCTS.Business
{
    public class InsertLogClipboardCTSBL
    {
        public static bool InsertLogClipboardCTS(DateTime date, string agent, Int16 optionUsed, string pnr)
        {
            bool insert = true;
            InsertLogClipboardCTSDAL objInsert = new InsertLogClipboardCTSDAL();



            ///cambios changeset
            try
            {
                int i = objInsert.InsertLogClipboardCTS(date, agent, optionUsed, pnr, CommonENT.MYCTSDB_CONNECTION);
                
                if (i == -1)
                {
                    insert = false;
                }
            }
            catch
            {
                insert = false;
                int i = objInsert.InsertLogClipboardCTS(date, agent, optionUsed, pnr, CommonENT.MYCTSDBBACKUP_CONNECTION);
                
            }

            return insert;
        }
    }
}
