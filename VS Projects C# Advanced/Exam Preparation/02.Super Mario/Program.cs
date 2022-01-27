using System;
using System.Linq;

namespace _02.Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine());
            int rowLength = int.Parse(Console.ReadLine());
            int colLength = 0;
            int rowMarioIndex = 0;
            int colMarioIndex = 0;

            char[,] matrix = { };

            for (int row = 0; row < rowLength; row++)
            {
                string[] input = Console.ReadLine()
                    .Select(x => new string(x, 1))
                    .ToArray();

                if (row == 0)
                {
                    matrix = new char[rowLength, input.Length];
                    colLength = input.Length;
                }
                
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row, col] = Convert.ToChar(input[col]);

                    if (matrix[row, col] == 'M')
                    {
                        rowMarioIndex = row;
                        colMarioIndex = col;
                    }
                }
            }

            while (true)
            {
                string[] parts = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string direction = parts[0];
                int bowserRow = int.Parse(parts[1]);
                int bowserCol = int.Parse(parts[2]);

                matrix[bowserRow, bowserCol] = 'B';
                matrix[rowMarioIndex, colMarioIndex] = '-';
                marioLives -= 1;

                switch (direction)
                {
                    case "W" when rowMarioIndex - 1 >= 0:
                        rowMarioIndex -= 1;
                        break;

                    case "S" when rowMarioIndex + 1 < rowLength:
                        rowMarioIndex += 1;
                        break;

                    case "A" when colMarioIndex - 1 >= 0:
                        colMarioIndex -= 1;
                        break;

                    case "D" when colMarioIndex + 1 < colLength:
                        colMarioIndex += 1;
                        break;
                }

                if (matrix[rowMarioIndex, colMarioIndex] == 'B')
                {
                    marioLives -= 2;
                    matrix[rowMarioIndex, colMarioIndex] = '-';
                }

                if (marioLives <= 0)
                {
                    matrix[rowMarioIndex, colMarioIndex] = 'X';
                    Console.WriteLine($"Mario died at {rowMarioIndex};{colMarioIndex}.");
                    break;
                }

                if (matrix[rowMarioIndex, colMarioIndex] == 'P')
                {
                    matrix[rowMarioIndex, colMarioIndex] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
                    break;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
