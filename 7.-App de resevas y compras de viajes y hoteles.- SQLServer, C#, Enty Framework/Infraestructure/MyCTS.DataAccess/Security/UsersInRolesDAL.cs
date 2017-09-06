using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyCTS.Entities;

namespace MyCTS.DataAccess
{
	/// <summary>
	/// Data access class for UsersInRoles table.
	/// </summary>
	public sealed class UsersInRolesDAL
	{
        public UsersInRolesDAL() { }

		/// <summary>
		/// Inserts a record into the UsersInRoles table.
		/// <summary>
		/// <param name="userId"></param>
		/// <param name="roleId"></param>
		/// <returns></returns>
		public void Insert(Guid userId, Guid roleId)
		{
			Database db = DatabaseFactory.CreateDatabase(CommonENT.MYCTSDBSECURITY_CONNECTION);
			DbCommand dbCommand = db.GetStoredProcCommand("spUsersInRolesInsert");

			db.AddInParameter(dbCommand, "UserId", DbType.Guid, userId);
			db.AddInParameter(dbCommand, "RoleId", DbType.Guid, roleId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Selects records from the UsersInRoles table by a foreign key.
		/// <summary>
		/// <param name="roleId"></param>
		/// <returns>DataSet</returns>
        public List<UserInRol> SelectByRoleId(Guid roleId)
		{
			Database db = DatabaseFactory.CreateDatabase(CommonENT.MYCTSDBSECURITY_CONNECTION);
			DbCommand dbCommand = db.GetStoredProcCommand("spUsersInRolesSelectByRoleId");

			db.AddInParameter(dbCommand, "RoleId", DbType.Guid, roleId);

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                List<UserInRol> usersInRoleList = new List<UserInRol>();
				while (dataReader.Read()) {
                    UserInRol usersInRole = MakeUsersInRole(dataReader);
					usersInRoleList.Add(usersInRole);
				}
				return usersInRoleList;
			}

		}

		/// <summary>
		/// Selects records from the UsersInRoles table by a foreign key.
		/// <summary>
		/// <param name="userId"></param>
		/// <returns>DataSet</returns>
        public List<UserInRol> SelectByUserId(Guid userId)
		{
			Database db = DatabaseFactory.CreateDatabase(CommonENT.MYCTSDBSECURITY_CONNECTION);
			DbCommand dbCommand = db.GetStoredProcCommand("spUsersInRolesSelectByUserId");

			db.AddInParameter(dbCommand, "UserId", DbType.Guid, userId);

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                List<UserInRol> usersInRoleList = new List<UserInRol>();
                while (dataReader.Read())
                {
                    UserInRol usersInRole = MakeUsersInRole(dataReader);
                    usersInRoleList.Add(usersInRole);
                }
                return usersInRoleList;
            }

		}

		/// <summary>
		/// Deletes a record from the UsersInRoles table by a composite primary key.
		/// <summary>
		public void Delete(Guid userId, Guid roleId)
		{
			Database db = DatabaseFactory.CreateDatabase(CommonENT.MYCTSDBSECURITY_CONNECTION);
			DbCommand dbCommand = db.GetStoredProcCommand("spUsersInRolesDelete");

			db.AddInParameter(dbCommand, "UserId", DbType.Guid, userId);
			db.AddInParameter(dbCommand, "RoleId", DbType.Guid, roleId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the UsersInRoles table by a foreign key.
		/// <summary>
		public void DeleteByRoleId(Guid roleId)
		{
			Database db = DatabaseFactory.CreateDatabase(CommonENT.MYCTSDBSECURITY_CONNECTION);
			DbCommand dbCommand = db.GetStoredProcCommand("spUsersInRolesDeleteByRoleId");

			db.AddInParameter(dbCommand, "RoleId", DbType.Guid, roleId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the UsersInRoles table by a foreign key.
		/// <summary>
		public void DeleteByUserId(Guid userId)
		{
			Database db = DatabaseFactory.CreateDatabase(CommonENT.MYCTSDBSECURITY_CONNECTION);
			DbCommand dbCommand = db.GetStoredProcCommand("spUsersInRolesDeleteByUserId");

			db.AddInParameter(dbCommand, "UserId", DbType.Guid, userId);

			db.ExecuteNonQuery(dbCommand);
		}

        		/// <summary>
		/// Creates a new instance of the UsersInRoles class and populates it with data from the specified SqlDataReader.
		/// </summary>
        private static UserInRol MakeUsersInRole(IDataReader dataReader)
        {
			UserInRol usersInRole = new UserInRol();
			
			if (dataReader.IsDBNull(0) == false) {
				usersInRole.UserId = dataReader.GetGuid(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				usersInRole.RoleId = dataReader.GetGuid(1);
			}

			return usersInRole;
		}

	}
}
