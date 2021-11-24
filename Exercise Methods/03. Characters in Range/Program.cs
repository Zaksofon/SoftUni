using System;
using System.Threading;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstSymbol = char.Parse(Console.ReadLine());
            char secondSymbol = char.Parse(Console.ReadLine());

            char start = firstSymbol;
            char end = secondSymbol;

            if (secondSymbol < firstSymbol)
            {
                start = secondSymbol;
                end = firstSymbol;
            }
             GetCharactersInRange(start, end);
        }

        private static void GetCharactersInRange(char start, char end)
        {
            for (int i = (char) start + 1; i < end; i++)
            {
                char result = Convert.ToChar(i);

                Console.Write($"{result} ");
            }
        }
    }
}
