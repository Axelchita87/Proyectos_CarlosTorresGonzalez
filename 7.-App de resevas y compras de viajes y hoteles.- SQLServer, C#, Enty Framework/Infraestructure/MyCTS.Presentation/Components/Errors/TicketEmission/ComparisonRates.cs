using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using System.Text.RegularExpressions;

namespace MyCTS.Presentation
{
   public class ComparisonRates
    {
        private static string answer;
        public static string Answer
        {
            get { return answer; }
            set { answer = value; }
        }

       private static bool basefare;
       public static bool BaseFare
        {
            get { return basefare; }
            set { basefare = value; }
        }

        



       public static void validation_wpncs(string result)
       {
           Answer = result;
           BaseFare = false;
           int row = 0;
           int col = 0;

           string send = string.Empty;

           send = Resources.TicketEmission.Constants.COMMANDS_WPNCS;
           using (CommandsAPI objCommands = new CommandsAPI())
           {
               objCommands.SendReceive(send);
           }

           CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col);
           if (row != 0 || col != 0)
           {
               BaseFare = true;
               row = 0;
               col = 0;
           }


           if (BaseFare)
           {
               CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.TOTAL, ref row, ref col, 1, 4, 30, 64);
               if (row != 0 || col != 0)
               {
                   string temp_WPNCS_CI = string.Empty;
                   string rate_ConImp_Low_ND = string.Empty;

                   row = row + 1;
                   CommandsQik.CopyResponse(result, ref temp_WPNCS_CI, row, 47, 14);
                   rate_ConImp_Low_ND = (temp_WPNCS_CI.Substring(0, 4));//verificar que quite MXN

                   col = 0;
                   row = 0;
               }


               CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.EQUIV_AMT, ref row, ref col, 1, 4, 30, 64);
               if (row != 0 || col != 0)
               {
                   string temp_WPNCS_SI = string.Empty;
                   string rate_SinImp_Low_ND = string.Empty;

                   row = row + 1;
                   CommandsQik.CopyResponse(result, ref temp_WPNCS_SI, row, 19, 14);
                   rate_SinImp_Low_ND = (temp_WPNCS_SI.Substring(0, 4));//verificar que quite MXN

                   col = 0;
                   row = 0;
                   BaseFare = false;
               }

               if (BaseFare)
               {
                   CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.BASE_FARE, ref row, ref col, 1, 4, 1, 20);
                   if (row != 0 || col != 0)
                   {
                       string temp_WPNCS_SI = string.Empty;
                       string rate_SinImp_Low_ND = string.Empty;

                       row = row + 1;
                       CommandsQik.CopyResponse(result, ref temp_WPNCS_SI, row, 5, 14);
                       rate_SinImp_Low_ND = (temp_WPNCS_SI.Substring(0, 4));//verificar que quite MXN

                       col = 0;
                       row = 0;
                   }
               }

               CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.ADT, ref row, ref col, 5, 7, 1, 4);
               if (row != 0 || col != 0)
               {
                   string book_fare_Low_ND = string.Empty;
                   row = row + 1;
                   CommandsQik.CopyResponse(result, ref book_fare_Low_ND, row, 9, 30);
                   col = 0;
                   row = 0;

               }


           }

           else
           {
               int hours;
               string hourscad;
               string hour;
               string day;
               string month;
               DateTime time =DateTime.Now;
               hours=time.Hour;
               hourscad = Convert.ToString(hours);
               hour = Regex.Replace(hourscad, @"[^\w\.@¥-]", "");

               day=time.ToString("dd", new System.Globalization.CultureInfo("en-US")).ToUpper();
               month=time.ToString("MMM", new System.Globalization.CultureInfo("en-US")).ToUpper();

               send = Resources.TicketEmission.Constants.COMMANDS_5H_NO_DETERMINO_TARIFA_MAS_BAJA_NO_DISPONIBLE_WPNCS_AST +
                   hours+Resources.TicketEmission.Constants.AST+ day+ Resources.TicketEmission.Constants.SLASH+
                   month;

                   
               using (CommandsAPI objCommands = new CommandsAPI())
               {
                   objCommands.SendReceive(send);
               }
           }



       }

    }
}
