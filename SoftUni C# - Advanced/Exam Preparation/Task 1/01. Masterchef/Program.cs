using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray());

            Stack<int> freshness = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> food = new Dictionary<string, int>()
            {
                {"Dipping sauce", 0},
                {"Green salad", 0},
                {"Chocolate cake", 0},
                {"Lobster", 0}
            };

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                int result = ingredients.Peek() * freshness.Peek();
                freshness.Pop();

                switch (result)
                {
                    case 150:
                        food["Dipping sauce"] += 1;
                        ingredients.Dequeue();
                        break;

                    case 250:
                        food["Green salad"] += 1;
                        ingredients.Dequeue();
                        break;

                    case 300:
                        food["Chocolate cake"] += 1;
                        ingredients.Dequeue();
                        break;

                    case 400:
                        food["Lobster"] += 1;
                        ingredients.Dequeue();
                        break;

                    default:
                        ingredients.Enqueue(ingredients.Dequeue() + 5);
                        break;
                }
            }

            Console.WriteLine(food.All(x => x.Value > 0)
                ? "Applause! The judges are fascinated by your dishes!"
                : "You were voted off. Better luck next year.");

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var item in food.OrderBy(x => x.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($" # {item.Key} --> {item.Value}");
                }
            }
        }
    }
}
