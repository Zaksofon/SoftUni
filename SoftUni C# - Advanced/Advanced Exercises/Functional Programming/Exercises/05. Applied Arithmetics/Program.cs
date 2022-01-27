using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _5.Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
               string command = Console.ReadLine();

                switch (command)
                {
                    case "add":
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbers[i]++;
                        }
                        break;

                    case "multiply":
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbers[i] *= 2;
                        }
                        break;

                    case "subtract":
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbers[i]--;
                        }
                        break;

                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;

                    case "end":
                        return;
                }
            }
        }
    }
}
