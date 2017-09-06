using System.Collections.Generic;
using MyCTS.Entities;
using System.Xml;

namespace MyCTS.Business
{
    public class CatBusCodesBL
    {
        //public static List<CatBusCodes> GetBusCodes(string StrToSearch)
        //{
        //    List<CatBusCodes> CatBusCodesList = new List<CatBusCodes>();
        //    try
        //    {
        //        CatBusCodesDAL objBusCodes = new CatBusCodesDAL();
        //        CatBusCodesList = objBusCodes.GetBusCodes(StrToSearch);
        //    }
        //    catch { }
        //    return CatBusCodesList;
        //}

        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.BUSCODES_FILENAME;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {
                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value; //CatBusCodCode
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value; //CatBusCodCode + ' ' + CatBusCodName
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value; //CatBusCodName                           
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> GetBusCodes_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 3)
            {
                GetElements(ref ObjectsBL.ListBusCodesMin);

                return ObjectsBL.ListBusCodesMin.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch); });
            }
            else
            {
                GetElements(ref ObjectsBL.ListBusCodesMaj);

                return ObjectsBL.ListBusCodesMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch)); });
            }
        }
    }
}
