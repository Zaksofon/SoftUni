using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
 
        static void Main(string[] args)
        {
            Dictionary<string, int> names = new Dictionary<string, int>(Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .ToDictionary(x => x, x => 0));

            Regex racerRegex = new Regex(@"[A-Za-z]+");
            Regex timeRegex = new Regex(@"[\d]+");


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of race")
                {
                    break;
                }

                MatchCollection matchesRacerName = racerRegex.Matches(input);
                MatchCollection matchesTime = timeRegex.Matches(input);

                StringBuilder sb = new StringBuilder();

                foreach (var letter in matchesRacerName)
                {
                    sb.Append(letter);
                }

                if (!names.ContainsKey(Convert.ToString(sb)))
                {
                    continue;
                }

                StringBuilder totalTimePerRacer = new StringBuilder();
                int timeSum = 0;

                foreach (var digit in matchesTime)
                {
                    totalTimePerRacer.Append(digit);
                }

                for (int i = 0; i < totalTimePerRacer.Length; i++)
                {
                    timeSum += totalTimePerRacer[i] - '0';
                }

                if (names.ContainsKey(Convert.ToString(sb)))
                {
                    names[Convert.ToString(sb)] += timeSum;
                }
            }

            string[] winners = names
                .OrderByDescending(x => x.Value)
                .Take(3)
                .Select(x => x.Key)
                .ToArray();

            int counter = 1;
            string adding = "";

            foreach (var name in winners)
            {
                switch (counter)
                {
                    case 1:
                        adding = "st";
                        break;
                    case 2:
                        adding = "nd";
                        break;
                    case 3:
                        adding = "rd";
                        break;
                    default:
                        adding = "th";
                        break;
                }

                Console.WriteLine($"{counter++}{adding} place: {name}");
            }
        }
    }
}

