using System;
using System.Collections.Generic;
using System.Text;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class UserinrolBL
    {
        public UserinrolBL()
        {
            //
        }


        /// <summary>	
        /// Obtiene un elemento utilizando la identidad enviada como parámetro (Capa de Negocio)	
        /// </summary>	
        /// <param name=''></param>	
        public static List<UserInRol> GetUserinrol(Guid UserId)
        {
            UsersInRolesDAL usersInRolesDAL = null;
            List<UserInRol> listUserinrol = null;
            try
            {
                usersInRolesDAL = new UsersInRolesDAL();
                listUserinrol = usersInRolesDAL.SelectByUserId(UserId);
            }
            catch (Exception ex)
            {
                listUserinrol = null;
                throw ex;
            }
            finally
            {
                usersInRolesDAL = null;
            }
            return listUserinrol;
        }

        /// <summary>	
        /// Obtiene todos los elementos de la tabla (Capa de Negocio)
        /// </summary>	
        /// <param name=''></param>	
        public static List<UserInRol> GetAllUserinrol(Guid RoleId)
        {
            UsersInRolesDAL userinrolDAL = null;
            List<UserInRol> listUserinrol = null;
            try
            {
                //llenar  
                userinrolDAL = new UsersInRolesDAL();
                listUserinrol = userinrolDAL.SelectByRoleId(RoleId);
            }
            catch (Exception ex)
            {
                listUserinrol = null;
                //EventLog.WriteEntry("SIO", " BusGetAll Userinrol:" + ex.Message, EventLogEntryType.Error);
                throw ex;
            }
            finally
            {
                userinrolDAL = null;
            }
            return listUserinrol;
        }


        /// <summary>	
        /// Inserta un elemento en la base de datos. (Capa de Negocio)	
        /// </summary>	
        /// <param name=""></param>	
        public static bool InsertUserinrol(Guid UserId, Guid RoleId)
        {
            UsersInRolesDAL UserinrolDAL = null;
            bool bResult = false;
            try
            {
                UserinrolDAL = new UsersInRolesDAL();
                //llenar  
                UserinrolDAL.Insert(UserId, RoleId);
                bResult = true;
            }
            catch (Exception ex)
            {
                //EventLog.WriteEntry("SIO", " BusInsert Userinrol:" + ex.Message, EventLogEntryType.Error);
                throw ex;
            }
            finally
            {
                UserinrolDAL = null;
            }
            return bResult;
        }



        /// <summary>	
        /// Borrado de un elemento de la base de datos (Capa de Negocio).	
        /// </summary>	
        /// <param name=""></param>	
        public static bool DeleteUserinrol(Guid UserId, Guid RoleId)
        {
            UsersInRolesDAL UserinrolDAL = null;
            bool bResult = false;
            try
            {
                UserinrolDAL = new UsersInRolesDAL();
                //llenar  
                UserinrolDAL.Delete(UserId, RoleId);
                bResult = true;
            }
            catch (Exception ex)
            {
                //EventLog.WriteEntry("SIO", " BusDelete Userinrol:" + ex.Message, EventLogEntryType.Error);
                throw ex;
            }
            finally
            {
                UserinrolDAL = null;
            }
            return bResult;
        }
    }
}