using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    class Program
    {
        private static string n;

        static void Main(string[] args)
        {
            List<string> items = new List<string>(Console.ReadLine()
                .Split("!", StringSplitOptions.RemoveEmptyEntries)
                .ToList());

            while (true)
            {
                List<string> parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string command = parts[0];
                string item = parts[1];

                if (command == "Go")
                {
                    Console.WriteLine(string.Join(", ", items));
                    return;
                }
                string newItem = " ";

                switch (command)
                {
                    case "Urgent" when !items.Contains(item):
                        items.Insert(0, item);
                        break;

                    case "Unnecessary" when items.Contains(item):
                        items.Remove(item);
                        break;

                    case "Correct" when items.Contains(item):
                        newItem = parts[2];
                        int itemToBeRemovedCurrentPosition = items.IndexOf(item);
                        items.Remove(item);
                        items.Insert(itemToBeRemovedCurrentPosition, newItem);
                        break;

                    case "Rearrange" when items.Contains(item):
                        items.Remove(item);
                        items.Add(item);
                        break;
                }
            }
        }
    }
}
