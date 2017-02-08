using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDesktopApplication.Model; 

namespace ChessDesktopApplication.Movement
{
    public class Movement
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
            if (Board.outofBounds(initX, initY))
            {
                //throw new System.ArgumentOutOfRangeException("Impossible Piece position");
                return false;
            }
            if (Board.outofBounds(destX, destY))
            {
                //throw new System.ArgumentOutOfRangeException("Destination is out side of Board");
                return false;
            }
            char piece = board.getPiece(initX, initY);
            char destPiece = board.getPiece(destX, destY);
            if (Board.blackPieces.Contains(piece) && Board.blackPieces.Contains(destPiece) || Board.whitePieces.Contains(piece) && Board.whitePieces.Contains(destPiece))
            {
                //throw new System.InvalidOperationException("Unable to capture ones own pieces");
                return false;
            }
            // Boolean isWhite = Board.whitePieces.Contains(piece);
            switch (piece)
            {
                case '♙':
                case '♟':
                    movePawn(initX, initY, destX, destY);
                    break;
                case '♖':
                case '♜':
                    moveRook(initX, initY, destX, destY);
                    break;
                case '♝':
                case '♗':
                    moveBishop(initX, initY, destX, destY);
                    break;
                case '♛':
                case '♕':
                    moveKing(initX, initY, destX, destY);
                    break;
                case '♚':
                case '♔':
                    moveQueen(initX, initY, destX, destY);
                    break;
                case '♘':
                case '♞':
                    moveKnight(initX, initY, destX, destY);
                    break;
                default:
                    return false;
                    break;
            }
            return true; 
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
