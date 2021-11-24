using System;

namespace _02.Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            string firstString = input[0];
            string secondString = input[1];

            int result = 0;

            string newFirst = "";
            string newSecond = "";

            for (int i = 0; i < Math.Min(firstString.Length, secondString.Length); i++)
            {
                result += firstString[i] * secondString[i]; 

                newFirst = firstString.Remove(0, 1 + i);
                newSecond = secondString.Remove(0, 1 + i);
            }

            if (newFirst.Length == 0 || newSecond.Length == 0)
            {
                string remainingSymbols = newFirst + newSecond;

                foreach (var symbol in remainingSymbols)
                {
                    result += symbol;
                }
            }
            Console.WriteLine(result);
        }
    }
}
