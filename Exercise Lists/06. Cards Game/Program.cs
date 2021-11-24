using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCards = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> secondPlayerCards = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {

                if (firstPlayerCards[0] > secondPlayerCards[0])
                {
                    firstPlayerCards.Add(firstPlayerCards[0]);
                    firstPlayerCards.Add(secondPlayerCards[0]);
                    firstPlayerCards.Remove(firstPlayerCards[0]);
                    secondPlayerCards.Remove(secondPlayerCards[0]);
                }

                else if(firstPlayerCards[0] < secondPlayerCards[0])
                {
                    secondPlayerCards.Add(secondPlayerCards[0]);
                    secondPlayerCards.Add(firstPlayerCards[0]);
                    secondPlayerCards.Remove(secondPlayerCards[0]);
                    firstPlayerCards.Remove(firstPlayerCards[0]);
                }

                else if (firstPlayerCards[0] == secondPlayerCards[0])
                {
                    firstPlayerCards.Remove(firstPlayerCards[0]);
                    secondPlayerCards.Remove(secondPlayerCards[0]);
                }

                if (firstPlayerCards.Count == 0 || secondPlayerCards.Count == 0)
                {
                    break;
                }
            }
            Console.WriteLine(firstPlayerCards.Count > secondPlayerCards.Count
                ? $"First player wins! Sum: {firstPlayerCards.Sum()}"
                : $"Second player wins! Sum: {secondPlayerCards.Sum()}");
        }
    }
}
