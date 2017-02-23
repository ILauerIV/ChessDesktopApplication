using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessDesktopApplication
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
            board = new Board();
        }
        /**
         * moves a piece on the board by taking the moving piecs coordinate
         * and the coordinate of the destination space
         * Check if the move is legal
         * Move should not be: Out of Bounds, to the same space, onto a piece of the same color
         */
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

            bool moved = false; 
            switch (piece)
            {
                case '♙':
                case '♟':
                   moved = movePawn(initX, initY, destX, destY);
                    break;
                case '♖':
                case '♜':
                    moved = moveRook(initX, initY, destX, destY);
                    break;
                case '♝':
                case '♗':
                   moved = moveBishop(initX, initY, destX, destY);
                    break;
                case '♛':
                case '♕':
                    moved = moveQueen(initX, initY, destX, destY);

                    break;
                case '♚':
                case '♔':
                    moved = moveKing(initX, initY, destX, destY);

                    break;
                case '♘':
                case '♞':
                 moved =    moveKnight(initX, initY, destX, destY);
                    break;
                default:
                    return false;
                   // break;
            }
            return moved;
        }

        public bool moveKing(int initX, int initY, int destX, int destY)
        {
            bool moveable = false;
            if ((Math.Abs(initY - destY) <= 1) && (Math.Abs(initX - destX) <= 1))

            {
                moveable = true;
                move(initX, initY, destX, destY);
            }
            else
            {
                moveable = castling(initX, initY, destX, destY);
            }
            return moveable;
        }
        public bool moveQueen(int initX, int initY, int destX, int destY)
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
            bool blocked = blockedMove(initX, initY, destX, destY);
            if (moveable && !blocked )
            {
                move(initX, initY, destX, destY);
            }
            return moveable && !blocked;
        }
        /**
         * Checks if a knight can move. It does this by calculating the angle between the 
         * inital and destination spaces and by making sure the x and y movement equals 3
         */
        public bool moveKnight(int initX, int initY, int destX, int destY)
        {
            bool moveable = false;
            float angle = -1;
            float y = Math.Abs(initY - destY);
            float x = Math.Abs(initX - destX);
            angle = x / y;
            if ((x + y) == 3 && ((angle == 2.0) || (angle == -2.0) || (angle == .5) || (angle == -.5)))
            {
                moveable = true;
                move(initX, initY, destX, destY);
            }
            return moveable;
        }
        public bool movePawn(int initX, int initY, int destX, int destY)
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
                else if (Math.Abs(initX - destX) == 1 && (initY - destY) == 1 && !(board.getPiece(destX, destY) == ' '))
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
                    else if (((destX - initX == 2) && (board.getPiece(destX, destY)) == ' ' && (initX == 2)))
                    {
                        moveable = true;
                    }
                }
                else if (Math.Abs(initX - destX) == 1 && (initY - destY) == 1 && !(board.getPiece(destX, destY) == ' '))
                {
                    moveable = true;
                }
                else if (entpassant()) // need to figure out how this works 
                {

                }
            }
            if (moveable)
            {
                move(initX, initY, destX, destY);
            }
            return moveable;
        }
        public bool moveRook(int initX, int initY, int destX, int destY)
        {
            bool moveable = false;
            if ((initX == destX) || (initY == destY))
            {
                moveable = true;
            }
            bool blocked = blockedMove(initX, initY, destX, destY);
            if (moveable && !blocked)
            {
                move(initX, initY, destX, destY);
            }
            return moveable && !blocked;
        }
        public bool moveBishop(int initX, int initY, int destX, int destY)
        {
            bool moveable = false;
            if (Math.Abs(initX - destX) == Math.Abs(initY - destY))
            {
                moveable = true;
            }
            bool blocked = blockedMove(initX, initY, destX, destY);
            if (moveable && !blocked)
            {
                move(initX, initY, destX, destY);
            }
            return moveable && !blocked;
        }
        public bool blockedMove(int initX, int initY, int destX, int destY)
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
                    blocked = blockedMoveRook(initX, initY, destX, destY);
                    break;
                case '♝':
                case '♗':
                    blocked = blockedMoveBishop(initX, initY, destX, destY);
                    break;

                case '♛':
                case '♕':
                    blocked = blockedMoveQueen(initX, initY, destX, destY);
                    break;

                default:
                    return false;

            }
            return blocked;
        }
        private bool blockedMoveQueen(int initX, int initY, int destX, int destY)
        {
            bool blockedBishop = blockedMoveBishop(initX, initY, destX, destY);
            bool blockedRook = blockedMoveRook(initX, initY, destX, destY);
            
            return blockedRook && blockedBishop; 
        }
        // this function makes me feel bad. 
        private bool blockedMoveBishop(int initX, int initY, int destX, int destY)
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
        private bool blockedMoveRook(int initX, int initY, int destX, int destY)
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
        private void move(int initX, int initY, int destX, int destY)
        {
            char piece = board.getPiece(initX, initY);
            board.setPiece(destX, destY, piece);
            board.setPiece(initX, initY, ' ');
        }

        public bool entpassant()
        {
            return false;
        }
        public bool castling(int initX, int initY, int destX, int destY)
        {
            bool castle = false;
            char piece = board.getPiece(initX, initY);
            bool left = false;
            bool white = Board.isWhite(piece);
            if (initX > destX)
            {
                left = true;
            }
            if (white)
            {
                if (!(initX == 4 && initY == 7) || destY != 7)
                {
                    return false;
                }
            }
            else
            {
                if (!(initX == 4 && initY == 0) || destY != 0)
                {
                    return false;
                }
            }
            if (white && left)
            {
                if (destX == 2) // if they king is moving to right space
                {
                    if (board.getPiece(7, 0) == '♖') // if the rook is still in position
                    {
                        if (!(blockedMoveRook(initX, initY, destX, destY)) && !(blockedMove(7, 0, 7, 3))) // if nothing is between the rook and king
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
                if (destX == 6)
                {
                    if (board.getPiece(7, 7) == '♖') // if the rook is still in position
                    {
                        if (!(blockedMoveRook(initX, initY, destX, destY)) && !(blockedMove(7, 7, 7, 5))) // if nothing is between the rook and king
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
                if (destX == 2) // if they king is moving to right space
                {
                    if (board.getPiece(0, 0) == '♜') // if the rook is still in position
                    {
                        if (!(blockedMoveRook(initX, initY, destX, destY)) && !(blockedMove(0, 0, 0, 3))) // if nothing is between the rook and king
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
                if (destX == 6)
                {
                    if (board.getPiece(0, 7) == '♜') // if the rook is still in position
                    {
                        if (!(blockedMoveRook(initX, initY, destX, destY)) && !(blockedMove(0, 7, 0, 5))) // if nothing is between the rook and king
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
