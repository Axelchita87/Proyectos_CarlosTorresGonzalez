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
    class ERR_DWLIST
    {
        /// <summary>
        /// Descripción: Clase que valida que la respuesta proporcionada por mySabre
        ///              en la pantalla de "Imprime documento DWLIST"
        /// Creación:    Marzo - Abril 09, Modificación: *
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

        private static bool statusprinter;
        public static bool StatusPrinter
        {
            get { return statusprinter; }
            set { statusprinter = value; }
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
        public static void err_DWLIST(string result)
        {
            Answer = result;
            Status = false;
            StatusPrinter = false;
            int row = 0;
            int col = 0;

            CommandsQik.searchResponse(result, Resources.ErrorMessages.ASSIGN_PROPER_PRINTER, ref row, ref col);
            if (row != 0 || col == 1)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.ASSIGN_PROPER_PRINTER, 11);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                StatusPrinter = true;
                row = 0;
                col = 0;
                return;

            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.FIN_O_IG, ref row, ref col);
            if (row != 0 || col == 1)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.FIN_O_IG, 11);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;

            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_ITIN, ref row, ref col);
            if (row != 0 || col == 1)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_ITIN, 11);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;

            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NEED_PNR, ref row, ref col);
            if (row != 0 || col == 1)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NEED_PNR, 11);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;

            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_INV_PRESENT, ref row, ref col);
            if (row != 0 || col == 1)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_INV_PRESENT, 11);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;

            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_NAMES, ref row, ref col);
            if (row != 0 || col == 1)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_NAMES, 11);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;

            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.TKT_PTR_NOT_ASSIGNED, ref row, ref col);
            if (row != 0 || col == 1)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.TKT_PTR_NOT_ASSIGNED, 11);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;

            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.TKT_PRT_NOT_ASSIGNED, ref row, ref col);
            if (row != 0 || col == 1)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.TKT_PRT_NOT_ASSIGNED, 11);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;

            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.TKT_PRT_NOT_ASSIGNED, ref row, ref col);
            if (row != 0 || col == 1)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.TKT_PRT_NOT_ASSIGNED, 11);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;

            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.ND_RCVD, ref row, ref col);
            if (row != 0 || col == 1)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.ND_RCVD, 11);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;

            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.CK_ACCT_DATA, ref row, ref col);
            if (row != 0 || col == 1)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.CK_ACCT_DATA, 11);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;

            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.INVALID_RANGE, ref row, ref col);
            if (row != 0 || col == 1)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.INVALID_RANGE, 11);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                Status = true;
                row = 0;
                col = 0;
                return;

            }

        }
    }
}
