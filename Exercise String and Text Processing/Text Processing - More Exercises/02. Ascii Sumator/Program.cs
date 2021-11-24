using System;
using System.Linq;

namespace _02.Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstSymbol = char.Parse(Console.ReadLine());
            char secondSymbol = char.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int sum = 0;

            foreach (var symbol in input.Where(symbol => symbol > firstSymbol && symbol < secondSymbol))
            {
                int charValue = symbol;
                sum += charValue;
            }
            Console.WriteLine(sum);
        }
    }
}
