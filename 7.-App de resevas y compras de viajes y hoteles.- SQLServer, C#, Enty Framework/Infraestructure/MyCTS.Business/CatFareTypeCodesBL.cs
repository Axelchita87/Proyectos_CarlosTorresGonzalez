using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;
namespace MyCTS.Business
{
    public class CatFareTypeCodesBL
    {
        public static List<CatFareTypeCodes> GetFareTypeCodes()
        {
            List<CatFareTypeCodes> objFareTypeCodesList = new List<CatFareTypeCodes>();
            CatFareTypeCodesDAL objFareTypeCodes = new CatFareTypeCodesDAL();
            try
            {
                try
                {
                    objFareTypeCodesList = objFareTypeCodes.GetFareTypeCodes(CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    objFareTypeCodesList = objFareTypeCodes.GetFareTypeCodes(CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return objFareTypeCodesList;
        }


        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.CLIENTSCATALOGS_FARETYPECODES;
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
                            li.Text2 = reader.Value.ToUpper();                            
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> GetFareType_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 5)
            {
                GetElements(ref ObjectsBL.ListEquipmentCodesMin);

                return ObjectsBL.ListEquipmentCodesMin.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch); });
            }
            else
            {
                GetElements(ref ObjectsBL.ListFareTypeCodesMaj);

                return ObjectsBL.ListFareTypeCodesMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch)); });
            }
        }

    }
}
