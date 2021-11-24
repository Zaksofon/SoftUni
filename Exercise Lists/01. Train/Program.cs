using System;
using System.Collections.Generic;
using System.Linq;

namespace Lists_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = line[0];

                if (command == "end")
                {
                    Console.WriteLine(string.Join(" ", wagons));
                    return;
                }
                if (command == "Add")
                {
                    wagons.Add(int.Parse(line[1]));
                }
                else
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if ((wagons[i] + int.Parse(command)) <= maxCapacity)
                        {
                            wagons.Insert(i, wagons[i] + (int.Parse(command)));
                            wagons.Remove(wagons[i + 1]);
                            break;
                        }
                    }
                }
            }
        }
    }
}
