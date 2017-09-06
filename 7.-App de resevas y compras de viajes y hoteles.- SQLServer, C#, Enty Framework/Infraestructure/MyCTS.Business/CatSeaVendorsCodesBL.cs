using System.Collections.Generic;
using MyCTS.Entities;
using System.Xml;

namespace MyCTS.Business
{
    public class CatSeaVendorsCodesBL
    {

        //public static List<CatSeaVendorsCodes> GetSeaVendorsCodes(string StrToSearch)
        //{
        //    List<CatSeaVendorsCodes> CatSeaVendorsCodesList = new List<CatSeaVendorsCodes>();
        //    try
        //    {
        //        CatSeaVendorsCodesDAL objSeaVendorsCodes = new CatSeaVendorsCodesDAL();
        //        CatSeaVendorsCodesList = objSeaVendorsCodes.GetSeaVendorsCodes(StrToSearch);
        //    }
        //    catch { }
        //    return CatSeaVendorsCodesList;
        //}

        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.SEAVENCODNAME_FILENAME;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {
                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value; //CatSeaVenCodCode
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value; //CatSeaVenCodCode + ' ' + CatSeaVenCodName
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value; //CatSeaVenCodName                           
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> GetSeaVendorsCodes_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 3)
            {
                GetElements(ref ObjectsBL.ListSeaVendorsCodesMin);

                return ObjectsBL.ListSeaVendorsCodesMin.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch); });
            }
            else
            {
                GetElements(ref ObjectsBL.ListSeaVendorsCodesMaj);

                return ObjectsBL.ListSeaVendorsCodesMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch)); });
            }
        }


    }
}
