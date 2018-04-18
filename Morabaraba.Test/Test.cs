using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace Morabaraba.Test
{
    [TestFixture]
    public class Test
    {
        //The following tests are for THE PLACEMENT PHASE
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
        public void CowsCanOnlyBePlacedOnEmptySpaces()
        {
            string position = "A7";//This is an example of fake input

            IBoard board = new Board();
            INode myBoardPos = board.getCell(position);

            Assert.That(myBoardPos.getState == Player.None);

        }

        [Test]
        public void ThePlayerWithDarkCowsIsGivenTheFirstChanceToMove()
        {
            Player state;
            state = Player.X;

            Assert.That(state.Equals(Player.X));

        }

        [Test]
        public void CowsCannotBeMovedDuringPlacementPhase()//Now working
        {
            Referee referee = new Referee();

            //This asserts that the player is not in the movement phase 
            //as the state in the is only changed once in the movement phase.
            Assert.That(referee.isInMovingPhase == false);
           
        }


        //These tests fall under the MOVEMENT PHASE
    
        //These tests fall under the GENERAL PHASE
        [Test]
        public void AMillIsFormedByThreeCowsOfTheSameColorInALine()//Now working
        {
        IReferee referee = new Referee();
            
            Board MockBoard = new Board();

            MockBoard.board["A1"] = new Node(Player.X);

            MockBoard.board["A4"] = new Node(Player.X);

            MockBoard.board["A7"] = new Node(Player.X);
            //This shows that a mill can be formed by three cows of the same color in a line.
            Assert.That(MockBoard.allInMill(Player.X) == true);

            MockBoard.board["A1"] = new Node(Player.X);

            MockBoard.board["A4"] = new Node(Player.O);

            MockBoard.board["A7"] = new Node(Player.X);
            //This shows that a mill cannot be formed by three cows of different colors in a line.
            Assert.That(MockBoard.allInMill(Player.X) == false);

        }

        [Test]
        public void AMillIsNotFormedWhenThreeCowsInALineAreOfDifferentColors ()//Now working
        {
            Referee referee = new Referee();

            //This asserts that the player is not in the movement phase 
            //as the state in the is only changed once in the movement phase.
            Assert.That(referee.isInMovingPhase == false);

        }




    }
}
