using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            string line = Console.ReadLine();

            string[,] field = new string[dimensions, dimensions];

            for (int row = 0; row < field.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];
                }
            }

            while (true)
            {
                int startRow = 0;
                int startCol = 0;

                for (int row = 0; row < field.GetLength(0); row++)
                {
                    for (int col = 0; col < field.GetLength(1); col++)
                    {
                        if (field[row, col] == "s")
                        {
                            startRow = row;
                            startCol = col;
                        }
                    }
                }

                string cellValue = " ";
                int currRow = startRow;
                int currCol = startCol;

                string[] command = line
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                int loopCounter = 0;

                for (int i = 0; i < command.Length; i++)
                {
                    string currentCommand = command[i];
                    loopCounter++;

                    switch (currentCommand)
                    {
                        case "left" when currCol - 1 >= 0:

                            cellValue = field[currRow, currCol - 1];
                            currCol -= 1;

                            switch (cellValue)
                            {
                                case "*":
                                    break;

                                case "e":
                                    Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                    return;

                                case "c":
                                    field[currRow, currCol] = "*";
                                    break;
                            }
                            break;

                        case "right" when currCol + 1 < dimensions:

                            cellValue = field[currRow, currCol + 1];
                            currCol += 1;

                            switch (cellValue)
                            {
                                case "*":
                                    break;

                                case "e":
                                    Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                    return;

                                case "c":
                                    field[currRow, currCol] = "*";
                                    break;
                            }
                            break;

                        case "up" when currRow - 1 >= 0:

                            cellValue = field[currRow - 1, currCol];
                            currRow -= 1;

                            switch (cellValue)
                            {
                                case "*":
                                    break;

                                case "e":
                                    Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                    return;

                                case "c":
                                    field[currRow, currCol] = "*";
                                    break;
                            }
                            break;

                        case "down" when currRow + 1 < dimensions:

                            cellValue = field[currRow + 1, currCol];
                            currRow += 1;

                            switch (cellValue)
                            {
                                case "*":
                                    break;

                                case "e":
                                    Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                    return;

                                case "c":
                                    field[currRow, currCol] = "*";
                                    break;
                            }
                            break;
                    }
                }

                int counter = 0;

                foreach (var element in field)
                {
                    if (element == "c")
                    {
                        counter++;
                    }
                }

                if (counter == 0)
                {
                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                    return;
                }

                if (command.Length == loopCounter)
                {
                    Console.WriteLine($"{counter} coals left. ({currRow}, {currCol})");
                    return;
                }
            }
        }
    }
}
