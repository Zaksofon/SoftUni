using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace _04.Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Regex star = new Regex(@"(?<star>[STARstar])");
                MatchCollection matches = star.Matches(input);

                int key = matches.Count;

                StringBuilder decryptedMassage = new StringBuilder();

                foreach (var symbol in input)
                {
                    decryptedMassage.Append(Convert.ToChar(symbol - key));
                }

                Regex currentCombination = 
                    new Regex(@"^[^@\-!:>]*@(?<planet>[A-Za-z]+)[^@\-!:>]*\:(?<population>\d+)[^@\-!:>]*!(?<aType>[AD])[^@\-!:>]*!->(?<troops>\d+)[^@\-!:>]*$");

                Match match = currentCombination.Match(Convert.ToString(decryptedMassage));

                if (!match.Success)
                {
                    continue;
                }

                string planet = match.Groups["planet"].Value;
                int population = Convert.ToInt32(match.Groups["population"].Value);
                string aType = match.Groups["aType"].Value;
                int troops = Convert.ToInt32(match.Groups["troops"].Value);

                if (aType == "A")
                {
                    attackedPlanets.Add(planet);
                }
                else
                {
                    destroyedPlanets.Add(planet);
                }
            }
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            List<string> orderedAttackedPlanets = attackedPlanets.OrderBy(x => x)
                .ToList();

            foreach (var planet in orderedAttackedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            List<string> orderedDestroyedPlanets = destroyedPlanets.OrderBy(x => x)
                .ToList();

            foreach (var planet in orderedDestroyedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
