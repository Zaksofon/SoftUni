using System;
using System.Linq;

namespace _02._Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] garden = new int[dimensions[0], dimensions[1]];

            
            for (int rows = 0; rows < garden.GetLength(0); rows++)
            {
                for (int cols = 0; cols < garden.GetLength(1); cols++)
                {
                    garden[rows, cols] = 0;
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Bloom Bloom Plow")
                {
                    break;
                }

                int[] flowersPosition = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int flowersRow = flowersPosition[0];
                int flowersCol = flowersPosition[1];

                if (flowersRow <= 0 || flowersRow > garden.GetLength(0) || flowersCol <= 0 ||
                    flowersRow > garden.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                for (int i = 0; i < garden.GetLength(0); i++)
                {
                    garden[flowersRow, i]++;
                }

                for (int i = 0; i < garden.GetLength(1); i++)
                {
                    garden[i, flowersCol]++;
                }

                garden[flowersRow, flowersCol]--;
            }

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write(garden[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
