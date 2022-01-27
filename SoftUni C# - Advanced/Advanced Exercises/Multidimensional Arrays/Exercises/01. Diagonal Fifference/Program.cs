using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            int[,] matrix = new int[dimensions, dimensions];

            for (int row = 0; row < dimensions; row++)
            {
                int[] values = Console.ReadLine()
                    .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < dimensions; col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            int firstDiagonal = 0;
            int secondDiagonal = 0;

            for (int row = 0; row < dimensions; row++)
            {
                firstDiagonal += matrix[row, row];
                secondDiagonal += matrix[row, dimensions - row - 1];
            }

            Console.WriteLine(Math.Abs(firstDiagonal - secondDiagonal));
        }
    }
}
