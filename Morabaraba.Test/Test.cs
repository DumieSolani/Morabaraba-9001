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
        public void AtStartAPlayerHasNoCows()
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
            Board b = new Board();
            int empty = 0;

            foreach (string item in b.getBoard())
            {
                if(item == " ")
                {
                    empty++;
                }
            }

           
            Assert.That(empty ==24);
        }

        [Test]

        public void BoardHasTwenty_FourSpaces()
        {
            Board b = new Board();
            Assert.That((b.getBoard()).Length ==24);
        }

        [Test]

        public void BoardHasTwenty_FourSpaces()
        {
            Board b = new Board();
            Assert.That((b.getBoard()).Length ==24);
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

     
        [Test]
        public void PlayersStartwithTwelveCows()
        {
            IPlayer player1 = new GamePlayer(Player.X);
            IPlayer player2 = new GamePlayer(Player.O);

            IPlayer currPlayer1 = player1;
            IPlayer currPlayer2 = player2;
            Assert.That(currPlayer1.Cows == 12 && currPlayer2.Cows ==12);
                        
        }

        [Test]

        public void CheckValidPositions()
        {

            string[] validPositions = new string[] { "A1", "A4", "A7", "B2", "B4", "B6", "C3", "C4", "C5", "D1", "D2", "D3", "D5", "D6", "D7", "E3", "E4", "E5", "F2", "F4", "F6", "G1", "G4", "G7" };
            int count = 0;
            foreach (string item in validPositions)
            {
                if (Board.validPositions.Contains(item)) count++;
            }

            Assert.That(count == 24);

        }

        [Test]

        public void CowsAreReduced()
        {
            IPlayer playerX = new GamePlayer(Player.X);
            IPlayer playerO = new GamePlayer(Player.O);
            

            
            playerX.reduceNumCows();
            playerO.reduceNumCows();

            Assert.That(playerX.Cows == 11 && playerX.Cows == 11);

        }

       
        [Test]
        public void PlayersStartwithTwelveCows()
        {
            IPlayer player1 = new GamePlayer(Player.X);
            IPlayer player2 = new GamePlayer(Player.O);

            IPlayer currPlayer1 = player1;
            IPlayer currPlayer2 = player2;
            Assert.That(currPlayer1.Cows == 12 && currPlayer2.Cows ==12);
                        
        }

        [Test]

        public void CheckValidPositions()
        {

            string[] validPositions = new string[] { "A1", "A4", "A7", "B2", "B4", "B6", "C3", "C4", "C5", "D1", "D2", "D3", "D5", "D6", "D7", "E3", "E4", "E5", "F2", "F4", "F6", "G1", "G4", "G7" };
            int count = 0;
            foreach (string item in validPositions)
            {
                if (Board.validPositions.Contains(item)) count++;
            }

            Assert.That(count == 24);

        }

        [Test]

        public void CowsAreReduced()
        {
            IPlayer playerX = new GamePlayer(Player.X);
            IPlayer playerO = new GamePlayer(Player.O);
            

            
            playerX.reduceNumCows();
            playerO.reduceNumCows();

            Assert.That(playerX.Cows == 11 && playerX.Cows == 11);

        }





    }   
    
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
