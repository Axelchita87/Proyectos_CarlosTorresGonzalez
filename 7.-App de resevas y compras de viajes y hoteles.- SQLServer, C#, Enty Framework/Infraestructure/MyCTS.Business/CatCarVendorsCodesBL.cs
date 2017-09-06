using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;


namespace MyCTS.Business
{
    public class CatCarVendorsCodesBL
    {
        public static List<ListItem> GetVendorCodes(string StrToSearch)
        {
            List<ListItem> CarsList = new List<ListItem>();
            CatCarVendorsCodesDAL objCars = new CatCarVendorsCodesDAL();
            try
            {
                try
                {
                    CarsList = objCars.GetVendorCodes(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    CarsList = objCars.GetVendorCodes(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return CarsList;

        }

        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.VENDORCODES_FILENAME;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {
                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value; //CatCarVenCodCode
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value; //CatCarVenCodCode + ' ' + CatCarVenCodName
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value; //CatCarVenCodName                            
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> GetVendorCodes_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 3)
            {
                GetElements(ref ObjectsBL.ListVendorCodesMin);

                return ObjectsBL.ListVendorCodesMin.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch); });
            }
            else
            {
                GetElements(ref ObjectsBL.ListVendorCodesMaj);

                return ObjectsBL.ListVendorCodesMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch)); });
            }
        }

    }
}
