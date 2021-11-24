using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryItems = new Dictionary<string, int>
            {
                {"shards", 0},
                {"fragments", 0},
                {"motes", 0},
            };

            SortedDictionary<string, int> junkItems = new SortedDictionary<string, int>();

            while (true)
            {
                string[] parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < parts.Length; i += 2)
                {
                    int value = int.Parse(parts[i]);
                    string item = parts[i + 1].ToLower();

                    if (legendaryItems.ContainsKey(item))
                    {
                        legendaryItems[item] += value;

                        if (legendaryItems[item] >= 250)
                        {
                            legendaryItems[item] -= 250;

                            string legendaryItem = " ";

                            switch (item)
                            {
                                case "shards":
                                    legendaryItem = "Shadowmourne";
                                    break;
                                case "fragments":
                                    legendaryItem = "Valanyr";
                                    break;
                                case "motes":
                                    legendaryItem = "Dragonwrath";
                                    break;
                            }
                            Console.WriteLine($"{legendaryItem} obtained!");

                            Dictionary<string, int> sortedLegendaryItems = legendaryItems
                                .OrderByDescending(k => k.Value)
                                .ThenBy(k => k.Key)
                                .ToDictionary(x => x.Key, x => x.Value);

                            foreach (var kvp in sortedLegendaryItems)
                            {
                                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                            }

                            foreach (var kvp in junkItems)
                            {
                                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                            }
                            return;
                        }
                    }

                    else if (junkItems.ContainsKey(item))
                    {
                        junkItems[item] += value;
                    }

                    else
                    {
                        junkItems.Add(item, value);
                    }
                }
            }
        }
    }
}
