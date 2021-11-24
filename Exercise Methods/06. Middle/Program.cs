using System;

namespace _06._Middle
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var result = GetTheMiddleCharacter(input);

            Console.WriteLine(result);
        }

        private static string GetTheMiddleCharacter(string input)
        {

            if (input.Length % 2 == 0)
            {
                return  input.Substring(input.Length / 2 - 1, 2);
            }
            else
            {
                return  input.Substring(input.Length / 2, 1);
            }
        }
    }
}
