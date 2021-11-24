using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Vehicle_Catalogue
{
    public class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Type { get; }

        public string Model { get; }

        public string Color { get; }

        public int HorsePower { get; }
    }

    public static class Program
    {
        static void Main(string[] args)
        {
            IList<Vehicle> vehicles = new List<Vehicle>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] parts = input.Split(" ");

                string type = parts[0];
                string model = parts[1];
                string color = parts[2];
                int horsePower = int.Parse(parts[3]);

                var vehicle = new Vehicle(type, model, color, horsePower);
                vehicles.Add(vehicle);
            }

            while (true)
            {
                string vehicleToPrint = Console.ReadLine();

                if (vehicleToPrint == "Close the Catalogue")
                {
                    IList<Vehicle> cars = vehicles.Where(v => v.Type == "car").ToList();
                    Console.WriteLine($"Cars have average horsepower of: {cars.Average(v => v.HorsePower):F2}.");

                    IList<Vehicle> trucks = vehicles.Where(v => v.Type == "truck").ToList();
                    Console.WriteLine($"Trucks have average horsepower of: {trucks.Average(v => v.HorsePower):F2}.");
                    break;
                }

                if (vehicles.Any(v => v.Model == vehicleToPrint))
                {
                    Vehicle currentVehicle = vehicles.First(v => v.Model == vehicleToPrint);

                    Console.WriteLine($"Type: {currentVehicle.Type.First().ToString().ToUpper() + currentVehicle.Type[1..]}");
                    Console.WriteLine($"Model: {currentVehicle.Model}");
                    Console.WriteLine($"Color: {currentVehicle.Color}");
                    Console.WriteLine($"Horsepower: {currentVehicle.HorsePower}");
                }
            }
        }
    }
}
