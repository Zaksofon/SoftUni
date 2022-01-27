using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        private static int charsSum;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int charSum = Int32.MinValue;
            string maxName = "";

            foreach (var name in names)
            {
                int sum = name.Sum(c => c);

                if (sum >= n)
                {
                    charSum = sum;
                    maxName = name;
                    Console.WriteLine(maxName);
                    return;
                }
            }
        }
    }
}
