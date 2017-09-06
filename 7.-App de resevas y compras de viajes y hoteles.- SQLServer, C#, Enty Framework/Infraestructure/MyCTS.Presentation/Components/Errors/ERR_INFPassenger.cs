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
    class ERR_INFPassenger
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


        public static void err_infpassenger(string result)
        {
            Answer = result;
            Status = false;
            CustomUserMsg = string.Empty;

            int row = 0;
            int col = 0;

            CommandsQik.searchResponse(result, Resources.ErrorMessages.CHECK_ITINERARY_SEGMENT_NBR, ref row, ref col);
            if (row != 0 || col != 0)
            {
               SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.CHECK_ITINERARY_SEGMENT_NBR, 6);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.CANNOT_ASSOC_TO_INFANT, ref row, ref col);
            if (row != 0 || col != 0)
            {
               SabreErrorMsg userErrorMessage =SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.CANNOT_ASSOC_TO_INFANT, 6);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.ADULT_NAME_ALREADY_ASSOCIATED, ref row, ref col);
            if (row != 0 || col != 0)
            {
               SabreErrorMsg userErrorMessage =SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.ADULT_NAME_ALREADY_ASSOCIATED, 6);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }



        }
    }
}
