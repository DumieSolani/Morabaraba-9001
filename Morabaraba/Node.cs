using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    class Node : INode
    {
        private Player state;
        public Player getState => state;
        public Node()//The Player is primarily not assigned hence, None 
        { state = Player.None; }
        public void changeState(Player changedState)//Store the recently changed states in the Game State.
        { state = changedState; }
    }
}
