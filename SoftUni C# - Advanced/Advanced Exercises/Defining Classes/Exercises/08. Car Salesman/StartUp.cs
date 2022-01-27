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

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] inputN = Console.ReadLine()
                    .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                string engineModel = inputN[0];
                int enginePower = int.Parse(inputN[1]);
                int engineDisplacement = 0;
                string engineEfficiency = "";

                if (inputN.Length == 3 )
                {
                    if (int.TryParse(inputN[2], out engineDisplacement))
                    {
                         engineDisplacement = int.Parse(inputN[2]);
                    }
                    else
                    {
                        engineEfficiency = inputN[2];
                    }
                }
                else if (inputN.Length == 4)
                {
                    engineDisplacement = int.Parse(inputN[2]);
                    engineEfficiency = inputN[3];
                }

                Engine engine = new Engine(engineModel, enginePower, engineDisplacement, engineEfficiency);
                engines.Add(new Engine(engineModel, enginePower, engineDisplacement, engineEfficiency));
            }

            int m = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] inputM = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string model = inputM[0];
                string engine = inputM[1];
                int weight = 0;
                string color = "";

                if (inputM.Length == 3)
                {
                    if (int.TryParse(inputM[2], out weight))
                    {
                        weight = int.Parse(inputM[2]);
                    }
                    else
                    {
                        color = inputM[2];
                    }
                }
                else if (inputM.Length == 4)
                {
                    weight = int.Parse(inputM[2]);
                    color = inputM[3];
                }

                Car car = new Car(model, engines.Find(e => e.Model == engine), weight, color);
                cars.Add(new Car(model, engines.Find(e => e.Model == engine), weight, color));
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine(car.Engine.Displacement == 0
                    ? $"    Displacement: n/a"
                    : $"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine(car.Engine.Efficiency == ""
                    ? $"    Efficiency: n/a"
                    : $"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine(car.Weight == 0
                    ? $"  Weight: n/a"
                    : $"  Weight: {car.Weight}");
                Console.WriteLine(car.Color == ""
                    ? $"  Color: n/a"
                    : $"  Color: {car.Color}");
            }
        }
    }
}
