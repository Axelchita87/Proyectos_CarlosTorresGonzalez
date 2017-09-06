using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;

namespace MyCTS.Business
{
    public class CatStatusCodesBL
    {

        public static List<ListItem> GetStatusCodes(string StrToSearch)
        {
            List<ListItem> CatStatusCodesList = new List<ListItem>();
            CatStatusCodesDAL objStatusCodes = new CatStatusCodesDAL();
            try
            {
                try
                {
                    CatStatusCodesList = objStatusCodes.GetStatusCodes(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    CatStatusCodesList = objStatusCodes.GetStatusCodes(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                
            }
            catch
            { }
            return CatStatusCodesList;

        }
        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.STATUSCODES_FILENAME;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {
                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value; //CatStaCodCode
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value; //CatStaCodCode + ' ' + CatStaCodDescription
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value; //CatStaCodDescription                            
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> GetStatusCodes_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 3)
            {
                GetElements(ref ObjectsBL.ListSatusCodesMin);

                return ObjectsBL.ListSatusCodesMin.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch); });
            }
            else
            {
                GetElements(ref ObjectsBL.ListSatusCodesMaj);

                return ObjectsBL.ListSatusCodesMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch)); });
            }
        }
    }
}

