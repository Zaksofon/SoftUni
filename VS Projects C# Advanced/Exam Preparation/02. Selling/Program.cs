using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _02._Selling
{
    class Program
    {
        private const int MIN_DOLLARS_NEEDED = 50;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] bakery = new char[n][];

            int playerRow = 0;
            int playerCol = 0;
            int totalMoneyCollected = 0;
            int nextRow = playerRow;
            int nextCol = playerCol;

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                {
                    for (int col = 0; col < input.Length; col++)
                    {
                        if (input[col] == 'S')
                        {
                            playerRow = row;
                            playerCol = col;
                        }

                        bakery[row] = input;
                    }
                }
            }

            while (totalMoneyCollected < MIN_DOLLARS_NEEDED)
            {
                string command = Console.ReadLine();
                bakery[nextRow][nextCol] = '-';
                char currentSymbol = bakery[nextRow][nextCol];
                switch (command)
                {
                    case "up" when playerRow - 1 >= 0:
                        playerRow--;
                        nextRow = playerRow;
                        nextCol = playerCol;
                        currentSymbol = bakery[nextRow][nextCol];

                        if (char.IsDigit(currentSymbol))
                        {
                            totalMoneyCollected += currentSymbol - 48;
                            if (totalMoneyCollected >= 50)
                            {
                                bakery[nextRow][nextCol] = 'S';
                                break;
                            }
                        }

                        else if (currentSymbol == 'O')
                        {
                            LookingForWormHoles(bakery, playerRow, playerCol, n);
                        }

                        break;

                    case "down" when playerRow + 1 < n:
                        playerRow++;
                        nextRow = playerRow;
                        nextCol = playerCol;
                        currentSymbol = bakery[nextRow][nextCol];

                        if (char.IsDigit(currentSymbol))
                        {
                            totalMoneyCollected += currentSymbol - 48;
                            if (totalMoneyCollected >= 50)
                            {
                                bakery[nextRow][nextCol] = 'S';
                                break;
                            }
                        }

                        else if (currentSymbol == 'O')
                        {
                            LookingForWormHoles(bakery, playerRow, playerCol, n);
                        }

                        break;

                    case "left" when playerCol - 1 >= 0:
                        playerCol--;
                        nextRow = playerRow;
                        nextCol = playerCol;
                        currentSymbol = bakery[nextRow][nextCol];

                        if (char.IsDigit(currentSymbol))
                        {
                            totalMoneyCollected += currentSymbol - 48;
                            if (totalMoneyCollected >= 50)
                            {
                                bakery[nextRow][nextCol] = 'S';
                                break;
                            }
                        }

                        else if (currentSymbol == 'O')
                        {
                            LookingForWormHoles(bakery, playerRow, playerCol, n);
                        }

                        break;

                    case "right" when playerCol + 1 < n:
                        playerCol++;
                        nextRow = playerRow;
                        nextCol = playerCol;
                        currentSymbol = bakery[nextRow][nextCol];

                        if (char.IsDigit(currentSymbol))
                        {
                            totalMoneyCollected += currentSymbol - 48;
                            if (totalMoneyCollected >= 50)
                            {
                                bakery[nextRow][nextCol] = 'S';
                                break;
                            }
                        }

                        else if (currentSymbol == 'O')
                        {
                            LookingForWormHoles(bakery, playerRow, playerCol, n);
                        }

                        break;

                    default:
                        Console.WriteLine($"Bad news, you are out of the bakery.");
                        Console.WriteLine($"Money: {totalMoneyCollected}");
                        foreach (var t in bakery)
                        {
                            Console.WriteLine(string.Join("", t));
                        }
                        return;
                }
            }

            Console.WriteLine("Good news! You succeeded in collecting enough money!");
            Console.WriteLine($"Money: {totalMoneyCollected}");

            foreach (var t in bakery)
            {
                Console.WriteLine(string.Join("", t));
            }
        }
        private static void LookingForWormHoles(char[][] bakery, int nextRow, int nextCol, int n)
        {
            bakery[nextRow][nextCol] = '-';

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (bakery[row][col] == 'O')
                    {
                        nextRow = row;
                        nextCol = col;
                        bakery[row][col] = '-';
                        break;
                    }
                }
            }
        }
    }
}

