﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessDesktopApplication.Model
{
    public static class Movement
    {
     //   Board board;
       
        /// <summary>
        /// moves a piece on the board by taking the moving pieces coordinate
        /// and the coordinate of the destination space
        ///Check if the move is legal
        /// Move should not be: Out of Bounds, to the same space, onto a piece of the same color
        /// </summary>
        /// <param name="initX"></param>
        /// <param name="initY"></param>
        /// <param name="destX"></param>
        /// <param name="destY"></param>
        /// <returns></returns>
        public static Turn movePiece(int initX, int initY, int destX, int destY, Board board) 
        {
            char initPiece;
            char destPiece;
            Turn returnTurn = null;
            bool moved = moveable( initX,  initY,  destX, destY,  board);
            if (moved)
            {
                initPiece = board.getPiece(initX, initY);
                destPiece = board.getPiece(initX, initY);

                returnTurn = new Turn(initX, initY, destX, destY, initPiece, destPiece);
                move(initX, initY, destX, destY, board);
            }
            return returnTurn;
        }
        public static bool moveable(int initX, int initY, int destX, int destY, Board board) ///Castling is not handed well 
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
            if (initX == destX && initY == destY)
            {
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
            if (piece == ' ')
            {
                return false;
            }

            bool moved = false;
            switch (piece)
            {
                case '♙':
                case '♟':
                    moved = movePawn(initX, initY, destX, destY, board);
                    break;
                case '♖':
                case '♜':
                    moved = moveRook(initX, initY, destX, destY, board);
                    break;
                case '♝':
                case '♗':
                    moved = moveBishop(initX, initY, destX, destY, board);
                    break;
                case '♛':
                case '♕':
                    moved = moveQueen(initX, initY, destX, destY, board);

                    break;
                case '♚':
                case '♔':
                    moved = moveKing(initX, initY, destX, destY, board);

                    break;
                case '♘':
                case '♞':
                    moved = moveKnight(initX, initY, destX, destY, board);
                    break;
                default:
                    return false;
                    // break;
            }
            return moved; 
        }
        public static bool moveKing(int initX, int initY, int destX, int destY, Board board)
        {
            bool moveable = false;
            if ((Math.Abs(initY - destY) <= 1) && (Math.Abs(initX - destX) <= 1))

            {
                moveable = true;
            }
            else
            {
                moveable = castling(initX, initY, destX, destY, board);
            }
            return moveable;
        }
        public static bool moveQueen(int initX, int initY, int destX, int destY, Board board)
        {
            bool moveable = false;
            if (Math.Abs(initX - destX) == Math.Abs(initY - destY))
            {
                moveable = true;
            }
            else if ((initX == destX) || (initY == destY))
            {
                moveable = true;
            }
            bool blocked = blockedMove(initX, initY, destX, destY, board);
            return moveable && !blocked;
        }
        /**
         * Checks if a knight can move. It does this by calculating the angle between the 
         * inital and destination spaces and by making sure the x and y movement equals 3
         */
        public static bool moveKnight(int initX, int initY, int destX, int destY, Board board)
        {
            bool moveable = false;
            float angle = -1;
            float y = Math.Abs(initY - destY);
            float x = Math.Abs(initX - destX);
            angle = x / y;
            if ((x + y) == 3 && ((angle == 2.0) || (angle == -2.0) || (angle == .5) || (angle == -.5)))
            {
                moveable = true;
            }
            return moveable;
        }
        public static bool movePawn(int initX, int initY, int destX, int destY, Board board)
        {
            bool isWhite = Board.isWhite(board.getPiece(initX, initY));
            bool moveable = false;
            if (isWhite)
            {
                if (initY == destY)
                {
                    if (((initX - destX) == 1) && (board.getPiece(destX, destY)) == ' ')
                    {
                        moveable = true;
                    }
                    else if (((initX - destX) == 2) && (board.getPiece(destX, destY)) == ' ' && (initX == 6))
                    {
                        moveable = true;
                    }
                }
                else if (Math.Abs(initX - destX) == 1 && (initY - destY) == 1 && Board.isBlack(board.getPiece(destX, destY)))
                {
                    moveable = true;
                }
                else if (entpassant()) // need to figure out how this works 
                {

                }
            }
            else
            {
                if (initY == destY)
                {
                    if (((destX - initX == 1) && (board.getPiece(destX, destY)) == ' '))
                    {
                        moveable = true;
                    }
                    else if (((destX - initX == 2) && (board.getPiece(destX, destY)) == ' ' && (initX == 1)))
                    {
                        moveable = true;
                    }
                }
                else if (( destX - initX) == 1 && Math.Abs(initY - destY) == 1 && !(board.getPiece(destX, destY) == ' '))
                {
                    moveable = true;
                }
                else if (entpassant()) // need to figure out how this works 
                {

                }
            }
            return moveable;
        }
        public static bool moveRook(int initX, int initY, int destX, int destY, Board board)
        {
            bool moveable = false;
            if ((initX == destX) || (initY == destY))
            {
                moveable = true;
            }
            bool blocked = blockedMove(initX, initY, destX, destY, board);
            return moveable && !blocked;
        }
        public static bool moveBishop(int initX, int initY, int destX, int destY, Board board)
        {
            bool moveable = false;
            if (Math.Abs(initX - destX) == Math.Abs(initY - destY))
            {
                moveable = true;
            }
            bool blocked = blockedMove(initX, initY, destX, destY, board);
            return moveable && !blocked;
        }

        /// <summary>
        /// Checks to see if there is a piece between the piece and its destination,
        /// does not check king or knight
        /// </summary>
        /// <param name="initX"></param>
        /// <param name="initY"></param>
        /// <param name="destX"></param>
        /// <param name="destY"></param>
        /// <returns></returns>
        public static bool blockedMove(int initX, int initY, int destX, int destY, Board board)
        {
            Boolean blocked = false;
            char piece = board.getPiece(initX, initY);
            switch (piece)
            {
                case '♙':
                case '♟':
                    break;
                case '♖':
                case '♜':
                    blocked = blockedMoveRook(initX, initY, destX, destY, board);
                    break;
                case '♝':
                case '♗':
                    blocked = blockedMoveBishop(initX, initY, destX, destY, board);
                    break;

                case '♛':
                case '♕':
                    blocked = blockedMoveQueen(initX, initY, destX, destY, board);
                    break;

                default:
                    return false;

            }
            return blocked;
        }
        private static bool blockedMoveQueen(int initX, int initY, int destX, int destY, Board board)
        {
            bool blockedBishop = blockedMoveBishop(initX, initY, destX, destY, board);
            bool blockedRook = blockedMoveRook(initX, initY, destX, destY, board);
            
            return blockedRook && blockedBishop; 
        }
        // this function makes me feel bad. 
        private static bool blockedMoveBishop(int initX, int initY, int destX, int destY, Board board)
        {
            bool blocked = false;
            int direction = -1; // Based upon quadrant system, so NE = 1, NW = 2, SW = 3, SE = 4
            if (initX > destX)
            {
                if (initY < destY)
                {
                    direction = 1;
                }
                else if (initY > destY)
                {
                    direction = 2;
                }
            }
            else if (initX < destX)
            {
                if (initY < destY)
                {
                    direction = 4;
                }
                else if (initY > destY)
                {
                    direction = 3;
                }
            }
            int x = initX;
            int y = initY;
            while (true) // this is a pain to write. I need to check all the spaces exclusive the inital and destination spaces 
            {
                if (direction == 4)
                {
                    x += 1;
                    y += 1;
                }
                else if (direction == 1) // okay 
                {
                    x += -1;
                    y += 1;
                }
                else if (direction == 2)
                {
                    x += -1;
                    y += -1;
                }
                else if (direction == 3)
                {
                    x += 1;
                    y += -1;
                }
                else
                {
                    return true;
                }
                if (x == destX)
                {
                   // blocked = false;
                    break; 
                }
                if (!(board.getPiece(x, y) == ' '))
                {
                    blocked = true;
                }
            }
            return blocked;
        }
        private static bool blockedMoveRook(int initX, int initY, int destX, int destY, Board board)
        {
            bool blocked = true;

            if (initX == destX)
            {
                int high = Math.Max(initY, destY);
                int low = Math.Min(initY, destY);
                for (int i = low + 1; i < high; ++i)
                {
                    if (!board.getPiece(initX, i).Equals(' '))
                    {
                        return blocked;
                    }
                }
                blocked = false;
            }
            else if (initY == destY)
            {
                int high = Math.Max(initX, destX);
                int low = Math.Min(initX, destX);
                for (int i = low + 1; i < high; ++i)
                {
                    if (!board.getPiece(i, initY).Equals(' '))
                    {
                        return true;
                    }
                }
                blocked = false;
            }
            return blocked;
        }
        private static void move(int initX, int initY, int destX, int destY, Board board)
        {
            char piece = board.getPiece(initX, initY);
            board.setPiece(destX, destY, piece);
            board.setPiece(initX, initY, ' ');
        }

        public static bool entpassant() ///TODO: Add entpassant to movement
        {
            return false;
        }  
        public static bool castling(int initX, int initY, int destX, int destY, Board board)
        {
            bool castle = false;
            char piece = board.getPiece(initX, initY);
            bool left = false;
            bool white = Board.isWhite(piece);
            if (initY > destY)
            {
                left = true;
            }
            if (white)
            {
                if (!(initX == 7 && initY == 4) || destX != 7)
                {
                    return false;
                }
            }
            else
            {
                if (!(initX == 0 && initY == 4) || destX != 0)
                {
                    return false;
                }
            }
            if (white && left)
            {
                if (destY == 2) // if they king is moving to right space
                {
                    if (board.getPiece(7, 0) == '♖') // if the rook is still in position
                    {
                        if (!(blockedMoveRook(initX, initY, destX, destY, board)) && !(blockedMove(7, 0, 7, 3, board))) // if nothing is between the rook and king
                        {
                            board.setPiece(initX, initY, ' ');
                            board.setPiece(7, 0, ' ');
                            board.setPiece(destX, destY, piece);
                            board.setPiece(7, 3, '♖');
                            castle = true;
                        }
                    }
                }
            }
            else if (white && !left)
            {
                if (destY == 6)
                {
                    if (board.getPiece(7, 7) == '♖') // if the rook is still in position
                    {
                        if (!(blockedMoveRook(initX, initY, destX, destY, board)) && !(blockedMove(7, 7, 7, 5, board))) // if nothing is between the rook and king
                        {
                            board.setPiece(initX, initY, ' ');
                            board.setPiece(7, 7, ' ');
                            board.setPiece(destX, destY, piece);
                            board.setPiece(7, 5, '♖');
                            castle = true;
                        }
                    }
                }
            }
            else if (!white && left)
            {
                if (destY == 2) // if they king is moving to right space
                {
                    if (board.getPiece(0, 0) == '♜') // if the rook is still in position
                    {
                        if (!(blockedMoveRook(initX, initY, destX, destY, board)) && !(blockedMove(0, 0, 0, 3, board))) // if nothing is between the rook and king
                        {
                            board.setPiece(initX, initY, ' ');
                            board.setPiece(0, 0, ' ');
                            board.setPiece(destX, destY, piece);
                            board.setPiece(0, 3, '♜');
                            castle = true;
                        }
                    }
                }
            }
            else if (!white && !left)
            {
                if (destY == 6)
                {
                    if (board.getPiece(0, 7) == '♜') // if the rook is still in position
                    {
                        if (!(blockedMoveRook(initX, initY, destX, destY, board)) && !(blockedMove(0, 7, 0, 5, board))) // if nothing is between the rook and king
                        {
                            board.setPiece(initX, initY, ' ');
                            board.setPiece(0, 7, ' ');
                            board.setPiece(destX, destY, piece);
                            board.setPiece(0, 5, '♜');
                            castle = true;
                        }
                    }
                }
            }

            return castle;
        }
    }
}
