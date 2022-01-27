using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace _6.Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] matrix = new int[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int firstRowLength = matrix[0].Length;
            int lastRowLength = matrix[n - 1].Length;

            if (firstRowLength == lastRowLength)
            {
                for (int i = 0; i < firstRowLength; i++)
                {
                    matrix[0][i] *= 2;
                    matrix[n - 1][i] *= 2;
                }
            }
            else
            {
                for (int i = 0; i < firstRowLength; i++)
                {
                    matrix[0][i] *= 2;
                }

                for (int i = 0; i < lastRowLength; i++)
                {
                    matrix[n - 1][i] /= 2;
                }
            }

            while (true)
            {
                string[] parts = Console.ReadLine()
                    .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = parts[0];

                if (command == "End")
                {
                    for (int i = 0; i < matrix.Length; i++)
                    {
                        for (int j = 0; j < matrix[i].Length; j++)
                        {
                            Console.Write(matrix[i][j] + " ");
                        }
                        Console.WriteLine();
                    }
                    return;
                }
                int curRow = Convert.ToInt32(parts[1]);
                int curCol = Convert.ToInt32(parts[2]);
                int curValue = Convert.ToInt32(parts[3]);

                if (curRow < n - 1 && curRow >= 0)
                {
                    if (curCol < matrix[curRow].Length && curCol >= 0)
                    {
                        switch (command)
                        {
                            case "Add":
                                matrix[curRow][curCol] += curValue;
                                break;

                            case "Subtract":
                                matrix[curRow][curCol] -= curValue;
                                break;
                        }
                    }
                }
            }
        }
    }
}
