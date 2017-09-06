using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;

namespace MyCTS.Business
{
    public class AirPortCityCountryBL
    {
        public static List<AirPortCityCountry> GetAirPortCityCountry(string StrToSearch)
        {
            List<AirPortCityCountry> objAirPortCityCountryList = new List<AirPortCityCountry>();
            AirPortCityCountryDAL objAirPortCityCountry = new AirPortCityCountryDAL();
            try
            {
                try
                {
                    objAirPortCityCountryList = objAirPortCityCountry.GetAirPortCityCountry(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objAirPortCityCountryList = objAirPortCityCountry.GetAirPortCityCountry(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return objAirPortCityCountryList;
        }

        private static List<ListItem> GetMinElements(string StrToSearch)
        {
            if (ObjectsBL.ListAirPortCityCountryMin == null)
            {
                ObjectsBL.ListAirPortCityCountryMin = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.AIRPORTCITYCOUNTRY_LEN_MIN_FILENAME;
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
                            ObjectsBL.ListAirPortCityCountryMin.Add(li);
                        }
                    }
                }
            }

            return ObjectsBL.ListAirPortCityCountryMin.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch); });
        }
        private static List<ListItem> GetMajElements(string StrToSearch)
        {
            if (ObjectsBL.ListAirPortCityCountryMaj == null)
            {
                ObjectsBL.ListAirPortCityCountryMaj = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.AIRPORTCITYCOUNTRY_LEN_MAJ_FILENAME;
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
                            li.Text2 = reader.Value; //CatCitName
                            reader.MoveToNextAttribute();
                            li.Text3 = reader.Value; //CatCouName
                            ObjectsBL.ListAirPortCityCountryMaj.Add(li);
                        }
                    }
                }
            }

            //Busca por CatcitName o CatCouName
            return ObjectsBL.ListAirPortCityCountryMaj.FindAll(delegate(ListItem li)
            { return ((li.Text2.StartsWith(StrToSearch)) | (li.Text3.StartsWith(StrToSearch))); });
        }

        public static List<ListItem> GetAirPortCityCountry_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 4)
                return GetMinElements(StrToSearch);
            else
                return GetMajElements(StrToSearch);
        }
    }
}
