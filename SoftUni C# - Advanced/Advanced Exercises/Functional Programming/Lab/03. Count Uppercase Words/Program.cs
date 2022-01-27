using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> predicate = str => char.IsUpper(str[0]);

            List<string> input = Console.ReadLine()
                .Split()
                .Where(w => predicate(w))
                .ToList();

            foreach (var word in input)
            {
                Console.WriteLine(word);
            }
        }
    }
}
