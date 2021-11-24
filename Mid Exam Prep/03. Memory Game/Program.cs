using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Memory_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = new List<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList());

            int counter = 0;

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];

                if (command == "end")
                {
                    Console.WriteLine("Sorry you lose :(");
                    Console.WriteLine(string.Join(" ", numbers));
                    break;
                }
                counter++;

                int firstIndex = int.Parse(input[0]);
                int secondIndex = int.Parse(input[1]);

                if (firstIndex >= 0 && firstIndex <= numbers.Count - 1 && secondIndex >= 0 && secondIndex <= numbers.Count - 1 && firstIndex != secondIndex)
                {
                    if (numbers[firstIndex] != numbers[secondIndex])
                    {
                        Console.WriteLine("Try again!");
                        continue;
                    }
                    string currentElement = numbers[firstIndex];

                    if (numbers[firstIndex] == numbers[secondIndex])
                    {
                        numbers.RemoveAll(n => n == currentElement);
                        Console.WriteLine($"Congrats! You have found matching elements - {currentElement}!");
                    }
                }

                else
                {
                    numbers.Insert(numbers.Count / 2, string.Concat("-", (counter), "a"));
                    numbers.Insert(numbers.Count / 2, string.Concat("-", (counter), "a"));

                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }

                if (numbers.Count == 0)
                {
                    Console.WriteLine($"You have won in {counter} turns!");
                    break;
                }
            }
        }
    }
}
