using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;

namespace MyCTS.Business
{
    public class CatLineClassesBL
    {
       

        public static List<ListItem> GetAirLinesClasses(string StrToSearch)
        {
            List<ListItem> CatLineClassesList = new List<ListItem>();
            CatLineClassesDAL objLineClasses = new CatLineClassesDAL();
            try
            {
                try
                {
                    CatLineClassesList = objLineClasses.GetAirLinesClasses(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    CatLineClassesList = objLineClasses.GetAirLinesClasses(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return CatLineClassesList;

        }


        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.AIRLINESCLASSES_FILENAME;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {
                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value; //CatAirLinClaId
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value; //CatAirLinClaId + ' ' + CatAirLinClaName
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value; //CatAirLinClaName                            
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> GetAirLinesClasses_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length == 1)
            {
                GetElements(ref ObjectsBL.ListAirLineClassesMin);

                return ObjectsBL.ListAirLineClassesMin.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch); });
            }
            else
            {
                GetElements(ref ObjectsBL.ListAirLineClassesMaj);

                return ObjectsBL.ListAirLineClassesMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch)); });
            }
        }
    }
}
