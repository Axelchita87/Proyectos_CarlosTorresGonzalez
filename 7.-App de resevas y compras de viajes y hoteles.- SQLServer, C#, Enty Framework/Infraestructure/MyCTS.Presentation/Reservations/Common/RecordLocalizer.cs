using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Forms.UI;
using MyCTS.Business;
using MyCTS.Entities;

namespace MyCTS.Presentation
{
    public class RecordLocalizer
    {
        public static string PNR = string.Empty;
        private static string valueReceived = string.Empty;
        private static string result = string.Empty;
        private static bool p6 = false;


        public static string GetRecordLocalizer()
        {
            valueReceived = string.Empty;
            p6 = false;

            using (CommandsAPI objCommand = new CommandsAPI())
            {
                if(ucEndReservation.EndReservation)
                    result = objCommand.SendReceive(Resources.Constants.COMMANDS_AST_P6);
                else
                result = objCommand.SendReceive(Resources.Constants.COMMANDS_AST_P6, 0, 0);
            }
            APIResponseP6();
            if (p6)
            {
                CommandsQik.CopyResponse(result, ref valueReceived, 2, 27, 7);
                valueReceived = valueReceived.Trim();
                if (string.IsNullOrEmpty(valueReceived))
                {
                    CommandsQik.CopyResponse(result, ref valueReceived, 3, 27, 7);
                    valueReceived = valueReceived.Trim();
                }
            }

            if (!string.IsNullOrEmpty(valueReceived) && ValidateRegularExpression.ValidatePNR(valueReceived) && valueReceived.Length==6)
            {
                PNR = valueReceived;
            }
            else
            {
                PNR = string.Empty;
            }

            return PNR;
        }

        private static void APIResponseP6()
        {
            int col = 0;
            int row = 0;

            if ((!string.IsNullOrEmpty(result)))
            {
                CommandsQik.searchResponse(result, Resources.ErrorMessages.RECEIVED, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    p6 = true;
                    row = 0;
                    col = 0;
                    return;
                }

            }
        }
    }
}
