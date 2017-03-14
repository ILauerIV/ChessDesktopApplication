using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessDesktopApplication.Model;
using System.Collections.Generic;

namespace ChessDesktopApplicationTests.Model
{
    [TestClass]
    public class PiecePositionTest
    {
        [TestMethod]
        public void getAllBlacksTest()
        {
            Board b = new Board();
            List<PiecePosition> l = PiecePosition.getAllBlack(b);
            Assert.AreEqual(l.Count, 16); 
        }
        [TestMethod]
        public void getAllWhitesTest()
        {
            Board b = new Board();
            List<PiecePosition> l = PiecePosition.getAllWhite(b);
            Assert.AreEqual(l.Count, 16);
        }
    }
}
