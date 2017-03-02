using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDesktopApplication.Model; 

namespace ChessDesktopApplication.Controller
{
    /// <summary>
    /// This class controls the turn sequence along with overall play of a game 
    /// </summary>
    class Play
    {
        private Board board;
        private Player white;
        private Player black;
        private Record record;
        private Movement movement;
        private bool whitesTurn; 

        public Play()
        {
            board = new Board();
            white = new Model.Player(true);
            black = new Model.Player(false);
            record = new Record();
            movement = new Movement(board);
            whitesTurn = true;         }
        /// <summary>
        /// Counts as one turn for a a game. Its moves a piece then changes sets the next players turn if the move was succesful
        /// </summary>
        /// <param name="initX"></param>
        /// <param name="initY"></param>
        /// <param name="destX"></param>
        /// <param name="destY"></param>
        /// <param name="isWhite"></param>
        /// <returns></returns>
        public bool turn(int initX, int initY, int destX, int destY)
        {
            bool moved;
            char piece = board.getPiece(initX, initY);
            bool pieceIsWhite =Board.isWhite( board.getPiece(initX, initY));
            if (pieceIsWhite != whitesTurn)
            {
                return false;
            }
            moved =  movement.movePiece(initX, initY, destX, destY);
            if (moved)
            {
                whitesTurn = !pieceIsWhite;
                record.recordTurn(initX, initY, destX, destY);
            }
            return moved; 
        }
        
        public bool endGame() { return false; }
    }
}
