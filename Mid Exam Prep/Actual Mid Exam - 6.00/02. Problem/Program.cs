using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> gifts = new List<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList());

            while (true)
            {
                string[] parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                if (command == "No")
                {
                    if (gifts.Contains("None"))
                    {
                        List<string> result = gifts
                            .Where(i => i != "None")
                            .ToList();

                        Console.WriteLine(string.Join(" ", result));
                        return;
                    }
                    Console.WriteLine(string.Join(" ", gifts));
                    return;
                }

                string gift = parts[1];

                switch (command)
                {
                    case "OutOfStock" when gifts.Contains(gift):

                        for (int i = 0; i <= gifts.Count - 1; i++)
                        {
                            if (gifts[i] == gift)
                            {
                                int currentIndex = i;
                                gifts.Remove(gift);
                                gifts.Insert(currentIndex, "None");
                            }
                        }
                        break;

                    case "Required":
                        int index = int.Parse(parts[2]);

                        if (index >= 0 && index <= gifts.Count - 1)
                        {
                            gifts.RemoveAt(index);
                            gifts.Insert(index, gift);
                        }
                        break;

                    case "JustInCase":
                        gifts.RemoveAt(gifts.Count - 1);
                        gifts.Add(gift);
                        break;
                }
            }
        }
    }
}
