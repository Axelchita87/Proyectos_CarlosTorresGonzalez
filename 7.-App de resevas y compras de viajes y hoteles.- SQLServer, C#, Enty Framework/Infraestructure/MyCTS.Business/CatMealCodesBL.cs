using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;

namespace MyCTS.Business
{
    public class CatMealCodesBL
    {
        

        public static List<ListItem> GetMealCodes(string StrToSearch)
        {
            List<ListItem> CatMealCodesList = new List<ListItem>();
            CatMealCodesDAL objMealCodes = new CatMealCodesDAL();
            try
            {
                try
                {
                    CatMealCodesList = objMealCodes.GetMealCodes(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    CatMealCodesList = objMealCodes.GetMealCodes(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return CatMealCodesList;

        }

        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.MEALCODES_FILANE;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {
                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value; //CatMeacodalCode
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value; //CatMeacodalCode + ' ' + CatMeacodCode + ' ' + CatMeaCodDescription
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value; //CatMeacodCode                           
                            reader.MoveToNextAttribute();
                            li.Text3 = reader.Value; //CatMeaCodDescription
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> GetMealCodes_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 3)
            {
                GetElements(ref ObjectsBL.ListMealCodesMin);

                return ObjectsBL.ListMealCodesMin.FindAll(delegate(ListItem li) { return li.Text2.StartsWith(StrToSearch); });
            }
            if (StrToSearch.Length.Equals(4))
            {
                GetElements(ref ObjectsBL.ListMealCodesEq);

                return ObjectsBL.ListMealCodesEq.FindAll(delegate(ListItem li)
                { return ((li.Value.Equals(StrToSearch))); });

            }
            else
           {
                GetElements(ref ObjectsBL.ListMealCodesMaj);

                return ObjectsBL.ListMealCodesMaj.FindAll(delegate(ListItem li)
                { return ((li.Value.StartsWith(StrToSearch)) | (li.Text3.StartsWith(StrToSearch))); });
            }
        }


    }
}
