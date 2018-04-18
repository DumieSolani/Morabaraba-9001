using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Node : INode
    {
        private Player state;
        public Player getState => state;
        public Node(Player initialState)//The Player is primarily not assigned hence, None 
        { state = initialState; }
        public void changeState(Player changedState)//Store the recently changed states in the Game State.
        { state = changedState; }
    }
}
