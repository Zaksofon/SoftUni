using System;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string[] parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];
                string name = parts[1];

                if (command == "register")
                {
                    string regNumber = parts[2];

                    if (users.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {regNumber}");
                        continue;
                    }

                    users.Add(name, regNumber);
                    Console.WriteLine($"{name} registered {regNumber} successfully");
                    continue;
                }

                if (!users.ContainsKey(name))
                {
                    Console.WriteLine($"ERROR: user {name} not found");
                    continue;
                }

                users.Remove(name);
                Console.WriteLine($"{name} unregistered successfully");
            }

            foreach (var kvp in users)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
