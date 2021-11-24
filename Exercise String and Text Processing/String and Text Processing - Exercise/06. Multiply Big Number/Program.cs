using System;
using System.Collections.Generic;

namespace _05.Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            int multiplyer = int.Parse(Console.ReadLine());

            List<int> result = new List<int>();
            int remainder = 0;

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (multiplyer == 0)
                {
                    Console.WriteLine("0");
                    break;
                }
                int currentDigit = (numbers[i] - '0') * multiplyer;

                if (currentDigit > 9)
                {
                    for (int j = 1; j < Convert.ToString(currentDigit).Length; j++)
                    {
                        result.Add(currentDigit % 10 + remainder);
                        remainder = currentDigit / 10;
                    }
                    continue;
                }

                if (remainder == 0)
                {
                    result.Add(currentDigit);
                }

                if (remainder > 0)
                {
                    if (remainder + currentDigit - 10 < 0)
                    {
                        result.Add((remainder + currentDigit));
                        remainder = 0;
                        continue;
                    }
                    result.Add((remainder + currentDigit) - 10);
                    remainder = (remainder + currentDigit) - 10;
                }
            }

            if (remainder > 0)
            {
                result.Add(remainder);
            }

            result.Reverse();
            Console.WriteLine(String.Concat(result));

        }
    }
}
