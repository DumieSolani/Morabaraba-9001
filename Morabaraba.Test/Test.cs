using System;
using NUnit.Framework;
using System.Linq;

namespace Morabaraba.Test
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void APlayerHasNoCows()
        {
            Board b = new Board();
            int OCows = b.numCows(Player.O);
            int XCows = b.numCows(Player.X);
            Assert.That(OCows == 0);
            Assert.That(XCows == 0);
        }

        [Test]
        public void EmptyBoard()
        {
            string[] Board = { };

            Assert.That(Board.Length == 0);
        }
    }
}
