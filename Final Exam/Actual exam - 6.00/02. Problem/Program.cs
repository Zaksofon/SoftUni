using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Regex validator = new Regex(@"(\*|@)(?<message>[A-Z]{1}[a-z]{2,})\1: (?<code>(\[[A-Za-z]\])\|(\[[A-Za-z]\])\|(\[[A-Za-z]\])\|)$");

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();

                Match isValid = validator.Match(message);

                List<int> result = new List<int>();

                if (isValid.Success)
                {
                    var numbers = isValid.Groups["code"].Value;

                    Regex letters = new Regex(@"\[([A-Za-z])\]\|");

                    MatchCollection groupsLetters = letters.Matches(numbers);


                    foreach (Match letter in groupsLetters)
                    {
                        char currentLetter = char.Parse(letter.Groups[1].Value);
                        result.Add(currentLetter);
                    }

                    Console.WriteLine($"{isValid.Groups["message"].Value}: {string.Join(" ", result)}");
                }

                if (!isValid.Success)
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
