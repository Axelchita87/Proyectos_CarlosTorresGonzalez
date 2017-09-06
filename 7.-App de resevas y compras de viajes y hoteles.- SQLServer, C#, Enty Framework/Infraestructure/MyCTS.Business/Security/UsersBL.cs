using System;
using System.Collections.Generic;
using System.Configuration;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class UserBL
    {
        public UserBL()
        {
            //
        }

        /// <summary>	
        /// Obtiene un elemento utilizando la identidad enviada como parámetro (Capa de Negocio)	
        /// </summary>	
        /// <param> <name></name> </param>
        /// <param name="UserId"> </param>	
        public static User GetUser(Guid UserId)
        {
            User user = null;
            UsersDAL UsersDAL = new UsersDAL();
            try
            {
                try
                {
                    user = UsersDAL.Select(UserId, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch 
                {
                    user = UsersDAL.Select(UserId, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch (Exception)
            {
            }

            return user;
        }



        /// <summary>	
        /// Obtiene el Campo AgentMail	
        /// </summary>	
        /// <param> <name></name> </param>
        /// <param name="Firma"> </param>
        public static User ValidAgentMail(string AgentMail)
        {
            User user = null;
            UsersDAL MailDal = new UsersDAL();

            try
            {
                user = MailDal.SelectAgenMail(AgentMail, CommonENT.MYCTSDBSECURITY_CONNECTION);

            }
            catch (Exception ex)
            {
            }

            return user;

        }
        /// <param name="PCC"> </param>	
        public static User GetUser(string Firma, string PCC)
        {
            User user = null;            
            UsersDAL objUsers = new UsersDAL();
            try
            {
                try
                {
                    user = objUsers.Select(Firma, PCC, CommonENT.MYCTSDBSECURITY_CONNECTION);
                    if (user != null)
                    {
                        
                        if (user.UserName != String.Empty)
                        {
                            ConfigurationManager.AppSettings["DatosContacto"] = user.UserName + "|" + user.Firm + "|" + user.PCC + "|" + user.UserMail + "|" + user.StatusFirm;
                        }
                    }
                }
                catch (Exception ex)
                {
                    

                    user = objUsers.Select(Firma, PCC, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                    if (user != null)
                    {
                        if (user.UserName != String.Empty)
                        {
                            ConfigurationManager.AppSettings["DatosContacto"] = user.UserName + "|" + user.Firm + "|" + user.PCC + "|" + user.UserMail;
                        }
                    }
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    
                }
            }
            catch (Exception ex)
            {
                new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
            }

            return user;
        }


        /// <summary>	
        /// Obtiene todos los elementos de la tabla (Capa de Negocio)
        /// </summary>	
        /// <param> <name></name> </param>	
        public static List<User> GetAllUser()
        {
            List<User> listUser = null;
            UsersDAL usersDAL = new UsersDAL();
            try
            {
                try
                {
                    listUser = usersDAL.SelectAll(CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch 
                {
                    listUser = usersDAL.SelectAll(CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch (Exception)
            {
               
            }
           
            return listUser;
        }


        /// <summary>	
        /// Inserta un elemento en la base de datos. (Capa de Negocio)	
        /// </summary>	
        /// <param> <name></name> </param>
        /// <param name="ApplicationId"> </param>
        /// <param name="UserId"> </param>
        /// <param name="UserName"> </param>
        /// <param name="LoweredUserName"> </param>
        /// <param name="UserMail"> </param>
        /// <param name="LastActivityDate"> </param>
        /// <param name="Firm"> </param>
        /// <param name="Password"> </param>
        /// <param name="FamilyName"> </param>
        /// <param name="Agent"> </param>
        /// <param name="Queue"> </param>
        /// <param name="PCC"> </param>
        /// <param name="TA"> </param>	
        public static bool InsertUser(Guid ApplicationId, Guid UserId, string UserName, string LoweredUserName, string UserMail, DateTime LastActivityDate, string Firm, string Password, string FamilyName, string Agent, string Queue, string PCC, string TA)
        {
            bool bResult = false;
            try
            {
                try
                {
                    new UsersDAL().Insert(ApplicationId, UserId, UserName, LoweredUserName, UserMail, LastActivityDate, Firm, Password, FamilyName, Agent, Queue, PCC, TA, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch 
                {
                    new UsersDAL().Insert(ApplicationId, UserId, UserName, LoweredUserName, UserMail, LastActivityDate, Firm, Password, FamilyName, Agent, Queue, PCC, TA, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
                bResult = true;
            }
            catch (Exception)
            {
            }
            return bResult;
        }

        /// <summary>
        /// Actualiza un elemento en la base de datos. (Capa de Negocio)
        /// </summary>
        /// <param name="ApplicationId">The application id.</param>
        /// <param name="UserId">The user id.</param>
        /// <param name="UserName">Name of the user.</param>
        /// <param name="LoweredUserName">Name of the lowered user.</param>
        /// <param name="UserMail">The user mail.</param>
        /// <param name="LastActivityDate">The last activity date.</param>
        /// <param name="Firm">The firm.</param>
        /// <param name="Password">The password.</param>
        /// <param name="FamilyName">Name of the family.</param>
        /// <param name="Agent">The agent.</param>
        /// <param name="Queue">The queue.</param>
        /// <param name="PCC">The PCC.</param>
        /// <param name="TA">The TA.</param>
        /// <returns></returns>
        public static bool UpdateUser(Guid ApplicationId, Guid UserId, string UserName, string LoweredUserName, string UserMail, DateTime LastActivityDate, string Firm, string Password, string FamilyName, string Agent, string Queue, string PCC, string TA)
        {
            bool bResult = false;
            try
            {
                try
                {
                    new UsersDAL().Update(ApplicationId, UserId, UserName, LoweredUserName, UserMail, LastActivityDate, Firm, Password, FamilyName, Agent, Queue, PCC, TA, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch 
                {
                    new UsersDAL().Update(ApplicationId, UserId, UserName, LoweredUserName, UserMail, LastActivityDate, Firm, Password, FamilyName, Agent, Queue, PCC, TA, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
                bResult = true;
            }
            catch (Exception)
            {
            }

            return bResult;
        }


        /// <summary>	
        /// Borrado de un elemento de la base de datos (Capa de Negocio).	
        /// </summary>	
        /// <param> <name></name> </param>
        /// <param name="UserId"> </param>	
        public static bool DeleteUser(Guid UserId)
        {
            bool bResult = false;
            try
            {
                try
                {
                    new UsersDAL().Delete(UserId, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch 
                {
                    new UsersDAL().Delete(UserId, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
                bResult = true;
            }
            catch (Exception)
            {
            }

            return bResult;
        }


        public static int OrgIdBL { get; set; }
    }
}
