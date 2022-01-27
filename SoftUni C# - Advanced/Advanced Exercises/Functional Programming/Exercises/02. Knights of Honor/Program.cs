using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> names = Console.WriteLine;

            Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(name => Console.WriteLine($"Sir {name}"));
        }
    }
}
