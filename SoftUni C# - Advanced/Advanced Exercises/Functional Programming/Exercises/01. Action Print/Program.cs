using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> names = Console.WriteLine;

            Console.ReadLine()
                .Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(name => Console.WriteLine(names));
        }
    }
}
