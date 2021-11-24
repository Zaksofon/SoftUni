using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2
{
    class Program
    {
        private static object inpit;

        static void Main(string[] args)
        {
            List<string> input = new List<string>(Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList());

            while (true)
            {
                string[] parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = parts[0];

                if (command == "Done")
                {
                    Console.WriteLine($"You crafted {string.Concat(input)}!");
                    return;
                }
                string direction = parts[1];

                if (command == "Check")
                {
                    switch (direction)
                    {
                        case "Odd":
                        {
                            List<string> result = new List<string>(input.Count);
                            result.AddRange(input.Where((t, i) => i % 2 != 0));

                            Console.WriteLine(string.Join(" ", result));
                            break;
                        }
                        case "Even":
                        {
                            List<string> result = new List<string>(input.Count);
                            result.AddRange(input.Where((t, j) => j % 2 == 0));

                            Console.WriteLine(string.Join(" ", result));
                            break;
                        }
                    }
                    continue;
                }
                int index = int.Parse(parts[2]);

                switch (command)
                {
                    case "Move" when index >= 0 && index <= input.Count - 1:

                        string currentElement = input[index];

                        switch (direction)
                        {
                            case "Right" when index + 1 >= 0 && index + 1 <= input.Count - 1:
                                input.RemoveAt(index);
                                input.Insert(index + 1, currentElement);
                                break;

                            case "Left" when index - 1 >= 0 && index - 1 <= input.Count - 1:
                                input.RemoveAt(index);
                                input.Insert(index - 1, currentElement);
                                break;
                        }
                        break;
                }
            }
        }
    }
}
