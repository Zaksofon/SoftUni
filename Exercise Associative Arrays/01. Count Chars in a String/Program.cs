using System;
using System.Collections.Generic;

namespace Exercise___Associative_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> word = new Dictionary<char, int>();

            string input = Console.ReadLine();

            foreach (var ch in input)
            {
                if (ch == ' ')
                {
                    continue;
                }

                if (word.ContainsKey(ch))
                {
                    word[ch] += 1;
                }

                else
                {
                    word.Add(ch, 1);
                }
            }

            foreach (var kvp in word)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value} ");
            }
        }
    }
}
