using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = line[0];
                double fuelAmount = double.Parse(line[1]);
                double fuelConsumptionFor1km = double.Parse(line[2]);

                Car currentCar = new Car()
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumptionPerKilometer = fuelConsumptionFor1km
                };
                cars.Add(currentCar);
            }

            while (true)
            {
               string input = Console.ReadLine();

                if (input == "End")
                {
                    foreach (var car in cars)
                    {
                        Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TraveledDistance}");
                    }
                    return;
                }
                string[] commandLine = input
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commandLine[0];
                string makeAndModel = commandLine[1];
                double distance = double.Parse(commandLine[2]);

                if (command == "Drive")
                {
                    Car car = cars
                        .FirstOrDefault(c => c.Model == makeAndModel);

                    bool isDriven = car.Move(distance);

                    if (isDriven == false)
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }
                }
            }
        }
    }
}
