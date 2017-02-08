using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDesktopApplication.Model; 

namespace ChessDesktopApplication.Movement
{
    public class  Movement
    {
        Board board; 
        public Movement(Board b)
        {
            board = b; 
        }
        public Movement()
        {
           board = new Model.Board();
        }
        public bool movePiece(int initX, int initY, int destX, int destY)
        {
            return false; 
        }
        public bool moveKing(int initX, int initY, int destX, int destY)
        { return false; }
        public bool moveQueen(int initX, int initY, int destX, int destY)
        { return false; }
        public bool moveKnight(int initX, int initY, int destX, int destY)
        { return false; }
        public bool movePawn(int initX, int initY, int destX, int destY)
        { return false; }
        public bool moveRook(int initX, int initY, int destX, int destY)
        { return false; }
        public bool moveBishop(int initX, int initY, int destX, int destY)
        { return false; }
        public bool blockedMove(int initX, int initY, int destX, int destY)
        { return false; }
        public bool blockedDestination(int initX, int initY, int destX, int destY)
        { return false; }
    }
}
