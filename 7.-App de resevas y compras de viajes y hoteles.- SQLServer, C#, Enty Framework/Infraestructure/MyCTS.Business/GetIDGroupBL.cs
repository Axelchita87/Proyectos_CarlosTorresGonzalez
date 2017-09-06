using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetIDGroupBL
    {
        public static List<ListItem> ListIDGroupCatalogs = null;
        public static List<ListItem> ListTemp = new List<ListItem>();

        public static List<ListItem> GetIDGroup(string strToSearch)
        {
            List<ListItem> idGroupList = new List<ListItem>();
            GetIDGroupDAL objIdGroup = new GetIDGroupDAL();
            try
            {
                try
                {
                    idGroupList = objIdGroup.GetIDGroup(strToSearch, CommonENT.MYCTSDBPRODUCTIVITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    idGroupList = objIdGroup.GetIDGroup(strToSearch, CommonENT.MYCTSDBPRODUCTIVITYBACKUP_CONNECTION);
                }
            }
            catch { }
            return idGroupList;
        }

       
        public static void GetElements(ref List<ListItem> list, string StrToSearch)
        {
            if (list != null)
            {
                ListTemp.Clear();
                foreach (ListItem item in ListIDGroupCatalogs)
                {
                    if (!string.IsNullOrEmpty(item.Value))
                    {
                        ListTemp.Add(item);
                    }

                }
            }
        }

        public static List<ListItem> GetIDGroups_Predictive(string StrToSearch)
        {
            ListIDGroupCatalogs = new List<ListItem>();
            ListIDGroupCatalogs = GetIDGroup(StrToSearch);
            if (StrToSearch.Length < 4)
            {
                GetElements(ref ListIDGroupCatalogs, StrToSearch);
                return ListTemp.FindAll(delegate(ListItem li)
                { return (li.Value.StartsWith(StrToSearch)); });
            }
            else
            {
                GetElements(ref ListIDGroupCatalogs, StrToSearch);
                return ListTemp.FindAll(delegate(ListItem li)
                { return (li.Text.StartsWith(StrToSearch)); });
            }
        }
    }
}
