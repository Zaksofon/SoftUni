using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToArray();

            int divider = int.Parse(Console.ReadLine());

            Predicate<int> predicate = n => n % divider != 0;

            Console.WriteLine(string.Join(" ", numbers.Where(n => predicate(n))));
        }
    }
}
