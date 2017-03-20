using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDesktopApplication.Model;

namespace ChessDesktopApplication.View
{
    class CMDDisplay
    {
        public void clearScreen()
        {
            Console.Clear(); 
        }
        public void printBoard(Board b)
        {
            Console.Write(b);    
        }
        public void newTurn(Board b, bool white)
        {
            clearScreen();
            printBoard(b);
            String player = "";
            if (white)
            {
                player = "white";
            }
            else
            {
                player = "black";
            }
            Console.Write(player + " player make your move:"); 
        }
    }
}
