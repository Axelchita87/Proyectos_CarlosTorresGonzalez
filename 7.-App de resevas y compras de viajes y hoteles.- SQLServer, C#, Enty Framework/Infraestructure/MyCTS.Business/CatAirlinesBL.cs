using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;

namespace MyCTS.Business
{
    public class CatAirlinesBL
    {
        public static List<CatAirlines> GetAirlines(string StrToSearch)
        {
            List<CatAirlines> AirlinesList = new List<CatAirlines>();
            CatAirlinesDAL objAirlines = new CatAirlinesDAL();
            try
            {
                try
                {
                    AirlinesList = objAirlines.GetAirlines(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    AirlinesList = objAirlines.GetAirlines(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return AirlinesList;

        }

        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.AIRLINES_FILENAME;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {
                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value; //CatAirLinAlfaId
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value; //CatAirLinAlfaId + ' ' + CatAirLinName
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value; // CatAirLinName                      
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> GetAirLines_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 3)
            {
                GetElements(ref ObjectsBL.ListAirlinesMin);

                //Busca por CatAirLinAlfaId
                return ObjectsBL.ListAirlinesMin.FindAll(delegate(ListItem li)
                { return (li.Value.StartsWith(StrToSearch)); });
            }
            else
            {
                GetElements(ref ObjectsBL.ListAirlinesMaj);

                //Busca por CatAirLinName
                return ObjectsBL.ListAirlinesMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch)); });
            }


        }
    }
}
