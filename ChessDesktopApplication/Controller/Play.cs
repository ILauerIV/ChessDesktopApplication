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

        public bool turn(int initX, int initY, int destX, int destY)
        { return false; }
        public void game() { }
        public bool endGame() { return false; }
    }
}
