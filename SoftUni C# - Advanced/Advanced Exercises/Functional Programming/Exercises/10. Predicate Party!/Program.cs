using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string[] line = Console.ReadLine()
                    .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = line[0];

                switch (command)
                {
                    case "Remove":
                        string subCommand = line[1];

                        switch (subCommand)
                        {
                            case "StartsWith":
                                names.RemoveAll(x => x.Contains(line[2]));
                                break;

                            case "EndsWith":
                                names.RemoveAll(x => x.Contains(line[2]));
                                break;

                            case "Length":
                                names.RemoveAll(x => x.Length == Convert.ToInt32(line[2]));
                                break;
                        }
                        break;

                    case "Double":
                        subCommand = line[1];

                        switch (subCommand)
                        {
                            case "StartsWith":

                                for (var i = 0; i < names.Count; i++)
                                {
                                    if (names[i].Contains(line[2]))
                                    {
                                        names.Insert(i + 1, names[i]);
                                        i++;
                                    }
                                }
                                break;

                            case "EndsWith":
                                for (int i = 0; i < names.Count; i++)
                                {
                                    if (names[i].Contains(line[2]))
                                    {
                                        names.Insert(i + 1, names[i]);
                                        i++;
                                    }
                                }
                                break;

                            case "Length":
                                for (int i = 0; i < names.Count; i++)
                                {
                                    if (names[i].Length == Convert.ToInt32(line[2]))
                                    {
                                        string currentName = names[i];

                                        names.Insert(i, currentName);
                                        break;
                                    }
                                }
                                break;
                        }
                        break;

                    case "Party!":
                        if (names.Count > 0)
                        {
                            Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
                            return;
                        }

                        Console.WriteLine("Nobody is going to the party!");
                        return;
                }
            }
        }
    }
}
