using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;

namespace MyCTS.Business
{
    public class CatCostCenterBL
    {
        
        public static List<ListItem> GetCostCenters(string DKToSearch, string StrToSearch)
        {
            List<ListItem> CatCostCenterList = new List<ListItem>();
            CatCostCenterDAL objCatCostCenter = new CatCostCenterDAL();
            try
            {
                try 
                {
                    CatCostCenterList = objCatCostCenter.GetCostCenters(DKToSearch, StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    CatCostCenterList = objCatCostCenter.GetCostCenters(DKToSearch, StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
                
            }
            catch
            { }

            return CatCostCenterList;
        }


        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.COSTCENTER_FILNAME;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {
                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value; //IdCC
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value; //IdCC + ' ' + CCName
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value; //CCName                            
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> GetCostCenters_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 3)
            {
                GetElements(ref ObjectsBL.ListCostCenterMin);

                return ObjectsBL.ListCostCenterMin.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch); });
            }
            else
            {
                GetElements(ref ObjectsBL.ListCostCenterMaj);

                return ObjectsBL.ListCostCenterMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch)); });
            }
        }

    }
}
