using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();

            while (true)
            {
                string metal = Console.ReadLine();

                if (metal == "stop")
                {
                    break;
                }

                int value = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(metal))
                {
                    resources[metal] += value;
                }
                else
                {
                    resources.Add(metal, value);
                }

            }

            foreach (var kvp in resources)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
