using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03.Maximal_Sum
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
            int[,] newMatrix = new int[3, 3];

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int[] currentMatrix =
                    {
                        matrix[row, col], matrix[row, col + 1], matrix[row, col + 2],
                        matrix[row + 1, col], matrix[row + 1, col + 1], matrix[row + 1, col + 2],
                        matrix[row + 2, col], matrix[row + 2, col + 1], matrix[row + 2, col + 2]
                    };
                    int sum = currentMatrix.Sum();

                    if (sum > maxSum)
                    {
                        maxSum = sum;

                        int index = 0;

                        for (int x = 0; x < 3; x++)
                        {
                            for (int y = 0; y < 3; y++)
                            {
                                newMatrix[x, y] = currentMatrix[index];
                                index++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            int counter = 0;
            foreach (int item in newMatrix)
            {
                Console.Write(item + " ");
                counter++;
                if (counter % 3 == 0 && counter != 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }

        private static int[] ReadMatrixFromTheConsole()
        {
            return Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
