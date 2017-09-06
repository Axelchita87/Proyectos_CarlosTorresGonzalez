using System;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using MyCTS.Components;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;
using System.Text.RegularExpressions;

namespace MyCTS.Presentation
{
    class ERR_MnuSee
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

        private static string customusermsg;
        public static string CustomUserMsg
        {
            get { return customusermsg; }
            set { customusermsg = value; }
        }

        private static string customusermsg2;
        public static string CustomUserMsg2
        {
            get { return customusermsg2; }
            set { customusermsg2 = value; }
        }

        public static void err_mnuSee(string result)
        {
            Answer = result;
            Status = false;
            int row = 0;
            int col = 0;

            CommandsQik.searchResponse(result, Resources.ErrorMessages.CROSS_NO_PSGR_DATA, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.CROSS_NO_PSGR_DATA, 12);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                CustomUserMsg2 = "NO EXISTEN MENSAJES PARA LA AEROLINEA";
                Status = true;
                row = 0;
                col = 0;
            }


            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_PSGR_DATA, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.CROSS_NO_PSGR_DATA, 12);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
            }
           

        }
    }
}
