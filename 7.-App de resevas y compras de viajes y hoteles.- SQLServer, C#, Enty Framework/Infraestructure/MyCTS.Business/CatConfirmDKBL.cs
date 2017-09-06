using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;

namespace MyCTS.Business
{
   public class CatConfirmDKBL
    {
        //public static List<CatConfirmDK> GetConfirmDK(string StrToSearch)
        //{
        //    List<CatConfirmDK> CatConfirmDKList = new List<CatConfirmDK>();
        //    try
        //    {
        //        CatConfirmDKDAL objCatConfirmDK = new CatConfirmDKDAL();
        //        CatConfirmDKList = objCatConfirmDK.GetConfirmDK(StrToSearch);
        //    }
        //    catch
        //    { }

        //    return CatConfirmDKList;
        //}

       public static List<ListItem> GetConfirmDK(string StrToSearch)
       {
           List<ListItem> CatConfirmDKList = new List<ListItem>();
           CatConfirmDKDAL objCatConfirmDK = new CatConfirmDKDAL();
           try
           {
               try
               {
                   CatConfirmDKList = objCatConfirmDK.GetConfirmDK(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
               }
               catch (Exception ex)
               {
                   new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                   CatConfirmDKList = objCatConfirmDK.GetConfirmDK(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
               }
               
           }
           catch
           { }
           return CatConfirmDKList;

       }

        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.CONFIRMDK_FILNAME;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {
                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value; //IdDK
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value; //IdDK + ' ' + DKName
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value; //DKName                            
                            list.Add(li);
                        }
                    }
                }
            }

        }

       public static List<ListItem> GetConfirmDK_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 3)
            {
                GetElements(ref ObjectsBL.ListConfirmDKMin);

                return ObjectsBL.ListConfirmDKMin.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch); });
            }
            else
            {
                GetElements(ref ObjectsBL.ListConfirmDKMaj);

                return ObjectsBL.ListConfirmDKMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch)); });
            }
        }

    }
}
