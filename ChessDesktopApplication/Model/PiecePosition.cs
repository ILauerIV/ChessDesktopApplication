using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDesktopApplication.Model
{
   public class  PiecePosition
    {
        public int x;
        public int y;
        public char piece;
        public bool isWhite; 

        public PiecePosition(int iX, int iY, char iPiece)
        {
            x = iX;
            y = iY;
            piece = iPiece;
            isWhite = Board.isWhite(piece);
        }


        public static List<PiecePosition> getAllWhite(Board board)
        {

            List<PiecePosition> whites = new List<PiecePosition>();
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    if (Board.isWhite(board.getPiece(i,j)))
                    {
                        whites.Add(new PiecePosition(i, j, board.getPiece(i, j)));
                    }
                }
            }
            return whites; 
        }
        public static List<PiecePosition> getAllBlack(Board board)
        {
            List<PiecePosition> whites = new List<PiecePosition>();
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    if (Board.isWhite(board.getPiece(i, j)))
                    {
                        whites.Add(new PiecePosition(i, j, board.getPiece(i, j)));
                    }
                }
            }
            return whites;
        }
    }
}
