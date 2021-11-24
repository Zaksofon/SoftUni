using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3.Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> cars = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] {"|"}, StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int mileage = int.Parse(input[1]);
                int fuel = int.Parse(input[2]);

                if (!cars.ContainsKey(model))
                {
                    cars.Add(model, new List<int> {mileage, fuel});
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Stop")
                {
                    cars = cars
                        .OrderByDescending(m => m.Value[0])
                        .ThenByDescending(c => c.Key)
                        .ToDictionary(x => x.Key, y => y.Value);

                    foreach (var model in cars.Keys)
                    {
                        Console.WriteLine($"{model} -> Mileage: {cars[model][0]} kms, Fuel in the tank: {cars[model][1]} lt.");
                    }
                    break;
                }
                string[] parts = line
                    .Split(new[] {" : "}, StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];
                string car = parts[1];

                switch (command)
                {
                    case "Drive":
                        int distance = int.Parse(parts[2]);
                        int fuel = int.Parse(parts[3]);

                        if (cars[car][1] >= fuel)
                        {
                            cars[car][1] -= fuel;
                            cars[car][0] += distance;
                            Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                            if (cars[car][0] >= 100000)
                            {
                                cars.Remove(car);
                                Console.WriteLine($"Time to sell the {car}!");
                            }
                            continue;
                        }
                        Console.WriteLine("Not enough fuel to make that ride");
                        break;

                    case "Refuel":
                        int refuel = int.Parse(parts[2]);
                        int currentFuelLevel = 75 - cars[car][1];

                        if (currentFuelLevel > refuel)
                        {
                            currentFuelLevel = refuel;
                        }
                        cars[car][1] += refuel;

                        if (cars[car][1] > 75)
                        {
                            cars[car][1] = 75;
                        }

                        Console.WriteLine($"{car} refueled with {currentFuelLevel} liters");
                        break;
                      
                    case "Revert":
                        int kilometers = int.Parse(parts[2]);

                            if ((cars[car][0] - kilometers) < 10000)
                            {
                                cars[car][0] = 10000;
                                Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                                continue;
                            }

                        cars[car][0] -= kilometers;
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                        break;
                }
            }
        }
    }
}
