using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;

namespace MyCTS.Business
{
   public class CatCarTypeCodesBL
    {
       

       public static List<ListItem> GetTypeCodes(string StrToSearch)
       {
           List<ListItem> CarsList = new List<ListItem>();
           CatCarTypeCodesDAL objCars = new CatCarTypeCodesDAL();
           try
           {
               try
               {
                   CarsList = objCars.GetTypeCodes(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
               }
               catch (Exception ex)
               {
                   new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                   CarsList = objCars.GetTypeCodes(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
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
               string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.CARTYPECODES_FILENAME;
               XmlTextReader reader = new XmlTextReader(pathfile);

               while (reader.Read())
               {
                   if (reader.NodeType == XmlNodeType.Element)
                   {
                       if (reader.HasAttributes)
                       {
                           ListItem li = new ListItem();
                           reader.MoveToFirstAttribute();
                           li.Value = reader.Value; //CatCarTypCodCode
                           reader.MoveToNextAttribute();
                           li.Text = reader.Value; //CatCarTypCodCode + ' ' + CatCarTypCodDescription
                           reader.MoveToNextAttribute();
                           li.Text2 = reader.Value; //CatCarTypCodDescription                            
                           list.Add(li);
                       }
                   }
               }
           }

       }

       public static List<ListItem> GetTypeCodes_Predictive(string StrToSearch)
       {
           if (StrToSearch.Length < 3)
           {
               GetElements(ref ObjectsBL.ListCarTypeCodesMin);

               return ObjectsBL.ListCarTypeCodesMin.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch); });
           }
           else
           {
               GetElements(ref ObjectsBL.ListCarTypeCodesMaj);

               return ObjectsBL.ListCarTypeCodesMaj.FindAll(delegate(ListItem li)
               { return (li.Text2.StartsWith(StrToSearch)); });
           }
       }

    }
}
