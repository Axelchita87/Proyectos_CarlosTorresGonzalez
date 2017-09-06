using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;

namespace MyCTS.DataAccess
{
    public static class DocsSecondLevelDA
    {
        public static bool AddImage(DocsSecondLevel docsEntities, string connectionName)
        {
            bool success = false;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionName);
                DbCommand dbCommand = db.GetStoredProcCommand("SetDocsSecondLevel");
                dbCommand.CommandTimeout = 60;
                db.AddInParameter(dbCommand, "ProfileId ", DbType.Int32, docsEntities.ProfileId);
                db.AddInParameter(dbCommand, "Name ", DbType.String, docsEntities.Name);
                db.AddInParameter(dbCommand, "Image ", DbType.Binary, docsEntities.Image);
                db.AddInParameter(dbCommand, "Enable ", DbType.Boolean, docsEntities.Enable);
                db.AddInParameter(dbCommand, "DocName", DbType.String, docsEntities.NameDocument);
                success = db.ExecuteNonQuery(dbCommand) > 0 ? true : false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return success;
        }

        public static bool DeleteImage(DocsSecondLevel docsEntities, string connectionName)
        {
            bool success = false;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionName);
                DbCommand dbCommand = db.GetStoredProcCommand("DeleteDocsSecondLevel");
                dbCommand.CommandTimeout = 60;
                db.AddInParameter(dbCommand, "ProfileId ", DbType.Int32, docsEntities.ProfileId);
                db.AddInParameter(dbCommand, "imageId ", DbType.Int32, docsEntities.ImageId);
                db.AddInParameter(dbCommand, "DeleteDate ", DbType.DateTime, docsEntities.DeleteDate);
                success = db.ExecuteNonQuery(dbCommand) > 0 ? true : false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return success;
        }

        public static bool UpdateImage(DocsSecondLevel docsEntities, string connectionName)
        {
            bool success = false;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionName);
                DbCommand dbCommand = db.GetStoredProcCommand("UpdateDocsSecondLevel");
                dbCommand.CommandTimeout = 60;
                db.AddInParameter(dbCommand, "ProfileId ", DbType.Int32, docsEntities.ProfileId);
                db.AddInParameter(dbCommand, "imageId ", DbType.Int32, docsEntities.ImageId);
                db.AddInParameter(dbCommand, "Image ", DbType.Binary, docsEntities.Image);
                db.AddInParameter(dbCommand, "UpdateDate ", DbType.DateTime, docsEntities.UpdateDate);
                db.AddInParameter(dbCommand, "Enable ", DbType.Boolean, docsEntities.Enable);
                db.AddInParameter(dbCommand, "docName", DbType.String, docsEntities.NameDocument);
                db.AddInParameter(dbCommand, "Name", DbType.String, docsEntities.Name);
                success = db.ExecuteNonQuery(dbCommand) > 0 ? true : false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return success;
        }

        public static DocsSecondLevel getImage(int profileId, int imageId, string connectionName)
        {
            try
            {
                DocsSecondLevel docsReturn = new DocsSecondLevel();
                Database db = DatabaseFactory.CreateDatabase(connectionName);
                DbCommand dbCommand = db.GetStoredProcCommand("GetDocsSecondLevel");
                dbCommand.CommandTimeout = 60;
                db.AddInParameter(dbCommand, "ProfileId ", DbType.Int32, profileId);
                db.AddInParameter(dbCommand, "imageId ", DbType.Int32, imageId);
                IDataReader  result = db.ExecuteReader (dbCommand);
                while (result.Read())
                {
                    docsReturn.ProfileId = int.Parse(result["ProfileId"].ToString());
                    docsReturn.Name = result["Name"].ToString();
                    docsReturn.Image = (byte[])result["Image"];
                    docsReturn.ImageId = int.Parse(result["imageId"].ToString());
                    docsReturn.NameDocument = result["DocName"].ToString();
                    docsReturn.InsertDate = result["InsertDate"] is DBNull ? DateTime.Parse("01/01/1900") : DateTime.Parse(result["InsertDate"].ToString());
                    docsReturn.UpdateDate = result["UpdateDate"] is DBNull ?  DateTime.Parse("01/01/1900"):DateTime.Parse(result["UpdateDate"].ToString()) ;
                    docsReturn.DeleteDate = result["DeleteDate"] is DBNull ? DateTime.Parse("01/01/1900") : DateTime.Parse(result["DeleteDate"].ToString());
                    docsReturn.Enable = bool.Parse(result["Enable"].ToString());
                }
                return docsReturn;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
       
        public static DocsSecondLevel getImageById(int imageId, string connectionName)
        {
            try
            {
                DocsSecondLevel docsReturn = new DocsSecondLevel();
                Database db = DatabaseFactory.CreateDatabase(connectionName);
                DbCommand dbCommand = db.GetStoredProcCommand("GetDocsSecondLevelByImageId");
                dbCommand.CommandTimeout = 60;
                db.AddInParameter(dbCommand, "imageId ", DbType.Int32, imageId);
                IDataReader result = db.ExecuteReader(dbCommand);
                while (result.Read())
                {
                    docsReturn.ProfileId = int.Parse(result["ProfileId"].ToString());
                    docsReturn.Name = result["Name"].ToString();
                    docsReturn.Image = (byte[])result["Image"];
                    docsReturn.ImageId = int.Parse(result["imageId"].ToString());
                    docsReturn.NameDocument = result["DocName"].ToString();
                    docsReturn.InsertDate = result["InsertDate"] is DBNull ? DateTime.Parse("01/01/1900") : DateTime.Parse(result["InsertDate"].ToString());
                    docsReturn.UpdateDate = result["UpdateDate"] is DBNull ? DateTime.Parse("01/01/1900") : DateTime.Parse(result["UpdateDate"].ToString());
                    docsReturn.DeleteDate = result["DeleteDate"] is DBNull ? DateTime.Parse("01/01/1900") : DateTime.Parse(result["DeleteDate"].ToString());
                    docsReturn.Enable = bool.Parse(result["Enable"].ToString());
                }
                return docsReturn;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static List<DocsSecondLevel> getImageByProfileId(int profileId, string connectionName)
        {
            try
            {             
                List<DocsSecondLevel> listDocsReturn = new List<DocsSecondLevel>();
                Database db = DatabaseFactory.CreateDatabase(connectionName);
                DbCommand dbCommand = db.GetStoredProcCommand("GetDocsSecondLevelbyProfileId");
                dbCommand.CommandTimeout = 60;
                db.AddInParameter(dbCommand, "ProfileId", DbType.Int32, profileId);
                IDataReader result = db.ExecuteReader(dbCommand);
                while (result.Read())
                {
                    DocsSecondLevel docsReturn = new DocsSecondLevel();
                    docsReturn.ProfileId = int.Parse(result["ProfileId"].ToString());
                    docsReturn.Name = result["Name"].ToString();
                    docsReturn.Image = (byte[])result["Image"];
                    docsReturn.NameDocument = result["DocName"].ToString();
                    docsReturn.ImageId = int.Parse(result["imageId"].ToString());
                    docsReturn.InsertDate = result["InsertDate"] is DBNull ? DateTime.Parse("01/01/1900") : DateTime.Parse(result["InsertDate"].ToString());
                    docsReturn.UpdateDate = result["UpdateDate"] is DBNull ? DateTime.Parse("01/01/1900") : DateTime.Parse(result["UpdateDate"].ToString());
                    docsReturn.DeleteDate = result["DeleteDate"] is DBNull ? DateTime.Parse("01/01/1900") : DateTime.Parse(result["DeleteDate"].ToString());
                    docsReturn.Enable = bool.Parse(result["Enable"].ToString());
                    listDocsReturn.Add(docsReturn);
                }
                return listDocsReturn;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
