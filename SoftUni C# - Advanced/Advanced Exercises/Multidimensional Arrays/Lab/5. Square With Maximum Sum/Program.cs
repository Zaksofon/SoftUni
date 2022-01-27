using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = ReadMatrixFromTheConsole();

            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] values = ReadMatrixFromTheConsole();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            int maxSum = int.MinValue;
            int maxRowOne = int.MinValue;
            int maxRowTwo = int.MinValue;
            int maxColOne = int.MinValue;
            int maxColTwo = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                   int[] currentMatrix = { matrix[row, col], matrix[row, col + 1], matrix[row + 1, col], matrix[row + 1, col + 1] };

                   int sum = currentMatrix.Sum();

                   if (sum > maxSum)
                   {
                       maxSum = sum;
                       maxRowOne = currentMatrix[0];
                       maxColOne = currentMatrix[1];
                       maxRowTwo = currentMatrix[2];
                       maxColTwo = currentMatrix[3];
                   }
                }
            }

            Console.WriteLine($"{maxRowOne} {maxColOne}");
            Console.WriteLine($"{maxRowTwo} {maxColTwo}");
            Console.WriteLine(maxSum);
        }

        private static int[] ReadMatrixFromTheConsole()
        {
            return Console.ReadLine()
                .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
