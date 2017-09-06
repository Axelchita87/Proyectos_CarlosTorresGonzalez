using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
	/// <summary>
	/// Data access class for Users table.
	/// </summary>
	public sealed class UsersDAL
	{
		public UsersDAL() {}

		/// <summary>
		/// Inserts a record into the Users table.
		/// </summary>
		/// <param name="applicationId"></param>
		/// <param name="userId"></param>
		/// <param name="userName"></param>
		/// <param name="loweredUserName"></param>
		/// <param name="isAnonymous"></param>
		/// <param name="lastActivityDate"></param>
		/// <param name="firm"></param>
		/// <param name="password"></param>
		/// <param name="familyName"></param>
		/// <param name="agent"></param>
		/// <param name="queue"></param>
		/// <param name="pCC"></param>
		/// <param name="tA"></param>
		/// <returns></returns>
        public void Insert(Guid applicationId, Guid userId, string userName, string loweredUserName, string userMail, DateTime lastActivityDate, string firm, string password, string familyName, string agent, string queue, string pCC, string tA, string connectionName)
		{
            Database db = DatabaseFactory.CreateDatabase(connectionName);
			DbCommand dbCommand = db.GetStoredProcCommand("spUsersInsert");

			db.AddInParameter(dbCommand, "ApplicationId", DbType.Guid, applicationId);
			db.AddInParameter(dbCommand, "UserId", DbType.Guid, userId);
			db.AddInParameter(dbCommand, "UserName", DbType.String, userName);
			db.AddInParameter(dbCommand, "LoweredUserName", DbType.String, loweredUserName);
			db.AddInParameter(dbCommand, "UserMail", DbType.String, userMail);
			db.AddInParameter(dbCommand, "LastActivityDate", DbType.DateTime, lastActivityDate);
			db.AddInParameter(dbCommand, "Firm", DbType.String, firm);
			db.AddInParameter(dbCommand, "Password", DbType.String, password);
			db.AddInParameter(dbCommand, "FamilyName", DbType.String, familyName);
			db.AddInParameter(dbCommand, "Agent", DbType.String, agent);
			db.AddInParameter(dbCommand, "Queue", DbType.String, queue);
			db.AddInParameter(dbCommand, "PCC", DbType.String, pCC);
			db.AddInParameter(dbCommand, "TA", DbType.String, tA);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Selects a single record from the Users table.
		/// <summary>
		/// <returns>DataSet</returns>
        public User Select(Guid userId, string connectionName)
		{
			Database db = DatabaseFactory.CreateDatabase(connectionName);
			DbCommand dbCommand = db.GetStoredProcCommand("spUsersSelect");

			db.AddInParameter(dbCommand, "UserId", DbType.Guid, userId);

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    return MakeUser(dataReader);
                }
                else
                {
                    return null;
                }
            }
        }



        /// <summary/>
        /// Selects a all AgentMail from the Users table.
        /// <summary/>
        /// <returns>DataSet</returns>
        public User SelectAgenMail(string AgentMail, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("GetAgenMail");

            db.AddInParameter(dbCommand, "AgentMail", DbType.String, AgentMail);

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    return MakeAgentMail(dataReader);
                }
                else
                {
                    return null;
                }
            }
        }


        /// <summary/>
        /// Selects a single record from the Users table.
        /// <summary/>
        /// <returns>DataSet</returns>
        public User Select(string Firma, string PCC, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("GetUserProfile");
            User objUser = null;

            db.AddInParameter(dbCommand, "Firma", DbType.String, Firma);
            db.AddInParameter(dbCommand, "PCC", DbType.String, PCC);


            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    objUser = MakeUser(dataReader);
                }
            }

            return objUser;
        }


		/// <summary>
		/// Selects records from the Users table by a foreign key.
		/// <summary>
		/// <param name="applicationId"></param>
		/// <returns>DataSet</returns>
        public List<User> SelectByApplicationId(Guid applicationId, string connectionName)
		{
            Database db = DatabaseFactory.CreateDatabase(connectionName);
			DbCommand dbCommand = db.GetStoredProcCommand("spUsersSelectByApplicationId");

			db.AddInParameter(dbCommand, "ApplicationId", DbType.Guid, applicationId);

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                List<User> userList = new List<User>();
                while (dataReader.Read())
                {
                    User user = MakeUser(dataReader);
                    userList.Add(user);
                }
                return userList;
            }

		}

		/// <summary>
		/// Selects all records from the Users table.
		/// <summary>
		/// <returns>DataSet</returns>
		public List<User> SelectAll(string connectionName)
		{
            Database db = null;
            //try
            //{
            //    db = DatabaseFactory.CreateDatabase("MyCTSSecurityDBProd");
            //}
            //catch (Exception)
            //{
            //    db = DatabaseFactory.CreateDatabase("MyCTSSecurityDBDev");
            //}
            db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("spUsersSelectAll");

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                List<User> userList = new List<User>();
                while (dataReader.Read())
                {
                    User user = MakeUser(dataReader);
                    userList.Add(user);
                }
                return userList;
            }
            
		}

		/// <summary>
		/// Updates a record in the Users table.
		/// <summary>
		/// <param name="applicationId"></param>
		/// <param name="userId"></param>
		/// <param name="userName"></param>
		/// <param name="loweredUserName"></param>
		/// <param name="isAnonymous"></param>
		/// <param name="lastActivityDate"></param>
		/// <param name="firm"></param>
		/// <param name="password"></param>
		/// <param name="familyName"></param>
		/// <param name="agent"></param>
		/// <param name="queue"></param>
		/// <param name="pCC"></param>
		/// <param name="tA"></param>
        public void Update(Guid applicationId, Guid userId, string userName, string loweredUserName, string userMail, DateTime lastActivityDate, string firm, string password, string familyName, string agent, string queue, string pCC, string tA, string connectionName)
		{
            Database db = DatabaseFactory.CreateDatabase(connectionName);
			DbCommand dbCommand = db.GetStoredProcCommand("spUsersUpdate");

			db.AddInParameter(dbCommand, "ApplicationId", DbType.Guid, applicationId);
			db.AddInParameter(dbCommand, "UserId", DbType.Guid, userId);
			db.AddInParameter(dbCommand, "UserName", DbType.String, userName);
			db.AddInParameter(dbCommand, "LoweredUserName", DbType.String, loweredUserName);
			db.AddInParameter(dbCommand, "UserMail", DbType.String, userMail);
			db.AddInParameter(dbCommand, "LastActivityDate", DbType.DateTime, lastActivityDate);
			db.AddInParameter(dbCommand, "Firm", DbType.String, firm);
			db.AddInParameter(dbCommand, "Password", DbType.String, password);
			db.AddInParameter(dbCommand, "FamilyName", DbType.String, familyName);
			db.AddInParameter(dbCommand, "Agent", DbType.String, agent);
			db.AddInParameter(dbCommand, "Queue", DbType.String, queue);
			db.AddInParameter(dbCommand, "PCC", DbType.String, pCC);
			db.AddInParameter(dbCommand, "TA", DbType.String, tA);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Users table by a composite primary key.
		/// <summary>
        public void Delete(Guid userId, string connectionName)
		{
            Database db = DatabaseFactory.CreateDatabase(connectionName);
			DbCommand dbCommand = db.GetStoredProcCommand("spUsersDelete");

			db.AddInParameter(dbCommand, "UserId", DbType.Guid, userId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Users table by a foreign key.
		/// <summary>
        public void DeleteByApplicationId(Guid applicationId, string connectionName)
		{
            Database db = DatabaseFactory.CreateDatabase(connectionName);
			DbCommand dbCommand = db.GetStoredProcCommand("spUsersDeleteByApplicationId");

			db.AddInParameter(dbCommand, "ApplicationId", DbType.Guid, applicationId);

			db.ExecuteNonQuery(dbCommand);
		}



        private static User MakeAgentMail(IDataReader dr)
        {
            User user = new User();


            int _AgentMail = dr.GetOrdinal("AgentMail");

            if (dr.IsDBNull(_AgentMail) == false)
                user.AgentMail = dr.GetString(_AgentMail);


            return user;
        }

    		/// <summary>
		/// Creates a new instance of the Users class and populates it with data from the specified SqlDataReader.
		/// </summary>
        private static User MakeUser(IDataReader dr)
        {
            User user = new User();

            int _applicationid = dr.GetOrdinal("ApplicationId");
            int _userid = dr.GetOrdinal("UserId");
            int _username = dr.GetOrdinal("UserName");
            int _loweredusername = dr.GetOrdinal("LoweredUserName");
            int _usermail = dr.GetOrdinal("UserMail");
            int _lastactivity = dr.GetOrdinal("LastActivityDate");
            int _firm = dr.GetOrdinal("Firm");
            int _password = dr.GetOrdinal("Password");
            int _familyname = dr.GetOrdinal("FamilyName");
            int _agent = dr.GetOrdinal("Agent");
            int _queue = dr.GetOrdinal("Queue");
            int _pcc = dr.GetOrdinal("PCC");
            int _statusfirm = dr.GetOrdinal("StatusFirm");
            int _ta = dr.GetOrdinal("TA");
            int _ismysabreblocked = dr.GetOrdinal("IsMySabreBlocked");
            int _installframework35 = dr.GetOrdinal("InstallFramework35");
            int _isframework35installed = dr.GetOrdinal("IsFramework35Installed");
            int _profileallaccess = dr.GetOrdinal("ProfileAllAccess");
            int _applicationname = dr.GetOrdinal("ApplicationName");
            int _orgid = dr.GetOrdinal("OrgId");
            int _supervisor = dr.GetOrdinal("Supervisor");
            int _upgradestatus = dr.GetOrdinal("UpgradeStatus");
            user.ApplicationId = dr.GetGuid(_applicationid);
            user.UserId = dr.GetGuid(_userid);
            user.UserName = dr.GetString(_username);
            user.LoweredUserName = dr.GetString(_loweredusername);

            if (dr.IsDBNull(_usermail) == false)
                user.UserMail = dr.GetString(_usermail);

            if (dr.IsDBNull(_lastactivity) == false)
                user.LastActivityDate = dr.GetDateTime(_lastactivity);

            if (dr.IsDBNull(_firm) == false)
                user.Firm = dr.GetString(_firm);

            if (dr.IsDBNull(_password) == false)
                user.Password = dr.GetString(_password);

            if (dr.IsDBNull(_familyname) == false)
                user.FamilyName = dr.GetString(_familyname);

            if (dr.IsDBNull(_agent) == false)
                user.Agent = dr.GetString(_agent);

            if (dr.IsDBNull(_queue) == false)
                user.Queue = dr.GetString(_queue);

            if (dr.IsDBNull(_pcc) == false)
                user.PCC = dr.GetString(_pcc);

            if (dr.IsDBNull(_statusfirm) == false)
                user.StatusFirm = dr.GetString(_statusfirm);

            if (dr.IsDBNull(_ta) == false)
                user.TA = dr.GetString(_ta);

            if (dr.IsDBNull(_profileallaccess) == false)
                user.ProfileAllAccess = dr.GetString(_profileallaccess);

            if (dr.IsDBNull(_upgradestatus) == false)
                user.UpgradeStatus = dr.GetInt32(_upgradestatus);

            user.ApplicationName = dr.GetString(_applicationname);
            user.OrgId = dr.GetInt32(_orgid);
            user.Supervisor = dr.GetBoolean(_supervisor);

            user.IsMySabreBlocked = dr.GetBoolean(_ismysabreblocked);
            user.InstallFramework35 = dr.GetBoolean(_installframework35);
            user.IsFramework35Installed = dr.GetBoolean(_isframework35installed);

            dr.NextResult();

            //Verifica Perfil Usuario
            if (dr.Read())
                user.ProfileUser = MakeProfile(dr);

            return user;
        }

        private static Profile MakeProfile(IDataReader dataReader)
        {
            Profile profile = new Profile();
            try
            {
                profile.UserId = dataReader.GetGuid(0);
                profile.PropertyNames = dataReader.GetString(1);

                if (!dataReader.IsDBNull(2))
                    profile.PropertyValuesString = dataReader.GetString(2);
                if (!dataReader.IsDBNull(3))
                    profile.PropertyValuesBinary = null;
                if (!dataReader.IsDBNull(4))
                    profile.LastUpdatedDate = dataReader.GetDateTime(4);
            }
            catch
            {
                profile = null;
            }


            return profile;
        }

	}
}
