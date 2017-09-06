using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation.Reservations.Availability.Volaris.CommandsBuilder
{
    public class VolarisAPICommunicator
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
                if (!string.IsNullOrEmpty(command))
                {
                    responseFromApi = commandSender.SendReceive(command.ToUpper());
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
