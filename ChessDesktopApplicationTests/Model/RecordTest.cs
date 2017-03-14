using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessDesktopApplication.Model;

namespace ChessDesktopApplicationTests.Model
{
    [TestClass]
    public class RecordTest
    {
        [TestMethod]
        public void BasicTest()
        {
            Record r = new Record();
            r.recordTurn(6, 2, 4, 2, '♙', ' ');
            r.recordTurn(1, 2, 3, 2, '♟', ' ');
            r.recordTurn(6, 1, 4, 1, '♙', ' ');
            r.recordTurn(3, 2, 4, 1, '♟', '♙');
            Assert.AreEqual(r.getLastTurn().move, "♟xb4");
        }
    }
}
