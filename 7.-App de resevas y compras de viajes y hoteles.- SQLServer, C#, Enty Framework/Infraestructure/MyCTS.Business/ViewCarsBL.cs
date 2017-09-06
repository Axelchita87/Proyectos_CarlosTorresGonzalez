using System;
using System.Collections.Generic;
using System.Text;
using MyCTS.Entities;
using MyCTS.DataAccess;


namespace MyCTS.Business
{
    public class ViewCarsBL
    {
        public static List<ViewCars> GetCars(string StrToSearch)
        {
            List<ViewCars> CarsList = new List<ViewCars>();
            try
            {
                ViewCarsDAL objCars = new ViewCarsDAL();
                CarsList = objCars.GetCars(StrToSearch);
                
            }
            catch
            { }
            return CarsList;
        }
    }
}
