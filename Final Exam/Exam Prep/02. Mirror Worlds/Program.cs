using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Problem_2.Mirror_words
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"(@|#{1})[A-Za-z]{3,}\1(@|#{1})[A-Za-z]{3,}\1");

            MatchCollection match = regex.Matches(input);

            int matchesCount = match.Count;

            if (matchesCount == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                return;

            }
            Console.WriteLine($"{matchesCount} word pairs found!");

            List<string> mirrorWords = new List<string>();

            List<string> word = new List<string>();

            foreach (Match pair in match)
            {
                Regex currentPair = new Regex(@"[A-Za-z]+");

                MatchCollection currentWord = currentPair.Matches(pair.Value);

                foreach (Match combination in currentWord)
                {
                    word.Add(combination.ToString());
                }

                string firstWord = word[0];
                string secondWordUnchanged = word[1];
                string secondWord = new string(word[1].Reverse().ToArray());
                secondWord = string.Concat(secondWord);

                if (firstWord == secondWord)
                {
                    mirrorWords.Add(firstWord + " <=>");
                    mirrorWords.Add(secondWordUnchanged + ",");
                }

                word.RemoveRange(0, 2);
            }

            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
                return;
            }

            if (mirrorWords[mirrorWords.Count - 1].Contains(","))
            {
                mirrorWords[mirrorWords.Count - 1] = mirrorWords[mirrorWords.Count - 1].Replace(",", "");
            }

            Console.WriteLine("The mirror words are:");
            Console.WriteLine($"{string.Join(" ", mirrorWords)}");
        }
    }
}