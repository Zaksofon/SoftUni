using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> firstSet = new HashSet<int>(lengths[0]);
            HashSet<int> secondSet = new HashSet<int>(lengths[1]);

            HashSet<int> result = new HashSet<int>();

            for (int i = 0; i < lengths[0]; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                firstSet.Add(numbers);
            }

            for (int j = 0; j < lengths[1]; j++)
            {
                int numbers = int.Parse(Console.ReadLine());
                secondSet.Add(numbers);
            }

            foreach (var number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    result.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
