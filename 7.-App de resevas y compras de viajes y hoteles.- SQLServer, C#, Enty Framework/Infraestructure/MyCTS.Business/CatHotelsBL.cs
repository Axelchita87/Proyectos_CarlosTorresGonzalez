using System.Collections.Generic;
using MyCTS.Entities;
using System.Xml;

namespace MyCTS.Business
{
    public class CatHotelsBL
    {
        //public static List<CatHotels> GetHotels(string StrToSearch)
        //{
        //    List<CatHotels> CatHotelsList = new List<CatHotels>();
        //    try
        //    {
        //        CatHotelsDAL objHotels = new CatHotelsDAL();
        //        CatHotelsList = objHotels.GetHotels(StrToSearch);
        //    }
        //    catch { }
        //    return CatHotelsList;
        //}

        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.HOTELS_FILENAME;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {

                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value; //CatHotCode
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value; //CatHotCode + ' ' + CatHotNameChain
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value; //CatHotNameChain                           
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> GetHotels_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 3)
            {
                GetElements(ref ObjectsBL.ListHotelsMin);

                return ObjectsBL.ListHotelsMin.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch); });
            }
            else
            {
                GetElements(ref ObjectsBL.ListHotelsMaj);

                return ObjectsBL.ListHotelsMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch)); });
            }

        }
    }
}
