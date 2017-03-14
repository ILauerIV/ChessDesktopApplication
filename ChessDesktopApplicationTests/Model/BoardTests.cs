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
        
       
    }
}