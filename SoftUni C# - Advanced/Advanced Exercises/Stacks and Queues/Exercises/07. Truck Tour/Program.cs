using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int> petrolStations = new Queue<int>();

            for (int j = 0; j < n; j++)
            {
                petrolStations.Enqueue(j);
            }

            int counter = 0;

            while (counter != n)
            {
                int[] petrolStationsProperties = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int fuel = petrolStationsProperties[0];
                int distance = petrolStationsProperties[1];
                counter++;

                if (fuel < distance)
                {
                    petrolStations.Dequeue();
                }
                else
                {
                    petrolStations.Enqueue(petrolStations.Dequeue());
                }
            }
            Console.WriteLine(petrolStations.Peek());
        }
    }
}
