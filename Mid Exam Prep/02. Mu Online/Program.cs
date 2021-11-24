using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialHealthPoints = 100;

            int initialBitcoinAmount = 0;

            List<string> inputDungeons = new List<string>(Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries));

            for (int i = 0; i < inputDungeons.Count; i++)
            {
                List<string> currentRoom = inputDungeons[i]
                    .Split(" ")
                    .ToList();

                string monster = currentRoom[0];
                int points = int.Parse(currentRoom[1]);

                if (monster == "chest" || monster == "potion")
                {
                    switch (monster)
                    {
                        case "chest":
                            initialBitcoinAmount += points;
                            Console.WriteLine($"You found {points} bitcoins.");
                            break;

                        case "potion":
                            if ((initialHealthPoints + points) > 100)
                            {
                                int currentPoints = 100 - initialHealthPoints;
                                initialHealthPoints = 100;
                                Console.WriteLine($"You healed for {currentPoints} hp.");
                                Console.WriteLine($"Current health: {initialHealthPoints} hp.");
                                break;
                            }
                            initialHealthPoints += points;
                            Console.WriteLine($"You healed for {points} hp.");
                            Console.WriteLine($"Current health: {initialHealthPoints} hp.");
                            break;
                    }
                }
                else
                {
                    initialHealthPoints -= points;

                    if (initialHealthPoints > 0)
                    {
                        Console.WriteLine($"You slayed {monster}.");
                        continue;
                    }

                    Console.WriteLine($"You died! Killed by {monster}.");
                    Console.WriteLine($"Best room: {i + 1}");
                    break;
                }
            }
            if (initialHealthPoints > 0)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {initialBitcoinAmount}");
                Console.WriteLine($"Health: {initialHealthPoints}");
            }
        }
    }
}
