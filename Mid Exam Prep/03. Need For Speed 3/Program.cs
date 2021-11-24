using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int myCars = int.Parse(Console.ReadLine());

            List<string> result = new List<string>(3 * myCars);

            for (int i = 1; i <= myCars; i++)
            {
                List<String> carProperties = new List<string>(Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToList());

                string vehicle = carProperties[0];
                int mileage = int.Parse(carProperties[1]);
                int fuelAvaliable = int.Parse(carProperties[2]);

                for (int j = 0; j < myCars; j++)
                {
                    result.Add(vehicle);
                    result.Add(Convert.ToString(mileage));
                    result.Add(Convert.ToString(string.Concat(fuelAvaliable, "|")));
                    break;
                }

                while (true)
                {
                    List<string> parts = new List<string>(Console.ReadLine()
                        .Split(":", StringSplitOptions.RemoveEmptyEntries)
                        .ToList());

                    string command = parts[0];
                    string car = parts[1];
                    int fuel = 0;
                    int distance = 0;

                    switch (command)
                    {
                        case "Drive":
                            fuel = int.Parse(parts[3]);
                            distance = int.Parse(parts[2]);

                            if (distance >= fuel)
                            {
                                Console.WriteLine("Not enough fuel to make that ride");
                                break;
                            }
                            mileage += distance;
                            fuelAvaliable -= fuel;
                            Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                            if (mileage >= 100000)
                            {
                                Console.WriteLine($"Time to sell the {car}!");
                            }
                            break;

                        case "Refuel":
                            fuel = int.Parse(parts[2]);
                            fuelAvaliable += fuel;

                            if (fuelAvaliable >= 75)
                            {
                                fuelAvaliable = 75;
                            }

                            Console.WriteLine($"{car} refueled with {fuel} liters");
                            break;

                        case "Revert":
                            distance = int.Parse(parts[2]);
                            mileage -= distance;

                            if (mileage < 10000)
                            {
                                mileage = 10000;
                                break;
                            }

                            Console.WriteLine($"{car} mileage decreased by {distance} kilometers");
                            break;
                    }
                }
            }

            ;
        }
    }
}
