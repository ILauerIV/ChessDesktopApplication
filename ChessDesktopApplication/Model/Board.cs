using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * This class describes the chessboard and holds all of the pieces.
 * */
namespace ChessDesktopApplication.Model
{
   public class Board
    {
        public static char[] colum = new char[8] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
        char[,] board;
        public static char[] whitePieces = new char[6] { '♙', '♖', '♘', '♗', '♕', '♔' };
        public static char[] blackPieces = new char[6] { '♟' , '♜', '♞', '♝', '♛', '♚' };
        public Board()
        {
            board = new char[8, 8]
            {
                {'♜','♞','♝','♛','♚','♝','♞','♜'},
                {'♟','♟','♟','♟','♟','♟','♟','♟'},
                {' ',' ',' ',' ',' ',' ',' ',' ' },
                {' ',' ',' ',' ',' ',' ',' ',' '  },
                {' ',' ',' ',' ',' ',' ',' ',' '  },
                {' ',' ',' ',' ',' ',' ',' ',' '  },
                {'♙','♙','♙','♙', '♙','♙','♙','♙'},
                {'♖','♘','♗','♕','♔','♗','♘','♖'},
            };
        
        }
        public char getPiece (int x, int y)
        {
            if (!outofBounds(x,y))
            {
                return board[x,y];
            }
            return '#'; 
        }
        public bool setPiece(int x, int y, char p) {
            if (!outofBounds(x, y))
            {
                board[x, y] = p;
                return true;
            }
            return false; 
        }
       public static bool outofBounds(int x, int y)
        {
            return !(x >= 0 && x < 8 && y >= 0 && y < 8); 

        }
        public static bool isWhite (char x)
        {
            return whitePieces.Contains(x);
        }
        public static bool isBlack(char x)
        {
            return blackPieces.Contains(x);
        }
        public void resetBoard() {
        board = new char[8,8]
                {
                {'♜','♞','♝','♛','♚','♝','♞','♜'},
                {'♟','♟','♟','♟','♟','♟','♟','♟'},
                {' ',' ',' ',' ',' ',' ',' ',' ' },
                {' ',' ',' ',' ',' ',' ',' ',' '  },
                {' ',' ',' ',' ',' ',' ',' ',' '  },
                {' ',' ',' ',' ',' ',' ',' ',' '  },
                {'♙','♙','♙','♙', '♙','♙','♙','♙'},
                {'♖','♘','♗','♕','♔','♗','♘','♖'},
            };
        }
        /*
         * This funciton converts the index notion of the array to algebraic chess noation. 
         */ 
        public static String IndexToChessNotation(int x, int y)
        {

            if (x < 8 && x >= 0 && y < 8 && y >= 0)
            {
                char ychar = colum[y];
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
                if (colum[i] == first)
                {
                    yint = i;
                    break;
                }
            }


            return xInt.ToString() + yint.ToString();
        }
        /*
         * Moves a piece on the board. Only checks if the move is on the board by taking the index coordinates of a piece and its destination. Returns true if the 
         * piece was moved. False is piece does not exist or is an out of bounds move. Will overwrite pieces on board. 
         */ 
        public bool movePiece(String init, String dest)
        {
            int initX = (int) Char.GetNumericValue(init[0]);
            int initY = (int)Char.GetNumericValue(init[1]);
            int destX = (int)Char.GetNumericValue(dest[0]);
            int destY = (int)Char.GetNumericValue(dest[1]);
            if(!outofBounds(initX,initY) && !outofBounds(destX,destY))
            {
                char piece = getPiece(initX, initY);
                setPiece(destX, destY, piece);
                setPiece(initX, initY, ' ');
                return true;
            }

            return false; }
        public override String ToString()
        {
            String fin = "";
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    fin = fin + board[i, j];
                }
                fin = fin + "\n";
            }
            return fin;
        }
    }
}
