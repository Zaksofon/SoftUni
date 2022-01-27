using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> calculations = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] parts = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int command = parts[0];

                switch (command)
                {
                    case 1:
                        int number = parts[1];
                        calculations.Push(number);
                        break;

                    case 2 when calculations.Count > 0:
                        calculations.Pop();
                        break;

                    case 3:
                        Console.WriteLine(calculations.Max());
                        break;

                    case 4:
                        Console.WriteLine(calculations.Min());
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", calculations.ToArray()));

            Console.WriteLine();
        }
    }
}