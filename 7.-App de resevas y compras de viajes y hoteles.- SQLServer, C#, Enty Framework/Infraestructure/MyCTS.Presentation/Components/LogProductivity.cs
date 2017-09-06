using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;
using MyCTS.Business;
using MyCTS.Entities;
using System.IO;

namespace MyCTS.Presentation
{

    public class LogProductivity
    {
        
        /// <summary>
        /// Descripción: Controlar la producción de los usuarios
        /// Creación:    29 - Oct 09, Modificación: Eduardo
        /// Cambio:      Modificar a un Log temporal  Solicito: Pablo
        /// Autor:       Jessica Gutierrez
        /// </summary>

        /// <summary>
        /// Guarda los comandos en la base de datos
        /// </summary>
        /// <param name="command">Commando que se envía</param>
        /// <param name="status">Estatus de emisión de boleto</param>
        public static void AddLogProductivity(string command, int status)
        {
            if (command.Equals("I") | command.StartsWith("IC") | command.Equals("DIX"))
            {
                Common.SetValueCurrentPNR(string.Empty);
            }
            else
            {
                if (command.StartsWith("¤A", StringComparison.InvariantCultureIgnoreCase))
                    Common.SetCurrentArea(Common.Area.Area_A);
                else if (command.StartsWith("¤B", StringComparison.InvariantCultureIgnoreCase))
                    Common.SetCurrentArea(Common.Area.Area_B);
                else if (command.StartsWith("¤C", StringComparison.InvariantCultureIgnoreCase))
                    Common.SetCurrentArea(Common.Area.Area_C);
                else if (command.StartsWith("¤D", StringComparison.InvariantCultureIgnoreCase))
                    Common.SetCurrentArea(Common.Area.Area_D);
                else if (command.StartsWith("¤E", StringComparison.InvariantCultureIgnoreCase))
                    Common.SetCurrentArea(Common.Area.Area_E);
                else if (command.StartsWith("¤F", StringComparison.InvariantCultureIgnoreCase))
                    Common.SetCurrentArea(Common.Area.Area_F);
            }

            SaveLogTransaction(Login.Agent, command);
        }
        private static int counter = 0;
        public static void SaveLogTransaction(string Agent, string Command)
        {
            Command = Command.Trim();
            if (Command.Length > 1248)
                Command = Command.Substring(0, 1248);

            string fName = GlobalConstants.CurrentFileName;
            int numCommandsToInsert = Int32.Parse(Parameters.NumCommandsToInsertLogs);
            //int numCommandsToInsert = 10;
            
            string sql = string.Format("INSERT INTO [CommandsTransaction]([Agent],[Command], [RecLoc], [DateCreated],[AreaGUID]) VALUES ('{0}' ,'{1}','{2}','{3}','{4}')",
               Login.Agent, Command, Common.CurrentPNR, Common.RealDateTime.ToString("yyyy-dd-MM HH:mm:ss"), Common.CurrentArea);

            
            ////Verifica si se está realizand el proceso manual
            ////para tener en línea los comandos ingresados
            //if (Common.IsManualCommandTransactions)
            //{
            //    Common.CurrentCommandsSQL.Add(sql);
            //    return;
            //}

            string fileSource = GlobalConstants.TEMP_FILES + "\\" + fName;
            try
            {
                using (TextWriter tw = new StreamWriter(fileSource, true))
                {
                    tw.WriteLine(sql);
                }
            }
            catch { return; }
            

            counter++;
            if (counter >= numCommandsToInsert)
            {
                GlobalConstants.CurrentFileName = string.Empty;
                File.Move(fileSource, GlobalConstants.QUEUE_FILES + "\\" + fName);
                counter = 0;
            }

        }


        public static void LogTransaction(string Agent, string Command)
        {
            CatTransactionBL.AddCommandsTransaction(Login.Agent, Common.CurrentPNR, Command,DateTime.Now, Common.CurrentArea);
        } 

    }
}