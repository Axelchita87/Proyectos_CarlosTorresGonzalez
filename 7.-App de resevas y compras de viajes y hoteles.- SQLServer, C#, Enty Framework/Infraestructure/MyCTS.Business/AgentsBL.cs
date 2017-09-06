using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;
using System.Xml;

namespace MyCTS.Business
{
    public class AgentsBL
    {
        public static List<ListItem> GetAgents(string StrToSearch)
        {
            List<ListItem> AgentsList = new List<ListItem>();
            AgentsDAL objAgents = new AgentsDAL();
            try
            {
                try
                {
                    AgentsList = objAgents.GetAgents(StrToSearch, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    AgentsList = objAgents.GetAgents(StrToSearch, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }

            }
            catch
            { }
            return AgentsList;

        }

        private static void GetElements(ref List<ListItem> list)
        {
            if (list == null)
            {
                list = new List<ListItem>();
                string pathfile = GlobalConstants.PATH_SABRE_USER + "\\" + GlobalConstants.AGENT_FILENAME;
                XmlTextReader reader = new XmlTextReader(pathfile);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {
                            ListItem li = new ListItem();
                            reader.MoveToFirstAttribute();
                            li.Value = reader.Value.ToUpper(); //Agent
                            reader.MoveToNextAttribute();
                            li.Text = reader.Value.ToUpper(); //Agent + ' ' + FamilyName
                            reader.MoveToNextAttribute();
                            li.Text2 = reader.Value.ToUpper(); //FamilyName                            
                            reader.MoveToNextAttribute();
                            li.Text3 = reader.Value.ToUpper(); //OrgId                           
                            list.Add(li);
                        }
                    }
                }
            }

        }

        public static List<ListItem> GetAgent_Predictive(string StrToSearch)
        {
            if (StrToSearch.Length < 3)
            {
                GetElements(ref ObjectsBL.ListAgentsCodesMin);

                return ObjectsBL.ListAgentsCodesMin.FindAll(delegate(ListItem li) { return li.Value.StartsWith(StrToSearch) && li.Text3 == UserBL.OrgIdBL.ToString(); });
            }
            else
            {
                GetElements(ref ObjectsBL.ListAgentsCodesMaj);

                return ObjectsBL.ListAgentsCodesMaj.FindAll(delegate(ListItem li)
                { return (li.Text2.Contains(StrToSearch) && li.Text3 == UserBL.OrgIdBL.ToString()); });
            }
        }

    }
}
