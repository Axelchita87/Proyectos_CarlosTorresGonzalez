using System;
using System.Collections.Generic;
using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class CatRolesBL
    {
        public static List<ListItem> GetCatRoles()
        {
            List<ListItem> listCatRoles = new List<ListItem>();
            CatRolesDAL objCatRoles = new CatRolesDAL();
            try
            {
                try
                {
                    listCatRoles = objCatRoles.GetCatRoles(CommonENT.MYCTSDBSECURITY_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    listCatRoles = objCatRoles.GetCatRoles(CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
                }
            }
            catch
            { }
            return listCatRoles;
        }
    }
}