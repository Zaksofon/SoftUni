using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] values = Console.ReadLine()
                    .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] parts = command
                    .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                command = parts[0];
                
                if (parts.Length == 5 && command == "swap" && 
                    Convert.ToInt32(parts[1]) <= matrix.GetLength(0) &&
                    Convert.ToInt32(parts[2]) <= matrix.GetLength(0) &&
                    Convert.ToInt32(parts[3]) <= matrix.GetLength(1) &&
                    Convert.ToInt32(parts[4]) <= matrix.GetLength(1))
                {
                    int row1 = Convert.ToInt32(parts[1]);
                    int col1 = Convert.ToInt32(parts[2]);
                    int row2 = Convert.ToInt32(parts[3]);
                    int col2 = Convert.ToInt32(parts[4]);

                    string temp = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = temp;

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row, col] + " ");
                        }

                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
