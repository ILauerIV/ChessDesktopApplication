
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDesktopApplication
{
  

    
        class Program
        {
            static void Main(string[] args)
            {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\test.txt"))
            {
              
                Board board = new Board();

                Movement move = new Movement(board);
                file.Write(move.movePiece(0, 3, 0, 4) + System.Environment.NewLine);
                file.Write(board.ToString());
                file.Write(move.movePiece(0, 3, -1, 4) + System.Environment.NewLine);
                file.Write(board.ToString());
                file.Write(move.movePiece(0, 3, 1, 4) + System.Environment.NewLine);
                file.Write(board.ToString());
                file.Write(move.movePiece(0, 3, 1, 5) + System.Environment.NewLine );
                file.Write(board.ToString());
                


                file.Write(move.movePiece(0, 3, 4, 4) + Environment.NewLine);
                file.Write(board.ToString());
                file.Close(); 
            }
            }
        }
    }
/// OVER ALL TD's
/// TODO: Understand what all the player needs to input
/// TODO: Decide how pawn promotion will work
/// TODO:Refactor?
