using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = new List<string>(Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList());

            while (true)
            {
                string[] parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                if (command == "Yohoho!")
                {
                    if (chest.Count == 0)
                    {
                        Console.WriteLine("Failed treasure hunt.");
                        return;
                    }
                    int sum = 0;

                    foreach (var letters in chest)
                    {
                        for (int i = 0; i < letters.Length; i++)
                        {
                            sum++;
                        }
                    }
                    double result = sum * 1.00 / chest.Count;

                    Console.WriteLine($"Average treasure gain: {result:F2} pirate credits.");
                    return;
                }

                switch (command)
                {
                    case "Loot":
                        for (int i = 1; i <= parts.Length - 1; i++)
                        {
                            if (chest.Contains(parts[i]))
                            {
                                continue;
                            }
                            chest.Insert(0, parts[i]);
                        }
                        break;

                    case "Drop" when int.Parse(parts[1]) >= 0 && int.Parse(parts[1]) <= chest.Count - 1:

                        int index = int.Parse(parts[1]);

                        string tempItem = chest[index];

                        chest.RemoveAt(index);

                        chest.Add(tempItem);
                        break;

                    case "Steal":
                        index = int.Parse(parts[1]);

                        if (index > chest.Count)
                        {
                            index = chest.Count;
                        }

                        List<String> stolenItems = new List<string>(chest)
                            .Skip(chest.Count - index)
                            .Take(index)
                            .ToList();

                        chest.RemoveRange(chest.Count - index, index);

                        Console.WriteLine(string.Join(", ", stolenItems));
                        break;
                }
            }
        }
    }
}
