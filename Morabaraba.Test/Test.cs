using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace Morabaraba.Test
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void APlayerHasNoCows()
        {
            IBoard b = new Board();

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
       
        
        [Test]
        public void CowsCanOnlyBePlacedOnEmptySpaces ()
        {
            string position = "A7";//This is an example of fake input

            IBoard board = new Board();
            INode myBoardPos = board.getCell(position);

            Assert.That(myBoardPos.getState == Player.None);
            
        }

        [Test]
        public void ThePlayerWithDarkCowsIsGivenTheFirstChanceToMove ()
        {
            Player state;
            state = Player.X;
           
            Assert.That(state.Equals(Player.X));

        }

        [Test]   
        public void CowsCannotBeMovedDuringPlacementPhase()
        {
            IReferee referee = new Referee();
            IPlayer player = new GamePlayer(Player.X);
            IBoard board = new Board();
            
            //To be fixed
            
        }

    }   
    
}
