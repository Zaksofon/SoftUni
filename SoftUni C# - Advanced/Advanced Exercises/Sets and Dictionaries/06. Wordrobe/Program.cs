using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new []{" -> "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string color = input[0];

                string[] item = input[1]
                    .Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var currentCloth in item)
                {
                    if (!wardrobe.ContainsKey(color))
                    {
                        wardrobe.Add(color, new Dictionary<string, int>());

                        if (!color.Contains(currentCloth))
                        {
                            wardrobe[color].Add(currentCloth, 1);
                            continue;
                        }

                        wardrobe[color][currentCloth]++;
                    }

                    if (wardrobe[color].ContainsKey(currentCloth))
                    {
                        wardrobe[color][currentCloth]++;
                        continue;
                    }
                    wardrobe[color].Add(currentCloth, 1);
                }
            }

            string[] lookingFor = Console.ReadLine()
                .Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string lookingForColor = lookingFor[0];
            string lookingForItem = lookingFor[1];

                foreach (var color in wardrobe)
                {
                    Console.WriteLine($"{color.Key} clothes:");

                    foreach (var item in color.Value)
                    {
                        if (color.Key == lookingForColor && item.Key == lookingForItem)
                        {
                            Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                            continue;
                        }
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
        }
    }
}
