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
                string[] parts = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string model = parts[0];

                int engineSpeed = int.Parse(parts[1]);
                int enginePower = int.Parse(parts[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(parts[3]);
                string cargoType = parts[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                double tire1Pressure = double.Parse(parts[5]);
                int tire1Age = int.Parse(parts[6]);
                double tire2Pressure = double.Parse(parts[7]);
                int tire2Age = int.Parse(parts[8]);
                double tire3Pressure = double.Parse(parts[9]);
                int tire3Age = int.Parse(parts[10]);
                double tire4Pressure = double.Parse(parts[11]);
                int tire4Age = int.Parse(parts[12]);
                Tire[] tires = new Tire[]
                {
                    new Tire(tire1Pressure, tire1Age),
                    new Tire(tire2Pressure, tire2Age),
                    new Tire(tire3Pressure, tire3Age),
                    new Tire(tire4Pressure, tire4Age)
                };

                cars.Add(new Car(model, engine, cargo, tires));
            }

            string line = Console.ReadLine();

            if (line == "fragile")
            {
                List<Car> filteredCars = cars
                    .Where(c => c.Cargo.CargoType == "fragile" && c.Tire.Any(t => t.Pressure < 1))
                    .ToList();
                foreach (var car in filteredCars)
                {
                    Console.WriteLine(car.Model);
                }
                return;
            }
            if (line == "flamable")
            {
                List<Car> filteredCars = cars
                    .Where(c => c.Cargo.CargoType == "flamable" && c.Engine.Power > 250)
                    .ToList();
                foreach (var car in filteredCars)
                {
                    Console.WriteLine(car.Model);
                }
                return;
            }

        }
    }
}
