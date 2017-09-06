using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Presentation.Components
{
    public class CommandsQik
    {
        public static void searchResponse(string responseString, string searchString, ref int row, ref int col)
        {
            int startRow = 1;
            int endrow = responseString.Split(new char[] { '\n' }).Length - 1;
            //int endrow = responseString.Split(Environment.NewLine.ToCharArray()).Length - 1;

            if (endrow.Equals(0)) endrow = 1;

            searchResponse(responseString, searchString, ref row, ref col, startRow, endrow);
        }
        public static void searchResponse(string responseString, string searchString, ref int row, ref int col, int startRow)
        {
            string[] content = responseString.Split(new char[] { '\n' });
            int endrow = content.Length - 1;

            searchResponse(responseString, searchString, ref row, ref col, startRow, endrow);
        }
        public static void searchResponse(string responseString, string searchString, ref int row, ref int col, int startRow, int endRow)
        {
            searchResponse(responseString, searchString, ref row, ref col, startRow, endRow, 1);
        }

        public static void searchResponse(string responseString, string searchString, ref int row, ref int col,
            int startRow, int endRow, int startCol)
        {
            searchResponse(responseString, searchString, ref row, ref col, startRow, endRow, startCol, 64);

        }

        public static void searchResponse(string responseString, string searchString, ref int row, ref int col,
                                    int startRow, int endRow, int startCol, int endCol)
        {
            searchString = searchString.ToUpper();
            string[] content = responseString.Split(new char[] { '\n' });
            int lenContent = content.Length;

            startRow = startRow - 1;
            endRow = (lenContent < endRow) ? lenContent : endRow;


            string temp = string.Empty;
            int startColTemp = 0;
            int endColTemp = 0;

            for (int i = startRow; i < endRow; i++)
            {
                temp = content[i];
                if (string.IsNullOrEmpty(temp)) continue;

                startColTemp = ((temp.Length < startCol) ? 1 : startCol) - 1;
                endColTemp = ((temp.Length < endCol) ? temp.Length : endCol);
                endColTemp = endColTemp - startColTemp;

                temp = temp.Substring(startColTemp, endColTemp);

                if (temp.Contains(searchString))
                {
                    row = i + 1;
                    col = content[i].IndexOf(searchString);
                    break;
                }

            }

        }

        public static void CopyResponse(string responseString, ref string result, int startRow, int startCol, int length)
        {

            responseString = responseString.ToUpper();
            string[] content = responseString.Split(new char[] { '\n' });
            startRow = startRow - 1;

            int lengthTemp = 0;
            string tempContent = string.Empty;
            string temp = string.Empty;

            temp = content[startRow];
            lengthTemp = (temp.Length - startCol + 1);
            startCol = startCol - 1;
            length = (lengthTemp < length) ? lengthTemp : length;


            try
            {
                result = temp.Substring(startCol, length);
            }
            catch
            {
                result = string.Empty;
            }


        }
    }
}
