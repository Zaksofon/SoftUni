using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> result = new Stack<int>(input);

            while (true)
            {
                string[] parts = Console.ReadLine()
                    .ToUpper()
                    .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                if (command == "END")
                {
                    break;
                }

                switch (command)
                {
                    case "ADD":
                        result.Push(Convert.ToInt32(parts[1]));
                        result.Push(Convert.ToInt32(parts[2]));
                        break;

                    case "REMOVE" when Convert.ToInt32(parts[1]) <= result.Count:
                        for (int i = 0; i < (Convert.ToInt32(parts[1])); i++)
                        {
                            result.Pop();
                        }
                        break;
                }
            }

            Console.WriteLine($"Sum: {result.Sum()}");
        }
    }
}
