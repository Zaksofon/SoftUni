using System;
using System.Linq;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "nd")
                {
                    break;
                }

                bool isPalendrom = CheckIfInputIsPalendrom(input);

                if (isPalendrom)
                {
                    Console.WriteLine(true);
                }
                else
                {
                    Console.WriteLine(false);
                }
            }
        }

        private static bool CheckIfInputIsPalendrom(string input)
        {

            for (int i = 0; i < input.Length / 2 && input.Length != 0; i++)
            {
                if (input[i] != input[input.Length - i - 1])
                {
                    return false;
                    break;
                }
            }

            return true;
        }
    }
}
