using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation.Reservations.Availability.InterJet.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterJetApiComunicator
    {

        /// <summary>
        /// Sends the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public string SendCommand(string command)
        {
            string responseFromApi = "";
            using (var commandSender = new CommandsAPI())
            {
                responseFromApi = commandSender.SendReceive(command.ToUpper());
            }

            if(responseFromApi.Contains("‡INVLD - TICKET NUMBER IN USE")
                || responseFromApi.Contains("‡INVLD TICKET"))
            {
                string[] array = command.ToUpper().Split('/');
                string a = array[2].Substring(0,2);
                string b = array[2].Substring(2, 8);
                int c = Convert.ToInt32(a) - 1;
                string d = c.ToString() + b;
                string newTkt = string.Empty;
                try
                {
                    newTkt = array[0] + "/" + array[1] + "/" + d + "/" + array[3] + "/" + array[4] + "/" + array[5] + "/" + array[6] + "/" + array[7] + "/" + array[8] + "/" + array[9] + "/" + array[10] + "/" + array[11] + "/" + array[12] + "/" + array[13];
                }
                catch
                {
                    newTkt = array[0] + "/" + array[1] + "/" + d + "/" + array[3] + "/" + array[4] + "/" + array[5] + "/" + array[6] + "/" + array[7] + "/" + array[8] + "/" + array[9] + "/" + array[10] + "/" + array[11];
                }
                using (var commandSender = new CommandsAPI())
                {
                    responseFromApi = commandSender.SendReceive(newTkt);
                }
            }
            return responseFromApi;

        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public void SendMessage(string msg)
        {
            CommandsAPI2.send_MessageToEmulator(msg);
        }

    }
}
