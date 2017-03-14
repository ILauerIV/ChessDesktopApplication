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
            b.setPiece(1,4, '♖');
           Assert.IsTrue (Checking.isChecked(b, true)); 
        }
        [TestMethod]
        public void NoCheckCheckingTest()
        {
            Board b = new Board();
            
            Assert.IsFalse(Checking.isChecked(b, false));
        }
    }
}
