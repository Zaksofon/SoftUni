using System;
using System.Collections.Generic;

namespace _8.Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> crossroad = new Queue<string>();
            int counter = 0;

            while (true)
            {
                string carModel = Console.ReadLine();

                switch (carModel)
                {
                    case "green":
                        for (int i = 0; i <= n; i++)
                        {
                            if (i == n || crossroad.Count == 0)
                            {
                                break;
                            }
                            Console.WriteLine($"{crossroad.Dequeue()} passed!");
                            counter++;
                        }
                        continue;

                    case "end":
                        Console.WriteLine($"{counter} cars passed the crossroads.");
                        return;
                }
                crossroad.Enqueue(carModel);
            }
        }
    }
}