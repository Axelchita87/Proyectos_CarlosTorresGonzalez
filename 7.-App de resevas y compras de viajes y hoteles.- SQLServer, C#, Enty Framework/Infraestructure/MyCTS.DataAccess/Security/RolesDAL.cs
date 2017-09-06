using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.Common;
using MyCTS.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MyCTS.DataAccess
{
    /// <summary>
    /// Data access class for Roles table.
    /// </summary>
    public sealed class RolesDAL
    {
        public RolesDAL() { }

        /// <summary>
        /// Inserts a record into the Roles table.
        /// <summary>
        /// <param name="applicationId"></param>
        /// <param name="roleId"></param>
        /// <param name="roleName"></param>
        /// <param name="loweredRoleName"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public void Insert(Guid applicationId, Guid roleId, string roleName, string loweredRoleName, string description, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("spRolesInsert");

            db.AddInParameter(dbCommand, "ApplicationId", DbType.Guid, applicationId);
            db.AddInParameter(dbCommand, "RoleId", DbType.Guid, roleId);
            db.AddInParameter(dbCommand, "RoleName", DbType.String, roleName);
            db.AddInParameter(dbCommand, "LoweredRoleName", DbType.String, loweredRoleName);
            db.AddInParameter(dbCommand, "Description", DbType.String, description);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Roles table.
        /// <summary>
        /// <returns>DataSet</returns>
        public Rol Select(Guid roleId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("spRolesSelect");

            db.AddInParameter(dbCommand, "RoleId", DbType.Guid, roleId);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    return MakeRole(dataReader);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Selects records from the Roles table by a foreign key.
        /// <summary>
        /// <param name="applicationId"></param>
        /// <returns>DataSet</returns>
        public List<Rol> SelectByApplicationId(Guid applicationId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("spRolesSelectByApplicationId");

            db.AddInParameter(dbCommand, "ApplicationId", DbType.Guid, applicationId);

            List<Rol> roleList = new List<Rol>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    Rol role = MakeRole(dataReader);
                    roleList.Add(role);
                }
                return roleList;
            }
        }

        /// <summary>
        /// Selects records from the Roles table by a foreign key.
        /// <summary>
        /// <param name="applicationId"></param>
        /// <returns>Entity</returns>
        public List<Rol> SelectByUser(Guid usuarioId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("spRolesSelectByUsuarioID");

            db.AddInParameter(dbCommand, "UsuarioId", DbType.Guid, usuarioId);

            List<Rol> roleList = new List<Rol>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    Rol role = MakeRole(dataReader);
                    roleList.Add(role);
                }
                return roleList;
            }
        }

        /// <summary>
        /// Selects records from the Roles table by a Firm and PCC.
        /// <summary>
        /// <param name="applicationId"></param>
        /// <returns>Entity</returns>
        public List<Rol> SelectByUser(string Firma, string PCC, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("spRolesSelectByUsuario");

            db.AddInParameter(dbCommand, "Firma", DbType.String, Firma);
            db.AddInParameter(dbCommand, "PCC", DbType.String, PCC);

            List<Rol> roleList = new List<Rol>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    Rol role = MakeRole(dataReader);
                    roleList.Add(role);
                }
                return roleList;
            }
        }

        /// <summary>
        /// Selects all records from the Roles table.
        /// <summary>
        /// <returns>DataSet</returns>
        public List<Rol> SelectAll(string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("spRolesSelectAll");
            List<Rol> roleList = new List<Rol>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    Rol role = MakeRole(dataReader);
                    roleList.Add(role);
                }
                return roleList;
            }
        }

        /// <summary>
        /// Updates a record in the Roles table.
        /// <summary>
        /// <param name="applicationId"></param>
        /// <param name="roleId"></param>
        /// <param name="roleName"></param>
        /// <param name="loweredRoleName"></param>
        /// <param name="description"></param>
        public void Update(Guid applicationId, Guid roleId, string roleName, string loweredRoleName, string description, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("spRolesUpdate");

            db.AddInParameter(dbCommand, "ApplicationId", DbType.Guid, applicationId);
            db.AddInParameter(dbCommand, "RoleId", DbType.Guid, roleId);
            db.AddInParameter(dbCommand, "RoleName", DbType.String, roleName);
            db.AddInParameter(dbCommand, "LoweredRoleName", DbType.String, loweredRoleName);
            db.AddInParameter(dbCommand, "Description", DbType.String, description);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Roles table by a composite primary key.
        /// <summary>
        public void Delete(Guid roleId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("spRolesDelete");

            db.AddInParameter(dbCommand, "RoleId", DbType.Guid, roleId);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Roles table by a foreign key.
        /// <summary>
        public void DeleteByApplicationId(Guid applicationId, string connectionName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("spRolesDeleteByApplicationId");

            db.AddInParameter(dbCommand, "ApplicationId", DbType.Guid, applicationId);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Creates a new instance of the Roles class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static Rol MakeRole(IDataReader dataReader)
        {
            Rol role = new Rol();

            if (dataReader.IsDBNull(0) == false)
            {
                role.ApplicationId = dataReader.GetGuid(0);
            }
            if (dataReader.IsDBNull(1) == false)
            {
                role.RoleId = dataReader.GetGuid(1);
            }
            if (dataReader.IsDBNull(2) == false)
            {
                role.RoleName = dataReader.GetString(2);
            }
            if (dataReader.IsDBNull(3) == false)
            {
                role.LoweredRoleName = dataReader.GetString(3);
            }
            if (dataReader.IsDBNull(4) == false)
            {
                role.Description = dataReader.GetString(4);
            }

            return role;
        }

        /// <summary>
        /// Indica si el usuario pertenece a un determinado Rol
        /// </summary>
        /// <param name="userId">Id del usuario</param>
        /// <param name="roleName">Nombre del rol</param>
        /// <param name="connectionName">Nombre conexion</param>
        /// <returns>Bool</returns>
        public bool IsUserInRole(Guid userId, string roleName, string connectionName)
        {

            Database db = DatabaseFactory.CreateDatabase(connectionName);
            DbCommand dbCommand = db.GetStoredProcCommand("IsUserInRole");
            bool exists = false;

            db.AddInParameter(dbCommand, "userID", DbType.Guid, userId);
            db.AddInParameter(dbCommand, "roleName", DbType.String, roleName);

            using (IDataReader dr = db.ExecuteReader(dbCommand))
            {
                exists = dr.Read();
            }

            return exists;
        }

    }
}

