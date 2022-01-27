using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> result = new SortedDictionary<char, int>();

            char[] text = input
                .ToArray();

            foreach (var letter in text)
            {
                if (!result.ContainsKey(letter))
                {
                    result.Add(letter, 1);
                    continue;
                }

                result[letter]++;
            }

            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
        
    }
}
