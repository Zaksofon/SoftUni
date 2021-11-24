using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Statistics")
                {
                    Console.WriteLine($"Users count: {users.Count}");

                    users = users
                        .OrderByDescending(r => r.Value.Count)
                        .ThenBy(k => k.Key)
                        .ToDictionary(x => x.Key, y => y.Value);

                    foreach (var name in users)
                    {
                        Console.WriteLine($"{name.Key}");

                        foreach (var message in name.Value)
                        {
                            Console.WriteLine($" - {message}");
                        }
                    }
                    break;
                }

                string[] parts = line
                    .Split(new[] {"->"}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = parts[0];
                string user = parts[1];

                switch (command)
                {
                    case "Add":
                        if (!users.ContainsKey(user))
                        {
                            users.Add(user, new List<string>());
                            continue;
                        }
                        Console.WriteLine($"{user} is already registered");
                        break;

                    case "Send":
                        string email = parts[2];
                        if (users.ContainsKey(user))
                        {
                            users[user].Add(email);
                        }
                        break;

                    case "Delete":
                        if (users.ContainsKey(user))
                        {
                            users.Remove(user);
                            continue;
                        }
                        Console.WriteLine($"{user} not found!");
                        break;
                }
            }
        }
    }
}
