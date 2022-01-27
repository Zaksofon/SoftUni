using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, int> indexes = new Dictionary<string, int>();

            while (true)
            {
                List<string> line = Console.ReadLine()
                    .Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string command = line[0];

                switch (command)
                {
                    case "Add filter":
                        string subCommand = line[1];

                        switch (subCommand)
                        {
                            case "Starts with":
                                foreach (var name in names.Where(name => name.StartsWith(line[2])).ToList())
                                {
                                    indexes.Add(name, names.IndexOf(name));
                                }
                                names.RemoveAll(n => n.StartsWith(line[2]));
                                break;

                            case "Ends with":
                                foreach (var name in names.Where(name => name.EndsWith(line[2])).ToList())
                                {
                                    indexes.Add(name, names.IndexOf(name));
                                }
                                names.RemoveAll(n => n.EndsWith(line[2]));
                                break;

                            case "Length" when char.IsDigit(Convert.ToChar(line[2])):
                                foreach (var name in names.Where(name => name.Length == Convert.ToInt32(line[2])).ToList())
                                {
                                    indexes.Add(name, names.IndexOf(name));
                                }
                                names.RemoveAll(n => n.Length == Convert.ToInt32(line[2]));
                                break;

                            case "Contains":
                                foreach (var name in names.Where(name => name.Contains(line[2])).ToList())
                                {
                                    indexes.Add(name, names.IndexOf(name));
                                }
                                names.RemoveAll(n => n.Contains(line[2]));
                                break;
                        }
                        break;

                    case "Remove filter":
                        subCommand = line[1];
                        List<string> curName = new List<string>();

                        switch (subCommand)
                        {
                            case "Starts with":
                                foreach (var name in indexes.Where(name => name.Key.StartsWith(line[2])))
                                {
                                    names.Insert(name.Value, name.Key);
                                    curName.Add(Convert.ToString(name.Key));
                                }

                                for (int i = 0; i < curName.Count; i++)
                                {
                                    if (indexes.ContainsKey(curName[i]))
                                    {
                                        indexes.Remove(curName[i]);
                                    }
                                }
                                break;

                            case "Ends with":
                                foreach (var name in indexes.Where(name => name.Key.EndsWith(line[2])))
                                {
                                    names.Insert(name.Value, name.Key);
                                    curName.Add(Convert.ToString(name.Key));
                                }

                                for (int i = 0; i < curName.Count; i++)
                                {
                                    if (indexes.ContainsKey(curName[i]))
                                    {
                                        indexes.Remove(curName[i]);
                                    }
                                }
                                break;

                            case "Length" when char.IsDigit(Convert.ToChar(line[2])):
                                foreach (var name in indexes.Where(name => name.Key.Length == Convert.ToInt32(line[2])))
                                {
                                    names.Insert(name.Value, name.Key);
                                    curName.Add(Convert.ToString(name.Key));
                                }

                                for (int i = 0; i < curName.Count; i++)
                                {
                                    if (indexes.ContainsKey(curName[i]))
                                    {
                                        indexes.Remove(curName[i]);
                                    }
                                }
                                break;

                            case "Contains":
                                foreach (var name in indexes.Where(name => name.Key.Contains(line[2])))
                                {
                                    names.Insert(name.Value, name.Key);
                                    curName.Add(Convert.ToString(name.Key));
                                }

                                for (int i = 0; i < curName.Count; i++)
                                {
                                    if (indexes.ContainsKey(curName[i]))
                                    {
                                        indexes.Remove(curName[i]);
                                    }
                                }
                                break;
                        }
                        break;

                    case "Print" when names.Any():
                        Console.WriteLine(string.Join(" ", names));
                        return;
                }
            }
        }
    }
}
