using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = new List<int>(Console.ReadLine()
                .Split("@", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            int currentPosition = 0;

            while (true)
            {
                string[] parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                if (command == "Love!")
                {
                    if (neighborhood.Sum() == 0)
                    {
                        Console.WriteLine($"Cupid's last position was {currentPosition}.");
                        Console.WriteLine("Mission was successful.");
                        return;
                    }

                    int housesWithoutValentine = neighborhood
                        .Count(h => h > 0);

                    Console.WriteLine($"Cupid's last position was {currentPosition}.");
                    Console.WriteLine($"Cupid has failed {housesWithoutValentine} places.");
                    return;
                }

                int index = int.Parse(parts[1]);

                if (command == "Jump")
                {
                    currentPosition += index;

                    if (currentPosition > neighborhood.Count - 1)
                    {
                        currentPosition = 0;
                    }

                    if (neighborhood[currentPosition] == 0)
                    {
                        Console.WriteLine($"Place {currentPosition} already had Valentine's day.");
                        continue;
                    }
                    neighborhood[currentPosition] -= 2;

                    if (neighborhood[currentPosition] == 0)
                    {
                        Console.WriteLine($"Place {currentPosition} has Valentine's day.");
                    }
                }
            }
        }
    }
}
