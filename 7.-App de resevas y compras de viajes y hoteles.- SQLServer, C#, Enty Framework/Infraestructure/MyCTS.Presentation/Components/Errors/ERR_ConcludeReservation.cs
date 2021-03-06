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
    class ERR_ConcludeReservation
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

        private static bool requestPending;
        public static bool RequestPending
        {
            get { return requestPending; }
            set { requestPending = value; }
        }

        private static bool showmask;
        public static bool Showmask
        {
            get { return showmask; }
            set { showmask = value; }
        }

        private static bool othermask;
        public static bool Otherwmask
        {
            get { return othermask; }
            set { othermask = value; }
        }


        private static bool command;
        public static bool Command
        {
            get { return command; }
            set { command = value; }
        }

        private static bool segment;
        public static bool Segment
        {
            get { return segment; }
            set { segment = value; }
        }

        private static bool employesnumber;
        public static bool EmployesNumber
        {
            get { return employesnumber; }
            set { employesnumber = value; }
        }

        private static bool remarks;
        public static bool Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }


        private static bool statusdknull;
        public static bool StatusDKNull
        {
            get { return statusdknull; }
            set { statusdknull = value; }
        }
   

        private static string customusermsg;
        public static string CustomUserMsg
        {
            get { return customusermsg; }
            set { customusermsg = value; }
        }

        private static string smx;
        public static string SMX
        {
            get { return smx; }
            set { smx = value; }
        }

        private static bool customer;
        public static bool Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        private static bool pq;
        public static bool PQ
        {
            get { return pq; }
            set { pq = value; }
        }

        private static string customernumber;
        public static string CustomerNumber
        {
            get { return customernumber; }
            set { customernumber = value; }
        }


        private static bool p6;
        public static bool P6
        {
            get { return p6; }
            set { p6 = value; }
        }


        private static bool allowclosedrecord;
        public static bool allowClosedRecord
        {
            get { return allowclosedrecord; }
            set { allowclosedrecord = value; }
        }

        private static bool commandf;
        public static bool CommandF
        {
            get { return commandf; }
            set { commandf = value; }
        }


        private static bool adreess;
        public static bool Adreess
        {
            get { return adreess; }
            set { adreess = value; }
        }

        private static bool secureflight;
        public static bool SecureFlight
        {
            get { return secureflight; }
            set { secureflight = value; }
        }

        private static bool placedOn;
        public static bool PlacedOn
        {
            get { return placedOn; }
            set { placedOn = value; }
        }

        public static bool ResendER { get; set; }

        public static bool CCError { get; set; }

        public static bool Received { get; set; }

        public static void err_concludereservation(string result)
        {

            Received = false;
            Answer = result;
            Status = false;
            Showmask = false;
            Otherwmask = false;
            Command = false;
            Segment = false;
            EmployesNumber = false;
            Remarks = false;
            Customer = false;
            StatusDKNull = false;
            PQ = false;
            allowClosedRecord = false;
            CommandF = false;
            P6 = false;
            adreess = false;
            secureflight = false;
            requestPending = false;
            PlacedOn = false;
            ResendER = false;
            CCError = false;
            int row = 0;
            int col = 0;

            CommandsQik.searchResponse(result, Resources.ErrorMessages.REQUEST_PENDING, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.REQUEST_PENDING, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                requestPending = true;
                row = 0;
                col = 0;

                
                CommandsQik.searchResponse(result, "DIRECT CONNECT RESPONSE RECEIVED", ref row, ref col);
                if (row != 0 || col != 0 && requestPending)
                {
                    Received = false;
                    row = 0;
                    col = 0;
                    return;
                }

               
                CommandsQik.searchResponse(result, "CREDIT CARD INFORMATION IS NOT VALID", ref row, ref col);
                if (row != 0 || col != 0 && requestPending)
                {
                    CCError = true;
                    row = 0;
                    col = 0;
                    return;
                }
                else
                {
                    return;
                }
            }

            CommandsQik.searchResponse(result, "PSGR SECURITY DATA REQUIRED", ref row, ref col);
            if (row != 0 || col != 0)
            {
                ResendER = true;
                row = 0;
                col = 0;
                return;
            }
           

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_PSGR_DATA, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_PSGR_DATA, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                statusdknull = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NEED_CUSTOMER_NUMBER, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NEED_CUSTOMER_NUMBER, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                StatusDKNull = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.SIMULTANEOUS_CHANGES_TO_PNR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.SIMULTANEOUS_CHANGES_TO_PNR, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.CUSTOMER_NUMBER, ref row, ref col);
            if (row != 0 || col != 0)
            {
                customernumber = string.Empty;
                CommandsQik.CopyResponse(result, ref customernumber, row, 19, 6);
                Customer = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.SEGMENTO_PROTECCION, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.SEGMENTO_PROTECCION, 9);
                Segment = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.U99_CC, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.U99_CC, 9);
                EmployesNumber = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.SMX, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.SMX, 9);
                smx = string.Empty;
                CommandsQik.CopyResponse(result, ref smx, row, 1, 3);
                Remarks = true;
                smx = smx.Trim();
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.FF_MILEAGE_AGREEMENT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.FF_MILEAGE_AGREEMENT, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                allowclosedrecord = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.UNABLE_TO_PROCESS_NAMES, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.UNABLE_TO_PROCESS_NAMES, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.VERIFY_SPECIAL_MEALS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.VERIFY_SPECIAL_MEALS, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.INVLD_ITIN, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.INVLD_ITIN, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.UNABLE_TO_END_TRANSACTION, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.UNABLE_TO_END_TRANSACTION, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_PQ_RECORD_SUMMARY, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_PQ_RECORD_SUMMARY, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.PQ_REQUIRED_BEFORE_END, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.PQ_REQUIRED_BEFORE_END, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.IM_AND_CANCEL_UNABLE_SEGMENTS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.IM_AND_CANCEL_UNABLE_SEGMENTS, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.SEGMENTS_NOT_IN_DATE_ORDER, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.SEGMENTS_NOT_IN_DATE_ORDER, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.AIRCRAFT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.VERIFY_ORDER_OF_ITINERARY, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                allowclosedrecord = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.ITINERARY_CHANGE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.ITINERARY_CHANGE, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.VERIFY_ORDER_OF_ITINERARY, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.VERIFY_ORDER_OF_ITINERARY, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                allowclosedrecord = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.FLT_CHK_DATE_CONTINUITY, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.FLT_CHK_DATE_CONTINUITY, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                allowclosedrecord = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.MIN_CONNX_TIME_SEG, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.MIN_CONNX_TIME_SEG, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                allowclosedrecord = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.ITINERARY_REQUIRED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.ITINERARY_REQUIRED, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_PNR_PRESENT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_PNR_PRESENT, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_CHANGES_MADE_TO_PNR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_CHANGES_MADE_TO_PNR, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }


            CommandsQik.searchResponse(result, Resources.ErrorMessages.NEED_NAME_IN_PNR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NEED_NAME_IN_PNR, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NEED_PHONE_FIELD, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NEED_PHONE_FIELD, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NEED_TICKETING_TIMELIMIT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NEED_TICKETING_TIMELIMIT, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Showmask = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.INCORRECT_TIME_LIMIT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.INCORRECT_TIME_LIMIT, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Showmask = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NEED_RECEIVED_FROM_FIELD, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NEED_RECEIVED_FROM_FIELD, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Otherwmask = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.FVR_INGRESE_SEGMENTO_PROT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.FVR_INGRESE_SEGMENTO_PROT, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.EMAIL_ADDRESS_NOT_PRESENT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.EMAIL_ADDRESS_NOT_PRESENT, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NEED_ADDRESS_USE_W, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NEED_ADDRESS_USE_W, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Command = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NEED_FIVE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NEED_FIVE, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.TICKET_TIMELIMIT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.TICKET_TIMELIMIT, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Showmask = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.CORRECT_NBR_OF_ACCTG_LINES, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.CORRECT_NBR_OF_ACCTG_LINES, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.CHECK_ACCOUNTING_DATA, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.CHECK_ACCOUNTING_DATA, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.FONE_ITEM, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.FONE_ITEM, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NUMBER_OF_NAMES_NOT_EQUAL, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NUMBER_OF_NAMES_NOT_EQUAL, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.INVALID_CREDIT_CARD_INFO, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.INVALID_CREDIT_CARD_INFO, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.SUBJECT_TO_CANCELLATION, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.SUBJECT_TO_CANCELLATION, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }


            CommandsQik.searchResponse(result, Resources.ErrorMessages.CARDHOLDER_NAME_REQUIRED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.CARDHOLDER_NAME_REQUIRED, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.SUBJECT_TO_CANCELLATION_NONREFUNDABLE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.SUBJECT_TO_CANCELLATION_NONREFUNDABLE, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.SUBJECT_TO_CANCELLATION_PENALTY_APPLIES, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.SUBJECT_TO_CANCELLATION_PENALTY_APPLIES, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.CREDIT_CARD_WILL_BE_DEBITED_PENALTY, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.CREDIT_CARD_WILL_BE_DEBITED_PENALTY, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.CREDIT_CARD_WILL_BE_DEBITED_TICKET, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.CREDIT_CARD_WILL_BE_DEBITED_TICKET, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }


            CommandsQik.searchResponse(result, Resources.ErrorMessages.MANUALLY_LINK_NAMES_CORRECT_PQ, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.MANUALLY_LINK_NAMES_CORRECT_PQ, 9);
                PQ = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NEED_TICKETING_TIMELIMIT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NEED_TICKETING_TIMELIMIT, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.INGRESA_DATOS_PARA_FACTURAR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                adreess = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.MANDATORY_EDITS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.MANDATORY_EDITS, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.PREVIOUS_ENTRY_ACTIVE_PLEASE_WAIT_FOR_RESPONSE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.PREVIOUS_ENTRY_ACTIVE_PLEASE_WAIT_FOR_RESPONSE, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                p6 = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.END_TRANSACTION_NOT_ALLOWEDN_TYPE_F, ref row, ref col);
            if (row != 0 || col != 0)
            {
                CommandF = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.UNABLE_E_TICKET_NOT_ISSUED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.UNABLE_E_TICKET_NOT_ISSUED, 9);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.FLIGHTS_REQUIRE_DOCS_FOR_PASSENGERS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SecureFlight = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, "PLACED ON", ref row, ref col);
            if (row != 0 || col != 0)
            {
                PlacedOn = true;
                row = 0;
                col = 0;
                return;
            }

            
            
        }
    }
}
