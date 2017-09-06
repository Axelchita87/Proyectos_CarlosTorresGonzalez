using System;
using System.Collections.Generic;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CatAllStarsBL
    {

        public static List<CatAllStars> ListAllStars = null;

        public static List<CatAllStars> GetAllStars(int OrgId, string name, string tipoBusqueda)
        {
            List<CatAllStars> listAllStars = new List<CatAllStars>();
            CatAllStarsDAL objGetAllStars = new CatAllStarsDAL();
            try
            {
                try
                {
                    listAllStars = objGetAllStars.GetAllStars(OrgId, name, tipoBusqueda, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listAllStars = objGetAllStars.GetAllStars(OrgId, name, tipoBusqueda, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }

            return listAllStars;
        }

        public static List<CatAllStars> GetAllStars(int OrgId, string name)
        {
            List<CatAllStars> listAllStars = new List<CatAllStars>();
            CatAllStarsDAL objGetAllStars = new CatAllStarsDAL();
            try
            {
                try
                {
                    listAllStars = objGetAllStars.GetAllStars(OrgId, name, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listAllStars = objGetAllStars.GetAllStars(OrgId, name, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }

            return listAllStars;
        }

        /// <summary>
        /// Codigo para motor de busqueda profiles
        /// </summary>
        /// <returns></returns>
        public static List<CatAllStars> GetAllStars_Profile(string strToSearch, int OrgId)
        {
            //GetElements(ref ListAllStars, OrgId);

            if (strToSearch.Length > 2)
            {
                return ListAllStars.FindAll(delegate(CatAllStars li)
                { return ((li.StarName.Contains(strToSearch) || li.Email.Contains(strToSearch) || li.DK.Contains(strToSearch)) && li.Active.Equals(true)); });
            }
            else
            {
                return ListAllStars.FindAll(delegate(CatAllStars li)
                { return ((li.StarName.StartsWith(strToSearch) || li.Email.StartsWith(strToSearch) || li.DK.StartsWith(strToSearch)) && li.Active.Equals(true)); });
            }

        }


        /// <summary>
        /// Codigo para motor de busqueda profiles a detalle
        /// </summary>
        /// <returns></returns>
        public static List<CatAllStars> GetAllStarsDetailed_Profile(string Pccid, string Star1Name, string Star2Name, int OrgId)
        {

            if (string.IsNullOrEmpty(Pccid) && !string.IsNullOrEmpty(Star2Name) && !string.IsNullOrEmpty(Star1Name))
            {
                return ListAllStars.FindAll(delegate(CatAllStars li)
                { return ((li.StarName.StartsWith(Star2Name) && li.Active.Equals(true) && li.Star1Ref.StartsWith(Star1Name))); });
            }
            else if (!string.IsNullOrEmpty(Star2Name) && !string.IsNullOrEmpty(Star1Name))
            {
                return GetAllStars(OrgId, Star2Name);
                //return ListAllStars.FindAll(delegate(CatAllStars li)
                //{ return (li.PccId.Equals(Pccid) && (li.StarName.StartsWith(Star2Name) && li.Active.Equals(true) && li.Star1Ref.StartsWith(Star1Name))); });
            }
            else if (!string.IsNullOrEmpty(Star1Name))
            {
                return GetAllStars(OrgId, Star1Name);
                //return ListAllStars.FindAll(delegate(CatAllStars li)
                //{ return (li.PccId.Equals(Pccid) && li.Active.Equals(true) && (li.StarName.StartsWith(Star1Name) || li.Star1Ref.StartsWith(Star1Name))); });
            }
            else
            {
                return GetAllStars(OrgId, Star2Name);
                //return ListAllStars.FindAll(li => Pccid != null && (Pccid.StartsWith(li.PccId) && li.Active.Equals(true)));

            }

            //{ return ((li.PccId.Equals(Pccid)) && li.StarName.Contains(Star1Name)) || (li.PccId.Equals(Pccid) && li.StarName.Contains(Star2Name)); });
        }

        /// <summary>
        /// Codigo para busqueda de profiles de segundo nivel a un primer nivel en especifico
        /// </summary>
        /// <returns></returns>
        public static List<CatAllStars> GetAll2ndStarDetailed_Profile(string Pccid, string Star1Name, int OrgId)
        {

            List<CatAllStars> listAllStars = new List<CatAllStars>();
            CatAllStarsDAL objGetAllStars = new CatAllStarsDAL();
            try
            {
                try
                {
                    listAllStars = objGetAllStars.GetProfiles2LevelByFirstLevel(OrgId, Star1Name, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);

                    listAllStars = objGetAllStars.GetProfiles2LevelByFirstLevel(OrgId, Star1Name, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch { }

            return listAllStars;
        }


        /// <summary>
        /// Codigo para busqueda de profiles de segundo nivel a un primer nivel en especifico
        /// </summary>
        /// <returns></returns>
        public static List<CatAllStars> GetAll1stStarDetailed_Profile(string Pccid, string Star1Name, int OrgId)
        {
            return GetAllStars(OrgId, Star1Name);
            //return ListAllStars.FindAll(delegate(CatAllStars li)
            //{ return li.PccId.Equals(Pccid) && li.StarName.Equals(Star1Name) && li.Active.Equals(true); });
        }

        public static void GetElements(ref List<CatAllStars> list, int OrgId)
        {
            if (list.Count.Equals(0))
            {
                list = GetAllStars(OrgId, string.Empty);
            }
        }

        public static void GetAllStarsCatalog(int OrgId, string name)
        {
            if (ListAllStars == null)
            {
                ListAllStars = GetAllStars(OrgId, name);
            }
        }


    }
}







