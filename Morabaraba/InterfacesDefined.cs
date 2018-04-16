using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morabaraba
{

 
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Hello World!");
    //    }
    //}

    
}
public class invalidMoveException : ApplicationException { }
public enum Player { X, O, None }

public interface IBoard
{   //Method to Shoot for the Player with the cows that have formed a mill
    void Shoot(IPlayer player);
    //Method to get the neighbouring positions.
    List<INode> getNeighbours(string getPosition);
    INode getCell(string getPosition);
    //Property which list's the total number of cows
    int numCows(Player player);
    bool allInMill(Player player);
    void drawBoard();//draw gameBoard
    bool canPlay(IPlayer player);
    //Method which Places the COWS onto the Board
    void Place(IPlayer player);
    //Method to move cows from on position to the other 
    void Move(IPlayer player);
    //Check Movability
    bool isMovable(string getPosition);
    //Check if the Cow is in a Mill position
    bool isInMill(string getPosition);

}


public interface IPlayer
{
    Player playerID { get; }
    string getMove(string prompt);
    Player getOpponent();
    int Cows { get; }
    void reduceNumCows();
    bool isFlying();
    void makeFlying();
}
public interface INode
{
    Player getState { get; }
    void changeState(Player changedState);
}
public interface IReferee
{
    //This is where the game starts initially
    void placingPhase();
    //Phase following the Placement phase where the entities move adjacently if position is unoccupied.
    void movingPhase();
}

public class Node : INode
{
    private Player state;
    public Player getState => state;
    public Node()//The Player is primarily not assigned hence, None 
    { state = Player.None; }
    public void changeState(Player changedState)//Store the recently changed states in the Game State.
    { state = changedState; }
}