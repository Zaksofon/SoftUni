using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inventory = new List<string>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries));

            while (true)
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    List<string> input = new List<string>(Console.ReadLine()
                        .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                        .ToList());

                    string command = input[0];

                    if (command == "Craft!")
                    {
                        Console.WriteLine(String.Join(", ", inventory));
                        return;
                    }
                    string newItem = input[1];

                    if (command == "Collect")
                    {
                        if (inventory.Contains(newItem))
                        {
                            continue;
                        }

                        inventory.Add(newItem);
                        break;
                    }
                    
                    if (command == "Drop" && inventory.Contains(newItem))
                    {
                        inventory.Remove(newItem);
                        break;
                    }

                    if (command == "Combine Items")
                    {
                        List<string> newItemCombined = input[1]
                            .Split(":", StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

                        newItem = newItemCombined[1];

                        if (inventory.Contains(newItemCombined[0]) && !inventory.Contains(newItemCombined[1]))
                        {
                            int indexToCombineWith = inventory.FindIndex(i => i == newItemCombined[0]);
                            inventory.Insert(indexToCombineWith + i, newItem);
                        }
                        break;
                    }

                    if (command == "Renew" && inventory.Contains(newItem))
                    {
                        inventory.Remove(newItem);
                        inventory.Add(newItem);
                        break;
                    }
                }
            }
        }
    }
}