using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> compounds = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                foreach (var element in input.Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries).ToArray())
                {
                    compounds.Add(element);
                }
            }
            Console.WriteLine(string.Join(" ", compounds));
        }
    }
}

