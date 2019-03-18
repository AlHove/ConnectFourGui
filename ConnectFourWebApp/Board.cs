// Katheryn Weeden and Alyssa Hove
// Started: 2/1/19
// Board class: deals with validating spaces and checking for wins and losses

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConnectFourWebApp.Player;

namespace ConnectFourWebApp
{
    public class Board
    {
        // Instance Variables 
        public int row;
        public int col;
        char[,] Grid = new char[7, 7];


        public Board()
        {

        }

        // Setter
        public void SetBoard()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Grid[i, j] = ' ';
                }
            }
        }

        public void SetExistingBoard(char[,] g)
        {
            Grid = g;
        }

        // Getter
        public Array GetBoard()
        {
            return this.Grid;
        }

        // Validate that location is free
        public bool ValidateLocation(Board b, int row, int col)
        {
            if (b.Grid[row, col] == 'X' ||
                b.Grid[row, col] == 'O')
            {
                return false;
            }

            if (b.Grid[row, col] == ' ')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Validate that requested location is free
        public bool CheckWin(Board b, Player p)
        {
            bool win = false;
            char token = p.piece;

            // Loops through board to check for Diagonal / win
            for (int i = 3; i < 7; i++)
            {
                for (int ix = 0; ix < 4; ix++)
                {
                    if (b.Grid[i, ix] == token &&
                        b.Grid[i - 1, ix + 1] == token &&
                        b.Grid[i - 2, ix + 2] == token &&
                        b.Grid[i - 3, ix + 3] == token)
                    {

                        win = true;
                        return win;
                    }
                }
            }

            // Loops through board to check for Vertical | win
            for (int i = 0; i < 4; i++)
            {
                for (int ix = 0; ix < 7; ix++)
                {
                    if (b.Grid[i, ix] == token &&
                        b.Grid[i + 1, ix] == token &&
                        b.Grid[i + 2, ix] == token &&
                        b.Grid[i + 3, ix] == token)
                    {
                        win = true;
                        return win;
                    }
                }
            }

            // Loops through board to chedk from Diagonal \ win
            for (int i = 0; i < 4; i++)
            {
                for (int ix = 0; ix < 4; ix++)
                {
                    if (b.Grid[i, ix] == token &&
                    b.Grid[i + 1, ix + 1] == token &&
                    b.Grid[i + 2, ix + 2] == token &&
                    b.Grid[i + 3, ix + 3] == token)
                    {
                        win = true;
                        return win;
                    }
                }
            }

            // Loops through board to check for Horizontal - win
            for (int i = 0; i < 7; i++)
            {
                for (int ix = 0; ix < 4; ix++)
                {
                    if (b.Grid[i, ix] == token &&
                 b.Grid[i, ix + 1] == token &&
                 b.Grid[i, ix + 2] == token &&
                 b.Grid[i, ix + 3] == token)
                    {
                        win = true;
                        return win;
                    }
                }
            }

            // If no wins yet, return win - initialized as false
            return win;
        }

        // Show current board
        public void DisplayBoard()
        {
            Console.WriteLine("  1 2 3 4 5 6 7 ");

            for (int i = 0; i < 7; i++)
            {
                Console.Write(i + 1);
                for (int j = 0; j < 7; j++)
                {
                    Console.Write('|');
                    Console.Write(this.Grid[i, j]);
                }
                Console.WriteLine('|');
                Console.WriteLine("  ______________");
            }
        }

        // Adds a piece to the board
        public bool AddPiece(int row, int col, char c, Board b)
        {
            bool valid = false;
            row = row - 1;
            col = col - 1;
            valid = ValidateLocation(b, row, col);

            if (valid == true)
            {
                b.Grid[row, col] = c;
                return true;
            }
            return false;
        }
    }
}