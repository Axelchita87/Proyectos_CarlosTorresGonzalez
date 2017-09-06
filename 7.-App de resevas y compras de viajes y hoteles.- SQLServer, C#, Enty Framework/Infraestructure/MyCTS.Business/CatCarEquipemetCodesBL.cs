using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;

namespace MyCTS.Business
{
    public class CatCarEquipemetCodesBL
    {

        public static List<ListItem> GetEquipmentCodes(string StrToSearch)
        {
            List<ListItem> CarsList = new List<ListItem>();
            CatCarEquipemetCodesDAL objCars = new CatCarEquipemetCodesDAL();
            try
            {
                try
                {
                    CarsList = objCars.GetEquipmentCodes(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    CarsList = objCars.GetEquipmentCodes(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
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
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.EQUIPMENTCODES_FILENAME;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {
                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value; //CatCarEquCodCode
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value; //CatCarEquCodCode + ' ' + CatCarEquCodName
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value; //CatCarEquCodName                            
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> GetEquipmentCodes_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 4)
            {
                GetElements(ref ObjectsBL.ListEquipmentCodesMin);

                return ObjectsBL.ListEquipmentCodesMin.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch); });
            }
            else
            {
                GetElements(ref ObjectsBL.ListEquipmentCodesMaj);

                return ObjectsBL.ListEquipmentCodesMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch)); });
            }
        }

    }
}
