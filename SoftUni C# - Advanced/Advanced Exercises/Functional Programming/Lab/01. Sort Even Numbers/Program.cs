using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .OrderBy(n =>n)
                .ToArray();

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
