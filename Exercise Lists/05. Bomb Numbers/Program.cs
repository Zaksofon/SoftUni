using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] bombCase = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int bombPosition = bombCase[0];
            int bombPower = bombCase[1];

            while (true)
            {
                int idx = numbers.IndexOf(bombPosition);

                if (idx == -1)
                {
                    break;
                }

                int startIndex = idx - bombPower;

                if (startIndex < 0)
                {
                    startIndex = 0;
                }

                int bombRange = bombPower * 2 + 1;

                if (bombRange > numbers.Count-1 )
                {
                    bombRange = numbers.Count - startIndex;
                }

                numbers.RemoveRange(index:startIndex, bombRange);
            }

            int sum = 0;

            foreach (var element in numbers)
            {
                sum += element;
            }

            Console.WriteLine(sum);
        }
    }
}
