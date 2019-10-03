using System;
using System.Collections.Generic;

namespace battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board = { { 0, 0, 1, 0 },
                             { 0, 0, 1, 0 },
                             { 0, 0, 1, 0 } };
            int[,] attacks = { { 3, 1 }, { 3, 2 }, { 3, 3 } };
            damagedOrSunk(board, attacks);
        }
        public static Dictionary<string, double> damagedOrSunk(int[,] board, int[,] attacks)
        {
            // Code here
            Dictionary<string, double> result = new Dictionary<string, double>{ { "sunk", 0 }, { "damaged", 0 }, { "notTouched", 0 }, { "points", 0 } };
            Dictionary<int, int> ships = new Dictionary<int, int>{ { 1, 0 }, { 2, 0 }, { 3, 0 } };

            Dictionary<int, int> hits = new Dictionary<int, int>{ { 1, 0 }, { 2, 0 }, { 3, 0 } };

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != 0)
                    {
                        ships[board[i, j]]++;
                    }
                }
            }

            for (int x = 0; x < attacks.GetLength(0); x++)
            {
                int ship = board[board.GetLength(0) - attacks[x, 1], attacks[x, 0] - 1];
                if (ship > 0) { hits[ship]++; }
            }
            for (int y = 1; y <= 3; y++)
            {
                if (ships[y] != 0)
                {
                    ships[y] = ships[y] - hits[y];
                    if (ships[y] == 0)
                    {
                        result["points"]++; result["sunk"]++;
                    }
                    else
                    {
                        if (hits[y] == 0)
                        {
                            result["notTouched"]++; result["points"]--;
                        }
                        else
                        {
                            result["damaged"]++; result["points"] = result["points"] + .5;
                        }
                    }
                }
            }
            return result;

        }
    }
}
