using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem_2.Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex digitsTreshold = new Regex(@"\d");
            Regex emojiRegex = new Regex(@"(::|\*\*)([A-Z][a-z]{2,})\1");

            MatchCollection digits = digitsTreshold.Matches(text);
            
            long tresholdSum = 1;

            MatchCollection validEmoji = emojiRegex.Matches(text);
            
            foreach (Match digit in digits)
            {
                tresholdSum *= int.Parse(digit.Value);
            }
            Console.WriteLine($"Cool threshold: {tresholdSum}");
            Console.WriteLine($"{validEmoji.Count} emojis found in the text. The cool ones are:");

            foreach (Match emoji in validEmoji)
            {
                string currentEmoji = emoji.Groups[2].Value;
                int coolness = 0;

                foreach (var letter in currentEmoji)
                {
                    coolness += letter;
                }

                if (coolness > tresholdSum)
                {
                    Console.WriteLine(emoji);
                }
            }
        }
    }
}
