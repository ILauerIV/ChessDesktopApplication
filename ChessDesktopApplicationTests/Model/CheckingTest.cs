using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessDesktopApplication.Model;

namespace ChessDesktopApplicationTests.Model
{
    [TestClass]
    public class CheckingTest
    {
        [TestMethod]
        public void SimpleCheckingTest()
        {
            Board b = new Board();
            b.setPiece(1, 4, b.getPiece(7,0));
         
            Assert.IsTrue(Checking.isChecked(b, false)); 
        }

        [TestMethod]
        public void RealWorldCheckingTest()
        {
            Board b = new Board();
            b.clearBoard();
            b.setPiece(5, 3,'♔');
            b.setPiece(3, 7,'♚');
            b.setPiece(7, 7, '♖');
            Assert.IsTrue(Checking.isChecked(b, false));
        }
        [TestMethod]
        public void NoCheckCheckingTest()
        {
            Board b = new Board();
            
            Assert.IsFalse(Checking.isChecked(b, false));
        }
    }
}
