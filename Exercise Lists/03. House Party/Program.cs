using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = new List<string>();

            int iterationsCounter = 0;

            while (iterationsCounter != n)
            {
                string[] parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = parts[0];

                iterationsCounter++;

                for (int i = 0; i <= parts.Length; i++)
                {
                    if (parts.Length == 3)
                    {
                        if (names.Contains(name))
                        {
                            Console.WriteLine($"{name} is already in the list!");
                            break;
                        }
                        else
                        {
                            names.Add(name);
                            break;
                        }
                    }
                    else
                    {
                        if (!names.Remove(name))
                        {
                            Console.WriteLine($"{name} is not in the list!");
                            break;
                        }
                        else
                        {
                            names.Remove(name);
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join("\n", names));
        }
    }
}
