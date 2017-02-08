using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessDesktopApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDesktopApplication.Model.Tests
{
    [TestClass()]
    public class BoardTests
    {
        [TestMethod()]
        public void IndexToChessNotationTest()
        {
            Assert.AreEqual("a8",Board.IndexToChessNotation(0,0));
            Assert.AreEqual("h1", Board.IndexToChessNotation(7, 7));
            Assert.AreEqual("a1", Board.IndexToChessNotation(7, 0));
            Assert.AreEqual("h8", Board.IndexToChessNotation(0, 7));
            Assert.AreEqual("d4", Board.IndexToChessNotation(4, 3));
        }

        [TestMethod()]
        public void getPieceTest()
        {
            Board board = new Board();
            Assert.AreEqual('♖', board.getPiece(7, 0));
            Assert.AreEqual(' ', board.getPiece(5, 6));
            Assert.AreEqual('♜', board.getPiece(0, 0));
            Assert.AreEqual('♟', board.getPiece(1, 5));

        }


      

        [TestMethod()]
        public void setPieceTest()
        {
            Board board = new Board();
            board.setPiece(5, 5, '♟');
            board.setPiece(7, 3, '♟');
       
            Assert.AreEqual('♟', board.getPiece(7, 3));
            Assert.AreEqual('♟', board.getPiece(5, 5));
            Assert.AreEqual('♟', board.getPiece(7, 3));
        }

  

        [TestMethod()]
        public void movePieceTest()
        {
            Board board = new Board();
            board.movePiece("73", "04");
         
            Assert.AreEqual(' ', board.getPiece(7, 3));
            Assert.AreEqual('♕', board.getPiece(0, 4));

        }

        [TestMethod()]
        public void ChessToIndexNotationTest()
        {
            Assert.AreEqual(Board.ChessToIndexNotation("a8"), "00");
            Assert.AreEqual(Board.ChessToIndexNotation("h1"), "77");
            Assert.AreEqual(Board.ChessToIndexNotation("a1"), "70");
            Assert.AreEqual(Board.ChessToIndexNotation("h8"), "07");
            Assert.AreEqual(Board.ChessToIndexNotation("d4"), "43");
        }
    }
}