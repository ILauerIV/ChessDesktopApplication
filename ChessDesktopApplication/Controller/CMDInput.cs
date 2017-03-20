using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDesktopApplication.Model;

namespace ChessDesktopApplication.Controller
{
    public  static class CMDInput
    {
        public static  void turnInputAlgebraic()
        {
            Console.Read();
        }
        /// <summary>
        /// Returns a Turn object using XY notation, returns null on bad input 
        /// </summary>
        public static Turn cmdInputXY()
        {
            int initX = -1;
            int initY = -1;
            int destX = -1;
            int destY = -1; 
            Console.Write("Please enter intial piece position X Y, seperated by a space: \n");
            try
            {
                String inital = Console.ReadLine();
                String[] intSplit = inital.Split(' ');
                initX = Int32.Parse(intSplit[0]);
                initY = Int32.Parse(intSplit[1]);
            }
            catch
            {
                Console.Write("Error, bad input!");
                return null; 
            }
            Console.Write("Please enter destination piece position X Y seperated by a space:  \n");
            try
            {
                String dest = Console.ReadLine();
                String[] destSplit = dest.Split(' ');
                destX = Int32.Parse(destSplit[0]);
                destY = Int32.Parse(destSplit[1]);
            }
            catch
            {
                Console.Write("Error, bad input!");
                return null;
            }
            if ((destX >= 0 && destX < 8)
                && (destY >= 0 && destY < 8)
                && (initX >= 0 && initX < 8)
               && (initX >= 0 && initY < 8))
            {
                return new Turn(initX, initY, destX, destY);

            }
            else
            {
                return null; 
            }
        }
    }
}
