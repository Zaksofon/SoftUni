using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Exercise__Regular_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@">>(?<name>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)");

            List<string> furniture = new List<string>();
            double sum = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Purchase")
                {
                    break;
                }

                Match match = regex.Match(input);

                if (!match.Success)
                {
                    continue;
                }
                string name = match.Groups["name"].Value;
                double price = double.Parse(match.Groups["price"].Value);
                int quantity = int.Parse(match.Groups["quantity"].Value);

               furniture.Add(name);
               sum += price * quantity;
            }
            Console.WriteLine("Bought furniture:");

            foreach (var item in furniture)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {sum:F2}");
        }
    }
}
