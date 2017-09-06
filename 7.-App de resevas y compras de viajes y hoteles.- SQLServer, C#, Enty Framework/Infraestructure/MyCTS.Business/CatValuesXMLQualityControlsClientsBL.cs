using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CatValuesXMLQualityControlsClientsBL
    {
        public static List<CatValuesXMLQualityControlsClients> GetValuesXMLQualityControls(string Attribute1, string PaxNumber, string C1s, string C2s, string C3s,
                string C4s, string C5s, string C6s, string C7s, string C8s, string C9s, string C10s, string C11s, string C12s, string C13s,
                string C14s, string C15s, string C16s, string C17s, string C18s, string C19s, string C20s, string C21s, string C22s, string C23s,
                string C24s, string C25s, string C26s, string C27s, string C28s, string C29s, string C30s, string C31s, string C32s, string C33s,
                string C34s, string C35s, string C36s, string C37s, string C38s, string C39s, string C40s, string C41s, string C42s, string C43s,
                string C44s, string C45s, string C46s, string C47s, string C48s, string C49s, string C50s, string C51s, string C52s, string C53s,
                string C54s, string C55s, string C56s, string C57s, string C58s, string C59s, string C60s, string C61s, string C62s, string C63s,
                string C64s, string C65s, string C66s, string C67s, string C68s, string C69s, string C70s, string C71s, string C72s, string C73s,
                string C74s, string C75s, string C76s, string C77s, string C78s, string C79s, string C80s, string C81s, string C82s, string C83s,
                string C84s, string C85s, string C86s, string C87s, string C88s, string C89s, string C90s, string C91s, string C92s, string C93s,
                string C94s, string C95s, string C96s, string C97s, string C98s, string C99s, string C100s)
        {
            List<CatValuesXMLQualityControlsClients> GetValuesXMLQualityControlsList = new List<CatValuesXMLQualityControlsClients>();
            CatValuesXMLQualityControlsClientsDAL objGetValuesXMLQualityControls = new CatValuesXMLQualityControlsClientsDAL();
            try
            {
                try
                {
                    GetValuesXMLQualityControlsList = objGetValuesXMLQualityControls.GetValuesXMLQualityControls(Attribute1, PaxNumber, C1s, C2s, C3s, C4s, C5s, C6s, C7s, C8s, C9s, C10s,
                    C11s, C12s, C13s, C14s, C15s, C16s, C17s, C18s, C19s, C20s, C21s, C22s, C23s, C24s, C25s, C26s, C27s, C28s, C29s, C30s, C31s, C32s, C33s, C34s, C35s, C36s, C37s, C38s, C39s,
                    C40s, C41s, C42s, C43s, C44s, C45s, C46s, C47s, C48s, C49s, C50s, C51s, C52s, C53s, C54s, C55s, C56s, C57s, C58s, C59s, C60s, C61s, C62s, C63s, C64s, C65s, C66s, C67s, C68s,
                    C69s, C70s, C71s, C72s, C73s, C74s, C75s, C76s, C77s, C78s, C79s, C80s, C81s, C82s, C83s, C84s, C85s, C86s, C87s, C88s, C89s, C90s, C91s, C92s, C93s, C94s, C95s, C96s, C97s,
                    C98s, C99s, C100s, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    GetValuesXMLQualityControlsList = objGetValuesXMLQualityControls.GetValuesXMLQualityControls(Attribute1, PaxNumber, C1s, C2s, C3s, C4s, C5s, C6s, C7s, C8s, C9s, C10s,
                    C11s, C12s, C13s, C14s, C15s, C16s, C17s, C18s, C19s, C20s, C21s, C22s, C23s, C24s, C25s, C26s, C27s, C28s, C29s, C30s, C31s, C32s, C33s, C34s, C35s, C36s, C37s, C38s, C39s,
                    C40s, C41s, C42s, C43s, C44s, C45s, C46s, C47s, C48s, C49s, C50s, C51s, C52s, C53s, C54s, C55s, C56s, C57s, C58s, C59s, C60s, C61s, C62s, C63s, C64s, C65s, C66s, C67s, C68s,
                    C69s, C70s, C71s, C72s, C73s, C74s, C75s, C76s, C77s, C78s, C79s, C80s, C81s, C82s, C83s, C84s, C85s, C86s, C87s, C88s, C89s, C90s, C91s, C92s, C93s, C94s, C95s, C96s, C97s,
                    C98s, C99s, C100s, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return GetValuesXMLQualityControlsList;

        }
    }
}

