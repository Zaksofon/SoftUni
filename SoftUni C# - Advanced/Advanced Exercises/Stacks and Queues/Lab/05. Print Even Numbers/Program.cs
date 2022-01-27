using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> evenNums = new Queue<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenNums.Enqueue(numbers[i]);

                    if (numbers.Length == i + 1)
                    {
                        Console.Write(evenNums.Dequeue());
                        break;
                    }
                    Console.Write($"{evenNums.Dequeue()}, ");
                }
            }

            Console.WriteLine();
        }
    }
}