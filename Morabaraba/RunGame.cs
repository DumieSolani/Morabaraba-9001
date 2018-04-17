using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morabaraba
{
    public class RunGame
    {
        static void Main(string[] args) // entry point
        {
            Console.WriteLine("Player X starts playing the game. Each player has 12 cows to place on the Board");

            //Placing the cows
            //The board is empty when the game begins.Each player has 12 pieces, known as "cows"; one player has light cows and the other has dark cows
            //The player with the dark cows moves first
            //Each turn consists of placing a cow on an empty intersection on the board            

            IReferee theRef = new Referee();
            theRef.placingPhase();

            //Moving the cows
            //After all the cows have been placed, each turn consists of moving a cow to an empty adjacent intersection
            //As before, completing a mill allows a player to shoot one of the opponent's cows. Again, this must be a cow which is not in a mill, unless all of the opponent's cows are in mills.
            //Players are allowed to "break" their own mills

            Console.WriteLine("The current player is now currently in the moving phase!");
            theRef.movingPhase();

            //The test to check if the game has ended is in another object.

            Console.ReadLine();
        }
    }
}
