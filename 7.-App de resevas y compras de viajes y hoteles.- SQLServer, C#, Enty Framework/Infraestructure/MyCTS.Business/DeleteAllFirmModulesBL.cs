using MyCTS.DataAccess;
using MyCTS.Entities;

namespace MyCTS.Business
{
    public class DeleteAllFirmModulesBL
    {
       public static bool DeleteTA(string ta)
       {
           bool delete = true;
           DeleteAllFirmModulesDAL objDelete = new DeleteAllFirmModulesDAL();
           try
           {
               try
               {
                   objDelete.DeleteTA(ta, CommonENT.MYCTSDBSECURITY_CONNECTION);
               }
               catch 
               {
                   delete = false;
                   objDelete.DeleteTA(ta, CommonENT.MYCTSDBSECURITYBACKUP_CONNECTION);
               }
           }
           catch 
           {
               delete = false;
           }

           return delete;
       }

       public static bool DeleteIATA(string iata)
       {
           bool delete = true;
           DeleteAllFirmModulesDAL objDelete = new DeleteAllFirmModulesDAL();
           try
           {
               try
               {
                   objDelete.DeleteIATA(iata, CommonENT.MYCTSDBSECURITY_CONNECTION);
               }
               catch
               {
                   delete = false;
                   objDelete.DeleteIATA(iata, CommonENT.MYCTSDBSECURITY_CONNECTION);
               }
           }
           catch
           {
               delete = false;
           }

           return delete;
       }
    }
}
