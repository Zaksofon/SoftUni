using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _4._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = line[0];

                if (command == "End")
                {
                    break;
                }

                if (command == "Add")
                {
                    numbers.Add(int.Parse(line[1]));
                }

                else if (command == "Insert")
                {
                    int index = int.Parse(line[2]);

                    if (!IsValid(index, numbers))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.Insert(int.Parse(line[2]), int.Parse(line[1]));
                }

                else if (command == "Remove")
                {
                    int index = int.Parse(line[1]);

                    if (!IsValid(index, numbers))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.RemoveAt(int.Parse(line[1]));
                }

                else if (command == "Shift")
                {
                    string direction = line[1];

                    if (direction == "left")
                    {
                        int count = int.Parse(line[2]);

                        for (int i = 0; i < count; i++)
                        {
                            int firstInteger = numbers[0];
                            
                            numbers.RemoveAt(0);
                            numbers.Add(firstInteger);
                        }
                    }

                    else
                    {
                        int count = int.Parse(line[2]);

                        for (int i = 0; i < count; i++)
                        {
                            int lastInteger = numbers[numbers.Count - 1];

                            numbers.RemoveAt(numbers.Count - 1);
                            numbers.Insert(0, lastInteger);
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static bool IsValid(int index, List<int> numbers)
        {
            return index >= 0 && index < numbers.Count;
        }
    }
}
