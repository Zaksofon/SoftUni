using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    class Program
    {
        private const int WREATHS_TARGET = 5;
        private const int FLOWERS_NEEDED_FOR_ONE_WREATHS = 15;
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int reserveFlowers = 0;
            int wreathsCount = 0;

            while (lilies.Count != 0 && roses.Count != 0)
            {
                int currentWreath = lilies.Peek() + roses.Peek();

                if (currentWreath == FLOWERS_NEEDED_FOR_ONE_WREATHS)
                {
                    wreathsCount++;
                    lilies.Pop();
                    roses.Dequeue();
                }

                else if (currentWreath > FLOWERS_NEEDED_FOR_ONE_WREATHS)
                {
                    lilies.Push(lilies.Pop() - 2);
                }

                else if (currentWreath < FLOWERS_NEEDED_FOR_ONE_WREATHS)
                {
                    reserveFlowers += currentWreath;
                    lilies.Pop();
                    roses.Dequeue();
                }
            }
            
            if (reserveFlowers != 0)
            {
                wreathsCount += reserveFlowers / FLOWERS_NEEDED_FOR_ONE_WREATHS;
            }

            if (wreathsCount >= WREATHS_TARGET)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCount} wreaths!");
            }

            else
            {
                int wreathsToAccomplish = WREATHS_TARGET - wreathsCount;
                Console.WriteLine($"You didn't make it, you need {wreathsToAccomplish} wreaths more!");
            }
        }
    }
}
