using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInTheBox = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> clothes = new Stack<int>(clothesInTheBox);

            int rackCounter = 0;
            int rackCapacityResult = rackCapacity;

            while (clothes.Count > 0)
            {
                rackCapacityResult -= clothes.Pop();

                if (clothes.Count == 0)
                {
                    rackCounter++;
                    break;
                }

                if (rackCapacityResult < clothes.Peek())
                {
                    rackCounter++;
                    rackCapacityResult = rackCapacity;
                }
            }

            Console.WriteLine(rackCounter);
        }
    }
}
