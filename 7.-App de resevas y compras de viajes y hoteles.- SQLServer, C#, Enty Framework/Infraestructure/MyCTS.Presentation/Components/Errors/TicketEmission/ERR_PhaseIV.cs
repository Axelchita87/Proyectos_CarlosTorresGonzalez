using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using MyCTS.Components;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation
{
    

    public class ERR_PhaseIV
    {
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

        

        public static void err_phaseIVErrors(string result)
        {
            customusermsg = string.Empty;
            status = false;
            int row = 0;
            int col = 0;

            //1
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.UNABLE_PAST_DATE_SEGMENT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.UNABLE_PAST_DATE_SEGMENT, 19);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //2
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.CODE_HX_SEG_STATUS_NOT_ALLOWED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.CODE_HX_SEG_STATUS_NOT_ALLOWED, 19);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //3
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.UNABLE_TO_ISSUE_PARTIAL_CONNECTION_TKT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.UNABLE_TO_ISSUE_PARTIAL_CONNECTION_TKT, 19);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //4
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.NEED_PNR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.NEED_PNR, 19);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //5
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.FORMAT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.FORMAT, 19);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //6
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.XT_IN_TX_BOX, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.XT_IN_TX_BOX, 19);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //7
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.XF, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.XF, 19);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }


            
        }
    }
}
