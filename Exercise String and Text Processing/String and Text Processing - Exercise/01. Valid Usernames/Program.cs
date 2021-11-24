using System;
using System.Linq;


namespace Exercise___Strings_and_Text_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var user in usernames)
            {
                if (IsValidUsername(user))
                {
                    Console.WriteLine(user);
                }
            }
        }

        private static bool IsValidUsername(string input)
        {
            return IsValidLength(input) && IsValidSymbols(input);
        }

        private static bool IsValidSymbols(string input)
        {
            return input.All(symbol => char.IsLetterOrDigit(symbol) || symbol == '_' || symbol == '-');
        }

        private static bool IsValidLength(string input)
        {
            return input.Length >= 3 && input.Length <= 16;
        }
    }
}
