using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;

namespace MyCTS.Business
{
    public class CatCountriesBL
    {
        //public static List<CatCountries> GetCountries(string StrToSearch)
        //{
        //    List<CatCountries> CatCountriesList = new List<CatCountries>();
        //    try
        //    {
        //        CatCountriesDAL objCountries = new CatCountriesDAL();
        //        CatCountriesList = objCountries.GetCountries(StrToSearch);
        //    }
        //    catch { }
        //    return CatCountriesList;
        //}

        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.COUNTRIES_FILENAME;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {

                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value; //CatCouId
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value; //CatCouId + ' ' + CatCouName
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value; //CatCouName                           
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> GetCountries_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 3)
            {
                GetElements(ref ObjectsBL.ListCountriesMin);

                return ObjectsBL.ListCountriesMin.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch); });
            }
            else
            {
                GetElements(ref ObjectsBL.ListCountriesMaj);

                return ObjectsBL.ListCountriesMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch)); });
            }

        }

        public List<ListItem> GetCountries()
        {

            CatCountriesDAL dataAcces = new CatCountriesDAL();
            return dataAcces.GetCountries();
        }

    }
}
