using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n <= 0)
            {
                return;
            }

            List<int> dividers = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> numbers = Enumerable.Range(1, n).ToList();

            List<int> result = new List<int>();

            foreach (var t in dividers)
            {
                result = numbers.FindAll(x => x % t == 0);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
