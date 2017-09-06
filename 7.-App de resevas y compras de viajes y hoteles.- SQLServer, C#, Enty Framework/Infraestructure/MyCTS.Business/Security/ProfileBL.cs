using System;
using System.Collections.Generic;
using System.Text;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class ProfileBL
    {
        public ProfileBL()
        {
            //
        }


        /// <summary>	
        /// Obtiene un elemento utilizando la identidad enviada como parámetro (Capa de Negocio)	
        /// </summary>	
        /// <param name=''></param>	
        public static Profile GetProfile(Guid UserId)
        {
            ProfilesDAL profileDAL = null;
            Profile profile = null;
            profileDAL = new ProfilesDAL();
            try
            {
                try
                {
                    profile = profileDAL.Select(UserId, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    profile = profileDAL.Select(UserId, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
                
            }
            catch (Exception ex)
            {
                profile = null;
                throw ex;
            }
            finally
            {
                profileDAL = null;
            }
            return profile;
        }

        /// <summary>	
        /// Obtiene todos los elementos de la tabla (Capa de Negocio)
        /// </summary>	
        /// <param name=''></param>	
        public static List<Profile> GetAllProfile()
        {
            ProfilesDAL profileDAL = null;
            List<Profile> listProfile = null;
            profileDAL = new ProfilesDAL();
            try
            {
                try
                {
                    listProfile = profileDAL.SelectAll(CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listProfile = profileDAL.SelectAll(CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
                
            }
            catch (Exception ex)
            {
                listProfile = null;
                throw ex;
            }
            finally
            {
                profileDAL = null;
            }
            return listProfile;
        }


        /// <summary>	
        /// Inserta un elemento en la base de datos. (Capa de Negocio)	
        /// </summary>	
        /// <param name=""></param>	
        public static bool InsertProfile(Guid UserId, string PropertyNames, string PropertyValuesString, byte[] PropertyValuesBinary, DateTime LastUpdatedDate)
        {
            ProfilesDAL profileDAL = null;
            bool bResult = false;
            profileDAL = new ProfilesDAL();
            try
            {
                try
                {
                    profileDAL.Insert(UserId, PropertyNames, PropertyValuesString, PropertyValuesBinary, LastUpdatedDate, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    profileDAL.Insert(UserId, PropertyNames, PropertyValuesString, PropertyValuesBinary, LastUpdatedDate, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
                
                bResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                profileDAL = null;
            }
            return bResult;
        }

        /// <summary>	
        /// Actualiza un elemento en la base de datos. (Capa de Negocio)	
        /// </summary>	
        /// <param name=""></param>	
        public static bool UpdateProfile(Guid UserId, string PropertyNames, string PropertyValuesString, byte[] PropertyValuesBinary, DateTime LastUpdatedDate)
        {
            ProfilesDAL profileDAL = null;
            bool bResult = false;
            profileDAL = new ProfilesDAL();
            try
            {
                try
                {
                    profileDAL.Update(UserId, PropertyNames, PropertyValuesString, PropertyValuesBinary, LastUpdatedDate, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    profileDAL.Update(UserId, PropertyNames, PropertyValuesString, PropertyValuesBinary, LastUpdatedDate, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
                
                bResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                profileDAL = null;
            }
            return bResult;
        }


        /// <summary>	
        /// Borrado de un elemento de la base de datos (Capa de Negocio).	
        /// </summary>	
        /// <param name=""></param>	
        public static bool DeleteProfile(Guid UserId)
        {
            ProfilesDAL profileDAL = null;
            bool bResult = false;
            profileDAL = new ProfilesDAL();
            try
            {
                try
                {
                    profileDAL.Delete(UserId, CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    profileDAL.Delete(UserId, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
                
                bResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                profileDAL = null;
            }
            return bResult;
        }
    }
}
