using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDesktopApplication.Model
{
    public static class Notation
    {
        public static char[] column = new char[8] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

        /*
        * This funciton converts the index notion of the array to algebraic chess noation. 
        */
        public static String IndexToChessNotation(int x, int y)
        {

            if (x < 8 && x >= 0 && y < 8 && y >= 0)
            {
                char ychar = column[y];
                int xint = 8 - x;
                return ychar + xint.ToString();
            }
            return "Fail";
        }
        /*
         * Converts algebraic chess notation into index notation of board array. Returns a string
         */
        public static String ChessToIndexNotation(String s)
        {
            char first = s[0];
            char second = s[1];
            int xInt = 8 - (int)Char.GetNumericValue(second);
            int yint = -1;
            for (int i = 0; i < 8; ++i)
            {
                if (column[i] == first)
                {
                    yint = i;
                    break;
                }
            }


            return xInt.ToString() + yint.ToString();
        }
      
    }
}
