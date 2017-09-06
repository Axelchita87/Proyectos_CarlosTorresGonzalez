using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;

namespace MyCTS.Business
{
    public class CatSSRCodesBL
    {
        public static List<CatSSRCodes> GetSSRCodes()
        {
            List<CatSSRCodes> objSSRCodesList = new List<CatSSRCodes>();
            CatSSRCodesDAL objSSRCodes = new CatSSRCodesDAL();
            try
            {
                try
                {
                    objSSRCodesList = objSSRCodes.GetSSRCodes(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objSSRCodesList = objSSRCodes.GetSSRCodes(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return objSSRCodesList;
        }

        public static List<ListItem> GetElementsSSRCodes()
        {
            List<ListItem> objSSRCodesList = new List<ListItem>();
            string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.CLIENTSCATALOGS_SSRCODES;
            XmlTextReader reader = new XmlTextReader(pathfile);

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.HasAttributes)
                    {
                        ListItem li = new ListItem();
                        reader.MoveToFirstAttribute();
                        li.Value = reader.Value;
                        reader.MoveToNextAttribute();
                        li.Text = reader.Value;
                        reader.MoveToNextAttribute();
                        li.Text2 = reader.Value;
                        objSSRCodesList.Add(li);
                    }
                }
            }

            return objSSRCodesList;
        }
    }
}
