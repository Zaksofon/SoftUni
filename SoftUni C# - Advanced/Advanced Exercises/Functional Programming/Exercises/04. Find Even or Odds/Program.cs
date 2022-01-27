using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string query = Console.ReadLine();

            Predicate<int> predicate = query == "odd"
                ? number => number % 2 != 0
                : new Predicate<int>(number => number % 2 == 0);

            List<int> result = new List<int>();

            for (int number = numbers[0]; number <= numbers[1]; number++)
            {
                if (predicate(number))
                {
                    result.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
