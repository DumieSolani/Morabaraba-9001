using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Morabaraba
{

    public class Board : IBoard
    {
        public void drawBoard()
        {
            Console.Clear();

            string[] GameBoard = board.Values.Select(cell => playerToString(cell.getState)).ToArray();

            string theGameBoard =
                 $@"
                                                                    1   2   3   4   5   6   7
                                                                a   {GameBoard[0]}-----------{GameBoard[1]}-----------{GameBoard[2]}
                                                                    | \         |         / |
                                                                b   |   {GameBoard[3]}-------{GameBoard[4]}-------{GameBoard[5]}   |
                                                                    |   | \     |     / |   |
                                                                c   |   |   {GameBoard[6]}---{GameBoard[7]}---{GameBoard[8]}   |   |
                                                                    |   |   |       |   |   |
                                                                d   {GameBoard[9]}---{GameBoard[10]}---{GameBoard[11]}       {GameBoard[12]}---{GameBoard[13]}---{GameBoard[14]}
                                                                    |   |   |       |   |   |
                                                                e   |   |   {GameBoard[15]}---{GameBoard[16]}---{GameBoard[17]}   |   |
                                                                    |   | /     |     \ |   |
                                                                f   |   {GameBoard[18]}-------{GameBoard[19]}-------{GameBoard[20]}   |
                                                                    | /         |         \ |
                                                                g   {GameBoard[21]}-----------{GameBoard[22]}-----------{GameBoard[23]}
            ";

            Console.WriteLine(theGameBoard);
        }


        public static string[] validPositions = new string[] { "A1", "A4", "A7", "B2", "B4", "B6", "C3", "C4", "C5", "D1", "D2", "D3", "D5", "D6", "D7", "E3", "E4", "E5", "F2", "F4", "F6", "G1", "G4", "G7" };

        public static Dictionary<string, List<string>> neighbouringCells = new Dictionary<string, List<string>> {
            { "A1", new List<string> { "A4", "D1", "B2" } },
            { "A4", new List<string> { "A1", "B4", "A7" } },
            { "A7", new List<string> { "A4", "B6", "D7" } },
            { "B2", new List<string> { "A1", "D2", "C3", "B4" } },
            { "B4", new List<string> { "B2", "A4", "C4", "B6" } },
            { "B6", new List<string> { "B4", "C5", "D6", "A7" } },
            { "C3", new List<string> { "B2", "C4", "D3" } },
            { "C4", new List<string> { "C3", "B4", "C5" } },
            { "C5", new List<string> { "C4", "D5", "B6" } },
            { "D1", new List<string> { "A1", "G1", "D2" } },
            { "D2", new List<string> { "D1", "F2", "D3", "B2" } },
            { "D3", new List<string> { "D2", "E3", "C3" } },
            { "D5", new List<string> { "E5", "D6", "C5" } },
            { "D6", new List<string> { "D5", "F6", "D7", "B6" } },
            { "D7", new List<string> { "D6", "G7", "A7" } },
            { "E3", new List<string> { "F2", "E4", "D3" } },
            { "E4", new List<string> { "E3", "F4", "E5" } },
            { "E5", new List<string> { "E4", "F6", "D5" } },
            { "F2", new List<string> { "G1", "F4", "E3", "D2" } },
            { "F4", new List<string> { "F2", "G4", "F6", "E4" } },
            { "F6", new List<string> { "F4", "G7", "D6", "E5" } },
            { "G1", new List<string> { "D1", "G4", "F2" } },
            { "G4", new List<string> { "G1", "F4", "G7" } },
            { "G7", new List<string> { "G4", "F6", "D7" } }
        };

        public Dictionary<string, INode> board = new Dictionary<string, INode>();

        public Board()
        {
            foreach (string pos in validPositions)//initialising board with empty values
            {
                board.Add(pos, new Node());
            }
        }

        public int numCows(Player player)
        {
            IEnumerable<INode> query =
                from cell in board.Values.ToList()
                where cell.getState == player
                select cell;
            return query.Count();
        }

        public INode getCell(string pos)
        {
            return board[pos];
        }

        public List<INode> getNeighbours(string pos)
        {
            List<INode> neighbourList = new List<INode>();
            foreach (string npos in neighbouringCells[pos])
            {
                neighbourList.Add(getCell(npos));
            }
            return neighbourList;
        }

        public static List<string[]> mills = new List<string[]>
        {
            new string[] {"A1", "A4", "A7"},
            new string[] {"B2", "B4", "B6"},
            new string[] {"C3", "C4", "C5"},
            new string[] {"D1", "D2", "D3"},
            new string[] {"D5", "D6", "D7"},
            new string[] {"E3", "E4", "E5"},
            new string[] {"F2", "F4", "F6"},
            new string[] {"G1", "G4", "G7"},
            new string[] {"A1", "D1", "G1"},
            new string[] {"B2", "D2", "F2"},
            new string[] {"C3", "D3", "E3"},
            new string[] {"A4", "B4", "C4"},
            new string[] {"E4", "F4", "G4"},
            new string[] {"C5", "D5", "E5"},
            new string[] {"B6", "D6", "F6"},
            new string[] {"A7", "D7", "G7"},
            new string[] {"A1", "B2", "C3"},
            new string[] {"G1", "F2", "E3"},
            new string[] {"G7", "F6", "E5"},
            new string[] { "A7", "B6", "C5"}
        };

        public void Place(IPlayer player)
        {
            string placePos;
            while (true)
            {
                placePos = player.getMove("Select position to place your piece: ");
                if (board[placePos].getState == Player.None)
                {
                    break;
                }
                Console.WriteLine("Please select a valid position");
            }
            board[placePos].changeState(player.playerID);
            player.reduceNumCows();
            if (isInMill(placePos))
                Shoot(player);
        }

        public void Move(IPlayer player)
        {
            string piecePos, placePos;
            while (true)
            {
                piecePos = player.getMove("Current player, Please select piece to move an enter it here: ");
                if (board[piecePos].getState == player.playerID)
                {
                    if (player.isFlying() || isMovable(piecePos))
                        break;
                }
                drawBoard();
                Console.WriteLine("You have entered an invalid Move. Please select your move again:");
            }

            while (true)
            {
                placePos = player.getMove("Current Player, Please Select the position to place the cow " + piecePos + ": ");
                if ((player.isFlying() || neighbouringCells[piecePos].Contains(placePos)) && board[placePos].getState == Player.None)
                {
                    break;
                }
                drawBoard();
                Console.WriteLine("Player, You have entered and invalid Move. Please play again and place correct move");
            }

            board[placePos].changeState(board[piecePos].getState);
            board[piecePos].changeState(Player.None);
            if (isInMill(placePos))
            {
                drawBoard();
                Shoot(player);
            }
        }

        public void Shoot(IPlayer player)
        {
            string shootPos;
            while (true)
            {
                shootPos = player.getMove("Current Player, Please Select piece to shoot: ");
                if (board[shootPos].getState == player.getOpponent() && (!isInMill(shootPos) || allInMill(player.getOpponent())))
                {
                    board[shootPos].changeState(Player.None);
                    return;
                }
                Console.WriteLine("Please select a valid piece to shoot, as you have selected an invalid move");
            }

        }

        public bool isMovable(string pos)
        {
            List<INode> emptyNeighbours =
                (from cell in getNeighbours(pos)
                 where cell.getState == Player.None
                 select cell).ToList();
            return emptyNeighbours.Count > 0;
        }


        public bool allInMill(Player player)
        {
            foreach (string pos in board.Keys)
            {
                if (board[pos].getState == player && !isInMill(pos))
                    return false;
            }
            return true;
        }

        public bool isInMill(string pos)
        {
            List<string[]> relevantmills = mills.Where(mill => mill.Contains(pos)).ToList();
            foreach (INode[] mill in relevantmills.Select(mill => mill.Select(getCell).ToArray()).ToList())
            {
                if ((mill[0].getState == Player.X && mill[1].getState == Player.X && mill[2].getState == Player.X) ||
                    (mill[0].getState == Player.O && mill[1].getState == Player.O && mill[2].getState == Player.O))
                {
                    return true;
                }
            }
            return false;
        }

        public bool canPlay(IPlayer player)
        {
            if (numCows(player.playerID) <= 3)
                return true;
            IEnumerable<string> query =
                from pos in board.Keys
                where board[pos].getState == player.playerID
                where isMovable(pos)
                select pos;
            return query.Any();
        }


        public string playerToString(Player player)
        {
            if (player == Player.O)
                return "O";
            else if (player == Player.X)
                return "X";
            return " ";
        }
    }
}

