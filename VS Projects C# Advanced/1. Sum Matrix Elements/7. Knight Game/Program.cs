using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] board = new char[n, n];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string[] values = Console.ReadLine()
                    .Select(x => new string(x, 1))
                    .ToArray();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = Convert.ToChar(values[col]);
                }
            }
            int otherKnightsFound = 0;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == 'K')
                    {
                        int rowKnightIndex = row;
                        int colKnightIndex = col;

                        if (rowKnightIndex - 1 >= 0 && colKnightIndex - 2 >= 0)
                        {
                            if (board[rowKnightIndex - 1, colKnightIndex - 2] == 'K')
                            {
                                board[rowKnightIndex - 1, colKnightIndex - 2] = '0';
                                otherKnightsFound++;
                            }
                        }
                        if (rowKnightIndex - 2 >= 0 && colKnightIndex - 1 >= 0)
                        {
                            if (board[rowKnightIndex - 2, colKnightIndex - 1] == 'K')
                            {
                                board[rowKnightIndex - 2, colKnightIndex - 1] = '0';
                                otherKnightsFound++;
                            }
                        }
                        if (rowKnightIndex - 1 >= 0 && colKnightIndex + 2 < n)
                        {
                            if (board[rowKnightIndex - 1, colKnightIndex + 2] == 'K')
                            {
                                board[rowKnightIndex - 1, colKnightIndex + 2] = '0';
                                otherKnightsFound++;
                            }
                        }
                        if (rowKnightIndex - 2 >= 0 && colKnightIndex + 1 < n)
                        {
                            if (board[rowKnightIndex - 2, colKnightIndex + 1] == 'K')
                            {
                                board[rowKnightIndex - 2, colKnightIndex + 1] = '0';
                                otherKnightsFound++;
                            }
                        }
                        if (rowKnightIndex + 2 < n && colKnightIndex - 1 >= 0)
                        {
                            if (board[rowKnightIndex + 2, colKnightIndex - 1] == 'K')
                            {
                                board[rowKnightIndex + 2, colKnightIndex - 1] = '0';
                                otherKnightsFound++;
                            }
                        }
                        if (rowKnightIndex + 1 < n && colKnightIndex - 2 >= 0)
                        {
                            if (board[rowKnightIndex + 1, colKnightIndex - 2] == 'K')
                            {
                                board[rowKnightIndex + 1, colKnightIndex - 2] = '0';
                                otherKnightsFound++;
                            }
                        }
                        if (rowKnightIndex + 1 < n && colKnightIndex + 2 < n)
                        {
                            if (board[rowKnightIndex + 1, colKnightIndex + 2] == 'K')
                            {
                                board[rowKnightIndex + 1, colKnightIndex + 2] = '0';
                                otherKnightsFound++;
                            }
                        }
                        if (rowKnightIndex + 2 < n && colKnightIndex + 1 < n)
                        {
                            if (board[rowKnightIndex + 2, colKnightIndex + 1] == 'K')
                            {
                                board[rowKnightIndex + 2, colKnightIndex + 1] = '0';
                                otherKnightsFound++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(otherKnightsFound);
        }
    }
}
