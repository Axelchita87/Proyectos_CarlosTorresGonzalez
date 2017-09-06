using System;
using System.Collections.Generic;
using System.Linq;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class CatStars2ndLevelBL
    {
        public static List<ListItem> ListStars2ndLevel = new List<ListItem>();
        public static List<ListItem> ListTemp = new List<ListItem>();

        public static List<CatStars2ndLevel> GetStars2ndLevel()
        {
            List<CatStars2ndLevel> listStars2 = new List<CatStars2ndLevel>();
            CatStars2ndLevelDAL objGetStars2 = new CatStars2ndLevelDAL();
            try
            {
                try
                {
                    listStars2 = objGetStars2.GetStars2ndCatalog(CommonENT.MYCTSDBPROFILES_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listStars2 = objGetStars2.GetStars2ndCatalog(CommonENT.MYCTSDBPROFILESBACKUP_CONNECTION);
                }
            }
            catch(Exception exe)
            {
                var ee = exe;
            }
            if (listStars2.Any())
            {
                if (ListStars2ndLevel.Any())
                {
                    ListStars2ndLevel.Clear();
                }

                foreach (var starSecondLevel in listStars2)
                {

                    ListStars2ndLevel.Add(new ListItem
                                               {
                                                   Text = starSecondLevel.Star2Name,
                                                   Value = starSecondLevel.Star2Name,
                                                   Text2 = starSecondLevel.Pccid,
                                                   Text3 = starSecondLevel.Star1id
                                               });

                }

            }
            return listStars2;
        }

        /// <summary>
        /// Codigo para predictivo
        /// </summary>
        /// <returns></returns>
        public static List<ListItem> GetStars2ndLevel_Predictive(string StrToSearch, string PCC, string Star1id)
        {
            GetElements(ref ListStars2ndLevel, PCC, Star1id);

            var newListItem = new List<ListItem>();
            foreach (var item in ListTemp)
            {
                if (newListItem.Any())
                {
                    bool IsInList = newListItem.Any(e => e.Value.Equals(item.Value));
                    if (!IsInList)
                    {
                        newListItem.Add(item);
                    }


                }
                else
                {
                    newListItem.Add(item);
                }

            }


            return newListItem.FindAll(delegate(ListItem li)
            { return (li.Text.StartsWith(StrToSearch)); });
        }

        /// <summary>
        /// Codigo para motor de busqueda
        /// </summary>
        /// <returns></returns>
        public static List<ListItem> GetStars2ndLevel_Profiles(string StrToSearch, string PCC, string Star1id)
        {
            GetElements(ref ListStars2ndLevel, PCC, Star1id);


            return ListTemp.FindAll(delegate(ListItem li)
                                        {
                                            return (li.Text.StartsWith(StrToSearch));
                                        }


            );
        }


        public static void GetElements(ref List<ListItem> list, string PCC, string Star1id)
        {
            if (list != null)
            {
                ListTemp.Clear();
                foreach (ListItem item in ListStars2ndLevel)
                {
                    if (item.Text3.Equals(Star1id))
                    {
                        ListTemp.Add(item);
                    }
                }
            }
        }

    }
}

