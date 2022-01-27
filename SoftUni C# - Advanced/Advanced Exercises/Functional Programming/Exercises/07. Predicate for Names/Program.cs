using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Predicate<string> filter = name => name.Length <= n;

            Console.WriteLine(string.Join("\n", names.Where(name => filter(name))));
        }
    }
}
