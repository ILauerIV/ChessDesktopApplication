using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDesktopApplication.Model;

namespace ChessDesktopApplication.View
{
    public class CMDDisplay
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
                player = "White";
            }
            else
            {
                player = "Black";
            }
            Console.Write(player + " player make your move:\n"); 
        }
        public void moveError (string s)
        {
            Console.Write(s + "\n");
        }
    }

}
