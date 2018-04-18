using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morabaraba
{
    public class Referee: IReferee
    {
        //Symbolic of the DARK Player
        private IPlayer player1 = new GamePlayer(Player.X);
        //Symbolic of the LIGHT Player
        private IPlayer player2 = new GamePlayer(Player.O);
        //This is the gameBoard on which the referee is working on
        private IBoard gameBoard = new Board();
        //To check if whether game is now in placement phase
        public bool isInMovingPhase = false;
      
        
        public void placingPhase()
        {
            //The following code tests if the player is in the placement phase
            IPlayer currPlayer = player1;
            while (currPlayer.Cows > 0)
            {
                //The following code sets the PlayerPhase to Placing
             
                gameBoard.drawBoard();
                gameBoard.Place(currPlayer);
               
                //Short construct for an if else method...
                currPlayer = currPlayer == player1 ? player2 : player1;                
            }
        }

        public void movingPhase()
        {
            IPlayer currentPlayer = player1;
            while (true)
            {
                //This says that the Player is now in the Movement Phase.
                isInMovingPhase = !isInMovingPhase; 

                gameBoard.drawBoard();
                //When a player has only three cows remaining, desperate measures are
                //called for. This player's cows are allowed to "fly" to any empty intersection,
                //not just adjacent ones.
                //If one player has three cows and the other player has more than three cows, 
                //only the player with three cows is allowed to fly
                //The code below if for the cow that is in the fly phase of the game.
                if (currentPlayer.Cows == 3)
                    currentPlayer.makeFlying();

                //A win occurs if one opponent has no moves
                //A win occurs if a player has just two cows
                //If either player has only three cows and neither player shoots a cow within ten moves, the game is drawn
                //If one person cheats, then the other one wins by default
                //The code below checks if an opponent has got or has got not moves at all

                if (gameBoard.numCows(Player.X) < 3 || !gameBoard.canPlay(player1))
                {
                    Console.WriteLine("Y has won the Game......Congradulations to PLAYER Y!!");
                    break;
                }
                if (gameBoard.numCows(Player.O) < 3 || !gameBoard.canPlay(player2))
                {
                    Console.WriteLine("X has won the Game......Congradulations to PLAYER X!");
                    break;
                }
                gameBoard.Move(currentPlayer);
                //Shorter construct for an if else method....
                currentPlayer = currentPlayer == player1 ? player2 : player1;              
            }
        }
    }
}
