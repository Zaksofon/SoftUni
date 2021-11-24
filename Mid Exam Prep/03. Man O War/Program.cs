using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = new List<int>(Console.ReadLine()
                .Split(">", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList()); 

            List<int> warShip = new List<int>(Console.ReadLine()
                .Split(">", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            int maxHealthCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string[] parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                if (command == "Retire")
                {
                    Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
                    Console.WriteLine($"Warship status: {warShip.Sum()}");
                    return;
                }

                if (command == "Status")
                {
                    int counter = pirateShip.Count(number => number < maxHealthCapacity * 0.2);

                    Console.WriteLine($"{counter} sections need repair.");
                    continue;
                }

                int index = int.Parse(parts[1]);

                if (command == "Fire" && index <= warShip.Count - 1 && index >= 0)
                {
                    int damage = int.Parse(parts[2]);

                    warShip[index] -= damage;

                    if (warShip[index] <= 0)
                    {
                        Console.WriteLine("You won! The enemy ship has sunken.");
                        return;
                    }
                }

                if (command == "Defend" && index >= 0 && int.Parse(parts[2]) <= pirateShip.Count - 1)
                {
                    int endIndex = int.Parse(parts[2]);
                    int damage = int.Parse(parts[3]);

                    for (int i = index; i <= endIndex; i++)
                    {
                        pirateShip[i] -= damage;

                        if (pirateShip[i] <= 0)
                        {
                            Console.WriteLine("You lost! The pirate ship has sunken.");
                            return;
                        }
                    }
                }

                if (command == "Repair" && index <= pirateShip.Count - 1 && index >= 0)
                {
                    int health = int.Parse(parts[2]);

                    pirateShip[index] += health;

                    if (pirateShip[index] > maxHealthCapacity)
                    {
                        pirateShip[index] = maxHealthCapacity;
                    }
                }
            }
        }
    }
}
