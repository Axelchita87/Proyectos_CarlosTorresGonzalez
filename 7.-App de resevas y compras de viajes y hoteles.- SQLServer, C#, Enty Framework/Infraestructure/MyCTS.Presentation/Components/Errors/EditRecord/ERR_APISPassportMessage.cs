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
    class ERR_APISPassportMessage
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

        private static bool othermask;
        public static bool OtherMask
        {
            get { return othermask; }
            set { othermask = value; }
        }

        private static string customusermsg;
        public static string CustomUserMsg
        {
            get { return customusermsg; }
            set { customusermsg = value; }
        }


        public static void err_apispassportmessage(string result)
        {
            Answer = result;
            Status = false;
            OtherMask = false;
            int row = 0;
            int col = 0;



            CommandsQik.searchResponse(result, Resources.ErrorMessages.SEGMENT_NUMBER_NOT_VALID, ref row, ref col);
            if (row != 0 || col != 0)
            {
               SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.SEGMENT_NUMBER_NOT_VALID, 21);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.INVALID_SSR_CODE, ref row, ref col);
            if (row != 0 || col != 0)
            {
               SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.INVALID_SSR_CODE, 21);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                OtherMask = true;
                row = 0;
                col = 0;
                return;
            }
        }

    }
}
