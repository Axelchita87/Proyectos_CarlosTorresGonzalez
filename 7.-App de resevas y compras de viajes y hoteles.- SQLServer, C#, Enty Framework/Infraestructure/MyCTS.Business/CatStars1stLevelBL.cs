using System;
using System.Collections.Generic;
using System.Linq;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CatStars1stLevelBL
    {
        public static List<CatStars1stLevel> ListStars1stLevel = new List<CatStars1stLevel>();
        public static List<ListItem> ListTemp = new List<ListItem>();

        public static List<CatStars1stLevel> GetStars1stLevel(int OrgId)
        {
            List<CatStars1stLevel> listStars1 = new List<CatStars1stLevel>();
            CatStars1stLevelDAL objGetStars1 = new CatStars1stLevelDAL();
            try
            {
                try
                {
                    listStars1 = objGetStars1.GetStars1stCatalog(OrgId, CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listStars1 = objGetStars1.GetStars1stCatalog(OrgId, CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch (Exception)
            { }

            return listStars1;
        }


        /// <summary>
        /// Codigo para predictivo
        /// </summary>
        /// <returns></returns>
        public static List<ListItem> GetStars1stLevel_Predictive(string StrToSearch, int OrgId)
        {
            GetElements(ref ListStars1stLevel, OrgId);

            var newList = new List<ListItem>();

            foreach (var listItem in ListTemp)
            {

                if (newList.Any())
                {
                    if (!newList.Any(e => e.Value.Equals(listItem.Value)))
                    {
                        newList.Add(listItem);
                    }
                }
                else
                {
                    newList.Add(listItem);
                }

            }

            return newList.FindAll(li => (li.Text.StartsWith(StrToSearch)));
        }

        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="OrgId">The org id.</param>
        public static void GetElements(ref List<CatStars1stLevel> list, int OrgId)
        {
            if (list == null) return;
            ListTemp.Clear();
            ListStars1stLevel = GetStars1stLevel(OrgId);
            foreach (ListItem item in ListStars1stLevel.Select(star => new ListItem
                                                                           {
                                                                               Value = star.Star1Name,
                                                                               Text = string.Concat(star.Star1Name, " ", star.Pccid),
                                                                               Text2 = star.Pccid
                                                                           }))
            {
                ListTemp.Add(item);
            }
        }

    }
}



