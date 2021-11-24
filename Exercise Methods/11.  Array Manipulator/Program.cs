using System;
using System.Linq;
using System.Security.Authentication;

namespace _11.__Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] parts = input.Split();

                string command = parts[0];

                if (command == "exchange")
                {
                    int index = int.Parse(parts[1]);

                    Exchange(numbers, index);
                }

                if (command == "max")
                {
                    
                }
            }
        }

        private static  void Exchange(int[] numbers, int index)
        {
            if (index < 0 || index >= numbers.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }
            for (int i = 0; i <=  index; i++)
            {
                int firstInteger = numbers[0];

                for (int j = 1; j < numbers.Length; j++)
                {
                    numbers[j - 1] = numbers[j];
                }

                numbers[numbers.Length - 1] = firstInteger;
            }
        }
    }
}
