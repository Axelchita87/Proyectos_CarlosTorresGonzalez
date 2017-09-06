using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    class ERR_AccountingInformation
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

        private static string total;
        public static string Total
        {
            get { return total; }
            set { total = value; }
        }


        public static void err_accountinginformation(string result)
        {
            Answer = result;
            Status = false;
            int row = 0;
            int col = 0;

            CommandsQik.searchResponse(result, Resources.ErrorMessages.TOTAL, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.TOTAL, 14);
                total = string.Empty;
                CommandsQik.CopyResponse(result, ref total, 2, 47,14);
                Status = true;
                row = 0;
                col = 0;
                return;
            }
        }

    }
}
