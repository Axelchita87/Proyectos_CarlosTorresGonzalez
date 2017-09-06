using System.Collections.Generic;
using MyCTS.Entities;
using System.Xml;

namespace MyCTS.Business
{
    public class CurrenciesCountriesBL
    {
      

        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.CURRENCIESCOUNTRIES_FILENAME;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {
                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value; //CatCurCouCode
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value; //CatCurCouCode + ' ' + CatCurCouName + ' ' + CatCouName
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value; //CatCurCouName                           
                            reader.MoveToNextAttribute();
                            li.Text3 = reader.Value; //CatCouName
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> GetCurrenciesCountries_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 3)
            {
                GetElements(ref ObjectsBL.ListCurrenciesCountriesMin);

                return ObjectsBL.ListCurrenciesCountriesMin.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch); });
            }
            if (StrToSearch.Length.Equals(3))
            {
                GetElements(ref ObjectsBL.ListCurrenciesCountriesEq);

                return ObjectsBL.ListCurrenciesCountriesMin.FindAll(delegate(ListItem li)
                { return ((li.Value.Equals(StrToSearch))); });

            }
            else
            {
                GetElements(ref ObjectsBL.ListCurrenciesCountriesMaj);

                return ObjectsBL.ListCurrenciesCountriesMaj.FindAll(delegate(ListItem li)
                { return ((li.Text2.StartsWith(StrToSearch)) | (li.Text3.StartsWith(StrToSearch))); });
            }
        }
    }
}
