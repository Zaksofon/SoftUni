using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, string[]> result = new Dictionary<string, string[]>();

            Regex regex = new Regex(@"(#|\|)(?<food>[A-Za-z\s]+)\1(?<exp>[\d\/\d\/\d\/]{8})\1(?<nutrition>[0-9]{1,5})\1", RegexOptions.Compiled);

            int nutritionSum = 0;

            foreach (Match item in regex.Matches(input))
            {
                string food = item.Groups["food"].Value;
                string expire = item.Groups["exp"].Value;
                int nutrition = int.Parse(item.Groups["nutrition"].Value);
                nutritionSum += nutrition;

                result.Add(food, new[] { expire, Convert.ToString(nutrition) });
                result = result.ToDictionary(k => k.Key, v => v.Value);
            }
            int days = nutritionSum / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (var food in result)
            {
                Console.WriteLine($"Item: {food.Key}, Best before: {food.Value[0]}, Nutrition: {food.Value[1]}");
            }
        }
    }
}
