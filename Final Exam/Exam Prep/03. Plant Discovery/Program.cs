using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3.Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, double[]> plantsCollection = new Dictionary<string, double[]>();

            for (int i = 0; i < n; i++)
            {
                string[] plants = Console.ReadLine()
                    .Split(new[] {"<->"}, StringSplitOptions.RemoveEmptyEntries);

                string plant = plants[0];
                double rarity = double.Parse(plants[1]);
                double rating = 0;

                if (!plantsCollection.ContainsKey(plant))
                {
                    plantsCollection.Add(plant, new []{rarity, rating});

                    if (plantsCollection.ContainsKey(plant))
                    {
                        plantsCollection[plant][0] = rarity;
                    }
                }
            }
            int ratingCounter = 1;
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Exhibition")
                {
                    plantsCollection = plantsCollection
                        .OrderByDescending(r => r.Value[0])
                        .ThenByDescending(k => k.Value[1])
                        .ToDictionary(x => x.Key, y => y.Value);

                    Console.WriteLine("Plants for the exhibition:");

                    foreach (var item in plantsCollection)
                    {
                        Console.WriteLine($"- {item.Key}; Rarity: {item.Value[0]}; Rating: {item.Value[1]:F2}");
                    }
                    break;
                }
               
                string[] parts = line
                    .Split(new[] {": "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = parts[0];

                string[] subCommand = parts[1]
                    .Split(new[] {" - "}, StringSplitOptions.RemoveEmptyEntries);

                string currentPlant = subCommand[0];

                if ((command == null) || (command != "Rate" && command != "Update" && command != "Reset") || (plantsCollection.ContainsKey(currentPlant) == false))
                {
                    Console.WriteLine("error");
                    continue;
                }

                switch (command)
                {
                    case "Rate":
                        double rating = double.Parse(subCommand[1]);
                        if (plantsCollection[currentPlant][1] != 0)
                        {
                            ratingCounter++;
                            double avgRating = (plantsCollection[currentPlant][1] + rating) / ratingCounter;
                            plantsCollection[currentPlant][1] = avgRating;
                            continue;
                        }
                        plantsCollection[currentPlant][1] += rating;
                        break;

                    case "Update":
                        double newRarity = double.Parse(subCommand[1]);
                        plantsCollection[currentPlant][0] = newRarity;
                        break;

                    case "Reset":
                        plantsCollection[currentPlant][1] = 0; 
                        break;
                }
            }
        }
    }
}
