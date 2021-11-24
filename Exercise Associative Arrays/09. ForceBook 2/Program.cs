using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook_2
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> usersByForceSide = new SortedDictionary<string, List<string>>();

            SortedDictionary<string, string> forceSideByUsers = new SortedDictionary<string, string>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Lumpawaroo")
                {
                    break;
                }

                if (line.Contains(" | "))
                {
                    string[] parts = line
                        .Split(new []{" | "}, StringSplitOptions.RemoveEmptyEntries);

                    string forceSide = parts[0];
                    string forceUser = parts[1];

                    if (!usersByForceSide.ContainsKey(forceSide))
                    {
                        usersByForceSide.Add(forceSide, new List<string>());
                    }
                    usersByForceSide[forceSide].Add(forceUser);
                    forceSideByUsers.Add(forceUser, forceSide);
                }
                else
                {
                    string[] parts = line
                        .Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                    string forceSide = parts[1];
                    string forceUser = parts[0];

                    if (!usersByForceSide.ContainsKey(forceUser))
                    {
                        usersByForceSide.Add(forceSide, new List<string>());
                    }

                    if (forceSideByUsers.ContainsKey(forceUser))
                    {
                        string oldForceSide = forceSideByUsers[forceUser];
                        usersByForceSide[oldForceSide].Remove(forceUser);
                        usersByForceSide[forceSide].Add(forceUser);
                    }
                }
            }

            ;
        }
    }
}
