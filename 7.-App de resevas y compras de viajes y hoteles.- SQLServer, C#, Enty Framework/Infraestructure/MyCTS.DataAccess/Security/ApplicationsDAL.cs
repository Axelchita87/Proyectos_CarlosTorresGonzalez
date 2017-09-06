using System;
using System.Text;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using MyCTS.Components.NullableHelper;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
	/// <summary>
	/// Data access class for Applications table.
	/// </summary>
	public sealed class ApplicationsDAL
	{
        public ApplicationsDAL() { }

		/// <summary>
		/// Inserts a record into the Applications table.
		/// <summary>
		/// <param name="applicationName"></param>
		/// <param name="loweredApplicationName"></param>
		/// <param name="applicationId"></param>
		/// <param name="description"></param>
		/// <returns></returns>
		public void Insert(string applicationName, string loweredApplicationName, Guid applicationId, string description)
		{
            
            Database db = DatabaseFactory.CreateDatabase(CommonENT.MYCTSDBSECURITY_CONNECTION);

			DbCommand dbCommand = db.GetStoredProcCommand("spApplicationsInsert");

			db.AddInParameter(dbCommand, "ApplicationName", DbType.String, applicationName);
			db.AddInParameter(dbCommand, "LoweredApplicationName", DbType.String, loweredApplicationName);
			db.AddInParameter(dbCommand, "ApplicationId", DbType.Guid, applicationId);
			db.AddInParameter(dbCommand, "Description", DbType.String, description);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Selects a single record from the Applications table.
		/// <summary>
		/// <returns>DataSet</returns>
        public ApplicationEntity Select(Guid applicationId)
		{
			Database db = DatabaseFactory.CreateDatabase(CommonENT.MYCTSDBSECURITY_CONNECTION);
			DbCommand dbCommand = db.GetStoredProcCommand("spApplicationsSelect");

			db.AddInParameter(dbCommand, "ApplicationId", DbType.Guid, applicationId);

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    return MakeApplication(dataReader);
                }
                else
                {
                    return null;
                }
            }
		}

		/// <summary>
		/// Selects all records from the Applications table.
		/// <summary>
		/// <returns>DataSet</returns>
        public List<ApplicationEntity> SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase(CommonENT.MYCTSDBSECURITY_CONNECTION);
			DbCommand dbCommand = db.GetStoredProcCommand("spApplicationsSelectAll");

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                List<ApplicationEntity> applicationList = new List<ApplicationEntity>();
                while (dataReader.Read())
                {
                    ApplicationEntity application = MakeApplication(dataReader);
                    applicationList.Add(application);
                }
                return applicationList;
            }
		}

		/// <summary>
		/// Updates a record in the Applications table.
		/// <summary>
		/// <param name="applicationName"></param>
		/// <param name="loweredApplicationName"></param>
		/// <param name="applicationId"></param>
		/// <param name="description"></param>
		public void Update(string applicationName, string loweredApplicationName, Guid applicationId, string description)
		{
			Database db = DatabaseFactory.CreateDatabase(CommonENT.MYCTSDBSECURITY_CONNECTION);
			DbCommand dbCommand = db.GetStoredProcCommand("spApplicationsUpdate");

			db.AddInParameter(dbCommand, "ApplicationName", DbType.String, applicationName);
			db.AddInParameter(dbCommand, "LoweredApplicationName", DbType.String, loweredApplicationName);
			db.AddInParameter(dbCommand, "ApplicationId", DbType.Guid, applicationId);
			db.AddInParameter(dbCommand, "Description", DbType.String, description);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Applications table by a composite primary key.
		/// <summary>
		public void Delete(Guid applicationId)
		{
			Database db = DatabaseFactory.CreateDatabase(CommonENT.MYCTSDBSECURITY_CONNECTION);
			DbCommand dbCommand = db.GetStoredProcCommand("spApplicationsDelete");

			db.AddInParameter(dbCommand, "ApplicationId", DbType.Guid, applicationId);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Creates a new instance of the Applications class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static ApplicationEntity MakeApplication(IDataReader dataReader)
        {
            ApplicationEntity application = new ApplicationEntity();

            application.ApplicationName = (dataReader.IsDBNull(0)) ? Types.StringNullValue : dataReader.GetString(0);
            application.LoweredApplicationName = (dataReader.IsDBNull(1)) ? Types.StringNullValue : dataReader.GetString(1);
            application.ApplicationId = (dataReader.IsDBNull(2)) ? Guid.NewGuid() : dataReader.GetGuid(2);
            application.Description = (dataReader.IsDBNull(3)) ? Types.StringNullValue : dataReader.GetString(3);

            return application;
        }

	}
}
