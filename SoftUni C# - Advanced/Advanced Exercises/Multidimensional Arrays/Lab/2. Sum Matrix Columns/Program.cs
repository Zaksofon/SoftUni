using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _2.Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadMatrixFromTheConsole();
            int[,] matrix = new int[size[0], size[1]];

            int colsSum = 0;
            for (int rows = 0; rows < size[0]; rows++)
            {
                int[] input = ReadMatrixFromTheConsole();

                for (int cols = 0; cols < size[1]; cols++)
                {
                    matrix[rows, cols] = input[cols];
                }
            }

            for (int col = 0; col < size[1]; col++)
            {
                for (int row = 0; row < size[0]; row++)
                {
                    colsSum += matrix[row, col];
                }

                Console.WriteLine(colsSum);
                colsSum = 0;
            }
        }

        private static int[] ReadMatrixFromTheConsole()
        {
            return Console.ReadLine()
                .Split(new[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
