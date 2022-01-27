using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray());

            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> food = new Dictionary<string, int>()
            {
                {"Bread", 0},
                {"Cake", 0},
                {"Pastry", 0},
                {"Fruit Pie", 0}
            };

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int result = liquids.Peek() + ingredients.Peek();
                liquids.Dequeue();

                switch (result)
                {
                    case 25:
                        food["Bread"] += 1;
                        ingredients.Pop();
                        break;

                    case 50:
                        food["Cake"] += 1;
                        ingredients.Pop();
                        break;

                    case 75:
                        food["Pastry"] += 1;
                        ingredients.Pop();
                        break;

                    case 100:
                        food["Fruit Pie"] += 1;
                        ingredients.Pop();
                        break;

                    default:
                        ingredients.Push(ingredients.Pop() + 3);
                        break;
                }
            }

            Console.WriteLine(food.All(x => x.Value > 0)
                ? "Wohoo! You succeeded in cooking all the food!"
                : "Ugh, what a pity! You didn't have enough materials to cook everything.");

            Console.WriteLine(liquids.Any() 
                ? $"Liquids left: {string.Join(", ", liquids)}" 
                : "Liquids left: none");

            Console.WriteLine(ingredients.Any()
                ? $"Ingredients left: {string.Join(", ", ingredients)}"
                : "Ingredients left: none");

            foreach (var item in food.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}