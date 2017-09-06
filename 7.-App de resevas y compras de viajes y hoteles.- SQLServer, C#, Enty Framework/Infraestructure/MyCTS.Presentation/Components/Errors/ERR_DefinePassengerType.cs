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
    class ERR_DefinePassengerType
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

        private static bool name2;
        public static bool Name2
        {
            get { return name2; }
            set { name2 = value; }
        }

        private static bool name3;
        public static bool Name3
        {
            get { return name3; }
            set { name3 = value; }
        }
        private static bool name4;
        public static bool Name4
        {
            get { return name4; }
            set { name4 = value; }
        }
        private static bool name5;
        public static bool Name5
        {
            get { return name5; }
            set { name5 = value; }
        }
        private static bool name6;
        public static bool Name6
        {
            get { return name6; }
            set { name6 = value; }
        }
        private static bool name7;
        public static bool Name7
        {
            get { return name7; }
            set { name7 = value; }
        }
        private static bool name8;
        public static bool Name8
        {
            get { return name8; }
            set { name8 = value; }
        }
        private static bool name9;
        public static bool Name9
        {
            get { return name9; }
            set { name9 = value; }
        }
        
        private static string namesend1;
        public static string Namesend1
        {
            get { return namesend1; }
            set { namesend1 = value; }
        }

        private static string namesend2;
        public static string Namesend2
        {
            get { return namesend2; }
            set { namesend2 = value; }
        }

        private static string namesend3;
        public static string Namesend3
        {
            get { return namesend3; }
            set { namesend3 = value; }
        }

        private static string namesend4;
        public static string Namesend4
        {
            get { return namesend4; }
            set { namesend4 = value; }
        }

        private static string namesend5;
        public static string Namesend5
        {
            get { return namesend5; }
            set { namesend5 = value; }
        }

        private static string namesend6;
        public static string Namesend6
        {
            get { return namesend6; }
            set { namesend6 = value; }
        }

        private static string namesend7;
        public static string Namesend7
        {
            get { return namesend7; }
            set { namesend7 = value; }
        }

        private static string namesend8;
        public static string Namesend8
        {
            get { return namesend8; }
            set { namesend8 = value; }
        }

        private static string namesend9;
        public static string Namesend9
        {
            get { return namesend9; }
            set { namesend9 = value; }
        }

        


        public static void err_definepassengertype(string result)
        {
            Answer = result;
            
            Status = false;
            Name2 = false;
            Name3 = false;
            Name4 = false;
            Name5 = false;
            Name6 = false;
            Name7 = false;
            Name8 = false;
            Name9 = false;


            int row = 0;
            int col = 0;


            CommandsQik.searchResponse(result, Resources.ErrorMessages.POSITION_ONE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.NO_LEVEL_ONE, 5);
                Status = true;
                namesend1 = string.Empty;
                CommandsQik.CopyResponse(result, ref namesend1, row, 1, 100);
                row = 0;
                col = 0;
                
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.POSITION_TWO, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.POSITION_TWO, 5);
                Name2 = true;
                namesend2 = string.Empty;
                CommandsQik.CopyResponse(result, ref namesend2, row, 1, 100);
                row = 0;
                col = 0;
                
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.POSITION_THREE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.POSITION_THREE, 5);
                Name3 = true;
                namesend3 = string.Empty;
                CommandsQik.CopyResponse(result, ref namesend3, row, 1, 100);
                row = 0;
                col = 0;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.POSITION_FOUR, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.POSITION_FOUR, 5);
                Name4 = true;
                namesend4 = string.Empty;
                CommandsQik.CopyResponse(result, ref namesend4, row, 1, 100);
                row = 0;
                col = 0;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.POSITION_FIVE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.POSITION_FIVE, 5);
                Name5 = true;
                namesend5 = string.Empty;
                CommandsQik.CopyResponse(result, ref namesend5, row, 1, 100);
                row = 0;
                col = 0;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.POSITION_SIX, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.POSITION_SIX, 5);
                Name6 = true;
                namesend6 = string.Empty;
                CommandsQik.CopyResponse(result, ref namesend6, row, 1, 100);
                row = 0;
                col = 0;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.POSITION_SEVEN, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.POSITION_SEVEN, 5);
                Name7 = true;
                namesend7 = string.Empty;
                CommandsQik.CopyResponse(result, ref namesend7, row, 1, 100);
                row = 0;
                col = 0;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.POSITION_EIGHT, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.POSITION_EIGHT, 5);
                Name8 = true;
                namesend8 = string.Empty;
                CommandsQik.CopyResponse(result, ref namesend8, row, 1, 100);
                row = 0;
                col = 0;
            }

            CommandsQik.searchResponse(result, Resources.ErrorMessages.POSITION_NINE, ref row, ref col);
            if (row != 0 || col != 0)
            {
                SabreErrorMsg userErrorMessage = SabreErrorMsgBL.GetSabreErrorMsg(Resources.ErrorMessages.POSITION_NINE, 5);
                Name9 = true;
                namesend9 = string.Empty;
                CommandsQik.CopyResponse(result, ref namesend9, row, 1, 100);
                row = 0;
                col = 0;
            }

          }
     }
}
