using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Applied_Arithmetics_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Action<int[]> result = number => Console.WriteLine(string.Join(" ",number));

            while (true)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "add":
                        numbers = ForEach(numbers, number => ++number);
                        break;

                    case "multiply":
                        numbers = ForEach(numbers, number => number * 2);
                        break;

                    case "subtract":
                        numbers = ForEach(numbers, number => --number);
                        break;

                    case "print":
                        result(numbers);
                        break;

                    case "end":
                        return;
                }
            }
        }

        private static int[] ForEach(int[] numbers, Func<int, int> func)
            => numbers.Select(func).ToArray();
    }
}
