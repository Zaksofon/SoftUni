using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Print_Even_Numbers_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .ToArray();

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}