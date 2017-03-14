using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDesktopApplication.Model;

namespace ChessDesktopApplication
{
    /*
     * Directions of Pieces
     *      Decreasing X val is moving left
     *      Increasing X val is moving right
     *      Decreasing Y is moving down
     *      Increasing Y is moving up 
     */ 
    [TestClass()]
    public class MovementTests
    {
          
      
        /*       
         *       This tests the movement of King. It makses the following moves
         *          White King  tries to move from Home space to middle of board
         *       WK tries to move from Home one forward, over top of pawn
         *       WK tries to move 1 right running into bishop
         *       WK tries to move backwards 1 off the board
         *       WK tries to move forward-right into pawn
         *       WK tries to move forward left into pawn
         *       All of above should fail. Then the kings pawn is removed 
         *       King then moves:
         *          forward 1
         *          Back 1
         *          Forward 1
         *          Forward Right 1
         *          Forward Left 1
         *          Backward Left 1
         */
        [TestMethod()]
        public void moveKingTest()
        {
            Board board = new Board();

            Assert.IsFalse(Movement.movePiece(7, 4, 4, 4,board)); 
            Assert.IsFalse(Movement.movePiece(7, 4, 6, 3,board));// move forward with piece in front
            Assert.IsFalse(Movement.movePiece(7, 4, 7, 2,board));// move right with piece in the way
            Assert.IsFalse(Movement.movePiece(7, 4, 8, 3,board));//move backwards off the board
            Assert.IsFalse(Movement.movePiece(7, 4, 7, 4,board));// move left with piece in way
            Assert.IsFalse(Movement.movePiece(7, 4, 6, 4,board));
            Assert.IsFalse(Movement.movePiece(7, 4, 6, 2,board));
            board.setPiece(6, 4, ' ');
            Assert.IsTrue(Movement.movePiece(7, 4, 6, 4,board));// forward
            Assert.IsTrue(Movement.movePiece(6, 4, 7, 4,board));// back //fail
            Assert.IsTrue(Movement.movePiece(7, 4, 6, 4,board));// foward
            Assert.IsTrue(Movement.movePiece(6, 4, 5, 5,board));// forward right
            Assert.IsTrue(Movement.movePiece(5, 5, 5, 4,board));// left
            Assert.IsTrue(Movement.movePiece(5, 4, 5, 5,board));// right
            Assert.IsTrue(Movement.movePiece(5, 5, 4, 5,board));// forward
            Assert.IsTrue(Movement.movePiece(4, 5, 3, 4,board));
            Assert.IsTrue(Movement.movePiece(3, 4, 2, 3,board));

        }
        /*
         * This method tests the movement of the Queen
         * BQ tries to move left into king
         * BQ tries to move backwards off of board
         * BQ tries to move down left into pawn
         * BQ tries to move to center of board
         * BQ tries to move to its same space
         * BQ tries to move left 2 running into King
         * All of these should fail. Then the Queens Pawn is removed
         * Queen then moves 
         *      Down 1
         *      UP 1
         *      Down 4
         *      Left 5
         *      Right 7
         *      Left 3
         *      Diagonal Down-Right
         *      Diagonal Up-Left
         *      
         */
        [TestMethod()]
        public void moveQueenTest()
        {
            Board board = new Board();
            
            Assert.IsFalse(Movement.movePiece(0, 3, 0, 4,board));
            Assert.IsFalse(Movement.movePiece(0, 3, -1, 4,board));
            Assert.IsFalse(Movement.movePiece(0, 3, 1, 4,board));
            Assert.IsFalse(Movement.movePiece(0, 3, 1,5 ,board));
            Assert.IsFalse(Movement.movePiece(0, 3, 4, 4,board)); 
            Assert.IsFalse(Movement.movePiece(0, 3, 0, 5,board));
            Assert.IsFalse(Movement.movePiece(0, 3, 0, 3,board));
            board.setPiece(1, 4, ' ');
           Assert.IsTrue(Movement.movePiece(0, 3, 1,4,board));
            //Assert.IsTrue(Movement.movePiece(1, 4, 0, 5,board));
            Assert.IsTrue(Movement.movePiece(1, 4, 4, 4,board));
            Assert.IsTrue(Movement.movePiece(4, 4, 4, 0,board));
            Assert.IsTrue(Movement.movePiece(4, 0, 4, 7,board));
            Assert.IsTrue(Movement.movePiece(4, 7, 4, 4,board));
            Assert.IsTrue(Movement.movePiece(4, 4, 6, 6,board));
            Assert.IsTrue(Movement.movePiece(6, 6, 4, 4,board));
            Assert.IsFalse(Movement.movePiece(4, 4, 7, 4,board));
            Assert.IsTrue(Movement.movePiece(4, 4, 6, 2,board));
            Assert.IsTrue(Movement.movePiece(6, 2, 2, 2,board));
        }


      

