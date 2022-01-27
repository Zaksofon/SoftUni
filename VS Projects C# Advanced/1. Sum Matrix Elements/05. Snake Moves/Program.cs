using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Snake_Moves
{
    class Program
    {
        private static int cout;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[dimensions[0], dimensions[1]];

            string input = Console.ReadLine();
            
            int index = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (index == input.Length)
                    {
                        index = 0;
                    }
                    matrix[row, col] = input[index];
                    index++;
                }
            }

            for (int outputRow = 0; outputRow < matrix.GetLength(0); outputRow++)
            {
                if (outputRow % 2 == 0)
                {
                    for (int outputCol = 0; outputCol < matrix.GetLength(1); outputCol++)
                    {
                        Console.Write(matrix[outputRow, outputCol]);
                    }
                    Console.WriteLine();
                }

                else
                {
                    for (int outputCol = matrix.GetLength(1) - 1; outputCol >= 0; outputCol--)
                    {
                        Console.Write(matrix[outputRow, outputCol]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
