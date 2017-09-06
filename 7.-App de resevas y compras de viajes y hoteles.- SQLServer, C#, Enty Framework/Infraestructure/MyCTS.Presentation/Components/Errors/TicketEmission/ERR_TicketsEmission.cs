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
    public class ERR_TicketsEmission
    {

        private static string answer;
        public static string Answer
        {
            get { return answer; }
            set { answer = value; }
        }

        private static string customusermsg;
        public static string CustomUserMsg
        {
            get { return customusermsg; }
            set { customusermsg = value; }
        }

        private static bool status;
        public static bool Status
        {
            get { return status; }
            set { status = value; }
        }

        private static bool statussendcommand;
        public static bool StatusSendCommand
        {
            get { return statussendcommand; }
            set { statussendcommand = value; }
        }

        private static bool statusshowusercontrol;
        public static bool statusShowUserControl
        {
            get { return statusshowusercontrol; }
            set { statusshowusercontrol = value; }
        }

        private static bool statusok;
        public static bool StatusOk
        {
            get { return statusok; }
            set { statusok = value; }
        }
        public static void err_ticketsEmission(string result)
        {

            Answer = result;
            status = false;
            statussendcommand = false;
            statusshowusercontrol = false;
            int row = 0;
            int col = 0; 

            //1
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.MANDATORY_EDITS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.MANDATORY_EDITS, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //2
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.SIMULTANEOUS_CHANGES_TO_PNR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.SIMULTANEOUS_CHANGES_TO_PNR, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //3
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.PNR_HAS_BEEN_UPDATED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.PNR_HAS_BEEN_UPDATED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //4
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.TKT_PTR_NOT_ASSIGNED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.TKT_PTR_NOT_ASSIGNED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //5
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.END_OR_IGNORE_PNR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.END_OR_IGNORE_PNR, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }


            //6
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.VENDOR_PROCESSING_ERROR_SLASH_CALL, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.VENDOR_PROCESSING_ERROR_SLASH_CALL, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //7
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.EXCEEDS_FBL_LIMIT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.EXCEEDS_FBL_LIMIT, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //8
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.NEED_FOP, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.NEED_FOP, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                //statusshowusercontrol = true;
                row = 0;
                col = 0;
                return;
            }

            //9
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.IATA_NUMBER_NOT_VALID, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.IATA_NUMBER_NOT_VALID, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                //statusshowusercontrol = true;
                row = 0;
                col = 0;
                return;
            }

            //10
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets._ASTERIKS_PAC_VERIFY_CORRECT_NBR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets._ASTERIKS_PAC_VERIFY_CORRECT_NBR, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                statussendcommand = true;
                row = 0;
                col = 0;
                return;
            }

            //11
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.NOT_ENOUGH_STOCK_IN_PNR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.NOT_ENOUGH_STOCK_IN_PNR, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //12
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.TKT_RECORD_DOES_NOT_EXIST, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.TKT_RECORD_DOES_NOT_EXIST, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //13
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.ND_T_FIELD_OR_DELETE_TKT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.ND_T_FIELD_OR_DELETE_TKT, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //14
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.NEED_MORE_PSGR_TYPES_OR_NAMES, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.NEED_MORE_PSGR_TYPES_OR_NAMES, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //15
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.AUX_SVC, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.AUX_SVC, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //16
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.TOO_MANY_PSGR_TYPES, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.TOO_MANY_PSGR_TYPES, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //17
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.CROSSLORAINE_AUTH_CARRIER_INVLD, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.CROSSLORAINE_AUTH_CARRIER_INVLD, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                //statusshowusercontrol = true;
                row = 0;
                col = 0;
                return;
            }

            //18
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.INVALID_COUPON_NUMBER, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.INVALID_COUPON_NUMBER, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //19
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.NO_PSGR_DATA, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.NO_PSGR_DATA, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //20
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.NO_RETAINED_FARE_EXISTS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.NO_RETAINED_FARE_EXISTS, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //21
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.NO_PRICE_RETENTION, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.NO_PRICE_RETENTION, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //22
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.MINI_ITIN_PRINTER_NO_ASSIGNED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.MINI_ITIN_PRINTER_NO_ASSIGNED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //23
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.UNABLE_TO_TICKET, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.UNABLE_TO_TICKET, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //24
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.NO_TKT_REC_EXIST, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.NO_TKT_REC_EXIST, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //25
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.ITEM_NR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.ITEM_NR, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //26
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.CONTINUITY_OF_FLATS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.CONTINUITY_OF_FLATS, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //27
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.ASSIGN_ETR_PRINTER_FIRST, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.ASSIGN_ETR_PRINTER_FIRST, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //28
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.ELECTRONIC_TICKETING_HOST_UNAVAILABLE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.ELECTRONIC_TICKETING_HOST_UNAVAILABLE, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //29
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.INCORRECT_ENTRY_VERIFY_AND_REENTER, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.INCORRECT_ENTRY_VERIFY_AND_REENTER, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //30
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.CHECK_ITIN, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.CHECK_ITIN, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //31
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.CHECK_ITINERARY_SEGMENTS_NOT_VALID, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.CHECK_ITINERARY_SEGMENTS_NOT_VALID, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //32
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.CHECK_ITINERARY_MORE_SEGMENTS_NOT_VALID, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.CHECK_ITINERARY_MORE_SEGMENTS_NOT_VALID, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //33
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.VERIFY_CITY_PAIR_AUTHORIZED_FOR_ET, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.VERIFY_CITY_PAIR_AUTHORIZED_FOR_ET, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //34
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.ETR_RESTRICTED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.ETR_RESTRICTED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //35
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.ELECTRONIC_TICKETING_NOT_ALLOWED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.ELECTRONIC_TICKETING_NOT_ALLOWED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //36
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.INFANT_PSGR_TYPE_NOT_VALID, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.INFANT_PSGR_TYPE_NOT_VALID, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //37
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.MULTIPLE_NAMES_NOT_ALLOWED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.MULTIPLE_NAMES_NOT_ALLOWED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //38
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.MAXIMUM_TWO_PASSENGER_TYPES, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.MAXIMUM_TWO_PASSENGER_TYPES, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }


            //40
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.ALL_PASSENGERS_MUST_BE_TICKETED_TOGETHER, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.ALL_PASSENGERS_MUST_BE_TICKETED_TOGETHER, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //41
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.SEGMENT_SELECT_NOT_ALLOWED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.SEGMENT_SELECT_NOT_ALLOWED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //42
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.MAXIMUM_FOUR_SEGMENTS_EXCEEDED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.MAXIMUM_FOUR_SEGMENTS_EXCEEDED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //43
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.MAXIMUM_SEGMENTS_EXCEED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.MAXIMUM_SEGMENTS_EXCEED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //44
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.ETR_NOT_ALLOWED_WITHIN_ONE_HOUR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.ETR_NOT_ALLOWED_WITHIN_ONE_HOUR, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //45
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.ELECTRONIC_TICKET_MUST_BE_ISSUED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.ELECTRONIC_TICKET_MUST_BE_ISSUED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                //statusshowusercontrol = true;
                row = 0;
                col = 0;
                return;
            }

            //46
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.ENTRY_REQUIRES_PNR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.ENTRY_REQUIRES_PNR, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //47
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.VOID_RESTRICTED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.VOID_RESTRICTED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //48
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.ONE_OR_MORE_COUPONS_UNABLE_TO_VOID, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.ONE_OR_MORE_COUPONS_UNABLE_TO_VOID, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //49
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.CARRIER_REQUIRES_CREDIT_CARD_PAYMENT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.CARRIER_REQUIRES_CREDIT_CARD_PAYMENT, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //50
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.AUTHORIZATION_CODE_REQUIRED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.AUTHORIZATION_CODE_REQUIRED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //51
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.CARDHOLDER_NAME_REQUIRED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.CARDHOLDER_NAME_REQUIRED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //52
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.CARRIER_NOT_ALLOW_MULTIPLE_FORM_PAYMENT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.CARRIER_NOT_ALLOW_MULTIPLE_FORM_PAYMENT, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //53
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.UNABLE_TO_VOID, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.UNABLE_TO_VOID, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //54
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.VOID_ENTRY_BY_PSEUDO_CITY, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.VOID_ENTRY_BY_PSEUDO_CITY, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.PASSENGER_SECURITY_IDENTIFICATION, ref row, ref col);
            if (row != 0 || col != 0)
            {
                //SabreErrorMsg userErrorMessage = "FALTA INGRESAR DATOS DEL SECURE FLIGHT PASSENGER,\n EL BOLETO AUN NO SE HA EMITIDO ,\n   INGRESA INFORMACIÓN FALTANTE Y CIERRA LA RESERVACIÓN, \n POSTERIOR A ESTE PASO PROCEDE NUEVAMENTE CON LA EMISIÓN";
                CustomUserMsg = "FALTA INGRESAR DATOS DEL SECURE FLIGHT PASSENGER,\nEL BOLETO AUN NO SE HA EMITIDO, INGRESA \nINFORMACIÓN FALTANTE Y CIERRA LA RESERVACIÓN,\nPOSTERIOR A ESTE PASO PROCEDE NUEVAMENTE CON LA EMISIÓN";
                Status = true;
                row = 0;
                col = 0;
                return;
            }


            //55
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.UNABLE_TO_PROCESS_ETR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.UNABLE_TO_PROCESS_ETR, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //56
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.CHECK_ENTRY_COMMENCING_WITH, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.CHECK_ENTRY_COMMENCING_WITH, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }
            
            //57
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.ETR_NOT_ALLOWED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.ETR_NOT_ALLOWED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //58
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.VERIFY_NAME_SELECTION, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.VERIFY_NAME_SELECTION, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //59
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.CHECK_ITIN_ADVANCE_BOARDING, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.CHECK_ITIN_ADVANCE_BOARDING, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //60
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.ONE_OR_MORE_SEGMENTS_NOT_VALID, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.ONE_OR_MORE_SEGMENTS_NOT_VALID, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //61
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.CROSSLORAINE_NEED_COMMISSION, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.CROSSLORAINE_NEED_COMMISSION, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                //statusshowusercontrol = true;
                row = 0;
                col = 0;
                return;
            }

            //62
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.CROSSLORAINE_NO_FARES, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.CROSSLORAINE_NO_FARES, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //63
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.UNABLE_TO_PROCESS_ETR_CORRECT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.UNABLE_TO_PROCESS_ETR_CORRECT, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //64
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.FORMAT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.FORMAT, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //65
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.PNR_UPDATED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.PNR_UPDATED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //66
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.EQUIVALENT_AMOUNT_TOO_LARGE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.EQUIVALENT_AMOUNT_TOO_LARGE, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //67
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.ONE_CONFIRMED_AIR_SEGMENT_FOR_ETR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.ONE_CONFIRMED_AIR_SEGMENT_FOR_ETR, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //68
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.PASSENGER_MUST_HAVE_SSR_FOID, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.PASSENGER_MUST_HAVE_SSR_FOID, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //69
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.CARRIER_NOT_ALLOWED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.CARRIER_NOT_ALLOWED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //70
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.NO_REPLY_FROM_SERVER, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.NO_REPLY_FROM_SERVER, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //71
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.NO_REPLY_FROM_SERVER, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.NO_REPLY_FROM_SERVER, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //72
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.INVALID_EXPIRATION_DATE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.INVALID_EXPIRATION_DATE, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //73
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.UPDATE_TKT_RECORD, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.UPDATE_TKT_RECORD, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //74
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.TICKET_HAS_BEEN_ISSUED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.TICKET_HAS_BEEN_ISSUED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //75
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.NO_FARE_FOR_CLASS_USED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.NO_FARE_FOR_CLASS_USED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //76
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.NEED_AIRLINE_PNR_LOCATOR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.NEED_AIRLINE_PNR_LOCATOR, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //77
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.CREDIT_CARD_AUTH_DECLINED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.CREDIT_CARD_AUTH_DECLINED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                //statusshowusercontrol = true;
                row = 0;
                col = 0;
                return;
            }

            //78
            CommandsQik.searchResponse(result, Resources.TicketEmission.ErrorMessagesTickets.INCORRECT_CARD_NUMBER, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ErrorMessagesTickets.INCORRECT_CARD_NUMBER, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                //statusshowusercontrol = true;
                row = 0;
                col = 0;
                return;
            }
 
        }

        public static void ok_ticketsEmission(string result)
        {
            customusermsg = string.Empty;
            Answer = result;
            statusok = false;
            int row = 0;
            int col = 0;

            CommandsQik.searchResponse(result, Resources.TicketEmission.ValitationLabels.INVOICED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                statusok = true;
                return;
            }
            else 
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.TicketEmission.ValitationLabels.INVOICED, 15);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                return;
            }
        }
    }
}
