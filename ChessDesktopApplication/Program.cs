using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDesktopApplication.Model
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Board board = new Board();
            board.movePiece("73", "04");
            Console.Write(board.ToString());
            Console.Read();
        }
    }
}
