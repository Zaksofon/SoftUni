using System;
using System.Linq;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] beach = new char[n][];

            int myTokens = 0;
            int opponentTokens = 0;

            for (int row = 0; row < n; row++)
            {
                beach[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Gong")
                {
                    for (int i = 0; i < beach.Length; i++)
                    {
                        for (int j = 0; j < beach[i].Length; j++)
                        {
                            Console.Write(beach[i][j] + " ");
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine($"Collected tokens: {myTokens}");
                    Console.WriteLine($"Opponent's tokens: {opponentTokens}");
                    break;
                }

                string[] parts = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int currentRow = int.Parse(parts[1]);
                int currentCol = int.Parse(parts[2]);

                if (currentRow < 0 || currentRow >= beach.GetLength(0) || currentCol < 0 || currentCol >= beach[currentRow].Length)
                {
                    continue;
                }

                if (parts.Length == 3)
                {
                    if (beach[currentRow][currentCol] == 'T')
                    {
                        myTokens++;
                        beach[currentRow][currentCol] = '-';
                    }
                }

                else if (parts.Length == 4)
                {
                    string direction = parts[3];

                    if (beach[currentRow][currentCol] == 'T')
                    {
                        opponentTokens++;
                        beach[currentRow][currentCol] = '-';
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        switch (direction)
                        {
                            case "up": currentRow--; break;
                            case "down": currentRow++; break;
                            case "left": currentCol--; break;
                            case "right": currentCol++; break;
                        }

                        if (currentRow < 0 || currentRow >= beach.GetLength(0) || currentCol < 0 || currentCol >= beach[currentRow].Length)
                        {
                            continue;
                        }

                        if (beach[currentRow][currentCol] == 'T')
                        {
                            opponentTokens++;
                            beach[currentRow][currentCol] = '-';
                        }
                    }
                }
            }
        }
    }
}
