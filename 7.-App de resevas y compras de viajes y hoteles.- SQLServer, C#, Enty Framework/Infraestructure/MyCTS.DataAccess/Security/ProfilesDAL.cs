using System;
using System.Text;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
	/// <summary>
	/// Data access class for Profile table.
	/// </summary>
	public sealed class ProfilesDAL
	{
        public ProfilesDAL() { }

		/// <summary>
		/// Inserts a record into the Profile table.
		/// <summary>
		/// <param name="userId"></param>
		/// <param name="propertyNames"></param>
		/// <param name="propertyValuesString"></param>
		/// <param name="propertyValuesBinary"></param>
		/// <param name="lastUpdatedDate"></param>
		/// <returns></returns>
        public void Insert(Guid userId, string propertyNames, string propertyValuesString, byte[] propertyValuesBinary, DateTime lastUpdatedDate, string connectionName)
		{
            Database db = DatabaseFactory.CreateDatabase(connectionName);
			DbCommand dbCommand = db.GetStoredProcCommand("spProfileInsert");

			db.AddInParameter(dbCommand, "UserId", DbType.Guid, userId);
			db.AddInParameter(dbCommand, "PropertyNames", DbType.String, propertyNames);
			db.AddInParameter(dbCommand, "PropertyValuesString", DbType.String, propertyValuesString);
			db.AddInParameter(dbCommand, "PropertyValuesBinary", DbType.Binary, propertyValuesBinary);
			db.AddInParameter(dbCommand, "LastUpdatedDate", DbType.DateTime, lastUpdatedDate);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Selects a single record from the Profile table.
		/// <summary>
		/// <returns>DataSet</returns>
        public Profile Select(Guid userId,string connectionName)
		{
            Database db = DatabaseFactory.CreateDatabase(connectionName);
			DbCommand dbCommand = db.GetStoredProcCommand("spProfileSelect");

			db.AddInParameter(dbCommand, "UserId", DbType.Guid, userId);

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    return MakeProfile(dataReader);
                }
                else
                {
                    return null;
                }
            }
		}

		/// <summary>
		/// Selects records from the Profile table by a foreign key.
		/// <summary>
		/// <param name="userId"></param>
		/// <returns>DataSet</returns>
        public Profile SelectByUserId(Guid userId, string connectionName)
		{
            Database db = DatabaseFactory.CreateDatabase(connectionName);
			DbCommand dbCommand = db.GetStoredProcCommand("spProfileSelectByUserId");

			db.AddInParameter(dbCommand, "UserId", DbType.Guid, userId);

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    return MakeProfile(dataReader);
                }
                else
                {
                    return null;
                }
            }
        }

		/// <summary>
		/// Selects all records from the Profile table.
		/// <summary>
		/// <returns>DataSet</returns>
		public List<Profile> SelectAll(string connectionName)
		{
            Database db = DatabaseFactory.CreateDatabase(connectionName);
			DbCommand dbCommand = db.GetStoredProcCommand("spProfileSelectAll");

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                List<Profile> profileList = new List<Profile>();
                while (dataReader.Read())
                {
                    Profile profile = MakeProfile(dataReader);
                    profileList.Add(profile);
                }
                return profileList;
            }
		}

		/// <summary>
		/// Updates a record in the Profile table.
		/// <summary>
		/// <param name="userId"></param>
		/// <param name="propertyNames"></param>
		/// <param name="propertyValuesString"></param>
		/// <param name="propertyValuesBinary"></param>
		/// <param name="lastUpdatedDate"></param>
        public void Update(Guid userId, string propertyNames, string propertyValuesString, byte[] propertyValuesBinary, DateTime lastUpdatedDate, string connectionName)
		{
            Database db = DatabaseFactory.CreateDatabase(connectionName);
			DbCommand dbCommand = db.GetStoredProcCommand("spProfileUpdate");

			db.AddInParameter(dbCommand, "UserId", DbType.Guid, userId);
			db.AddInParameter(dbCommand, "PropertyNames", DbType.String, propertyNames);
			db.AddInParameter(dbCommand, "PropertyValuesString", DbType.String, propertyValuesString);
			db.AddInParameter(dbCommand, "PropertyValuesBinary", DbType.Binary, propertyValuesBinary);
			db.AddInParameter(dbCommand, "LastUpdatedDate", DbType.DateTime, lastUpdatedDate);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Profile table by a composite primary key.
		/// <summary>
        public void Delete(Guid userId, string connectionName)
		{
            Database db = DatabaseFactory.CreateDatabase(connectionName);
			DbCommand dbCommand = db.GetStoredProcCommand("spProfileDelete");

			db.AddInParameter(dbCommand, "UserId", DbType.Guid, userId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Profile table by a foreign key.
		/// <summary>
        public void DeleteByUserId(Guid userId, string connectionName)
		{
            Database db = DatabaseFactory.CreateDatabase(connectionName);
			DbCommand dbCommand = db.GetStoredProcCommand("spProfileDeleteByUserId");

			db.AddInParameter(dbCommand, "UserId", DbType.Guid, userId);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Creates a new instance of the Profile class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static Profile MakeProfile(IDataReader dataReader)
        {
            Profile profile = new Profile();

            if (dataReader.IsDBNull(0) == false)
            {
                profile.UserId = dataReader.GetGuid(0);
            }
            if (dataReader.IsDBNull(1) == false)
            {
                profile.PropertyNames = dataReader.GetString(1);
            }
            if (dataReader.IsDBNull(2) == false)
            {
                profile.PropertyValuesString = dataReader.GetString(2);
            }
            if (dataReader.IsDBNull(3) == false)
            {
                profile.PropertyValuesBinary = null;
            }
            if (dataReader.IsDBNull(4) == false)
            {
                profile.LastUpdatedDate = dataReader.GetDateTime(4);
            }

            return profile;
        }

	}
}
