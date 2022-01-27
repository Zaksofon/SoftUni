using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> numSequence = new Dictionary<int, int>(n);

            for (int i = 0; i < n; i++)
            {
                int numbers = int.Parse(Console.ReadLine());

                if (!numSequence.ContainsKey(numbers))
                {
                    numSequence.Add(numbers, 1);
                    continue;
                }
                numSequence[numbers]++;
            }

            numSequence = numSequence
                .Where(key => key.Value % 2 == 0)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var kvp in numSequence)
            {
                Console.WriteLine(kvp.Key);
            }
        }
    }
}
