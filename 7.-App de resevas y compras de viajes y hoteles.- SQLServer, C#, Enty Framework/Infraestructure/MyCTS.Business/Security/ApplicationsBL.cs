using System;
using System.Collections.Generic;
using System.Text;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class ApplicationsBL
    {
        public ApplicationsBL()
        {
            //
        }


        /// <summary>	
        /// Obtiene un elemento utilizando la identidad enviada como parámetro (Capa de Negocio)	
        /// </summary>	
        /// <param name=''></param>	
        public static ApplicationEntity GetApplications(Guid ApplicationId)
        {
            ApplicationsDAL applicationsDAL = null;
            ApplicationEntity application = null;
            try
            {
                applicationsDAL = new ApplicationsDAL();
                application = applicationsDAL.Select(ApplicationId);
            }
            catch (Exception ex)
            {
                application = null;
                throw ex;
            }
            finally
            {
                applicationsDAL = null;
            }
            return application;
        }

        /// <summary>	
        /// Obtiene todos los elementos de la tabla (Capa de Negocio)
        /// </summary>	
        /// <param name=''></param>	
        public static List<ApplicationEntity> GetAllApplications()
        {
            ApplicationsDAL applicationsDAL = null;
            List<ApplicationEntity> listApplications = null;
            try
            {
                applicationsDAL = new ApplicationsDAL();
                listApplications = applicationsDAL.SelectAll();
            }
            catch (Exception ex)
            {
                listApplications = null;
                throw ex;
            }
            finally
            {
                applicationsDAL = null;
            }
            return listApplications;
        }


        /// <summary>	
        /// Inserta un elemento en la base de datos. (Capa de Negocio)	
        /// </summary>	
        /// <param name=""></param>	
        public static bool InsertApplications(string ApplicationName, string LoweredApplicationName, Guid ApplicationId, string Description)
        {
            ApplicationsDAL applicationsDAL = null;
            bool bResult = false;
            try
            {
                applicationsDAL = new ApplicationsDAL();
                applicationsDAL.Insert(ApplicationName, LoweredApplicationName, ApplicationId, Description);
                bResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                applicationsDAL = null;
            }
            return bResult;
        }

        /// <summary>	
        /// Actualiza un elemento en la base de datos. (Capa de Negocio)	
        /// </summary>	
        /// <param name=""></param>	
        public static bool UpdateApplications(string ApplicationName, string LoweredApplicationName, Guid ApplicationId, string Description)
        {
            ApplicationsDAL applicationsDAL = null;
            bool bResult = false;
            try
            {
                applicationsDAL = new ApplicationsDAL();
                applicationsDAL.Update(ApplicationName, LoweredApplicationName, ApplicationId, Description);
                bResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                applicationsDAL = null;
            }
            return bResult;
        }


        /// <summary>	
        /// Borrado de un elemento de la base de datos (Capa de Negocio).	
        /// </summary>	
        /// <param name=""></param>	
        public static bool DeleteApplications(Guid ApplicationId)
        {
            ApplicationsDAL applicationsDAL = null;
            bool bResult = false;
            try
            {
                applicationsDAL = new ApplicationsDAL();
                applicationsDAL.Delete(ApplicationId);
                bResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                applicationsDAL = null;
            }
            return bResult;
        }
    }
}
