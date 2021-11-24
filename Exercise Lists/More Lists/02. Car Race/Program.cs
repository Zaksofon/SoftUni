using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lapsTime = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            double lappsTimeTotal = 0;

            while (true)
            {
                if (lapsTime.Count / 2 == 0)
                {
                    break;
                }

                for (int i = 0; i < lapsTime.Count/2; i++)
                {
                    lappsTimeTotal += lapsTime[i];

                    if (lapsTime[i] == 0)
                    {
                        lappsTimeTotal *= 0.8;
                    }
                }
            }

            Console.WriteLine(lappsTimeTotal);
        }
    }
}
