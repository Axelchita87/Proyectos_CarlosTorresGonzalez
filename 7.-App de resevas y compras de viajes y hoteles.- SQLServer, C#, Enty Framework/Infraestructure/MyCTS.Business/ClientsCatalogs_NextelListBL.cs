using System;
using System.Collections.Generic;
using System.Text;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;


namespace MyCTS.Business
{
    class ClientsCatalogs_NextelListBL
    {
      
        public static List<ClientsCatalogs_Nextel> GetCatalog_ClientsCatalogs_Nextel()
        {
            List<ClientsCatalogs_Nextel> ClientsCatalogs_NextelList = new List<ClientsCatalogs_Nextel>();
            ClientsCatalogs_NextelDAL objClientsCatalogs_Nextel = new ClientsCatalogs_NextelDAL();
            try
            {
                try
                {
                    ClientsCatalogs_NextelList = objClientsCatalogs_Nextel.GetCatalog_ClientsCatalogs_Nextel(CommonENT.MYCTSDB_CONNECTION);
                }
                catch
                {
                    ClientsCatalogs_NextelList = objClientsCatalogs_Nextel.GetCatalog_ClientsCatalogs_Nextel(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return ClientsCatalogs_NextelList;

        }

    }
}
