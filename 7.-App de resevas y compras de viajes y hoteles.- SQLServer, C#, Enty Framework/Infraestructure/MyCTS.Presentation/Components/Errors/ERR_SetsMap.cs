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
    class ERR_SetsMap
    {
        private static string answer;
        public static string Answer
        {
            get { return answer; }
            set { answer = value; }
        }

        private static bool refused;
        public static bool Refused
        {
            get { return refused; }
            set { refused = value; }
        }

        private static bool remote;
        public static bool Remote
        {
            get { return remote; }
            set { remote = value; }
        }


        private static string customusermsg;
        public static string CustomUserMsg
        {
            get { return customusermsg; }
            set { customusermsg = value; }
        }


        public static void err_errsetsmap(string result)
        {
            Answer = result;
            Refused = false;
            Remote = false;
            int row = 0;
            int col = 0;


            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_PSGR_DATA, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_PSGR_DATA, 7);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;

                Refused = true;
                row = 0;
                col = 0;
                return;
            }



            CommandsQik.searchResponse(result, Resources.ErrorMessages.CROSS_ND_NAMES, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.CROSS_ND_NAMES, 7);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;

                Refused = true;
                row = 0;
                col = 0;
                return;
            }



            CommandsQik.searchResponse(result, Resources.ErrorMessages.INV_FLT_SEG, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.INV_FLT_SEG, 7);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;  

                Refused = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_ADVANCED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_ADVANCED, 7);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;

                Refused = true;
                row = 0;
                col = 0;
                return;
            }


            CommandsQik.searchResponse(result, Resources.ErrorMessages.HOST_NOT_RESPONDING, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.HOST_NOT_RESPONDING, 7);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;

                Refused = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.SEAT_BOARDING_PASS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.SEAT_BOARDING_PASS, 7);
                Remote = true;
                row = 0;
                col = 0;
                return;
            }

           

           
        }

    }
}
