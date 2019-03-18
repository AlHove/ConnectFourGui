// Katheryn Weeden and Alyssa Hove
// Started: 2/1/19
// Game class: Deals with Starting the Game, Stopping the game, and restarting game

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConnectFourWebApp.Player;
using static ConnectFourWebApp.Board;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace ConnectFourWebApp
{
    public class Game
    {
        // Start the game
        // Method will also allow saved game in future
        // Returns a "w" for win or a "s" for save
        public string StartGame(char[,] g, int turn)
        {
            Board b = new Board();
            b.SetExistingBoard(g);
            return (PlayGame(b, turn));
        }

        // Start a New Game
        // Returns a "w" for win or a "s" for save
        public string NewGame()
        {
            //Initialize the board
            Board b = new Board();
            b.SetBoard();
            return (PlayGame(b, 0));
        }

        // Continues to prompt users to play until a win or save occurs
        // Returns a "w" for win or a "s" for save
        public string PlayGame(Board b, int saveTurn)
        {
            bool win = false;
            bool placed = false;
            string x;
            int VarCol;
            int VarRow;

            //Initialize the players
            Player player = new Player();
            player.piece = 'X';
            player.turnNumber = 0;
            Player playerTwo = new Player();
            playerTwo.piece = 'O';
            playerTwo.turnNumber = 1;
            int turn = saveTurn;



            //Loops through a series of asking player one and two to input a location
            //Assumes the location input is always formatted as 'row# col#' w/o error checking
            do
            {
                if (turn == 0)
                {
                    b.DisplayBoard();
                    Console.WriteLine("Player One choose your location, row then column, or input save to save game, for row 1 column 1 put 1 1");
                    x = SaveGame(Console.ReadLine(), b, player);
                    if (x == "save")
                    {
                        return "s";
                    }
                    try // try to get input
                    {
                        VarRow = Convert.ToInt32(x.Split(' ')[0]);
                        VarCol = Convert.ToInt32(x.Split(' ')[1]);
                    }
                    catch (IndexOutOfRangeException e) //Catch the Exception
                    {
                        Console.WriteLine(e);
                        PlayGame(b, turn);

                    }
                    finally // get the value
                    {
                        VarRow = Convert.ToInt32(x.Split(' ')[0]);
                        VarCol = Convert.ToInt32(x.Split(' ')[1]);
                        placed = b.AddPiece(VarRow, VarCol, 'X', b);
                        turn = 1;
                    }
                    while (placed == false) // if location was input correctly but is occupied
                    {
                        Console.WriteLine("Player One invalid location choose another location, row then column");
                        x = Console.ReadLine();
                        VarRow = Convert.ToInt32(x.Split(' ')[0]);
                        VarCol = Convert.ToInt32(x.Split(' ')[1]);
                        placed = b.AddPiece(VarRow, VarCol, 'X', b);
                        turn = 1;
                    }
                    win = b.CheckWin(b, player);


                    if (win == true) // if player 1 won
                    {
                        break;
                    }
                }
                if (turn == 1)
                {
                    b.DisplayBoard();
                    Console.WriteLine("Player Two choose your location, row then column, or input save to save game");
                    x = SaveGame(Console.ReadLine(), b, playerTwo);
                    if (x == "save")
                    {
                        return "s";
                    }
                    try
                    {
                        VarRow = Convert.ToInt32(x.Split(' ')[0]);
                        VarCol = Convert.ToInt32(x.Split(' ')[1]);
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine(e);
                        PlayGame(b, turn);
                    }
                    finally
                    {
                        VarRow = Convert.ToInt32(x.Split(' ')[0]);
                        VarCol = Convert.ToInt32(x.Split(' ')[1]);
                        placed = b.AddPiece(VarRow, VarCol, 'O', b);
                        turn = 0;
                    }
                    while (placed == false)
                    {
                        Console.WriteLine("Player Two invalid location choose another location");
                        try
                        {
                            VarRow = Convert.ToInt32(x.Split(' ')[0]);
                            VarCol = Convert.ToInt32(x.Split(' ')[1]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            PlayGame(b, turn);
                        }
                        finally
                        {
                            VarRow = Convert.ToInt32(x.Split(' ')[0]);
                            VarCol = Convert.ToInt32(x.Split(' ')[1]);
                            placed = b.AddPiece(VarRow, VarCol, 'O', b);
                            turn = 0;
                        }
                    }
                    win = b.CheckWin(b, playerTwo);

                    if (win == true)
                    {
                        b.DisplayBoard();
                    }
                }
            } while (win == false);
            return "w";
        }

        // Checks user input for save and saves the current game if requested
        public string SaveGame(string s, Board b, Player p)
        {
            if (String.Equals(s, "save", StringComparison.CurrentCultureIgnoreCase))
            {
                Stream saveFile = File.Create("Connect4Save.xml");
                SoapFormatter serializer = new SoapFormatter();
                serializer.Serialize(saveFile, p.getTurnNumber());
                serializer.Serialize(saveFile, b.GetBoard());

                saveFile.Close();
                return "save";
            }
            return s;
        }

    }
}
