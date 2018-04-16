using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morabaraba
{
    public class GamePlayer : IPlayer
    {
        public GamePlayer(Player player)
        {
            gameplayer = player;//Assign given player to the gamePlayer
            numCows = 12;//These are the initial Number of Cows the Player starts with.

        }
        public Player getOpponent()
        {
            if (gameplayer == Player.X)
                return Player.O;
            return Player.X;

        }

        private int numCows;
        private bool flying = false;
        public Player playerID => gameplayer;

        public void makeFlying()
        {
            flying = true;
        }
        public bool isFlying()
        {
            return flying;
        }

        private Player gameplayer;

        public int Cows => numCows;

        public void reduceNumCows()
        { numCows--; }

        public string getMove(string prompt)
        {
            string input;

            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine().ToUpper();
                if (Board.validPositions.Contains(input))
                    break;
                Console.WriteLine("Hello there, you have entered an invalid position!!!");
            }
            return input;
        }
    }
}
