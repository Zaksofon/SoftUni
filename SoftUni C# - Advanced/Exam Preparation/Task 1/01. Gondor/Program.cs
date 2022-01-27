using System;
using System.Collections.Generic;
using System.Linq;

namespace Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            Stack<int> orcs = new Stack<int>();

            List<int> plates = new List<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            for (int i = 1; i <= waves; i++)
            {
                orcs = new Stack<int>(Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray());

                if (i % 3 == 0)
                {
                    plates.Add(int.Parse(Console.ReadLine()));
                }

                int orcWaveCount = orcs.Count;

                for (int j = 0; j < orcWaveCount; j++)
                {
                    if (plates.Count == 0)
                    {
                        break;
                    }

                    int currentOrc = orcs.Peek();
                    int currentPlate = plates.First();
                    int currentFight = Math.Abs(currentPlate - currentOrc);

                    if (currentPlate < currentOrc)
                    {
                        plates.Remove(currentPlate);
                        orcs.Pop();
                        orcs.Push(currentFight);
                    }

                    else if (currentPlate == currentOrc)
                    {
                        plates.Remove(currentPlate);
                        orcs.Pop();
                    }

                    else if (currentPlate > currentOrc)
                    {
                        orcs.Pop();
                        plates.RemoveAt(0);
                        plates.Insert(0, currentFight);
                    }
                }

                if (plates.Count == 0)
                {
                    Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                    Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
                    return;
                }
            }

            if (orcs.Count == 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
                return;
            }
        }
    }
}
