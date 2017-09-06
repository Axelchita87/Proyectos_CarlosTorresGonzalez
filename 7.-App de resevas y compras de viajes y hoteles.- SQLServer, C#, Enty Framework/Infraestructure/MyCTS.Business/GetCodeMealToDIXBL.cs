using System;
using MyCTS.Entities;
using MyCTS.DataAccess;

namespace MyCTS.Business
{
    public class GetCodeMealToDIXBL
    {
        public static string GetCodeMealToDIX(string codeMeal)
        {
            GetCodeMealToDIXDAL objCodeMeal = new GetCodeMealToDIXDAL();
            string descriptionMeal = string.Empty;
            try
            {
                try
                {
                    descriptionMeal = objCodeMeal.GetCodeMealToDIX(codeMeal, CommonENT.MYCTSDB_CONNECTION);
                }
                catch (Exception ex)
                {
                    new EventsManager.EventsManager(ex, EventsManager.EventsManager.OrigenError.BaseDeDatos);
                    descriptionMeal = objCodeMeal.GetCodeMealToDIX(codeMeal, CommonENT.MYCTSDBBACKUP_CONNECTION);
                }
            }
            catch { }
            return descriptionMeal;

        }
    }
}
