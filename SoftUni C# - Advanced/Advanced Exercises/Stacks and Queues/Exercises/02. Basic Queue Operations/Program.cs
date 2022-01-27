using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] operations = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbersQueue = new Queue<int>(numbers);

            int toDequeue = operations[1];
            int toPeek = operations[2];

            for (int i = 0; i < toDequeue; i++)
            {
                numbersQueue.Dequeue();
            }

            if (numbersQueue.Contains(toPeek))
            {
                Console.WriteLine("true");
                return;
            }

            if (!numbersQueue.Contains(toPeek) && numbersQueue.Count != 0)
            {
                Console.WriteLine(numbersQueue.Min());
                return;
            }

            if (numbersQueue.Count == 0)
            {
                Console.WriteLine("0");
            }
        }
    }
}