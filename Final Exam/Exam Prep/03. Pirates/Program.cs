using System;
using System.Collections.Generic;
using System.Linq;


namespace Problem_3.P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> cities = new Dictionary<string, int[]>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var townName = input[0];

                if (townName == "Sail")
                {
                    break;
                }
                var population = Convert.ToInt32(input[1]);
                var gold = Convert.ToInt32(input[2]);

                if (!cities.ContainsKey(townName))
                {
                    cities.Add(townName, new[] { population, gold });
                    continue;
                }
                cities[townName][0] += population;
                cities[townName][1] += gold;
            }

            while (true)
            {
                string[] parts = Console.ReadLine()
                    .Split(new[] {"=>"}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = parts[0];

                if (command == "End")
                {
                    if (cities.Count > 0)
                    {
                        cities = cities
                            .OrderByDescending(p => p.Value[1])
                            .ThenBy(p => p.Key)
                            .ToDictionary(x => x.Key, k => k.Value);

                        Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                        foreach (var town in cities)
                        {
                            Console.WriteLine($"{town.Key} -> Population: {town.Value[0]} citizens, Gold: {town.Value[1]} kg");
                        }
                        break;
                    }
                    Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
                    break;
                }
                string partsTown = parts[1];

                switch (command)
                {
                    case "Plunder":
                        int partsPopulation = Convert.ToInt32(parts[2]);
                        int partsGold = Convert.ToInt32(parts[3]);

                        if (cities.ContainsKey(partsTown))
                        {
                            cities[partsTown][0] -= partsPopulation;
                            cities[partsTown][1] -= partsGold;
                            Console.WriteLine($"{partsTown} plundered! {partsGold} gold stolen, {partsPopulation} citizens killed.");

                            if (cities[partsTown][0] == 0 || cities[partsTown][1] == 0)
                            {
                                cities.Remove(partsTown);
                                Console.WriteLine($"{partsTown} has been wiped off the map!");
                            }
                        }
                        break;

                    case "Prosper":
                        int partsGoldProsper = Convert.ToInt32(parts[2]);

                        if (partsGoldProsper < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            continue;
                        }

                        if (cities.ContainsKey(partsTown))
                        {
                            cities[partsTown][1] += partsGoldProsper;
                            Console.WriteLine($"{partsGoldProsper} gold added to the city treasury. {partsTown} now has {cities[partsTown][1]} gold.");
                        }
                        break;
                }
            }
        }
    }
}
