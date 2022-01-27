using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] mineField = new int[n, n];

            for (int row = 0; row < mineField.GetLength(0); row++)
            {
                int[] values = Console.ReadLine()
                    .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < mineField.GetLength(1); col++)
                {
                    mineField[row, col] = values[col];
                }
            }

            while (true)
            {
                string[] parts = Console.ReadLine()
                    .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int loopCounter = parts.Length;

                for (int i = 0; i < parts.Length; i++)
                {
                    string[] currentBombPosition = parts[i]
                        .Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    
                    int rowBomb = Convert.ToInt32(currentBombPosition[0]);
                    int colBomb = Convert.ToInt32(currentBombPosition[1]);
                    
                    int currentBombPower = mineField[rowBomb, colBomb];

                    if (rowBomb - 1 >= 0 && mineField[rowBomb - 1, colBomb] > 0)
                    {
                        mineField[rowBomb - 1, colBomb] -= currentBombPower;
                    }

                    if (rowBomb + 1 < n && mineField[rowBomb + 1, colBomb] > 0)
                    {
                        mineField[rowBomb + 1, colBomb] -= currentBombPower;
                    }

                    if (colBomb - 1 >= 0 && mineField[rowBomb, colBomb - 1] > 0)
                    {
                        mineField[rowBomb, colBomb - 1] -= currentBombPower;
                    }

                    if (colBomb + 1 < n && mineField[rowBomb, colBomb + 1] > 0)
                    {
                        mineField[rowBomb, colBomb + 1] -= currentBombPower;        
                    }

                    if (rowBomb - 1 >= 0 && colBomb - 1 >= 0 && mineField[rowBomb - 1, colBomb - 1] > 0)
                    {
                        mineField[rowBomb - 1, colBomb - 1] -= currentBombPower;
                    }

                    if (rowBomb + 1 < n && colBomb + 1 < n && mineField[rowBomb + 1, colBomb + 1] > 0)
                    {
                        mineField[rowBomb + 1, colBomb + 1] -= currentBombPower;    
                    }

                    if (rowBomb - 1 >= 0 && colBomb + 1 < n && mineField[rowBomb - 1, colBomb + 1] > 0)
                    {
                        mineField[rowBomb - 1, colBomb + 1] -= currentBombPower;
                    }

                    if (rowBomb + 1 < n && colBomb - 1 >= 0 && mineField[rowBomb + 1, colBomb - 1] > 0)
                    {
                        mineField[rowBomb + 1, colBomb - 1] -= currentBombPower;
                    }

                    mineField[rowBomb, colBomb] = 0;
                    loopCounter--;
                }

                int aliveCellsCounter = 0;
                int aliveCellsSum = 0;

                for (int row = 0; row < mineField.GetLength(0); row++)
                {
                    for (int col = 0; col < mineField.GetLength(1); col++)
                    {
                        if (mineField[row, col] > 0)
                        {
                            aliveCellsCounter++;
                            aliveCellsSum += mineField[row, col];
                        }
                    }
                }

                if (loopCounter == 0)
                {
                    Console.WriteLine($"Alive cells: {aliveCellsCounter}");
                    Console.WriteLine($"Sum: {aliveCellsSum}");

                    for (int row = 0; row < mineField.GetLength(0); row++)
                    {
                        for (int col = 0; col < mineField.GetLength(1); col++)
                        {
                            Console.Write(mineField[row, col] + " ");
                        }
                        Console.WriteLine();
                    }
                    return;
                }
            }
        }
    }
}
