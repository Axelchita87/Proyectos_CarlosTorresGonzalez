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
    public class DeleteAccountLine
    {
        private static string answer;
        public static string Answer
        {
            get { return answer; }
            set { answer = value; }
        }

        private static bool status;
        public static bool Status
        {
            get { return status; }
            set { status = value; }
        }



        public static void validation_deleteaccountline(string result)
        {
            Answer = result;
            status = false;
            int row = 0;
            int col = 0;

            string send = string.Empty;

            send = Resources.TicketEmission.Constants.COMMANDS_AST_PAC;
            using (CommandsAPI objCommands = new CommandsAPI())
            {
                objCommands.SendReceive(send);
            }



            CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.ACCOUNTING_DATA, ref row, ref col);
            if (row != 0 || col != 0)
            {
                Status = true;
                row = 0;
                col = 0;
                return;
            }


            //if (Status)
            //{
            //    Loader.AddToPanel(Loader.Zone.Middle, this, Resources.TicketEmission.Constants.UC_DELETEACCOUNTLINE);
            //}

        }

    }
}
