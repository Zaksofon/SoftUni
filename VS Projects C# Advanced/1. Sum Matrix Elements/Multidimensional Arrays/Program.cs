using System;
using System.Collections.Generic;
using System.Linq;

namespace Multidimensional_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadMatrixFromTheConsole();

            int[,] matrix = new int[sizes[0], sizes[1]];

            int sum = 0;

            for (int rows = 0; rows < sizes[0]; rows++)
            {
                int[] arr = ReadMatrixFromTheConsole();

                for (int cols = 0; cols < sizes[1]; cols++)
                {
                    matrix[rows, cols] = arr[cols];
                    sum += arr[cols];
                }
            }

            Console.WriteLine(sizes[0]);
            Console.WriteLine(sizes[1]);
            Console.WriteLine(sum);
        }

        private static int[] ReadMatrixFromTheConsole()
        {
            return Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
