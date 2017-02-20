﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Movement move = new Movement(board);
            Assert.IsFalse(move.movePiece(7, 3, 4, 4)); 
            Assert.IsFalse(move.movePiece(7, 3, 6, 3));// move forward with piece in front
            Assert.IsFalse(move.movePiece(7, 3, 7, 2));// move right with piece in the way
            Assert.IsFalse(move.movePiece(7, 3, 8, 3));//move backwards off the board
            Assert.IsFalse(move.movePiece(7, 3, 7, 4));// move left with piece in way
            Assert.IsFalse(move.movePiece(7, 3, 6, 4));
            Assert.IsFalse(move.movePiece(7, 3, 6, 2));
            board.setPiece(6, 3, ' ');
            Assert.IsTrue(move.movePiece(7, 3, 6, 3));// forward
            Assert.IsTrue(move.movePiece(6, 3, 7, 3));// back
            Assert.IsTrue(move.movePiece(7, 3, 6, 3));// foward
            Assert.IsTrue(move.movePiece(6, 3, 5, 4));// forward right
            Assert.IsTrue(move.movePiece(5, 4, 5, 3));// left
            Assert.IsTrue(move.movePiece(5, 3, 5, 4));// right
            Assert.IsTrue(move.movePiece(5, 4, 4, 3));// forward
            Assert.IsTrue(move.movePiece(4, 3, 5, 2));
            Assert.IsTrue(move.movePiece(5, 2, 4, 3));

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
            Movement move = new Movement(board);
            Assert.IsFalse(move.movePiece(0, 3, 0, 4));
            Assert.IsFalse(move.movePiece(0, 3, -1, 4));
            Assert.IsFalse(move.movePiece(0, 3, 1, 4));
            Assert.IsFalse(move.movePiece(0, 3, 1,5 ));
            Console.OutputEncoding = System.Text.Encoding.Unicode;

           
            Assert.IsFalse(move.movePiece(0, 3, 4, 4)); 
            Assert.IsFalse(move.movePiece(0, 3, 0, 5));
            Assert.IsFalse(move.movePiece(0, 3, 0, 3));
            board.setPiece(1, 4, ' ');
            Assert.IsTrue(move.movePiece(0, 3, 1,4)); //failed
            Assert.IsTrue(move.movePiece(1, 4, 0, 5));
            Assert.IsTrue(move.movePiece(0, 3, 4, 5));
            Assert.IsTrue(move.movePiece(4, 3, 4, 0));
            Assert.IsTrue(move.movePiece(4, 0, 4, 7));
            Assert.IsTrue(move.movePiece(4, 7, 4, 4));
            Assert.IsTrue(move.movePiece(4, 4, 6, 6));
            Assert.IsTrue(move.movePiece(6, 6, 4, 4));
            Assert.IsFalse(move.movePiece(4, 4, 7, 4));
            Assert.IsTrue(move.movePiece(4, 4, 6, 2));
            Assert.IsTrue(move.movePiece(6, 2, 2, 2));
        }

        [TestMethod()]
        public void moveKnightTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void movePawnTest()
        {
            Board board = new Board();
            Movement move = new Movement(board);
            Assert.IsFalse(move.movePiece(1, 5, 0, 5));
            Assert.IsFalse(move.movePiece(1, 5, -1, 5));
            Assert.IsFalse(move.movePiece(1, 5, 1, 4));
            Assert.IsFalse(move.movePiece(1, 5, 1, 6));
            Assert.IsFalse(move.movePiece(1, 5, 5, 5));  
            Assert.IsFalse(move.movePiece(1, 5, 1, 6));
            Assert.IsFalse(move.movePiece(1, 5, 1,4));
            Assert.IsTrue(move.movePiece(1, 5, 2, 5)); //failed
            Assert.IsTrue(move.movePiece(2, 5, 3, 5));
            Assert.IsFalse(move.movePiece(3, 5, 5, 4));
            Assert.IsFalse(move.movePiece( 3, 5,2, 5));
        }
        public void moveKingTest1()
        {
            Board board = new Board();
            Movement move = new Movement(board);
            Assert.IsFalse(move.movePiece(7, 3, 6, 3));
            Assert.IsFalse(move.movePiece(7, 3, 8, 3));
            Assert.IsFalse(move.movePiece(7, 3, 7, 2));
            Assert.IsFalse(move.movePiece(7, 3, 7, 4));
            Assert.IsFalse(move.movePiece(7, 3, 6, 2));
            Assert.IsFalse(move.movePiece(7, 3, 6, 4));
            Assert.IsFalse(move.movePiece(7, 3, 8, 4));
            Assert.IsFalse(move.movePiece(7, 3, 8, 2));
            Assert.IsFalse(move.movePiece(7, 3, 4, 3));
            Assert.IsFalse(move.movePiece(7, 3, 7, 0));
            Assert.IsFalse(move.movePiece(7, 3, 7, 6));
            Assert.IsFalse(move.movePiece(7, 3, 10, 3));
            board.setPiece(4, 5, ' ');
            Assert.IsTrue(move.movePiece(7, 3, 6, 3));
            Assert.IsTrue(move.movePiece(6, 3, 5, 3));
            Assert.IsFalse(move.movePiece(5, 3, 0, 0));
            Assert.IsTrue(move.movePiece(5, 3, 5, 2));
            Assert.IsTrue(move.movePiece(5, 2, 5, 3));
            Assert.IsTrue(move.movePiece(5, 3, 6, 3));
            Assert.IsTrue(move.movePiece(6, 3, 5, 3));
            Assert.IsTrue(move.movePiece(5, 3, 4, 2));
            Assert.IsTrue(move.movePiece(4, 2, 5, 3));
            Assert.IsTrue(move.movePiece(5, 3, 4, 4));
            Assert.IsTrue(move.movePiece(4, 4, 5, 3));
            Assert.IsFalse(move.movePiece(5, 3, 5, 1));
            Assert.IsFalse(move.movePiece(5, 3, 5, 5));
            Assert.IsFalse(move.movePiece(5, 3, 7, 3));
            Assert.IsFalse(move.movePiece(5, 3, 3, 3));
            Assert.IsFalse(move.movePiece(5, 3, 3, 1));
            Assert.IsFalse(move.movePiece(5, 3, 7, 5));
            Assert.IsFalse(move.movePiece(5, 3, 3, 5));
            Assert.IsFalse(move.movePiece(5, 3, 7, 1));
            Assert.IsTrue(move.movePiece(5, 3, 4, 3));
        }
        [TestMethod()]
        public void moveBishopTest()
        {
            Board board = new Board();
            Movement move = new Movement(board);
            Assert.IsFalse(move.movePiece(0, 2, -1, 2));
            Assert.IsFalse(move.movePiece(0, 2, 1, 2));
            Assert.IsFalse(move.movePiece(0, 2, 0, 1));
            Assert.IsFalse(move.movePiece(0, 2, 0, 3));
            Assert.IsFalse(move.movePiece(0, 2, -1, 1));
            Assert.IsFalse(move.movePiece(0, 2, -1, 3));
            Assert.IsFalse(move.movePiece(0, 2, 1, 1));
            Assert.IsFalse(move.movePiece(0, 2, 1, 3));
            Assert.IsFalse(move.movePiece(0, 2, -4, 2));
            Assert.IsFalse(move.movePiece(0, 2, 4, 2));
            Assert.IsFalse(move.movePiece(0, 2, 0, -2));
            Assert.IsFalse(move.movePiece(0, 2, 0, 6));
            Assert.IsFalse(move.movePiece(0, 2, -4, -2));
            Assert.IsFalse(move.movePiece(0, 2, -4, 6));
            Assert.IsFalse(move.movePiece(0, 2, 4, -2));
            Assert.IsFalse(move.movePiece(0, 2, 4, 6));
            board.setPiece(2, 1, ' ');
            board.setPiece(2, 3, ' ');
            Assert.IsTrue(move.movePiece(0, 2, 2, 0));
            Assert.IsTrue(move.movePiece(2, 0, 0, 2));
            Assert.IsTrue(move.movePiece(0, 2, 2, 0));
            Assert.IsTrue(move.movePiece(2, 0, 5, 3));
            Assert.IsTrue(move.movePiece(5, 3, 6, 2));
            Assert.IsTrue(move.movePiece(6, 2, 4, 0));
            Assert.IsFalse(move.movePiece(4, 0, 3, 0));
            Assert.IsFalse(move.movePiece(4, 0, 5, 0));
        }
        [TestMethod()]
        public void moveRookTest()
        {
            Board board = new Board();
            Movement move = new Movement(board);
            Assert.IsFalse(move.movePiece(7, 7, 6, 7));
            Assert.IsFalse(move.movePiece(7, 7, 8, 7));
            Assert.IsFalse(move.movePiece(7, 7, 7, 6));
            Assert.IsFalse(move.movePiece(7, 7, 7, 8));
            Assert.IsFalse(move.movePiece(7, 7, 6, 6));
            Assert.IsFalse(move.movePiece(7, 7, 6, 8));
            Assert.IsFalse(move.movePiece(7, 7, 8, 6));
            Assert.IsFalse(move.movePiece(7, 7, 8, 8));
            Assert.IsFalse(move.movePiece(7, 7, 3, 7));
            Assert.IsFalse(move.movePiece(7, 7, 11, 7));
            Assert.IsFalse(move.movePiece(7, 7, 7, 3));
            Assert.IsFalse(move.movePiece(7, 7, 7, 11));
            Assert.IsFalse(move.movePiece(7, 7, 3, 3));
            Assert.IsFalse(move.movePiece(7, 7, 3, 11));
            Assert.IsFalse(move.movePiece(7, 7, 11, 3));
            Assert.IsFalse(move.movePiece(7, 7, 11, 11));
            board.setPiece(6, 7, ' ');
            Assert.IsTrue(move.movePiece(7, 7, 4, 7));
            Assert.IsTrue(move.movePiece(4, 7, 4, 4));
            Assert.IsFalse(move.movePiece(4, 4, 3, 3));
            Assert.IsFalse(move.movePiece(4, 4, 3, 5));
            Assert.IsFalse(move.movePiece(4, 4, 5, 3));
            Assert.IsFalse(move.movePiece(4, 4, 5, 5));
            Assert.IsFalse(move.movePiece(4, 4, 0, 0));
            Assert.IsFalse(move.movePiece(4, 4, 0, 8));
            Assert.IsFalse(move.movePiece(4, 4, 8, 0));
            Assert.IsFalse(move.movePiece(4, 4, 8, 8));
            Assert.IsTrue(move.movePiece(4, 4, 4, 7));
            Assert.IsTrue(move.movePiece(4, 7, 4, 4));
            Assert.IsFalse(move.movePiece(4, 4, 6, 4)); 
            Assert.IsFalse(move.movePiece(6, 4, 4, 4));
            Assert.IsFalse(move.movePiece(4, 4, 8, 4));
            Assert.IsTrue(move.movePiece(4, 4, 1, 4)); 
            Assert.IsTrue(move.movePiece(1, 4, 1, 3));
            Assert.IsTrue(move.movePiece(1, 3, 2, 3));
            Assert.IsTrue(move.movePiece(2, 3, 0, 3));
          
        }
        [TestMethod()]
        public void moveQueenTest1()
        {
            Board board = new Board();
            Movement move = new Movement(board);
            Assert.IsFalse(move.movePiece(0, 3, -1, 3));
            Assert.IsFalse(move.movePiece(0, 3, 1, 3));
            Assert.IsFalse(move.movePiece(0, 3, 0, 2));
            Assert.IsFalse(move.movePiece(0, 3, 0, 4));
            Assert.IsFalse(move.movePiece(0, 3, -1, 2));
            Assert.IsFalse(move.movePiece(0, 3, -1, 4));
            Assert.IsFalse(move.movePiece(0, 3, 1, 2));
            Assert.IsFalse(move.movePiece(0, 3, 1, 4));
            Assert.IsFalse(move.movePiece(0, 3, -4, 3));
            Assert.IsFalse(move.movePiece(0, 3, 4, 3)); //failed
            Assert.IsFalse(move.movePiece(0, 3, 0, -1));
            Assert.IsFalse(move.movePiece(0, 3, 0, 7));
            Assert.IsFalse(move.movePiece(0, 3, -4, -1));
            Assert.IsFalse(move.movePiece(0, 3, -4, 7));
            Assert.IsFalse(move.movePiece(0, 3, 4, -1));
            Assert.IsFalse(move.movePiece(0, 3, 4, 7));
        }

        [TestMethod()]
        public void blockedMoveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void blockedDestinationTest()
        {
            Assert.Fail();
        }
    }
}