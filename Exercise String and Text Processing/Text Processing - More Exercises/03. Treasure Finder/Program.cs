using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> key = new List<int>(Console.ReadLine()
                .Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());


            List<int> toAdd = key;

            while (true)
            {
                string inputToBeDecrypt = Console.ReadLine();

                if (inputToBeDecrypt == "find")
                {
                    break;
                }

                StringBuilder decryptedInput = new StringBuilder();

                for (int i = 0; i < inputToBeDecrypt.Length; i++)
                {
                    if (key.Count < inputToBeDecrypt.Length)
                    {
                        key.AddRange(toAdd);
                    }

                    decryptedInput.Append(Convert.ToChar(inputToBeDecrypt[i] - key[i]));
                }

                Match treasure = Regex.Match(Convert.ToString(decryptedInput), @"\&(?<treasure>\w+)\&");
                Match coordinates = Regex.Match(Convert.ToString(decryptedInput), @"\<(?<coordinates>\w+)\>");

                Console.WriteLine($"Found {treasure.Groups["treasure"]} at {coordinates.Groups["coordinates"]}");
            }
        }
    }
}
