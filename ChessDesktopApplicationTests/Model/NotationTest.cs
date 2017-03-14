using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessDesktopApplication.Model;

namespace ChessDesktopApplicationTests.Model
{
    [TestClass]
    public class NotationTest
    {
        [TestMethod()]
        public void IndexToChessNotationTest()
        {
            Assert.AreEqual("a8",Notation.IndexToChessNotation(0,0));
            Assert.AreEqual("h1", Notation.IndexToChessNotation(7, 7));
            Assert.AreEqual("a1", Notation.IndexToChessNotation(7, 0));
            Assert.AreEqual("h8", Notation.IndexToChessNotation(0, 7));
            Assert.AreEqual("d4", Notation.IndexToChessNotation(4, 3));
        
        }
        [TestMethod()]
        public void ChessToIndexNotationTest()
        {
            
            Assert.AreEqual(Notation.ChessToIndexNotation("a8"), "00");
            Assert.AreEqual(Notation.ChessToIndexNotation("h1"), "77");
            Assert.AreEqual(Notation.ChessToIndexNotation("a1"), "70");
            Assert.AreEqual(Notation.ChessToIndexNotation("h8"), "07");
            Assert.AreEqual(Notation.ChessToIndexNotation("d4"), "43");
 
        }
    }
}
