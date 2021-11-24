using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem_2.Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string destinations = Console.ReadLine();

            List<string> countries = new List<string>();

            Regex regex = new Regex(@"(=|\/)(?<country>[A-Z][A-Za-z]\s?[A-Z]?[A-Za-z]{3,})\1");

            MatchCollection country = regex.Matches(destinations);

            int travelPoints = 0;

            foreach (Match item in country)
            {
                countries.Add(item.Groups["country"].Value);
                travelPoints += item.Groups["country"].Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", countries)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
