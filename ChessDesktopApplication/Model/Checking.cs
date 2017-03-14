using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDesktopApplication.Model
{
    static class Checking
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="whitesTurn"></param>
        /// <returns></returns>
        public static bool isChecked(Board b, bool white)
        {
            List<PiecePosition> blacks =  PiecePosition.getAllBlack(b);
            List<PiecePosition> whites = PiecePosition.getAllWhite(b);
            List<PiecePosition> enemy = null; /// This is the side that has the king in check
            PiecePosition king = null;  // this is the king we are checkign if its in check
            if (white)
            {
                king = getKing(whites);
                enemy = blacks;
            }
            else
            {
                king = getKing(blacks);
                enemy = whites;
            }
            foreach (PiecePosition piece in enemy) /// check each piece if it has the king in check 
            {

            }

            return false;
        }
        public static bool isCheckmate(Board b, bool whitesTurn)
        {
            return false; 
        }
        private static PiecePosition getKing(List<PiecePosition> l)
        {
            foreach (PiecePosition p in l)
            {
                if (p.piece == '♚' || p.piece == '♔')
                {
                    return p; 
                }
            }
            return null; 
        }
    }
}
