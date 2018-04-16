using System;
using NUnit.Framework;
using System.Linq;

namespace Morabaraba.Test
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void APlayerHas12Cows()
        {
            Board b = new Board();
            int OCows = b.numCows(Player.O);
            int XCows = b.numCows(Player.X);
            Assert.That(OCows == 12);
            Assert.That(XCows == 12);
        }
    }
}
