using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;


namespace MyCTS.Business
{
    public class CatStatesUSABL
    {
 

        public static List<ListItem> GetSatesUSA(string StrToSearch)
        {
            List<ListItem> CarsList = new List<ListItem>();
            CatStatesUSADAL objStatesUSA = new CatStatesUSADAL();
            try
            {
                try
                {
                    CarsList = objStatesUSA.GetStatesUSA(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    CarsList = objStatesUSA.GetStatesUSA(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return CarsList;

        }


        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.STATESUSA_FILENAME;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {
                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value; // CatStaUSACode
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value; // CatStaUSACode+ ' ' +  CatStaUSAName
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value; //CatStaUSAName                           
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> GetSatesUSA_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 3)
            {
                GetElements(ref ObjectsBL.ListSatesUSAMin);

                return ObjectsBL.ListSatesUSAMin.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch); });
            }
            else
            {
                GetElements(ref ObjectsBL.ListSatesUSAMaj);

                return ObjectsBL.ListSatesUSAMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch)); });
            }
        }

    }
}
