using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;


namespace MyCTS.Business
{
    public class CatPccsBL
    {
        public static List<ListItem> GetPccs(string StrToSearch, int OrgId)
        {
            List<ListItem> listCatPccs = new List<ListItem>();
            CatPccsDAL objCatPccs = new CatPccsDAL();
            try
            {
                try
                {
                    listCatPccs = objCatPccs.GetPccs(StrToSearch, OrgId, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listCatPccs = objCatPccs.GetPccs(StrToSearch, OrgId, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listCatPccs;

        }

        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.PCCS_FILNAME;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {
                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value; //CatPCCsId
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value; //CatPCCsId + ' ' + CatPCCsName
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value.ToUpper(); //CatPCCsName                            
                            reader.MoveToNextAttribute();
                            li.Text3 = reader.Value.ToUpper(); //OrgId 
                            reader.MoveToNextAttribute();
                            li.Text5 = reader.Value.ToUpper();
                            reader.MoveToNextAttribute();
                            li.Text6 = reader.Value.ToUpper();
                            reader.MoveToNextAttribute();
                            li.Text7 = reader.Value.ToUpper();
                            reader.MoveToNextAttribute();
                            li.Text8 = reader.Value.ToUpper();
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> DeletePCCs_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 5)
            {
                GetElements(ref ObjectsBL.ListPCCsMin);

               return ObjectsBL.ListPCCsMin.FindAll(delegate(ListItem li)
                {
                  return li.Value.StartsWith(StrToSearch) && li.Text8 == "A" && li.Text3 == UserBL.OrgIdBL.ToString();
                });
            }
            else
            {
                GetElements(ref ObjectsBL.ListPCCsMaj);

                return ObjectsBL.ListPCCsMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch) && li.Text3 == UserBL.OrgIdBL.ToString()); });
            }
        }
        public static List<ListItem> GetPCCs_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 5)
            {
                if (StrToSearch.StartsWith("5U") || StrToSearch.Contains("CAPACITACION"))
                {
                    GetElements(ref ObjectsBL.ListPCCsMin);

                    return ObjectsBL.ListPCCsMin.FindAll(delegate(ListItem li)
                    {
                        return li.Value.StartsWith(StrToSearch) && li.Text8 == "A" && li.Text3 == UserBL.OrgIdBL.ToString() && li.Text5.Contains("CAPACITACION");
                    });

                }
                else 
                {
                    GetElements(ref ObjectsBL.ListPCCsMin);

                    return ObjectsBL.ListPCCsMin.FindAll(delegate(ListItem li)
                    {
                        return li.Value.StartsWith(StrToSearch) && li.Text8 == "A" && li.Text3 == UserBL.OrgIdBL.ToString() && li.Text5.Contains("OPERATIVO");
                    });
                }
                
            }
            else
            {
                GetElements(ref ObjectsBL.ListPCCsMaj);

                return ObjectsBL.ListPCCsMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.StartsWith(StrToSearch) && li.Text3 == UserBL.OrgIdBL.ToString()); });
            }
        }

    }
}
