using System;

namespace _02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            char[,] field = new char[dimensions, dimensions];

            int currentRowIndex = 0;
            int currentColIndex = 0;
            int flowersCounter = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];

                    if (field[row, col] == 'B')
                    {
                        currentRowIndex = row;
                        currentColIndex = col;
                    }
                }
            }

            field[currentRowIndex, currentColIndex] = '.';

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    field[currentRowIndex, currentColIndex] = 'B';
                    break;
                }

                switch (command)
                {
                    case "up": currentRowIndex--; break;
                    case "down": currentRowIndex++; break;
                    case "left": currentColIndex--; break;
                    case "right": currentColIndex++; break;
                }

                if (currentRowIndex < 0 || currentRowIndex >= dimensions || currentColIndex < 0 || currentColIndex >= dimensions)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                switch (field[currentRowIndex, currentColIndex])
                {
                    case 'f':
                        flowersCounter++;
                        field[currentRowIndex, currentColIndex] = '.';
                        break;

                    case 'O':
                    {
                        field[currentRowIndex, currentColIndex] = '.';
                        switch (command)
                        {
                            case "up": currentRowIndex--; break;
                            case "down": currentRowIndex++; break;
                            case "left": currentColIndex--; break;
                            case "right": currentColIndex++; break;
                        }

                        if (field[currentRowIndex, currentColIndex] == 'f')
                        {
                            field[currentRowIndex, currentColIndex] = '.';
                            flowersCounter++;
                        }

                        break;
                    }
                }
            }

            Console.WriteLine(flowersCounter >= 5
                ? $"Great job, the bee managed to pollinate {flowersCounter} flowers!"
                : $"The bee couldn't pollinate the flowers, she needed {5 - flowersCounter} flowers more");

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
