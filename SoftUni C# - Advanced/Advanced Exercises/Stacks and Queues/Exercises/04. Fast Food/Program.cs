using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> ordersQueue = new Queue<int>(orders);
            Console.WriteLine(ordersQueue.Max());

            int foodAmount = n;

            while (ordersQueue.Count > 0 && foodAmount > 0)
            {
                foodAmount -= ordersQueue.Dequeue();

                if (ordersQueue.Count == 0 && foodAmount >= 0)
                {
                    Console.WriteLine("Orders complete");
                    return;
                }

                if (foodAmount < ordersQueue.Peek())
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", ordersQueue)}");
                    return;
                }
            }
        }
    }
}
