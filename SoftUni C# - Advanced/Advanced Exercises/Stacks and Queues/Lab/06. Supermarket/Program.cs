using System;
using System.Collections.Generic;

namespace _6.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();


            while (true)
            {
                string name = Console.ReadLine();

                if (name == "End")
                {
                    Console.WriteLine($"{queue.Count} people remaining.");
                    break;
                }

                if (name == "Paid")
                {
                    for (int i = 0; i <= queue.Count + 1; i++)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                    continue;
                }
                queue.Enqueue(name);
            }
        }
    }
}