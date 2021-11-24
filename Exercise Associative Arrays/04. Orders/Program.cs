using System;
using System.Collections.Generic;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> priceByProduct = new Dictionary<string, double>();
            Dictionary<string, int> quantityByProduct = new Dictionary<string, int>();

            while (true)
            {
                string[] parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                if (command == "buy")
                {
                    foreach (var kvp in priceByProduct)
                    {
                        string product = kvp.Key;
                        double totalPrice = kvp.Value;
                        int totalQuantity = quantityByProduct[product];

                        double total = totalPrice * totalQuantity;

                        Console.WriteLine($"{kvp.Key} -> {total:F2}");
                    }
                    break;
                }

                double price = double.Parse(parts[1]);
                int quantity = int.Parse(parts[2]);

                if (priceByProduct.ContainsKey(command))
                {
                    priceByProduct[command] = price;
                    quantityByProduct[command] += quantity;
                }
                else
                {
                    priceByProduct.Add(command, price);
                    quantityByProduct.Add(command, quantity);
                }
            }
        }
    }
}