        [TestMethod()]
        public void movePawnTest()
        {
            Board board = new Board();
            ///
            Assert.IsFalse(Movement.movePiece(1, 5, 0, 5,board));
            Assert.IsFalse(Movement.movePiece(1, 5, -1, 5,board));
            Assert.IsFalse(Movement.movePiece(1, 5, 1, 4,board));
            Assert.IsFalse(Movement.movePiece(1, 5, 1, 6,board));
            Assert.IsFalse(Movement.movePiece(1, 5, 5, 5,board));  
            Assert.IsFalse(Movement.movePiece(1, 5, 1, 6,board));
            Assert.IsFalse(Movement.movePiece(1, 5, 1,4,board));
            Assert.IsTrue(Movement.movePiece(1, 5, 2, 5,board)); //failed
            Assert.IsTrue(Movement.movePiece(2, 5, 3, 5,board));
            Assert.IsFalse(Movement.movePiece(3, 5, 5, 4,board));
            Assert.IsFalse(Movement.movePiece( 3, 5,2, 5,board));
        }
       // [TestMethod()]
        public void moveKingTest1()
        {
            Board board = new Board();
            ///
            Assert.IsFalse(Movement.movePiece(7, 3, 6, 3,board));
            Assert.IsFalse(Movement.movePiece(7, 3, 8, 3,board));
            Assert.IsFalse(Movement.movePiece(7, 3, 7, 2,board));
            Assert.IsFalse(Movement.movePiece(7, 3, 7, 4,board));
            Assert.IsFalse(Movement.movePiece(7, 3, 6, 2,board));
            Assert.IsFalse(Movement.movePiece(7, 3, 6, 4,board));
            Assert.IsFalse(Movement.movePiece(7, 3, 8, 4,board));
            Assert.IsFalse(Movement.movePiece(7, 3, 8, 2,board));
            Assert.IsFalse(Movement.movePiece(7, 3, 4, 3,board));
            Assert.IsFalse(Movement.movePiece(7, 3, 7, 0,board));
            Assert.IsFalse(Movement.movePiece(7, 3, 7, 6,board));
            Assert.IsFalse(Movement.movePiece(7, 3, 10, 3,board));
            board.setPiece(6, 3, ' ');
            Assert.IsTrue(Movement.movePiece(7, 3, 6, 3,board));
            Assert.IsTrue(Movement.movePiece(6, 3, 5, 3,board));
            Assert.IsFalse(Movement.movePiece(5, 3, 0, 0,board));
            Assert.IsTrue(Movement.movePiece(5, 3, 5, 2,board));
            Assert.IsTrue(Movement.movePiece(5, 2, 5, 3,board));
            Assert.IsTrue(Movement.movePiece(5, 3, 6, 3,board));
            Assert.IsTrue(Movement.movePiece(6, 3, 5, 3,board));
            Assert.IsTrue(Movement.movePiece(5, 3, 4, 2,board));
            Assert.IsTrue(Movement.movePiece(4, 2, 5, 3,board));
            Assert.IsTrue(Movement.movePiece(5, 3, 4, 4,board));
            Assert.IsTrue(Movement.movePiece(4, 4, 5, 3,board));
            Assert.IsFalse(Movement.movePiece(5, 3, 5, 1,board)); //fail
            Assert.IsFalse(Movement.movePiece(5, 3, 5, 5,board));
            Assert.IsFalse(Movement.movePiece(5, 3, 7, 3,board));
            Assert.IsFalse(Movement.movePiece(5, 3, 3, 3,board));
            Assert.IsFalse(Movement.movePiece(5, 3, 3, 1,board));
            Assert.IsFalse(Movement.movePiece(5, 3, 7, 5,board));
            Assert.IsFalse(Movement.movePiece(5, 3, 3, 5,board));
            Assert.IsFalse(Movement.movePiece(5, 3, 7, 1,board));
            Assert.IsTrue(Movement.movePiece(5, 3, 4, 3,board));
        }
        [TestMethod()]
        public void moveKingCastling()
        {
            Board board = new Board();
            ///
            board.setPiece(7, 1, ' ');
            board.setPiece(7, 2, ' ');
            board.setPiece(7, 3, ' ');
            Assert.IsTrue(Movement.movePiece(7, 4, 7, 2,board));
            board.setPiece(0, 5, ' ');
            board.setPiece(0, 6, ' ');
            Assert.IsTrue(Movement.movePiece(0, 4, 0,6,board));
            Assert.IsTrue(board.getPiece(0, 5) == '♜');
            Assert.IsTrue(board.getPiece(7, 3) == '♖');
        }
        [TestMethod()]
        public void moveBishopTest()
        {
            Board board = new Board();
            ///
            Assert.IsFalse(Movement.movePiece(0, 2, -1, 2,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 1, 2,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 0, 1,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 0, 3,board));
            Assert.IsFalse(Movement.movePiece(0, 2, -1, 1,board));
            Assert.IsFalse(Movement.movePiece(0, 2, -1, 3,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 1, 1,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 1, 3,board));
            Assert.IsFalse(Movement.movePiece(0, 2, -4, 2,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 4, 2,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 0, -2,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 0, 6,board));
            Assert.IsFalse(Movement.movePiece(0, 2, -4, -2,board));
            Assert.IsFalse(Movement.movePiece(0, 2, -4, 6,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 4, -2,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 4, 6,board));
            board.setPiece(2, 1, ' ');
            board.setPiece(2, 3, ' ');
           
        }
        [TestMethod()]
        public void moveRookTest()
        {
            Board board = new Board();
            ///
            Assert.IsFalse(Movement.movePiece(7, 7, 6, 7,board));
            Assert.IsFalse(Movement.movePiece(7, 7, 8, 7,board));
            Assert.IsFalse(Movement.movePiece(7, 7, 7, 6,board));
            Assert.IsFalse(Movement.movePiece(7, 7, 7, 8,board));
            Assert.IsFalse(Movement.movePiece(7, 7, 6, 6,board));
            Assert.IsFalse(Movement.movePiece(7, 7, 6, 8,board));
            Assert.IsFalse(Movement.movePiece(7, 7, 8, 6,board));
            Assert.IsFalse(Movement.movePiece(7, 7, 8, 8,board));
            Assert.IsFalse(Movement.movePiece(7, 7, 3, 7,board));
            Assert.IsFalse(Movement.movePiece(7, 7, 11, 7,board));
            Assert.IsFalse(Movement.movePiece(7, 7, 7, 3,board));
            Assert.IsFalse(Movement.movePiece(7, 7, 7, 11,board));
            Assert.IsFalse(Movement.movePiece(7, 7, 3, 3,board));
            Assert.IsFalse(Movement.movePiece(7, 7, 3, 11,board));
            Assert.IsFalse(Movement.movePiece(7, 7, 11, 3,board));
            Assert.IsFalse(Movement.movePiece(7, 7, 11, 11,board));
            board.setPiece(6, 7, ' ');
            Assert.IsTrue(Movement.movePiece(7, 7, 4, 7,board));
            Assert.IsTrue(Movement.movePiece(4, 7, 4, 4,board));
            Assert.IsFalse(Movement.movePiece(4, 4, 3, 3,board));
            Assert.IsFalse(Movement.movePiece(4, 4, 3, 5,board));
            Assert.IsFalse(Movement.movePiece(4, 4, 5, 3,board));
            Assert.IsFalse(Movement.movePiece(4, 4, 5, 5,board));
            Assert.IsFalse(Movement.movePiece(4, 4, 0, 0,board));
            Assert.IsFalse(Movement.movePiece(4, 4, 0, 8,board));
            Assert.IsFalse(Movement.movePiece(4, 4, 8, 0,board));
            Assert.IsFalse(Movement.movePiece(4, 4, 8, 8,board));
            Assert.IsTrue(Movement.movePiece(4, 4, 4, 7,board));
            Assert.IsTrue(Movement.movePiece(4, 7, 4, 4,board));
            Assert.IsFalse(Movement.movePiece(4, 4, 6, 4,board)); 
            Assert.IsFalse(Movement.movePiece(6, 4, 4, 4,board));
            Assert.IsFalse(Movement.movePiece(4, 4, 8, 4,board));
            Assert.IsTrue(Movement.movePiece(4, 4, 1, 4,board)); 
            Assert.IsTrue(Movement.movePiece(1, 4, 1, 3,board));
            Assert.IsTrue(Movement.movePiece(1, 3, 2, 3,board));
            Assert.IsTrue(Movement.movePiece(2, 3, 0, 3,board));
          
        }
        [TestMethod()]
        public void moveQueenTest1()
        {
            Board board = new Board();
            ///
            Assert.IsFalse(Movement.movePiece(0, 3, -1, 3,board));
            Assert.IsFalse(Movement.movePiece(0, 3, 1, 3,board));
            Assert.IsFalse(Movement.movePiece(0, 3, 0, 2,board));
            Assert.IsFalse(Movement.movePiece(0, 3, 0, 4,board));
            Assert.IsFalse(Movement.movePiece(0, 3, -1, 2,board));
            Assert.IsFalse(Movement.movePiece(0, 3, -1, 4,board));
            Assert.IsFalse(Movement.movePiece(0, 3, 1, 2,board));
            Assert.IsFalse(Movement.movePiece(0, 3, 1, 4,board));
            Assert.IsFalse(Movement.movePiece(0, 3, -4, 3,board));
            Assert.IsFalse(Movement.movePiece(0, 3, 4, 3,board)); //failed
            Assert.IsFalse(Movement.movePiece(0, 3, 0, -1,board));
            Assert.IsFalse(Movement.movePiece(0, 3, 0, 7,board));
            Assert.IsFalse(Movement.movePiece(0, 3, -4, -1,board));
            Assert.IsFalse(Movement.movePiece(0, 3, -4, 7,board));
            Assert.IsFalse(Movement.movePiece(0, 3, 4, -1,board));
            Assert.IsFalse(Movement.movePiece(0, 3, 4, 7,board));
        }
        [TestMethod()]
        public void moveBishop1Test()
        {
            Board board = new Board();
            ///
            Assert.IsFalse(Movement.movePiece(0, 2, -1, 2,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 1, 2,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 0, 1,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 0, 3,board));
            Assert.IsFalse(Movement.movePiece(0, 2, -1, 1,board));
            Assert.IsFalse(Movement.movePiece(0, 2, -1, 3,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 1, 3,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 1, 1,board));
            Assert.IsFalse(Movement.movePiece(0, 2, -3, 2,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 0, -1,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 0, 5,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 3, 2,board));
            board.setPiece(1, 3, ' ');
            Assert.IsTrue(Movement.movePiece(0, 2, 1, 3,board));
            Assert.IsTrue(Movement.movePiece(1, 3, 2, 2,board));
            Assert.IsFalse(Movement.movePiece(2, 2, 5, 2,board));
            Assert.IsTrue(Movement.movePiece(2, 2, 5, 5,board));
            Assert.IsTrue(Movement.movePiece(5, 5, 6, 6,board));
            Assert.IsTrue(Movement.movePiece(6, 6, 5, 7,board));
           // Assert.IsFalse(Movement.movePiece(5, 7, 2, 4,board)); //fail 
            Assert.IsFalse(Movement.movePiece(5, 7, 2, 7,board));
            Assert.IsTrue(Movement.movePiece(5, 7, 0, 2,board));
            Assert.IsFalse(Movement.movePiece(0, 2, 2, 0,board));
            board.setPiece(1, 1, ' ');
            Assert.IsTrue(Movement.movePiece(0, 2, 2, 0,board));
            Assert.IsTrue(Movement.movePiece(2, 0, 3, 1,board));
            
        }
             [TestMethod()]
        public void moveKnightTest1()
        {
            Board board = new Board();
            ///
            Assert.IsFalse(Movement.movePiece(7, 6, 6, 6,board));
            Assert.IsFalse(Movement.movePiece(7, 6, 8, 6,board));
            Assert.IsFalse(Movement.movePiece(7, 6, 7, 5,board));
            Assert.IsFalse(Movement.movePiece(7, 6, 7, 7,board));
            Assert.IsFalse(Movement.movePiece(7, 6, 6, 5,board));
            Assert.IsFalse(Movement.movePiece(7, 6, 6, 7,board));
            Assert.IsFalse(Movement.movePiece(7, 6, 8, 7,board));
            Assert.IsFalse(Movement.movePiece(7, 6, 8, 5,board));
            Assert.IsFalse(Movement.movePiece(7, 6, 4, 6,board));
            Assert.IsFalse(Movement.movePiece(7, 6, 7, 3,board));
            Assert.IsFalse(Movement.movePiece(7, 6, 7, 9,board));
            Assert.IsFalse(Movement.movePiece(7, 6, 10, 6,board));
            Assert.IsTrue(Movement.movePiece(7, 6, 5, 7,board)); //Fail
            Assert.IsTrue(Movement.movePiece( 5, 7, 7, 6,board));
            Assert.IsTrue(Movement.movePiece(7,6 ,5,5,board));
            Assert.IsFalse(Movement.movePiece(5, 5, 7,4,board));
            Assert.IsTrue(Movement.movePiece(5, 5, 3, 4,board));
            Assert.IsTrue(Movement.movePiece(3, 4, 1, 3,board));
            Assert.IsTrue(Movement.movePiece(1, 3, 0, 1,board));

        }
        //[TestMethod()]
        public void blockedMoveTest()
        {
            Assert.Fail();
        }

      //  [TestMethod()]
        public void blockedDestinationTest()
        {
            Assert.Fail();
        }
    }
}