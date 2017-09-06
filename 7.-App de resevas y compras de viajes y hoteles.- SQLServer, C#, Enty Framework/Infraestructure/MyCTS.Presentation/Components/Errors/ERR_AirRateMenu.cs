using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Components;
using MyCTS.Entities;
using MyCTS.Business;
using MyCTS.Presentation.Components;


namespace MyCTS.Presentation
{
    class ERR_AirRateMenu
    {
        /// <summary>
        /// Descripción: Clase que valida que la respuesta proporcionada por mySabre
        ///              en el menu de reservaciones sea erronea
        /// Creación:    Diciembre 08 -Marzo 09, Modificación: *
        /// Cambio:      *  Solicito:*
        /// Autor:       Marcos Q. Ramírez
        /// </summary>
        /// 

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


        /// <summary>
        /// Validación de posibles errores en la respuesta de mySabre
        /// </summary>
        /// <param name="result">Respuesta de mySabre</param>
        public static void err_AirRateMenu(string result)
        {
            Answer = result;
            CustomUserMsg = string.Empty;
            Status = false;
            int row = 0;
            int col = 0;

            //al evaluar la respuesta del comando WPRQ de la mascarilla de cotizacion aera se recibe una cadena 
            //que no coincide con la mostrada en MySabre por lo tanto entra a este error.
            //CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_NAMES, ref row, ref col);
            //if (row == 1 || col != 0)
            //{
            //    row = 0;
            //    col = 0;
            //    CommandsQik.searchResponse(result, Resources.Constants.E_TICKET, ref row, ref col);
            //    if (row != 0 || col != 0)
            //    {
            //        return;
            //    }
            //    else if (row == 0)
            //    {
            //        SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_NAMES, 3);
            //        CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
            //        Status = true;
            //        row = 0;
            //        col = 0;
            //        return;
            //    }
            //}

            CommandsQik.searchResponse(result, Resources.ErrorMessages.INVALID_FLIGHT_NUMBER, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.INVALID_FLIGHT_NUMBER, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_ITINERARY, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_ITINERARY, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.INVALID_HOST, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.INVALID_HOST, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.INVALID_FLT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.INVALID_FLT, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.SEG_NR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.SEG_NR, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.TIME, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.TIME, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.FLT_CHK_DATE_CONTINUITY, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.FLT_CHK_DATE_CONTINUITY, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.AVAIL_EXPIRED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.AVAIL_EXPIRED, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.SERVICE_NOT_FOUND, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.SERVICE_NOT_FOUND, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.REQUIRES_PAYMENT_WITH_BOOKING, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.REQUIRES_PAYMENT_WITH_BOOKING, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.CARRIER_CODE_REQUIRED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.CARRIER_CODE_REQUIRED, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.CK_ACTION_STATUS_CODE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.CK_ACTION_STATUS_CODE, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.SEGS_SOLD_ORDER, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.SEGS_SOLD_ORDER, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            //CommandsQik.searchResponse(result, Resources.ErrorMessages.RESPONSE, ref row, ref col);
            //if (row != 0 || col != 0)
            //{
            //    SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.RESPONSE, 3);
            //    CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
            //    Status = true;
            //    row = 0;
            //    col = 0;
            //    return;
            //}

            CommandsQik.searchResponse(result, Resources.ErrorMessages.FORMAT_UNEQUAL_NAMES, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.FORMAT_UNEQUAL_NAMES, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.FORMAT_CHECK_SEGMENT_NUMBER, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.FORMAT_CHECK_SEGMENT_NUMBER, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.FORMAT_NEED_PSGR_TYPES_SELECT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.FORMAT_NEED_PSGR_TYPES_SELECT, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.FORMAT_USE_SEGMENT_SELECT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.FORMAT_USE_SEGMENT_SELECT, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.CURRENCY, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.CURRENCY, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.MAXIMUM_6_SEGMENTS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.MAXIMUM_6_SEGMENTS, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.TKT_DESIGNATOR_NOT_FOUND, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.TKT_DESIGNATOR_NOT_FOUND, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.TKT_DES_REQUIRES_FARE_BASIS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.TKT_DES_REQUIRES_FARE_BASIS, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.FARE_BASIS_NOT_FOUND, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.FARE_BASIS_NOT_FOUND, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.TKT_DES_INVALID_FOR_CARRIER, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.TKT_DES_INVALID_FOR_CARRIER, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_FARE_CLASS_USED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_FARE_CLASS_USED, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.INVALID_FARE_BASIS_TKT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.INVALID_FARE_BASIS_TKT, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.TKT_DES_FAILED_RULES_CHECK, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.TKT_DES_FAILED_RULES_CHECK, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.FARE_BASIS_NOT_AVAILABLE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.FARE_BASIS_NOT_AVAILABLE, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_COMBINABLE_FARES_CLASS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_COMBINABLE_FARES_CLASS, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.AUX_SVC, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.AUX_SVC, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_TKT_REC_EXISTS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_TKT_REC_EXISTS, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_PSGR_DATA, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_PSGR_DATA, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_PREVIOUS_WPNI_ENTRY, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_PREVIOUS_WPNI_ENTRY, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_RETAINED_FARE_EXISTS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_RETAINED_FARE_EXISTS, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.CHECK_SEGMENT_CONTINUITY, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.CHECK_SEGMENT_CONTINUITY, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.CHK_DATE_TIME_CONTINUITY, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.CHK_DATE_TIME_CONTINUITY, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.WITH_FARE_BASIS_CODE_AFTER_Q, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.WITH_FARE_BASIS_CODE_AFTER_Q, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_DIRECT_NONSTOPS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_DIRECT_NONSTOPS, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.ALL_RECORDS_DELETED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.ALL_RECORDS_DELETED, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NEED_COMMISSION_DOLLAR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NEED_COMMISSION_DOLLAR, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_APPL_FARE_SPECIFIED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_APPL_FARE_SPECIFIED, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.FLT_CHK_DATE_CONTINUITY, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.FLT_CHK_DATE_CONTINUITY, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.INVALID_SEG_STATUS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.INVALID_SEG_STATUS, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.BARGAIN_FINDER_PLUS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.BARGAIN_FINDER_PLUS, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.UTP_VERIFY_NUMBER_PARTY, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.UTP_VERIFY_NUMBER_PARTY, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NEED_EPR_KEYWORD_PVTDIS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NEED_EPR_KEYWORD_PVTDIS, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.UNABLE_TO_CALCULATE_RATE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.UNABLE_TO_CALCULATE_RATE, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.UNABLE_PRICE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.UNABLE_PRICE, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NEED_COMMISSION, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NEED_COMMISSION, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.CURRENCY_CODE_DECIMAL_ERROR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.CURRENCY_CODE_DECIMAL_ERROR, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.INVALID_CURRENCY_CODE_ENTRY, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.INVALID_CURRENCY_CODE_ENTRY, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.CODE_UC_SEG_STATUS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.CODE_UC_SEG_STATUS, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NEED_WP_BEFORE_PQ, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NEED_WP_BEFORE_PQ, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.UNABLE_SELL_SEGMENTS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.UNABLE_SELL_SEGMENTS, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.INCORRECT_LINE_NUMBER, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.INCORRECT_LINE_NUMBER, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.INVALID_DISCOUNT_CODE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.INVALID_DISCOUNT_CODE, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.FARE_BASIS_LIMITED, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.FARE_BASIS_LIMITED, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.FARE_BASIS_EXCEEDS, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.FARE_BASIS_EXCEEDS, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_PRIVATE_FARES, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_PRIVATE_FARES, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.INVALID_CORPORATE_ID, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.INVALID_CORPORATE_ID, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.UNABLE_TO_DISPLAY, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.UNABLE_TO_DISPLAY, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_PUBLIC_FARES, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_PUBLIC_FARES, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.FORMAT, ref row, ref col);
            if (row == 1 || col == 1)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.FORMAT, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_NAMES, ref row, ref col);
            if (row == 1 || col == 1)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_NAMES, 3);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;
            }

        }
    }
}
