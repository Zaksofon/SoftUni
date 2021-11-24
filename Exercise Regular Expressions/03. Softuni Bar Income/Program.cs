using System;
using System.Text.RegularExpressions;

namespace _03.SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalSum = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of shift")
                {
                    break;
                }

                Regex regex = new Regex(@"^[^|$%.]*%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)[^|$%.]*\|(?<price>\d+\.?\d+)[^|$%.]*\$$");

                Match match = regex.Match(input);

                if (!match.Success)
                {
                    continue;
                }

                string name = match.Groups["name"].Value;
                string product = match.Groups["product"].Value;
                int quantity = int.Parse(match.Groups["quantity"].Value);
                double price = double.Parse(match.Groups["price"].Value);

                double sum = price * quantity;
                totalSum += sum;

                Console.WriteLine(value: $"{name}: {product} - {sum:F2}");
            }

            Console.WriteLine($"Total income: {totalSum:F2}");
        }
    }
}