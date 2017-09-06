using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Forms.UI.Entities;

namespace MyCTS.Forms.UI.DataAccess
{
    public class Security
    {
        private static string SQL_APPLICATIONOBJECTS = "SELECT [ID],[Text],[Name],EventName,Roles,ParentID,ShortCut,ImageName, Checked " +
                                                       "FROM ApplicationObjects Order By [Order]";

        public static List<ApplicationObjects> GetMenuData()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("MyCTSSecurityDB");
                DbCommand dbCommand = db.GetSqlStringCommand(SQL_APPLICATIONOBJECTS);

                List<ApplicationObjects> applicationObjectsList = new List<ApplicationObjects>();

                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    int _id = reader.GetOrdinal("ID");
                    int _text = reader.GetOrdinal("Text");
                    int _name = reader.GetOrdinal("Name");
                    int _eventname = reader.GetOrdinal("EventName");
                    int _roles = reader.GetOrdinal("Roles");
                    int _parentid = reader.GetOrdinal("ParentID");
                    int _shortcut = reader.GetOrdinal("ShortCut");
                    int _imagename = reader.GetOrdinal("ImageName");
                    int _checked = reader.GetOrdinal("checked");

                    while (reader.Read())
                    {
                        ApplicationObjects item = new ApplicationObjects();
                        item.ID = reader.GetInt32(_id);
                        item.Text = reader.GetString(_text);
                        item.Name = DBNull.Value == reader[_roles] ? string.Empty : reader.GetString(_name);
                        item.EventName = DBNull.Value == reader[_eventname] ? string.Empty : reader.GetString(_eventname);
                        item.Roles = DBNull.Value == reader[_roles] ? string.Empty : reader.GetString(_roles);
                        item.ParentID = reader.GetInt32(_parentid);
                        item.ShortCut = DBNull.Value == reader[_shortcut] ? string.Empty : reader.GetString(_shortcut);
                        item.ImageName = DBNull.Value == reader[_imagename] ? string.Empty : reader.GetString(_imagename);
                        item.Checked = Convert.ToBoolean(reader[_checked]);
                        applicationObjectsList.Add(item);
                    }
                }

                return applicationObjectsList;
            }
            catch
            {
                Database db = DatabaseFactory.CreateDatabase("MyCTSSecurityDB_Mirror");
                DbCommand dbCommand = db.GetSqlStringCommand(SQL_APPLICATIONOBJECTS);

                List<ApplicationObjects> applicationObjectsList = new List<ApplicationObjects>();

                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    int _id = reader.GetOrdinal("ID");
                    int _text = reader.GetOrdinal("Text");
                    int _name = reader.GetOrdinal("Name");
                    int _eventname = reader.GetOrdinal("EventName");
                    int _roles = reader.GetOrdinal("Roles");
                    int _parentid = reader.GetOrdinal("ParentID");
                    int _shortcut = reader.GetOrdinal("ShortCut");
                    int _imagename = reader.GetOrdinal("ImageName");
                    int _checked = reader.GetOrdinal("checked");

                    while (reader.Read())
                    {
                        ApplicationObjects item = new ApplicationObjects();
                        item.ID = reader.GetInt32(_id);
                        item.Text = reader.GetString(_text);
                        item.Name = DBNull.Value == reader[_roles] ? string.Empty : reader.GetString(_name);
                        item.EventName = DBNull.Value == reader[_eventname] ? string.Empty : reader.GetString(_eventname);
                        item.Roles = DBNull.Value == reader[_roles] ? string.Empty : reader.GetString(_roles);
                        item.ParentID = reader.GetInt32(_parentid);
                        item.ShortCut = DBNull.Value == reader[_shortcut] ? string.Empty : reader.GetString(_shortcut);
                        item.ImageName = DBNull.Value == reader[_imagename] ? string.Empty : reader.GetString(_imagename);
                        item.Checked = Convert.ToBoolean(reader[_checked]);
                        applicationObjectsList.Add(item);
                    }
                }

                return applicationObjectsList;
            }
        }
    }
}
