using System;

namespace _02._Bakery
{
    class Program
    {
        private const int MIN_DOLLARS_AMOUNT = 50;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] bakery = new char[n, n];

            int startIndexRow = 0;
            int startIndexCol = 0;
            int totalMoneyCollected = 0;

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    bakery[row, col] = input[col];

                    if (bakery[row, col] == 'S')
                    {
                        startIndexRow = row;
                        startIndexCol = col;
                        bakery[startIndexRow, startIndexCol] = '-';
                    }
                }
            }
            char nextSymbol = bakery[startIndexRow, startIndexCol];

            while (totalMoneyCollected < MIN_DOLLARS_AMOUNT)
            {
                string input = Console.ReadLine();
                
                switch (input)
                {
                    case "up" when startIndexRow - 1 >= 0:
                        startIndexRow--;
                        nextSymbol = bakery[startIndexRow, startIndexCol];

                        if (GameCases(nextSymbol, bakery, ref startIndexRow, ref startIndexCol, n, ref totalMoneyCollected))
                            return;
                        else
                            break;

                    case "down" when startIndexRow + 1 < n:
                        startIndexRow++;
                        nextSymbol = bakery[startIndexRow, startIndexCol];

                        if (GameCases(nextSymbol, bakery, ref startIndexRow, ref startIndexCol, n, ref totalMoneyCollected))
                            return;
                        else
                            break;

                    case "left" when startIndexCol - 1 >= 0:
                        startIndexCol--;
                        nextSymbol = bakery[startIndexRow, startIndexCol];

                        if (GameCases(nextSymbol, bakery, ref startIndexRow, ref startIndexCol, n, ref totalMoneyCollected))
                            return;
                        else
                            break;

                    case "right" when startIndexCol + 1 < n:
                        startIndexCol++;
                        nextSymbol = bakery[startIndexRow, startIndexCol];

                        if (GameCases(nextSymbol, bakery, ref startIndexRow, ref startIndexCol, n, ref totalMoneyCollected))
                            return;
                        else
                            break;

                    default:
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine($"Money: {totalMoneyCollected}");
                        for (int row = 0; row < bakery.GetLength(0); row++)
                        {
                            for (int col = 0; col < bakery.GetLength(1); col++)
                            {
                                Console.Write(bakery[row, col]);
                            }
                            Console.WriteLine();
                        }
                        return;
                }
            }
        }

        private static bool GameCases(char nextSymbol, char[,] bakery, ref int startIndexRow, ref int startIndexCol, int n,
            ref int totalMoneyCollected)
        {
            if (char.IsDigit(nextSymbol))
            {
                if (MovingPlayer(nextSymbol, bakery, startIndexRow, startIndexCol, ref totalMoneyCollected))
                    return true;
            }

            else if (nextSymbol == 'O')
            {
                WormHoleScenario(bakery, ref startIndexRow, ref startIndexCol, n);
            }

            return false;
        }

        private static void WormHoleScenario(char[,] bakery, ref int startIndexRow, ref int startIndexCol, int n)
        {
            bakery[startIndexRow, startIndexCol] = '-';
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (bakery[row, col] == 'O')
                    {
                        startIndexRow = row;
                        startIndexCol = col;
                        bakery[startIndexRow, startIndexCol] = '-';
                        break;
                    }
                }
            }
        }

        private static bool MovingPlayer(char nextSymbol, char[,] bakery, int startIndexRow, int startIndexCol,
            ref int totalMoneyCollected)
        {
            totalMoneyCollected += nextSymbol - 48;
            bakery[startIndexRow, startIndexCol] = '-';
            if (totalMoneyCollected >= MIN_DOLLARS_AMOUNT)
            {
                bakery[startIndexRow, startIndexCol] = 'S';
                PrintResult(totalMoneyCollected, bakery);
                return true;
            }

            return false;
        }

        private static void PrintResult(int totalMoneyCollected, char[,] bakery)
        {
            Console.WriteLine("Good news! You succeeded in collecting enough money!");
            Console.WriteLine($"Money: {totalMoneyCollected}");
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    Console.Write(bakery[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
