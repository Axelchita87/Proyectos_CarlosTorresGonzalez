using System;
using System.Collections.Generic;
using System.Xml;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CatPAirlinesFareBL
    {
        //public static List<CatPAirlinesFare> GetAirLinesFare(string DKToSearch)
        //{
        //    List<CatPAirlinesFare> listAirLinesFare = new List<CatPAirlinesFare>();
        //    try
        //    {
        //        catPAirlinesFareDAL objAirLinesFare = new catPAirlinesFareDAL();
        //        listAirLinesFare = objAirLinesFare.GetPAirLinesFare(DKToSearch);
        //    }
        //    catch
        //    { }
        //    return listAirLinesFare;
        //}

        public static List<ListItem> GetAirLinesFare(string StrToSearch)
        {
            List<ListItem> listAirLinesFare = new List<ListItem>();
            catPAirlinesFareDAL objAirLinesFare = new catPAirlinesFareDAL();
            try
            {
                try
                {
                    listAirLinesFare = objAirLinesFare.GetPAirLinesFare(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listAirLinesFare = objAirLinesFare.GetPAirLinesFare(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listAirLinesFare;
        }


        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.CATPAIRLINESFARE_FILENAME;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {
                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value; //catairlinfarid
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value; //catairlinfarid + ' ' + catairlinfarname
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value; //catairlinfarid                            
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> GetPAirlinesFare_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 3)
            {
                GetElements(ref ObjectsBL.ListPAirlinesFareMin);

                return ObjectsBL.ListPAirlinesFareMin.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch); });
            }
            else
            {
                GetElements(ref ObjectsBL.ListPAirlinesFareMaj);

                return ObjectsBL.ListPAirlinesFareMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch)); });
            }
        }

   
    }
}
