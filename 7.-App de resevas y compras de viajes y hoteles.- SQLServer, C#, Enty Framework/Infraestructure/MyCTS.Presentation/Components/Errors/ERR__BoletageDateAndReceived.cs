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
    class ERR__BoletageDateAndReceived
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



        private static bool ia;
        public static bool IA
        {
            get { return ia; }
            set { ia = value; }
        }

        private static string fecha;
        public static string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private static string customusermsg;
        public static string CustomUserMsg
        {
            get { return customusermsg; }
            set { customusermsg = value; }
        }


        private static bool boletagereceived;
        public static bool BoletageReceived
        {
            get { return boletagereceived; }
            set { boletagereceived = value; }
        }




        public static void err_boletagedataandreceived(string result)
        {
            Answer = result;
            status = false;
            BoletageReceived = false;
            IA = false;
            int row = 0;
            int col = 0;


            CommandsQik.searchResponse(result, Resources.ErrorMessages.PAC_VEFIFY_CORRECT_NBR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                BoletageReceived = true;
                row = 0;
                col = 0;
                return;
            }


            //********** BoletageDataAndReceived **************** //

            if (ucBoletageDateAndReceived.PQ)
            {

                CommandsQik.searchResponse(result, Resources.ErrorMessages.LAST_DAY_TO_PURCHASE, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.LAST_DAY_TO_PURCHASE, 8);
                    status = true;
                    fecha = string.Empty;
                    CommandsQik.CopyResponse(result, ref fecha, row, 22, 5);
                    row = 0;
                    col = 0;
                    return;
                }
            }
            else if (ucBoletageDateAndReceived.WP)
            {
                CommandsQik.searchResponse(result, Resources.ErrorMessages.LAST_DAY_TO_PURCHASE, ref row, ref col);
                if (row != 0 || col != 0)
                {
                    SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.LAST_DAY_TO_PURCHASE, 8);
                    status = true;
                    fecha = string.Empty;
                    CommandsQik.CopyResponse(result, ref fecha, row, 47, 5);
                    row = 0;
                    col = 0;
                    return;
                }

            }


            CommandsQik.searchResponse(result, Resources.ErrorMessages.NO_ITIN, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_ITIN, 8);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                status = false;
                row = 0;
                col = 0;
                return;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.ONE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.ONE, 8);
                CustomUserMsg = userErrorMessage.CusErrMsgUserMsg;
                fecha = string.Empty;
                CommandsQik.CopyResponse(result, ref fecha, row, 12, 5);
                IA = true;
                row = 0;
                col = 0;
                return;
            }


          
            
        }
    }
}
