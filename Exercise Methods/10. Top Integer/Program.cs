using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;

namespace _10._Top_Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i <= n; i++)
            {
                if (IsTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool IsTopNumber(int number)
        {
            return IsDividebleByEight(number, divider: 8) && ContainsOddDigit(number);
        }

        private static bool ContainsOddDigit(int number)
        {

            while (number != 0)
            {
                int lastDigit = number % 10;

                if (lastDigit % 2 != 0)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }

        private static bool IsDividebleByEight(int number, int divider)
        {
            int sum = 0;

            while (number != 0)
            {
                int lastDigit = number % 10;
                sum += lastDigit;

                number /= 10;
            }

            return sum % divider == 0;
        }
    }
}