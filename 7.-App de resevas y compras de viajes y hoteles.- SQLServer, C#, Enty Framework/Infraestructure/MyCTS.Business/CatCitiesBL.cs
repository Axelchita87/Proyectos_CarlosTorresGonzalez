using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;

namespace MyCTS.Business
{
    public class CatCitiesBL
    {

        public static List<ListItem> GetCities(string StrToSearch)
        {
            List<ListItem> CitiesList = new List<ListItem>();
            CatCitiesDAL objCities = new CatCitiesDAL();
            try
            {
                try
                {
                    CitiesList = objCities.GetCities(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    CitiesList = objCities.GetCities(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return CitiesList;

        }

        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.CITIES_FILENAME;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {
                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value; //CatCitId
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value; //CatCitId + ' ' + CatCitName
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value; //CatCitName                            
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> GetCities_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 4)
            {
                GetElements(ref ObjectsBL.ListCitiesMin);

                return ObjectsBL.ListCitiesMin.FindAll(delegate(ListItem li) 
                { return (li.Value.StartsWith(StrToSearch)); });
            }
            else
            {
                GetElements(ref ObjectsBL.ListCitiesMaj);

                return ObjectsBL.ListCitiesMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch)); });
            }
        }

        public static List<ListItem> GetCodeCities(string StrToSearch)
        {
            List<ListItem> CitiesList = new List<ListItem>();
            CatCitiesDAL objCities = new CatCitiesDAL();
            try
            {
                try
                {
                    CitiesList = objCities.GetCodeCities(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch
                {
                    CitiesList = objCities.GetCities(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return CitiesList;

        }
    }
}
