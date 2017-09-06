using System;
using System.Collections.Generic;
using System.Text;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class RolesBL
    {
        public RolesBL()
        {
            //
        }


        /// <summary>	
        /// Obtiene un elemento utilizando la identidad enviada como parámetro (Capa de Negocio)	
        /// </summary>	
        /// <param name=''></param>	
        public static Rol GetRol(Guid RoleId)
        {
            RolesDAL rolesDAL = null;
            Rol role = null;
            rolesDAL = new RolesDAL();
            try
            {
                try
                {
                    role = rolesDAL.Select(RoleId, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    role = rolesDAL.Select(RoleId, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return role;
        }

        /// <summary>	
        /// Obtiene todos los elementos de la tabla (Capa de Negocio)
        /// </summary>	
        /// <param name=''></param>	
        public static List<Rol> GetAllRoles()
        {
            RolesDAL rolesDAL = null;
            List<Rol> listRoles = null;
            rolesDAL = new RolesDAL();
            try
            {
                try
                {
                    listRoles = rolesDAL.SelectAll(CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listRoles = rolesDAL.SelectAll(CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listRoles;
        }

        /// <summary>	
        /// Obtiene todos los elementos de la tabla (Capa de Negocio)
        /// </summary>	
        /// <param name=''></param>	
        public static List<Rol> GetRolesByUser(Guid usuario)
        {
            RolesDAL rolesDAL = null;
            List<Rol> listRoles = null;
            rolesDAL = new RolesDAL();
            try
            {
                try
                {
                    listRoles = rolesDAL.SelectByUser(usuario, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch(Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listRoles = rolesDAL.SelectByUser(usuario, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listRoles;
        }

        /// <summary>	
        /// Obtiene todos los elementos de la tabla (Capa de Negocio)
        /// </summary>	
        /// <param name=''></param>	
        public static List<Rol> GetRolesByUser(string Firma, string PCC)
        {
            RolesDAL rolesDAL = null;
            List<Rol> listRoles = null;
            rolesDAL = new RolesDAL();
            try
            {
                try
                {
                    listRoles = rolesDAL.SelectByUser(Firma, PCC, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listRoles = rolesDAL.SelectByUser(Firma, PCC, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listRoles;
        }

        /// <summary>	
        /// Inserta un elemento en la base de datos. (Capa de Negocio)	
        /// </summary>	
        /// <param name=""></param>	
        public static bool InsertRoles(Guid ApplicationId, Guid RoleId, string RoleName, string LoweredRoleName, string Description)
        {
            RolesDAL rolesDAL = null;
            bool bResult = false;
            rolesDAL = new RolesDAL();
            try
            {
                try
                {
                    rolesDAL.Insert(ApplicationId, RoleId, RoleName, LoweredRoleName, Description, CommonENT.MYCTSDBSECURITY_CONNECTION);
                    bResult = true;
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    rolesDAL.Insert(ApplicationId, RoleId, RoleName, LoweredRoleName, Description, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                    bResult = true;
                }
            }
            catch
            { }
            return bResult;
        }

        /// <summary>	
        /// Actualiza un elemento en la base de datos. (Capa de Negocio)	
        /// </summary>	
        /// <param name=""></param>	
        public static bool UpdateRoles(Guid ApplicationId, Guid RoleId, string RoleName, string LoweredRoleName, string Description)
        {
            RolesDAL rolesDAL = null;
            bool bResult = false;
            rolesDAL = new RolesDAL();
            try
            {
                try
                {
                    rolesDAL.Update(ApplicationId, RoleId, RoleName, LoweredRoleName, Description, CommonENT.MYCTSDBSECURITY_CONNECTION);
                    bResult = true;
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    rolesDAL.Update(ApplicationId, RoleId, RoleName, LoweredRoleName, Description, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                    bResult = true;
                }
            }
            catch
            { }
            return bResult;
        }


        /// <summary>	
        /// Borrado de un elemento de la base de datos (Capa de Negocio).	
        /// </summary>	
        /// <param name=""></param>	
        public static bool DeleteRoles(Guid RoleId)
        {
            RolesDAL rolesDAL = null;
            bool bResult = false;
            rolesDAL = new RolesDAL();
            try
            {
                try
                {
                    rolesDAL.Delete(RoleId, CommonENT.MYCTSDBSECURITY_CONNECTION);
                    bResult = true;
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    rolesDAL.Delete(RoleId, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                    bResult = true;
                }
            }
            catch
            { }
            return bResult;
        }

        /// <summary>
        /// Indica si el usuario pertenece a un determinado Rol
        /// </summary>
        /// <param name="userId">Id del usuario</param>
        /// <param name="roleName">Nombre del rol</param>
        /// <returns>Bool</returns>
        public static bool IsUserInRole(Guid userId, string roleName)
        {
            RolesDAL rolesDAL = new RolesDAL();
            bool exists = false;

            try
            {
                try
                {
                    exists = rolesDAL.IsUserInRole(userId, roleName, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    exists = rolesDAL.IsUserInRole(userId, roleName, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch
            { }

            return exists;
        }
    }
}
